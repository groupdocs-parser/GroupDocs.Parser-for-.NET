---
id: groupdocs-parser-for-net-20-3-release-notes
url: parser/net/groupdocs-parser-for-net-20-3-release-notes
title: GroupDocs.Parser for .NET 20.3 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.3{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Improved the support of text structure extraction
*   Improved table of contents extraction API

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1432 | Improve the support of text structure extraction | Improvement |
| PARSERNET-1431 | Improve table of contents extraction API | Improvement |

## Public API and Backward Incompatible Changes

### Improve table of contents extraction API

#### Description

This feature improves API of text extraction by table of contents items.

#### Public API changes

[GroupDocs.Parser.Data.TocItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem) public class was updated with changes as follows:

*   Added ExtractText method
*   [GetText](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/tocitem/methods/gettext) method was marked as obsolete

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

### Improve the support of text structure extraction

#### Description

This feature adds text extraction from shapes, word art objects and text boxes for Microsoft Office formats. Also added hyperlink extraction for spreadsheets and presentations.

{{< alert style="danger" >}}The structure of XML representation of a document was changed. For details, see Extract text structure.{{< /alert >}}

#### Public API changes

There are no changes in public API

#### Usage

The following example shows how to extract hyperlinks from the document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract text structure to the XML reader
    using (XmlReader reader = parser.GetStructure())
    {
        // Check if text structure extraction is supported
        if (reader == null)
        {
            Console.WriteLine("Text structure extraction isn't supported.");
            return;
        }
 
        // Process the XML document
        // Read the XML document to search hyperlinks
        while (reader.Read())
        {
            // Check if this is a start element with "hyperlink" name
            if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement() && reader.Name.ToLowerInvariant() == "hyperlink")
            {
                // Extract "link" attribute
                string value = reader.GetAttribute("link");
                if (value != null)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
```
