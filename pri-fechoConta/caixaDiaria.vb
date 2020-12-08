Public Class caixaDiaria
    Dim SQL As New sqlControlo
    Dim js As JmrJson = New JmrJson()



    Private Sub caixaDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SQL.temConexao() = True Then
            Dim tabela As New DataTable
            Dim contaPos As String = ConferenciaCaixa.cboContaPos.SelectedItem.ToString()
            Dim serie As String = ConferenciaCaixa.cboFacturaSerie.SelectedItem.ToString()

            tabela = SQL.buscarDado("select  ct.NumDoc, dc.Conta, dc.Diario, dc.DataAbertura, dc.SaldoAbertura, dc.UtilizadorAbertura, dc.DataFecho, dc.SaldoFecho, dc.UtilizadorFecho, dc.Estado from diarioCaixa as dc, cabecTesouraria as ct where Conta = '" + contaPos + " ' and ct.IDDiarioCaixa=dc.Id  AND ct.TipoDoc = 'FCHCX' and ct.ContaOrigem = '" + contaPos + "'  and ct.Serie = '" + serie + "'   order by dc.DataFecho desc")

            If (tabela.Rows.Count <> 0) Then

                Try
                    dgvCaixaDiaria.DataSource = tabela
                Catch ex As Exception
                    MsgBox("ocorreu um erro " + ex.Message)
                End Try

            Else
                dgvCaixaDiaria.DataSource = Nothing
            End If
        End If
    End Sub



    Private Sub caixaDiaria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ConferenciaCaixa.Enabled = True

    End Sub

    Private Sub dgvCaixaDiaria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvCaixaDiaria.MouseDoubleClick
        Dim i As Integer
        i = Me.dgvCaixaDiaria.CurrentRow.Index
        Dim diario As Integer = CInt(dgvCaixaDiaria.Rows(i).Cells(0).Value)

        ConferenciaCaixa.txtCaixaNum.Text = diario
        ConferenciaCaixa.buscarDiario = True

        Me.Close()
    End Sub


End Class