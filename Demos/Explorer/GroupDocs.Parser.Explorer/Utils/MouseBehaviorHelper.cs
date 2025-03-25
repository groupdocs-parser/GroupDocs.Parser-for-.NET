using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GroupDocs.Parser.Explorer.Utils
{
    public static class MouseBehaviorHelper
    {
        public static bool GetCanvas(
            DependencyObject inDependencyObject,
            out FrameworkElement uiElement,
            out Canvas canvas,
            out string tag)
        {
            uiElement = inDependencyObject as FrameworkElement;
            if (null == uiElement)
            {
                canvas = null;
                tag = string.Empty;
                return false;
            }

            tag = uiElement.Tag as string;
            Canvas body = VisualTreeHelper.GetParent(uiElement) as Canvas;
            if (null == body)
            {
                canvas = null;
                return false;
            }

            UIElement presenter = VisualTreeHelper.GetParent(body) as UIElement;
            if (null == presenter)
            {
                canvas = null;
                return false;
            }

            canvas = VisualTreeHelper.GetParent(presenter) as Canvas;
            if (canvas == null) return false;

            return true;
        }
    }
}
