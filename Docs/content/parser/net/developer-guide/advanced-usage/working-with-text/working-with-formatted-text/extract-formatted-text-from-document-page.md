---
id: extract-formatted-text-from-document-page
url: parser/net/extract-formatted-text-from-document-page
title: Extract formatted text from document page
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract formatted text from document page by the [GetFormattedText(int, FormattedTextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/getformattedtext/methods/1) method:

```csharp
TextReader GetFormattedText(int pageIndex, FormattedTextOptions options);

```

Methods return an instance of [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) class with the extracted text. [FormattedTextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextoptions) has the following constructor:

```csharp
FormattedTextOptions(FormattedTextMode mode);
```

[FormattedTextMode](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextmode) enumeration has the following members:

| Member | Description |
| --- | --- |
| Html | Html format. |
| Markdown | Markdown format. |
| PlainText | Plain text format. |

Here are the steps to extract a HTML formatted page text from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Check if formatted text extraction is supported for the document;
*   Instantiate [FormattedTextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/formattedtextoptions) with HTML text mode;
*   Call [GetFormattedText(int, FormattedTextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/getformattedtext/methods/1) method with the page index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example shows how to extract a document page text as Markdown text:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports formatted text extraction
    if (!parser.Features.FormattedText)
    {
        Console.WriteLine("Document isn't supports formatted text extraction.");
        return;
    }

    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    // Check if the document has pages
    if (documentInfo.PageCount == 0)
    {
        Console.WriteLine("Document hasn't pages.");
        return;
    }
   
    // Iterate over pages
    for (int p = 0; p < documentInfo.PageCount; p++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.PageCount));
        // Extract a formatted text into the reader
        using (TextReader reader = parser.GetFormattedText(p, new FormattedTextOptions(FormattedTextMode.Html)))
        {
            // Print a formatted text from the document
            // We ignore null-checking as we have checked formatted text extraction feature support earlier
            Console.WriteLine(reader.ReadToEnd());
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