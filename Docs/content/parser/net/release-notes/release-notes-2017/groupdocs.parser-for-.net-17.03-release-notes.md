---
id: groupdocs-parser-for-net-17-03-release-notes
url: parser/net/groupdocs-parser-for-net-17-03-release-notes
title: GroupDocs.Parser for .NET 17.03 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.3.0{{< /alert >}}

## Major Features

The following features have been introduced in this release:

*   Ability to detect EPUB documents and ZIP containers
*   Ability to extract metadata from EPUB documents
*   Ability to search a text in EPUB documents
*   Ability to extract highlights from EPUB documents

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-509 | Implement the ability to detect ZIP files | New feature |
| TEXTNET-510 | Implement the ability to extract metadata from EPUB files | New feature |
| TEXTNET-534 | Implement the ability to extract highlights from EPUB files | New feature |
| TEXTNET-535 | Implement the ability to search a text in EPUB files | New feature |
| TEXTNET-561 | Implement the ability to detect EPUB files | New feature |
| TEXTNET-574 | Implement Extractor class | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.3.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement Extractor Class

This enhancement orders API. Extractor class provides extraction methods.

**Public API Changes**  
Added **Extractor** class.  
**ExtractMetadata** methods in **ExtractorFactory** class are marked as Obsolete (use **Extractor** class instead).  
Added **CreateMetadataExtractor** methods to **ExtractorFactory**.

**Usage of extractor class:**

**C#**

```csharp
var extractor = new Extractor();
var metadata = extractor.ExtractMetadata(stream);

foreach (string key in metadata.Keys)
{
    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
}

```

**CreateMetadataExtractor method usage**

**C#**

```csharp
var factory = new ExtractorFactory();
var extractor = factory.CreateMetadataExtractor(stream);
var metadata = extractor.ExtractMetadata(stream);

foreach (string key in metadata.Keys)
{
    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
}

```

#### Implement the Ability to Detect ZIP Files

This feature allows to detect ZIP containers.

**Public API changes**  
Added **ZipMediaTypeDetector** class.

**Usage of Zip Media type detection:**

**C#**

```csharp
var detector = new ZipMediaTypeDetector();
var mediaType = detector.Detect(stream);

// APPLICATION/ZIP or null if stream is not ZIP container.
Console.WriteLine(mediaType);

```

For detecting any supported media type CompositeMediaTypeDetector class is used:

**CompositeMediaTypeDetector Class Usage**

**C#**

```csharp
var mediaType = CompositeMediaTypeDetector.Default.Detect(stream);

```

It returns media type (APPLICATION/ZIP for ZIP container) or null if media type can't be detected.

#### Implement the Ability to Extract Metadata From EPUB Files

This feature allows to extract metadata from EPUB documents.

**Public API changes**  
Added **EpubMetadataExtractor** class.  
Added **Description**, **Language**, **Copyrights**, **Publisher** and **PublishedDate** constants to **MetadataNames** class.  
Added **ComplexMetadataExtractor** class.

**Extracting metadata from EPUB document:**

**C#**

```csharp
var metadataExtractor = new EpubMetadataExtractor();
var metadata = metadataExtractor.ExtractMetadata(stream);
foreach (string key in metadata.Keys)
{
    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
}

```

EPUB document can contain one or more packages. Each package has its own metadata collection. For working with such metadata ComplexMetadataExtractor class is used. It has ExtractComplexMetadata methods for extracting the complex metadata. The methods return an enumerator for all metadata collections. EpubMetadataExtractor is inherited from ComplexMetadataExtractor class.

**Usage of ComplexMetadataExtractor class:**

**C#**

```csharp
var metadataExtractor = new EpubMetadataExtractor();
using(var enumerator = metadataExtractor.ExtractComplexMetadata(stream)) {
  while(enumerator.MoveNext()) {
    var metadata = enumerator.Current;
    foreach (string key in metadata.Keys) {
      Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
    }
  }
}

```

#### Implement the Ability to Extract Highlights From EPUB Files

This feature allows to extract a highlight from EPUB documents.

**Public API changes**  
Added **ExtractHighlights** method to **EpubTextExtractor** class.

**Usage**

**C#**

```csharp
using (EpubTextExtractor extractor = new EpubTextExtractor(stream)) {
  IList<string> highlights = extractor.ExtractHighlights(HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 9, 3));
  for (int i = 0; i < highlights.Count; i++) {
    Console.WriteLine(highlights[i]);
  }
}

```

#### Implement the Ability to Search a Text in EPUB Files

This feature allows to search with a regular expression or search a text in EPUB documents.

**Public API changes**  
Added **Search** methods to **EpubTextExtractor** class.  
Added **SearchWithRegex** method to **EpubTextExtractor** class.

Following example shows how to search with a regular expression

**C#**

```csharp
using (EpubTextExtractor extractor = new EpubTextExtractor(stream)) {
  var searchOptions = new RegexSearchOptions();
  var handler = new ListSearchHandler();
  extractor.SearchWithRegex("On[a-z]", handler, searchOptions);

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

Following example shows how to search a text in EPUB files

**C#**

```csharp
using (EpubTextExtractor extractor = new EpubTextExtractor(stream)) {
  var options = new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(0));
  var handler = new ListSearchHandler();
  var keywords = new string[] { "One" };
  extractor.Search(options, handler, keywords);

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

#### Implement the Ability to Detect EPUB Files

This feature allows to detect EPUB files.

**Public API changes**  
Added **EpubMediaTypeDetector** class.

**EpubMediaTypeDetector Class Usage**

**C#**

```csharp
var detector = new EpubMediaTypeDetector();
var mediaType = detector.Detect(stream);

// APPLICATION/EPUB+ZIP or null if stream is not EPUB document.
Console.WriteLine(mediaType);

```

For detecting any supported media type CompositeMediaTypeDetector class is used:

**CompositeMediaTypeDetector Class Usage**

**C#**

```csharp
var mediaType = CompositeMediaTypeDetector.Default.Detect(stream);

```

It returns media type (APPLICATION/EPUB+ZIP for EPUB document) or null if media type can't be detected.
