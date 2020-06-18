// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTables
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;
    using GroupDocs.Parser.Templates;

    /// <summary>
    /// This example shows how to extract tables from the whole document.
    /// </summary>
    static class ExtractTablesFromDocument
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleInvoicePagesPdf))
            {
                // Check if the document supports table extraction
                if (!parser.Features.Tables)
                {
                    Console.WriteLine("Document isn't supports tables extraction.");
                    return;
                }

                // Create the layout of tables
                TemplateTableLayout layout = new TemplateTableLayout(
                    new double[] { 50, 95, 275, 415, 485, 545 },
                    new double[] { 325, 340, 365, 395 });

                // Create the options for table extraction
                PageTableAreaOptions options = new PageTableAreaOptions(layout);

                // Extract tables from the document
                IEnumerable<PageTableArea> tables = parser.GetTables(options);

                // Iterate over tables
                foreach (PageTableArea t in tables)
                {
                    // Iterate over rows
                    for (int row = 0; row < t.RowCount; row++)
                    {
                        // Iterate over columns
                        for (int column = 0; column < t.ColumnCount; column++)
                        {
                            // Get the table cell
                            PageTableAreaCell cell = t[row, column];
                            if (cell != null)
                            {
                                // Print the table cell text
                                Console.Write(cell.Text);
                                Console.Write(" | ");
                            }
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
