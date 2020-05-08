// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Email
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract emails from Exchange Server.
    /// </summary>
    class ExtractEmailsFromRemoveServer
    {
        public static void Run()
        {
            // Create the connection object for Exchange Web Services protocol 
            EmailConnection connection = new EmailEwsConnection(
                "https://outlook.office365.com/ews/exchange.asmx",
                "email@server",
                "password");

            // Create an instance of Parser class to extract emails from the remote server
            using (Parser parser = new Parser(connection))
            {
                // Check if container extraction is supported
                if (!parser.Features.Container)
                {
                    Console.WriteLine("Container extraction isn't supported.");
                    return;
                }

                // Extract email messages from the server
                IEnumerable<ContainerItem> emails = parser.GetContainer();

                // Iterate over attachments
                foreach (ContainerItem item in emails)
                {
                    // Create an instance of Parser class for email message
                    using (Parser emailParser = item.OpenParser())
                    {
                        // Extract the email text
                        using (TextReader reader = emailParser.GetText())
                        {
                            // Print the email text
                            Console.WriteLine(reader == null ? "Text extraction isn't supported." : reader.ReadToEnd());
                        }
                    }
                }
            }
        }
    }
}
