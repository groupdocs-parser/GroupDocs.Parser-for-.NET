---
id: groupdocs-parser-for-net-20-12-release-notes
url: parser/net/groupdocs-parser-for-net-20-12-release-notes
title: GroupDocs.Parser for .NET 20.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 20.12{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1690 | Implement the ability to identify whether a file is password-protected | New Feature |


## Public API and Backward Incompatible Changes

#### Description

This feature allows to identify whether a file is password-protected.

#### Public API changes

The following types were added:

* Added [FileInfo](https://apireference.groupdocs.com/parser/net/groupdocs.parser.options/fileinfo) class into GroupDocs.Parser.Options namespace.

[GroupDocs.Parser.Parser](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser) public class was updated with changes as follows:

* Added [GetFileInfo(Stream)](https://apireference.groupdocs.com/parser/net/groupdocs.parser/parser/methods/getfileinfo) method
* Added [GetFileInfo(String)](https://apireference.groupdocs.com/parser/net/groupdocs.parser.parser/getfileinfo/methods/1) method

#### Usage

The following code shows how to check whether a file is password-protected:

```csharp
// Get a file info
Options.FileInfo info = Parser.GetFileInfo(document);
// Check IsEncrypted property
Console.WriteLine(info.IsEncrypted ? "Password is required" : "");
```