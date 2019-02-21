Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class sqlControloPriEmpre

    Dim utilitario As New Util
    Dim js As JmrJson = New JmrJson()
    Public sqlCon As New SqlConnection With {.ConnectionString = "Server= " + js.getConexao().servidor + ";Database=PRIEMPRE;User=" + js.getConexao().utilizador + ";Pwd=" + utilitario.Decrypt(js.getConexao().senha)}

    ' Public sqlCon As New SqlConnection With {.ConnectionString = "Server=LAPTOP-PI4UTIJ2\PRIMAVERA;Database=PRIEMPRE;User=sa;Pwd=jmr2013!"}
    Public sqlCmd As SqlCommand

    Public Function temConexao() As Boolean
        Try
            sqlCon.Open()
            sqlCon.Close()

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("[TEM CONEXAO] Sem conexão com base dados" + ex.Message, "Atenção - Importante", MessageBoxButtons.OK)
            Return False
        End Try
    End Function


    Public Function buscarDado(query As String) As DataTable
        Dim dados As New ArrayList

        Dim sqlQuery As New SqlDataAdapter(query, sqlCon)

        Dim tabela As New DataTable()
        Try
            sqlQuery.Fill(tabela)

        Catch ex As Exception
            MessageBox.Show("[BUSCAR DADO] Por algum motivo o servidor de base dados parou de funcionar" + ex.Message, "Atenção", MessageBoxButtons.OK)
            MsgBox(query)
        End Try

        Return tabela
    End Function


    Public Sub abrirCon()
        Try
            sqlCon.Open()

        Catch ex As Exception
            MsgBox("ocorreu um erro abrindo base de dados")
        End Try
    End Sub

    Public Sub fecharCon()
        Try
            sqlCon.Close()

        Catch ex As Exception
            MsgBox("ocorreu um erro fechando conexao base de dados")
        End Try
    End Sub

    Public Function conexao() As SqlConnection

        Return sqlCon
    End Function
End Class
