---
id: markdown
url: parser/net/markdown
title: Markdown
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
The following example shows how to extract Markdown formatted text:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a formatted text into the reader
    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Markdown)))
    {
        // Print a formatted text from the document
        // If formatted text extraction isn't supported, a reader is null
        Console.WriteLine(reader == null ? "Formatted text extraction isn't supported" : reader.ReadToEnd());
    }
}
```

The API supports the following formatting:

*   Bold text
*   Italic text
*   Hyperlinks
*   Headings
*   Numbering and bullets lists
*   Tables

The following Microsoft Word document is used as input document:

![](parser/net/images/markdown.png)

The following Markdown document is extracted using the example above:

![](parser/net/images/markdown_1.png)

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).