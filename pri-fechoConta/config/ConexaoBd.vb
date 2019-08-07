Public Class Conexao


    Public Property servidor As String
    Public Property basedados As String
    Public Property utilizador As String
    Public Property senha As String
    Public Property net_path As String

    Sub New()


        Me.servidor = ""
        Me.basedados = ""
        Me.utilizador = ""
        Me.servidor = ""
        Me.net_path = ""
    End Sub
    Sub New(servidor As String, basedados As String, utilizador As String, senha As String)


        Me.servidor = servidor
        Me.basedados = basedados
        Me.utilizador = utilizador
        Me.servidor = senha
        Me.net_path = ""

    End Sub



End Class
