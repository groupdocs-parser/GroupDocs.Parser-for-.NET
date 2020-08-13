---
id: working-with-templates
url: parser/net/working-with-templates
title: Working with templates
weight: 101
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
Document template is set by [Template](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/template) class. It contains template items - fields and tables. Each item has the unique (in the template bounds) name and optional page index - value that represents the index of the page where the template item is located; *null* if the template item is located on any page.

## Template fields

The template field is set by [TemplateField](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatefield) class with the following constructor:

```csharp
TemplateField(TemplatePosition position, string name, int? pageIndex)
```

| Parameter | Description |
| --- | --- |
| position | Defines the way how to find the field on a page. |
| name | A unique template item name. |
| pageIndex | The page index. An integer value that represents the index of the page where the template item is located; *null* if the template item is located on any page. |

[TemplatePosition](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templateposition) is an abstract base class. The following classes are used to set template positions:

*   [TemplateFixedPosition](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatefixedposition). Provides a template field position which is defined by the rectangular area.
*   [TemplateRegexPosition](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templateregexposition). Provides a template field position which uses the regular expression.
*   [TemplateLinkedPosition](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatelinkedposition). Provides a template field position which uses the linked field.

### TemplateFixedPosition

This is simplest way to define the field position. It requires to set a rectangular area on the page that bounds the field value. All the text that is contained (even partially) into the rectangular area will be extracted as a value:

```csharp
// Create a fixed template field with "Address" name which is bounded by a rectangle
// at the position (35, 160) and with the size (110, 20)
TemplateField templateField = new TemplateField(
    new TemplateFixedPosition(new Rectangle(new Point(35, 160), new Size(110, 20))),
    "Address");
```

It is recommended to define a rectangular area above (below) the center of the line that is below (above) the selected area, in order to avoid the excessive extraction of the text. For example:

| Template definition | Result |
| --- | --- |
| ![](parser/net/images/working-with-templates.png)) | Extracts only one line
67890 |
|  ![](parser/net/images/working-with-templates_1.png)) | Extracts two lines
4321 First Street  
Anytown, State ZIP |
| ![](parser/net/images/working-with-templates_2.png)) | Extracts four lines
Company Name  
4321 First Street  
Anytown, State ZIP  
Date: 06/02/2019 |

### TemplateRegexPosition

This way to define the field position allows to find a field value by a regular expression. For example, if the document contains "Invoice Number INV-12345" then template field can be defined in the following way:

```csharp
// Create a regex template field with "InvoiceNumber" name
TemplateField templateField = new TemplateField(
    new TemplateRegexPosition("Invoice Number\\s+[A-Z0-9\\-]+"), 
    "InvoiceNumber");
```

In this case as a value the entire string is extracted. To extract only a part of the string the regular expression group "value" is used:

```csharp
// Create a regex template field with "InvoiceNumber" name with "value" group
TemplateField templateField = new TemplateField(
    new TemplateRegexPosition("Invoice Number\\s+(?<value>[A-Z0-9\\-]+)"),
    "InvoiceNumber");
```

In this case as a value "INV-3337" string is extracted.

Regular expression fields can be used as linked fields.

### TemplateLinkedPosition

This way to define the field position allows to find a field value by extracting a rectangular area around the linked field. For example, if it's known that the field with an invoice number is placed on the right of "Invoice number" string the following code is used:

```csharp
// Create a regex template field to find "Invoice Number" text
TemplateField invoice = new TemplateField(new TemplateRegexPosition("Invoice Number"), "Invoice");
// Create a related template field associated with "Invoice" field and extract the value on the right of it
TemplateField invoiceNumber = new TemplateField(
    new TemplateLinkedPosition("invoice", new Size(100, 15), new TemplateLinkedPositionEdges(false, false, true, false)),
    "InvoiceNumber");
```

| Template definition | Result |
| --- | --- |
| ![](parser/net/images/working-with-templates_3.png)) | Extracts a text on the right of "Invoice Number" field:INV-3337 

To simplify the setting of the size of template field [AutoScale](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatelinkedposition/properties/autoscale) property is used. The size of template field is scaled according to the related field if [AutoScale](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatelinkedposition/properties/autoscale) is set to *true*. This is useful when the font size is not known in advance, but the proportions of the size of the value (the ratio of height to width) are approximately known:

```csharp
// Create a regex template field to find "Invoice Number" text
TemplateField invoice = new TemplateField(new TemplateRegexPosition("Invoice Number"), "Invoice");
// Create a related template field associated with "Invoice" field and extract the value on the right of it
TemplateField invoiceNumber = new TemplateField(
    new TemplateLinkedPosition("invoice", new Size(100, 15), new TemplateLinkedPositionEdges(false, false, true, false), true),
    "InvoiceNumber");
```

| Template definition | Result |
| --- | --- |
| ![](parser/net/images/working-with-templates_4.png)) | Extracts a text on the right of "Invoice Number" field:INV-3337 

The field value can be extracted from either side of the related field. The side of the value extraction is set by [Edges](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatelinkedposition/properties/edges) property. The size of rectangular area is set by [SearchArea](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatelinkedposition/properties/searcharea) property. The position of rectangular area depends on the side of the value extraction:

```csharp
Left: (LinkedField.Rectangle.Left - SearchAreaSize.Width; LinkedField.Rectangle.Top)
Top: (LinkedField.Rectangle.Left; LinkedField.Rectangle.Top - SearchAreaSize.Height)
Right: (LinkedField.Rectangle.Right; LinkedField.Rectangle.Top)
Bottom: (LinkedField.Rectangle.Left; LinkedField.Rectangle.Bottom)
```

The related field can be any field which was previously defined in the template:

```csharp
// Create a regex template field
TemplateField fromField = new TemplateField(new TemplateRegexPosition("From"), "From", 0);
// Create a related template field linked to "From" regex field and placed under it
TemplateField companyField = new TemplateField(
    new TemplateLinkedPosition("From", new Size(100, 10), new TemplateLinkedPositionEdges(false, false, false, true)),
    "FromCompany", 
    0);
// Create a related template field linked to "FromCompany" related field and placed under it
TemplateField addressField = new TemplateField(
    new TemplateLinkedPosition("FromCompany", new Size(100, 30), new TemplateLinkedPositionEdges(false, false, false, true)),
    "FromAddress", 
    0);
```

| Template definition | Result |
| --- | --- |
| ![](parser/net/images/working-with-templates_5.png)) | The extraction is processed in the following way:Extracts data of "From" regex field (green
Extracts data of "FromCompany" related field (yellow)  
Extracts data of "FromAddress" related field (red) |

A value of the field depends on the related field. The field is always empty if the related field doesn't have a value. If the field has a value then it has a link to the related field.

### Document template with fields

An instance of [Template](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/template) class is created by the constructor:

```csharp
Template(IEnumerable<TemplateItem> items)
```

This constructor accepts a collection of template items:

```csharp
// Create an array of template fields
TemplateItem[] fields = new TemplateItem[]
{
    new TemplateField(new TemplateRegexPosition("From"), "From", 0),
    new TemplateField(
        new TemplateLinkedPosition("From", new Size(100, 10), new TemplateLinkedPositionEdges(false, false, false, true)),
        "FromCompany",
        0),
    new TemplateField(
        new TemplateLinkedPosition("FromCompany", new Size(100, 30), new TemplateLinkedPositionEdges(false, false, false, true)),
        "FromAddress",
        0)
};
// Create a document template
Template template = new Template(fields);
```

The field name is case-insensitive (Field and FIELD - the same names) and must be unique in the template. The related field must be associated with the early defined field. If these conditions don't meet, the exception is thrown.

## Template tables

Template table is set by [TemplateTable](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetable) class with the following constructors:

```csharp
TemplateTable(TemplateTableLayout layout, string name, int? pageIndex)
TemplateTable(TemplateTableParameters parameters, string name, int? pageIndex)
```

Template table can be set by detector parameters or table layout. If the page index is omitted, tables are extracted from every document page. It's useful in the cases when the document contains pages with the same layout (pages differ only by data).

[TemplateTableParameters](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetableparameters) class has the following constructors:

```csharp
TemplateTableParameters(Rectangle rectangle, IEnumerable<double> verticalSeparators)
TemplateTableParameters(Rectangle rectangle, IEnumerable<double> verticalSeparators, bool? hasMergedCells, int? minRowCount, int? minColumnCount, int? minVerticalSpace)
```

Each of parameters is optional. The most easy way to define a table is to set the rectangular area of the table and columns separators:

```csharp
TemplateTableParameters parameters = new TemplateTableParameters(
    new Rectangle(new Point(175, 350), new Size(400, 200)),
    new double[] { 185, 370, 425, 485, 545 });
```

If a template table is set by detector parameters, the table is detected automatically:

```csharp
TemplateTableParameters parameters = new TemplateTableParameters(
    new Rectangle(new Point(175, 350), new Size(400, 200)),
    new double[] { 185, 370, 425, 485, 545 });

TemplateTable table = new TemplateTable(parameters, "Details", 0);

// Create a document template
Template template = new Template(new TemplateItem[] { table });
```

Template table is set by table layout if the table can't be detected automatically:

```csharp
TemplateTableLayout layout = new TemplateTableLayout(
    new double[] { 50, 95, 275 },
    new double[] { 325, 340, 365 });

TemplateTable table = new TemplateTable(layout, "Details", null);
Template template = new Template(new TemplateItem[] { table });
```

These collections represent bounds of columns and rows. For example, for 2x2 table there are 3 vertical and 3 horizontal separators:

```
---------
|   |   |
---------
|   |   |
---------
```

[MoveTo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetablelayout/methods/moveto) method is used to move Table Layout. 

For example, a document has tables on each page (or a set of documents with a table on the page). These tables differ by position and content, but have the same columns and rows. In this case a user can define [TemplateTableLayout](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetablelayout) object at (0, 0) once and then move it to the location of the definite table.

If the table position depends on the other object of the page, a user can define [TemplateTableLayout](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetablelayout) object based on template document and then move it according to an anchor object. For example, if this is a summary table and it is followed by details table (which can contain a different count of rows). In this case a user can define [TemplateTableLayout](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetablelayout) object on template document (with the known details table rectangle) and then move [TemplateTableLayout](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetablelayout) object according to the difference of details table rectangle of template and real document.

[MoveTo](https://apireference.groupdocs.com/net/parser/groupdocs.parser.templates/templatetablelayout/methods/moveto) method returns a copy of the current object. A user can pass any coordinates (even negative - then layout will be moved to the left/top).

## Complex template example

This example shows the template which is used to parse the following invoice:

![](parser/net/images/working-with-templates_6.jpg)

```csharp
// Create detector parameters for "Details" table
TemplateTableParameters detailsTableParameters = new TemplateTableParameters(new Rectangle(new Point(35, 320), new Size (530, 55)), null);
 
// Create detector parameters for "Summary" table
TemplateTableParameters summaryTableParameters = new TemplateTableParameters(new Rectangle(new Point(330, 385), new Size(220, 65)), null);
 
// Create a collection of template items
TemplateItem[] templateItems = new TemplateItem[]
{
    new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 135), new Size(100, 10))), "FromCompany"),
    new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 150), new Size(100, 35))), "FromAddress"),
    new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 190), new Size(150, 2))), "FromEmail"),
    new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 250), new Size(100, 2))), "ToCompany"),
    new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 260), new Size(100, 15))), "ToAddress"),
    new TemplateField(new TemplateFixedPosition(new Rectangle(new Point(35, 290), new Size(150, 2))), "ToEmail"),

    new TemplateField(new TemplateRegexPosition("Invoice Number"), "InvoiceNumber"),
    new TemplateField(new TemplateLinkedPosition(
        "InvoiceNumber",
        new Size(200, 15),
        new TemplateLinkedPositionEdges(false, false, true, false)),
        "InvoiceNumberValue"),

    new TemplateField(new TemplateRegexPosition("Order Number"), "InvoiceOrder"),
    new TemplateField(new TemplateLinkedPosition(
        "InvoiceOrder",
        new Size(200, 15),
        new TemplateLinkedPositionEdges(false, false, true, false)),
        "InvoiceOrderValue"),

    new TemplateField(new TemplateRegexPosition("Invoice Date"), "InvoiceDate"),
    new TemplateField(new TemplateLinkedPosition(
        "InvoiceDate",
        new Size(200, 15),
        new TemplateLinkedPositionEdges(false, false, true, false)),
        "InvoiceDateValue"),

    new TemplateField(new TemplateRegexPosition("Due Date"), "DueDate"),
    new TemplateField(new TemplateLinkedPosition(
        "DueDate",
        new Size(200, 15),
        new TemplateLinkedPositionEdges(false, false, true, false)),
        "DueDateValue"),

    new TemplateField(new TemplateRegexPosition("Total Due"), "TotalDue"),
    new TemplateField(new TemplateLinkedPosition(
        "TotalDue",
        new Size(200, 15),
        new TemplateLinkedPositionEdges(false, false, true, false)),
        "TotalDueValue"),

    new TemplateTable(detailsTableParameters, "details", null),
    new TemplateTable(summaryTableParameters, "summary", null)
};
 
// Create a document template
Template template = new Template(templateItems); 
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).