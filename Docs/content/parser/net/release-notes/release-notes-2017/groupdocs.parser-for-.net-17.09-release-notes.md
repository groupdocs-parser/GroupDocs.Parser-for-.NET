---
id: groupdocs-parser-for-net-17-09-release-notes
url: parser/net/groupdocs-parser-for-net-17-09-release-notes
title: GroupDocs.Parser for .NET 17.09 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.9.0{{< /alert >}}

## Major Features

There are the following features in this release:

*   Remove obsolete members (v1702)
*   Implement the ability to extract a text from Microsoft Exchange Server
*   Implement the media type detector for CHM files

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-533 | Remove obsolete members (v1702) | Enhancement |
| TEXTNET-551 | Implement the ability to extract a text from Microsoft Exchange Server | New Feature |
| TEXTNET-707 | Implement the media type detector for CHM files | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.9.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Remove obsolete members (v1702)

Obsolete constructors of **SearchHighlightOptions** class and **CreateFixedLength** obsolete method from **HighlightOptions** class were removed.

**Public API Changes**  
Obsolete constructors of **SearchHighlightOptions** class were removed.  
**CreateFixedLength** obsolete method from **HighlightOptions** class was removed.

Use SearchHighlightOptions.CreateFixedLengthOptions static methods instead of constructor:

**C#**

```csharp
// use
var options = SearchHighlightOptions.CreateFixedLengthOptions(12);
// instead of 
var options = new SearchHighlightOptions(12);

```

**C#**

```csharp
// use
var options = SearchHighlightOptions.CreateFixedLengthOptions(0, 10);
// instead of
var options = new SearchHighlightOptions(0, 10);

```

Use HighlightOptions.CreateFixedLengthOptions static method instead of HighlightOptions.CreateFixedLength:

**C#**

```csharp
// use
var options = HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 0, 30);
// instead of
var options = HighlightOptions.CreateFixedLength(HighlightDirection.Right, 0, 30);

```

#### Implement the ability to extract a text from Microsoft Exchange Server

This feature allows to extract emails from Microsoft Exchange Server using Exchange Web Service.

**Public API Changes**  
Added **EmailConnectionType** enumeration.  
Added **EmailConnectionInfo** class.  
Added **EmailContainer** class.

Usage:

**C#**

```csharp
var info = EmailConnectionInfo.CreateEwsConnectionInfo(@"https://outlook.office365.com/ews/exchange.asmx", "username", "password", "domain");

// or if domain is not required:

var info = EmailConnectionInfo.CreateEwsConnectionInfo(@"https://outlook.office365.com/ews/exchange.asmx", "username", "password");

```

Retrieve a list of all emails using Entities property:

**C#**

```csharp
// Create connection info
var info = EmailConnectionInfo.CreateEwsConnectionInfo(@"https://outlook.office365.com/ews/exchange.asmx", "username", "password");
// Create an email container
using (var container = new EmailContainer(info)) {
  // Iterate over emails
  foreach(var entity in container.Entities) {
    Console.WriteLine("Folder: " + entity.Path.ToString()); // A folder at server
    Console.WriteLine("Subject: " + entity[MetadataNames.Subject]); // A subject of email
    Console.WriteLine("From: " + entity[MetadataNames.EmailFrom]); // "From" address
    Console.WriteLine("To: " + entity[MetadataNames.EmailTo]); // "To" addresses
  }
}

```

Retrieve an email using OpenEntityStream method:

**C#**

```csharp
// Create connection info
var info = EmailConnectionInfo.CreateEwsConnectionInfo(@"https://outlook.office365.com/ews/exchange.asmx", "username", "password");
// Create an email container
using (var container = new EmailContainer(info)) {
  // Iterate over emails
  foreach(var entity in container.Entities) {
    // Create a stream with content of email
    var stream = container.OpenEntityStream(entity); // or var stream = entity.OpenStream();
    // Create a text extractor for email
    using(var extractor = new EmailTextExtractor(stream)) { 
      // Extract all the text from email
      Console.WriteLine(extractor.ExtractAll());
    }
  }
}

```

#### Implement the media type detector for CHM files

This feature allows to detect CHM files.

**Public API Changes**  
Added **ChmMediaTypeDetector** class.

Usage:

**C#**

```csharp
// Create a media type detector
var detector = new ChmMediaTypeDetector();
// Detect a media type by the file name
Console.WriteLine(detector.Detect("file.chm")); // APPLICATION/VND.MS-HTMLHELP if supported or NULL otherwise
// Detect a media type by the content
Console.WriteLine(detector.Detect(stream)); // APPLICATION/VND.MS-HTMLHELP if supported or NULL otherwise

```
