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
            if (args.Length != 5)
            {
                Console.WriteLine("Command line arguments: ");
                Console.WriteLine("\tLicense file path");
                Console.WriteLine("\tDocument file path");
                Console.WriteLine("\tTemplate file path");
                Console.WriteLine("\tOutput file path");
                Console.WriteLine("\tUse OCR");
                Environment.Exit(5);
            }

            var licensePath = args[0];
            var documentPath = args[1];
            var templatePath = args[2];
            var outputPath = args[3];
            bool useOcr = bool.Parse(args[4]);
            Console.WriteLine("License file path: " + licensePath);
            Console.WriteLine("Document file path: " + documentPath);
            Console.WriteLine("Template file path: " + templatePath);
            Console.WriteLine("Output file path: " + outputPath);
            Console.WriteLine("Use OCR: " + useOcr);
            Console.WriteLine();

            var template = Template.Load(templatePath);
            var stringBuilder = new StringBuilder();

            Console.WriteLine("Setting the license");
            new License().SetLicense(licensePath);
            Console.WriteLine("The license is set");
            Console.WriteLine();

            Console.WriteLine("Parsing the template");
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
            Console.WriteLine("All done");
        }
    }
}
