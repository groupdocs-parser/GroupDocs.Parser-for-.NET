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


        ''' <summary>
        ''' Shows how to extract structured text from emails
        ''' Here as a sample usage where we are showing how to extract hyperlinks from an email
        ''' Feature is supported by version 17.04 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractEmailHyperlinks(fileName As String)
            'ExStart:ExtractEmailHyperlinks
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim hyperlinks As New List(Of String)()
            Dim sb As StringBuilder = Nothing
            Dim currentLink As String = Nothing
            Dim extractor As IStructuredExtractor = New EmailTextExtractor(filePath)
            Dim handler As New StructuredHandler()

            ' Handle Hyperlink event to process a starting of a hyperlink
            AddHandler handler.Hyperlink, Function(sender, e)
                                              sb = New StringBuilder()
                                              currentLink = e.Properties.Link
                                          End Function

            ' Handle ElementClose event to process a closing of a hyperlink
            AddHandler handler.ElementClosed, Function(sender, e)
                                                  Dim h As StructuredHandler = TryCast(sender, StructuredHandler)
                                                  If h IsNot Nothing AndAlso TypeOf h(0) Is HyperlinkProperties Then
                                                      ' closing of hyperlink
                                                      If sb IsNot Nothing Then
                                                          hyperlinks.Add(String.Format("{0} ({1})", sb.ToString(), currentLink))
                                                      End If
                                                      sb = Nothing
                                                      currentLink = Nothing
                                                  End If

                                              End Function

            ' Handle ElementText event to process a text
            AddHandler handler.ElementText, Function(sender, e)
                                                If sb IsNot Nothing Then
                                                    ' if hyperlink is open
                                                    sb.Append(e.Text)
                                                End If

                                            End Function

            ' Extract a text with its structure
            extractor.ExtractStructured(handler)

            For Each hl As String In hyperlinks
                Console.WriteLine(hl)
            Next
            'ExEnd:ExtractEmailHyperlinks
        End Sub


        ''' <summary>
        ''' Shows how to extract text fromE attachments of email format using container
        ''' Feature is supported in version 17.7 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractTextFromEmailAttachmentsUsingContainer(fileName As String)
            'ExStart:ExtractTextFromEmailAttachments
            'get the file's path
            Dim filePath As String = Common.getFilePath(fileName)
            ' Create an extractor factory
            Dim factory = New ExtractorFactory()
            ' Create an instance of EmailTextExtractor class 
            Dim extractor = New EmailTextExtractor(filePath)
            ' Iterate over all attachments in the message 
            For i As var = 0 To extractor.Entities.Count - 1
                ' Print the name of an attachment   
                Console.WriteLine(extractor.Entities(i).Name)
                ' Open the stream of an attachment   
                Using stream = extractor.Entities(i).OpenStream()
                    ' Create the text extractor for an attachment     
                    Dim attachmentExtractor = factory.CreateTextExtractor(stream)
                    ' If a media type is supported     
                    If attachmentExtractor IsNot Nothing Then
                        Try
                            ' Print the content of an attachment       
                            Console.WriteLine(attachmentExtractor.ExtractAll())
                        Finally
                            attachmentExtractor.Dispose()
                        End Try
                    End If
                End Using
            Next
            'ExEnd:ExtractTextFromEmailAttachments
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


        ''' <summary>
        ''' Shows how to exatract text from PDF portfolios
        ''' Feature is supported in version 17.07 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractTextFromPdfPortfolios(fileName As String)
            'ExStart:ExtractTextFromPdfPortfolios
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create an extractor factory 
            Dim factory = New ExtractorFactory()
            ' Create an instance of PdfTextExtractor class 
            Dim extractor = New PdfTextExtractor(filePath)
            ' Iterate over all files in the portfolio 
            For i As var = 0 To extractor.Entities.Count - 1
                ' Print the name of a file   
                Console.WriteLine(extractor.Entities(i).Name)
                ' Open the stream of a file   
                Using stream = extractor.Entities(i).OpenStream()
                    ' Create the text extractor for a file     
                    Dim entityExtractor = factory.CreateTextExtractor(stream)
                    ' If a media type is supported
                    If entityExtractor IsNot Nothing Then
                        Try
                            ' Print the content of a file       
                            Console.WriteLine(entityExtractor.ExtractAll())
                        Finally
                            entityExtractor.Dispose()
                        End Try
                    End If
                End Using
            Next
            'ExEnd:ExtractTextFromPdfPortfolios
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


        ''' <summary>
        ''' Shows how to extract structured text from presentation documents
        ''' Here as a sample usage where we are showing how to extract top-level lists from ppt
        ''' Feature is supported by version 17.04 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractTopLevelLists(fileName As String)
            'ExStart:ExtractTopLevelLists
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim sb As New StringBuilder()
            Dim extractor As IStructuredExtractor = New SlidesTextExtractor(filePath)
            Dim handler As New StructuredHandler()

            Dim isList As Boolean = False

            ' Handle Hyperlink event to process a starting of a list
            AddHandler handler.List, Function(sender, e)
                                         e.Properties.SkipElement = e.Properties.Depth > 0
                                         ' process only top-level lists
                                         If Not e.Properties.SkipElement Then
                                             isList = True
                                         End If

                                     End Function

            ' Handle ElementClose event to process a closing of a list
            AddHandler handler.ElementClosed, Function(sender, e)
                                                  Dim h As StructuredHandler = TryCast(sender, StructuredHandler)
                                                  If h IsNot Nothing AndAlso TypeOf h(0) Is ListProperties Then
                                                      isList = False
                                                  End If

                                              End Function

            ' Handle ElementText event to process a text
            AddHandler handler.ElementText, Function(sender, e)
                                                If Not isList Then
                                                    Exit Function
                                                End If

                                                If sb.Length > 0 Then
                                                    sb.AppendLine()
                                                End If

                                                sb.Append(e.Text)

                                            End Function

            ' Extract a text with its structure
            extractor.ExtractStructured(handler)

            Console.WriteLine(sb.ToString())
            'ExEnd:ExtractTopLevelLists
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


        ''' <summary>
        ''' Shows how to read a structured text from spreadsheets
        ''' Feature is supported by version 17.04 or greater
        ''' </summary>
        Public Shared Sub ExtractStructuredText(fileName As String)
            'ExStart:ExtractStructuredText
            'get file's complete path 
            Dim filePath As String = Common.getFilePath(fileName)
            Dim sb As New StringBuilder()
            Dim extractor As IStructuredExtractor = New CellsTextExtractor(filePath)
            Dim handler As New StructuredHandler()

            ' Handle Table event to process a table
            AddHandler handler.Table, Function(sender, e)
                                          e.Properties.SkipElement = e.Properties.Name <> "Sheet2"
                                          ' process only the sheet which name is Sheet2
                                          If Not e.Properties.SkipElement Then
                                              If sb.Length > 0 Then
                                                  sb.AppendLine()
                                              End If

                                              sb.Append(e.Properties.Name)
                                          End If

                                      End Function

            ' Handle TableRow event to process a table row
            AddHandler handler.TableRow, Function(sender, e)
                                             sb.AppendLine()

                                         End Function

            ' Handle TableCell event to process a table cell
            AddHandler handler.TableCell, Function(sender, e)
                                              If e.Properties.Column > 0 Then
                                                  sb.Append(" ")
                                              End If

                                          End Function

            ' Handle ElementText event to process a text
            AddHandler handler.ElementText, Function(sender, e)
                                                sb.Append(e.Text)

                                            End Function

            ' Extract a text with its structure
            extractor.ExtractStructured(handler)
            Console.WriteLine(sb.ToString())
            'ExEnd:ExtractStructuredText
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


        ''' <summary>
        ''' Shows how to read structured text from text documents
        ''' here we show how to extract header from a document
        ''' Feature is supported by version 17.04 or greater
        ''' </summary>
        Public Shared Sub ExtractHeadersFromDocument(fileName As String)
            'ExStart:ExtractHeadersFromDocument
            'get file's complete path 
            Dim filePath As String = Common.getFilePath(fileName)
            Dim sb As New StringBuilder()
            Dim extractor As IStructuredExtractor = New WordsTextExtractor(filePath)
            Dim handler As New StructuredHandler()

            ' Handle List event to prevent processing of lists
            AddHandler handler.List, Function(sender, e) (e.Properties.SkipElement = True)
            ' ignore lists
            ' Handle Table event to prevent processing of tables
            AddHandler handler.Table, Function(sender, e) (e.Properties.SkipElement = True)
            ' ignore tables
            ' Handle Paragraph event to process a paragraph
            AddHandler handler.Paragraph, Function(sender, e)
                                              Dim h1 As Integer = CInt(ParagraphStyle.Heading1)
                                              Dim h6 As Integer = CInt(ParagraphStyle.Heading6)

                                              Dim style As Integer = CInt(e.Properties.Style)
                                              If h1 <= style AndAlso style <= h6 Then
                                                  If sb.Length > 0 Then
                                                      sb.AppendLine()
                                                  End If

                                                  ' make an indention for the header (h1 - no indention)
                                                  sb.Append(" "c, style - h1)
                                              Else
                                                  ' skip paragraph if it's not a header or a title
                                                  e.Properties.SkipElement = e.Properties.Style <> ParagraphStyle.Title
                                              End If

                                          End Function

            ' Handle ElementText event to process a text
            AddHandler handler.ElementText, Function(sender, e) sb.Append(e.Text)

            ' Extract a text with its structure
            extractor.ExtractStructured(handler)

            Console.WriteLine(sb.ToString())
            'ExEnd:ExtractHeadersFromDocument
        End Sub

        ''' <summary>
        ''' Extracts hyperlinks from a document
        ''' feature supported in version 17.04 or greater
        ''' </summary>
        ''' <param name="fileName">Name of the source file</param>
        Public Shared Sub ExtractHyperlinksFromDocument(fileName As String)
            'ExStart:ExtractHyperlinksFromDocument
            'get file path
            Dim filePath As String = Common.getFilePath(fileName)
            Dim hyperlinks As New List(Of String)()
            Dim sb As StringBuilder = Nothing
            Dim currentLink As String = Nothing
            Dim extractor As IStructuredExtractor = New WordsTextExtractor(filePath)
            Dim handler As New StructuredHandler()

            ' Handle Hyperlink event to process a starting of a hyperlink
            AddHandler handler.Hyperlink, Function(sender, e)
                                              sb = New StringBuilder()
                                              currentLink = e.Properties.Link

                                          End Function

            ' Handle ElementClose event to process a closing of a hyperlink
            AddHandler handler.ElementClosed, Function(sender, e)
                                                  Dim h As StructuredHandler = TryCast(sender, StructuredHandler)
                                                  If h IsNot Nothing AndAlso TypeOf h(0) Is HyperlinkProperties Then
                                                      ' closing of hyperlink
                                                      If sb IsNot Nothing Then
                                                          hyperlinks.Add(String.Format("{0} ({1})", sb.ToString(), currentLink))
                                                      End If
                                                      sb = Nothing
                                                      currentLink = Nothing
                                                  End If

                                              End Function

            ' Handle ElementText event to process a text
            AddHandler handler.ElementText, Function(sender, e)
                                                If sb IsNot Nothing Then
                                                    ' if hyperlink is open
                                                    sb.Append(e.Text)
                                                End If

                                            End Function

            ' Extract a text with its structure
            extractor.ExtractStructured(handler)

            For Each hl As String In hyperlinks
                Console.WriteLine(hl)
            Next
            'ExEnd:ExtractHyperlinksFromDocument
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


        ''' <summary>
        ''' Shows how to extract section titles from EPUB document
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractSectionTitle(fileName As String)
            'ExStart:ExtractSectionTitleEpub
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a text extractor
            Using extractor As New EpubTextExtractor(filePath)
                Dim sb As StringBuilder = Nothing
                Dim isSectionHasTitle As Boolean = False

                ' Create a handler
                Dim handler As New StructuredHandler()

                ' Handle ElementText event to process a section
                AddHandler handler.Section, Function(sender, e)
                                                ' a new section doesn't have a title
                                                isSectionHasTitle = False

                                            End Function

                ' Handle Paragraph event to process a paragraph
                AddHandler handler.Paragraph, Function(sender, e)
                                                  ' is paragraph a heading?
                                                  Dim isHeading As Boolean = ParagraphStyle.Heading1 <= e.Properties.Style AndAlso e.Properties.Style <= ParagraphStyle.Heading6

                                                  If isHeading AndAlso Not isSectionHasTitle Then
                                                      sb = New StringBuilder()
                                                  End If

                                              End Function

                ' Handle ElementClosed event to process a closing of a paragraph
                AddHandler handler.ElementClosed, Function(sender, e)
                                                      ' Check if closing tag is paragraph
                                                      If sb IsNot Nothing AndAlso TypeOf e.Properties Is ParagraphProperties Then
                                                          ' Print a title to the console
                                                          Console.WriteLine(sb.ToString())
                                                          ' Section has a title
                                                          isSectionHasTitle = True
                                                          sb = Nothing
                                                      End If

                                                  End Function

                ' Handle ElementText event to process a text
                AddHandler handler.ElementText, Function(sender, e)
                                                    If sb IsNot Nothing Then
                                                        ' Add a text to the title
                                                        sb.Append(e.Text)
                                                    End If

                                                End Function

                ' Extract a text with its structure
                extractor.ExtractStructured(handler)
            End Using
            'ExEnd:ExtractSectionTitleEpub
        End Sub

        ''' <summary>
        ''' Shows how to extract formatted text from Epub files
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractFormattedText(fileName As String)
            'ExStart:ExtractFormattedTextEpub
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a formatted text extractor for EPUB documents
            Using extractor = New EpubFormattedTextExtractor(filePath)
                ' Set a document formatter to Markdown
                extractor.DocumentFormatter = New MarkdownDocumentFormatter()
                ' Extact a text and print it to the console
                Console.Write(extractor.ExtractAll())
            End Using
            'ExEnd:ExtractFormattedTextEpub
        End Sub

    End Class


    Public Class Fb2
        ''' <summary>
        ''' Shows how to extract whole text from fb2 file
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractWholeText(fileName As String)
            'ExStart:ExtractWholeTextFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor = New FictionBookTextExtractor(filePath)
                Console.Write(extractor.ExtractAll())
            End Using
            'ExEnd:ExtractWholeTextFb2
        End Sub

        ''' <summary>
        ''' Shows how to extract text line by line
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractTextByLine(fileName As String)
            'ExStart:ExtractTextByLineFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Using extractor = New FictionBookTextExtractor(filePath)
                Dim line As String = extractor.ExtractLine()
                While line IsNot Nothing
                    Console.Write(line)
                    line = extractor.ExtractLine()
                End While
            End Using
            'ExEnd:ExtractTextByLineFb2
        End Sub

        ''' <summary>
        ''' Shows how to extract highlights from fb2 files
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractHighlights(fileName As String)
            'ExStart:ExtractHighlightsFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a text extractor 
            Using extractor As New FictionBookTextExtractor(filePath)
                ' Extract two highlights with the fixed position and length     
                Dim highlights = extractor.ExtractHighlights(HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 19, 22), HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 19, 10))

                For i As Integer = 0 To highlights.Count - 1
                    ' Print highlights to the console        
                    Console.WriteLine(highlights(i))
                Next
            End Using
            'ExEnd:ExtractHighlightsFb2
        End Sub

        ''' <summary>
        ''' Shows how to search text in fb2 files with a regular expression
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub SearchTextWithRegex(fileName As String)
            'ExStart:SearchTextWithRegexFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a text extractor 
            Using extractor = New FictionBookTextExtractor(filePath)
                ' Create search options   
                Dim searchOptions = New RegexSearchOptions()
                ' Create a search handler. ListSearchHandler collects search results to the list  
                Dim handler = New ListSearchHandler()
                ' Search with a regular expression   
                extractor.SearchWithRegex("On[a-z]", handler, searchOptions)

                ' If list doesn't contain any results   
                If handler.List.Count = 0 Then
                    ' Print "Not Found" to the console  
                    Console.WriteLine("Not found")
                Else
                    ' Iterate search results     
                    For i As Integer = 0 To handler.List.Count - 1
                        ' Print a search result to the console       
                        Console.Write(handler.List(i).LeftText)
                        ' a text on the left side from the found text      
                        Console.Write("_")
                        Console.Write(handler.List(i).FoundText)
                        ' the found text       
                        Console.Write("_")
                        Console.Write(handler.List(i).RightText)
                        ' a text on the right side from the found text       
                        Console.WriteLine("---")
                    Next
                End If
            End Using
            'ExEnd:SearchTextWithRegexFb2
        End Sub

        ''' <summary>
        ''' Shows how to search tex tin fb2 files
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub SearchText(fileName As String)
            'ExStart:SearchTextFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a text extractor 
            Using extractor = New FictionBookTextExtractor(filePath)
                ' Create search options   
                Dim options = New SearchOptions(SearchHighlightOptions.CreateFixedLengthOptions(0))
                ' Create a search handler. ListSearchHandler collects search results to the list  
                Dim handler = New ListSearchHandler()
                ' Create keywords to search   
                Dim keywords = New String() {"examined"}
                ' Search keywords   
                extractor.Search(options, handler, keywords)

                ' If list doesn't contain any results   
                If handler.List.Count = 0 Then
                    ' Print "Not Found" to the console   
                    Console.WriteLine("Not found")
                Else
                    ' Iterate search results     
                    For i As Integer = 0 To handler.List.Count - 1
                        ' Print a search result to the console       
                        Console.Write(handler.List(i).LeftText)
                        ' a text on the left side from the found text       
                        Console.Write("_")
                        Console.Write(handler.List(i).FoundText)
                        ' the found text       
                        Console.Write("_")
                        Console.Write(handler.List(i).RightText)
                        ' a text on the right side from the found text       
                        Console.WriteLine("---")
                    Next
                End If
            End Using
            'ExEnd:SearchTextFb2
        End Sub

        ''' <summary>
        ''' Shows how to extract section titles from fb2 document
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractSectionTitle(fileName As String)
            'ExStart:ExtractSectionTitleFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a text extractor 
            Using extractor As New FictionBookTextExtractor(filePath)
                Dim sb As StringBuilder = Nothing

                ' Create a handler     
                Dim handler As New StructuredHandler()

                ' Handle Group event to process a group     
                AddHandler handler.Group, Function(sender, e)
                                              Dim h As StructuredHandler = TryCast(sender, StructuredHandler)

                                              ' Is the group a section title?         
                                              Dim isSectionTitleGroup As Boolean = h IsNot Nothing AndAlso h.Depth > 1 AndAlso TypeOf h(0) Is SectionProperties

                                              ' If a group is the section title        
                                              If isSectionTitleGroup Then
                                                  sb = New StringBuilder()
                                              End If

                                          End Function

                ' Handle Paragraph event to process a paragraph     
                AddHandler handler.Paragraph, Function(sender, e)
                                                  If sb IsNot Nothing AndAlso sb.Length > 0 Then
                                                      sb.AppendLine()
                                                  End If

                                              End Function

                ' Handle ElementClosed event to process a closing of a paragraph     
                AddHandler handler.ElementClosed, Function(sender, e)
                                                      If sb Is Nothing OrElse sb.Length = 0 Then
                                                          Return 0
                                                      End If

                                                      ' Check if closing tag is paragraph         
                                                      If TypeOf e.Properties Is ParagraphProperties Then
                                                          sb.AppendLine()
                                                      End If

                                                      ' Check if closing tag is group of section title         
                                                      If TypeOf e.Properties Is GroupProperties AndAlso TryCast(e.Properties, GroupProperties).Style = "title" Then
                                                          ' Print a title to the console             
                                                          Console.WriteLine(sb.ToString())
                                                          sb = Nothing
                                                      End If

                                                  End Function

                ' Handle ElementText event to process a text     
                AddHandler handler.ElementText, Function(sender, e)
                                                    If sb IsNot Nothing Then
                                                        ' Add a text to the title             
                                                        sb.Append(e.Text)
                                                    End If

                                                End Function

                ' Extract a text with its structure     
                extractor.ExtractStructured(handler)
            End Using
            'ExEnd:ExtractSectionTitleFb2
        End Sub

        ''' <summary>
        ''' Shows how to detect media type of a fb2 file
        ''' Feature is supported in version 17.05 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub DetectMediaType(fileName As String)
            'ExStart:DetectMediaTypeFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a media type detector 
            Dim detector = New FictionBookMediaTypeDetector()
            ' Detect a media type by the file name 
            Console.WriteLine(detector.Detect(fileName))
            ' Detect a media type by the content 
            Console.WriteLine(detector.Detect(filePath))
            ''ExEnd:DetectMediaTypeFb2
        End Sub


        ''' <summary>
        ''' Shows how to extract formatted text from fb2 file
        ''' Feature is supported in version 17.06 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractFormattedText(fileName As String)
            'ExStart:ExtractFormattedTextFb2
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            ' Create a formatted text extractor for FictionBook (fb2)documents 
            Using extractor = New FictionBookFormattedTextExtractor(filePath)
                ' Set a document formatter to Markdown 
                'extractor.DocumentFormatter = new FictionBookFormattedTextExtractor();
                ' Extact a text and print it to the console 
                Console.Write(extractor.ExtractAll())
            End Using
            'ExEnd:ExtractFormattedTextFb2
        End Sub

    End Class


    Public Class Dot
        ''' <summary>
        ''' Shows how to extract text from Dot file
        ''' Feature is supported in version 17.07 or greater
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractText(fileName As String)
            'ExStart:ExtractTextDotFiles
            Dim filePath As String = Common.getFilePath(fileName)
            ' Create an instance of WordsTextExtractor class 
            Using extractor = New WordsTextExtractor(filePath)
                ' Extract a text   
                Console.WriteLine(extractor.ExtractAll())
            End Using
            'ExEnd:ExtractTextDotFiles
        End Sub
    End Class


    Public Class Chm
        ''' <summary>
        ''' Shows how to extract a line of text from CHM file
        ''' Feature is supported in version 17.8.0 or greater 
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractALine(fileName As String)
            'ExStart:ChmExtractALine
            Dim filePath As String = Common.getFilePath(fileName)
            ' Create a text extractor for CHM documents
            Using extractor = New ChmTextExtractor(filePath)
                ' Extract a line of the text
                Dim line As String = extractor.ExtractLine()
                ' If the line is null, then the end of the file is reached
                While line IsNot Nothing
                    ' Print a line to the console
                    Console.WriteLine(line)
                    ' Extract another line
                    line = extractor.ExtractLine()
                End While
            End Using
            'ExEnd:ChmExtractALine
        End Sub

        ''' <summary>
        ''' Shows how to extract all characters from CHM file
        ''' Feature is supported in version 17.8.0 or greater 
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractAllCharacters(fileName As String)
            'ExStart:ChmExtractAllCharacters
            Dim filePath As String = Common.getFilePath(fileName)
            ' Create a text extractor for CHM documents
            Using extractor = New ChmTextExtractor(filePath)
                ' Extract a text
                Console.WriteLine(extractor.ExtractAll())
            End Using
            'ExEnd:ChmExtractAllCharacters
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


    ''' <summary>
    ''' Shows how to extract formatted highlights from documents.
    ''' Feature is supported by version 17.06 or greater
    ''' Supports all formats i-e Word,Epub,Slides,Cells,Email and fb2 docs
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ExtractFormattedHighlights(fileName As String)
        'ExStart:ExtractFormattedHighlights
        'get file actual path
        Dim filePath As [String] = Common.getFilePath(fileName)
        Using extractor As New WordsFormattedTextExtractor(filePath)
            Dim highlights As IList(Of String) = extractor.ExtractHighlights(HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Left, 15, 10), HighlightOptions.CreateFixedLengthOptions(HighlightDirection.Right, 20, 10))

            For i As Integer = 0 To highlights.Count - 1
                Console.WriteLine(highlights(i))
            Next
        End Using
        'ExEnd:ExtractFormattedHighlights
    End Sub



    ''' <summary>
    ''' Shows how to implement IPageExtractor
    '''Feature supported in version 17.07 or greater
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ImplementIpageExtractorInterface(fileName As String)
        'ExStart:ImplementIpageExtractorInterface
        Dim filePath As String = Common.getFilePath(fileName)
        ' Create an extractor factory 
        Dim factory = New ExtractorFactory()
        ' Create an instance of text extractor class 
        Using extractor = factory.CreateTextExtractor(filePath)
            ' Check if IPageTextExtractor is supported   
            Dim pageTextExtractor = TryCast(extractor, IPageTextExtractor)
            If pageTextExtractor IsNot Nothing Then
                ' Iterate over all pages     
                For i As Integer = 0 To pageTextExtractor.PageCount - 1
                    ' Print a page number       
                    Console.WriteLine(String.Format("{0}/{1}", i, pageTextExtractor.PageCount))
                    ' Extract a text from the page       
                    Console.WriteLine(pageTextExtractor.ExtractPage(i))
                Next
            End If
        End Using
        'ExEnd:ImplementIpageExtractorInterface
    End Sub


End Class
