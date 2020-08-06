---
id: search-text-in-epub-ebooks
url: parser/net/search-text-in-epub-ebooks
title: Search text in EPUB eBooks
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To search a keyword in EPUB e-books [Search(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) method is used. This method returns the collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects. For details, see [Search Text]({{< ref "parser/net/developer-guide/advanced-usage/working-with-text/search-text.md" >}}).

Here are the steps to search a keyword in EPUB e-book:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Call [Search(string)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) method and obtain the collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects;
*   Iterate through the collection and get the position and text.

{{< alert style="warning" >}}
[Search(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) method returns *null* value if search isn't supported for the e-book. For example, text extraction isn't supported for Zip archive. Therefore, for Zip archive [Search(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) method returns *null*. For empty EPUB e-book [Search(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/search) method returns an empty collection.
{{< /alert >}}

The following example shows how to find a keyword in EPUB e-book:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Search a keyword:
    IEnumerable<SearchResult> sr = parser.Search("page number");
   
    // Iterate over search results
    foreach(SearchResult s in sr)
    {
        // Print an index and found text:
        Console.WriteLine(string.Format("At {0}: {1}", s.Position, s.Text));
    }
}
```

[Search(String, SearchOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/search/methods/1) is used for the advanced search in EPUB e-books - like search with regular expressions, search by pages etc. [SearchOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions) parameter is used to customize a search.

Here are the steps to search with a regular expression in EPUB e-book:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial e-book;
*   Instantiate [SearchOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/searchoptions) object with the parameters for the search;
*   Call [Search(string, SearchOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/search/methods/1) method and obtain the collection of [SearchResult](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/searchresult) objects;
*   Iterate through the collection and get the position and text.

The following example shows how to search with a regular expression in EPUB e-book:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Search with a regular expression with case matching
    IEnumerable<SearchResult> sr = parser.Search("page number: [0-9]+", new SearchOptions(true, false, true));
    // Iterate over search results
    foreach(SearchResult s in sr)
    {
        // Print an index and found text:
        Console.WriteLine(string.Format("At {0}: {1}", s.Position, s.Text));
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