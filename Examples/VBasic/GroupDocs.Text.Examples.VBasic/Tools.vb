
Imports System.IO
Imports GroupDocs.Text.Detectors
Imports GroupDocs.Text.Detectors.Encoding
Imports GroupDocs.Text.Extractors.Text
Imports System.Text
Imports GroupDocs.Text

Public Class Tools
    Public Class EncodingDetection
        ''' <summary>
        ''' Detects encoding of a filestream when BOM is present
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractEncodingByBOM(fileName As String)
            'ExStart:ExtractEncodingByBOM
            Try
                Dim detector As New EncodingDetector(Encoding.GetEncoding(1251))
                'get file actual path
                Dim filePath As [String] = Common.getFilePath(fileName)
                Dim stream As Stream = New FileStream(filePath, FileMode.Open)
                Console.WriteLine(detector.Detect(stream))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            'ExEnd:ExtractEncodingByBOM
        End Sub

        ''' <summary>
        ''' Detects encoding from BOM is present or from the content if BOM is not present
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractEncodingByContentAndBOM(fileName As String)
            'ExStart:ExtractEncodingByContentAndBOM

            Try
                Dim detector As New EncodingDetector(Encoding.GetEncoding(1251))
                'get file actual path
                Dim filePath As [String] = Common.getFilePath(fileName)
                Dim stream As Stream = New FileStream(filePath, FileMode.Open)
                Console.WriteLine(detector.Detect(stream, True))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            'ExEnd:ExtractEncodingByContentAndBOM
        End Sub
    End Class

    Public Class logger
        ''' <summary>
        ''' Logs messages using NotificationReceiver 
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub LoggerWithManualExceptionHandling(fileName As String)
            'ExStart:LoggerWithManualExceptionHandling
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim receiver = New NotificationReceiver()
            Dim loadOptions As New LoadOptions()
            loadOptions.NotificationReceiver = receiver

            Try
                Using extractor = New CellsTextExtractor(filePath, loadOptions)
                    Console.WriteLine(extractor.ExtractAll())
                End Using
            Catch ex As Exception
                receiver.ProcessMessage(NotificationMessage.CreateErrorMessage(ex.Message, ex))
            End Try
            'ExEnd:LoggerWithManualExceptionHandling
        End Sub

        ''' <summary>
        ''' Logs messages using NotificationReceiver 
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub LoggerWithExtractorFactory(fileName As String)
            'ExStart:LoggerWithExtractorFactory
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim receiverForFactory = New NotificationReceiver()
            Dim factory = New ExtractorFactory(Nothing, Nothing, Nothing, receiverForFactory)

            Dim receiver = New NotificationReceiver()
            Dim loadOptions As New LoadOptions()
            loadOptions.NotificationReceiver = receiver

            Using extractor = New CellsTextExtractor(filePath, loadOptions)
                Console.WriteLine(extractor.ExtractAll())
            End Using
            'ExEnd:LoggerWithExtractorFactory
        End Sub
    End Class



    'ExStart:SimpleLogger
    Private Class NotificationReceiver
        Implements INotificationReceiver
        Public Sub ProcessMessage(message As NotificationMessage) Implements INotificationReceiver.ProcessMessage
            Console.WriteLine(message.Description)   
        End Sub
    End Class
    'ExEnd:SimpleLogger
End Class

