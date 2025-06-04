using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GroupDocs.Parser.Gui.Utils
{
    public static class MouseUpBehavior
    {
        private static readonly DependencyProperty MouseUpCommandProperty = DependencyProperty.RegisterAttached(
            "MouseUpCommand",
            typeof(ICommand),
            typeof(MouseUpBehavior),
            new PropertyMetadata(MouseUpCommandPropertyChangedCallBack));

        public static void SetMouseUpCommand(this UIElement inUIElement, ICommand inCommand)
        {
            inUIElement.SetValue(MouseUpCommandProperty, inCommand);
        }

        public static ICommand GetMouseUpCommand(UIElement inUIElement)
        {
            return (ICommand)inUIElement.GetValue(MouseUpCommandProperty);
        }

        private static void MouseUpCommandPropertyChangedCallBack(
            DependencyObject inDependencyObject,
            DependencyPropertyChangedEventArgs inEventArgs)
        {
            if (!MouseBehaviorHelper.GetCanvas(
                inDependencyObject,
                out FrameworkElement uiElement,
                out Canvas canvas,
                out string tag))
            {
                return;
            }

            uiElement.MouseUp += (sender, args) =>
            {
                Point point = args.GetPosition(canvas);
                Point max = new Point(canvas.ActualWidth, canvas.ActualHeight);
                MouseArguments ma = new MouseArguments(point, max, tag);
                uiElement.ReleaseMouseCapture();
                GetMouseUpCommand(uiElement).Execute(ma);
                args.Handled = true;
            };
        }
    }
}
