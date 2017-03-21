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


    Public Class Epub
        ''' <summary>
        ''' Extracts a line of characters from a document
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractALine(fileName As String)
            'ExStart:ExtractALine
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor = New EpubTextExtractor(filePath)
                Dim line As String = extractor.ExtractLine()
                While line IsNot Nothing
                    Console.WriteLine(line)
                    line = extractor.ExtractLine()
                End While
            End Using
            'ExEnd:ExtractALine
        End Sub

        ''' <summary>
        ''' Extracts all characters from a document
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractAllCharacters(fileName As String)
            'ExStart:ExtractAllCharacters
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor = New EpubTextExtractor(filePath)
                Console.WriteLine(extractor.ExtractAll())
            End Using
            'ExEnd:ExtractAllCharacters
        End Sub


        ''' <summary>
        ''' Searches for a text in an epub file using regular expression
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub SearchTextUsingRegex(fileName As String)
            'ExStart:SearchTextInEpubUsingRegex
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor As New EpubTextExtractor(filePath)
                Dim searchOptions = New RegexSearchOptions()
                Dim handler = New ListSearchHandler()
                extractor.SearchWithRegex("On[a-z]", handler, searchOptions)

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
            'ExEnd:SearchTextInEpubUsingRegex
        End Sub

        ''' <summary>
        ''' Searches some text in an epub file
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub SearchText(fileName As String)
            'ExStart:SearchTextInEpub
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor As New EpubTextExtractor(filePath)
                Dim options = New SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(0))
                Dim handler = New ListSearchHandler()
                Dim keywords = New String() {"Name"}
                extractor.Search(options, handler, keywords)

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
            'ExEnd:SearchTextInEpub
        End Sub

        ''' <summary>
        ''' Extracts highlighted text in epub file
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractHighlight(fileName As String)
            'ExStart:ExtractHighlightInEpub
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor As New EpubTextExtractor(filePath)
                Dim highlights As IList(Of String) = extractor.ExtractHighlights(HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 9, 3))
                For i As Integer = 0 To highlights.Count - 1
                    Console.WriteLine(highlights(i))
                Next
            End Using
            'ExEnd:ExtractHighlightInEpub
        End Sub

        ''' <summary>
        ''' Detects Epub Media type
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub DetectEpubMediaType(fileName As String)
            'ExStart:DetectEpubMediaType
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim detector = New EpubMediaTypeDetector()
            Dim mediaType = detector.Detect(filePath)

            ' APPLICATION/EPUB+ZIP or null if stream is not EPUB document.
            Console.WriteLine(mediaType)
            'ExEnd:DetectEpubMediaType
        End Sub


        'public static void ExtractTextUsingTextReader(string fileName) {
        '    //get file's actual path
        '    string filePath = Common.getFilePath(fileName);
        '    using (TextReader reader = package.GetTextReader(0))
        '    {
        '        string line = reader.ReadLine();
        '        while (line != null)
        '        {
        '            Console.WriteLine(line);
        '            line = reader.ReadLine();
        '        }
        '    }
        '}
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
        loadOptions.Password = "invalidpwd"

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
    ''' Shows highlight extraction with defined words from the position
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="wordsCount">count of words from the position from where to extract highlight</param>
    Public Shared Sub ExtractHighlightWithLimitedWordsCount(fileName As String, wordsCount As Integer)
        'ExStart:ExtractHighlightWithLimitedWordsCount
        'get file path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim highlights As IList(Of String) = extractor.ExtractHighlights(HighlightOptions.CreateWordsCountOptions(HighlightDirection.Left, 15, wordsCount), HighlightOptions.CreateWordsCountOptions(HighlightDirection.Right, 20, wordsCount))

            For i As Integer = 0 To highlights.Count - 1
                Console.WriteLine(highlights(i))
            Next
        End Using
        'ExEnd:ExtractHighlightWithLimitedWordsCount
    End Sub

    ''' <summary>
    ''' Extracts highlight to the start or end of line
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ExtractHighlightTillStartOrEndOfLine(fileName As String)
        'ExStart:ExtractHighlightTillStartOrEndOfLine
        'get file path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim highlights As IList(Of String) = extractor.ExtractHighlights(HighlightOptions.CreateLineOptions(HighlightDirection.Left, 15), HighlightOptions.CreateLineOptions(HighlightDirection.Right, 20))

            For i As Integer = 0 To highlights.Count - 1
                Console.WriteLine(highlights(i))
            Next
        End Using
        'ExEnd:ExtractHighlightTillStartOrEndOfLine
    End Sub
    ''' <summary>
    ''' Searches text in documents.
    ''' </summary>
    ''' <param name="fileName">the name of the file to searrch text from</param>
    Public Shared Sub SearchTextInDocuments(fileName As String)
        'ExStart:SearchTextInDocuments
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        'initialize words text extractor
        Using extractor As New WordsTextExtractor(filePath)
            'initialize search handler
            Dim handler As New ListSearchHandler()
            'search for the text
            extractor.Search(New SearchOptions(New SearchHighlightOptions(10)), handler, Nothing, New String() {"test text", "keyword"})

            'Results count is none
            If handler.List.Count = 0 Then
                Console.WriteLine("Not found")
            Else
                'loop through the list and display the results
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

    ''' <summary>
    ''' Searches whole word in documents.
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub SearchWholeWord(fileName As String)
        'ExStart:SearchWholeWord
        'get file path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim searchOptions As New SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(15), True, True)
            Dim handler As New ListSearchHandler()
            extractor.Search(searchOptions, handler, Nothing, New String() {"mark", "down"})

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
        'ExEnd:SearchWholeWord
    End Sub

    ''' <summary>
    ''' Search text in documents using regular expression
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub SearchTextWithRegex(fileName As String)
        'ExStart:SearchTextWithRegex
        'get file path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim handler As New ListSearchHandler()
            extractor.SearchWithRegex("19[0-9]{2}", handler, New RegexSearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(10)))

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
        'ExEnd:SearchTextWithRegex
    End Sub

    ''' <summary>
    ''' Shows searching a text with highlights limited by line's start/end
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub UseExtractionModesWithSearch(fileName As String)
        'ExStart:UseExtractionModesWithSearch
        'get file path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New WordsTextExtractor(filePath)
            Dim handler As New ListSearchHandler()
            Dim highlightOptions As SearchHighlightOptions = SearchHighlightOptions.CreateLineOptions(100, 100)
            extractor.Search(New SearchOptions(highlightOptions), handler, Nothing, New String() {"text", "extraction"})

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
        'ExEnd:UseExtractionModesWithSearch
    End Sub

    ''' <summary>
    ''' Detects any supported media type using CompositeMediaTypeDetector class
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub MediaTypeDetection(fileName As String)
        'ExStart:MediaTypeDetection
        'get file actual path
        Dim filePath As [String] = Common.getFilePath(fileName)
        Dim mediaType = CompositeMediaTypeDetector.[Default].Detect(filePath)
        Console.WriteLine(mediaType)
        'ExEnd:MediaTypeDetection
    End Sub

End Class
