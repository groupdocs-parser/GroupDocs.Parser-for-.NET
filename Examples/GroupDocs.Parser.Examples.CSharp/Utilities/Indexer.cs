using GroupDocs.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET.Utilities
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
}
