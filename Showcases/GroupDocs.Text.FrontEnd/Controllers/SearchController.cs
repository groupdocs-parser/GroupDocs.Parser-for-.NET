using System;
using GroupDocs.Text.Extractors.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GroupDocs.Text;
using GroupDocs.Text.Formatters.Html;
using Newtonsoft.Json;
using GroupDocs.Text.Extractors.Metadata;
using GroupDocs.Text.Extractors;

namespace GroupDocs.Text.FrontEnd.Controllers
{
    /// <summary>
    /// Methods to handle searching in file
    /// </summary>
    [System.Web.Http.RoutePrefix("Search")]
    public class SearchController : Controller
    {
        /// <summary>
        /// Action Method to extract text from a row in cell
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="keyWord"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("SearchText")]
        public ActionResult SearchText([FromBody] string fileName, [FromBody] string keyWord)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                //ExStart:SearchTextInDocuments
                //get file actual path
              
                using (WordsTextExtractor extractor = new WordsTextExtractor(filePath))
                {
                    ListSearchHandler handler = new ListSearchHandler();
                    extractor.Search(new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(10)), handler, null, new string[] { keyWord });

                    if (handler.List.Count == 0)
                    {
                        Console.WriteLine("Not found");
                    }
                    else
                    {
                        for (int i = 0; i < handler.List.Count; i++)
                        {
                            extractedText.Add("Text at Left: " +  handler.List[i].LeftText);

                            extractedText.Add("Found Text: " +handler.List[i].FoundText);
                            
                            extractedText.Add("Text at Right: " + handler.List[i].RightText);
                            
                        }
                    }
                }
                //ExEnd:SearchTextInDocuments
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
    }
}