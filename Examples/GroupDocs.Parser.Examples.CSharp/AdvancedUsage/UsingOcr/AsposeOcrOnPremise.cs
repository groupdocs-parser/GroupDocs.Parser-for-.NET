// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

#if !NETCOREAPP
extern alias OCR;
#endif

namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.UsingOcr
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Aspose.OCR;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;


    /// <summary>
    /// This example shows how to integrate Aspose.OCR on-premise API.
    /// </summary>
    public class AsposeOcrOnPremise : OcrConnectorBase
    {
        static AsposeOcrOnPremise()
        {
            // Set the license for Aspose OCR
            new Aspose.OCR.License().SetLicense(Constants.AsposeOcrLicensePath);
        }

        public override string RecognizeText(Stream imageStream, int pageIndex, OcrOptions options)
        {
            // Create an instance of Aspose OCR API
            AsposeOcr api = new AsposeOcr();

            // Convert the image stream into the memory stream
            using (MemoryStream memoryStream = GetMemoryStream(imageStream))
            {
                // Create an instance of RecognitionSettings
                RecognitionSettings settings = new RecognitionSettings();

#if !NETCOREAPP
                // Check if the rectangle is set
                if (options != null && options.Rectangle != null)
                {
                    List<OCR::Aspose.Drawing.Rectangle> areas = new List<OCR::Aspose.Drawing.Rectangle>();
                    areas.Add(new OCR::Aspose.Drawing.Rectangle(
                        (int)options.Rectangle.Left,
                        (int)options.Rectangle.Top,
                        (int)options.Rectangle.Size.Width,
                        (int)options.Rectangle.Size.Height));

                    // Set recognition areas
                    settings.RecognitionAreas = areas;
                }
#else
                // Check if the rectangle is set
                if (options != null && options.Rectangle != null)
                {
                    List<Aspose.Drawing.Rectangle> areas = new List<Aspose.Drawing.Rectangle>();
                    areas.Add(new Aspose.Drawing.Rectangle(
                        (int)options.Rectangle.Left,
                        (int)options.Rectangle.Top,
                        (int)options.Rectangle.Size.Width,
                        (int)options.Rectangle.Size.Height));

                    // Set recognition areas
                    settings.RecognitionAreas = areas;
                }
#endif

                // Perform the text recognition
                RecognitionResult result = api.RecognizeImage(memoryStream, settings);

                // Check if the handler is set
                if (options != null && options.Handler != null)
                {
                    // Send all recognition warnings
                    options.Handler.OnWarnings(pageIndex, result.Warnings);
                }

                // Return a recognized text
                return result.RecognitionText;
            }
        }

        public override IList<PageTextArea> RecognizeTextAreas(Stream imageStream, int pageIndex, Data.Size pageSize, OcrOptions options)
        {
            // Create an instance of Aspose OCR API
            AsposeOcr api = new AsposeOcr();

            // Convert the image stream into the memory stream
            using (MemoryStream memoryStream = GetMemoryStream(imageStream))
            {
                // Create recognition settings and set detect areas
                RecognitionSettings settings = new RecognitionSettings(detectAreas: true);

#if !NETCOREAPP
                // Check if the rectangle is set
                if (options != null && options.Rectangle != null)
                {
                    List<OCR::Aspose.Drawing.Rectangle> areas = new List<OCR::Aspose.Drawing.Rectangle>();
                    areas.Add(new OCR::Aspose.Drawing.Rectangle(
                        (int)options.Rectangle.Left,
                        (int)options.Rectangle.Top,
                        (int)options.Rectangle.Size.Width,
                        (int)options.Rectangle.Size.Height));

                    // Set recognition areas
                    settings.RecognitionAreas = areas;
                }
#else
                // Check if the rectangle is set
                if (options != null && options.Rectangle != null)
                {
                    List<Aspose.Drawing.Rectangle> areas = new List<Aspose.Drawing.Rectangle>();
                    areas.Add(new Aspose.Drawing.Rectangle(
                        (int)options.Rectangle.Left,
                        (int)options.Rectangle.Top,
                        (int)options.Rectangle.Size.Width,
                        (int)options.Rectangle.Size.Height));

                    // Set recognition areas
                    settings.RecognitionAreas = areas;
                }
#endif

                // Perform the text recognition 
                RecognitionResult r = api.RecognizeImage(memoryStream, settings);

                // Check if the handler is set
                if (options != null && options.Handler != null)
                {
                    // Send all recognition warnings
                    options.Handler.OnWarnings(pageIndex, r.Warnings);
                }

                // Create a page object. The pageIndex parameter represents the page index of the document; for images it's always zero.
                Page page = new Page(pageIndex, pageSize);

                // Combibe rectangle and text collections to produce PageTextArea collection
                return r.RecognitionAreasRectangles
                    .Zip(r.RecognitionAreasText, (rect, text) => new { Rect = rect, Text = text })
                    .Select(x => new PageTextArea(x.Text, page, new Data.Rectangle(x.Rect.Left, x.Rect.Top, x.Rect.Right, x.Rect.Bottom)))
                    .ToList();
            }
        }

        private MemoryStream GetMemoryStream(Stream stream)
        {
            stream.Position = 0;
            if (stream is MemoryStream)
            {
                return stream as MemoryStream;
            }
            else
            {
                MemoryStream m = new MemoryStream();
                stream.CopyTo(m);
                return m;
            }
        }

    }
}
