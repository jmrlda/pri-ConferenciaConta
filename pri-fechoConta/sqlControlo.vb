Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class sqlControlo

    Dim js As JmrJson = New JmrJson()
    Dim utilitario As Util = New Util
    'Me.txtBasedados.Text = js.getConexao().basedados
    'Me.txtSenha.Text = js.getConexao().senha
    'Me.txtServidor.Text = js.getConexao().servidor
    'Me.txtUtilizadorBd.Text = js.getConexao().utilizador
    Public sqlCon As New SqlConnection With {.ConnectionString = "Server=" + js.getConexao().servidor + ";Database=" + js.getConexao().basedados + ";User=" + js.getConexao().utilizador + ";Pwd=" + utilitario.Decrypt(js.getConexao().senha)}
    Public sqlCmd As SqlCommand



    Public Function temConexao() As Boolean
        Try
            sqlCon.Open()

            sqlCon.Close()

            Return True

        Catch ex As Exception
            MsgBox("Erro abertura base de dados " + ex.Message)
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
            MsgBox("Por algum motivo o servidor de base dados parou de funcionar. Tente novamente ou entre em contacto com o administrador " + ex.Message)
        End Try

        Return tabela
    End Function

    Public Function query(qr As String) As SqlDataAdapter
        Try
            Dim sql As New SqlDataAdapter(qr, sqlCon)

            Return sql
        Catch ex As Exception
            MsgBox("ocorreu um erro na query")
        End Try

        Return Nothing

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

    Public Function checkExisteTabela()

    End Function


    ' Proposito - Criar tabelas na base de dados PRITERRAMAR
    '
    ' Retorno : 
    '   * True - se tiver criado as tabelas com sucesso
    '   * False - se a tabela ja estiver criada.

    Public Function criarTabela(sql) As Boolean
        Dim rv As Boolean

        Try
            'Dim sql As String
            sqlCmd = New SqlCommand(sql, sqlCon)
            sqlCmd.Connection.Open()
            sqlCmd.ExecuteNonQuery()
            sqlCmd.Connection.Close()
            rv = True
        Catch
            'MsgBox(" Tabela ja criada", MsgBoxStyle.Critical, " MaS InfoTech- Warning")
            rv = False
            sqlCmd.Connection.Close()

        End Try

        Return rv
    End Function


End Class
