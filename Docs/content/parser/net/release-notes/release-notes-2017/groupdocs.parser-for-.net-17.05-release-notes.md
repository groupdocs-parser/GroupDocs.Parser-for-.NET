---
id: groupdocs-parser-for-net-17-05-release-notes
url: parser/net/groupdocs-parser-for-net-17-05-release-notes
title: GroupDocs.Parser for .NET 17.05 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.5.0{{< /alert >}}

## Major Features

There are the following features in this release:

*   Ability to extract a text with its structure from EPUB documents.
*   Ability to extract a formatted text from EPUB documents.
*   Ability to extract a text from fb2 (FictionBook) documents.
*   Ability to extract highlights from fb2 (FictionBook) documents.
*   Ability to search a text in fb2 (FictionBook) documents.
*   Ability to extract metadata from fb2 (FictionBook) documents.
*   Ability to detect fb2 (FictionBook) documents.
*   Ability to extract a text with its structure from fb2 (FictionBook) documents.
*   Ability to use Metered keys.

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-511 | Implement the ability to extract a structured text from EPUB files | New feature |
| TEXTNET-536 | Implement the ability to extract a formatted text from EPUB files | New feature |
| TEXTNET-537 | Implement the ability to extract a text from fb2 files | New feature |
| TEXTNET-538 | Implement the ability to extract metadata from fb2 files | New feature |
| TEXTNET-539 | Implement the ability to extract highlights from fb2 files | New feature |
| TEXTNET-540 | Implement the ability to search a text in fb2 files | New feature |
| TEXTNET-604 | Implement the ability to extract a structured text from fb2 files | New feature |
| TEXTNET-615 | Implement the support for Dynabic.Metered | New feature |
| TEXTNET-616 | Implement the media type detector for fb2 documents | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.5.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement the ability to extract a structured text from EPUB files

This feature allows to extract a text with its structure from EPUB documents.

**Public API Changes**  
Added **SectionProperties** class.  
Added **Section** item to **StructuredElementType** enum.  
Added **Section** event to **StructuredHandler** class.  
Added **OnStartSection** protected method to **StructuredHandler** class.  
Added **ExtractStructured** method to **EpubTextExtractor** class.

**Extracting section titles from EPUB document:**

**C#**

```csharp
// Create a text extractor
using (EpubTextExtractor extractor = new EpubTextExtractor(stream))
{
    StringBuilder sb = null;
    bool isSectionHasTitle = false;

    // Create a handler
    StructuredHandler handler = new StructuredHandler();

    // Handle ElementText event to process a section
    handler.Section += (sender, e) =>
    {
        isSectionHasTitle = false; // a new section doesn't have a title
    };

    // Handle Paragraph event to process a paragraph
    handler.Paragraph += (sender, e) =>
    {
        // is paragraph a heading?
        bool isHeading = ParagraphStyle.Heading1 <= e.Properties.Style && e.Properties.Style <= ParagraphStyle.Heading6;

        if (isHeading && !isSectionHasTitle)
        {
            sb = new StringBuilder();
        }
    };

    // Handle ElementClosed event to process a closing of a paragraph
    handler.ElementClosed += (sender, e) =>
    {
        // Check if closing tag is paragraph
        if (sb != null && e.Properties is ParagraphProperties)
        {
            // Print a title to the console
            Console.WriteLine(sb.ToString());
            // Section has a title
            isSectionHasTitle = true;
            sb = null;
        }
    };

    // Handle ElementText event to process a text
    handler.ElementText += (sender, e) =>
    {
        if (sb != null)
        {
            // Add a text to the title
            sb.Append(e.Text);
        }
    };

    // Extract a text with its structure
    extractor.ExtractStructured(handler);
}

```

#### Implement the ability to extract a formatted text from EPUB files

This feature allows to extract a formatted text from EPUB documents.

**Public API changes**  
Added **EpubTextExtractorBase** class.  
Added **EpubFormattedTextExtractor** class.

**Extracting a formatted text:**

**C#**

```csharp
// Create a formatted text extractor for EPUB documents
using (var extractor = new EpubFormattedTextExtractor(stream)) {
  // Set a document formatter to Markdown
  extractor.DocumentFormatter = new MarkdownDocumentFormatter();
  // Extact a text and print it to the console
  Console.Write(extractor.ExtractAll());
}

```

#### Implement the ability to extract a text from fb2 files

This feature allows to extract a text form fb2 (FictionBook) documents.

**Public API changes**  
Added **FictionBookTextExtractor** class.

**Extracting the whole text at once:**

**C#**

```csharp
using(var extractor = new FictionBookTextExtractor(stream))
{
   Console.Write(extractor.ExtractAll());
}

```

**Extracting a text by lines:**

**C#**

```csharp
using(var extractor = new FictionBookTextExtractor(stream))
{
   string line = extractor.ExtractLine();
   while(line != null)
   {
      Console.Write(line);
      line = extractor.ExtractLine();
   }
}

```

#### Implement the ability to extract metadata from fb2 files

This feature allows to extract metadata from fb2 (FictionBook) documents.

**Public API changes**  
Added **FictionBookMetadataExtractor** class.

**C#**

```csharp
// Create a metadata extractor 
FictionBookMetadataExtractor extractor = new FictionBookMetadataExtractor();
// Extract metadata
 MetadataCollection metadata = extractor.ExtractMetadata(stream);
// Iterate metadata values 
foreach (string key in metadata.Keys)
{
    // Print a metadata key/value pair to the console    
   Console.WriteLine(string.Format("{0} = {1}", key, metadata[key]));
}

```

#### Implement the ability to extract highlights from fb2 files

This feature allows to extract a highlight from fb2 (FictionBook) documents.

**Public API changes**  
Added **ExtractHighlights** method to **FictionBookTextExtractor** class.

**C#**

```csharp
// Create a text extractor 
using (FictionBookTextExtractor extractor = new FictionBookTextExtractor(stream))
{
    // Extract two highlights with the fixed position and length     
	var highlights = extractor.ExtractHighlights(
        HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 1962, 22),
        HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 1982, 10));

    for(int i = 0; i < highlights.Count; i++)
    {
        // Print highlights to the console        
	    Console.WriteLine(highlights[i]);
    }
}
```

#### Implement the ability to search a text from fb2 files

This feature allows to search with a regular expression or search a text in fb2 (FictionBook) documents.

**Public API changes**  
Added **Search** methods to **FictionBookTextExtractor** class.  
Added **SearchWithRegex** method to **FictionBookTextExtractor** class.

**Searching with a regular expression:**

**C#**

```csharp
// Create a text extractor 
using (var extractor = new FictionBookTextExtractor(stream)) {
  // Create search options   
	var searchOptions = new RegexSearchOptions(); 
  // Create a search handler. ListSearchHandler collects search results to the list  
	 var handler = new ListSearchHandler(); 
  // Search with a regular expression   
	extractor.SearchWithRegex("On[a-z]", handler, searchOptions); 

  // If list doesn't contain any results   
  if (handler.List.Count == 0)
  {
    Console.WriteLine("Not found"); // Print "Not Found" to the console  
  }
  else
  {
    // Iterate search results     
	for (int i = 0; i < handler.List.Count; i++)
    {
      // Print a search result to the console       
	  Console.Write(handler.List[i].LeftText); // a text on the left side from the found text      
	  Console.Write("_");
      Console.Write(handler.List[i].FoundText); // the found text       
      Console.Write("_");
      Console.Write(handler.List[i].RightText); // a text on the right side from the found text       
      Console.WriteLine("---");
    }
  }
}
```

**Searching a text:**

**C#**

```csharp
// Create a text extractor 
using (var extractor = new FictionBookTextExtractor(stream)) {
  // Create search options   
	var options = new SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(0));
  // Create a search handler. ListSearchHandler collects search results to the list  
	var handler = new ListSearchHandler();
  // Create keywords to search   
	var keywords = new string[] { "One" };
  // Search keywords   
	extractor.Search(options, handler, keywords);

  // If list doesn't contain any results   
  if (handler.List.Count == 0)
  {
    Console.WriteLine("Not found"); 
	// Print "Not Found" to the console   
  }
  else
  {
    // Iterate search results     
	for (int i = 0; i < handler.List.Count; i++)
    {
      // Print a search result to the console       
	  Console.Write(handler.List[i].LeftText); 
	  // a text on the left side from the found text       
	  Console.Write("_");
      Console.Write(handler.List[i].FoundText); 
      // the found text       
      Console.Write("_");
      Console.Write(handler.List[i].RightText); 
      // a text on the right side from the found text       
      Console.WriteLine("---");
    }
  }
}
```

#### Implement the ability to extract a structured text from fb2 files

This feature allows to extract a text with its structure from fb2 (FictionBook) documents.

**Public API changes**  
Added **LineBreakProperties** class.  
Added **LineBreak** item to **StructuredElementType** enum.  
Added **LineBreak** event to **StructuredHandler** class.  
Added **OnLineBreak** protected method to **StructuredHandler** class.  
Added **GroupProperties** class.  
Added **Group** item to **StructuredElementType** enum.  
Added **Group** event to **StructuredHandler** class.  
Added **OnStartGroup** protected method to **StructuredHandler** class.  
Added **ExtractStructured** method to **FictionBookTextExtractor** class.

**Extracting section titles from fb2 document:**

**C#**

```csharp
// Create a text extractor 
using (FictionBookTextExtractor extractor = new FictionBookTextExtractor(File.OpenRead(@"C:\Sources\GroupDocs.Parser\GroupDocs.Parser.Net\testdata\unit\fb2\complex.fb2")))
{
    StringBuilder sb = null;

    // Create a handler     
	StructuredHandler handler = new StructuredHandler();

    // Handle Group event to process a group     
	handler.Group += (sender, e) =>
    {
        StructuredHandler h = sender as StructuredHandler;

        // Is the group a section title?         
		bool isSectionTitleGroup = h != null && h.Depth > 1 && h[0] is SectionProperties;

        // If a group is the section title        
	    if(isSectionTitleGroup)
        {
            sb = new StringBuilder();
        }
    };

    // Handle Paragraph event to process a paragraph     
	handler.Paragraph += (sender, e) =>
    {
        if (sb != null && sb.Length > 0)
        {
            sb.AppendLine();
        }
    };

    // Handle ElementClosed event to process a closing of a paragraph     
	handler.ElementClosed += (sender, e) =>
    {
        if (sb == null || sb.Length == 0)
        {
            return;
        }

        // Check if closing tag is paragraph         
		if (e.Properties is ParagraphProperties)
        {
            sb.AppendLine();
        }

        // Check if closing tag is group of section title         
		if (e.Properties is GroupProperties && (e.Properties as GroupProperties).Style == "title")
        {
            // Print a title to the console             
			Console.WriteLine(sb.ToString());
            sb = null;
        }
    };

    // Handle ElementText event to process a text     
	handler.ElementText += (sender, e) =>
    {
        if (sb != null)
        {
            // Add a text to the title             
		sb.Append(e.Text);
        }
    };

    // Extract a text with its structure     
	extractor.ExtractStructured(handler);
}
```

#### Implement the support for Dynabic.Metered

This feature allows to use metered keys.

**Public API changes**  
Added **Metered** class.

**In this example, an attempt will be made to set metered public and private key:**

**C#**

```csharp
 
Metered matered = new Metered();
matered.SetMeteredKey("PublicKey", "PrivateKey");
```

#### Implement the media type detector for fb2 documents

This feature allows to detect fb2 (FictionBook) documents.

**Public API changes**  
Added **FictionBookMediaTypeDetector** class.

**C#**

```csharp
// Create a media type detector 
var detector = new FictionBookMediaTypeDetector();
// Detect a media type by the file name 
Console.WriteLine(detector.Detect("file.fb2"));
// Detect a media type by the content 
Console.WriteLine(detector.Detect(stream));
```
