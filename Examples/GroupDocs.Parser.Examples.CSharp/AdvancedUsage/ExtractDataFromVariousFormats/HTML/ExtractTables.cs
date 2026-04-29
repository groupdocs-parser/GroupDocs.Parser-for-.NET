// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.HTML
{
    using GroupDocs.Parser.Data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This example shows how to extract tables from HTML document.
    /// </summary>
    static class ExtractTables
    {
        private const int CellLength = 18;

        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExtractTables : This example shows how to extract tables from HTML document.\n");

            // Create an instance of the Parser class
            using (Parser parser = new Parser(Constants.TablesHtml))
            {
                // Extract tables
                IEnumerable<PageTableArea> tables = parser.GetTables();
                foreach (PageTableArea table in tables)
                {
                    Console.WriteLine("Found table:");
                    Console.WriteLine("\tRows: " + table.RowCount);
                    Console.WriteLine("\tColumns: " + table.ColumnCount);
                    for (int i = 0; i < table.RowCount; i++)
                    {
                        PrintSeparator(table.ColumnCount);
                        Console.Write(" | ");
                        for (int j = 0; j < table.ColumnCount; j++)
                        {
                            PageTableAreaCell cell = table[i, j];
                            if (cell == null)
                            {
                                Console.Write("".PadRight(CellLength));
                                continue;
                            }
                            string cellText = GetCellText(cell);
                            var t = cellText.PadRight(CellLength);
                            Console.Write(t);
                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    PrintSeparator(table.ColumnCount);
                }
            }
        }

        private static void PrintSeparator(int columnCount)
        {
            string separator = new string('-', columnCount * (CellLength + 3) + 1);
            Console.WriteLine(" " + separator + " ");
        }

        private static string GetCellText(PageTableAreaCell cell)
        {
            var text = cell.Text
                ?.Replace("\n\r", " ")
                ?.Replace("\r\n", " ")
                ?.Replace('\n', ' ')
                ?.Replace('\r', ' ')
                ?.Replace('\a', ' ')
                ?.Replace('\u00A0', ' ')
                ?.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Length > CellLength)
                {
                    return text.Substring(0, CellLength - 3) + "...";
                }
                else
                {
                    return text;
                }
            }

            return string.Empty;
        }
    }
}
