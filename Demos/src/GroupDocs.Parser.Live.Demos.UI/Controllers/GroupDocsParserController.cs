using System.Web.Http;
using System.Threading.Tasks;
using GroupDocs.Parser.Live.Demos.UI.Models;
using System;
using System.IO;
using GroupDocs.Parser.Extractors.Text;
using GroupDocs.Parser.Extractors.Metadata;
using GroupDocs.Parser.Detectors.Encoding;
using System.Text;
using GroupDocs.Parser.Extractors;
using System.Collections.Generic;

namespace GroupDocs.Parser.Live.Demos.UI.Controllers
{
	public class GroupDocsParserController : ApiControllerBase
	{
        private enum FormatType { Excel, Other };
        private string[] ExcelTypes = { "xls", "xlsx", "csv", "xlsm", "xlsb", "ods", "tsv" };

        private string[] WordTypesForImage = { "doc", "docx", "docm", "rtf", "dot", "dotm", "dotx", "odt" };
        private string[] ExcelTypesForImage = { "xls", "xlsx", "xlsm", "xlsb", "ods", "xlt", "xltm", "xltx" };
        private string[] SlidesTypesForImage = { "ppt", "pptx", "pptm", "odp", "pps", "ppsx", "ppsm" };
        private string[] PdfTypesForImage = { "pdf", "pot", "potm", "potx" };        


        private FormatType GetFormatType(string fileExt)
        {
            FormatType formatType = FormatType.Other;

            if (Array.Exists(ExcelTypes, E => E == fileExt))
            {
                formatType = FormatType.Excel;
            } 

            return formatType;
        }        

        [HttpGet]
		[ActionName("ParseFile")]
		public async Task<Response> ParseFile(string fileName, string folderName, string parseType)
        {
            Response res = null;

            if(parseType == "text")
            {
                res = await ParseFileText(fileName, folderName);
            }
            else if (parseType == "image")
            {
                res = await ParseFileImages(fileName, folderName);
            }

            return res;
        }

        private async Task<Response> ParseFileText(string fileName, string folderName)
        {
			string logMsg = "ControllerName: GroupDocsParserController FileName: " + fileName + " FolderName: " + folderName;
			try
			{								
				return await ProcessTask(fileName, folderName, ".txt", false, "", delegate (string inFilePath, string outPath, string zipOutFolder)
				{                                        
                    EncodingDetector detector = new EncodingDetector(Encoding.GetEncoding(1251));

                    if (!Directory.Exists(zipOutFolder))
                    {
                        Directory.CreateDirectory(zipOutFolder);
                    }

                    using (Stream stream = new FileStream(inFilePath, FileMode.Open)) {                        
                        System.IO.File.WriteAllText(outPath, "Encoding: " + detector.Detect(stream, true) + Environment.NewLine);
                    }

                    ExtractorFactory factory = new ExtractorFactory();
                    MetadataExtractor metadataExtractor = factory.CreateMetadataExtractor(inFilePath);
                    if(metadataExtractor != null)
                    {
                        MetadataCollection metadataCollection = metadataExtractor.ExtractMetadata(inFilePath);

                        System.IO.File.AppendAllText(outPath, Environment.NewLine + "Metadata:" + Environment.NewLine);
                        foreach (string key in metadataCollection.Keys)
                        {                            
                            System.IO.File.AppendAllText(outPath, string.Format("{0} = {1}", key, metadataCollection[key]) + Environment.NewLine);
                        }
                    }

                    System.IO.File.AppendAllText(outPath, Environment.NewLine + "Parsed content:" + Environment.NewLine);
                    
                    string fileExt = Path.GetExtension(fileName).Substring(1).ToLower();
                    if (GetFormatType(fileExt) == FormatType.Excel)
                    {
                        CellsTextExtractor extractor = new CellsTextExtractor(inFilePath);
                        extractor.ExtractMode = ExtractMode.Standard;
                        for (int sheetIndex = 0; sheetIndex < extractor.SheetCount; sheetIndex++)
                        {
                            System.IO.File.AppendAllText(outPath, Environment.NewLine + "Sheet # " + extractor.SheetCount + Environment.NewLine);
                            System.IO.File.AppendAllText(outPath, extractor.ExtractSheet(sheetIndex));                            
                        }
                    }
                    else
                    {
                        TextExtractor textExtractor = factory.CreateFormattedTextExtractor(inFilePath);
                        if (textExtractor == null)
                        {
                            textExtractor = factory.CreateTextExtractor(inFilePath);
                        }
                        System.IO.File.AppendAllText(outPath, textExtractor.ExtractAll());
                    }

                });
			}
			catch (Exception exc)
			{
                return new Response { FileName = fileName, FolderName = folderName, OutputType = "txt", Status = exc.Message, StatusCode = 500, Text = exc.ToString() };
			}
		}

		private async Task<Response> ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, string userEmail, ActionDelegate action)
		{
			try
			{
                return await Process("GroupDocsParserController", fileName, folderName, outFileExtension, createZip, action);
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}

        private IDocumentContentExtractor GetContentExtractor(string inFilePath, string fileExt)
        {
            IDocumentContentExtractor extractor = null;

            if (Array.Exists(WordTypesForImage, E => E == fileExt))
            {
                extractor = new WordsTextExtractor(inFilePath);
            }
            else if (Array.Exists(ExcelTypesForImage, E => E == fileExt))
            {
                extractor = new CellsTextExtractor(inFilePath);
            }
            else if (Array.Exists(SlidesTypesForImage, E => E == fileExt))
            {
                extractor = new SlidesTextExtractor(inFilePath);
            }
            else if (Array.Exists(PdfTypesForImage, E => E == fileExt))
            {
                extractor = new PdfTextExtractor(inFilePath);
            }

            return extractor;
        }

        private async Task<Response> ParseFileImages(string fileName, string folderName)
        {
            string logMsg = "ControllerName: GroupDocsParserController FileName: " + fileName + " FolderName: " + folderName;
            try
            {            
                return await ProcessTask(fileName, folderName, ".jpg", true, "", delegate (string inFilePath, string outPath, string zipOutFolder)
                {
                    if (!Directory.Exists(zipOutFolder))
                    {
                        Directory.CreateDirectory(zipOutFolder);
                    }

                    string fileExt = Path.GetExtension(fileName).Substring(1).ToLower();
                    IDocumentContentExtractor extractor = GetContentExtractor(inFilePath, fileExt);
                    if(extractor == null)
                    {
                        throw new Exception("Unsupported file type for image extraction");
                    }

                    ImageAreaSearchOptions searchOptions = new ImageAreaSearchOptions();
                    searchOptions.Rectangle = new Rectangle(0, 0, 1920, 1080);
                    int pageCount = extractor.DocumentContent.PageCount;                    

                    for (int pageIndex=0; pageIndex < pageCount; pageIndex++) {

                        IList<ImageArea> imageAreas = extractor.DocumentContent.GetImageAreas(pageIndex, searchOptions);

                        if (pageIndex == 0 && imageAreas.Count == 0)
                        {
                            throw new Exception("No images found for extraction");
                        }

                        for (int i = 0; i < imageAreas.Count; i++)
                        {
                            using (Stream fs = System.IO.File.Create(String.Format(zipOutFolder + "/{0}-{1}.jpg", pageIndex+1, i+1)))
                            {
                                CopyStream(imageAreas[i].GetRawStream(), fs);
                            }
                        }
                    }

                });
            }
            catch (Exception exc)
            {
                return new Response { FileName = fileName, FolderName = folderName, OutputType = "zip", Status = exc.Message, StatusCode = 500, Text = exc.ToString() };
            }
        }

        private static void CopyStream(Stream source, Stream dest)
        {
            byte[] buffer = new byte[4096];
            source.Position = 0;

            int r = 0;
            do
            {
                r = source.Read(buffer, 0, buffer.Length);
                if (r > 0)
                {
                    dest.Write(buffer, 0, r);
                }
            }
            while (r > 0);
        }
    }
}