Imports GroupDocs.Text.Extractors.Metadata

Public Class MetaDataExtractor


    Public Class CellsMetadata
        ''' <summary>
        ''' Extract metadata from cells
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadataFromCells(fileName As String)
            'ExStart:ExtractMetadataFromCells
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New CellsMetadataExtractor()
            Dim metadata As MetadataCollection = extractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataFromCells
        End Sub
    End Class

    Public Class SlidesMetadata
        ''' <summary>
        ''' Extract metadata from slides
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadataFromSlides(fileName As String)
            'ExStart:ExtractMetadataFromSlides
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New SlidesMetadataExtractor()
            Dim metadata As MetadataCollection = extractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataFromSlides
        End Sub
    End Class

    Public Class WordsMetaData
        ''' <summary>
        ''' Extract metadata from word documents
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadataFromWords(fileName As String)
            'ExStart:ExtractMetadataFromWords
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New WordsMetadataExtractor()
            Dim metadata As MetadataCollection = extractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataFromWords
        End Sub
    End Class

    Public Class PdfMetaData
        ''' <summary>
        ''' Extract metadata from pdf documents
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadataFromPdf(fileName As String)
            'ExStart:ExtractMetadataFromPdf
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New PdfMetadataExtractor()
            Dim metadata As MetadataCollection = extractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataFromPdf
        End Sub
    End Class

    Public Class EmailMetaData
        ''' <summary>
        ''' Extract metadata from emails
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadataFromEmails(fileName As String)
            'ExStart:ExtractMetadataFromEmails
            'get file actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim extractor As New EmailMetadataExtractor()
            Dim metadata As MetadataCollection = extractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataFromEmails
        End Sub
    End Class



    Public Class EpubMetaData
        ''' <summary>
        ''' Extracts metadata from an epub file
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadata(fileName As String)
            'ExStart:ExtractMetadataInEpub
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim metadataExtractor = New EpubMetadataExtractor()
            Dim metadata = metadataExtractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataInEpub
        End Sub

        ''' <summary>
        ''' Extracts metadata using complex metadata extractor class
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Shared Sub ExtractMetadataUsingComplexMetadataExtractor(fileName As String)
            'ExStart:ExtractMetadataUsingComplexMetadataExtractorInEpub
            'get file's actual path
            Dim filePath As [String] = Common.getFilePath(fileName)
            Dim metadataExtractor = New EpubMetadataExtractor()
            Using enumerator = metadataExtractor.ExtractComplexMetadata(filePath)
                While enumerator.MoveNext()
                    Dim metadata = enumerator.Current
                    For Each key As String In metadata.Keys
                        Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
                    Next
                End While
            End Using
            'ExEnd:ExtractMetadataUsingComplexMetadataExtractorInEpub
        End Sub
    End Class

    Public Shared Sub UsingExtractorFactory(fileName As String)
        'ExStart:UsingExtractorFactory
        'get file actual path
        Dim filePath As [String] = Common.getFilePath(fileName)
        Dim factory As New ExtractorFactory()
        Dim metadata As MetadataCollection = factory.ExtractMetadata(filePath)
        If metadata Is Nothing Then
            Console.WriteLine("The document format is not supported")
        End If

        For Each key As String In metadata.Keys
            Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
        Next
        'ExEnd:UsingExtractorFactory
    End Sub


    ''' <summary>
    ''' shows how extractor class is used to extract metadata, this feature is supported ni version 17.03 or greater
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub ExtractClassUsage(fileName As String)
        'ExStart:ExtractClassUsage
        'get file actual path
        Dim filePath As [String] = Common.getFilePath(fileName)
        Dim extractor = New Extractor()
        Dim metadata = extractor.ExtractMetadata(filePath)

        For Each key As String In metadata.Keys
            Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
        Next
        'ExEnd:ExtractClassUsage
    End Sub

    ''' <summary>
    ''' Shows the usage of CreateMetadataExtractor method, the method is supported in version 17.03 or greater
    ''' </summary>
    ''' <param name="fileName"></param>
    Public Shared Sub CreateMetadataExtractorMethodUsage(fileName As String)
        'ExStart:CreateMetadataExtractorMethodUsage
        'get file actual path
        Dim filePath As [String] = Common.getFilePath(fileName)
        Dim factory = New ExtractorFactory()
        Dim extractor = factory.CreateMetadataExtractor(filePath)
        Dim metadata = extractor.ExtractMetadata(filePath)

        For Each key As String In metadata.Keys
            Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
        Next
        'ExEnd:CreateMetadataExtractorMethodUsage
    End Sub

End Class
