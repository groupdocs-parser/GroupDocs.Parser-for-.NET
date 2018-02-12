using GroupDocs.Text;
using GroupDocs.Text.Extractors.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    public class MetadataExtractor
    {
        public class CellsMetadata
        {
            /// <summary>
            /// Extracts metadata from cells
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromCells(string fileName)
            {
                //ExStart:ExtractMetadataFromCells
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
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
            /// Extracts metadata from slides
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromSlides(string fileName)
            {
                //ExStart:ExtractMetadataFromSlides
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
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
            /// Extracts metadata from word documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromWords(string fileName)
            {
                //ExStart:ExtractMetadataFromWords
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
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
            /// Extracts metadata from pdf documents
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromPdf(string fileName)
            {
                //ExStart:ExtractMetadataFromPdf
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
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
            /// Extracts metadata from emails
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataFromEmails(string fileName)
            {
                //ExStart:ExtractMetadataFromEmails
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                EmailMetadataExtractor extractor = new EmailMetadataExtractor();
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFromEmails
            }
        }

        public class EpubMetaData
        {
            /// <summary>
            /// Extracts metadata from an epub file
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadata(string fileName)
            {
                //ExStart:ExtractMetadataInEpub
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                var metadataExtractor = new EpubMetadataExtractor();
                var metadata = metadataExtractor.ExtractMetadata(filePath);
                foreach (string key in metadata.Keys)
                {
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataInEpub
            }

            /// <summary>
            /// Extracts metadata using complex metadata extractor class
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadataUsingComplexMetadataExtractor(string fileName)
            {
                //ExStart:ExtractMetadataUsingComplexMetadataExtractorInEpub
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                var metadataExtractor = new EpubMetadataExtractor();
                using (var enumerator = metadataExtractor.ExtractComplexMetadata(filePath))
                {
                    while (enumerator.MoveNext())
                    {
                        var metadata = enumerator.Current;
                        foreach (string key in metadata.Keys)
                        {
                            Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                        }
                    }
                }
                //ExEnd:ExtractMetadataUsingComplexMetadataExtractorInEpub
            }
        }

        public class Fb2Metadata {
            /// <summary>
            /// Shows how to extract metadata from fb2 files
            /// Feature is supported in version 17.05 or greater
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractMetadata(string fileName) {
                //ExStart:ExtractMetadataFb2
                //get file's actual path
                String filePath = Common.GetFilePath(fileName);
                // Create a metadata extractor 
                FictionBookMetadataExtractor extractor = new FictionBookMetadataExtractor();
                // Extract metadata
                MetadataCollection metadata = extractor.ExtractMetadata(filePath);
                // Iterate metadata values 
                foreach (string key in metadata.Keys)
                {
                    // Print a metadata key/value pair to the console    
                    Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
                }
                //ExEnd:ExtractMetadataFb2
            }
        }

        public static void UsingExtractorFactory(string fileName)
        {
            //ExStart:UsingExtractorFactory
            //get file actual path
            String filePath = Common.GetFilePath(fileName);
            Extractor extractor = new Extractor();
            //ExtractMetadata methods in ExtractorFactory class are marked as Obsolete from version 17.03 onwards(use Extractor class instead).
            MetadataCollection metadata = extractor.ExtractMetadata(filePath);
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

        /// <summary>
        /// Shows how extractor class is used to extract metadata, this feature is supported ni version 17.03 or greater
        /// </summary>
        /// <param name="fileName"></param>
        public static void ExtractClassUsage(string fileName)
        {
            //ExStart:ExtractClassUsage
            //get file actual path
            String filePath = Common.GetFilePath(fileName);
            var extractor = new Extractor();
            var metadata = extractor.ExtractMetadata(filePath);

            foreach (string key in metadata.Keys)
            {
                Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
            }
            //ExEnd:ExtractClassUsage
        }

        /// <summary>
        /// Shows the usage of CreateMetadataExtractor method, the method is supported in version 17.03 or greater
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreateMetadataExtractorMethodUsage(string fileName)
        {
            //ExStart:CreateMetadataExtractorMethodUsage
            //get file actual path
            String filePath = Common.GetFilePath(fileName);
            var factory = new ExtractorFactory();
            var extractor = factory.CreateMetadataExtractor(filePath);
            var metadata = extractor.ExtractMetadata(filePath);

            foreach (string key in metadata.Keys)
            {
                Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
            }
            //ExEnd:CreateMetadataExtractorMethodUsage
        }
    }
}
