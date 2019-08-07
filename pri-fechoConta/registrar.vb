Public Class registrar

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Dim administacao As New ConferenciaAdmin

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub registrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setRegisto()
    End Sub


    Private Sub setRegisto()
        Dim SQLPriTerramar As New sqlControlo
        Dim tblPriTerrmar As New DataTable
        Dim utilizadores As New List(Of String)
        utilizadores.Add("Selecionar Utilizador")

        If SQLPriTerramar.temConexao() = True Then

            tblPriTerrmar = SQLPriTerramar.buscarDado("select CDU_utilizador from TDU_ConferenciaUtilizador where CDU_nivel not like '%Super%'")

            If (tblPriTerrmar.Rows.Count <> 0) Then
                For i As Integer = 0 To tblPriTerrmar.Rows.Count - 1
                    utilizadores.Add(tblPriTerrmar.Rows(i)("CDU_utilizador"))
                Next

                cboUtilizador.DataSource = utilizadores
            End If

        End If


    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        If (cboUtilizador.SelectedIndex <= 0) Then
            'MessageBox.Show("Por favor Selecione um Utilizador ", "Erro no Registo", MessageBoxButtons.OK)
            lblMsgErro.Text = "Por favor Selecione um Utilizador"
            lblMsgErro.Visible = True
        ElseIf (txtSenha.Text.Length = 0 Or txtConfirmarSenha.Text.Length = 0) Then
            'MessageBox.Show("Campos em branco devem ser preenchidos", "Erro no Registo", MessageBoxButtons.OK)
            lblMsgErro.Text = "Campos em branco devem ser preenchidos"
            lblMsgErro.Visible = True

        ElseIf (txtSenha.Text.Length < 6) Then
            'MessageBox.Show("Por favor insira no minimo 6 caracteres", "Erro no Registo", MessageBoxButtons.OK)
            lblMsgErro.Text = "Por favor insira no minimo 6 caracteres"
            lblMsgErro.Visible = True

        ElseIf ((txtConfirmarSenha.Text.Length <> txtSenha.Text.Length) Or Not txtSenha.Text.Equals(txtConfirmarSenha.Text)) Then
            'MessageBox.Show("Por favor confirme a senha corretamente", "Erro no Registo", MessageBoxButtons.OK)
            lblMsgErro.Text = "Por favor confirme a senha corretamente"
            lblMsgErro.Visible = True

        Else
            lblMsgErro.Visible = False
            Dim resultado As Boolean = administacao.setSenhaUtilizador(cboUtilizador.Text, administacao.Encrypt(txtConfirmarSenha.Text))

            If (resultado) Then
                If cboUtilizador.Text = ConferenciaCaixa.utilizador_logado.getNome() Then
                    ConferenciaCaixa.setLogado(New Utilizador)
                End If
                MsgBox("Senha criado com sucesso, Precisa entrar no Sistema para iniciar as actividades")
                Me.Close()
            Else
                MsgBox("Ocorreu um erro enquanto registava. Por favor entre em contacto com o administrador")

            End If
        End If
    End Sub

    Private Sub registrar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True

    End Sub

    Private Sub btnAlterarImagem_Click(sender As Object, e As EventArgs) Handles btnAlterarImagem.Click

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                If (Me.cboUtilizador.SelectedIndex > 0) Then
                    administacao.actualizarImagemUtilizador(Me.cboUtilizador.Text, OpenFileDialog1.FileName)
                    Me.pboxPerfil.ImageLocation = administacao.buscarUtilizadorImagem(Me.cboUtilizador.Text)

                End If

            Catch ex As Exception
                MessageBox.Show("Ocorreu um erro no carregamento de imagem " + ex.Message, "Atenção", MessageBoxButtons.OK)
            End Try

        End If

    End Sub

    Private Sub cboUtilizador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUtilizador.SelectedIndexChanged
        If cboUtilizador.SelectedIndex > 0 Then
            Me.btnAlterarImagem.Enabled = True
            Me.btnNovaSenha.Enabled = True
            Me.pboxPerfil.ImageLocation = administacao.buscarUtilizadorImagem(Me.cboUtilizador.Text)
        Else
            Me.btnAlterarImagem.Enabled = False
            Me.btnNovaSenha.Enabled = False
            Me.btnRegistrar.Enabled = False
        End If
    End Sub

    Private Sub btnNovaSenha_Click(sender As Object, e As EventArgs) Handles btnNovaSenha.Click
        unblockSenha()
    End Sub


    Sub blockSenha()
        Me.txtConfirmarSenha.Enabled = False
        Me.txtSenha.Enabled = False
        Me.btnRegistrar.Enabled = False


    End Sub

    Sub unblockSenha()
        Me.txtConfirmarSenha.Enabled = True
        Me.txtSenha.Enabled = True
        Me.btnRegistrar.Enabled = True

    End Sub
End Class
