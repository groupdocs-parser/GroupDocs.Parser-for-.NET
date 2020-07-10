---
id: groupdocs-parser-for-net-17-04-release-notes
url: parser/net/groupdocs-parser-for-net-17-04-release-notes
title: GroupDocs.Parser for .NET 17.04 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.4.0{{< /alert >}}

## Major Features

There are the following features in this release:

*   Ability to extract a text with its structure.

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-341 | Implement the architecture to read a structured text | New feature |
| TEXTNET-342 | Implement the ability to read a structured text from spreadsheets | New feature |
| TEXTNET-343 | Implement the ability to read a structured text from text documents | New feature |
| TEXTNET-344 | Implement the ability to read a structured text from presentations | New feature |
| TEXTNET-345 | Implement the ability to read a structured text from emails | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.4.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement the architecture to read a structured text

This feature allows to extract a text with its structure.

**Public API Changes**  
Added **IStructuredExtractor** interface.  
Added **StructuredHandler** class.  
Added **XmlStructuredHandler** class.  
Added **ModelStructuredHandler** class.  
Added **ModelNode** class.  
Added **StructuredEventArgs<T>** class.  
Added **StructuredEventHandler<T>** delegate.  
Added **StructuredTextEventArgs** class.  
Added **StructuredTextEventHandler** delegate.  
Added **StructuredElementProperties** class.  
Added **DocumentProperties** class.  
Added **PageProperties** class.  
Added **SlideProperties** class.  
Added **ParagraphProperties** class.  
Added **HyperlinkProperties** class.  
Added **TextProperties** class.  
Added **TableProperties** class.  
Added **TableRowProperties** class.  
Added **TableCellProperties** class.  
Added **ListProperties** class.  
Added **ListItemProperties** class.  
Added **ListType** enumeration.  
Added **ParagraphStyle** enumeration.  
Added **StructuredElementType** enumeration.

**Extracting headers from a document:**

**C#**

```csharp
StringBuilder sb = new StringBuilder();
IStructuredExtractor extractor = new WordsTextExtractor(stream);
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

**Extracting hyperlinks from a document:**

**C#**

```csharp
List<string> hyperlinks = new List<string>();
StringBuilder sb = null;
string currentLink = null;
IStructuredExtractor extractor = new WordsTextExtractor(stream);
StructuredHandler handler = new StructuredHandler();

// Handle Hyperlink event to process a starting of a hyperlink
handler.Hyperlink += (sender, e) =>
{
    sb = new StringBuilder();
    currentLink = e.Properties.Link;
};

// Handle ElementClose event to process a closing of a hyperlink
handler.ElementClosed += (sender, e) =>
{
    StructuredHandler h = sender as StructuredHandler;
    if (h != null && h[0] is HyperlinkProperties) // closing of hyperlink
    {
        if (sb != null)
        {
            hyperlinks.Add(string.Format("{0} ({1})", sb.ToString(), currentLink));
        }
        sb = null;
        currentLink = null;
    }
};

// Handle ElementText event to process a text
handler.ElementText += (sender, e) =>
{
    if (sb != null) // if hyperlink is open
    {
        sb.Append(e.Text);
    }
};

// Extract a text with its structure
extractor.ExtractStructured(handler);

foreach(string hl in hyperlinks)
{
    Console.WriteLine(hl);
}
```

#### Implement the ability to read a structured text from spreadsheets

This feature allows to extract a text with its structure from spreadsheets.

**Public API changes**  
Added **ExtractStructured** method to **CellsTextExtractor** class.

**Extracting a sheet which name is Sheet2:**

**C#**

```csharp
StringBuilder sb = new StringBuilder();
IStructuredExtractor extractor = new CellsTextExtractor(stream);
StructuredHandler handler = new StructuredHandler();

// Handle Table event to process a table
handler.Table += (sender, e) =>
{
    e.Properties.SkipElement = e.Properties.Name != "Sheet2"; // process only the sheet which name is Sheet2
    if (!e.Properties.SkipElement)
    {
        if (sb.Length > 0)
        {
            sb.AppendLine();
        }

        sb.Append(e.Properties.Name);
    }
};

// Handle TableRow event to process a table row
handler.TableRow += (sender, e) =>
{
    sb.AppendLine();
};

// Handle TableCell event to process a table cell
handler.TableCell += (sender, e) =>
{
    if (e.Properties.Column > 0)
    {
        sb.Append(" ");
    }
};

// Handle ElementText event to process a text
handler.ElementText += (sender, e) =>
{
    sb.Append(e.Text);
};

// Extract a text with its structure
extractor.ExtractStructured(handler);
Console.WriteLine(sb.ToString());

```

#### Implement the ability to read a structured text from text documents

This feature allows to extract a text with its structure from text documents.

**Public API changes**  
Added **ExtractStructured** method to **WordsTextExtractor** class.

**Extracting headers from a document:**

**C#**

```csharp
StringBuilder sb = new StringBuilder();
IStructuredExtractor extractor = new WordsTextExtractor(stream);
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

#### Implement the ability to read a structured text from presentations

This feature allows to extract a text with its structure from slides.

**Public API changes**  
Added **ExtractStructured** method to **SlidesTextExtractor** class.

**Extracting top-level lists from a presentation:**

**C#**

```csharp
StringBuilder sb = new StringBuilder();
IStructuredExtractor extractor = new SlidesTextExtractor(stream);
StructuredHandler handler = new StructuredHandler();

bool isList = false;

// Handle Hyperlink event to process a starting of a list
handler.List += (sender, e) =>
{
    e.Properties.SkipElement = e.Properties.Depth > 0; // process only top-level lists
    if (!e.Properties.SkipElement)
    {
        isList = true;
    }
};

// Handle ElementClose event to process a closing of a list
handler.ElementClosed += (sender, e) =>
{
    StructuredHandler h = sender as StructuredHandler;
    if (h != null && h[0] is ListProperties)
    {
        isList = false;
    }
};

// Handle ElementText event to process a text
handler.ElementText += (sender, e) =>
{
    if (!isList)
    {
        return;
    }

    if (sb.Length > 0)
    {
        sb.AppendLine();
    }

    sb.Append(e.Text);
};

// Extract a text with its structure
extractor.ExtractStructured(handler);

Console.WriteLine(sb.ToString());

```

#### Implement the ability to read a structured text from emails

This feature allows to extract a text with its structure from emails.

**Public API changes**  
Added **ExtractStructured** method to **EmailTextExtractor** class.

**Extracting hyperlinks from an email:**

**C#**

```csharp
List<string> hyperlinks = new List<string>();
StringBuilder sb = null;
string currentLink = null;
IStructuredExtractor extractor = new EmailTextExtractor(stream);
StructuredHandler handler = new StructuredHandler();

// Handle Hyperlink event to process a starting of a hyperlink
handler.Hyperlink += (sender, e) =>
{
    sb = new StringBuilder();
    currentLink = e.Properties.Link;
};

// Handle ElementClose event to process a closing of a hyperlink
handler.ElementClosed += (sender, e) =>
{
    StructuredHandler h = sender as StructuredHandler;
    if (h != null && h[0] is HyperlinkProperties) // closing of hyperlink
    {
        if (sb != null)
        {
            hyperlinks.Add(string.Format("{0} ({1})", sb.ToString(), currentLink));
        }
        sb = null;
        currentLink = null;
    }
};

// Handle ElementText event to process a text
handler.ElementText += (sender, e) =>
{
    if (sb != null) // if hyperlink is open
    {
        sb.Append(e.Text);
    }
};

// Extract a text with its structure
extractor.ExtractStructured(handler);

foreach(string hl in hyperlinks)
{
    Console.WriteLine(hl);
}
```
