---
id: groupdocs-parser-for-net-18-5-release-notes
url: parser/net/groupdocs-parser-for-net-18-5-release-notes
title: GroupDocs.Parser for .NET 18.5 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.5.{{< /alert >}}

## Major Features

There are the following enhancements in this release:

*   Standard extract mode is used as default behavior
*   Implemented the support for GitHub Markdown syntax

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-948 | Implement Standard extract mode as default behavior | Enhancement |
| PARSERNET-877 | Implement the support for GitHub Markdown syntax | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Standard Extract Mode as the Default Behavior

#### Description

This enhancement changes the default behavior of text extraction. The text is extracted with better quality but it takes more time. Use ExtractMode property to change this behavior.

#### Public API changes

No public API changes.

#### Usage

ExtractMode enumeration has the following members:

<table class="confluenceTable"><tbody><tr><td class="confluenceTd">Value</td><td class="confluenceTd">Description</td></tr><tr><td class="confluenceTd">Simple</td><td class="confluenceTd">Fast text extraction. The text in this mode is not extracted in a very accurate way but it is faster than the standard mode. If the fast text extraction doesn't support the document format, then this parameter is ignored and the standard text extraction is used.</td></tr><tr><td class="confluenceTd">Standard</td><td class="confluenceTd">Standard text extraction.</td></tr></tbody></table>

**C#**

```csharp
// Create a text extractor
CellsTextExtractor extractor = new CellsTextExtractor("document.xls");
// Set ExtractMode for the faster text extraction
extractor.ExtractMode = ExtractMode.Simple;
// Extract a text
Console.WriteLine(extractor.ExtractAll());
```

### Support for GitHub Markdown Syntax

#### Description

This enhancement allows extracting GitHub-specific objects from Markdown (md) documents.

#### Public API changes

Added read-only indexer to **StructuredElementProperties** class.  
Added **TaskState** constant **ListItemProperties** class.  
Added **TextProperties** constructor with three parameters - (isBold, isItalic, style).

#### Usage

**C#**

```csharp
// Create a text extractor for Markdown documents
using (var extractor = new MarkdownTextExtractor(stream)) {
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
 // Create a text extractor for Markdown documents
 using (var extractor = new MarkdownTextExtractor(stream)) {
   // Extract a text
   Console.WriteLine(extractor.ExtractAll());
 }
```
