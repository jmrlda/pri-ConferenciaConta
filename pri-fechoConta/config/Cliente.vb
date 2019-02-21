Public Class Cliente

    Public Property id As String
    Public Property Codigo As String
    Public Property nome As String
    Public Property filial As String
    Public Property morada As String
    Public Property localidade As String
    Public Property nuit As Integer

    Sub New()
        Me.id = ""
        Me.Codigo = ""
        Me.nome = ""
        Me.filial = ""
        Me.morada = ""
        Me.localidade = ""
        Me.nuit = -1
    End Sub

    Sub New(id As String, codigo As String, nome As String, filial As String, morada As String, localidade As String, nuit As Integer)
        Me.id = id
        Me.Codigo = codigo
        Me.nome = nome
        Me.filial = filial
        Me.morada = morada
        Me.localidade = localidade
        Me.nuit = nuit
    End Sub


End Class