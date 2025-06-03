using GroupDocs.Parser.Gui.XmlStorage;
using System.Windows;

namespace GroupDocs.Parser.Gui
{
    class Settings
    {
        private const string WindowStateKey = "WindowState";
        private const string HeightKey = "Height";
        private const string WidthKey = "Width";
        private const string LeftKey = "Left";
        private const string TopKey = "Top";

        private const string LicensePathKey = "LicensePath";

        private const WindowState WindowStateDefault = WindowState.Normal;
        private const double HeightDefault = 600;
        private const double WidthDefault = 800;
        private const double LeftDefault = 0;
        private const double TopDefault = 0;

        private static readonly string LicensePathDefault = string.Empty;

        public Settings()
        {
            WindowState = WindowStateDefault;
            Height = HeightDefault;
            Width = WidthDefault;
            Left = LeftDefault;
            Top = TopDefault;

            LicensePath = LicensePathDefault;
        }

        public WindowState WindowState { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }

        public string LicensePath { get; set; }

        public void Save(XmlWriter writer)
        {
            writer.Write(WindowStateKey, (int)WindowState);
            writer.Write(HeightKey, Height);
            writer.Write(WidthKey, Width);
            writer.Write(LeftKey, Left);
            writer.Write(TopKey, Top);

            writer.Write(LicensePathKey, LicensePath);
        }

        public void Load(XmlReader reader)
        {
            WindowState = (WindowState)reader.Read(WindowStateKey, (int)WindowStateDefault);
            Height = reader.Read(HeightKey, HeightDefault);
            Width = reader.Read(WidthKey, WidthDefault);
            Left = reader.Read(LeftKey, LeftDefault);
            Top = reader.Read(TopKey, TopDefault);

            LicensePath = reader.Read(LicensePathKey, LicensePathDefault);
        }
    }
}
