namespace GroupDocs.Parser.Gui.ViewModels
{
    internal interface ISelectedFieldHost
    {
        IFieldViewModel SelectedField { get; set; }

        void Remove(IFieldViewModel field);
    }
}
