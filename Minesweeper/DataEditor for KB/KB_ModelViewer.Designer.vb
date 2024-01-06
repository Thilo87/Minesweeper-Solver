<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KB_ModelViewer
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
        Me.lvAllModels = New System.Windows.Forms.ListView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvAllModels
        '
        Me.lvAllModels.Dock = System.Windows.Forms.DockStyle.Top
        Me.lvAllModels.GridLines = True
        Me.lvAllModels.Location = New System.Drawing.Point(0, 0)
        Me.lvAllModels.Name = "lvAllModels"
        Me.lvAllModels.Size = New System.Drawing.Size(514, 242)
        Me.lvAllModels.TabIndex = 0
        Me.lvAllModels.UseCompatibleStateImageBehavior = False
        Me.lvAllModels.View = System.Windows.Forms.View.Details
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(338, 248)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(53, 20)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'KB_ModelViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 268)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lvAllModels)
        Me.Name = "KB_ModelViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Model viewer for knowledge bases"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvAllModels As System.Windows.Forms.ListView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
