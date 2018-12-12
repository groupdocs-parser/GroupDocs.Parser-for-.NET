using GroupDocs.Parser;
using GroupDocs.Parser.Detectors.MediaType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Parser_for_.NET.Utilities
{
        //ExStart:Indexer_18.8
        class Indexer
        {
            /// <summary>
            /// Gets a name of the current processed file
            /// </summary>
            public string CurrentFileName
            {
                get; private set;
            }

            /// <summary>
            /// Processes the directory
            /// </summary>
            /// <param name="dir">Directory to process</param>
            public void Process(DirectoryInfo dir)
            {
                // Process the sub-directories
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    Process(subDir);
                }

                // Create load options with Password Provider
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.PasswordProvider = new PasswordProvider(this);

                // Process files in the directory
                foreach (FileInfo file in dir.GetFiles())
                {
                    // Set the name of the current processed file
                    CurrentFileName = file.Name;

                    try
                    {
                        // Extract a text from the file
                        string text = Extractor.Default.ExtractText(file.FullName, loadOptions);
                        // Print the length of the file
                        Console.WriteLine($"{CurrentFileName}, length: {(text ?? string.Empty).Length}");
                    }
                    catch (GroupDocsParserException ex)
                    {
                        // Print an error message (for example, "Invalid Password")
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            /// <summary>
            /// Provides the ability to request a password from a user
            /// </summary>
            private class PasswordProvider : IPasswordProvider
            {
                private readonly Indexer owner;

                public PasswordProvider(Indexer owner)
                {
                    this.owner = owner;
                }

                /// <summary>
                /// Requests a password from a user
                /// </summary>
                /// <param name="sender">Sender of a request (for example, an instance of WordsTextExtractor)</param>
                /// <param name="request">Request information</param>
                public void OnPasswordRequest(object sender, PasswordRequest request)
                {
                    // Print a password request
                    Console.WriteLine($"Enter password for {owner.CurrentFileName}:");
                    string password = Console.ReadLine();

                    // If a user omits a password (entered a blank password)
                    if (string.IsNullOrEmpty(password))
                    {
                        // Mark the request as cancelled
                        request.Cancel = true;
                    }
                    else
                    {
                        // Set the password
                        request.Password = password;
                    }
                }
            }
        }
        //ExEnd:Indexer_18.8

        //ExStart:Detector_18.12
        class Detector : IPasswordProvider
        {
            private string currentFile;
            public void Detect(string[] documents)
            {
                // Create load options
                LoadOptions loadOptions = new LoadOptions();
                // Set a password provider (it requests a password for protected documents if nessesary)
                loadOptions.PasswordProvider = this;
                // Get a default composite media type detector
                var detector = CompositeMediaTypeDetector.Default;
                // Iterage over documents
                foreach (var fileName in documents)
                {
                    // Set the current file name to dispay it with the password request
                    currentFile = fileName;
                    // Create a stream to detect media type by content (not file extension)                
                    using (var stream = File.OpenRead(fileName))
                    {
                        // Detect a media type
                        var mediaType = detector.Detect(stream, loadOptions);
                        // Print a detected media type
                        Console.WriteLine(mediaType);
                    }
                }
            }
            // If the document is encrypted Office Open XML, OnPasswordRequest is invoked
            public void OnPasswordRequest(object sender, PasswordRequest request)
            {
                // Print a password request
                Console.WriteLine($"Enter password for {currentFile}:");
                string password = Console.ReadLine();
                // If a user omits a password (entered a blank password)
                if (string.IsNullOrEmpty(password))
                {
                    // Mark the request as cancelled
                    request.Cancel = true;
                }
                else
                {
                    // Set a password
                    request.Password = password;
                }
            }
        }
        //ExEnd:Detector_18.12
    
}
