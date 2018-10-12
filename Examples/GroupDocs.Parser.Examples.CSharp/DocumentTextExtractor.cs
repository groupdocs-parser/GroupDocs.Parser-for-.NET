using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Parser.Extractors.Text;
using GroupDocs.Parser.Formatters.Plain;
using GroupDocs.Parser.Formatters.Markdown;
using GroupDocs.Parser.Formatters.Html;
using System.IO;
using GroupDocs.Parser;
using GroupDocs.Parser.Detectors.MediaType;
using GroupDocs.Parser.Containers;
using GroupDocs.Parser.Extractors;
using GroupDocs.Parser.Extractors.Metadata;
using GroupDocs.Parser.Formatters;

namespace GroupDocs.Parser_for_.NET
{
    public class DocumentTextExtractor
    {

        public class EmailsExtractor
        {
            public static void ExtractEmailAttachments(string fileName)
            {
                //ExStart:ExtractEmailAttachments
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                EmailTextExtractor extractor = new EmailTextExtractor(filePath);
                ExtractorFactory factory = new ExtractorFactory();
                for (int i = 0; i < extractor.AttachmentCount; i++)
                {
                    Console.WriteLine(extractor.GetContentType(i).Name);
                    Stream stream = extractor.GetStream(i);
                    TextExtractor attachmentExtractor = factory.CreateTextExtractor(filePath);
                    try
                    {
                        Console.WriteLine(attachmentExtractor == null ? "Document format is not supported" : attachmentExtractor.ExtractAll());
                    }
                    finally
                    {
                        if (attachmentExtractor != null)
                        {
                            attachmentExtractor.Dispose();
                        }
                    }
                }
                //ExEnd:ExtractEmailAttachments
            }

            /// <summary>
            /// Shows how to extract structured text from emails
            /// Here as a sample usage where we are showing how to extract hyperlinks from an email
            /// Feature is supported by version 17.04 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractEmailHyperlinks(string fileName)
            {
                //ExStart:ExtractEmailHyperlinks
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                List<string> hyperlinks = new List<string>();
                StringBuilder sb = null;
                string currentLink = null;
                IStructuredExtractor extractor = new EmailTextExtractor(filePath);
                StructuredHandler handler = new StructuredHandler();

                // Handle Hyperlink event to process a starting of a hyperlink
                handler.Hyperlink += (sender, e) =>
                {
                    sb = new StringBuilder();
                    currentLink = e.Properties.Link;
                };

                // Handle ElementClose event to process a closing of a hyperlink
                handler.ElementClosed += (sender, e) =>
                {
                    StructuredHandler h = sender as StructuredHandler;
                    if (h != null && h[0] is HyperlinkProperties) // closing of hyperlink
                    {
                        if (sb != null)
                        {
                            hyperlinks.Add(string.Format("{0} ({1})", sb.ToString(), currentLink));
                        }
                        sb = null;
                        currentLink = null;
                    }
                };

                // Handle ElementText event to process a text
                handler.ElementText += (sender, e) =>
                {
                    if (sb != null) // if hyperlink is open
                    {
                        sb.Append(e.Text);
                    }
                };

                // Extract a text with its structure
                extractor.ExtractStructured(handler);

                foreach (string hl in hyperlinks)
                {
                    Console.WriteLine(hl);
                }
                //ExEnd:ExtractEmailHyperlinks
            }

            /// <summary>
            /// Shows how to extract text fromE attachments of email format using container
            /// Feature is supported in version 17.7 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextFromEmailAttachmentsUsingContainer(string fileName)
            {
                //ExStart:ExtractTextFromEmailAttachments
                //get the file's path
                string filePath = Common.GetFilePath(fileName);
                // Create an extractor factory
                var factory = new ExtractorFactory();
                // Create an instance of EmailTextExtractor class 
                var extractor = new EmailTextExtractor(filePath);
                // Iterate over all attachments in the message 
                for (var i = 0; i < extractor.Entities.Count; i++)
                {
                    // Print the name of an attachment   
                    Console.WriteLine(extractor.Entities[i].Name);
                    // Open the stream of an attachment   
                    using (var stream = extractor.Entities[i].OpenStream())
                    {
                        // Create the text extractor for an attachment     
                        var attachmentExtractor = factory.CreateTextExtractor(stream);
                        // If a media type is supported     
                        if (attachmentExtractor != null) try
                            {
                                // Print the content of an attachment       
                                Console.WriteLine(attachmentExtractor.ExtractAll());
                            }
                            finally
                            {
                                attachmentExtractor.Dispose();
                            }
                    }
                }
                //ExEnd:ExtractTextFromEmailAttachments
            }
        }

        public class OneNoteDocument
        {
            /// <summary>
            /// Extracts text from onenote file/document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractOneNoteDocument(string fileName)
            {
                //ExStart:ExtractOneNoteDocument
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                //Set page index
                int pageIndex = 1;
                NoteTextExtractor extractor = new NoteTextExtractor(filePath);
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractPage(pageIndex), extractor.PageCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.PageCount);
                //ExEnd:ExtractOneNoteDocument
            }

            /// <summary>
            /// Opens password-protected OneNote sections
            /// </summary>
            /// <param name="fileName">Name of the password protected one note file</param>
            public static void OpenPasswordProtectedOneNoteSection(string fileName)
            {
                //ExStart: OpenPasswordProtectedOneNoteSection
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                //set password in the load options
                var loadOptions = new LoadOptions();
                loadOptions.Password = "test";


                //initialize Note text extractor using the load options to open password protected sections
                using (var extractor = new NoteTextExtractor(filePath, loadOptions))
                {
                    //display the extracted text
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:OpenPasswordProtectedOneNoteSection
            }

            /// <summary>
            /// Extracts text by pages via a generic function
            /// </summary>
            /// <param name="fileName">Name of the password protected one note file</param>
            public static void ExtractTextByPagesUsingGenericFunction(string fileName)
            {
                //ExStart: ExtractTextByPagesUsingGenericFunction
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a text extractor
                NoteTextExtractor textExtractor = new NoteTextExtractor(filePath);
                // Invoke a function to print a text by pages
                PrintPages(textExtractor);
                //ExEnd:ExtractTextByPagesUsingGenericFunction
            }

            // This function allows to extract a text by pages from any text extractor with IPageTextExtractor interface support
            static void PrintPages(TextExtractor textExtractor)
            {
                // Check if IPageTextExtractor is supported
                IPageTextExtractor pageTextExtractor = textExtractor as IPageTextExtractor;
                if (pageTextExtractor != null)
                {
                    // Iterate over all pages
                    for (int i = 0; i < pageTextExtractor.PageCount; i++)
                    {
                        // Print a page number
                        Console.WriteLine(string.Format("{0}/{1}", i, pageTextExtractor.PageCount));
                        // Extract a text from the page
                        Console.WriteLine(pageTextExtractor.ExtractPage(i));
                    }
                }
            }

            /// <summary>
            /// Shows how to detect media type of .one file 
            /// </summary>
            /// <param name="fileName"></param>
            public static void DetectMediaType(string fileName)
            {
                //ExStart:DetectMediaTypeOne_18.4
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a media type detector
                var detector = new NoteMediaTypeDetector();
                // Detect a media type by the file name 
                Console.WriteLine(detector.Detect(filePath));
                // Detect a media type by the content using stream object
                //Console.WriteLine(detector.Detect(stream));
                //ExEnd:DetectMediaTypeOne_18.4
            }
        }

        public class PdfDocument
        {
            /// <summary>
            /// Extracts text from pdf documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractPdfDocument(string fileName)
            {
                //ExStart:ExtractPdfDocument
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                //Set page index
                int pageIndex = 1;
                PdfTextExtractor extractor = new PdfTextExtractor(filePath);
                /**set extract mode to standard
                extractor.ExtractMode = ExtractMode.Standard;**/
                //Set extraction mode to Fast text extraction in version 17.10
                extractor.ExtractMode = ExtractMode.Simple;
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractPage(pageIndex), extractor.PageCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.PageCount);
                //ExEnd:ExtractPdfDocument
            }

            /// <summary>
            /// Shows how to exatract text from PDF portfolios
            /// Feature is supported in version 17.07 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextFromPdfPortfolios(string fileName)
            {
                //ExStart:ExtractTextFromPdfPortfolios
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                // Create an extractor factory 
                var factory = new ExtractorFactory();
                // Create an instance of PdfTextExtractor class 
                var extractor = new PdfTextExtractor(filePath);
                //Set extraction mode to Fast text extraction
                extractor.ExtractMode = ExtractMode.Simple;
                // Iterate over all files in the portfolio 
                for (var i = 0; i < extractor.Entities.Count; i++)
                {
                    // Print the name of a file   
                    Console.WriteLine(extractor.Entities[i].Name);
                    // Open the stream of a file   
                    using (var stream = extractor.Entities[i].OpenStream())
                    {
                        // Create the text extractor for a file     
                        var entityExtractor = factory.CreateTextExtractor(stream);
                        // If a media type is supported
                        if (entityExtractor != null) try
                            {
                                // Print the content of a file       
                                Console.WriteLine(entityExtractor.ExtractAll());
                            }
                            finally
                            {
                                entityExtractor.Dispose();
                            }
                    }
                }
                //ExEnd:ExtractTextFromPdfPortfolios
            }

            /// <summary>
            /// Extracts a text area from a PDF document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextAreaFromPDFDocument(string fileName)
            {
                //ExStart:ExtractTextAreaFromDocument_18.7
                // Create a text extractor
                PdfTextExtractor extractor = new PdfTextExtractor(Common.GetFilePath(fileName));

                // Create search options
                TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
                // Set a regular expression to search 'Invoice # XXX' text
                searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
                // Limit the search with a rectangle
                searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);

                // Get text areas
                IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);

                // Iterate over a list
                foreach (TextArea area in texts)
                {
                    // Print a text
                    Console.WriteLine(area.Text);
                }
                //ExEnd:ExtractTextAreaFromDocument_18.7
            }

            /// <summary>
            /// Extracts data from PDF Forms
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractDataFromPDFForms(string fileName)
            {
                //ExStart:ExtractDataFromPDFForms_18.9
                // Create a text extractor
                using (var extractor = new PdfTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract forms data
                    var fields = extractor.GetFormData();
                    // Iterate over fields
                    foreach (var f in fields)
                    {
                        // Print field name and value
                        System.Console.WriteLine(string.Format("{0}: {1}", f.Key, f.Value));
                    }
                }
                //ExEnd:ExtractDataFromPDFForms_18.9
            }

            /// <summary>
            /// Extracts images from the PDF document
            /// </summary>
            public static void ExtractImages(string fileName)
            {
                //ExStart:ExtractImages_PDF_18.10
                // Create a text extractor
                PdfTextExtractor extractor = new PdfTextExtractor(fileName);

                // Create search options
                ImageAreaSearchOptions searchOptions = new ImageAreaSearchOptions();
                // Limit the search with the rectangle: position (0; 0), size (300; 300)
                searchOptions.Rectangle = new Rectangle(0, 0, 300, 300);

                // Get images from the first page
                IList<ImageArea> imageAreas = extractor.DocumentContent.GetImageAreas(0, searchOptions);

                // Iterate over the images
                for (int i = 0; i < imageAreas.Count; i++)
                {
                    using (Stream fs = File.Create(String.Format("{0}.jpg", i)))
                    {
                        // Save the image to the file
                        Common.CopyStream(imageAreas[i].GetRawStream(), fs);
                    }
                }
                //ExEnd:ExtractImages_PDF_18.10
            }
        }

        public class PresentationDocument
        {
            /// <summary>
            /// Extracts text from presentatoin documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractPresentationDocument(string fileName)
            {
                //ExStart:ExtractPresentationDocument
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                //Set slide index
                int slideIndex = 1;
                SlidesTextExtractor extractor = new SlidesTextExtractor(filePath);
                //set extract mode to standard
                extractor.ExtractMode = ExtractMode.Standard;
                Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractSlide(slideIndex), extractor.SlideCount);
                //Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.SlideCount);
                //ExEnd:ExtractPresentationDocument
            }

            /// <summary>
            /// Shows how to extract structured text from presentation documents
            /// Here as a sample usage where we are showing how to extract top-level lists from ppt
            /// Feature is supported by version 17.04 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTopLevelLists(string fileName)
            {
                //ExStart:ExtractTopLevelLists
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                StringBuilder sb = new StringBuilder();
                IStructuredExtractor extractor = new SlidesTextExtractor(filePath);
                StructuredHandler handler = new StructuredHandler();

                bool isList = false;

                // Handle Hyperlink event to process a starting of a list
                handler.List += (sender, e) =>
                {
                    e.Properties.SkipElement = e.Properties.Depth > 0; // process only top-level lists
                    if (!e.Properties.SkipElement)
                    {
                        isList = true;
                    }
                };

                // Handle ElementClose event to process a closing of a list
                handler.ElementClosed += (sender, e) =>
                {
                    StructuredHandler h = sender as StructuredHandler;
                    if (h != null && h[0] is ListProperties)
                    {
                        isList = false;
                    }
                };

                // Handle ElementText event to process a text
                handler.ElementText += (sender, e) =>
                {
                    if (!isList)
                    {
                        return;
                    }

                    if (sb.Length > 0)
                    {
                        sb.AppendLine();
                    }

                    sb.Append(e.Text);
                };

                // Extract a text with its structure
                extractor.ExtractStructured(handler);

                Console.WriteLine(sb.ToString());
                //ExEnd:ExtractTopLevelLists
            }

            /// <summary>
            /// Extracts a text area from a presentation document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextAreaFromPresentationDocument(string fileName)
            {
                //ExStart:ExtractTextAreaFromPresentationDocument_18.8
                // Create a text extractor
                SlidesTextExtractor extractor = new SlidesTextExtractor(Common.GetFilePath(fileName));

                // Create search options
                TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
                // Set a regular expression to search 'Invoice # XXX' text
                searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
                // Limit the search with a rectangle
                searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);

                // Get text areas
                IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);

                // Iterate over a list
                foreach (TextArea area in texts)
                {
                    // Print a text
                    Console.WriteLine(area.Text);
                }
                //ExEnd:ExtractTextAreaFromPresentationDocument_18.8
            }

            /// <summary>
            /// Extracts images from the presentation document
            /// </summary>
            public static void ExtractImages(string fileName)
            {
                //ExStart:ExtractImages_Presentation_18.10
                // Create a text extractor
                SlidesTextExtractor extractor = new SlidesTextExtractor(fileName);

                // Create search options
                ImageAreaSearchOptions searchOptions = new ImageAreaSearchOptions();
                // Limit the search with the rectangle: position (0; 0), size (300; 300)
                searchOptions.Rectangle = new Rectangle(0, 0, 300, 300);

                // Get images from the first slide
                IList<ImageArea> imageAreas = extractor.DocumentContent.GetImageAreas(0, searchOptions);

                // Iterate over the images
                for (int i = 0; i < imageAreas.Count; i++)
                {
                    using (Stream fs = File.Create(String.Format("{0}.jpg", i)))
                    {
                        // Save the image to the file
                        Common.CopyStream(imageAreas[i].GetRawStream(), fs);
                    }
                }
                //ExEnd:ExtractImages_Presentation_18.10
            }
        }

        public class SpreadsheetDocument
        {
            /// <summary>
            /// Extracts text from spreadsheet documents
            /// </summary>
            public static void ExtractEntireSheet(string fileName)
            {
                //ExStart:ExtractEntireSheet
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                //set extract mode to standard
                extractor.ExtractMode = ExtractMode.Standard;
                //display all the sheets present in the excel file
                for (int sheetIndex = 0; sheetIndex < extractor.SheetCount; sheetIndex++)
                    Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractSheet(sheetIndex), extractor.SheetCount);
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
                String filePath = Common.GetFilePath(fileName);
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
            /// Extracts the selected columns
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSelectedColumns(string fileName)
            {
                //ExStart:ExtractSelectedColumns
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                Console.WriteLine(sheetInfo.ExtractSheet("B1", "C1"));
                //ExEnd:ExtractSelectedColumns
            }

            /// <summary>
            /// Extracts the selected columns from selected rows
            /// </summary>
            public static void ExtractSelectedColumnsAndRows(string fileName)
            {
                //ExStart:ExtractSelectedColumnsAndRows
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                Console.WriteLine(sheetInfo.ExtractSheetHeader());
                for (int rowIndex = 2; rowIndex < sheetInfo.RowCount; rowIndex++)
                {
                    Console.WriteLine(sheetInfo.ExtractRow(rowIndex, "B1", "C1"));
                }
                //ExEnd:ExtractSelectedColumnsAndRows
            }

            /// <summary>
            /// Creates the concrete extractor by hand using filestream
            /// </summary>
            /// <param name="fileName"></param>
            public static void ConcreteExtractor(string fileName)
            {
                //ExStart:ConcreteExtractor
                //get file actual path
                string filePath = Common.GetFilePath(fileName);
                using (Stream stream = File.OpenRead(filePath))
                {
                    using (CellsTextExtractor extractor = new CellsTextExtractor(stream))
                    {
                        //set extract mode to standard
                        extractor.ExtractMode = ExtractMode.Standard;
                        Console.WriteLine(extractor.ExtractAll());
                    }
                }
                //ExEnd:ConcreteExtractor
            }

            /// <summary>
            /// Creates the concrete extractor by hand
            /// </summary>
            /// <param name="fileName"></param>
            public static void ConcreteExtractorByFile(string fileName)
            {
                //ExStart:ConcreteExtractorByFile
                //get file actual path
                string filePath = Common.GetFilePath(fileName);

                using (CellsTextExtractor extractor = new CellsTextExtractor(filePath))
                {
                    Console.WriteLine(extractor.ExtractAll());
                }

                //ExEnd:ConcreteExtractorByFile
            }

            /// <summary>
            /// Shows how to read a structured text from spreadsheets
            /// Feature is supported by version 17.04 or greater
            /// </summary>
            public static void ExtractStructuredText(string fileName)
            {
                //ExStart:ExtractStructuredText
                //get file's complete path 
                string filePath = Common.GetFilePath(fileName);
                StringBuilder sb = new StringBuilder();
                IStructuredExtractor extractor = new CellsTextExtractor(filePath);
                StructuredHandler handler = new StructuredHandler();

                // Handle Table event to process a table
                handler.Table += (sender, e) =>
                {
                    e.Properties.SkipElement = e.Properties.Name != "Sheet2"; // process only the sheet which name is Sheet2
                    if (!e.Properties.SkipElement)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }

                        sb.Append(e.Properties.Name);
                    }
                };

                // Handle TableRow event to process a table row
                handler.TableRow += (sender, e) =>
                {
                    sb.AppendLine();
                };

                // Handle TableCell event to process a table cell
                handler.TableCell += (sender, e) =>
                {
                    if (e.Properties.Column > 0)
                    {
                        sb.Append(" ");
                    }
                };

                // Handle ElementText event to process a text
                handler.ElementText += (sender, e) =>
                {
                    sb.Append(e.Text);
                };

                // Extract a text with its structure
                extractor.ExtractStructured(handler);
                Console.WriteLine(sb.ToString());
                //ExEnd:ExtractStructuredText
            }

            /// <summary>
            /// Extracts a text area from a spreadsheet document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextAreaFromSpreadsheetDocument(string fileName)
            {
                //ExStart:ExtractTextAreaFromSpreadsheetDocument_18.8
                // Create a text extractor
                CellsTextExtractor extractor = new CellsTextExtractor(Common.GetFilePath(fileName));

                // Create search options
                TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
                // Set a regular expression to search 'Invoice # XXX' text
                searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
                // Limit the search with a rectangle
                searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);

                // Get text areas
                IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);

                // Iterate over a list
                foreach (TextArea area in texts)
                {
                    // Print a text
                    Console.WriteLine(area.Text);
                }
                //ExEnd:ExtractTextAreaFromSpreadsheetDocument_18.8
            }

            /// <summary>
            /// Extracts images from the speardsheet document
            /// </summary>
            public static void ExtractImages(string fileName)
            {
                //ExStart:ExtractImages_Spreadsheet_18.10
                // Create a text extractor
                CellsTextExtractor extractor = new CellsTextExtractor(fileName);

                // Create search options
                ImageAreaSearchOptions searchOptions = new ImageAreaSearchOptions();
                // Limit the search with the rectangle: position (0; 0), size (300; 300)
                searchOptions.Rectangle = new Rectangle(0, 0, 300, 300);

                // Get images from the first slide
                IList<ImageArea> imageAreas = extractor.DocumentContent.GetImageAreas(0, searchOptions);

                // Iterate over the images
                for (int i = 0; i < imageAreas.Count; i++)
                {
                    using (Stream fs = File.Create(String.Format("{0}.jpg", i)))
                    {
                        // Save the image to the file
                        Common.CopyStream(imageAreas[i].GetRawStream(), fs);
                    }
                }
                //ExEnd:ExtractImages_Spreadsheet_18.10
            }
        }

        public class TextDocument
        {
            /// <summary>
            /// Extracts formatted text from word
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractEntireWordPage(string fileName)
            {
                //ExStart:ExtractEntireWordPage
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                int pageIndex = 0;
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                Console.WriteLine(extractor.ExtractPage(pageIndex));
                //ExEnd:ExtractEntireWordPage
            }

            /// <summary>
            /// Extracts text from word by defining a table format
            /// </summary>
            /// <param name="fileName"></param>
            public static void FormattingTable(string fileName)
            {
                //ExStart:FormattingTable
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                PlainTableFrame frame = new PlainTableFrame(
                    PlainTableFrameAngle.ASCII,
                    PlainTableFrameEdge.ASCII,
                    PlainTableFrameIntersection.ASCII,
                    new PlainTableFrameConfig(true, true, true, false));
                extractor.DocumentFormatter = new PlainDocumentFormatter(frame);
                Console.WriteLine(extractor.ExtractAll());
                //ExEnd:FormattingTable
            }

            /// <summary>
            /// Extracts text with markdown text format
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractingWithMarkdown(string fileName)
            {
                //ExStart:ExtractingWithMarkdown
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                extractor.DocumentFormatter = new MarkdownDocumentFormatter();
                Console.WriteLine(extractor.ExtractAll());
                //ExEnd:ExtractingWithMarkdown
            }

            /// <summary>
            /// Extracts a text with HTML text formatter
            /// </summary>
            /// <param name="fileName"></param>
            public static void HtmlTextFormating(string fileName)
            {
                //ExStart:HtmlTextFormating
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                extractor.DocumentFormatter = new HtmlDocumentFormatter();
                Console.WriteLine(extractor.ExtractAll());
                //ExEnd:HtmlTextFormating
            }

            /// <summary>
            /// Shows how to read structured text from text documents
            /// here we show how to extract header from a document
            /// Feature is supported by version 17.04 or greater
            /// </summary>
            public static void ExtractHeadersFromDocument(string fileName)
            {
                //ExStart:ExtractHeadersFromDocument
                //get file's complete path 
                string filePath = Common.GetFilePath(fileName);
                StringBuilder sb = new StringBuilder();
                IStructuredExtractor extractor = new WordsTextExtractor(filePath);
                StructuredHandler handler = new StructuredHandler();

                // Handle List event to prevent processing of lists
                handler.List += (sender, e) => e.Properties.SkipElement = true; // ignore lists
                                                                                // Handle Table event to prevent processing of tables
                handler.Table += (sender, e) => e.Properties.SkipElement = true; // ignore tables
                                                                                 // Handle Paragraph event to process a paragraph
                handler.Paragraph += (sender, e) =>
                {
                    int h1 = (int)ParagraphStyle.Heading1;
                    int h6 = (int)ParagraphStyle.Heading6;

                    int style = (int)e.Properties.Style;
                    if (h1 <= style && style <= h6)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }

                        sb.Append(' ', style - h1); // make an indention for the header (h1 - no indention)
                    }
                    else
                    {
                        e.Properties.SkipElement = e.Properties.Style != ParagraphStyle.Title; // skip paragraph if it's not a header or a title
                    }
                };

                // Handle ElementText event to process a text
                handler.ElementText += (sender, e) => sb.Append(e.Text);

                // Extract a text with its structure
                extractor.ExtractStructured(handler);

                Console.WriteLine(sb.ToString());
                //ExEnd:ExtractHeadersFromDocument
            }

            /// <summary>
            /// Extracts hyperlinks from a document
            /// feature supported in version 17.04 or greater
            /// </summary>
            /// <param name="fileName">Name of the source file</param>
            public static void ExtractHyperlinksFromDocument(string fileName)
            {
                //ExStart:ExtractHyperlinksFromDocument
                //get file path
                string filePath = Common.GetFilePath(fileName);
                List<string> hyperlinks = new List<string>();
                StringBuilder sb = null;
                string currentLink = null;
                IStructuredExtractor extractor = new WordsTextExtractor(filePath);
                StructuredHandler handler = new StructuredHandler();

                // Handle Hyperlink event to process a starting of a hyperlink
                handler.Hyperlink += (sender, e) =>
                {
                    sb = new StringBuilder();
                    currentLink = e.Properties.Link;
                };

                // Handle ElementClose event to process a closing of a hyperlink
                handler.ElementClosed += (sender, e) =>
                {
                    StructuredHandler h = sender as StructuredHandler;
                    if (h != null && h[0] is HyperlinkProperties) // closing of hyperlink
                    {
                        if (sb != null)
                        {
                            hyperlinks.Add(string.Format("{0} ({1})", sb.ToString(), currentLink));
                        }
                        sb = null;
                        currentLink = null;
                    }
                };

                // Handle ElementText event to process a text
                handler.ElementText += (sender, e) =>
                {
                    if (sb != null) // if hyperlink is open
                    {
                        sb.Append(e.Text);
                    }
                };

                // Extract a text with its structure
                extractor.ExtractStructured(handler);

                foreach (string hl in hyperlinks)
                {
                    Console.WriteLine(hl);
                }
                //ExEnd:ExtractHyperlinksFromDocument
            }

            /// <summary>
            /// Extracts a text area from a text document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextAreaFromTextDocument(string fileName)
            {
                //ExStart:ExtractTextAreaFromTextDocument_18.8
                // Create a text extractor
                WordsTextExtractor extractor = new WordsTextExtractor(Common.GetFilePath(fileName));

                // Create search options
                TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
                // Set a regular expression to search 'Invoice # XXX' text
                searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
                // Limit the search with a rectangle
                searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);

                // Get text areas
                IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);

                // Iterate over a list
                foreach (TextArea area in texts)
                {
                    // Print a text
                    Console.WriteLine(area.Text);
                }
                //ExEnd:ExtractTextAreaFromTextDocument_18.8
            }

            /// <summary>
            /// Extracts images from the text document
            /// </summary>
            public static void ExtractImages(string fileName)
            {
                //ExStart:ExtractImages_TextDocument_18.10
                // Create a text extractor
                WordsTextExtractor extractor = new WordsTextExtractor(fileName);

                // Create search options
                ImageAreaSearchOptions searchOptions = new ImageAreaSearchOptions();
                // Limit the search with the rectangle: position (0; 0), size (300; 300)
                searchOptions.Rectangle = new Rectangle(0, 0, 300, 300);

                // Get images from the first slide
                IList<ImageArea> imageAreas = extractor.DocumentContent.GetImageAreas(0, searchOptions);

                // Iterate over the images
                for (int i = 0; i < imageAreas.Count; i++)
                {
                    using (Stream fs = File.Create(String.Format("{0}.jpg", i)))
                    {
                        // Save the image to the file
                        Common.CopyStream(imageAreas[i].GetRawStream(), fs);
                    }
                }
                //ExEnd:ExtractImages_TextDocument_18.10
            }
        }

        public class MarkdownDocument
        {
            /// <summary>
            /// Extracts single line of characters as raw text from Markdown document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSingleLineAsRawText(string fileName)
            {
                //ExStart:ExtractSingleLineAsRawTextMarkdown_18.2 
                using (var extractor = new MarkdownTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract a line of the text
                    string line = extractor.ExtractLine();
                    // If the line is null, then the end of the file is reached
                    while (line != null)
                    {
                        // Print a line to the console
                        Console.WriteLine(line);
                        // Extract another line
                        line = extractor.ExtractLine();
                    }
                }
                //ExEnd:ExtractSingleLineAsRawTextMarkdown_18.2
            }

            /// <summary>
            /// Extracts all characters as raw text from Markdown document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractAllCharactersAsRawText(string fileName)
            {
                //ExStart:ExtractAllCharactersAsRawTextMarkdown_18.2 
                using (var extractor = new MarkdownTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract a text
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ExtractAllCharactersAsRawTextMarkdown_18.2
            }

            /// <summary>
            /// Extracts a line of characters as formatted text from Markdown document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSingleLineAsFormattedText(string fileName)
            {
                //ExStart:ExtractSingleLineAsFormattedTextMarkdown_18.2 
                // Create a text extractor for Markdown documents
                using (var extractor = new MarkdownFormattedTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract a line of the text
                    string line = extractor.ExtractLine();
                    // If the line is null, then the end of the file is reached
                    while (line != null)
                    {
                        // Print a line to the console
                        Console.WriteLine(line);
                        // Extract another line
                        line = extractor.ExtractLine();
                    }
                }
                //ExEnd:ExtractSingleLineAsFormattedTextMarkdown_18.2
            }

            /// <summary>
            /// Extracts a line of characters as formatted text from Markdown document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractAllCharactersAsFormattedText(string fileName)
            {
                //ExStart:ExtractAllCharactersAsFormattedTextMarkdown_18.2 
                // Create a text extractor for Markdown documents
                using (var extractor = new MarkdownFormattedTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract a text
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ExtractAllCharactersAsFormattedTextMarkdown_18.2
            }

            /// <summary>
            /// Extracts formatted text using DocumentFormatter from Markdown document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractFormattedTextUsingDocumentFormatter(string fileName)
            {
                //ExStart:ExtractFormattedTextUsingDocumentFormatterMarkdown_18.2 
                // Create a formatted text extractor for text documents
                MarkdownFormattedTextExtractor extractor = new MarkdownFormattedTextExtractor(Common.GetFilePath(fileName));
                // Set a HTML formatter for formatting
                extractor.DocumentFormatter = new HtmlDocumentFormatter(); // all the text will be formatted as HTML
                //ExEnd:ExtractFormattedTextUsingDocumentFormatterMarkdown_18.2
            }

            /// <summary>
            /// Extracts structured text from Markdown document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractStructuredText(string fileName)
            {
                //ExStart:ExtractStructuredTextMarkdown_18.2 
                StringBuilder sb = new StringBuilder();
                IStructuredExtractor extractor = new MarkdownTextExtractor(Common.GetFilePath(fileName));
                StructuredHandler handler = new StructuredHandler();

                // Handle List event to prevent processing of lists
                handler.List += (sender, e) => e.Properties.SkipElement = true; // ignore lists

                // Handle Table event to prevent processing of tables
                handler.Table += (sender, e) => e.Properties.SkipElement = true; // ignore tables

                // Handle Paragraph event to process a paragraph
                handler.Paragraph += (sender, e) =>
                {
                    int h1 = (int)ParagraphStyle.Heading1;
                    int h6 = (int)ParagraphStyle.Heading6;

                    int style = (int)e.Properties.Style;
                    if (h1 <= style && style <= h6)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }

                        sb.Append(' ', style - h1); // make an indention for the header (h1 - no indention)
                    }
                    else
                    {
                        e.Properties.SkipElement = e.Properties.Style != ParagraphStyle.Title; // skip paragraph if it's not a header or a title
                    }
                };

                // Handle ElementText event to process a text
                handler.ElementText += (sender, e) => sb.Append(e.Text);

                // Extract a text with its structure
                extractor.ExtractStructured(handler);

                Console.WriteLine(sb.ToString());
                //ExEnd:ExtractStructuredTextMarkdown_18.2
            }

        }

        public class Epub
        {
            /// <summary>
            /// Extracts a line of characters from a document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractALine(string fileName)
            {
                //ExStart:ExtractALine
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (var extractor = new EpubTextExtractor(filePath))
                {
                    string line = extractor.ExtractLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = extractor.ExtractLine();
                    }
                }
                //ExEnd:ExtractALine
            }

            /// <summary>
            /// Extracts all characters from a document
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractAllCharacters(string fileName)
            {
                //ExStart:ExtractAllCharacters
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (var extractor = new EpubTextExtractor(filePath))
                {
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ExtractAllCharacters
            }

            /// <summary>
            /// Searches for a text in an epub file using regular expression
            /// </summary>
            /// <param name="fileName"></param>
            public static void SearchTextUsingRegex(string fileName)
            {
                //ExStart:SearchTextInEpubUsingRegex
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (EpubTextExtractor extractor = new EpubTextExtractor(filePath))
                {
                    var searchOptions = new RegexSearchOptions();
                    var handler = new ListSearchHandler();
                    extractor.SearchWithRegex("On[a-z]", handler, searchOptions);

                    if (handler.List.Count == 0)
                    {
                        Console.WriteLine("Not found");
                    }
                    else
                    {
                        for (int i = 0; i < handler.List.Count; i++)
                        {
                            Console.Write(handler.List[i].LeftText);
                            Console.Write("_");
                            Console.Write(handler.List[i].FoundText);
                            Console.Write("_");
                            Console.Write(handler.List[i].RightText);
                            Console.WriteLine("---");
                        }
                    }
                }
                //ExEnd:SearchTextInEpubUsingRegex
            }

            /// <summary>
            /// Searches some text in an epub file
            /// </summary>
            /// <param name="fileName"></param>
            public static void SearchText(string fileName)
            {
                //ExStart:SearchTextInEpub
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (EpubTextExtractor extractor = new EpubTextExtractor(filePath))
                {
                    var options = new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(0));
                    var handler = new ListSearchHandler();
                    var keywords = new string[] { "Name" };
                    extractor.Search(options, handler, keywords);

                    if (handler.List.Count == 0)
                    {
                        Console.WriteLine("Not found");
                    }
                    else
                    {
                        for (int i = 0; i < handler.List.Count; i++)
                        {
                            Console.Write(handler.List[i].LeftText);
                            Console.Write("_");
                            Console.Write(handler.List[i].FoundText);
                            Console.Write("_");
                            Console.Write(handler.List[i].RightText);
                            Console.WriteLine("---");
                        }
                    }
                }
                //ExEnd:SearchTextInEpub
            }

            /// <summary>
            /// Extracts highlighted text in epub file
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractHighlight(string fileName)
            {
                //ExStart:ExtractHighlightInEpub
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (EpubTextExtractor extractor = new EpubTextExtractor(filePath))
                {
                    IList<string> highlights = extractor.ExtractHighlights(HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 9, 3));
                    for (int i = 0; i < highlights.Count; i++)
                    {
                        Console.WriteLine(highlights[i]);
                    }
                }
                //ExEnd:ExtractHighlightInEpub
            }

            /// <summary>
            /// Detects Epub Media type
            /// </summary>
            /// <param name="fileName"></param>
            public static void DetectEpubMediaType(string fileName)
            {
                //ExStart:DetectEpubMediaType
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                var detector = new EpubMediaTypeDetector();
                var mediaType = detector.Detect(filePath);

                // APPLICATION/EPUB+ZIP or null if stream is not EPUB document.
                Console.WriteLine(mediaType);
                //ExEnd:DetectEpubMediaType
            }

            /// <summary>
            /// Shows how to extract section titles from EPUB document
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSectionTitle(string fileName)
            {
                //ExStart:ExtractSectionTitleEpub
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a text extractor
                using (EpubTextExtractor extractor = new EpubTextExtractor(filePath))
                {
                    StringBuilder sb = null;
                    bool isSectionHasTitle = false;

                    // Create a handler
                    StructuredHandler handler = new StructuredHandler();

                    // Handle ElementText event to process a section
                    handler.Section += (sender, e) =>
                    {
                        isSectionHasTitle = false; // a new section doesn't have a title
                    };

                    // Handle Paragraph event to process a paragraph
                    handler.Paragraph += (sender, e) =>
                    {
                        // is paragraph a heading?
                        bool isHeading = ParagraphStyle.Heading1 <= e.Properties.Style && e.Properties.Style <= ParagraphStyle.Heading6;

                        if (isHeading && !isSectionHasTitle)
                        {
                            sb = new StringBuilder();
                        }
                    };

                    // Handle ElementClosed event to process a closing of a paragraph
                    handler.ElementClosed += (sender, e) =>
                    {
                        // Check if closing tag is paragraph
                        if (sb != null && e.Properties is ParagraphProperties)
                        {
                            // Print a title to the console
                            Console.WriteLine(sb.ToString());
                            // Section has a title
                            isSectionHasTitle = true;
                            sb = null;
                        }
                    };

                    // Handle ElementText event to process a text
                    handler.ElementText += (sender, e) =>
                    {
                        if (sb != null)
                        {
                            // Add a text to the title
                            sb.Append(e.Text);
                        }
                    };

                    // Extract a text with its structure
                    extractor.ExtractStructured(handler);
                }
                //ExEnd:ExtractSectionTitleEpub
            }

            /// <summary>
            /// Shows how to extract formatted text from Epub files
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractFormattedText(string fileName)
            {
                //ExStart:ExtractFormattedTextEpub
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a formatted text extractor for EPUB documents
                using (var extractor = new EpubFormattedTextExtractor(filePath))
                {
                    // Set a document formatter to Markdown
                    extractor.DocumentFormatter = new MarkdownDocumentFormatter();
                    // Extact a text and print it to the console
                    Console.Write(extractor.ExtractAll());
                }
                //ExEnd:ExtractFormattedTextEpub
            }

            /// <summary>
            /// Extracts TOC from epub file
            /// </summary>
            /// <param name="fileName"></param>
            //ExStart:ExtractTableOfContentEpub_18.4
            public static void ExtractTableOfContent(string fileName)
            {
                // Create a text extractor
                using (EpubTextExtractor extractor = new EpubTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Print TOC on the screen
                    PrintToc(extractor[0].TableOfContents, 0);
                }
            }
            private static void PrintToc(IEnumerable<TableOfContentsItem> tableOfContents, int depth)
            {
                // Use spaces to indicate the depth of the TOC item
                string spaces = new string(' ', depth);

                // Iterate over items
                foreach (TableOfContentsItem item in tableOfContents)
                {
                    System.Console.Write(spaces);
                    // Print the item's text
                    System.Console.Write(item.Text);

                    // If item has a text (it's not just a node)
                    if (item.PageIndex.HasValue)
                    {
                        // Print the text length
                        System.Console.Write(string.Format(" ({0})", item.ExtractPage().Length));
                    }

                    System.Console.WriteLine();

                    // If the item has children
                    if (item.Count > 0)
                    {
                        // Print them
                        PrintToc(item, depth + 1);
                    }
                }
            }
            //ExEnd:ExtractTableOfContentEpub_18.4

            /// <summary>
            /// Extracts text from the item of TOC
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextOfItemInTOC(string fileName)
            {
                //ExStart:ExtractTextOfItemInTOCEpub_18.4
                // Create a text extractor
                using (EpubTextExtractor extractor = new EpubTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Print a content of the third sub-item of the second item 
                    Console.WriteLine(extractor[0].TableOfContents[1][2].ExtractPage());
                }
                //ExEnd:ExtractTextOfItemInTOCEpub_18.4
            }

            
        }

        public class Fb2
        {
            /// <summary>
            /// Shows how to extract whole text from fb2 file
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractWholeText(string fileName)
            {
                //ExStart:ExtractWholeTextFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (var extractor = new FictionBookTextExtractor(filePath))
                {
                    Console.Write(extractor.ExtractAll());
                }
                //ExEnd:ExtractWholeTextFb2
            }

            /// <summary>
            /// Shows how to extract text line by line
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextByLine(string fileName)
            {
                //ExStart:ExtractTextByLineFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                using (var extractor = new FictionBookTextExtractor(filePath))
                {
                    string line = extractor.ExtractLine();
                    while (line != null)
                    {
                        Console.Write(line);
                        line = extractor.ExtractLine();
                    }
                }
                //ExEnd:ExtractTextByLineFb2
            }

            /// <summary>
            /// Shows how to extract highlights from fb2 files
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractHighlights(string fileName)
            {
                //ExStart:ExtractHighlightsFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a text extractor 
                using (FictionBookTextExtractor extractor = new FictionBookTextExtractor(filePath))
                {
                    // Extract two highlights with the fixed position and length     
                    var highlights = extractor.ExtractHighlights(
                        HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 19, 22),
                        HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 19, 10));

                    for (int i = 0; i < highlights.Count; i++)
                    {
                        // Print highlights to the console        
                        Console.WriteLine(highlights[i]);
                    }
                }
                //ExEnd:ExtractHighlightsFb2
            }

            /// <summary>
            /// Shows how to search text in fb2 files with a regular expression
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void SearchTextWithRegex(string fileName)
            {
                //ExStart:SearchTextWithRegexFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a text extractor 
                using (var extractor = new FictionBookTextExtractor(filePath))
                {
                    // Create search options   
                    var searchOptions = new RegexSearchOptions();
                    // Create a search handler. ListSearchHandler collects search results to the list  
                    var handler = new ListSearchHandler();
                    // Search with a regular expression   
                    extractor.SearchWithRegex("On[a-z]", handler, searchOptions);

                    // If list doesn't contain any results   
                    if (handler.List.Count == 0)
                    {
                        Console.WriteLine("Not found"); // Print "Not Found" to the console  
                    }
                    else
                    {
                        // Iterate search results     
                        for (int i = 0; i < handler.List.Count; i++)
                        {
                            // Print a search result to the console       
                            Console.Write(handler.List[i].LeftText); // a text on the left side from the found text      
                            Console.Write("_");
                            Console.Write(handler.List[i].FoundText); // the found text       
                            Console.Write("_");
                            Console.Write(handler.List[i].RightText); // a text on the right side from the found text       
                            Console.WriteLine("---");
                        }
                    }
                }
                //ExEnd:SearchTextWithRegexFb2
            }

            /// <summary>
            /// Shows how to search tex tin fb2 files
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void SearchText(string fileName)
            {
                //ExStart:SearchTextFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a text extractor 
                using (var extractor = new FictionBookTextExtractor(filePath))
                {
                    // Create search options   
                    var options = new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(0));
                    // Create a search handler. ListSearchHandler collects search results to the list  
                    var handler = new ListSearchHandler();
                    // Create keywords to search   
                    var keywords = new string[] { "examined" };
                    // Search keywords   
                    extractor.Search(options, handler, keywords);

                    // If list doesn't contain any results   
                    if (handler.List.Count == 0)
                    {
                        Console.WriteLine("Not found");
                        // Print "Not Found" to the console   
                    }
                    else
                    {
                        // Iterate search results     
                        for (int i = 0; i < handler.List.Count; i++)
                        {
                            // Print a search result to the console       
                            Console.Write(handler.List[i].LeftText);
                            // a text on the left side from the found text       
                            Console.Write("_");
                            Console.Write(handler.List[i].FoundText);
                            // the found text       
                            Console.Write("_");
                            Console.Write(handler.List[i].RightText);
                            // a text on the right side from the found text       
                            Console.WriteLine("---");
                        }
                    }
                }
                //ExEnd:SearchTextFb2
            }

            /// <summary>
            /// Shows how to extract section titles from fb2 document
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractSectionTitle(string fileName)
            {
                //ExStart:ExtractSectionTitleFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a text extractor 
                using (FictionBookTextExtractor extractor = new FictionBookTextExtractor(filePath))
                {
                    StringBuilder sb = null;

                    // Create a handler     
                    StructuredHandler handler = new StructuredHandler();

                    // Handle Group event to process a group     
                    handler.Group += (sender, e) =>
                    {
                        StructuredHandler h = sender as StructuredHandler;

                        // Is the group a section title?         
                        bool isSectionTitleGroup = h != null && h.Depth > 1 && h[0] is SectionProperties;

                        // If a group is the section title        
                        if (isSectionTitleGroup)
                        {
                            sb = new StringBuilder();
                        }
                    };

                    // Handle Paragraph event to process a paragraph     
                    handler.Paragraph += (sender, e) =>
                    {
                        if (sb != null && sb.Length > 0)
                        {
                            sb.AppendLine();
                        }
                    };

                    // Handle ElementClosed event to process a closing of a paragraph     
                    handler.ElementClosed += (sender, e) =>
                    {
                        if (sb == null || sb.Length == 0)
                        {
                            return;
                        }

                        // Check if closing tag is paragraph         
                        if (e.Properties is ParagraphProperties)
                        {
                            sb.AppendLine();
                        }

                        // Check if closing tag is group of section title         
                        if (e.Properties is GroupProperties && (e.Properties as GroupProperties).Style == "title")
                        {
                            // Print a title to the console             
                            Console.WriteLine(sb.ToString());
                            sb = null;
                        }
                    };

                    // Handle ElementText event to process a text     
                    handler.ElementText += (sender, e) =>
                    {
                        if (sb != null)
                        {
                            // Add a text to the title             
                            sb.Append(e.Text);
                        }
                    };

                    // Extract a text with its structure     
                    extractor.ExtractStructured(handler);
                }
                //ExEnd:ExtractSectionTitleFb2
            }

            /// <summary>
            /// Shows how to detect media type of a fb2 file
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void DetectMediaType(string fileName)
            {
                //ExStart:DetectMediaTypeFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a media type detector 
                var detector = new FictionBookMediaTypeDetector();
                // Detect a media type by the file name 
                Console.WriteLine(detector.Detect(fileName));
                // Detect a media type by the content 
                Console.WriteLine(detector.Detect(filePath));
                //ExEnd:DetectMediaTypeFb2
            }

            /// <summary>
            /// Shows how to extract formatted text from fb2 file
            /// Feature is supported in version 17.06 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractFormattedText(string fileName)
            {
                //ExStart:ExtractFormattedTextFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a formatted text extractor for FictionBook (fb2)documents 
                using (var extractor = new FictionBookFormattedTextExtractor(filePath))
                {
                    // Set a document formatter to Markdown 
                    //extractor.DocumentFormatter = new FictionBookFormattedTextExtractor();
                    // Extact a text and print it to the console 
                    Console.Write(extractor.ExtractAll());
                }
                //ExEnd:ExtractFormattedTextFb2
            }
        }

        public class Dot
        {
            /// <summary>
            /// Shows how to extract text from Dot file
            /// Feature is supported in version 17.07 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractText(string fileName)
            {
                //ExStart:ExtractTextDotFiles
                string filePath = Common.GetFilePath(fileName);
                // Create an instance of WordsTextExtractor class 
                using (var extractor = new WordsTextExtractor(filePath))
                {
                    // Extract a text   
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ExtractTextDotFiles
            }
        }

        public class Chm
        {
            /// <summary>
            /// Shows how to extract a line of text from CHM file
            /// Feature is supported in version 17.8.0 or greater 
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractALine(string fileName)
            {
                //ExStart:ChmExtractALine
                string filePath = Common.GetFilePath(fileName);
                // Create a text extractor for CHM documents
                using (var extractor = new ChmTextExtractor(filePath))
                {
                    // Extract a line of the text
                    string line = extractor.ExtractLine();
                    // If the line is null, then the end of the file is reached
                    while (line != null)
                    {
                        // Print a line to the console
                        Console.WriteLine(line);
                        // Extract another line
                        line = extractor.ExtractLine();
                    }
                }
                //ExEnd:ChmExtractALine
            }

            /// <summary>
            /// Shows how to extract all characters from CHM file
            /// Feature is supported in version 17.8.0 or greater 
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractAllCharacters(string fileName)
            {
                //ExStart:ChmExtractAllCharacters
                string filePath = Common.GetFilePath(fileName);
                // Create a text extractor for CHM documents
                using (var extractor = new ChmTextExtractor(filePath))
                {
                    // Extract a text
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ChmExtractAllCharacters
            }

            /// <summary>
            /// Detects CHM Media type
            /// Feature is supported in version 17.09.0 or greater 
            /// </summary>
            /// <param name="fileName"></param>
            public static void DetectChmMediaType(string fileName)
            {
                //ExStart:DetectChmMediaType
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a media type detector
                var detector = new ChmMediaTypeDetector();
                // Detect a media type by the file name
                Console.WriteLine(detector.Detect(filePath));
                // APPLICATION/VND.MS-HTMLHELP if supported or NULL otherwise
                // Detect a media type by the content
                // APPLICATION/VND.MS-HTMLHELP if supported or NULL otherwise
                FileStream stream = new FileStream(filePath, FileMode.Open);
                Console.WriteLine(detector.Detect(stream));
                //ExEnd:DetectChmMediaType
            }


            /// <summary>
            /// Extracts line of formatted text from chm file
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractLineOfFormattedText(string fileName)
            {
                //ExStart:ExtractLineOfFormattedText_18.3
                // Create a text extractor for chm documents
                using (var extractor = new ChmFormattedTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract a line of the text
                    string line = extractor.ExtractLine();
                    // If the line is null, then the end of the file is reached
                    while (line != null)
                    {
                        // Print a line to the console
                        Console.WriteLine(line);
                        // Extract another line
                        line = extractor.ExtractLine();
                    }
                }
                //ExEnd:ExtractLineOfFormattedText_18.3
            }

            /// <summary>
            /// Extracts all characters from chm file
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractAllCharactersOfFormattedText(string fileName)
            {
                //ExStart:ExtractAllCharactersOfFormattedText_18.3
                // Create a text extractor for chm documents
                using (var extractor = new ChmFormattedTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Extract a text
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ExtractAllCharactersOfFormattedText_18.3
            }

            /// <summary>
            /// Extracts text from chm file using text formatter
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractFormattedTextUsingTextFormatter(string fileName)
            {
                //ExStart:ExtractFormattedTextUsingTextFormatter_18.3
                // Create a text extractor for chm documents
                using (var extractor = new ChmFormattedTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Set a HTML formatter for formatting
                    extractor.DocumentFormatter = new HtmlDocumentFormatter(); // all the text will be formatted as HTML

                    // Extract a text
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:ExtractFormattedTextUsingTextFormatter_18.3
            }

            /// <summary>
            /// Extracts text from chm file by pages
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextByPages(string fileName)
            {
                //ExStart:ExtractTextByPages_18.3
                // Create a text extractor
                ChmTextExtractor textExtractor = new ChmTextExtractor(Common.GetFilePath(fileName));
                // Invoke a function to print a text by pages
                // Check if IPageTextExtractor is supported
                IPageTextExtractor pageTextExtractor = textExtractor as IPageTextExtractor;
                if (pageTextExtractor != null)
                {
                    // Iterate over all pages
                    for (int i = 0; i < pageTextExtractor.PageCount; i++)
                    {
                        // Print a page number
                        Console.WriteLine(string.Format("{0}/{1}", i, pageTextExtractor.PageCount));
                        // Extract a text from the page
                        Console.WriteLine(pageTextExtractor.ExtractPage(i));
                    }
                }
                //ExEnd:ExtractTextByPages_18.3
            }

            /// <summary>
            /// Extracts TOC from chm file
            /// </summary>
            /// <param name="fileName"></param>
            //ExStart:ExtractTableOfContent_18.3
            public static void ExtractTableOfContent(string fileName)
            {               
                // Create a text extractor
                using (ChmTextExtractor extractor = new ChmTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Print TOC on the screen
                    PrintToc(extractor.TableOfContents, 0);
                } 
            }
            private static void PrintToc(IEnumerable<TableOfContentsItem> tableOfContents, int depth)
            {
                // Use spaces to indicate the depth of the TOC item
                string spaces = new string(' ', depth);

                // Iterate over items
                foreach (TableOfContentsItem item in tableOfContents)
                {
                    System.Console.Write(spaces);
                    // Print the item's text
                    System.Console.Write(item.Text);

                    // If item has a text (it's not just a node)
                    if (item.PageIndex.HasValue)
                    {
                        // Print the text length
                        System.Console.Write(string.Format(" ({0})", item.ExtractPage().Length));
                    }

                    System.Console.WriteLine();

                    // If the item has children
                    if (item.Count > 0)
                    {
                        // Print them
                        PrintToc(item, depth + 1);
                    }
                }
            }
            //ExEnd:ExtractTableOfContent_18.3

            /// <summary>
            /// Extracts text from the item of TOC
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractTextOfItemInTOC(string fileName)
            {
                //ExStart:ExtractTextOfItemInTOC_18.3
                // Create a text extractor
                using (ChmTextExtractor extractor = new ChmTextExtractor(Common.GetFilePath(fileName)))
                {
                    // Print a content of the third sub-item of the second item
                    Console.WriteLine(extractor.TableOfContents[1][1].ExtractPage());
                }
                //ExEnd:ExtractTextOfItemInTOC_18.3
            }
        }


        public static void PassEncodingToCreatedExtractor(string fileName)
        {
            //ExStart:PassEncodingToCreatedExtractor
            //get file actual path
            string filePath = Common.GetFilePath(fileName);
            LoadOptions loadOptions = new LoadOptions("text/plain", Encoding.UTF8);
            ExtractorFactory factory = new ExtractorFactory();
            using (TextExtractor extractor = factory.CreateTextExtractor(filePath, loadOptions))
            {
                Console.WriteLine(extractor != null ? extractor.ExtractAll() : "The document format is not supported");
            }
            //ExEnd:PassEncodingToCreatedExtractor
        }

        /// <summary>
        /// Extracts text from a password protected document 
        /// </summary>
        /// <param name="fileName"></param>
        public static void PasswordProtectedDocumentExtractor(string fileName)
        {
            //ExStart:PasswordProtectedDocumentExtractor
            //get file actual path
            string filePath = Common.GetFilePath(fileName);
            //To open password-protected document Password property of LoadOptions must be set
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = "12345";

            WordsTextExtractor extractor = null;
            //If password is not set or incorrect InvalidPasswordException is thrown
            try
            {
                Console.WriteLine("Able to open the password protected document");
                extractor = new WordsTextExtractor(filePath, loadOptions);
                Console.WriteLine(extractor.ExtractAll());
            }
            catch (InvalidPasswordException)
            {
                Console.WriteLine("Invalid password.");
            }
            finally
            {
                if (extractor != null)
                {
                    extractor.Dispose();
                }
            }
            //ExEnd:PasswordProtectedDocumentExtractor
        }

        /// <summary>
        /// Shows how a conatiner is created using ExtractFactory
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreatingContainerUsingExtractorFactory(string fileName)
        {
            //ExStart:CreatingContainerUsingExtractorFactory
            //get file actual path
            string filePath = Common.GetFilePath(fileName);
            ExtractorFactory factory = new ExtractorFactory(null, new CellsMediaTypeDetector());
            using (Container container = factory.CreateContainer(filePath))
            {
                if (container == null)
                {
                    Console.WriteLine("The document format is not supported");
                }
            }
            //ExEnd:CreatingContainerUsingExtractorFactory
        }

        /// <summary>
        /// Shows how a conatiner is created using ExtractFactory
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractorFactoryCreateFormattedExtractor(string fileName)
        {
            //ExStart:ExtractorFactoryCreateFormattedExtractor
            //get file actual path
            string filePath = Common.GetFilePath(fileName);
            ExtractorFactory factory = new ExtractorFactory(new MarkdownDocumentFormatter());
            using (TextExtractor extractor = factory.CreateFormattedTextExtractor(fileName))
            {
                Console.WriteLine(extractor != null ? extractor.ExtractAll() : "The document format is not supported");
            }
            //ExEnd:ExtractorFactoryCreateFormattedExtractor
        }

        /// <summary>
        /// Extracts highight from a document
        /// </summary>
        public static void ExtractHighlight(string fileName)
        {
            //ExStart:ExtractHighlight
            //get file path
            string filePath = Common.GetFilePath(fileName);
            //initialize words text extractor
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                //extract hightlights from the document
                IList<string> highlights = extractor.ExtractHighlights(
                //set highlight options to get fixed length text from the highlighted portion

                //From version 17.9.0 onwards,CreateFixedLength method has been marked obsolete
                //Use HighlightOptions.CreateFixedLengthOptions static method instead of HighlightOptions.CreateFixedLength
                //HighlightOptions.CreateFixedLength(HighlightDirection.Left, 15, 10),
                //HighlightOptions.CreateFixedLength(HighlightDirection.Right, 20, 10));

                HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 15, 10),
                HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 20, 10));

                //write the result on console
                for (int i = 0; i < highlights.Count; i++)
                {
                    Console.WriteLine(highlights[i]);
                }
            }
            //ExEnd:ExtractHighlight
        }

        /// <summary>
        /// Shows highlight extraction with defined words from the position
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="wordsCount">count of words from the position from where to extract highlight</param>
        public static void ExtractHighlightWithLimitedWordsCount(string fileName, int wordsCount)
        {
            //ExStart:ExtractHighlightWithLimitedWordsCount
            //get file path
            string filePath = Common.GetFilePath(fileName);
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                IList<string> highlights = extractor.ExtractHighlights(
                  HighlightOptions.CreateWordsCountOptions(HighlightDirection.Left, 15, wordsCount),
                  HighlightOptions.CreateWordsCountOptions(HighlightDirection.Right, 20, wordsCount));

                for (int i = 0; i < highlights.Count; i++)
                {
                    Console.WriteLine(highlights[i]);
                }
            }
            //ExEnd:ExtractHighlightWithLimitedWordsCount
        }

        /// <summary>
        /// Extracts highlight to the start or end of line
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractHighlightTillStartOrEndOfLine(string fileName)
        {
            //ExStart:ExtractHighlightTillStartOrEndOfLine
            //get file path
            string filePath = Common.GetFilePath(fileName);
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                IList<string> highlights = extractor.ExtractHighlights(
                  HighlightOptions.CreateLineOptions(HighlightDirection.Left, 15),
                  HighlightOptions.CreateLineOptions(HighlightDirection.Right, 20));

                for (int i = 0; i < highlights.Count; i++)
                {
                    Console.WriteLine(highlights[i]);
                }
            }
            //ExEnd:ExtractHighlightTillStartOrEndOfLine
        }

        /// <summary>
        /// Searches text in documents.
        /// </summary>
        /// <param name="fileName">the name of the file to searrch text from</param>
        public static void SearchTextInDocuments(string fileName)
        {
            //ExStart:SearchTextInDocuments
            //get file actual path
            string filePath = Common.GetFilePath(fileName);
            //initialize words text extractor
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                //initialize search handler
                ListSearchHandler handler = new ListSearchHandler();
                //search for the text
                //From version 17.9.0 onwards,SearchHighlightOptions constructor has been marked obsolete
                //Use SearchHighlightOptions.CreateFixedLengthOptions static methods instead of the constructor

                //extractor.Search(new SearchOptions(new SearchHighlightOptions(10)), handler, null, new string[] { "test text", "keyword" });

                extractor.Search(new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(10)), handler, null, new string[] { "Butterfly", "test text", "keyword" });

                //Results count is none
                if (handler.List.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    //loop through the list and display the results
                    for (int i = 0; i < handler.List.Count; i++)
                    {
                        Console.Write(handler.List[i].LeftText);
                        Console.Write("_");
                        Console.Write(handler.List[i].FoundText);
                        Console.Write("_");
                        Console.Write(handler.List[i].RightText);
                        Console.WriteLine("---");
                    }
                }
            }
            //ExEnd:SearchTextInDocuments
        }

        /// <summary>
        /// Searches whole word in documents.
        /// </summary>
        /// <param name="fileName"></param>
        public static void SearchWholeWord(string fileName)
        {
            //ExStart:SearchWholeWord
            //get file path
            string filePath = Common.GetFilePath(fileName);
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                SearchOptions searchOptions = new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(15), true, true);
                ListSearchHandler handler = new ListSearchHandler();
                extractor.Search(searchOptions, handler, null, new string[] { "mark", "down" });

                if (handler.List.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    for (int i = 0; i < handler.List.Count; i++)
                    {
                        Console.Write(handler.List[i].LeftText);
                        Console.Write("_");
                        Console.Write(handler.List[i].FoundText);
                        Console.Write("_");
                        Console.Write(handler.List[i].RightText);
                        Console.WriteLine("---");
                    }
                }
            }
            //ExEnd:SearchWholeWord
        }

        /// <summary>
        /// Search text in documents using regular expression
        /// </summary>
        /// <param name="fileName"></param>
        public static void SearchTextWithRegex(string fileName)
        {
            //ExStart:SearchTextWithRegex
            //get file path
            string filePath = Common.GetFilePath(fileName);
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                ListSearchHandler handler = new ListSearchHandler();
                extractor.SearchWithRegex("19[0-9]{2}", handler, new RegexSearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(10)));

                if (handler.List.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    for (int i = 0; i < handler.List.Count; i++)
                    {
                        Console.Write(handler.List[i].LeftText);
                        Console.Write("_");
                        Console.Write(handler.List[i].FoundText);
                        Console.Write("_");
                        Console.Write(handler.List[i].RightText);
                        Console.WriteLine("---");
                    }
                }
            }
            //ExEnd:SearchTextWithRegex
        }

        /// <summary>
        /// Shows searching a text with highlights limited by line's start/end
        /// </summary>
        /// <param name="fileName"></param>
        public static void UseExtractionModesWithSearch(string fileName)
        {
            //ExStart:UseExtractionModesWithSearch
            //get file path
            string filePath = Common.GetFilePath(fileName);
            using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
            {
                ListSearchHandler handler = new ListSearchHandler();
                SearchHighlightOptions highlightOptions = SearchHighlightOptions.CreateLineOptions(100, 100);
                extractor.Search(new SearchOptions(highlightOptions), handler, null, new string[] { "text", "extraction" });

                if (handler.List.Count == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    for (int i = 0; i < handler.List.Count; i++)
                    {
                        Console.Write(handler.List[i].LeftText);
                        Console.Write("_");
                        Console.Write(handler.List[i].FoundText);
                        Console.Write("_");
                        Console.Write(handler.List[i].RightText);
                        Console.WriteLine("---");
                    }
                }
            }
            //ExEnd:UseExtractionModesWithSearch
        }

        /// <summary>
        /// Detects any supported media type using CompositeMediaTypeDetector class
        /// </summary>
        /// <param name="fileName"></param>
        public static void MediaTypeDetection(string fileName)
        {
            //ExStart:MediaTypeDetection
            //get file actual path
            String filePath = Common.GetFilePath(fileName);
            var mediaType = CompositeMediaTypeDetector.Default.Detect(filePath);
            Console.WriteLine(mediaType);
            //ExEnd:MediaTypeDetection
        }

        /// <summary>
        /// Shows how to extract formatted highlights from documents.
        /// Feature is supported by version 17.06 or greater
        /// Supports all formats i-e Word,Epub,Slides,Cells,Email and fb2 docs
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractFormattedHighlights(string fileName)
        {
            //ExStart:ExtractFormattedHighlights
            //get file actual path
            String filePath = Common.GetFilePath(fileName);
            using (WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath))
            {
                IList<string> highlights = extractor.ExtractHighlights(
                HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 15, 10),
                HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 20, 10));

                for (int i = 0; i < highlights.Count; i++)
                {
                    Console.WriteLine(highlights[i]);
                }
            }
            //ExEnd:ExtractFormattedHighlights
        }

        /// <summary>
        /// Shows how to implement IPageExtractor
        ///Feature supported in version 17.07 or greater
        /// </summary>
        /// <param name="fileName"></param>
        public static void ImplementIpageExtractorInterface(string fileName)
        {
            //ExStart:ImplementIpageExtractorInterface_17.12
            string filePath = Common.GetFilePath(fileName);
            // Create an extractor factory 
            var factory = new ExtractorFactory();
            // Create an instance of text extractor class 
            using (var extractor = factory.CreateTextExtractor(filePath))
            {
                // Check if IPageTextExtractor is supported   
                var pageTextExtractor = extractor as IPageTextExtractor;
                if (pageTextExtractor != null)
                {
                    // Iterate over all pages     
                    for (var i = 0; i < pageTextExtractor.PageCount; i++)
                    {
                        // Print a page number       
                        Console.WriteLine(string.Format("{0}/{1}", i, pageTextExtractor.PageCount));
                        // Extract a text from the page       
                        Console.WriteLine(pageTextExtractor.ExtractPage(i));
                    }
                }
            }
            //ExEnd:ImplementIpageExtractorInterface_17.12
        }

        /// <summary>
        /// Shows how to use ITextExtractorWithFormatter interface 
        /// </summary>
        /// <param name="fileName"></param>
        public static void UsingITextExtractorWithFormatterInterface(string fileName)
        {
            //ExStart:UsingITextExtractorWithFormatterInterface_17.12
            string filePath = Common.GetFilePath(fileName);

            WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);

            // If the extractor supports ITextExtractorWithFormatter interface
            if (extractor is ITextExtractorWithFormatter)
            {
                // Set MarkdownDocumentFormatter formatter
                (extractor as ITextExtractorWithFormatter).DocumentFormatter = new MarkdownDocumentFormatter();

            }
            Console.WriteLine(extractor.ExtractAll());
            //ExEnd:UsingITextExtractorWithFormatterInterface_17.12
        }

        /// <summary>
        /// Extracts a text from a file or stream via a simple interface
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractTextUsingSimpleInterface(string fileName)
        {
            //ExStart:ExtractTextUsingSimpleInterface_17.12
            string filePath = Common.GetFilePath(fileName);

            // Extract a text from the stream
            using (Stream stream = File.OpenRead(filePath))
            {
                Console.WriteLine(Extractor.Default.ExtractText(stream));
            }
            // Extract a text from the file
            Console.WriteLine(Extractor.Default.ExtractText(filePath));
            //ExEnd:ExtractTextUsingSimpleInterface_17.12
        }

        /// <summary>
        /// Extracts formatted text from a file or stream via a simple interface
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractFormattedTextUsingSimpleInterface(string fileName)
        {
            //ExStart:ExtractFormattedTextUsingSimpleInterface_17.12
            string filePath = Common.GetFilePath(fileName);

            // Extract a text from the stream
            using (Stream stream = File.OpenRead(filePath))
            {
                Console.WriteLine(Extractor.Default.ExtractFormattedText(stream));
            }
            // Extract a text from the file
            Console.WriteLine(Extractor.Default.ExtractFormattedText(filePath));
            //ExEnd:ExtractFormattedTextUsingSimpleInterface_17.12
        }

        /// <summary>
        /// Extracts a text from a file or stream using LoadOptions via a simple interface
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractTextUsingSimpleInterfaceAndLoadOptions(string fileName)
        {
            //ExStart:ExtractTextUsingSimpleInterfaceAndLoadOptions_17.12
            string filePath = Common.GetFilePath(fileName);

            // Create load options
            LoadOptions loadOptions = new LoadOptions(MediaTypeNames.Application.WordOpenXml);

            // Extract a text from the stream
            using (Stream stream = File.OpenRead(filePath))
            {
                Console.WriteLine(Extractor.Default.ExtractText(stream, loadOptions));
            }
            // Extract a text from the file
            Console.WriteLine(Extractor.Default.ExtractText(filePath, loadOptions));
            //ExEnd:ExtractTextUsingSimpleInterfaceAndLoadOptions_17.12
        }

        /// <summary>
        /// Extracts formatted text from a file or stream using LoadOptions via a simple interface
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractFormattedTextUsingSimpleInterfaceAndLoadOptions(string fileName)
        {
            //ExStart:ExtractFormattedTextUsingSimpleInterfaceAndLoadOptions_17.12
            string filePath = Common.GetFilePath(fileName);

            // Create load options
            LoadOptions loadOptions = new LoadOptions(MediaTypeNames.Application.WordOpenXml);

            // Extract a text from the stream
            using (Stream stream = File.OpenRead(filePath))
            {
                Console.WriteLine(Extractor.Default.ExtractFormattedText(stream, loadOptions));
            }
            // Extract a text from the file
            Console.WriteLine(Extractor.Default.ExtractFormattedText(filePath, loadOptions));
            //ExEnd:ExtractFormattedTextUsingSimpleInterfaceAndLoadOptions_17.12
        }

        /// <summary>
        /// Uses default instance of Extractor class for text extraction
        /// </summary>
        /// <param name="fileName"></param>
        public static void UseDefaultInstanceOfExtractorClassForTextExtraction(string fileName)
        {
            //ExStart:UseDefaultInstanceOfExtractorClass_17.12
            string filePath = Common.GetFilePath(fileName);
            // Extract a text from the stream
            using (Stream stream = File.OpenRead(filePath))
            {
                // Create an instance of Extractor
                Extractor extractor = new Extractor(null, null, null);
                // Extract a text from the stream
                Console.WriteLine(extractor.ExtractText(stream));
            }
            //ExEnd:UseDefaultInstanceOfExtractorClass_17.12
        }

        /// <summary>
        /// Uses default instance of Extractor class for formatted text extraction
        /// </summary>
        /// <param name="fileName"></param>
        public static void UseDefaultInstanceOfExtractorClassForformattedTextExtraction(string fileName)
        {
            //ExStart:UseDefaultInstanceOfExtractorClassForFormattedTextExtraction_17.12
            string filePath = Common.GetFilePath(fileName);
            // Extract a text from the stream
            using (Stream stream = File.OpenRead(filePath))
            {
                // Create an instance of Extractor
                Extractor extractor = new Extractor(null, null, null, new MarkdownDocumentFormatter());
                // Extract a text from the stream
                Console.WriteLine(extractor.ExtractFormattedText(stream));
            }
            //ExEnd:UseDefaultInstanceOfExtractorClassForFormattedTextExtraction_17.12
        }

        /// <summary>
        /// Extracts a text from a file or stream using extract mode
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractTextUsingExtractMode(string fileName)
        {
            //ExStart:ExtractTextUsingExtractMode_18.5
            string filePath = Common.GetFilePath(fileName);

            // Create a text extractor
            CellsTextExtractor extractor = new CellsTextExtractor(filePath);
            
            // Set ExtractMode for the faster text extraction
            extractor.ExtractMode = ExtractMode.Simple;
            
            // Extract text
            Console.WriteLine(extractor.ExtractAll());
            //ExEnd:ExtractTextUsingExtractMode_18.5
        }

        

    }
}
