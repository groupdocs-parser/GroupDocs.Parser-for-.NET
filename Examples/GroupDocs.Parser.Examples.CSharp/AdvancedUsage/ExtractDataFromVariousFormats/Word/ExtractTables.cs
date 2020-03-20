// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Word
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract tables from Microsoft Office Word document.
    /// </summary>
    static class ExtractTables
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleDocx))
            {
                // Get the reader object for the document XML representation
                using (XmlReader reader = parser.GetStructure())
                {
                    // Iterate over the document
                    while (reader.Read())
                    {
                        // Check if this is the start of the table
                        if (reader.IsStartElement() && reader.Name == "table")
                        {
                            // Process the table
                            ProcessTable(reader);
                        }
                    }
                }
            }
        }

        private static void ProcessTable(XmlReader reader)
        {
            Console.WriteLine("table");
            // Create an instance of StringBuilder to store the cell value
            StringBuilder value = new StringBuilder();
            // Iterate over the table
            while (reader.Read())
            {
                // Check if the current tag is the end of the table
                bool isTableEnd = !reader.IsStartElement() && reader.Name == "table";
                // Check if the current tag is the start of the row or the cell
                bool isRowOrCellStart = reader.IsStartElement() && (reader.Name == "tr" || reader.Name == "td");
                // Print the cell value if this is the end of the table or the start of the row or the cell
                if ((isTableEnd || isRowOrCellStart) && value.Length > 0)
                {
                    Console.Write("  ");
                    Console.WriteLine(value.ToString());
                    value = new StringBuilder();
                }
                // If this is the end of the table - return to the main function
                if (isTableEnd)
                {
                    return;
                }
                // If this is the start of the row or the cell - print the tag name
                if (isRowOrCellStart)
                {
                    Console.WriteLine(reader.Name);
                    continue;
                }
                // If this code line is reached then this is the value of the cell
                value.Append(reader.Value);
            }
        }
    }
}
