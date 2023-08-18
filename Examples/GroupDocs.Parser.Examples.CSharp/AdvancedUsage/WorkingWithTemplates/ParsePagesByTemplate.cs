// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Templates;

    /// <summary>
    /// This example shows how to parse document pages by template.
    /// </summary>
    static class ParsePagesByTemplate
    {
        public static void Run()
        {
            // Define a barcode field
            TemplateBarcode barcode = new TemplateBarcode(
                new Rectangle(new Point(405, 55), new Size(100, 50)),
                "QR");

            // Create a template
            Template template = new Template(new TemplateItem[] { barcode });

            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdfWithBarcodes))
            {
                // Iterate over document pages
                foreach (DocumentPageData data in parser.ParsePagesByTemplate(template))
                {
                    // Print the page index
                    Console.WriteLine("Page: " + data.PageIndex);

                    // Print all extracted data
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.Write(data[i].Name + ": ");
                        PageBarcodeArea area = data[i].PageArea as PageBarcodeArea;
                        Console.WriteLine(area == null ? "Not a template barcode field" : area.Value);
                    }
                }
            }
        }
    }
}