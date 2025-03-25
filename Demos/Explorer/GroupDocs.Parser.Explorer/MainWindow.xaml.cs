using GroupDocs.Parser.Explorer.Controls;
using System;
using System.Windows;

namespace GroupDocs.Parser.Explorer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public event EventHandler<PercentagePositionEventArgs> PercentagePositionChanged;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CustomScrollViewer_PercentagePositionChanged(object sender, PercentagePositionEventArgs e)
    {
        PercentagePositionChanged?.Invoke(this, e);
    }
}