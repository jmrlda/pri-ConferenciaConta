Public Class stringArray

    Public lista As String

    Sub New()


        lista = ""


    End Sub

    Public Sub add(str As String)
        If (lista.Length <= 0) Then
            lista = str
        Else
            lista = lista + "," + str
        End If
    End Sub

    Public Function exists(str As String) As Integer
        Dim pos As Integer = -1

        If (tem_dados() = True) Then
            Dim arrayLi() As String = lista.Split(",")
            Dim i As Integer
            For i = 0 To arrayLi.Length - 1
                If str = arrayLi(i) Then
                    pos = i
                End If
            Next
        End If
        Return pos
    End Function

    Public Sub remover(str As String)
        If (tem_dados() = True) Then

            Dim listaAux As String = ""
            Dim arrayLi() As String = lista.Split(",")
            Dim i As Integer
            lista = ""
            For i = 0 To arrayLi.Length - 1
                If str <> arrayLi(i) Then
                    add(arrayLi(i))
                End If
            Next
        End If
    End Sub

    Public Function primeiro() As String
        Dim rv As String = ""
        If (tem_dados() = True) Then
            rv = Me.lista.Split(",").First()
        End If

        Return rv
    End Function

    Public Function ultimo() As String
        Dim rv As String = ""
        If (tem_dados() = True) Then
            rv = Me.lista.Split(",").Last()
        End If

        Return rv

    End Function

    Public Sub reset()
        Me.lista = ""
    End Sub

    Public Sub imprimir_lista()
        If (tem_dados() = True) Then
            Dim arrayLi() As String = lista.Split(",")
            Dim i As Integer
            For i = 0 To arrayLi.Length - 1
                Console.WriteLine(arrayLi(i))
            Next
        End If
    End Sub

    Public Function tem_dados() As Boolean
        Dim rv As Boolean = False

        If (lista.Length > 0) Then
            rv = True
        End If

        Return rv
    End Function

End Class
