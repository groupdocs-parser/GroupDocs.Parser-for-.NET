---
id: groupdocs-parser-for-net-19-5-release-notes
url: parser/net/groupdocs-parser-for-net-19-5-release-notes
title: GroupDocs.Parser for .NET 19.5 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 19.5.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Implement the ability to extract data from documents
*   Implement the ability to move Table Layout
*   Implement the ability to detect a table in a rectangular area using a collection of column separators
*   Implement the support for spreadsheet and presentation templates
*   Some constructors and properties were removed from **TextProperties** class

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1145 | Implement the ability to extract data from documents | New feature |
| PARSERNET-1151 | Implement the ability to move Table Layout | New feature |
| PARSERNET-1158 | Implement the ability to detect a table in a rectangular area using a collection of column separators | New feature |
| PARSERNET-1200 | Implement the support for spreadsheet and presentation templates | New feature |
| PARSERNET-63 | Remove obsolete members (version 18.7) | Breaking Change |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  ### Implement the ability to extract data from documents
    
    #### Description
    
    This feature allows to extract data from documents.
    
    *   Document template
        *   Template fields
            *   Fixed field position
            *   Regular expression field
            *   Related field
        *   Document template with fields
        *   Template tables
    *   Extracting data from the document
        
        *   Example
    *   Analyzing data fields and tables
        
        *   Data fields
            
        *   Data tables
            
    
    #### Public API changes
    
    Namespace GroupDocs.Parser.Extractors.Templates:
    
    *   Added **DocumentData** class
    *   Added **DocumentDataField** class
    *   Added **DocumentDataTable** class
    *   Added **DocumentTemplate** class
    *   Added **TemplateField** class
    *   Added **TemplateFieldPosition** class
    *   Added **TemplateFieldPositionType** enumeration
    *   Added **TemplateFieldRelatedPositionType** enumeration
    *   Added **TemplateTable** class
    
    Namespace GroupDocs.Parser.Extractors:
    
    *   Added **GetPageSize** method to **DocumentContent** class
    
    Namespace GroupDocs.Parser:
    
    *   Added **Size** class
    *   Added **DocumentParser** class
    
    #### Usage
    
    Data extraction from documents is performed in three stages:
    
    *   Preparing the document template
    *   Extracting data from the document
    *   Analyzing data fields and tables
    
    ##### Document template
    
    The document template is set by DocumentTemplate class:
    
    | Member | Description |
    | --- | --- |
    | Count | An integer value that represents the total number of the template fields. |
    | TemplateField this\[int index\] | Gets a template field. |
    | IList<TemplateTable> GetTables() | Returns a collection of template tables. |
    
    An instance of the class is created by the following constructors:
    
    ```csharp
    // Creates a document template with fields
    DocumentTemplate(IEnumerable<TemplateField> templateFields);
    // Creates a document template with fields and tables
    DocumentTemplate(IEnumerable<TemplateField> templateFields, IEnumerable<TemplateTable> templateTables);
    ```
    
    ##### Template fields
    
    The template field is set by TemplateField class:
    
    | Member | Description |
    | --- | --- |
    | FieldName | An uppercase string that represents the name of the template field. |
    | PageIndex | A zero-based index of the page where the field is placed; null if the field is placed on any page. |
    | FieldPosition | A field position on the page (see below). |
    
    An instance of the class is created by the following constructors:
    
    <table class="confluenceTable"><tbody><tr><td class="confluenceTd"><div class="container" title="Hint: double-click to select code"><div class="line number1 index0 alt2"><code class="java plain">TemplateField(string fieldName, TemplateFieldPosition fieldPosition)</code></div><div class="line number2 index1 alt1"><code class="java plain">TemplateField(string fieldName, </code><code class="java keyword">int</code> <code class="java plain">pageIndex, TemplateFieldPosition fieldPosition)</code></div></div></td></tr></tbody></table>
    
    The only difference between them is pageIndex. If the page index is omitted, data are extracted from every document page. It's useful in the cases when the document contains pages with the same layout (pages are differed only by data).
    
    TemplateFieldPosition class defines the field position on the page. The following position types are supported (position type is defined by TemplateFieldPositionType enumeration):
    
    *   The position is set by a rectangle (Fixed)
    *   The position is found by a regular expression (Regex)
    *   The position is set relative to the related field (Related)
    
    TemplateFieldPosition class contains properties for all supported position types. The instance of TemplateFieldPosition class contains only those properties which are related to the position type; other properties are null.
    
    | Member | Description | Fixed | Regex | Related |
    | --- | --- | --- | --- | --- |
    | Type | A value that represents a type of the template field position. | • | • | • |
    | Rectangle | A rectangle that bounds the field. | • |   |   |
    | Regex | A string value that represents a regular expression to find the field |   | • |   |
    | RelatedFieldName | A string value that represents a name of the related field. |   |   | • |
    | RelatedPositionType | A value that represents a field position relative to the related field. |   |   | • |
    | SearchAreaSize | A size of the field. |   |   | • |
    | CanScaleSearchAreaSize | A value indicating whether SearchAreaSize is scaled according to the related field. |   |   | • |
    
    An instance of the class is created by the following static methods:
    
    ```csharp
    // Creates a related template field position (scaling mode is enabled)
    TemplateFieldPosition CreateRegex(string regex);
    // Creates a regex template field position.
    TemplateFieldPosition CreateRegex(string regex);
    // Creates a related template field position.
    TemplateFieldPosition CreateRelated(
                string relatedFieldName, 
                TemplateFieldRelatedPositionType relatedPositionType,
                Size searchAreaSize);
    // Creates a related template field position (with the ability to explicitly set a scaling mode)
    TemplateFieldPosition CreateRelated(
                string relatedFieldName,
                TemplateFieldRelatedPositionType relatedPositionType,
                Size searchAreaSize,
                bool canScaleSearchAreaSize);
    ```
    
    ###### Fixed field position
    
    This is simplest way to define the field position. It's required to set a rectangular area at the page that bounds field value. All the text that is contained (even partially) into the rectangular area will be extracted as a value:
    
    ```csharp
    // Create a fixed template field with "Address" name which is bounded by a rectangle at the position (35, 160) and with the size (110, 20)
    TemplateField templateField = new TemplateField("Address", TemplateFieldPosition.CreateFixed(new Rectangle(35, 160, 110, 20)));
    ```
    
    It is recommended to define a rectangular area above (below) the center of the line that is below (above) the selected area, in order to avoid the excessive extraction of the text. For example:
    
    | Template definition | Result |
    | --- | --- |
| ![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes.png)) | Extracts only one line:67890 
| ![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_1.png)) | Extracts two lines:4321 First Stree
    Anytown, State ZIP |
| ![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_2.png)) | Extracts four lines:Company Nam
    4321 First Street  
    Anytown, State ZIP  
    Date: 06/02/2019 |
    
    ###### Regular expression field
    
    This way to define the field position allows to find a field value by a regular expression. For example, if the document contains "Invoice Number   INV-12345" then template field can be defined in the following way:
    
    ```csharp
    // Create a regex template field with "InvoiceNumber" name
    TemplateField templateField = new TemplateField("InvoiceNumber", TemplateFieldPosition.CreateRegex("Invoice Number\\s+[A-Z0-9\\-]+"));
    ```
    
    In this case as a value the entire string is extracted. To extract only a part of the string the regular expression group "value" is used:
    
    ```csharp
    // Create a regex template field with "InvoiceNumber" name with "value" group
    TemplateField templateField = new TemplateField("InvoiceNumber", TemplateFieldPosition.CreateRegex("Invoice Number\\s+(?<value>[A-Z0-9\\-]+)"));
    ```
    
    In this case as a value "INV-3337" string is extracted.
    
    Regular expression fields can be used as related fields.
    
    ###### Related field
    
    This way to define the field position allows to find a field value by extracting a rectangular area around the related field. For example, if it's known that the field with an invoice number is placed on the right of "Invoice number" string the following code is used:
    
    ```csharp
    // Create a regex template field to find "Invoice Number" text
    TemplateField invoice = new TemplateField("Invoice", TemplateFieldPosition.CreateRegex("Invoice Number"));
    // Create a related template field associated with "Invoice" field and extract the value on the right of it
    TemplateField invoiceNumber = new TemplateField("InvoiceNumber", TemplateFieldPosition.CreateRelated("invoice", TemplateFieldRelatedPositionType.Right, new Size(100, 15), false));
    ```
    
    | Template definition | Result |
    | --- | --- |
| ![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_3.png)) | Extracts a text on the right of "Invoice Number" field:INV-3337 
    
    To simplify the setting of the size of template field CanScaleSearchAreaSize property is used. The size of template field is scaled according to the related field if CanScaleSearchAreaSize is set to true.This is useful when the font size is not known in advance, but the proportions of the size of the value (the ratio of height to width) are approximately known:
    
    ```csharp
    TemplateField invoice = new TemplateField("Invoice", TemplateFieldPosition.CreateRegex("Invoice Number"));
    // Create a related template field associated with "Invoice" field with auto-scale
    TemplateField invoiceNumber = new TemplateField("InvoiceNumber", TemplateFieldPosition.CreateRelated("invoice", TemplateFieldRelatedPositionType.Right, new Size(100, 15), true));
    ```
    
    | Template definition | Result |
    | --- | --- |
| ![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_4.png))  | Extracts a text on the right of "Invoice Number" field:INV-3337 
    
    The field value can be extracted from either side of the related field. The side of value extraction is set by TemplateFieldRelatedPositionType enumeration. The size of rectangular area is set by SearchAreaSize property. The position of rectangular area depends on the side of value extraction:
    
    *   Left: (RelatedField.Rectangle.Left - SearchAreaSize.Width; RelatedField.Rectangle.Top)
    *   Top: (RelatedField.Rectangle.Left; RelatedField.Rectangle.Top - SearchAreaSize.Height)
    *   Right: (RelatedField.Rectangle.Right; RelatedField.Rectangle.Top)
    *   Bottom: (RelatedField.Rectangle.Left; RelatedField.Rectangle.Bottom)
    
    The related field can be any field which was previously defined in the template:
    
    ```csharp
    // Create regex template field
    TemplateField fromField = new TemplateField("From", 0, TemplateFieldPosition.CreateRegex("From"));
    // Create related template field linked to "From" regex field and placed under it
    TemplateField companyField = new TemplateField("FromCompany", 0, TemplateFieldPosition.CreateRelated("From", TemplateFieldRelatedPositionType.Bottom, new Size(100, 10), false));
    // Create related template field linked to "FromCompany" related field and placed under it
    TemplateField addressField = new TemplateField("FromAddress", 0, TemplateFieldPosition.CreateRelated("FromCompany", TemplateFieldRelatedPositionType.Bottom, new Size(100, 30), false));
    ```
    
    | Template definition | Result |
    | --- | --- |
| ![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_5.png)) | The extraction is processed in the following way
    1.  Extracts data of "From" regex field (green)
    2.  Extracts data of "FromCompany" related field (yellow)
    3.  Extracts data of "FromAddress" related field (red)
    
     |
    
    A value of the field depends on the related field. The field is always empty If the related field doesn't have a value. If the field has a value then it has a link to the related field.
    
    ##### Document template with fields
    
    An instance of DocumentTemplate class is created by the constructor:
    
    ```csharp
    DocumentTemplate(IEnumerable<TemplateField> templateFields);
    ```
    
    This constructor accepts a collection of template fields:
    
    ```csharp
    // Create an array of template fields
    TemplateField[] fields = new TemplateField[]
    {
        new TemplateField("From", 0, TemplateFieldPosition.CreateRegex("From")),
        new TemplateField("FromCompany", 0, TemplateFieldPosition.CreateRelated(
            "From",
            TemplateFieldRelatedPositionType.Bottom,
            new Size(100, 10),
            false)),
        new TemplateField("FromAddress", 0, TemplateFieldPosition.CreateRelated(
            "FromCompany",
            TemplateFieldRelatedPositionType.Bottom,
            new Size(100, 30),
            false))
    };
     
    // Create a document template
    DocumentTemplate template = new DocumentTemplate(fields);
    ```
    
    The field name is case-insensitive (Field and FIELD - the same names) and must be unique in the template. Related field must be associated with early defined field. If these conditions don't meet, the exception is thrown.
    
    ##### Template tables
    
    Template table is set by TemplateTable class:
    
    | Member | Description |
    | --- | --- |
    | TableName | An uppercase string that represents the name of the template table. |
    | PageIndex | A zero-based index of the page where the table is placed; null if the table is placed on any page. |
    | DetectorParameters | An instance of TableAreaDetectorParameters class or null if TableAreaLayout property is set. |
    | TableAreaLayout | An instance of TableAreaLayout class or null if DetectorParameters property is set. |
    
    An instance of the class is created by the following constructors:
    
    ```csharp
    TemplateTable(string tableName, TableAreaDetectorParameters detectorParameters)
    TemplateTable(string tableName, int pageIndex, TableAreaDetectorParameters detectorParameters)
    TemplateTable(string tableName, TableAreaLayout tableAreaLayout)
    TemplateTable(string tableName, int pageIndex, TableAreaLayout tableAreaLayout)
    ```
    
    Template table can be set with detector parameters or table layout. If the page index is omitted, tables are extracted from every document page. It's useful in the cases when the document contains pages with the same layout (pages are differed only by data).
    
    TableAreaDetectorParameters class has the following members:
    
    | Member | Description |
    | --- | --- |
    | MinRowCount | Minimum number of table rows |
    | MinColumnCount | Minimum number of table columns |
    | HasMergedCells | Value indicating whether the table has merged cells |
    | MinVerticalSpace | Minimum width of vertical separators |
    | Rectangle | Rectangle which bounds a table detection region |
    
    If a template table is set by detector parameters, the table is detected automatically:
    
    ```csharp
    // Create detector parameters
    TableAreaDetectorParameters detectorParameters = new TableAreaDetectorParameters();
    // Table is bounded by the rectangular area
    detectorParameters.Rectangle = new Rectangle(35, 330, 550, 100);
    // Create "Details" template table 
    TemplateTable table = new TemplateTable("Details", detectorParameters);
    // Create a collection of template tables
    TemplateTable[] tables = new TemplateTable[]
    {
        table
    };
    // Create a document template. Fields are omitted (we pass null instead of fields collection)
    DocumentTemplate template = new DocumentTemplate(null, tables);
    ```
    
    Template table is set by table layout if the table can't be detected automatically:
    
    | Member | Description |
    | --- | --- |
    | VerticalSeparators | A collection of vertical separators |
    | HorizontalSeparators | A collection of horizontal separators |
    
    These collections represent bounds of columns and rows. For example, for 2x2 table there are 3 vertical and 3 horizontal separators:
    
    ```csharp
    ---------
    |   |   |
    ---------
    |   |   |
    ---------
    ```
    
    In this case the document template has the following structure:
    
    ```csharp
    // Create a table layout
    TableAreaLayout tableAreaLayout = new TableAreaLayout();
     
    // Add vertical separators (columns)
    tableAreaLayout.VerticalSeparators.Add(50);
    tableAreaLayout.VerticalSeparators.Add(95);
    tableAreaLayout.VerticalSeparators.Add(275);
     
    // Add horizontal separators (rows)
    tableAreaLayout.HorizontalSeparators.Add(325);
    tableAreaLayout.HorizontalSeparators.Add(340);
    tableAreaLayout.HorizontalSeparators.Add(365);
     
    // Create "Details" template table
    TemplateTable table = new TemplateTable("Details", tableAreaLayout);
    // Create a collection of template tables
    TemplateTable[] tables = new TemplateTable[]
    {
        table
    };
    // Create a document template. Fields are omitted (we pass null instead of fields collection)
    DocumentTemplate template = new DocumentTemplate(null, tables);
    ```
    
    #### Extracting data from the document
    
    For data extracting DocumentParser class is used. This class has only one method with different overloads:
    
    ```csharp
    DocumentData ParseByTemplate(string fileName, DocumentTemplate documentTemplate)
    DocumentData ParseByTemplate(string fileName, DocumentTemplate documentTemplate, LoadOptions loadOptions)
    DocumentData ParseByTemplate(Stream stream, DocumentTemplate documentTemplate)
    DocumentData ParseByTemplate(Stream stream, DocumentTemplate documentTemplate, LoadOptions loadOptions)
    ```
    
    This method parses data from the document by a user-generated template. LoadOptions parameter is used to pass additional options to open the document (for example, password).
    
    To get the instance of DocumentParser class Default property is used:
    
    ```csharp
    DocumentData data = DocumentParser.Default.ParseByTemplate("invoice - John Smith, Jan-2019.pdf", template);
    ```
    
    ##### Example
    
    This example shows the template which is used to parse the following invoice:
    
![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_6.jpg)
    
    ```csharp
    // Create a collection of template fields
    TemplateField[] templateFields = new TemplateField[]
    {
        new TemplateField("FromCompany", TemplateFieldPosition.CreateFixed(new Rectangle(35, 135, 100, 10))),
        new TemplateField("FromAddress", TemplateFieldPosition.CreateFixed(new Rectangle(35, 150, 100, 35))),
        new TemplateField("FromEmail", TemplateFieldPosition.CreateFixed(new Rectangle(35, 190, 150, 2))),
        new TemplateField("ToCompany", TemplateFieldPosition.CreateFixed(new Rectangle(35, 250, 100, 2))),
        new TemplateField("ToAddress", TemplateFieldPosition.CreateFixed(new Rectangle(35, 260, 100, 15))),
        new TemplateField("ToEmail", TemplateFieldPosition.CreateFixed(new Rectangle(35, 290, 150, 2))),
        new TemplateField("InvoiceNumber", TemplateFieldPosition.CreateRegex("Invoice Number")),
        new TemplateField("InvoiceNumberValue", TemplateFieldPosition.CreateRelated(
            "InvoiceNumber",
            TemplateFieldRelatedPositionType.Right,
            new Size(200, 15))),
        new TemplateField("InvoiceOrder", TemplateFieldPosition.CreateRegex("Order Number")),
        new TemplateField("InvoiceOrderValue", TemplateFieldPosition.CreateRelated(
            "InvoiceOrder",
            TemplateFieldRelatedPositionType.Right,
            new Size(200, 15))),
        new TemplateField("InvoiceDate", TemplateFieldPosition.CreateRegex("Invoice Date")),
        new TemplateField("InvoiceDateValue", TemplateFieldPosition.CreateRelated(
            "InvoiceDate",
            TemplateFieldRelatedPositionType.Right,
            new Size(200, 15))),
        new TemplateField("DueDate", TemplateFieldPosition.CreateRegex("Due Date")),
        new TemplateField("DueDateValue", TemplateFieldPosition.CreateRelated(
            "DueDate",
            TemplateFieldRelatedPositionType.Right,
            new Size(200, 15))),
        new TemplateField("TotalDue", TemplateFieldPosition.CreateRegex("Total Due")),
        new TemplateField("TotalDueValue", TemplateFieldPosition.CreateRelated(
            "TotalDue",
            TemplateFieldRelatedPositionType.Right,
            new Size(200, 15))),
    };
     
    // Create detector parameters for "Details" table
    TableAreaDetectorParameters detailsTableParameters = new TableAreaDetectorParameters();
    detailsTableParameters.Rectangle = new Rectangle(35, 320, 530, 55);
     
    // Create detector parameters for "Summary" table
    TableAreaDetectorParameters summaryTableParameters = new TableAreaDetectorParameters();
    summaryTableParameters.Rectangle = new Rectangle(330, 385, 220, 65);
     
    // Create a collection of template tables
    TemplateTable[] templateTables = new TemplateTable[]
    {
        new TemplateTable("details", detailsTableParameters),
        new TemplateTable("summary", summaryTableParameters)
    };
     
    // Create a document template
    DocumentTemplate template = new DocumentTemplate(templateFields, templateTables);
     
    // Extract data from PDF
    DocumentData data = DocumentParser.Default.ParseByTemplate("invoice - John Smith, Jan-2019.pdf", template);
    ```
    
    #### Analyzing data fields and tables
    
    Extracted data are stored in the instance of DocumentData class:
    
    | Member | Description |
    | --- | --- |
    | Count | An integer value that represents the total number of data fields. |
    | DocumentDataField this\[int index\] | Gets a data field. |
    | IList<DocumentDataField> GetDataFieldsByName(string fieldName) | Returns a collection of the data fields which name is "fieldName". |
    | IList<DocumentDataTable> GetDataTables() | Returns a read-only collection of data tables. |
    
    The following methods are used to fill an instance with the data:
    
    | Method | Description |
    | --- | --- |
    | AddDataField(DocumentDataField dataField) | Adds a data field. |
    | AddDataFields(IEnumerable<DocumentDataField> dataFields) | Adds a collection of data fields. |
    | AddDataTable(DocumentDataTable dataTable) | Adds a data table. |
    
    An instance of DocumentData class can contain more than one field (or table) with the same name. This is because a field (or table) is placed on more than one page or one page can contain more than one text value that meets the template field condition (for example, template regex field).
    
    ##### Data fields
    
    Data field is set by DocumentDataField class:
    
    | Member | Description |
    | --- | --- |
    | FieldName | An uppercase string that represents the name of the data field. |
    | PageIndex | A zero-based index of the page where the value is found. |
    | Value | A string value that represents a value of the data field; null if the value isn't found. |
    | Rectangle | A rectangle that bounds the data field; null if the value isn't found. |
    | RelatedDataField | A data field relative to which the value is found; null for non-related data fields. |
    | IsEmpty | A value indicating whether a value is found. |
    
    An instance of the class is created by the following constructors:
    
    ```csharp
    // Creates an instance for the fixed or regex template fields
    DocumentDataField(string fieldName, int pageIndex, string value, Rectangle rectangle);
    // Creates an instance for the related template fields
    DocumentDataField(string fieldName, int pageIndex, string value, Rectangle rectangle, DocumentDataField relatedDataField);
    // Creates an empty instance (when value isn't found)
    DocumentDataField(string fieldName, int pageIndex);
    ```
    
    There are two ways to work with data fields.
    
    Iteration via all the fields:
    
    ```csharp
    for (int i = 0; i < data.Count; i++) {
        Console.Write(data[i].FieldName + ": ");
        Console.WriteLine(data[i].Value);
    }
    ```
    
    Find fields by a field name:
    
    ```csharp
    // Get all the fields with "Address" name
    IList<DocumentDataField> addressFields = data.GetDataFieldsByName("Address");
    if(addressFields.Count == 0) {
        Console.WriteLine("Address not found");
    }
    else {
        Console.WriteLine("Address");
        // Iterate over the fields collection
        for (int i = 0; i < addressFields.Count; i++) {
            Console.WriteLine(addressFields[i].Value);
            // If it's a related field:
            if(addressFields[i].RelatedDataField != null) {
                Console.Write("Linked to ");
                Console.WriteLine(addressFields[i].RelatedDataField.Value);
            }
        }
    }
    ```
    
    This functionality allows to iterate all data fields and select the most suitable of them. For example, if more than one text value meets the condition of the regular expression, a user can iterate over them and select the most suitable one.
    
    ##### Data tables
    
    Data table is set by DocumentDataTable class:
    
    | Member | Description |
    | --- | --- |
    | TableName | An uppercase string that represents the name of the data table. |
    | PageIndex | A zero-based index of the page where the table is found. |
    | TableRectangle | A rectangle that bounds the data table; null if the table isn't found. |
    | RowCount | An integer value that represents a number of rows. |
    | ColumnCount | An integer value that represents a number of columns. |
    | string this\[int row, int column\] | Gets a value of the table cell. |
    
    An instance of the class is created by the following constructors:
    
    ```csharp
    // Creates an empty instance (when value isn't found)
    DocumentDataTable(string tableName, int pageIndex);
    // Creates an instance of the data table
    DocumentDataTable(string tableName, int pageIndex, TableArea tableArea, Rectangle tableRectangle);
    ```
    
    Method DocumentData.GetTables() is used to work with tables:
    
    ```csharp
    // Get all the tables
    IList<DocumentDataTable> dataTables = data.GetDataTables();
    // Iterate over tables
    foreach(DocumentDataTable table in dataTables) {
        // Print a table name
        Console.WriteLine(table.TableName);
        // Iterate over rows
        for (int r = 0; r < table.RowCount; r++) {
            // Iterate over columns
            for (int c = 0; c < table.ColumnCount; c++) {
                // Print a value of the cell
                Console.Write(table[r, c]);
                Console.Write(" ");
            }
     
            Console.WriteLine();
        }
    }
    ```
    
2.  ### Implement the ability to move Table Layout
    
    #### Description
    
    This feature allows to move **TableAreaLayout** object.
    
    #### Public API changes
    
    Namespace GroupDocs.Parser.Extractors:
    
    *   Added **GetTableRectangle()** method to **TableAreaLayout** class
    *   Added **MoveTo(double x, double y)** method to **TableAreaLayout** class
    
    #### Usage
    
    This functionality allows to move Table Layout.
    
    For example, a document has tables on each page (or a set of documents with a table on the page). These tables differ by position and content, but have the same columns and rows. In this case a user can define TableAreaLayout object at (0, 0) once and then move it to the location of the definite table.
    
    If the table position depends on the other object of the page, a user can define TableAreaLayout object based on template document and then move it according to an anchor object. For example, if this is a summary table and it is followed by details table (which can contain a different count of rows). In this case a user can define TableAreaLayout object on template document (with the known details table rectangle) and then move TableAreaLayout object according to the difference of details table rectangle of template and real document.
    
    MoveTo method returns a copy of the current object. A user can pass any coordinates (even negative - then layout will be moved to the left/top).
    
    GetTableRectangle method returns a rectangle that bounds the table.
    
    ```csharp
    // Create a table layout
    TableAreaLayout templateLayout = new TableAreaLayout();
     
    // with 4 columns:
    templateLayout.VerticalSeparators.Add(0);
    templateLayout.VerticalSeparators.Add(25);
    templateLayout.VerticalSeparators.Add(150);
    templateLayout.VerticalSeparators.Add(180);
    templateLayout.VerticalSeparators.Add(230);
     
    // and with 5 rows:
    templateLayout.HorizontalSeparators.Add(0);
    templateLayout.HorizontalSeparators.Add(15);
    templateLayout.HorizontalSeparators.Add(30);
    templateLayout.HorizontalSeparators.Add(45);
    templateLayout.HorizontalSeparators.Add(60);
    templateLayout.HorizontalSeparators.Add(75);
     
    // Print a rectangle
    Rectangle rect = templateLayout.GetTableRectangle();
     
    // Prints: pos: (0, 0) size: (230, 75)
    Console.WriteLine(string.Format("pos: ({0}, {1}) size: ({2}, {3})", rect.Left, rect.Top, rect.Width, rect.Height));
     
    // Move layout to the definite table location
    TableAreaLayout movedLayout = templateLayout.MoveTo(315, 250);
     
    // Ensure that the first separators are moved:
    Console.WriteLine(movedLayout.VerticalSeparators[0]); // prints: 315
    Console.WriteLine(movedLayout.HorizontalSeparators[0]); // prints: 250
     
    Rectangle movedRect = movedLayout.GetTableRectangle();
     
    // Prints: pos: (315, 250) size: (230, 75)
    Console.WriteLine(string.Format("pos: ({0}, {1}) size: ({2}, {3})", movedRect.Left, movedRect.Top, movedRect.Width, movedRect.Height));
     
    // movedLayout object is a copy of templateLayout object, thus we can tune separators without the impact on the original layout:
    movedLayout.HorizontalSeparators.Add(90);
     
    Console.WriteLine(movedLayout.HorizontalSeparators.Count); // prints: 7
    Console.WriteLine(templateLayout.HorizontalSeparators.Count); // prints: 6
    ```
    
3.  ### Implement the ability to detect a table in a rectangular area using a collection of column separators
    
    #### Description
    
    This feature allows to detect tables by column separators.
    
    #### Public API changes
    
    Namespace GroupDocs.Parser.Extractors:
    
    *   Added **VerticalSeparators **property to **TableAreaDetectorParameters** class
    
    #### Usage
    
    This API provides the ability to detect tables in documents by setting table vertical separators:
    
    ```csharp
    // Create PDF text extractor
    IDocumentContentExtractor extractor = new PdfTextExtractor(fileName) as IDocumentContentExtractor;
    try
    {
        // Create table detector parameters
        TableAreaDetectorParameters parameters = new TableAreaDetectorParameters();
     
        // Set vertical separators
        parameters.VerticalSeparators = new List<double>();
        parameters.VerticalSeparators.Add(185.0);
        parameters.VerticalSeparators.Add(370.0);
        parameters.VerticalSeparators.Add(425.0);
        parameters.VerticalSeparators.Add(485.0);
        parameters.VerticalSeparators.Add(545.0);
     
        // Create a table detector
        TableAreaDetector detector = new TableAreaDetector(extractor.DocumentContent);
     
        // Detect a table on the first page with detector parameters
        IList<TableAreaLayout> layout = detector.DetectLayouts(0, parameters);
    }
    finally
    {
        // Dispose an extractor
        if (extractor is IDisposable)
        {
            (extractor as IDisposable).Dispose();
        }
    }
    ```
    
![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_7.png)
    
    For more accurate table detection a user can set a rectangular area that bounds the table:
    
    ```csharp
    // Create PDF text extractor
    IDocumentContentExtractor extractor = new PdfTextExtractor(fileName) as IDocumentContentExtractor;
    try
    {
        // Create table detector parameters
        TableAreaDetectorParameters parameters = new TableAreaDetectorParameters();
     
        // Set vertical separators
        parameters.VerticalSeparators = new List<double>();
        parameters.VerticalSeparators.Add(185.0);
        parameters.VerticalSeparators.Add(370.0);
        parameters.VerticalSeparators.Add(425.0);
        parameters.VerticalSeparators.Add(485.0);
        parameters.VerticalSeparators.Add(545.0);
     
        // Set a rectangular area that bounds a table
        parameters.Rectangle = new Rectangle(175, 350, 400, 200);
     
        // Create a table detector
        TableAreaDetector detector = new TableAreaDetector(extractor.DocumentContent);
     
        // Detect a table on the first page with detector parameters
        IList<TableAreaLayout> layout = detector.DetectLayouts(0, parameters);
    }
    finally
    {
        // Dispose an extractor
        if (extractor is IDisposable)
        {
            (extractor as IDisposable).Dispose();
        }
    }
    ```
    
![](parser/net/images/groupdocs-parser-for-net-19-5-release-notes_8.png)
    
4.  ### Remove obsolete members (version 18.7)
    
    #### Description
    
    Some constructors and properties were removed from **TextProperties** class.
    
    #### Public API changes
    
    Namespace GroupDocs.Parser.Extractors:
    
    *   Removed **TextProperties**(bool isBold, bool isItalic) constructor from **TextProperties** class
        
    *   Removed **TextProperties**(bool isBold, bool isItalic, string style) constructor constructor from **TextProperties** class
        
    *   Removed **IsBold** and **IsItalic** properties from **TextProperties** class.
        
    
    #### Usage
    
    Use TextProperties(Font font) or TextProperties(Font font, string style) constructors instead:
    
    ```csharp
    TextProperties properties = new TextProperties(new Font(false, true));
     
    // instead of:
     
    TextProperties properties = new TextProperties(false, true);
    ```
    
    ```csharp
    TextProperties properties = new TextProperties(new Font(false, true), "congue");
     
    // instead of:
     
    TextProperties properties = new TextProperties(false, true, "congue");
    ```
    
    Use Font property instead of IsBold or IsItalic properties:
    
    ```csharp
    TextProperties properties = new TextProperties(new Font(false, true));
     
    Console.WriteLine("IsItalic " + (properties.Font.IsItalic ? "yes" : "No"));
    Console.WriteLine("IsBold " + (properties.Font.IsBold ? "yes" : "No"));
     
    // instead of:
     
    Console.WriteLine("IsItalic " + (properties.IsItalic ? "yes" : "No"));
    Console.WriteLine("IsBold " + (properties.IsBold ? "yes" : "No"));
    ```
    
5.  ### Implement the support for spreadsheet and presentation templates
    
    #### Description
    
    This feature allows to extract a text and metadata from the following documents:
    
    #### **Spreadsheet**
    
    | Format | Description |
    | --- | --- |
    | XLT | Microsoft Excel Template |
    | XLTX | Office Open XML Spreadsheet Template |
    | XLTM | Office Open XML Spreadsheet Template (Macro-enabled) |
    | OTS | Open Document Spreadsheet Template |
    | XLA | Excel Add-In File |
    | XLAM | Excel Open XML Macro-Enabled Add-In |
    
    #### **Presentations**
    
    | Format | Description |
    | --- | --- |
    | POT | PowerPoint Template |
    | OTP | Open Document Presentation Template |
