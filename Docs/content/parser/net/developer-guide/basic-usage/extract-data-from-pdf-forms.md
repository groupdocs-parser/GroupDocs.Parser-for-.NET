---
id: extract-data-from-pdf-forms
url: parser/net/extract-data-from-pdf-forms
title: Extract data from PDF forms
weight: 10
description: "Extract data from PDF forms easily with GroupDocs.Parser."
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser allows to parse form data from PDF documents.

To extract PDF form data please call the [ParseForm](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parseform) method:

```csharp
DocumentData ParseForm()

```

This method returns an instance of [DocumentData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata) class with the extracted data.

Here are the steps to parse form of the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document
*   Call [ParseForm](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/parseform) method and obtain the [DocumentData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata) object;
*   Check if *data* isn't *null* (parse form is supported for the document);
*   Iterate over field data to obtain form data.

The following example shows how to parse a form of the document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract data from PDF document
    DocumentData data = parser.ParseForm();
    // Check if form extraction is supported
	if(data == null) {
		Console.WriteLine("Form extraction isn't supported.");
		return;
    }
    // Iterate over extracted data
    for (int i = 0; i < data.Count; i++)
    {
        Console.Write(data[i].Name + ": ");
        PageTextArea area = data[i].PageArea as PageTextArea;
        Console.WriteLine(area == null ? "Not a template field" : area.Text);
    }
}

```

## More resources

### Advanced usage topics

To learn more about document data extraction features and get familiar how to extract text, images, forms and more, please refer to the [advanced usage section]({{< ref "parser/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to extract text, metadata and images from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).
