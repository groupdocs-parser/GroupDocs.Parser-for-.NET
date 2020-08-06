---
id: extract-tables-from-microsoft-office-word-documents
url: parser/net/extract-tables-from-microsoft-office-word-documents
title: Extract tables from Microsoft Office Word documents
weight: 5
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract tables from Microsoft Office Word document [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method is used. This method returns XML representation of the document. Tables are represented by "table" tag. For more details, see [Extract text structure]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/extract-text-structure.md" >}}).

{{< alert style="warning" >}}
[GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method returns *null* value if text structure extraction isn't supported for the document. For example, text structure extraction isn't supported for TXT files. Therefore, for TXT file [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method returns *null*. If Microsoft Office Word document has no text, [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure)[](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata)method returns an empty [XmlReader](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmlreader?view=netframework-2.0) object.
{{< /alert >}}

Here are the steps to extract tables from Microsoft Office Word documents:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method and obtain [XmlReader](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmlreader?view=netframework-2.0) object;
*   Iterate through the XML document.

The following example demonstrates how to extract tables from Microsoft Office Word document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Get the reader object for the document XML representation
    using (XmlReader reader = parser.GetStructure())
    {
        // Iterate over the document
        while (reader.Read())
        {
            // Check if this is the start of the table
            if (reader.IsStartElement() && reader.Name == "table")
            {
                // Process the table
                ProcessTable(reader);
            }
        }
    }
}
 
private static void ProcessTable(XmlReader reader)
{
    Console.WriteLine("table");
    // Create an instance of StringBuilder to store the cell value
    StringBuilder value = new StringBuilder();
    // Iterate over the table
    while (reader.Read())
    {
        // Check if the current tag is the end of the table
        bool isTableEnd = !reader.IsStartElement() && reader.Name == "table";
        // Check if the current tag is the start of the row or the cell
        bool isRowOrCellStart = reader.IsStartElement() && (reader.Name == "tr" || reader.Name == "td");
        // Print the cell value if this is the end of the table or the start of the row or the cell
        if ((isTableEnd || isRowOrCellStart) && value.Length > 0)
        {
            Console.Write("  ");
            Console.WriteLine(value.ToString());
            value = new StringBuilder();
        }
        // If this is the end of the table - return to the main function
        if (isTableEnd)
        {
            return;
        }
        // If this is the start of the row or the cell - print the tag name
        if (isRowOrCellStart)
        {
            Console.WriteLine(reader.Name);
            continue;
        }
        // If this code line is reached then this is the value of the cell
        value.Append(reader.Value);
    }
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