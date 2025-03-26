using GroupDocs.Parser.Data;
using GroupDocs.Parser.Explorer.Utils;
using GroupDocs.Parser.Options;
using GroupDocs.Parser.Templates;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static GroupDocs.Parser.Options.PreviewOptions;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private const int MaxLogItemCount = 1000;
        private const int Dpi = 144;

        private int fieldCounter;

        private readonly string tempFolder;
        private bool windowEnabled = true;
        private readonly ObservableCollection<LogItemViewModel> log = new ObservableCollection<LogItemViewModel>();
        private LogItemViewModel selectedLogItem;
        private double percentagePosition;

        private readonly Settings settings;
        private readonly string version;

        private double scale = 1.0;

        private string filePath = string.Empty;
        private ObservableCollection<string> pagePaths = new ObservableCollection<string>();
        private ObservableCollection<PageViewModel> pageImages = new ObservableCollection<PageViewModel>();

        public RelayCommand SetLicenseCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }
        public RelayCommand ZoomInCommand { get; private set; }
        public RelayCommand ZoomOutCommand { get; private set; }
        public RelayCommand AddTextFieldCommand { get; private set; }
        public RelayCommand ParseCommand { get; private set; }

        public MainViewModel(Settings settings)
        {
            tempFolder = Path.Combine(Path.GetTempPath(), "ParserExplorer");
            Directory.CreateDirectory(tempFolder);

            this.settings = settings;

            version = new LoadOptions().GetType().Assembly.GetName().Version.ToString(3);

            SetLicenseCommand = new RelayCommand(OnSetLicense);
            OpenFileCommand = new RelayCommand(OnOpenFile);
            ZoomInCommand = new RelayCommand(OnZoomIn);
            ZoomOutCommand = new RelayCommand(OnZoomOut);
            AddTextFieldCommand = new RelayCommand(OnAddTextField);
            ParseCommand = new RelayCommand(OnParseAsync);

            Init();
        }

        public bool WindowEnabled
        {
            get { return windowEnabled; }
            set { UpdateProperty(ref windowEnabled, value); }
        }

        public string Title => "GroupDocs.Parser.Explorer " + version;

        public Settings Settings => settings;

        public double Scale
        {
            get => scale;
            set
            {
                if (UpdateProperty(ref scale, value))
                {
                    NotifyPropertyChanged(nameof(ScaleText));
                    foreach (var page in pageImages)
                    {
                        page.Scale = scale;
                    }
                }
            }
        }

        public string ScaleText => Math.Round(scale * 100) + "%";

        public string FilePath
        {
            get => filePath;
            set => UpdateProperty(ref filePath, value);
        }

        public ObservableCollection<string> PagePaths
        {
            get => pagePaths;
            set
            {
                if (UpdateProperty(ref pagePaths, value))
                {
                    var images = new ObservableCollection<PageViewModel>();
                    for (int i = 0; i < pagePaths.Count; i++)
                    {
                        var pagePath = pagePaths[i];
                        var image = new BitmapImage(new Uri(pagePath));
                        image.Freeze();
                        var page = new PageViewModel(i, image, Scale);
                        images.Add(page);
                    }
                    PageImages = images;
                }
            }
        }

        public ObservableCollection<PageViewModel> PageImages
        {
            get => pageImages;
            set => UpdateProperty(ref pageImages, value);
        }

        public ObservableCollection<LogItemViewModel> Log => log;

        public LogItemViewModel SelectedLogItem
        {
            get { return selectedLogItem; }
            set { UpdateProperty(ref selectedLogItem, value); }
        }

        public void SetPercentagePosition(double percentagePosition)
        {
            this.percentagePosition = percentagePosition;
        }

        public void AddLogEntry(DateTime time, string message)
        {
            var item = new LogItemViewModel(time, message);
            AddLogEntryPrivate(item);

            SelectedLogItem = item;
        }

        public void AddLogEntry(string message)
        {
            AddLogEntry(DateTime.Now, message);
        }

        private void AddLogEntryPrivate(LogItemViewModel item)
        {
            Action action = () =>
            {
                while (Log.Count >= MaxLogItemCount)
                {
                    Log.RemoveAt(0);
                }

                Log.Add(item);
            };

            var dispatcher = System.Windows.Application.Current.Dispatcher;
            if (!dispatcher.CheckAccess())
            {
                dispatcher.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        private async void Init()
        {
            var result = await SetLicense();
            if (!result)
            {
                AddLogEntry("License is not set");
            }
        }

        private async Task<bool> SetLicense()
        {
            WindowEnabled = false;
            try
            {
                var licensePath = Settings.LicensePath;
                if (!string.IsNullOrWhiteSpace(licensePath))
                {
                    AddLogEntry("Setting a license: " + licensePath);

                    await Task.Factory.StartNew(() =>
                    {
                        var license = new License();
                        license.SetLicense(licensePath);
                    });

                    AddLogEntry("The license is set");
                    return true;
                }
                return false;
            }
            finally
            {
                WindowEnabled = true;
            }
        }
        private async void OnSetLicense()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog(App.Current.MainWindow) == true)
            {
                var path = openFileDialog.FileName;
                Settings.LicensePath = path;

                await SetLicense();
            }
        }

        private async void OnOpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select a document";
            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
                AddLogEntry("Opened a file: " + FilePath);
                await GeneratePreviewAsync();
            }
        }

        private void OnZoomIn()
        {
            double newValue = Scale + 0.1;
            if (newValue > 3.0)
            {
                newValue = 3.0;
            }
            Scale = newValue;
        }

        private void OnZoomOut()
        {
            double newValue = Scale - 0.1;
            if (newValue < 0.1)
            {
                newValue = 0.1;
            }
            Scale = newValue;
        }

        private void OnAddTextField()
        {
            if (pageImages == null || pageImages.Count == 0)
            {
                return;
            }

            int pageIndex = (int)(percentagePosition * pageImages.Count + 0.7);
            if (pageIndex < 0)
            {
                return;
            }

            if (pageIndex >= pageImages.Count)
            {
                pageIndex = pageImages.Count - 1;
            }

            var page = pageImages[pageIndex];
            fieldCounter++;
            int fieldNumber = fieldCounter;
            var fieldName = "Field" + fieldNumber.ToString(CultureInfo.InvariantCulture);
            var field = new FieldViewModel(10, 10, 80, 40, Scale, fieldName);
            page.Objects.Add(field);
        }

        private async void OnParseAsync()
        {
            AddLogEntry("Started parsing by template.");
            Task task = Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(FilePath))
                {
                    return;
                }

                double factor = 1;//72 / Dpi;
                var templateItems = new List<TemplateItem>();
                foreach (var page in PageImages)
                {
                    foreach (var pageElement in page.Objects)
                    {
                        switch (pageElement.ElementType)
                        {
                            case PageElementType.TextField:
                                var templateField = new TemplateField(
                                    new TemplateFixedPosition(
                                        new Rectangle(
                                            new Point(pageElement.X * factor, pageElement.Y * factor),
                                            new Size(pageElement.Width * factor, pageElement.Height * factor))),
                                    pageElement.Name,
                                    page.PageIndex);
                                templateItems.Add(templateField);
                                break;
                        }
                    }
                }

                Template template = new Template(templateItems);

                using (Parser parser = new Parser(FilePath))
                {
                    DocumentData data = parser.ParseByTemplate(template);

                    for (int i = 0; i < data.Count; i++)
                    {
                        AddLogEntry(data[i].Name + ": " + data[i].Text);
                    }
                }
            });
            await task;
            AddLogEntry("Parsing by template is completed.");
        }

        private async Task GeneratePreviewAsync()
        {
            AddLogEntry("Started generating preview.");
            Task task = Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(FilePath))
                {
                    return;
                }

                var folderName = Path.GetFileName(FilePath).Replace('.', '_');
                var folderPath = Path.Combine(tempFolder, folderName);
                ClearFolder(folderPath);

                var paths = new ObservableCollection<string>();
                using (Parser parser = new Parser(FilePath))
                {
                    PreviewOptions previewOptions = new PreviewOptions(
                        pageNumber =>
                        {
                            var imagePath = GetOutputPath(folderPath, $"preview_{pageNumber}.png");
                            paths.Add(imagePath);
                            var stream = File.Create(imagePath);
                            return stream;
                        });
                    previewOptions.PreviewFormat = PreviewFormats.PNG;
                    previewOptions.Dpi = Dpi;
                    parser.GeneratePreview(previewOptions);
                }
                PagePaths = paths;
            });
            await task;
            AddLogEntry("Generating preview is completed.");
        }

        private void ClearFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    var files = Directory.GetFiles(folderPath);
                    foreach (var file in files)
                    {
                        File.Delete(file);
                    }
                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception e)
            {
                AddLogEntry(e.ToString());
            }
        }

        private string GetOutputPath(string folder, string fileName)
        {
            return Path.Combine(folder, fileName);
        }
    }
}
