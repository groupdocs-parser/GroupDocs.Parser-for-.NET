﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
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
    /// This example shows how to define a template field with the linked field.
    /// </summary>
    static class WorkingWithTemplateLinkedPosition
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # WorkingWithTemplateLinkedPosition : This example shows how to define a template field with the linked field.\n");

           
            // Define a field with the regular expression
            TemplateField field = new TemplateField(
                new TemplateRegexPosition("Tax"),
                "Tax");

            TemplateField linkedField = new TemplateField(
                new TemplateLinkedPosition(
                    "Tax",
                    new Size(100, 20),
                    new TemplateLinkedPositionEdges(false, false, true, false)),
                "TaxValue");

            // Create a template
            Template template = new Template(new TemplateItem[] { field, linkedField });

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
