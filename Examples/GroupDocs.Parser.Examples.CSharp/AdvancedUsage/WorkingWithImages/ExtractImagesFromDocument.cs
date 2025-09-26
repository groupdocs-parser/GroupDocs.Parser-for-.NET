﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithImages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract all images from the whole document.
    /// </summary>
    static class ExtractImagesFromDocument
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExtractImagesFromDocument : This example shows how to extract all images from the whole document.\n");


            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleImagesPdf))
            {
                // Extract images
                IEnumerable<PageImageArea> images = parser.GetImages();
                // Check if images extraction is supported
                if (images == null)
                {
                    Console.WriteLine("Images extraction isn't supported");
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
