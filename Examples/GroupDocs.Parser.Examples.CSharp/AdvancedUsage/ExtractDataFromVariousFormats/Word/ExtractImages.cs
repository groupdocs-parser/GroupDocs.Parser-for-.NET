// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Word
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract images from Microsoft Office Word document.
    /// </summary>
    static class ExtractImages
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleWithImagesDocx))
            {
                // Extract images from document
                IEnumerable<PageImageArea> images = parser.GetImages();

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
