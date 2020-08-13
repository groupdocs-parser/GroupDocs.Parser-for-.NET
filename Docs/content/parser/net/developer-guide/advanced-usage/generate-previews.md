---
id: generate-previews
url: parser/net/generate-previews
title: Generate previews
weight: 105
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to generate document page previews by [GeneratePreview(PreviewOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/generatepreview) method:

```csharp
void GeneratePreview(PreviewOptions previewOptions);
```

[PreviewOptions](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions) class is used to set requirements and stream delegates for preview generation.

Here are the steps to generate document page previews:

* Prepare [PreviewOptions](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions) object;
* Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object;
* Call [GeneratePreview(PreviewOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/generatepreview) method.

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

{{< alert style="info" >}}Spreadsheets are rendered by tiles. See the example bellow.{{< /alert >}}

Here are the steps to generate spreadsheets page previews:

* Prepare [PreviewOptions](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/previewoptions) object;
* Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object;
* Call [GeneratePreview(PreviewOptions)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/generatepreview) method.

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
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).