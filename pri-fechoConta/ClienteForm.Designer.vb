<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClienteForm
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
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtFilial = New System.Windows.Forms.TextBox()
        Me.txtNuit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMorada = New System.Windows.Forms.TextBox()
        Me.lblMsgErro = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(80, 49)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(80, 92)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(276, 20)
        Me.txtNome.TabIndex = 1
        '
        'txtFilial
        '
        Me.txtFilial.Location = New System.Drawing.Point(80, 144)
        Me.txtFilial.Name = "txtFilial"
        Me.txtFilial.Size = New System.Drawing.Size(276, 20)
        Me.txtFilial.TabIndex = 2
        '
        'txtNuit
        '
        Me.txtNuit.Location = New System.Drawing.Point(80, 118)
        Me.txtNuit.Name = "txtNuit"
        Me.txtNuit.Size = New System.Drawing.Size(276, 20)
        Me.txtNuit.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nome:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Filial:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nuit:"
        '
        'btnGravar
        '
        Me.btnGravar.Enabled = False
        Me.btnGravar.Location = New System.Drawing.Point(194, 267)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(75, 23)
        Me.btnGravar.TabIndex = 8
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Location = New System.Drawing.Point(275, 267)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(75, 23)
        Me.btnFechar.TabIndex = 9
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ATENÇÃO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(392, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Sempre que desejar alterar um destes dados,  informe a JMR para actualização e "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = " emissão de nova licença"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Morada:"
        '
        'txtMorada
        '
        Me.txtMorada.Location = New System.Drawing.Point(80, 170)
        Me.txtMorada.Name = "txtMorada"
        Me.txtMorada.Size = New System.Drawing.Size(276, 20)
        Me.txtMorada.TabIndex = 13
        '
        'lblMsgErro
        '
        Me.lblMsgErro.AutoSize = True
        Me.lblMsgErro.ForeColor = System.Drawing.Color.Red
        Me.lblMsgErro.Location = New System.Drawing.Point(105, 18)
        Me.lblMsgErro.Name = "lblMsgErro"
        Me.lblMsgErro.Size = New System.Drawing.Size(211, 13)
        Me.lblMsgErro.TabIndex = 15
        Me.lblMsgErro.Text = "ATENÇÃO: Preecha os campos em branco"
        Me.lblMsgErro.Visible = False
        '
        'ClienteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 315)
        Me.Controls.Add(Me.lblMsgErro)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMorada)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNuit)
        Me.Controls.Add(Me.txtFilial)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtCodigo)
        Me.Name = "ClienteForm"
        Me.Text = "Conferência Caixa -- Cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend Shared WithEvents txtCodigo As TextBox
    Friend WithEvents txtNome As TextBox
    Friend WithEvents txtFilial As TextBox
    Friend WithEvents txtNuit As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGravar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMorada As TextBox
    Friend WithEvents lblMsgErro As Label
End Class
