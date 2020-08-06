---
id: extract-text-from-microsoft-office-word-documents
url: parser/net/extract-text-from-microsoft-office-word-documents
title: Extract text from Microsoft Office Word documents
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract a text from Microsoft Office Word documents [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) and [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) methods are used. These methods allow to extract a text from the entire document or a text from the selected page. [TextOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textoptions) parameter is ignored for Microsoft Office Words documents.

Here are the steps to extract a text from Microsoft Office Word document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

{{< alert style="warning" >}}
[GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null* value if text extraction isn't supported for the document. For example, text extraction isn't supported for Zip archive. Therefore, for Zip archive [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null*. For empty Microsoft Office Word document [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns an empty [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object ([reader.ReadToEnd](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoend?view=netframework-2.0) method returns an empty string).
{{< /alert >}}

The following example demonstrates how to extract a text from Microsoft Office Word document:

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

Here are the steps to extract a text from the page of Microsoft Office Word document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method and obtain [IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) object with [page count](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount);
*   Call [GetText(pageIndex)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method with the page index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

{{< alert style="warning" >}}
Text extraction from Microsoft Office Word document page is more resource consuming operation. Use text extraction from the entire document where it is applicable.
{{< /alert >}}

The following example demonstrates how to extract a text from the page of Microsoft Office Word document:

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

GroupDocs.Parser also allows to extract a text from Microsoft Office Word documents as HTML, Markdown and formatted plain text. For more details, see [Extract Formatted Text]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/working-with-formatted-text/extract-formatted-text-from-document.md" >}}).

Here are the steps to extract a text from Microsoft Office Word document as HTML:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetFormattedText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getformattedtext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example shows how to extract a text from Microsoft Office Word document as HTML:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a formatted text into the reader
    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
    {
        // Print a formatted text from the document
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