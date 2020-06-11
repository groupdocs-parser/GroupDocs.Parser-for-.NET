---
id: groupdocs-parser-for-net-18-8-release-notes
url: parser/net/groupdocs-parser-for-net-18-8-release-notes
title: GroupDocs.Parser for .NET 18.8 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 18.8.{{< /alert >}}

## Major Features

There are the following features in this release:

*   Support for text analysis API for text documents
*   Support for text analysis API for spreadsheets
*   Support for text analysis API for presentation
*   Ability to request a password for protected documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| PARSERNET-1024 | Implement the ability to request a password for protected documents | New feature |
| PARSERNET-978 | Implement the support for text analysis API for text documents | New feature |
| PARSERNET-979 | Implement the support for text analysis API for spreadsheets | New feature |
| PARSERNET-980 | Implement the support for text analysis API for presentations | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Parser for .NET 18.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Parser which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support for text analysis API for text documents

#### Description

This feature allows extracting text areas from document pages of text documents.

#### Public API changes

Added **DocumentContent** property to **WordsTextExtractor** class.

#### Usage

**C#**

```csharp
// Create a text extractor
WordsTextExtractor extractor = new WordsTextExtractor("invoice.docx");
 
// Create search options
TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
// Set a regular expression to search 'Invoice # XXX' text
searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
// Limit the search with a rectangle
searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);
 
// Get text areas
IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);
             
// Iterate over a list
foreach(TextArea area in texts)
{
    // Print a text
    Console.WriteLine(area.Text);
}
```

### Support for text analysis API for spreadsheets

#### Description

This feature allows extracting text areas from document pages of spreadsheets.

#### Public API changes

Added **DocumentContent** property to **CellsTextExtractor** class.

#### Usage

**C#**

```csharp
// Create a text extractor
CellsTextExtractor extractor = new CellsTextExtractor("invoice.xlsx");
 
// Create search options
TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
// Set a regular expression to search 'Invoice # XXX' text
searchOptions.Expression = "\\s?INVOICE\\s?#\\s?[0-9]+";
// Limit the search with a rectangle
searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);
 
// Get text areas
IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);
             
// Iterate over a list
foreach(TextArea area in texts)
{
    // Print a text
    Console.WriteLine(area.Text);
}
```

### Support for text analysis API for presentations

#### Description

This feature allows extracting text areas from document pages of presentations.

#### Public API changes

Added **DocumentContent** property to **SlidesTextExtractor** class.

#### Usage

**C#**

```csharp
// Create a text extractor
SlidesTextExtractor extractor = new SlidesTextExtractor("presentation.pptx");
 
// Create search options
TextAreaSearchOptions searchOptions = new TextAreaSearchOptions();
// Set a regular expression to search 'Published: XXXX.XX.XX' text
searchOptions.Expression = "\\s?Published\\:\\s?[0-9]{4}\\.[0-9]{2}\\.[0-9]{2}";
// Limit the search with a rectangle
searchOptions.Rectangle = new GroupDocs.Parser.Rectangle(10, 10, 300, 150);
 
// Get text areas
IList<TextArea> texts = extractor.DocumentContent.GetTextAreas(0, searchOptions);
             
// Iterate over a list
foreach(TextArea area in texts)
{
    // Print a text
    Console.WriteLine(area.Text);
}
```

### Ability to request a password for protected documents

#### Description

This feature allows providing a password for protected documents on-demand.

#### Public API changes

Added **IPasswordProvider** interface.  
Added **PasswordRequest** class.  
Added **PasswordProvider** property to **LoadOptions** class.

#### Usage

`IPasswordProvider` interface has only one method:

**C#**

```csharp
void OnPasswordRequest(object sender, PasswordRequest request);
```

This method is called when the extractor or container meets a password-protected document. `sender` contains the link to the caller. `PasswordRequest` class contains the information about the request:

| Member | Description |
| --- | --- |
| Cancel | The boolean value indicating whether the request is rejected |
| Password | A password for the document |

A user has two ways to provide a password for the document. When the password is known, `Password` property of *`LoadOptions`* class is used. If it is not known whether it is protected or not before opening the document, `PasswordProvider` property of *`LoadOptions`* class is used.

**C#**

```csharp
class Indexer
{
    /// <summary>
    /// Gets a name of the current processed file
    /// </summary>
    public string CurrentFileName
    {
        get; private set;
    }
 
    /// <summary>
    /// Processes the directory
    /// </summary>
    /// <param name="dir">Directory to process</param>
    public void Process(DirectoryInfo dir)
    {
        // Process the sub-directories
        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            Process(subDir);
        }
 
        // Create load options with Password Provider
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.PasswordProvider = new PasswordProvider(this);
 
        // Process files in the directory
        foreach (FileInfo file in dir.GetFiles())
        {
            // Set the name of the current processed file
            CurrentFileName = file.Name;
 
            try
            {
                // Extract a text from the file
                string text = Extractor.Default.ExtractText(file.FullName, loadOptions);
                // Print the length of the file
                Console.WriteLine($"{CurrentFileName}, length: {(text ?? string.Empty).Length}");
            }
            catch (GroupDocsParserException ex)
            {
                // Print an error message (for example, "Invalid Password")
                Console.WriteLine(ex.Message);
            }
        }
    }
 
    /// <summary>
    /// Provides the ability to request a password from a user
    /// </summary>
    private class PasswordProvider : IPasswordProvider
    {
        private readonly Indexer owner;
 
        public PasswordProvider(Indexer owner)
        {
            this.owner = owner;
        }
 
        /// <summary>
        /// Requests a password from a user
        /// </summary>
        /// <param name="sender">Sender of a request (for example, an instance of WordsTextExtractor)</param>
        /// <param name="request">Request information</param>
        public void OnPasswordRequest(object sender, PasswordRequest request)
        {
            // Print a password request
            Console.WriteLine($"Enter password for {owner.CurrentFileName}:");
            string password = Console.ReadLine();
 
            // If a user omits a password (entered a blank password)
            if (string.IsNullOrEmpty(password))
            {
                // Mark the request as cancelled
                request.Cancel = true;
            }
            else
            {
                // Set the password
                request.Password = password;
            }
        }
    }
}
```
