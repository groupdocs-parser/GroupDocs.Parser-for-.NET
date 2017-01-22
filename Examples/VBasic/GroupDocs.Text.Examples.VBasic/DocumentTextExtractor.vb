Imports GroupDocs.Text.Extractors.Text
Imports GroupDocs.Text.Formatters.Html
Imports GroupDocs.Text.Formatters.Plain
Imports GroupDocs.Text.Formatters.Markdown
Imports System.IO
Imports System.Text
Imports GroupDocs.Text.Containers
Imports GroupDocs.Text.Detectors.MediaType
Imports GroupDocs.Text.Extractors

Public Class DocumentTextExtractor

    Public Class EmailsExtractor


        Public Shared Sub ExtractEmailAttachments(fileName As String)
            'ExStart:ExtractEmailAttachments
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New EmailTextExtractor(filePath)
            Dim factory As New ExtractorFactory()
            For i As Integer = 0 To extractor.AttachmentCount - 1
                Console.WriteLine(extractor.GetContentType(i).Name)
                Dim stream As Stream = extractor.GetStream(i)
                Dim attachmentExtractor As TextExtractor = factory.CreateTextExtractor(filePath)
                Try
                    Console.WriteLine(If(attachmentExtractor Is Nothing, "Document format is not supported", attachmentExtractor.ExtractAll()))
                Finally
                    If attachmentExtractor IsNot Nothing Then
                        attachmentExtractor.Dispose()
                    End If
                End Try
            Next
            'ExEnd:ExtractEmailAttachments
        End Sub

    End Class

    Public Class OneNoteDocument
        ''' <summary>
        ''' Extract text from onenote file/document
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractOneNoteDocument(fileName As String)
            'ExStart:ExtractOneNoteDocument
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            'Set page index
            Dim pageIndex As Integer = 1
            Dim extractor As New NoteTextExtractor(filePath)
            Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractPage(pageIndex), extractor.PageCount)
            'Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.PageCount);
            'ExEnd:ExtractOneNoteDocument
        End Sub


        ''' <summary>
        ''' Opens password-protected OneNote sections
        ''' </summary>
        ''' <param name="fileName">Name of the password protected one note file</param>
        Public Shared Sub OpenPasswordProtectedOneNoteSection(fileName As String)
            'ExStart: OpenPasswordProtectedOneNoteSection
            Dim loadOptions = New LoadOptions()
            loadOptions.Password = "test"
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)

            Using extractor = New NoteTextExtractor(filePath, loadOptions)
                Console.WriteLine(extractor.ExtractAll())
            End Using
            'ExEnd:OpenPasswordProtectedOneNoteSection
        End Sub
    End Class

    Public Class PdfDocument
        ''' <summary>
        ''' Extract text from pdf documents
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractPdfDocument(fileName As String)
            'ExStart:ExtractPdfDocument
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            'Set page index
            Dim pageIndex As Integer = 1
            Dim extractor As New PdfTextExtractor(filePath)
            'set extract mode to standard
            extractor.ExtractMode = ExtractMode.Standard
            Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractPage(pageIndex), extractor.PageCount)
            'Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.PageCount);
            'ExEnd:ExtractPdfDocument
        End Sub
    End Class

    Public Class PresentationDocument
        ''' <summary>
        ''' Extract text from presentatoin documents
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractPresentationDocument(fileName As String)
            'ExStart:ExtractPresentationDocument
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            'Set slide index
            Dim slideIndex As Integer = 1
            Dim extractor As New SlidesTextExtractor(filePath)
            'set extract mode to standard
            extractor.ExtractMode = ExtractMode.Standard
            Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractSlide(slideIndex), extractor.SlideCount)
            'Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.SlideCount);
            'ExEnd:ExtractPresentationDocument
        End Sub
    End Class

    Public Class SpreadsheetDocument
        ''' <summary>
        ''' Extract text from spreadsheet documents
        ''' </summary>
        Public Shared Sub ExtractEntireSheet(fileName As String)
            'ExStart:ExtractEntireSheet
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            'Set slide index
            Dim sheetIndex As Integer = 1
            Dim extractor As New CellsTextExtractor(filePath)
            'set extract mode to standard
            extractor.ExtractMode = ExtractMode.Standard
            Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractSheet(sheetIndex), extractor.SheetCount)
            'Console.WriteLine("{0} Page Count : {1} ", extractor.ExtractAll(), extractor.SheetCount);
            'ExEnd:ExtractEntireSheet
        End Sub
        ''' <summary>
        ''' Extracting the sheet by the rows
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractSheetByRows(fileName As String)
            'ExStart:ExtractSheetByRows
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New CellsTextExtractor(filePath)
            Dim sheetIndex As Integer = 0
            Dim sheetInfo As CellsSheetInfo = extractor.GetSheetInfo(sheetIndex)
            Console.WriteLine(sheetInfo.ExtractSheetHeader())
            For rowIndex As Integer = 2 To sheetInfo.RowCount - 1
                Console.WriteLine(sheetInfo.ExtractRow(rowIndex))
            Next
            'ExEnd:ExtractSheetByRows
        End Sub
        ''' <summary>
        ''' Extracting the selected columns
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractSelectedColumns(fileName As String)
            'ExStart:ExtractSelectedColumns
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New CellsTextExtractor(filePath)
            Dim sheetIndex As Integer = 0
            Dim sheetInfo As CellsSheetInfo = extractor.GetSheetInfo(sheetIndex)
            Console.WriteLine(sheetInfo.ExtractSheet("B1", "C1"))
            'ExEnd:ExtractSelectedColumns
        End Sub
        ''' <summary>
        ''' Extracting the selected columns from selected rows
        ''' </summary>
        Public Shared Sub ExtractSelectedColumnsAndRows(fileName As String)
            'ExStart:ExtractSelectedColumnsAndRows
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New CellsTextExtractor(filePath)
            Dim sheetIndex As Integer = 0
            Dim sheetInfo As CellsSheetInfo = extractor.GetSheetInfo(sheetIndex)
            Console.WriteLine(sheetInfo.ExtractSheetHeader())
            For rowIndex As Integer = 2 To sheetInfo.RowCount - 1
                Console.WriteLine(sheetInfo.ExtractRow(rowIndex, "B1", "C1"))
            Next
            'ExEnd:ExtractSelectedColumnsAndRows
        End Sub

        ''' <summary>
        ''' Create the concrete extractor by hand using filestream
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ConcreteExtractor(fileName As String)
            'ExStart:ConcreteExtractor
            'get file actual path
            Dim filePath As String = Common.getFilePath(fileName)
            Using stream As Stream = File.OpenRead(filePath)
                Using extractor As New CellsTextExtractor(stream)
                    Console.WriteLine(extractor.ExtractAll())
                End Using
            End Using
            'ExEnd:ConcreteExtractor
        End Sub

        ''' <summary>
        ''' Create the concrete extractor by hand using file
        ''' </summary>
        ''' <param name="fileName"></param>

        Public Shared Sub ConcreteExtractorByFile(fileName As String)
            'ExStart:ConcreteExtractorByFile
            'get file actual path
            Dim filePath As String = Common.getFilePath(fileName)

            Using extractor As New CellsTextExtractor(filePath)
                Console.WriteLine(extractor.ExtractAll())
            End Using

            'ExEnd:ConcreteExtractorByFile
        End Sub




    End Class

    Public Class TextDocument
        ''' <summary>
        ''' Extract formatted text from word
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractEntireWordPage(fileName As String)
            'ExStart:ExtractEntireWordPage
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim pageIndex As Integer = 0
            Dim extractor As New WordsFormattedTextExtractor(filePath)
            Console.WriteLine(extractor.ExtractPage(pageIndex))
            'ExEnd:ExtractEntireWordPage
        End Sub
        ''' <summary>
        ''' Extract text from word by defining a table format
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub FormattingTable(fileName As String)
            'ExStart:FormattingTable
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New WordsFormattedTextExtractor(filePath)
            Dim frame As New PlainTableFrame(PlainTableFrameAngle.ASCII, PlainTableFrameEdge.ASCII, PlainTableFrameIntersection.ASCII, New PlainTableFrameConfig(True, True, True, False))
            extractor.DocumentFormatter = New PlainDocumentFormatter(frame)
            Console.WriteLine(extractor.ExtractAll())
            'ExEnd:FormattingTable
        End Sub
        ''' <summary>
        ''' Extract text with markdown text format
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractingWithMarkdown(fileName As String)
            'ExStart:ExtractingWithMarkdown
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New WordsFormattedTextExtractor(filePath)
            extractor.DocumentFormatter = New MarkdownDocumentFormatter()
            Console.WriteLine(extractor.ExtractAll())
            'ExEnd:ExtractingWithMarkdown
        End Sub

        ''' <summary>
        ''' Extract a text with HTML text formatter
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub HtmlTextFormating(fileName As String)
            'ExStart:HtmlTextFormating
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New WordsFormattedTextExtractor(filePath)
            extractor.DocumentFormatter = New HtmlDocumentFormatter()
            Console.WriteLine(extractor.ExtractAll())
            'ExEnd:HtmlTextFormating
        End Sub
    End Class

    Public Shared Sub PassEncodingToCreatedExtractor(fileName As String)
        'ExStart:PassEncodingToCreatedExtractor
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        Dim loadOptions As New LoadOptions("text/plain", Encoding.UTF8)
        Dim factory As New ExtractorFactory()
        Using extractor As TextExtractor = factory.CreateTextExtractor(filePath, loadOptions)
            Console.WriteLine(If(extractor IsNot Nothing, extractor.ExtractAll(), "The document format is not supported"))
        End Using
        'ExEnd:PassEncodingToCreatedExtractor
    End Sub


    ''' <summary>
    ''' Extract text from a password protected document 
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub PasswordProtectedDocumentExtractor(fileName As String)
        'ExStart:PasswordProtectedDocumentExtractor
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        'To open password-protected document Password property of LoadOptions must be set
        Dim loadOptions As New LoadOptions()
        loadOptions.Password = "test"

        Dim extractor As WordsTextExtractor = Nothing
        'If password is not set or incorrect InvalidPasswordException is thrown
        Try
            extractor = New WordsTextExtractor(filePath, loadOptions)
            Console.WriteLine(extractor.ExtractAll())
        Catch generatedExceptionName As InvalidPasswordException
            Console.WriteLine("Invalid password.")
        Finally
            If extractor IsNot Nothing Then
                extractor.Dispose()
            End If
        End Try
        'ExEnd:PasswordProtectedDocumentExtractor
    End Sub


    ''' <summary>
    ''' Shows how a conatiner is created using ExtractFactory
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub CreatingContainerUsingExtractorFactory(fileName As String)
        'ExStart:CreatingContainerUsingExtractorFactory
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        Dim factory As New ExtractorFactory(Nothing, New CellsMediaTypeDetector())
        Using container As Container = factory.CreateContainer(filePath)
            If container Is Nothing Then
                Console.WriteLine("The document format is not supported")
            End If
        End Using
        'ExEnd:CreatingContainerUsingExtractorFactory
    End Sub

    ''' <summary>
    ''' Shows how a conatiner is created using ExtractFactory
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ExtractorFactoryCreateFormattedExtractor(fileName As String)
        'ExStart:ExtractorFactoryCreateFormattedExtractor
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        Dim factory As New ExtractorFactory(New MarkdownDocumentFormatter())
        Using extractor As TextExtractor = factory.CreateFormattedTextExtractor(fileName)
            Console.WriteLine(If(extractor IsNot Nothing, extractor.ExtractAll(), "The document format is not supported"))
        End Using
        'ExEnd:ExtractorFactoryCreateFormattedExtractor
    End Sub



    ''' <summary>
    ''' Extracts highight from a document
    ''' </summary>
    Public Shared Sub ExtractHighlight(fileName As String)
        'ExStart:ExtractHighlight
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim highlights As IList(Of String) = extractor.ExtractHighlights(HighlightOptions.CreateFixedLength(HighlightDirection.Left, 15, 10), HighlightOptions.CreateFixedLength(HighlightDirection.Right, 20, 10))

            For i As Integer = 0 To highlights.Count - 1
                Console.WriteLine(highlights(i))
            Next
        End Using
        'ExEnd:ExtractHighlight
    End Sub

    ''' <summary>
    ''' Searches text in documents.
    ''' </summary>
    ''' <param name="fileName">the name of the file to searrch text from</param>
    Public Shared Sub SearchTextInDocuments(fileName As String)
        'ExStart:SearchTextInDocuments
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim handler As New ListSearchHandler()
            extractor.Search(New SearchOptions(New SearchHighlightOptions(10)), handler, Nothing, New String() {"test text", "keyword"})

            If handler.List.Count = 0 Then
                Console.WriteLine("Not found")
            Else
                For i As Integer = 0 To handler.List.Count - 1
                    Console.Write(handler.List(i).LeftText)
                    Console.Write("_")
                    Console.Write(handler.List(i).FoundText)
                    Console.Write("_")
                    Console.Write(handler.List(i).RightText)
                    Console.WriteLine("---")
                Next
            End If
        End Using
        'ExEnd:SearchTextInDocuments
    End Sub




End Class
