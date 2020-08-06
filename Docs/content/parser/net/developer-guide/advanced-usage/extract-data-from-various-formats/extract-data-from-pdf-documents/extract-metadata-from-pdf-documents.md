---
id: extract-metadata-from-pdf-documents
url: parser/net/extract-metadata-from-pdf-documents
title: Extract metadata from PDF documents
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract metadata from PDF documents [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method is used. This method allows to extract the following metadata:

| Name | Description |
| --- | --- |
| title | The title of the presentation. |
| subject | The subject of the presentation. |
| keywords | The keyword of the presentation. |
| author | The name of the presentation's author. |
| application | The name of the application. |
| application-version | The version number of the application that created the presentation. |
| created-time | The time of the presentation creation. |
| last-saved-time | The time of the the presentation when it was last saved. |

Here are the steps to extract metadata from PDF document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method and obtain collection of document metadata objects;
*   Iterate through the collection and get metadata names and values.

{{< alert style="warning" >}}
[GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null* value if metadata extraction isn't supported for the document. For example, metadata extraction isn't supported for TXT files. Therefore, for TXT file [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null*. If PDF document has no metadata, [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns an empty collection.
{{< /alert >}}

The following example demonstrates how to extract metadata from PDF document:

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