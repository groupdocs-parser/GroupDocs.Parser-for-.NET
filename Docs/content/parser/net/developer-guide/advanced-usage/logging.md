---
id: logging
url: parser/net/logging
title: Logging
weight: 103
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
[ILogger](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger) interface is used to receive the information about errors, warnings and events which occur while data extraction. [ILogger](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger) interface has the following members:

| Member | Description |
| --- | --- |
| [Error(string, Exception)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger/methods/error) | Logs an error that occurred during data extraction. |
| [Warning(string)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger/methods/warning) | Logs a warning that occurred during data extraction. |
| [Trace(string)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger/methods/trace) | Logs an event occurred during data extraction. |

Here are the steps to receive the information via [ILogger](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger) interface:

*   Implement the class with [ILogger](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger) interface implementation;
*   Instantiate [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser)  object with [ParserSettings](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/parsersettings) object.

The following example shows how to receive the information via [ILogger](https://apireference.groupdocs.com/net/parser/groupdocs.parser.options/ilogger) interface.

```csharp
try
{
    // Create an instance of Logger class
    Logger logger = new Logger();
    // Create an instance of Parser class with the parser settings
    using (Parser parser = new Parser(Constants.SamplePassword, null, new ParserSettings(logger)))
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
    ; // Ignore the exception
}

private class Logger : ILogger
{
    public void Error(string message, Exception exception)
    {
        // Print error message
        Console.WriteLine("Error: " + message);
    }
    public void Trace(string message)
    {
        // Print event message
        Console.WriteLine("Event: " + message);
    }
    public void Warning(string message)
    {
        // Print warning message
        Console.WriteLine("Warning: " + message);
    }
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Parser for .NET examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET)    
*   [GroupDocs.Parser for Java examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-Java)    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to parse documents and extract data from PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Parser App](https://products.groupdocs.app/parser).