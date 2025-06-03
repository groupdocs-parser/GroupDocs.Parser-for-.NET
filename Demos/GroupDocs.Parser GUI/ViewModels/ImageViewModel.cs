using System.Windows.Media.Imaging;

namespace GroupDocs.Parser.Gui.ViewModels
{
    class ImageViewModel : ViewModelBase, IPageElement
    {
        private readonly BitmapImage bitmapImage;
        private double scale;

        public ImageViewModel(
            BitmapImage bitmapImage,
            double scale)
        {
            this.bitmapImage = bitmapImage;
            this.scale = scale;
        }

        public BitmapImage BitmapImage => bitmapImage;

        public double Scale
        {
            get => scale;
            set
            {
                if (UpdateProperty(ref scale, value))
                {
                    NotifyPropertyChanged(nameof(Width));
                }
            }
        }

        public double OriginalX => 0;

        public double OriginalY => 0;

        public double OriginalWidth => bitmapImage.Width;

        public double OriginalHeight => bitmapImage.Height;

        public double X => 0;

        public double Y => 0;

        public double Width => bitmapImage.Width * scale;

        public double Height => bitmapImage.Height * scale;

        public PageElementType ElementType => PageElementType.Image;

        public string Name => string.Empty;
    }
}
