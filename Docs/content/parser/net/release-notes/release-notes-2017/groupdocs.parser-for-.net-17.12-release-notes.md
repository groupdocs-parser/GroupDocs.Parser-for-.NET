---
id: groupdocs-parser-for-net-17-12-release-notes
url: parser/net/groupdocs-parser-for-net-17-12-release-notes
title: GroupDocs.Parser for .NET 17.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.12.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Ability to extract pages from OneNote documents via IPageTextExtractor interface
*   Ability to work with document formatters via ITextExtractorWithFormatter interface
*   Ability to retrieve an entity from Zip container by the full name
*   Ability to extract a raw and formatted text via Extractor class

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-820 | Implement IPageTextExtractor support for NoteTextExtractor | Enhancement |
| TEXTNET-826 | Implement ITextExtractorWithFormatter interface | Enhancement |
| TEXTNET-823 | Implement the ability to retrieve an entity from Zip container by the full name | New feature |
| TEXTNET-824 | Implement the ability to extract a text via Extractor class | New feature |
| TEXTNET-825 | Implement the ability to extract a formatted text via Extractor class | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### IPageTextExtractor support for NoteTextExtractor

#### Description

This enhancement allows working with OneNotes pages via **IPageTextExtractor** interface.

#### Public API changes

Added the implementation of IPageTextExtractor interface to NoteTextExtractor class.

#### Usage

This example shows how to extract a text by pages via a generic function:

**C#**

```csharp
// Create a text extractor
NoteTextExtractor textExtractor = new NoteTextExtractor(stream);
// Invoke a function to print a text by pages
PrintPages(textExtractor);

// This function allows to extract a text by pages from any text extractor with IPageTextExtractor interface support
void PrintPages(TextExtractor textExtractor)
{ 
    // Check if IPageTextExtractor is supported
    IPageTextExtractor pageTextExtractor = textExtractor as IPageTextExtractor;
    if (pageTextExtractor != null)
    {
        // Iterate over all pages
        for (int i = 0; i < pageTextExtractor.PageCount; i++)
        {
            // Print a page number
            Console.WriteLine(string.Format("{0}/{1}", i, pageTextExtractor.PageCount));
            // Extract a text from the page
            Console.WriteLine(pageTextExtractor.ExtractPage(i));
        }
    }
}
```

### ITextExtractorWithFormatter interface

#### Description

This enhancement allows to set or get a document formatter via **ITextExtractorWithFormatter** interface.

#### **Public API Changes**

Added **ITextExtractorWithFormatter** interface.

#### Usage

ITextExtractorWithFormatter interface has only one property:

**C#**

```csharp
DocumentFormatter DocumentFormatter { get; set; }
```

This property gets or sets a document formatter of formatted text extractors.

**C#**

```csharp
// If the extractor supports ITextExtractorWithFormatter interface
if (extractor is ITextExtractorWithFormatter) {
  // Set MarkdownDocumentFormatter formatter
  (extractor as ITextExtractorWithFormatter).DocumentFormatter = new MarkdownDocumentFormatter;
}
```

  

### Ability to retrieve an entity from Zip container by the full name

#### Description

This feature allows getting an entity from Zip container by the full name.

#### Public API changes

Added **GetEntity** method to **ZipContainer** class.

#### Usage

This example shows how to extract a text from the entity:

**C#**

```csharp
// Create a factory
ExtractorFactory factory = new ExtractorFactory();
// Create Zip container
ZipContainer zip = new ZipContainer(stream);
// Try to get "container.xml" entity from "META-INF" folder
Container.Entity containerEntry = zip.GetEntity("META-INF\\container.xml");
// If the entity isn't found
if (containerEntry == null)
{
    throw new GroupDocsTextException("File not found");
}

// Try to create a text extractor
TextExtractor extractor = factory.CreateTextExtractor(containerEntry.OpenStream());
try
{
    // Extract a text (if the document type is supported)
    Console.WriteLine(extractor == null ? "Document type isn't supported" : extractor.ExtractAll());
}
finally
{
    // Cleanup
    if (extractor != null)
    {
        extractor.Dispose();
    }
}
```

### Ability to extract a text via Extractor class

#### Description

This feature allows extracting a text from a file or stream via a simple interface.

#### Public API changes

Added **ExtractText** methods to **Extractor** class.

#### Usage

Extractor class contains four methods to extract a text:

**C#**

```csharp
string ExtractText(string fileName)
string ExtractText(string fileName, LoadOptions loadOptions)
string ExtractText(Stream stream)
string ExtractText(Stream stream, LoadOptions loadOptions)
```

A user can extract a text from a stream or file:

**C#**

```csharp
// Extract a text from the stream
Console.WriteLine(Extractor.Default.ExtractText(stream));

// Extract a text from the file
Console.WriteLine(Extractor.Default.ExtractText(fileName));
```

If loadOptions or loadOptions.MediaType is null, media type will be detected by the extension (or content) of the file. Setting {loadOptions}} will increase text extraction (because detecting media type is skipped):

**C#**

```csharp
// Create load options
LoadOptions loadOptions = new LoadOptions(MediaTypeNames.Application.WordOpenXml);
// Extract a text from the file
Console.WriteLine(Extractor.Default.ExtractText(fileName, loadOptions));
```

Extractor.Default property contains a default instance of Extractor class. It's used in most cases. If the custom behavior is needed, Extractor class can be created via constructor:

**C#**

```csharp
// Create an instance of Extractor
Extractor extractor = new Extractor(mediaTypeDetector, encodingDetector, notificationReceiver);
// Extract a text from the stream
Console.WriteLine(extractor.ExtractText(stream));
```

Any of constructor's parameter is optional and can be null. In this case, the default behavior is used.

### Ability to extract a formatted text via Extractor class

#### Description

This feature allows extracting a formatted text from a file or stream via a simple interface.

#### Public API changes

Added **ExtractFormattedText** methods to **Extractor** class.  
Added the constructor with **DocumentFormatter** parameter to **Extractor** class.

#### Usage

Extractor class contains four methods to extract a formatted text:

**C#**

```csharp
string ExtractFormattedText(string fileName)
string ExtractFormattedText(string fileName, LoadOptions loadOptions)
string ExtractFormattedText(Stream stream)
string ExtractFormattedText(Stream stream, LoadOptions loadOptions)
```

A user can extract a formatted text from a stream or file:

**C#**

```csharp
// Extract a formatted text from the stream
Console.WriteLine(Extractor.Default.ExtractFormattedText(stream));

// Extract a formatted text from the file
Console.WriteLine(Extractor.Default.ExtractFormattedText(fileName));
```

If loadOptions or loadOptions.MediaType is null, media type will be detected by the extension (or content) of the file. Setting {loadOptions}} will increase text extraction (because detecting media type is skipped):

**C#**

```csharp
// Create load options
LoadOptions loadOptions = new LoadOptions(MediaTypeNames.Application.WordOpenXml);
// Extract a formatted text from the file
Console.WriteLine(Extractor.Default.ExtractFormattedText(fileName, loadOptions));
```

Extractor.Default property contains a default instance of Extractor class. It's used in most cases. If the custom behavior is needed, Extractor class can be created via constructor:

**C#**

```csharp
// Create an instance of Extractor
Extractor extractor = new Extractor(mediaTypeDetector, encodingDetector, notificationReceiver, documentFormatter);
// Extract a formatted text from the stream
Console.WriteLine(extractor.ExtractFormattedText(stream));
```

Any of constructor's parameter is optional and can be null. In this case, the default behavior is used.

**C#**

```csharp
// Create an instance of Extractor with a custom document formatter
Extractor extractor = new Extractor(null, null, null, new MarkdownDocumentFormatter());
// Extract a Markdown-formatted text
Console.WriteLine(extractor.ExtractFormattedText(stream));
```
