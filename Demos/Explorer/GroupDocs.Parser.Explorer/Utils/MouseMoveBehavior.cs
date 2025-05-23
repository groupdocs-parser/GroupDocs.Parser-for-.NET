using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GroupDocs.Parser.Explorer.Utils
{
    public static class MouseMoveBehavior
    {
        private static readonly DependencyProperty MouseMoveCommandProperty = DependencyProperty.RegisterAttached(
            "MouseMoveCommand",
            typeof(ICommand),
            typeof(MouseMoveBehavior),
            new PropertyMetadata(MouseMoveCommandPropertyChangedCallBack));

        public static void SetMouseMoveCommand(this UIElement inUIElement, ICommand inCommand)
        {
            inUIElement.SetValue(MouseMoveCommandProperty, inCommand);
        }

        public static ICommand GetMouseMoveCommand(UIElement inUIElement)
        {
            return (ICommand)inUIElement.GetValue(MouseMoveCommandProperty);
        }

        private static void MouseMoveCommandPropertyChangedCallBack(
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

            uiElement.MouseMove += (sender, args) =>
            {
                Point point = args.GetPosition(canvas);
                Point max = new Point(canvas.ActualWidth, canvas.ActualHeight);
                MouseArguments ma = new MouseArguments(point, max, tag);
                GetMouseMoveCommand(uiElement).Execute(ma);
                args.Handled = true;
            };
        }
    }
}
