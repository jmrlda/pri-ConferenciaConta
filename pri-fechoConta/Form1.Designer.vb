<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FechoConta
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim btnAdicionar As System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.mskValorRecebAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorRecebNumerario = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorRecebMultiBim = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorRecebMultiUnico = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorRecebCabazes = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorConfAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorConfNumerario = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorConfMultiBim = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorConfMultiUnico = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorConfCabazes = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaNumerario = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaMultiBim = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaMultiUnico = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaCabazes = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.mskValorRecebCheque = New System.Windows.Forms.MaskedTextBox()
        Me.mskValorConfCheque = New System.Windows.Forms.MaskedTextBox()
        Me.mskDiferencaCheques = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblEstadoAbertura = New System.Windows.Forms.Label()
        Me.lblEstadoNumerario = New System.Windows.Forms.Label()
        Me.lblEstadoMultiBim = New System.Windows.Forms.Label()
        Me.lblEstadoMultiUnico = New System.Windows.Forms.Label()
        Me.lblEstadoCheques = New System.Windows.Forms.Label()
        Me.lblEstadoCabazes = New System.Windows.Forms.Label()
        Me.mskSaldoFecho = New System.Windows.Forms.MaskedTextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.mskDataFecho = New System.Windows.Forms.MaskedTextBox()
        Me.mskSaldoAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.mskDataAbertura = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCaixaNum = New System.Windows.Forms.TextBox()
        Me.txtUtilizadoFecho = New System.Windows.Forms.TextBox()
        Me.txtUtilizadorAbertura = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboModoRecebimento = New System.Windows.Forms.ComboBox()
        Me.cboReferencia = New System.Windows.Forms.ComboBox()
        Me.mskValor = New System.Windows.Forms.MaskedTextBox()
        Me.numQuantidade = New System.Windows.Forms.NumericUpDown()
        Me.quadroConferencia = New System.Windows.Forms.DataGridView()
        Me.modoRecebimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        btnAdicionar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.numQuantidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quadroConferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(1, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 250)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1001, 34)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorRecebAbertura, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorRecebNumerario, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorRecebMultiBim, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorRecebMultiUnico, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorRecebCabazes, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorConfAbertura, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorConfNumerario, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorConfMultiBim, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorConfMultiUnico, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorConfCabazes, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDiferencaAbertura, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDiferencaNumerario, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDiferencaMultiBim, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDiferencaMultiUnico, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDiferencaCabazes, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorRecebCheque, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.mskValorConfCheque, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.mskDiferencaCheques, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstadoAbertura, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstadoNumerario, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstadoMultiBim, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstadoMultiUnico, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstadoCheques, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstadoCabazes, 4, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(397, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(544, 220)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Espécie"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Valor de Abertura:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Numerário:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Multibanco BIM:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Multibanco ÚNICO:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Senhas CABAZES:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(123, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Valor Recebido"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(243, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Valor Conferido"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(363, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Diferença"
        '
        'mskValorRecebAbertura
        '
        Me.mskValorRecebAbertura.Location = New System.Drawing.Point(123, 34)
        Me.mskValorRecebAbertura.Name = "mskValorRecebAbertura"
        Me.mskValorRecebAbertura.Size = New System.Drawing.Size(100, 20)
        Me.mskValorRecebAbertura.TabIndex = 9
        '
        'mskValorRecebNumerario
        '
        Me.mskValorRecebNumerario.Location = New System.Drawing.Point(123, 65)
        Me.mskValorRecebNumerario.Name = "mskValorRecebNumerario"
        Me.mskValorRecebNumerario.Size = New System.Drawing.Size(100, 20)
        Me.mskValorRecebNumerario.TabIndex = 10
        '
        'mskValorRecebMultiBim
        '
        Me.mskValorRecebMultiBim.Location = New System.Drawing.Point(123, 96)
        Me.mskValorRecebMultiBim.Name = "mskValorRecebMultiBim"
        Me.mskValorRecebMultiBim.Size = New System.Drawing.Size(100, 20)
        Me.mskValorRecebMultiBim.TabIndex = 11
        '
        'mskValorRecebMultiUnico
        '
        Me.mskValorRecebMultiUnico.Location = New System.Drawing.Point(123, 127)
        Me.mskValorRecebMultiUnico.Name = "mskValorRecebMultiUnico"
        Me.mskValorRecebMultiUnico.Size = New System.Drawing.Size(100, 20)
        Me.mskValorRecebMultiUnico.TabIndex = 12
        '
        'mskValorRecebCabazes
        '
        Me.mskValorRecebCabazes.Location = New System.Drawing.Point(123, 189)
        Me.mskValorRecebCabazes.Name = "mskValorRecebCabazes"
        Me.mskValorRecebCabazes.Size = New System.Drawing.Size(100, 20)
        Me.mskValorRecebCabazes.TabIndex = 13
        '
        'mskValorConfAbertura
        '
        Me.mskValorConfAbertura.Location = New System.Drawing.Point(243, 34)
        Me.mskValorConfAbertura.Name = "mskValorConfAbertura"
        Me.mskValorConfAbertura.Size = New System.Drawing.Size(100, 20)
        Me.mskValorConfAbertura.TabIndex = 14
        '
        'mskValorConfNumerario
        '
        Me.mskValorConfNumerario.Location = New System.Drawing.Point(243, 65)
        Me.mskValorConfNumerario.Name = "mskValorConfNumerario"
        Me.mskValorConfNumerario.Size = New System.Drawing.Size(100, 20)
        Me.mskValorConfNumerario.TabIndex = 15
        '
        'mskValorConfMultiBim
        '
        Me.mskValorConfMultiBim.Location = New System.Drawing.Point(243, 96)
        Me.mskValorConfMultiBim.Name = "mskValorConfMultiBim"
        Me.mskValorConfMultiBim.Size = New System.Drawing.Size(100, 20)
        Me.mskValorConfMultiBim.TabIndex = 16
        '
        'mskValorConfMultiUnico
        '
        Me.mskValorConfMultiUnico.Location = New System.Drawing.Point(243, 127)
        Me.mskValorConfMultiUnico.Name = "mskValorConfMultiUnico"
        Me.mskValorConfMultiUnico.Size = New System.Drawing.Size(100, 20)
        Me.mskValorConfMultiUnico.TabIndex = 17
        '
        'mskValorConfCabazes
        '
        Me.mskValorConfCabazes.Location = New System.Drawing.Point(243, 189)
        Me.mskValorConfCabazes.Name = "mskValorConfCabazes"
        Me.mskValorConfCabazes.Size = New System.Drawing.Size(100, 20)
        Me.mskValorConfCabazes.TabIndex = 18
        '
        'mskDiferencaAbertura
        '
        Me.mskDiferencaAbertura.Location = New System.Drawing.Point(363, 34)
        Me.mskDiferencaAbertura.Name = "mskDiferencaAbertura"
        Me.mskDiferencaAbertura.Size = New System.Drawing.Size(100, 20)
        Me.mskDiferencaAbertura.TabIndex = 19
        '
        'mskDiferencaNumerario
        '
        Me.mskDiferencaNumerario.Location = New System.Drawing.Point(363, 65)
        Me.mskDiferencaNumerario.Name = "mskDiferencaNumerario"
        Me.mskDiferencaNumerario.Size = New System.Drawing.Size(100, 20)
        Me.mskDiferencaNumerario.TabIndex = 20
        '
        'mskDiferencaMultiBim
        '
        Me.mskDiferencaMultiBim.Location = New System.Drawing.Point(363, 96)
        Me.mskDiferencaMultiBim.Name = "mskDiferencaMultiBim"
        Me.mskDiferencaMultiBim.Size = New System.Drawing.Size(100, 20)
        Me.mskDiferencaMultiBim.TabIndex = 21
        '
        'mskDiferencaMultiUnico
        '
        Me.mskDiferencaMultiUnico.Location = New System.Drawing.Point(363, 127)
        Me.mskDiferencaMultiUnico.Name = "mskDiferencaMultiUnico"
        Me.mskDiferencaMultiUnico.Size = New System.Drawing.Size(100, 20)
        Me.mskDiferencaMultiUnico.TabIndex = 22
        '
        'mskDiferencaCabazes
        '
        Me.mskDiferencaCabazes.Location = New System.Drawing.Point(363, 189)
        Me.mskDiferencaCabazes.Name = "mskDiferencaCabazes"
        Me.mskDiferencaCabazes.Size = New System.Drawing.Size(100, 20)
        Me.mskDiferencaCabazes.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 155)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Cheques:"
        '
        'mskValorRecebCheque
        '
        Me.mskValorRecebCheque.Location = New System.Drawing.Point(123, 158)
        Me.mskValorRecebCheque.Name = "mskValorRecebCheque"
        Me.mskValorRecebCheque.Size = New System.Drawing.Size(100, 20)
        Me.mskValorRecebCheque.TabIndex = 25
        '
        'mskValorConfCheque
        '
        Me.mskValorConfCheque.Location = New System.Drawing.Point(243, 158)
        Me.mskValorConfCheque.Name = "mskValorConfCheque"
        Me.mskValorConfCheque.Size = New System.Drawing.Size(100, 20)
        Me.mskValorConfCheque.TabIndex = 26
        '
        'mskDiferencaCheques
        '
        Me.mskDiferencaCheques.Location = New System.Drawing.Point(363, 158)
        Me.mskDiferencaCheques.Name = "mskDiferencaCheques"
        Me.mskDiferencaCheques.Size = New System.Drawing.Size(100, 20)
        Me.mskDiferencaCheques.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(483, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Estado"
        '
        'lblEstadoAbertura
        '
        Me.lblEstadoAbertura.AutoSize = True
        Me.lblEstadoAbertura.Location = New System.Drawing.Point(483, 31)
        Me.lblEstadoAbertura.Name = "lblEstadoAbertura"
        Me.lblEstadoAbertura.Size = New System.Drawing.Size(45, 13)
        Me.lblEstadoAbertura.TabIndex = 29
        Me.lblEstadoAbertura.Text = "Label18"
        '
        'lblEstadoNumerario
        '
        Me.lblEstadoNumerario.AutoSize = True
        Me.lblEstadoNumerario.Location = New System.Drawing.Point(483, 62)
        Me.lblEstadoNumerario.Name = "lblEstadoNumerario"
        Me.lblEstadoNumerario.Size = New System.Drawing.Size(45, 13)
        Me.lblEstadoNumerario.TabIndex = 30
        Me.lblEstadoNumerario.Text = "Label19"
        '
        'lblEstadoMultiBim
        '
        Me.lblEstadoMultiBim.AutoSize = True
        Me.lblEstadoMultiBim.Location = New System.Drawing.Point(483, 93)
        Me.lblEstadoMultiBim.Name = "lblEstadoMultiBim"
        Me.lblEstadoMultiBim.Size = New System.Drawing.Size(45, 13)
        Me.lblEstadoMultiBim.TabIndex = 31
        Me.lblEstadoMultiBim.Text = "Label20"
        '
        'lblEstadoMultiUnico
        '
        Me.lblEstadoMultiUnico.AutoSize = True
        Me.lblEstadoMultiUnico.Location = New System.Drawing.Point(483, 124)
        Me.lblEstadoMultiUnico.Name = "lblEstadoMultiUnico"
        Me.lblEstadoMultiUnico.Size = New System.Drawing.Size(45, 13)
        Me.lblEstadoMultiUnico.TabIndex = 32
        Me.lblEstadoMultiUnico.Text = "Label21"
        '
        'lblEstadoCheques
        '
        Me.lblEstadoCheques.AutoSize = True
        Me.lblEstadoCheques.Location = New System.Drawing.Point(483, 155)
        Me.lblEstadoCheques.Name = "lblEstadoCheques"
        Me.lblEstadoCheques.Size = New System.Drawing.Size(45, 13)
        Me.lblEstadoCheques.TabIndex = 33
        Me.lblEstadoCheques.Text = "Label22"
        '
        'lblEstadoCabazes
        '
        Me.lblEstadoCabazes.AutoSize = True
        Me.lblEstadoCabazes.Location = New System.Drawing.Point(483, 186)
        Me.lblEstadoCabazes.Name = "lblEstadoCabazes"
        Me.lblEstadoCabazes.Size = New System.Drawing.Size(45, 13)
        Me.lblEstadoCabazes.TabIndex = 34
        Me.lblEstadoCabazes.Text = "Label23"
        '
        'mskSaldoFecho
        '
        Me.mskSaldoFecho.Location = New System.Drawing.Point(162, 158)
        Me.mskSaldoFecho.Name = "mskSaldoFecho"
        Me.mskSaldoFecho.Size = New System.Drawing.Size(100, 20)
        Me.mskSaldoFecho.TabIndex = 25
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(3, 155)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 13)
        Me.Label33.TabIndex = 24
        Me.Label33.Text = "Saldo Fecho"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(3, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(49, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Caixa nº:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 124)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(63, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "Data Fecho"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(3, 31)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(76, 13)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "Data Abertura:"
        '
        'mskDataFecho
        '
        Me.mskDataFecho.Location = New System.Drawing.Point(162, 127)
        Me.mskDataFecho.Name = "mskDataFecho"
        Me.mskDataFecho.Size = New System.Drawing.Size(100, 20)
        Me.mskDataFecho.TabIndex = 12
        '
        'mskSaldoAbertura
        '
        Me.mskSaldoAbertura.Location = New System.Drawing.Point(162, 65)
        Me.mskSaldoAbertura.Name = "mskSaldoAbertura"
        Me.mskSaldoAbertura.Size = New System.Drawing.Size(100, 20)
        Me.mskSaldoAbertura.TabIndex = 10
        '
        'mskDataAbertura
        '
        Me.mskDataAbertura.Location = New System.Drawing.Point(162, 34)
        Me.mskDataAbertura.Name = "mskDataAbertura"
        Me.mskDataAbertura.Size = New System.Drawing.Size(100, 20)
        Me.mskDataAbertura.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 93)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Utilizador Abertura"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 62)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 13)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Saldo Abertura:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDataAbertura, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.mskSaldoAbertura, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.mskDataFecho, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label29, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label31, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label32, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label33, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.mskSaldoFecho, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCaixaNum, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtUtilizadoFecho, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtUtilizadorAbertura, 1, 3)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(7, 21)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(319, 220)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Utilizador Fecho"
        '
        'txtCaixaNum
        '
        Me.txtCaixaNum.Location = New System.Drawing.Point(162, 3)
        Me.txtCaixaNum.Name = "txtCaixaNum"
        Me.txtCaixaNum.Size = New System.Drawing.Size(100, 20)
        Me.txtCaixaNum.TabIndex = 27
        '
        'txtUtilizadoFecho
        '
        Me.txtUtilizadoFecho.Location = New System.Drawing.Point(162, 189)
        Me.txtUtilizadoFecho.Name = "txtUtilizadoFecho"
        Me.txtUtilizadoFecho.Size = New System.Drawing.Size(100, 20)
        Me.txtUtilizadoFecho.TabIndex = 28
        '
        'txtUtilizadorAbertura
        '
        Me.txtUtilizadorAbertura.Location = New System.Drawing.Point(162, 96)
        Me.txtUtilizadorAbertura.Name = "txtUtilizadorAbertura"
        Me.txtUtilizadorAbertura.Size = New System.Drawing.Size(100, 20)
        Me.txtUtilizadorAbertura.TabIndex = 29
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Location = New System.Drawing.Point(1, 297)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(990, 63)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel4.Location = New System.Drawing.Point(1, 431)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(990, 197)
        Me.Panel4.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.6863!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25708!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboModoRecebimento, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboReferencia, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.mskValor, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.numQuantidade, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(btnAdicionar, 4, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(984, 57)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Modo Recebimento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Referência"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(453, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Quantidade"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(621, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Valor"
        '
        'cboModoRecebimento
        '
        Me.cboModoRecebimento.FormattingEnabled = True
        Me.cboModoRecebimento.Items.AddRange(New Object() {"valor abertura", "numerario", "multibanco bim", "multibanco unico", "cheque", "senhas cabazes"})
        Me.cboModoRecebimento.Location = New System.Drawing.Point(3, 31)
        Me.cboModoRecebimento.Name = "cboModoRecebimento"
        Me.cboModoRecebimento.Size = New System.Drawing.Size(187, 21)
        Me.cboModoRecebimento.TabIndex = 8
        '
        'cboReferencia
        '
        Me.cboReferencia.FormattingEnabled = True
        Me.cboReferencia.Location = New System.Drawing.Point(228, 31)
        Me.cboReferencia.Name = "cboReferencia"
        Me.cboReferencia.Size = New System.Drawing.Size(200, 21)
        Me.cboReferencia.TabIndex = 9
        '
        'mskValor
        '
        Me.mskValor.Location = New System.Drawing.Point(621, 31)
        Me.mskValor.Name = "mskValor"
        Me.mskValor.Size = New System.Drawing.Size(188, 20)
        Me.mskValor.TabIndex = 10
        '
        'numQuantidade
        '
        Me.numQuantidade.Location = New System.Drawing.Point(453, 31)
        Me.numQuantidade.Name = "numQuantidade"
        Me.numQuantidade.Size = New System.Drawing.Size(120, 20)
        Me.numQuantidade.TabIndex = 11
        '
        'quadroConferencia
        '
        Me.quadroConferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.quadroConferencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.modoRecebimento, Me.referencia, Me.quantidade, Me.valor})
        Me.quadroConferencia.Location = New System.Drawing.Point(1, 366)
        Me.quadroConferencia.Name = "quadroConferencia"
        Me.quadroConferencia.ReadOnly = True
        Me.quadroConferencia.Size = New System.Drawing.Size(987, 240)
        Me.quadroConferencia.TabIndex = 0
        '
        'modoRecebimento
        '
        Me.modoRecebimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.modoRecebimento.HeaderText = "Modo Recebimento"
        Me.modoRecebimento.Name = "modoRecebimento"
        Me.modoRecebimento.ReadOnly = True
        Me.modoRecebimento.Width = 114
        '
        'referencia
        '
        Me.referencia.HeaderText = "Referência"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        '
        'quantidade
        '
        Me.quantidade.HeaderText = "Quantidade"
        Me.quantidade.Name = "quantidade"
        Me.quantidade.ReadOnly = True
        '
        'valor
        '
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        '
        'btnAdicionar
        '
        btnAdicionar.Location = New System.Drawing.Point(903, 31)
        btnAdicionar.Name = "btnAdicionar"
        btnAdicionar.Size = New System.Drawing.Size(75, 23)
        btnAdicionar.TabIndex = 12
        btnAdicionar.Text = "adicionar"
        btnAdicionar.UseVisualStyleBackColor = True
        AddHandler btnAdicionar.Click, AddressOf Me.btnAdicionar_Click
        '
        'FechoConta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 639)
        Me.Controls.Add(Me.quadroConferencia)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FechoConta"
        Me.Text = "Fecho de Conta"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.numQuantidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quadroConferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents mskValorRecebAbertura As MaskedTextBox
    Friend WithEvents mskValorRecebNumerario As MaskedTextBox
    Friend WithEvents mskValorRecebMultiBim As MaskedTextBox
    Friend WithEvents mskValorRecebMultiUnico As MaskedTextBox
    Friend WithEvents mskValorRecebCabazes As MaskedTextBox
    Friend WithEvents mskValorConfAbertura As MaskedTextBox
    Friend WithEvents mskValorConfNumerario As MaskedTextBox
    Friend WithEvents mskValorConfMultiBim As MaskedTextBox
    Friend WithEvents mskValorConfMultiUnico As MaskedTextBox
    Friend WithEvents mskValorConfCabazes As MaskedTextBox
    Friend WithEvents mskDiferencaAbertura As MaskedTextBox
    Friend WithEvents mskDiferencaNumerario As MaskedTextBox
    Friend WithEvents mskDiferencaMultiBim As MaskedTextBox
    Friend WithEvents mskDiferencaMultiUnico As MaskedTextBox
    Friend WithEvents mskDiferencaCabazes As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents mskValorRecebCheque As MaskedTextBox
    Friend WithEvents mskValorConfCheque As MaskedTextBox
    Friend WithEvents mskDiferencaCheques As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents lblEstadoAbertura As Label
    Friend WithEvents lblEstadoNumerario As Label
    Friend WithEvents lblEstadoMultiBim As Label
    Friend WithEvents lblEstadoMultiUnico As Label
    Friend WithEvents lblEstadoCheques As Label
    Friend WithEvents lblEstadoCabazes As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents mskDataAbertura As MaskedTextBox
    Friend WithEvents mskSaldoAbertura As MaskedTextBox
    Friend WithEvents mskDataFecho As MaskedTextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents mskSaldoFecho As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCaixaNum As TextBox
    Friend WithEvents txtUtilizadoFecho As TextBox
    Friend WithEvents txtUtilizadorAbertura As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboModoRecebimento As ComboBox
    Friend WithEvents cboReferencia As ComboBox
    Friend WithEvents mskValor As MaskedTextBox
    Friend WithEvents numQuantidade As NumericUpDown
    Friend WithEvents quadroConferencia As DataGridView
    Friend WithEvents modoRecebimento As DataGridViewTextBoxColumn
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents quantidade As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs)

    End Sub
End Class
