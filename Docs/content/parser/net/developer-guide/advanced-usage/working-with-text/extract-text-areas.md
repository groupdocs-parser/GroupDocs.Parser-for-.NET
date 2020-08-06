---
id: extract-text-areas
url: parser/net/extract-text-areas
title: Extract text areas
weight: 7
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract text areas from documents by the following methods:

```csharp
IEnumerable<PageTextArea> GetTextAreas();
IEnumerable<PageTextArea> GetTextAreas(PageTextAreaOptions options);
IEnumerable<PageTextArea> GetTextAreas(int pageIndex);
IEnumerable<PageTextArea> GetTextAreas(int pageIndex, PageTextAreaOptions options);
```

The methods return a collection of [PageTextArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea) objects:

| Member | Description |
| --- | --- |
| [Page](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/page) | The page that contains the text area. |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/rectangle) | The rectangular area on the page that contains the text area. |
| [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/text) | The value of the text area. |
| [BaseLine](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/baseline) | The base line of the text area. |
| [TextStyle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/textstyle) | The text style of the text area. |
| [Areas](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/areas) | The collection of child text areas. |

Text area represents a rectangular page area with a text. Text area can be simple or composite. The simple text area contains only a text and [Areas](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/areas) property is always an empty collection (not null). The composite text area doesn't have its own text. Text property is calculated by its children texts which are contained in [Areas](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/areas) property.

## Extract text areas

Here are the steps to extract text areas from the whole document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetTextAreas](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettextareas) method and obtain collection of [PageTextArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea) objects;
*   Check if *collection* isn't *null* (text areas extraction is supported for the document);
*   Iterate through the collection and get rectangles and text.

The following example shows how to extract all text areas from the whole document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract text areas
    IEnumerable<PageTextArea> areas = parser.GetTextAreas();
    // Check if text areas extraction is supported
    if(areas == null)
    {
        Console.WriteLine("Page text areas extraction isn't supported");
        return;
    }

    // Iterate over page text areas
    foreach(PageTextArea a in areas)
    {
        // Print a page index, rectangle and text area value:
        Console.WriteLine(string.Format("Page: {0}, R: {1}, Text: {2}", a.Page.Index, a.Rectangle, a.Text));
    }
}
```

## Extract text areas from a document page

Here are the steps to extract text areas from a document page:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [Features.TextAreas](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/textareas) property to check if text areas extraction is supported for the document;
*   Call [GetTextAreas(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettextareas/methods/2) method with the page index and obtain collection of [PageTextArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea) objects;
*   Check if *collection* isn't *null* (text areas extraction is supported for the document);
*   Iterate through the collection and get rectangles and text.

The following example shows how to extract text areas from a document page:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Check if the document supports text areas extraction
    if(!parser.Features.TextAreas)
    {
        Console.WriteLine("Document isn't supports text areas extraction.");
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
    for(int pageIndex = 0; pageIndex < documentInfo.PageCount; pageIndex++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", pageIndex + 1, documentInfo.PageCount));

        // Iterate over page text areas
        // We ignore null-checking as we have checked text areas extraction feature support earlier
        foreach(PageTextArea a in parser.GetTextAreas(pageIndex))
        {
            // Print a rectangle and text area value:
            Console.WriteLine(string.Format("R: {0}, Text: {1}", a.Rectangle, a.Text));
        }
    }
}
```

## Extract text areas with options

[PageTextAreaOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pagetextareaoptions) parameter is used to customize text areas extraction process. This class has the following members:

| Member | Description |
| --- | --- |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pageareaoptions/properties/rectangle) | The rectangular area that contains a text area. |
| [Expression](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pagetextareaoptions/properties/expression) | The regular expression. |
| [MatchCase](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pagetextareaoptions/properties/matchcase) | The value that indicates whether a text case isn't ignored. |
| [UniteSegments](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pagetextareaoptions/properties/unitesegments) | The value that indicates whether segments are united. |
| [IgnoreFormatting](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pagetextareaoptions/properties/ignoreformatting) | The value that indicates whether text formatting is ignored. |

Here are the steps to extract text areas from the upper-left corner:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [PageTextAreaOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/pagetextareaoptions) with the rectangular area;
*   Call [GetTextAreas(int, PageTextAreaOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettextareas/methods/3) method and obtain collection of [PageTextArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea) objects;
*   Check if *collection* isn't *null* (text areas extraction is supported for the document);
*   Iterate through the collection and get rectangles and text.

The following example shows how to extract only text areas with digits from the upper-left corner:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Create the options which are used for text area extraction
    PageTextAreaOptions options = new PageTextAreaOptions("[0-9]+", new Rectangle(new Point(0, 0), new Size(300, 100)));

    // Extract text areas which contain only digits from the upper-left corner of a page:
    IEnumerable<PageTextArea> areas = parser.GetTextAreas(options);
    // Check if text areas extraction is supported
    if(areas == null)
    {
        Console.WriteLine("Page text areas extraction isn't supported");
        return;
    }

    // Iterate over page text areas
    foreach(PageTextArea a in areas)
    {
        // Print a page index, rectangle and text area value:
        Console.WriteLine(string.Format("Page: {0}, R: {1}, Text: {2}", a.Page.Index, a.Rectangle, a.Text));
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