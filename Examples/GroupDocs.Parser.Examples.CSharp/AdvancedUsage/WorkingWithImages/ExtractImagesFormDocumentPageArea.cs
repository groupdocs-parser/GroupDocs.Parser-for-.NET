// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithImages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract only images from the upper-right corner.
    /// </summary>
    static class ExtractImagesFormDocumentPageArea
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleImagesPdf))
            {
                // Create the options which are used for images extraction
                PageAreaOptions options = new PageAreaOptions(new Rectangle(new Point(340, 150), new Size(300, 100)));
                // Extract images from the upper-left corner of a page:
                IEnumerable<PageImageArea> images = parser.GetImages(options);
                // Check if images extraction is supported
                if (images == null)
                {
                    Console.WriteLine("Page images extraction isn't supported");
                    return;
                }
                // Iterate over images
                foreach (PageImageArea image in images)
                {
                    // Print a page index, rectangle and image type:
                    Console.WriteLine(string.Format("Page: {0}, R: {1}, Type: {2}", image.Page.Index, image.Rectangle, image.FileType));
                }
            }
        }
    }
}
