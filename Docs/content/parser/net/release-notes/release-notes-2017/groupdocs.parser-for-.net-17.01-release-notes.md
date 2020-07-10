---
id: groupdocs-parser-for-net-17-01-release-notes
url: parser/net/groupdocs-parser-for-net-17-01-release-notes
title: GroupDocs.Parser for .NET 17.01 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.1.0{{< /alert >}}

## Major Features

There are following features in this release:

*   Ability to search a text
*   Ability to extract highlight
*   Support for extracting documents from ZIP containers

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-338 | Implement the ability to search a text | New Feature |
| TEXTNET-339 | Implement the ability to extract highlight | New Feature |
| TEXTNET-252 | Implement the support for ZIP containers | New Feature |
| TEXTNET-496 | Implement the ability to open password-protected OneNote sections | New Feature |
| TEXTNET-504 | Add enum property to set extraction mode | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.1.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Add enum property to set extraction mode

This enhancement allows to set extraction mode via enumeration (ExtractionMode) instead of boolean property (IsRawMode).

**Public API Changes**  
Added **ExtractionMode** enumeration.  
Added **ExtractionMode** property to PdfTextExtractor, CellsTextExtractor and SlidesTextExtractor classes.  
**IsRawMode** property is marked as Obsolete in PdfTextExtractor, CellsTextExtractor and SlidesTextExtractor classes.

**C#**

```csharp
using (var extractor = new SlidesTextExtractor(stream)) {
  extractor.ExtractMode = ExtractMode.Standard;
  extractor.ExtractAll();
}

```

#### Implement the support for ZIP containers

This feature allows to open documents from ZIP containers.

**Public API changes**  
Added **ZipContainer** class.

Enumerate all files in the archive:

**C#**

```csharp
using (var container = new ZipContainer(stream))
{
  for(int i = 0; i < container.Entities.Count; i++)
  {
    Console.WriteLine("Name: " + container.Entities[i].Name);
    Console.WriteLine("Path: " + container.Entities[i].Path.ToString());
    Console.WriteLine("Media type: " + container.Entities[i].MediaType);
  }
}

```

Read the concrete file:

**C#**

```csharp
using (var container = new ZipContainer(stream))
{
  using (TextExtractor extractor = extractorFactory.CreateTextExtractor(container.Entities[index].OpenStream())
  {
    Console.WriteLine(extractor.ExtractAll());
  }
}

```

#### Implement the ability to search a text

This feature allows to search text in documents.

**Public API changes**  
Added **ISearchable** interface.  
Added **ISearchHandler** interface.  
Added **ISearchEngine** interface.  
Added **SearchResult** class  
Added **SearchOptions** class.  
Added **SearchHighlightOptions** class.  
Added **ContainsSearchHandler** and **ListSearchHandler** classes.

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx"))
{
  ListSearchHandler handler = new ListSearchHandler();
  extractor.Search(new SearchOptions(new SearchHighlightOptions(10)), handler, null, new string[] { "test text", "keyword" });

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

#### Implement the ability to extract highlight

This feature allows to extract highlights from documents.

**Public API changes**

Added **IHighlightExtractor** interface.  
Added **HighlightOptions** class.  
Added **HighlightDirection** enum.

**C#**

```csharp
using (WordsTextExtractor extractor = new WordsTextExtractor(@"document.docx"))
{
  IList<string> highlights = extractor.ExtractHighlights(
  HighlightOptions.CreateFixedLength(HighlightDirection.Left, 15, 10),
  HighlightOptions.CreateFixedLength(HighlightDirection.Right, 20, 10));

  for (int i = 0; i < highlights.Count; i++)
  {
    Console.WriteLine(highlights[i]);
  }
}
```

#### Implement the ability to open password-protected OneNote sections

This feature allows to open password-protected OneNote sections.

**C#**

```csharp
var loadOptions = new LoadOptions();
loadOptions.Password = "123456";

using (var extractor = new NoteTextExtractor("password-protected.one", loadOptions))
{
  Console.WriteLine(extractor.ExtractAll());
}
```
