---
id: extract-emails-from-remote-server-via-pop-imap-or-exchange-web-services-protocols
url: parser/net/extract-emails-from-remote-server-via-pop-imap-or-exchange-web-services-protocols
title: Extract emails from remote server via POP IMAP or Exchange Web Services protocols
weight: 6
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser allows you to extract emails from remote servers and data from the emails. The following email protocols are supported:

*   Post Office Protocol (POP)
*   Internet Message Access Protocol (IMAP)
*   Exchange Web Services (EWS)

To create an instance of [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) class to extract emails from a remote server the following constructor is used:

```csharp
Parser(string filePath, LoadOptions loadOptions);

```

Here are the steps to extract emails from the remote server:

*   Prepare connection string (see table below);
*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object with connection string;
*   Call [Features.Container](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/features/properties/container) property to check if container extraction is supported;
*   Call [GetContainer](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser/methods/getcontainer) method and obtain collection of document container item objects;
*   Iterate through the collection and get [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object for each item.

The following example shows how to extract emails from Exchange Server:

```csharp
StringBuilder sb = new StringBuilder();
sb.AppendLine("mode = exchange");
sb.AppendLine("MailboxUri = https://outlook.office365.com/ews/exchange.asmx");
sb.AppendLine("Username = test@outlook.com");
sb.AppendLine("Password = password");

// Create an instance of Parser class to extract emails from the remote server
// As filePath connection parameters are passed; LoadOptions is set to Email file format
using(Parser parser = new Parser(sb.ToString(), new LoadOptions(FileFormat.Email)))
{
    // Check if container extraction is supported
    if(!parser.Features.Container)
    {
        Console.WriteLine("Container extraction isn't supported.");
        return;
    }

    // Extract email messages from the server
    IEnumerable<ContainerItem> emails = parser.GetContainer();

    // Iterate over attachments
    foreach(ContainerItem item in emails)
    {
        // Create an instance of Parser class for email message
        using(Parser emailParser = item.OpenParser())
        {
            // Extract the email text
            using(TextReader reader = emailParser.GetText())
            {
                // Print the email text
                Console.WriteLine(reader == null ? "Text extraction isn't supported." : reader.ReadToEnd());
            }
        }
    }
}

```

The following connection parameters are used:

| Protocol | Parameters |
| --- | --- |
| POP | mode = pop  
Host = <url>  
Port = <port>  
Username = <user-name>  
Password = <password>  
  
 |
| IMAP | mode = imap  
Host = <url>  
Port = <port>  
Username = <user-name>  
Password = <password>  
  
 |
| EWS | mode = exchange  
MailboxUri = <url>  
Username = <user-name>  
Password = <password>
 |

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)
    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)
    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).
