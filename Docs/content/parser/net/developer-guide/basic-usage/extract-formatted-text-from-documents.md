---
id: extract-formatted-text-from-documents
url: parser/net/extract-formatted-text-from-documents
title: Extract formatted text from documents
weight: 6
description: "Extract formatted text represented as HTML or Markdown with GroupDocs.Parser from documents of various formats like Emails, Ebooks (EPUB, FB2, CHM), Microsoft Office formats: Word (DOC, DOCX), PowerPoint (PPT, PPTX), Excel (XLS, XLSX), LibreOffice formats and many others."
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser allows to extract formatted text from documents for those cases when simple plain text is not enough and you may need to keep formatting like text style, table layout etc.

This feature allows to extract text with integrated HTML tags, or Markdown syntax. Even PlainText mode allows to convert your documents to high quality text with integrated ASCII formatting symbols for tables, lists etc.

## Extract formatted text from documents

To extract a formatted text from documents simply call the [GetFormattedText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method:

```csharp
TextReader GetFormattedText(FormattedTextOptions options);

```

Methods return an instance of [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) class with an extracted text. [FormattedTextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextoptions) has the following constructor:

```csharp
FormattedTextOptions(FormattedTextMode mode)

```

[FormattedTextMode](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextmode) enumeration has the following members:

| Member | Description |
| --- | --- |
| Html | Html format. |
| Markdown | Markdown format. |
| PlainText | Plain text format. |

Here are the steps to extract a HTML formatted text from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [FormattedTextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextoptions) with HTML text mode;
*   Call [GetFormattedText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
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

### Advanced usage topics

To learn more about text extraction features, please refer the [advanced help section]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/working-with-formatted-text/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online text extractor App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to extract text from your documents with our free online [GroupDocs Parser App](https://products.groupdocs.app/parser).