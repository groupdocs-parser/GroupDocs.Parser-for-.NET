using GroupDocs.Parser.Gui.Utils;
using System.Windows;
using System.Windows.Controls;

namespace GroupDocs.Parser.Gui.ViewModels
{
    class SeparatorViewModel : ViewModelBase
    {
        private readonly TableViewModel host;
        private double position;
        private double scale;

        private bool isMouseDown;
        private double oldPosition;
        private Point startMovePoint;

        public RelayCommand<MouseArguments> MouseDownCommand { get; private set; }
        public RelayCommand<MouseArguments> MouseMoveCommand { get; private set; }
        public RelayCommand<MouseArguments> MouseUpCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }

        public SeparatorViewModel(
            TableViewModel host,
            double position,
            double scale)
        {
            this.host = host;
            this.host.HeightChanged += OnHostHeightChanged;
            this.host.VisibilityChanged += OnHostVisibilityChanged;

            this.position = position;
            this.scale = scale;

            MouseDownCommand = new RelayCommand<MouseArguments>(OnMouseDown);
            MouseMoveCommand = new RelayCommand<MouseArguments>(OnMouseMove);
            MouseUpCommand = new RelayCommand<MouseArguments>(OnMouseUp);
            RemoveCommand = new RelayCommand(OnRemove);
        }

        private void OnHostHeightChanged()
        {
            NotifyPropertyChanged(nameof(Height));
        }

        private void OnHostVisibilityChanged()
        {
            NotifyPropertyChanged(nameof(Visibility));
        }

        private void OnMouseDown(MouseArguments args)
        {
            isMouseDown = true;
            oldPosition = position;
            startMovePoint = args.Point;
        }

        private void OnMouseMove(MouseArguments args)
        {
            if (isMouseDown)
            {
                ChangePosition(args);
            }
        }

        private void OnMouseUp(MouseArguments args)
        {
            isMouseDown = false;
            ChangePosition(args);
        }

        private void OnRemove()
        {
            host.Remove(this);
        }

        private void ChangePosition(MouseArguments args)
        {
            double newPosition = oldPosition + (args.Point.X - startMovePoint.X);
            Position = newPosition;
        }

        public double Height => host.Height;

        public Visibility Visibility => host.Visibility;

        public double OriginalPosition => position;

        public double Position
        {
            get => position * scale;
            set
            {
                position = value / scale;
                NotifyPropertyChanged(nameof(Position));
            }
        }

        public double Scale
        {
            get => scale;
            set
            {
                if (UpdateProperty(ref scale, value))
                {
                    NotifyPropertyChanged(string.Empty);
                }
            }
        }
    }
}
