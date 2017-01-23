Imports GroupDocs.Text.Extractors.Text
Imports GroupDocs.Text.Containers
Imports GroupDocs.Text.Detectors.MediaType

Public Class ContainerExtractor

    ''' <summary>
    ''' Extract from OST container
    ''' </summary>
    Public Shared Sub ExtractFromOstContainer()
        'ExStart:ExtractFromOstContainer
        Dim factory As New ExtractorFactory()
        Using container = New PersonalStorageContainer("default.ost")
            For i As Integer = 0 To container.Entities.Count - 1
                Console.WriteLine(container.Entities(i).Name)
                Console.WriteLine(container.Entities(i).Path.ToString())
                Console.WriteLine(container.Entities(i).MediaType)
                Console.WriteLine(container.Entities(i)(PersonalStorageContainer.EmailSubject))
                Console.WriteLine(container.Entities(i)(PersonalStorageContainer.EmailSender))
                Console.WriteLine(container.Entities(i)(PersonalStorageContainer.EmailReceiver))

                Using extractor As TextExtractor = factory.CreateTextExtractor(container.Entities(i).OpenStream())
                    Console.WriteLine("Content:")
                    Console.WriteLine(If(extractor IsNot Nothing, extractor.ExtractAll(), "The document format is not supported"))
                End Using
            Next
        End Using
        'ExEnd:ExtractFromOstContainer
    End Sub

    ''' <summary>
    ''' For enumerating all the entities of the group of containers ContainerEnumerator class is used
    ''' </summary>
    Public Shared Sub EnumeratingAllEntities()
        'ExStart:EnumeratingAllEntities
        Dim containerFactory As IContainerFactory = Nothing
        Dim containerMediaTypeDetector As MediaTypeDetector = Nothing
        Dim container As Container = Nothing
        Dim readerFactory As New ExtractorFactory()
        Dim enumerator = New ContainerEnumerator(containerFactory, containerMediaTypeDetector, container)
        While enumerator.MoveNext()
            Using stream = enumerator.Current.OpenStream()
                Using extractor = readerFactory.CreateTextExtractor(stream)
                    Console.WriteLine(If(extractor Is Nothing, "document isn't supported", extractor.ExtractAll()))
                End Using
            End Using
        End While
        'ExEnd:EnumeratingAllEntities
    End Sub


    ''' <summary>
    ''' Enumerates all files in an archived folder
    ''' </summary>
    ''' <param name="folderName">name of the zip archive</param>
    Public Shared Sub EnumerateAllArchivedFiles(folderName As String)
        'ExStart:EnumerateAllArchivedFiles
        'get zip folder's path
        Dim folderPath As String = Common.getFilePath(folderName)

        Using container = New ZipContainer(folderPath)
            For i As Integer = 0 To container.Entities.Count - 1
                Console.WriteLine("Name: " + container.Entities(i).Name)
                Console.WriteLine("Path: " + container.Entities(i).Path.ToString())
                Console.WriteLine("Media type: " + container.Entities(i).MediaType)
            Next
        End Using
        'ExEnd:EnumerateAllArchivedFiles
    End Sub

    ''' <summary>
    ''' Reads concrete files from a zip folder
    ''' </summary>
    ''' <param name="folderName">Name of the zipped folder</param>
    Public Shared Sub ReadConcreteFile(folderName As String)
        'ExStart:ReadConcreteFile
        'get zip folder's path
        Dim folderPath As String = Common.getFilePath(folderName)
        Dim extractorFactory As New ExtractorFactory()

        Using container = New ZipContainer(folderPath)
            For i As Integer = 0 To container.Entities.Count - 1
                Using extractor As TextExtractor = extractorFactory.CreateTextExtractor(container.Entities(i).OpenStream())
                    Console.WriteLine(extractor.ExtractAll())
                End Using
            Next
        End Using
        'ExEnd:ReadConcreteFile
    End Sub


End Class
