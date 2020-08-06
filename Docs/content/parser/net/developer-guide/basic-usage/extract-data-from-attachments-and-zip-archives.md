---
id: extract-data-from-attachments-and-zip-archives
url: parser/net/extract-data-from-attachments-and-zip-archives
title: Extract data from attachments and ZIP archives
weight: 9
description: "Extract data (text, images, PDF forms) from ZIP-archived documents with GroupDocs.Parser."
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
It is easy to extract data, text, images and use any GroupDocs.Parser feature for ZIP-archived documents. The same feature allows to get attachments from  PDF and Emails and extract data from them.

# Extract data from attachments and ZIP archives

To extract documents from ZIP files and get attachments from containers simply call the [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method:

```csharp
IEnumerable<ContainerItem> GetContainer()

```

This method returns a collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects:

| Member | Description |
| --- | --- |
| [Name](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/name) | The name of the item. |
| [Directory](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/directory) | The directory of the item. |
| [FilePath](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/filepath) | The full path of the item. |
| [Size](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/size) | The size of the item in bytes. |
| [Metadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/properties/metadata) | The collection of item metadata. |
| Stream [OpenStream()](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/methods/openstream) | Opens the stream of the item content. |
| Parser [OpenParser()](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem/methods/openparser) | Creates the Parser object for the item content. |
| Parser [OpenParser(LoadOptions)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data.containeritem/openparser/methods/1) | Creates the Parser object for the item content with [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions). |
| Parser [OpenParser(LoadOptions, ParserSettings)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data.containeritem/openparser/methods/2) | Creates the Parser object for the item content with [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions) and [ParserSettings](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/parsersettings). |

Container represents both container-only files (like zip archives, outlook storage) and documents with attachments (like emails, PDF Portfolios).

Here are the steps to extract an email text from outlook storage:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method and obtain collection of document container item objects;
*   Check if *collection* isn't *null* (container extraction is supported for the document);
*   Iterate through the collection and obtain [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object to extract a text.

The following example shows how to extract a text from from zip entities:

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
    // Iterate over zip entities
    foreach (ContainerItem item in attachments)
    {
        // Print the file path
        Console.WriteLine(item.FilePath);
        try
        {
            // Create Parser object for the zip entity content
            using (Parser attachmentParser = item.OpenParser())
            {
                // Extract an zip entity text
                using (TextReader reader = attachmentParser.GetText())
                {
                    Console.WriteLine(reader == null ? "No text" : reader.ReadToEnd());
                }
            }
        }
        catch (UnsupportedDocumentFormatException)
        {
            Console.WriteLine("Isn't supported.");
        }
    }
}
```

## More resources

### Advanced usage topics

To learn more how to work with attachments and ZIP archives, please refer the [advanced help section]({{< ref "parser/net/developer-guide/advanced-usage/working-with-zip-archives-and-attachments/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to extract text, metadata and images from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).
