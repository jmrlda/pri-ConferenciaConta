
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class ConferenciaCaixa
    Dim SQL As New sqlControlo
    Dim SQLPriEmpre As New sqlControloPriEmpre
    Dim DIARIO_CONFERIDO As Boolean = False
    Dim administracao As New ConferenciaAdmin
    Dim reporte As New crystalReport
    Dim utilitario As New Util

    ' flag informando se o usuario estado logado ou  nao
    Dim logado As Boolean = False
    Public utilizador_logado As New Utilizador


    'Idenficacao de cada tipo de movimento pelos codigos'
    Dim indiceFechoConta As Integer = 0
    Dim numerarioMov() As String = {"NUM", "RNUM"}
    Dim numerarioTotal As Double
    Dim numerarioConferidoTotal As Double
    Dim numerarioReferencia() As String = {"Selecionar", "1000.00", "500.00", "200.00", "100.00", "50.00", "20.00", "10.0", "5.00", "2.00", "1.00", "0.50"}

    Dim multibancoMov() As String = {"RCMR", "MB"}
    Dim multibancoTotal As Double
    Dim multibancoConferidoTotal As Double


    Dim chequeMov() As String = {"DEP", "RCHQ", "RCHPD"}
    Dim chequeTotal As Double
    Dim chequeConferidoTotal As Double

    Dim senhasCabazesMov() As String = {}
    Dim senhasCabazesTotal As Double
    Dim senhasCabazesConferidoTotal As Double
    Dim senhasCabazesReferencia() As String = {"Selecionar", "5000.00", "2000.00", "200.00", "100.00", "50.00"}


    Dim bancos As String() = {"Selecionar", "Millenium Bim", "Standard Bank", "Banco Unico"}
    Dim bancosCartaoTipo As String() = {"Selecionar", "Mastercard", "MBIM-Electron", "MBIM-visa", "Visa Moz", "Ponto 24", "Visa"}


    Dim aberturaTotal, aberturaConferidoTotal, entradaTotal, entradaConferidoTotal, saidaTotal, saidaConferidoTotal As Double

    Dim diarioCaixaCurrente As Integer

    Public ISCONEXAOCONFIGURADA As Boolean = False

    ' tipos de movimentos # MODO HARDCODE #'



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim js As New JmrJson

        'Verficar se a conexao a base de dados ja foi configurada
        If System.IO.File.Exists(js.CONEXAO_PATH) Then
            If System.IO.File.Exists(js.CLIENTE_PATH) Then

                startapp()
            Else

                ClienteForm.ShowDialog(Me)
            End If

        Else

            MessageBox.Show("conexão não configurada", "Atenção", MessageBoxButtons.OK)

            Conexaobd.ShowDialog(Me)
            If (ISCONEXAOCONFIGURADA = True) Then
                startapp()
            End If
        End If

        'ptxboxUtilizadorAberturaCaixa.ImageLocation = "C:\PRIMAVERA\SG900\DADOS\LP\Imagens\Utilizadores\default.jpg"
        'ptxboxUtilizadorAberturaCaixa.


    End Sub


    Public Sub startapp()
        Dim licencaDuracao As Integer = -1
        Dim licencaDuracao_str As String = ""
        Dim licencaUtilizadores As Integer = -1
        Dim licencaSistema As String = ""
        Dim licenca_encode As String = ""
        Dim dataInic, dataFim As String
        Dim superLicenca As String = "UIlM5q4Asz0jp0WmXsBfbGkj43YHKkToIqk8RH6rYHjay0iqevjQzPLWFz47XnblJWkPApjhtWHI8+sgPnpJJOaBt8Nb3iNRJQEVqklo3+YS6ecYzDyp9g6BKvRiyg/sHqMaBy3AjbChSripIDLQ4lRdAHxmwkWzz2zdgMnRDut5VlOkTehHuAW9azp1T5DL4B/3yEsS0MBV8QJbjrPZOih6tUlkn6knBbOawd/G2WobC4dt4+EVFAshDW42oSe1EQqG5MGv+Xnu9rcsf3TQdA=="
        Dim sucesso As Boolean = False
        Dim except_msg As String


        administracao.criarTblLicenca()
        administracao.criarTblConferenciaUtilizador()
        administracao.criarTblConferenciaCaixa()

        Dim licenca_decode As String = administracao.Decrypt(superLicenca)

        If (licenca_decode.Length > 0) Then
            Try

                licencaUtilizadores = licenca_decode.Split("_")(0)
                licencaSistema = licenca_decode.Split("_")(1)
                licencaDuracao_str = licenca_decode.Split("_")(2)
                dataInic = Date.Now().ToShortDateString
                dataFim = Date.Now().AddDays(utilitario.change_duracao_str_int(licencaDuracao_str)).ToShortDateString
                If administracao.existeLicencasBySerie(superLicenca) = False Then

                    administracao.insertLicenca(superLicenca, licencaUtilizadores, dataInic, dataFim)
                End If

                Dim id_licenca As String = administracao.buscarIdLicencasBySerie(superLicenca)
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
                End If

            Catch ex As Exception
                MessageBox.Show("Ocorreu um erro ao iniciar a aplicação", "Atenção", MessageBoxButtons.OK)
                Me.Close()
            End Try

        End If
    End Sub
    Private Sub MaskedTextBox13_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskValConfMultiBim.MaskInputRejected

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        caixaDiaria.ShowDialog(Me)

    End Sub





    Private Function limpar_campo_fechoconta() As Integer
        If (is_multibanco_mov() Or is_cheque_mov()) Then
            'Me.cboCartaoTipo.SelectedIndex = 0
        End If
        'Me.txtTransacaoNumero.Text = ""
        cboCartaoTipo.Text = ""
        Me.cboModoRecebido.SelectedItem = ""
        Me.cboReferenciaModoReceb.Text = ""
        Me.txtQuantidade.Text = ""
        Me.mskValorRecebido.Text = 0


        Return 0

    End Function




    Private Sub preencher_tipo_movimento()
        'Dim qrTipoMov As String = "select Descricao from DocumentosBancos where Descricao like 'rec.%'"
        Dim qrTipoMov As String = "select Descricao from DocumentosBancos where Descricao like 'rec.%' or Descricao = 'Diversos a débito' or Descricao = 'Diversos a crédito' or Descricao = 'Saldo abertura'"
        Dim tabelaMov As New DataTable
        tabelaMov = SQL.buscarDado(qrTipoMov)
        If (tabelaMov.Rows.Count <> 0) Then
            For i As Integer = 0 To tabelaMov.Rows.Count - 1
                If (cboModoRecebido.Items.IndexOf(tabelaMov.Rows(i)("Descricao")) = -1) Then
                    cboModoRecebido.Items.Add(tabelaMov.Rows(i)("Descricao"))
                End If
            Next
        End If

    End Sub

    Private Sub preencher_movimento_referencia(movimento)
        'Me.lblFechoContaReferencia.Text = "Referência"
        'Me.lblFechoContaQuantidade.Text = "Quantidade"

        Me.cboReferenciaModoReceb.DataSource = {"selecionar referencia"}
        Me.cboReferenciaModoReceb.SelectedIndex = 0
        If (movimento = "Rec. em Numerário" Or movimento = "Rec. Numerario (NAO USAR)") Then
            Me.lblFechoContaQuantidade.Text = "Quantidade"
            Me.lblFechoContaCartaoChequeDesc.Text = ""
            Me.lblFechoContaReferencia.Text = "Referência Numerário"

            Me.cboReferenciaModoReceb.DataSource = numerarioReferencia
            Me.cboCartaoTipo.DataSource = {}
            'destrancarLinhaFechoConta_mov_local()
            destrancarNumerario_mov()
            trancarCartaoChequeInput()


        ElseIf (movimento = "Rec. Multi Rede" Or movimento = "Rec. por Multibanco") Then
            Me.lblFechoContaQuantidade.Text = "Transação Número"
            Me.lblFechoContaCartaoChequeDesc.Text = "Cartão Tipo"
            Me.lblFechoContaReferencia.Text = "Referência Banco"

            'Me.txtQuantidade.Enabled = False
            Me.cboReferenciaModoReceb.DataSource = bancos
            'Me.cboReferenciaModoReceb
            Me.cboCartaoTipo.DataSource = bancosCartaoTipo

            Me.lblFechoContaReferencia.Text = "POS Banco"
            'destrancarCartaoChequeInput()
            destrancarLinhaFechoConta_mov_local()


        ElseIf (movimento = "Rec. por Cheque (PD)" Or movimento = "Rec. por Cheque") Then
            Me.lblFechoContaReferencia.Text = "Referência Banco"
            Me.lblFechoContaQuantidade.Text = "Cheque Número"
            Me.lblFechoContaCartaoChequeDesc.Text = "Cheque Descricão / Cliente"

            Me.txtQuantidade.Enabled = True

            Me.cboReferenciaModoReceb.DataSource = bancos
            'Me.cboCartaoTipo.Enabled = False
            Me.cboCartaoTipo.DataSource = {}
            'destrancarCartaoChequeInput()
            destrancarLinhaFechoConta_mov_local()

        ElseIf (check_entrada_caixa_mov(movimento) Or check_saida_caixa_mov(movimento) Or check_abertura_caixa_mov(movimento)) Then
            Me.lblFechoContaReferencia.Text = ""
            Me.lblFechoContaQuantidade.Text = ""
            Me.lblFechoContaCartaoChequeDesc.Text = ""
            trancarLinhaFechoConta_mov_local()
            If (check_saida_caixa_mov(movimento)) Then
                Me.cboReferenciaModoReceb.Enabled = True
                Me.lblFechoContaReferencia.Text = "Descrição Saida Caixa"
                Me.cboReferenciaModoReceb.Text = ""


            End If


        End If

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnConfereAdicionar.Click
        If (DIARIO_CONFERIDO = True) Then
            If MessageBox.Show("Tem a certeza que deseja remover os dados da conferência?", "Atenção - Perigo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try

                    If (administracao.removeLinhasCaixa(Me.txtCaixaNum.Text) = True) Then
                        MessageBox.Show("Linhas de Conferência de Caixa  removidos com sucesso", "Informação", MessageBoxButtons.OK)
                        btnPrevisualizarReporte.Enabled = False

                        limpar_campos()
                        limpar_campo_fechoconta()
                        trancarCartaoChequeInput()


                        trancarLinhaFechoConta()
                        trancarLinhaFechoConta_mov_local()
                        Me.btnConfereAdicionar.Text = "Adicionar"
                        buscarCaixa()

                    Else
                        MessageBox.Show("Falha na remoção das linhas de Conferência de Caixa. Se persistir entre em contacto com o administrador", "Informação", MessageBoxButtons.OK)

                    End If
                Catch ex As Exception
                    'MessageBox.Show("Falha na remoção das linhas de Conferência de Caixa. Se persistir entre em contacto com o administrador", "Informação", MessageBoxButtons.OK)

                End Try

            End If
        Else



            '      Dim conta As DataGrid
            Dim checkDiferenca As Double

            Dim linha_valor_confirmado As Boolean = False
            'If (Me.cboModoRecebido.SelectedIndex <> 0 And Me.cboReferenciaModoReceb.SelectedIndex <> 0 And Me.txtQuantidade.Text.Length > 0 And Me.mskValorRecebido.Text.Length > 0) Then
            If (is_abertura_caixa_mov() Or is_cheque_mov() Or is_entrada_caixa_mov() Or is_multibanco_mov() Or is_numerario_mov() Or is_saida_caixa_mov()) Then

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
                            If (checkDiferenca < 0) Then
                                Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            Else
                                Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            End If

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
                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", "", "", Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True

                        End If
                    End If

                ElseIf (is_cheque_mov()) Then
                    If (cboModoRecebido.SelectedIndex > 0 And cboReferenciaModoReceb.SelectedIndex > 0 And txtQuantidade.Text.Length > 0 And cboCartaoTipo.Text.Length > 0 And mskValorRecebido.Text.Length > 0) Then
                        Dim idx As Integer = is_lancamento_cheque_redundante()
                        If (idx >= 0) Then
                            MsgBox("Cheque Numero " + txtQuantidade.Text + " ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                        Else
                            Me.chequeConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                            Me.mskValConfCheques.Text = Me.chequeConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfCheques.Text) - CDbl(Me.mskValRecCheque.Text)
                            If (checkDiferenca < 0) Then
                                Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            Else
                                Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            End If

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
                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, cboCartaoTipo.Text, Me.txtQuantidade.Text, "", 1, Me.mskValorRecebido.Text})
                            linha_valor_confirmado = True
                            btnFecharConta.Enabled = True

                        End If
                    End If
                ElseIf (is_multibanco_mov()) Then
                    If (cboModoRecebido.SelectedIndex > 0 And cboReferenciaModoReceb.SelectedIndex > 0 And txtQuantidade.Text.Length > 0 And cboCartaoTipo.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0) Then
                        Dim idx As Integer = is_lancamento_multibanco_redundante()
                        If (idx >= 0) Then
                            MsgBox("Transação Numero " + txtQuantidade.Text + " ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                        Else
                            Me.multibancoConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                            Me.mskValConfMultiBim.Text = Me.multibancoConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfMultiBim.Text) - CDbl(Me.mskValRecMultiBim.Text)
                            If (checkDiferenca < 0) Then
                                Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            Else
                                Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            End If

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

                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, Me.cboCartaoTipo.Text, Me.txtQuantidade.Text, "", 1, Me.mskValorRecebido.Text})

                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True

                        End If
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
                            If (checkDiferenca < 0) Then
                                Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            Else
                                Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            End If

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
                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", "", "", Me.mskValorRecebido.Text})
                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True

                        End If
                    End If
                ElseIf (is_saida_caixa_mov()) Then
                    If (cboModoRecebido.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0) Then
                        Dim idx As Integer = is_lancamento_saida_redundante()
                        If (idx >= 0) Then
                            MsgBox("Saida de Caixa Ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                        Else
                            Me.saidaConferidoTotal -= CDbl(Me.mskValorRecebido.Text)
                            Me.mskValConfSaidaCaixa.Text = Me.saidaConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfSaidaCaixa.Text) + CDbl(Me.mskValRecSaidaCaixa.Text)

                            If (checkDiferenca < 0) Then
                                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            Else
                                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            End If

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
                            If valor > 0 Then
                                valor *= -1
                            End If

                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", cboReferenciaModoReceb.Text, "", valor})
                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True

                        End If
                    End If
                ElseIf (is_abertura_caixa_mov()) Then
                    If (cboModoRecebido.SelectedIndex > 0 And mskValorRecebido.Text.Length > 0) Then
                        Dim idx As Integer = is_lancamento_abertura_redundante()
                        If (idx >= 0) Then
                            MsgBox("Abertura de Caixa Ja conferido. Edite a linha  nº " + (idx + 1).ToString() + "  para actualizar")
                        Else
                            Me.aberturaConferidoTotal += CDbl(Me.mskValorRecebido.Text)
                            Me.mskValConfAbertura.Text = Me.aberturaConferidoTotal
                            checkDiferenca = CDbl(Me.mskValConfAbertura.Text) - CDbl(Me.mskValRecAbertura.Text)
                            If (checkDiferenca < 0) Then
                                Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                            Else
                                Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                            End If

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
                            tabelaConferenciaCaixa.Rows.Add(New String() {Me.cboModoRecebido.SelectedItem, "", "", "", "", "", Me.mskValorRecebido.Text})
                            btnFecharConta.Enabled = True
                            linha_valor_confirmado = True


                        End If
                    End If

                    If (linha_valor_confirmado) Then

                        limpar_campo_fechoconta()
                        'Me.indiceFechoConta += 1
                    End If
                End If
                limpar_campo_fechoconta()

            End If
            calcularTotalConferido_diferenca()

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
        If (txtCaixaNum.Text.Length <= 0) Then
            Return
        End If
        Dim refer As Double
        Try

            If (is_numerario_mov() And IsNumeric(Me.cboReferenciaModoReceb.Text)) Then
                refer = Me.cboReferenciaModoReceb.SelectedItem
                Me.mskValorRecebido.Text = refer * CInt(Me.txtQuantidade.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function is_numerario_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Rec. em Numerário" Or Me.cboModoRecebido.SelectedItem = "Rec. Numerario (NAO USAR)") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    Private Function check_numerario_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Rec. em Numerário" Or query = "Rec. Numerario (NAO USAR)") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_cheque_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Rec. por Cheque" Or Me.cboModoRecebido.SelectedItem = "Rec. por Cheque (PD)") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    Private Function check_cheque_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Rec. por Cheque" Or query = "Rec. por Cheque (PD)") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_multibanco_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Rec. Multi Rede" Or Me.cboModoRecebido.SelectedItem = "Rec. por Multibanco") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_multibanco_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Rec. Multi Rede" Or query = "Rec. por Multibanco") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function
    Private Function is_entrada_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Diversos a crédito") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_entrada_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Diversos a crédito") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_saida_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Diversos a débito") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_saida_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Rec. Multi Rede" Or query = "Diversos a débito") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function is_abertura_caixa_mov() As Boolean
        Dim rv As Boolean = False

        If (Me.cboModoRecebido.SelectedItem = "Saldo abertura") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function

    Private Function check_abertura_caixa_mov(query) As Boolean
        Dim rv As Boolean = False

        If (query = "Saldo abertura") Then
            rv = True
        Else
            rv = False
        End If

        Return rv

    End Function



    Private Sub txtCaixaNum_TextChanged(sender As Object, e As EventArgs) Handles txtCaixaNum.TextChanged
        Dim result As Integer

        multibancoConferidoTotal = 0
        chequeConferidoTotal = 0
        numerarioConferidoTotal = 0
        saidaConferidoTotal = 0
        entradaConferidoTotal = 0
        aberturaConferidoTotal = 0
        reset()
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtCaixaNum.Text = digitsOnly.Replace(txtCaixaNum.Text, "")
        If (txtCaixaNum.Text.Length <= 0) Then
            Return
        End If
        If (diarioCaixaCurrente = CInt(Me.txtCaixaNum.Text)) Then
            Return

        End If

        limpar_campo_fechoconta()
        ' Dim idCabecTesouraria As String
        If (tabelaConferenciaCaixa.Rows.Count > 1 And DIARIO_CONFERIDO = False) Then
            result = MessageBox.Show("Conferência de conta já iniciado, se continuar os dados lançados serão perdidos. Continuar ? ", "Atenção", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                buscarCaixa()
                'Else
                '    Me.txtCaixaNum.Text = diarioCaixaCurrente
            End If
        Else
            buscarCaixa()
        End If


    End Sub

    Private Sub buscarCaixa()

        Dim idCaixa As String
        Dim idLinhaTesouraria, movimento As String
        Dim rv As Integer
        Dim diario As String = txtCaixaNum.Text

        limpar_campos()

        If txtCaixaNum.TextLength <> 0 And IsNumeric(txtCaixaNum.Text) Then
            destrancarLinhaFechoConta()
            If SQL.temConexao() = True And SQLPriEmpre.temConexao() = True Then
                Dim tabela, tblLinhaTesourariaBd, tblPrimEmpre, tabelaEntradaSaida, cabecTesouraria, tabelaLinhaTesouraria As New DataTable

                tabela = SQL.buscarDado("select * from diarioCaixa where Diario = " + diario)
                If (tabela.Rows.Count <> 0) Then
                    Me.txtCaixaNum.Text = tabela.Rows(0)("diario")
                    Me.mskDataAbertura.Text = tabela.Rows(0)("DataAbertura")
                    Me.mskSaldoAbertura.Text = tabela.Rows(0)("SaldoAbertura")
                    Me.txtUtilizadorAbertura.Text = tabela.Rows(0)("UtilizadorAbertura")

                    Me.mskDataFecho.Text = tabela.Rows(0)("DataFecho")
                    Me.mskSaldoFecho.Text = tabela.Rows(0)("SaldoFecho")

                    Me.txtUtilizadorFecho.Text = tabela.Rows(0)("UtilizadorFecho")

                    ptxboxUtilizadorAberturaCaixa.ImageLocation = administracao.buscarUtilizadorImagem(Me.txtUtilizadorFecho.Text)

                    Me.mskValRecAbertura.Text = tabela.Rows(0)("SaldoAbertura")
                    idCaixa = tabela.Rows(0)("Id").ToString()

                    ' buscando id do cabecDoc
                    Dim qrCabecTes As String = "select * from cabectesouraria where (tipoDoc = 'SAICX' or TipoDoc = 'ENTCX' or tipoDoc = 'MOV') and IDDiarioCaixa = '" + idCaixa + "'"
                    'Dim qrEntradaSaida As String = "select * from cabectesouraria where (tipoDoc = 'SAICX' or TipoDoc = 'ENTCX') and IDDiarioCaixa = '" + idCaixa + "'"
                    Dim sqlLinhaTesouraria As String = "select *  from TDU_ConferenciaCaixa where CDU_diarioCaixa =  '" + diario + "'"

                    Dim qrLinhaTes As String
                    Dim tipo_movimento As String
                    tabela = SQL.buscarDado(qrCabecTes)
                    'tabelaEntradaSaida = SQL.buscarDado(qrEntradaSaida)
                    If (tabela.Rows.Count <> 0) Then

                        For i As Integer = 0 To tabela.Rows.Count - 1
                            idLinhaTesouraria = tabela.Rows(i)("Id").ToString()
                            movimento = tabela.Rows(i)("TipoDoc").ToString()
                            If (movimento = "MOV") Then

                                qrLinhaTes = "select * from LinhasTesouraria where IdCabecTesouraria =  '" + idLinhaTesouraria + "'"


                                tabelaLinhaTesouraria = SQL.buscarDado(qrLinhaTes)
                                If (tabela.Rows.Count <> 0) Then
                                    For j As Integer = 0 To tabelaLinhaTesouraria.Rows.Count - 1
                                        tipo_movimento = tabelaLinhaTesouraria.Rows(j)("Movim").ToString()

                                        ' consultando numerario
                                        rv = numerarioMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            numerarioTotal += tabelaLinhaTesouraria.Rows(j)("Credito")
                                        End If

                                        ' consultando multibanco
                                        rv = multibancoMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            multibancoTotal += tabelaLinhaTesouraria.Rows(j)("Credito")
                                        End If

                                        ' consultando cheque
                                        rv = chequeMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            chequeTotal += tabelaLinhaTesouraria.Rows(j)("Credito")
                                        End If

                                        ' consultando senha cabazes
                                        rv = senhasCabazesMov.ToList.FindIndex(Function(x) x = tipo_movimento)
                                        If (rv >= 0) Then
                                            senhasCabazesTotal += tabelaLinhaTesouraria.Rows(j)("Credito")
                                        End If

                                    Next
                                End If
                            ElseIf (movimento = "ENTCX") Then
                                entradaTotal += tabela.Rows(i)("TotalCredito")
                            ElseIf (movimento = "SAICX") Then
                                saidaTotal += tabela.Rows(i)("TotalDebito")
                            End If

                        Next



                        Me.mskValRecNumerario.Text = numerarioTotal
                        Me.mskValRecCheque.Text = chequeTotal
                        Me.mskValRecMultiBim.Text = multibancoTotal
                        Me.mskValRecSenhasCabazes.Text = senhasCabazesTotal
                        Me.mskValRecEntradaCaixa.Text = entradaTotal


                        Me.mskValRecSaidaCaixa.Text = saidaTotal
                        mskValRecSaidaCaixa.ForeColor = Color.Red

                        carregar_valor()

                        numerarioTotal = 0
                        chequeTotal = 0
                        multibancoTotal = 0
                        senhasCabazesTotal = 0
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

                            If (check_multibanco_mov(movimento)) Then

                                Dim tipo_cartao As String = tblLinhaTesourariaBd.Rows(i)("CDU_cartaoTipo").ToString()
                                Dim transacao As String = tblLinhaTesourariaBd.Rows(i)("CDU_transacaoNumero").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()

                                tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, tipo_cartao, transacao, "", 1, valor})
                                preencherCabecalho(movimento, valor)

                            ElseIf (check_cheque_mov(movimento)) Then

                                Dim descricao As String = tblLinhaTesourariaBd.Rows(i)("CDU_chequeDescricao").ToString()
                                Dim chequeNum As String = tblLinhaTesourariaBd.Rows(i)("CDU_chequeNumero").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()

                                tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, descricao, chequeNum, "", 1, valor})
                                preencherCabecalho(movimento, valor)

                            ElseIf (check_numerario_mov(movimento)) Then

                                Dim quantidade As String = tblLinhaTesourariaBd.Rows(i)("CDU_quantidade").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()

                                tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", "", quantidade, valor})
                                preencherCabecalho(movimento, valor)


                            ElseIf (check_entrada_caixa_mov(movimento) Or check_saida_caixa_mov(movimento) Or check_abertura_caixa_mov(movimento)) Then

                                Dim quantidade As String = tblLinhaTesourariaBd.Rows(i)("CDU_quantidade").ToString()
                                Dim referencia As String = tblLinhaTesourariaBd.Rows(i)("CDU_referencia").ToString()
                                Dim valor As String = tblLinhaTesourariaBd.Rows(i)("CDU_valor").ToString()


                                If (check_saida_caixa_mov(movimento)) Then
                                    Dim saidaDesc As String = tblLinhaTesourariaBd.Rows(i)("CDU_saidaDescricao").ToString()
                                    tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", saidaDesc, 1, valor})
                                    preencherCabecalho(movimento, valor)

                                Else
                                    tabelaConferenciaCaixa.Rows.Add(New String() {movimento, referencia, "", "", "", 1, valor})


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
                    Else
                        DIARIO_CONFERIDO = False
                        btnPrevisualizarReporte.Enabled = False
                        Me.btnConfereAdicionar.Text = "Adicionar"

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

    Private Sub cboReferenciaModoReceb_TextChanged(sender As Object, e As EventArgs) Handles cboReferenciaModoReceb.TextChanged
        'If (is_cheque_mov()) Then
        '    Me.cboReferenciaModoReceb.Items.Insert(0, Me.cboReferenciaModoReceb.Text)
        'End If
    End Sub

    Private Sub cboModoRecebido_TextChanged(sender As Object, e As EventArgs) Handles cboModoRecebido.TextChanged
        'If (is_cheque_mov() Or is_multibanco_mov()) Then
        '    Me.mskValorRecebido.Enabled = True
        'Else
        '    Me.mskValorRecebido.Enabled = False
        'End If
        'If (is_cheque_mov() = False) Then
        '    Me.lblFechoContaReferencia.Text = "Referência"
        '    Me.lblFechoContaQuantidade.Text = "Quantidade"
        'End If
    End Sub

    Private Sub btnFecharConta_Click(sender As Object, e As EventArgs) Handles btnFecharConta.Click

        Dim ok As Boolean = False
        Dim result As Integer


        Dim indice_tabela_conta, quantidade As Integer
        Dim modoRecebRef, modoReceb, tipo_cartao, transacao_cheque_numero, i, descricao_saida_caixa As String
        Dim sqlAberturaInsert, sqlEntradaInsert, sqlSaidaInsert, sqlNumerarioInsert, sqlPosInsert, sqlChequeInsert As String
        Dim valor As Double = 0.0

        result = MessageBox.Show("Tem certeza que terminou a conferência de conta ?", "Atenção", MessageBoxButtons.YesNo)
        Dim con As SqlConnection = SQL.conexao()

        If result = DialogResult.Yes Then

            If (check_conferencia_caixa()) Then
                ok = True
            Else
                result = MessageBox.Show("Encontrado diferença nos valores Registados e Conferidos. Deseja continuar ?", "Atenção", MessageBoxButtons.YesNo)
                ok = False

            End If
        End If
        Try

            If (ok = True) Or (ok = False And result = DialogResult.Yes) Then

                For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
                    If Not row.IsNewRow Then



                        modoReceb = row.Cells(0).Value

                        modoRecebRef = row.Cells(1).Value

                        tipo_cartao = row.Cells(2).Value
                        transacao_cheque_numero = row.Cells(3).Value
                        descricao_saida_caixa = row.Cells(4).Value
                        valor = row.Cells(6).Value
                        If (check_numerario_mov(modoReceb)) Then
                            quantidade = row.Cells(5).Value
                        Else
                            quantidade = 1
                        End If

                        If (check_abertura_caixa_mov(modoReceb)) Then
                            administracao.insertConferenciaCaixa(txtCaixaNum.Text, modoReceb, "", "", 1, valor, 0, "", Date.Now(), utilizador_logado.getNome(), "", "")
                        End If

                        If (check_saida_caixa_mov(modoReceb)) Then
                            administracao.insertConferenciaCaixa(txtCaixaNum.Text, modoReceb, "", "", 1, valor, 0, "", Date.Now(), utilizador_logado.getNome(), descricao_saida_caixa, "")
                        End If


                        If (check_entrada_caixa_mov(modoReceb)) Then
                            administracao.insertConferenciaCaixa(txtCaixaNum.Text, modoReceb, "", "", 1, valor, 0, "", Date.Now(), utilizador_logado.getNome(), "", "")
                        End If
                        If (check_numerario_mov(modoReceb)) Then
                            administracao.insertConferenciaCaixa(txtCaixaNum.Text, modoReceb, "", "", quantidade, valor, 0, "", Date.Now(), utilizador_logado.getNome(), "", modoRecebRef)
                        End If

                        If (check_multibanco_mov(modoReceb)) Then
                            administracao.insertConferenciaCaixa(txtCaixaNum.Text, modoReceb, tipo_cartao, transacao_cheque_numero, quantidade, valor, 0, "", Date.Now(), utilizador_logado.getNome(), "", modoRecebRef)
                        End If

                        If (check_cheque_mov(modoReceb)) Then
                            administracao.insertConferenciaCaixa(txtCaixaNum.Text, modoReceb, "", "", quantidade, valor, transacao_cheque_numero, tipo_cartao, Date.Now(), utilizador_logado.getNome(), "", modoRecebRef)
                        End If

                    Else
                        ' MsgBox("Nenhum dado na tabela por gravar")

                    End If
                Next
                MsgBox("salvo com sucesso")
                limpar_campos()
                limpar_campo_fechoconta()
                tabelaConferenciaCaixa.Rows.Clear()
                btnPrevisualizarReporte.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("Ocorreu um erro " + ex.Message())
        End Try
    End Sub

    Private Sub mskValRecNumerario_TextChanged(sender As Object, e As EventArgs) Handles mskValRecNumerario.TextChanged
        Me.mskValRecNumerario.Text = FormatCurrency(Me.mskValRecNumerario.Text).TrimStart("$")
    End Sub

    Private Sub mskValRecAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskValRecAbertura.TextChanged
        Me.mskValRecAbertura.Text = FormatCurrency(Me.mskValRecAbertura.Text).TrimStart("$")

    End Sub

    Private Sub mskValRecMultiBim_TextChanged(sender As Object, e As EventArgs) Handles mskValRecMultiBim.TextChanged
        Me.mskValRecMultiBim.Text = FormatCurrency(Me.mskValRecMultiBim.Text).TrimStart("$")

    End Sub

    Private Sub mskValRecMultiUnico_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub mskValRecCheque_TextChanged(sender As Object, e As EventArgs) Handles mskValRecCheque.TextChanged
        Me.mskValRecCheque.Text = FormatCurrency(Me.mskValRecCheque.Text).TrimStart("$")

    End Sub

    Private Sub mskValRecSenhasCabazes_TextChanged(sender As Object, e As EventArgs) Handles mskValRecSenhasCabazes.TextChanged
        Me.mskValRecSenhasCabazes.Text = FormatCurrency(Me.mskValRecSenhasCabazes.Text).TrimStart("$")

    End Sub

    Private Sub mskValConfAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskValConfAbertura.TextChanged
        Me.mskValConfAbertura.Text = FormatCurrency(Me.mskValConfAbertura.Text).TrimStart("$")

    End Sub

    Private Sub mskValConfNumerario_TextChanged(sender As Object, e As EventArgs) Handles mskValConfNumerario.TextChanged
        Me.mskValConfNumerario.Text = FormatCurrency(Me.mskValConfNumerario.Text).TrimStart("$")

    End Sub

    Private Sub mskValConfMultiBim_TextChanged(sender As Object, e As EventArgs) Handles mskValConfMultiBim.TextChanged
        Me.mskValConfMultiBim.Text = FormatCurrency(Me.mskValConfMultiBim.Text).TrimStart("$")

    End Sub

    Private Sub mskValConfMultiUnico_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub mskValConfCheques_TextChanged(sender As Object, e As EventArgs) Handles mskValConfCheques.TextChanged
        Me.mskValConfCheques.Text = FormatCurrency(Me.mskValConfCheques.Text).TrimStart("$")

    End Sub

    Private Sub mskValConfSenhas_TextChanged(sender As Object, e As EventArgs) Handles mskValConfSenhas.TextChanged
        Me.mskValConfSenhas.Text = FormatCurrency(Me.mskValConfSenhas.Text).TrimStart("$")


    End Sub

    Private Sub mskDiferencaAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaAbertura.TextChanged
        Dim diferenca As Double
        diferenca = CDbl(Me.mskDiferencaAbertura.Text)
        If (diferenca < 0) Then
            Me.mskDiferencaAbertura.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.mskDiferencaAbertura.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub

    Private Sub mskDiferencaNumerario_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaNumerario.TextChanged
        'Me..Text = Me.mskDiferencaNumerario.Text
        Dim diferenca As Double
        diferenca = CDbl(Me.mskDiferencaNumerario.Text)
        If (diferenca < 0) Then
            Me.mskDiferencaNumerario.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.mskDiferencaNumerario.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub

    Private Sub mskDiferencaMultiBim_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaMultiBim.TextChanged
        Dim diferenca As Double
        diferenca = CDbl(Me.mskDiferencaMultiBim.Text)
        If (diferenca < 0) Then
            Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub


    Private Sub mskDiferencaCheque_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaCheque.TextChanged
        Dim diferenca As Double
        diferenca = CDbl(Me.mskDiferencaCheque.Text)
        If (diferenca < 0) Then
            Me.mskDiferencaCheque.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.mskDiferencaCheque.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub

    Private Sub mskDiferencaSenhasCabazes_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaSenhasCabazes.TextChanged
        Dim diferenca As Double
        diferenca = CDbl(Me.mskDiferencaSenhasCabazes.Text)
        If (diferenca < 0) Then
            Me.mskDiferencaSenhasCabazes.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.mskDiferencaSenhasCabazes.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub

    Private Sub mskValorRecebido_TextChanged(sender As Object, e As EventArgs) Handles mskValorRecebido.TextChanged
        'Dim digitsOnly As Regex = New Regex("[\d\.\,]")
        'mskValorRecebido.Text = digitsOnly.Replace(mskValorRecebido.Text, "")

        If (IsNumeric(mskValorRecebido.Text)) Then

            If (CDbl(mskValorRecebido.Text) < 0) Then
                Me.mskValorRecebido.Text = FormatCurrency(Format(mskValorRecebido.Text, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskValorRecebido.Text = FormatCurrency(Format(mskValorRecebido.Text, "Fixed")).TrimStart("$")
            End If

        End If

    End Sub

    Private Sub mskSaldoFecho_TextChanged(sender As Object, e As EventArgs) Handles mskSaldoFecho.TextChanged
        Me.mskSaldoFecho.Text = FormatCurrency(Me.mskSaldoFecho.Text).TrimStart("$")

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
        Me.mskSaldoAbertura.Text = "0.00"
        Me.txtUtilizadorAbertura.Text = ""
        Me.mskDataFecho.Text = ""
        Me.mskSaldoFecho.Text = "0.00"
        Me.txtUtilizadorFecho.Text = ""


        Me.lblEstdCheques.Text = ""
        Me.lblEstdEntradaCaixa.Text = ""
        Me.lblEstdPagamentoAutomatico.Text = ""
        Me.lblEstdSaidaCaixa.Text = ""
        Me.lblEstdSaldoAbert.Text = ""
        Me.lblEstdSenhas.Text = ""
        Me.lblTotalConferido.Text = ""
        Me.lblTotalDiferenca.Text = ""
        Me.lblTotalRecebido.Text = ""
        lblEstdNumerario.Text = ""



        tabelaConferenciaCaixa.Rows.Clear()

    End Sub

    Private Sub mskValRecEntradaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValRecEntradaCaixa.TextChanged

        Try
            'If (Me.mskValRecEntradaCaixa.Text.Length > 0 And IsNumeric(Me.mskValRecEntradaCaixa.Text)) Then

            Me.mskValRecEntradaCaixa.Text = FormatCurrency(Me.mskValRecEntradaCaixa.Text).TrimStart("$")
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskValRecSaidaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValRecSaidaCaixa.TextChanged
        'Try
        'If (Me.mskValRecSaidaCaixa.Text.Length > 0 And IsNumeric(Me.mskValRecSaidaCaixa.Text)) Then

        Me.mskValRecSaidaCaixa.Text = FormatCurrency(Me.mskValRecSaidaCaixa.Text).TrimStart("$")
        '    Dim diferenca As Double = CDbl(Me.mskValRecSaidaCaixa.Text) * (-1)

        '    If (diferenca < 0) Then
        '        Me.mskValRecSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        '    Else
        '        Me.mskValRecSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        '    End If
        '    'End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub mskValConfEntradaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValConfEntradaCaixa.TextChanged

        Try
            'If (Me.mskValConfEntradaCaixa.Text.Length > 0 And IsNumeric(Me.mskValConfEntradaCaixa.Text)) Then

            Me.mskValConfEntradaCaixa.Text = FormatCurrency(Me.mskValConfEntradaCaixa.Text).TrimStart("$")
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskValConfSaidaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskValConfSaidaCaixa.TextChanged
        Dim diferenca As Double
        Try

            diferenca = CDbl(Me.mskDiferencaSaidaCaixa.Text)
            If (diferenca < 0) Then
                Me.mskValConfSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskValConfSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mskDiferencaEntradaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaEntradaCaixa.TextChanged
        Dim diferenca As Double
        diferenca = CDbl(Me.mskDiferencaEntradaCaixa.Text)
        If (diferenca < 0) Then
            Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub

    Private Sub mskDiferencaSaidaCaixa_TextChanged(sender As Object, e As EventArgs) Handles mskDiferencaSaidaCaixa.TextChanged
        Dim diferenca As Double
        Try

            diferenca = CDbl(Me.mskDiferencaSaidaCaixa.Text)
            If (diferenca < 0) Then
                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
            End If
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

                    'If (utilizador_logado.getNivel() = administracao.super Or utilizador_logado.getNivel() = administracao.administrador) Then
                    '    editarFechoConta()
                    '    calcularTotalConferido_diferenca()
                    '    destrancarLinhaFechoConta()

                    'Else
                    '    MessageBox.Show("Somente Utilizador autorizado poderá editar as Linhas de conferência de caixa. Entre em contacto com administrador", "Atenção", MessageBoxButtons.OK)

                    'End If

                    MessageBox.Show("Depois de conferido não pode ser editado. Para a correção apague os dados e reinicie a conferência", "Atenção", MessageBoxButtons.OK)

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

    End Sub

    Private Sub trancarCartaoChequeInput()
        'txtTransacaoNumero.Enabled = False
        cboCartaoTipo.Enabled = False
        mskValorRecebido.Enabled = False
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
            modoRecebVal = tabelaConferenciaCaixa.Rows(indice_tabela_conta).Cells(6).Value





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
            cboReferenciaModoReceb.SelectedIndex = i

            'Por fim actualizar o tipo de cartao se o movimento for do tipo pagamento automatico
            ' Caso contrario actualizar cheque descricao ou cliente
            If (is_cheque_mov()) Then
                cboCartaoTipo.Text = tipo_cartao
                txtQuantidade.Text = transacao_cheque_numero
            ElseIf (is_multibanco_mov()) Then

                cboCartaoTipo.SelectedText = tipo_cartao
                txtQuantidade.Text = transacao_cheque_numero
            ElseIf (is_numerario_mov()) Then
                txtQuantidade.Text = quantidade
            ElseIf (is_saida_caixa_mov()) Then
                cboReferenciaModoReceb.Text = descricao_saida_caixa

            End If

            If (modoRecebVal < 0) Then
                Me.mskValorRecebido.Text = FormatCurrency(Format(modoRecebVal, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskValorRecebido.Text = FormatCurrency(Format(modoRecebVal, "Fixed")).TrimStart("$")
            End If



            Me.tabelaConferenciaCaixa.Rows.RemoveAt(indice_tabela_conta)
            'Me.indiceFechoConta -= 1




        Catch ex As Exception
            MsgBox("Ocorreu um erro " + ex.Message())
        End Try

        'Me.tabelaConferenciaCaixa.del
        'Me.tabelaConferenciaCaixa.Rows(indice_tabela_conta)







        If (modoReceb = "Rec. em Numerário" Or modoReceb = "Rec. Numerario (NAO USAR)") Then
            Me.numerarioConferidoTotal -= CDbl(modoRecebVal)
            Me.mskValConfNumerario.Text = Me.numerarioConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfNumerario.Text) - CDbl(Me.mskValRecNumerario.Text)
            If (checkDiferenca < 0) Then
                Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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

        ElseIf (modoReceb = "Rec. por Cheque (PD)" Or modoReceb = "Rec. por Cheque") Then

            Me.chequeConferidoTotal -= CDbl(modoRecebVal)
            Me.mskValConfCheques.Text = Me.chequeConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfCheques.Text) - CDbl(Me.mskValRecCheque.Text)
            If (checkDiferenca < 0) Then
                Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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

        ElseIf (modoReceb = "Rec. Multi Rede" Or modoReceb = "Rec. por Multibanco") Then
            If (Me.cboCartaoTipo.SelectedIndex <> 0) Then

                Me.multibancoConferidoTotal -= CDbl(modoRecebVal)
                Me.mskValConfMultiBim.Text = Me.multibancoConferidoTotal
                checkDiferenca = CDbl(Me.mskValConfMultiBim.Text) - CDbl(Me.mskValRecMultiBim.Text)
                If (checkDiferenca < 0) Then
                    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

                Else
                    Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
                End If

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

            Me.aberturaConferidoTotal -= CDbl(modoRecebVal)


            Me.mskValConfAbertura.Text = Me.aberturaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfAbertura.Text) - CDbl(Me.mskValRecAbertura.Text)
            If (checkDiferenca < 0) Then
                Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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
            If (checkDiferenca < 0) Then
                Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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

            Me.saidaConferidoTotal += CDbl(modoRecebVal)

            Me.mskValConfSaidaCaixa.Text = Me.saidaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfSaidaCaixa.Text) - CDbl(Me.mskValRecSaidaCaixa.Text)

            If (checkDiferenca < 0) Then
                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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

            'Me.saidaConferidoTotal -= CDbl(modoRecebVal)
            'Me.mskValConfSaidaCaixa.Text = Me.saidaConferidoTotal
            'checkDiferenca = CDbl(Me.mskValConfSaidaCaixa.Text) - CDbl(Me.mskValRecSaidaCaixa.Text)
            'MsgBox(saidaConferidoTotal)
            'MsgBox(modoRecebVal)
            'If (checkDiferenca < 0) Then
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            'Else
            '    Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            'End If

            'If (checkDiferenca < 0) Then
            '    Me.lblEstdSaidaCaixa.ForeColor = Color.Red
            '    Me.lblEstdSaidaCaixa.Text = "Valor a Menos"
            'ElseIf (checkDiferenca = 0 Or checkDiferenca = 0.0) Then
            '    Me.lblEstdSaidaCaixa.ForeColor = Color.Black
            '    Me.lblEstdSaidaCaixa.Text = "Correcto"
            'Else
            '    Me.lblEstdSaidaCaixa.ForeColor = Color.Green
            '    Me.lblEstdSaidaCaixa.Text = "Valor a Mais"

            'End If

        End If
    End Sub

    Private Sub btnConfereLimpar_Click(sender As Object, e As EventArgs) Handles btnConfereLimpar.Click
        limpar_campo_fechoconta()

    End Sub
    Private Function is_lancamento_redudante() As Integer
        Dim tipo_movimento, valor_movimento, cartao_cheque_numero As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In tabelaConferenciaCaixa.Rows
            If Not row.IsNewRow Then
                tipo_movimento = row.Cells(0).Value.ToString

                If (check_numerario_mov(tipo_movimento)) Then
                    valor_movimento = row.Cells(1).Value.ToString

                    If (Me.cboReferenciaModoReceb.Text = valor_movimento) Then
                        'tabelaConferenciaCaixa.Rows.Insert (row.Index, New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
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
                        'tabelaConferenciaCaixa.Rows.Insert (row.Index, New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
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

    Private Sub txtCaixaNum_MouseEnter(sender As Object, e As EventArgs) Handles txtCaixaNum.MouseEnter
    End Sub

    Private Sub txtCaixaNum_Click(sender As Object, e As EventArgs) Handles txtCaixaNum.Click
        If (Me.txtCaixaNum.Text.Length > 0) Then
            diarioCaixaCurrente = CInt(Me.txtCaixaNum.Text)
        End If

    End Sub

    Private Function is_lancamento_abertura_redundante() As Integer
        Dim tipo_movimento, valor As String
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
        Dim tipo_movimento, valor As String
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
        Dim tipo_movimento, valor As String
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
        lblTotalRecebido.Text = (CDbl(mskValRecAbertura.Text) + CDbl(mskValRecNumerario.Text) + CDbl(mskValRecMultiBim.Text) + CDbl(mskValRecCheque.Text) + CDbl(mskValRecSenhasCabazes.Text) + CDbl(mskValRecEntradaCaixa.Text)) - CDbl(mskValRecSaidaCaixa.Text)

        Dim diferenca As Double
        diferenca = CDbl(Me.lblTotalRecebido.Text)
        If (diferenca < 0) Then
            Me.lblTotalRecebido.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.lblTotalRecebido.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If
    End Sub


    Private Sub calcularTotalConferido_diferenca()
        lblTotalConferido.Text = (CDbl(mskValConfAbertura.Text) + CDbl(mskValConfNumerario.Text) + CDbl(mskValConfMultiBim.Text) + CDbl(mskValConfCheques.Text) + CDbl(mskValConfSenhas.Text) + CDbl(mskValConfEntradaCaixa.Text)) + CDbl(mskValConfSaidaCaixa.Text)

        Dim diferenca As Double
        diferenca = CDbl(Me.lblTotalConferido.Text)
        If (diferenca < 0) Then
            Me.lblTotalConferido.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.lblTotalConferido.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If


        lblTotalDiferenca.Text = (CDbl(mskDiferencaAbertura.Text) + CDbl(mskDiferencaNumerario.Text) + CDbl(mskDiferencaMultiBim.Text) + CDbl(mskDiferencaCheque.Text) + CDbl(mskDiferencaSenhasCabazes.Text) + CDbl(mskDiferencaEntradaCaixa.Text) - CDbl(mskDiferencaSaidaCaixa.Text))

        diferenca = CDbl(Me.lblTotalDiferenca.Text)
        If (diferenca < 0) Then
            Me.lblTotalDiferenca.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            Me.lblTotalDiferenca.Text = FormatCurrency(Format(diferenca, "Fixed")).TrimStart("$")
        End If



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
        If Not is_saida_caixa_mov() Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboCartaoTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCartaoTipo.KeyPress
        If Not is_cheque_mov() Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQuantidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantidade.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskValorRecebido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskValorRecebido.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPrevisualizarReporte_Click(sender As Object, e As EventArgs) Handles btnPrevisualizarReporte.Click
        ConferenciaContaReporteView.setDiario(CInt(txtCaixaNum.Text))

        ConferenciaContaReporteView.Show()

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
            If (checkDiferenca < 0) Then
                Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaNumerario.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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
            If (checkDiferenca < 0) Then
                Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaCheque.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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
            If (checkDiferenca < 0) Then
                Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaMultiBim.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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
            If (checkDiferenca < 0) Then
                Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaEntradaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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

            If (checkDiferenca < 0) Then
                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaSaidaCaixa.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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

        ElseIf (check_abertura_caixa_mov(movimento)) Then

            Me.aberturaConferidoTotal += CDbl(valor)
            Me.mskValConfAbertura.Text = Me.aberturaConferidoTotal
            checkDiferenca = CDbl(Me.mskValConfAbertura.Text) - CDbl(Me.mskValRecAbertura.Text)
            If (checkDiferenca < 0) Then
                Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

            Else
                Me.mskDiferencaAbertura.Text = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
            End If

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
        If (checkDiferenca < 0) Then
            estado_cls.valor_str = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("(").TrimEnd(")").TrimStart("$").Insert(0, "-")

        Else
            estado_cls.valor_str = FormatCurrency(Format(checkDiferenca, "Fixed")).TrimStart("$")
        End If


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
        If (Me.sair_sistema() = True) Then
            Me.Close()
        End If
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

    Private Sub mskValConfEntradaCaixa_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskValConfEntradaCaixa.MaskInputRejected

    End Sub

    Private Sub mskSaldoAbertura_TextChanged(sender As Object, e As EventArgs) Handles mskSaldoAbertura.TextChanged
        Me.mskSaldoAbertura.Text = FormatCurrency(Me.mskSaldoAbertura.Text).TrimStart("$")

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

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
            Me.txtCaixaNum.Enabled = True
            Me.cboModoRecebido.Items.Add("Selecionar movimento")
            Me.cboModoRecebido.SelectedIndex = 0

            preencher_tipo_movimento()
            trancarLinhaFechoConta()
            limpar_campos()
        Else
            Me.txtCaixaNum.Enabled = False
            Me.cboModoRecebido.Items.Clear()
            Me.cboModoRecebido.Text = ""
            'Me.cboReferenciaModoReceb.Items.Clear()
            cboReferenciaModoReceb.Text = ""
            trancarLinhaFechoConta()
            limpar_campos()
            Me.rodape.Text = "Sessão Não Iniciado"

        End If
    End Sub

    Public Function getLogado() As Utilizador
        Return Me.utilizador_logado
    End Function


    Private Function sair_sistema() As Boolean
        Dim rv As Boolean
        Try
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
        aberturaConferidoTotal = 0
        entradaTotal = 0
        entradaConferidoTotal = 0
        saidaTotal = 0
        saidaConferidoTotal = 0
    End Sub

    Function is_row_valid(line As Integer) As Boolean
        Dim movimento As String
        Dim rv As Boolean = False
        movimento = tabelaConferenciaCaixa.Rows(line).Cells(0).Value

        If check_abertura_caixa_mov(movimento) Or check_cheque_mov(movimento) Or
            check_entrada_caixa_mov(movimento) Or check_multibanco_mov(movimento) Or
            check_numerario_mov(movimento) Or check_saida_caixa_mov(movimento) Then
            rv = True
        Else
            rv = False
        End If


        Return rv

    End Function

End Class



Public Class Estado

    Public cor As Color
    Public texto As String
    Public valor_str As String

End Class