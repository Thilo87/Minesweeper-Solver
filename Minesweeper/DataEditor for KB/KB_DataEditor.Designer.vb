<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KB_DataEditor
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstKnowledge = New System.Windows.Forms.ListBox()
        Me.txtTellSentence = New System.Windows.Forms.TextBox()
        Me.btnTell = New System.Windows.Forms.Button()
        Me.btnAsk = New System.Windows.Forms.Button()
        Me.txtAskSentence = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefreshKnowledgeList = New System.Windows.Forms.Button()
        Me.lstVariables = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVariable = New System.Windows.Forms.TextBox()
        Me.btnAddVariable = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblModelCount = New System.Windows.Forms.Label()
        Me.btnShowAllModels = New System.Windows.Forms.Button()
        Me.btnClearKnowledge = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstKnowledge
        '
        Me.lstKnowledge.FormattingEnabled = True
        Me.lstKnowledge.Location = New System.Drawing.Point(12, 44)
        Me.lstKnowledge.Name = "lstKnowledge"
        Me.lstKnowledge.Size = New System.Drawing.Size(813, 303)
        Me.lstKnowledge.TabIndex = 0
        '
        'txtTellSentence
        '
        Me.txtTellSentence.Location = New System.Drawing.Point(12, 363)
        Me.txtTellSentence.Name = "txtTellSentence"
        Me.txtTellSentence.Size = New System.Drawing.Size(732, 20)
        Me.txtTellSentence.TabIndex = 1
        '
        'btnTell
        '
        Me.btnTell.Location = New System.Drawing.Point(750, 363)
        Me.btnTell.Name = "btnTell"
        Me.btnTell.Size = New System.Drawing.Size(75, 23)
        Me.btnTell.TabIndex = 2
        Me.btnTell.Text = "Tell"
        Me.btnTell.UseVisualStyleBackColor = True
        '
        'btnAsk
        '
        Me.btnAsk.Location = New System.Drawing.Point(750, 405)
        Me.btnAsk.Name = "btnAsk"
        Me.btnAsk.Size = New System.Drawing.Size(75, 23)
        Me.btnAsk.TabIndex = 3
        Me.btnAsk.Text = "Ask"
        Me.btnAsk.UseVisualStyleBackColor = True
        '
        'txtAskSentence
        '
        Me.txtAskSentence.Location = New System.Drawing.Point(12, 405)
        Me.txtAskSentence.Name = "txtAskSentence"
        Me.txtAskSentence.Size = New System.Drawing.Size(732, 20)
        Me.txtAskSentence.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Knowledge:"
        '
        'btnRefreshKnowledgeList
        '
        Me.btnRefreshKnowledgeList.Location = New System.Drawing.Point(750, 18)
        Me.btnRefreshKnowledgeList.Name = "btnRefreshKnowledgeList"
        Me.btnRefreshKnowledgeList.Size = New System.Drawing.Size(75, 20)
        Me.btnRefreshKnowledgeList.TabIndex = 6
        Me.btnRefreshKnowledgeList.Text = "Refresh"
        Me.btnRefreshKnowledgeList.UseVisualStyleBackColor = True
        '
        'lstVariables
        '
        Me.lstVariables.FormattingEnabled = True
        Me.lstVariables.Location = New System.Drawing.Point(12, 487)
        Me.lstVariables.Name = "lstVariables"
        Me.lstVariables.Size = New System.Drawing.Size(420, 121)
        Me.lstVariables.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 464)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Variables:"
        '
        'txtVariable
        '
        Me.txtVariable.Location = New System.Drawing.Point(12, 614)
        Me.txtVariable.Name = "txtVariable"
        Me.txtVariable.Size = New System.Drawing.Size(339, 20)
        Me.txtVariable.TabIndex = 9
        '
        'btnAddVariable
        '
        Me.btnAddVariable.Location = New System.Drawing.Point(357, 614)
        Me.btnAddVariable.Name = "btnAddVariable"
        Me.btnAddVariable.Size = New System.Drawing.Size(75, 23)
        Me.btnAddVariable.TabIndex = 10
        Me.btnAddVariable.Text = "Add"
        Me.btnAddVariable.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(466, 464)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Models:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(652, 464)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Count:"
        '
        'lblModelCount
        '
        Me.lblModelCount.AutoSize = True
        Me.lblModelCount.Location = New System.Drawing.Point(712, 464)
        Me.lblModelCount.Name = "lblModelCount"
        Me.lblModelCount.Size = New System.Drawing.Size(13, 13)
        Me.lblModelCount.TabIndex = 13
        Me.lblModelCount.Text = "0"
        '
        'btnShowAllModels
        '
        Me.btnShowAllModels.Location = New System.Drawing.Point(469, 487)
        Me.btnShowAllModels.Name = "btnShowAllModels"
        Me.btnShowAllModels.Size = New System.Drawing.Size(261, 23)
        Me.btnShowAllModels.TabIndex = 17
        Me.btnShowAllModels.Text = "Show all models"
        Me.btnShowAllModels.UseVisualStyleBackColor = True
        '
        'btnClearKnowledge
        '
        Me.btnClearKnowledge.Location = New System.Drawing.Point(206, 18)
        Me.btnClearKnowledge.Name = "btnClearKnowledge"
        Me.btnClearKnowledge.Size = New System.Drawing.Size(113, 23)
        Me.btnClearKnowledge.TabIndex = 18
        Me.btnClearKnowledge.Text = "Clear knowledge"
        Me.btnClearKnowledge.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(325, 18)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(113, 23)
        Me.btnClearAll.TabIndex = 19
        Me.btnClearAll.Text = "Clear all"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'KB_DataViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 655)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnClearKnowledge)
        Me.Controls.Add(Me.btnShowAllModels)
        Me.Controls.Add(Me.lblModelCount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAddVariable)
        Me.Controls.Add(Me.txtVariable)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstVariables)
        Me.Controls.Add(Me.btnRefreshKnowledgeList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAskSentence)
        Me.Controls.Add(Me.btnAsk)
        Me.Controls.Add(Me.btnTell)
        Me.Controls.Add(Me.txtTellSentence)
        Me.Controls.Add(Me.lstKnowledge)
        Me.Name = "KB_DataViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Data editor for knowledge bases"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstKnowledge As System.Windows.Forms.ListBox
    Friend WithEvents txtTellSentence As System.Windows.Forms.TextBox
    Friend WithEvents btnTell As System.Windows.Forms.Button
    Friend WithEvents btnAsk As System.Windows.Forms.Button
    Friend WithEvents txtAskSentence As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshKnowledgeList As System.Windows.Forms.Button
    Friend WithEvents lstVariables As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVariable As System.Windows.Forms.TextBox
    Friend WithEvents btnAddVariable As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblModelCount As System.Windows.Forms.Label
    Friend WithEvents btnShowAllModels As System.Windows.Forms.Button
    Friend WithEvents btnClearKnowledge As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
End Class
