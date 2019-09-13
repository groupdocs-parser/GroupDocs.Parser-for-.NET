// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage.ExtractContainersAndAttachments
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract attachments from a container.
    /// </summary>
    static class ExtractAttachmentList
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleZip))
            {
                // Extract attachments from the container
                IEnumerable<ContainerItem> attachments = parser.GetContainer();
                // Check if container extraction is supported
                if (attachments == null)
                {
                    Console.WriteLine("Container extraction isn't supported");
                }

                // Iterate over attachments
                foreach (ContainerItem item in attachments)
                {
                    // Print an item name and size
                    Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Size));
                }
            }
        }
    }
}
