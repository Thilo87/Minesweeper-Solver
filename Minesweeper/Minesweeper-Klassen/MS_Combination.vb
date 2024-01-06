Public Class MS_Combination
    Private _State As MS_Field(,)
    Public ReadOnly Property State As MS_Field(,)
        Get
            Return _State
        End Get
    End Property

    Private _Width As Integer
    Public ReadOnly Property Width As Integer
        Get
            Return _Width
        End Get
    End Property

    Private _Height As Integer
    Public ReadOnly Property Height As Integer
        Get
            Return _Height
        End Get
    End Property

    Private _Mines As Integer

    Private _GameOver As Boolean = False
    Public Property GameOver As Boolean
        Get
            Return _GameOver
        End Get
        Set(value As Boolean)
            _GameOver = value
        End Set
    End Property

    Public Sub Clear()
        For y As Integer = 0 To _Height - 1
            For x As Integer = 0 To _Width - 1
                _State(y, x) = New MS_Field(x, y, Me)
            Next
        Next
    End Sub

    Friend Sub OpenAdjacentClearMines(ByVal X As Integer, ByVal Y As Integer)
        If _State(Y, X).AdjacentMines = -1 And Not _State(Y, X).IsMined Then
            For k As Integer = -1 To 1
                For l As Integer = -1 To 1

                    If Y + k >= 0 And Y + k <= _Height - 1 And X + l >= 0 And X + l <= _Width - 1 Then
                        If Not (k = -1 And l = -1) And Not (k = 1 And l = -1) And Not (k = -1 And l = 1) And Not (k = 1 And l = 1) Then
                            If Not _State(Y + k, X + l).IsMined And Not _State(Y + k, X + l).IsOpen Then
                                _State(Y + k, X + l).Open()
                            End If
                        Else
                            If Not _State(Y + k, X + l).AdjacentMines = -1 Then
                                _State(Y + k, X + l).Open()
                            End If
                        End If
                    End If

                Next
            Next
        End If
    End Sub

    Public Function Subset(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As MS_Combination
        Dim newState(y2 - y1, x2 - x1) As MS_Field

        For y As Integer = y1 To y2
            For x As Integer = x1 To x2
                newState(y - y1, x - x1) = _State(y, x)
            Next
        Next

        Return New MS_Combination(newState)
    End Function

    Public Sub Restart()
        Dim possFields As New List(Of MS_Field)

        For i As Integer = 0 To _Height - 1
            For j As Integer = 0 To _Width - 1
                possFields.Add(New MS_Field(j, i, Me))
            Next
        Next

        ' Minen zufällig platzieren
        Randomize()
        Dim placedMines As Integer = 0
        Do Until placedMines = _Mines
            Dim rndNmbr As Integer = CInt(Rnd() * (possFields.Count - 1))
            If possFields(rndNmbr).MineState = MS_Field.MineStates.No_Mine Then
                possFields(rndNmbr).MineState = MS_Field.MineStates.Mine
                placedMines += 1
            End If
        Loop

        ' Zustand aktualisieren
        For i As Integer = 0 To possFields.Count - 1
            _State(possFields(i).Y, possFields(i).X) = possFields(i)
        Next

        ' benachbarte Minen berechnen
        RefreshAdjacentMines()
        _GameOver = False
    End Sub

    Public Sub RefreshAdjacentMines()
        For i As Integer = 0 To _Height - 1
            For j As Integer = 0 To _Width - 1

                Dim adjacentMines As Integer = 0
                For k As Integer = -1 To 1
                    For l As Integer = -1 To 1
                        If i + k >= 0 And i + k <= _Height - 1 And j + l >= 0 And j + l <= _Width - 1 Then
                            If _State(i + k, j + l).IsMined Then
                                adjacentMines += 1
                            End If
                        End If
                    Next
                Next

                If adjacentMines <> 0 Then _State(i, j).AdjacentMines = adjacentMines
            Next
        Next
    End Sub

    Public Sub New(ByVal State As MS_Field(,))
        _Height = UBound(State, 1) + 1
        _Width = UBound(State, 2) + 1
        _State = State
    End Sub

    Public Sub New(ByVal Width As Integer, ByVal Height As Integer, ByVal Mines As Integer)
        _Width = Width
        _Height = Height
        _Mines = Mines

        ReDim _State(_Height - 1, _Width - 1)
        Restart()
    End Sub
End Class
