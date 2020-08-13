---
id: iterate-through-container-items
url: parser/net/iterate-through-container-items
title: Iterate through container items
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract items from containers by the [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method:

```csharp
IEnumerable<ContainerItem> GetContainer();
```

This method returns a collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects:

| Member | Description |
| --- | --- |
| [Name](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/name) | The name of the item. |
| [Directory](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/directory) | The directory of the item. |
| [FilePath](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/filepath) | The full path of the item. |
| [Size](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/size) | The size of the item in bytes. |
| [Metadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/metadata) | The collection of item metadata. |
| [DetectFileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/containeritem/methods/detectfiletype) | Detects a file type of the container item. |
| Stream [OpenStream()](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/methods/openstream) | Opens the stream of the item content. |
| Parser [OpenParser()](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/methods/openparser) | Creates the [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the item content. |
| Parser [OpenParser(LoadOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data.containeritem/openparser/methods/1) | Creates the [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the item content with [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions). |
| Parser [OpenParser(LoadOptions, ParserSettings)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data.containeritem/openparser/methods/2) | Creates the [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the item content with [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions) and [ParserSettings](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/parsersettings). |

Here are the steps to extract container from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method and obtain collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects;
*   Check if *collection* isn't *null* (container extraction is supported for the document);
*   Iterate through the collection and get container item names, sizes and obtain content.

The following example shows how to extract attachments from a container:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract attachments from the container
    IEnumerable<ContainerItem> attachments = parser.GetContainer();
    // Check if container extraction is supported
    if(attachments == null)
    {
        Console.WriteLine("Container extraction isn't supported");
    }

    // Iterate over attachments
    foreach(ContainerItem item in attachments)
    {
        // Print an item name and size
        Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Size));
    }
}
```

Container represents both container-only files (like zip archives, outlook storage) and documents with attachments (like emails, PDF Portfolios).

In case of outlook storage (ost/pst files) container consists of email documents (msg files)

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).