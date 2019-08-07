<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaixaPerfil
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
        Me.pboxPerfil = New System.Windows.Forms.PictureBox()
        Me.btnAlterarImagem = New System.Windows.Forms.Button()
        Me.cboUtilizador = New System.Windows.Forms.ComboBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.pboxPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxPerfil
        '
        Me.pboxPerfil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pboxPerfil.Image = Global.pri_fechoConta.My.Resources.Resources._default
        Me.pboxPerfil.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pboxPerfil.Location = New System.Drawing.Point(12, 68)
        Me.pboxPerfil.Name = "pboxPerfil"
        Me.pboxPerfil.Size = New System.Drawing.Size(171, 162)
        Me.pboxPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxPerfil.TabIndex = 1
        Me.pboxPerfil.TabStop = False
        '
        'btnAlterarImagem
        '
        Me.btnAlterarImagem.Enabled = False
        Me.btnAlterarImagem.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAlterarImagem.Location = New System.Drawing.Point(12, 246)
        Me.btnAlterarImagem.Name = "btnAlterarImagem"
        Me.btnAlterarImagem.Size = New System.Drawing.Size(171, 23)
        Me.btnAlterarImagem.TabIndex = 11
        Me.btnAlterarImagem.Text = "Alterar Imagem"
        Me.btnAlterarImagem.UseVisualStyleBackColor = True
        '
        'cboUtilizador
        '
        Me.cboUtilizador.FormattingEnabled = True
        Me.cboUtilizador.Location = New System.Drawing.Point(12, 41)
        Me.cboUtilizador.Name = "cboUtilizador"
        Me.cboUtilizador.Size = New System.Drawing.Size(171, 21)
        Me.cboUtilizador.TabIndex = 12
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UsernameLabel.Location = New System.Drawing.Point(12, 15)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(171, 23)
        Me.UsernameLabel.TabIndex = 13
        Me.UsernameLabel.Text = "&Utilizador "
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CaixaPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(208, 288)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.cboUtilizador)
        Me.Controls.Add(Me.btnAlterarImagem)
        Me.Controls.Add(Me.pboxPerfil)
        Me.Name = "CaixaPerfil"
        Me.Text = "CaixaPerfil"
        CType(Me.pboxPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pboxPerfil As PictureBox
    Friend WithEvents btnAlterarImagem As Button
    Friend WithEvents cboUtilizador As ComboBox
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
