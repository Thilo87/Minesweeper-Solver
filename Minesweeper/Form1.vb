Option Strict On
Public Class Form1
    Public MS_Viewer As New MS_Viewer(Me) With {.Left = 10, .Top = 10}
    Public MS_Combination As New MS_Combination(15, 15, 30)
    Public MS_Solver As New MS_Solver_Logical(MS_Combination)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MS_Viewer.Combination = MS_Combination
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MS_Solver.StepForward()
        MS_Viewer.Combination = MS_Combination
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MS_Combination.Restart()
        MS_Solver.Clear()
        MS_Viewer.Combination = MS_Combination
    End Sub
End Class
