// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SQLite;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract data from Sqlite database.
    /// </summary>
    static class ExtractDataFromDatabasesWithDbConnection
    {
        public static void Run()
        {
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
        }
    }
}
