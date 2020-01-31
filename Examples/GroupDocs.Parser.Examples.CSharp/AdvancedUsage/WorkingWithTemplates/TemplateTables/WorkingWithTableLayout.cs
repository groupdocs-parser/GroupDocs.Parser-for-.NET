// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates.TemplateTables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Templates;

    /// <summary>
    /// This example shows how to define a template table with the layout.
    /// </summary>
    static class WorkingWithTableLayout
    {
        public static void Run()
        {
            // Create a table template with the layout
            TemplateTable table = new TemplateTable(
                new TemplateTableLayout(new double[] { 30, 100, 320, 400, 480, 550 }, new double[] { 320, 345, 375 }),
                "Details",
                null);

            // Create a template
            Template template = new Template(new TemplateItem[] { table });

            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleInvoicePdf))
            {
                // Parse the document by the template
                DocumentData data = parser.ParseByTemplate(template);

                // Print all extracted data
                for (int i = 0; i < data.Count; i++)
                {
                    Console.Write(data[i].Name + ": ");
                    // Check if the field is a table
                    PageTableArea area = data[i].PageArea as PageTableArea;
                    if (area == null)
                    {
                        continue;
                    }

                    // Iterate via table rows
                    for (int row = 0; row < area.RowCount; row++)
                    {
                        // Iterate via table columns
                        for (int column = 0; column < area.ColumnCount; column++)
                        {
                            // Get the cell value
                            PageTextArea cellValue = area[row, column].PageArea as PageTextArea;

                            // Print the space between columns
                            if (column > 0)
                            {
                                Console.Write("\t");
                            }

                            // Print the cell value
                            Console.Write(cellValue == null ? "" : cellValue.Text);
                        }

                        // Print new line
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
