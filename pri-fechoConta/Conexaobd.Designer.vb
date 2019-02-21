<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Conexaobd
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
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents btnTerminar As System.Windows.Forms.Button
    Friend WithEvents btnTestar As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Conexaobd))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.btnTerminar = New System.Windows.Forms.Button()
        Me.btnTestar = New System.Windows.Forms.Button()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.txtUtilizadorBd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBasedados = New System.Windows.Forms.TextBox()
        Me.lblMsgErro = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogoPictureBox.Image = Global.pri_fechoConta.My.Resources.Resources.jmr_bd
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(156, 255)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Location = New System.Drawing.Point(205, 1)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Nome Servidor"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.Location = New System.Drawing.Point(205, 50)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Base de Dados"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtServidor
        '
        Me.txtServidor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServidor.Location = New System.Drawing.Point(208, 27)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(241, 20)
        Me.txtServidor.TabIndex = 1
        '
        'btnTerminar
        '
        Me.btnTerminar.Location = New System.Drawing.Point(369, 232)
        Me.btnTerminar.Name = "btnTerminar"
        Me.btnTerminar.Size = New System.Drawing.Size(80, 23)
        Me.btnTerminar.TabIndex = 4
        Me.btnTerminar.Text = "&Terminar"
        '
        'btnTestar
        '
        Me.btnTestar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTestar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTestar.Location = New System.Drawing.Point(208, 232)
        Me.btnTestar.Name = "btnTestar"
        Me.btnTestar.Size = New System.Drawing.Size(77, 23)
        Me.btnTestar.TabIndex = 5
        Me.btnTestar.Text = "&Testar"
        '
        'txtSenha
        '
        Me.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSenha.Location = New System.Drawing.Point(209, 174)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(240, 20)
        Me.txtSenha.TabIndex = 9
        '
        'txtUtilizadorBd
        '
        Me.txtUtilizadorBd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUtilizadorBd.Location = New System.Drawing.Point(209, 125)
        Me.txtUtilizadorBd.Name = "txtUtilizadorBd"
        Me.txtUtilizadorBd.Size = New System.Drawing.Size(240, 20)
        Me.txtUtilizadorBd.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(206, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "&Senha"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(206, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(220, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "&Utilizador BD"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBasedados
        '
        Me.txtBasedados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBasedados.Location = New System.Drawing.Point(208, 76)
        Me.txtBasedados.Name = "txtBasedados"
        Me.txtBasedados.Size = New System.Drawing.Size(241, 20)
        Me.txtBasedados.TabIndex = 11
        '
        'lblMsgErro
        '
        Me.lblMsgErro.AutoSize = True
        Me.lblMsgErro.BackColor = System.Drawing.Color.Transparent
        Me.lblMsgErro.ForeColor = System.Drawing.Color.Red
        Me.lblMsgErro.Location = New System.Drawing.Point(180, 203)
        Me.lblMsgErro.Name = "lblMsgErro"
        Me.lblMsgErro.Size = New System.Drawing.Size(10, 13)
        Me.lblMsgErro.TabIndex = 12
        Me.lblMsgErro.Text = " "
        Me.lblMsgErro.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(291, 232)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Conexaobd
        '
        Me.AcceptButton = Me.btnTerminar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.btnTestar
        Me.ClientSize = New System.Drawing.Size(494, 267)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblMsgErro)
        Me.Controls.Add(Me.txtBasedados)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.txtUtilizadorBd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnTestar)
        Me.Controls.Add(Me.btnTerminar)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Conexaobd"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametros de Acesso a Base de Dados"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSenha As TextBox
    Friend WithEvents txtUtilizadorBd As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBasedados As TextBox
    Friend WithEvents lblMsgErro As Label
    Friend WithEvents btnGuardar As Button
End Class
