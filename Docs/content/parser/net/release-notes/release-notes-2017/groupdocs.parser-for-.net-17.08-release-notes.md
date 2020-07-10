---
id: groupdocs-parser-for-net-17-08-release-notes
url: parser/net/groupdocs-parser-for-net-17-08-release-notes
title: GroupDocs.Parser for .NET 17.08 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.8.0.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Implement the support for CHM files

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-653 | Implement the support for CHM files | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.8.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement the ability to extract a text from pdf portfolios

This feature allows to extract a raw text from .CHM files.

**Public API Changes**  
Added **ChmTextExtractor** class.

Extracts a line of characters from a document:

**C#**

```csharp
// Create a text extractor for CHM documents
using (var extractor = new ChmTextExtractor(stream)) {
  // Extract a line of the text
  string line = extractor.ExtractLine();
  // If the line is null, then the end of the file is reached
  while (line != null) {
    // Print a line to the console
    Console.WriteLine(line);
    // Extract another line
    line = extractor.ExtractLine();
  }
} 

```

Extracts all characters from a document:

**C#**

```csharp
// Create a text extractor for CHM documents
using (var extractor = new ChmTextExtractor(stream)) {
  // Extract a text
  Console.WriteLine(extractor.ExtractAll());
} 

```
