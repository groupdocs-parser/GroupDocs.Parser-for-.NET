// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithHyperlinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract hyperlinks from the document page area.
    /// </summary>
    static class ExtractHyperlinksFromDocumentPageArea
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.HyperlinksPdf))
            {
                // Check if the document supports hyperlink extraction
                if (!parser.Features.Hyperlinks)
                {
                    Console.WriteLine("Document isn't supports hyperlink extraction.");
                    return;
                }

                // Create the options which are used for hyperlink extraction
                PageAreaOptions options = new PageAreaOptions(new Rectangle(new Point(380, 90), new Size(150, 50)));

                // Extract hyperlinks from the document page area
                IEnumerable<PageHyperlinkArea> hyperlinks = parser.GetHyperlinks(options);

                // Iterate over hyperlinks
                foreach (PageHyperlinkArea h in hyperlinks)
                {
                    // Print the hyperlink text
                    Console.WriteLine(h.Text);
                    // Print the hyperlink URL
                    Console.WriteLine(h.Url);

                    Console.WriteLine();
                }
            }
        }
    }
}
