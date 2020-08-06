---
id: extract-text-from-microsoft-office-powerpoint-presentations
url: parser/net/extract-text-from-microsoft-office-powerpoint-presentations
title: Extract text from Microsoft Office PowerPoint presentations
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract a text from Microsoft Office PowerPoint presentations [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) and [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method is used. These methods allow to extract a text from the entire presentation or a text from the selected slide.

Here are the steps to extract a text from Microsoft Office PowerPoint presentations:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial presentation;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

{{< alert style="warning" >}}GetText method returns null value if text extraction isn't supported for the document. For example, text extraction isn't supported for Zip archive. Therefore, for Zip archive GetText method returns null. For empty Microsoft Office PowerPoint presentations GetText method returns an empty TextReader object (reader.ReadToEnd method returns an empty string).{{< /alert >}}

The following example demonstrates how to extract a text from Microsoft Office PowerPoint presentation:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract a text into the reader
    using(TextReader reader = parser.GetText())
    {
        // Print a text from the presentation
        Console.WriteLine(reader.ReadToEnd());
    }
}
```

Here are the steps to extract a text from the sheet of Microsoft Office PowerPoint presentation:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial presentation;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method and obtain [IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) object with [page count](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount);
*   Call [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method with the sheet index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example demonstrates how to extract a text from the slide of Microsoft Office PowerPoint presentation:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    
    // Iterate over slides
    for(int p = 0; p < documentInfo.PageCount; p++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Slide {0}/{1}", p + 1, documentInfo.PageCount));
    
        // Extract a text into the reader
        using(TextReader reader = parser.GetText(p))
        {
            // Print a text from the presentation slide
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

Raw mode allows to increase the speed of text extraction due to poor formatting accuracy. [GetText(TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/1) and [GetText(pageIndex, TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/3) methods are used to extract a text in raw mode.

{{< alert style="warning" >}}Raw mode is not supported for password-protected presentations.{{< /alert >}}{{< alert style="warning" >}}Some presentations may have different slide numbers in raw and accurate modes. Use [IDocumentInfo.RawPageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) instead of [IDocumentInfo.PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) in raw mode.{{< /alert >}}

Here are the steps to extract a raw text from the sheet of Microsoft Office PowerPoint presentation:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial presentation;
*   Instantiate [TextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textoptions) object with *true* parameter;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method;
*   Use [RawPageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) instead of [PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) to avoid extra calculations;
*   Call [GetText(pageIndex, TextOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/3) method with the sheet index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example demonstrates how to extract a raw text from the slide of Microsoft Office PowerPoint presentation:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    // Check if the document has slides
    if (documentInfo == null || documentInfo.RawPageCount == 0)
    {
        Console.WriteLine("Document hasn't pages.");
        return;
    }
    // Iterate over slides
    for (int p = 0; p < documentInfo.RawPageCount; p++)
    {
        // Print a slide number 
        Console.WriteLine(string.Format("Slide {0}/{1}", p + 1, documentInfo.RawPageCount));
        // Extract a text into the reader
        using (TextReader reader = parser.GetText(p, new TextOptions(true)))
        {
            // Print a text from the presentation slide
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

GroupDocs.Parser also allows to extract a text from Microsoft Office PowerPoint presentations as HTML, Markdown and formatted plain text. For more details, see [Extract Formatted Text]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/working-with-formatted-text/extract-formatted-text-from-document.md" >}}).

Here are the steps to extract a text from Microsoft Office PowerPoint presentation as HTML:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial presentation;
*   Call [GetFormattedText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example shows how to extract a text from Microsoft Office PowerPoint presentation as HTML:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a formatted text into the reader
    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
    {
        // Print a formatted text from the presentation
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