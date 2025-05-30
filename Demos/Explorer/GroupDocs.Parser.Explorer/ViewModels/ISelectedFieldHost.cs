namespace GroupDocs.Parser.Explorer.ViewModels
{
    internal interface ISelectedFieldHost
    {
        IFieldViewModel SelectedField { get; set; }

        void Remove(IFieldViewModel field);
    }
}
