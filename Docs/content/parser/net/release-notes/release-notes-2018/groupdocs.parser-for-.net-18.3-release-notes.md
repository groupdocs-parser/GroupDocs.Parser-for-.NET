---
id: groupdocs-parser-for-net-18-3-release-notes
url: parser/net/groupdocs-parser-for-net-18-3-release-notes
title: GroupDocs.Parser for .NET 18.3 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.3.{{< /alert >}}

## Major Features

There are the following new features in this release:

*   Ability to extract a formatted text from chm files
*   Ability to extract a text from chm documents by pages
*   Ability to extract topics from chm documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-546 | Implement the ability to extract a formatted text from chm files | New feature |
| TEXTNET-883 | Implement the ability to extract a text from chm documents by pages | New feature |
| TEXTNET-884 | Implement the ability to extract topics from chm documents | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to extract a formatted text from chm files

#### Description

This feature allows extracting a formatted text from chm files.

#### Public API changes

Added **ChmFormattedTextExtractor** class.

#### Usage

Extracts a line of characters from a document:

**C#**

```csharp
// Create a text extractor for chm documents
using (var extractor = new ChmFormattedTextExtractor(stream)) {
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
// Create a text extractor for chm documents
using (var extractor = new ChmFormattedTextExtractor(stream)) {
  // Extract a text
  Console.WriteLine(extractor.ExtractAll());
}
```

For setting a formatter DocumentFormatter property is used.

**C#**

```csharp
// Create a formatted text extractor for text documents
var extractor = new ChmFormattedTextExtractor(stream);
// Set a HTML formatter for formatting
extractor.DocumentFormatter = new HtmlDocumentFormatter(); // all the text will be formatted as HTML
```

By default, a text is formatted as a plain text by PlainDocumentFormatter.

### Ability to extract a text from chm documents by pages

#### Description

This feature allows extracting a text from chm documents by pages.

#### Public API changes

Added the implementation of **IPageTextExtractor** interface to **ChmTextExtractor** class.  
Added **PageCount** property to **ChmTextExtractor** class.  
Added **ExtractPage** property to **ChmTextExtractor** class.

#### Usage

This example shows how to extract a text by pages via a generic function:

**C#**

```csharp
// Create a text extractor
ChmTextExtractor textExtractor = new ChmTextExtractor(stream);
// Invoke a function to print a text by pages
PrintPages(textExtractor);

// This function allows to extract a text by pages from any text extractor with IPageTextExtractor interface support
void PrintPages(TextExtractor textExtractor)
{ 
    // Check if IPageTextExtractor is supported
    IPageTextExtractor pageTextExtractor = textExtractor as IPageTextExtractor;
    if (pageTextExtractor != null)
    {
        // Iterate over all pages
        for (int i = 0; i < pageTextExtractor.PageCount; i++)
        {
            // Print a page number
            Console.WriteLine(string.Format("{0}/{1}", i, pageTextExtractor.PageCount));
            // Extract a text from the page
            Console.WriteLine(pageTextExtractor.ExtractPage(i));
        }
    }
}
```

### Ability to extract TOC from chm documents

#### Description

This feature allows extracting the table of contents (TOC) from chm documents.

#### Public API changes

Added **TableOfContentsItem** class.  
Added **TableOfContents** property to **ChmTextExtractor** class.

#### Usage

TableOfContents property is used to retrieve a list of TOC items:

**C#**

```csharp
IList<TableOfContentsItem> TableOfContents { get; }
```

TableOfContentsItem has the following members:

| Name | Description |
| --- | --- |
| Text | The text of the item. Usually, it is a chapter's title. |
| PageIndex | The page index of the text. Null if it is just a node without content. |
| Count | The number of sub-items. Zero if the item hasn't sub-items. |
| this\[int index\] | Gets a sub-item. |
| ExtractPage | Extracts a text of the item. |

This example shows how to print TOC:

**C#**

```csharp
// Create a text extractor
using (ChmTextExtractor extractor = new ChmTextExtractor(@"C:\Sources\GroupDocs.Parser\TestData\unit\chm\VBOB6.CHM"))
{
    // Print TOC on the screen
    PrintToc(extractor.TableOfContents, 0);
}

private static void PrintToc(IEnumerable<TableOfContentsItem> tableOfContents, int depth)
{
    // Use spaces to indicate the depth of the TOC item
    string spaces = new string(' ', depth);

    // Iterate over items
    foreach (TableOfContentsItem item in tableOfContents)
    {
        System.Console.Write(spaces);
        // Print the item's text
        System.Console.Write(item.Text);

        // If item has a text (it's not just a node)
        if (item.PageIndex.HasValue)
        {
            // Print the text length
            System.Console.Write(string.Format(" ({0})", item.ExtractPage().Length));
        }

        System.Console.WriteLine();

        // If the item has children
        if (item.Count > 0)
        {
            // Print them
            PrintToc(item, depth + 1);
        }
    }
}
```

This example shows how to extract a text of the item:

**C#**

```csharp
// Create a text extractor
using (ChmTextExtractor extractor = new ChmTextExtractor(@"C:\Sources\GroupDocs.Parser\TestData\unit\chm\VBOB6.CHM"))
{
    // Print a content of the third sub-item of the second item
    Console.WriteLine(extractor.TableOfContents[1][1].ExtractPage());
}
```
