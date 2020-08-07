# Text, Metadata & Image Extractor API

[Document Parser API](https://products.groupdocs.com/parser/net) works well to search & extract formatted text as well as the raw text from a variety of documents of [50+ supported file formats](https://docs.groupdocs.com/parser/net/supported-document-formats/).

<p align="center">

  <a title="Download complete GroupDocs.Parser for .NET source code" href="https://codeload.github.com/groupdocs-parser/GroupDocs.Parser-for-.NET/zip/master">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Demos](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET/tree/master/Demos) | Source code for live demos hosted at https://products.groupdocs.app/parser/family.
[Docs](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET/tree/master/Docs)  | Product documentation containing the Developer's Guide, Release Notes and more.
[Examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET/tree/master/Examples)  | C# examples and sample files that will help you learn how to use product features. 

## Document Parsing Features

- Parse documents by user-defined templates.
- Extract plain and structured text.
- Extract text areas with coordinates, text styles and other information.
- Search text by a keyword or regular expression; extract text around that word.
- Extract HTML or Markdown (MD) formatted text for a fast preview.
- Increase performance by extracting raw text.
- Extract formatted text, metadata, images, containers, and attachments.
- Extract table of contents for some supported document formats.
- Parse form data from PDF documents.

## Parse Document by Template

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF, TXT\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLSB, XLTX, XLTM, ODS, OTS, CSV, XLA, XLAM, NUMBERS\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM, ODP, OTP\
**Portable:** PDF

## Extract Text (Accurate)

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF, TXT\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLSB, XLTX, XLTM, ODS, OTS, CSV, XLA, XLAM, NUMBERS\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM, ODP, OTP\
**Email:** EML, EMLX, MSG\
**Markup:** HTML, XHTML, MHTML, MD, XML\
**eBooks:** CHM, EPUB, FB2\
**Portable:** PDF\
**Notes:** ONE\
**Databases:** Databases are supported via ADO.NET. To work with the corresponding database format install its database provider.

## Extract Text (Raw)

**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLSB, XLTX, XLTM, XLA, XLAM\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM\
**Portable:** PDF

## Extract Structured & Formatted Text

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLTX, XLTM, XLA, XLAM\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM, ODP, OTP\
**Email:** EML, EMLX, MSG\
**Markup:** MD (Formatted Text is Not supported)\
**eBooks:** CHM, EPUB, FB2

## Extract Text Areas

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLSB, XLTX, XLTM, ODS, OTS, XLA, XLAM, NUMBERS\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM, ODP, OTP\
**Portable:** PDF

## Extract Metadata

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLSB, XLTX, XLTM, ODS, OTS, XLA, XLAM\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM, ODP, OTP\
**Email:** EML, EMLX, MSG\
**eBooks:** EPUB, FB2\
**Portable:** PDF

## Extract Images

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLSB, XLTX, XLTM, ODS, OTS, XLA, XLAM, NUMBERS\
**Presentation:** PPT, PPS, POT, PPTX, PPTM, POTX, POTM, PPSX, PPSM, ODP, OTP\
**Email:** EML, EMLX, MSG\
**Portable:** PDF\
**Archive:** ZIP

## Extract Containers and Attachments

**Email:** PST, OST, EML, EMLX, MSG\
**Portable:** PDF\
**Archive:** ZIP

## Parse Form Data

**Portable:** PDF

## Extract Table of Contents

**Word Processing:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, ODT, OTT, RTF\
**eBooks:** CHM, EPUB\
**Portable:** PDF\
**Databases:** Databases are supported via ADO.NET. To work with the corresponding database format install its database provider.

## Develop & Deploy GroupDocs.Parser Anywhere

**Microsoft Windows:** Microsoft Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop.\
**Supported Frameworks:** NET Standard 2.0, .NET Framework 2.0 or higher, .NET Core 2.0 or higher, Mono Framework 1.2 or higher

## Get Started with GroupDocs.Parser for .NET

Are you ready to give GroupDocs.Parser for .NET a try? Simply execute `Install-Package GroupDocs.Parser` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Parser assembly in your project. If you already have GroupDocs.Parser for .Net and want to upgrade it, please execute `Update-Package GroupDocs.Parser` to get the latest version.

## Extract Data from Database

```csharp
string connectionString = string.Format("Provider=System.Data.Sqlite;Data Source={0};Version=3;", "database.db");
// create an instance of Parser class to extract tables from the database
// as filePath connection parameters are passed; LoadOptions is set to Database file format
using (Parser parser = new Parser(connectionString, new LoadOptions(FileFormat.Database)))
{
    // check if text extraction is supported
    if (!parser.Features.Text)
    {
        Console.WriteLine("Text extraction isn't supported.");
        return;
    }
    // check if toc extraction is supported
    if (!parser.Features.Toc)
    {
        Console.WriteLine("Toc extraction isn't supported.");
        return;
    }
    // get a list of tables
    IEnumerable<TocItem> toc = parser.GetToc();
    // iterate over tables
    foreach (TocItem i in toc)
    {
        // print the table name
        Console.WriteLine(i.Text);
        // extract a table content as a text
        using (TextReader reader = parser.GetText(i.PageIndex.Value))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
```

## Extract & Save Images As PNG

```csharp
// create an instance of Parser class
using (Parser parser = new Parser(Constants.SampleZip))
{
    // extract images from document
    IEnumerable<PageImageArea> images = parser.GetImages();
    // check if images extraction is supported
    if (images == null)
    {
        Console.WriteLine("Page images extraction isn't supported");
        return;
    }
    // create the options to save images in PNG format
    ImageOptions options = new ImageOptions(ImageFormat.Png);
    int imageNumber = 0;
    // iterate over images
    foreach (PageImageArea image in images)
    {
        // save the image to the png file
        image.Save(imageNumber.ToString() + ".png", options);
        imageNumber++;
    }
}
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/parser/net) | [Documentation](https://docs.groupdocs.com/parser/net/) | [Demo](https://products.groupdocs.app/parser/family) | [API Reference](https://apireference.groupdocs.com/parser/net) | [Examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET) | [Blog](https://blog.groupdocs.com/category/parser/) | [Free Support](https://forum.groupdocs.com/c/parser) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
