using System;
using System.Windows.Controls;

namespace GroupDocs.Parser.Gui.Controls
{
    public class CustomScrollViewer : ScrollViewer
    {
        public event EventHandler<PercentagePositionEventArgs> PercentagePositionChanged;

        public CustomScrollViewer()
        {
        }

        protected override void OnScrollChanged(ScrollChangedEventArgs e)
        {
            base.OnScrollChanged(e);

            if (e.VerticalChange == 0)
            {
                double k = e.ExtentHeightChange / e.ExtentHeight;
                double offset = e.VerticalOffset + k * e.VerticalOffset;
                if (!double.IsNaN(offset))
                {
                    ScrollToVerticalOffset(offset);
                }
            }
            else
            {
                double position = e.VerticalOffset / e.ExtentHeight;
                if (double.IsNaN(position))
                {
                    position = 0;
                }

                PercentagePositionChanged?.Invoke(this, new PercentagePositionEventArgs(position));
            }
        }
    }
}
