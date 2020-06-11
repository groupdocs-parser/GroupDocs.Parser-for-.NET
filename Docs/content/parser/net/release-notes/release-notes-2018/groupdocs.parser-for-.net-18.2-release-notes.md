---
id: groupdocs-parser-for-net-18-2-release-notes
url: parser/net/groupdocs-parser-for-net-18-2-release-notes
title: GroupDocs.Parser for .NET 18.2 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.2.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Ability to extract a raw text from Markdown documents
*   Ability to extract a formatted text from Markdown documents
*   Ability to extract a text with its structure from Markdown documents
*   Improved the memory consuming while extracting a text from ost/pst files

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-843 | Implement the support for raw text extraction from Markdown documents | New feature |
| TEXTNET-844 | Implement the support for formatted text extraction from Markdown documents | New feature |
| TEXTNET-845 | Implement the support for structured text extraction from Markdown documents | New feature |
| TEXTNET-873 | Improve the memory consuming while extracting a text from ost (pst) files | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support for raw text extraction from Markdown documents

#### Description

This feature allows extracting a raw text from Markdown (.md) files.

#### Public API changes

Added **MarkdownTextExtractor** class.

#### Usage

Extracts a line of characters from a document:

**C#**

```csharp
// Create a text extractor for Markdown documents
using (var extractor = new MarkdownTextExtractor(stream)) {
  // Extract a line of the text
  string line = extractor.ExtractLine();
  // If the line is null, then the end of the file is reached
  while (line != null) {
    // Print a line to the console
    Console.WriteLine(line);
    // Extract another line
    line = extractor.ExtractLine();
  }
} 
```

Extracts all characters from a document:

**C#**

```csharp
// Create a text extractor for Markdown documents
using (var extractor = new MarkdownTextExtractor(stream)) {
  // Extract a text
  Console.WriteLine(extractor.ExtractAll());
}
```

### Support for formatted text extraction from Markdown documents

#### Description

This feature allows extracting a formatted text from Markdown (.md) files.

#### Public API changes

Added **MarkdownFormattedTextExtractor** class.

#### Usage

Extracts a line of characters from a document:

**C#**

```csharp
// Create a text extractor for Markdown documents
using (var extractor = new MarkdownFormattedTextExtractor(stream)) {
  // Extract a line of the text
  string line = extractor.ExtractLine();
  // If the line is null, then the end of the file is reached
  while (line != null) {
    // Print a line to the console
    Console.WriteLine(line);
    // Extract another line
    line = extractor.ExtractLine();
  }
} 
```

Extracts all characters from a document:

**C#**

```csharp
// Create a text extractor for Markdown documents
using (var extractor = new MarkdownFormattedTextExtractor(stream)) {
  // Extract a text
  Console.WriteLine(extractor.ExtractAll());
}
```

For setting a formatter DocumentFormatter property is used. By default, a text is formatted as a plain text by PlainDocumentFormatter.

**C#**

```csharp
// Create a formatted text extractor for text documents
MarkdownFormattedTextExtractor extractor = new MarkdownFormattedTextExtractor(stream);
// Set a HTML formatter for formatting
extractor.DocumentFormatter = new HtmlDocumentFormatter(); // all the text will be formatted as HTML
```

### Support for structured text extraction from Markdown documents

#### Description

This feature allows extracting a text with its structure from Markdown (.md) files.

#### Public API changes

Added **ExtractStructured** method to **MarkdownTextExtractor** class.  
Added **Style** property to **TextProperties** class.  
Added (bool isEmphasized, string style) constructor to **TextProperties** class.

#### Usage

Extracting headers from a document:

**C#**

```csharp
StringBuilder sb = new StringBuilder();
IStructuredExtractor extractor = new MarkdownTextExtractor(stream);
StructuredHandler handler = new StructuredHandler();

// Handle List event to prevent processing of lists
handler.List += (sender, e) => e.Properties.SkipElement = true; // ignore lists

// Handle Table event to prevent processing of tables
handler.Table += (sender, e) => e.Properties.SkipElement = true; // ignore tables

// Handle Paragraph event to process a paragraph
handler.Paragraph += (sender, e) =>
{
    int h1 = (int)ParagraphStyle.Heading1;
    int h6 = (int)ParagraphStyle.Heading6;

    int style = (int)e.Properties.Style;
    if (h1 <= style && style <= h6)
    {
        if (sb.Length > 0)
        {
            sb.AppendLine();
        }

        sb.Append(' ', style - h1); // make an indention for the header (h1 - no indention)
    }
    else
    {
        e.Properties.SkipElement = e.Properties.Style != ParagraphStyle.Title; // skip paragraph if it's not a header or a title
    }
};

// Handle ElementText event to process a text
handler.ElementText += (sender, e) => sb.Append(e.Text);

// Extract a text with its structure
extractor.ExtractStructured(handler);

Console.WriteLine(sb.ToString());
```

### Improved memory consuming while extracting a text from ost (pst) files

#### Description

Improved the memory consuming while extracting a text from ost/pst files

#### Public API changes

No public API changes

#### Usage

**C#**

```csharp
var container = new PersonalStorageContainer(fileStream);
var enumerator = container.Entities.GetEnumerator();

while (enumerator.MoveNext())
{
	var entity = enumerator.Current;
	using (var entityStream = entity.OpenStream())
	{
		using (var extractor = new EmailTextExtractor(entityStream))
		{
			string content = extractor.ExtractAll();
			Console.WriteLine(entity[PersonalStorageContainer.EmailSubject]);
			Console.WriteLine(entity[PersonalStorageContainer.EmailSender]),
			Console.WriteLine(entity[PersonalStorageContainer.EmailReceiver]),
			Console.WriteLine(content);
		}
	}
}
```
