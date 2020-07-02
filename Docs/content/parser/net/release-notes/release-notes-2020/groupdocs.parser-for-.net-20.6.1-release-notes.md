---
id: groupdocs-parser-for-net-20-6-1-release-notes
url: parser/net/groupdocs-parser-for-net-20-6-1-release-notes
title: GroupDocs.Parser for .NET 20.6.1 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.6.1{{< /alert >}}


## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1555 | Misspelling in GetHyperlinks method name | Bug |

## Public API and Backward Incompatible Changes

### Misspelling in GetHyperlinks method name

#### Description

This hot-fix fixes misspelling in GetHyperlinks methods name in Parser class.

#### Public API changes

GroupDocs.Parser.Parser public class was updated with changes as follows:

*    Renamed GetHyperlinks method
*    Renamed GetHyperlinks(Int32) method
*    Renamed GetHyperlinks(PageAreaOptions) method
*    Renamed GetHyperlinks(Int32, PageAreaOptions) method

#### Usage

The following example shows how to extract hyperlinks from the document page area:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports hyperlink extraction
    if (!parser.Features.Hyperlinks)
    {
        Console.WriteLine("Document isn't supports hyperlink extraction.");
        return;
    }
    // Create the options which are used for hyperlink extraction
    PageAreaOptions options = new PageAreaOptions(new Rectangle(new Point(380, 90), new Size(150, 50)));
    // Extract hyperlinks from the document page area
    IEnumerable<PageHyperlinkArea> hyperlinks = parser.GetHyperlinks(options);
    // Iterate over hyperlinks
    foreach (PageHyperlinkArea h in hyperlinks)
    {
        // Print the hyperlink text
        Console.WriteLine(h.Text);
        // Print the hyperlink URL
        Console.WriteLine(h.Url);
        Console.WriteLine();
    }
}
```

