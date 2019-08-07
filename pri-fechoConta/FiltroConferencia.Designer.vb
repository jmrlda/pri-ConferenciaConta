<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroConferencia
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstboxDiariosConferidos = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkboxDiarioCaixa = New System.Windows.Forms.CheckBox()
        Me.chkboxData = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstboxContaOrigem = New System.Windows.Forms.ListBox()
        Me.chkboxContaOrigem = New System.Windows.Forms.CheckBox()
        Me.lstboxContaOrigemSelecionados = New System.Windows.Forms.ListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lstboxDiariosConferidoSelecionados = New System.Windows.Forms.ListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnContaCada = New System.Windows.Forms.Button()
        Me.btnContaTodas = New System.Windows.Forms.Button()
        Me.btnCaixaTodas = New System.Windows.Forms.Button()
        Me.btnCaixaCada = New System.Windows.Forms.Button()
        Me.btnContaRemoverTodas = New System.Windows.Forms.Button()
        Me.btnContaRemover = New System.Windows.Forms.Button()
        Me.btnCaixaRemoverTodas = New System.Windows.Forms.Button()
        Me.btnCaixaRemover = New System.Windows.Forms.Button()
        Me.btnPrevisualizar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Parametros da Listagem"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(418, 40)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstboxDiariosConferidos)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 246)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 141)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DiarioCaixa"
        '
        'lstboxDiariosConferidos
        '
        Me.lstboxDiariosConferidos.FormattingEnabled = True
        Me.lstboxDiariosConferidos.Location = New System.Drawing.Point(6, 19)
        Me.lstboxDiariosConferidos.Name = "lstboxDiariosConferidos"
        Me.lstboxDiariosConferidos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstboxDiariosConferidos.Size = New System.Drawing.Size(134, 108)
        Me.lstboxDiariosConferidos.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtFinal)
        Me.GroupBox2.Controls.Add(Me.dtInicial)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 422)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 65)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data"
        '
        'dtFinal
        '
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(214, 23)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtFinal.TabIndex = 3
        '
        'dtInicial
        '
        Me.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicial.Location = New System.Drawing.Point(51, 23)
        Me.dtInicial.Name = "dtInicial"
        Me.dtInicial.Size = New System.Drawing.Size(95, 20)
        Me.dtInicial.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Final:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Inicial:"
        '
        'chkboxDiarioCaixa
        '
        Me.chkboxDiarioCaixa.AutoSize = True
        Me.chkboxDiarioCaixa.Location = New System.Drawing.Point(12, 265)
        Me.chkboxDiarioCaixa.Name = "chkboxDiarioCaixa"
        Me.chkboxDiarioCaixa.Size = New System.Drawing.Size(15, 14)
        Me.chkboxDiarioCaixa.TabIndex = 4
        Me.chkboxDiarioCaixa.UseVisualStyleBackColor = True
        '
        'chkboxData
        '
        Me.chkboxData.AutoSize = True
        Me.chkboxData.Location = New System.Drawing.Point(12, 445)
        Me.chkboxData.Name = "chkboxData"
        Me.chkboxData.Size = New System.Drawing.Size(15, 14)
        Me.chkboxData.TabIndex = 5
        Me.chkboxData.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstboxContaOrigem)
        Me.GroupBox3.Location = New System.Drawing.Point(41, 45)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(146, 159)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contas Disponiveis"
        '
        'lstboxContaOrigem
        '
        Me.lstboxContaOrigem.FormattingEnabled = True
        Me.lstboxContaOrigem.Location = New System.Drawing.Point(6, 25)
        Me.lstboxContaOrigem.Name = "lstboxContaOrigem"
        Me.lstboxContaOrigem.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstboxContaOrigem.Size = New System.Drawing.Size(134, 121)
        Me.lstboxContaOrigem.TabIndex = 1
        '
        'chkboxContaOrigem
        '
        Me.chkboxContaOrigem.AutoSize = True
        Me.chkboxContaOrigem.Location = New System.Drawing.Point(12, 68)
        Me.chkboxContaOrigem.Name = "chkboxContaOrigem"
        Me.chkboxContaOrigem.Size = New System.Drawing.Size(15, 14)
        Me.chkboxContaOrigem.TabIndex = 11
        Me.chkboxContaOrigem.UseVisualStyleBackColor = True
        '
        'lstboxContaOrigemSelecionados
        '
        Me.lstboxContaOrigemSelecionados.FormattingEnabled = True
        Me.lstboxContaOrigemSelecionados.Location = New System.Drawing.Point(6, 25)
        Me.lstboxContaOrigemSelecionados.Name = "lstboxContaOrigemSelecionados"
        Me.lstboxContaOrigemSelecionados.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstboxContaOrigemSelecionados.Size = New System.Drawing.Size(144, 121)
        Me.lstboxContaOrigemSelecionados.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lstboxContaOrigemSelecionados)
        Me.GroupBox4.Location = New System.Drawing.Point(243, 45)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(156, 159)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Contas Disponiveis"
        '
        'lstboxDiariosConferidoSelecionados
        '
        Me.lstboxDiariosConferidoSelecionados.FormattingEnabled = True
        Me.lstboxDiariosConferidoSelecionados.Location = New System.Drawing.Point(6, 19)
        Me.lstboxDiariosConferidoSelecionados.Name = "lstboxDiariosConferidoSelecionados"
        Me.lstboxDiariosConferidoSelecionados.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstboxDiariosConferidoSelecionados.Size = New System.Drawing.Size(144, 108)
        Me.lstboxDiariosConferidoSelecionados.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lstboxDiariosConferidoSelecionados)
        Me.GroupBox5.Location = New System.Drawing.Point(243, 246)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(156, 141)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DiarioCaixa"
        '
        'btnContaCada
        '
        Me.btnContaCada.Location = New System.Drawing.Point(193, 87)
        Me.btnContaCada.Name = "btnContaCada"
        Me.btnContaCada.Size = New System.Drawing.Size(44, 23)
        Me.btnContaCada.TabIndex = 12
        Me.btnContaCada.Text = ">"
        Me.btnContaCada.UseVisualStyleBackColor = True
        '
        'btnContaTodas
        '
        Me.btnContaTodas.Location = New System.Drawing.Point(193, 152)
        Me.btnContaTodas.Name = "btnContaTodas"
        Me.btnContaTodas.Size = New System.Drawing.Size(44, 23)
        Me.btnContaTodas.TabIndex = 13
        Me.btnContaTodas.Text = ">>"
        Me.btnContaTodas.UseVisualStyleBackColor = True
        '
        'btnCaixaTodas
        '
        Me.btnCaixaTodas.Location = New System.Drawing.Point(193, 340)
        Me.btnCaixaTodas.Name = "btnCaixaTodas"
        Me.btnCaixaTodas.Size = New System.Drawing.Size(44, 23)
        Me.btnCaixaTodas.TabIndex = 15
        Me.btnCaixaTodas.Text = ">>"
        Me.btnCaixaTodas.UseVisualStyleBackColor = True
        '
        'btnCaixaCada
        '
        Me.btnCaixaCada.Location = New System.Drawing.Point(193, 279)
        Me.btnCaixaCada.Name = "btnCaixaCada"
        Me.btnCaixaCada.Size = New System.Drawing.Size(44, 23)
        Me.btnCaixaCada.TabIndex = 14
        Me.btnCaixaCada.Text = ">"
        Me.btnCaixaCada.UseVisualStyleBackColor = True
        '
        'btnContaRemoverTodas
        '
        Me.btnContaRemoverTodas.Location = New System.Drawing.Point(310, 217)
        Me.btnContaRemoverTodas.Name = "btnContaRemoverTodas"
        Me.btnContaRemoverTodas.Size = New System.Drawing.Size(95, 23)
        Me.btnContaRemoverTodas.TabIndex = 17
        Me.btnContaRemoverTodas.Text = "Remover Todas"
        Me.btnContaRemoverTodas.UseVisualStyleBackColor = True
        '
        'btnContaRemover
        '
        Me.btnContaRemover.Location = New System.Drawing.Point(243, 217)
        Me.btnContaRemover.Name = "btnContaRemover"
        Me.btnContaRemover.Size = New System.Drawing.Size(61, 23)
        Me.btnContaRemover.TabIndex = 16
        Me.btnContaRemover.Text = "Remover"
        Me.btnContaRemover.UseVisualStyleBackColor = True
        '
        'btnCaixaRemoverTodas
        '
        Me.btnCaixaRemoverTodas.Location = New System.Drawing.Point(310, 393)
        Me.btnCaixaRemoverTodas.Name = "btnCaixaRemoverTodas"
        Me.btnCaixaRemoverTodas.Size = New System.Drawing.Size(89, 23)
        Me.btnCaixaRemoverTodas.TabIndex = 19
        Me.btnCaixaRemoverTodas.Text = "Remover todas"
        Me.btnCaixaRemoverTodas.UseVisualStyleBackColor = True
        '
        'btnCaixaRemover
        '
        Me.btnCaixaRemover.Location = New System.Drawing.Point(243, 393)
        Me.btnCaixaRemover.Name = "btnCaixaRemover"
        Me.btnCaixaRemover.Size = New System.Drawing.Size(61, 23)
        Me.btnCaixaRemover.TabIndex = 18
        Me.btnCaixaRemover.Text = "Remover"
        Me.btnCaixaRemover.UseVisualStyleBackColor = True
        '
        'btnPrevisualizar
        '
        Me.btnPrevisualizar.Location = New System.Drawing.Point(310, 506)
        Me.btnPrevisualizar.Name = "btnPrevisualizar"
        Me.btnPrevisualizar.Size = New System.Drawing.Size(89, 23)
        Me.btnPrevisualizar.TabIndex = 21
        Me.btnPrevisualizar.Text = "Previsualizar"
        Me.btnPrevisualizar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Location = New System.Drawing.Point(243, 506)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(61, 23)
        Me.btnFechar.TabIndex = 20
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'FiltroConferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 550)
        Me.Controls.Add(Me.btnPrevisualizar)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnCaixaRemoverTodas)
        Me.Controls.Add(Me.btnCaixaRemover)
        Me.Controls.Add(Me.btnContaRemoverTodas)
        Me.Controls.Add(Me.btnContaRemover)
        Me.Controls.Add(Me.btnCaixaTodas)
        Me.Controls.Add(Me.btnCaixaCada)
        Me.Controls.Add(Me.btnContaTodas)
        Me.Controls.Add(Me.btnContaCada)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.chkboxContaOrigem)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkboxData)
        Me.Controls.Add(Me.chkboxDiarioCaixa)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FiltroConferencia"
        Me.Text = "Parametros"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtFinal As DateTimePicker
    Friend WithEvents dtInicial As DateTimePicker
    Friend WithEvents chkboxDiarioCaixa As CheckBox
    Friend WithEvents chkboxData As CheckBox
    Friend WithEvents lstboxDiariosConferidos As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkboxContaOrigem As CheckBox
    Friend WithEvents lstboxContaOrigem As ListBox
    Friend WithEvents lstboxContaOrigemSelecionados As ListBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lstboxDiariosConferidoSelecionados As ListBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnContaCada As Button
    Friend WithEvents btnContaTodas As Button
    Friend WithEvents btnCaixaTodas As Button
    Friend WithEvents btnCaixaCada As Button
    Friend WithEvents btnContaRemoverTodas As Button
    Friend WithEvents btnContaRemover As Button
    Friend WithEvents btnCaixaRemoverTodas As Button
    Friend WithEvents btnCaixaRemover As Button
    Friend WithEvents btnPrevisualizar As Button
    Friend WithEvents btnFechar As Button
End Class
