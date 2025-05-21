using System.Windows.Media.Imaging;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class ImageViewModel : ViewModelBase, IPageElement
    {
        private readonly BitmapImage bitmapImage;
        private double factor;
        private double scale;

        public ImageViewModel(
            BitmapImage bitmapImage,
            double factor,
            double scale)
        {
            this.bitmapImage = bitmapImage;
            this.factor = factor;
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

        public double OriginalWidth => bitmapImage.Width * factor;

        public double OriginalHeight => bitmapImage.Height * factor;

        public double X => 0;

        public double Y => 0;

        public double Width => bitmapImage.Width * factor * scale;

        public double Height => bitmapImage.Height * factor * scale;

        public PageElementType ElementType => PageElementType.Image;

        public string Name => string.Empty;
    }
}
