---
id: search-text
url: parser/net/search-text
title: Search text
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to search text from documents by the [Search(string)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) and [Search(string, SearchOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/search/methods/1) methods:

```csharp
IEnumerable<SearchResult> Search(string keyword);
IEnumerable<SearchResult> Search(string keyword, SearchOptions options);
```

The *keyword* parameter can contain a text or a regular expression. [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) class contains every occurrence of the keyword in the document text. This class has the following members:

| Member | Description |
| --- | --- |
| [Position](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult/properties/position) | A zero-based index of the start position of the search result. Depending on [SearchOptions.SearchByPages](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/searchbypages) property value this index starts from the document start or the document page start. |
| [PageIndex](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult/properties/pageindex) | The page index where the text is found. |
| [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult/properties/text) | The found text. |
| [LeftHighlightItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult/properties/lefthighlightitem) | The left highlight. |
| [RightHighlightItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult/properties/righthighlightitem) | The right highlight. |

## Search text by keyword

Here are the steps to search a keyword in the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [Search(string)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) method and obtain collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects;
*   Check if *collection* isn't null (search is supported for the document);
*   Iterate through the collection and get position and text.

The following example shows how to find a keyword in a document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Search a keyword:
    IEnumerable<SearchResult> sr = parser.Search("page number");
    // Check if search is supported
    if(sr == null)
    {
        Console.WriteLine("Search isn't supported");
        return;
    }

    // Iterate over search results
    foreach(SearchResult s in sr)
    {
        // Print an index and found text:
        Console.WriteLine(string.Format("At {0}: {1}", s.Position, s.Text));
    }
}
```

## Search text by regular expression

[SearchOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions) parameter is used to customize a search. This class has the following members:

| Member | Description |
| --- | --- |
| [MatchCase](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/matchcase) | The value that indicates whether a text case isn't ignored. |
| [MatchWholeWord](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/matchwholeword) | The value that indicates whether text search is limited by the whole word. |
| [SearchByPages](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/searchbypages) | The value that indicates whether the search is performed by pages. |
| [UseRegularExpression](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/useregularexpression) | The value that indicates whether a regular expression is used. |
| [LeftHighlightOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/lefthighlightoptions) | The options for the left highlight. |
| [RightHighlightOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions/properties/righthighlightoptions) | The options for the right highlight. |

Here are the steps to search with a regular expression in the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [SearchOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions) object with the parameters for the search;
*   Call [Search(string, SearchOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/search/methods/1) method and obtain collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects;
*   Check if *collection* isn't *null* (search is supported for the document);
*   Iterate through the collection and get position and text.

The following example shows how to search with a regular expression in a document:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Search with a regular expression with case matching
    IEnumerable<SearchResult> sr = parser.Search("page number: [0-9]+", new SearchOptions(true, false, true));
    // Check if search is supported
    if(sr == null)
    {
        Console.WriteLine("Search isn't supported");
        return;
    }

    // Iterate over search results
    foreach(SearchResult s in sr)
    {
        // Print an index and found text:
        Console.WriteLine(string.Format("At {0}: {1}", s.Position, s.Text));
    }
}
```

## Search text with highlights

Here are the steps to search text with a highlights:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Instantiate [HighlightOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/highlightoptions) object with the parameters for the highlight extraction;
*   Instantiate [SearchOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions) object with the parameters for the search;
*   Call [Search(string, SearchOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/search/methods/1) method and obtain collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects;
*   Check if *collection* isn't *null* (search is supported for the document);
*   Iterate through the collection and get position and text.

The following example shows how to search a text with the highlights:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(Constants.SamplePdf))
{
    HighlightOptions highlightOptions = new HighlightOptions(15);
    // Search a keyword:
    IEnumerable<SearchResult> sr = parser.Search("lorem", new SearchOptions(true, false, false, highlightOptions));
    // Check if search is supported
    if (sr == null)
    {
        Console.WriteLine("Search isn't supported");
        return;
    }
    // Iterate over search results
    foreach (SearchResult s in sr)
    {
        // Print the found text and highlights: 
        Console.WriteLine(string.Format("{0}{1}{2}", s.LeftHighlightItem.Text, s.Text, s.RightHighlightItem.Text));
    }
}
```

## Search text with page numbers

Here are the steps to search text with page numbers:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser)  object for the initial document;
*   Instantiate [SearchOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions) object with the parameters for the search;
*   Call [Search(string, SearchOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/search/methods/1) method and obtain collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects;
*   Check if *collection* isn't null (search is supported for the document);
*   Iterate through the collection and get position, text and page number.

The following example shows how to search a text with page numbers:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(Constants.SamplePdf))
{
    // Search a keyword with page numbers
    IEnumerable<SearchResult> sr = parser.Search("lorem", new SearchOptions(false, false, false, true));
    // Check if search is supported
    if(sr == null)
    {
        Console.WriteLine("Search isn't supported");
        return;
    }
 
    // Iterate over search results
    foreach(SearchResult s in sr)
    {
        // Print an index, page number and found text:
        Console.WriteLine(string.Format("At {0} (page {1}): {2}", s.Position, s.PageIndex, s.Text));
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