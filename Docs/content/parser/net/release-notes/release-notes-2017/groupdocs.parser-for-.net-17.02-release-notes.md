---
id: groupdocs-parser-for-net-17-02-release-notes
url: parser/net/groupdocs-parser-for-net-17-02-release-notes
title: GroupDocs.Parser for .NET 17.02 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.2.0{{< /alert >}}

## Major Features

There are the following features in this release:

*   Support for extracting a text from EPUB documents
*   Ability to search with a regular expression
*   Ability to search the whole word
*   Ability to extract a highlight to line's start/end or with the limited words count

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-525 | Implement the ability to extract a text from EPUB files | New feature |
| TEXTNET-340 | Implement the ability to search a text with a regular expression | New feature |
| TEXTNET-492 | Implement the ability to search the whole word | New feature |
| TEXTNET-494 | Implement the ability to extract a highlight to line's start (end) | New feature |
| TEXTNET-495 | Implement the ability to extract a highlight with the limited words count | New feature |
| TEXTNET-528 | Implement the ability to use all highlight extraction modes with search functionality | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.2.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement the ability to use all highlight extraction modes with search functionality

This enhancement allows to use all highlight extraction modes with search functionality.

**Public API Changes**  
Added (int leftLength, int rightLength, HighlightMode highlightMode) constructor to **SearchHighlightOptions** class.  
Added **HighlightMode** property to **SearchHighlightOptions** class.  
Added **WordSeparators** property (and constructor to initialize it) to **SearchOptions** class.  
Added **WordSeparators** property (and constructor to initialize it) to **RegexSearchOptions** class.  
Added **CreateLeftHighlightOptions** and **CreateRightHighlightOptions** methods to **SearchOptions** class.  
Added **CreateLeftHighlightOptions** and **CreateRightHighlightOptions** methods to **RegexSearchOptions** class.  
Added void Search(SearchOptions options, ISearchHandler handler, IList<string> keywords) to **ISearchable** interface.

Following example shows searching a text with highlights limited by line's start/end.

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx"))
{
  ListSearchHandler handler = new ListSearchHandler();
  SearchHighlightOptions highlightOptions = SearchHighlightOptions.CreateLineOptions(100, 100);
  extractor.Search(new SearchOptions(highlightOptions), handler, null, new string[] { "test text", "keyword" });

  if (handler.List.Count == 0)
  {
    Console.WriteLine("Not found");
  }
  else
  {
    for (int i = 0; i < handler.List.Count; i++)
    {
      Console.Write(handler.List[i].LeftText);
      Console.Write("_");
      Console.Write(handler.List[i].FoundText);
      Console.Write("_");
      Console.Write(handler.List[i].RightText);
      Console.WriteLine("---");
    }
  }
}

```

#### Implement the ability to search a text with a regular expression

This feature allows to search a text in documents with regular expressions.

**Public API changes**  
Added **IRegexSearchable** interface.  
Added **RegexSearchOptions** class.

Enumerate all files in the archive:

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx"))
{
  ListSearchHandler handler = new ListSearchHandler();
  extractor.SearchWithRegex("19[0-9]{2}", handler, new RegexSearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(10)));

  if (handler.List.Count == 0)
  {
    Console.WriteLine("Not found");
  }
  else
  {
    for (int i = 0; i < handler.List.Count; i++)
    {
      Console.Write(handler.List[i].LeftText);
      Console.Write("_");
      Console.Write(handler.List[i].FoundText);
      Console.Write("_");
      Console.Write(handler.List[i].RightText);
      Console.WriteLine("---");
    }
  }
}

```

#### Implement the ability to search the whole word

This feature allows to search the whole word in documents.

**Public API changes**  
Added two constructors with **isWholeWord** and **wordsSeparators** arguments to **SearchOptions** class.  
Added **IsWholeWord** and **WordSeparators** properties to **SearchOptions** class.

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx"))
{
  SearchOptions searchOptions = new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(15), true, true);
  ListSearchHandler handler = new ListSearchHandler();
  extractor.Search(searchOptions, handler, null, new string[] { "test", "keyword" });

  if (handler.List.Count == 0)
  {
    Console.WriteLine("Not found");
  }
  else
  {
    for (int i = 0; i < handler.List.Count; i++)
    {
      Console.Write(handler.List[i].LeftText);
      Console.Write("_");
      Console.Write(handler.List[i].FoundText);
      Console.Write("_");
      Console.Write(handler.List[i].RightText);
      Console.WriteLine("---");
    }
  }
}
```

#### Implement the ability to extract a highlight to line's start (end)

This feature allows to limit highlight by the start or end of line. Highlight is a part of the text. Usually it is used to explain a context of the found text.

**Public API changes**  
Added **CreateLineOptions** methods to **HighlightOptions** class.  
Added **CreateLineOptions** methods to **SearchHighlightOptions** class.  
Added Line value to HighlightMode enum.

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx")) {
  IList<string> highlights = extractor.ExtractHighlights(
    HighlightOptions.CreateLineOptions(HighlightDirection.Left, 15),
    HighlightOptions.CreateLineOptions(HighlightDirection.Right, 20));

  for (int i = 0; i < highlights.Count; i++) {
    Console.WriteLine(highlights[i]);
  }
}
```

#### Implement the ability to extract a highlight with the limited words count

This feature allows to limit highlight by the words count. Highlight is a part of the text. Usually it is used to explain a context of the found text.  
**Public API changes**  
Added **CreateWordsCount** methods to **HighlightOptions** class.  
Added Mode property to **HighlightOptions** class.  
Added **HighlightMode** enum.  
Added **WordSeparators** class.  
Added **WordSeparators** property to **HighlightOptions** class.  
Added **CreateFixedLengthOptions** methods to **HighlightOptions** class.  
Added **CreateWordsCountOptions** methods to **HighlightOptions** class.  
Added **CreateWordsCountOptions** methods to **SearchHighlightOptions** class.  
Constructors of SearchHighlightOptions class are marked as **Obsolete** (use CreateXXX static methods instead).  
CreateFixedLength method in HighlightOptions is marked as **Obsolete** (use CreateFixedLengthOptions method instead).

Following example shows highlight extraction with five words from the position

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx")) {
  IList<string> highlights = extractor.ExtractHighlights(
    HighlightOptions.CreateWordsCountOptions(HighlightDirection.Left, 15, 5),
    HighlightOptions.CreateWordsCountOptions(HighlightDirection.Right, 20, 5));

  for (int i = 0; i < highlights.Count; i++) {
    Console.WriteLine(highlights[i]);
  }
}

```

#### Implement the ability to extract a text from EPUB files

This feature allows to extract a text from EPUB documents.  
**Public API changes**  
Added **EpubTextExtractor** class.  
Added **EpubPackage** class.

Following example extracts a line of characters from a document:

**C#**

```csharp
using (var extractor = new EpubTextExtractor(stream)) {
  string line = extractor.ExtractLine();
  while (line != null) {
    Console.WriteLine(line);
    line = extractor.ExtractLine();
  }
}

```

Following example extracts all characters from a document:

**C#**

```csharp
using (var extractor = new EpubTextExtractor(stream)) {
  Console.WriteLine(extractor.ExtractAll());
}

```

GetTextReader method is another way to extract a text from content documents. This method returns TextReader class:

**C#**

```csharp
using (TextReader reader = package.GetTextReader(0)) {
  string line = reader.ReadLine();
  while (line != null) {
    Console.WriteLine(line);
    line = reader.ReadLine();
  }
}

```
