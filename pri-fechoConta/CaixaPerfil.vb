Public Class CaixaPerfil

    Dim administracao As New ConferenciaAdmin

    Private Sub CaixaPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setRegisto()
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
            End If
            cboUtilizador.DataSource = utilizadores
        Else
            MsgBox("sem conexao")

        End If

    End Sub

    Private Sub btnAlterarImagem_Click(sender As Object, e As EventArgs) Handles btnAlterarImagem.Click

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                If (Me.cboUtilizador.SelectedIndex > 0) Then
                    administracao.actualizarImagemUtilizador(Me.cboUtilizador.Text, OpenFileDialog1.FileName)
                    Me.pboxPerfil.ImageLocation = administracao.buscarUtilizadorImagem(Me.cboUtilizador.Text)

                End If

            Catch ex As Exception
                MessageBox.Show("Ocorreu um erro no carregamento de imagem " + ex.Message, "Atenção", MessageBoxButtons.OK)
            End Try

        End If
    End Sub

    Private Sub cboUtilizador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUtilizador.SelectedIndexChanged
        If Me.cboUtilizador.SelectedIndex > 0 Then
            Me.btnAlterarImagem.Enabled = True
            Me.pboxPerfil.ImageLocation = administracao.buscarUtilizadorImagem(Me.cboUtilizador.Text)

        Else
            Me.btnAlterarImagem.Enabled = False

        End If
    End Sub
End Class