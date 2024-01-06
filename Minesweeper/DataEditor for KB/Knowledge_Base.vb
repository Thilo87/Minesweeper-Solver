Public Class Knowledge_Base
    Private _Knowledge As New List(Of String)
    Public ReadOnly Property Knowledge As List(Of String)
        Get
            Return _Knowledge
        End Get
    End Property

    Private _Variables As New List(Of String)
    Public ReadOnly Property Variables As List(Of String)
        Get
            Return _Variables
        End Get
    End Property

    Private _Models As New List(Of Dictionary(Of String, Boolean))
    Public ReadOnly Property Models As List(Of Dictionary(Of String, Boolean))
        Get
            Return _Models
        End Get
    End Property

    Private _BooleanExpressionEvaluator As New BEE


    Public Sub AddVariable(ByVal Name As String)
        If Not _Variables.Contains(Name) Then
            _Variables.Add(Name)
            If _Variables.Count = 1 Then
                _Models.Add(New Dictionary(Of String, Boolean))
                _Models.Last.Add(Name, True)
                _Models.Add(New Dictionary(Of String, Boolean))
                _Models.Last.Add(Name, False)
            Else
                For i As Integer = 0 To _Models.Count - 1
                    _Models.Add(New Dictionary(Of String, Boolean)(_Models(i)))
                    _Models(i).Add(Name, True)
                    _Models(_Models.Count - 1).Add(Name, False)
                Next
            End If
        End If
    End Sub

    Public Sub Tell(ByVal Sentence As String)
        If Not _Knowledge.Contains(Sentence) Then
            Dim i As Integer = 0
            Do Until i = _Models.Count
                If Not _BooleanExpressionEvaluator.Evaluate(Sentence, _Models(i)) Then
                    _Models.RemoveAt(i)
                    i -= 1
                End If
                i += 1
            Loop
            _Knowledge.Add(Sentence)
        End If
    End Sub

    Public Function Ask(ByVal Sentence As String) As Boolean
        For i As Integer = 0 To _Models.Count - 1
            If Not _BooleanExpressionEvaluator.Evaluate(Sentence, _Models(i)) Then
                Return False
            End If
        Next
        Return True
    End Function


    Enum ClearTypes
        Knowledge
        All
    End Enum

    Public Sub Clear(ByVal Type As ClearTypes)
        Select Case Type
            Case ClearTypes.All
                _Knowledge.Clear()
                _Variables.Clear()
                _Models.Clear()
            Case ClearTypes.Knowledge
                _Knowledge.Clear()
                _Models.Clear()

                Dim backupVariables As List(Of String) = New List(Of String)(_Variables)
                _Variables.Clear()
                For Each Variable As String In backupVariables
                    AddVariable(Variable)
                Next
        End Select
    End Sub


    Private Shared Function Bruteforce(chars As Char(), count As Integer, includeSubLists As Boolean) As String()
        If count < 1 Then Return New String(-1) {}
        Dim buffer As String()
        Dim oldBuffer = {String.Empty}
        Dim result = New List(Of String)()
        While count > 0
            count -= 1
            buffer = New String(oldBuffer.Length * chars.Length - 1) {}
            Dim index = 0
            For i = 0 To oldBuffer.Length - 1
                For j = 0 To chars.Length - 1
                    buffer(index) = oldBuffer(i) & chars(j)
                    index += 1
                Next
            Next
            oldBuffer = buffer
            If includeSubLists OrElse count = 0 Then result.AddRange(buffer)
        End While
        Return result.ToArray()
    End Function
End Class
