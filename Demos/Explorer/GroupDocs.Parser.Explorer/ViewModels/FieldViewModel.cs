using GroupDocs.Parser.Explorer.Utils;
using System;
using System.Windows;

namespace GroupDocs.Parser.Explorer.ViewModels
{
    class FieldViewModel : ViewModelBase, IPageElement
    {
        private static readonly Point MinSize = new Point(5, 5);

        private readonly ISelectedFieldHost selectedFieldHost;
        private double x;
        private double y;
        private double width;
        private double height;
        private double scale;
        private string name;

        private bool isSelected;

        private string text;

        private bool isMouseDown;
        private Point oldPoint;
        private Point oldSize;
        private Point startMovePoint;

        public RelayCommand<MouseArguments> MouseDownCommand { get; private set; }
        public RelayCommand<MouseArguments> MouseMoveCommand { get; private set; }
        public RelayCommand<MouseArguments> MouseUpCommand { get; private set; }
        public RelayCommand<MouseArguments> RemoveCommand { get; private set; }

        public FieldViewModel(
            ISelectedFieldHost selectedFieldHost,
            double x,
            double y,
            double width,
            double height,
            double scale,
            string name)
        {
            this.selectedFieldHost = selectedFieldHost;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.scale = scale;
            this.name = name;

            MouseDownCommand = new RelayCommand<MouseArguments>(OnMouseDown);
            MouseMoveCommand = new RelayCommand<MouseArguments>(OnMouseMove);
            MouseUpCommand = new RelayCommand<MouseArguments>(OnMouseUp);
            RemoveCommand = new RelayCommand<MouseArguments>(OnRemove);
        }

        private void OnRemove(MouseArguments arguments)
        {
            selectedFieldHost.Remove(this);
        }

        private void OnMouseDown(MouseArguments args)
        {
            isMouseDown = true;
            oldPoint = new Point(X, Y);
            oldSize = new Point(Width, Height);
            startMovePoint = args.Point;
            selectedFieldHost.SelectedField = this;
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

        private void ChangePosition(MouseArguments args)
        {
            if (args.Tag == "0")
            {
                SetPosition(args);
            }
            else if (args.Tag == "1")
            {
                SetCorner1(args);
            }
            else if (args.Tag == "2")
            {
                SetCorner2(args);
            }
            else if (args.Tag == "3")
            {
                SetCorner3(args);
            }
            else if (args.Tag == "4")
            {
                SetCorner4(args);
            }
        }

        private void SetCorner1(MouseArguments args)
        {
            var newPoint = oldPoint + (args.Point - startMovePoint);
            var max = new Point(oldPoint.X + oldSize.X - MinSize.X, oldPoint.Y + oldSize.Y - MinSize.Y);
            if (newPoint.X < 0)
            {
                X = 0;
            }
            else if (newPoint.X > max.X)
            {
                X = max.X;
            }
            else
            {
                X = newPoint.X;
            }
            if (newPoint.Y < 0)
            {
                Y = 0;
            }
            else if (newPoint.Y > max.Y)
            {
                Y = max.Y;
            }
            else
            {
                Y = newPoint.Y;
            }
            var delta = new Point(X - oldPoint.X, Y - oldPoint.Y);
            Width = oldSize.X - delta.X;
            Height = oldSize.Y - delta.Y;
        }

        private void SetCorner2(MouseArguments args)
        {
            var newWidth = args.Point.X - oldPoint.X;
            var maxWidth = args.Max.X - oldPoint.X;
            var newY = oldPoint.Y + (args.Point.Y - startMovePoint.Y);
            var maxY = oldPoint.Y + oldSize.Y - MinSize.Y;
            if (newWidth < MinSize.X)
            {
                Width = MinSize.X;
            }
            else if (newWidth > maxWidth)
            {
                Width = maxWidth;
            }
            else
            {
                Width = newWidth;
            }
            if (newY < 0)
            {
                Y = 0;
            }
            else if (newY > maxY)
            {
                Y = maxY;
            }
            else
            {
                Y = newY;
            }
            double deltaY = Y - oldPoint.Y;
            Height = oldSize.Y - deltaY;
        }

        private void SetCorner3(MouseArguments args)
        {
            var newWidth = args.Point.X - oldPoint.X;
            var maxWidth = args.Max.X - oldPoint.X;
            var newHeight = args.Point.Y - oldPoint.Y;
            var maxHeight = args.Max.Y - oldPoint.Y;
            if (newWidth < MinSize.X)
            {
                Width = MinSize.X;
            }
            else if (newWidth > maxWidth)
            {
                Width = maxWidth;
            }
            else
            {
                Width = newWidth;
            }
            if (newHeight < MinSize.Y)
            {
                Height = MinSize.Y;
            }
            else if (newHeight > maxHeight)
            {
                Height = maxHeight;
            }
            else
            {
                Height = newHeight;
            }
        }

        private void SetCorner4(MouseArguments args)
        {
            var newX = oldPoint.X + (args.Point.X - startMovePoint.X);
            var maxX = oldPoint.X + oldSize.X - MinSize.X;
            var newHeight = args.Point.Y - oldPoint.Y;
            var maxHeight = args.Max.Y - oldPoint.Y;
            if (newX < 0)
            {
                X = 0;
            }
            else if (newX > maxX)
            {
                X = maxX;
            }
            else
            {
                X = newX;
            }
            double deltaX = X - oldPoint.X;
            Width = oldSize.X - deltaX;
            if (newHeight < MinSize.Y)
            {
                Height = MinSize.Y;
            }
            else if (newHeight > maxHeight)
            {
                Height = maxHeight;
            }
            else
            {
                Height = newHeight;
            }
        }

        private void SetPosition(MouseArguments args)
        {
            var newPoint = oldPoint + (args.Point - startMovePoint);
            var max = new Point(args.Max.X - Width, args.Max.Y - Height);
            if (newPoint.X < 0)
            {
                X = 0;
            }
            else if (newPoint.X > max.X)
            {
                X = max.X;
            }
            else
            {
                X = newPoint.X;
            }
            if (newPoint.Y < 0)
            {
                Y = 0;
            }
            else if (newPoint.Y > max.Y)
            {
                Y = max.Y;
            }
            else
            {
                Y = newPoint.Y;
            }
        }

        public double X
        {
            get => x * scale;
            set
            {
                x = value / scale;
                NotifyPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get => y * scale;
            set
            {
                y = value / scale;
                NotifyPropertyChanged(nameof(Y));
            }
        }

        public double Width
        {
            get => width * scale;
            set
            {
                width = value / scale;
                NotifyPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get => height * scale;
            set
            {
                height = value / scale;
                NotifyPropertyChanged(nameof(Height));
            }
        }

        public double Scale
        {
            get => scale;
            set
            {
                if (UpdateProperty(ref scale, value))
                {
                    NotifyPropertyChanged(nameof(X));
                    NotifyPropertyChanged(nameof(Y));
                    NotifyPropertyChanged(nameof(Width));
                    NotifyPropertyChanged(nameof(Height));
                }
            }
        }

        public PageElementType ElementType => PageElementType.TextField;

        public string Name
        {
            get => name;
            set => UpdateProperty(ref name, value);
        }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (UpdateProperty(ref isSelected, value))
                {
                    NotifyPropertyChanged(nameof(Visibility));
                    NotifyPropertyChanged(nameof(StrokeThickness));
                }
            }
        }

        public Visibility Visibility
        {
            get => isSelected ? Visibility.Visible : Visibility.Collapsed;
        }

        public double StrokeThickness
        {
            get => isSelected ? 1 : 0;
        }

        public string Text
        {
            get => text;
            set
            {
                if (UpdateProperty(ref text, value))
                {
                    NotifyPropertyChanged(nameof(TextShort));
                    NotifyPropertyChanged(nameof(TextShortVisibility));
                }
            }
        }

        public string TextShort
        {
            get
            {
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }
                else
                {
                    return text.Length < 30 ? text : text.Substring(0, 30) + " ...";
                }
            }
        }

        public Visibility TextShortVisibility => string.IsNullOrEmpty(text) ? Visibility.Collapsed : Visibility.Visible;
    }
}
