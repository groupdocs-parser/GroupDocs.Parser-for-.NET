// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to print all the supported file types.
    /// </summary>
    static class GetSupportedFileFormats
    {
        public static void Run()
        {
            // Get a collection of supported file formats
            IEnumerable<FileType> supportedFileTypes = FileType.GetSupportedFileTypes();

            // Iterate over collection and print file format information
            foreach (FileType fileType in supportedFileTypes)
            {
                Console.WriteLine(fileType);
            }
        }
    }
}
