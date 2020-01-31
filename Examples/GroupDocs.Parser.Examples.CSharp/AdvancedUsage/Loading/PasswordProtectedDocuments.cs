// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.Loading
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Exceptions;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to process password protected documents.
    /// </summary>
    static class PasswordProtectedDocuments
    {
        public static void Run()
        {
            try
            {
                string password = "123456";

                // Create an instance of Parser class with the password:
                using (Parser parser = new Parser(Constants.SamplePassword, new LoadOptions(password)))
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
                // Print the message if the password is incorrect or empty
                Console.WriteLine("Invalid password");
            }
        }
    }
}
