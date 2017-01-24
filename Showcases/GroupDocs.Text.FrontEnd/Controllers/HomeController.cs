using System;
using GroupDocs.Text.Extractors.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GroupDocs.Text.Extractors.Metadata;
using GroupDocs.Text.Formatters.Plain;
using GroupDocs.Text.Formatters.Markdown;
using GroupDocs.Text.Detectors.Encoding;
using System.IO;
using System.Text;

namespace GroupDocs.Text.FrontEnd.Controllers
{
    [System.Web.Http.RoutePrefix("Home")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Action Method to Handle the Upload Functionalty
        /// </summary>
        /// <param name="model"></param>
        [System.Web.Http.HttpPost]
        public ActionResult Upload([FromBody] SubmitModel model)
        {
            try
            {
                string path = Server.MapPath("../App_Data//Uploads//") + model.file.FileName;
                if (!System.IO.File.Exists(path))
                {
                    model.file.SaveAs(path);
                }
               
                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(400);
            }
           

        }
        /// <summary>
        /// Action Method to Handle the Extract Text From Documents
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="password"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractText")]
        public ActionResult ExtractText([FromBody] string fileName, string password = null)
        {
            //ExStart:ExtractText
            ExtractorFactory factory = new ExtractorFactory();
            string path = Server.MapPath("../App_Data//Uploads//"+fileName);
            
           
            List<string> extractedText = new List<string>();
            try
            {
                string line = null;
                if (!string.IsNullOrWhiteSpace(password))
                {
                    LoadOptions loadOptions = new LoadOptions();
                    loadOptions.Password = password;
                    WordsTextExtractor protectedDocument = new WordsTextExtractor(path, loadOptions);

                    
                    do
                    {
                        int lineNumber = 0;
                        do
                        {
                            line = protectedDocument.ExtractLine();
                            lineNumber++;
                            if (line != null)
                            {
                                extractedText.Add(line);
                            }
                        }
                        while (line != null);
                    }
                    while (line != null);
                }
                else
                {
                    TextExtractor extractor = factory.CreateTextExtractor(path);

                    do
                    {
                        int lineNumber = 0;
                        do
                        {
                            line = extractor.ExtractLine();
                            lineNumber++;
                            if (line != null)
                            {
                                extractedText.Add(line);
                            }
                        }
                        while (line != null);
                    }
                    while (line != null);
                }  
                
                //extractedText.Add(extractor.ExtractAll());
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Action Method to Extract Metadata
        /// </summary>
        /// <param name="fileName"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractMetadata")]
        public ActionResult ExtractMetadata([FromBody] string fileName)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string path = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            { 
                MetadataCollection metadata = factory.ExtractMetadata(path);
                if (metadata == null)
                {
                    extractedText.Add("The document format is not supported");
                }

                foreach (string key in metadata.Keys)
                {
                    extractedText.Add(string.Format("{0} = {1}", key, metadata[key]));
                }
         
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Action Method to ExtractTableWithFormat
        /// </summary>
        /// <param name="fileName"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractTableWithFormat")]
        public ActionResult ExtractTableWithFormat([FromBody] string fileName)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                PlainTableFrame frame = new PlainTableFrame(
                    PlainTableFrameAngle.ASCII,
                    PlainTableFrameEdge.ASCII,
                    PlainTableFrameIntersection.ASCII,
                    new PlainTableFrameConfig(true, true, true, false));
                extractor.DocumentFormatter = new PlainDocumentFormatter(frame);
                if (extractor == null)
                {
                    extractedText.Add("The document format is not supported");
                }
                string line = null;
                do
                {
                    int lineNumber = 0;
                    do
                    {
                        line = extractor.ExtractLine();
                        lineNumber++;
                        if (line != null)
                        {
                            extractedText.Add(line);
                        }
                    }
                    while (line != null);
                }
                while (line != null);
                //extractedText.Add(extractor.ExtractAll());
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Action Method to ExtractTextWithMarkDown
        /// </summary>
        /// <param name="fileName"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractTextWithMarkDown")]
        public ActionResult ExtractTextWithMarkDown([FromBody] string fileName)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                WordsFormattedTextExtractor extractor = new WordsFormattedTextExtractor(filePath);
                extractor.DocumentFormatter = new MarkdownDocumentFormatter();
                if (extractor == null)
                {
                    extractedText.Add("The document format is not supported");
                }
                string line = null;
                do
                {
                    int lineNumber = 0;
                    do
                    {
                        line = extractor.ExtractLine();
                        lineNumber++;
                        if (line != null)
                        {
                            extractedText.Add(line);
                        }
                    }
                    while (line != null);
                }
                while (line != null);
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Action Method to ExtractDocumentEndocing
        /// </summary>
        /// <param name="fileName"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractDocumentEndocing")]
        public ActionResult ExtractDocumentEndocing([FromBody] string fileName)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
               
                EncodingDetector detector = new EncodingDetector(Encoding.GetEncoding(1251));
                Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
                extractedText.Add(detector.Detect(stream).ToString());
            }
            catch (Exception ex)
            {
                extractedText.Add("File Format not supported");
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Action Method to CountStatistics
        /// </summary>
        /// <param name="fileName"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("CountStatistics")]
        public ActionResult CountStatistics([FromBody] string fileName)
        {
            List<string> extractedText = new List<string>();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                string[] arguments = new string[] { filePath };

                int maxWordLength = 0;
                for (int i = 0; i < arguments.Length; i++)
                {
                    if (arguments[i].Length == 1 || !int.TryParse(arguments[i], out maxWordLength))
                    {
                        maxWordLength = 5;
                    }
                }
                ExtractorFactory factory = new ExtractorFactory();
                Dictionary<string, int> statistic = new Dictionary<string, int>();

                TextExtractor extractor = factory.CreateTextExtractor(filePath);
                if (extractor == null)
                {
                    extractedText.Add("The document's format is not supported");
                    
                }
                try
                {
                    string line = null;
                    do
                    {
                        line = extractor.ExtractLine();
                        if (line != null)
                        {
                            string[] words = line.Split(' ', ',', ';', '.');
                            foreach (string w in words)
                            {
                                string word = w.Trim().ToLower();
                                if (word.Length > maxWordLength)
                                {
                                    if (!statistic.ContainsKey(word))
                                    {
                                        statistic[word] = 0;
                                    }

                                    statistic[word]++;
                                }
                            }
                        }
                    }
                    while (line != null);
                }
                finally
                {
                    extractor.Dispose();
                }

                extractedText.Add("Top words:");

                for (int i = 0; i < 10; i++)
                {
                    int count = -1;
                    string maxKey = null;
                    foreach (string key in statistic.Keys)
                    {
                        if (statistic[key] > count)
                        {
                            count = statistic[key];
                            maxKey = key;
                        }
                    }

                    if (maxKey == null)
                    {
                        break;
                    }

                    extractedText.Add(maxKey +" : " +count);
                    statistic.Remove(maxKey);
                }
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Model for receiving file 
        /// </summary>
        public class SubmitModel
        {
            public HttpPostedFileBase file { get; set; }     
        }
        /// <summary>
        /// Model for extracted text
        /// </summary>
        public class ExtractedText
        {
            public List<string> lines = null;
        }
    }
}