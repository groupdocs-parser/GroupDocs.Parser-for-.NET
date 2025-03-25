using GroupDocs.Parser.Explorer.Controls;
using System.Windows;

namespace GroupDocs.Parser.Explorer.Utils
{
    static class AutoScrollBehavior
    {
        public static readonly DependencyProperty AutoScrollProperty = DependencyProperty.RegisterAttached(
            "AutoScroll",
            typeof(bool),
            typeof(AutoScrollBehavior),
            new PropertyMetadata(false, AutoScrollPropertyChanged));

        public static void AutoScrollPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is CustomListView listView)
            {
                if ((bool)args.NewValue)
                {
                    listView.ItemsChanged += OnItemsChanged;
                }
                else
                {
                    listView.ItemsChanged -= OnItemsChanged;
                }
            }
        }

        private static void OnItemsChanged(object sender, System.EventArgs e)
        {
            if (sender is CustomListView listView && listView.Items.Count > 0)
            {
                listView.ScrollIntoView(listView.Items[listView.Items.Count - 1]);
            }
        }

        public static bool GetAutoScroll(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollProperty);
        }

        public static void SetAutoScroll(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollProperty, value);
        }
    }
}
