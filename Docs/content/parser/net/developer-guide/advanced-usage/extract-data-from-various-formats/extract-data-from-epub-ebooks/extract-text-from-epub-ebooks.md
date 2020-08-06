---
id: extract-text-from-epub-ebooks
url: parser/net/extract-text-from-epub-ebooks
title: Extract text from EPUB eBooks
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract a text from EPUB e-books [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) and [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) methods is used. These methods allow to extract a text from the entire document or a text from the selected page. Raw mode is not supported for EPUB.

Here are the steps to extract a text from EPUB e-book:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

{{< alert style="warning" >}}
[GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null* value if text extraction isn't supported for the document. For example, text extraction isn't supported for Zip archive. Therefore, for Zip archive [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null*. For empty EPUB e-book [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns an empty [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object ([reader.ReadToEnd](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoend?view=netframework-2.0) method returns an empty string).
{{< /alert >}}

The following example demonstrates how to extract a text from EPUB e-book:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract a text into the reader
    using(TextReader reader = parser.GetText())
    {
        // Print a text from the e-book
        Console.WriteLine(reader.ReadToEnd());
    }
}
```

Here are the steps to extract a text from the page of EPUB e-book:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method and obtain [IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) object with [page count](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount);
*   Call [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method with the page index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example demonstrates how to extract a text from the page of EPUB e-book:

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
            // Print a text from the e-book
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

GroupDocs.Parser also allows to extract a text from EPUB e-books as HTML, Markdown and formatted plain text. For more details, see [Extract Formatted Text]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/working-with-formatted-text/extract-formatted-text-from-document.md" >}}).

Here are the steps to extract a text from EPUB e-book as HTML:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Call [GetFormattedText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example shows how to extract a text from EPUB e-book as HTML:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a formatted text into the reader
    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
    {
        // Print a formatted text from the e-book
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