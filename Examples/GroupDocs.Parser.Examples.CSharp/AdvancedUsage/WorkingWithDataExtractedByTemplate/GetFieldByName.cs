// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithDataExtractedByTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Templates;

    /// <summary>
    /// This example shows how to get field data by name.
    /// </summary>
    static class GetFieldByName
    {
        public static void Run()
        {
            // Define a "price" field
            TemplateField priceField = new TemplateField(
                new TemplateRegexPosition("\\$\\d+(.\\d+)?"),
                "Price");

            // Define a "email" field
            TemplateField emailField = new TemplateField(
                new TemplateRegexPosition("[a-z]+\\@[a-z]+.[a-z]+"),
                "Email");

            // Create a template
            Template template = new Template(new TemplateItem[] { priceField, emailField });

            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleInvoicePdf))
            {
                // Parse the document by the template
                DocumentData data = parser.ParseByTemplate(template);

                // Print prices
                Console.WriteLine("Prices:");
                foreach(FieldData field in data.GetFieldsByName("Price"))
                {
                    PageTextArea area = field.PageArea as PageTextArea;
                    Console.WriteLine(area == null ? "Not a template field" : area.Text);
                }

                // Print emails
                Console.WriteLine("Emails:");
                foreach (FieldData field in data.GetFieldsByName("Email"))
                {
                    // As we have defined only text fields in the template,
                    // we cast PageArea property value to PageTextArea
                    PageTextArea area = field.PageArea as PageTextArea;
                    Console.WriteLine(area == null ? "Not a template field" : area.Text);
                }
            }
        }
    }
}
