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
    /// This example shows how to get basic document info.
    /// </summary>
    static class GetDocumentInfo
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleDocx))
            {
                // Get the document info
                IDocumentInfo info = parser.GetDocumentInfo();

                // Print document information
                Console.WriteLine(string.Format("FileType: {0}", info.FileType));
                Console.WriteLine(string.Format("PageCount: {0}", info.PageCount));
                Console.WriteLine(string.Format("Size: {0}", info.Size));
            }
        }
    }
}
