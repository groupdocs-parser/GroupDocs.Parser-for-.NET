---
id: extract-images-to-files
url: parser/net/extract-images-to-files
title: Extract images to files
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
Here are the steps to extract images to files:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetImages](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getimages) method and obtain collection of [PageImageArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pageimagearea) objects;
*   Check if *collection* isn't null (images extraction is supported for the document);
*   Iterate through the collection and save image contents to the file.

The following example shows how to save images to files:

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

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online image extractor App

Along with full featured .NET library we provide simple, but powerfull free APPs.

You are welcome to extract images from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [GroupDocs Parser App](https://products.groupdocs.app/parser).