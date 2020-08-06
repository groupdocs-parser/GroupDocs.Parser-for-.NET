---
id: detect-file-type-of-container-item
url: parser/net/detect-file-type-of-container-item
title: Detect file type of container item
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
# Detect file type of container item

GroupDocs.Parser provides the functionality to detect a file type of container items by [DetectFileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/containeritem/methods/detectfiletype) method. [FileTypeDetectionMode](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/filetypedetectionmode) parameter provides the ability to control file type detection:

- Default. The file type is detected by the file extension; if the file extension  isn't recognized, the file type is detected by the file content.
- Extension. The file type is detected only by the file extension.
- Content. The file type is detected only by the file content.

Here are the steps to detect a file type of container items:

- Instantiate [Parser ](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser)object for the initial document;
- Call [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method and obtain the collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects;
- Check if *collection* isn't *null* (container extraction is supported for the document);
- Iterate through the collection and call [DetectFileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/containeritem/methods/detectfiletype) method.

The following example shows how to detect a file type of container items:

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

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).