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
    /// This example shows how to generate spreadsheet page previews.
    /// </summary>
    static class GenerateSpreadsheetPagesPreview
    {
        public static void Run()
        {
            // Create an instance of Parser class to generate spreadsheet page previews
            using (Parser parser = new Parser(Constants.SampleXlsx))
            {
                PageRenderInfo renderInfo = null;

                // Create preview options
                PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create(GetOutputPath(renderInfo, pageNumber)));
                // Set delegate to obtain the render info
                previewOptions.PreviewPageRender = info => renderInfo = info;
                // Set PNG as an output image format
                previewOptions.PreviewFormat = PreviewFormats.PNG;
                // Set DPI for the output image
                previewOptions.Dpi = 72;

                // Generate previews
                parser.GeneratePreview(previewOptions);
            }
        }

        private static string GetOutputPath(PageRenderInfo renderInfo, int pageNumber)
        {
            // Set the output directory. If the render info is set, then sheets are rendered on its own directory
            string outputDirectory = renderInfo == null 
                ? Constants.OutputPath 
                : Path.Combine(Constants.OutputPath, $"preview_{renderInfo.PageNumber}");

            // Create the output directory if necessary
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Set the file name. If the render info is set, then tile name is {Row}x{Column}.png
            string fileName = renderInfo == null
                ? $"preview_{pageNumber}.png"
                : $"{renderInfo.GetRow(pageNumber)}x{renderInfo.GetColumn(pageNumber)}.png";

            return Path.Combine(outputDirectory, fileName);
        }
    }
}