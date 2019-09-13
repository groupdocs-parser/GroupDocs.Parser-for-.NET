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
    using GroupDocs.Parser.Examples.CSharp.BasicUsage.ExtractText;
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
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();
            //HelloWorld.Run();

            #endregion

            #region Basic Usage

            //GetSupportedFileFormats.Run();
            //GetDocumentInfo.Run();
            //GetSupportedFeatures.Run();

            //ExtractTableOfContents.Run();
            //ExtractMetadata.Run();

            //ParseDocumentByTemplate.Run();
            //ParseFormData.Run();

            #region Extract text

            //ExtractPlainText.Run();
            //ExtractPlainTextFromPage.Run();
            //ExtractPlainTextWithTextOptions.Run();

            //ExtractHighlight.Run();

            //TextSearchByKeyword.Run();
            //TextSearchByRegex.Run();

            //ExtractFormattedText.Run();
            //ExtractFormattedTextFromPage.Run();

            #endregion

            #region Extract images

            //ExtractImages.Run();
            //ExtractImagesFromPage.Run();
            //ExtractImagesWithOptions.Run();
            //ExtractImagesAndSaveThemToFiles.Run();

            #endregion

            #region Extract Containers and Attachments

            //ExtractAttachmentList.Run();
            //ExtractAttachmentContent.Run();

            #endregion

            #endregion

            #region Advanced Usage

            ExtractDatabase.Run();
            //ExtractEmails.Run();
            //ExtractTextStructure.Run();
            //DetectEncoding.Run();

            #region Loading

            //AdvancedUsage.Loading.PasswordProtectedDocuments.Run();
            //AdvancedUsage.Loading.SpecifyFileFormat.Run();

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
