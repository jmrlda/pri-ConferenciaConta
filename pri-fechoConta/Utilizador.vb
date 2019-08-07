Public Class Utilizador

    Dim id As String
    Dim nome As String
    Dim senha As String
    Dim nivel As String
    Dim host As String = Environment.MachineName
    Dim logado As Boolean
    Dim licencaExpirado As Boolean

    Dim admin As ConferenciaAdmin = New ConferenciaAdmin()

    Public Sub New(id, nome, senha, nivel, logado)
        Me.id = id.ToString
        Me.nome = nome
        Me.senha = senha
        Me.nivel = nivel
        Me.logado = logado
        Me.host = Environment.MachineName
    End Sub

    Public Sub New(id, nome, senha, nivel, logado, expirado)
        Me.id = id.ToString
        Me.nome = nome
        Me.senha = senha
        Me.nivel = nivel
        Me.logado = logado
        Me.licencaExpirado = expirado
        Me.host = Environment.MachineName
    End Sub


    Public Sub New()
        Me.id = -1
        Me.nome = ""
        Me.senha = ""
        Me.nivel = ""
        Me.host = Environment.MachineName
        Me.logado = False
        Me.licencaExpirado = False

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
        If (logado = True) Then
            admin.setUtilizadorLogado(Me.getNome(), Me.getHost, 1)
        Else
            admin.setUtilizadorLogado(Me.getNome(), Me.getHost, 0)
        End If
        Me.logado = logado
    End Sub



    Public Sub setLicencaExpirado(expirado)
        Me.licencaExpirado = expirado
    End Sub

    Public Function getLogado() As Boolean
        Me.logado = admin.isUtilizadorLogado(Me.getNome(), Me.getHost())
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

    Public Function getLicencaExpirado() As Boolean
        Return Me.licencaExpirado
    End Function

    Public Sub setHost(host)
        Me.host = host
    End Sub

    Public Function getHost() As String
        Return Me.host
    End Function


End Class
