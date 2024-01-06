Public Class KB_DataEditor
    Private _Knowledge_Base As Knowledge_Base
    Private _ModelViewer As KB_ModelViewer

    Public Sub New(ByRef Knowledge_Base As Knowledge_Base)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        _Knowledge_Base = Knowledge_Base

        Me.Top = 0
        Me.Left = 0

        _ModelViewer = New KB_ModelViewer(_Knowledge_Base) With {.Top = Me.Top + Me.Height, .Left = Me.Left, .Width = Me.Width}
        _ModelViewer.Show()

        Refresh()
    End Sub

    Public Overrides Sub Refresh()
        lstKnowledge.Items.Clear()
        For Each Sentence As String In _Knowledge_Base.Knowledge
            lstKnowledge.Items.Add(Sentence)
        Next

        lstVariables.Items.Clear()
        For Each Variable As String In _Knowledge_Base.Variables
            lstVariables.Items.Add(Variable)
        Next

        lblModelCount.Text = _Knowledge_Base.Models.Count
    End Sub

    Private Sub btnRefreshKnowledgeList_Click(sender As Object, e As EventArgs) Handles btnRefreshKnowledgeList.Click
        Refresh()
    End Sub

    Private Sub btnTell_Click(sender As Object, e As EventArgs) Handles btnTell.Click
        If txtTellSentence.Text <> "" Then
            _Knowledge_Base.Tell(txtTellSentence.Text)
            _ModelViewer.RefreshData()
            Refresh()
        End If
    End Sub

    Private Sub btnAddVariable_Click(sender As Object, e As EventArgs) Handles btnAddVariable.Click
        If txtVariable.Text <> "" Then
            _Knowledge_Base.AddVariable(txtVariable.Text)
            _ModelViewer.RefreshData()
            Refresh()
        End If
    End Sub


    Private Sub btnShowAllModels_Click(sender As Object, e As EventArgs) Handles btnShowAllModels.Click
        _ModelViewer.Show()
    End Sub


    Private Sub btnClearKnowledge_Click(sender As Object, e As EventArgs) Handles btnClearKnowledge.Click
        _Knowledge_Base.Clear(Knowledge_Base.ClearTypes.Knowledge)
        Refresh()
        _ModelViewer.RefreshData()
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        _Knowledge_Base.Clear(Knowledge_Base.ClearTypes.All)
        Refresh()
        _ModelViewer.RefreshData()
    End Sub

    Private Sub KB_DataViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class