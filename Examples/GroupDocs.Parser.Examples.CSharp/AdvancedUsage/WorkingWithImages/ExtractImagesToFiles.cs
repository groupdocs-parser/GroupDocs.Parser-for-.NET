// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithImages
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to save extracted images to files.
    /// </summary>
    static class ExtractImagesToFiles
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleZip))
            {
                // Extract images from document
                IEnumerable<PageImageArea> images = parser.GetImages();

                // Check if images extraction is supported
                if (images == null)
                {
                    Console.WriteLine("Page images extraction isn't supported");
                    return;
                }

                // Create the options to save images in PNG format
                ImageOptions options = new ImageOptions(ImageFormat.Png);

                int imageNumber = 0;
                // Iterate over images
                foreach (PageImageArea image in images)
                {
                    // Save the image to the png file
                    image.Save(imageNumber.ToString() + ".png", options);

                    imageNumber++;
                }
            }
        }
    }
}
