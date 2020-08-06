---
id: loading-specific-file-formats
url: parser/net/loading-specific-file-formats
title: Loading specific file formats
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
In some cases it's required to specify the document format manually to guarantee correct output produced by GroupDocs.Parser. The following are the cases when the document format must be specified manually:

*   Markdown documents
*   MHTML documents
*   OTP documents (OpenDocument Presentation Template)
*   Databases
*   Emails from remote servers

Here are the steps to specify the document format for Markup document.

*   Instantiate the [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions) object and pass the document format in [LoadOptions(FileFormat)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions/constructors/1) constructor;
*   Create [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object and call any method.

The following example shows how to specify the document format for Markup document:  

```csharp
// Create an instance of Parser class for markdown document
using (Parser parser = new Parser(stream, new LoadOptions(FileFormat.Markup)))
{
    // Check if text extraction is supported
    if (!parser.Features.Text)
    {
        Console.WriteLine("Text extraction isn't supported.");
        return;
    }
    using (TextReader reader = parser.GetText())
    {
        // Print the document text
        // Markdown is detected; text without special symbols is printed
        Console.WriteLine(reader.ReadToEnd());
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
