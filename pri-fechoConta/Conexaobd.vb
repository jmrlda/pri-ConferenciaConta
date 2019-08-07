Imports System.IO

Public Class Conexaobd

    Dim administracao As ConferenciaAdmin = New ConferenciaAdmin()
    Dim js As JmrJson = New JmrJson()




    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTerminar.Click

        If System.IO.File.Exists(js.CONEXAO_PATH) Then

            ConferenciaCaixa.ISCONEXAOCONFIGURADA = True
            Me.Close()

        Else
            MessageBox.Show("Configure as conexoes antes de proseguir para qualquer actividade")
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestar.Click
        If administracao.testeConexaoBd() Then
            MessageBox.Show("Teste de Conexão com Sucesso")
        Else
            MessageBox.Show("Falhou no teste de conexão")

        End If
    End Sub


    Private Sub Conexaobd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If System.IO.File.Exists(js.CONEXAO_PATH) Then

            carregarConfiguracao()
        Else
            txtBasedados.Text = ""
            txtSenha.Text = ""
            txtServidor.Text = ""
            txtUtilizadorBd.Text = ""
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim con As Conexao = New Conexao()
        If (checkCampos() = True) Then

            con.basedados = txtBasedados.Text
            con.servidor = txtServidor.Text
            con.senha = administracao.Encrypt(txtSenha.Text)
            con.utilizador = txtUtilizadorBd.Text
            con.net_path = txtPath.Text
            administracao.criarEscreverFicheiro(js.CONEXAO_PATH, js.js.Serialize(con))

            MsgBox("Configurações Salvos com sucesso")

            carregarConfiguracao()

        Else
            Me.lblMsgErro.Text = "Preecha os campos em branco"

        End If
    End Sub


    Sub carregarConfiguracao()
        Me.txtBasedados.Text = js.getConexao().basedados
        Me.txtSenha.Text = js.getConexao().senha 'administracao.Decrypt(js.getConexao().senha)
        Me.txtServidor.Text = js.getConexao().servidor
        Me.txtUtilizadorBd.Text = js.getConexao().utilizador
        Me.txtPath.Text = js.getConexao().net_path
    End Sub


    Function checkCampos() As Boolean
        Dim rv As Boolean = False
        If (Me.txtBasedados.Text.Trim(" ").Length > 0 And Me.txtSenha.Text.Trim(" ").Length > 0 And Me.txtServidor.Text.Trim(" ").Length > 0 And Me.txtUtilizadorBd.Text.Trim(" ").Length > 0) Then
            rv = True
        Else
            rv = False
        End If

        Return rv
    End Function



    Private Sub Conexaobd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True

    End Sub

    Private Sub btnSelecionarCaminho_Click(sender As Object, e As EventArgs) Handles btnSelecionarCaminho.Click

    End Sub

    Private Sub btnTestarCaminho_Click(sender As Object, e As EventArgs) Handles btnTestarCaminho.Click



    End Sub
End Class
