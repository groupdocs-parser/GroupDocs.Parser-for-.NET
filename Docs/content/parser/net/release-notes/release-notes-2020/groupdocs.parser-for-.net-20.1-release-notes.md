---
id: groupdocs-parser-for-net-20-1-release-notes
url: parser/net/groupdocs-parser-for-net-20-1-release-notes
title: GroupDocs.Parser for .NET 20.1 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.1{{< /alert >}}{{< alert style="danger" >}}In this version legacy API was removed (all types from GroupDocs.Parser.Legacy namespace were removed).{{< /alert >}}

## Major Features

There are the following features in this release:

*   Legacy API was removed (GroupDocs.Parser.Legacy namespace)
*   Implement the ability to extract a text by table of contents item
*   Implement the ability to extract table of contents from PDF and Word Processing documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1099 | Remove obsolete members (Legacy namespace) | Improvement |
| PARSERNET-1363 | Implement the ability to extract a text by TOC item | New feature |
| PARSERNET-1361 | Implement the ability to extract TOC from Word Processing documents | New feature |
| PARSERNET-1362 | Implement the ability to extract TOC from PDF documents | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 20.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  ### Implement the ability to extract a text by TOC item
    
    ## Description
    
    This feature provides the functionality to extract a text by an item of table of contents.
    
    ## Public API changes
    
    *   Added **GetText** method to **GroupDocs.Parser.Data.TocItem** class
    
    ## Usage
    
    The following example shows how to extract a text by an item of table of contents:
    
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
            using (TextReader reader = tocItem.GetText())
            {
                Console.WriteLine("----");
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
    ```
    
2.  ### Implement the ability to extract TOC from PDF documents
    
    ## Description
    
    This feature allows to extract table of contents (TOC) from PDF documents.
    
    ## Public API changes
    
    No API changes.
    
    ## Usage
    
    The following example shows how to extract table of contents from PDF document:
    
    ```csharp
    // Create an instance of Parser class
    using (Parser parser = new Parser(filePath))
    {
        // Check if text extraction is supported
        if (!parser.Features.Text)
        {
            Console.WriteLine("Text extraction isn't supported.");
            return;
        }
        // Check if toc extraction is supported
        if (!parser.Features.Toc)
        {
            Console.WriteLine("Toc extraction isn't supported.");
            return;
        }
        // Get table of contents
        IEnumerable<TocItem> toc = parser.GetToc();
        // Iterate over items
        foreach (TocItem i in toc)
        {
            // Print the Toc text
            Console.WriteLine(i.Text);
            // Check if page index has a value
            if (i.PageIndex == null)
            {
                continue;
            }
            // Extract a page text
            using (TextReader reader = parser.GetText(i.PageIndex.Value))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
    ```
    
3.  ### Implement the ability to extract TOC from Word Processing documents
    
    ## Description
    
    This feature allows to extract table of contents (TOC) from word processing documents.
    
    ## Public API changes
    
    No API changes
    
    ## Usage
    
    The following example shows how to extract table of contents from word processing document:
    
    ```csharp
    // Create an instance of Parser class
    using (Parser parser = new Parser(filePath))
    {
        // Check if text extraction is supported
        if (!parser.Features.Text)
        {
            Console.WriteLine("Text extraction isn't supported.");
            return;
        }
        // Check if toc extraction is supported
        if (!parser.Features.Toc)
        {
            Console.WriteLine("Toc extraction isn't supported.");
            return;
        }
        // Get table of contents
        IEnumerable<TocItem> toc = parser.GetToc();
        // Iterate over items
        foreach (TocItem i in toc)
        {
            // Print the Toc text
            Console.WriteLine(i.Text);
            // Check if page index has a value
            if (i.PageIndex == null)
            {
                continue;
            }
            // Extract a page text
            using (TextReader reader = parser.GetText(i.PageIndex.Value))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
    ```
    
4.  ### Remove obsolete members (Legacy namespace)
    
    ## Description
    
    All types from GroupDocs.Parser.Legacy namespace were removed**.  
    **
    
    ## Public API changes
    
    *   All types from GroupDocs.Parser.Legacy namespace were removed**.  
        **
    
    ## Usage
    
See [migration notes]({{< ref "parser/net/developer-guide/migration-notes.md" >}}) for brief comparison of how to extract data using the old and new API.
