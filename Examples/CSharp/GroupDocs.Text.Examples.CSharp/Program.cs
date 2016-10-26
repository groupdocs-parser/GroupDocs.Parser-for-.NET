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
            //Un-comment to apply license 
            Common.ApplyLicense();

            #region TextExtractors

            //Extracting email attachments
            DocumentTextExtractor.EmailsExtractor.ExtractEmailAttachments("The butterfly effect.msg");

            //Extracting onenote text
            //DocumentTextExtractor.OneNoteDocument.ExtractOneNoteDocument("The butterfly effect.one");

            //Extracting pdf text
            //DocumentTextExtractor.PdfDocument.ExtractPdfDocument("The butterfly effect.pdf");

            //Extracting slides text
            //DocumentTextExtractor.PresentationDocument.ExtractPresentationDocument("The butterfly effect.pptx");

            //Extracting the entire sheet
            //DocumentTextExtractor.SpreadsheetDocument.ExtractEntireSheet("The butterfly effect.xlsx");
            //Extracting the sheet by the rows
            //DocumentTextExtractor.SpreadsheetDocument.ExtractSheetByRows("The butterfly effect.xlsx");
            //Extracting the selected columns
            //DocumentTextExtractor.SpreadsheetDocument.ExtractSelectedColumns("The butterfly effect.xlsx");
            //Extracting selected rows and columns
            //DocumentTextExtractor.SpreadsheetDocument.ExtractSelectedColumnsAndRows("The butterfly effect.xlsx"); 

            //Extracting text from word page (formatted)
            //DocumentTextExtractor.TextDocument.ExtractEntireWordPage("The butterfly effect.docx");
            //Extracting formatted/tabled text from word
            //DocumentTextExtractor.TextDocument.FormattingTable("The butterfly effect.docx");
            //Extracting text with markdown text format, at the moment bullets are supported
            //DocumentTextExtractor.TextDocument.ExtractingWithMarkdown("The butterfly effect.docx");
            //Extracting text with html text format
            //DocumentTextExtractor.TextDocument.HtmlTextFormating("The butterfly effect.docx");
            #endregion

            #region MetadataExtractors
            //Extracting metadata from cells
            //MetaDataExtractor.CellsMetadata.ExtractMetadataFromCells("The butterfly effect.xlsx");
            //Extracting metadata from slides
            //MetaDataExtractor.SlidesMetadata.ExtractMetadataFromSlides("The butterfly effect.pptx");
            //Extracting metadata from words
            //MetaDataExtractor.WordsMetaData.ExtractMetadataFromWords("The butterfly effect.docx");
            //Extracting metadata from pdf documents
            //MetaDataExtractor.PdfMetaData.ExtractMetadataFromPdf("The butterfly effect.pdf");
            //Extracting metadata from emails
            //MetaDataExtractor.EmailMetaData.ExtractMetadataFromEmails("The butterfly effect.msg");
            //Extract metadata of any supported file formatted document using extractor factory
            //MetaDataExtractor.UsingExtractorFactory("The butterfly effect.pptx");
            #endregion

            #region ContainerExtractor
            //Extracting from OST
            //ContainerExtractor.ExtractFromOstContainer();
            //Enumerating all entities 
            //ContainerExtractor.EnumeratingAllEntities();
            #endregion

            #region OtherOperations
            //Creating a concrete extractor
            //DocumentTextExtractor.SpreadsheetDocument.ConcreteExtractor("The butterfly effect.xlsx");
            //Extract all
            //OtherOperations.ExtractAllFromCells("The butterfly effect.xlsx");
            //Pass media type and encoding to the created extractor
            //DocumentTextExtractor.PassEncodingToCreatedExtractor("The butterfly effect.xlsx");
            #endregion

            #region BusinessCases

            //count the statistic of word's occurrences in the document
            //WordStatistic.FindMaxWordLength("The butterfly effect.xlsx", "The butterfly effect.pptx");
            // view the content of the file in Console
            //ExtractText.ViewContentInConsole("The butterfly effect.xlsx");
            #endregion
        }
    }
}
