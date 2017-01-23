Public Class Common

    'ExStart:commonutilities
    Public Const sourcePath As String = "../../../../Data/Storage/"
    Public Const licensePath As String = "D:/Aspose Projects/License/GroupDocs.Total.lic"
    'ExEnd:commonutilities

    ''' <summary>
    ''' Apply license
    ''' </summary>
    Public Shared Sub ApplyLicense()
        'ExStart:applylicense
        Try
            Dim lic As New License()
            lic.SetLicense(licensePath)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
        'ExEnd:applylicense
    End Sub

    ''' <summary>
    ''' Get source file path
    ''' </summary>
    ''' <param name="emailMessage"></param>
    ''' <returns></returns>
    Public Shared Function getFilePath(fileName As String) As [String]
        'ExStart:getfilepath
        Dim fileLocation As [String] = sourcePath & fileName
        Return fileLocation
        'ExEnd:getfilepath
    End Function

End Class
