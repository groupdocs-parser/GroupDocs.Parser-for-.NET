---
id: extract-data-from-databases
url: parser/net/extract-data-from-databases
title: Extract data from databases
weight: 100
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to extract data from databases via ADO.NET.

## Extract data with DbConnection object

To create an instance of Parser class to extract data from a database with DbConnection object the following constructors are used:

```csharp
Parser(DbConnection connection);
Parser(DbConnection connection, ParserSettings parserSettings)
```

The second constructor allows to use [ParserSettings](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/parsersettings) object to control the process; for example, by adding [logging functionality]({{< ref "parser/net/developer-guide/advanced-usage/logging.md" >}}).

Here are the steps to extract data from Sqlite database:

* Prepare [DbConnection](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbconnection?view=netcore-3.1) object;
* Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object with connection string;
* Call [Features.Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/text) property to check if text extraction is supported;
* Call [Features.Toc](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/toc) property to check if table of contents extraction is supported;
* Call [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method and obtain collection of tables;
* Iterate through the collection and get a text from tables.

The following example shows how to extract data from Sqlite database:

```csharp
// Create DbConnection object
DbConnection connection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", Constants.SampleDatabase));
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

## Extract data with connection string

{{< alert style="danger" >}}This functionality is supported only in .NET Framework version of GroupDocs.Parser for .NET{{< /alert >}}

To create an instance of [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) class to extract data from a database with a connection string the following constructor is used:

```csharp
Parser(string filePath, LoadOptions loadOptions);
```

The list of tables is represented as table of contents. The table extraction is processed by [GetText(int)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.parser/gettext/methods/2) method.

Here are the steps to extract data from Sqlite database:

*   Prepare connection string;
*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object with connection string;
*   Call [Features.Text](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/text) property to check if text extraction is supported;
*   Call [Features.Toc](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/toc) property to check if table of contents extraction is supported;
*   Call [GetToc](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/gettoc) method and obtain collection of tables;
*   Iterate through the collection and get a text from tables.

The following example shows how to extract data from Sqlite database:

```csharp
string connectionString = string.Format("Provider=System.Data.Sqlite;Data Source={0};Version=3;", "database.db");
// Create an instance of Parser class to extract tables from the database
// As filePath connection parameters are passed; LoadOptions is set to Database file format
using (Parser parser = new Parser(connectionString, new LoadOptions(FileFormat.Database)))
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

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).