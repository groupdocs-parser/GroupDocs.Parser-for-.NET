using GroupDocs.Text_for_.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            //If you have the product license, un-comment following function to apply the license 
            //Common.ApplyLicense();

            #region TextExtractors
            //Extract email attachments
            //DocumentTextExtractor.EmailsExtractor.ExtractEmailAttachments("The butterfly effect.msg");
            //DocumentTextExtractor.EmailsExtractor.ExtractTextFromEmailAttachmentsUsingContainer("The butterfly effect.msg");

            //Extract onenote text
            //DocumentTextExtractor.OneNoteDocument.ExtractOneNoteDocument("The butterfly effect.one");

            //Open password protected one note document
            //DocumentTextExtractor.OneNoteDocument.OpenPasswordProtectedOneNoteSection("password protected note.one");

            //Extract pdf text
            //DocumentTextExtractor.PdfDocument.ExtractPdfDocument("The butterfly effect.pdf");
            //DocumentTextExtractor.PdfDocument.ExtractTextFromPdfPortfolios("Portfolio.pdf");

            //Extract slides text
            //DocumentTextExtractor.PresentationDocument.ExtractPresentationDocument("The butterfly effect.pptx");

            //Extract the entire sheet
            //DocumentTextExtractor.SpreadsheetDocument.ExtractEntireSheet("The butterfly effect.xlsx");

            //Extract the sheet by the rows
            //DocumentTextExtractor.SpreadsheetDocument.ExtractSheetByRows("The butterfly effect.xlsx");

            //Extract the selected columns
            //DocumentTextExtractor.SpreadsheetDocument.ExtractSelectedColumns("The butterfly effect.xlsx");

            //Extract selected rows and columns
            //DocumentTextExtractor.SpreadsheetDocument.ExtractSelectedColumnsAndRows("The butterfly effect.xlsx"); 

            //Extract text from word page (formatted)
            //DocumentTextExtractor.TextDocument.ExtractEntireWordPage("The butterfly effect.docx");

            //Extract formatted/tabled text from word
            //DocumentTextExtractor.TextDocument.FormattingTable("The butterfly effect.docx");

            //Extract text with markdown text format, at the moment bullets are supported
            //DocumentTextExtractor.TextDocument.ExtractingWithMarkdown("The butterfly effect.docx");

            //Extract text with html text format
            //DocumentTextExtractor.TextDocument.HtmlTextFormating("The butterfly effect.docx");

            //Extract a line of characters from epub document
            //DocumentTextExtractor.Epub.ExtractALine("sample.epub");

            //Extract all characters from epub document
            //DocumentTextExtractor.Epub.ExtractAllCharacters("sample.epub");

            //Search text in an epub file using regex
            //DocumentTextExtractor.Epub.SearchTextUsingRegex("sample.epub");

            //Search text in an epub document
            //DocumentTextExtractor.Epub.SearchText("sample.epub");

            //Extract highlight in epub file
            //DocumentTextExtractor.Epub.ExtractHighlight("Epub_file_with_highlighted_text.epub");

            //Detect epub media type
            //DocumentTextExtractor.Epub.DetectEpubMediaType("sample.epub");

            //Extract text from fb2 file(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.ExtractWholeText("sample.fb2");

            //Extract text by line from fb2 file(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.ExtractTextByLine("sample.fb2");

            //Extract highlight in fb2 file(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.ExtractHighlights("fb2_file_with_highlighted_text.fb2");

            //Search text with regular expresion(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.SearchTextWithRegex("sample.fb2");

            //Search text in fb2 files(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.SearchText("sample.fb2");

            //Detect fb2 media type(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.DetectMediaType("sample.fb2");

            //Extract Formatted text from fb2 files(feature supported by version 17.06 or greater)
            //DocumentTextExtractor.Fb2.ExtractFormattedText("sample.fb2");

            //Extract Text from DOT files(feature supported by version 17.07 or greater)
            //DocumentTextExtractor.Dot.ExtractText("Complex.dot");

            //Extract a line of Text from CHM files(feature supported by version 17.8.0 or greater)
            //DocumentTextExtractor.Chm.ExtractALine("sample.chm");

            //Extract all characters from CHM files(feature supported by version 17.8.0 or greater)
            //DocumentTextExtractor.Chm.ExtractAllCharacters("sample.chm");

            //Detect media type of CHM files(feature supported by version 17.9.0 or greater)
            //DocumentTextExtractor.Chm.DetectChmMediaType("sample.chm");

            //Extract single line as raw text from Markdown document
            //DocumentTextExtractor.MarkdownDocument.ExtractSingleLineAsRawText("sample.md");

            //Extract all characters as raw text from Markdown document
            //DocumentTextExtractor.MarkdownDocument.ExtractAllCharactersAsRawText("sample.md");

            //Extract single line as formatted text from Markdown document
            //DocumentTextExtractor.MarkdownDocument.ExtractSingleLineAsFormattedText("sample.md");

            //Extract all characters as raw text from Markdown document
            //DocumentTextExtractor.MarkdownDocument.ExtractAllCharactersAsFormattedText("sample.md");

            //Extract formatted text using document formatter from Markdown document
            //DocumentTextExtractor.MarkdownDocument.ExtractFormattedTextUsingDocumentFormatter("sample.md");

            //Extract structured text from Markdown document
            //DocumentTextExtractor.MarkdownDocument.ExtractStructuredText("sample.md");
             
            #endregion

            #region MetadataExtractors
            //Extract metadata from cells
            //MetadataExtractor.CellsMetadata.ExtractMetadataFromCells("The butterfly effect.xlsx");

            //Extract metadata from slides
            //MetadataExtractor.SlidesMetadata.ExtractMetadataFromSlides("The butterfly effect.pptx");

            //Extract metadata from words
            //MetadataExtractor.WordsMetaData.ExtractMetadataFromWords("The butterfly effect.docx");

            //Extract metadata from pdf documents
            //MetadataExtractor.PdfMetaData.ExtractMetadataFromPdf("The butterfly effect.pdf");

            //Extract metadata from emails
            //MetadataExtractor.EmailMetaData.ExtractMetadataFromEmails("The butterfly effect.msg");

            //Extract metadata of any supported file formatted document using extractor factory
            //MetadataExtractor.UsingExtractorFactory("The butterfly effect.pptx");

            //Extract metadata from an epub file
            //MetadataExtractor.EpubMetaData.ExtractMetadata("sample.epub");

            //Extract Metadata Using Complex Metadata Extractor
            //MetadataExtractor.EpubMetaData.ExtractMetadataUsingComplexMetadataExtractor("sample.epub");

            //Show usage of extractor class
            //MetadataExtractor.ExtractClassUsage("The butterfly effect.docx");

            //Extract metadata from fb2 files
            //MetadataExtractor.Fb2Metadata.ExtractMetadata("sample.fb2");
            #endregion

            #region ContainerExtractor
            //Extracting from OST
            //ContainerExtractor.ExtractFromOstContainer("sample.ost");

            //Enumerating all entities 
            //ContainerExtractor.EnumeratingAllEntities();

            //Enumerate all files in archive folder
            //ContainerExtractor.EnumerateAllArchivedFiles("zipcontainer.zip");

            //Read concrete file in a zip archive
            //ContainerExtractor.ReadConcreteFile("zipcontainer.zip");

            //Detect Zip Media Type
            //ContainerExtractor.DetectZipMediaType("zipcontainer.zip");

            //Retrieve emails using Entity property(feature is supported in version 17.9.0)
            //ContainerExtractor.RetrieveEmailsUsingEntity();

            //Retrieve an email using OpenEntityStream method(feature is supported in version 17.9.0)
            //ContainerExtractor.RetrieveEmailUsingOpenEntityStream();

            //Retrieve emails from POP3 server using Entity property(feature is supported in version 17.10)
            //ContainerExtractor.RetrieveEmailsUsingEntityPOP3();

            //Retrieve an email using OpenEntityStream method POP3(feature is supported in version 17.10)
            //ContainerExtractor.RetrieveEmailUsingOpenEntityStreamPOP3();

            //Retrieve emails from IMAP server using Entity property(feature is supported in version 17.10)
            //ContainerExtractor.RetrieveEmailsUsingEntityIMAP();

            //Retrieve an email using OpenEntityStream method IMAP(feature is supported in version 17.10)
            //ContainerExtractor.RetrieveEmailUsingOpenEntityStreamIMAP();
            #endregion

            #region Structured Text Extraction
            //Extract hyperlinks from document(feature supported by version 17.04 or greater)
            //DocumentTextExtractor.TextDocument.ExtractHyperlinksFromDocument("The butterfly effect.docx");

            //Extract structured text from a spread sheet(feature supported by version 17.04 or greater)
            //DocumentTextExtractor.SpreadsheetDocument.ExtractStructuredText("The butterfly effect.xlsx");

            //Extract top-level lists from presentation document(feature supported by version 17.04 or greater)
            //DocumentTextExtractor.PresentationDocument.ExtractTopLevelLists("The butterfly effect.pptx");

            //Extract headers from document(feature supported by version 17.04 or greater)
            //DocumentTextExtractor.TextDocument.ExtractHeadersFromDocument("The butterfly effect.docx");

            //Extract hyperlinks from emails(feature supported by version 17.04 or greater)
            //DocumentTextExtractor.EmailsExtractor.ExtractEmailHyperlinks("The butterfly effect.msg");

            //Extract formatted text from Epub files(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Epub.ExtractFormattedText("sample.epub");

            //Extract section title from Epub files(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Epub.ExtractSectionTitle("sample.epub");

            //Extract section title from fb2 files(feature supported by version 17.05 or greater)
            //DocumentTextExtractor.Fb2.ExtractSectionTitle("sample.fb2");
            #endregion

            #region OtherOperations
            //Create a concrete extractor
            //DocumentTextExtractor.SpreadsheetDocument.ConcreteExtractor("The butterfly effect.xlsx");

            //Extract all
            //OtherOperations.ExtractAllFromCells("The butterfly effect.xlsx");

            //Pass media type and encoding to the created extractor
            //DocumentTextExtractor.PassEncodingToCreatedExtractor("The butterfly effect.xlsx");

            //Extracting Password protected documents
            //DocumentTextExtractor.PasswordProtectedDocumentExtractor("Password protected document.docx");

            //Create a container from a file or stream
            //DocumentTextExtractor.CreatingContainerUsingExtractorFactory("The butterfly effect.xlsx");

            //Extract highlights  from documents
            //DocumentTextExtractor.ExtractHighlight("doc with highlighted text.docx");
            //DocumentTextExtractor.ExtractHighlightWithLimitedWordsCount("doc with highlighted text.docx",5);
            //DocumentTextExtractor.ExtractHighlightTillStartOrEndOfLine("doc with highlighted text.docx");

            //Search text in a document
            //DocumentTextExtractor.SearchTextInDocuments("The butterfly effect.docx");

            //Search whole word in documents
            //DocumentTextExtractor.SearchWholeWord("The butterfly effect.docx");   (ask)

            //Use all highlight extraction modes with search functionality
            //DocumentTextExtractor.UseExtractionModesWithSearch("doc with highlighted text.docx"); check

            //Extract formatted highlights from word document
            //DocumentTextExtractor.ExtractFormattedHighlights("doc with highlighted text.docx");

            //Implement IPageExtractor interface
            //DocumentTextExtractor.ImplementIpageExtractorInterface("The butterfly effect.docx");
            #endregion

            #region Tools
            //Detect encoding by BOM
            //Tools.EncodingDetection.ExtractEncodingByBOM("Encoding detection.txt");

            //Detect encoding by BOM and the content (if BOM is not presented)
            //Tools.EncodingDetection.ExtractEncodingByContentAndBOM("Encoding detection.txt");

            //Implement INotificationReceiver for extractors and does amual exception handling, to test the notification provide an invalid file name or something that can throw an exception so that a message can be logged
            //Tools.logger.LoggerWithManualExceptionHandling("The butterfly effect.xlsx");

            //Implement INotificationReceiver for extractors. To test the notification provide an invalid file name or something that can throw an exception so that a message can be logged
            //Tools.logger.LoggerWithManualExceptionHandling("The butterfly effect.xlsx");
            #endregion

            #region BusinessCases

            //count the statistic of word's occurrences in the document
            //WordStatistic.FindMaxWordLength("The butterfly effect.xlsx", "The butterfly effect.pptx");
            // view the content of the file in Console
            //ExtractText.ViewContentInConsole("The butterfly effect.xlsx");

            #endregion
            Console.ReadKey();
        }
    }
}
