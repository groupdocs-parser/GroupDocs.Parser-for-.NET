---
id: extract-hyperlinks-from-document
url: parser/net/extract-hyperlinks-from-document
title: Extract hyperlinks from document
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---

GroupDocs.Parser provides the functionality to extract hyperlinks from documents by the [GetHyperlinks](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/gethyperlinks) method:

```csharp
IEnumerable<PageHyperlinkArea> GetHyperlinks();
```

This method returns a collection of [PageHyperlinkArea](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea) object:

| Member                                                       | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [Page](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/page) | The page that contains the text area.                        |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/rectangle) | The rectangular area on the page that contains the text area. |
| [Text](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea/properties/text) | The hyperlink text.                                          |
| [Url](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea/properties/url) | The hyperlink URL.                                           |

Here are the steps to extract all hyperlinks from the whole document:

- Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
- Check if the document supports hyperlink extraction;
- Call [GetHyperlinks](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/gethyperlinks) method and obtain collection of [PageHyperlinkArea](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea) objects;
- Iterate through the collection and get a hyperlink text and URL.

The following example shows how to extract all hyperlinks from the whole document:

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
    // Extract hyperlinks from the document
    IEnumerable<PageHyperlinkArea> hyperlinks = parser.GetHyperlinks();
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