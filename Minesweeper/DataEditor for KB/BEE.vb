Public Class BEE
    Private Sub ReplaceVariable(ByRef Part As String, ByRef Model As Dictionary(Of String, Boolean))
        If Part <> "true" And Part <> "false" Then
            Select Case Model(Part)
                Case True
                    Part = "true"
                Case False
                    Part = "false"
            End Select
        End If
    End Sub

    Private Sub Eval(ByRef Expression As String, ByRef Model As Dictionary(Of String, Boolean))
        If Expression <> "true" And Expression <> "false" Then
            Dim subparts As List(Of String) = Expression.Split(" ").ToList
            For i As Integer = 0 To subparts.Count - 1
                If i < subparts.Count Then
                    If subparts(i) = "not" Then
                        ReplaceVariable(subparts(i + 1), Model)

                        If subparts(i + 1) = "true" Then
                            subparts(i + 1) = "false"
                        Else
                            subparts(i + 1) = "true"
                        End If
                        subparts.RemoveAt(i)
                    End If
                End If
            Next

            For i As Integer = 0 To subparts.Count - 1
                If i < subparts.Count Then
                    If subparts(i) = "and" Then
                        ReplaceVariable(subparts(i - 1), Model)
                        ReplaceVariable(subparts(i + 1), Model)

                        If Not (subparts(i - 1) = "true" And subparts(i + 1) = "true") Then
                            subparts(i + 1) = "false"
                        End If
                        subparts.RemoveAt(i)
                        subparts.RemoveAt(i - 1)

                        i -= 1
                    End If
                End If
            Next

            For i As Integer = 0 To subparts.Count - 1
                If i < subparts.Count Then
                    If subparts(i) = "or" Then
                        ReplaceVariable(subparts(i - 1), Model)
                        ReplaceVariable(subparts(i + 1), Model)

                        If subparts(i - 1) = "true" Or subparts(i + 1) = "true" Then
                            subparts(i + 1) = "true"
                        Else
                            subparts(i + 1) = "false"
                        End If
                        subparts.RemoveAt(i)
                        subparts.RemoveAt(i - 1)
                        i -= 1
                    End If
                End If
            Next

            For i As Integer = 0 To subparts.Count - 1
                If i < subparts.Count Then
                    If subparts(i) = "xor" Then
                        ReplaceVariable(subparts(i - 1), Model)
                        ReplaceVariable(subparts(i + 1), Model)

                        If subparts(i - 1) = "true" Or subparts(i + 1) = "true" Then
                            If subparts(i - 1) = "true" And subparts(i + 1) = "true" Then
                                subparts(i + 1) = "false"
                            Else
                                subparts(i + 1) = "true"
                            End If
                        Else
                            subparts(i + 1) = "false"
                        End If
                        subparts.RemoveAt(i)
                        subparts.RemoveAt(i - 1)
                        i -= 1
                    End If
                End If
            Next

            For i As Integer = 0 To subparts.Count - 1
                If i < subparts.Count Then
                    If subparts(i) = "imp" Then
                        ReplaceVariable(subparts(i - 1), Model)
                        ReplaceVariable(subparts(i + 1), Model)

                        If Not (subparts(i - 1) = "true" And subparts(i + 1) = "false") Then
                            subparts(i + 1) = "true"
                        End If
                        subparts.RemoveAt(i)
                        subparts.RemoveAt(i - 1)
                        i -= 1
                    End If
                End If
            Next

            For i As Integer = 0 To subparts.Count - 1
                If i < subparts.Count Then
                    If subparts(i) = "equ" Then
                        ReplaceVariable(subparts(i - 1), Model)
                        ReplaceVariable(subparts(i + 1), Model)

                        If subparts(i - 1) = subparts(i + 1) Then
                            subparts(i + 1) = "true"
                        Else
                            subparts(i + 1) = "false"
                        End If
                        subparts.RemoveAt(i)
                        subparts.RemoveAt(i - 1)
                        i -= 1
                    End If
                End If
            Next

            Expression = subparts(0)
        End If
    End Sub

    Private Function Parse(ByVal Expression As String, ByRef Model As Dictionary(Of String, Boolean)) As String
        Try
            Dim bracketBilance As Integer = 0
            Dim bracketExists As Boolean = False

            For i As Integer = 0 To Expression.Length
                If i < Expression.Length Then
                    If Expression(i) = "(" Then
                        bracketBilance += 1
                        bracketExists = True

                        For j As Integer = i + 1 To Expression.Length - 1
                            If Expression(j) = "(" Then
                                bracketBilance += 1
                            ElseIf Expression(j) = ")" Then
                                bracketBilance -= 1
                            End If

                            If bracketBilance = 0 Then
                                Dim result As String = Parse(Expression.Substring(i + 1, j - i - 1), Model)
                                Expression = Expression.Remove(i, j - i + 1)
                                Expression = Expression.Insert(i, result)
                                i = -1
                                Exit For
                            End If
                        Next
                    End If
                Else
                    Exit For
                End If
            Next

            Eval(Expression, Model)
            Return Expression
        Catch ex As ArgumentOutOfRangeException
            MsgBox("Boolean Expression Evaluator error: " & vbNewLine & vbNewLine & ex.ToString)
            Application.Exit()
        End Try
    End Function

    Public Function Evaluate(ByRef Expression As String, ByRef Model As Dictionary(Of String, Boolean)) As Boolean
        Dim result As String = Parse(Expression, Model)
        Select Case result
            Case "true"
                Return True
            Case "false"
                Return False
            Case Else
                MsgBox("Unknown Boolean Expression Evaluator error.")
                Application.Exit()
        End Select
    End Function
End Class
