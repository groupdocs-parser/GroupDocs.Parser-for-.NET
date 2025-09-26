// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SQLite;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;
    using static GroupDocs.Parser.Options.PreviewOptions;

    /// <summary>
    /// This example shows how to handle loading of external resources.
    /// </summary>
    static class HandleLoadingOfExternalResources
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # HandleLoadingOfExternalResources : This example shows how to handle loading of external resources.\n");


            // Create an instance of ParserSettings to pass External Resource Handler
            ParserSettings settings = new ParserSettings(new Handler());

            // Create an instance of Parser class to generate spreadsheet page previews
            using (Parser parser = new Parser(Constants.SampleHtmlWithImages, settings))
            {
                // Extract images from HTML document
                IEnumerable<PageImageArea> images = parser.GetImages();

                // Iterate over extracted images
                foreach (PageImageArea i in images)
                {
                    // Print the type of image
                    Console.WriteLine(i.FileType);
                }
            }
        }

        /// <summary>
        /// This class provides the ability to filter extracted images.
        /// </summary>
        private class Handler : ExternalResourceHandler
        {
            /// <summary>
            /// Called before any external resource loads. It allows to skip unnesesary file loading.
            /// </summary>
            public override void OnLoading(ExternalResourceLoadingArgs args)
            {
                // Check if the file name ends with installation.png
                if (!args.Uri.EndsWith("installation.png"))
                {
                    // Otherwise skip this file
                    args.Skipped = true;
                }

                base.OnLoading(args);
            }
        }
    }
}

