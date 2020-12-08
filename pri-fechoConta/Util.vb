Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Util




    Public dataMainPath As String = ""
    Public dataPathConfig As String = ""
    Public dataPathReport As String = ""



    Public Sub New()
        dataMainPath = System.AppDomain.CurrentDomain.BaseDirectory()


        dataPathConfig = dataMainPath + "config"
        dataPathReport = dataMainPath + "report"


    End Sub

    Public Sub New(path)
        dataMainPath = path
        dataPathConfig = dataMainPath + "config"
        dataPathReport = dataMainPath + "report"


    End Sub



    Public Function change_duracao_str_int(duracao As String)

        '1 Mês
        '3 Meses
        '6 Meses
        '1 Ano

        Dim duracao_int As Integer
        If (duracao.Equals("1 Mês") = True) Then
            duracao_int = 31
        ElseIf (duracao.Equals("3 Meses") = True) Then
            duracao_int = 93
        ElseIf (duracao.Equals("6 Meses") = True) Then
            duracao_int = 186
        ElseIf (duracao.Equals("1 Ano") = True) Then
            duracao_int = 365
        Else
            duracao_int = 0
        End If


        Return duracao_int
    End Function




    Public Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "#JMR2013!soft"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function


    Public Function Decrypt(cipherText As String) As String
        Try

            Dim EncryptionKey As String = "#JMR2013!soft"
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using
        Catch ex As Exception
            cipherText = ""
        End Try

        Return cipherText
    End Function

    Public Function soNumero(valor As String) As String
        'MsgBox(valor)
        Console.WriteLine(valor)
        Dim newValor As String
        Dim formated As String
        newValor = "0"
        If (valor.Length > 0) Then
            Dim digitsOnly As Regex = New Regex("[a-zA-Z]")

            newValor = digitsOnly.Replace(valor, "")
            If newValor = "" Then
                newValor = "0"
            End If
        End If
        formated = Format(newValor, "Standard").Trim()
        Return formated
    End Function


    Public Function formatNum(val As Integer) As String
        Dim newVal As String = ""
        If (val < 10) Then
            newVal = "0" & val
        Else
            newVal = val
        End If

        Return newVal
    End Function



    Public Function removeSpace(str As String) As String
        Dim i As Integer

        For i = 0 To str.Length - 1
            If str(i).ToString() = " " Then
                str.Remove(i)

            End If
        Next

        Return str
    End Function


    Public Function changeDotToComa(str As String) As String
        Dim newStr As String = ""
        Dim ch As Char

        For Each ch In str

            If ch = "." Then
                ch = ","
            End If

            newStr = newStr & ch
        Next
        Return newStr
    End Function


    Public Function changeComaToDot(str As String) As String
        Dim newStr As String = ""
        Dim ch As Char

        For Each ch In str

            If ch = "," Then
                ch = "."
            End If

            newStr = newStr & ch
        Next

        Return newStr
    End Function





End Class
