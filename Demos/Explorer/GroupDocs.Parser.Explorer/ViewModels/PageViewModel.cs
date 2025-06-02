using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class PageViewModel : ViewModelBase
    {
        private readonly int pageIndex;
        private readonly ObservableCollection<IPageElement> objects = new ObservableCollection<IPageElement>();
        private ImageViewModel imageViewModel;

        public PageViewModel(
            int pageIndex,
            BitmapImage bitmapImage,
            double scale)
        {
            this.pageIndex = pageIndex;
            imageViewModel = new ImageViewModel(bitmapImage, scale);
            objects.Add(imageViewModel);
        }

        public int PageIndex => pageIndex;

        public ObservableCollection<IPageElement> Objects => objects;

        public double Scale
        {
            get => imageViewModel.Scale;
            set
            {
                if (imageViewModel.Scale != value)
                {
                    foreach (IPageElement element in objects)
                    {
                        element.Scale = value;
                    }
                    NotifyPropertyChanged(nameof(Scale));
                    NotifyPropertyChanged(nameof(Width));
                    NotifyPropertyChanged(nameof(Height));
                }
            }
        }

        public double Width => imageViewModel.Width;

        public double Height => imageViewModel.Height;

        public double OriginalWidth => imageViewModel.OriginalWidth;

        public double OriginalHeight => imageViewModel.OriginalHeight;
    }
}
