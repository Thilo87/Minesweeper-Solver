Public Class MS_Solver_Logical
    Private _Combination As MS_Combination
    Private _BooleanExpressionEvaluator As New BEE

    Private _KB As New Knowledge_Base
    'Private _KnowledgeEditor As New KB_DataEditor(_KB)

    Public Sub Clear()
        _KB.Clear(Knowledge_Base.ClearTypes.All)
    End Sub

    Public Sub StepForward()
        If Not _Combination.GameOver Then

            ' Alle einzelnen Felder des Minesweeper-Feldes durchgehen
            For y As Integer = 0 To _Combination.Height - 1
                For x As Integer = 0 To _Combination.Width - 1

                    ' Ein Feld ermitteln, welches offen ist und eine Zahl enthält, ermitteln
                    If _Combination.State(y, x).IsOpen And _Combination.State(y, x).AdjacentMines > 0 Then

                        ' alle umgebenden Felder ermitteln, die geschlossen sind (also eine Mine enthalten könnten)
                        Dim adjacentFields As New List(Of MS_Field)
                        For k As Integer = -1 To 1
                            For l As Integer = -1 To 1
                                If Not (k = 0 And l = 0) Then
                                    If y + k >= 0 And y + k <= _Combination.Height - 1 And x + l >= 0 And x + l <= _Combination.Width - 1 Then
                                        If Not _Combination.State(y + k, x + l).IsOpen Then

                                            ' der Knowledge Base ("_KB") eine Variable hinzufügen, die dieses mögliche Minenfeld repräsentiert
                                            _KB.AddVariable("M" & x + l & "," & y + k)
                                            adjacentFields.Add(_Combination.State(y + k, x + l))
                                        End If
                                    End If
                                End If
                            Next
                        Next

                        ' die möglichen Verteilungen der Minen ermitteln
                        Dim possibleMineAllocations As New List(Of String)
                        For i As Integer = 0 To CInt(2 ^ adjacentFields.Count - 1)
                            Dim Combination As String = Convert.ToString(i, 2).PadLeft(adjacentFields.Count, CChar("0"))

                            If Combination.Length - Combination.Replace("1", "").Length = _Combination.State(y, x).AdjacentMines Then
                                possibleMineAllocations.Add(Combination)
                            End If
                        Next

                        ' logische Sätze bilden, wie die Minen verteilt sein könnten, und diese der Wissensbasis / Knowledge-Base hinzufügen
                        Dim Sentence As String = ""
                        For Each MineAllocation As String In possibleMineAllocations
                            Sentence &= "("

                            Dim unminedFields As New List(Of String)
                            Dim minedFields As New List(Of String)
                            For i As Integer = 0 To MineAllocation.Length - 1
                                If MineAllocation(i) = "0" Then
                                    unminedFields.Add("M" & adjacentFields(i).X & "," & adjacentFields(i).Y)
                                ElseIf MineAllocation(i) = "1" Then
                                    minedFields.Add("M" & adjacentFields(i).X & "," & adjacentFields(i).Y)
                                End If
                            Next

                            Dim minedFieldsPart As String = ""
                            If minedFields.Count > 0 Then
                                minedFieldsPart &= "("
                                For Each minedField As String In minedFields
                                    minedFieldsPart &= minedField & " and "
                                Next
                                minedFieldsPart = minedFieldsPart.Substring(0, minedFieldsPart.Length - 5)
                                minedFieldsPart &= ")"
                            End If

                            Dim unminedFieldsPart As String = ""
                            If unminedFields.Count > 0 Then
                                unminedFieldsPart &= "not ("
                                For Each unminedField As String In unminedFields
                                    unminedFieldsPart &= unminedField & " or "
                                Next
                                unminedFieldsPart = unminedFieldsPart.Substring(0, unminedFieldsPart.Length - 4)
                                unminedFieldsPart &= ")"
                            End If


                            If minedFields.Count = 1 Then
                                Sentence &= "not (not " & minedFields(0) & ")"
                                If unminedFields.Count > 0 Then
                                    Sentence &= " and " & unminedFieldsPart
                                End If
                            Else

                                If minedFields.Count > 0 And unminedFields.Count = 0 Then
                                    Sentence &= minedFieldsPart
                                ElseIf minedFields.Count = 0 And unminedFields.Count > 0 Then
                                    Sentence &= unminedFieldsPart
                                ElseIf minedFields.Count <> 0 And unminedFields.Count <> 0 Then
                                    Sentence &= minedFieldsPart & " and " & unminedFieldsPart
                                End If
                            End If

                            Sentence &= ") or "
                        Next
                        Sentence = Sentence.Substring(0, Sentence.Length - 4)
                        _KB.Tell(Sentence)
                    End If
                Next
            Next

            ' jede Spalte in der Wahrheitstabelle überprüfen, ob sie nur einen Wert true oder false enthält
            For y As Integer = 0 To _Combination.Height - 1
                For x As Integer = 0 To _Combination.Width - 1
                    If _KB.Variables.Contains("M" & x & "," & y) Then
                        If _KB.Ask("not (not M" & x & "," & y & ")") Then
                            ' die Spalte enthält nur true, daher ist es eine Mine. Dieses Feld als Mine markieren.
                            _Combination.State(y, x).MarkState = MS_Field.MarkStates.Flag
                        ElseIf _KB.Ask("not M" & x & "," & y) Then
                            ' die Spalte enthält nur false, daher ist es keine Mine. Das Feld kann geöffnet werden.
                            _Combination.State(y, x).Open()
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Public Sub New(ByRef Combination As MS_Combination)
        _Combination = Combination
        '_KnowledgeEditor.Show()
    End Sub
End Class
