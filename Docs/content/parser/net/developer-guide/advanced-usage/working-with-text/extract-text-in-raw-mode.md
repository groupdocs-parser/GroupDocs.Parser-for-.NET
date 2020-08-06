---
id: extract-text-in-raw-mode
url: parser/net/extract-text-in-raw-mode
title: Extract text in Raw mode
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract a text from documents.

The **Raw** mode is the fastest text extraction mode and it means that performance wlll be the best possible.

Raw mode usually retrieves text in worse quality than Accurate mode, but in some cases performance is more important than quality.

You can extract the whole document text or only a document page.

To extract a text from the document in the Raw mode, [GetText(TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/1) and [GetText(int, TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/3) methods of [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) class are used:

```csharp
TextReader GetText(TextOptions options);
TextReader GetText(int pageIndex, TextOptions options);
```

Methods return an instance of [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) class with an extracted text. The first method extracts text from the whole document. The second method extracts text from the document page. To retrieve the total number of document pages [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method is used (see below).

{{< alert style="warning" >}}
Instead of the accurate mode, [RawPageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) property of [IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) class is used to avoid extra calculations.
{{< /alert >}}

## Extract text

Here are the steps to extract a raw text from document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [TextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textoptions) object with *true* parameter;
*   Call [GetText(TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/1) method with [TextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textoptions)parameter and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Check if *reader* isn't *null* (text extraction is supported for the document);
*   Read a text from *reader*.

The following example shows how to extract a raw text from a document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract a raw text into the reader
    using(TextReader reader = parser.GetText(new TextOptions(true)))
    {
        // Print a text from the document
        // If text extraction isn't supported, a reader is null
        Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
    }
}
```

## Extract text from a page

Here are the steps to extract a raw text from the document page:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [TextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textoptions) object with *true* parameter;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method;
*   Call [Features.Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/text) property to check if text extraction is supported for the document;
*   Use [RawPageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) instead of [PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) to avoid extra calculations;
*   Call [GetText(int, TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/3) method with the page index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example shows how to extract a raw text from a document page:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports text extraction
    if (!parser.Features.Text)
    {
        Console.WriteLine("Document isn't supports text extraction.");
        return;
    }
    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    // Check if the document has pages
    if (documentInfo == null || documentInfo.RawPageCount == 0)
    {
        Console.WriteLine("Document hasn't pages.");
        return;
    }
    // Iterate over pages
    for (int p = 0; p < documentInfo.RawPageCount; p++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.RawPageCount));
        // Extract a text into the reader
        using (TextReader reader = parser.GetText(p, new TextOptions(true)))
        {
            // Print a text from the document
            // We ignore null-checking as we have checked text extraction feature support earlier
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