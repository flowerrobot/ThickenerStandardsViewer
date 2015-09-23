Imports System.Xml

Public Class SendComment
    Dim _SelectedItem As File
    Const PlaceToWrite As String = "C:\Temp\Comments]"
    Public Property UserName As String = "Optional"
    Public Property Area As AreaTypes
    Public Property Urgency As Integer
    Public AreaTypesList As New List(Of ComboBoxItem)
    Private Sub New()
        InitializeComponent()
        Me.DataContext = Me
        '    AreaTypesList.Add()
    End Sub
    Sub New(ByVal SelectedItem As File)
        Me.New
        _SelectedItem = SelectedItem
    End Sub
    Private Sub Btn_Ok_Click(sender As Object, e As RoutedEventArgs)
        If SubmitComment() Then
            Me.DialogResult = True
            Me.Close()
        Else
            MsgBox("Can not submit comment right now, please try again")
        End If
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As RoutedEventArgs)
        Me.DialogResult = False
        Me.Close()
    End Sub
    Function SubmitComment() As Boolean
        Try
            If IO.Directory.Exists(PlaceToWrite) Then
                Dim XmlFile As XmlDocument = New XmlDocument()
                Try
                    With XmlFile
                        Dim TopNode As XmlElement = .CreateElement("UserComment")
                        .AppendChild(TopNode)
                        Dim Node As XmlElement = .CreateElement("UserName")
                        Node.Value = UserName
                        TopNode.AppendChild(Node)
                    End With
                    XmlFile.Save(PlaceToWrite & "Comment")
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Enum AreaTypes As Integer
        Drawings_Bug = 1
        Drawing_Request = 2
        Drawing_Suggestion = 3
        Program_Feature_Request = 4
        Program_Bug = 5
    End Enum
End Class
