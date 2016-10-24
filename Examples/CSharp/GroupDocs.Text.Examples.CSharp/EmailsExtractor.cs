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
    public class EmailsExtractor
    {
        public static void ExtractEmailAttachments(string fileName)
        {
            //ExStart:ExtractEmailAttachments
            //get file actual path
            String filePath = Utilities.getFilePath(fileName);
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
    }
}
