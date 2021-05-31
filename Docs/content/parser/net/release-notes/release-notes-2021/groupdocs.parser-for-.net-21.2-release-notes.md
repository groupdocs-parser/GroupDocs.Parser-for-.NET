---
id: groupdocs-parser-for-net-21-2-release-notes
url: parser/net/groupdocs-parser-for-net-21-2-release-notes
title: GroupDocs.Parser for .NET 21.2 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 21.2{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1734 | Improve text page extraction from WordProcessing documents | Improvement |
| PARSERNET-1722 | Remove GetText method from TocItem class | Improvement  |
| PARSERNET-1484 | Text isn't extracted in raw mode | Bug |
| PARSERNET-1711 | Detected package downgrade: System.Reflection.Emit.ILGeneration | Bug |
| PARSERNET-1724 | No results from landscape page of a Word document | Bug |
| PARSERNET-1731 | Searching text with highlights is not showing all the occurrences in the DOCX file | Bug |
| PARSERNET-1732 | Search returns wrong PageIndex for DOCX if Header/Footer | Bug |
| PARSERNET-1725 | Search returns null for PageIndex in DOCX documents | Bug |
| PARSERNET-1726 | Parsing plain text without extension | Bug |
| PARSERNET-1727 | Search results are less than as expected | Bug |
| PARSERNET-1728 | API shows search results only from the first page | Bug |

## Public API and Backward Incompatible Changes

### Improve text page extraction from WordProcessing documents

#### Description

This improvement enhanced the work with documents that contain sections, footers, headers and footnotes.

#### Public API changes

No API changes.

### Remove GetText method from TocItem class

#### Description

Removed the obsolete TocItem.GetText method. Use [TocItem.ExtractText](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/tocitem/methods/extracttext) method instead.

#### Public API changes

[GroupDocs.Parser.Data.TocItem](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/tocitem) public class was updated with changes as follows:

* Removed GetText method

#### Usage

The following example how to extract a text by the an item of table of contents:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(Constants.SampleDocxWithToc))
{
    // Get table of contents
    IEnumerable<TocItem> tocItems = parser.GetToc();
    // Check if toc extraction is supported
    if (tocItems == null)
    {
        Console.WriteLine("Table of contents extraction isn't supported");
    }
    // Iterate over items
    foreach (TocItem tocItem in tocItems)
    {
        // Print the text of the chapter
        using (TextReader reader = tocItem.ExtractText())
        {
            Console.WriteLine("----");
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```