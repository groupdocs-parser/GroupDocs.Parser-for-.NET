Imports GroupDocs.Text.Extractors.Text
Imports System.Text
Imports System.IO

Public Class OtherOperations

    ''' <summary>
    ''' Create the concrete extractor by hand
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
    ''' Extract all from cells
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ExtractAllFromCells(fileName As String)
        'ExStart:ExtractAllFromCells
        'get file actual path
        Dim filePath As String = Common.getFilePath(fileName)
        Using extractor As New CellsTextExtractor(filePath)
            Console.WriteLine(extractor.ExtractAll())
        End Using
        'ExEnd:ExtractAllFromCells
    End Sub

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

End Class
