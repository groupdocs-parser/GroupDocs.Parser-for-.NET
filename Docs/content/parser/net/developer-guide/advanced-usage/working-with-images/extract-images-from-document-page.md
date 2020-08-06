---
id: extract-images-from-document-page
url: parser/net/extract-images-from-document-page
title: Extract images from document page
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract images from document page by the [GetImages(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/getimages/methods/2) method:

```csharp
IEnumerable<PageImageArea> GetImages(int pageIndex);
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

Here are the steps to extract images from the document page:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [Features.Images](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/images) property to check if images extraction is supported for the document;
*   Call [GetImages(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/getimages/methods/2) method with the page index and obtain collection of [PageImageArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea) objects;
*   Iterate through the collection and get sizes, image types and image contents.

The following example shows how to extract images from a document page:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports images extraction
    if (!parser.Features.Images)
    {
        Console.WriteLine("Document isn't supports images extraction.");
        return;
    }
    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    // Check if the document has pages
    if (documentInfo.PageCount == 0)
    {
        Console.WriteLine("Document hasn't pages.");
        return;
    }
    // Iterate over pages
    for (int pageIndex = 0; pageIndex < documentInfo.PageCount; pageIndex++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", pageIndex + 1, documentInfo.PageCount));
        // Iterate over images
        // We ignore null-checking as we have checked images extraction feature support earlier
        foreach (PageImageArea image in parser.GetImages(pageIndex))
        {
            // Print a rectangle and image type
            Console.WriteLine(string.Format("R: {0}, Text: {1}", image.Rectangle, image.FileType));
        }
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