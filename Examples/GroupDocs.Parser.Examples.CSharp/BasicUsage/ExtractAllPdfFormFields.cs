// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage
{
    using System;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to read all available form fields from a PDF document.
    /// Form field values (e.g. AcroForm text boxes) are not returned by GetText -
    /// they have to be extracted with ParseForm.
    /// </summary>
    static class ExtractAllPdfFormFields
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # ExtractAllPdfFormFields : This example shows how to read all available form fields from a PDF document.\n");


            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleFormFieldsPdf))
            {
                // Extract data from the PDF form
                DocumentData data = parser.ParseForm();

                // Check if form extraction is supported
                if (data == null)
                {
                    Console.WriteLine("Form extraction isn't supported.");
                    return;
                }

                Console.WriteLine("Total form fields: {0}\n", data.Count);

                // Iterate over all the extracted form fields
                for (int i = 0; i < data.Count; i++)
                {
                    FieldData field = data[i];

                    // A field area can be a text area (text boxes, radio buttons, checkboxes, etc.)
                    PageTextArea area = field.PageArea as PageTextArea;

                    Console.WriteLine("{0}: {1}",
                        field.Name,
                        area == null ? "Not a text field" : area.Text);
                }
            }
        }
    }
}
