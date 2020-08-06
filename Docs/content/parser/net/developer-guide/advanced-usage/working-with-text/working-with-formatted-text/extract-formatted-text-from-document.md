---
id: extract-formatted-text-from-document
url: parser/net/extract-formatted-text-from-document
title: Extract formatted text from document
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract formatted text from documents by the [GetFormattedText(FormattedTextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method:

```csharp
TextReader GetFormattedText(FormattedTextOptions options);
```

Methods return an instance of [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) class with the extracted text. [FormattedTextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextoptions) has the following constructor:

```csharp
FormattedTextOptions(FormattedTextMode mode);
```

[FormattedTextMode](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextmode) enumeration has the following members:

| Member | Description |
| --- | --- |
| Html | HTML format. |
| Markdown | Markdown format. |
| PlainText | Plain text format. |

Here are the steps to extract a HTML formatted text from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [FormattedTextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextoptions) with HTML text mode;
*   Call [GetFormattedText(FormattedTextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Check if *reader* isn't *null* (formatted text extraction is supported for the document);
*   Read a text from *reader*.

The following example shows how to extract a document text as HTML text:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a formatted text into the reader
    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
    {
        // Print a formatted text from the document
        // If formatted text extraction isn't supported, a reader is null
        Console.WriteLine(reader == null ? "Formatted text extraction isn't supported" : reader.ReadToEnd());
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