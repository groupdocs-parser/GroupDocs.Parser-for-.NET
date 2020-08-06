---
id: get-supported-file-formats
url: parser/net/get-supported-file-formats
title: Get supported file formats
weight: 1
description: " "
keywords: Formats Parser .Net dotNet C# CSharp
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser allows to get the list of all the supported file formats by the [GetSupportedFileTypes](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype/methods/getsupportedfiletypes) static method:

```csharp
IEnumerable<FileType> FileType.GetSupportedFileTypes();

```

This method returns a collection of [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype) items with the following members:

| Member | Description |
| --- | --- |
| [FileFormat](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype/properties/fileformat) | File type name e.g. "Microsoft Word Document". |
| [Extension](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype/properties/extension) | Filename suffix (including the period ".") e.g. ".doc". |

Also [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype) contains static fields that represent all the supported file formats.

Here are the steps to get all the supported file formats:

*   Call [GetSupportedFileTypes](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype/methods/getsupportedfiletypes) static method and obtain a collection of [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype) objects;
*   Iterate through the collection and get [FileFormat](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype/properties/fileformat) or [Extension](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype/properties/extension) of [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/filetype).

The following example shows how to print all the supported file types:

```csharp
IEnumerable<FileType> supportedFileTypes = FileType.GetSupportedFileTypes();

foreach (FileType fileType in supportedFileTypes)
{
    Console.WriteLine(fileType);
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