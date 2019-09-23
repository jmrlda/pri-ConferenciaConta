
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization
Imports Microsoft.Win32

Public Class ConferenciaCaixa


    Dim SQL As New sqlControlo
    Dim SQLPriEmpre As New sqlControloPriEmpre
    Dim DIARIO_CONFERIDO As Boolean = False
    Dim administracao As New ConferenciaAdmin
    Dim reporte As New crystalReporter
    Dim utilitario As New Util
    Dim IDCABECTESOURARIA As String

    Public buscarDiario As Boolean = False

    Public numerario_mov As New Movimento()
    Public pagamentoAutomatico_mov As New Movimento()
    Public cheque_mov As New Movimento()
    Public outros_mov As New Movimento()
    Public saida_mov As New Movimento()
    Dim lista_movimentos As New Movimentos()

    Dim js As JmrJson = New JmrJson()



    ' flag informando se o usuario estado logado ou  nao
    Dim logado As Boolean = False
    Public utilizador_logado As New Utilizador


    'Idenficacao de cada tipo de movimento pelos codigos'
    Dim indiceFechoConta As Integer = 0
    'Dim numerarioMov() As String = {"NUM", "RNUM"}
    Dim numerarioMov(50) As String
    Dim numerarioTotal As Double
    Dim numerarioConferidoTotal As Double
    Dim centimos As Double = 1 / 2
    Dim numerarioReferencia() As String = {"Selecionar", utilitario.soNumero("1000"), utilitario.soNumero("500"), utilitario.soNumero("200"), utilitario.soNumero("100"), utilitario.soNumero("50"), utilitario.soNumero("20"), utilitario.soNumero("10"), utilitario.soNumero("5"), utilitario.soNumero("2"), utilitario.soNumero("1"), utilitario.soNumero(centimos.ToString())}

    Dim multibancoMov(50) As String
    ' Dim multibancoMov() As String = {"RCMR", "MB"}

    Dim multibancoTotal As Double
    Dim multibancoConferidoTotal As Double


    'Dim chequeMov() As String = {"DEP", "RCHQ", "RCHPD"}
    Dim chequeMov(50) As String
    Dim chequeTotal As Double
    Dim chequeConferidoTotal As Double

    'Dim outrosMov() As String = {}
    Dim outrosMov(50) As String

    Dim outrosTotal As Double
    Dim outrosConferidoTotal As Double
    Dim outrosReferencia() As String = {"Selecionar", "5000.00", "2000.00", "200.00", "100.00", "50.00"}


    Dim bancos As List(Of String) '{"Selecionar", "Millenium Bim", "Standard Bank", "Banco Unico", "BCI"}
    Dim bancosCartaoTipo As String() = {"Selecionar", "Mastercard", "MBIM-Electron", "MBIM-visa", "Visa Moz", "Ponto 24", "Visa", "Nao Aplicavel"}

    Dim saidaMov(50) As String


    Dim aberturaTotal, aberturaConferidoTotal, entradaTotal, entradaConferidoTotal, saidaTotal, saidaConferidoTotal As Double

    Dim diarioCaixaCurrente As Integer

    Public ISCONEXAOCONFIGURADA As Boolean = False

    Public autoCompleteClientes As New AutoCompleteStringCollection ' autocomlete
    Public autoCompleteTransacao As New AutoCompleteStringCollection ' autocomlete


    ' tipos de movimentos # MODO HARDCODE #'

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'config_acesso_remoto.ShowDialog(Me)
        criarConfigFolder()
        Dim path As Util = New Util()


        Dim tudo_configurado As Boolean
        tudo_configurado = False

        '   
        '   Verificar se as configuracoes forem definidas antes de prosseguir
        '  

        While (tudo_configurado = False)

            If Not System.IO.File.Exists(js.CONEXAO_PATH) Then

                MessageBox.Show("Conexão não configurada", "Atenção", MessageBoxButtons.OK)
                Conexaobd.ShowDialog(Me)
            End If

            If Not System.IO.File.Exists(js.CLIENTE_PATH) Then

                MessageBox.Show("Cliente não configurada. Por favor Definir os Dados do cliente para validação correcta das licenças.", "Atenção", MessageBoxButtons.OK)
                ClienteForm.ShowDialog(Me)
            End If

            If Not System.IO.File.Exists(js.MOVIMENTO_PATH) Then

                MessageBox.Show("Movimentos não configurado. Por favor Definir os movimentos para a conferência.", "Atenção", MessageBoxButtons.OK)
                ConfigMovimentos.ShowDialog(Me)
            End If

            If System.IO.File.Exists(js.CONEXAO_PATH) And System.IO.File.Exists(js.CLIENTE_PATH) And System.IO.File.Exists(js.MOVIMENTO_PATH) Then
                tudo_configurado = True

            End If

        End While
        carregarConfiguracao()
        restoreCsvToDatabase("C:\Users\jmr-guirruta\Documents\develop\projectos\primavera\bd\lista_artigos.json")
        bancos = administracao.buscarBancos()
        startapp()


    End Sub


    ' funcao principal 
    Public Sub startapp()
        Dim licencaDuracao As Integer = -1
        Dim licencaDuracao_str As String = ""
        Dim licencaUtilizadores As Integer = -1
        Dim licencaSistema As String = ""
        Dim licenca_encode As String = ""
        Dim dataInic, dataFim As String
        Dim superLicenca As String = "UIlM5q4Asz0jp0WmXsBfbGkj43YHKkToIqk8RH6rYHjay0iqevjQzPLWFz47Xnblj2LSVW2nK1AH4CvNW2aorafRu2L7MMACqNGc9Tk2zcdHRSciFYvAMmI7UWr2aLeSobzWr5sMCjJE7P/jJDvvhS5dRjwqhszGuyUH5LJwwQcEDmjiQc1gmZGtTyfV5TeKP9Ve46GvKgdHvM6lg6QE339Tfk5KwpYztrcqwwI/nEH+kjcDLVZuSEuZbXHBNBzV"
        Dim sucesso As Boolean = False
        Dim except_msg As String

        ' Criar tabelas se nao tiver antes na base de dados 
        administracao.criarTblConferenciaCaixa()
        administracao.criarTblLicenca()
        administracao.criarTblConferenciaUtilizador()

        ' Todos utilizadores precisam de licenca para operar inclusive o super usuario
        Dim licenca_decode As String = administracao.Decrypt(superLicenca)

        If (licenca_decode.Length > 0) Then
            Try
                ' Extrair dados da serie da licenca decodificado
                licencaUtilizadores = licenca_decode.Split("_")(0)
                licencaSistema = licenca_decode.Split("_")(1)
                licencaDuracao_str = licenca_decode.Split("_")(2)
                dataInic = Date.Now().ToShortDateString()
                dataFim = Date.Now().AddDays(utilitario.change_duracao_str_int(licencaDuracao_str)).ToShortDateString()

                If administracao.existeLicencasBySerie(superLicenca) = False Then

                    administracao.insertLicenca(superLicenca, licencaUtilizadores, dataInic, dataFim)
                End If

                Dim id_licenca As String = administracao.buscarIdLicencasBySerie(superLicenca)

                ' Depois de registrar o super usuario padrao. Verificar se esta registado e esta devidamente licenciado
                Try
                    If (administracao.isUtilizadorLicenciado("jmr") = False) Then
                        administracao.insertConferenciaUtilizador("jmr", "#JMR2013!", administracao.super, id_licenca)
                        sucesso = True
                    End If
                Catch ex As Exception
                    except_msg = ex.ToString()
                    sucesso = False
                End Try


                utilizador_logado.setLogado(False)
                Entrar.ShowDialog(Me)
                If (Me.getLogado().getLogado = False) Then

                    MessageBox.Show("É preciso logar para usar o modulo Conferência de Caixa", "Atenção", MessageBoxButtons.OK)
                    Me.Close()
                End If

            Catch ex As Exception
                MessageBox.Show("Ocorreu um erro ao iniciar a aplicação", "Atenção", MessageBoxButtons.OK)
                Me.Close()
            End Try

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Tabela com todos diarios de um caixa selecionado
        If (utilizador_logado.getLogado() = True) Then
            If (Me.cboContaPos.SelectedIndex > 0) Then
                caixaDiaria.ShowDialog(Me)
            Else
                MessageBox.Show("Selecione a Conta Caixa", "Atencao", MessageBoxButtons.OK)
            End If
        Else
            If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Entrar.ShowDialog(Me)
            End If
        End If


    End Sub



    '
    '   Limpar dados de entrada nos formularios
    '


    Private Function limpar_campo_fechoconta() As Integer

        'Me.txtTransacaoNumero.Text = ""
        cboCartaoTipo.Text = ""
        'Me.cboModoRecebido.SelectedIndex = 0
        Me.cboReferenciaModoReceb.Text = ""
        Me.txtQuantidade.Text = ""
        Me.mskValorRecebido.Text = ""
        Me.dtTransacao.Value = Date.Now()

        Return 0

    End Function

    Private Sub preencher_tipo_movimento()
        Dim qrTipoMov As String = "select Descricao from DocumentosBancos where MovUtilizadoEmPOS='true'"

        Dim tabelaMov As New DataTable
        'tabelaMov = SQL.buscarDado(qrTipoMov)
        'If (tabelaMov.Rows.Count <> 0) Then
        '    'For i As Integer = 0 To tabelaMov.Rows.Count - 1
        '    '    If (cboModoRecebido.Items.IndexOf(tabelaMov.Rows(i)("Descricao")) = -1) Then
        '    '        'cboModoRecebido.Items.Add(tabelaMov.Rows(i)("Descricao"))
        '    '    End If
        '    'Next
        'End If
        getDescricaoMovimento()
    End Sub

    Private Sub preencher_movimento_referencia(movimento)
        'Me.lblFechoContaReferencia.Text = "Referência"
        'Me.lblFechoContaQuantidade.Text = "Quantidade"

        Me.cboReferenciaModoReceb.DataSource = {"selecionar referencia"}
        Me.cboReferenciaModoReceb.SelectedIndex = 0
        'If (movimento = "Rec. em Numerário" Or movimento = "Rec. Numerario (NAO USAR)") Then
        If (check_numerario_mov(movimento)) Then

            Me.lblFechoContaQuantidade.Text = "Quantidade"
            Me.lblFechoContaCartaoChequeDesc.Text = ""
            Me.lblFechoContaReferencia.Text = "Referência Numerário"

            Me.cboReferenciaModoReceb.DataSource = numerarioReferencia
            Me.cboCartaoTipo.DataSource = {}
            'destrancarLinhaFechoConta_mov_local()
            destrancarNumerario_mov()
            trancarCartaoChequeInput()


            'ElseIf (movimento = "Rec. Multi Rede" Or movimento = "Rec. por Multibanco") Then
        ElseIf (check_multibanco_mov(movimento)) Then
            Me.lblFechoContaQuantidade.Text = "Transação Número"
            Me.lblFechoContaCartaoChequeDesc.Text = "Cartão Tipo / Cliente"
            Me.lblFechoContaReferencia.Text = "Referência Banco"

            'Me.txtQuantidade.Enabled = False
            Me.cboReferenciaModoReceb.DataSource = bancos
            'Me.cboReferenciaModoReceb
            Me.cboCartaoTipo.DataSource = bancosCartaoTipo
            If (movimento = "Recibo Transf. Bancaria") Then
                Me.cboCartaoTipo.DataSource = {}

            End If
            Me.lblFechoContaReferencia.Text = "POS Banco"
            'destrancarCartaoChequeInput()
            destrancarLinhaFechoConta_mov_local()


            'ElseIf (movimento = "Rec. por Cheque (PD)" Or movimento = "Rec. por Cheque") Then
        ElseIf (check_cheque_mov(movimento)) Then
            Me.lblFechoContaReferencia.Text = "Referência Banco"
            Me.lblFechoContaQuantidade.Text = "Cheque Número"
            Me.lblFechoContaCartaoChequeDesc.Text = "Cheque Descricão / Cliente"
            Me.cboCartaoTipo.Enabled = True

            Me.txtQuantidade.Enabled = True

            Me.cboReferenciaModoReceb.DataSource = bancos


            'Me.cboCartaoTipo.Enabled = False
            Me.cboCartaoTipo.DataSource = {}
            'destrancarCartaoChequeInput()
            destrancarLinhaFechoConta_mov_local()

        ElseIf (check_entrada_caixa_mov(movimento) Or check_saida_caixa_mov(movimento) Or check_abertura_caixa_mov(movimento) Or check_pagamento_caixa_mov(movimento)) Then
            Me.lblFechoContaReferencia.Text = ""
            Me.lblFechoContaQuantidade.Text = ""
            Me.lblFechoContaCartaoChequeDesc.Text = ""
            trancarLinhaFechoConta_mov_local()
            If (check_saida_caixa_mov(movimento) Or check_pagamento_caixa_mov(movimento)) Then
                Me.cboReferenciaModoReceb.Enabled = True
                Me.lblFechoContaReferencia.Text = "Descrição "
                Me.cboReferenciaModoReceb.Text = ""


            End If


        End If

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnConfereAdicionar.Click
        Dim rec_inicial As Integer = 0
        Dim rec_final As Integer = 0
        Dim rec_serie As String = ""

        cboCartaoTipo.AutoCompleteMode = AutoCompleteMode.Suggest
        cboCartaoTipo.AutoCompleteSource = AutoCompleteSource.CustomSource

        txtQuantidade.AutoCompleteMode = AutoCompleteMode.Suggest
        txtQuantidade.AutoCompleteSource = AutoCompleteSource.CustomSource


        autoCompleteClientes.Add(Me.cboCartaoTipo.Text)
        autoCompleteTransacao.Add(Me.txtQuantidade.Text)
        cboCartaoTipo.AutoCompleteCustomSource = autoCompleteClientes
        txtQuantidade.AutoCompleteCustomSource = autoCompleteTransacao


        If (cboContaPos.SelectedIndex > 0) And ((Len(txtCaixaNum.Text) > 0 And IsNumeric(txtCaixaNum.Text)) Or cboContaPos.SelectedItem = "CXMT") Then
            If (DIARIO_CONFERIDO = True) Then
                If (utilizador_logado.getNivel() <> "Tesoureiro") Then

                    If MessageBox.Show("Tem a certeza que deseja remover os dados da conferência?", "Atenção - Perigo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Try
                            Dim rv As Boolean
                            If Me.cboContaPos.SelectedItem = "CXMT" Then
                                rec_inicial = Me.txtDocInicio.Text
                                rec_final = Me.txtDocFim.Text
                                rec_serie = Me.cboFacturaSerie.Text
                                rv = administracao.removeLinhasCaixa(CInt(Me.txtDocInicio.Text & "" & Me.txtDocFim.Text), Me.cboContaPos.SelectedItem, dtInicio.Value.ToShortDateString(), rec_inicial, rec_final, rec_serie)
                            Else
                                rv = administracao.removeLinhasCaixa(Me.lblDiarioCaixa.Text, Me.cboContaPos.SelectedItem, "", rec_inicial, rec_final, rec_serie)


                            End If
                            If (rv = True) Then
                                MessageBox.Show("Linhas de Conferência de Caixa  removidos com sucesso", "Informação", MessageBoxButtons.OK)
                                btnPrevisualizarReporte.Enabled = False

                                limpar_campos()
                                limpar_campo_fechoconta()
                                trancarCartaoChequeInput()


                                trancarLinhaFechoConta()
                                trancarLinhaFechoConta_mov_local()
                                Me.btnConfereAdicionar.Text = "Adicionar"

                                If Me.cboContaPos.SelectedItem = "CXMT" Then
                                    buscarCaixaFactura()
                                Else
                                    buscarCaixa()


                                End If

                            Else
                                MessageBox.Show("Falha na remoção das linhas de Conferência de Caixa. Se persistir entre em contacto com o administrador", "Informação", MessageBoxButtons.OK)

                            End If
                        Catch ex As Exception
                            MessageBox.Show("Falha na remoção das linhas de Conferência de Caixa. Se persistir entre em contacto com o administrador: " & ex.Message(), "Informação", MessageBoxButtons.OK)

                        End Try

                    End If
                Else
                    MessageBox.Show("Somente o administrador pode remover o Caixa!", "Informação", MessageBoxButtons.OK)

                End If
            Else

                If Not (IsNumeric(Me.mskValorRecebido.Text)) Then

                    '    If Me.mskValorRecebido.Text.IndexOf(".") >= 0 Then
                    '        lblMsgValor.Visible = True
                    '    Else

                    '        lblMsgValor.Visible = False

                    '    End If
                    '    Return
                    'Else
                    MessageBox.Show("Preencha o campo 'VALOR' com dados numerico ou Configure  Formatação de Moedas no Windows", "Atenção", MessageBoxButtons.OK)
                    Return
                End If
                '      Dim conta As DataGrid
                Dim checkDiferenca As Double

                Dim linha_valor_confirmado As Boolean = False
                'If (Me.cboModoRecebido.SelectedIndex <> 0 And Me.cboReferenciaModoReceb.SelectedIndex <> 0 And Me.txtQuantidade.Text.Length > 0 And Me.mskValorRecebido.Text.Length > 0) Then
                If (is_abertura_caixa_mov() Or is_cheque_mov() Or is_entrada_caixa_mov() Or is_multibanco_mov() Or is_numerario_mov() Or is_saida_caixa_mov() Or is_pagamento_caixa_mov()) Then

                    'If (is_multibanco_mov()) Then
                    '    If (Me.cboCartaoTipo.SelectedIndex <> 0) Then
                    '        tabelaConferenciaCaixa.Rows.Insert(Me.indiceFechoConta, New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, Me.cboCartaoTipo.Text, Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
                    '        btnFecharConta.Enabled = True
                    '    End If
                    'Else
                    '    tabelaConferenciaCaixa.Rows.Insert(Me.indiceFechoConta, New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
                    '    btnFecharConta.Enabled = True
                    'End If

                    'Somar total conferido por tipo de movimento
                    If (is_numerario_mov()) Then

                        If (cboModoRecebido.SelectedIndex > 0 And cboReferenciaModoReceb.SelectedIndex > 0 And txtQuantidade.Text.Length > 0) Then
                            Dim idx As Integer = is_lancamento_redudante()
                            If (idx >= 0) Then
                                MsgBox("Nota ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                            Else
                                Me.numerarioConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                                Me.mskValConfNumerario.Text = Me.numerarioConferidoTotal
                                checkDiferenca = CDbl(Me.mskValConfNumerario.Text) - CDbl(Me.mskValRecNumerario.Text)
                                Me.mskDiferencaNumerario.Text = checkDiferenca
                                'If (checkDiferenca < 0) Then
                                '    Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                                'Else
                                '    Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                                'End If

                                If (checkDiferenca < 0) Then
                                    Me.lblEstdNumerario.ForeColor = Color.Red
                                    Me.lblEstdNumerario.Text = "Valor a Menos"
                                ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                    Me.lblEstdNumerario.ForeColor = Color.Black
                                    Me.lblEstdNumerario.Text = "Correcto"
                                Else
                                    Me.lblEstdNumerario.ForeColor = Color.Green
                                    Me.lblEstdNumerario.Text = "Valor a Mais"

                                End If
                                tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", "", "", Me.txtQuantidade.Text, utilitario.soNumero(mskValorRecebido.Text), dtTransacao.Value.ToShortDateString})
                                btnFecharConta.Enabled = True
                                linha_valor_confirmado = True

                            End If
                        Else
                            linha_valor_confirmado = False
                            'MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If

                    ElseIf (is_cheque_mov()) Then
                        If (cboModoRecebido.SelectedIndex > 0 And cboReferenciaModoReceb.SelectedIndex > 0 And txtQuantidade.Text.Length > 0 And cboCartaoTipo.Text.Length > 0 And mskValorRecebido.Text.Length > 0) Then
                            ' Dim idx As Integer = is_lancamento_cheque_redundante()

                            Me.chequeConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                            Me.mskValConfCheques.Text = Me.chequeConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfCheques.Text) - CDbl(Me.mskValRecCheque.Text)
                            Me.mskDiferencaCheque.Text = checkDiferenca
                            'If (checkDiferenca < 0) Then
                            '    Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            'Else
                            '    Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            'End If

                            If (checkDiferenca < 0) Then
                                Me.lblEstdCheques.ForeColor = Color.Red
                                Me.lblEstdCheques.Text = "Valor a Menos"

                            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                Me.lblEstdCheques.ForeColor = Color.Black
                                Me.lblEstdCheques.Text = "Correcto"

                            Else
                                Me.lblEstdCheques.ForeColor = Color.Green
                                Me.lblEstdCheques.Text = "Valor a Mais"

                            End If
                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, cboCartaoTipo.Text, Me.txtQuantidade.Text, "", 1, utilitario.soNumero(mskValorRecebido.Text), Me.dtTransacao.Value.ToShortDateString()})
                            linha_valor_confirmado = True
                            btnFecharConta.Enabled = True
                        Else
                            linha_valor_confirmado = False
                            'MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If
                    ElseIf (is_multibanco_mov()) Then
                        If (cboModoRecebido.SelectedIndex > 0 And cboReferenciaModoReceb.SelectedIndex > 0 And txtQuantidade.Text.Length > 0 And cboCartaoTipo.SelectedItem <> "Selecionar" And mskValorRecebido.Text.Length > 0) Then
                            ' Dim idx As Integer = is_lancamento_multibanco_redundante()

                            Me.multibancoConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                            Me.mskValConfMultiBim.Text = Me.multibancoConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfMultiBim.Text) - CDbl(Me.mskValRecMultiBim.Text)
                            Me.mskDiferencaMultiBim.Text = checkDiferenca
                            'If (checkDiferenca < 0) Then
                            '    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            'Else
                            '    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            'End If

                            If (checkDiferenca < 0) Then
                                Me.lblEstdPagamentoAutomatico.ForeColor = Color.Red
                                Me.lblEstdPagamentoAutomatico.Text = "Valor a Menos"

                            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                Me.lblEstdPagamentoAutomatico.ForeColor = Color.Black
                                Me.lblEstdPagamentoAutomatico.Text = "Correcto"

                            Else
                                Me.lblEstdPagamentoAutomatico.ForeColor = Color.Green
                                Me.lblEstdPagamentoAutomatico.Text = "Valor a Mais"


                            End If

                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, Me.cboCartaoTipo.Text, Me.txtQuantidade.Text, "", 1, utilitario.soNumero(mskValorRecebido.Text), Me.dtTransacao.Value.ToShortDateString()})

                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True
                        Else
                            linha_valor_confirmado = False
                            'MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If

                    ElseIf (is_entrada_caixa_mov()) Then
                        If (cboModoRecebido.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0) Then
                            Dim idx As Integer = is_lancamento_entrada_redundante()
                            If (idx >= 0) Then
                                MsgBox("Entrada Ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                            Else
                                Me.entradaConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                                Me.mskValConfEntradaCaixa.Text = Me.entradaConferidoTotal

                                checkDiferenca = CDbl(Me.mskValConfEntradaCaixa.Text) - CDbl(Me.mskValRecEntradaCaixa.Text)
                                Me.mskDiferencaEntradaCaixa.Text = checkDiferenca
                                'If (checkDiferenca < 0) Then
                                '    Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                                'Else
                                '    Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                                'End If

                                If (checkDiferenca < 0) Then
                                    Me.lblEstdEntradaCaixa.ForeColor = Color.Red
                                    Me.lblEstdEntradaCaixa.Text = "Valor a Menos"
                                ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                    Me.lblEstdEntradaCaixa.ForeColor = Color.Black
                                    Me.lblEstdEntradaCaixa.Text = "Correcto"
                                Else
                                    Me.lblEstdEntradaCaixa.ForeColor = Color.Green
                                    Me.lblEstdEntradaCaixa.Text = "Valor a Mais"

                                End If
                                tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", "", "", utilitario.soNumero(mskValorRecebido.Text), dtTransacao.Value.ToShortDateString})
                                btnFecharConta.Enabled = True
                                linha_valor_confirmado = True


                            End If
                        Else
                            linha_valor_confirmado = False
                            'MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If
                    ElseIf (is_saida_caixa_mov()) Then
                        If (cboModoRecebido.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0 And cboReferenciaModoReceb.Text.Length > 0) Then
                            'Dim idx As Integer = is_lancamento_saida_redundante()
                            'If (idx >= 0) Then
                            '    MsgBox("Saida de Caixa Ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                            'Else
                            If (CDbl(Me.mskValorRecebido.Text) < 0) Then
                                Me.saidaConferidoTotal -= CDbl(Me.mskValorRecebido.Text)
                            Else
                                Me.saidaConferidoTotal += CDbl(Me.mskValorRecebido.Text)

                            End If
                            Me.mskValConfSaidaCaixa.Text = Me.saidaConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfSaidaCaixa.Text) + CDbl(Me.mskValRecSaidaCaixa.Text)
                            Me.mskDiferencaSaidaCaixa.Text = checkDiferenca
                            'If (checkDiferenca < 0) Then
                            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            'Else
                            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            'End If

                            If (checkDiferenca < 0) Then
                                Me.lblEstdSaidaCaixa.ForeColor = Color.Red
                                Me.lblEstdSaidaCaixa.Text = "Valor a Menos"
                            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                Me.lblEstdSaidaCaixa.ForeColor = Color.Black
                                Me.lblEstdSaidaCaixa.Text = "Correcto"
                            Else
                                Me.lblEstdSaidaCaixa.ForeColor = Color.Green
                                Me.lblEstdSaidaCaixa.Text = "Valor a Mais"

                            End If
                            Dim valor As Double = Me.mskValorRecebido.Text

                            'If valor > 0 Then
                            '    valor *= -1
                            'End If

                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", cboReferenciaModoReceb.Text, "", utilitario.soNumero(valor), dtTransacao.Value.ToShortDateString})
                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True
                        Else
                            linha_valor_confirmado = False
                            'MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If

                        ' Verificar se o movimeto eh pagamento numerario 
                    ElseIf (is_pagamento_caixa_mov()) Then
                        If (cboModoRecebido.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0 And cboReferenciaModoReceb.Text.Length > 0) Then
                            'Dim idx As Integer = is_lancamento_saida_redundante()
                            'If (idx >= 0) Then
                            '    MsgBox("Saida de Caixa Ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                            'Else
                            If (CDbl(Me.mskValorRecebido.Text) < 0) Then
                                Me.outrosConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                            Else
                                Me.outrosConferidoTotal -= CDbl(Me.mskValorRecebido.Text)

                            End If

                            If (Me.outrosConferidoTotal > 0) Then
                                Me.mskValConfSenhas.Text = Me.outrosConferidoTotal * -1
                            Else
                                Me.mskValConfSenhas.Text = Me.outrosConferidoTotal

                            End If
                            checkDiferenca = CDbl(Me.mskValRecSenhasCabazes.Text) + CDbl(Me.mskValConfSenhas.Text)
                            Me.mskDiferencaSenhasCabazes.Text = checkDiferenca
                            'If (checkDiferenca < 0) Then
                            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            'Else
                            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            'End If

                            If (checkDiferenca < 0) Then
                                Me.lblEstdSenhas.ForeColor = Color.Red
                                Me.lblEstdSenhas.Text = "Valor a Menos"
                            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                Me.lblEstdSenhas.ForeColor = Color.Black
                                Me.lblEstdSenhas.Text = "Correcto"
                            Else
                                Me.lblEstdSenhas.ForeColor = Color.Green
                                Me.lblEstdSenhas.Text = "Valor a Mais"

                            End If
                            Dim valor As Double = Me.mskValorRecebido.Text

                            If valor < 0 Then
                                valor *= -1
                            End If

                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", cboReferenciaModoReceb.Text, "", utilitario.soNumero(valor), dtTransacao.Value.ToShortDateString})
                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True

                        Else
                            linha_valor_confirmado = False
                            'MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If

                        ' Verificar se o movimento eh abertura
                    ElseIf (is_abertura_caixa_mov()) Then
                        If (cboModoRecebido.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0) Then
                            Dim idx As Integer = is_lancamento_abertura_redundante()
                            If (idx >= 0) Then
                                MsgBox("Abertura de Caixa Ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                            Else
                                Me.aberturaConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                                Me.mskValConfAbertura.Text = Me.aberturaConferidoTotal
                                checkDiferenca = CDbl(Me.mskValConfAbertura.Text) - CDbl(Me.mskValRecAbertura.Text)
                                Me.mskDiferencaAbertura.Text = checkDiferenca
                                'If (checkDiferenca < 0) Then
                                '    Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                                'Else
                                '    Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                                'End If

                                If (checkDiferenca < 0) Then
                                    Me.lblEstdSaldoAbert.ForeColor = Color.Red
                                    Me.lblEstdSaldoAbert.Text = "Valor a Menos"
                                ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                                    Me.lblEstdSaldoAbert.ForeColor = Color.Black
                                    Me.lblEstdSaldoAbert.Text = "Correcto"
                                Else
                                    Me.lblEstdSaldoAbert.ForeColor = Color.Green
                                    Me.lblEstdSaldoAbert.Text = "Valor a Mais"

                                End If
                                tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", "", "", utilitario.soNumero(Me.mskValorRecebido.Text), dtTransacao.Value.ToShortDateString})
                                btnFecharConta.Enabled = True
                                linha_valor_confirmado = True
                                limpar_campo_fechoconta()


                            End If

                        Else
                            linha_valor_confirmado = False
                            MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)

                        End If


                    End If

                    If (linha_valor_confirmado) Then

                        limpar_campo_fechoconta()
                        'Me.indiceFechoConta += 1
                    Else
                        MessageBox.Show("Preencher os campos em falta", "Atenção", MessageBoxButtons.OK)
                    End If


                End If
                calcularTotalConferido_diferenca()
                Dim pos As Integer = Me.tabelaConferenciaCaixa.Rows.Count - 2

                Me.tabelaConferenciaCaixa.Rows(pos).Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight


            End If
        Else
            MessageBox.Show("Selecione O caixa  e/ou o Diario Caixa", "Atenção", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub cboModoRecebido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModoRecebido.SelectedIndexChanged
        limpar_campo_fechoconta()
        preencher_movimento_referencia(Me.cboModoRecebido.SelectedItem)

    End Sub

    Private Sub cboReferenciaModoReceb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReferenciaModoReceb.SelectedIndexChanged
        If (IsNumeric(Me.cboReferenciaModoReceb.Text)) Then
            Dim refer As Double
            Try

                If (is_numerario_mov() And Me.txtQuantidade.Text <> "" And IsNumeric(Me.txtQuantidade.Text)) Then
                    refer = Me.cboReferenciaModoReceb.SelectedItem
                    Me.mskValorRecebido.Text = refer * CInt(Me.txtQuantidade.Text)
                End If
            Catch ex As Exception
                MsgBox("Ocorreu um erro de calculo " + ex.Message())
            End Try
        End If
    End Sub

    Private Sub txtQuantidade_TextChanged(sender As Object, e As EventArgs) Handles txtQuantidade.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtQuantidade.Text = digitsOnly.Replace(txtQuantidade.Text, "")
        If (txtCaixaNum.Text.Length <= 0 And Me.cboContaPos.SelectedItem <> "CXMT") Then
            Return
        End If
        Dim refer As Double
        Try

            'If (is_numerario_mov() And IsNumeric(Me.cboReferenciaModoReceb.Text)) Then
            If (is_numerario_mov()) Then
                refer = CDbl(Me.cboReferenciaModoReceb.SelectedItem.ToString())
                Me.mskValorRecebido.Text = refer * CInt(Me.txtQuantidade.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function is_numerario_mov() As Boolean
        Dim rv As Boolean = False

        'If (Me.cboModoRecebido.SelectedItem = "Rec. em Numerário" Or Me.cboModoRecebido.SelectedItem = "Rec. Numerario (NAO USAR)") Then
        If (numerario_mov.descricao.Contains(Me.cboModoRecebido.SelectedItem)) Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    Private Function check_numerario_mov(query) As Boolean
        Dim rv As Boolean = False

        ' If (query = "Rec. em Numerário" Or query = "Rec. Numerario (NAO USAR)") Then
        If (numerario_mov.descricao.Contains(query)) Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_cheque_mov() As Boolean
        Dim rv As Boolean = False

        ' If (Me.cboModoRecebido.SelectedItem = "Rec. por Cheque" Or Me.cboModoRecebido.SelectedItem = "Rec. por Cheque (PD)") Then
        If (cheque_mov.descricao.Contains(Me.cboModoRecebido.SelectedItem)) Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    Private Function check_cheque_mov(query) As Boolean
        Dim rv As Boolean = False

        If (cheque_mov.descricao.Contains(query)) Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_multibanco_mov() As Boolean
        Dim rv As Boolean = False

        If (pagamentoAutomatico_mov.descricao.Contains(Me.cboModoRecebido.SelectedItem)) Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_multibanco_mov(query) As Boolean
        Dim rv As Boolean = False

        If (pagamentoAutomatico_mov.descricao.Contains(query)) Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    Private Function is_entrada_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Entrada de Caixa") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_entrada_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Entrada de Caixa") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_saida_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Saida de Caixa") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_saida_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Saida de Caixa") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_pagamento_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Pagamento em Numerário") Or (Me.cboModoRecebido.SelectedItem = "Venda") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_pagamento_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Pagamento em Numerário") Or (Me.cboModoRecebido.SelectedItem = "Venda") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_abertura_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Abertura de Caixa") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_abertura_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Abertura de Caixa") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    'Private Function is_pagamento_numerario_mov() As Boolean
    '    Dim rv As Boolean = False

    '    If (Me.cboModoRecebido.SelectedItem = "Abertura de Caixa") Then
    '        rv = True
    '    Else
    '        rv = False
    '    End If

    '    Return rv

    'End Function

    'Private Function check_pagamento_numerario_mov(query) As Boolean
    '    Dim rv As Boolean = False

    '    If (query = "Abertura de Caixa") Then
    '        rv = True
    '    Else
    '        rv = False
    '    End If

    '    Return rv

    'End Function
    Private Sub buscarCaixaFactura()


        Dim idCaixa As String
        Dim movimento As String
        Dim rv As Integer
        Dim diario As String = txtCaixaNum.Text
        Dim tabela, tblLinhaTesourariaBd, tblPrimEmpre, tabelaEntradaSaida, cabecTesouraria, tabelaLinhaTesouraria As New DataTable


        Dim contaPos As String
        contaPos = Me.cboContaPos.SelectedItem.ToString()
        limpar_campos()
        movimento = ""
        idCaixa = ""

        destrancarLinhaFechoConta()
        If SQL.temConexao() = True And SQLPriEmpre.temConexao() = True Then



            Dim qrCabecTes As String = "select * from cabectesouraria where  IDDiarioCaixa = '" + idCaixa + "'"
            Dim sqlLinhaTesouraria As String = "select *  from TDU_ConferenciaCaixa where CDU_rec_num_inicial = '" & CInt(Me.txtDocInicio.Text) & "' and  CDU_rec_num_final = '" & CInt(Me.txtDocFim.Text) & "' and  CDU_rec_serie = '" & Me.cboFacturaSerie.Text & "' and CDU_Conta=  '" + cboContaPos.SelectedItem + "' and CDU_data_fecho = '" + dtInicio.Value.ToShortDateString() + "'"


            Dim qrLinhaTes As String
            Dim tipo_movimento As String
            Dim tipoMov As String = ""

            qrLinhaTes = "select *  from Historico where DataDoc = '" & reverter_str(dtInicio.Value.ToShortDateString()) & "'  and TipoDoc = 'RE'  and Moeda='MT' and serie='" & Me.cboFacturaSerie.Text & "' and NumDocint>= '" & CInt(Me.txtDocInicio.Text) & "' and NumDocInt <='" & CInt(Me.txtDocFim.Text) & "'"

            tabelaLinhaTesouraria = SQL.buscarDado(qrLinhaTes)
            Dim listaMov As Movimentos = New Movimentos
            listaMov = js.getListaMovimento()
            tipoMov = "ValorTotal"
            If (tabelaLinhaTesouraria.Rows.Count <> 0) Then
                For j As Integer = 0 To tabelaLinhaTesouraria.Rows.Count - 1
                    IDCABECTESOURARIA = tabelaLinhaTesouraria.Rows(0)("IdDoc").ToString()
                    If Not IsDBNull(tabelaLinhaTesouraria.Rows(0)("ModoPag")) Then

                        tipo_movimento = tabelaLinhaTesouraria.Rows(j)("ModoPag").ToString().Trim()
                    Else
                        tipo_movimento = ""
                    End If

                    ' consultando numerario
                    rv = numerarioMov.ToList.FindIndex(Function(x As String) x = tipo_movimento)
                    If (rv >= 0) Then

                        numerarioTotal += (tabelaLinhaTesouraria.Rows(j)(tipoMov))
                    End If

                    ' consultando multibanco
                    rv = multibancoMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                    If (rv >= 0) Then
                        multibancoTotal += tabelaLinhaTesouraria.Rows(j)(tipoMov)
                    End If

                    ' consultando cheque
                    rv = chequeMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                    If (rv >= 0) Then
                        chequeTotal += tabelaLinhaTesouraria.Rows(j)(tipoMov)
                    End If



                Next

                chequeTotal = chequeTotal * -1
                multibancoTotal = multibancoTotal * -1
                If (numerarioTotal < 0) Then
                    numerarioTotal = numerarioTotal * -1
                End If



                Me.mskValRecNumerario.Text = numerarioTotal - outrosTotal
                    Me.mskValRecCheque.Text = chequeTotal
                    Me.mskValRecMultiBim.Text = multibancoTotal
                    If outrosTotal < 0 Then

                        outrosTotal = outrosTotal * -1
                    End If
                    Me.mskValRecSenhasCabazes.Text = outrosTotal
                    Me.mskValRecEntradaCaixa.Text = entradaTotal

                    If saidaTotal > 0 Then
                        saidaTotal = saidaTotal * -1
                    End If
                    Me.mskValRecSaidaCaixa.Text = saidaTotal
                    mskValRecSaidaCaixa.ForeColor = Color.Red

                    carregar_valor()

                    numerarioTotal = 0
                    chequeTotal = 0
                    multibancoTotal = 0
                    outrosTotal = 0
                    entradaTotal = 0
                    saidaTotal = 0
                End If
                tblLinhaTesourariaBd = SQL.buscarDado(sqlLinhaTesouraria)

            If (tblLinhaTesourariaBd.Rows.Count <> 0) Then
                multibancoConferidoTotal = 0
                chequeConferidoTotal = 0
                numerarioConferidoTotal = 0
                saidaConferidoTotal = 0
                entradaConferidoTotal = 0
                aberturaConferidoTotal = 0
                btnPrevisualizarReporte.Enabled = True
                DIARIO_CONFERIDO = True
                For i As Integer = 0 To tblLinhaTesourariaBd.Rows.Count - 1
                    movimento = tblLinhaTesourariaBd.Rows(i)("CDU_modoMovimento").ToString()
                    Me.txtUtilizadorConferencia.Text = tblLinhaTesourariaBd.Rows(i)("CDU_utilizadorTesoureiro").ToString()

                    If (check_multibanco_mov(movimento)) Then

                        Dim tipo_cartao As String = tblLinhaTesourariaBd.Rows(i)("CDU_cartaoTipo").ToString()
                        Dim transacao As String = tblLinhaTesourariaBd.Rows(i)("CDU_transacaoNumero").ToString()
                        Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                        Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                        Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()

                        tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, tipo_cartao, transacao, "", 1, valor, data})
                        preencherCabecalho(movimento, valor)

                    ElseIf (check_cheque_mov(movimento)) Then

                        Dim descricao As String = tblLinhaTesourariaBd.Rows(i)("CDU_chequeDescricao").ToString()
                        Dim chequeNum As String = tblLinhaTesourariaBd.Rows(i)("CDU_chequeNumero").ToString()
                        Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                        Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                        Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()

                        tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, descricao, chequeNum, "", 1, valor, data})
                        preencherCabecalho(movimento, valor)

                    ElseIf (check_numerario_mov(movimento)) Then

                        Dim quantidade As String = tblLinhaTesourariaBd.Rows(i)("CDU_quantidade").ToString()
                        Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                        Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                        Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()

                        tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", "", quantidade, valor, data})
                        preencherCabecalho(movimento, valor)


                    ElseIf (check_entrada_caixa_mov(movimento) Or check_saida_caixa_mov(movimento) Or check_abertura_caixa_mov(movimento) Or check_pagamento_caixa_mov(movimento)) Then

                        Dim quantidade As String = tblLinhaTesourariaBd.Rows(i)("CDU_quantidade").ToString()
                        Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                        Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                        Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()


                        If (check_saida_caixa_mov(movimento)) Or (check_pagamento_caixa_mov(movimento)) Then
                            Dim saidaDesc As String = tblLinhaTesourariaBd.Rows(i)("CDU_saidaDescricao").ToString()
                            tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", saidaDesc, 1, valor, data})
                            preencherCabecalho(movimento, valor)

                        Else
                            tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", "", 1, valor, data})


                        End If


                        If (check_entrada_caixa_mov(movimento)) Then
                            preencherCabecalho(movimento, valor)
                        ElseIf (check_abertura_caixa_mov(movimento)) Then
                            preencherCabecalho(movimento, valor)
                        End If

                    End If

                    Try
                        Me.tabelaConferenciaCaixa.Rows(i).Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Catch ex As Exception
                        Console.WriteLine(ex)
                    End Try

                Next

                bloquearEdicao()
                Me.btnConfereAdicionar.Text = "Remover"
                Me.btnConfereAdicionar.Enabled = True

                If utilizador_logado.getNivel() <> "Tesoureiro" Then

                    chkEditar.Enabled = True
                    chkEditar.Checked = False
                End If
            Else
                DIARIO_CONFERIDO = False
                btnPrevisualizarReporte.Enabled = False
                Me.btnConfereAdicionar.Text = "Adicionar"
                Me.txtUtilizadorConferencia.Text = Me.getLogado().getNome()
                If utilizador_logado.getNivel() <> "Tesoureiro" Then

                    chkEditar.Enabled = False
                    chkEditar.Checked = False
                End If
                desbloquearEdicao()
            End If


            calcularTotalConferido_diferenca()

            'For i As Integer = 0 To tabela.Rows.Count - 1
            ''Dim DataType() As String = myTableData.Rows(i).Item(1)
            'Me.txtCaixaNum.Text = tabela.Rows(i)("diario")
            'Next
            'Else

            '    MsgBox("Resultado não encontrado para o Diario numero " + diario.ToString())
            '    DIARIO_CONFERIDO = False

            '    limpar_campos()
            '    trancarLinhaFechoConta()

        End If
        'End If
        'Else
        '    'MsgBox("invalido")
        '    limpar_campos()
        '    trancarLinhaFechoConta()
        'End If



        calcularTotalRecebido()



    End Sub



    Private Sub buscarCaixa()


        Dim idCaixa As String
        Dim idLinhaTesouraria, movimento As String
        Dim rv As Integer
        Dim diario As String = txtCaixaNum.Text
        Dim diarioCaixa As String
        Dim tabela, tblLinhaTesourariaBd, tblPrimEmpre, tabelaEntradaSaida, cabecTesouraria, tabelaLinhaTesouraria As New DataTable


        Dim contaPos As String
        contaPos = Me.cboContaPos.SelectedItem.ToString()
        limpar_campos()
        movimento = ""
        idCaixa = ""

        If txtCaixaNum.TextLength <> 0 And IsNumeric(txtCaixaNum.Text) Then
            destrancarLinhaFechoConta()
            If SQL.temConexao() = True And SQLPriEmpre.temConexao() = True Then




                tabela = SQL.buscarDado("Select dc.*, ct.NumDoc As NumDoc from diarioCaixa As dc, cabecTesouraria As ct where dc.Conta = '" + contaPos + "' and ct.NumDoc = '" + diario + "'  and ct.TipoDoc='FCHCX'  and dc.Id=ct.IDDiarioCaixa  and Serie = (select Serie from SeriesTesouraria where TipoDoc = 'FCHCX' and SeriePorDefeito = 1) ")
                'tabela = SQL.buscarDado("select distinct dc.*, ct.NumDoc as NumDoc, ct.Serie from diarioCaixa as dc, cabecTesouraria as ct where dc.Conta = 'cxp02' and ct.NumDoc = '12' and ct.TipoDoc='FCHCX' and ct.Serie='B2019'   and dc.Id=ct.IDDiarioCaixa ")
                If (tabela.Rows.Count <> 0) Then
                    Me.txtCaixaNum.Text = tabela.Rows(0)("NumDoc")
                    Me.lblDiarioCaixa.Text = tabela.Rows(0)("Diario")
                    diarioCaixa = Me.lblDiarioCaixa.Text
                    If Not IsDBNull(tabela.Rows(0)("DataAbertura")) Then
                        Me.mskDataAbertura.Text = tabela.Rows(0)("DataAbertura")
                    End If

                    If Not IsDBNull(tabela.Rows(0)("SaldoAbertura")) Then

                        Me.mskSaldoAbertura.Text = tabela.Rows(0)("SaldoAbertura")
                    End If
                    If Not IsDBNull(tabela.Rows(0)("UtilizadorAbertura")) Then
                        Me.txtUtilizadorAbertura.Text = tabela.Rows(0)("UtilizadorAbertura")

                    End If


                    If Not (IsDBNull(tabela.Rows(0)("DataFecho"))) Then
                        Me.mskDataFecho.Text = tabela.Rows(0)("DataFecho")
                    End If

                    If Not IsDBNull(tabela.Rows(0)("SaldoFecho")) Then

                        Me.mskSaldoFecho.Text = tabela.Rows(0)("SaldoFecho")
                    End If
                    If Not IsDBNull(tabela.Rows(0)("UtilizadorFecho")) Then

                        Me.txtUtilizadorFecho.Text = tabela.Rows(0)("UtilizadorFecho")
                    End If
                    ptxboxUtilizadorAberturaCaixa.ImageLocation = administracao.buscarUtilizadorImagem(Me.txtUtilizadorFecho.Text)
                    If Not IsDBNull(tabela.Rows(0)("SaldoAbertura")) Then
                        Me.mskValRecAbertura.Text = tabela.Rows(0)("SaldoAbertura")
                    End If
                    If Not IsDBNull(tabela.Rows(0)("Id")) Then
                        idCaixa = tabela.Rows(0)("Id").ToString()
                    End If

                    ' buscando id do cabecDoc
                    'Dim qrCabecTes As String = "select * from cabectesouraria where (tipoDoc = 'SAICX' or TipoDoc = 'ENTCX' or tipoDoc = 'MOV') and IDDiarioCaixa = '" + idCaixa + "'"
                    Dim qrCabecTes As String = "select * from cabectesouraria where  IDDiarioCaixa = '" + idCaixa + "'"
                    'Dim qrEntradaSaida As String = "select * from cabectesouraria where (tipoDoc = 'SAICX' or TipoDoc = 'ENTCX') and IDDiarioCaixa = '" + idCaixa + "'"
                    Dim sqlLinhaTesouraria As String = "select *  from TDU_ConferenciaCaixa where CDU_diarioCaixa =  '" + diarioCaixa + "' and CDU_conta = '" + contaPos + "'"

                    Dim qrLinhaTes As String
                    Dim tipo_movimento As String
                    Dim tipoMov As String = ""

                    tabela = SQL.buscarDado(qrCabecTes)
                    'tabelaEntradaSaida = SQL.buscarDado(qrEntradaSaida)
                    If (tabela.Rows.Count <> 0) Then

                        For i As Integer = 0 To tabela.Rows.Count - 1
                            idLinhaTesouraria = tabela.Rows(i)("Id").ToString()
                            If Not IsDBNull(tabela.Rows(0)("TipoDoc")) Then

                                movimento = tabela.Rows(i)("TipoDoc").ToString()
                            End If
                            If (movimento = "MOV") Then

                                qrLinhaTes = "select * from LinhasTesouraria where IdCabecTesouraria =  '" + idLinhaTesouraria + "'"

                                IDCABECTESOURARIA = idLinhaTesouraria
                                tabelaLinhaTesouraria = SQL.buscarDado(qrLinhaTes)
                                Dim listaMov As Movimentos = New Movimentos
                                listaMov = js.getListaMovimento()
                                If listaMov.modoMovimento = "bancario" Then
                                    tipoMov = "Credito"
                                Else
                                    tipoMov = "Debito"
                                End If

                                If (tabela.Rows.Count <> 0) Then
                                    For j As Integer = 0 To tabelaLinhaTesouraria.Rows.Count - 1
                                        If Not IsDBNull(tabelaLinhaTesouraria.Rows(0)("Movim")) Then

                                            tipo_movimento = tabelaLinhaTesouraria.Rows(j)("Movim").ToString()
                                        Else
                                            tipo_movimento = ""
                                        End If
                                        ' consultando numerario
                                        rv = numerarioMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            numerarioTotal += tabelaLinhaTesouraria.Rows(j)(tipoMov)
                                        End If

                                        ' consultando multibanco
                                        rv = multibancoMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            multibancoTotal += tabelaLinhaTesouraria.Rows(j)(tipoMov)
                                        End If

                                        ' consultando cheque
                                        rv = chequeMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            chequeTotal += tabelaLinhaTesouraria.Rows(j)(tipoMov)
                                        End If

                                        '' consultando senha cabazes
                                        'rv = outrosMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        'If (rv >= 0) Then
                                        '    outrosTotal += tabelaLinhaTesouraria.Rows(j)(tipoMov)
                                        'End If


                                        'consultando saida pagamento numerario
                                        'rv = saidaMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        'If (rv >= 0) Then
                                        If (tipo_movimento = "PGNUM" And tabelaLinhaTesouraria.Rows(j)("Descricao").ToString() = "Venda") Then

                                            outrosTotal += tabelaLinhaTesouraria.Rows(j)("Debito")
                                        End If
                                        'End If

                                        Try
                                            Me.tabelaConferenciaCaixa.Rows(j).Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                                        Catch ex As Exception
                                            Console.WriteLine(ex)
                                        End Try
                                    Next
                                End If


                            ElseIf (movimento = "ENTCX") Then



                                'If Not IsDBNull(tabela.Rows(i)("TotalCredito") And tabela.Rows(i)("TotalCredito") > 0) Then

                                '    entradaTotal += tabela.Rows(i)("TotalCredito")
                                'Else
                                '    entradaTotal += tabela.Rows(i)("TotalDebito")

                                'End If

                                If (tipoMov = "credito") Then
                                    entradaTotal += tabela.Rows(i)("TotalCredito")
                                Else

                                    entradaTotal += tabela.Rows(i)("TotalDebito")

                                End If


                            ElseIf (movimento = "SAICX") Then
                                'If Not IsDBNull(tabela.Rows(i)("TotalDebito")) And tabela.Rows(i)("TotalDebito") > 0 Then

                                '    saidaTotal += tabela.Rows(i)("TotalDebito")
                                'Else
                                '    saidaTotal += tabela.Rows(i)("TotalCredito")
                                'End If

                                If (tipoMov = "credito") Then
                                    saidaTotal += tabela.Rows(i)("TotalDebito")

                                Else
                                    saidaTotal += tabela.Rows(i)("TotalCredito")


                                End If
                            End If


                        Next



                        Me.mskValRecNumerario.Text = numerarioTotal - outrosTotal
                        Me.mskValRecCheque.Text = chequeTotal
                        Me.mskValRecMultiBim.Text = multibancoTotal
                        If outrosTotal < 0 Then

                            outrosTotal = outrosTotal * -1
                        End If
                        Me.mskValRecSenhasCabazes.Text = outrosTotal
                        Me.mskValRecEntradaCaixa.Text = entradaTotal

                        If saidaTotal > 0 Then
                            saidaTotal = saidaTotal * -1
                        End If
                        Me.mskValRecSaidaCaixa.Text = saidaTotal
                        mskValRecSaidaCaixa.ForeColor = Color.Red

                        carregar_valor()

                        numerarioTotal = 0
                        chequeTotal = 0
                        multibancoTotal = 0
                        outrosTotal = 0
                        entradaTotal = 0
                        saidaTotal = 0
                    End If
                    tblLinhaTesourariaBd = SQL.buscarDado(sqlLinhaTesouraria)

                    If (tblLinhaTesourariaBd.Rows.Count <> 0) Then
                        multibancoConferidoTotal = 0
                        chequeConferidoTotal = 0
                        numerarioConferidoTotal = 0
                        saidaConferidoTotal = 0
                        entradaConferidoTotal = 0
                        aberturaConferidoTotal = 0
                        btnPrevisualizarReporte.Enabled = True
                        DIARIO_CONFERIDO = True
                        For i As Integer = 0 To tblLinhaTesourariaBd.Rows.Count - 1
                            movimento = tblLinhaTesourariaBd.Rows(i)("CDU_modoMovimento").ToString()
                            Me.txtUtilizadorConferencia.Text = tblLinhaTesourariaBd.Rows(i)("CDU_utilizadorTesoureiro").ToString()

                            If (check_multibanco_mov(movimento)) Then

                                Dim tipo_cartao As String = tblLinhaTesourariaBd.Rows(i)("CDU_cartaoTipo").ToString()
                                Dim transacao As String = tblLinhaTesourariaBd.Rows(i)("CDU_transacaoNumero").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                                Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()

                                tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, tipo_cartao, transacao, "", 1, valor, data})
                                preencherCabecalho(movimento, valor)

                            ElseIf (check_cheque_mov(movimento)) Then

                                Dim descricao As String = tblLinhaTesourariaBd.Rows(i)("CDU_chequeDescricao").ToString()
                                Dim chequeNum As String = tblLinhaTesourariaBd.Rows(i)("CDU_chequeNumero").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                                Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()

                                tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, descricao, chequeNum, "", 1, valor, data})
                                preencherCabecalho(movimento, valor)

                            ElseIf (check_numerario_mov(movimento)) Then

                                Dim quantidade As String = tblLinhaTesourariaBd.Rows(i)("CDU_quantidade").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                                Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()

                                tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", "", quantidade, valor, data})
                                preencherCabecalho(movimento, valor)


                            ElseIf (check_entrada_caixa_mov(movimento) Or check_saida_caixa_mov(movimento) Or check_abertura_caixa_mov(movimento) Or check_pagamento_caixa_mov(movimento)) Then

                                Dim quantidade As String = tblLinhaTesourariaBd.Rows(i)("CDU_quantidade").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()
                                Dim data As String = tblLinhaTesourariaBd.Rows(i)("CDU_data_transacao").ToString()


                                If (check_saida_caixa_mov(movimento)) Or (check_pagamento_caixa_mov(movimento)) Then
                                    Dim saidaDesc As String = tblLinhaTesourariaBd.Rows(i)("CDU_saidaDescricao").ToString()
                                    tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", saidaDesc, 1, valor, data})
                                    preencherCabecalho(movimento, valor)

                                Else
                                    tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", "", 1, valor, data})


                                End If


                                If (check_entrada_caixa_mov(movimento)) Then
                                    preencherCabecalho(movimento, valor)
                                ElseIf (check_abertura_caixa_mov(movimento)) Then
                                    preencherCabecalho(movimento, valor)
                                End If

                            End If

                        Next

                        bloquearEdicao()
                        Me.btnConfereAdicionar.Text = "Remover"
                        Me.btnConfereAdicionar.Enabled = True

                        If utilizador_logado.getNivel() <> "Tesoureiro" Then

                            chkEditar.Enabled = True
                            chkEditar.Checked = False
                        End If
                    Else
                        DIARIO_CONFERIDO = False
                        btnPrevisualizarReporte.Enabled = False
                        Me.btnConfereAdicionar.Text = "Adicionar"
                        Me.txtUtilizadorConferencia.Text = Me.getLogado().getNome()
                        If utilizador_logado.getNivel() <> "Tesoureiro" Then

                            chkEditar.Enabled = False
                            chkEditar.Checked = False
                        End If
                        desbloquearEdicao()
                    End If


                    calcularTotalConferido_diferenca()

                    'For i As Integer = 0 To tabela.Rows.Count - 1
                    ''Dim DataType() As String = myTableData.Rows(i).Item(1)
                    'Me.txtCaixaNum.Text = tabela.Rows(i)("diario")
                    'Next
                Else

                    MsgBox("Resultado não encontrado para o Diario numero " + diario.ToString())
                    DIARIO_CONFERIDO = False

                    limpar_campos()
                    trancarLinhaFechoConta()

                End If
            End If
        Else
            'MsgBox("invalido")
            limpar_campos()
            trancarLinhaFechoConta()
        End If



        calcularTotalRecebido()



    End Sub


    Private Sub btnFecharConta_Click(sender As Object, e As EventArgs) Handles btnFecharConta.Click

        Dim ok As Boolean = False
        Dim result As Integer


        Dim quantidade As Integer
        Dim modoRecebRef, modoReceb, tipo_cartao, transacao_cheque_numero, descricao_saida_caixa As String

        Dim valor As String

        result = MessageBox.Show("Tem a certeza que pretende terminar esta Conferência de Caixa?", "Atenção", MessageBoxButtons.YesNo)
        Dim con As SqlConnection = SQL.conexao()
        Dim rv As Boolean

        If result = DialogResult.Yes Then

            If (check_conferencia_caixa()) Then
                ok = True
            Else
                result = MessageBox.Show("Existem diferenças nos valores registados. Pretende continuar ?", "Atenção", MessageBoxButtons.YesNo)
                ok = False

            End If
        End If

        Dim dataDiario As String = ""
        Dim diario As String = ""
        Dim dataTransacao = ""
        Dim rec_inicial As Integer = 0
        Dim rec_final As Integer = 0
        Dim rec_serie As String = ""
        Try


            If (ok = True) Or (ok = False And result = DialogResult.Yes) Then
                If Me.cboContaPos.SelectedItem = "CXMT" Then
                    rec_inicial = Me.txtDocInicio.Text
                    rec_final = Me.txtDocFim.Text
                    rec_serie = Me.cboFacturaSerie.Text
                    rv = administracao.removeLinhasCaixa((Me.txtDocInicio.Text & "0" & Me.txtDocFim.Text), Me.cboContaPos.SelectedItem, dtInicio.Value.ToShortDateString(), rec_inicial, rec_final, rec_serie)

                Else
                    rv = administracao.removeLinhasCaixa(Me.lblDiarioCaixa.Text, Me.cboContaPos.SelectedItem, "", rec_inicial, rec_final, rec_serie)


                End If

                For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
                    If Not row.IsNewRow Then

                        If Me.cboContaPos.SelectedItem = "CXMT" Then
                            dataDiario = dtInicio.Value.ToShortDateString()
                            diario = CInt(Me.txtDocInicio.Text & "0" & Me.txtDocFim.Text)
                        Else
                            dataDiario = administracao.buscarDataFechoDiario(lblDiarioCaixa.Text)
                            diario = lblDiarioCaixa.Text


                        End If

                        modoReceb = row.Cells(0).Value

                        modoRecebRef = row.Cells(1).Value

                        tipo_cartao = row.Cells(2).Value
                        transacao_cheque_numero = row.Cells(3).Value
                        descricao_saida_caixa = row.Cells(4).Value
                        valor = row.Cells(6).Value
                        dataTransacao = CDate(row.Cells(7).Value)
                        If (check_numerario_mov(modoReceb)) Then
                            quantidade = row.Cells(5).Value
                        Else
                            quantidade = 1
                        End If

                        If (check_abertura_caixa_mov(modoReceb)) Then

                            rv = administracao.insertConferenciaCaixa(diario, modoReceb, "", "", 1, valor, 0, "", Date.Now().ToShortDateString, utilizador_logado.getNome(), "", "", IDCABECTESOURARIA, Me.cboContaPos.SelectedItem, dataDiario, dataTransacao, rec_inicial, rec_final, rec_serie)
                        End If

                        If (check_saida_caixa_mov(modoReceb) Or check_pagamento_caixa_mov(modoReceb)) Then
                            rv = administracao.insertConferenciaCaixa(diario, modoReceb, "", "", 1, valor, 0, "", Date.Now().ToShortDateString, utilizador_logado.getNome(), descricao_saida_caixa, "", IDCABECTESOURARIA, Me.cboContaPos.SelectedItem, dataDiario, dataTransacao, rec_inicial, rec_final, rec_serie)
                        End If


                        If (check_entrada_caixa_mov(modoReceb)) Then
                            rv = administracao.insertConferenciaCaixa(diario, modoReceb, "", "", 1, valor, 0, "", Date.Now().ToShortDateString, utilizador_logado.getNome(), "", "", IDCABECTESOURARIA, Me.cboContaPos.SelectedItem, dataDiario, dataTransacao, rec_inicial, rec_final, rec_serie)
                        End If
                        If (check_numerario_mov(modoReceb)) Then
                            rv = administracao.insertConferenciaCaixa(diario, modoReceb, "", "", quantidade, valor, 0, "", Date.Now().ToShortDateString, utilizador_logado.getNome(), "", modoRecebRef, IDCABECTESOURARIA, Me.cboContaPos.SelectedItem, dataDiario, dataTransacao, rec_inicial, rec_final, rec_serie)
                        End If

                        If (check_multibanco_mov(modoReceb)) Then
                            rv = administracao.insertConferenciaCaixa(diario, modoReceb, tipo_cartao, transacao_cheque_numero, quantidade, valor, 0, "", Date.Now().ToShortDateString, utilizador_logado.getNome(), "", modoRecebRef, IDCABECTESOURARIA, Me.cboContaPos.SelectedItem, dataDiario, dataTransacao, rec_inicial, rec_final, rec_serie)
                        End If

                        If (check_cheque_mov(modoReceb)) Then
                            rv = administracao.insertConferenciaCaixa(diario, modoReceb, "", "", quantidade, valor, transacao_cheque_numero, tipo_cartao, Date.Now().ToShortDateString, utilizador_logado.getNome(), "", modoRecebRef, IDCABECTESOURARIA, Me.cboContaPos.SelectedItem, dataDiario, dataTransacao, rec_inicial, rec_final, rec_serie)
                        End If
                        If rv = False Then
                            Exit For
                        End If

                    Else
                        ' MsgBox("Nenhum dado na tabela por gravar")

                    End If
                Next
                If rv = True Then
                    MessageBox.Show("Documento Gravado com Sucesso", "Atenção", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("Ocorreu um erro na gravacão! ", "Atenção", MessageBoxButtons.OK)
                End If
                limpar_campos()
                limpar_campo_fechoconta()
                tabelaConferenciaCaixa.Rows.Clear()
                btnPrevisualizarReporte.Enabled = True
                Dim old As String = Me.txtCaixaNum.Text
                Me.txtCaixaNum.Text = ""
                dtInicio.Refresh()
                Me.txtCaixaNum.Text = old

            End If


        Catch ex As Exception
            MsgBox("[btnFecharConta_Click] Ocorreu um erro " + ex.Message())
        End Try
    End Sub

    Private Sub mskValRecNumerario_TextChanged(sender As Object, e As EventArgs) Handles mskValRecNumerario.TextChanged

        Me.mskValRecNumerario.Text = utilitario.soNumero(mskValRecNumerario.Text)

    End Sub

    Private Sub mskValRecAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskValRecAbertura.TextChanged

        Me.mskValRecAbertura.Text = utilitario.soNumero(mskValRecAbertura.Text)

    End Sub

    Private Sub mskValRecMultiBim_TextChanged(sender As Object, e As EventArgs) Handles mskValRecMultiBim.TextChanged
        'Me.mskValRecMultiBim.Text = FormatCurrency(Me.mskValRecMultiBim.Text).TrimStart("$")

        Try
            Me.mskValRecMultiBim.Text = utilitario.soNumero(mskValRecMultiBim.Text)

        Catch ex As Exception

        End Try
    End Sub



    Private Sub mskValRecCheque_TextChanged(sender As Object, e As EventArgs) Handles mskValRecCheque.TextChanged
        'Me.mskValRecCheque.Text = FormatCurrency(Me.mskValRecCheque.Text).TrimStart("$")
        Try
            Me.mskValRecCheque.Text = utilitario.soNumero(mskValRecCheque.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskValRecSenhasCabazes_TextChanged(sender As Object, e As EventArgs) Handles mskValRecSenhasCabazes.TextChanged
        'Me.mskValRecSenhasCabazes.Text = FormatCurrency(Me.mskValRecSenhasCabazes.Text).TrimStart("$")

        Try
            Me.mskValRecSenhasCabazes.Text = utilitario.soNumero(mskValRecSenhasCabazes.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskValConfAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskValConfAbertura.TextChanged
        'Me.mskValConfAbertura.Text = FormatCurrency(Me.mskValConfAbertura.Text).TrimStart("$")

        Try
            Me.mskValConfAbertura.Text = utilitario.soNumero(Me.mskValConfAbertura.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskValConfNumerario_TextChanged(sender As Object, e As EventArgs) Handles mskValConfNumerario.TextChanged
        'Me.mskValConfNumerario.Text = FormatCurrency(Me.mskValConfNumerario.Text).TrimStart("$")

        Try
            Me.mskValConfNumerario.Text = utilitario.soNumero(Me.mskValConfNumerario.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskValConfMultiBim_TextChanged(sender As Object, e As EventArgs) Handles mskValConfMultiBim.TextChanged
        'Me.mskValConfMultiBim.Text = FormatCurrency(Me.mskValConfMultiBim.Text).TrimStart("$")
        Try
            Me.mskValConfMultiBim.Text = utilitario.soNumero(Me.mskValConfMultiBim.Text)

        Catch ex As Exception

        End Try

    End Sub


    Private Sub mskValConfCheques_TextChanged(sender As Object, e As EventArgs) Handles mskValConfCheques.TextChanged
        'Me.mskValConfCheques.Text = FormatCurrency(Me.mskValConfCheques.Text).TrimStart("$")
        Try
            Me.mskValConfCheques.Text = utilitario.soNumero(Me.mskValConfCheques.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskValConfSenhas_TextChanged(sender As Object, e As EventArgs) Handles mskValConfSenhas.TextChanged
        'Me.mskValConfSenhas.Text = FormatCurrency(Me.mskValConfSenhas.Text).TrimStart("$")
        Try
            Me.mskValConfSenhas.Text = utilitario.soNumero(Me.mskValConfSenhas.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskDiferencaAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaAbertura.TextChanged
        Try
            Me.mskDiferencaAbertura.Text = utilitario.soNumero(mskDiferencaAbertura.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskDiferencaNumerario_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaNumerario.TextChanged
        Try

            Me.mskDiferencaNumerario.Text = utilitario.soNumero(mskDiferencaNumerario.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskDiferencaMultiBim_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaMultiBim.TextChanged

        Try
            Me.mskDiferencaMultiBim.Text = utilitario.soNumero(mskDiferencaMultiBim.Text)

        Catch ex As Exception

        End Try

    End Sub


    Private Sub mskDiferencaCheque_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaCheque.TextChanged


        Try
            Me.mskDiferencaCheque.Text = utilitario.soNumero(mskDiferencaCheque.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskDiferencaSenhasCabazes_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaSenhasCabazes.TextChanged


        Try

            Me.mskDiferencaSenhasCabazes.Text = utilitario.soNumero(mskDiferencaSenhasCabazes.Text)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub mskValorRecebido_TextChanged(sender As Object, e As EventArgs) Handles mskValorRecebido.TextChanged

        If (is_numerario_mov()) Then
            mskValorRecebido.Text = utilitario.soNumero(mskValorRecebido.Text)

            'Else

            '    If mskValorRecebido.Text.Length > 2 Then
            '        Dim T As String = mskValorRecebido.Text.Substring(mskValorRecebido.Text.Length - 3)
            '        Console.WriteLine(T)
            '        Dim F As Boolean = True
            '        For Each C As Char In T
            '            If Not Char.IsNumber(C) Then F = False
            '        Next
            '        If F Then
            '            mskValorRecebido.Text &= "."
            '            mskValorRecebido.Text = utilitario.soNumero(mskValorRecebido.Text)
            '            mskValorRecebido.SelectionStart = mskValorRecebido.Text.Length
            '        End If
            '    End If
        End If


    End Sub

    Private Sub mskSaldoFecho_TextChanged(sender As Object, e As EventArgs) Handles mskSaldoFecho.TextChanged

        mskSaldoFecho.Text = utilitario.soNumero(mskSaldoFecho.Text)

    End Sub


    Private Sub limpar_campos()


        Me.mskValRecNumerario.Text = 0
        Me.mskValRecCheque.Text = 0
        Me.mskValRecMultiBim.Text = 0
        Me.mskValRecSenhasCabazes.Text = 0
        Me.mskValRecAbertura.Text = 0
        Me.mskValRecEntradaCaixa.Text = 0
        Me.mskValRecSaidaCaixa.Text = 0

        Me.mskValConfAbertura.Text = 0
        Me.mskValConfNumerario.Text = 0
        Me.mskValConfMultiBim.Text = 0
        Me.mskValConfCheques.Text = 0
        Me.mskValConfSenhas.Text = 0
        Me.mskValConfEntradaCaixa.Text = 0
        Me.mskValConfSaidaCaixa.Text = 0

        Me.mskDiferencaAbertura.Text = 0
        Me.mskDiferencaNumerario.Text = 0
        Me.mskDiferencaMultiBim.Text = 0

        Me.mskDiferencaCheque.Text = 0
        Me.mskDiferencaSenhasCabazes.Text = 0
        Me.mskDiferencaEntradaCaixa.Text = 0
        Me.mskDiferencaSaidaCaixa.Text = 0

        Me.mskDataAbertura.Text = ""
        Me.mskSaldoAbertura.Text = 0
        Me.txtUtilizadorAbertura.Text = ""
        Me.mskDataFecho.Text = ""
        Me.mskSaldoFecho.Text = 0
        Me.txtUtilizadorFecho.Text = ""


        Me.lblEstdCheques.Text = ""
        Me.lblEstdEntradaCaixa.Text = ""
        Me.lblEstdPagamentoAutomatico.Text = ""
        Me.lblEstdSaidaCaixa.Text = ""
        Me.lblEstdSaldoAbert.Text = ""
        Me.lblEstdSenhas.Text = ""
        Me.lblTotalConferido.Text = ""
        Me.lblTotalDiferenca.Text = ""
        Me.lblTotalRecebido_.Text = ""
        Me.lblTotalRecebido_.Text = ""

        lblEstdNumerario.Text = ""

        Me.txtUtilizadorConferencia.Text = ""


        numerarioConferidoTotal = 0
        chequeConferidoTotal = 0
        outrosConferidoTotal = 0
        entradaConferidoTotal = 0

        saidaConferidoTotal = 0
        aberturaConferidoTotal = 0
        multibancoConferidoTotal = 0

        numerarioTotal = 0
        chequeTotal = 0
        outrosTotal = 0

        entradaTotal = 0
        saidaTotal = 0
        multibancoTotal = 0

        tabelaConferenciaCaixa.Rows.Clear()

    End Sub

    Private Sub mskValRecEntradaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValRecEntradaCaixa.TextChanged

        Try
            'If (Me.mskValRecEntradaCaixa.Text.Length > 0 And IsNumeric(Me.mskValRecEntradaCaixa.Text)) Then
            Me.mskValRecEntradaCaixa.Text = utilitario.soNumero(mskValRecEntradaCaixa.Text)

            'Me.mskValRecEntradaCaixa.Text = FormatCurrency(Me.mskValRecEntradaCaixa.Text).TrimStart("$")
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskValRecSaidaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValRecSaidaCaixa.TextChanged

        Me.mskValRecSaidaCaixa.Text = utilitario.soNumero(mskValRecSaidaCaixa.Text)
    End Sub

    Private Sub mskValConfEntradaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValConfEntradaCaixa.TextChanged

        Try
            'If (Me.mskValConfEntradaCaixa.Text.Length > 0 And IsNumeric(Me.mskValConfEntradaCaixa.Text)) Then

            'Me.mskValConfEntradaCaixa.Text = FormatCurrency(Me.mskValConfEntradaCaixa.Text).TrimStart("$")
            Me.mskValConfEntradaCaixa.Text = utilitario.soNumero(mskValConfEntradaCaixa.Text)

            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskValConfSaidaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValConfSaidaCaixa.TextChanged

        mskValConfSaidaCaixa.Text = utilitario.soNumero(mskValConfSaidaCaixa.Text)

    End Sub

    Private Sub mskDiferencaEntradaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaEntradaCaixa.TextChanged

        Me.mskDiferencaEntradaCaixa.Text = utilitario.soNumero(mskDiferencaEntradaCaixa.Text)

    End Sub

    Private Sub mskDiferencaSaidaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaSaidaCaixa.TextChanged




        Try
            Me.mskDiferencaSaidaCaixa.Text = utilitario.soNumero(mskDiferencaSaidaCaixa.Text)


            'diferenca = CDbl(Me.mskDiferencaSaidaCaixa.Text)
            'If (diferenca < 0) Then
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tabelaConferenciaCaixa_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tabelaConferenciaCaixa.MouseDoubleClick

        'If Not DIARIO_CONFERIDO Then

        'Else
        '    MessageBox.Show("Somente Utilizador autorizado poderá editar as Linhas de conferência de caixa", "Atenção")

        'End If

        Dim row As Integer = Me.tabelaConferenciaCaixa.CurrentRow.Index

        If (tabelaConferenciaCaixa.Rows.Count() > 1 And is_row_valid(row)) Then

            If (utilizador_logado.getLogado() = True) Then

                If DIARIO_CONFERIDO Then

                    If (utilizador_logado.getNivel() = "Administrador" Or utilizador_logado.getNivel() = "Super administrador") Then
                        If Me.chkEditar.Checked = True Then
                            editarFechoConta()
                            calcularTotalConferido_diferenca()
                            destrancarLinhaFechoConta()
                            Me.btnConfereAdicionar.Text = "Adicionar"
                        Else
                            MessageBox.Show("Selecione Editar Caixa para alteração da linha", "Atenção", MessageBoxButtons.OK)

                        End If

                    Else
                        MessageBox.Show("Documento ja gravado. Para alterar contacte o Administrador do Sistema", "Atenção", MessageBoxButtons.OK)

                    End If


                Else
                    editarFechoConta()
                    calcularTotalConferido_diferenca()
                    Me.btnConfereAdicionar.Text = "Adicionar"
                End If
            Else
                If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Entrar.ShowDialog(Me)
                End If
            End If

        End If
    End Sub


    Private Sub trancarLinhaFechoConta()
        cboModoRecebido.Enabled = False
        cboReferenciaModoReceb.Enabled = False
        btnConfereAdicionar.Enabled = False
        btnFecharConta.Enabled = False
        btnConfereLimpar.Enabled = False
        trancarCartaoChequeInput()


    End Sub
    Private Sub destrancarLinhaFechoConta()
        cboModoRecebido.Enabled = True
        cboReferenciaModoReceb.Enabled = True
        btnConfereAdicionar.Enabled = True
        btnFecharConta.Enabled = True

        btnConfereLimpar.Enabled = True

    End Sub

    Private Sub destrancarCartaoChequeInput()
        'txtTransacaoNumero.Enabled = True
        cboCartaoTipo.Enabled = True
        mskValorRecebido.Enabled = True
        Me.dtTransacao.Enabled = True

    End Sub

    Private Sub trancarCartaoChequeInput()
        'txtTransacaoNumero.Enabled = False
        cboCartaoTipo.Enabled = False
        mskValorRecebido.Enabled = False
        Me.dtTransacao.Enabled = False
    End Sub
    Private Sub trancarLinhaFechoConta_mov_local()
        cboReferenciaModoReceb.Enabled = False
        txtQuantidade.Enabled = False
        trancarCartaoChequeInput()
        cboReferenciaModoReceb.Enabled = False
        mskValorRecebido.Enabled = True


    End Sub
    Private Sub destrancarLinhaFechoConta_mov_local()
        cboReferenciaModoReceb.Enabled = True
        txtQuantidade.Enabled = True
        mskValorRecebido.Enabled = True
        cboReferenciaModoReceb.Enabled = True

        destrancarCartaoChequeInput()



    End Sub

    Private Sub destrancarNumerario_mov()
        txtQuantidade.Enabled = True
        cboReferenciaModoReceb.Enabled = True

    End Sub


    Private Sub editarFechoConta()
        Dim checkDiferenca As Double

        Dim linha_valor_confirmado As Boolean = False




        Dim indice_tabela_conta, quantidade As Integer
        Dim modoRecebRef, modoReceb, tipo_cartao, transacao_cheque_numero, i, descricao_saida_caixa As String
        Dim modoRecebVal As Double

        modoReceb = ""
        Try


            indice_tabela_conta = Me.tabelaConferenciaCaixa.CurrentRow.Index
            modoReceb = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(0).Value
            modoRecebRef = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(1).Value

            tipo_cartao = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(2).Value
            transacao_cheque_numero = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(3).Value
            descricao_saida_caixa = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(4).Value

            If (check_numerario_mov(modoReceb)) Then
                quantidade = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(5).Value
            Else
                quantidade = 1
            End If
            modoRecebVal = utilitario.soNumero(tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(6).Value)
            Dim data As String = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(7).Value
            Try
                dtTransacao.Value = CDate(data)

            Catch ex As Exception
                dtTransacao.Refresh()
            End Try





            'Alterar primeiro o tipo de movimento
            i = cboModoRecebido.Items.IndexOf(modoReceb)
            cboModoRecebido.SelectedIndex = i

            'Em seguida mostrar opcoes de referencia de modo recebimento 
            'dependendo do tipo do movimento
            If (IsNumeric(modoRecebRef)) Then
                i = cboReferenciaModoReceb.Items.IndexOf(modoRecebRef.ToString())
            Else
                i = cboReferenciaModoReceb.Items.IndexOf(modoRecebRef)
            End If


            'Por fim actualizar o tipo de cartao se o movimento for do tipo pagamento automatico
            ' Caso contrario actualizar cheque descricao ou cliente
            If (is_cheque_mov()) Then
                cboCartaoTipo.Text = tipo_cartao
                txtQuantidade.Text = transacao_cheque_numero
            ElseIf (is_multibanco_mov()) Then

                cboCartaoTipo.Text = tipo_cartao
                txtQuantidade.Text = transacao_cheque_numero
            ElseIf (is_numerario_mov()) Then
                txtQuantidade.Text = quantidade
            ElseIf (is_saida_caixa_mov() Or is_pagamento_caixa_mov()) Then
                cboReferenciaModoReceb.Text = descricao_saida_caixa

            End If
            Me.mskValorRecebido.Text = modoRecebVal
            If (i >= 0) Then
                cboReferenciaModoReceb.Text = cboReferenciaModoReceb.Items.Item(i)
            End If

            'If (modoRecebVal < 0) Then
            '    Me.mskValorRecebido.Text = FormatCurrency(Format(modoRecebVal, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskValorRecebido.Text = FormatCurrency(Format(modoRecebVal, "Fixed")).TrimStart("$")
            'End If



            Me.tabelaConferenciaCaixa.Rows.RemoveAt(indice_tabela_conta)
            'Me.indiceFechoConta -= 1




        Catch ex As Exception
            MsgBox("[editarFechoConta] Ocorreu um erro " + ex.Message())
        End Try

        'Me.tabelaConferenciaCaixa.del
        'Me.tabelaConferenciaCaixa.Rows(indice_tabela_conta)







        'If (modoReceb = "Rec. em Numerário" Or modoReceb = "Rec. Numerario (NAO USAR)") Then
        If check_numerario_mov(modoReceb) Then
            Me.numerarioConferidoTotal -= CDbl(modoRecebVal)
            Me.mskValConfNumerario.Text = Me.numerarioConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfNumerario.Text) - CDbl(Me.mskValRecNumerario.Text)
            Me.mskDiferencaNumerario.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdNumerario.ForeColor = Color.Red
                Me.lblEstdNumerario.Text = "Valor a Menos"
            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdNumerario.ForeColor = Color.Black
                Me.lblEstdNumerario.Text = "Correcto"
            Else
                Me.lblEstdNumerario.ForeColor = Color.Green
                Me.lblEstdNumerario.Text = "Valor a Mais"

            End If

            'ElseIf (modoReceb = "Rec. por Cheque (PD)" Or modoReceb = "Rec. por Cheque") Then
        ElseIf (check_cheque_mov(modoReceb)) Then

            Me.chequeConferidoTotal -= CDbl(modoRecebVal)
            Me.mskValConfCheques.Text = Me.chequeConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfCheques.Text) - CDbl(Me.mskValRecCheque.Text)
            Me.mskDiferencaCheque.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdCheques.ForeColor = Color.Red
                Me.lblEstdCheques.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdCheques.ForeColor = Color.Black
                Me.lblEstdCheques.Text = "Correcto"

            Else
                Me.lblEstdCheques.ForeColor = Color.Green
                Me.lblEstdCheques.Text = "Valor a Mais"

            End If

            'ElseIf (modoReceb = "Rec. Multi Rede" Or modoReceb = "Rec. por Multibanco") Then
        ElseIf check_multibanco_mov(modoReceb) Then
            If (Me.cboCartaoTipo.SelectedIndex <> 0) Then

                Me.multibancoConferidoTotal -= CDbl(modoRecebVal)
                Me.mskValConfMultiBim.Text = Me.multibancoConferidoTotal
                checkDiferenca = CDbl(Me.mskValConfMultiBim.Text) - CDbl(Me.mskValRecMultiBim.Text)
                Me.mskDiferencaMultiBim.Text = checkDiferenca
                'If (checkDiferenca < 0) Then
                '    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                'Else
                '    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                'End If

                If (checkDiferenca < 0) Then
                    Me.lblEstdPagamentoAutomatico.ForeColor = Color.Red
                    Me.lblEstdPagamentoAutomatico.Text = "Valor a Menos"
                ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                    Me.lblEstdPagamentoAutomatico.ForeColor = Color.Black
                    Me.lblEstdPagamentoAutomatico.Text = "Correcto"

                Else
                    Me.lblEstdPagamentoAutomatico.ForeColor = Color.Green
                    Me.lblEstdPagamentoAutomatico.Text = "Valor a Mais"

                End If



            End If
        ElseIf (is_abertura_caixa_mov()) Then

            Me.aberturaConferidoTotal = CDbl(modoRecebVal)


            Me.mskValConfAbertura.Text = Me.aberturaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfAbertura.Text) - CDbl(Me.mskValRecAbertura.Text)
            Me.mskDiferencaAbertura.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdSaldoAbert.ForeColor = Color.Red
                Me.lblEstdSaldoAbert.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdSaldoAbert.ForeColor = Color.Black
                Me.lblEstdSaldoAbert.Text = "Correcto"

            Else
                Me.lblEstdSaldoAbert.ForeColor = Color.Green
                Me.lblEstdSaldoAbert.Text = "Valor a Mais"

            End If

        ElseIf (is_entrada_caixa_mov()) Then
            Me.entradaConferidoTotal -= CDbl(modoRecebVal)
            Me.mskValConfEntradaCaixa.Text = Me.entradaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfEntradaCaixa.Text) - CDbl(Me.mskValRecEntradaCaixa.Text)
            Me.mskDiferencaEntradaCaixa.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdEntradaCaixa.ForeColor = Color.Red
                Me.lblEstdEntradaCaixa.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdEntradaCaixa.ForeColor = Color.Black
                Me.lblEstdEntradaCaixa.Text = "Correcto"

            Else
                Me.lblEstdEntradaCaixa.ForeColor = Color.Green
                Me.lblEstdEntradaCaixa.Text = "Valor a Mais"

            End If
        ElseIf (is_saida_caixa_mov()) Then

            Me.saidaConferidoTotal -= CDbl(modoRecebVal)

            Me.mskValConfSaidaCaixa.Text = Me.saidaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfSaidaCaixa.Text) - CDbl(Me.mskValRecSaidaCaixa.Text)
            Me.mskDiferencaSaidaCaixa.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdSaidaCaixa.ForeColor = Color.Red
                Me.lblEstdSaidaCaixa.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdSaidaCaixa.ForeColor = Color.Black
                Me.lblEstdSaidaCaixa.Text = "Correcto"

            Else
                Me.lblEstdSaidaCaixa.ForeColor = Color.Green
                Me.lblEstdSaidaCaixa.Text = "Valor a Mais"

            End If


        ElseIf (is_pagamento_caixa_mov()) Then



            Me.outrosConferidoTotal += CDbl(modoRecebVal)
            If (CDbl(Me.outrosConferidoTotal) > 0) Then
                Me.outrosConferidoTotal = Me.outrosConferidoTotal * -1
            End If
            Me.mskValConfSenhas.Text = Me.outrosConferidoTotal
            checkDiferenca = CDbl(Me.mskValRecSenhasCabazes.Text) - CDbl(Me.mskValConfSenhas.Text)
            Me.mskDiferencaSenhasCabazes.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdSenhas.ForeColor = Color.Red
                Me.lblEstdSenhas.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdSenhas.ForeColor = Color.Black
                Me.lblEstdSenhas.Text = "Correcto"

            Else
                Me.lblEstdSenhas.ForeColor = Color.Green
                Me.lblEstdSenhas.Text = "Valor a Mais"

            End If



        End If
    End Sub

    Private Sub btnConfereLimpar_Click(sender As Object, e As EventArgs) Handles btnConfereLimpar.Click
        limpar_campo_fechoconta()

    End Sub
    Private Function is_lancamento_redudante() As Integer
        Dim tipo_movimento, valor_movimento As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_numerario_mov(tipo_movimento)) Then
                    valor_movimento = row.Cells(1).Value.ToString

                    If (Me.cboReferenciaModoReceb.Text = valor_movimento) Then
                        rv = row.Index
                    End If

                End If
            End If
        Next

        Return rv
    End Function


    Private Function is_lancamento_multibanco_redundante() As Integer
        Dim tipo_movimento, cartao_cheque_numero As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_multibanco_mov(tipo_movimento)) Then
                    cartao_cheque_numero = row.Cells(3).Value.ToString
                    If (Me.txtQuantidade.Text = cartao_cheque_numero) Then
                        rv = row.Index
                    End If

                End If
            End If
        Next

        Return rv
    End Function

    Private Function is_lancamento_cheque_redundante() As Integer
        Dim tipo_movimento, cartao_cheque_numero As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_cheque_mov(tipo_movimento)) Then
                    cartao_cheque_numero = row.Cells(3).Value.ToString
                    If (Me.txtQuantidade.Text = cartao_cheque_numero) Then
                        'tabelaConferenciaCaixa.Rows.Insert (row.Index, New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
                        rv = row.Index
                    End If

                End If
            End If
        Next

        Return rv
    End Function

    Private Sub mskValRecEntradaCaixa_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskValRecEntradaCaixa.MaskInputRejected

    End Sub

    Private Sub ptxboxUtilizadorAberturaCaixa_Click(sender As Object, e As EventArgs) Handles ptxboxUtilizadorAberturaCaixa.Click

    End Sub

    Private Sub btnLimparTabela_Click(sender As Object, e As EventArgs) Handles btnLimparTabela.Click
        Dim result As Integer = MessageBox.Show("Limpar tabela causará perdas de dados. Deseja continuar ?", "Atenção", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Me.tabelaConferenciaCaixa.Rows.Clear()
        End If

    End Sub


    Private Sub txtCaixaNum_Click(sender As Object, e As EventArgs) Handles txtCaixaNum.Click


    End Sub

    Private Function is_lancamento_abertura_redundante() As Integer
        Dim tipo_movimento As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_abertura_caixa_mov(tipo_movimento)) Then
                    rv = row.Index
                End If
            End If
        Next

        Return rv
    End Function
    Private Function is_lancamento_saida_redundante() As Integer
        Dim tipo_movimento As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_saida_caixa_mov(tipo_movimento)) Then
                    rv = row.Index
                End If
            End If
        Next

        Return rv
    End Function
    Private Function is_lancamento_entrada_redundante() As Integer
        Dim tipo_movimento As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_entrada_caixa_mov(tipo_movimento)) Then
                    rv = row.Index
                End If
            End If
        Next

        Return rv
    End Function


    'calcular totais de todos movimentos Do caixa
    Private Sub calcularTotalRecebido()
        lblTotalRecebido_.Text = utilitario.soNumero((CDbl(mskValRecAbertura.Text) + CDbl(mskValRecNumerario.Text) + CDbl(mskValRecMultiBim.Text) + CDbl(mskValRecCheque.Text) + CDbl(mskValRecEntradaCaixa.Text)))
        'lblTotalRecebido.Text = utilitario.soNumero((CDbl(mskValRecAbertura.Text) + CDbl(mskValRecNumerario.Text) + CDbl(mskValRecMultiBim.Text) + CDbl(mskValRecCheque.Text) + CDbl(mskValRecEntradaCaixa.Text)))
        Me.mskSaldoFecho.Text = lblTotalRecebido_.Text
        'Me.lblTotalRecebido_.Text = lblTotalRecebido.Text
    End Sub


    Private Sub calcularTotalConferido_diferenca()
        lblTotalConferido.Text = utilitario.soNumero((CDbl(mskValConfAbertura.Text) + CDbl(mskValConfNumerario.Text) + CDbl(mskValConfMultiBim.Text) + CDbl(mskValConfCheques.Text) + CDbl(mskValConfEntradaCaixa.Text) + CDbl(mskValConfSaidaCaixa.Text)))
        ' lblTotalConferido.Text = utilitario.soNumero((CDbl(c.Text) + CDbl(mskValConfNumerario.Text) + CDbl(mskValConfMultiBim.Text) + CDbl(mskValConfCheques.Text) + CDbl(mskValConfEntradaCaixa.Text)))

        lblTotalDiferenca.Text = utilitario.soNumero((CDbl(mskDiferencaAbertura.Text) + CDbl(mskDiferencaNumerario.Text) + CDbl(mskDiferencaMultiBim.Text) + CDbl(mskDiferencaCheque.Text) + CDbl(mskDiferencaSaidaCaixa.Text)))
        'lblTotalDiferenca.Text = CDbl(lblTotalRecebido.Text) - CDbl(lblTotalConferido.Text)
    End Sub

    Private Sub txtCaixaNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCaixaNum.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskValRecSaidaCaixa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskValRecSaidaCaixa.KeyPress
        e.Handled = True
    End Sub

    Private Sub mskValConfSaidaCaixa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskValConfSaidaCaixa.KeyPress
        e.Handled = True

    End Sub

    Private Sub cboModoRecebido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboModoRecebido.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboReferenciaModoReceb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboReferenciaModoReceb.KeyPress
        If Not (is_saida_caixa_mov() Or is_pagamento_caixa_mov()) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboCartaoTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCartaoTipo.KeyPress
        'If Not is_cheque_mov() Or Not Me.cboContaPos.SelectedItem = "Recibo Transf. Bancaria" Then
        '    e.Handled = True
        '    'And Me.cboContaPos.SelectedItem = "Recibo Transf. Bancaria"
        'End If
    End Sub

    Private Sub txtQuantidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantidade.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub mskValorRecebido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskValorRecebido.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub btnPrevisualizarReporte_Click(sender As Object, e As EventArgs) Handles btnPrevisualizarReporte.Click
        'report.Reporte_origem = "FECHO CAIXA"
        'report.setDiario(CInt(txtCaixaNum.Text))
        'report.setConta(cboContaPos.SelectedItem)

        'report.Show()
        ' ReporteView.Show(Me)

        Dim reportPath As String
        Dim path As Util = New Util()
        Dim utilizador As String = js.getConexao().utilizador
        Dim senha As String = utilitario.Decrypt(js.getConexao().senha)
        Dim servidor As String = js.getConexao().servidor
        Dim basedados As String = js.getConexao.basedados
        report.Reporte_origem = "FECHO CAIXA"
        If Me.cboContaPos.SelectedItem = "CXMT" Then
            reportPath = path.dataPathReport + "\PRIFFTJMR.rpt"

        Else
            reportPath = path.dataPathReport + "\PRIFCJMR.rpt"
        End If


        If (System.IO.File.Exists(reportPath) = True) Then
            report.cryRpt.Load(reportPath)

            report.cryRpt.SetDatabaseLogon(utilizador, senha, servidor, basedados)
            'With report.crConnectionInfo
            '    .ServerName = servidor
            '    'If you are connecting to Oracle there is no DatabaseName. Use an empty string. 
            '    'For example, .DatabaseName = ""
            '    .DatabaseName = basedados
            '    .UserID = utilizador
            '    .Password = senha
            'End With


            'report.setDiario(CInt(lblDiarioCaixa.Text))
            'report.setConta(Me.cboContaPos.SelectedItem)
            Dim conta As String = Me.cboContaPos.SelectedItem
            Dim data_factura As String = Me.dtInicio.Value.ToShortDateString()
            If conta = "CXMT" Then
                report.cryRpt.SetParameterValue("conta_caixa", conta)
                report.cryRpt.SetParameterValue("data_factura", data_factura)
                report.cryRpt.SetParameterValue("numerario_recebido", mskValRecNumerario.Text)
                report.cryRpt.SetParameterValue("multibanco_recebido", mskValRecMultiBim.Text)

                report.cryRpt.SetParameterValue("cheque_recebido", mskValRecCheque.Text)
                report.cryRpt.SetParameterValue("devolucao_recebido", mskValRecSenhasCabazes.Text)
                report.cryRpt.SetParameterValue("entrada_recebido", mskValRecEntradaCaixa.Text)
                report.cryRpt.SetParameterValue("saida_recebido", mskValRecSaidaCaixa.Text)
                report.cryRpt.SetParameterValue("total_recebido", lblTotalRecebido_.Text)

                'conferidos
                report.cryRpt.SetParameterValue("numerario_conferido", mskValConfNumerario.Text)
                report.cryRpt.SetParameterValue("multibanco_conferido", mskValConfMultiBim.Text)

                report.cryRpt.SetParameterValue("cheque_conferido", mskValConfCheques.Text)
                report.cryRpt.SetParameterValue("devolucao_conferido", mskValConfSenhas.Text)
                report.cryRpt.SetParameterValue("entrada_conferido", mskValConfEntradaCaixa.Text)
                report.cryRpt.SetParameterValue("saida_conferido", mskValConfSaidaCaixa.Text)
                report.cryRpt.SetParameterValue("total_conferido", lblTotalConferido.Text)
                report.cryRpt.SetParameterValue("diario", (Me.txtDocInicio.Text + "0" & Me.txtDocFim.Text))
                report.cryRpt.SetParameterValue("numDocInicial", (Me.txtDocInicio.Text))
                report.cryRpt.SetParameterValue("numDocFinal", (Me.txtDocFim.Text))
                report.cryRpt.SetParameterValue("doc_serie", (Me.cboFacturaSerie.Text))

            Else
                report.cryRpt.SetParameterValue("diario", CInt(lblDiarioCaixa.Text))
                report.cryRpt.SetParameterValue("conta", Me.cboContaPos.SelectedItem)
                '        cryRpt.SetParameterValue("Diario", getDiario())
            End If

            report.CrystalReportViewer1.ReportSource = report.cryRpt

            report.CrystalReportViewer1.Refresh()
            report.ShowDialog()

        End If
    End Sub

    Private Sub EntrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntrarToolStripMenuItem.Click

        Entrar.ShowDialog(Me)
    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click
        If (utilizador_logado.getLogado() = True) Then
            If (utilizador_logado.getNivel() = administracao.super Or utilizador_logado.getNivel() = administracao.administrador) Then
                registrar.ShowDialog(Me)

            Else

                MessageBox.Show("Somente o Utilizador autorizado pode registrar?", "Atenção", MessageBoxButtons.OK)

            End If
        Else
            If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Entrar.ShowDialog(Me)
            End If

        End If

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function


    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function


    Private Sub preencherCabecalho(movimento, valor)
        Dim checkDiferenca As Double


        If (check_numerario_mov(movimento)) Then

            Me.numerarioConferidoTotal += CDbl(valor)
            Me.mskValConfNumerario.Text = Me.numerarioConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfNumerario.Text) - CDbl(Me.mskValRecNumerario.Text)
            Me.mskDiferencaNumerario.Text = checkDiferenca

            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdNumerario.ForeColor = Color.Red
                Me.lblEstdNumerario.Text = "Valor a Menos"
            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdNumerario.ForeColor = Color.Black
                Me.lblEstdNumerario.Text = "Correcto"
            Else
                Me.lblEstdNumerario.ForeColor = Color.Green
                Me.lblEstdNumerario.Text = "Valor a Mais"

            End If


        ElseIf (check_cheque_mov(movimento)) Then

            Me.chequeConferidoTotal += CDbl(valor)
            Me.mskValConfCheques.Text = Me.chequeConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfCheques.Text) - CDbl(Me.mskValRecCheque.Text)
            Me.mskDiferencaCheque.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdCheques.ForeColor = Color.Red
                Me.lblEstdCheques.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdCheques.ForeColor = Color.Black
                Me.lblEstdCheques.Text = "Correcto"

            Else
                Me.lblEstdCheques.ForeColor = Color.Green
                Me.lblEstdCheques.Text = "Valor a Mais"

            End If

        ElseIf (check_multibanco_mov(movimento)) Then

            Me.multibancoConferidoTotal += CDbl(valor)
            Me.mskValConfMultiBim.Text = Me.multibancoConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfMultiBim.Text) - CDbl(Me.mskValRecMultiBim.Text)
            Me.mskDiferencaMultiBim.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdPagamentoAutomatico.ForeColor = Color.Red
                Me.lblEstdPagamentoAutomatico.Text = "Valor a Menos"

            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdPagamentoAutomatico.ForeColor = Color.Black
                Me.lblEstdPagamentoAutomatico.Text = "Correcto"

            Else
                Me.lblEstdPagamentoAutomatico.ForeColor = Color.Green
                Me.lblEstdPagamentoAutomatico.Text = "Valor a Mais"


            End If


        ElseIf (check_entrada_caixa_mov(movimento)) Then

            Me.entradaConferidoTotal += CDbl(valor)
            Me.mskValConfEntradaCaixa.Text = Me.entradaConferidoTotal

            checkDiferenca = CDbl(Me.mskValConfEntradaCaixa.Text) - CDbl(Me.mskValRecEntradaCaixa.Text)
            Me.mskDiferencaEntradaCaixa.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdEntradaCaixa.ForeColor = Color.Red
                Me.lblEstdEntradaCaixa.Text = "Valor a Menos"
            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdEntradaCaixa.ForeColor = Color.Black
                Me.lblEstdEntradaCaixa.Text = "Correcto"
            Else
                Me.lblEstdEntradaCaixa.ForeColor = Color.Green
                Me.lblEstdEntradaCaixa.Text = "Valor a Mais"

            End If

        ElseIf (check_saida_caixa_mov(movimento)) Then

            Me.saidaConferidoTotal += CDbl(valor)
            Me.mskValConfSaidaCaixa.Text = Me.saidaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfSaidaCaixa.Text) + CDbl(Me.mskValRecSaidaCaixa.Text)
            Me.mskDiferencaSaidaCaixa.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdSaidaCaixa.ForeColor = Color.Red
                Me.lblEstdSaidaCaixa.Text = "Valor a Menos"
            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdSaidaCaixa.ForeColor = Color.Black
                Me.lblEstdSaidaCaixa.Text = "Correcto"
            Else
                Me.lblEstdSaidaCaixa.ForeColor = Color.Green
                Me.lblEstdSaidaCaixa.Text = "Valor a Mais"

            End If
        ElseIf (check_pagamento_caixa_mov(movimento)) Then

            Me.outrosConferidoTotal += CDbl(valor)
            If (CDbl(Me.outrosConferidoTotal) > 0) Then
                Me.outrosConferidoTotal = Me.outrosConferidoTotal * -1
            End If
            Me.mskValConfSenhas.Text = Me.outrosConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfSenhas.Text) + CDbl(Me.mskValRecSenhasCabazes.Text)
            Me.mskDiferencaSenhasCabazes.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdSenhas.ForeColor = Color.Red
                Me.lblEstdSenhas.Text = "Valor a Menos"
            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdSenhas.ForeColor = Color.Black
                Me.lblEstdSenhas.Text = "Correcto"
            Else
                Me.lblEstdSenhas.ForeColor = Color.Green
                Me.lblEstdSenhas.Text = "Valor a Mais"

            End If

        ElseIf (check_abertura_caixa_mov(movimento)) Then

            Me.aberturaConferidoTotal += CDbl(valor)
            Me.mskValConfAbertura.Text = Me.aberturaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfAbertura.Text) - CDbl(Me.mskValRecAbertura.Text)
            Me.mskDiferencaAbertura.Text = checkDiferenca
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            If (checkDiferenca < 0) Then
                Me.lblEstdSaldoAbert.ForeColor = Color.Red
                Me.lblEstdSaldoAbert.Text = "Valor a Menos"
            ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
                Me.lblEstdSaldoAbert.ForeColor = Color.Black
                Me.lblEstdSaldoAbert.Text = "Correcto"
            Else
                Me.lblEstdSaldoAbert.ForeColor = Color.Green
                Me.lblEstdSaldoAbert.Text = "Valor a Mais"

            End If

        End If


    End Sub


    Private Sub bloquearEdicao()
        Me.btnConfereAdicionar.Enabled = False
        Me.btnConfereLimpar.Enabled = False
        Me.btnFecharConta.Enabled = False
        Me.btnLimparTabela.Enabled = False
        trancarLinhaFechoConta()
    End Sub

    Private Sub desbloquearEdicao()
        Me.btnConfereAdicionar.Enabled = True
        Me.btnConfereLimpar.Enabled = True
        Me.btnFecharConta.Enabled = True
        Me.btnLimparTabela.Enabled = True
        Me.tabelaConferenciaCaixa.Enabled = True
        destrancarLinhaFechoConta()
    End Sub


    Private Sub previsualizar_reporte()

    End Sub

    Private Sub ConexaoBaseDeDadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexaoBaseDeDadosToolStripMenuItem.Click

        If (utilizador_logado.getLogado() = True) Then
            If (utilizador_logado.getNivel() = administracao.super) Then
                Conexaobd.ShowDialog(Me)

            Else

                MessageBox.Show("Somente o super administrador pode configurar a base de dados. Entre em contacto ?", "Atenção", MessageBoxButtons.OK)

            End If
        Else
            If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Entrar.ShowDialog(Me)
            End If

        End If
    End Sub

    Private Sub LicenciarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicenciarToolStripMenuItem.Click

        If (utilizador_logado.getLogado() = True) Then
            If (utilizador_logado.getNivel() = administracao.super Or utilizador_logado.getNivel() = administracao.administrador) Then


                LicencaControlo.ShowDialog(Me)

            Else

                MessageBox.Show("Somente o Utilizador autorizado pode Licenciar?. Entre em contacto com o administrador", "Atenção", MessageBoxButtons.OK)

            End If
        Else
            If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Entrar.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Function check_conferencia_caixa() As Boolean
        Dim ok_abertura, ok_numerario, ok_cheque, ok_banco, ok_entrada, ok_saida As Boolean
        ok_abertura = ok_banco = ok_cheque = ok_entrada = ok_numerario = ok_saida = False


        If (CDbl(Me.mskValRecAbertura.Text) > 0) And (CDbl(Me.mskDiferencaAbertura.Text) <> 0) Then
            ok_abertura = False
        Else
            ok_abertura = True
        End If

        If (CDbl(Me.mskValRecNumerario.Text) > 0) And (CDbl(Me.mskDiferencaNumerario.Text) <> 0) Then
            ok_numerario = False
        Else
            ok_numerario = True

        End If
        If (CDbl(Me.mskValRecCheque.Text) > 0) And (CDbl(Me.mskDiferencaCheque.Text) <> 0) Then
            ok_cheque = False
        Else
            ok_cheque = True

        End If
        If (CDbl(Me.mskValRecEntradaCaixa.Text) > 0) And (CDbl(Me.mskDiferencaEntradaCaixa.Text) <> 0) Then
            ok_entrada = False
        Else
            ok_entrada = True

        End If

        If (CDbl(Me.mskValRecSaidaCaixa.Text) > 0) And (CDbl(Me.mskDiferencaSaidaCaixa.Text) <> 0) Then
            ok_saida = False
        Else
            ok_saida = True

        End If

        If (CDbl(Me.mskValRecMultiBim.Text) > 0) And (CDbl(Me.mskDiferencaMultiBim.Text) <> 0) Then
            ok_banco = False
        Else
            ok_banco = True

        End If


        If (ok_abertura And ok_banco And ok_cheque And ok_entrada And ok_numerario And ok_saida) Then
            Return True
        End If

        Return False
    End Function

    Public Function changeEstado(valor1 As Double, valor2 As Double) As Estado
        Dim checkDiferenca As Double = valor1 - valor2
        Dim estado_cls As New Estado
        estado_cls.valor_str = checkDiferenca
        'If (checkDiferenca < 0) Then
        '    estado_cls.valor_str = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        'Else
        '    estado_cls.valor_str = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
        'End If


        If (checkDiferenca < 0) Then
            estado_cls.cor = Color.Red
            estado_cls.texto = "Valor a Menos"
        ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
            estado_cls.cor = Color.Black
            estado_cls.texto = "Correcto"
        Else
            estado_cls.cor = Color.Green
            estado_cls.texto = "Valor a Mais"

        End If

        Return estado_cls
    End Function


    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click

        Me.Close()
    End Sub

    Private Sub carregar_valor()
        Dim estado_cls As Estado


        'Para valor abertura    
        estado_cls = changeEstado(Me.mskValConfAbertura.Text, Me.mskValRecAbertura.Text)
        Me.mskDiferencaAbertura.Text = estado_cls.valor_str
        Me.lblEstdSaldoAbert.Text = estado_cls.texto
        Me.lblEstdSaldoAbert.ForeColor = estado_cls.cor

        'Para valor numerario    
        estado_cls = changeEstado(Me.mskValConfNumerario.Text, Me.mskValRecNumerario.Text)
        Me.mskDiferencaNumerario.Text = estado_cls.valor_str
        Me.lblEstdNumerario.Text = estado_cls.texto
        Me.lblEstdNumerario.ForeColor = estado_cls.cor


        'Para valor banco    
        estado_cls = changeEstado(Me.mskValConfMultiBim.Text, Me.mskValRecMultiBim.Text)
        Me.mskDiferencaMultiBim.Text = estado_cls.valor_str
        Me.lblEstdPagamentoAutomatico.Text = estado_cls.texto
        Me.lblEstdPagamentoAutomatico.ForeColor = estado_cls.cor

        'Para valor cheques    
        estado_cls = changeEstado(Me.mskValConfCheques.Text, Me.mskValRecCheque.Text)
        Me.mskDiferencaCheque.Text = estado_cls.valor_str
        Me.lblEstdCheques.Text = estado_cls.texto
        Me.lblEstdCheques.ForeColor = estado_cls.cor

        'Para valor Senhas    
        estado_cls = changeEstado(Me.mskValConfSenhas.Text, Me.mskValRecSenhasCabazes.Text)
        Me.mskDiferencaSenhasCabazes.Text = estado_cls.valor_str
        Me.lblEstdSenhas.Text = estado_cls.texto
        Me.lblEstdSenhas.ForeColor = estado_cls.cor

        'Para valor entrada    
        estado_cls = changeEstado(Me.mskValConfEntradaCaixa.Text, Me.mskValRecEntradaCaixa.Text)
        Me.mskDiferencaEntradaCaixa.Text = estado_cls.valor_str
        Me.lblEstdEntradaCaixa.Text = estado_cls.texto
        Me.lblEstdEntradaCaixa.ForeColor = estado_cls.cor


        'Para valor Saida    
        estado_cls = changeEstado(Me.mskValConfSaidaCaixa.Text, Me.mskValRecSaidaCaixa.Text)
        Me.mskDiferencaSaidaCaixa.Text = estado_cls.valor_str
        Me.lblEstdSaidaCaixa.Text = estado_cls.texto
        Me.lblEstdSaidaCaixa.ForeColor = estado_cls.cor




    End Sub



    Private Sub mskSaldoAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskSaldoAbertura.TextChanged


        Try
            'Me.mskSaldoAbertura.Text = FormatCurrency(Me.mskSaldoAbertura.Text).TrimStart("$")
            mskSaldoAbertura.Text = utilitario.soNumero(mskSaldoAbertura.Text)
        Catch ex As Exception

        End Try


    End Sub



    Private Sub SistemaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SistemaToolStripMenuItem1.Click
        ClienteForm.ShowDialog(Me)


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub VerificarNovaVerãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificarNovaVerãoToolStripMenuItem.Click
        loading.ShowDialog(Me)

    End Sub

    Private Sub initBaseDados()
        Dim administrador As New ConferenciaAdmin

        If (administrador.criarTblLicenca() = True) Then
            MsgBox("Licenca criado sucesso")
        Else
            MsgBox("Licenca criado falha")

        End If

        If (administrador.criarTblConferenciaUtilizador() = True) Then
            MsgBox("Utilizador criado sucesso")
        Else
            MsgBox("Utilizador criado sem sucesso")

        End If
        If (administrador.criarTblConferenciaCaixa() = True) Then
            MsgBox("caixa criado sucesso")
        Else
            MsgBox("caixa criado falha")

        End If
    End Sub

    '***
    ' Proposito - Inicializar o programa. verificar se todos componentes dependentes estao em funcionamento antes de inicializar 
    '              o Sistema para o uso  
    '
    ' Retorno - Sem retorno
    '***

    Private Sub init()
        initBaseDados()


    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        pnlMensagemLicenca.Visible = False
    End Sub


    Public Sub setLogado(user As Utilizador)
        Me.utilizador_logado = user
        If (user.getLogado()) Then
            Me.rodape.Text = "Sessão Aberto: " + utilizador_logado.getNome() + " - " + utilizador_logado.getNivel()

            Dim licenca As String = administracao.buscarUtilizadorLicenca(user.getNome())

            If administracao.LicencaDiasExpiracao(licenca) >= 0 Then


                Me.txtCaixaNum.Enabled = True
                Me.cboModoRecebido.Items.Add("Selecionar movimento")
                Me.cboModoRecebido.SelectedIndex = 0

                preencher_tipo_movimento()
                trancarLinhaFechoConta()
                limpar_campos()
            Else
                ' MessageBox.Show("Usuario possui licenca expirado! Entrea em contacto com o administrador.")
            End If
        Else
            Me.txtCaixaNum.Enabled = False
            Me.cboModoRecebido.Items.Clear()
            Me.cboModoRecebido.Text = ""
            Me.txtUtilizadorConferencia.Text = ""
            'Me.cboReferenciaModoReceb.Items.Clear()
            cboReferenciaModoReceb.Text = ""
            trancarLinhaFechoConta()
            limpar_campos()
            Me.rodape.Text = "Sessão Não Iniciado"

        End If
    End Sub

    Private Sub MovimentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimentosToolStripMenuItem.Click
        ConfigMovimentos.ShowDialog(Me)
        carregarConfiguracao()
    End Sub


    Private Sub UtilizadorCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilizadorCaixaToolStripMenuItem.Click
        CaixaPerfil.Show(Me)
    End Sub

    Private Sub rodape_Click(sender As Object, e As EventArgs) Handles rodape.Click

    End Sub

    Public Function getLogado() As Utilizador
        Return Me.utilizador_logado
    End Function

    Private Function sair_sistema() As Boolean
        Dim rv As Boolean
        Try
            administracao.setUtilizadorLogado(utilizador_logado.getNome(), "", 0)
            Me.setLogado(New Utilizador())
            rv = True
            Me.rodape.Text = "Sessão Encerrado"

        Catch ex As Exception
            rv = False
        End Try

        Return rv
    End Function


    Sub reset()
        aberturaTotal = 0

        entradaTotal = 0

        saidaTotal = 0
        multibancoTotal = 0
        numerarioTotal = 0
        chequeTotal = 0
        aberturaTotal = 0

        multibancoConferidoTotal = 0
        chequeConferidoTotal = 0
        numerarioConferidoTotal = 0
        saidaConferidoTotal = 0
        entradaConferidoTotal = 0
        aberturaConferidoTotal = 0
    End Sub

    Private Sub cboContaPos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContaPos.SelectedIndexChanged


        If Me.cboContaPos.SelectedIndex > 0 Then

            Dim result As Integer

            reset()

            'If (txtCaixaNum.Text.Length <= 0 And Me.cboContaPos.SelectedItem <> "CXMT") Then
            '    Return
            'End If



            limpar_campo_fechoconta()
            If (tabelaConferenciaCaixa.Rows.Count > 1 And DIARIO_CONFERIDO = False) Then
                result = MessageBox.Show("Conferência de conta já iniciado, se continuar os dados lançados serão perdidos. Continuar ? ", "Atenção", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    If Me.cboContaPos.SelectedItem = "CXMT" Then
                        Me.dtInicio.Visible = True
                        Me.txtCaixaNum.Visible = False
                        txtUtilizadorFecho.Enabled = True
                        'buscarCaixaFactura()
                    Else
                        Me.dtInicio.Visible = False
                        Me.txtCaixaNum.Visible = True
                        txtUtilizadorFecho.Enabled = False
                        'buscarCaixa()

                    End If

                    'Else
                    '    Me.txtCaixaNum.Text = diarioCaixaCurrente
                End If
            Else

                If Me.cboContaPos.SelectedItem = "CXMT" Then
                    Me.dtInicio.Visible = True
                    Me.txtCaixaNum.Visible = False
                    txtUtilizadorFecho.Enabled = True
                    Me.cboFacturaSerie.Visible = True
                    Me.lblDocFim.Visible = True
                    Me.lblDocInicio.Visible = True
                    Me.txtDocFim.Visible = True
                    Me.txtDocInicio.Visible = True
                    Dim serie As List(Of String) = New List(Of String)

                    serie = administracao.buscarSerie()
                    serie.Insert(0, "Selecionar")
                    Me.cboFacturaSerie.DataSource = serie


                    'buscarCaixaFactura()
                Else
                    Me.dtInicio.Visible = False
                    Me.txtCaixaNum.Visible = True
                    txtUtilizadorFecho.Enabled = False
                    Me.cboFacturaSerie.Visible = False
                    Me.lblDocFim.Visible = False
                    Me.lblDocInicio.Visible = False
                    Me.txtDocFim.Visible = False
                    Me.txtDocInicio.Visible = False

                    'buscarCaixa()

                End If

            End If
        End If
    End Sub

    Function is_row_valid(line As Integer) As Boolean
        Dim movimento As String
        Dim rv As Boolean = False
        movimento = tabelaConferenciaCaixa.Rows(line).Cells(0).Value

        If check_abertura_caixa_mov(movimento) Or check_cheque_mov(movimento) Or
            check_entrada_caixa_mov(movimento) Or check_multibanco_mov(movimento) Or
            check_numerario_mov(movimento) Or check_saida_caixa_mov(movimento) Or
            check_pagamento_caixa_mov(movimento) Then
            rv = True
        Else
            rv = False
        End If


        Return rv

    End Function

    Private Sub mskValorRecebido_KeyUp(sender As Object, e As KeyEventArgs) Handles mskValorRecebido.KeyUp
        '  ContinuousFormat(Me.mskValorRecebido)
    End Sub


    Sub buscarDiarioCaixa()


        Dim result As Integer


        reset()

        If Me.cboContaPos.SelectedItem <> "CXMT" Then
            Dim digitsOnly As Regex = New Regex("[^\d]")
            txtCaixaNum.Text = digitsOnly.Replace(txtCaixaNum.Text, "")
            If (txtCaixaNum.Text.Length <= 0) Then
                Return
            End If

        End If

        limpar_campo_fechoconta()
        ' Dim idCabecTesouraria As String
        If (tabelaConferenciaCaixa.Rows.Count > 1 And DIARIO_CONFERIDO = False) Then
            result = MessageBox.Show("Conferência de conta já iniciado, se continuar os dados lançados serão perdidos. Continuar ? ", "Atenção", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                If Me.cboContaPos.SelectedItem <> "CXMT" Then

                    buscarCaixa()
                Else
                    buscarCaixaFactura()
                End If
                'Else
                '    Me.txtCaixaNum.Text = diarioCaixaCurrente
            End If
        Else
            If Me.cboContaPos.SelectedItem <> "CXMT" Then

                buscarCaixa()
            Else
                buscarCaixaFactura()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If (utilizador_logado.getLogado() = True) Then
            If (Me.cboContaPos.SelectedIndex > 0) Then
                If Me.cboContaPos.SelectedItem <> "CXMT" Then

                    buscarCaixa()
                Else
                    If (Me.cboFacturaSerie.SelectedIndex > 0) Then

                        buscarCaixaFactura()
                    Else

                        MessageBox.Show("Selecione a serie  ", "Atencao", MessageBoxButtons.OK)
                    End If
                End If
                    Else
                MessageBox.Show("Selecione a Conta Caixa", "Atencao", MessageBoxButtons.OK)
            End If
        Else
            naoLogado()
            If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Entrar.ShowDialog(Me)
            End If
        End If

    End Sub

    Private Sub FiltrarDiarioCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        CaixaDiarioConferido.ShowDialog(Me)
    End Sub

    Private Sub ConferênciaDeCaixaTotaisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConferênciaDeCaixaTotaisToolStripMenuItem.Click
        FiltroConferencia.ShowDialog(Me)
    End Sub

    Private Sub mskValRecSenhasCabazes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskValRecSenhasCabazes.KeyPress
        e.Handled = True

    End Sub

    Private Sub mskValConfSenhas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskValConfSenhas.KeyPress
        e.Handled = True

    End Sub





    Private Sub chkEditar_CheckedChanged_2(sender As Object, e As EventArgs) Handles chkEditar.CheckedChanged
        If utilizador_logado.getNivel() <> "Tesoureiro" Then

            If chkEditar.Checked = True Then
                DIARIO_CONFERIDO = False
                Me.btnConfereAdicionar.Text = "Adicionar"
                desbloquearEdicao()

            Else

                DIARIO_CONFERIDO = True
                Me.btnConfereAdicionar.Text = "Remover"
                ' destranca
            End If
        End If
    End Sub

    Private Sub ConferenciaCaixa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If (Me.sair_sistema() = False) Then
            MessageBox.Show("Não foi possivel fechar alguns serviços em execução", "Atenção", MessageBoxButtons.OK)
        End If
    End Sub


    Function reverter_str(str As String) As String

        Dim _str As String = str.Split("-")(2) ' ano
        _str = _str & "-" & str.Split("-")(1) ' ano
        _str = _str & "-" & str.Split("-")(0) ' ano


        Return _str
    End Function

    Sub carregarConfiguracao()

        Dim lista_mov As Movimentos
        Dim geral As New Movimento()
        Dim mov As List(Of String) = New List(Of String)
        lista_mov = js.getListaMovimento()
        Dim max As Integer = lista_mov.lista.Count()
        Dim data As String
        Dim i As Integer
        For i = 0 To max - 1

            mov.Clear()
            geral = lista_mov.lista(i)
            If (geral.tipoMovimento = "numerario") Then
                numerario_mov = geral
                For Each data In numerario_mov.codigo.ToArray()
                    mov.Add(data)
                    numerarioMov = mov.ToArray()
                Next
            ElseIf (geral.tipoMovimento = "pagamento automatico") Then
                pagamentoAutomatico_mov = geral
                For Each data In pagamentoAutomatico_mov.codigo.ToArray()
                    mov.Add(data)
                    multibancoMov = mov.ToArray()
                Next


            ElseIf (geral.tipoMovimento = "cheque") Then
                cheque_mov = geral
                For Each data In cheque_mov.codigo.ToArray()
                    mov.Add(data)
                    chequeMov = mov.ToArray()
                Next

            ElseIf (geral.tipoMovimento = "outros") Then
                outros_mov = geral
                For Each data In outros_mov.codigo.ToArray()
                    mov.Add(data)
                    outrosMov = mov.ToArray()
                Next

            ElseIf (geral.tipoMovimento = "saida caixa") Then
                saida_mov = geral
                For Each data In saida_mov.codigo.ToArray()
                    mov.Add(data)
                    saidaMov = mov.ToArray()
                Next

            End If

        Next
        getContaBancaria()

    End Sub



    Sub getDescricaoMovimento()
        cboModoRecebido.Items.Clear()
        cboModoRecebido.Items.Add("Selecionar")
        Dim lista_mov As Movimentos
        Dim geral As New Movimento()
        lista_mov = js.getListaMovimento()
        Dim max As Integer = lista_mov.lista.Count()
        Dim maxDesc As Integer
        Dim i As Integer
        Dim j As Integer
        For i = 0 To max - 1
            geral = lista_mov.lista(i)
            maxDesc = geral.descricao.Count()
            For j = 0 To maxDesc - 1
                cboModoRecebido.Items.Add(geral.descricao(j))
            Next
        Next




    End Sub

    Private Sub tabelaConferenciaCaixa_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles tabelaConferenciaCaixa.RowPrePaint

    End Sub

    Private Sub mskValorRecebido_Leave(sender As Object, e As EventArgs) Handles mskValorRecebido.Leave
        Me.mskValorRecebido.Text = utilitario.soNumero(Me.mskValorRecebido.Text)
    End Sub

    Private Sub txtDocInicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocInicio.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDocFim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocFim.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub getContaBancaria()
        Dim contas As List(Of String) = New List(Of String)

        contas = administracao.consultaColuna("select * from ContasBancarias where TipoConta = 5 or conta='CXMT'", "Conta")
        contas.Insert(0, "Selecionar Conta")
        cboContaPos.DataSource = contas

    End Sub

    'Inicio criarConfigFolder
    Private Sub criarConfigFolder()
        Directory.CreateDirectory(utilitario.dataPathConfig)
        Directory.CreateDirectory(utilitario.dataPathReport)

    End Sub
    'Fim criarConfigFolder


    Private Sub ContinuousFormat(ByVal text As MaskedTextBox)

        Dim a As Integer : Dim R As String

        For a = 1 To Len(text.Text)
            R = Mid(text.Text, a, 1)
            If R = "." Then Exit Sub


        Next



        If text.Text = "0" Then Exit Sub

        text.Text = Format(Val(Replace(text.Text, ",", "")), "#,###,###")

        If Len(text.Text) > 1 Then
            text.SelectionStart = Len(text.Text)
            text.SelectionLength = 0
        End If
    End Sub



    Public Sub naoLogado()
        limpar_campos()
        limpar_campo_fechoconta()
        tabelaConferenciaCaixa.Rows.Clear()
        trancarCartaoChequeInput()
        trancarLinhaFechoConta()
        trancarLinhaFechoConta_mov_local()
        MessageBox.Show("Utilizador Desconectado. Entre para continuar as actividades!")

    End Sub

    Public Function restoreCsvToDatabase(filename As String) As Object
        Dim js = New JavaScriptSerializer()
        js.MaxJsonLength = 999999999
        Dim db As Object = New Object()
        Dim count As Integer = 0
        If System.IO.File.Exists(filename) Then

            Dim jsStr As String = File.ReadAllText(filename)
            db = js.Deserialize(Of Object)(jsStr)
            Console.WriteLine("dentro")
            For i As Integer = 0 To db.length - 1

                Try

                    administracao.insertConferenciaCaixa(db(i)("diariocaixa"), db(i)("modomovimento"), db(i)("cartao"), db(i)("transacao"), db(i)("quantidade"),
                                              db(i)("valor"), db(i)("chequenum"), db(i)("chequedesc"), db(i)("data_conferencia"), db(i)("utilizador_tes"),
                                              db(i)("saidadesc"), db(i)("referencia"), db(i)("idCabec"), db(i)("conta"), db(i)("datafecho"), db(i)("datatransacao"), 0, 0, "")
                Catch ex As Exception
                    Console.WriteLine("Ocorreu um erro ")
                    Console.WriteLine(ex.Message())
                End Try

                Console.WriteLine(i)

            Next

            Console.WriteLine("Fim")

            Return db
        End If

        Return Nothing
    End Function

End Class



Public Class Estado

    Public cor As Color
    Public texto As String
    Public valor_str As String

End Class