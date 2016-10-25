Imports System.IO
Imports GroupDocs.Text.Extractors.Text

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
