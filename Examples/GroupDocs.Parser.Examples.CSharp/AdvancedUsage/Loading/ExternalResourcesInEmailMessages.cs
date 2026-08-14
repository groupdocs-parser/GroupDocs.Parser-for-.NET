// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.Loading
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows that an email message may refer to resources that are stored outside of
    /// the message, and that extracting data from such a message makes the parser download them.
    /// </summary>
    static class ExternalResourcesInEmailMessages
    {
        /// <summary>
        /// The address of a publicly hosted image.
        /// This image belongs to this repository, which is distributed under the MIT license
        /// (see the LICENSE file in the repository root), therefore it is safe to refer to it here.
        /// </summary>
        private const string ExternalImageUrl =
            "https://raw.githubusercontent.com/groupdocs-parser/GroupDocs.Parser-for-.NET/master/" +
            "Examples/GroupDocs.Parser.Examples.CSharp/Resources/SampleFiles/installation.png";

        /// <summary>
        /// The address which is used as a clickable hyperlink in the message body.
        /// The parser never requests it; it is here to show the difference between a hyperlink
        /// and an external resource.
        /// </summary>
        private const string HyperlinkUrl = "https://products.groupdocs.com/parser/net/";

        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExternalResourcesInEmailMessages : This example shows when parsing of an email message downloads external resources.\n");

            // Create an email message which refers to an image that is stored on a remote server
            string filePath = CreateEmailMessage();
            Console.WriteLine("A sample message is created: {0}", filePath);
            Console.WriteLine("Its body refers to an external image: {0}", ExternalImageUrl);
            Console.WriteLine("Its body also contains a clickable hyperlink: {0}", HyperlinkUrl);

            // Watch the requests which are sent to remote servers while the message is parsed
            RequestWatcher watcher = RequestWatcher.Install();
            try
            {
                // Extract a plain text; the external image isn't required to build it
                watcher.Reset();
                using (Parser parser = new Parser(filePath))
                {
                    using (TextReader reader = parser.GetText())
                    {
                        reader.ReadToEnd();
                    }
                }

                watcher.Print("GetText");

                // Extract a formatted text; the message body is laid out as an HTML document,
                // therefore the external image is downloaded
                watcher.Reset();
                using (Parser parser = new Parser(filePath))
                {
                    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
                    {
                        reader.ReadToEnd();
                    }
                }

                watcher.Print("GetFormattedText");

                // Extract a structure; the external image is downloaded as well
                watcher.Reset();
                using (Parser parser = new Parser(filePath))
                {
                    using (XmlReader reader = parser.GetStructure())
                    {
                        while (reader.Read())
                        {
                        }
                    }
                }

                watcher.Print("GetStructure");

                // Try to prevent the download with an External Resource Handler.
                // Please note that email messages don't support this handler yet: OnLoading isn't
                // called and the image is still downloaded
                Handler handler = new Handler();
                ParserSettings settings = new ParserSettings(handler);

                watcher.Reset();
                using (Parser parser = new Parser(filePath, settings))
                {
                    using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
                    {
                        reader.ReadToEnd();
                    }
                }

                watcher.Print("GetFormattedText with External Resource Handler");
                Console.WriteLine("    OnLoading is called: {0}", handler.IsCalled);
            }
            finally
            {
                // Stop watching the requests
                watcher.Uninstall();
            }

            Console.WriteLine();
            Console.WriteLine("The hyperlink isn't requested: the parser downloads external resources like images");
            Console.WriteLine("and style sheets, but it never follows the links from a message body.");
        }

        /// <summary>
        /// Creates an email message which refers to an image that is stored on a remote server.
        /// </summary>
        /// <returns>The path to the created message.</returns>
        private static string CreateEmailMessage()
        {
            StringBuilder message = new StringBuilder();

            message.Append("From: sender@example.com\r\n");
            message.Append("To: receiver@example.com\r\n");
            message.Append("Subject: A message with an external image\r\n");
            message.Append("MIME-Version: 1.0\r\n");
            message.Append("Content-Type: text/html; charset=utf-8\r\n");
            message.Append("\r\n");
            message.Append("<html><body>");
            message.Append("<p>This message body refers to an image which is stored on a remote server.</p>");
            message.Append("<p><a href=\"" + HyperlinkUrl + "\">This is a clickable hyperlink</a></p>");
            message.Append("<p><img src=\"" + ExternalImageUrl + "\" width=\"100\" height=\"100\" /></p>");
            message.Append("</body></html>\r\n");

            if (!Directory.Exists(Constants.OutputPath))
            {
                Directory.CreateDirectory(Constants.OutputPath);
            }

            string filePath = Path.Combine(Constants.OutputPath, "ExternalResourcesInEmailMessages.eml");
            File.WriteAllText(filePath, message.ToString(), Encoding.UTF8);

            return filePath;
        }

        /// <summary>
        /// This class provides the ability to control the loading of external resources.
        /// </summary>
        private class Handler : ExternalResourceHandler
        {
            /// <summary>
            /// Gets the value that indicates whether the handler is called at least once.
            /// </summary>
            public bool IsCalled { get; private set; }

            /// <summary>
            /// Called before any external resource loads. It allows to skip unnecessary file loading.
            /// </summary>
            public override void OnLoading(ExternalResourceLoadingArgs args)
            {
                IsCalled = true;

                // Don't load this resource
                args.Skipped = true;

                base.OnLoading(args);
            }
        }

        /// <summary>
        /// This class prints the addresses which are requested by the parser.
        /// It is a web proxy which doesn't proxy anything: every request is sent directly to its
        /// server, the proxy is used to observe the addresses only.
        /// </summary>
        private class RequestWatcher : IWebProxy
        {
            private readonly List<string> addresses = new List<string>();
            private IWebProxy previousProxy;

            /// <summary>
            /// Gets or sets the credentials which are used to authenticate the proxy.
            /// </summary>
            public ICredentials Credentials { get; set; }

            /// <summary>
            /// Starts to watch the requests which are sent by the current process.
            /// </summary>
            /// <returns>An instance of <see cref="RequestWatcher"/> class.</returns>
            public static RequestWatcher Install()
            {
                RequestWatcher watcher = new RequestWatcher();

                watcher.previousProxy = WebRequest.DefaultWebProxy;
                WebRequest.DefaultWebProxy = watcher;

                return watcher;
            }

            /// <summary>
            /// Stops to watch the requests which are sent by the current process.
            /// </summary>
            public void Uninstall()
            {
                WebRequest.DefaultWebProxy = previousProxy;
            }

            /// <summary>
            /// Forgets the addresses which are watched before this call.
            /// </summary>
            public void Reset()
            {
                lock (addresses)
                {
                    addresses.Clear();
                }
            }

            /// <summary>
            /// Prints the addresses which are requested after the last <see cref="Reset"/> call.
            /// </summary>
            /// <param name="methodName">The name of the method which is called.</param>
            public void Print(string methodName)
            {
                Console.WriteLine();
                Console.WriteLine("{0} sends the following requests to remote servers:", methodName);

                lock (addresses)
                {
                    if (addresses.Count == 0)
                    {
                        Console.WriteLine("    nothing is requested");
                        return;
                    }

                    foreach (string address in addresses)
                    {
                        Console.WriteLine("    -> {0}", address);
                    }
                }
            }

            /// <summary>
            /// Returns the proxy for the requested address.
            /// </summary>
            /// <param name="destination">The address which is requested.</param>
            /// <returns>The same address: this proxy isn't used to send the request.</returns>
            public Uri GetProxy(Uri destination)
            {
                Add(destination);

                return destination;
            }

            /// <summary>
            /// Checks if the proxy isn't used for the requested address.
            /// </summary>
            /// <param name="host">The address which is requested.</param>
            /// <returns><c>true</c>: this proxy isn't used to send the request.</returns>
            public bool IsBypassed(Uri host)
            {
                Add(host);

                return true;
            }

            private void Add(Uri address)
            {
                string value = address.ToString();

                lock (addresses)
                {
                    if (!addresses.Contains(value))
                    {
                        addresses.Add(value);
                    }
                }
            }
        }
    }
}
