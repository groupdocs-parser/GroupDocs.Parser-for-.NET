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
using System.Xml.Linq;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class MainViewModel : ViewModelBase, ISelectedFieldHost
    {
        private const int MaxLogItemCount = 1000;
        private const int Dpi = 144;

        private int fieldCounter;

        private bool windowEnabled = true;
        private readonly ObservableCollection<LogItemViewModel> log = new ObservableCollection<LogItemViewModel>();
        private LogItemViewModel selectedLogItem;
        private double percentagePosition;

        private readonly Settings settings;
        private readonly string version;

        private double scale = 1.0;

        private string filePath = string.Empty;
        private ObservableCollection<PageViewModel> pages = new ObservableCollection<PageViewModel>();
        private readonly ObservableCollection<FieldViewModel> fields = new ObservableCollection<FieldViewModel>();

        private FieldViewModel selectedField;

        public RelayCommand SetLicenseCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }
        public RelayCommand ZoomInCommand { get; private set; }
        public RelayCommand ZoomOutCommand { get; private set; }
        public RelayCommand AddTextFieldCommand { get; private set; }
        public RelayCommand ParseFieldsCommand { get; private set; }
        public RelayCommand ParseDocumentCommand { get; private set; }
        public RelayCommand SaveTemplatesCommand { get; private set; }
        public RelayCommand LoadTemplatesCommand { get; private set; }
        public RelayCommand SaveResultsCommand { get; private set; }

        public MainViewModel(Settings settings)
        {
            this.settings = settings;

            version = new Options.LoadOptions().GetType().Assembly.GetName().Version.ToString(3);

            SetLicenseCommand = new RelayCommand(OnSetLicense);
            OpenFileCommand = new RelayCommand(OnOpenFile);
            ZoomInCommand = new RelayCommand(OnZoomIn);
            ZoomOutCommand = new RelayCommand(OnZoomOut);
            AddTextFieldCommand = new RelayCommand(OnAddTextField);
            ParseFieldsCommand = new RelayCommand(OnParseFieldsAsync);
            ParseDocumentCommand = new RelayCommand(OnParseDocumentAsync);
            SaveTemplatesCommand = new RelayCommand(OnSaveTemplates);
            LoadTemplatesCommand = new RelayCommand(OnLoadTemplates);
            SaveResultsCommand = new RelayCommand(OnSaveResults);

            Init();
        }

        public bool WindowEnabled
        {
            get => windowEnabled;
            set => UpdateProperty(ref windowEnabled, value);
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
                    foreach (var page in pages)
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

        public ObservableCollection<PageViewModel> Pages
        {
            get => pages;
            set => UpdateProperty(ref pages, value);
        }

        public ObservableCollection<FieldViewModel> Fields => fields;

        public FieldViewModel SelectedField
        {
            get => selectedField;
            set
            {
                if (selectedField != value)
                {
                    if (selectedField != null)
                    {
                        selectedField.IsSelected = false;
                    }
                    selectedField = value;
                    if (selectedField != null)
                    {
                        selectedField.IsSelected = true;
                    }
                    NotifyPropertyChanged(nameof(SelectedField));
                }
            }
        }

        public ObservableCollection<LogItemViewModel> Log => log;

        public LogItemViewModel SelectedLogItem
        {
            get => selectedLogItem;
            set => UpdateProperty(ref selectedLogItem, value);
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

        private void OnOpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select a document";
            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
                AddLogEntry("Opened a file: " + FilePath);
                GeneratePreview();
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
            if (pages == null || pages.Count == 0)
            {
                return;
            }

            int pageIndex = (int)(percentagePosition * pages.Count + 0.7);
            if (pageIndex < 0)
            {
                return;
            }

            if (pageIndex >= pages.Count)
            {
                pageIndex = pages.Count - 1;
            }

            var page = pages[pageIndex];
            fieldCounter++;
            int fieldNumber = fieldCounter;
            var fieldName = "Field" + fieldNumber.ToString(CultureInfo.InvariantCulture);
            var field = new FieldViewModel(this, 10, 10, 80, 40, Scale, fieldName);
            AddField(page, field);
        }

        private void AddField(PageViewModel page, FieldViewModel field)
        {
            page.Objects.Add(field);
            fields.Add(field);
        }

        private async void OnParseFieldsAsync()
        {
            AddLogEntry("Started parsing by template.");
            Task task = Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(FilePath))
                {
                    return;
                }

                Template template = GetTemplate(108.0 / Dpi, 0, 0);
                using (Parser parser = new Parser(FilePath))
                {
                    var options = new ParseByTemplateOptions(true);
                    DocumentData data = parser.ParseByTemplate(template, options);

                    ClearParsedText();
                    for (int i = 0; i < data.Count; i++)
                    {
                        var fieldData = data[i];
                        SetParsedText(fieldData);
                        AddLogEntry(fieldData.Name + ": " + fieldData.Text);
                    }
                }
            });
            await task;
            AddLogEntry("Parsing by template is completed.");
        }

        private Template GetTemplate(double factor, double offsetX, double offsetY)
        {
            var templateItems = new List<TemplateItem>();
            foreach (var page in Pages)
            {
                foreach (var pageElement in page.Objects)
                {
                    switch (pageElement.ElementType)
                    {
                        case PageElementType.TextField:
                            var templateField = new TemplateField(
                                new TemplateFixedPosition(
                                    new Rectangle(
                                        new Point(
                                            offsetX + pageElement.X * factor,
                                            offsetY + pageElement.Y * factor),
                                        new Size(
                                            pageElement.Width * factor,
                                            pageElement.Height * factor))),
                                pageElement.Name,
                                page.PageIndex,
                                false);
                            templateItems.Add(templateField);
                            break;
                    }
                }
            }
            Template template = new Template(templateItems);
            return template;
        }

        private void ClearParsedText()
        {
            Action action = () =>
            {
                foreach (var field in Fields)
                {
                    field.Text = string.Empty;
                }
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
        private void SetParsedText(FieldData fieldData)
        {
            Action action = () =>
            {
                foreach (var field in Fields)
                {
                    if (field.Name == fieldData.Name)
                    {
                        field.Text = fieldData.Text;
                        break;
                    }
                }
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

        private async void OnParseDocumentAsync()
        {
            AddLogEntry("Started parsing the document.");
            Task task = Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(FilePath))
                {
                    return;
                }

                var dialog = new SaveFileDialog();
                dialog.FileName = "Document";
                dialog.DefaultExt = ".txt";
                dialog.Filter = "Text documents (.txt)|*.txt";

                var result = dialog.ShowDialog();
                if (result == true)
                {
                    string filePath = dialog.FileName;

                    using (Parser parser = new Parser(FilePath))
                    {
                        var options = new TextOptions(false, true);
                        var reader = parser.GetText(options);
                        using (var writer = File.CreateText(filePath))
                        {
                            while (true)
                            {
                                string line = reader.ReadLine();
                                if (line == null)
                                {
                                    break;
                                }

                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            });
            await task;
            AddLogEntry("Parsing the document is completed.");
        }

        private void OnSaveTemplates()
        {
            Template template = GetTemplate(1, 0, 0);

            var dialog = new SaveFileDialog();
            dialog.FileName = "Templates";
            dialog.DefaultExt = ".xml";
            dialog.Filter = "Templates (.xml)|*.xml";

            var result = dialog.ShowDialog();
            if (result == true)
            {
                AddLogEntry("Saved a file: " + dialog.FileName);
                template.Save(dialog.FileName);
            }
        }

        private void OnLoadTemplates()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select template file";
            if (dialog.ShowDialog() == true)
            {
                AddLogEntry("Opened a file: " + dialog.FileName);
                ApplayTemplates(dialog.FileName);
            }
        }

        private void OnSaveResults()
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "Results";
            dialog.DefaultExt = ".xml";
            dialog.Filter = "Results (.xml)|*.xml";

            var result = dialog.ShowDialog();
            if (result == true)
            {
                AddLogEntry("Saved a file: " + dialog.FileName);
                SaveParsingResults(dialog.FileName);
            }
        }

        private void SaveParsingResults(string fileName)
        {
            XElement fieldsElement = new XElement("fields");
            foreach (var field in fields)
            {
                XElement fieldElement = new XElement("field", field.Text);
                XAttribute nameAttr = new XAttribute("name", field.Name);
                fieldElement.Add(nameAttr);
                fieldsElement.Add(fieldElement);
            }
            XDocument xdoc = new XDocument();
            xdoc.Add(fieldsElement);
            xdoc.Save(fileName);
        }

        private void ApplayTemplates(string filePath)
        {
            Template template = Template.Load(filePath);
            ClearTemplate();
            foreach (TemplateField templateField in template)
            {
                var position = templateField.Position as TemplateFixedPosition;
                var field = new FieldViewModel(
                    this,
                    position.Rectangle.Left,
                    position.Rectangle.Top,
                    position.Rectangle.Size.Width,
                    position.Rectangle.Size.Height,
                    Scale,
                    templateField.Name);
                if (pages.Count > templateField.PageIndex)
                {
                    var page = pages[templateField.PageIndex.Value];
                    AddField(page, field);
                }
            }
        }

        private void ClearTemplate()
        {
            Fields.Clear();
            SelectedField = null;
            foreach (var page in pages)
            {
                for (int i = page.Objects.Count - 1; i >= 0; i--)
                {
                    if (page.Objects[i] is FieldViewModel)
                    {
                        page.Objects.RemoveAt(i);
                    }
                }
            }
        }

        private void GeneratePreview()
        {
            AddLogEntry("Started generating preview.");

            if (string.IsNullOrEmpty(FilePath))
            {
                return;
            }

            using (Parser parser = new Parser(FilePath))
            {
                var info = parser.GetDocumentInfo();
                PagePreviewOptions options = new PagePreviewOptions(PagePreviewFormat.Png, Dpi);
                Clear();
                for (int pageIndex = 0; pageIndex < info.PageCount; pageIndex++)
                {
                    var stream = parser.GetPagePreview(pageIndex, options);
                    if (stream != null)
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        var page = new PageViewModel(pageIndex, bitmap, Scale);
                        Pages.Add(page);
                    }
                }
            }

            AddLogEntry("Generating preview is completed.");
        }

        private void Clear()
        {
            Pages.Clear();
            Fields.Clear();
            SelectedField = null;
        }

        public void Remove(FieldViewModel field)
        {
            if (SelectedField == field)
            {
                SelectedField = null;
            }
            foreach (var page in pages)
            {
                page.Objects.Remove(field);
            }
            fields.Remove(field);
        }
    }
}
