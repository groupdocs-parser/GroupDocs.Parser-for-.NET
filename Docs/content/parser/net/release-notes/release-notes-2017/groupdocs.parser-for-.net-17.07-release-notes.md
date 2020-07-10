---
id: groupdocs-parser-for-net-17-07-release-notes
url: parser/net/groupdocs-parser-for-net-17-07-release-notes
title: GroupDocs.Parser for .NET 17.07 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.7.0{{< /alert >}}

## Major Features

There are the following features in this release:

*   Implement the ability to extract a text from pdf portfolios
*   Implement IContainer interface support for email text extractors
*   Implement the support for DOT files
*   Implement IPageTextExtractor interface

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-628 | Implement the ability to extract a text from pdf portfolios | New feature |
| TEXTNET-648 | Implement IContainer interface support for email text extractors | New feature |
| TEXTNET-650 | Implement the support for DOT files | New feature |
| TEXTNET-666 | Implement IPageTextExtractor interface | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.07. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement the ability to extract a text from pdf portfolios

This feature allows to extract a text from PDF Portfolio documents.

**Public API Changes**  
Added **Entities** property to **PdfTextExtractor** class.  
Added **OpenEntityStream** method to **PdfTextExtractor** class.

Usage:

**C#**

```csharp
// Create an extractor factory 
var factory = new ExtractorFactory();
// Create an instance of PdfTextExtractor class 
var extractor = new PdfTextExtractor(fileName);
// Iterate over all files in the portfolio 
for (var i = 0; i < extractor.Entities.Count; i++) 
{
    // Print the name of a file   
    Console.WriteLine(extractor.Entities[i].Name);
    // Open the stream of a file   
    using (var stream = extractor.Entities[i].OpenStream()) 
    {
        // Create the text extractor for a file     
        var entityExtractor = factory.CreateTextExtractor(stream);
        // If a media type is supported
        if (entityExtractor != null) try 
        {
            // Print the content of a file       
            Console.WriteLine(entityExtractor.ExtractAll());
        }
    finally 
	{
      entityExtractor.Dispose();
    }
}

```

#### Extract a text from attachments for email format (using IContainer Interface)  

This feature allows to work with an email text extractor as a container.

**Public API changes**  
Added **IContainer** interface.  
Added **OpenEntityStream** method to **Container** class.  
Added **Entities** property to **EmailTextExtractorBase** class.  
Added **OpenEntityStream** method to **EmailTextExtractorBase** class.

Usage:

**C#**

```csharp
// Create an extractor factory
var factory = new ExtractorFactory();
// Create an instance of EmailTextExtractor class 
var extractor = new EmailTextExtractor(fileName);
// Iterate over all attachments in the message 
for (var i = 0; i < extractor.Entities.Count; i++) 
{
    // Print the name of an attachment   
    Console.WriteLine(extractor.Entities[i].Name);
    // Open the stream of an attachment   
	using (var stream = extractor.Entities[i].OpenStream()) 
	{
    	// Create the text extractor for an attachment     
		var attachmentExtractor = factory.CreateTextExtractor(stream);
    	// If a media type is supported     
		if (attachmentExtractor != null) try 
		{
      		// Print the content of an attachment       
			Console.WriteLine(attachmentExtractor.ExtractAll());
    	}
    finally 
	{
      attachmentExtractor.Dispose();
    }
}

```

#### Implement the support for DOT files  

This feature allows to extract a formatted and a raw text from .DOT files.

**Public API changes**  
None

Usage:

**C#**

```csharp
// Create an instance of WordsTextExtractor class 
using (var extractor = new WordsTextExtractor("sample.dot"))
{
	// Extract a text   
	Console.WriteLine(extractor.ExtractAll());
}
```

#### Implement IPageTextExtractor interface

This feature allows to work with document's pages in the same way for all supported documents.

**Public API changes**  
Added **IPageTextExtractor** interface.  
Added **PageCount** property to **CellsTextExtractor**, **CellsFormattedTextExtractor**, **SlidesTextExtractor** and **SlidesFormattedTextExtractor** classes.  
Added **ExtractPage** method to **CellsTextExtractor**, **CellsFormattedTextExtractor**, **SlidesTextExtractor** and **SlidesFormattedTextExtractor** classes.

Usage:

**C#**

```csharp
// Create an extractor factory 
var factory = new ExtractorFactory();
// Create an instance of text extractor class 
using (var extractor = factory.CreateTextExtractor(fileName)) 
{
	// Check if IPageTextExtractor is supported   
	var pageTextExtractor = extractor as IPageTextExtractor;
    if (pageTextExtractor != null) 
	{
    	// Iterate over all pages     
		for (var i = 0; i < pageTextExtractor.PageCount; i++) 
		{
      		// Print a page number       
			Console.WriteLine(string.Format("{0}/{1}", i, pageTextExtractor.PageCount));
      		// Extract a text from the page       
			Console.WriteLine(pageTextExtractor.ExtractPage(i));
    	}
  	}
}
```
