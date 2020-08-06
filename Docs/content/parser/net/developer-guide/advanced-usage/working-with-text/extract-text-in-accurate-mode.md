---
id: extract-text-in-accurate-mode
url: parser/net/extract-text-in-accurate-mode
title: Extract text in Accurate mode
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract text from documents.

The **Accurate** mode is default text extraction mode and it means that text quality wlll be the best possible.

You can extract the whole document text or only a document page.

To extract a text from the document in the Accurate mode, [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) and [GetText(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) methods of [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) class are used:

```csharp
TextReader GetText();
TextReader GetText(int pageIndex);
```

Methods return an instance of [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) class with the extracted text. The first method extracts text from the whole document. The second method extracts text from the document page. To retrieve the total number of document pages [GetDocumentIn](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo)[fo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo)  method is used (see below).

## Extract text

Here are the steps to extract text from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettext) method and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Check if *reader* isn't null (text extraction is supported for the document);
*   Read a text from *reader*.

The following example shows how to extract text from a document:

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

## Extract text from a document page

Here are the steps to extract text from a document page:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [Features.Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/text) property to check if text extraction is supported for the document;
*   Call [GetText(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method with the page index and obtain [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netframework-2.0) object;
*   Read a text from *reader*.

The following example shows how to extract a text from the document page:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Check if the document supports text extraction
    if(!parser.Features.Text)
    {
        Console.WriteLine("Document isn't supports text extraction.");
        return;   
	}

    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    // Check if the document has pages
    if(documentInfo.PageCount == 0)
    {
        Console.WriteLine("Document hasn't pages.");
        return;
    }
 
    // Iterate over pages
    for(int p = 0; p < documentInfo.PageCount; p++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.PageCount));
 
        // Extract a text into the reader
        using(TextReader reader = parser.GetText(p))
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