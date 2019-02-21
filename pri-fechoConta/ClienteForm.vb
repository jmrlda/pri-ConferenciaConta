

Public Class ClienteForm
    Dim administracao As ConferenciaAdmin = New ConferenciaAdmin()
    Dim js As JmrJson = New JmrJson()


    Private Sub ClienteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(js.CLIENTE_PATH) Then

            carregarConfiguracao()
            block_campo()
        Else
            unblock_campo()
            Me.txtCodigo.Text = ""
            Me.txtFilial.Text = ""
            Me.txtMorada.Text = ""
            Me.txtNome.Text = ""
            Me.txtNuit.Text = ""

            MessageBox.Show("Configure dados do Cliente para a validação correcta das Licenças", "Atenção - Importante", MessageBoxButtons.OK)

        End If
    End Sub


    Sub carregarConfiguracao()
        Me.txtCodigo.Text = js.getClienteConexao().Codigo
        Me.txtFilial.Text = js.getClienteConexao.filial
        Me.txtMorada.Text = js.getClienteConexao().morada
        Me.txtNome.Text = js.getClienteConexao().nome
        Me.txtNuit.Text = js.getClienteConexao.nuit
    End Sub


    Sub guardar()
        Dim cli As Cliente = New Cliente()
        If (checkCampos() = True) Then

            cli.Codigo = txtCodigo.Text
            cli.nome = txtNome.Text
            cli.filial = txtFilial.Text
            cli.morada = txtMorada.Text
            cli.nuit = txtNuit.Text
            administracao.criarEscreverFicheiro(js.CLIENTE_PATH, js.js.Serialize(cli))

            MsgBox("Cliente Salvo com sucesso")
            Me.lblMsgErro.Visible = False
            carregarConfiguracao()
            block_campo()

        Else
            Me.lblMsgErro.Visible = True

        End If
    End Sub


    Function checkCampos() As Boolean
        Dim rv As Boolean = False
        If (Me.txtCodigo.Text.Trim(" ").Length > 0 And Me.txtFilial.Text.Trim(" ").Length > 0 And Me.txtNome.Text.Trim(" ").Length > 0 And Me.txtNuit.Text.Trim(" ").Length > 0) Then
            rv = True
        Else
            rv = False
        End If

        Return rv
    End Function

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        guardar()

    End Sub

    Sub block_campo()
        Me.txtCodigo.ReadOnly = True
        Me.txtFilial.ReadOnly = True
        Me.txtMorada.ReadOnly = True
        Me.txtNome.ReadOnly = True
        Me.txtNuit.ReadOnly = True
        Me.btnGravar.Enabled = False

    End Sub

    Sub unblock_campo()
        Me.txtCodigo.ReadOnly = False
        Me.txtFilial.ReadOnly = False
        Me.txtMorada.ReadOnly = False
        Me.txtNome.ReadOnly = False
        Me.txtNuit.ReadOnly = False
        Me.btnGravar.Enabled = True

    End Sub

    Private Sub ClienteForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True
    End Sub
End Class