Imports System.Web.Script.Serialization
Imports System.IO


Public Class JmrJson

    Public js As JavaScriptSerializer

    Dim conBd As Conexao = New Conexao()
    Dim conBdAdmin As Conexao = New Conexao()

    Dim movDb As Movimentos = New Movimentos()
    Dim utilitario As New Util

    ' msgbox("config")

    Public CONEXAO_PATH As String = utilitario.dataPathConfig + "\conexaobd.json"
    Public CONEXAO_PATH_ADMIN As String = utilitario.dataPathConfig + "\conexaobdadmin.json"

    Public CLIENTE_PATH As String = utilitario.dataPathConfig + "\cliente.json"
    Public MOVIMENTO_PATH As String = utilitario.dataPathConfig + "\movimento.json"

    Dim cliDb As Cliente = New Cliente

    Sub New()
        js = New JavaScriptSerializer()

        'If System.IO.File.Exists("..\..\config\conexaobd.json") = True Then

        '    Dim jsStr As String = File.ReadAllText("..\..\config\conexaobd.json")
        '    conBd = js.Deserialize(Of Conexao)(jsStr)
        'End If

    End Sub

    Public Function getConexao() As Conexao
        js = New JavaScriptSerializer()

        If System.IO.File.Exists(CONEXAO_PATH) Then


            Dim jsStr As String = File.ReadAllText(CONEXAO_PATH)
            conBd = js.Deserialize(Of Conexao)(jsStr)
            Return Me.conBd
        End If

        Return New Conexao()
    End Function

    Public Function getClienteConexao() As Cliente
        js = New JavaScriptSerializer()

        If System.IO.File.Exists(CLIENTE_PATH) Then

            Dim jsStr As String = File.ReadAllText(CLIENTE_PATH)
            cliDb = js.Deserialize(Of Cliente)(jsStr)
            Return Me.cliDb
        End If

        Return New Cliente()
    End Function
    Public Function getListaMovimento() As Movimentos
        js = New JavaScriptSerializer()

        If System.IO.File.Exists(MOVIMENTO_PATH) Then

            Dim jsStr As String = File.ReadAllText(MOVIMENTO_PATH)
            movDb = js.Deserialize(Of Movimentos)(jsStr)
            Return Me.movDb
        End If

        Return New Movimentos()
    End Function

    Public Function getConexaoAdmin() As Conexao
        js = New JavaScriptSerializer()

        If System.IO.File.Exists(CONEXAO_PATH_ADMIN) Then


            Dim jsStr As String = File.ReadAllText(CONEXAO_PATH_ADMIN)
            conBdAdmin = js.Deserialize(Of Conexao)(jsStr)
            Return Me.conBdAdmin
        End If

        Return New Conexao()
    End Function


End Class
