---
id: working-with-data-extracted-by-template
url: parser/net/working-with-data-extracted-by-template
title: Working with data extracted by template
weight: 102
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
## DocumentData class

Extracted data are stored in the instance of [DocumentData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata) class:

| Member | Description |
| --- | --- |
| [Count](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata/properties/count) | The total number of the data fields. |
| DataField [Item](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata/properties/item) | The data field. |
| IList<FieldData> [GetFieldsByName(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/documentdata/methods/getfieldsbyname) | Returns the collection of data fields where the name is equal to field name. |

[FieldData](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/fielddata) class has the following members:

| Member | Description |
| --- | --- |
| [Name](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/fielddata/properties/name) | The field name. |
| [PageIndex](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/fielddata/properties/pageindex) | The page index. |
| [PageArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/fielddata/properties/pagearea) | The value of the field. |
| [LinkedField](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/fielddata/properties/linkedfield) | The linked field. |

Field data are stored in [PageArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/fielddata/properties/pagearea) property. Depending on the type of the value it can contain the instance of [PageTextArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea) or [PageTableArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea) classes:

```csharp
// Get the field data
FieldData field = data[i];
// Check if the field data contains a text
if(field.PageArea is PageTextArea)
{
    // Print the field value
    Console.WriteLine((field.PageArea as PageTextArea).Text);
}
```

[PageTextArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea) class represents a text block on the page. This class has the following members:

| Member | Description |
| --- | --- |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/rectangle) | The rectangular area that bounds the text area. |
| [Page](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/page) | The page information (page index and page size). |
| [Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/text) | The value of the text area. |
| [BaseLine](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/baseline) | The base line of the text area. |
| [TextStyle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/textstyle) | The style of the text block (like font name, font size etc.) |
| [Areas](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetextarea/properties/areas) | The collection of child text areas. |

The text area can be single or composite. In the first case it contains a text which is bounded by a rectangular area. In the second case it contains other text areas; text and table properties are calculated by child text areas.

[PageTableArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea) class represents a table. This class has the following members:

| Member | Description |
| --- | --- |
| [Rectangle](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/rectangle) | The rectangular area that bounds text area. |
| [Page](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagearea/properties/page) | The page information (page index and page size) |
| [RowCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea/properties/rowcount) | The total number of the table rows. |
| [ColumnCount](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea/properties/columncount) | The total number of the table columns. |
| PageTableAreaCell [Item](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea/properties/item) | The table cell by row and column indexes. |
| double [GetRowHeight(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea/methods/getrowheight) | The the row height. |
| double [GetColumnWidth(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.data/pagetablearea/methods/getcolumnwidth) | Returns the column width. |

There are two ways to work with fields data.

## Iterate through fields

The following example shows how to iterate via extracted field data:

```csharp
for (int i = 0; i < data.Count; i++) {
    Console.Write(data[i].Name + ": ");
    PageTextArea area = data[i].PageArea as PageTextArea;
    Console.WriteLine(area == null ? "Not a template field" : area.Text);
}
```

## Get field by name

The following example shows how to get field by the name:

```csharp
// Get all the fields with "Address" name
IList<FieldData> addressFields = data.GetFieldsByName("Address");
if(addressFields.Count == 0) {
    Console.WriteLine("Address not found");
}
else {
    Console.WriteLine("Address");
    // Iterate over the fields collection
    for (int i = 0; i < addressFields.Count; i++) {
        PageTextArea area = addressFields[i].PageArea as PageTextArea;
        Console.WriteLine(area == null ? "Not a template field" : area.Text);        
        
        // If it's a related field:
        if(addressFields[i].LinkedField != null) {
            Console.Write("Linked to ");
            PageTextArea linkedArea = addressFields[i].LinkedField.PageArea as PageTextArea;
            Console.WriteLine(linkedArea == null ? "Not a template field" : linkedArea.Text);            
        }
    }
}
```

This functionality allows to iterate all data fields and select the most suitable of them. For example, if more than one text value meets the condition of the regular expression, a user can iterate over them and select the most suitable one.

## Working with tables

The following example shows how to work with extracted tables:

```csharp
// Print all extracted data
for (int i = 0; i < data.Count; i++)
{
    Console.Write(data[i].Name + ": ");
    // Check if the field is a table
    PageTableArea area = data[i].PageArea as PageTableArea;
    if (area == null)
    {
        continue;
    }
    // Iterate via table rows
    for (int row = 0; row < area.RowCount; row++)
    {
        // Iterate via table columns
        for (int column = 0; column < area.ColumnCount; column++)
        {
            // Get the cell value
            PageTextArea cellValue = area[row, column].PageArea as PageTextArea;
            // Print the space between columns
            if (column > 0)
            {
                Console.Write("\t");
            }
            // Print the cell value
            Console.Write(cellValue == null ? "" : cellValue.Text);
        }
        // Print a new line
        Console.WriteLine();
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