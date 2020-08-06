---
id: extract-text-from-pdf-documents
url: parser/net/extract-text-from-pdf-documents
title: Extract text from PDF documents
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract a text from PDF documents [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) and [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method is used. These methods allow to extract a text from the entire document or a text from the selected page.

Here are the steps to extract a text from PDF document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

{{< alert style="warning" >}}
[GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null* value if text extraction isn't supported for the document. For example, text extraction isn't supported for Zip archive. Therefore, for Zip archive [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null*. For empty PDF document [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns an empty [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object ([reader.ReadToEnd](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoend?view=netframework-2.0) method returns an empty string).
{{< /alert >}}

The following example demonstrates how to extract a text from PDF document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract a text into the reader
    using(TextReader reader = parser.GetText())
    {
        // Print a text from the document
        Console.WriteLine(reader.ReadToEnd());
    }
}
```

Here are the steps to extract a text from the page of PDF document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method and obtain [IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) object with [page count](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount);
*   Call [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method with the page index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example demonstrates how to extract a text from the page of PDF document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
   
    // Iterate over pages
    for(int p = 0; p < documentInfo.PageCount; p++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.PageCount));
   
        // Extract a text into the reader
        using(TextReader reader = parser.GetText(p))
        {
            // Print a text from the document
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

Raw mode allows to increase the speed of text extraction due to poor formatting accuracy. [GetText(TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/1) and [GetText(pageIndex, TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/3) methods are used to extract a text in raw mode.

{{< alert style="warning" >}}
Some documents may have different page numbers in raw and accurate modes. Use [DocumentInfo.RawPageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) instead of [IDocumentInfo.PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) in raw mode.
{{< /alert >}}

Here are the steps to extract a raw text from the page of PDF document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [TextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textoptions) object with *true* parameter;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo);
*   Use [RawPageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) instead of [PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) to avoid extra calculations;
*   Call [GetText(pageIndex, TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/3) method with the sheet index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example demonstrates how to extract a raw text from the page of PDF document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
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
        // Print a pagenumber 
        Console.WriteLine(string.Format("Slide {0}/{1}", p + 1, documentInfo.RawPageCount));
        // Extract a text into the reader
        using (TextReader reader = parser.GetText(p, new TextOptions(true)))
        {
            // Print a text from the document page
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