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
        public static void ExtractFromOstContainer()
        {
            //ExStart:ExtractFromOstContainer
            ExtractorFactory factory = new ExtractorFactory();
            using (var container = new PersonalStorageContainer("default.ost"))
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
    }
}
