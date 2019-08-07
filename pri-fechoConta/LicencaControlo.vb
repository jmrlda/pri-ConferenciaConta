Public Class LicencaControlo

    Dim administracao As New ConferenciaAdmin
    Dim util As New Util
    Dim total_utilizadores_licenciados As Integer = 0
    Dim actualizar As Boolean = False
    Dim actualizado As Boolean = False




    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLicenciar.Click
        Dim sucesso As Boolean = False
        Dim except_msg As String = ""
        If (dgvUtilizadoresLicenca.Rows.Count() > 1) Then
            For Each row As DataGridViewRow In dgvUtilizadoresLicenca.Rows
                If Not row.IsNewRow Then



                    Dim utilizador As String = row.Cells(0).Value
                    Dim nivel As String = row.Cells(1).Value
                    Dim id_licenca As String = administracao.buscarIdLicencasBySerie(Me.cboLicencaSerie.Text)
                    Try
                        If (administracao.isUtilizadorLicenciado(utilizador) = False) Then
                            administracao.insertConferenciaUtilizador(utilizador, Date.Now(), nivel, id_licenca)
                            sucesso = True
                        End If
                    Catch ex As Exception
                        except_msg = ex.Message()
                        sucesso = False
                    End Try
                Else
                    ' MsgBox("Nenhum dado na tabela por gravar")

                End If
            Next
            If (sucesso) Then
                MsgBox("Usuarios registado com sucesso")
                limpar_campos()
            Else
                MsgBox("Ocorreu um erro enquanto registava usuarios: " + except_msg)
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub LicencaControlo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboNivelUtilizador.SelectedIndex = 0
        setRegisto()
        carregar_licenca()
    End Sub
    Private Sub setRegisto()
        Dim SQLPriEmpre As New sqlControloPriEmpre
        Dim tblPrimEmpre As New DataTable
        Dim utilizadores As New List(Of String)
        utilizadores.Add("Selecionar Utilizador")

        If SQLPriEmpre.temConexao() = True Then

            tblPrimEmpre = SQLPriEmpre.buscarDado("select codigo from Utilizadores")

            If (tblPrimEmpre.Rows.Count <> 0) Then
                For i As Integer = 0 To tblPrimEmpre.Rows.Count - 1
                    utilizadores.Add(tblPrimEmpre.Rows(i)("Codigo"))
                Next

                cboUtilizador.DataSource = utilizadores
            End If

        End If


    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click

        If (total_utilizadores_licenciados < CInt(Me.txtUtilizadoresNumero.Text) Or actualizar = True) Then

            If (Me.cboUtilizador.SelectedIndex <> 0 And Me.cboNivelUtilizador.SelectedIndex <> 0) Then
                Dim idx As Integer = is_usuario_licenca_redudante()
                If (idx >= 0) Then
                    MsgBox("Utilizador será actualizado na linha: " + (idx + 1).ToString())
                    If (administracao.actualizarLicencaUsuario(cboUtilizador.Text, cboNivelUtilizador.Text) = True) Then
                        Me.dgvUtilizadoresLicenca.Rows.Insert(idx, New String() {Me.cboUtilizador.Text, Me.cboNivelUtilizador.Text})
                        Me.dgvUtilizadoresLicenca.Rows.RemoveAt(idx + 1)
                    End If
                Else
                        Me.dgvUtilizadoresLicenca.Rows.Add(New String() {Me.cboUtilizador.Text, Me.cboNivelUtilizador.Text})
                    Me.cboUtilizador.SelectedIndex = 0
                    Me.cboNivelUtilizador.SelectedIndex = 0
                    btnLicenciar.Enabled = True

                    If Not actualizar Then
                        total_utilizadores_licenciados += 1

                    End If
                End If

            End If
        Else
            MsgBox("atingiu o número maximo de utilizadores para a licença selecionada")
        End If
    End Sub




    Private Sub NovaLicençaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovaLicençaToolStripMenuItem.Click


        If (ConferenciaCaixa.utilizador_logado.getLogado() = True) Then
            If ConferenciaCaixa.utilizador_logado.getNivel() = administracao.super Then
                LicencaTipo.ShowDialog(Me)

            Else
                MessageBox.Show("Somente o super administrador poderá Licenciar o Sistema", "Atenção", MessageBoxButtons.OK)

            End If
        Else
            If MessageBox.Show("Por favor entre no Sistema para iniciar uma actividade. Deseja entrar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Entrar.ShowDialog(Me)
            End If
        End If

    End Sub

    Private Sub LicencaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicencaToolStripMenuItem.Click

    End Sub

    Public Sub carregar_licenca()
        Dim licencas As List(Of String) = administracao.buscarLicencas()

        cboLicencaSerie.DataSource = licencas
        cboLicencaSerie.SelectedIndex = 0

    End Sub

    Private Sub cboLicencaSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLicencaSerie.SelectedIndexChanged
        If cboLicencaSerie.SelectedIndex > 0 Then
            If administracao.isLicencaDentroPrazo(cboLicencaSerie.Text) Then


                Dim licenca_decode As String
                Dim licencaUtilizadores As Integer
                Dim licenca_modulo As String
                Dim licencaDuracao_str As String
                Dim dataInic, dataFim As String
                Dim licencaClienteNuit As Integer
                Dim licencaDuracaoActivacao As Integer
                Dim licencaClienteCodigo As String
                Dim licencaClienteNome As String
                Dim licencaClienteMorada As String
                Dim licencaClienteFilial As String


                Dim isSuper As Boolean = False


                total_utilizadores_licenciados = 0
                Me.dgvUtilizadoresLicenca.Rows.Clear()

                If (cboLicencaSerie.SelectedIndex > 0) Then
                    licenca_decode = administracao.Decrypt(cboLicencaSerie.Text)


                    If (licenca_decode.Length > 0) Then
                        Me.cboUtilizador.Enabled = True
                        Me.cboNivelUtilizador.Enabled = True
                        Me.btnAdicionar.Enabled = True
                        btnRemoverLicenca.Enabled = True


                        licencaUtilizadores = licenca_decode.Split("_")(0)
                        licenca_modulo = licenca_decode.Split("_")(1)
                        licencaDuracao_str = licenca_decode.Split("_")(2)
                        licencaClienteNuit = licenca_decode.Split("_")(3)
                        licencaDuracaoActivacao = licenca_decode.Split("_")(5)
                        licencaClienteCodigo = licenca_decode.Split("_")(6)
                        licencaClienteNome = licenca_decode.Split("_")(7)
                        licencaClienteMorada = licenca_decode.Split("_")(8)
                        licencaClienteFilial = licenca_decode.Split("_")(9)






                        dataInic = Date.Now().ToShortDateString
                        dataFim = Date.Now().AddDays(util.change_duracao_str_int(licencaDuracao_str)).ToShortDateString

                        Me.txtUtilizadoresNumero.Text = licencaUtilizadores
                        Me.txtDuracao.Text = licencaDuracao_str
                        Me.txtClienteNuit.Text = licencaClienteNuit

                        Dim sql As New sqlControlo
                        Dim user_serie_qr As String = "select * from TDU_ConferenciaUtilizador  where CDU_conferenciaLicencaId = (select CDU_id from TDU_ConferenciaLicenca where CDU_serie_licenca = '" + cboLicencaSerie.Text + "' )"
                        Dim serie_qr As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" + cboLicencaSerie.Text + "'"

                        Dim tabelaUtilizador, tabelaSerie As New DataTable
                        tabelaUtilizador = sql.buscarDado(user_serie_qr)
                        tabelaSerie = sql.buscarDado(serie_qr)
                        If (tabelaSerie.Rows.Count <> 0) Then
                            Me.dtpDataInicio.Value = DateValue(tabelaSerie.Rows(0)("CDU_dataLicenca"))
                            Me.dtpDataFim.Value = DateValue(tabelaSerie.Rows(0)("CDU_dataLicencaFim"))
                            'total_utilizadores_licenciados = tabelaSerie.Rows(0)("CDU_numero_utilizador")
                        End If


                        If (tabelaUtilizador.Rows.Count <> 0) Then
                            Me.dgvUtilizadoresLicenca.Rows.Clear()
                            For i As Integer = 0 To tabelaUtilizador.Rows.Count - 1
                                Me.dgvUtilizadoresLicenca.Rows.Add(New String() {tabelaUtilizador.Rows(i)("CDU_utilizador"), tabelaUtilizador.Rows(i)("CDU_nivel")})
                                total_utilizadores_licenciados += 1

                                If (tabelaUtilizador.Rows(i)("CDU_nivel") = administracao.super) Then
                                    isSuper = True
                                End If
                                'If (cboModoRecebido.Items.IndexOf(tabelaMov.Rows(i)("Descricao")) = -1) Then
                                '    cboModoRecebido.Items.Add(tabelaMov.Rows(i)("Descricao"))
                                'End If
                            Next

                            If (isSuper = True) Then
                                block_campos()
                                Me.dgvUtilizadoresLicenca.Enabled = False
                                Me.btnLicenciar.Enabled = False
                            Else
                                unblock_campos()
                                Me.dgvUtilizadoresLicenca.Enabled = True
                                Me.btnLicenciar.Enabled = True

                            End If

                        End If
                    Else

                        MessageBox.Show("Licença  Invalido. Entre em contacto com o administrador", "Atenção")
                        Me.cboUtilizador.Enabled = False
                        Me.cboNivelUtilizador.Enabled = False
                        block_campos()
                        Me.dgvUtilizadoresLicenca.Enabled = False
                        Me.btnLicenciar.Enabled = False
                    End If
                Else
                    block_campos()
                    Me.dgvUtilizadoresLicenca.Enabled = False
                    Me.btnLicenciar.Enabled = False
                End If


            Else
                Me.btnRemoverLicenca.Enabled = True
                If MessageBox.Show("Licença expirado! Deseja remover", "Atenção - Importante", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Try
                        Dim rv As Boolean = administracao.removeUsuarioByLicenca(cboLicencaSerie.Text)
                        If rv = True Then
                            administracao.removeLicencaBySerie(cboLicencaSerie.Text)
                            carregar_licenca()
                        End If
                    Catch ex As Exception
                        MessageBox.Show("[cboLicencaSerie_SelectedIndexChanged] Ocorreu um erro enquanto Removia a licença " + ex.Message())
                    End Try
                End If
            End If

        Else
            btnAdicionar.Enabled = False
            btnLimpar.Enabled = False
            btnRemover.Enabled = False
            btnRemoverLicenca.Enabled = False
            Me.dgvUtilizadoresLicenca.Rows.Clear()

        End If

    End Sub


    Private Function is_usuario_licenca_redudante() As Integer
        Dim usuario As String
        Dim rv As Integer = -1

        For Each row As DataGridViewRow In dgvUtilizadoresLicenca.Rows
            If Not row.IsNewRow Then
                usuario = row.Cells(0).Value.ToString
                If (Me.cboUtilizador.Text = usuario) Then
                    'tabelaConferenciaCaixa.Rows.Insert (row.Index, New String() {Me.cboModoRecebido.SelectedItem, Me.cboReferenciaModoReceb.Text, "", Me.txtQuantidade.Text, Me.mskValorRecebido.Text})
                    rv = row.Index

                End If

            End If
        Next

        Return rv
    End Function

    Private Sub limpar_campos()
        Me.cboLicencaSerie.SelectedIndex = 0
        Me.cboNivelUtilizador.SelectedIndex = 0
        Me.cboUtilizador.SelectedIndex = 0
        Me.txtDuracao.Text = ""
        Me.txtClienteNuit.Text = ""
        Me.dtpDataFim.Value = Date.Now()
        Me.dtpDataInicio.Value = Date.Now()


        Me.dgvUtilizadoresLicenca.Rows.Clear()
        block_campos()

    End Sub


    Private Sub block_campos()
        Me.cboUtilizador.Enabled = False
        Me.cboNivelUtilizador.Enabled = False
        Me.btnAdicionar.Enabled = False
        Me.btnLimpar.Enabled = False

    End Sub

    Private Sub unblock_campos()
        Me.cboUtilizador.Enabled = True
        Me.cboNivelUtilizador.Enabled = True
        Me.btnAdicionar.Enabled = True
        Me.btnLimpar.Enabled = True

    End Sub


    Private Sub btnRemoverLinha_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        cboNivelUtilizador.SelectedIndex = 0
        cboUtilizador.SelectedIndex = 0

        Me.btnAdicionar.Text = "Adicionar"
    End Sub



    Private Sub dgvUtilizadoresLicenca_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUtilizadoresLicenca.CellClick
        Me.btnRemover.Enabled = True


    End Sub


    Private Sub dgvUtilizadoresLicenca_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUtilizadoresLicenca.CellDoubleClick
        Dim i As Integer

        i = Me.dgvUtilizadoresLicenca.CurrentRow.Index
        Dim utilizador As String = dgvUtilizadoresLicenca.Rows(i).Cells(0).Value
        Dim nivel As String = dgvUtilizadoresLicenca.Rows(i).Cells(1).Value



        i = cboUtilizador.Items.IndexOf(utilizador)
        cboUtilizador.SelectedIndex = i

        i = cboNivelUtilizador.Items.IndexOf(nivel)
        cboNivelUtilizador.SelectedIndex = i


        Me.btnAdicionar.Text = "Actualizar"
        Me.actualizar = True
        Me.btnRemover.Enabled = False
        btnLicenciar.Enabled = False
    End Sub

    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click
        Dim i As Integer = Me.dgvUtilizadoresLicenca.CurrentRow.Index
        If (i <> Me.dgvUtilizadoresLicenca.Rows.Count() - 1) Then
            Dim nome As String = dgvUtilizadoresLicenca.Rows(i).Cells(0).Value
            Dim nivel As String = dgvUtilizadoresLicenca.Rows(i).Cells(1).Value
            If MessageBox.Show("Tem certeza que deseja apagar a linha " + i.ToString() + ". Dados não serão recuperaods apos confirmar ação?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If administracao.removeLicencaUsuario(nome, nivel) = True Then
                    Me.dgvUtilizadoresLicenca.Rows.RemoveAt(i)
                    total_utilizadores_licenciados -= 1
                End If
            End If
        End If
    End Sub

    Private Sub cboUtilizador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUtilizador.SelectedIndexChanged
        btnAdicionar.Text = "Adicionar"
        Me.cboNivelUtilizador.SelectedIndex = 0
        btnLicenciar.Enabled = True

    End Sub

    Private Sub cboNivelUtilizador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNivelUtilizador.SelectedIndexChanged

    End Sub

    Private Sub dgvUtilizadoresLicenca_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUtilizadoresLicenca.CellContentClick

    End Sub

    Private Sub LicencaControlo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True

    End Sub

    Private Sub btnRemoverLicenca_Click(sender As Object, e As EventArgs) Handles btnRemoverLicenca.Click
        Try
            Dim rv As Boolean = administracao.removeUsuarioByLicenca(cboLicencaSerie.Text)
            If rv = True Then
                administracao.removeLicencaBySerie(cboLicencaSerie.Text)
                carregar_licenca()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro enquanto Removia a licença " + ex.Message())
        End Try
    End Sub

    Private Sub dgvUtilizadoresLicenca_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvUtilizadoresLicenca.RowsAdded
        If (dgvUtilizadoresLicenca.Rows.Count() > 1) Then
            btnLicenciar.Enabled = True
        Else
            btnLicenciar.Enabled = False

        End If
    End Sub

End Class
