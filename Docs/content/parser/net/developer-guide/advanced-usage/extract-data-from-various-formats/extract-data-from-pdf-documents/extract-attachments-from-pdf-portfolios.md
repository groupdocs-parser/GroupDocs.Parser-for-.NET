---
id: extract-attachments-from-pdf-portfolios
url: parser/net/extract-attachments-from-pdf-portfolios
title: Extract attachments from PDF portfolios
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
To extract attachments from emails [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method is used. This method returns the collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects.

Here are the steps to extract an attachment text from PDF Portfolios:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method and obtain collection of [ContainerItem](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/containeritem) objects;
*   Check if *collection* isn't *null* (container extraction is supported for the document);
*   Iterate through the collection and get container item names, sizes and obtain content.

The following example shows how to extract a text from PDF Portfolios:

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
		// Print the file path
		Console.WriteLine(item.FilePath);
        try
        {
            // Create Parser object for the email content
            using (Parser attachmentParser = item.OpenParser())
            {
                // Extract an email text
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

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).