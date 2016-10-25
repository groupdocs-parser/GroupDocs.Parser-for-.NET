using GroupDocs.Text;
using GroupDocs.Text.Extractors.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    public class OtherOperations
    {
        /// <summary>
        /// Create the concrete extractor by hand
        /// </summary>
        /// <param name="fileName"></param>
        public static void ConcreteExtractor(string fileName)
        {
            //ExStart:ConcreteExtractor
            //get file actual path
            string filePath = Common.getFilePath(fileName);
            using (Stream stream = File.OpenRead(filePath))
            {
                using (CellsTextExtractor extractor = new CellsTextExtractor(stream))
                {
                    Console.WriteLine(extractor.ExtractAll());
                }
            }
            //ExEnd:ConcreteExtractor
        }

        /// <summary>
        /// Extract all from cells
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractAllFromCells(string fileName)
        {
            //ExStart:ExtractAllFromCells
            //get file actual path
            string filePath = Common.getFilePath(fileName);
            using (CellsTextExtractor extractor = new CellsTextExtractor(filePath))
            {
                Console.WriteLine(extractor.ExtractAll());
            }
            //ExEnd:ExtractAllFromCells
        }

        public static void PassEncodingToCreatedExtractor(string fileName)
        {
            //ExStart:PassEncodingToCreatedExtractor
            //get file actual path
            string filePath = Common.getFilePath(fileName);
            LoadOptions loadOptions = new LoadOptions("text/plain", Encoding.UTF8);
            ExtractorFactory factory = new ExtractorFactory();
            using (TextExtractor extractor = factory.CreateTextExtractor(filePath, loadOptions))
            {
                Console.WriteLine(extractor != null ? extractor.ExtractAll() : "The document format is not supported");
            }
            //ExEnd:PassEncodingToCreatedExtractor
        }
    }
}
