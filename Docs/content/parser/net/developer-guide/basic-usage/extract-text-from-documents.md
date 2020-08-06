---
id: extract-text-from-documents
url: parser/net/extract-text-from-documents
title: Extract text from documents
weight: 5
description: "Extract text with GroupDocs.Parser from PDF, Emails, Ebooks (EPUB, FB2, CHM), Microsoft Office formats: Word (DOC, DOCX), PowerPoint (PPT, PPTX), Excel (XLS, XLSX), LibreOffice formats and many others."
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser allows to extract text from PDF, Emails, Ebooks, Microsoft Office formats: Word (DOC, DOCX), PowerPoint (PPT, PPTX), Excel (XLS, XLSX), LibreOffice formats and many others (see full list at [supported document formats]({{< ref "parser/net/getting-started/supported-document-formats.md" >}}) article).

GroupDocs.Parser's text extractor is easy to use and powerful at the same time (to resolve complex scenarios see [advanced usage section]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/_index.md" >}})).

This article demonstrates how to implement the simplest scenario - extract text from any supported format without additional settings.

## Extract text from documents

To extract text from documents simply call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method:

```csharp
TextReader GetText();


```

Methods return an instance of [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) class with an extracted text. 

Here are the steps to extract a text from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Check if *reader* isn't *null* (text extraction is supported for the document);
*   Read a text from *reader*.

The following example shows how to extract a text from a document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract a text into the reader
    using(TextReader reader = parser.GetText())
    {
        // Print a text from the document
        // If text extraction isn't supported, a reader is null
        Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
    }
}

```

## More resources

### Advanced usage topics

To learn more about text extraction features, please refer the [advanced usage section]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online text extractor App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to extract text from your documents with our free online [GroupDocs Parser App](https://products.groupdocs.app/parser).