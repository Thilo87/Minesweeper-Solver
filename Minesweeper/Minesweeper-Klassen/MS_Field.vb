Public Class MS_Field
    Private _BaseClass As MS_Combination

    Enum MineStates
        No_Mine
        Mine
    End Enum

    Enum OpenStates
        Open
        Closed
    End Enum

    Enum MarkStates
        No_Mark
        Questionmark
        Flag
    End Enum

    Private _X As Integer
    Public ReadOnly Property X As Integer
        Get
            Return _X
        End Get
    End Property

    Private _Y As Integer
    Public ReadOnly Property Y As Integer
        Get
            Return _Y
        End Get
    End Property

    Private _OpenState As OpenStates = OpenStates.Closed
    Public Property OpenState As OpenStates
        Get
            Return _OpenState
        End Get
        Set(value As OpenStates)
            _OpenState = value
        End Set
    End Property

    Private _MineState As MineStates = MineStates.No_Mine
    Public Property MineState As MineStates
        Get
            Return _MineState
        End Get
        Set(value As MineStates)
            _MineState = value
        End Set
    End Property

    Private _MarkState As MarkStates = MarkStates.No_Mark
    Public Property MarkState As MarkStates
        Get
            Return _MarkState
        End Get
        Set(value As MarkStates)
            _MarkState = value
        End Set
    End Property

    Private _MineProbability As Double = -1
    Public Property MineProbability As Double
        Get
            Return _MineProbability
        End Get
        Set(value As Double)
            _MineProbability = value
        End Set
    End Property

    Private _AdjacentMines As Integer = -1
    Public Property AdjacentMines As Integer
        Get
            Return _AdjacentMines
        End Get
        Set(value As Integer)
            _AdjacentMines = value
        End Set
    End Property

    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByRef BaseClass As MS_Combination)
        _X = X
        _Y = Y
        _BaseClass = BaseClass
    End Sub

    Public Function IsMined() As Boolean
        Select Case _MineState
            Case MineStates.Mine
                Return True
            Case MineStates.No_Mine
                Return False
        End Select
    End Function

    Public Function IsOpen() As Boolean
        Select Case _OpenState
            Case OpenStates.Closed
                Return False
            Case OpenStates.Open
                Return True
        End Select
    End Function

    Public Sub Open()
        _OpenState = OpenStates.Open
        _BaseClass.OpenAdjacentClearMines(_X, _Y)
    End Sub
End Class
