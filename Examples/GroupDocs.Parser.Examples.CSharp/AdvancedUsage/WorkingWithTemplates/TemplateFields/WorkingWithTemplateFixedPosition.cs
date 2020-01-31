// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates.TemplateFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Templates;

    /// <summary>
    /// This example shows how to define a template field with the fixed position.
    /// </summary>
    static class WorkingWithTemplateFixedPosition
    {
        public static void Run()
        {
            // Define a field with the fixed position
            TemplateField field = new TemplateField(
                new TemplateFixedPosition(new Rectangle(new Point(35, 135), new Size(100, 10))),
                "FromCompany");

            // Create a template
            Template template = new Template(new TemplateItem[] { field });

            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleInvoicePdf))
            {
                // Parse the document by the template
                DocumentData data = parser.ParseByTemplate(template);

                // Print all extracted data
                for (int i = 0; i < data.Count; i++)
                {
                    Console.Write(data[i].Name + ": ");
                    PageTextArea area = data[i].PageArea as PageTextArea;
                    Console.WriteLine(area == null ? "Not a template field" : area.Text);
                }
            }
        }
    }
}
