// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Exceptions;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to receive the information via ILogger interface.
    /// </summary>
    static class Logging
    {
        public static void Run()
        {
            try
            {
                // Create an instance of Logger class
                Logger logger = new Logger();

                // Create an instance of Parser class with the parser settings
                using (Parser parser = new Parser(Constants.SamplePassword, null, new ParserSettings(logger)))
                {
                    // Check if text extraction is supported
                    if (!parser.Features.Text)
                    {
                        Console.WriteLine("Text extraction isn't supported.");
                        return;
                    }

                    // Print the document text
                    using (TextReader reader = parser.GetText())
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            catch (InvalidPasswordException)
            {
                ; // Ignore the exception
            }
        }

        private class Logger : ILogger
        {
            public void Error(string message, Exception exception)
            {
                // Print error message
                Console.WriteLine("Error: " + message);
            }

            public void Trace(string message)
            {
                // Print event message
                Console.WriteLine("Event: " + message);
            }

            public void Warning(string message)
            {
                // Print warning message
                Console.WriteLine("Warning: " + message);
            }
        }
    }
}
