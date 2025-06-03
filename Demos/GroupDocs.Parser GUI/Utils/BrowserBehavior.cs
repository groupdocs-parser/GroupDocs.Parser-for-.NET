using System;
using System.Windows;
using System.Windows.Controls;

namespace GroupDocs.Parser.Gui.Utils
{
    static class BrowserBehavior
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(BrowserBehavior),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtml(WebBrowser d)
        {
            return (string)d.GetValue(HtmlProperty);
        }

        public static void SetHtml(WebBrowser d, string value)
        {
            d.SetValue(HtmlProperty, value);
        }

        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser wb = d as WebBrowser;
            if (wb != null)
            {
                string html = e.NewValue as string;
                if (html == null)
                {
                    wb.Source = null;
                }
                else
                {
                    wb.NavigateToString(html);
                }
            }
        }

        public static readonly DependencyProperty HtmlUrlProperty = DependencyProperty.RegisterAttached(
            "HtmlUrl",
            typeof(string),
            typeof(BrowserBehavior),
            new FrameworkPropertyMetadata(OnHtmlUrlChanged));

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtmlUrl(WebBrowser d)
        {
            return (string)d.GetValue(HtmlUrlProperty);
        }

        public static void SetHtmlUrl(WebBrowser d, string value)
        {
            d.SetValue(HtmlUrlProperty, value);
        }

        static void OnHtmlUrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser wb = d as WebBrowser;
            if (wb != null)
            {
                string url = e.NewValue as string;
                wb.Source = url == null ? null : new Uri(url);
            }
        }
    }
}
