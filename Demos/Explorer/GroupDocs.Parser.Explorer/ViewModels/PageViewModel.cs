using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class PageViewModel : ViewModelBase
    {
        private readonly ObservableCollection<IPageElement> objects = new ObservableCollection<IPageElement>();
        private ImageViewModel imageViewModel;

        public PageViewModel(
            BitmapImage bitmapImage,
            double scale)
        {
            imageViewModel = new ImageViewModel(bitmapImage, scale);
            objects.Add(imageViewModel);
        }

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
    }
}
