---
id: groupdocs-parser-for-net-20-8-release-notes
url: parser/net/groupdocs-parser-for-net-20-8-release-notes
title: GroupDocs.Parser for .NET 20.8 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.8{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1176 | Implement the ability to extract images from .chm files | New feature |
| PARSERNET-1177 | Implement the ability to extract images from .epub files | New feature |
| PARSERNET-1178 | Implement the ability to extract images from .fb2 files | New feature |
| PARSERNET-1179 | Implement the ability to extract images from .html files | New feature |
| PARSERNET-1580 | Implement FileType.Format property | New feature |
| PARSERNET-1576 | Implement the ability to set DPI parameter in Preview API | Improvement |
| PARSERNET-1579 | Improve the spreadsheet preview functionality | Improvement |

## Public API and Backward Incompatible Changes

### Implement the ability to extract images from .chm files

#### Description

This feature allows to extract images from Compiled HTML Help files.

#### Public API changes

No API changes.

#### Usage

The following example shows how to extract all images from the whole document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract images
    IEnumerable<PageImageArea> images = parser.GetImages();
    // Check if images extraction is supported
    if (images == null)
    {
        Console.WriteLine("Images extraction isn't supported");
        return;
    }
    // Iterate over images
    foreach (PageImageArea image in images)
    {
        // Print a page index, rectangle and image type:
        Console.WriteLine(string.Format("Page: {0}, R: {1}, Type: {2}", image.Page.Index, image.Rectangle, image.FileType));
    }
}
```


### Implement the ability to extract images from .ebup files

#### Description

This feature allows to extract images from Digital E-Book File Format (ePUB) documents.

#### Public API changes

No API changes.

#### Usage

The following example shows how to extract all images from the whole document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract images
    IEnumerable<PageImageArea> images = parser.GetImages();
    // Check if images extraction is supported
    if (images == null)
    {
        Console.WriteLine("Images extraction isn't supported");
        return;
    }
    // Iterate over images
    foreach (PageImageArea image in images)
    {
        // Print a page index, rectangle and image type:
        Console.WriteLine(string.Format("Page: {0}, R: {1}, Type: {2}", image.Page.Index, image.Rectangle, image.FileType));
    }
}
```

### Implement the ability to extract images from .fb2 files

#### Description

This feature allows to extract images from Fiction Books 2.0 (fb2) documents.

#### Public API changes

No API changes.

#### Usage

The following example shows how to extract all images from the whole document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract images
    IEnumerable<PageImageArea> images = parser.GetImages();
    // Check if images extraction is supported
    if (images == null)
    {
        Console.WriteLine("Images extraction isn't supported");
        return;
    }
    // Iterate over images
    foreach (PageImageArea image in images)
    {
        // Print a page index, rectangle and image type:
        Console.WriteLine(string.Format("Page: {0}, R: {1}, Type: {2}", image.Page.Index, image.Rectangle, image.FileType));
    }
}
```

### Implement the ability to extract images from .html files

#### Description

This feature allows to extract images from HTML documents.

#### Public API changes

No API changes.

#### Usage

The following example shows how to extract all images from the whole document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract images
    IEnumerable<PageImageArea> images = parser.GetImages();
    // Check if images extraction is supported
    if (images == null)
    {
        Console.WriteLine("Images extraction isn't supported");
        return;
    }
    // Iterate over images
    foreach (PageImageArea image in images)
    {
        // Print a page index, rectangle and image type:
        Console.WriteLine(string.Format("Page: {0}, R: {1}, Type: {2}", image.Page.Index, image.Rectangle, image.FileType));
    }
}
```

### Implement FileType.Format property

#### Description

This feature allows to get file format from FileType object.

#### Public API changes

* Added [Format](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/filetype/properties/format) property to [GroupDocs.Parser.Options.FileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/filetype) class
* Added **Image** member to [GroupDocs.Parser.Options.FileFormat](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/fileformat) enum

#### Usage

The following example shows how to get file format from FileType object:

```csharp
Console.WriteLine(FileType.CHM.Format);
```

### Implement the ability to set DPI parameter in Preview API

#### Description

This improvement allows to set dpi to generate previews.

#### Public API changes

* Added [Dpi](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions/properties/dpi) property to [GroupDocs.Parser.Options.PreviewOptions](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions) class

#### Usage

The following example shows how to generate document page previews:

```csharp
// Create an instance of Parser class to generate document page previews
using (Parser parser = new Parser(Constants.SamplePdfWithToc))
{
    // Create preview options
    PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create(GetOutputPath($"preview_{pageNumber}.png")));
    // Set PNG as an output image format
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    // Set DPI for the output image
    previewOptions.Dpi = 72;

    // Generate previews
    parser.GeneratePreview(previewOptions);
}            

private static string GetOutputPath(string fileName)
{
    // Create the output directory if necessary
    if (!Directory.Exists(Constants.OutputPath))
    {
        Directory.CreateDirectory(Constants.OutputPath);
    }

    return Path.Combine(Constants.OutputPath, fileName);
}
```

### Improve the spreadsheet preview functionality

#### Description

This improvement allows to generate previews for spreadsheets by tiles

#### Public API changes

* Added [PageRenderInfo](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/pagerenderinfo) class to [GroupDocs.Parser.Options](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options) namespace
* Added [PreviewPageRender](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewpagerender) delegate to [GroupDocs.Parser.Options](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options) namespace
* Added [PreviewPageRender](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions/properties/previewpagerender) property to [GroupDocs.Parser.Options.PreviewOptions](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions) class

#### Usage

The following example shows how to generate spreadsheet page previews:

```csharp
// Create an instance of Parser class to generate spreadsheet page previews
using (Parser parser = new Parser(Constants.SampleXlsx))
{
    PageRenderInfo renderInfo = null;

    // Create preview options
    PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create(GetOutputPath(renderInfo, pageNumber)));
    // Set delegate to obtain the render info
    previewOptions.PreviewPageRender = info => renderInfo = info;
    // Set PNG as an output image format
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    // Set DPI for the output image
    previewOptions.Dpi = 72;

    // Generate previews
    parser.GeneratePreview(previewOptions);
}

private static string GetOutputPath(PageRenderInfo renderInfo, int pageNumber)
{
    // Set the output directory. If the render info is set, then sheets are rendered on its own directory
    string outputDirectory = renderInfo == null 
        ? Constants.OutputPath 
        : Path.Combine(Constants.OutputPath, $"preview_{renderInfo.PageNumber}");

    // Create the output directory if necessary
    if (!Directory.Exists(outputDirectory))
    {
        Directory.CreateDirectory(outputDirectory);
    }

    // Set the file name. If the render info is set, then tile name is {Row}x{Column}.png
    string fileName = renderInfo == null
        ? $"preview_{pageNumber}.png"
        : $"{renderInfo.GetRow(pageNumber)}x{renderInfo.GetColumn(pageNumber)}.png";

    return Path.Combine(outputDirectory, fileName);
}