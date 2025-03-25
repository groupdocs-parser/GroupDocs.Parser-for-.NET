namespace GroupDocs.Parser.Explorer.ViewModels
{
    interface IPageElement
    {
        public double X { get; }
        public double Y { get; }
        public double Width { get; }
        public double Height { get; }
        public double Scale { get; set; }
    }
}
