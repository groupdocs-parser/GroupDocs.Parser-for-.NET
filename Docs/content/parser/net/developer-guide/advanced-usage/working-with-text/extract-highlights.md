---
id: extract-highlights
url: parser/net/extract-highlights
title: Extract highlights
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract a highlight (a part of the text which is usually used to explain the context of the found text in the search functionality) from documents by the [GetHighlight](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gethighlight) method:

```csharp
HighlightItem GetHighlight(int position, bool isDirect, HighlightOptions options);
```

The *position* parameter defines the start position from which the highlight is extracted. The *isDirect* parameter indicates whether highlight extraction is direct: *true* if the highlight is extracted by the right of the position; otherwise, *false*. [HighlightOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/highlightoptions) parameter is used to define the end of the highlight.

[HighlightOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/highlightoptions) class has the following constructors:

```csharp
// Highlight is limited to maxLength text length.
HighlightOptions(int maxLength);
// Highlight is limited to the start (or the end) of a text line (or maxLength text length - if set).
HighlightOptions(int? maxLength, bool isLineLimited);
// Highlight is limited to word count (or maxLength text length - if set).
HighlightOptions(int? maxLength, int wordCount);
// General constructor
HighlightOptions(int? maxLength, int? wordCount, bool isLineLimited);
```

[HighlightItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem) class has the following members:

| Member | Description |
| --- | --- |
| [Position](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem/properties/position) | The position in the document text. |
| [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem/properties/text) | The highlight text. |

Here are the steps to extract highlight from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [HighlightOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/highlightoptions) object with the extraction parameters;
*   Call [GetHighlight](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gethighlight) method and obtain the [HighlightItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem) object;
*   Check if [HighlightItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem) isn't null (highlight extraction is supported for the document);
*   Call properties such as  [Position](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem/properties/position) and [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/highlightitem/properties/text).

The following example shows how to extract a highlight that contains 3 words:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a highlight:
    HighlightItem hl = parser.GetHighlight(2, true, new HighlightOptions(3));
    // Check if highlight extraction is supported
    if (hl == null)
    {
        Console.WriteLine("Highlight extraction isn't supported");
        return;
    }
    // Print an extracted highlight
    Console.WriteLine(string.Format("At {0}: {1}", hl.Position, hl.Text));
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