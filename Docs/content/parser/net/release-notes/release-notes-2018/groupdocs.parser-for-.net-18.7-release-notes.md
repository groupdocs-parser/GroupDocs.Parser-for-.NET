---
id: groupdocs-parser-for-net-18-7-release-notes
url: parser/net/groupdocs-parser-for-net-18-7-release-notes
title: GroupDocs.Parser for .NET 18.7 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.7.{{< /alert >}}

## Major Features

There are the following features in this release:

*   API to provide data for text analysis
*   Support for text analysis API for PDF documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-992 | Implement API to provide data for text analysis | New feature |
| PARSERNET-956 | Implement the support for text analysis API for PDF documents | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### API to provide data for text analysis

#### Description

This feature allows extracting text areas from document pages.

#### Public API changes

Added **DocumentContent** class.  
Added **DocumentPage** class.  
Added **TextArea** class.  
Added **TextAreaItem** class.  
Added **Rectangle** class.  
Added **Font** class.  
Added **Font** property to **TextProperties** class.  
**IsBold** and **IsItalic** properties of **TextProperties** class are marked as obsolete.

DocumentContent abstract class provides API to extract text areas from document pages. This API is represented by an abstract class, so we can extend this API in new versions. To provide this API, text extractor implements its own internal private class and provides DocumentContent property (see PdfTextExtractor as the sample).

DocumentContent class has the following members:

| Member | Description |
| --- | --- |
| PageCount | Returns a total number of document pages |
| Dispose | Releases resources used by the class |
| GetPage | Returns a document page (see below) |
| GetTextAreas | Returns a collection of TextArea objects (see below) |

GetPage method returns an instance of DocumentPage class. This class has the following members:

| Member | Description |
| --- | --- |
| Index | Zero-based page index |
| Width | Page width |
| Height | Page height |
| TextAreas | Collection of TextArea objects |

GetPage method works in the same way as GetTextAreas method excepting it returns DocumentPage object instead of collection of text areas.

GetTextAreas method returns a collection of TextArea objects. There are two versions of this method:

**C#**

```csharp
GetTextArea(int pageIndex)
GetTextArea(int pageIndex, TextAreaSearchOptions searchOptions)
```

  
The first version returns all text areas from the page. The second version provides the ability to search a text with the regular expression and bounds the search area by the rectangle. TextAreaSearchOptions class has the following members:

| Member | Description |
| --- | --- |
| Expression | Regular expression. Null if it isn't used |
| Rectangle | Rectangle to bound the search area. Null if it isn't used |
| IgnoreFormatting | A value indicating whether text formatting is ignored. |
| UniteSegments | A value indicating whether nearby standing text segments are united. |

TextArea class has the following members:

| Member | Description |
| --- | --- |
| Page | Document page |
| Text | Text of the text area |
| Rectangle | Rectangle of the text area |
| Items | Collection of TextAreaItem objects |
| Dispose | Removes an object from DocumentPage |

TextArea class can be used as a stand-alone object. In this case, it has own Rectangle and Text properties; Items collection is empty. But in most cases it contains items. If TextArea object has items, then Text and Rectangle properties are calculated by Items collection.

Rectangle class has the following members:

| Member | Description |
| --- | --- |
| Left | X-coordinate of the upper-left corner |
| Top | Y-coordinate of the upper-left corner |
| Right | X-coordinate of the lower-right corner |
| Bottom | Y-coordinate of the lower-right corner |
| Width | Width of the rectangle |
| Height | Height of the rectangle |

TextAreaItem class has the following members:

| Member | Description |
| --- | --- |
| Text | Text of the text area |
| Rectangle | Rectangle of the text area |
| TextProperties | Text properties of the segment |

TextProperties class has Font property. Font class has the following members:

| Member | Description |
| --- | --- |
| IsBold | A value indicating whether the text is bold; otherwise, false. |
| IsItalic | A value indicating whether the text is italic; otherwise, false. |
| Name | Font name |
| Size | Font size |

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
foreach(TextArea area in texts)
{
    // Print a text
    Console.WriteLine(area.Text);
}
```

### Support for text analysis API for PDF documents

#### Description

This feature allows extracting text areas from document pages of PDF documents.

#### Public API changes

Added **DocumentContent** property to **PdfTextExtractor** class.

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
foreach(TextArea area in texts)
{
    // Print a text
    Console.WriteLine(area.Text);
}
```
