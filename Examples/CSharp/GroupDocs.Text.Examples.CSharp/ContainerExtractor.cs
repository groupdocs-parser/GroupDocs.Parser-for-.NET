using GroupDocs.Text;
using GroupDocs.Text.Containers;
using GroupDocs.Text.Detectors.MediaType;
using GroupDocs.Text.Extractors.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    public class ContainerExtractor
    {
        /// <summary>
        /// Extract from OST container
        /// </summary>
        public static void ExtractFromOstContainer(string fileName)
        {
            //ExStart:ExtractFromOstContainer
            ExtractorFactory factory = new ExtractorFactory();
            //get OST file's path
            string filePath = Common.getFilePath(fileName);
            using (var container = new PersonalStorageContainer(filePath))
            {
                for (int i = 0; i < container.Entities.Count; i++)
                {
                    Console.WriteLine(container.Entities[i].Name);
                    Console.WriteLine(container.Entities[i].Path.ToString());
                    Console.WriteLine(container.Entities[i].MediaType);
                    Console.WriteLine(container.Entities[i][PersonalStorageContainer.EmailSubject]);
                    Console.WriteLine(container.Entities[i][PersonalStorageContainer.EmailSender]);
                    Console.WriteLine(container.Entities[i][PersonalStorageContainer.EmailReceiver]);

                    using (TextExtractor extractor = factory.CreateTextExtractor(container.Entities[i].OpenStream()))
                    {
                        Console.WriteLine("Content:");
                        Console.WriteLine(extractor != null ? extractor.ExtractAll() : "The document format is not supported");
                    }
                }
            }
            //ExEnd:ExtractFromOstContainer
        }

        /// <summary>
        /// For enumerating all the entities of the group of containers ContainerEnumerator class is used
        /// </summary>
        public static void EnumeratingAllEntities()
        {
            //ExStart:EnumeratingAllEntities
            IContainerFactory containerFactory = null;
            MediaTypeDetector containerMediaTypeDetector = null;
            Container container = null;
            ExtractorFactory readerFactory = new ExtractorFactory();
            var enumerator = new ContainerEnumerator(containerFactory, containerMediaTypeDetector, container);
            while (enumerator.MoveNext())
            {
                using (var stream = enumerator.Current.OpenStream())
                {
                    using (var extractor = readerFactory.CreateTextExtractor(stream))
                    {
                        Console.WriteLine(extractor == null ? "document isn't supported" : extractor.ExtractAll());
                    }
                }
            }
            //ExEnd:EnumeratingAllEntities
        }

        /// <summary>
        /// Enumerates all files in an archived folder
        /// </summary>
        /// <param name="folderName">name of the zip archive</param>
        public static void EnumerateAllArchivedFiles(string folderName)
        {
            //ExStart:EnumerateAllArchivedFiles
            //get ZIP folder's path
            string folderPath = Common.getFilePath(folderName);

            //initialize ZIP container
            using (var container = new ZipContainer(folderPath))
            {
                //loop through all the entities in the folder
                for (int i = 0; i < container.Entities.Count; i++)
                {
                    //display each entity's information
                    Console.WriteLine("Name: " + container.Entities[i].Name);
                    Console.WriteLine("Path: " + container.Entities[i].Path.ToString());
                    Console.WriteLine("Media type: " + container.Entities[i].MediaType);
                }
            }
            //ExEnd:EnumerateAllArchivedFiles
        }

        /// <summary>
        /// Reads concrete files from a ZIP folder
        /// </summary>
        /// <param name="folderName">Name of the zipped folder</param>
        public static void ReadConcreteFile(string folderName)
        {
            //ExStart:ReadConcreteFile
            //get ZIP folder's path
            string folderPath = Common.getFilePath(folderName);
            ExtractorFactory extractorFactory = new ExtractorFactory();

            //initialize ZIP container
            using (var container = new ZipContainer(folderPath))
            {
                //loop through all the entities in the folder
                for (int i = 0; i < container.Entities.Count; i++)
                {
                    //extract content of each entity by creating a textextractor using extractfactory's CreateTextExtractor function
                    using (TextExtractor extractor = extractorFactory.CreateTextExtractor(container.Entities[i].OpenStream()))
                    {
                        //display the extracted text
                        Console.WriteLine(extractor.ExtractAll());
                    }
                }
            }
            //ExEnd:ReadConcreteFile
        }
    }
}
