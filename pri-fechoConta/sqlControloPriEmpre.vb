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


    Public Function buscarUtilizadores()

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
