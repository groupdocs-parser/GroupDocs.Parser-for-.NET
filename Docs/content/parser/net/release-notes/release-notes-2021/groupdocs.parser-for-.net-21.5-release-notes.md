---
id: groupdocs-parser-for-net-21-5-release-notes
url: parser/net/groupdocs-parser-for-net-21-5-release-notes
title: GroupDocs.Parser for .NET 21.5 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 21.5{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1776 | Implement Text property for FieldData class | Improvement |
| PARSERNET-1804 | Implement data extraction from RAR archives | New Feature |
| PARSERNET-1805 | Implement data extraction from TAR archives | New Feature |
| PARSERNET-1806 | Implement data extraction from BZip2 compressed files | New Feature |
| PARSERNET-1807 | Implement data extraction from GZip compressed files | New Feature |
| PARSERNET-1780 | GetDocumentInfo().FileType.Extension returns wrong extension for RAR | Bug |

## Public API and Backward Incompatible Changes

### Implement Text property for FieldData class

#### Description

This improvement enhanced the work with text fields.

#### Public API changes

[GroupDocs.Parser.Data.FieldData](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/fielddata) public class was updated with changes as follows:

* Added [Text](https://apireference.groupdocs.com/parser/net/groupdocs.parser.data/fielddata/properties/text) property

#### Usage

The following example how to extract data from text fields:

```csharp
// Get the field data
FieldData field = data[i];
// Check if the field data contains a text
if(field.PageArea.Text != null)
{
    // Print the field text value
    Console.WriteLine(field.Text);
}
```

### Implement data extraction from TAR and RAR archives

#### Description

This feature allows to extract documents from TAR and RAR archives.

#### Public API changes

[GroupDocs.Parser.Options.FileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/filetype) public class was updated with changes as follows:

* Added ZIP and RAR readonly static fields.

#### Usage

The following example shows how to extract documents from the archive:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser(filePath))
{
    // Extract attachments from the container
    IEnumerable<ContainerItem> attachments = parser.GetContainer();
    // Check if container extraction is supported
    if(attachments == null)
    {
        Console.WriteLine("Container extraction isn't supported");
    }

    // Iterate over attachments
    foreach(ContainerItem item in attachments)
    {
        // Print an item name and size
        Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Size));
    }
}
```

### Implement data extraction from GZip and BZip2 archives

#### Description

This feature allows to extract documents from GZip and BZip2 archives.

#### Public API changes

[GroupDocs.Parser.Options.FileType](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/filetype) public class was updated with changes as follows:

* Added GZ and BZ2 readonly static fields.

#### Usage

Data extraction from GZip and BZip2 archives is performed transparently for a user. Parser object is created only for extracted file. For example, compressed TAR is extracted from TAR.GZ file and Parser object is created for TAR container.

The following example shows how to extract documents from the TAR.GZ archive:

```csharp
// Create an instance of Parser class
using(Parser parser = new Parser("file.tar.gz"))
{
    // Extract attachments from the container
    IEnumerable<ContainerItem> attachments = parser.GetContainer();
    // Check if container extraction is supported
    if(attachments == null)
    {
        Console.WriteLine("Container extraction isn't supported");
    }

    // Iterate over attachments
    foreach(ContainerItem item in attachments)
    {
        // Print an item name and size
        Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Size));
    }
}
```