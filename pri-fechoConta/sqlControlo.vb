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
        ajustarConexao()
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
        ajustarConexao()
        Dim dados As New ArrayList

        Dim tabela As New DataTable()

        Try
            Dim sqlQuery As New SqlDataAdapter(query, sqlCon)
            sqlQuery.Fill(tabela)

        Catch ex As Exception
            MsgBox("[buscarDado] Por algum motivo o servidor de base dados parou de funcionar. Tente novamente ou entre em contacto com o administrador " + ex.Message)

        End Try

        Return tabela
    End Function

    Public Function query(qr As String) As SqlDataAdapter
        ajustarConexao()
        Try
            Dim sql As New SqlDataAdapter(qr, sqlCon)

            Return sql
        Catch ex As Exception
            MsgBox("[query] Ocorreu um erro na query")
        End Try

        Return Nothing

    End Function

    Public Sub abrirCon()
        ajustarConexao()
        Try
            sqlCon.Open()

        Catch ex As Exception
            MsgBox("[abrirCon] Ocorreu um erro abrindo base de dados")
        End Try
    End Sub

    Public Sub fecharCon()
        Try
            sqlCon.Close()

        Catch ex As Exception
            MsgBox("[fecharCon] Ocorreu um erro fechando conexao base de dados")
        End Try
    End Sub


    Public Function conexao() As SqlConnection
        ajustarConexao()
        Return sqlCon
    End Function




    ' Proposito - Criar tabelas na base de dados PRITERRAMAR
    '
    ' Retorno : 
    '   * True - se tiver criado as tabelas com sucesso
    '   * False - se a tabela ja estiver criada.

    Public Function criarTabela(sql) As Boolean
        Dim rv As Boolean
        ajustarConexao()
        Try
            'Dim sql As String
            sqlCmd = New SqlCommand(sql, sqlCon)
            sqlCmd.Connection.Open()
            sqlCmd.ExecuteNonQuery()
            sqlCmd.Connection.Close()
            rv = True
        Catch ex As Exception

            rv = False
            ' MsgBox("[criarTabela] Ocorreu um erro  na criacão de tabela " + ex.Message(), MsgBoxStyle.Critical, " MaS InfoTech- Warning")
            sqlCmd.Connection.Close()

        End Try

        Return rv
    End Function

    Sub ajustarConexao()
        If sqlCon.ConnectionString = "Server=;Database=;User=;Pwd=" Then
            sqlCon = New SqlConnection With {.ConnectionString = "Server=" + js.getConexao().servidor + ";Database=" + js.getConexao().basedados + ";User=" + js.getConexao().utilizador + ";Pwd=" + utilitario.Decrypt(js.getConexao().senha)}

        End If

    End Sub

    Public Function resetComissaoInterveniente()

        Try

            If (temConexao()) Then
                Dim query = "delete from ComissaoInterveniente"
                abrirCon()

                Dim cmd = New SqlCommand(query, conexao)

                cmd.ExecuteNonQuery()
                fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[REMOVE COMISSAO INTERVENIENTE]: Ocorreu um erro  /> " + ex.Message(), "Atenção - Perigo", MessageBoxButtons.OK)
            fecharCon()

            Return False
        End Try

        Return True
    End Function

    Public Function insertUpdateComissaoInterveniente()

        Try

            If (temConexao()) Then
                Dim query = "insert into ComissaoInterveniente(id, vendedor, nome,  classe, especialidade, posto, comissao, data, filial, tipoDoc, serie, numDoc, entidade, nomeEntidade, total, comVenda  )  select cd.id, ld.Vendedor, v.Nome, v.CDU_classe, v.CDU_Especialidade, cd.Posto, c.Comissao, ld.Data, cd.Filial, cd.TipoDoc, cd.Serie, cd.NumDoc, cd.Entidade, cli.Nome, case  when ld.precUnit = 0 then ld.CDU_pliquido else cast(ld.precUnit  as float) end as total, case  when ld.precUnit <= 0 then ld.CDU_pliquido * (c.Comissao/100) else ld.precUnit * (c.Comissao/100) end  as comVenda from CabecDoc cd, LinhasDoc ld, Vendedores v, Comissoes c, Artigo a, ArtigoMoeda am, Clientes cli where cd.id = ld.IdCabecDoc and v.Vendedor = ld.Vendedor and c.Campo1 = ld.Vendedor and c.Campo2 = a.Familia and cd.Entidade = cli.Cliente and a.Artigo = am.Artigo and am.Moeda = 'MT'   and ld.Vendedor is not NULL order by NumDoc asc"
                abrirCon()

                Dim cmd = New SqlCommand(query, conexao)

                cmd.ExecuteNonQuery()
                fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[INSERT COMISSAO INTERVENIENTE]: Ocorreu um erro  /> " + ex.Message(), "Atenção - Perigo", MessageBoxButtons.OK)
            fecharCon()

            Return False
        End Try

        Return True
    End Function

End Class
