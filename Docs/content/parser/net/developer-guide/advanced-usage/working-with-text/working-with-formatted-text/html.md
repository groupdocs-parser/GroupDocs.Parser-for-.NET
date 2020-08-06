---
id: html
url: parser/net/html
title: HTML
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
The following example shows how to extract HTML formatted text:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a formatted text into the reader
    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
    {
        // Print a formatted text from the document
        // If formatted text extraction isn't supported, a reader is null
        Console.WriteLine(reader == null ? "Formatted text extraction isn't suppported" : reader.ReadToEnd());
    }
}
```

The following HTML tags are supported by the API:

| Tag | Description |
| --- | --- |
| `<p>` | Paragraph is surrounded by `<p>` tag |
| `<a>` | Hyperlinks |
| `<b>` | Text with Bold font is surrounded by `<a>` tag |
| `<i>` | Text with Italic font is surrounded by `<i>` tag |
| `<h>` - `<h6>` | If the heading has 'Heading X' style, it's surrounded by `<hX>` tag |
| `<ol>` / `<ul>` | Numbering and bullets lists |
| `<table>` | Tables |

The following Microsoft Word document is used as input document:

![](parser/net/images/html.png)

The following HTML document is extracted using the example above:

![](parser/net/images/html_1.png)

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).