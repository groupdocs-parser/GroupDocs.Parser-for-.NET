---
id: extract-hyperlinks-from-document-page-area
url: parser/net/extract-hyperlinks-from-document-page-area
title: Extract hyperlinks from document page area
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---

GroupDocs.Parser provides the functionality to extract hyperlinks from document page area by the [GetHyperlinks(PageAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gethyperlinks/methods/1) and [GetHyperlinks(Int32, PageAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gethyperlinks/methods/3) methods:

```csharp
IEnumerable<PageHyperlinkArea> GetHyperlinks(int pageIndex, PageAreaOptions options);
IEnumerable<PageHyperlinkArea> GetHyperlinks(PageAreaOptions options);
```

These methods return a collection of [PageHyperlinkArea](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea) object:

| Member                                                       | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [Page](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/page) | The page that contains the text area.                        |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/rectangle) | The rectangular area on the page that contains the text area. |
| [Text](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea/properties/text) | The hyperlink text.                                          |
| [Url](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea/properties/url) | The hyperlink URL.                                           |

Here are the steps to extract hyperlinks from the document page area:

- Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
- Check if the document supports hyperlink extraction;
- Instantiate [PageAreaOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pageareaoptions) with the rectangular area;
- Call [GetHyperlinks(PageAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gethyperlinks/methods/1) method and obtain collection of [PageHyperlinkArea](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea) objects;
- Iterate through the collection and get a hyperlink text and URL.

The following example shows how to extract hyperlinks from the document page area:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports hyperlink extraction
    if (!parser.Features.Hyperlinks)
    {
        Console.WriteLine("Document isn't supports hyperlink extraction.");
        return;
    }
    // Create the options which are used for hyperlink extraction
    PageAreaOptions options = new PageAreaOptions(new Rectangle(new Point(380, 90), new Size(150, 50)));
    // Extract hyperlinks from the document page area
    IEnumerable<PageHyperlinkArea> hyperlinks = parser.GetHyperlinks(options);
    // Iterate over hyperlinks
    foreach (PageHyperlinkArea h in hyperlinks)
    {
        // Print the hyperlink text
        Console.WriteLine(h.Text);
        // Print the hyperlink URL
        Console.WriteLine(h.Url);
        Console.WriteLine();
    }
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

- [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)
- [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)

### Free online image extractor App

Along with full featured .NET library we provide simple, but powerfull free APPs.

You are welcome to extract images from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [GroupDocs Parser App](https://products.groupdocs.app/parser).