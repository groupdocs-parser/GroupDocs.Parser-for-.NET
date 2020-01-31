// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract only text areas with digits from the upper-left corner.
    /// </summary>
    static class ExtractTextAreasWithOptions
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleImagesPdf))
            {
                // Create the options which are used for text area extraction
                PageTextAreaOptions options = new PageTextAreaOptions("\\s[a-z]{2}\\s", new Rectangle(new Point(0, 0), new Size(300, 100)));

                // Extract text areas which contain only digits from the upper-left corner of a page:
                IEnumerable<PageTextArea> areas = parser.GetTextAreas(options);
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
