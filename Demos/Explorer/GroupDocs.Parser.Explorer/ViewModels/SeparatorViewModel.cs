using GroupDocs.Parser.Explorer.Utils;
using System.Windows;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class SeparatorViewModel : ViewModelBase
    {
        private readonly TableViewModel host;
        private double position;

        private bool isMouseDown;
        private double oldPosition;
        private Point startMovePoint;

        public RelayCommand<MouseArguments> MouseDownCommand { get; private set; }
        public RelayCommand<MouseArguments> MouseMoveCommand { get; private set; }
        public RelayCommand<MouseArguments> MouseUpCommand { get; private set; }
        public RelayCommand RemoveCommand { get; private set; }

        public SeparatorViewModel(
            TableViewModel host,
            double position)
        {
            this.host = host;
            this.host.HeightChanged += OnHostHeightChanged;
            this.host.VisibilityChanged += OnHostVisibilityChanged;

            this.position = position;

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

        public double Position
        {
            get => position;
            set => UpdateProperty(ref position, value);
        }
    }
}
