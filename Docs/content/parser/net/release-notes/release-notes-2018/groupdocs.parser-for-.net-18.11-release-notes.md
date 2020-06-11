---
id: groupdocs-parser-for-net-18-11-release-notes
url: parser/net/groupdocs-parser-for-net-18-11-release-notes
title: GroupDocs.Parser for .NET 18.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.11.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Implemented the ability to retrieve the information of supported extractors for a document
*   Implemented IFastTextExtractor interface
*   Implemented IDocumentContentExtractor interface
*   Improved text area extraction for PDF documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1077 | Implement the ability to retrieve the information of supported extractors for a document | New feature |
| PARSERNET-1075 | Implement IFastTextExtractor interface | Enhancement |
| PARSERNET-1076 | Implement IDocumentContentExtractor interface | Enhancement |
| PARSERNET-1069 | Improve text area extraction for PDF documents | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to retrieve the information of supported extractors for a document

#### Description

This enhancement allows getting the information of supported extractors for a document.

#### Public API changes

*   Added **DocumentInfo** class
    
*   Added **GetDocumentInfo** methods to **ExtractorFactory** class
    

#### Usage

**DocumentInfo** class has the following properties:

| Property | Description |
| --- | --- |
| HasText | Boolean value indicating if a user can extract a plain text from a document |
| HasFormattedText | Boolean value indicating if a user can extract a formatted text from a document |
| HasMetadata | Boolean value indicating if a user can extract metadata from a document |
| IsContainer | Boolean value indicating if a document contains other documents (like email attachments or zip archive) |

Usage:

**C#**

```csharp
void PrintDocumentInfo(string fileName)
{
    ExtractorFactory factory = new ExtractorFactory();
    // Get the document info
    DocumentInfo info = factory.GetDocumentInfo(fileName);
    Console.WriteLine("This document contains:");
 
    // Check if a user can extract a plain text from a document
    if (info.HasText)
    {
        Console.WriteLine("text");
    }
 
    // Check if a user can extract a formatted text from a document
    if (info.HasFormattedText)
    {
        Console.WriteLine("formatted text");
    }
 
    // Check if a user can extract metadata from a document
    if (info.HasMetadata)
    {
        Console.WriteLine("metadata");
    }
 
    // Check if the document contains other documents
    if (info.IsContainer)
    {
        Console.WriteLine("other documents");
    }
}
```

### Improved text area extraction for PDF documents

#### Description

This enhancement improves text area extraction for PDF documents. The Y-coordinates of text areas start from the top of the page. Text areas have more items for some kind of documents.

#### Public API changes

No API changes.

#### Usage

**C#**

```csharp
// Create a text extractor
PdfTextExtractor extractor = new PdfTextExtractor("invoice.pdf");
  
// Create search options
TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
// Set a regular expression to search 'Invoice # XXX' text
searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
// Limit the search with a rectangle
searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);
  
// Get text areas
IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);
              
// Iterate over a list
foreach(TextArea area in texts) {
    // Print a text
    Console.WriteLine(area.Text);
}
```

### IFastTextExtractor interface

#### Description

This enhancement allows setting the fast text extraction via **IFastTextExtractor **interface.

#### Public API changes

Added **IFastTextExtractor **interface

Added support for **IFastTextExtractor **interface to the following classes:

*   **PdfTextExtractor** class
*   **CellsTextExtractor** class
*   **SlidesTextExtractor** class

#### Usage

**IFastTextExtractor** interface has only one property:

```csharp
ExtractMode ExtractMode { get; set; }
```

This property gets or sets a value indicating the mode of text extraction. `ExtractMode` enumeration has the following members:

| Value | Description |
| --- | --- |
| `Simple` | Fast text extraction. The text in this mode is not extracted in a very accurate way but faster than it is extracted in the standard mode. If the fast text extraction doesn't support the document format, this parameter is ignored and the standard text extraction is used. |
| `Standard` | Standard text extraction. |

Usage:

**C#**

```csharp
void ExtractText(TextExtractor extractor) {  
  IFastTextExtractor fastTextExtractor = extractor as IFastTextExtractor ;
  // Check if extractor supports IFastTextExtractor interface
  if (fastTextExtractor != null) {
    // Set the mode of text extraction
    fastTextExtractor.ExtractMode = ExtractMode.Simple;
  }
  // Extract a text
  System.Console.WriteLine(extractor.ExtractAll());
}
```

### IDocumentContentExtractor interface

#### Description

This enhancement allows getting the access to Text Analysis API via **IDocumentContentExtractor **interface.

#### Public API changes

Added **IDocumentContentExtractor **interface

Added support for **IDocumentContentExtractor** interface to the following classes:

*   **PdfTextExtractor** class
*   **CellsTextExtractor** class
*   **SlidesTextExtractor** class
*   **WordsTextExtractor** class

#### Usage

**IDocumentContentExtractor** interface has only one property:

```csharp
DocumentContent DocumentContent { get; }
```

This property gets the access to the document's content.

Usage:

**C#**

```csharp
void ExtractText(TextExtractor extractor) {  
  IDocumentContentExtractor contentExtractor = extractor as IDocumentContentExtractor;
  // Check if extractor supports IDocumentContentExtractor interface
  if (contentExtractor != null) {
    // Iterate over pages
    for (int i = 0; i < contentExtractor.DocumentContent.PageCount; i++) {
      // Iterate over text areas of the page
      foreach (TextArea textArea in contentExtractor.DocumentContent.GetTextAreas(i)) {
        Console.WriteLine(textArea.Text);
      }
    }
  }
}
```
