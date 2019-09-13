// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.TextAreas;
    using GroupDocs.Parser.Examples.CSharp.BasicUsage;
    using GroupDocs.Parser.Examples.CSharp.BasicUsage.ExtractContainersAndAttachments;
    using GroupDocs.Parser.Examples.CSharp.BasicUsage.ExtractImages;
    using GroupDocs.Parser.Examples.CSharp.BasicUsage.TextExtraction;
    using GroupDocs.Parser.Examples.CSharp.QuickStart;

    class RunExamples
    {
        static void Main()
        {
            Console.WriteLine("Open RunExamples.cs." + Environment.NewLine + "In Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            // NOTE: Please uncomment the example you want to try out

            #region Quick Start

            SetLicenseFromFile.Run();
            // SetLicenseFromStream.Run();
            // SetMeteredLicense.Run();
            // HelloWorld.Run();

            #endregion

            #region Basic Usage

            //GetSupportedFileFormats.Run();
            //GetFileInfo.Run();
            //GetSupportedFeatures.Run();

            //ExtractTableOfContents.Run();
            //ExtractMetadata.Run();

            //ParseDocumentByTemplate.Run();
            //ParseFormData.Run();

            #region Extract text

            //ExtractPlainText.Run();
            //ExtractPlainTextPage.Run();
            //ExtractRawText.Run();

            //ExtractHighlight.Run();

            //TextSearchByKeyword.Run();
            //TextSearchByRegex.Run();

            //ExtractFormattedText.Run();
            //ExtractFormattedTextPage.Run();

            #endregion

            #region Extract images

            //ExtractImage.Run();
            //ExtractImagePage.Run();
            //ExtractImageOptions.Run();
            //ImageSave.Run();

            #endregion

            #region Extract Containers and Attachments

            //ExtractAttachmentList.Run();
            //ExtractAttachmentContent.Run();

            #endregion

            #endregion

            #region Advanced Usage

            //ExtractTextStructure.Run();
            //EncodingDetection.Run();

            #region Loading

            //AdvancedUsage.Loading.LoadPasswordProtectedDocuments.Run();
            //AdvancedUsage.Loading.LoadDocumentsWithFileFormat.Run();

            #endregion

            #region Extract text areas

            //ExtractTextAreas.Run();
            //ExtractTextAreasOptions.Run();
            //ExtractTextAreasPage.Run();

            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
