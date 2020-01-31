// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example how to extract all text areas from the whole document.
    /// </summary>
    static class ExtractTextAreas
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleImagesPdf))
            {
                // Extract text areas
                IEnumerable<PageTextArea> areas = parser.GetTextAreas();
                // Check if text areas extraction is supported
                if (areas == null)
                {
                    Console.WriteLine("Page text areas extraction isn't supported");
                    return;
                }

                // Iterate over page text areas
                foreach (PageTextArea a in areas)
                {
                    // Print a page index, rectangle and text area value:
                    Console.WriteLine(string.Format("Page: {0}, R: {1}, Text: {2}", a.Page.Index, a.Rectangle, a.Text));
                }
            }
        }
    }
}
