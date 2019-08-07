<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class ConfigMovimentos
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
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigMovimentos))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.chkLstMovCodigo = New System.Windows.Forms.CheckedListBox()
        Me.rdBtnNumerario = New System.Windows.Forms.RadioButton()
        Me.rdBtnPagAutomatico = New System.Windows.Forms.RadioButton()
        Me.rdBtnCheques = New System.Windows.Forms.RadioButton()
        Me.rdBtnOutros = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLstMovDescricao = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdiMovContabilistico = New System.Windows.Forms.RadioButton()
        Me.rdiMovBancario = New System.Windows.Forms.RadioButton()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.rdBtnFecho = New System.Windows.Forms.RadioButton()
        Me.rdBtnAbertura = New System.Windows.Forms.RadioButton()
        Me.rdBtnSaida = New System.Windows.Forms.RadioButton()
        Me.rdBtnEntrada = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(614, 241)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(94, 23)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "&Guardar"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(722, 241)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Fechar"
        '
        'chkLstMovCodigo
        '
        Me.chkLstMovCodigo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstMovCodigo.FormattingEnabled = True
        Me.chkLstMovCodigo.Location = New System.Drawing.Point(325, 54)
        Me.chkLstMovCodigo.Name = "chkLstMovCodigo"
        Me.chkLstMovCodigo.Size = New System.Drawing.Size(184, 184)
        Me.chkLstMovCodigo.TabIndex = 13
        '
        'rdBtnNumerario
        '
        Me.rdBtnNumerario.AutoSize = True
        Me.rdBtnNumerario.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnNumerario.Location = New System.Drawing.Point(175, 50)
        Me.rdBtnNumerario.Name = "rdBtnNumerario"
        Me.rdBtnNumerario.Size = New System.Drawing.Size(73, 17)
        Me.rdBtnNumerario.TabIndex = 14
        Me.rdBtnNumerario.TabStop = True
        Me.rdBtnNumerario.Text = "Numerario"
        Me.rdBtnNumerario.UseVisualStyleBackColor = False
        '
        'rdBtnPagAutomatico
        '
        Me.rdBtnPagAutomatico.AutoSize = True
        Me.rdBtnPagAutomatico.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnPagAutomatico.Location = New System.Drawing.Point(175, 73)
        Me.rdBtnPagAutomatico.Name = "rdBtnPagAutomatico"
        Me.rdBtnPagAutomatico.Size = New System.Drawing.Size(144, 17)
        Me.rdBtnPagAutomatico.TabIndex = 15
        Me.rdBtnPagAutomatico.TabStop = True
        Me.rdBtnPagAutomatico.Text = "Pagamentos automaticos"
        Me.rdBtnPagAutomatico.UseVisualStyleBackColor = False
        '
        'rdBtnCheques
        '
        Me.rdBtnCheques.AutoSize = True
        Me.rdBtnCheques.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnCheques.Location = New System.Drawing.Point(175, 96)
        Me.rdBtnCheques.Name = "rdBtnCheques"
        Me.rdBtnCheques.Size = New System.Drawing.Size(67, 17)
        Me.rdBtnCheques.TabIndex = 16
        Me.rdBtnCheques.TabStop = True
        Me.rdBtnCheques.Text = "Cheques"
        Me.rdBtnCheques.UseVisualStyleBackColor = False
        '
        'rdBtnOutros
        '
        Me.rdBtnOutros.AutoSize = True
        Me.rdBtnOutros.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnOutros.Location = New System.Drawing.Point(175, 119)
        Me.rdBtnOutros.Name = "rdBtnOutros"
        Me.rdBtnOutros.Size = New System.Drawing.Size(56, 17)
        Me.rdBtnOutros.TabIndex = 17
        Me.rdBtnOutros.TabStop = True
        Me.rdBtnOutros.Text = "Outros"
        Me.rdBtnOutros.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Movimento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(321, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Codigo"
        '
        'chkLstMovDescricao
        '
        Me.chkLstMovDescricao.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstMovDescricao.FormattingEnabled = True
        Me.chkLstMovDescricao.Location = New System.Drawing.Point(535, 54)
        Me.chkLstMovDescricao.Name = "chkLstMovDescricao"
        Me.chkLstMovDescricao.Size = New System.Drawing.Size(281, 184)
        Me.chkLstMovDescricao.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(500, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Descrição"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.rdiMovContabilistico)
        Me.Panel1.Controls.Add(Me.rdiMovBancario)
        Me.Panel1.Location = New System.Drawing.Point(325, 244)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 90)
        Me.Panel1.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tipo Movimento"
        '
        'rdiMovContabilistico
        '
        Me.rdiMovContabilistico.AutoSize = True
        Me.rdiMovContabilistico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdiMovContabilistico.Location = New System.Drawing.Point(13, 57)
        Me.rdiMovContabilistico.Name = "rdiMovContabilistico"
        Me.rdiMovContabilistico.Size = New System.Drawing.Size(162, 19)
        Me.rdiMovContabilistico.TabIndex = 1
        Me.rdiMovContabilistico.TabStop = True
        Me.rdiMovContabilistico.Text = "Movimento Contabilistico"
        Me.rdiMovContabilistico.UseVisualStyleBackColor = True
        '
        'rdiMovBancario
        '
        Me.rdiMovBancario.AutoSize = True
        Me.rdiMovBancario.Checked = True
        Me.rdiMovBancario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdiMovBancario.Location = New System.Drawing.Point(13, 32)
        Me.rdiMovBancario.Name = "rdiMovBancario"
        Me.rdiMovBancario.Size = New System.Drawing.Size(138, 19)
        Me.rdiMovBancario.TabIndex = 0
        Me.rdiMovBancario.TabStop = True
        Me.rdiMovBancario.Text = "Movimento Bancario"
        Me.rdiMovBancario.UseVisualStyleBackColor = True
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.pri_fechoConta.My.Resources.Resources.jmr_caixa
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, -3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(165, 351)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'rdBtnFecho
        '
        Me.rdBtnFecho.AutoSize = True
        Me.rdBtnFecho.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnFecho.Location = New System.Drawing.Point(175, 165)
        Me.rdBtnFecho.Name = "rdBtnFecho"
        Me.rdBtnFecho.Size = New System.Drawing.Size(99, 17)
        Me.rdBtnFecho.TabIndex = 24
        Me.rdBtnFecho.TabStop = True
        Me.rdBtnFecho.Text = "Fecho de Caixa"
        Me.rdBtnFecho.UseVisualStyleBackColor = False
        '
        'rdBtnAbertura
        '
        Me.rdBtnAbertura.AutoSize = True
        Me.rdBtnAbertura.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnAbertura.Location = New System.Drawing.Point(175, 142)
        Me.rdBtnAbertura.Name = "rdBtnAbertura"
        Me.rdBtnAbertura.Size = New System.Drawing.Size(109, 17)
        Me.rdBtnAbertura.TabIndex = 23
        Me.rdBtnAbertura.TabStop = True
        Me.rdBtnAbertura.Text = "Abertura de Caixa"
        Me.rdBtnAbertura.UseVisualStyleBackColor = False
        '
        'rdBtnSaida
        '
        Me.rdBtnSaida.AutoSize = True
        Me.rdBtnSaida.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnSaida.Location = New System.Drawing.Point(175, 214)
        Me.rdBtnSaida.Name = "rdBtnSaida"
        Me.rdBtnSaida.Size = New System.Drawing.Size(52, 17)
        Me.rdBtnSaida.TabIndex = 26
        Me.rdBtnSaida.TabStop = True
        Me.rdBtnSaida.Text = "Saida"
        Me.rdBtnSaida.UseVisualStyleBackColor = False
        '
        'rdBtnEntrada
        '
        Me.rdBtnEntrada.AutoSize = True
        Me.rdBtnEntrada.BackColor = System.Drawing.Color.Transparent
        Me.rdBtnEntrada.Location = New System.Drawing.Point(175, 188)
        Me.rdBtnEntrada.Name = "rdBtnEntrada"
        Me.rdBtnEntrada.Size = New System.Drawing.Size(65, 17)
        Me.rdBtnEntrada.TabIndex = 25
        Me.rdBtnEntrada.TabStop = True
        Me.rdBtnEntrada.Text = "Entrada "
        Me.rdBtnEntrada.UseVisualStyleBackColor = False
        '
        'ConfigMovimentos
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.pri_fechoConta.My.Resources.Resources.Erpbg01
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(817, 346)
        Me.Controls.Add(Me.rdBtnSaida)
        Me.Controls.Add(Me.rdBtnEntrada)
        Me.Controls.Add(Me.rdBtnFecho)
        Me.Controls.Add(Me.rdBtnAbertura)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkLstMovDescricao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rdBtnOutros)
        Me.Controls.Add(Me.rdBtnCheques)
        Me.Controls.Add(Me.rdBtnPagAutomatico)
        Me.Controls.Add(Me.rdBtnNumerario)
        Me.Controls.Add(Me.chkLstMovCodigo)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ConfigMovimentos"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametro de Movimentos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkLstMovCodigo As CheckedListBox
    Friend WithEvents rdBtnNumerario As RadioButton
    Friend WithEvents rdBtnPagAutomatico As RadioButton
    Friend WithEvents rdBtnCheques As RadioButton
    Friend WithEvents rdBtnOutros As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chkLstMovDescricao As CheckedListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents rdiMovContabilistico As RadioButton
    Friend WithEvents rdiMovBancario As RadioButton
    Friend WithEvents rdBtnFecho As RadioButton
    Friend WithEvents rdBtnAbertura As RadioButton
    Friend WithEvents rdBtnSaida As RadioButton
    Friend WithEvents rdBtnEntrada As RadioButton
End Class
