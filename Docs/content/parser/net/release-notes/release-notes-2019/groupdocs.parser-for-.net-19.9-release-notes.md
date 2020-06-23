---
id: groupdocs-parser-for-net-19-9-release-notes
url: parser/net/groupdocs-parser-for-net-19-9-release-notes
title: GroupDocs.Parser for .NET 19.9 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Parser for .NET 19.9{{< /alert >}}

## Major Features

{{< alert style="danger" >}}In this version we're introducing new public API which was designed to be simple and easy to use. For more details about new API please check Developer Guide section. The legacy API have been moved into Legacy namespace so after update to this version it is required to make project-wide replacement of namespace usages from GroupDocs.Parser. to GroupDocs.Parser.Legacy. to resolve build issues.{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| PARSERNET-1218 | New public API | Feature |

## Public API and Backward Incompatible Changes

#### All public types from GroupDocs.Parser namespace 

1.  Have been moved into **GroupDocs.Parser.Legacy** namespace
2.  Marked as **Obsolete** with message: *This interface/class/enumeration is obsolete and will be available till January 2020 (v20.1).*

#### Full list of types that have been moved and marked as obsolete:

###### div.rbtoc1591867446738 { padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; }div.rbtoc1591867446738 ul { list-style-type: disc; list-style-image: none; margin-left: 0px; }div.rbtoc1591867446738 li { margin-left: 0px; padding-left: 0px; }

###### GroupDocs.Parser

New namespace: **GroupDocs.Parser.Legacy**

Types:

*   ArgumentNullException
*   CompositeNotificationReceiver
*   CorruptedDocumentException
*   DocumentInfo
*   DocumentParser
*   ExtractMode
*   Extractor
*   ExtractorFactory
*   GroupDocsParserException
*   IContainerFactory
*   INotificationReceiver
*   InvalidPasswordException
*   IPasswordProvider
*   LoadOptions
*   NotificationLevel
*   NotificationMessage
*   PasswordRequest
*   Rectangle
*   Size
*   UnsupportedDocumentFormatException

###### GroupDocs.Parser.Containers

New namespace: **GroupDocs.Parser.Legacy.Containers**

Types:

*   Container
*   ContainerEnumerator
*   ContainerPath
*   DbContainer
*   DbTableReader
*   EmailConnectionInfo
*   EmailConnectionType
*   EmailContainer
*   FolderContainer
*   IContainer
*   NamespaceDoc
*   PersonalStorageContainer
*   ZipContainer

###### GroupDocs.Parser.Detectors.Encoding

New namepace: **GroupDocs.Parser.Lecagy.Detectors.Encoding**

Types:

*   EncodingDetector

###### GroupDocs.Parser.Detectors.MediaType

New namespace: **GroupDocs.Parser.Legacy.Detectors.MediaType**

Types:

*   CellsMediaTypeDetector
*   ChmMediaTypeDetector
*   CompositeMediaTypeDetector
*   CsvMediaTypeDetector
*   EmailMediaTypeDetector
*   EpubMediaTypeDetector
*   FictionBookMediaTypeDetector
*   MediaTypeDetector
*   MediaTypeNames
*   NoteMediaTypeDetector
*   PdfMediaTypeDetector
*   PersonalStorageMediaTypeDetector
*   SlidesMediaTypeDetector
*   WordsMediaTypeDetector
*   ZipMediaTypeDetector

###### GroupDocs.Parser.Extractors

New namespace: **GroupDocs.Parser.Legacy.Extractors**

Types:

*   ContainsSearchHandler
*   DocumentContent
*   DocumentPage
*   DocumentProperties
*   Font
*   GroupProperties
*   HighlightDirection
*   HighlightMode
*   HighlightOptions
*   HyperlinkProperties
*   IDocumentContentExtractor
*   IFastTextExtractor
*   IHighlightExtractor
*   ImageArea
*   ImageAreaSearchOptions
*   IPageTextExtractor
*   IRegExSearchable
*   ISearchable
*   ISearchEngine
*   ISearchHandler
*   IStructuredExtractor
*   ITextExtractorWithFormatter
*   LineBreakProperties
*   ListItemProperties
*   ListProperties
*   ListSearchHandler
*   ListType
*   ModelNode
*   ModelStructuredHandler
*   PageProperties
*   ParagraphProperties
*   ParagraphStyle
*   RegExSearchOptions
*   SearchHighlightOptions
*   SearchOptions
*   SearchResult
*   SectionProperties
*   SlideProperties
*   StructuredElementProperties
*   StructuredElementType
*   StructuredEventArgs
*   StructuredHandler
*   StructuredTextEventArgs
*   TableArea
*   TableAreaCell
*   TableAreaDetector
*   TableAreaDetectorParameters
*   TableAreaLayout
*   TableAreaParser
*   TableCellProperties
*   TableOfContentsItem
*   TableProperties
*   TableRowProperties
*   TextArea
*   TextAreaItem
*   TextAreaSearchOptions
*   TextProperties
*   WordSeparators
*   XmlStructuredHandler

###### GroupDocs.Parser.Extractors.Metadata

New namespace: **GroupDocs.Parser.Legacy.Extractors.Metadata**

Types:

*   CellsMetadataExtractor
*   ComplexMetadataExtractor
*   EmailMetadataExtractor
*   EpubMetadataExtractor
*   FictionBookMetadataExtractor
*   MetadataCollection
*   MetadataExtractor
*   MetadataNames
*   PdfMetadataExtractor
*   SlidesMetadataExtractor
*   WordsMetadataExtractor

###### GroupDocs.Parser.Extractors.Templates

New namespace: **GroupDocs.Parser.Legacy.Extractors.Templates**

Types:

*   DocumentData
*   DocumentDataField
*   DocumentDataTable
*   DocumentTemplate
*   TemplateField
*   TemplateFieldPosition
*   TemplateFieldPositionType
*   TemplateFieldRelatedPositionType
*   TemplateTable

###### GroupDocs.Parser.Extractors.Text

New namespace: **GroupDocs.Parser.Legacy.Extractors.Text**

Types:

*   CellsFormattedTextExtractor
*   CellsSheetInfo
*   CellsTextExtractor
*   CellsTextExtractorBase
*   ChmFormattedTextExtractor
*   ChmTextExtractor
*   EmailFormattedTextExtractor
*   EmailTextExtractor
*   EmailTextExtractorBase
*   EpubFormattedTextExtractor
*   EpubPackage
*   EpubTextExtractor
*   EpubTextExtractorBase
*   FictionBookFormattedTextExtractor
*   FictionBookTextExtractor
*   MarkdownFormattedTextExtractor
*   MarkdownTextExtractor
*   NoteTextExtractor
*   PdfTextExtractor
*   SlidesFormattedTextExtractor
*   SlidesTextExtractor
*   SlidesTextExtractorBase
*   TextExtractor
*   WordsFormattedTextExtractor
*   WordsTextExtractor
*   XmlTextExtractor

###### GroupDocs.Parser.Formatters

New namespace: **GroupDocs.Parser.Legacy.Formatters**

Types:

*   DocumentFormatter
*   DocumentPartFormatter
*   DocumentPartOptions
*   ListFormatter
*   ListItem
*   ListItemOptions
*   ListItemStyle
*   StyleNames
*   TableCell
*   TableCellBorders
*   TableCellComparer
*   TableCellText
*   TableColumnWidthCollection
*   TableFormatter
*   TableRow
*   TextFormatter
*   TextItem
*   TextItemOptions

###### GroupDocs.Parser.Formatters.Html

New namespace: **GroupDocs.Parser.Legacy.Formatters.Html**

Types:

*   HtmlDocumentFormatter
*   HtmlListFormatter
*   HtmlTableFormatter
*   HtmlTextFormatter

###### GroupDocs.Parser.Formatters.Markdown

New namespace: **GroupDocs.Parser.Legacy.Formatters.Markdown**

Types:

*   MarkdownDocumentFormatter
*   MarkdownListFormatter
*   MarkdownTableFormatter
*   MarkdownTextFormatter

###### GroupDocs.Parser.Formatters.Plain

New namespace: **GroupDocs.Parser.Legacy.Formatters.Plain**

Types:

*   PlainDocumentFormatter
*   PlainListFormatter
*   PlainTableFormatter
*   PlainTableFrame
*   PlainTableFrameAngle
*   PlainTableFrameConfig
*   PlainTableFrameEdge
*   PlainTableFrameIntersection
*   PlainTextFormatter

###### GroupDocs.Parser.Options

New namespace: **GroupDocs.Parser.Legacy.Options**

Types:

*   DocumentType

###### GroupDocs.Parser.Preview

New namespace:** GroupDocs.Parser.Legacy.Preview**

Types:

*   PreviewFactory
*   PreviewHandler
*   PreviewImageData
*   PreviewNotSupportedException
*   PreviewPage
*   PreviewUnitOfMeasurement
