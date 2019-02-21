<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConferenciaCaixa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConferenciaCaixa))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ptxboxUtilizadorAberturaCaixa = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblEstdSaldoAbert = New System.Windows.Forms.Label()
        Me.lblEstdNumerario = New System.Windows.Forms.Label()
        Me.lblEstdPagamentoAutomatico = New System.Windows.Forms.Label()
        Me.lblEstdCheques = New System.Windows.Forms.Label()
        Me.lblEstdSenhas = New System.Windows.Forms.Label()
        Me.mskValRecAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskValRecNumerario = New System.Windows.Forms.MaskedTextBox()
        Me.mskValRecMultiBim = New System.Windows.Forms.MaskedTextBox()
        Me.mskValRecCheque = New System.Windows.Forms.MaskedTextBox()
        Me.mskValRecSenhasCabazes = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfNumerario = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfMultiBim = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfCheques = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfSenhas = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskDiferencaAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaNumerario = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaMultiBim = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaCheque = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaSenhasCabazes = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.mskValRecEntradaCaixa = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfEntradaCaixa = New System.Windows.Forms.MaskedTextBox()
        Me.mskValConfSaidaCaixa = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaEntradaCaixa = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaSaidaCaixa = New System.Windows.Forms.MaskedTextBox()
        Me.lblEstdEntradaCaixa = New System.Windows.Forms.Label()
        Me.lblEstdSaidaCaixa = New System.Windows.Forms.Label()
        Me.mskValRecSaidaCaixa = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblTotalDiferenca = New System.Windows.Forms.Label()
        Me.lblTotalRecebido = New System.Windows.Forms.Label()
        Me.lblTotalConferido = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mskDataAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.txtCaixaNum = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mskSaldoFecho = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mskSaldoAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUtilizadorAbertura = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUtilizadorFecho = New System.Windows.Forms.TextBox()
        Me.mskDataFecho = New System.Windows.Forms.MaskedTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnPrevisualizarReporte = New System.Windows.Forms.Button()
        Me.btnConfereLimpar = New System.Windows.Forms.Button()
        Me.btnConfereAdicionar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFechoContaMovimento = New System.Windows.Forms.Label()
        Me.lblFechoContaReferencia = New System.Windows.Forms.Label()
        Me.lblFechoContaQuantidade = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboModoRecebido = New System.Windows.Forms.ComboBox()
        Me.cboReferenciaModoReceb = New System.Windows.Forms.ComboBox()
        Me.mskValorRecebido = New System.Windows.Forms.MaskedTextBox()
        Me.lblFechoContaCartaoChequeDesc = New System.Windows.Forms.Label()
        Me.cboCartaoTipo = New System.Windows.Forms.ComboBox()
        Me.txtQuantidade = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimparTabela = New System.Windows.Forms.Button()
        Me.btnFecharConta = New System.Windows.Forms.Button()
        Me.tabelaConferenciaCaixa = New System.Windows.Forms.DataGridView()
        Me.modoMovimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cartaoTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descSaidaCaixa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FerramentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenciarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConexaoBaseDeDadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SistemaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreNósToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualDeUtilizadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerificarNovaVerãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.rodape = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlMensagemLicenca = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMsgLicencaExpiracao = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.ptxboxUtilizadorAberturaCaixa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.tabelaConferenciaCaixa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlMensagemLicenca.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.ptxboxUtilizadorAberturaCaixa)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Location = New System.Drawing.Point(6, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1294, 280)
        Me.Panel2.TabIndex = 0
        '
        'ptxboxUtilizadorAberturaCaixa
        '
        Me.ptxboxUtilizadorAberturaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ptxboxUtilizadorAberturaCaixa.ErrorImage = Global.pri_fechoConta.My.Resources.Resources._default
        Me.ptxboxUtilizadorAberturaCaixa.Image = Global.pri_fechoConta.My.Resources.Resources._default
        Me.ptxboxUtilizadorAberturaCaixa.ImageLocation = ""
        Me.ptxboxUtilizadorAberturaCaixa.Location = New System.Drawing.Point(1085, 6)
        Me.ptxboxUtilizadorAberturaCaixa.Name = "ptxboxUtilizadorAberturaCaixa"
        Me.ptxboxUtilizadorAberturaCaixa.Size = New System.Drawing.Size(184, 179)
        Me.ptxboxUtilizadorAberturaCaixa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptxboxUtilizadorAberturaCaixa.TabIndex = 1
        Me.ptxboxUtilizadorAberturaCaixa.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.53272!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.73572!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.73572!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.97486!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.02098!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdSaldoAbert, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdNumerario, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdPagamentoAutomatico, 4, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdCheques, 4, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdSenhas, 4, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecAbertura, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecNumerario, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecMultiBim, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecCheque, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecSenhasCabazes, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfAbertura, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfNumerario, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfMultiBim, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfCheques, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfSenhas, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaAbertura, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaNumerario, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaMultiBim, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaCheque, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaSenhasCabazes, 3, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecEntradaCaixa, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfEntradaCaixa, 2, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValConfSaidaCaixa, 2, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaEntradaCaixa, 3, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDiferencaSaidaCaixa, 3, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdEntradaCaixa, 4, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEstdSaidaCaixa, 4, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.mskValRecSaidaCaixa, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotalDiferenca, 3, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotalRecebido, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotalConferido, 2, 8)
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(437, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 9
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(621, 221)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(252, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Valor Conferido"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(142, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Valor Recebido"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Especié"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Saldo de Abertura:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Numerário:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Pagamentos Automáticos"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Cheques"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Senhas"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(479, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Estado"
        '
        'lblEstdSaldoAbert
        '
        Me.lblEstdSaldoAbert.AutoSize = True
        Me.lblEstdSaldoAbert.Location = New System.Drawing.Point(479, 25)
        Me.lblEstdSaldoAbert.Name = "lblEstdSaldoAbert"
        Me.lblEstdSaldoAbert.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdSaldoAbert.TabIndex = 11
        '
        'lblEstdNumerario
        '
        Me.lblEstdNumerario.AutoSize = True
        Me.lblEstdNumerario.Location = New System.Drawing.Point(479, 50)
        Me.lblEstdNumerario.Name = "lblEstdNumerario"
        Me.lblEstdNumerario.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdNumerario.TabIndex = 12
        '
        'lblEstdPagamentoAutomatico
        '
        Me.lblEstdPagamentoAutomatico.AutoSize = True
        Me.lblEstdPagamentoAutomatico.Location = New System.Drawing.Point(479, 75)
        Me.lblEstdPagamentoAutomatico.Name = "lblEstdPagamentoAutomatico"
        Me.lblEstdPagamentoAutomatico.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdPagamentoAutomatico.TabIndex = 13
        '
        'lblEstdCheques
        '
        Me.lblEstdCheques.AutoSize = True
        Me.lblEstdCheques.Location = New System.Drawing.Point(479, 100)
        Me.lblEstdCheques.Name = "lblEstdCheques"
        Me.lblEstdCheques.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdCheques.TabIndex = 15
        '
        'lblEstdSenhas
        '
        Me.lblEstdSenhas.AutoSize = True
        Me.lblEstdSenhas.Location = New System.Drawing.Point(479, 125)
        Me.lblEstdSenhas.Name = "lblEstdSenhas"
        Me.lblEstdSenhas.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdSenhas.TabIndex = 16
        '
        'mskValRecAbertura
        '
        Me.mskValRecAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecAbertura.Enabled = False
        Me.mskValRecAbertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValRecAbertura.Location = New System.Drawing.Point(142, 28)
        Me.mskValRecAbertura.Name = "mskValRecAbertura"
        Me.mskValRecAbertura.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecAbertura.TabIndex = 17
        Me.mskValRecAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValRecNumerario
        '
        Me.mskValRecNumerario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecNumerario.Enabled = False
        Me.mskValRecNumerario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValRecNumerario.Location = New System.Drawing.Point(142, 53)
        Me.mskValRecNumerario.Name = "mskValRecNumerario"
        Me.mskValRecNumerario.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecNumerario.TabIndex = 18
        Me.mskValRecNumerario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValRecMultiBim
        '
        Me.mskValRecMultiBim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecMultiBim.Enabled = False
        Me.mskValRecMultiBim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValRecMultiBim.Location = New System.Drawing.Point(142, 78)
        Me.mskValRecMultiBim.Name = "mskValRecMultiBim"
        Me.mskValRecMultiBim.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecMultiBim.TabIndex = 19
        Me.mskValRecMultiBim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValRecCheque
        '
        Me.mskValRecCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecCheque.Enabled = False
        Me.mskValRecCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskValRecCheque.Location = New System.Drawing.Point(142, 103)
        Me.mskValRecCheque.Name = "mskValRecCheque"
        Me.mskValRecCheque.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecCheque.TabIndex = 21
        Me.mskValRecCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValRecSenhasCabazes
        '
        Me.mskValRecSenhasCabazes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecSenhasCabazes.Enabled = False
        Me.mskValRecSenhasCabazes.Location = New System.Drawing.Point(142, 128)
        Me.mskValRecSenhasCabazes.Name = "mskValRecSenhasCabazes"
        Me.mskValRecSenhasCabazes.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecSenhasCabazes.TabIndex = 22
        Me.mskValRecSenhasCabazes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfAbertura
        '
        Me.mskValConfAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfAbertura.Enabled = False
        Me.mskValConfAbertura.Location = New System.Drawing.Point(252, 28)
        Me.mskValConfAbertura.Name = "mskValConfAbertura"
        Me.mskValConfAbertura.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfAbertura.TabIndex = 23
        Me.mskValConfAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfNumerario
        '
        Me.mskValConfNumerario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfNumerario.Enabled = False
        Me.mskValConfNumerario.Location = New System.Drawing.Point(252, 53)
        Me.mskValConfNumerario.Name = "mskValConfNumerario"
        Me.mskValConfNumerario.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfNumerario.TabIndex = 24
        Me.mskValConfNumerario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfMultiBim
        '
        Me.mskValConfMultiBim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfMultiBim.Enabled = False
        Me.mskValConfMultiBim.Location = New System.Drawing.Point(252, 78)
        Me.mskValConfMultiBim.Name = "mskValConfMultiBim"
        Me.mskValConfMultiBim.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfMultiBim.TabIndex = 25
        Me.mskValConfMultiBim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfCheques
        '
        Me.mskValConfCheques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfCheques.Enabled = False
        Me.mskValConfCheques.Location = New System.Drawing.Point(252, 103)
        Me.mskValConfCheques.Name = "mskValConfCheques"
        Me.mskValConfCheques.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfCheques.TabIndex = 27
        Me.mskValConfCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfSenhas
        '
        Me.mskValConfSenhas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfSenhas.Enabled = False
        Me.mskValConfSenhas.Location = New System.Drawing.Point(252, 128)
        Me.mskValConfSenhas.Name = "mskValConfSenhas"
        Me.mskValConfSenhas.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfSenhas.TabIndex = 28
        Me.mskValConfSenhas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(362, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Diferença"
        '
        'mskDiferencaAbertura
        '
        Me.mskDiferencaAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaAbertura.Enabled = False
        Me.mskDiferencaAbertura.Location = New System.Drawing.Point(362, 28)
        Me.mskDiferencaAbertura.Name = "mskDiferencaAbertura"
        Me.mskDiferencaAbertura.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaAbertura.TabIndex = 30
        Me.mskDiferencaAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDiferencaNumerario
        '
        Me.mskDiferencaNumerario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaNumerario.Enabled = False
        Me.mskDiferencaNumerario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskDiferencaNumerario.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.mskDiferencaNumerario.Location = New System.Drawing.Point(362, 53)
        Me.mskDiferencaNumerario.Name = "mskDiferencaNumerario"
        Me.mskDiferencaNumerario.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaNumerario.TabIndex = 31
        Me.mskDiferencaNumerario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDiferencaMultiBim
        '
        Me.mskDiferencaMultiBim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaMultiBim.Enabled = False
        Me.mskDiferencaMultiBim.Location = New System.Drawing.Point(362, 78)
        Me.mskDiferencaMultiBim.Name = "mskDiferencaMultiBim"
        Me.mskDiferencaMultiBim.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaMultiBim.TabIndex = 32
        Me.mskDiferencaMultiBim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDiferencaCheque
        '
        Me.mskDiferencaCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaCheque.Enabled = False
        Me.mskDiferencaCheque.Location = New System.Drawing.Point(362, 103)
        Me.mskDiferencaCheque.Name = "mskDiferencaCheque"
        Me.mskDiferencaCheque.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaCheque.TabIndex = 34
        Me.mskDiferencaCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDiferencaSenhasCabazes
        '
        Me.mskDiferencaSenhasCabazes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaSenhasCabazes.Enabled = False
        Me.mskDiferencaSenhasCabazes.Location = New System.Drawing.Point(362, 128)
        Me.mskDiferencaSenhasCabazes.Name = "mskDiferencaSenhasCabazes"
        Me.mskDiferencaSenhasCabazes.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaSenhasCabazes.TabIndex = 35
        Me.mskDiferencaSenhasCabazes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Entrada Caixa"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 175)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Saida Caixa"
        '
        'mskValRecEntradaCaixa
        '
        Me.mskValRecEntradaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecEntradaCaixa.Enabled = False
        Me.mskValRecEntradaCaixa.Location = New System.Drawing.Point(142, 153)
        Me.mskValRecEntradaCaixa.Name = "mskValRecEntradaCaixa"
        Me.mskValRecEntradaCaixa.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecEntradaCaixa.TabIndex = 38
        Me.mskValRecEntradaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfEntradaCaixa
        '
        Me.mskValConfEntradaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfEntradaCaixa.Enabled = False
        Me.mskValConfEntradaCaixa.Location = New System.Drawing.Point(252, 153)
        Me.mskValConfEntradaCaixa.Name = "mskValConfEntradaCaixa"
        Me.mskValConfEntradaCaixa.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfEntradaCaixa.TabIndex = 40
        Me.mskValConfEntradaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskValConfSaidaCaixa
        '
        Me.mskValConfSaidaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValConfSaidaCaixa.ForeColor = System.Drawing.Color.Red
        Me.mskValConfSaidaCaixa.Location = New System.Drawing.Point(252, 178)
        Me.mskValConfSaidaCaixa.Name = "mskValConfSaidaCaixa"
        Me.mskValConfSaidaCaixa.Size = New System.Drawing.Size(104, 20)
        Me.mskValConfSaidaCaixa.TabIndex = 41
        Me.mskValConfSaidaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDiferencaEntradaCaixa
        '
        Me.mskDiferencaEntradaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaEntradaCaixa.Enabled = False
        Me.mskDiferencaEntradaCaixa.Location = New System.Drawing.Point(362, 153)
        Me.mskDiferencaEntradaCaixa.Name = "mskDiferencaEntradaCaixa"
        Me.mskDiferencaEntradaCaixa.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaEntradaCaixa.TabIndex = 42
        Me.mskDiferencaEntradaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mskDiferencaSaidaCaixa
        '
        Me.mskDiferencaSaidaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDiferencaSaidaCaixa.Enabled = False
        Me.mskDiferencaSaidaCaixa.Location = New System.Drawing.Point(362, 178)
        Me.mskDiferencaSaidaCaixa.Name = "mskDiferencaSaidaCaixa"
        Me.mskDiferencaSaidaCaixa.Size = New System.Drawing.Size(99, 20)
        Me.mskDiferencaSaidaCaixa.TabIndex = 43
        Me.mskDiferencaSaidaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEstdEntradaCaixa
        '
        Me.lblEstdEntradaCaixa.AutoSize = True
        Me.lblEstdEntradaCaixa.Location = New System.Drawing.Point(479, 150)
        Me.lblEstdEntradaCaixa.Name = "lblEstdEntradaCaixa"
        Me.lblEstdEntradaCaixa.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdEntradaCaixa.TabIndex = 44
        '
        'lblEstdSaidaCaixa
        '
        Me.lblEstdSaidaCaixa.AutoSize = True
        Me.lblEstdSaidaCaixa.Location = New System.Drawing.Point(479, 175)
        Me.lblEstdSaidaCaixa.Name = "lblEstdSaidaCaixa"
        Me.lblEstdSaidaCaixa.Size = New System.Drawing.Size(0, 13)
        Me.lblEstdSaidaCaixa.TabIndex = 45
        '
        'mskValRecSaidaCaixa
        '
        Me.mskValRecSaidaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValRecSaidaCaixa.ForeColor = System.Drawing.Color.Red
        Me.mskValRecSaidaCaixa.Location = New System.Drawing.Point(142, 178)
        Me.mskValRecSaidaCaixa.Name = "mskValRecSaidaCaixa"
        Me.mskValRecSaidaCaixa.Size = New System.Drawing.Size(104, 20)
        Me.mskValRecSaidaCaixa.TabIndex = 39
        Me.mskValRecSaidaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 200)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 13)
        Me.Label19.TabIndex = 46
        Me.Label19.Text = "Total"
        '
        'lblTotalDiferenca
        '
        Me.lblTotalDiferenca.AutoSize = True
        Me.lblTotalDiferenca.Location = New System.Drawing.Point(362, 200)
        Me.lblTotalDiferenca.Name = "lblTotalDiferenca"
        Me.lblTotalDiferenca.Size = New System.Drawing.Size(11, 13)
        Me.lblTotalDiferenca.TabIndex = 49
        Me.lblTotalDiferenca.Text = " "
        Me.lblTotalDiferenca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalRecebido
        '
        Me.lblTotalRecebido.AutoSize = True
        Me.lblTotalRecebido.Location = New System.Drawing.Point(142, 200)
        Me.lblTotalRecebido.Name = "lblTotalRecebido"
        Me.lblTotalRecebido.Size = New System.Drawing.Size(0, 13)
        Me.lblTotalRecebido.TabIndex = 47
        Me.lblTotalRecebido.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalConferido
        '
        Me.lblTotalConferido.AutoSize = True
        Me.lblTotalConferido.Location = New System.Drawing.Point(252, 200)
        Me.lblTotalConferido.Name = "lblTotalConferido"
        Me.lblTotalConferido.Size = New System.Drawing.Size(11, 13)
        Me.lblTotalConferido.TabIndex = 48
        Me.lblTotalConferido.Text = " "
        Me.lblTotalConferido.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDataAbertura, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCaixaNum, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LinkLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.mskSaldoFecho, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.mskSaldoAbertura, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUtilizadorAbertura, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUtilizadorFecho, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDataFecho, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(428, 173)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Abertura:"
        '
        'mskDataAbertura
        '
        Me.mskDataAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDataAbertura.Enabled = False
        Me.mskDataAbertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskDataAbertura.Location = New System.Drawing.Point(217, 27)
        Me.mskDataAbertura.Name = "mskDataAbertura"
        Me.mskDataAbertura.Size = New System.Drawing.Size(208, 20)
        Me.mskDataAbertura.TabIndex = 7
        '
        'txtCaixaNum
        '
        Me.txtCaixaNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaixaNum.Enabled = False
        Me.txtCaixaNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaixaNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCaixaNum.Location = New System.Drawing.Point(217, 3)
        Me.txtCaixaNum.Name = "txtCaixaNum"
        Me.txtCaixaNum.Size = New System.Drawing.Size(74, 20)
        Me.txtCaixaNum.TabIndex = 13
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(49, 13)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = " Caixa nº"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Saldo de Fecho:"
        '
        'mskSaldoFecho
        '
        Me.mskSaldoFecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskSaldoFecho.Enabled = False
        Me.mskSaldoFecho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskSaldoFecho.Location = New System.Drawing.Point(217, 147)
        Me.mskSaldoFecho.Name = "mskSaldoFecho"
        Me.mskSaldoFecho.Size = New System.Drawing.Size(208, 20)
        Me.mskSaldoFecho.TabIndex = 10
        Me.mskSaldoFecho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Saldo de Abertura:"
        '
        'mskSaldoAbertura
        '
        Me.mskSaldoAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskSaldoAbertura.Enabled = False
        Me.mskSaldoAbertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskSaldoAbertura.Location = New System.Drawing.Point(217, 123)
        Me.mskSaldoAbertura.Name = "mskSaldoAbertura"
        Me.mskSaldoAbertura.Size = New System.Drawing.Size(208, 20)
        Me.mskSaldoAbertura.TabIndex = 8
        Me.mskSaldoAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Utilizador Abertura:"
        '
        'txtUtilizadorAbertura
        '
        Me.txtUtilizadorAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUtilizadorAbertura.Enabled = False
        Me.txtUtilizadorAbertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUtilizadorAbertura.Location = New System.Drawing.Point(217, 51)
        Me.txtUtilizadorAbertura.Name = "txtUtilizadorAbertura"
        Me.txtUtilizadorAbertura.Size = New System.Drawing.Size(208, 20)
        Me.txtUtilizadorAbertura.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Utilizador Fecho:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Data Fecho:"
        '
        'txtUtilizadorFecho
        '
        Me.txtUtilizadorFecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUtilizadorFecho.Enabled = False
        Me.txtUtilizadorFecho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUtilizadorFecho.Location = New System.Drawing.Point(217, 99)
        Me.txtUtilizadorFecho.Name = "txtUtilizadorFecho"
        Me.txtUtilizadorFecho.Size = New System.Drawing.Size(208, 20)
        Me.txtUtilizadorFecho.TabIndex = 12
        '
        'mskDataFecho
        '
        Me.mskDataFecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskDataFecho.Enabled = False
        Me.mskDataFecho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskDataFecho.Location = New System.Drawing.Point(217, 75)
        Me.mskDataFecho.Name = "mskDataFecho"
        Me.mskDataFecho.Size = New System.Drawing.Size(208, 20)
        Me.mskDataFecho.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.btnPrevisualizarReporte)
        Me.Panel3.Controls.Add(Me.btnConfereLimpar)
        Me.Panel3.Controls.Add(Me.btnConfereAdicionar)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Location = New System.Drawing.Point(0, 313)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1297, 61)
        Me.Panel3.TabIndex = 0
        '
        'btnPrevisualizarReporte
        '
        Me.btnPrevisualizarReporte.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrevisualizarReporte.Enabled = False
        Me.btnPrevisualizarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrevisualizarReporte.Location = New System.Drawing.Point(1178, 33)
        Me.btnPrevisualizarReporte.Name = "btnPrevisualizarReporte"
        Me.btnPrevisualizarReporte.Size = New System.Drawing.Size(94, 23)
        Me.btnPrevisualizarReporte.TabIndex = 3
        Me.btnPrevisualizarReporte.Text = "Pre-visualizar"
        Me.btnPrevisualizarReporte.UseVisualStyleBackColor = False
        '
        'btnConfereLimpar
        '
        Me.btnConfereLimpar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConfereLimpar.Enabled = False
        Me.btnConfereLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfereLimpar.Location = New System.Drawing.Point(1067, 33)
        Me.btnConfereLimpar.Name = "btnConfereLimpar"
        Me.btnConfereLimpar.Size = New System.Drawing.Size(104, 23)
        Me.btnConfereLimpar.TabIndex = 2
        Me.btnConfereLimpar.Text = "Limpar Campos"
        Me.btnConfereLimpar.UseVisualStyleBackColor = False
        '
        'btnConfereAdicionar
        '
        Me.btnConfereAdicionar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConfereAdicionar.Enabled = False
        Me.btnConfereAdicionar.FlatAppearance.BorderSize = 2
        Me.btnConfereAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfereAdicionar.Location = New System.Drawing.Point(986, 34)
        Me.btnConfereAdicionar.Name = "btnConfereAdicionar"
        Me.btnConfereAdicionar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfereAdicionar.TabIndex = 1
        Me.btnConfereAdicionar.Text = "Adicionar"
        Me.btnConfereAdicionar.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.64674!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.64674!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.74656!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.95996!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblFechoContaMovimento, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFechoContaReferencia, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFechoContaQuantidade, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label28, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboModoRecebido, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboReferenciaModoReceb, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.mskValorRecebido, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFechoContaCartaoChequeDesc, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboCartaoTipo, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtQuantidade, 3, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 6)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(963, 55)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'lblFechoContaMovimento
        '
        Me.lblFechoContaMovimento.AutoSize = True
        Me.lblFechoContaMovimento.Location = New System.Drawing.Point(3, 0)
        Me.lblFechoContaMovimento.Name = "lblFechoContaMovimento"
        Me.lblFechoContaMovimento.Size = New System.Drawing.Size(89, 13)
        Me.lblFechoContaMovimento.TabIndex = 0
        Me.lblFechoContaMovimento.Text = "Modo Movimento"
        '
        'lblFechoContaReferencia
        '
        Me.lblFechoContaReferencia.AutoSize = True
        Me.lblFechoContaReferencia.Location = New System.Drawing.Point(227, 0)
        Me.lblFechoContaReferencia.Name = "lblFechoContaReferencia"
        Me.lblFechoContaReferencia.Size = New System.Drawing.Size(59, 13)
        Me.lblFechoContaReferencia.TabIndex = 1
        Me.lblFechoContaReferencia.Text = "Referência"
        '
        'lblFechoContaQuantidade
        '
        Me.lblFechoContaQuantidade.AutoSize = True
        Me.lblFechoContaQuantidade.Location = New System.Drawing.Point(658, 0)
        Me.lblFechoContaQuantidade.Name = "lblFechoContaQuantidade"
        Me.lblFechoContaQuantidade.Size = New System.Drawing.Size(10, 13)
        Me.lblFechoContaQuantidade.TabIndex = 2
        Me.lblFechoContaQuantidade.Text = " "
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(777, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Valor"
        '
        'cboModoRecebido
        '
        Me.cboModoRecebido.Enabled = False
        Me.cboModoRecebido.FormattingEnabled = True
        Me.cboModoRecebido.Location = New System.Drawing.Point(3, 30)
        Me.cboModoRecebido.Name = "cboModoRecebido"
        Me.cboModoRecebido.Size = New System.Drawing.Size(218, 21)
        Me.cboModoRecebido.TabIndex = 4
        '
        'cboReferenciaModoReceb
        '
        Me.cboReferenciaModoReceb.Enabled = False
        Me.cboReferenciaModoReceb.FormattingEnabled = True
        Me.cboReferenciaModoReceb.Location = New System.Drawing.Point(227, 30)
        Me.cboReferenciaModoReceb.Name = "cboReferenciaModoReceb"
        Me.cboReferenciaModoReceb.Size = New System.Drawing.Size(218, 21)
        Me.cboReferenciaModoReceb.TabIndex = 5
        '
        'mskValorRecebido
        '
        Me.mskValorRecebido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mskValorRecebido.Enabled = False
        Me.mskValorRecebido.Location = New System.Drawing.Point(777, 30)
        Me.mskValorRecebido.Name = "mskValorRecebido"
        Me.mskValorRecebido.Size = New System.Drawing.Size(183, 20)
        Me.mskValorRecebido.TabIndex = 9
        Me.mskValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFechoContaCartaoChequeDesc
        '
        Me.lblFechoContaCartaoChequeDesc.AutoSize = True
        Me.lblFechoContaCartaoChequeDesc.Location = New System.Drawing.Point(451, 0)
        Me.lblFechoContaCartaoChequeDesc.Name = "lblFechoContaCartaoChequeDesc"
        Me.lblFechoContaCartaoChequeDesc.Size = New System.Drawing.Size(10, 13)
        Me.lblFechoContaCartaoChequeDesc.TabIndex = 12
        Me.lblFechoContaCartaoChequeDesc.Text = " "
        '
        'cboCartaoTipo
        '
        Me.cboCartaoTipo.Enabled = False
        Me.cboCartaoTipo.FormattingEnabled = True
        Me.cboCartaoTipo.Location = New System.Drawing.Point(451, 30)
        Me.cboCartaoTipo.Name = "cboCartaoTipo"
        Me.cboCartaoTipo.Size = New System.Drawing.Size(197, 21)
        Me.cboCartaoTipo.TabIndex = 13
        '
        'txtQuantidade
        '
        Me.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantidade.Enabled = False
        Me.txtQuantidade.Location = New System.Drawing.Point(658, 30)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(113, 20)
        Me.txtQuantidade.TabIndex = 10
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnLimparTabela)
        Me.Panel4.Controls.Add(Me.btnFecharConta)
        Me.Panel4.Controls.Add(Me.tabelaConferenciaCaixa)
        Me.Panel4.Location = New System.Drawing.Point(3, 380)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1297, 200)
        Me.Panel4.TabIndex = 0
        '
        'btnLimparTabela
        '
        Me.btnLimparTabela.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimparTabela.Enabled = False
        Me.btnLimparTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimparTabela.Location = New System.Drawing.Point(1197, 3)
        Me.btnLimparTabela.Name = "btnLimparTabela"
        Me.btnLimparTabela.Size = New System.Drawing.Size(75, 41)
        Me.btnLimparTabela.TabIndex = 1
        Me.btnLimparTabela.Text = "Limpar Tabela"
        Me.btnLimparTabela.UseVisualStyleBackColor = False
        '
        'btnFecharConta
        '
        Me.btnFecharConta.BackColor = System.Drawing.SystemColors.Control
        Me.btnFecharConta.Enabled = False
        Me.btnFecharConta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFecharConta.Location = New System.Drawing.Point(1197, 155)
        Me.btnFecharConta.Name = "btnFecharConta"
        Me.btnFecharConta.Size = New System.Drawing.Size(75, 23)
        Me.btnFecharConta.TabIndex = 0
        Me.btnFecharConta.Text = "Terminar"
        Me.btnFecharConta.UseVisualStyleBackColor = False
        '
        'tabelaConferenciaCaixa
        '
        Me.tabelaConferenciaCaixa.BackgroundColor = System.Drawing.Color.SlateGray
        Me.tabelaConferenciaCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabelaConferenciaCaixa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.modoMovimento, Me.Referencia, Me.cartaoTipo, Me.descricao, Me.descSaidaCaixa, Me.quantidade, Me.valor})
        Me.tabelaConferenciaCaixa.Location = New System.Drawing.Point(3, 3)
        Me.tabelaConferenciaCaixa.Name = "tabelaConferenciaCaixa"
        Me.tabelaConferenciaCaixa.Size = New System.Drawing.Size(1188, 197)
        Me.tabelaConferenciaCaixa.TabIndex = 0
        '
        'modoMovimento
        '
        Me.modoMovimento.HeaderText = "Modo Movimento"
        Me.modoMovimento.Name = "modoMovimento"
        Me.modoMovimento.ReadOnly = True
        Me.modoMovimento.Width = 150
        '
        'Referencia
        '
        Me.Referencia.HeaderText = "Referência"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Width = 200
        '
        'cartaoTipo
        '
        Me.cartaoTipo.HeaderText = "Cartão Tipo / Cheque Descrição"
        Me.cartaoTipo.Name = "cartaoTipo"
        Me.cartaoTipo.Width = 150
        '
        'descricao
        '
        Me.descricao.HeaderText = "Transação número / Cheque Número"
        Me.descricao.Name = "descricao"
        Me.descricao.Width = 150
        '
        'descSaidaCaixa
        '
        Me.descSaidaCaixa.HeaderText = "Descrição Saida de Caixa"
        Me.descSaidaCaixa.Name = "descSaidaCaixa"
        Me.descSaidaCaixa.Width = 250
        '
        'quantidade
        '
        Me.quantidade.HeaderText = "Quantidade"
        Me.quantidade.Name = "quantidade"
        '
        'valor
        '
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        Me.valor.Width = 150
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SistemaToolStripMenuItem, Me.FerramentasToolStripMenuItem, Me.ConfigurarToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1300, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntrarToolStripMenuItem, Me.RegistrarToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.SistemaToolStripMenuItem.Text = "Sistema"
        '
        'EntrarToolStripMenuItem
        '
        Me.EntrarToolStripMenuItem.Name = "EntrarToolStripMenuItem"
        Me.EntrarToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.EntrarToolStripMenuItem.Text = "Entrar"
        '
        'RegistrarToolStripMenuItem
        '
        Me.RegistrarToolStripMenuItem.Name = "RegistrarToolStripMenuItem"
        Me.RegistrarToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.RegistrarToolStripMenuItem.Text = "&Registrar"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'FerramentasToolStripMenuItem
        '
        Me.FerramentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LicenciarToolStripMenuItem})
        Me.FerramentasToolStripMenuItem.Name = "FerramentasToolStripMenuItem"
        Me.FerramentasToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.FerramentasToolStripMenuItem.Text = "Ferramentas"
        '
        'LicenciarToolStripMenuItem
        '
        Me.LicenciarToolStripMenuItem.Name = "LicenciarToolStripMenuItem"
        Me.LicenciarToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.LicenciarToolStripMenuItem.Text = "Licenciar"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConexaoBaseDeDadosToolStripMenuItem, Me.SistemaToolStripMenuItem1})
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar"
        '
        'ConexaoBaseDeDadosToolStripMenuItem
        '
        Me.ConexaoBaseDeDadosToolStripMenuItem.Name = "ConexaoBaseDeDadosToolStripMenuItem"
        Me.ConexaoBaseDeDadosToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.ConexaoBaseDeDadosToolStripMenuItem.Text = "Conexao BD"
        '
        'SistemaToolStripMenuItem1
        '
        Me.SistemaToolStripMenuItem1.Name = "SistemaToolStripMenuItem1"
        Me.SistemaToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.SistemaToolStripMenuItem1.Text = "Sistema"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreNósToolStripMenuItem, Me.ManualDeUtilizadorToolStripMenuItem, Me.VerificarNovaVerãoToolStripMenuItem})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem.Text = "Ajuda"
        '
        'SobreNósToolStripMenuItem
        '
        Me.SobreNósToolStripMenuItem.Name = "SobreNósToolStripMenuItem"
        Me.SobreNósToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SobreNósToolStripMenuItem.Text = "Sobre nós"
        '
        'ManualDeUtilizadorToolStripMenuItem
        '
        Me.ManualDeUtilizadorToolStripMenuItem.Name = "ManualDeUtilizadorToolStripMenuItem"
        Me.ManualDeUtilizadorToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ManualDeUtilizadorToolStripMenuItem.Text = "Manual de Utilizador"
        '
        'VerificarNovaVerãoToolStripMenuItem
        '
        Me.VerificarNovaVerãoToolStripMenuItem.Name = "VerificarNovaVerãoToolStripMenuItem"
        Me.VerificarNovaVerãoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.VerificarNovaVerãoToolStripMenuItem.Text = "Verificar nova verão"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rodape})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 588)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1300, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'rodape
        '
        Me.rodape.Name = "rodape"
        Me.rodape.Size = New System.Drawing.Size(112, 17)
        Me.rodape.Text = "Sessão Não Iniciado"
        '
        'pnlMensagemLicenca
        '
        Me.pnlMensagemLicenca.BackColor = System.Drawing.Color.Red
        Me.pnlMensagemLicenca.Controls.Add(Me.LinkLabel2)
        Me.pnlMensagemLicenca.Controls.Add(Me.PictureBox1)
        Me.pnlMensagemLicenca.Controls.Add(Me.lblMsgLicencaExpiracao)
        Me.pnlMensagemLicenca.Location = New System.Drawing.Point(341, 1)
        Me.pnlMensagemLicenca.Name = "pnlMensagemLicenca"
        Me.pnlMensagemLicenca.Size = New System.Drawing.Size(581, 23)
        Me.pnlMensagemLicenca.TabIndex = 3
        Me.pnlMensagemLicenca.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(512, 5)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(66, 13)
        Me.LinkLabel2.TabIndex = 3
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Fechar   X"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.pri_fechoConta.My.Resources.Resources.perigo
        Me.PictureBox1.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblMsgLicencaExpiracao
        '
        Me.lblMsgLicencaExpiracao.AutoSize = True
        Me.lblMsgLicencaExpiracao.BackColor = System.Drawing.Color.Transparent
        Me.lblMsgLicencaExpiracao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgLicencaExpiracao.ForeColor = System.Drawing.Color.Yellow
        Me.lblMsgLicencaExpiracao.Location = New System.Drawing.Point(33, 3)
        Me.lblMsgLicencaExpiracao.Name = "lblMsgLicencaExpiracao"
        Me.lblMsgLicencaExpiracao.Size = New System.Drawing.Size(0, 17)
        Me.lblMsgLicencaExpiracao.TabIndex = 0
        '
        'ConferenciaCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1300, 610)
        Me.Controls.Add(Me.pnlMensagemLicenca)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ConferenciaCaixa"
        Me.Text = " PRI-Conferência de Caixa "
        Me.Panel2.ResumeLayout(False)
        CType(Me.ptxboxUtilizadorAberturaCaixa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.tabelaConferenciaCaixa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlMensagemLicenca.ResumeLayout(False)
        Me.pnlMensagemLicenca.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblEstdSaldoAbert As Label
    Friend WithEvents lblEstdNumerario As Label
    Friend WithEvents lblEstdPagamentoAutomatico As Label
    Friend WithEvents lblEstdCheques As Label
    Friend WithEvents lblEstdSenhas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblFechoContaMovimento As Label
    Friend WithEvents lblFechoContaReferencia As Label
    Friend WithEvents lblFechoContaQuantidade As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents btnConfereAdicionar As Button
    Friend WithEvents cboModoRecebido As ComboBox
    Friend WithEvents cboReferenciaModoReceb As ComboBox
    Friend WithEvents tabelaConferenciaCaixa As DataGridView
    Friend WithEvents btnFecharConta As Button
    Friend WithEvents mskValRecAbertura As MaskedTextBox
    Friend WithEvents mskValRecNumerario As MaskedTextBox
    Friend WithEvents mskValRecMultiBim As MaskedTextBox
    Friend WithEvents mskValRecCheque As MaskedTextBox
    Friend WithEvents mskValRecSenhasCabazes As MaskedTextBox
    Friend WithEvents mskValConfAbertura As MaskedTextBox
    Friend WithEvents mskValConfNumerario As MaskedTextBox
    Friend WithEvents mskValConfMultiBim As MaskedTextBox
    Friend WithEvents mskValConfCheques As MaskedTextBox
    Friend WithEvents mskValConfSenhas As MaskedTextBox
    Friend WithEvents mskDataAbertura As MaskedTextBox
    Friend WithEvents mskSaldoAbertura As MaskedTextBox
    Friend WithEvents mskDataFecho As MaskedTextBox
    Friend WithEvents mskSaldoFecho As MaskedTextBox
    Friend WithEvents txtUtilizadorFecho As TextBox
    Friend WithEvents txtCaixaNum As TextBox
    Friend WithEvents mskValorRecebido As MaskedTextBox
    Friend WithEvents txtQuantidade As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents mskDiferencaAbertura As MaskedTextBox
    Friend WithEvents mskDiferencaNumerario As MaskedTextBox
    Friend WithEvents mskDiferencaMultiBim As MaskedTextBox
    Friend WithEvents mskDiferencaCheque As MaskedTextBox
    Friend WithEvents mskDiferencaSenhasCabazes As MaskedTextBox
    Public WithEvents txtUtilizadorAbertura As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents mskValRecEntradaCaixa As MaskedTextBox
    Friend WithEvents mskValRecSaidaCaixa As MaskedTextBox
    Friend WithEvents mskValConfEntradaCaixa As MaskedTextBox
    Friend WithEvents mskValConfSaidaCaixa As MaskedTextBox
    Friend WithEvents mskDiferencaEntradaCaixa As MaskedTextBox
    Friend WithEvents mskDiferencaSaidaCaixa As MaskedTextBox
    Friend WithEvents lblEstdEntradaCaixa As Label
    Friend WithEvents lblEstdSaidaCaixa As Label
    Friend WithEvents lblFechoContaCartaoChequeDesc As Label
    Friend WithEvents cboCartaoTipo As ComboBox
    Friend WithEvents btnConfereLimpar As Button
    Friend WithEvents ptxboxUtilizadorAberturaCaixa As PictureBox
    Friend WithEvents Label19 As Label
    Friend WithEvents lblTotalRecebido As Label
    Friend WithEvents lblTotalDiferenca As Label
    Friend WithEvents lblTotalConferido As Label
    Friend WithEvents btnLimparTabela As Button
    Friend WithEvents modoMovimento As DataGridViewTextBoxColumn
    Friend WithEvents Referencia As DataGridViewTextBoxColumn
    Friend WithEvents cartaoTipo As DataGridViewTextBoxColumn
    Friend WithEvents descricao As DataGridViewTextBoxColumn
    Friend WithEvents descSaidaCaixa As DataGridViewTextBoxColumn
    Friend WithEvents quantidade As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn
    Friend WithEvents btnPrevisualizarReporte As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SistemaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FerramentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LicenciarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConexaoBaseDeDadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents rodape As ToolStripStatusLabel
    Friend WithEvents SistemaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SobreNósToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualDeUtilizadorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerificarNovaVerãoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlMensagemLicenca As Panel
    Friend WithEvents lblMsgLicencaExpiracao As Label
    Friend WithEvents LinkLabel2 As LinkLabel
End Class
