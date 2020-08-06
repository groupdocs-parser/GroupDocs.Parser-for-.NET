---
id: extract-text-structure
url: parser/net/extract-text-structure
title: Extract text structure
weight: 6
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract the text structure from documents by the [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method:

```csharp
XmlReader GetStructure();
```

This method returns XML representation of a document. A document has the following structure:

![](parser/net/images/extract-text-structure.png)


| Tag | Description |
| --- | --- |
| document | The root tag |
| section | Represents a section of the document. Depending on the document type, it can represent a worksheet, a slide and so on. Can contain the following attributes:<ul><li>style - the style of the section</li><li>name - the name of the section (for example, the name of the sheet)</li></ul> |
| p | Represents a text paragraph. Can contain the following attribute:<ul><li>style - the style of paragraph</li></ul> |
| ul | Represents an unordered list |
| ol | Represents an ordered list |
| li | Represents a list item |
| shape | Represents a shape object. |
| table | Represents a table |
| tr | Represents a table row |
| td | Represents a table cell. Can contain the following attributes:<ul><li>rowIndex - the zero-based index of the row</li><li>columnIndex - the zero-based index of the column</li><li>rowSpan - the total number of rows that contain the table cell</li><li>columnSpan - the total number of columns that contain the table cell</li></ul> |

Tags have the following relations:

*   **document** tag can contain any number of section tags
*   **section** tag can contain any number of **p, ul, ol** or **table** tags in any sequence
*   **table** tag can contain any number of **tr** tags
*   **tr** tag can contain any number of **td** tags
*   **td** tag can contain one **p** tag

The **p** and **li** tags can contain **hyperlink, strong, em** tags and the value that represents a text:

![](parser/net/images/extract-text-structure_1.png))![](parser/net/images/extract-text-structure_2.png)

| Tag | Description |
| --- | --- |
| hyperlink | Represents a hyperlink. Can contain the following attribute:<ul><li>link - URL</li></ul> |
| strong | Represents a strong emphasis (bold text) |
| em | Represents a regular emphasis (italic text) |
| br | Represents a line break (empty tag) |

## Features of text extraction for different formats

### Word processing documents

Word processing documents have a more complex table cell and paragraph can contain any number of shapes.

A table cell can contain any number of paragraphs, lists and tables:

![](parser/net/images/extract-text-structure_3.png)

A shape can contain a single hyperlink (empty tag) for the entire shape and any number of paragraphs, lists or tables:

![](parser/net/images/extract-text-structure_4.png)

### Presentations

Presentations have a more complex table cell and section can contain any number of shapes.

A table cell can contain any number of paragraphs or lists:

![](parser/net/images/extract-text-structure_5.png)

A shape can contain a single hyperlink (empty tag) for the entire shape and any number of paragraphs or lists:

![](parser/net/images/extract-text-structure_6.png)

### Spreadsheets

Spreadsheets have the following document structure:

![](parser/net/images/extract-text-structure_7.png)

It's more simple than others. A section can contain any number of shapes and only one table. A shape can contain a single hyperlink (empty tag) for the entire shape and any numbers of paragraphs.

## Examples

Here are the steps to extract hyperlinks from the document:

*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser)  object for the initial document;
*   Call [GetStructure](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getstructure) method and obtain [XmlReader](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmlreader?view=netframework-2.0) object;
*   Check if *reader* isn't null (text structure extraction is supported for the document);
*   Process the XML document.

The following example shows how to extract hyperlinks from the document:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract text structure to the XML reader
    using (XmlReader reader = parser.GetStructure())
    {
        // Check if text structure extraction is supported
        if (reader == null)
        {
            Console.WriteLine("Text structure extraction isn't supported.");
            return;
        }

		// Process the XML document
        // Read the XML document to search hyperlinks
        while (reader.Read())
        {
            // Check if this is a start element with "hyperlink" name
            if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement() && reader.Name.ToLowerInvariant() == "hyperlink")
            {
                // Extract "link" attribute
                string value = reader.GetAttribute("link");
                if (value != null)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
```

The following document:

![](parser/net/images/extract-text-structure_8.png)

has the following text structure:

```xml
<?xml version="1.0"?>
<document>
  <section>
    <p style="HEADING1">
      <shape>
        <p style="HEADING1">
          Lorem ipsum dolor sit amet, <hyperlink link="google.com">consectetuer</hyperlink> adipiscing elit. Maecenas porttitor congue massa.
        </p>
      </shape>Lorem
    </p>
    <p>
      Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed <hyperlink link="bing.com">pulvinar ultricies</hyperlink>, purus lectus <strong>malesuada</strong> libero, sit amet commodo magna eros quis urna.
    </p>
    <ol>
      <li>Nunc viverra imperdiet enim. </li>
      <li>Fusce est.</li>
    </ol>
    <p>Vivamus a tellus. </p>
    <ul>
      <li>
        Pellentesque <em>
          <strong>habitant morbi tristique senectus et netus et</strong>
        </em> malesuada fames ac turpis egestas.
      </li>
      <li>Proin pharetra nonummy pede. </li>
      <li>Mauris et orci. </li>
      <li>Aenean nec lorem.</li>
    </ul>
    <table>
      <tr>
        <td rowIndex="0" columnIndex="0" rowSpan="1" columnSpan="1">
          <p>In porttitor.</p>
        </td>
        <td rowIndex="0" columnIndex="1" rowSpan="1" columnSpan="1">
          <p>
            Donec laoreet <strong>nonummy</strong> augue.
          </p>
        </td>
        <td rowIndex="0" columnIndex="2" rowSpan="1" columnSpan="1">
          <p>
            Suspendisse dui purus, <em>
              <strong>scelerisque</strong>
            </em> at, vulputate vitae, pretium mattis, nunc.
          </p>
        </td>
        <td rowIndex="0" columnIndex="3" rowSpan="1" columnSpan="1">
          <p>Mauris eget neque at sem venenatis eleifend. </p>
        </td>
      </tr>
      <tr>
        <td rowIndex="1" columnIndex="0" rowSpan="1" columnSpan="1">
          <p>Ut nonummy.</p>
        </td>
        <td rowIndex="1" columnIndex="1" rowSpan="1" columnSpan="1">
          <p>
            Fusce <hyperlink link="google.com">aliquet pede</hyperlink> non pede.
          </p>
        </td>
        <td rowIndex="1" columnIndex="2" rowSpan="1" columnSpan="1">
          <p>Suspendisse dapibus lorem pellentesque magna.</p>
        </td>
        <td rowIndex="1" columnIndex="3" rowSpan="1" columnSpan="1">
          <p>Integer nulla.</p>
        </td>
      </tr>
      <tr>
        <td rowIndex="2" columnIndex="0" rowSpan="3" columnSpan="1">
          <p>Donec blandit feugiat ligula.</p>
        </td>
        <td rowIndex="4" columnIndex="1" rowSpan="1" columnSpan="1">
          <p>
            Donec hendrerit, felis et <em>imperdiet</em> euismod, purus ipsum pretium metus, in lacinia nulla nisl eget sapien.
          </p>
        </td>
        <td rowIndex="2" columnIndex="2" rowSpan="3" columnSpan="1">
          <p>
            <strong>Donec</strong> ut est in lectus consequat consequat.
          </p>
        </td>
        <td rowIndex="2" columnIndex="3" rowSpan="3" columnSpan="1">
          <p>Etiam eget dui. Aliquam erat volutpat.</p>
        </td>
      </tr>
    </table>
    <p>Sed at lorem in nunc porta tristique. Proin nec augue.</p>
  </section>
</document>
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).