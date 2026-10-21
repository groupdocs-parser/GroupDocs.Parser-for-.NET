## GroupDocs.Parser for .NET



[Product Page](https://products.groupdocs.com/parser/net) | [Docs](https://docs.groupdocs.com/parser/net/) | [Demos](https://products.groupdocs.com/parser/net/demos) | [API Reference](https://reference.groupdocs.com/parser/net/) | [Examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET) | [Blog](https://blog.groupdocs.com/categories/groupdocs.parser-product-family/) | [Releases](https://releases.groupdocs.com/parser/net/) | [Free Support](https://forum.groupdocs.com/c/parser/17) | [Temporary License](https://purchase.groupdocs.com/temp-license)



GroupDocs.Parser for .NET is a powerful .NET parsing library that enables developers to extract text, images, metadata, barcodes, forms, and structured content-including tables of contents and hyperlinks-from 65+ document formats, including PDF, Microsoft Office (DOCX, XLSX, PPTX), email (EML, MSG), archives (ZIP, RAR), e-books (EPUB, FB2), and more.

### Features

- Parse documents by user-defined templates.
- Extract plain and structured text.
- Extract text areas with coordinates, text styles and other information.
- Search text by a keyword or regular expression; extract text around that word.
- Extract HTML or Markdown (MD) formatted text for a fast preview.
- Increase performance by extracting raw text.
- Extract formatted text, metadata, images, containers, and attachments.
- Extract table of contents for some supported document formats.
- Parse form data from PDF documents.

See the [Features overview](https://docs.groupdocs.com/parser/net/features-overview/) documentation topic for more details.

### Supported formats

## Supported Formats (high level)

This API supports a broad set of document and media formats, including:

- **PDF**: PDF
- **Images**: JPG, PNG, TIFF, BMP, GIF, PSD
- **Email**: EML, MSG, EMLX, OST, PST
- **eBook**: EPUB, MOBI, AZW3, CHM, FB2
- **Archives**: ZIP, RAR, 7Z, TAR, BZ2, GZ

Supports **65+ formats**. See the [supported file formats](https://docs.groupdocs.com/parser/net/supported-document-formats/) table for the complete list.

### Supported Frameworks

**Supported Frameworks:** .NET 100 or higher, .NET 462 or higher, .NET 6.0 or higher, .NET 8.0 or higher, .NET Standard 2.1 or higher

### Getting Started


To get started with `GroupDocs.Parser` install the package using the command at the top of this NuGet page, or run:

```powershell
dotnet add package GroupDocs.Parser
```

You can run the following C# samples to see how the library works. Also check the [Examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET) repository for other common use cases.

#### Extract Data from Database

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

#### Extract & Save Images As PNG

```csharp
// create an instance of Parser class
using (Parser parser = new Parser("sample.zip"))
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



Explore the sample projects in this repository or open [documentation](https://docs.groupdocs.com/parser/net/) for more topics.

### Support

Our technical support is available to all users, including those evaluating our product. We offer assistance through our [Free Support Forum](https://forum.groupdocs.com/c/parser/17) and [Paid Support Helpdesk](https://helpdesk.groupdocs.com/). Let us know if you have any questions or issues, and we'll do our best to help you.

[Product Page](https://products.groupdocs.com/parser/net) | [Docs](https://docs.groupdocs.com/parser/net/) | [Demos](https://products.groupdocs.com/parser/net/demos) | [API Reference](https://reference.groupdocs.com/parser/net/) | [Examples](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET) | [Blog](https://blog.groupdocs.com/categories/groupdocs.parser-product-family/) | [Releases](https://releases.groupdocs.com/parser/net/) | [Free Support](https://forum.groupdocs.com/c/parser/17) | [Temporary License](https://purchase.groupdocs.com/temp-license)
