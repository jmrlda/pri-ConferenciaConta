Public Class CaixaDiarioConferido
    Dim SQL As New sqlControlo
    Dim js As JmrJson = New JmrJson()
    Private Sub CaixaDiarioConferido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SQL.temConexao() = True Then
            Dim tabela As New DataTable

            tabela = SQL.buscarDado("select distinct CDU_diarioCaixa as 'Caixa Diario', CDU_conta as 'Posto', CDU_dataConferencia from TDU_ConferenciaCaixa order by CDU_dataConferencia")

            If (tabela.Rows.Count <> 0) Then

                Try
                    dgvCaixaDiariaConferido.DataSource = tabela
                Catch ex As Exception
                    MsgBox("ocorreu um erro " + ex.Message)
                End Try

            Else
                dgvCaixaDiariaConferido.DataSource = Nothing
            End If
        End If
    End Sub
End Class