Public Class Conexao


    Public Property servidor As String
    Public Property basedados As String
    Public Property utilizador As String
    Public Property senha As String

    Sub New()


        Me.servidor = ""
        Me.basedados = ""
        Me.utilizador = ""
        Me.servidor = ""

    End Sub
    Sub New(servidor As String, basedados As String, utilizador As String, senha As String)


        Me.servidor = servidor
        Me.basedados = basedados
        Me.utilizador = utilizador
        Me.servidor = senha

    End Sub



End Class
