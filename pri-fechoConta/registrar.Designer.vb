<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class registrar
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(registrar))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.cboUtilizador = New System.Windows.Forms.ComboBox()
        Me.txtConfirmarSenha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMsgErro = New System.Windows.Forms.Label()
        Me.pboxPerfil = New System.Windows.Forms.PictureBox()
        Me.btnAlterarImagem = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnNovaSenha = New System.Windows.Forms.Button()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogoPictureBox.Image = Global.pri_fechoConta.My.Resources.Resources.jmr
        resources.ApplyResources(Me.LogoPictureBox, "LogoPictureBox")
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.UsernameLabel, "UsernameLabel")
        Me.UsernameLabel.Name = "UsernameLabel"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PasswordLabel, "PasswordLabel")
        Me.PasswordLabel.Name = "PasswordLabel"
        '
        'txtSenha
        '
        resources.ApplyResources(Me.txtSenha, "txtSenha")
        Me.txtSenha.Name = "txtSenha"
        '
        'btnRegistrar
        '
        resources.ApplyResources(Me.btnRegistrar, "btnRegistrar")
        Me.btnRegistrar.Name = "btnRegistrar"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.Cancel, "Cancel")
        Me.Cancel.Name = "Cancel"
        '
        'cboUtilizador
        '
        Me.cboUtilizador.FormattingEnabled = True
        resources.ApplyResources(Me.cboUtilizador, "cboUtilizador")
        Me.cboUtilizador.Name = "cboUtilizador"
        '
        'txtConfirmarSenha
        '
        resources.ApplyResources(Me.txtConfirmarSenha, "txtConfirmarSenha")
        Me.txtConfirmarSenha.Name = "txtConfirmarSenha"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblMsgErro
        '
        resources.ApplyResources(Me.lblMsgErro, "lblMsgErro")
        Me.lblMsgErro.ForeColor = System.Drawing.Color.Red
        Me.lblMsgErro.Name = "lblMsgErro"
        '
        'pboxPerfil
        '
        Me.pboxPerfil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pboxPerfil.Image = Global.pri_fechoConta.My.Resources.Resources._default
        resources.ApplyResources(Me.pboxPerfil, "pboxPerfil")
        Me.pboxPerfil.Name = "pboxPerfil"
        Me.pboxPerfil.TabStop = False
        '
        'btnAlterarImagem
        '
        resources.ApplyResources(Me.btnAlterarImagem, "btnAlterarImagem")
        Me.btnAlterarImagem.Name = "btnAlterarImagem"
        Me.btnAlterarImagem.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnNovaSenha
        '
        resources.ApplyResources(Me.btnNovaSenha, "btnNovaSenha")
        Me.btnNovaSenha.Image = Global.pri_fechoConta.My.Resources.Resources.pencil_edit_button
        Me.btnNovaSenha.Name = "btnNovaSenha"
        Me.btnNovaSenha.TabStop = False
        Me.btnNovaSenha.UseVisualStyleBackColor = True
        '
        'registrar
        '
        Me.AcceptButton = Me.btnRegistrar
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.Controls.Add(Me.btnNovaSenha)
        Me.Controls.Add(Me.btnAlterarImagem)
        Me.Controls.Add(Me.pboxPerfil)
        Me.Controls.Add(Me.lblMsgErro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConfirmarSenha)
        Me.Controls.Add(Me.cboUtilizador)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "registrar"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboUtilizador As ComboBox
    Friend WithEvents txtConfirmarSenha As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMsgErro As Label
    Friend WithEvents pboxPerfil As PictureBox
    Friend WithEvents btnAlterarImagem As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnNovaSenha As Button
End Class
