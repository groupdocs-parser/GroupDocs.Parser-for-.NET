---
id: extract-metadata-from-microsoft-office-word-documents
url: parser/net/extract-metadata-from-microsoft-office-word-documents
title: Extract metadata from Microsoft Office Word documents
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract metadata from Microsoft Office Word documents [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method is used. This method allows to extract the following metadata:

| Name | Description |
| --- | --- |
| title | The title of the document. |
| subject | The subject of the document. |
| keywords | The keyword of the document. |
| comments | The comments of the document. |
| content-status | The content status of the document. |
| category | The category of the document. |
| company | The company of the document. |
| manager | The manager of the document. |
| author | The name of the document's author. |
| last-author | The name of the last document's author. |
| hyperlink-base | The base string used for evaluating relative hyperlinks in this document. |
| application | The name of the application. |
| application-version | The version number of the application that created the document. |
| template | The informational name of the document template. |
| created-time | The time of the document creation. |
| last-saved-time | The time of the the document when it was last saved. |
| last-printed-time | The time of the document when it was last printed. |
| revision-number | The document revision number. |
| total-editing-time | The total editing time in minutes. |

Here are the steps to extract metadata from Microsoft Office Word document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method and obtain collection of document metadata objects;
*   Iterate through the collection and get metadata names and values.

{{< alert style="warning" >}}
[GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null* value if metadata extraction isn't supported for the document. For example, metadata extraction isn't supported for Zip archive. Therefore, for Zip archive [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null*. If Microsoft Office Word document has no metadata, [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns an empty collection.
{{< /alert >}}

The following example demonstrates how to extract metadata from Microsoft Office Word document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract metadata from the document
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