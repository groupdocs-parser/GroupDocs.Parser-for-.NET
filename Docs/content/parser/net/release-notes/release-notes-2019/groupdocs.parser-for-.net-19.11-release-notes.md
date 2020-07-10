---
id: groupdocs-parser-for-net-19-11-release-notes
url: parser/net/groupdocs-parser-for-net-19-11-release-notes
title: GroupDocs.Parser for .NET 19.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 19.11.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Implement the ability to extract a page number with search results

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1294 | Implement the ability to extract a page number with search results | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 19.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  ### Implement the ability to extract a page number with search results
    
    #### Description
    
    This feature allows to extract a page number with search results.
    
    #### Public API changes
    
    *   Added **PageIndex **property **to GroupDocs.Parser.Data.SearchResult** class
    *   Added **SearchByPages **property to **GroupDocs.Parser.Options.SearchOptions** class
    *   Added (matchCase, matchWholeWord, useRegularExpression, findInPages, leftHighlightOptions, rightHighlightOptions) and (matchCase, matchWholeWord, useRegularExpression, findInPages) constructors to** GroupDocs.Parser.Options.SearchOptions** class
    
    #### Usage
    
    The following example shows how to search a text with page numbers:
    
    ```csharp
    // Create an instance of Parser class
    using(Parser parser = new Parser(Constants.SamplePdf))
    {
        // Search a keyword with page numbers
        IEnumerable<SearchResult> sr = parser.Search("lorem", new SearchOptions(false, false, false, true));
        // Check if search is supported
        if(sr == null)
        {
            Console.WriteLine("Search isn't supported");
            return;
        }
       
        // Iterate over search results
        foreach(SearchResult s in sr)
        {
            // Print an index, page number and found text:
            Console.WriteLine(string.Format("At {0} (page {1}): {2}", s.Position, s.PageIndex, s.Text));
        }
    }
    ```
