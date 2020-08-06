---
id: get-document-info
url: parser/net/get-document-info
title: Get document info
weight: 2
description: " "
keywords: Dofument Info Parser C# CSharp .Net dotNet
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to get the basic document info by the [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method:

```csharp
IDocumentInfo GetDocumentInfo();

```

[IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) interface has the following members:

| Member | Description |
| --- | --- |
| [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/filetype) | The document type. |
| [PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) | The total number of document pages. |
| [Size](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/size) | The size of the document in bytes. |

Here are the steps to get document info:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getdocumentinfo) method and obtain the object with [IDocumentInfo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo) interface;
*   Call properties such as [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/filetype), [PageCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/pagecount) or [Size](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/idocumentinfo/properties/size).

The following example shows how to get document info:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Get the document info
    IDocumentInfo info = parser.GetDocumentInfo();

    Console.WriteLine(string.Format("FileType: {0}", info.FileType));
    Console.WriteLine(string.Format("PageCount: {0}", info.PageCount));
    Console.WriteLine(string.Format("Size: {0}", info.Size));
}

```

## More resources

### Advanced usage topics

To learn more about document data extraction features and get familiar how to extract text, images, forms and more, please refer to the [advanced usage section]({{< ref "parser/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).