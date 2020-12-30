---
id: password-protected-documents
url: parser/net/password-protected-documents
title: Password-protected documents
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
GroupDocs.Parser provides the functionality to open the password-protected documents.

Here are the steps to work with password protected documents.

*   Instantiate the [LoadOptions](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions) object and pass the password in [LoadOptions(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/loadoptions/constructors/4) constructor;
*   Create [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) object and call any method.

The following code sample shows how to process password protected documents.

```csharp
try
{
    // Create an instance of Parser class with the password:
    using (Parser parser = new Parser(filePath, new LoadOptions(password)))
    {
        // Check if text extraction is supported
        if (!parser.Features.Text)
        {
            Console.WriteLine("Text extraction isn't supported.");
            return;
        }
        // Print the document text
        using (TextReader reader = parser.GetText())
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
catch (InvalidPasswordException)
{
    // Print the message if the password is incorrect or empty
    Console.WriteLine("Invalid password");
}
```

If the password is incorrect or empty [InvalidPasswordException](https://apireference.groupdocs.com/net/parser/groupdocs.parser.exceptions/invalidpasswordexception) exception is thrown.

The following code shows how to check whether a file is password-protected:

```csharp
// Get a file info
Options.FileInfo info = Parser.GetFileInfo(document);
// Check IsEncrypted property
Console.WriteLine(info.IsEncrypted ? "Password is required" : "");
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).