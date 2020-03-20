// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Pdf
{
    using System;
    using System.Linq;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to parse a form of the PDF document.
    /// </summary>
    static class ExtractDataFromPdfForms
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleCarWashPdf))
            {
                // Extract data from PDF document
                DocumentData data = parser.ParseForm();
                // Check if form extraction is supported
                if (data == null)
                {
                    Console.WriteLine("Form extraction isn't supported.");
                    return;
                }

                // Create the preliminary record object
                PreliminaryRecord rec = new PreliminaryRecord();
                rec.Name = GetFieldText(data, "Name");
                rec.Model = GetFieldText(data, "Model");
                rec.Time = GetFieldText(data, "Time");
                rec.Description = GetFieldText(data, "Description");

                // We can save the preliminary record object to the database, 
                // send it as the web response or just print it to the console
                Console.WriteLine("Preliminary record");
                Console.WriteLine("Name: {0}", rec.Name);
                Console.WriteLine("Model: {0}", rec.Model);
                Console.WriteLine("Time: {0}", rec.Time);
                Console.WriteLine("Description: {0}", rec.Description);
            }
        }

        private static string GetFieldText(DocumentData data, string fieldName)
        {
            // Get the field from data collection
            FieldData fieldData = data.GetFieldsByName(fieldName).FirstOrDefault();

            // Check if the field data is not null (a field with the fieldName is contained in data collection)
            // and check if the field data contains the text
            return fieldData != null && fieldData.PageArea is PageTextArea
                ? (fieldData.PageArea as PageTextArea).Text
                : null;
        }

        /// <summary>
        /// Simple POCO object to store the extracted data.
        /// </summary>
        public class PreliminaryRecord
        {
            public string Name { get; set; }

            public string Model { get; set; }

            public string Time { get; set; }

            public string Description { get; set; }
        }
    }
}
