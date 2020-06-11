---
id: groupdocs-parser-for-net-17-06-release-notes
url: parser/net/groupdocs-parser-for-net-17-06-release-notes
title: GroupDocs.Parser for .NET 17.06 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.6.0{{< /alert >}}

## Major Features

There are the following features in this release:

*   Implemented the ability to extract formatted highlights.
*   Implemented the ability to extract a formatted text from FictionBook (fb2) documents.
*   Removed IsRawMode obsolete property from PdfTextExtractor, CellsTextExtractor and SlidesTextExtractor classes.

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-524 | Remove IsRawMode obsolete property from PdfTextExtractor, CellsTextExtractor and SlidesTextExtractor classes | Enhancement |
| TEXTNET-541 | Implement the ability to extract a formatted text from FictionBook (fb2) documents | New feature |
| TEXTNET-547 | Implement the ability to extract formatted highlights | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.6.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Remove IsRawMode obsolete property from PdfTextExtractor, CellsTextExtractor and SlidesTextExtractor classes

**IsRawMode** obsolete property was removed in this enhancement.

**Public API Changes**  
**IsRawMode** obsolete property was removed from **PdfTextExtractor**, **CellsTextExtractor** and **SlidesTextExtractor** classes.

Use **ExtractMode** instead:

**C#**

```csharp
using (var extractor = new SlidesTextExtractor(stream)) { 
  extractor.ExtractMode = ExtractMode.Standard; 
  extractor.ExtractAll(); 
} 

```

#### Implement the ability to extract a formatted text from FictionBook (fb2) documents

This feature allows to extract a formatted text from FictionBook (fb2) documents.

**Public API changes**  
Added **FictionBookFormattedTextExtractor** class.

Extracting a formatted text:

**C#**

```csharp
// Create a formatted text extractor for FictionBook (fb2)documents 
using (var extractor = new FictionBookFormattedTextExtractor(stream)) { 
// Set a document formatter to Markdown 
extractor.DocumentFormatter = new FictionBookFormattedTextExtractor(); 
// Extact a text and print it to the console 
Console.Write(extractor.ExtractAll()); 
} 

```

#### Implement the ability to extract formatted highlights

This feature allows to extract formatted highlights from documents.

**Public API changes**  
Added **ExtractHighlights** method to **WordsFormattedTextExtractor** class.  
Added **ExtractHighlights** method to **SlidesFormattedTextExtractor** class.  
Added **ExtractHighlights** method to **CellsFormattedTextExtractor** class.  
Added **ExtractHighlights** method to **FictionBookFormattedTextExtractor** class.  
Added **ExtractHighlights** method to **EpubFormattedTextExtractor** class.  
Added **ExtractHighlights** method to **EmailFormattedTextExtractor** class.

**C#**

```csharp
using (WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(@"document.docx"))
{
  IList<string> highlights = extractor.ExtractHighlights(
  HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 15, 10),
  HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 20, 10));

  for (int i = 0; i < highlights.Count; i++)
  {
    Console.WriteLine(highlights[i]);
  }
}
```
