---
id: extract-table-of-contents
url: parser/net/extract-table-of-contents
title: Extract table of contents
weight: 11
description: "With GroupDocs.Parser you may extract table of contents from Microsoft Word (DOC, DOCX etc), PDF documents and Ebooks (CHM, EPUB)."
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser allows to extract table of contents from Microsoft Word (DOC, DOCX etc), PDF documents and Ebooks.

## Extract table of contents

To extract TOC from documents, please use the [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method:

```csharp
IEnumerable<TocItem> GetToc()

```

[TocItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem) class has the following members:

| Member | Description |
| --- | --- |
| [Depth](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem/properties/depth) | The depth level. |
| [PageIndex](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem/properties/pageindex) | The page index. |
| [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem/properties/text) | The text. |
| TextReader [ExtractText()](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem/methods/extracttext) | Extract a text from the document to which [TocItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem) object refers. For detail, see [Extract Text By Table of Contents Item]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/extract-text-by-table-of-contents-item.md" >}}) |

Here are the steps to extract extract table of contents from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method and obtain collection of [TocItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem) objects;
*   Check if *collection* isn't *null* (table of contents  extraction is supported for the document);
*   Iterate through the collection and get page index to extract a page text from the document.

The following example shows how to extract table of contents from CHM file:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if text extraction is supported
    if (!parser.Features.Text)
    {
        Console.WriteLine("Text extraction isn't supported.");
        return;
    }
    // Check if toc extraction is supported
    if (!parser.Features.Toc)
    {
        Console.WriteLine("Toc extraction isn't supported.");
        return;
    }
    // Get table of contents
    IEnumerable<TocItem> toc = parser.GetToc();
    // Iterate over items
    foreach (TocItem i in toc)
    {
        // Print the Toc text
        Console.WriteLine(i.Text);
        // Check if page index has a value
        if (i.PageIndex == null)
        {
            continue;
        }
        // Extract a page text
        using (TextReader reader = parser.GetText(i.PageIndex.Value))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
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

You are welcome to extract text, metadata and images from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).