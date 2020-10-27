---
id: groupdocs-parser-for-net-20-5-release-notes
url: parser/net/groupdocs-parser-for-net-20-5-release-notes
title: GroupDocs.Parser for .NET 20.5 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.5{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Added [RawPageCount](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) property to [IDocumentInfo](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/idocumentinfo) interface
*   Implemented the ability to create [Parser](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser) object with [DbConnection](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbconnection?view=netcore-3.1) and [EmailConnection](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/emailconnection) objects

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1507 | Add RawPageCount property to IDocumentInfo interface | Improvement |
| PARSERNET-1364 | Implement the ability to create Parser object with DbConnection | New feature |
| PARSERNET-1365 | Implement the ability to create Parser object with EmailConnection | New feature |

## Public API and Backward Incompatible Changes

### Add RawPageCount property to IDocumentInfo interface

#### Description

This feature improves API of raw text extraction from document page.

#### Public API changes

[IDocumentInfo](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/idocumentinfo) interface was updated with changes as follows:

*   Added [RawPageCount](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/idocumentinfo/properties/rawpagecount) property

#### Usage

The following example shows how to extract a raw text from a document page:

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Check if the document supports text extraction
    if (!parser.Features.Text)
    {
        Console.WriteLine("Document isn't supports text extraction.");
        return;
    }
    // Get the document info
    IDocumentInfo documentInfo = parser.GetDocumentInfo();
    // Check if the document has pages
    if (documentInfo == null || documentInfo.RawPageCount == 0)
    {
        Console.WriteLine("Document hasn't pages.");
        return;
    }
    // Iterate over pages
    for (int p = 0; p < documentInfo.RawPageCount; p++)
    {
        // Print a page number 
        Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.RawPageCount));
        // Extract a text into the reader
        using (TextReader reader = parser.GetText(p, new TextOptions(true)))
        {
            // Print a text from the document
            // We ignore null-checking as we have checked text extraction feature support earlier
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

### Implement the ability to create Parser object with DbConnection

#### Description

This feature allows to extract data from databases via ADO.NET.

#### Public API changes

[Parser](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser) class was updated with changes as follows:

*   Added [Parser(DbConnection)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/constructors/2) constructor
*   Added [Parser(DbConnection, ParserSettings)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/constructors/3) constructor

#### Usage

The following example shows how to extract data from Sqlite database:

```csharp
// Create DbConnection object
DbConnection connection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", filePath));
// Create an instance of Parser class to extract tables from the database
using (Parser parser = new Parser(connection))
{
    // Check if text extraction is supported
    if (!parser.Features.Text)
    {
        Console.WriteLine("Text extraction isn't supported.");
        return;
    }
    // Check if toc extraction is supported
    if (!parser.Features.Toc)
    {
        Console.WriteLine("Toc extraction isn't supported.");
        return;
    }
    // Get a list of tables
    IEnumerable<TocItem> toc = parser.GetToc();
    // Iterate over tables
    foreach (TocItem i in toc)
    {
        // Print the table name
        Console.WriteLine(i.Text);
        // Extract a table content as a text
        using (TextReader reader = parser.GetText(i.PageIndex.Value))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

### Implement the ability to create Parser object with EmailConnection

#### Description

This feature allows to extract data from email servers.

#### Public API changes

[Parser](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser) class was updated with changes as follows:

*   Added [Parser(EmailConnection)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/constructors/main) constructor
*   Added [Parser(EmailConnection, ParserSettings)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/constructors/1) constructor

#### Usage

The following example shows how to extract emails from Exchange Server:

```csharp
// Create the connection object for Exchange Web Services protocol 
EmailConnection connection = new EmailEwsConnection(
    "https://outlook.office365.com/ews/exchange.asmx",
    "email@server",
    "password");
 
// Create an instance of Parser class to extract emails from the remote server
using (Parser parser = new Parser(connection))
{
    // Check if container extraction is supported
    if (!parser.Features.Container)
    {
        Console.WriteLine("Container extraction isn't supported.");
        return;
    }
 
    // Extract email messages from the server
    IEnumerable<ContainerItem> emails = parser.GetContainer();
 
    // Iterate over attachments
    foreach (ContainerItem item in emails)
    {
        // Create an instance of Parser class for email message
        using (Parser emailParser = item.OpenParser())
        {
            // Extract the email text
            using (TextReader reader = emailParser.GetText())
            {
                // Print the email text
                Console.WriteLine(reader == null ? "Text extraction isn't supported." : reader.ReadToEnd());
            }
        }
    }
}
```
