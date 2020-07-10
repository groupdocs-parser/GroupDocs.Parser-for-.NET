---
id: groupdocs-parser-for-net-19-12-release-notes
url: parser/net/groupdocs-parser-for-net-19-12-release-notes
title: GroupDocs.Parser for .NET 19.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 19.12{{< /alert >}}

## Major Features

**.NET Standard 2.0**

Starting from 19.12 release GroupDocs.Parser for .NET includes .NET Standard 2.0 version.

There are the following features in this release:

*   Implement the ability to extract the image in a different format
*   Implement the ability to save images to file

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1389 | Implement .NET Standard 2.0 support | New feature |
| PARSERNET-1342 | Implement the ability to extract the image in a different format | New feature |
| PARSERNET-1341 | Implement the ability to save images to file | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 19.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  ### Implement .NET Standard 2.0 support
    
    #### Description
    
    Starting from 19.12 release GroupDocs.Parser for .NET includes .NET Standard 2.0 version.
    
    #### Public API changes
    
    None
    
2.  ### Implement the ability to extract the image in a different format
    
    #### Description
    
    This feature allows to extract images to files.
    
    #### Public API changes
    
    *   Added **GetImageStream**(ImageOptions) method to **GroupDocs.Parser.Data.PageImageArea** class
    
    #### Usage
    
    **GetImageStream**(ImageOptions) method is used to extract the image in a different format.
    
    **ImageOptions** class is used to define the image format into which the image is converted. The following image formats are supported:
    
    *   Bmp
    *   Gif
    *   Jpeg
    *   Png
    *   WebP
    
    ##### Example:
    
    ```csharp
    // Create an instance of Parser class
    using (Parser parser = new Parser(Constants.SampleZip))
    {
        // Extract images from document
        IEnumerable<PageImageArea> images = parser.GetImages();
        // Check if images extraction is supported
        if (images == null)
        {
            Console.WriteLine("Page images extraction isn't supported");
            return;
        }
        // Create the options to save images in PNG format
        ImageOptions options = new ImageOptions(ImageFormat.Png);
     
        // Iterate over images
        foreach (PageImageArea image in images)
        {
            using (Stream stream = image.GetImageStream(options))
            {
                // add a logic to work with the stream
            }
        }
    }
    ```
    
3.  ### Implement the ability to save images to file
    
    #### Description
    
    This feature allows to save images to files.
    
    #### Public API changes
    
    *   Added **Save** methods to **GroupDocs.Parser.Data.PageImageArea** class
    
    #### Usage
    
    The following example shows how to extract images to files:
    
    ```csharp
    // Create an instance of Parser class
    using (Parser parser = new Parser(Constants.SampleZip))
    {
        // Extract images from document
        IEnumerable<PageImageArea> images = parser.GetImages();
        // Check if images extraction is supported
        if (images == null)
        {
            Console.WriteLine("Page images extraction isn't supported");
            return;
        }
        // Create the options to save images in PNG format
        ImageOptions options = new ImageOptions(ImageFormat.Png);
        int imageNumber = 0;
        // Iterate over images
        foreach (PageImageArea image in images)
        {
            // Save the image to the png file
            image.Save(imageNumber.ToString() + ".png", options);
            imageNumber++;
        }
    }
    ```
