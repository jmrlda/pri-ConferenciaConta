

Public Class Entrar

    Dim administracao As New ConferenciaAdmin
    Private Sub entrar()
        Dim SQLPriEmpre As New sqlControloPriEmpre
        Dim tblPrimEmpre As New DataTable

        If SQLPriEmpre.temConexao() = True Then
            If (tblPrimEmpre.Rows.Count <> 0) Then
                'ptxboxUtilizadorAberturaCaixa.ImageLocation = tblPrimEmpre.Rows(0)("Fotografia")

            End If
        End If

    End Sub

    Private Sub Entrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        If (Me.txtSenha.Text.Length > 0 And Me.txtUtilizador.Text.Length > 0) Then
            Dim user As String = txtUtilizador.Text
            Dim senha As String = administracao.Encrypt(txtSenha.Text)
            Dim user_online As New Utilizador


            If (administracao.isUtilizadorLogadoNoutroComputador(Me.txtUtilizador.Text, Environment.MachineName) = True) Then
                If MessageBox.Show("Sessão Aberta na maquina " & administracao.buscarMaquinaRemoto(Me.txtUtilizador.Text) & ". Fechar outra sessão para Continuar ?", "Atenção", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    user_online = administracao.logar(user, senha)
                Else
                    Me.Close()
                End If
            Else
                user_online = administracao.logar(user, senha)

            End If

            If (user_online.getLogado() = True) Then

                        Me.txtSenha.Text = ""
                        Me.txtUtilizador.Text = ""
                        ConferenciaCaixa.setLogado(user_online)
                        lblMsgErro.Visible = False
                        Dim licenca As String = administracao.buscarUtilizadorLicenca(user)
                        Try

                            If administracao.LicencaDiasExpiracao(licenca) <= 20 Then
                                ConferenciaCaixa.lblMsgLicencaExpiracao.Text = administracao.LicencaDiasExpiracao_str(licenca)
                                ConferenciaCaixa.pnlMensagemLicenca.Visible = True
                            Else
                                ConferenciaCaixa.pnlMensagemLicenca.Visible = False


                            End If
                            Me.Close()

                        Catch ex As Exception
                            MessageBox.Show("[BTN ENTRAR] Erro:/> " + ex.Message)

                        End Try

                    Else

                        Me.txtSenha.Text = ""
                        ConferenciaCaixa.setLogado(user_online)
                        Me.lblMsgErro.Text = "Utilizador ou Senha incorrecto"

                        lblMsgErro.Visible = True
                    End If


                Else

            Me.lblMsgErro.Text = "Os campos devem estar preenchidos"
            lblMsgErro.Visible = True
        End If


    End Sub

    Private Sub Entrar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True

    End Sub

    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click

    End Sub
End Class
