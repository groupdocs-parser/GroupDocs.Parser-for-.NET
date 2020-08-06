---
id: extract-images-from-document
url: parser/net/extract-images-from-document
title: Extract images from document
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract images from documents by the [GetImages](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getimages) method:

```csharp
IEnumerable<PageImageArea> GetImages();
```

The methods return a collection of [PageImageArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea) objects:

| Member | Description |
| --- | --- |
| [Page](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/page) | The page that contains the text area. |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/rectangle) | The rectangular area on the page that contains the text area. |
| [FileType](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea/properties/filetype) | The format of the image. |
| [Rotation](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea/properties/rotation) | The rotation angle of the image. |
| Stream [GetImageStream()](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea/methods/getimagestream) | Returns the image stream. |
| Stream [GetImageStream(ImageOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data.pageimagearea/getimagestream/methods/1) | Returns the image stream in a different format. |
| [Save(string)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea/methods/save) | Saves the image to the file. |
| [Save(string, ImageOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data.pageimagearea/save/methods/1) | Saves the image to the file in a different format. |

[ImageOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/imageoptions) class is used to define the image format into which the image is converted. The following image formats are supported:

*   Bmp
*   Gif
*   Jpeg
*   Png
*   WebP

Here are the steps to extract images from the whole document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetImages](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getimages) method and obtain collection of [PageImageArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea) objects;
*   Check if *collection* isn't *null* (images extraction is supported for the document);
*   Iterate through the collection and get sizes, image types and image contents.

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

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online image extractor App

Along with full featured .NET library we provide simple, but powerfull free APPs.

You are welcome to extract images from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [GroupDocs Parser App](https://products.groupdocs.app/parser).