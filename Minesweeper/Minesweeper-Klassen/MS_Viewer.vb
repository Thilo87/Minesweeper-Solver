Public Class MS_Viewer
    Private mainWnd As Windows.Forms.Form
    Private WithEvents pbScreen As New Windows.Forms.PictureBox With {.BackColor = Color.White}

    Private _Combination As MS_Combination
    Public Property Combination As MS_Combination
        Get
            Return _Combination
        End Get
        Set(value As MS_Combination)
            _Combination = value
            Refresh()
        End Set
    End Property

    Private _Left As Integer = 0
    Public Property Left As Integer
        Get
            Return _Left
        End Get
        Set(value As Integer)
            _Left = value
            Refresh()
        End Set
    End Property

    Private _Top As Integer = 0
    Public Property Top As Integer
        Get
            Return _Top
        End Get
        Set(value As Integer)
            _Top = value
            Refresh()
        End Set
    End Property

    Private _BlockWidth As Integer = 20
    Private _BlockHeight As Integer = 20

    Private Sub pbScreen_OnPaint(sender As Object, e As PaintEventArgs) Handles pbScreen.Paint
        If Not _Combination Is Nothing Then
            For i As Integer = 0 To _Combination.Height - 1
                For j As Integer = 0 To _Combination.Width - 1

                    e.Graphics.DrawRectangle(Pens.Gray, j * _BlockWidth, i * _BlockHeight, _BlockWidth, _BlockHeight)

                    If _Combination.State(i, j).IsOpen Then
                        e.Graphics.FillRectangle(Brushes.WhiteSmoke, j * _BlockWidth + 1, i * _BlockHeight + 1, _BlockWidth - 2, _BlockHeight - 2)

                        If _Combination.State(i, j).IsMined Then
                            e.Graphics.FillRectangle(Brushes.Red, j * _BlockWidth + 1, i * _BlockHeight + 1, _BlockWidth - 2, _BlockHeight - 2)
                        Else
                            If _Combination.State(i, j).AdjacentMines <> -1 Then
                                e.Graphics.DrawString(_Combination.State(i, j).AdjacentMines, New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, j * _BlockWidth + 4, i * _BlockHeight + 3)
                            End If
                        End If
                    Else
                        If _Combination.State(i, j).MarkState = MS_Field.MarkStates.Flag Then
                            e.Graphics.FillRectangle(Brushes.Green, j * _BlockWidth + 2, i * _BlockHeight + 2, _BlockWidth - 2, _BlockHeight - 2)
                        Else
                            e.Graphics.FillRectangle(Brushes.LightGray, j * _BlockWidth + 2, i * _BlockHeight + 2, _BlockWidth - 2, _BlockHeight - 2)
                        End If
                        If _Combination.State(i, j).MineProbability <> -1.0 Then
                            e.Graphics.DrawString(Math.Round(_Combination.State(i, j).MineProbability, 2), New Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular), Brushes.Black, j * _BlockWidth, i * _BlockHeight + 3)
                        End If
                    End If

                    'e.Graphics.DrawString(j & "," & i, New Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular), Brushes.Black, j * _BlockWidth + 4, i * _BlockHeight + 9)
                Next
            Next
        End If
    End Sub

    Private Sub pbScreen_OnMouseDown(sender As Object, e As MouseEventArgs) Handles pbScreen.MouseDown
        If Not _Combination Is Nothing Then
            If Not _Combination.GameOver Then
                Dim j As Integer = (e.X - e.X Mod _BlockHeight) / _BlockHeight
                Dim i As Integer = (e.Y - e.Y Mod _BlockWidth) / _BlockWidth

                Select Case e.Button
                    Case MouseButtons.Left
                        If Not _Combination.State(i, j).IsOpen Then
                            _Combination.State(i, j).Open()
                            If _Combination.State(i, j).IsMined Then
                                MsgBox("Boom! :(")
                                _Combination.GameOver = True
                            End If
                        End If
                    Case MouseButtons.Right
                        If Not _Combination.State(i, j).IsOpen Then
                            If _Combination.State(i, j).MarkState = MS_Field.MarkStates.Flag Then
                                _Combination.State(i, j).MarkState = MS_Field.MarkStates.No_Mark
                            Else
                                _Combination.State(i, j).MarkState = MS_Field.MarkStates.Flag
                            End If
                        End If
                End Select


                pbScreen.Refresh()
            End If
        End If
    End Sub

    Public Sub Refresh()
        If Not _Combination Is Nothing Then
            pbScreen.Top = _Top
            pbScreen.Left = _Left
            pbScreen.Width = _Combination.Width * _BlockWidth
            pbScreen.Height = _Combination.Height * _BlockHeight
        End If

        pbScreen.Refresh()
    End Sub

    Private Sub RegisterControls()
        With mainWnd.Controls
            .Add(pbScreen)
        End With
    End Sub

    Public Sub New(ByRef mainWnd As Windows.Forms.Form)
        Me.mainWnd = mainWnd
        RegisterControls()
    End Sub
End Class
