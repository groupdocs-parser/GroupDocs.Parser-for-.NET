---
id: groupdocs-parser-for-net-18-12-release-notes
url: parser/net/groupdocs-parser-for-net-18-12-release-notes
title: GroupDocs.Parser for .NET 18.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.12.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Added the ability to extract tables from PDFs
*   Added the support for text and presentation templates
*   Added the ability to detect the type of password-protected Office Open XML documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1016 | Implement the ability to extract tables from PDFs | New feature |
| PARSERNET-1097 | Implement the support for text and presentation templates | New feature |
| PARSERNET-1092 | Implement the ability to detect the type of password-protected Office Open XML documents | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to extract tables from PDFs

#### Description

This feature allows extracting tables from PDF documents.

#### Public API changes

*   Added **TableArea** class
*   Added **TableAreaCell** class
*   Added **TableAreaLayout** class
*   Added **TableAreaDetector** class
*   Added **TableAreaDetectorParameters** class
*   Added **TableAreaParser** class
*   Added **TableAreaDetector** property to **PdfTextExtractor** class
*   Added **TableAreaParser** property to **PdfTextExtractor** class

#### Usage

For extracting tables from PDF document, **TableAreaParser** class is used. The instance of **TableAreaParser** class is available via property with the same name in **PdfTextExtractor** class:

**C#**

```csharp
PdfTextExtractor extractor = new PdfTextExtractor("document.pdf"); 
TableAreaParser parser = extractor.TableAreaParser;
```

**ParseTableArea** method is used to extract a table from the document page:

**C#**

```csharp
TableArea ParseTableArea(int pageIndex, TableAreaLayout tableAreaLayout)
```

This method accepts the zero-based page index and layout of the table. The layout is represented by **TableAreaLayout** class with the following members:

| Member | Description |
| --- | --- |
| VerticalSeparators | A collection of vertical separators |
| HorizontalSeparators | A collection of horizontal separators |

These collections represent bounds of columns and rows. For example, for 2x2 table there are 3 vertical and 3 horizontal separators:

`---------`

`|   |   |`

`---------`

`|   |   |`

`---------`

**TableArea** class has the following members:

| Member | Description |
| --- | --- |
| int RowCount | Number of table rows |
| int ColumnCount | Number of table columns |
| TableAreaCell this\[int row, int column\] | Cell of the table |
| double GetRowHeight(int row) | Height of the row |
| double GetColumnWidth(int column) | Width of the row |

**TableCellArea** class has the following members:

| Member | Description |
| --- | --- |
| TextArea | Content of the cell. |
| Row | Zero-based index of the row. |
| Column | Zero-based index of the column. |
| RowSpan | Number of rows which the cell spans across. |
| ColumnSpan | Number of columns which the cell spans across. |

Usage:

**C#**

```csharp
void Parse(string fileName)
{
    // Create a text extractor
    using (var extractor = new PdfTextExtractor(fileName))
    {
        // Get a table parser
        var parser = extractor.TableAreaParser;
        // Create a table layout
        var layout = new TableAreaLayout();
        // Add vertical separators (columns)
        layout.VerticalSeparators.Add(72);
        layout.VerticalSeparators.Add(125);
        layout.VerticalSeparators.Add(333);
        layout.VerticalSeparators.Add(454);
        layout.VerticalSeparators.Add(485);
        // Add horizontal separators (rows)
        layout.HorizontalSeparators.Add(390);
        layout.HorizontalSeparators.Add(417);
        layout.HorizontalSeparators.Add(440);
        layout.HorizontalSeparators.Add(500);
        layout.HorizontalSeparators.Add(521);
        // Extract a table area
        var tableArea = parser.ParseTableArea(0, layout);
        // Iterate over rows
        for (var row = 0; row < tableArea.RowCount; row++)
        {
            Console.Write("| ");
            // Iterate over columns
            for (var column = 0; column < tableArea.ColumnCount; column++)
            {
                // Get a table cell
                var cell = tableArea[row, column];
                // If a cell is empty or it continues another cell
                if (cell == null || cell.Column != column || cell.Row != row)
                {
                    // Skip this cell
                    continue;
                }
                // Write content of the cell
                Console.Write(cell == null ? " " : cell.TextArea.Text);
                Console.Write(" | ");
            }
            Console.WriteLine();
        }
    }
}
```

A user can create **TableAreaLayout** object manually or by using **TableAreaDetector** class. The instance of **TableAreaDetector** class is available via property with the same name in **PdfTextExtractor** class:

**C#**

```csharp
PdfTextExtractor extractor = new PdfTextExtractor("document.pdf");
TableAreaDetector detector = extractor.TableAreaDetector;
```

**TableAreaDetector** class is created to find table bounds in automatic mode. **DetectLayouts** method searches tables on the page of the document and returns a collection of table layouts:

**C#**

```csharp
IList<TableAreaLayout> DetectLayouts(int pageIndex, params TableAreaDetectorParameters[] parameters)
```

This method accepts the zero-based page index and optional parameters. These parameters help to detect tables. If set, the detector tries to search only those tables which meet this criterion; the total number of detected tables, in this case, must be equal to the number of passed parameters.

**TableAreaDetectorParameters** class has the following members:

| Member | Description |
| --- | --- |
| MinRowCount | Minimum number of table rows. |
| MinColumnCount | Minimum number of table columns. |
| HasMergedCells | Value indicating whether the table has merged cells. |
| MinVerticalSpace | Minimum width of vertical separators. |
| Rectangle | Rectangle which bounds a table detection region. |

By setting parameters a user can tune detector's behavior. For example, limit the page area to search a table and disable searching complex tables (with merged cells):

**C#**

```csharp
void DetectAndParse(string fileName)
{
    // Create a text extractor
    using (var extractor = new PdfTextExtractor(fileName))
    {
        // Get a table detector
        var detector = extractor.TableAreaDetector;
        var pageIndex = 0;
        // Get a page object
        var page = extractor.DocumentContent.GetPage(pageIndex);
        // Create a parameter to help the detector to search a table
        var parameter = new TableAreaDetectorParameters();
        // We assume that the table is placed in a middle of the page and has a half page height
        parameter.Rectangle = new Rectangle(0, page.Height / 3, page.Width, page.Height / 2);
        // Table hasn't merged cells
        parameter.HasMergedCells = false;
        // Table contains 3 or more rows
        parameter.MinRowCount = 3;
        // Table contains 4 or more columns
        parameter.MinColumnCount = 4;
        // Detect layouts
        var layouts = detector.DetectLayouts(pageIndex, parameter);
        // If layouts collection is empty - exit
        if (layouts.Count == 0)
        {
            Console.WriteLine("No tables found");
            return;
        }
        // Get a table parser
        var parser = extractor.TableAreaParser;
        // Extract a table area. As we pass only one parameter, there is only one layout
        var tableArea = parser.ParseTableArea(pageIndex, layouts[0]);
        // Iterate over rows
        for (var row = 0; row < tableArea.RowCount; row++)
        {
            Console.Write("| ");
            // Iterate over columns
            for (var column = 0; column < tableArea.ColumnCount; column++)
            {
                // Get a table cell
                var cell = tableArea[row, column];
                // If a cell is empty or it continues another cell
                if (cell == null || cell.Column != column || cell.Row != row)
                {
                    // Skip this cell
                    continue;
                }
                // Print content of the cell
                Console.Write(cell == null ? " " : cell.TextArea.Text);
                Console.Write(" | ");
            }
            Console.WriteLine();
        }
    }
}
```

### Support for text and presentation templates

#### Description

This feature allows to extract a text and metadata from the following documents:

*       dotx (Template)
*       dotm (Macro-enabled template)
*       ott (OpenDocument Text Template)
*       potx (Template)
*       potm (Macro-enabled template)
*       ppsm (Macro-enabled slide show)
*       pptm (Macro-enabled presentation)

#### Public API changes

No API changes.

#### Usage

**C#**

```csharp
void ExtractText(string fileName)
{
    // Extract a text from the file
    var text = Extractor.Default.ExtractText(fileName);
    // Print an extracted text
    Console.WriteLine(text);
}
 
void ExtractMetadata(string fileName)
{
    // Extract metadata from the file
    var metadata = Extractor.Default.ExtractMetadata(fileName);
    // Print extracted metadata
    foreach (var m in metadata)
    {
        // Print a metadata key
        Console.Write(m.Key);
        Console.Write(": ");
        // Print a metadata value
        Console.WriteLine(m.Value);
    }
}
 
void DetectMediaType(string fileName)
{
    // Get a default composite media type detector
    var detector = CompositeMediaTypeDetector.Default;
    // Detect a media type
    var mediaType = detector.Detect(fileName);
    // Print a detected media type
    Console.WriteLine(mediaType);
}
```

### Ability to detect the type of password-protected Office Open XML documents

#### Description

This feature allows detecting password-protected Office Open XML documents by content.

#### Public API changes

*   Added string **Detect(Stream, LoadOptions)** public method to **MediaTypeDetector** class.
*   Added string **DetectByContent(Stream, LoadOptions)** protected virtual method to **MediaTypeDetector** class.
*   Marked as obsolete **string DetectByContent(Stream)** protected virtual method from **MediaTypeDetector** class.

#### Usage

To detect media type of encrypted Office Open XML document **Detect(Stream, LoadOptions)** method is used:

**C#**

```csharp
void Detect(string fileName, string password)
{
    // Create load options
    LoadOptions loadOptions = new LoadOptions();
    // Set a password
    loadOptions.Password = password;
    // Get a default composite media type detector
    var detector = CompositeMediaTypeDetector.Default;
    // Create a stream to detect media type by content (not file extension)                
    using (var stream = File.OpenRead(fileName))
    {
        // Detect a media type
        var mediaType = detector.Detect(stream, loadOptions);
        // Print a detected media type
        Console.WriteLine(mediaType);
    }
}
```

For batch document processing PasswordProvider is used:

**C#**

```csharp
class Detector : IPasswordProvider
{
    private string currentFile;
    public void Detect(string[] documents)
    {
        // Create load options
        LoadOptions loadOptions = new LoadOptions();
        // Set a password provider (it requests a password for protected documents if nessesary)
        loadOptions.PasswordProvider = this;
        // Get a default composite media type detector
        var detector = CompositeMediaTypeDetector.Default;
        // Iterage over documents
        foreach (var fileName in documents)
        {
            // Set the current file name to dispay it with the password request
            currentFile = fileName;
            // Create a stream to detect media type by content (not file extension)                
            using (var stream = File.OpenRead(fileName))
            {
                // Detect a media type
                var mediaType = detector.Detect(stream, loadOptions);
                // Print a detected media type
                Console.WriteLine(mediaType);
            }
        }
    }
    // If the document is encrypted Office Open XML, OnPasswordRequest is invoked
    public void OnPasswordRequest(object sender, PasswordRequest request)
    {
        // Print a password request
        Console.WriteLine($"Enter password for {currentFile}:");
        string password = Console.ReadLine();
        // If a user omits a password (entered a blank password)
        if (string.IsNullOrEmpty(password))
        {
            // Mark the request as cancelled
            request.Cancel = true;
        }
        else
        {
            // Set a password
            request.Password = password;
        }
    }
}
```
