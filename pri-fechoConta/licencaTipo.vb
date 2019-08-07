Public Class LicencaTipo
    Dim administracao As New ConferenciaAdmin
    Dim licencaDuracao As Integer = -1
    Dim licencaDuracao_str As String = ""

    Dim licencaUtilizadores As Integer = -1
    Dim licencaSistema As String = ""
    Dim licenca_encode As String
    Dim dataInic, dataFim As String
    Dim licenca_decode As String

    Dim licencaClienteNuit As Integer
    Dim licencaDuracaoActivacao As Integer
    Dim licencaClienteCodigo As String
    Dim licencaClienteNome As String
    Dim licencaClienteMorada As String
    Dim licencaClienteFilial As String
    Dim js As JmrJson = New JmrJson()


    Private Sub LicencaTipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdLicencaFicheiro.Checked = True
        txtLicencaCodigo.Clear()
    End Sub

    Private Sub rdLicencaFicheiro_CheckedChanged(sender As Object, e As EventArgs) Handles rdLicencaFicheiro.CheckedChanged
        Me.txtLicencaCodigo.Enabled = False
        Me.btnAbrirFicheiro.Enabled = True
        licenca_decode = ""
    End Sub

    Private Sub rdLicencaCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdLicencaCodigo.CheckedChanged
        Me.txtLicencaCodigo.Enabled = True
        Me.btnAbrirFicheiro.Enabled = False
        Me.txtLicencaCodigo.Text = ""
        licenca_decode = ""

    End Sub

    Private Sub btnAbrirFicheiro_Click(sender As Object, e As EventArgs) Handles btnAbrirFicheiro.Click
        'ofdFicheiro.Filter = "Ficheiro Licenca | *.lic"

        If ofdFicheiro.ShowDialog = DialogResult.OK Then

            licenca_encode = administracao.lerFicheiroLicenca(ofdFicheiro.FileName)
            Me.txtLicencaCodigo.Text = licenca_encode

            licenca_decode = administracao.Decrypt(licenca_encode)
                licencaUtilizadores = licenca_decode.Split("_")(0)
                licencaSistema = licenca_decode.Split("_")(1)
                licencaDuracao_str = licenca_decode.Split("_")(2)
                licencaClienteNuit = licenca_decode.Split("_")(3)
            licencaDuracaoActivacao = licenca_decode.Split("_")(5)
            licencaClienteCodigo = licenca_decode.Split("_")(6)
            licencaClienteNome = licenca_decode.Split("_")(7)
            licencaClienteMorada = licenca_decode.Split("_")(8)
            licencaClienteFilial = licenca_decode.Split("_")(9)
            dataInic = Date.Now().ToShortDateString
                dataFim = Date.Now().AddDays(change_duracao_str_int(licencaDuracao_str)).ToShortDateString


            End If

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub btnSalvar_Click_1(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If rdLicencaCodigo.Checked = True And Me.txtLicencaCodigo.Text.Length > 5 Then
            licenca_decode = administracao.Decrypt(txtLicencaCodigo.Text)
            If (licenca_decode.Length > 0) Then
                If administracao.isLicencaDentroPrazo(txtLicencaCodigo.Text) Then
                    Try

                        licencaUtilizadores = licenca_decode.Split("_")(0)
                        licencaSistema = licenca_decode.Split("_")(1)
                        licencaDuracao_str = licenca_decode.Split("_")(2)
                        licencaClienteNuit = licenca_decode.Split("_")(3)
                        licencaDuracaoActivacao = licenca_decode.Split("_")(5)
                        licencaClienteCodigo = licenca_decode.Split("_")(6)
                        licencaClienteNome = licenca_decode.Split("_")(7)
                        licencaClienteMorada = licenca_decode.Split("_")(8)
                        licencaClienteFilial = licenca_decode.Split("_")(9)


                        If checkLicencaProprietario() = True Then
                            dataInic = Date.Now().ToShortDateString
                            dataFim = Date.Now().AddDays(change_duracao_str_int(licencaDuracao_str)).ToShortDateString
                            If administracao.existeLicencasBySerie(txtLicencaCodigo.Text) = False Then

                                administracao.insertLicenca(txtLicencaCodigo.Text, licencaUtilizadores, dataInic, dataFim)
                                LicencaControlo.carregar_licenca()
                                MessageBox.Show("Licença Válida. Registo Confirmado", "Sucesso", MessageBoxButtons.OK)

                                Me.Close()

                            Else
                                MessageBox.Show("Esta licença já se encontra activada", "Atenção", MessageBoxButtons.OK)


                            End If
                        Else
                            MessageBox.Show("Licença Inválida para este cliente", "Atenção", MessageBoxButtons.OK)


                        End If
                    Catch ex As Exception
                        MessageBox.Show("Ocorreu um erro de Licenciamento. Certifique que existe uma ligação a base de dados: " + ex.Message, "Erro", MessageBoxButtons.OK)

                    End Try
                Else
                    MessageBox.Show("Licença Ultrapassou a Data para activação. Entre em contacto com o administrador", "Atenção", MessageBoxButtons.OK)

                End If


            Else
                MessageBox.Show("Licença Inválida. Por favor contacte a JMR", "Atenção", MessageBoxButtons.OK)
            End If

        Else
            If (administracao.isLicencaDentroPrazo(licenca_encode)) Then

                If administracao.existeLicencasBySerie(licenca_encode) = False Then
                    If checkLicencaProprietario() = True Then


                        administracao.insertLicenca(licenca_encode, licencaUtilizadores, dataInic, dataFim)
                        LicencaControlo.carregar_licenca()
                        MessageBox.Show("Licença Válida. Registo Confirmado", "Sucesso", MessageBoxButtons.OK)

                        Me.Close()
                    Else
                        MessageBox.Show("Licença Inválida para este cliente", "Atenção", MessageBoxButtons.OK)

                    End If

                Else
                    MessageBox.Show("Esta licença já se encontra activada", "Atenção", MessageBoxButtons.OK)
                End If

            Else
                MessageBox.Show("Licença Ultrapassou a Data para activação. Entre em contacto com o administrador", "Atenção", MessageBoxButtons.OK)
            End If

        End If
    End Sub

    Private Function change_duracao_str_int(duracao As String)

        '1 Mês
        '3 Meses
        '6 Meses
        '1 Ano

        Dim duracao_int As Integer
        If (duracao.Equals("1 Mês") = True) Then
            duracao_int = 31
        ElseIf (duracao.Equals("3 Meses") = True) Then
            duracao_int = 93
        ElseIf (duracao.Equals("6 Meses") = True) Then
            duracao_int = 186
        ElseIf (duracao.Equals("1 Ano") = True) Then
            duracao_int = 365
        Else
            duracao_int = 0
        End If


        Return duracao_int
    End Function


    Function checkLicencaProprietario() As Boolean
        Dim rv As Boolean = False
        Dim campos As String = " "
        If licencaClienteCodigo = js.getClienteConexao().Codigo And
        licencaClienteFilial = js.getClienteConexao.filial And
        licencaClienteMorada = js.getClienteConexao().morada And
            licencaClienteNome = js.getClienteConexao().nome And
        licencaClienteNuit = js.getClienteConexao.nuit Then

            rv = True
        Else
            rv = False
        End If


        If licencaClienteCodigo <> js.getClienteConexao().Codigo Then
            campos += "CODIGO, "
        End If

        If licencaClienteNome <> js.getClienteConexao().nome Then

            campos += "NOME, "
        End If

        If licencaClienteFilial <> js.getClienteConexao.filial Then
            campos += "FILIAL, "
        End If

        If licencaClienteMorada <> js.getClienteConexao().morada Then
            campos += "MORADA, "
        End If

        If licencaClienteNuit <> js.getClienteConexao.nuit Then
            campos += "NUIT, "

        End If


        If campos.Length > 2 Then
            MessageBox.Show("Licença Invalida. verifique se o(s) campo(s) " + campos + "possui(em) dados correctos", "Erro  - Licença", MessageBoxButtons.OK)

        End If
        Return rv





    End Function
End Class