<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config_acesso_remoto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(25, 40)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(198, 20)
        Me.txtPath.TabIndex = 0
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(237, 37)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrir.TabIndex = 1
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Caminho Remoto"
        '
        'btnFechar
        '
        Me.btnFechar.Location = New System.Drawing.Point(237, 78)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(115, 23)
        Me.btnFechar.TabIndex = 3
        Me.btnFechar.Text = "Guardar e Fechar"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(318, 37)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCheck.TabIndex = 4
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'ofd
        '
        Me.ofd.FileName = "ofd"
        '
        'config_acesso_remoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 113)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.txtPath)
        Me.Name = "config_acesso_remoto"
        Me.Text = "config_acesso_remoto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPath As TextBox
    Friend WithEvents btnAbrir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnCheck As Button
    Friend WithEvents ofd As OpenFileDialog
End Class
