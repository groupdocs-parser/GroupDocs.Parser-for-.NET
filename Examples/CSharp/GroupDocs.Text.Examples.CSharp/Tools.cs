using GroupDocs.Text;
using GroupDocs.Text.Detectors.Encoding;
using GroupDocs.Text.Detectors.MediaType;
using GroupDocs.Text.Extractors.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    public class Tools
    {
        public class EncodingDetection
        {
            /// <summary>
            /// Detects encoding of a filestream when BOM is present
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractEncodingByBOM(string fileName)
            {
                //ExStart:ExtractEncodingByBOM

                try
                {
                    EncodingDetector detector = new EncodingDetector(Encoding.GetEncoding(1251));
                    //get file actual path
                    String filePath = Common.GetFilePath(fileName);
                    Stream stream = new FileStream(filePath, FileMode.Open);
                    Console.WriteLine(detector.Detect(stream));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //ExEnd:ExtractEncodingByBOM
            }

            /// <summary>
            /// Detects encoding from BOM is present or from the content if BOM is not present
            /// </summary>
            /// <param name="fileName"></param>
            public static void ExtractEncodingByContentAndBOM(string fileName)
            {
                //ExStart:ExtractEncodingByContentAndBOM

                try
                {
                    EncodingDetector detector = new EncodingDetector(Encoding.GetEncoding(1251));
                    //get file actual path
                    String filePath = Common.GetFilePath(fileName);
                    Stream stream = new FileStream(filePath, FileMode.Open);
                    Console.WriteLine(detector.Detect(stream, true));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //ExEnd:ExtractEncodingByContentAndBOM
            }
        }

        public class logger
        {
            /// <summary>
            /// Logs messages using NotificationReceiver 
            /// </summary>
            /// <param name="fileName"></param>
            public static void LoggerWithManualExceptionHandling(string fileName)
            {
                //ExStart:LoggerWithManualExceptionHandling
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                var receiver = new NotificationReceiver();
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.NotificationReceiver = receiver;

                try
                {
                    using (var extractor = new CellsTextExtractor(filePath, loadOptions))
                    {
                        Console.WriteLine(extractor.ExtractAll());
                    }
                }
                catch (Exception ex)
                {
                    receiver.ProcessMessage(NotificationMessage.CreateErrorMessage(ex.Message, ex));
                }
                //ExEnd:LoggerWithManualExceptionHandling
            }

            /// <summary>
            /// Logs messages using NotificationReceiver 
            /// </summary>
            /// <param name="fileName"></param>
            public static void LoggerWithExtractorFactory(string fileName)
            {
                //ExStart:LoggerWithExtractorFactory
                //get file actual path
                String filePath = Common.GetFilePath(fileName);
                var receiverForFactory = new NotificationReceiver();
                var factory = new ExtractorFactory(null, null, null, receiverForFactory);

                var receiver = new NotificationReceiver();
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.NotificationReceiver = receiver;

                using (var extractor = new CellsTextExtractor(filePath, loadOptions))
                {
                    Console.WriteLine(extractor.ExtractAll());
                }
                //ExEnd:LoggerWithExtractorFactory
            }
        }



        //ExStart:SimpleLogger
        class NotificationReceiver : INotificationReceiver
        {
            public void ProcessMessage(NotificationMessage message)
            {
                Console.WriteLine(message.Description);
            }
        }
        //ExEnd:SimpleLogger

     
    }

}
