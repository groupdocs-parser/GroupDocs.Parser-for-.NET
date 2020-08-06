---
id: extract-text-from-zip-archive-files
url: parser/net/extract-text-from-zip-archive-files
title: Extract text from ZIP archive files
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract files from ZIP archives [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method is used. This method returns the collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects.

Zip Entry can contain the following metadata:

| Name | Description |
| --- | --- |
| date | The time and date at which the file indicated by the Zip Entry was last modified. |

These metadata refer to a container element itself, not a document.

Here are the steps to extract an email text from Zip archives:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial archive;
*   Call [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method and obtain collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects;
*   Check if *collection* isn't *null* (container extraction is supported for the document);
*   Iterate through the collection and get container item names, sizes and obtain content.

The following example shows how to extract a text from Zip archives:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract attachments from the container
    IEnumerable<ContainerItem> attachments = parser.GetContainer();

    // Iterate over files
    foreach(ContainerItem item in attachments)
    {
		// Print the file path
		Console.WriteLine(item.FilePath);

        // Print metadata
        foreach(MetadataItem metadata in item.Metadata)
        {
            Console.WriteLine(string.Format("{0}: {1}", metadata.Name, metadata.Value));
        }
       
        try
        {
            // Create Parser object for the file content
            using (Parser fileParser = item.OpenParser())
            {
                // Extract the file text
                using (TextReader reader = fileParser.GetText())
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

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free Online Document Parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).