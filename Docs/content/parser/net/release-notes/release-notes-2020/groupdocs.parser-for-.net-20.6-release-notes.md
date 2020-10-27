---
id: groupdocs-parser-for-net-20-6-release-notes
url: parser/net/groupdocs-parser-for-net-20-6-release-notes
title: GroupDocs.Parser for .NET 20.6 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.6{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Implement the API to extract data from documents
*   Implement the ability to detect media types for Zip container

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1394 | Implement the API to extract data from documents | Feature |
| PARSERNET-1187 | Implement the ability to detect media types for Zip container | Feature |

## Public API and Backward Incompatible Changes

### Implement the ability to detect media types for Zip container 

#### Description 

This feature provides the functionality to detect a file type of
container items.

#### Public API changes

[GroupDocs.Parser.Data.ContainerItem](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/containeritem)
public class was updated with changes as follows:

*   Added    [DetectFileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/containeritem/methods/detectfiletype) method

The following types were added:

*   [FileTypeDetectionMode](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/filetypedetectionmode)enumeration into GroupDocs.Parser.Options namespace.

#### Usage

The following example shows how to detect a file type of container
items:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract attachments from the container
    IEnumerable<ContainerItem> attachments = parser.GetContainer();
    // Check if container extraction is supported
    if (attachments == null)
    {
        Console.WriteLine("Container extraction isn't supported");
    }
    // Iterate over attachments
    foreach (ContainerItem item in attachments)
    {
        // Detect the file type
        Options.FileType fileType = item.DetectFileType(Options.FileTypeDetectionMode.Default);
         
        // Print the name and file type
        Console.WriteLine(string.Format("{0}: {1}", item.Name, fileType));
    }
}
```

### Implement the API to extract data from documents 

#### Description 

This feature provides the functionality to extract tables and hyperlinks
from the following document types:

*   PDF
*   Presentation
*   Spreadsheet
*   Word Processing document

#### Public API changes 

The following types were added:

*   [PageHyperlinkArea](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagehyperlinkarea)
    class into GroupDocs.Parser.Data namespace
*   [PageTableAreaOptions](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/pagetableareaoptions)
    class into GroupDocs.Parser.Options namespace

[GroupDocs.Parser.Data.PageTableAreaCell](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagetableareacell)
public class was updated with changes as follows:

*   Added
    [Text](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/pagetableareacell/properties/text)
    property

[GroupDocs.Parser.Parser ](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser)public
class was updated with changes as follows:

*   Added
    [GetHypelinks](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/gethypelinks)
    method
*   Added [GetHypelinks(Int32)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gethypelinks/methods/2)
    method
*   Added [GetHypelinks(PageAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gethypelinks/methods/1)
    method
*   Added [GetHypelinks(Int32,
    PageAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gethypelinks/methods/3)
    method
*   Added [GetTables(PageTableAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/gettables)
    method
*   Added [GetTables(Int32,
    PageTableAreaOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/gettables/methods/1)
    method

#### Usage 

The following example shows how to extract hyperlinks from the document
page area:

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
    IEnumerable<PageHyperlinkArea> hyperlinks = parser.GetHypelinks(options);
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

The following example shows how to extract tables from the whole
document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports table extraction
    if (!parser.Features.Tables)
    {
        Console.WriteLine("Document isn't supports tables extraction.");
        return;
    }
    // Create the layout of tables
    TemplateTableLayout layout = new TemplateTableLayout(
        new double[] { 50, 95, 275, 415, 485, 545 },
        new double[] { 325, 340, 365, 395 });
    // Create the options for table extraction
    PageTableAreaOptions options = new PageTableAreaOptions(layout);
    // Extract tables from the document
    IEnumerable<PageTableArea> tables = parser.GetTables(options);
    // Iterate over tables
    foreach (PageTableArea t in tables)
    {
        // Iterate over rows
        for (int row = 0; row < t.RowCount; row++)
        {
            // Iterate over columns
            for (int column = 0; column < t.ColumnCount; column++)
            {
                // Get the table cell
                PageTableAreaCell cell = t[row, column];
                if (cell != null)
                {
                    // Print the table cell text
                    Console.Write(cell.Text);
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
```