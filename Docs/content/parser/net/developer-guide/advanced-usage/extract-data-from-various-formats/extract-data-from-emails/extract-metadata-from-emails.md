---
id: extract-metadata-from-emails
url: parser/net/extract-metadata-from-emails
title: Extract metadata from Emails
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract metadata from emails [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method is used. This method allows to extract the following metadata:

| Name | Description |
| --- | --- |
| subject | The email "subject" field. |
| email-sender | The email "from" field. |
| email-to | The email "to" field. May contain more than one address separated by semicolons. |
| email-cc | The email "cc" field. May contain more than one address separated by semicolons. |

Here are the steps to extract metadata from an email:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial email;
*   Call [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method and obtain collection of document metadata objects;
*   Iterate through the collection and get metadata names and values.

{{< alert style="warning" >}}
[GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null* value if metadata extraction isn't supported for the document. For example, metadata extraction isn't supported for Zip archive. Therefore, for Zip archive [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns *null*. If an email has no metadata, [GetMetadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata) method returns an empty collection.
{{< /alert >}}

The following example demonstrates how to extract metadata from an email:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract metadata from the email
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