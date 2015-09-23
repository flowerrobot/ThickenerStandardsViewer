Imports System.Collections.ObjectModel
Imports System.Xml

Class TopFile
#If Not RELEASED Then
    Private Const FileLocation As String = "C:\Temp\ThickenerStandards\TopLevelFiles.xml"
#Else
    Private Const FileLocation As String = "\\SYDDT991\Robot Programs\ThickenerStandards\TopLevelFiles.xml" '"C:\Temp\Exclusion.xml"
#End If
    Private Const PersonalFiles As String = "C:\temp\TopLevelFiles.xml"
    Const FolderNode As String = "FolderPath"
    Const FileNode As String = "FilePath"
#Region "Shared functions"
    Shared _FolderPaths As ObservableCollection(Of TopFile)
    Shared _FileNames As ObservableCollection(Of TopFile)
    Shared _Files As New ObservableCollection(Of File)
    Public Shared Property IsInitilized As Boolean
#Region "Conts"
    Const DWG As String = ".dwg"
    'To-DO Solidworks handling for design sheets - Low
    Const SLDDRW As String = ".slddrw"
#End Region
    Public Shared ReadOnly Property Files As ObservableCollection(Of File)
        Get
            If Not IsInitilized Then
                Initilized()
            End If
            Return _Files
        End Get
    End Property

    Public Shared Property FolderPaths As ObservableCollection(Of TopFile)
        Get
            If Not IsInitilized Then
                Initilized()
            End If
            Return _FolderPaths
        End Get
        Set(value As ObservableCollection(Of TopFile))
            _FolderPaths = value
        End Set
    End Property
    Public Shared Property FileNames As ObservableCollection(Of TopFile)
        Get
            If Not IsInitilized Then
                Initilized()
            End If
            Return _FileNames
        End Get
        Set(value As ObservableCollection(Of TopFile))
            _FileNames = value
        End Set
    End Property

    Private Shared Function readXML() As Boolean
        If IO.File.Exists(FileLocation) Then
            Try
                FolderPaths = New ObservableCollection(Of TopFile)
                FileNames = New ObservableCollection(Of TopFile)

                Dim XMLFile As XmlReader = XmlReader.Create(FileLocation)
                Do While XMLFile.Read
                    Select Case XMLFile.Name
                        Case FolderNode
                            FolderPaths.Add(New TopFile(XMLFile.GetAttribute("Value"), True))
                        Case FileNode
                            FileNames.Add(New TopFile(XMLFile.GetAttribute("Value")))
                    End Select
                Loop
                If IO.File.Exists(PersonalFiles) Then
                    XMLFile = XmlReader.Create(PersonalFiles)
                    Do While XMLFile.Read
                        Select Case XMLFile.Name
                            Case FolderNode
                                FolderPaths.Add(New TopFile(XMLFile.GetAttribute("Value")))
                            Case FileNode
                                FileNames.Add(New TopFile(XMLFile.GetAttribute("Value")))
                        End Select
                    Loop
                End If
                Return True
            Catch ex As Exception
            End Try
        End If
        Return False
    End Function
    Public Shared Function WriteXML() As Boolean
        If IO.Directory.Exists(IO.Path.GetDirectoryName(FileLocation)) Then
            Try
                Dim XMLFile As New XmlDocument()
                Dim Header As XmlElement = XMLFile.CreateElement("xml")
                XMLFile.AppendChild(Header)
                Dim Root As XmlElement = XMLFile.CreateElement("Data")
                Header.AppendChild(Root)
                For Each Node As TopFile In FolderPaths
                    If Node.IsEditable Then
                        Dim Child As XmlElement = XMLFile.CreateElement(FolderNode)
                        Child.SetAttribute("Value", Node.Path)
                        Root.AppendChild(Child)
                    End If
                Next
                For Each Node As TopFile In FileNames
                    If Node.IsEditable Then
                        Dim Child As XmlElement = XMLFile.CreateElement(FileNode)
                        Child.SetAttribute("Value", Node.Path)
                        Root.AppendChild(Child)
                    End If
                Next
                XMLFile.Save(FileLocation)
                Return True
            Catch ex As Exception
            End Try
        End If
        Return False
    End Function
    Private Shared Sub Initilized()
        FolderPaths = New ObservableCollection(Of TopFile)
        FileNames = New ObservableCollection(Of TopFile)
        IsInitilized = True

        If Not readXML() Then
            FolderPaths.Add(New TopFile("C:\EDM_SEAP\20 Products\Thickeners\Global\00 - Common\03 - Design Sheets"))

            FileNames.Add(New TopFile("C:\EDM_SEAP\20 Products\Thickeners\Global\70 - Mechanism\03 - Design Sheets\OU650064066.dwg"))
        End If

        Try
            For Each File As TopFile In TopFile.FileNames
                If File.IsValid Then
                    Files.Add(New File(File.Path))
                End If
            Next
            For Each Path As TopFile In TopFile.FolderPaths
                If Path.IsValid Then
                    For Each file As String In IO.Directory.GetFiles(Path.Path)
                        If IO.Path.GetExtension(file).ToLower = DWG Then
                            Files.Add(New File(file))
                        End If
                    Next
                End If
            Next
        Catch
        End Try
    End Sub
#End Region
    Dim _Path As String
    Sub New()
        IsEditable = True
    End Sub
    Sub New(iPath As String, Optional iIsEditable As Boolean = True)
        Path = iPath
        IsEditable = iIsEditable
    End Sub
    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property
    Public ReadOnly Property IsValid As Boolean
        Get
            Try
                If IsFile Then
                    If IO.File.Exists(Path) Then
                        Return True
                    End If
                Else
                    If IO.Directory.Exists(Path) Then
                        Return True
                    End If
                End If
            Catch
            End Try
            Return False
        End Get
    End Property
    Public ReadOnly Property IsFile As Boolean
        Get
            Return IO.Path.GetExtension(Path) <> ""
        End Get
    End Property
    Public Property IsEditable As Boolean
End Class
