---
id: extract-table-of-contents-from-epub-ebooks
url: parser/net/extract-table-of-contents-from-epub-ebooks
title: Extract table of contents from EPUB eBooks
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract table of contents from EPUB e-books [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method is used.

{{< alert style="warning" >}}
[GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method returns *null* value if table of contents extraction isn't supported for the document. For example, table of contents extraction isn't supported for TXT files. Therefore, for TXT file [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method returns *null*. If EPUB e-book has no table of contents, [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method returns an empty collection.
{{< /alert >}}

Here are the steps to extract extract table of contents from EPUB e-book:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Call [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method and obtain collection of [TocItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem) objects;
*   Iterate through the collection and get page index to extract a page text from the document.

The following example shows how to extract table of contents from EPUB e-book:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
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

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).