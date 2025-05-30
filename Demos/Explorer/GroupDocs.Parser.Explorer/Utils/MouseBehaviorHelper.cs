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

            DependencyObject child = uiElement;
            while (true)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(child);
                if (parent == null)
                {
                    canvas = null;
                    return false;
                }

                var localCanvas = parent as Canvas;
                if (localCanvas != null && localCanvas.Name == "Canvas")
                {
                    canvas = localCanvas;
                    return true;
                }

                child = parent;
            }
        }
    }
}
