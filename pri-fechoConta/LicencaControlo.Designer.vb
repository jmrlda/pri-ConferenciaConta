<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class LicencaControlo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    Friend WithEvents btnLicenciar As System.Windows.Forms.Button
    Friend WithEvents btnFechar As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicencaControlo))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.btnLicenciar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.txtUtilizadoresNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.cboUtilizador = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboLicencaSerie = New System.Windows.Forms.ComboBox()
        Me.dgvUtilizadoresLicenca = New System.Windows.Forms.DataGridView()
        Me.Utilizadores = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.dtpDataInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpDataFim = New System.Windows.Forms.DateTimePicker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LicencaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NovaLicençaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboNivelUtilizador = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDuracao = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRemover = New System.Windows.Forms.Button()
        Me.txtClienteNuit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnRemoverLicenca = New System.Windows.Forms.Button()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUtilizadoresLicenca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogoPictureBox.Image = Global.pri_fechoConta.My.Resources.Resources.jmr_caixa
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 27)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(165, 340)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Location = New System.Drawing.Point(168, 29)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Licença serie"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.Location = New System.Drawing.Point(374, 92)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(106, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Numero Utilizadores"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLicenciar
        '
        Me.btnLicenciar.Enabled = False
        Me.btnLicenciar.Location = New System.Drawing.Point(520, 395)
        Me.btnLicenciar.Name = "btnLicenciar"
        Me.btnLicenciar.Size = New System.Drawing.Size(94, 23)
        Me.btnLicenciar.TabIndex = 4
        Me.btnLicenciar.Text = "&Salvar"
        '
        'btnFechar
        '
        Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFechar.Location = New System.Drawing.Point(620, 395)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(94, 23)
        Me.btnFechar.TabIndex = 5
        Me.btnFechar.Text = "&Fechar"
        '
        'txtUtilizadoresNumero
        '
        Me.txtUtilizadoresNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUtilizadoresNumero.Enabled = False
        Me.txtUtilizadoresNumero.Location = New System.Drawing.Point(377, 118)
        Me.txtUtilizadoresNumero.Name = "txtUtilizadoresNumero"
        Me.txtUtilizadoresNumero.Size = New System.Drawing.Size(114, 20)
        Me.txtUtilizadoresNumero.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(566, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Data Expiração"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(332, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "&Data Inicio"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Enabled = False
        Me.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdicionar.Location = New System.Drawing.Point(569, 231)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(66, 23)
        Me.btnAdicionar.TabIndex = 11
        Me.btnAdicionar.Text = "&Adicionar"
        '
        'cboUtilizador
        '
        Me.cboUtilizador.Enabled = False
        Me.cboUtilizador.FormattingEnabled = True
        Me.cboUtilizador.Location = New System.Drawing.Point(168, 231)
        Me.cboUtilizador.Name = "cboUtilizador"
        Me.cboUtilizador.Size = New System.Drawing.Size(206, 21)
        Me.cboUtilizador.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(168, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Utilizadores"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLicencaSerie
        '
        Me.cboLicencaSerie.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboLicencaSerie.FormattingEnabled = True
        Me.cboLicencaSerie.Location = New System.Drawing.Point(174, 55)
        Me.cboLicencaSerie.Name = "cboLicencaSerie"
        Me.cboLicencaSerie.Size = New System.Drawing.Size(359, 21)
        Me.cboLicencaSerie.TabIndex = 14
        '
        'dgvUtilizadoresLicenca
        '
        Me.dgvUtilizadoresLicenca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUtilizadoresLicenca.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Utilizadores, Me.Nivel})
        Me.dgvUtilizadoresLicenca.Location = New System.Drawing.Point(168, 258)
        Me.dgvUtilizadoresLicenca.Name = "dgvUtilizadoresLicenca"
        Me.dgvUtilizadoresLicenca.Size = New System.Drawing.Size(395, 131)
        Me.dgvUtilizadoresLicenca.TabIndex = 15
        '
        'Utilizadores
        '
        Me.Utilizadores.HeaderText = "Utilizadores Licenciado"
        Me.Utilizadores.Name = "Utilizadores"
        Me.Utilizadores.ReadOnly = True
        Me.Utilizadores.Width = 200
        '
        'Nivel
        '
        Me.Nivel.HeaderText = "Nivel"
        Me.Nivel.Name = "Nivel"
        Me.Nivel.Width = 150
        '
        'btnLimpar
        '
        Me.btnLimpar.Enabled = False
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpar.Location = New System.Drawing.Point(643, 231)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(67, 23)
        Me.btnLimpar.TabIndex = 16
        Me.btnLimpar.Text = "&Limpar"
        '
        'dtpDataInicio
        '
        Me.dtpDataInicio.Enabled = False
        Me.dtpDataInicio.Location = New System.Drawing.Point(335, 166)
        Me.dtpDataInicio.Name = "dtpDataInicio"
        Me.dtpDataInicio.Size = New System.Drawing.Size(228, 20)
        Me.dtpDataInicio.TabIndex = 19
        '
        'dtpDataFim
        '
        Me.dtpDataFim.Enabled = False
        Me.dtpDataFim.Location = New System.Drawing.Point(569, 166)
        Me.dtpDataFim.Name = "dtpDataFim"
        Me.dtpDataFim.Size = New System.Drawing.Size(230, 20)
        Me.dtpDataFim.TabIndex = 20
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LicencaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(803, 26)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LicencaToolStripMenuItem
        '
        Me.LicencaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NovaLicençaToolStripMenuItem})
        Me.LicencaToolStripMenuItem.Font = New System.Drawing.Font("Ubuntu Condensed", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicencaToolStripMenuItem.Name = "LicencaToolStripMenuItem"
        Me.LicencaToolStripMenuItem.Size = New System.Drawing.Size(58, 22)
        Me.LicencaToolStripMenuItem.Text = "Licença"
        '
        'NovaLicençaToolStripMenuItem
        '
        Me.NovaLicençaToolStripMenuItem.Name = "NovaLicençaToolStripMenuItem"
        Me.NovaLicençaToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.NovaLicençaToolStripMenuItem.Text = "&nova licenca"
        '
        'cboNivelUtilizador
        '
        Me.cboNivelUtilizador.Enabled = False
        Me.cboNivelUtilizador.FormattingEnabled = True
        Me.cboNivelUtilizador.Items.AddRange(New Object() {"Selecionar nivel", "Administrador", "Tesoureiro"})
        Me.cboNivelUtilizador.Location = New System.Drawing.Point(380, 231)
        Me.cboNivelUtilizador.Name = "cboNivelUtilizador"
        Me.cboNivelUtilizador.Size = New System.Drawing.Size(183, 21)
        Me.cboNivelUtilizador.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(377, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Perfil Nivel"
        '
        'txtDuracao
        '
        Me.txtDuracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDuracao.Enabled = False
        Me.txtDuracao.Location = New System.Drawing.Point(172, 166)
        Me.txtDuracao.Name = "txtDuracao"
        Me.txtDuracao.Size = New System.Drawing.Size(142, 20)
        Me.txtDuracao.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(168, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 23)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "&Duração"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRemover
        '
        Me.btnRemover.Enabled = False
        Me.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemover.Location = New System.Drawing.Point(570, 261)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(65, 23)
        Me.btnRemover.TabIndex = 26
        Me.btnRemover.Text = "Remover"
        Me.btnRemover.UseVisualStyleBackColor = True
        '
        'txtClienteNuit
        '
        Me.txtClienteNuit.Enabled = False
        Me.txtClienteNuit.Location = New System.Drawing.Point(174, 117)
        Me.txtClienteNuit.Name = "txtClienteNuit"
        Me.txtClienteNuit.Size = New System.Drawing.Size(197, 20)
        Me.txtClienteNuit.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(172, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Nuit"
        '
        'btnRemoverLicenca
        '
        Me.btnRemoverLicenca.Enabled = False
        Me.btnRemoverLicenca.Location = New System.Drawing.Point(539, 55)
        Me.btnRemoverLicenca.Name = "btnRemoverLicenca"
        Me.btnRemoverLicenca.Size = New System.Drawing.Size(140, 23)
        Me.btnRemoverLicenca.TabIndex = 29
        Me.btnRemoverLicenca.Text = "Remover licença"
        Me.btnRemoverLicenca.UseVisualStyleBackColor = True
        '
        'LicencaControlo
        '
        Me.AcceptButton = Me.btnLicenciar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.btnFechar
        Me.ClientSize = New System.Drawing.Size(803, 430)
        Me.Controls.Add(Me.btnRemoverLicenca)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtClienteNuit)
        Me.Controls.Add(Me.btnRemover)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDuracao)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboNivelUtilizador)
        Me.Controls.Add(Me.dtpDataFim)
        Me.Controls.Add(Me.dtpDataInicio)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.dgvUtilizadoresLicenca)
        Me.Controls.Add(Me.cboLicencaSerie)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboUtilizador)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUtilizadoresNumero)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnLicenciar)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LicencaControlo"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PRI-Conferência de Caixa -- Licença"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUtilizadoresLicenca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUtilizadoresNumero As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents cboUtilizador As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboLicencaSerie As ComboBox
    Friend WithEvents dgvUtilizadoresLicenca As DataGridView
    Friend WithEvents btnLimpar As Button
    Friend WithEvents dtpDataInicio As DateTimePicker
    Friend WithEvents dtpDataFim As DateTimePicker
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LicencaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NovaLicençaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cboNivelUtilizador As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Utilizadores As DataGridViewTextBoxColumn
    Friend WithEvents Nivel As DataGridViewTextBoxColumn
    Friend WithEvents txtDuracao As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnRemover As Button
    Friend WithEvents txtClienteNuit As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnRemoverLicenca As Button
End Class
