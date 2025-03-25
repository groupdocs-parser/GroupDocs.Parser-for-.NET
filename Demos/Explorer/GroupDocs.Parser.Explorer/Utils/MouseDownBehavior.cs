using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GroupDocs.Parser.Explorer.Utils
{
    public static class MouseDownBehavior
    {
        private static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.RegisterAttached(
            "MouseDownCommand",
            typeof(ICommand),
            typeof(MouseDownBehavior),
            new PropertyMetadata(MouseDownCommandPropertyChangedCallBack));

        public static void SetMouseDownCommand(this UIElement inUIElement, ICommand inCommand)
        {
            inUIElement.SetValue(MouseDownCommandProperty, inCommand);
        }

        private static ICommand GetMouseDownCommand(UIElement inUIElement)
        {
            return (ICommand)inUIElement.GetValue(MouseDownCommandProperty);
        }

        private static void MouseDownCommandPropertyChangedCallBack(
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

            uiElement.MouseDown += (sender, args) =>
            {
                Point point = args.GetPosition(canvas);
                Point max = new Point(canvas.ActualWidth, canvas.ActualHeight);
                MouseArguments ma = new MouseArguments(point, max, tag);
                uiElement.CaptureMouse();
                GetMouseDownCommand(uiElement).Execute(ma);
                args.Handled = true;
            };
        }
    }
}
