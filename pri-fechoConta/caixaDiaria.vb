Public Class caixaDiaria
    Dim SQL As New sqlControlo



    Private Sub caixaDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SQL.temConexao() = True Then
            Dim tabela As New DataTable
            tabela = SQL.buscarDado("select * from diarioCaixa ")

            If (tabela.Rows.Count <> 0) Then

                Try
                    dgvCaixaDiaria.DataSource = tabela
                Catch ex As Exception
                    MsgBox("ocorreu um erro " + ex.Message)
                End Try

            Else

            End If
        End If
    End Sub

    Private Sub dgvCaixaDiaria_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCaixaDiaria.CellEndEdit

    End Sub

    Private Sub dgvCaixaDiaria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCaixaDiaria.CellDoubleClick
        Dim i As Integer
        i = Me.dgvCaixaDiaria.CurrentRow.Index
        Dim diario As Integer = CInt(dgvCaixaDiaria.Rows(i).Cells(2).Value)

        ConferenciaCaixa.txtCaixaNum.Text = diario

        Me.Close()

    End Sub

    Private Sub caixaDiaria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True

    End Sub
End Class