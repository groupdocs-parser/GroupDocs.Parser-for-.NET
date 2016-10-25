Imports GroupDocs.Text.Extractors.Text

Public Class WordStatistic

    Public Sub New(fileName As String, maxWordLength As Integer)
        'ExStart:WordStatistic
        Dim factory As New ExtractorFactory()
        Dim statistic As New Dictionary(Of String, Integer)()

        Dim extractor As TextExtractor = factory.CreateTextExtractor(fileName)
        If extractor Is Nothing Then
            Console.WriteLine("The document's format is not supported")
            Return
        End If

        Try
            Dim line As String = Nothing
            Do
                line = extractor.ExtractLine()
                If line IsNot Nothing Then
                    Dim words As String() = line.Split(" "c, ","c, ";"c, "."c)
                    For Each w As String In words
                        Dim word As String = w.Trim().ToLower()
                        If word.Length > maxWordLength Then
                            If Not statistic.ContainsKey(word) Then
                                statistic(word) = 0
                            End If

                            statistic(word) += 1
                        End If
                    Next
                End If
            Loop While line IsNot Nothing
        Finally
            extractor.Dispose()
        End Try

        Console.WriteLine("Top words:")

        For i As Integer = 0 To 9
            Dim count As Integer = -1
            Dim maxKey As String = Nothing
            For Each key As String In statistic.Keys
                If statistic(key) > count Then
                    count = statistic(key)
                    maxKey = key
                End If
            Next

            If maxKey Is Nothing Then
                Exit For
            End If

            Console.WriteLine("{0}: {1}", maxKey, count)
            statistic.Remove(maxKey)
            'ExEnd:WordStatistic
        Next
    End Sub
    Public Shared Sub FindMaxWordLength(fileOne As String, fileTwo As String)
        'ExStart:FindMaxWordLength
        Dim firstFile As [String] = Common.getFilePath(fileOne)
        Dim secondFile As [String] = Common.getFilePath(fileTwo)
        Dim arguments As String() = New String() {firstFile, secondFile}

        Dim maxWordLength As Integer
        For i As Integer = 0 To arguments.Length - 1
            If arguments(i).Length = 1 OrElse Not Integer.TryParse(arguments(i), maxWordLength) Then
                maxWordLength = 5
            End If
            Dim ws As New WordStatistic(arguments(i), maxWordLength)
            Console.WriteLine("__________________")
        Next
        'ExEnd:FindMaxWordLength
    End Sub

End Class
