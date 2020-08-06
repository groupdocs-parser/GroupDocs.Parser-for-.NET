---
id: get-supported-features
url: parser/net/get-supported-features
title: Get supported features
weight: 3
description: "`"
keywords: Features Parser C# CSharp .Net dotNet
productName: GroupDocs.Parser for .NET
hideChildren: False
---
The set of the supported features depends on the document format. GroupDocs.Parser provides the functionality to check if feature supported for the document. [Features](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/properties/features) property is used for this purposes.

[Features](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features) class has the following members:

| Member | Description |
| --- | --- |
| bool [IsFeatureSupported(string featureName)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/methods/isfeaturesupported) | Returns the value that indicates whether the **feature** is supported. |
| [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/text) | The value that indicates whether **text extraction** is supported. |
| [TextPage](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/textpage) | The value that indicates whether **text page** extraction is supported. |
| [FormattedText](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/formattedtext) | The value that indicates whether **formatted text** extraction is supported. |
| [FormattedTextPage](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/formattedtextpage) | The value that indicates whether **formatted text page** extraction is supported. |
| [Search](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/search) | The value that indicates whether **text search** is supported. |
| [Highlight](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/highlight) | The value that indicates whether **highlight extraction** is supported. |
| [Structure](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/structure) | The value that indicates whether **text structure extraction** is supported. |
| [Toc](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/toc) | The value that indicates whether **table of contents extraction** is supported. |
| [Container](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/container) | The value that indicates whether **container extraction** is supported. |
| [Metadata](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/metadata) | The value that indicates whether **metadata extraction** is supported. |
| [TextAreas](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/textareas) | The value that indicates whether **text areas extraction** is supported. |
| [Images](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/images) | The value that indicates whether **images extraction** is supported. |
| [ParseByTemplate](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/parsebytemplate) | The value that indicates whether **parsing by template** is supported. |
| [ParseForm](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/parseform) | The value that indicates whether **form parsing** is supported. |

Here are the steps for check if feature is supported:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for the initial document;
*   Call corresponding property of [Feature](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/properties/features) property to check if the feature is supported.

The following example shows how to check if text extraction feature is supported:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser("doc.zip"))
{
    // Check if text extraction is supported for the document
    if(!parser.Features.Text)
    {
        Console.WriteLine("Text extraction isn't supported");
        return;
    }

    // Extract a text from the document
    using(TextReader reader = parser.GetText())
    {
        Console.WriteLine(reader.ReadToEnd());
    }
}
```

If the feature isn't supported, the method returns null instead of the value. So if checking of [Features](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/properties/features) properties is omitted, result is checked for *null*:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser("doc.zip"))
{
    // Extract a text from the document 
    using(TextReader reader = parser.GetText())
    {
        // Check if reader isn't null
        if(reader == null)
        {
            Console.WriteLine("Text extraction isn't supported");
        }
        else
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}

```

This example prints "Text extraction isn't supported" because there is no text in zip-archive.

Some operations may consume significant time. So it's not optimal to call the method to just check the support for the feature. For this purpose [Features](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/properties/features) property is used.

## More resources

### Advanced usage topics

To learn more about document data extraction features and get familiar how to extract text, images, forms and more, please refer to the [advanced usage section]({{< ref "parser/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).