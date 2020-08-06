---
id: extract-metadata-from-microsoft-office-excel-spreadsheets
url: parser/net/extract-metadata-from-microsoft-office-excel-spreadsheets
title: Extract metadata from Microsoft Office Excel spreadsheets
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract metadata from Microsoft Office Excel spreadsheets [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method is used. This method allows to extract the following metadata:

| Name | Description |
| --- | --- |
| title | The title of the spreadsheet. |
| subject | The subject of the spreadsheet. |
| keywords | The keyword of the spreadsheet. |
| comments | The comments of the spreadsheet. |
| content-status | The content status of the spreadsheet. |
| category | The category of the spreadsheet. |
| company | The company of the spreadsheet. |
| manager | The manager of the spreadsheet. |
| author | The name of the spreadsheet's author. |
| last-author | The name of the last spreadsheet's author. |
| hyperlink-base | The base string used for evaluating relative hyperlinks in this spreadsheet. |
| application | The name of the application. |
| application-version | The version number of the application that created the spreadsheet. |
| template | The informational name of the spreadsheet template. |
| created-time | The time of the spreadsheet creation. |
| last-saved-time | The time of the the spreadsheet when it was last saved. |
| last-printed-time | The time of the spreadsheet when it was last printed. |
| revision-number | The spreadsheet revision number. |
| total-editing-time | The total editing time in minutes. |

Here are the steps to extract metadata from Microsoft Office Excel spreadsheet:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial spreadsheet;
*   Call [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method and obtain collection of document metadata objects;
*   Iterate through the collection and get metadata names and values.

{{< alert style="warning" >}}
[GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null* value if metadata extraction isn't supported for the document. For example, metadata extraction isn't supported for CSV files. Therefore, for CSV file [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null*. If Microsoft Office Excel spreadsheet has no metadata, [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns an empty collection.
{{< /alert >}}

The following example demonstrates how to extract metadata from Excel spreadsheet:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract metadata from the spreadsheet
    IEnumerable<MetadataItem> metadata = parser.GetMetadata();
 
    // Iterate over metadata items
    foreach(MetadataItem item in metadata)
    {
        // Print the item name and value
        Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Value));
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