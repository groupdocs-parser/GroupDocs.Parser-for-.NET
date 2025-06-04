using GroupDocs.Parser.Data;
using GroupDocs.Parser.Options;
using GroupDocs.Parser.Templates;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Parser.TextExtractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Command line arguments: ");
                Console.WriteLine("\tDocument file path");
                Console.WriteLine("\tTemplate file path");
                Console.WriteLine("\tOutput file path");
                Console.WriteLine("\tUse OCR");
                Environment.Exit(5);
            }

            var documentPath = args[0];
            var templatePath = args[1];
            var outputPath = args[2];
            bool useOcr = bool.Parse(args[3]);
            Console.WriteLine("Document file path: " + documentPath);
            Console.WriteLine("Template file path: " + templatePath);
            Console.WriteLine("Output file path: " + outputPath);
            Console.WriteLine("Use OCR: " + useOcr);

            var template = Template.Load(templatePath);
            var stringBuilder = new StringBuilder();
            using (Parser parser = new Parser(documentPath))
            {
                var options = new ParseByTemplateOptions(useOcr);
                var data = parser.ParseByTemplate(template, options);

                for (int i = 0; i < data.Count; i++)
                {
                    var fieldData = data[i];
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine(fieldData.Name);
                    var pageArea = fieldData.PageArea;
                    if (pageArea is PageTextArea)
                    {
                        var pageTextArea = (PageTextArea)pageArea;
                        stringBuilder.AppendLine(pageTextArea.Text);
                    }
                    else if (pageArea is PageTableArea)
                    {
                        var pageTableArea = (PageTableArea)pageArea;
                        var text = string.Join('\t', pageTableArea.Cells.Select(c => c.Text));
                        stringBuilder.AppendLine(text);
                    }
                    else if (pageArea is PageBarcodeArea)
                    {
                        var pageBarcodeArea = (PageBarcodeArea)pageArea;
                        stringBuilder.AppendLine(pageBarcodeArea.Value);
                    }
                }
            }

            File.WriteAllText(outputPath, stringBuilder.ToString());
        }
    }
}
