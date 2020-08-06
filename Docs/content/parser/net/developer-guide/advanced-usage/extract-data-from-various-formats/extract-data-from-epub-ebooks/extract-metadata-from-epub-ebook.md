---
id: extract-metadata-from-epub-ebook
url: parser/net/extract-metadata-from-epub-ebook
title: Extract metadata from EPUB eBook
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract metadata from EPUB e-books [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method is used. This method allows to extract the following metadata:

| Name | Description |
| --- | --- |
| title | The title of the e-book. |
| subject | The subject of the e-book. |
| author | The name of the e-book's author. |
| language | The language of the e-book. |
| published-date | The published date of the e-book. |
| description | The description of the e-book. |
| publisher | The publisher of the e-book. |
| copyrights | The copyrights of the e-book. |

Here are the steps to extract metadata from EPUB e-book:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Call [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method and obtain collection of document metadata objects;
*   Iterate through the collection and get metadata names and values.

{{< alert style="warning" >}}
[GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null* value if metadata extraction isn't supported for the document. For example, metadata extraction isn't supported for Zip archive. Therefore, for Zip archive [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null*. If EPUB e-book has no metadata, [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns an empty collection.
{{< /alert >}}

The following example demonstrates how to extract metadata from EPUB e-book:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract metadata from the e-book
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