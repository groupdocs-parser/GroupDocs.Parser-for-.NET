---
id: groupdocs-parser-for-net-18-9-release-notes
url: parser/net/groupdocs-parser-for-net-18-9-release-notes
title: GroupDocs.Parser for .NET 18.9 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.9.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Ability to extract a text from databases
*   Ability to extract data from PDF Forms

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-555 | Implement the ability to extract a text from databases | New feature |
| PARSERNET-975 | Implement the ability to extract data from the form fields of PDFs | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to extract a text from databases

#### Description

This feature allows extracting a text from databases.

#### Public API changes

*   Added **DbContainer** class
*   Added **DbTableReader** class

#### Usage

To extract a text from databases **DbContainer** class is used. **DbContainer** class implements **IContainer** interface. Each data table is represented by the entity. The content of the entity is CSV-presentation of data table. For more detailed text extraction **GetTableReader** method is used. Also, this method is faster and consumes less memory. **GetTableReader** method returns an instance of **DbTableReader** class.

**DbTableReader** class has the following members:

| Member | Description |
| --- | --- |
| Read() | Reads the next data row and returns a collection of row cells |
| ReadLine() | Reads the next data row and returns a string representation of comma-separated values |
| ColumnsFilter | Gets or sets a collection of columns names which are returned by Read and ReadLine methods; null if all table columns are returned |
| Columns | Gets a collection of table columns names |

Using DbContainer as a container:

**C#**

```csharp
// Create a container
using (var container = new DbContainer(new SQLiteConnection(connectionString)))
{
    // Iterate over entities 
    foreach (var entity in container.Entities)
    {
        // Print a table name
        System.Console.WriteLine(entity.Name);
        // Print a media type
        System.Console.WriteLine(entity.MediaType);
        // Create a stream reader for CSV document: OpenStream method converts a table to the CSV file and returns it as Stream
        using (var reader = new StreamReader(entity.OpenStream()))
        {
            // Read a line
            string line = reader.ReadLine();
            // Loop to the end of the file
            while (line != null)
            {
                // Print a line from the document
                System.Console.WriteLine(line);
                // Read the next line
                line = reader.ReadLine();
            }
        }
    }
}
```

### Ability to extract data from the form fields of PDFs

#### Description

This feature allows extracting data from PDF Forms.

#### Public API changes

*   Added **GetFormData** method to **PdfTextExtractor** class

#### Usage

**C#**

```csharp
// Create a text extractor
using (var extractor = new PdfTextExtractor(fileName))
{
    // Extract forms data
    var fields = extractor.GetFormData();
    // Iterate over fields
    foreach (var f in fields)
    {
        // Print field name and value
        System.Console.WriteLine(string.Format("{0}: {1}", f.Key, f.Value));
    }
}
```
