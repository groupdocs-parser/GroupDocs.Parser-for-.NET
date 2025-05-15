namespace GroupDocs.Parser.Explorer.ViewModels
{
    internal interface ISelectedFieldHost
    {
        FieldViewModel SelectedField { get; set; }

        void Remove(FieldViewModel field);
    }
}
