using System.Windows.Media.Imaging;

namespace GroupDocs.Parser.Explorer.ViewModels
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

        public double X => 0;

        public double Y => 0;

        public double Width => bitmapImage.Width * scale;

        public double Height => bitmapImage.Height * scale;
    }
}
