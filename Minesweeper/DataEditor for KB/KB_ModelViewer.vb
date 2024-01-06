Public Class KB_ModelViewer
    Private _Knowledge_Base As Knowledge_Base

    Public Sub New(ByRef Knowledge_Base As Knowledge_Base)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        _Knowledge_Base = Knowledge_Base
        RefreshData()
    End Sub

    Public Sub RefreshData()
        lvAllModels.Clear()
        If _Knowledge_Base.Models.Count > 0 Then
            For Each Pair As KeyValuePair(Of String, Boolean) In _Knowledge_Base.Models(0)
                lvAllModels.Columns.Add(Pair.Key)
            Next
        End If

        For i As Integer = 0 To _Knowledge_Base.Models.Count - 1
            If _Knowledge_Base.Models(i).Count > 0 Then
                If _Knowledge_Base.Models(i).ElementAt(0).Value = True Then
                    lvAllModels.Items.Add("1")
                Else
                    lvAllModels.Items.Add("0")
                End If


                With lvAllModels.Items(lvAllModels.Items.Count - 1)
                    For j As Integer = 1 To _Knowledge_Base.Models(i).Count - 1
                        If _Knowledge_Base.Models(i).ElementAt(j).Value = True Then
                            .SubItems.Add("1")
                        Else
                            .SubItems.Add("0")
                        End If
                        '.SubItems.Add(_Knowledge_Base.Models(i).ElementAt(j).Value)
                    Next
                End With
            End If
        Next
    End Sub

    Private Sub KB_ShowAllModels_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshData()
    End Sub
End Class