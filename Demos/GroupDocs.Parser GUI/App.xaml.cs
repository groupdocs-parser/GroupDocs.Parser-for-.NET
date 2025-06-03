using GroupDocs.Parser.Gui.Utils;
using GroupDocs.Parser.Gui.ViewModels;
using GroupDocs.Parser.Gui.XmlStorage;
using System;
using System.IO;
using System.Windows;

namespace GroupDocs.Parser.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string RootElementName = "Root";

    private MainWindow mainWindow;
    private MainViewModel mainViewModel;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var settings = LoadSettings();

        mainViewModel = new MainViewModel(settings);

        mainWindow = new MainWindow();
        mainWindow.PercentagePositionChanged += OnPercentagePositionChanged;
        mainWindow.DataContext = mainViewModel;
        App.Current.MainWindow = mainWindow;
        mainWindow.Show();
    }

    private void OnPercentagePositionChanged(object sender, Controls.PercentagePositionEventArgs e)
    {
        mainViewModel.SetPercentagePosition(e.PercentagePosition);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        SaveSettings(mainViewModel.Settings);
    }

    private void SaveSettings(Settings settings)
    {
        try
        {
            var doc = new XmlDocumentWriter();
            var rootWriter = doc.CreateRootWriter(RootElementName);

            settings.Save(rootWriter);

            FileHelper.EnsureFolderExists(Constants.SettingsFilePath);
            doc.Save(Constants.SettingsFilePath);
        }
        catch (Exception)
        {
        }
    }

    private Settings LoadSettings()
    {
        var settings = new Settings();
        try
        {
            FileHelper.EnsureFolderExists(Constants.SettingsFilePath);
            if (File.Exists(Constants.SettingsFilePath))
            {
                var doc = new XmlDocumentReader(Constants.SettingsFilePath);
                var rootReader = doc.GetRootReader(RootElementName);

                settings.Load(rootReader);
            }
        }
        catch (Exception)
        {
        }
        return settings;
    }
}
