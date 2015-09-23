Imports System.Collections.ObjectModel
Imports System
Public Class Top_Level_Files
    Dim Files As ObservableCollection(Of TopFile)
    Dim Folders As ObservableCollection(Of TopFile)
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = Me
        DG_Folders.ItemsSource = New ObservableCollection(Of TopFile)(TopFile.FolderPaths)
        DG_Names.ItemsSource = New ObservableCollection(Of TopFile)(TopFile.FileNames)
    End Sub

    Private Sub Close_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        Me.DialogResult = False
        Me.Close()
    End Sub

    Private Sub btn_Ok_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        TopFile.FolderPaths = DG_Folders.ItemsSource
        TopFile.FileNames = DG_Names.ItemsSource
        TopFile.WriteXML()
        Me.DialogResult = True
        Me.Close()
    End Sub
End Class
