---
id: detect-encoding
url: parser/net/detect-encoding
title: Detect encoding
weight: 8
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to detect the encoding of a plain text file. The following encodings are supported:

*   UTF32 LE
*   UTF32 BE
*   UTF16 LE
*   UTF16 BE
*   UTF8
*   UTF7
*   ANSI  

Encoding can be detected by BOM or by the content of the file (if BOM isn't presented). 

Here are the steps to detect the encoding of the document:

*   Instantiate [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions) object with the default ANSI encoding;
*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method and cast the result to [TextDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textdocumentinfo);
*   Read the [Encoding](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/textdocumentinfo/properties/encoding) property.

The following example shows how to detect the encoding of the document:

```csharp
// Create an instance of LoadOptions class with the default ANSI encoding.
// This encoding is returned for ANSI text documents.
LoadOptions loadOptions = new LoadOptions(FileFormat.WordProcessing, null, null, Encoding.GetEncoding(1251));
// Create an instance of Parser class
using (Parser parser = new Parser(Constants.SampleText, loadOptions))
{
    // Get the document info
    TextDocumentInfo info = parser.GetDocumentInfo() as TextDocumentInfo;
    // Check if it's the document info of a plain text document
    if (info == null)
    {
        Console.WriteLine("Isn't a plain text document");
        return;
    }

    // Print the encoding
    Console.WriteLine("Encoding: " + info.Encoding.WebName);
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