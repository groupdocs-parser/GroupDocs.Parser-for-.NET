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

namespace GroupDocs.Text.FrontEnd.Controllers
{
    /// <summary>
    /// Methods to handle cells format documents
    /// </summary>
    /// 
    [System.Web.Http.RoutePrefix("Cells")]
    public class CellsController : Controller
    {

        /// <summary>
        /// Action Method to extract text from a row in cell
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="rowIndex"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractRow")]
        public ActionResult ExtractRow([FromBody] string fileName, [FromBody] int rowIndex)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                extractedText.Add(sheetInfo.ExtractRow(rowIndex));
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Action Method to extract text from a row in cell
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="columnIndex"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractColumn")]
        public ActionResult ExtractColumn([FromBody] string fileName, [FromBody] string columnIndex)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                extractedText.Add(sheetInfo.ExtractSheet(columnIndex));
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Action Method to extract text from a row in cell
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtractRowAndColumn")]
        public ActionResult ExtractRowAndColumn([FromBody] string fileName, [FromBody] int rowIndex, [FromBody] string columnIndex)
        {
            List<string> extractedText = new List<string>();
            ExtractorFactory factory = new ExtractorFactory();
            string filePath = Server.MapPath("../App_Data//Uploads//" + fileName);
            try
            {
                CellsTextExtractor extractor = new CellsTextExtractor(filePath);
                int sheetIndex = 0;
                CellsSheetInfo sheetInfo = extractor.GetSheetInfo(sheetIndex);
                extractedText.Add(sheetInfo.ExtractRow(rowIndex,columnIndex));
            }
            catch (Exception ex)
            {
                extractedText.Add(ex.Message);
            }
            return Json(extractedText, JsonRequestBehavior.AllowGet);

        }
    }
}