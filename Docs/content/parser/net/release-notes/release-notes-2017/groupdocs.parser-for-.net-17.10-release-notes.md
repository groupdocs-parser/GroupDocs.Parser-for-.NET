---
id: groupdocs-parser-for-net-17-10-release-notes
url: parser/net/groupdocs-parser-for-net-17-10-release-notes
title: GroupDocs.Parser for .NET 17.10 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 17.10{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Remove obsolete members (v1703)
*   Implement additional properties for container entities
*   Update parameters keys for PersonalStorageContainer
*   Improve the performance of PDF text extractor
*   Implement the ability to extract a text from POP3 and IMAP mail servers

## All Changes

| Key | Summary | Issue Type |
| --- | --- | --- |
| TEXTNET-578 | Remove obsolete members (v1703) | Enhancement |
| TEXTNET-753 | Implement additional properties for container entities | Enhancement |
| TEXTNET-755 | Update parameters keys for PersonalStorageContainer | Enhancement |
| TEXTNET-775 | Improve the performance of PDF text extractor | Enhancement |
| TEXTNET-550 | Implement the ability to extract a text from POP3 and IMAP mail servers | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 17.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Remove obsolete members (v1703)

#### Description

**ExtractMetadata** obsolete methods from **ExtractorFactory** class were removed.

****Public API Changes****

**ExtractMetadata** obsolete methods from **ExtractorFactory** class were removed.

**Usage**

Use **ExtractMetadata **methods of **Extractor **class instead of **ExtractorFactory** class.

**C#**

```csharp
// use
var extractor = new Extractor();
var metadata = extractor.ExtractMetadata(("document.pdf", loadOptions);
// instead of
var factory = new ExtractorFactory();
var metadata = factory.ExtractMetadata("document.pdf", loadOptions);
```

### Implement additional properties for container entities

#### Description

Implemented the ability to retrieve **date** and **size** properties of containers entity.

**Public API changes**

Added **Date** and **Size** properties to **Container.Entity** class.

Added constructor with **date** and **size** parameters to **Container.Entity** class.

**Usage**

Container.Entity class contains the following properties:

<table class="confluenceTable"><tbody><tr><td class="confluenceTd"><p><strong>Property</strong></p></td><td class="confluenceTd"><p><strong>Data type</strong></p></td><td class="confluenceTd"><p><strong>Description</strong></p></td></tr><tr><td class="confluenceTd"><p>Name</p></td><td class="confluenceTd"><p>String</p></td><td class="confluenceTd"><p>Name of the entity. Depending on container it contains a filename, a unified id, a sequence number etc.</p></td></tr><tr><td class="confluenceTd"><p>Path</p></td><td class="confluenceTd"><p>ContainerPath</p></td><td class="confluenceTd"><p>Instance of&nbsp;ContainerPath&nbsp;class that represents the path of entity in the container</p></td></tr><tr><td class="confluenceTd"><p>MediaType</p></td><td class="confluenceTd"><p>String</p></td><td class="confluenceTd"><p>Media type of the entity (or null if a media type isn't set)</p></td></tr><tr><td class="confluenceTd"><p>Date</p></td><td class="confluenceTd"><p>DateTime?</p></td><td class="confluenceTd"><p>Date of the entity (or null if a date isn't set). In most&nbsp;cases, it means "last modified"</p></td></tr><tr><td class="confluenceTd"><p>Size</p></td><td class="confluenceTd"><p>Int64</p></td><td class="confluenceTd"><p>Size (in bytes) of the entity (or 0 if a size isn't set)</p></td></tr></tbody></table>

The following containers support the extraction of **date** and **size** properties of an entity:

*   EmailContainer
*   ZipContainer
*   PersonalStorageContainer 

**C#**

```csharp
// Create a container for zip-file
using (var c = new ZipContainer("data.zip")) {
    // Iterate via entities
    foreach (var e in c.Entities) {
        Console.WriteLine("Name: " + e.Name); // name of the file (i.e. "document.pdf")
        Console.WriteLine("Path: " + e.Path.ToString()); // path of the file in the container (i.e. "/contracts")
        Console.WriteLine("Date: " + e.Date.ToString()); // date when the file was added to the archive
        Console.WriteLine("Size: " + e.Size.ToString()); // uncompressed size of the file
    }
}
Entities from ZipContainer also have CRC property:
Console.WriteLine("CRC: " + e[MetadataNames.Crc]);

```

### Update parameters keys for PersonalStorageContainer

#### Description

Entities of **PersonalStorageContainer** class use **MetadataNames** class constants.

**Public API changes**

**EmailSubject**, **EmailSender** and **EmailReceiver** constants of **PersonalStorageContainer** class were marked as obsolete.

**Usage**

Use **MetadataNames.\* **constants instead:

**C#**

```csharp
// Use:
Console.WriteLine("Subject: ",
container.Entities[0][MetadataNames.Subject]);
Console.WriteLine("From: ",
container.Entities[0][MetadataNames.EmailFrom]);
Console.WriteLine("To: ",
container.Entities[0][MetadataNames.EmailTo]);
// Instead of:
Console.WriteLine("Subject: ",
container.Entities[0][PersonalStorageContainer.EmailSubject]);
Console.WriteLine("From: ",
container.Entities[0][PersonalStorageContainer.EmailSender]);
Console.WriteLine("To: ",
container.Entities[0][PersonalStorageContainer.EmailReceiver]);
```

  

### Improve the performance of PDF text extractor

#### **Description**

The performance of **PDF text extractor** was improved.

**Public API changes**

Public API was not changed.

**Usage**

**C#**

```csharp
// Create an instance of PDF text extractor
using (var extractor = new
PdfTextExtractor(stream)) {
//Set extraction mode to Fast text extraction
extractor.ExtractMode = ExtractMode.Simple; 
//Extract a text from the document
Console.WriteLine(extractor.ExtractAll());
}
```

### Implement the ability to extract a text from POP3 and IMAP mail servers

#### **Description**

This feature allows extracting emails from email servers using POP and IMAP protocols.

**Public API changes**

Added **Host** and **Port** properties to **EmailConnectionInfo** class.

Added **CreatePopConnectionInfo** and **CreateImapConnectionInfo** static methods to **EmailConnectionInfo** class.

Added **Pop** and **Imap** members to **EmailConnectionType** enumeration.

**Usage**

To retrieve a list of all emails **Entities **property is used:

**C#**

```csharp
// Create connection info
var info = EmailConnectionInfo.CreatePopConnectionInfo(@"pop-mail.outlook.com", 995, "username", "password");
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

To retrieve an email **OpenEntityStream **method is used:

**C#**

```csharp
// Create connection info
var info = EmailConnectionInfo.CreatePopConnectionInfo(@"pop-mail.outlook.com", 995, "username", "password");
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
