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
            Dim filePath As [String] = Utilities.getFilePath(fileName)
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
            Dim filePath As [String] = Utilities.getFilePath(fileName)
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
            Dim filePath As [String] = Utilities.getFilePath(fileName)
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
            Dim filePath As [String] = Utilities.getFilePath(fileName)
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
            Dim filePath As [String] = Utilities.getFilePath(fileName)
            Dim extractor As New EmailMetadataExtractor()
            Dim metadata As MetadataCollection = extractor.ExtractMetadata(filePath)
            For Each key As String In metadata.Keys
                Console.WriteLine(String.Format("{0} = {1}", key, metadata(key)))
            Next
            'ExEnd:ExtractMetadataFromEmails
        End Sub
    End Class

    Public Shared Sub UsingExtractorFactory(fileName As String)
        'ExStart:UsingExtractorFactory
        'get file actual path
        Dim filePath As [String] = Utilities.getFilePath(fileName)
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

End Class
