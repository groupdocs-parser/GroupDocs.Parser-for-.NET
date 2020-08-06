---
id: extract-images-from-microsoft-office-powerpoint-presentations
url: parser/net/extract-images-from-microsoft-office-powerpoint-presentations
title: Extract images from Microsoft Office PowerPoint presentations
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract images from Microsoft Office PowerPoint presentations [GetImages](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getimages) methods are used. By default images are extracted with its original format. With using [ImageOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/imageoptions) class it is possible to extract images from Microsoft Office PowerPoint presentations as bmp, gif, jpeg, png and webp formats.

{{< alert style="warning" >}}GetImages method returns null value if image extraction isn't supported for the document. For example, image extraction isn't supported for TXT files. Therefore, for TXT file GetImages method returns null. If Microsoft Office PowerPoint presentation has no images, GetImages method returns an empty collection.{{< /alert >}}

Here are the steps to extract images from Microsoft Office PowerPoint presentation to PNG-files:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial presentation;
*   Call [GetImages](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getimages) method and obtain the collection of image objects;
*   Iterate through the collection and save image contents to the file.

The following example demonstrates how to extract images from Microsoft Office PowerPoint presentation:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract images from presentation
    IEnumerable<PageImageArea> images = parser.GetImages();
  
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

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).