// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage.ExtractImages
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to save extracted images to files.
    /// </summary>
    static class ExtractImagesAndSaveThemToFiles
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

                int imageNumber = 0;
                // Iterate over images
                foreach (PageImageArea image in images)
                {
                    // Open the image stream
                    using (Stream imageStream = image.GetImageStream())
                    {
                        // Create the file to save image
                        using (Stream destStream = File.Create(imageNumber.ToString() + image.FileType.Extension))
                        {
                            byte[] buffer = new byte[4096];
                            int readed = 0;

                            do
                            {
                                // Read data from the image stream
                                readed = imageStream.Read(buffer, 0, buffer.Length);

                                if (readed > 0)
                                {
                                    // Write data to the file stream
                                    destStream.Write(buffer, 0, readed);
                                }
                            }
                            while (readed > 0);
                        }

                        imageNumber++;
                    }
                }
            }
        }
    }
}
