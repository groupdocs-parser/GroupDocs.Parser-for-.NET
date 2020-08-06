---
id: parse-data-from-pdf-documents
url: parser/net/parse-data-from-pdf-documents
title: Parse data from PDF documents
weight: 5
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract data from PDF documents [ParseForm](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parseform) and [ParseByTemplate](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parsebytemplate) methods are used. Both methods return [DocumentData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata) object. For details, see [Working With Extracted Data]({{< ref "parser/net/developer-guide/advanced-usage/working-with-data-extracted-by-template.md" >}}).

Here are the steps to extract data from PDF Form:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document
*   Call [ParseForm](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parseform) method and obtain the [DocumentData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata) object;
*   Check if *data* isn't *null* (parse form is supported for the document);
*   Iterate over field data to obtain form data.

The following example shows the use case when a user fills in PDF form and send it by email (for example). The software opens this PDF and extracts the preliminary record:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(Constants.SampleCarWashPdf))
{
    // Extract data from PDF document
    DocumentData data = parser.ParseForm();
    // Check if form extraction is supported
    if (data == null)
    {
        Console.WriteLine("Form extraction isn't supported.");
        return;
    }

    // Create the preliminary record object
    PreliminaryRecord rec = new PreliminaryRecord();
    rec.Name = GetFieldText(data, "Name");
    rec.Model = GetFieldText(data, "Model");
    rec.Time = GetFieldText(data, "Time");
    rec.Description = GetFieldText(data, "Description");

    // We can save the preliminary record object to the database, 
    // send it as the web response or just print it to the console
    Console.WriteLine("Preliminary record");
    Console.WriteLine("Name: {0}", rec.Name);
    Console.WriteLine("Model: {0}", rec.Model);
    Console.WriteLine("Time: {0}", rec.Time);
    Console.WriteLine("Description: {0}", rec.Description);
}

private static string GetFieldText(DocumentData data, string fieldName)
{
    // Get the field from data collection
    FieldData fieldData = data.GetFieldsByName(fieldName).FirstOrDefault();
    // Check if the field data is not null (a field with the fieldName is contained in data collection)
    // and check if the field data contains the text
    return fieldData != null && fieldData.PageArea is PageTextArea
        ? (fieldData.PageArea as PageTextArea).Text
        : null;
}

/// <summary>
/// Simple POCO object to store the extracted data.
/// </summary>
public class PreliminaryRecord
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Time { get; set; }
    public string Description { get; set; }
}
```

[ParseByTemplate](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parsebytemplate) method is used to parse PDF document by a user-generated template. For details about templates, see [Working With Templates]({{< ref "parser/net/developer-guide/advanced-usage/working-with-templates.md" >}}).

Here are the steps to parse data from PDF document by the user-generated template:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the existing document;
*   Instantiate [Template](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/template) object with the user-generated template;
*   Call [ParseByTemplate](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parsebytemplate) method and obtain [DocumentData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata) object;
*   Iterate over field data to obtain the document data.

The following example shows how to parse data from PDF document by the user-generated template:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(Constants.SampleInvoicePdf))
{
    // Parse the document by the template
    DocumentData data = parser.ParseByTemplate(GetTemplate());
    // Check if parsing document by template is supported
    if (data == null)
    {
        Console.WriteLine("Parsing Document by Template isn't supported.");
        return;
    }
    // Print extracted fields
    for (int i = 0; i < data.Count; i++)
    {
        Console.Write(data[i].Name + ": ");
        PageTextArea area = data[i].PageArea as PageTextArea;
        Console.WriteLine(area == null ? "Not a template field" : area.Text);
    }
}

private static Template GetTemplate()
{
    // Create detector parameters for "Details" table
    TemplateTableParameters detailsTableParameters = new TemplateTableParameters(new Rectangle(new Point(35, 320), new Size(530, 55)), null);
    // Create detector parameters for "Summary" table
    TemplateTableParameters summaryTableParameters = new TemplateTableParameters(new Rectangle(new Point(330, 385), new Size(220, 65)), null);
    // Create a collection of template items
    TemplateItem[] templateItems = new TemplateItem[]
    {
        new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 135), new Size(100, 10))), "FromCompany"),
        new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 150), new Size(100, 35))), "FromAddress"),
        new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 190), new Size(150, 2))), "FromEmail"),
        new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 250), new Size(100, 2))), "ToCompany"),
        new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 260), new Size(100, 15))), "ToAddress"),
        new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 290), new Size(150, 2))), "ToEmail"),
        new TemplateField(new TemplateRegexPosition("Invoice Number"), "InvoiceNumber"),
        new TemplateField(new TemplateLinkedPosition(
            "InvoiceNumber",
            new Size(200, 15),
            new TemplateLinkedPositionEdges(false, false, true, false)),
            "InvoiceNumberValue"),
        new TemplateField(new TemplateRegexPosition("Order Number"), "InvoiceOrder"),
        new TemplateField(new TemplateLinkedPosition(
            "InvoiceOrder",
            new Size(200, 15),
            new TemplateLinkedPositionEdges(false, false, true, false)),
            "InvoiceOrderValue"),
        new TemplateField(new TemplateRegexPosition("Invoice Date"), "InvoiceDate"),
        new TemplateField(new TemplateLinkedPosition(
            "InvoiceDate",
            new Size(200, 15),
            new TemplateLinkedPositionEdges(false, false, true, false)),
            "InvoiceDateValue"),
        new TemplateField(new TemplateRegexPosition("Due Date"), "DueDate"),
        new TemplateField(new TemplateLinkedPosition(
            "DueDate",
            new Size(200, 15),
            new TemplateLinkedPositionEdges(false, false, true, false)),
            "DueDateValue"),
        new TemplateField(new TemplateRegexPosition("Total Due"), "TotalDue"),
        new TemplateField(new TemplateLinkedPosition(
            "TotalDue",
            new Size(200, 15),
            new TemplateLinkedPositionEdges(false, false, true, false)),
            "TotalDueValue"),
        new TemplateTable(detailsTableParameters, "details", null),
        new TemplateTable(summaryTableParameters, "summary", null)
    };
    // Create a document template
    Template template = new Template(templateItems);
    return template;
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).