---
id: extract-hyperlinks-from-microsoft-office-word-documents
url: parser/net/extract-hyperlinks-from-microsoft-office-word-documents
title: Extract hyperlinks from Microsoft Office Word documents
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract hyperlinks from Microsoft Office Word document [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method is used. This method returns XML representation of the document. Hyperlinks are represented by "hyperlink" tag; "link" attribute contains hyperlink's URL. For more details, see [Extract text structure]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/extract-text-structure.md" >}}). Hyperlink can contain a text:

```xml
<hyperlink link="www.google.com">google.com</hyperlink>
```

{{< alert style="warning" >}}
[GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method returns *null* value if text structure extraction isn't supported for the document. For example, text structure extraction isn't supported for TXT files. Therefore, for TXT file [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method returns *null*. If Microsoft Office Word document has no text, [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure)[](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getmetadata)method returns an empty [XmlReader](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmlreader?view=netframework-2.0) object.
{{< /alert >}}

Here are the steps to extract hyperlinks from Microsoft Office Word documents:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method and obtain [XmlReader](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmlreader?view=netframework-2.0) object;
*   Iterate through the XML document.

The following example demonstrates how to extract hyperlinks from Microsoft Office Word document:

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
            // If it is the start tag of the hyperlink
            if (reader.IsStartElement() && reader.Name == "hyperlink")
            {
                // Print the link attribute
                Console.WriteLine(reader.GetAttribute("link"));
            }
        }
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