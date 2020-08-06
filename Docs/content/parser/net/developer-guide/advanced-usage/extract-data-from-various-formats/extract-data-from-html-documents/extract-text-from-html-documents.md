---
id: extract-text-from-html-documents
url: parser/net/extract-text-from-html-documents
title: Extract text from HTML documents
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract a text from HTML documents [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method is used. This method allows to extract a text from the entire document. Pagination and raw mode is not supported for emails.

Here are the steps to extract a text from HTML document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

{{< alert style="warning" >}}
[GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null* value if text extraction isn't supported for the document. For example, text extraction isn't supported for Zip archive. Therefore, for Zip archive [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns *null*. For an HTML document [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method returns an empty [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object ([reader.ReadToEnd](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoend?view=netframework-2.0) method returns an empty string).
{{< /alert >}}

The following example demonstrates how to extract a text from HTML document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract a text into the reader
    using(TextReader reader = parser.GetText())
    {
        // Print a text from the email
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