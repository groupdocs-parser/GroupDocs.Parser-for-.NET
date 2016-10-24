using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Text.Extractors.Text;
using GroupDocs.Text.Formatters.Plain;
using GroupDocs.Text.Formatters.Markdown;
using GroupDocs.Text.Formatters.Html;
using System.IO;

namespace GroupDocs.Text_for_.NET
{
    public class ContentExtractor
    {
        public class OneNoteDocument
        {
            /// <summary>
            /// Extract text from onenote file/document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractOneNoteDocument(string fileName)
            {
                //ExStart:ExtractOneNoteDocument
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                //Set page index
                int pageIndex = 1;
                NoteTextExtractor extractor = new NoteTextExtractor(filePath);
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractPage(pageIndex), extractor.PageCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.PageCount);
                //ExEnd:ExtractOneNoteDocument
            }
        }

        public class PdfDocument
        {
            /// <summary>
            /// Extract text from pdf documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractPdfDocument(string fileName)
            {
                //ExStart:ExtractPdfDocument
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                //Set page index
                int pageIndex = 1;
                PdfTextExtractor extractor = new PdfTextExtractor(filePath);
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractPage(pageIndex), extractor.PageCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.PageCount);
                //ExEnd:ExtractPdfDocument
            }
        }

        public class PresentationDocument
        {
            /// <summary>
            /// Extract text from presentatoin documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractPresentationDocument(string fileName)
            {
                //ExStart:ExtractPresentationDocument
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                //Set slide index
                int slideIndex = 1;
                SlidesTextExtractor extractor = new SlidesTextExtractor(filePath);
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractSlide(slideIndex), extractor.SlideCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.SlideCount);
                //ExEnd:ExtractPresentationDocument
            }
        }

        public class SpreadsheetDocument
        {
            /// <summary>
            /// Extract text from spreadsheet documents
            /// </summary>
            public static void ExtractEntireSheet(string fileName)
            {
                //ExStart:ExtractEntireSheet
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                //Set slide index
                int slideIndex = 1;
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractSheet(slideIndex), extractor.SheetCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.SheetCount);
                //ExEnd:ExtractEntireSheet
            }
            /// <summary>
            /// Extracting the sheet by the rows
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSheetByRows(string fileName)
            {
                //ExStart:ExtractSheetByRows
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                Console.WriteLine(sheetInfo.ExtractSheetHeader());
                for (int rowIndex = 2; rowIndex < sheetInfo.RowCount; rowIndex++)
                {
                    Console.WriteLine(sheetInfo.ExtractRow(rowIndex));
                }
                //ExEnd:ExtractSheetByRows
            }
            /// <summary>
            /// Extracting the selected columns
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSelectedColumns(string fileName)
            {
                //ExStart:ExtractSelectedColumns
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                Console.WriteLine(sheetInfo.ExtractSheet("B1", "C1"));
                //ExEnd:ExtractSelectedColumns
            }
            /// <summary>
            /// Extracting the selected columns from selected rows
            /// </summary>
            public static void ExtractSelectedColumnsAndRows(string fileName)
            {
                //ExStart:ExtractSelectedColumnsAndRows
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                Console.WriteLine(sheetInfo.ExtractSheetHeader());
                for (int rowIndex =2; rowIndex < sheetInfo.RowCount; rowIndex++)
                {
                    Console.WriteLine(sheetInfo.ExtractRow(rowIndex, "B1", "C1"));
                }
                //ExEnd:ExtractSelectedColumnsAndRows
            }
        }

        public class TextDocument
        {
            /// <summary>
            /// Extract formatted text from word
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractEntireWordPage(string fileName)
            {
                //ExStart:ExtractEntireWordPage
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                int pageIndex = 0;
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                Console.WriteLine(extractor.ExtractPage(pageIndex));
                //ExEnd:ExtractEntireWordPage
            }
            /// <summary>
            /// Extract text from word by defining a table format
            /// </summary>
            /// <param name="fileName"></param>
            public static void FormattingTable(string fileName)
            {
                //ExStart:ExtractEntireWordPage
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                PlainTableFrame frame = new PlainTableFrame(
                    PlainTableFrameAngle.ASCII,
                    PlainTableFrameEdge.ASCII,
                    PlainTableFrameIntersection.ASCII,
                    new PlainTableFrameConfig(true, true, true, false));
                extractor.DocumentFormatter = new PlainDocumentFormatter(frame);
                Console.WriteLine(extractor.ExtractAll());
                //ExEnd:ExtractEntireWordPage
            }
            /// <summary>
            /// Extract text with markdown text format
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractingWithMarkdown(string fileName)
            {
                //ExStart:ExtractingWithMarkdown
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                extractor.DocumentFormatter = new MarkdownDocumentFormatter();
                Console.WriteLine(extractor.ExtractAll());
                //ExEnd:ExtractingWithMarkdown
            }

            /// <summary>
            /// Extract a text with HTML text formatter
            /// </summary>
            /// <param name="fileName"></param>
            public static void HtmlTextFormating(string fileName)
            {
                //ExStart:HtmlTextFormating
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                extractor.DocumentFormatter = new HtmlDocumentFormatter();
                Console.WriteLine(extractor.ExtractAll());
                //ExEnd:HtmlTextFormating
            }
        }

    }
}
