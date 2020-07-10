---
id: groupdocs-parser-for-net-18-4-release-notes
url: parser/net/groupdocs-parser-for-net-18-4-release-notes
title: GroupDocs.Parser for .NET 18.4 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.4.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Removed obsolete members
*   Improved the public API
*   Ability to extract topics from EPUB documents
*   Ability to detect media type for .one files

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-911 | Remove obsolete members (version 18.4) | Enhancement |
| TEXTNET-915 | Improve the public API | Enhancement |
| TEXTNET-910 | Implement the ability to extract topics from EPUB documents | New feature |
| TEXTNET-929 | Implement the media type detector for .one files | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to extract topics from EPUB documents

#### Description

This feature allows extracting the table of contents (TOC) from EPUB documents.

#### Public API changes

Added **TableOfContents** property to **EpubPackage** class.  
Added the implementation of **IPageTextExtractor** interface to **EpubPackage** class.

#### Usage

TableOfContents property is used to retrieve a list of TOC items:

```csharp
IList<TableOfContentsItem> TableOfContents { get; }
```

TableOfContentsItem has the following members:

| Name | Description |
| --- | --- |
| Text | The text of the item. Usually, it is a chapter's title |
| PageIndex | The page index of the text. Null if it is just a node without content |
| Count | The number of sub-items. Zero if the item hasn't sub-items |
| this\[int index\] | Gets a sub-item |
| ExtractPage | Extracts a text of the item |

This example shows how to print TOC:

**C#**

```csharp
// Create a text extractor
using (EpubTextExtractor extractor = new EpubTextExtractor(@"document.epub"))
{
    // Print TOC on the screen
    PrintToc(extractor[0].TableOfContents, 0);
}

private static void PrintToc(IEnumerable<TableOfContentsItem> tableOfContents, int depth)
{
    // Use spaces to indicate the depth of the TOC item
    string spaces = new string(' ', depth);

    // Iterate over items
    foreach (TableOfContentsItem item in tableOfContents)
    {
        System.Console.Write(spaces);
        // Print the item's text
        System.Console.Write(item.Text);

        // If item has a text (it's not just a node)
        if (item.PageIndex.HasValue)
        {
            // Print the text length
            System.Console.Write(string.Format(" ({0})", item.ExtractPage().Length));
        }

        System.Console.WriteLine();

        // If the item has children
        if (item.Count > 0)
        {
            // Print them
            PrintToc(item, depth + 1);
        }
    }
}
```

This example shows how to extract a text of the item:

**C#**

```csharp
// Create a text extractor
using (EpubTextExtractor = new EpubTextExtractor(@"document.epub"))
{
    // Print a content of the third sub-item of the second item
    Console.WriteLine(extractor[0].TableOfContents[1][2].ExtractPage());
}
```

### Implementation of the media type detector for .one files

#### Description

This feature allows detecting the media type of OneNote sections.

#### Public API changes

Added **NoteMediaTypeDetector** class.

#### Usage

**C#**

```csharp
// Create a media type detector
var detector = new NoteMediaTypeDetector();
// Detect a media type by the file name
Console.WriteLine(detector.Detect("section.one");
// Detect a media type by the content
Console.WriteLine(detector.Detect(stream));
```

### Improved public API

#### Description

This enhancement allows working with functionality via generic interfaces.

#### Public API changes

Added implementation of **ITextExtractorWithFormatter** interface to **ChmFormattedTextExtractor** class.  
Added implementation of **ITextExtractorWithFormatter** interface to **MarkdownFormattedTextExtractor** class.  
Added implementation of **ISearchable**, **IRegexSearchable** and **IHighlightExtractor** interfaces to **MarkdownTextExtractor** class.

#### Usage

With **ITextExtractorWithFormatter** interface a user can set a document formatter:

**C#**

```csharp
// If the extractor supports ITextExtractorWithFormatter interface
if (extractor is ITextExtractorWithFormatter) {
  // Set MarkdownDocumentFormatter formatter
  (extractor as ITextExtractorWithFormatter).DocumentFormatter = new MarkdownDocumentFormatter();
}
```

### Removal of obsolete members

#### Description

**EmailSubject**, **EmailSender** and **EmailReceiver** constants from **PersonalStorageContainer** class are removed.

#### Public API changes

**EmailSubject**, **EmailSender** and **EmailReceiver** constants from **PersonalStorageContainer** class are removed.

#### Usage

| New constant | Removed constant |
| --- | --- |
| MetadataNames.Subject | PersonalStorageContainer.EmailSubject |
| MetadataNames.EmailFrom | PersonalStorageContainer.EmailSender |
| MetadataNames.EmailTo | PersonalStorageContainer.EmailReceiver |
