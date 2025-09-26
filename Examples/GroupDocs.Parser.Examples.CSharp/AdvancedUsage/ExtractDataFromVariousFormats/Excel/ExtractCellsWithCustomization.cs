// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract cells from Microsoft Office Excel spreadsheet with the customization.
    /// </summary>
    static class ExtractCellsWithCustomization
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExtractCellsWithCustomization : This example shows how to extract cells from Microsoft Office Excel spreadsheet with the customization.\n");


            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleXlsx))
            {
                // Check if worksheet cells extraction is supported
                if (!parser.Features.Worksheet)
                {
                    throw new NotSupportedException("Worksheet cells extraction isn't supported");
                }

                // Get the information about the first worksheet
                WorksheetInfo info = parser.GetWorksheetInfo(0);

                // Print the worksheet name
                Console.WriteLine(info.Name);
                Console.WriteLine();

                // Create the range that represents the first two rows
                WorksheetRange range = new WorksheetRange(
                    info.MinRowIndex,
                    Math.Min(info.MinRowIndex + 1, info.MaxRowIndex),
                    info.MinColumnIndex,
                    info.MaxColumnIndex);

                // Get the worksheet cells from the first two rows
                IEnumerable<WorksheetCell> cells = parser.GetWorksheetCells(0, new WorksheetOptions(range));

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