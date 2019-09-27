// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal static class Constants
    {
        public const string LicensePath = "C://licenses//GroupDocs.Parser.Net.lic";
        public const string SamplesPath = "../../../Resources/SampleFiles";
        public const string OutputPath = "../../Output/";

        public static readonly string SampleDocx = GetFilePath("sample.docx");

        public static readonly string SampleHyperlinksDocx = GetFilePath("Hyperlinks.docx");

        public static readonly string SamplePdf = GetFilePath("sample.pdf");

        public static readonly string SampleImagesPdf = GetFilePath("images.pdf");

        public static readonly string SampleFormsPdf = GetFilePath("forms.pdf");

        public static readonly string SampleInvoicePdf = GetFilePath("invoice.pdf");

        public static readonly string SamplePassword = GetFilePath("samplePassword.pdf");

        public static readonly string SampleMd = GetFilePath("sample.md");

        public static readonly string SampleEpub = GetFilePath("sample.epub");

        public static readonly string SampleZip = GetFilePath("sample.zip");

        public static readonly string SampleText = GetFilePath("utf8.txt");

        public static readonly string SampleDatabase = GetFilePath("sqlite.db");

        public static readonly string SampleMsg = GetFilePath("The butterfly effect.msg");

        public static readonly string SampleOutlook = GetFilePath("sample.ost");

        public static readonly string SamplePdfPortfolio = GetFilePath("PortfolioWithFolder.pdf");             

        private static string GetFilePath(string fileName)
        {
            return Path.Combine(SamplesPath, fileName);
        }

        public static string GetOutputFilePath(string fileName)
        {
            string outputDirectory = Path.Combine(OutputPath, fileName);

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            return outputDirectory;
        }
    }
}
