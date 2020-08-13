// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp
{
    using System;
    using System.Data.SQLite;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.Loading;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithDataExtractedByTemplate;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithHyperlinks;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithImages;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTables;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates.TemplateFields;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithTemplates.TemplateTables;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText.WorkingWithFormattedText;
    using GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithZipArchivesAndAttachments;
    using GroupDocs.Parser.Examples.CSharp.BasicUsage;
    using GroupDocs.Parser.Examples.CSharp.QuickStart;

    class RunExamples
    {
        static void Main()
        {
            Console.WriteLine("Open RunExamples.cs." + Environment.NewLine + "In Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            // NOTE: Please uncomment the example you want to try out

            #region Quick start

            SetLicenseFromFile.Run();
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();
            //HelloWorld.Run();

            #endregion

            #region Basic usage

            //ExtractDataFromAttachmentsAndZipArchives.Run();
            //ExtractFormattedTextFromDocuments.Run();
            //ExtractImages.Run();
            //ExtractImagesFromDocuments.Run();
            //ExtractTableOfContents.Run();
            //ExtractTextFromDocuments.Run();
            //GetDocumentInfo.Run();
            //GetSupportedFeatures.Run();
            //GetSupportedFileFormats.Run();
            //ParseDataFromDocuments.Run();

            #endregion

            #region Advanced usage

            //Logging.Run();
            //ExtractDataFromDatabasesWithDbConnection.Run();
            //GenerateDocumentPagesPreview.Run();
            //GenerateSpreadsheetPagesPreview.Run();

            #region Loading

            //PasswordProtectedDocuments.Run();
            //LoadingSpecificFileFormats.Run();
            //LoadDocumentFromStream.Run();
            //LoadDocumentFromLocalDisk.Run();

            #endregion

            #region Working with Zip archives and attachments

            //IterateThroughContainerItems.Run();
            //DetectFileType.Run();

            #endregion

            #region Working with images

            //ExtractImagesFormDocumentPageArea.Run();
            //ExtractImagesFromDocument.Run();
            //ExtractImagesFromDocumentPage.Run();
            //ExtractImagesToFiles.Run();

            #endregion

            #region Working with tables

            //ExtractTablesFromDocument.Run();
            //ExtractTablesFromDocumentPage.Run();

            #endregion

            #region Working with hyperlinks

            //ExtractHyperlinksFromDocument.Run();
            //ExtractHyperlinksFromDocumentPage.Run();
            //ExtractHyperlinksFromDocumentPageArea.Run();

            #endregion

            #region Working with text

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
            //SearchTextWithHighlights.Run();
            //SearchTextByPages.Run();
            //ExtractTextByTocItem.Run();

            #region Working With Formatted Text

            //ExtractFormattedTextFromDocument.Run();
            //ExtractFormattedTextFromDocumentPage.Run();
            //Html.Run();
            //Markdown.Run();
            //PlainText.Run();

            #endregion

            #endregion

            #region Working with templates

            #region Template fields

            //WorkingWithTemplateFixedPosition.Run();
            //WorkingWithTemplateRegexPosition.Run();
            //WorkingWithTemplateLinkedPosition.Run();

            #endregion

            #region Template tables

            //WorkingWithTableLayout.Run();
            //WorkingWithTableParameters.Run();

            #endregion

            #endregion

            #region Working with data extracted by template

            //GetFieldByName.Run();
            //IterateThroughFields.Run();
            //WorkingWithTables.Run();

            #endregion

            #region Extract data from various formats

            #region Word

            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractHyperlinks.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractImages.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractMetadata.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractTableOfContents.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractTables.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractTextAsHtml.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.ExtractTextFromPage.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Word.SearchTextByRegularExpression.Run();

            #endregion

            #region Excel

            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.ExtractImages.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.ExtractMetadata.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.ExtractTextAsHtml.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.ExtractTextFromSheet.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.ExtractTextFromSheetInRawMode.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Excel.SearchTextByRegularExpression.Run();

            #endregion

            #region PowerPoint

            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.ExtractImages.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.ExtractMetadata.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.ExtractTextAsHtml.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.ExtractTextFromSlide.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.ExtractTextFromSlideInRawMode.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint.SearchTextByRegularExpression.Run();

            #endregion

            #region PDF

            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractDataFromPdfForms.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractImages.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractMetadata.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractTextFromPage.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractTextFromPageInRawMode.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.SearchTextByRegularExpression.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ExtractAttachmentsFromPdfPortfolios.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Pdf.ParseDataFromDocuments.Run();

            #endregion

            #region Email

            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractEmailsFromOutlookStorage.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractAttachmentsFromEmails.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractEmailsFromRemoveServer.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractMetadata.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractTextAsHtml.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.ExtractImages.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.Email.SearchTextByRegularExpression.Run();

            #endregion

            #region EPUB

            //AdvancedUsage.ExtractDataFromVariousFormats.EPUB.ExtractTableOfContents.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.EPUB.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.EPUB.ExtractTextAsHtml.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.EPUB.ExtractTextFromPage.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.EPUB.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.EPUB.SearchTextByRegularExpression.Run();

            #endregion

            #region Zip

            //AdvancedUsage.ExtractDataFromVariousFormats.Zip.ExtractTextFromZipArchiveFiles.Run();

            #endregion

            #region HTML

            //AdvancedUsage.ExtractDataFromVariousFormats.HTML.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.HTML.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.HTML.SearchTextByRegularExpression.Run();

            #endregion

            #region OneNote

            //AdvancedUsage.ExtractDataFromVariousFormats.OneNote.ExtractText.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.OneNote.SearchTextByKeyword.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.OneNote.SearchTextByRegularExpression.Run();
            //AdvancedUsage.ExtractDataFromVariousFormats.OneNote.ExtractTextFromPage.Run();

            #endregion

            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
