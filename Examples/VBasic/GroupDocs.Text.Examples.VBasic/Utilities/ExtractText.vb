Imports GroupDocs.Text.Extractors.Text

Public Class ExtractText

    Public Sub New(fileName As String, formatted As Boolean)
        'ExStart:ExtractText
        Dim linesPerPage As Integer = Console.WindowHeight
        Dim factory As New ExtractorFactory()

        Dim extractor As TextExtractor = If(formatted, factory.CreateFormattedTextExtractor(fileName), factory.CreateTextExtractor(fileName))
        If extractor Is Nothing Then
            Console.WriteLine("The document's format is not supported")
            Return
        End If

        Try
            Dim line As String = Nothing
            Do
                Console.Clear()
                Console.WriteLine("{0}", fileName)

                Dim lineNumber As Integer = 0
                Do
                    line = extractor.ExtractLine()
                    lineNumber += 1
                    If line IsNot Nothing Then
                        Console.WriteLine(line)
                    End If
                Loop While line IsNot Nothing AndAlso lineNumber < linesPerPage

                Console.WriteLine()
                Console.WriteLine("Press Esc to exit or any other key to move to the next page")
            Loop While line IsNot Nothing AndAlso Console.ReadKey().Key <> ConsoleKey.Escape
        Finally
            extractor.Dispose()
            'ExEnd:ExtractText
        End Try
    End Sub
    Public Shared Sub ViewContentInConsole(fileName As String)
        'ExStart:ViewContentInConsole
        'get file actual path
        Dim filePath As [String] = Common.getFilePath(fileName)
        Dim extractor As New ExtractText(filePath, filePath.Length > 1 AndAlso filePath = "/f")
        'ExEnd:ViewContentInConsole
    End Sub

End Class
