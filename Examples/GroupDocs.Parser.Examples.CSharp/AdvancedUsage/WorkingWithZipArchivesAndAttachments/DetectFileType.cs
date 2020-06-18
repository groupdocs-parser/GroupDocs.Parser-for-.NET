// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithZipArchivesAndAttachments
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to detect file type of container item.
    /// </summary>
    static class DetectFileType
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
                    // Detect the file type
                    Options.FileType fileType = item.DetectFileType(Options.FileTypeDetectionMode.Default);
                    
                    // Print the name and file type
                    Console.WriteLine(string.Format("{0}: {1}", item.Name, fileType));
                }
            }
        }
    }
}
