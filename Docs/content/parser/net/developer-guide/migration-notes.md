---
id: migration-notes
url: parser/net/migration-notes
title: Migration notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
### Why To Migrate?

Here are the key reasons to use the new updated API provided by GroupDocs.Parser for .NET since version 19.8:

*   [Parser](https://apireference.groupdocs.com/net/parser/groupdocs.parser/parser) class is introduced as a **single entry point** to extract data from the document.    
*   Data extraction was unified for all data types.      
*   The overall document related classes were unified to common.      
*   Product architecture was redesigned from scratch in order to simplify passing options and classes to manipulate data.    
*   Document information and preview generation procedures were simplified.      
    

### How To Migrate?

Here is brief comparison of how to extract data using the old and new API.  

#### Text

**Old coding style**

```csharp
// Create an extractor factory
ExtractorFactory factory = new ExtractorFactory();
// Create a text extractor
using (TextExtractor extractor = factory.CreateTextExtractor(filePath))
{
    // Extract a text from the text extractor
    string textLine = null;
    do
    {
        textLine = extractor.ExtractLine();
        if (textLine != null)
        {
            Console.WriteLine(textLine);
        }
    }
    while (textLine != null);
}
```

**New coding style**

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract a text to the reader
    using (TextReader reader = parser.GetText())
    {
        // Check if text extraction is supported
        if (reader == null)
        {
            Console.WriteLine("Text extraction isn't supported.");
            return;
        }
        // Extract a text from the reader
        string textLine = null;
        do
        {
            textLine = reader.ReadLine();
            if (textLine != null)
            {
                Console.WriteLine(textLine);
            }
        }
        while (textLine != null);
    }
}
```  

#### Text Page

**Old coding style**

```csharp
// Create an extractor factory
ExtractorFactory factory = new ExtractorFactory();
// Create a text extractor
using (TextExtractor extractor = factory.CreateTextExtractor(filePath))
{
    // Check if the extractor supports pagination
    IPageTextExtractor pte = extractor as IPageTextExtractor;
    if (pte != null)
    {
        // Extract the first page
        Console.WriteLine(pte.ExtractPage(0));
    }
}
```

**New coding style**

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract the first page text to the reader
    using (TextReader reader = parser.GetText(0))
    {
        // Check if text extraction is supported
        if (reader != null)
        {
            // Extract a text from the reader
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```  

#### Search

**Old coding style**

```csharp
// Create an extractor factory
ExtractorFactory factory = new ExtractorFactory();
// Create a text extractor
using (TextExtractor extractor = factory.CreateTextExtractor(filePath))
{
    // Check if the extractor supports search
    ISearchable se = extractor as ISearchable;
    if (se != null)
    {
        // Create a handler
        ListSearchHandler handler = new ListSearchHandler();
        // Search "keyword" in the document
        se.Search(new SearchOptions(null), handler, new string[] { "keyword" });
        // Print search results
        foreach (SearchResult result in handler.List)
        {
            Console.WriteLine(string.Format("at {0}: {1}", result.Index, result.FoundText));
        }
    }
}
```

**New coding style**

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Search "keyword" in the document
    IEnumerable<SearchResult> list = parser.Search("keyword");
    // Check if search is supported
    if (list == null)
    {
        Console.WriteLine("Search isn't supported.");
        return;
    }
    // Print search results
    foreach (SearchResult result in list)
    {
        Console.WriteLine(string.Format("at {0}: {1}", result.Position, result.Text));
    }
}
```

#### File Type Detection

**Old coding style**

```csharp
// Detect and print file type
Console.WriteLine(CompositeMediaTypeDetector.Default.Detect(filePath));
```

**New coding style**

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Detect and print file type
    Console.WriteLine(parser.GetDocumentInfo().FileType);
}
```

  

#### Metadata

**Old coding style**

```csharp
// Create an extractor factory
ExtractorFactory factory = new ExtractorFactory();
// Create a metadata extractor
MetadataExtractor extractor = factory.CreateMetadataExtractor(filePath);
// Extract metadata
MetadataCollection metadata = extractor.ExtractMetadata(filePath);
// Print metadata
foreach (KeyValuePair<string, string> item in metadata)
{
    Console.WriteLine(string.Format("{0} = {1}", item.Key, item.Value));
}
```

**New coding style**

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract metadata
    IEnumerable<MetadataItem> metadata = parser.GetMetadata();
    // Check if metadata extraction is supported
    if (metadata == null)
    {
        Console.WriteLine("Metadata extraction isn't supported.");
        return;
    }
    // Print metadata
    foreach (MetadataItem item in metadata)
    {
        Console.WriteLine(string.Format("{0} = {1}", item.Name, item.Value));
    }
}
```

  

#### Structure

**Old coding style**

```csharp
// Create an extractor factory
ExtractorFactory factory = new ExtractorFactory();
// Create a text extractor
using (TextExtractor extractor = factory.CreateTextExtractor(filePath))
{
    // Check if the extractor supports text structure extraction
    IStructuredExtractor se = extractor as IStructuredExtractor;
    if (se != null)
    {
        // Create a handler
        Handler handler = new Handler();
        // Extract text structure
        se.ExtractStructured(handler);
        // Print hyperlinks
        foreach (string link in handler.Links)
        {
            Console.WriteLine(link);
        }
    }
}

// Handler for the hyperlink extraction
private class Handler : StructuredHandler
{
    public Handler()
    {
        Links = new List<string>();
    }
    public List<string> Links { get; private set; }
    // Override the method to catch hyperlinks
    protected override void OnStartHyperlink(HyperlinkProperties properties)
    {
        Links.Add(properties.Link);
    }
}
```

**New coding style**

```csharp
// Create an instance of Parser class
using (Parser parser = new Parser(filePath))
{
    // Extract text structure to the XML reader
    using (XmlReader reader = parser.GetStructure())
    {
        // Check if text structure extraction is supported
        if (reader == null)
        {
            Console.WriteLine("Text structure extraction isn't supported.");
            return;
        }
        // Read the XML document to search hyperlinks
        while (reader.Read())
        {
            // Check if this is a start element with "hyperlink" name
            if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement() && reader.Name.ToLowerInvariant() == "hyperlink")
            {
                // Extract "link" attribute
                string value = reader.GetAttribute("link");
                if (value != null)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
```
