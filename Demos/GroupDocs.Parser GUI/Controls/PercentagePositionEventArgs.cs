using System;

namespace GroupDocs.Parser.Gui.Controls
{
    public class PercentagePositionEventArgs : EventArgs
    {
        public PercentagePositionEventArgs(double percentagePosition)
        {
            PercentagePosition = percentagePosition;
        }

        public double PercentagePosition { get; }
    }
}
