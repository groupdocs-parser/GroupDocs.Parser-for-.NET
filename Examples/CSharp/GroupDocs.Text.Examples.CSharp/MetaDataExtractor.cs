using GroupDocs.Text;
using GroupDocs.Text.Extractors.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    public class MetaDataExtractor
    {
        public class CellsMetadata
        {
            /// <summary>
            /// Extract metadata from cells
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromCells(string fileName)
            {
                //ExStart:ExtractMetadataFromCells
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                CellsMetadataExtractor extractor = new CellsMetadataExtractor();
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFromCells
            }
        }

        public class SlidesMetadata
        {
            /// <summary>
            /// Extract metadata from slides
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromSlides(string fileName)
            {
                //ExStart:ExtractMetadataFromSlides
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                SlidesMetadataExtractor extractor = new SlidesMetadataExtractor();
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFromSlides
            }
        }

        public class WordsMetaData
        {
            /// <summary>
            /// Extract metadata from word documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromWords(string fileName)
            {
                //ExStart:ExtractMetadataFromWords
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                WordsMetadataExtractor extractor = new WordsMetadataExtractor();
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFromWords
            }
        }

        public class PdfMetaData
        {
            /// <summary>
            /// Extract metadata from pdf documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromPdf(string fileName)
            {
                //ExStart:ExtractMetadataFromPdf
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                PdfMetadataExtractor extractor = new PdfMetadataExtractor();
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFromPdf
            }
        }

        public class EmailMetaData
        {
            /// <summary>
            /// Extract metadata from emails
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromEmails(string fileName)
            {
                //ExStart:ExtractMetadataFromEmails
                //get file actual path
                String filePath = Utilities.getFilePath(fileName);
                EmailMetadataExtractor extractor = new EmailMetadataExtractor();
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFromEmails
            }
        }

        public static void UsingExtractorFactory(string fileName)
        {
            //ExStart:UsingExtractorFactory
            //get file actual path
            String filePath = Utilities.getFilePath(fileName);
            ExtractorFactory factory = new ExtractorFactory();
            MetadataCollection metadata = factory.ExtractMetadata(filePath);
            if (metadata == null)
            {
                Console.WriteLine("The document format is not supported");
            }

            foreach (string key in metadata.Keys)
            {
                Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
            }
            //ExEnd:UsingExtractorFactory
        }
    }
}
