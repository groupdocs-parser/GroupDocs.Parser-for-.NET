using System;

namespace GroupDocs.Parser.Explorer.Controls
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
