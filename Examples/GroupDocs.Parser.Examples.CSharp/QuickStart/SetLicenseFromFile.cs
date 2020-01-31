// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.QuickStart
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This example demonstrates how to set license from file.
    /// </summary>
    /// <remarks>
    /// The SetLicense method attempts to set a license from several locations relative to the executable and GroupDocs.Viewer.dll.
    /// You can also use the additional overload to load a license from a stream, this is useful for instance when the 
    /// License is stored as an embedded resource. 
    /// </remarks>
    static class SetLicenseFromFile
    {
        public static void Run()
        {
            if (File.Exists(Constants.LicensePath))
            {
                License license = new License();
                license.SetLicense(Constants.LicensePath);

                Console.WriteLine("License set successfully.");
            }
            else
            {
                Console.WriteLine("\nWe do not ship any license with this example. " +
                                  "\nVisit the GroupDocs site to obtain either a temporary or permanent license. " +
                                  "\nLearn more about licensing at https://purchase.groupdocs.com/faqs/licensing. " +
                                  "\nLear how to request temporary license at https://purchase.groupdocs.com/temporary-license.");
            }
        }
    }
}
