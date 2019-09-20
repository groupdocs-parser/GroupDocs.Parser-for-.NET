// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp
{
    using System;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.Loading;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithContainersAndAttachments;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithDataExtractedByTemplate;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithImages;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates.TemplateFields;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates.TemplateTables;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText.WorkingWithFormattedText;
    using GroupDocs.Parser.Examples.CSharp.BasicUsage;
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

            //ExtractContainersAndAttachments.Run();
            //ExtractFormattedText.Run();
            //ExtractImages.Run();
            //ExtractMetadata.Run();
            //ExtractTableOfContents.Run();
            //ExtractText.Run();
            //GetDocumentInfo.Run();
            //GetSupportedFeatures.Run();
            //GetSupportedFileFormats.Run();
            //ParseDocumentByTemplate.Run();

            #endregion

            #region Advanced Usage

            //ExtractDatabase.Run();
            //ExtractEmails.Run();

            #region Loading

            //PasswordProtectedDocuments.Run();
            //SpecifyFileFormat.Run();

            #endregion

            #region Working With Containers and Attachments

            //IterateThroughContainerItems.Run();
            //WorkWithEmailAttachments.Run();
            //WorkWithOutlookStorage.Run();
            //WorkWithPdfPortfolios.Run();
            //WorkWithZipArchives.Run();

            #endregion

            #region Working With Images

            //ExtractImagesFormDocumentPageArea.Run();
            //ExtractImagesFromDocument.Run();
            //ExtractImagesFromDocumentPage.Run();
            //ExtractImagesToFiles.Run();

            #endregion

            #region Working With Text

            //DetectEncoding.Run();
            //ExtractHighlight.Run();
            //ExtractTextAreas.Run();
            //ExtractTextAreasFromPage.Run();
            //ExtractTextAreasWithOptions.Run();
            //ExtractTextFromPageInAccurateMode.Run();
            //ExtractTextInRawMode.Run();
            //ExtractTextInAccurateMode.Run();
            //ExtractTextFromPageInRawMode.Run();
            //ExtractTextStructure.Run();
            //SearchTextByKeyword.Run();
            //SearchTextByRegex.Run();

            #region Working With Formatted Text

            //ExtractFormattedTextFromDocument.Run();
            //ExtractFormattedTextFromDocumentPage.Run();
            //Html.Run();
            //Markdown.Run();
            //PlainText.Run();

            #endregion

            #endregion

            #region Working With Templates

            #region Template Fields

            //WorkingWithTemplateFixedPosition.Run();
            //WorkingWithTemplateRegexPosition.Run();
            //WorkingWithTemplateLinkedPosition.Run();

            #endregion

            #region Template Tables

            //WorkingWithTableLayout.Run();
            //WorkingWithTableParameters.Run();

            #endregion

            #endregion

            #region Working With Data Extracted By Template

            //GetFieldByName.Run();
            //IterateThroughFields.Run();
            //WorkingWithTables.Run();

            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
