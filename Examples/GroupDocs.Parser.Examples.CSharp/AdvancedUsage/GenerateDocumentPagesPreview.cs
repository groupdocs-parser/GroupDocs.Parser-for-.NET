// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
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
    /// This example shows how to generate document page preview.
    /// </summary>
    static class GenerateDocumentPagesPreview
    {
        public static void Run()
        {
            // Create an instance of Parser class to generate document page previews
            using (Parser parser = new Parser(Constants.SamplePdfWithToc))
            {
                // Create preview options
                PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create(GetOutputPath($"preview_{pageNumber}.png")));
                // Set PNG as an output image format
                previewOptions.PreviewFormat = PreviewFormats.PNG;
                // Set DPI for the output image
                previewOptions.Dpi = 72;

                // Generate previews
                parser.GeneratePreview(previewOptions);
            }            
        }

        private static string GetOutputPath(string fileName)
        {
            // Create the output directory if necessary
            if (!Directory.Exists(Constants.OutputPath))
            {
                Directory.CreateDirectory(Constants.OutputPath);
            }

            return Path.Combine(Constants.OutputPath, fileName);
        }
    }
}
