// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage
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
    class ExtractEmails
    {
        public static void Run()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("mode = exchange");
            sb.AppendLine("MailboxUri = https://outlook.office365.com/ews/exchange.asmx");
            sb.AppendLine("Username = email@server");
            sb.AppendLine("Password = password");

            // Create an instance of Parser class to extract emails from the remote server
            // As filePath connection parameters are passed; LoadOptions is set to Email file format
            using (Parser parser = new Parser(sb.ToString(), new LoadOptions(FileFormat.Email)))
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
