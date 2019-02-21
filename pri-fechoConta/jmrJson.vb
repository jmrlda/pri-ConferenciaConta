Imports System.Web.Script.Serialization
Imports System.IO


Public Class JmrJson

    Public js As JavaScriptSerializer
    Dim conBd As Conexao = New Conexao()
    Public CONEXAO_PATH As String = "conexaobd.json"
    Public CLIENTE_PATH As String = "cliente.json"

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



End Class
