using System.Windows;

namespace GroupDocs.Parser.Explorer.Utils
{
    class MouseArguments
    {
        public Point Point { get; }
        public Point Max { get; }
        public string Tag { get; }

        public MouseArguments(
            Point point,
            Point max,
            string tag)
        {
            Point = point;
            Max = max;
            Tag = tag;
        }
    }
}
