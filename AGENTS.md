# GroupDocs.Parser for .NET - AGENTS.md

> Instructions for AI agents working with **.NET** examples in this repository.

GroupDocs.Parser for .NET extracts text, images, metadata, forms, barcodes, and structured content from **65+** document and related formats (PDF, Office, email, e-books, archives, and more), without Microsoft Office or Adobe dependencies.

**Supported formats:** **65+** file formats - authoritative table: [https://docs.groupdocs.com/parser/net/supported-document-formats/](https://docs.groupdocs.com/parser/net/supported-document-formats/)

**Human overview:** see [README.md](README.md) in this repository.

## Install

```powershell
dotnet add package GroupDocs.Parser
```

Package page: [https://www.nuget.org/packages/GroupDocs.Parser/](https://www.nuget.org/packages/GroupDocs.Parser/)

## Resources

| Resource | URL |
|---|---|
| Documentation | [https://docs.groupdocs.com/parser/net/](https://docs.groupdocs.com/parser/net/) |
| API reference | [https://reference.groupdocs.com/parser/net/](https://reference.groupdocs.com/parser/net/) |
| Code examples (this repo) | [https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET) |
| Release notes | [https://releases.groupdocs.com/parser/net/](https://releases.groupdocs.com/parser/net/) |
| Temporary license | [https://purchase.groupdocs.com/temp-license](https://purchase.groupdocs.com/temp-license) |

## MCP server (optional)

Separate surface: [https://github.com/groupdocs-parser/GroupDocs.Parser.Mcp](https://github.com/groupdocs-parser/GroupDocs.Parser.Mcp). This repo is the **on-premise SDK** path.

## License

```csharp
using GroupDocs.Parser;

new License().SetLicense("path/to/GroupDocs.Parser.lic");
```

## API entry

Primary type: `GroupDocs.Parser.Parser`.

```csharp
using (Parser parser = new Parser("input.pdf"))
{
    using (TextReader reader = parser.GetText())
    {
        Console.WriteLine(reader.ReadToEnd());
    }
}
```
