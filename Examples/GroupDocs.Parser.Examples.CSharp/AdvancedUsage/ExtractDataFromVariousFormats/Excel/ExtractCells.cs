// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract cells from Microsoft Office Excel spreadsheet.
    /// </summary>
    static class ExtractCells
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleXlsx))
            {
                // Check if worksheet cells extraction is supported
                if (!parser.Features.Worksheet)
                {
                    throw new NotSupportedException("Worksheet cells extraction isn't supported");
                }

                // Get the information about worksheets
                IEnumerable<WorksheetInfo> info = parser.GetWorksheetInfo();
               
                // Iterate over worksheet information
                foreach(WorksheetInfo i in info)
                {
                    // Print the worksheet name
                    Console.WriteLine(i.Name);
                    Console.WriteLine();

                    // Get the worksheet cells
                    IEnumerable<WorksheetCell> cells = parser.GetWorksheetCells(i.Index);

                    // Iterate over cells
                    foreach (WorksheetCell c in cells)
                    {
                        // Print the cell information and text value
                        Console.WriteLine($"Row: {c.RowIndex} Column: {c.ColumnIndex} RowSpan: {c.RowSpan} ColumnSpan: {c.ColumnSpan}");
                        Console.WriteLine(c.Text);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}