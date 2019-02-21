Public Class Utilizador

    Dim id As String
    Dim nome As String
    Dim senha As String
    Dim nivel As String
    Dim logado As Boolean

    Public Sub New(id, nome, senha, nivel, logado)
        Me.id = id.ToString
        Me.nome = nome
        Me.senha = senha
        Me.nivel = nivel
        Me.logado = logado
    End Sub

    Public Sub New()
        Me.id = -1
        Me.nome = ""
        Me.senha = ""
        Me.nivel = ""
        Me.logado = False
    End Sub

    Public Sub setId(id)
        Me.id = id.ToString()
    End Sub

    Public Sub setNome(nome)
        Me.nome = nome
    End Sub

    Public Sub setNivel(nivel)
        Me.nivel = nivel
    End Sub

    Public Sub setSenha(senha)
        Me.senha = senha
    End Sub
    Public Sub setLogado(logado)
        Me.logado = logado
    End Sub

    Public Function getLogado() As Boolean
        Return Me.logado
    End Function

    Public Function getId() As Integer
        Return Me.id
    End Function

    Public Function getNome() As String
        Return Me.nome
    End Function

    Public Function getNivel() As String
        Return Me.nivel
    End Function

    Public Function getSenha() As String
        Return Me.senha
    End Function



End Class
