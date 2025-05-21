namespace GroupDocs.Parser.Explorer.ViewModels
{
    interface IPageElement
    {
        public double OriginalX { get; }
        public double OriginalY { get; }
        public double OriginalWidth { get; }
        public double OriginalHeight { get; }

        public double X { get; }
        public double Y { get; }
        public double Width { get; }
        public double Height { get; }
        public double Scale { get; set; }
        public PageElementType ElementType { get; }
        public string Name { get; }
    }
}
