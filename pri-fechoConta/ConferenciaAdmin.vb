Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class ConferenciaAdmin

    Dim SQLPriEmpre As New sqlControloPriEmpre
    Dim SQLTerramar As New sqlControlo

    Dim tblPrimEmpre, tblTerramar As New DataTable
    Dim sqlResult As New SqlDataAdapter

    Public super As String = "Super administrador"
    Public administrador As String = "Administrador"
    Public tesoureiro As String = "Tesoureiro"

    Public modulo As String = "priConferenciaConta"
    Public versao As String = "1.0"

    Public Function criarTblConferenciaUtilizador() As Boolean

        Dim query As String = "create table  dbo.TDU_ConferenciaUtilizador (CDU_id uniqueIdentifier default (newId()) primary key, CDU_utilizador varchar(50), CDU_senha varchar(200), CDU_nivel varchar(50),CDU_conferenciaLicencaId uniqueidentifier null foreign key references dbo.TDU_ConferenciaLicenca(CDU_id))"

        Return SQLTerramar.criarTabela(query)
    End Function


    Public Function apagarTblConferenciaUtilizador() As Boolean
        Dim query As String = "drop table  dbo.TDU_ConferenciaUtilizador"

        Return SQLTerramar.criarTabela(query)

    End Function
    Public Function criarTblLicenca() As Boolean

        Dim query As String = "create table  dbo.TDU_ConferenciaLicenca(CDU_id uniqueIdentifier default (newId()) primary key, CDU_serie_licenca varchar(2018), CDU_numero_utilizador int ,CDU_dataLicenca date, CDU_dataLicencaFim date)"

        Return SQLTerramar.criarTabela(query)
    End Function


    Public Function apagarTblLicenca() As Boolean
        Dim query As String = "drop table  dbo.TDU_ConferenciaLicenca"

        Return SQLTerramar.criarTabela(query)

    End Function


    Public Function criarTblConferenciaCaixa() As Boolean

        Dim query As String = "create table dbo.TDU_ConferenciaCaixa (CDU_id uniqueIdentifier default (newId()) primary key, CDU_diarioCaixa int  not null, CDU_modoMovimento nvarchar(50) not null, CDU_cartaoTipo nvarchar(50),CDU_TransacaoNumero int, CDU_quantidade int, CDU_valor money not null, CDU_chequeNumero nvarchar(50), CDU_chequeDescricao nvarchar(50), CDU_dataConferencia datetime not null, CDU_utilizadorTesoureiro nvarchar(50), CDU_saidaDescricao nvarchar(50), CDU_referencia nvarchar(50))"

        Return SQLTerramar.criarTabela(query)
    End Function


    Public Function apagarTblConferenciaCaixa() As Boolean
        Dim query As String = "drop table  dbo.TDU_ConferenciaCaixa"

        Return SQLTerramar.criarTabela(query)

    End Function



    Public Function insertLicenca(serie, numeroUtilizador, dataInicio, dataFim)
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "INSERT INTO TDU_ConferenciaLicenca (CDU_serie_licenca , CDU_numero_utilizador, CDU_dataLicenca , CDU_dataLicencaFim ) VALUES ('" & serie & "',  '" & numeroUtilizador & "', '" & dataInicio & "', '" & dataFim & "')"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())
            SQLTerramar.fecharCon()

        End Try
    End Function

    Public Function removeLicenca(licenca)
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "remove from TDU_ConferenciaLicenca where CDU_id = '" & licenca & "')"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())
            SQLTerramar.fecharCon()

        End Try
    End Function


    Public Function buscarLicencas() As List(Of String)

        Dim query As String = "select * from TDU_ConferenciaLicenca"

        Dim tabela As New DataTable
        Dim listaSerie As New List(Of String)
        listaSerie.Insert(0, "Selecionar")

        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaSerie.Add(tabela.Rows(i)("CDU_serie_licenca"))
            Next
        End If

        Return listaSerie
    End Function
    Public Function existeLicencasBySerie(serie As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & serie & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False

        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            rv = True
        Else
            rv = False
        End If

        Return rv
    End Function
    Public Function buscarIdLicencasBySerie(serie As String) As String

        Dim query As String = "select CDU_id from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & serie & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False

        tabela = SQLTerramar.buscarDado(query)


        Return tabela.Rows(0)("CDU_id").ToString()
    End Function


    Public Function insertConferenciaCaixa(caixa As Integer, movimento As String, cartaoTipo As String, transacaoNumero As String, quantidade As Integer, valor As Double, chequeNumero As Integer, chequeDescricao As String, dataConferencia As Date, tesoureiro As String, saidaDescricao As String, referencia As String)
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "INSERT INTO TDU_ConferenciaCaixa ( CDU_diarioCaixa , CDU_modoMovimento , CDU_cartaoTipo , CDU_TransacaoNumero, CDU_quantidade , CDU_valor , CDU_chequeNumero , CDU_chequeDescricao , CDU_dataConferencia , CDU_utilizadorTesoureiro , CDU_saidaDescricao , CDU_referencia  ) " &
                    "VALUES ('" & caixa & "',  '" & movimento & "', '" & cartaoTipo & "','" & transacaoNumero & "', '" & quantidade & "',  '" & valor & "',  '" & chequeNumero & "',  '" & chequeDescricao & "',  '" & dataConferencia & "',  '" & tesoureiro & "',  '" & saidaDescricao & "',  '" & referencia & "')"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[INSERT CONFERENCIA CAIXA]: Ocorreu um erro  /> " + ex.Message(), "Atenção - Perigo", MessageBoxButtons.OK)
            SQLTerramar.fecharCon()

        End Try
    End Function

    Public Function removeConferenciaCaixa(caixa)
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "remove from TDU_ConferenciaCaixa where CDU_id = " & caixa & "')"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())
            SQLTerramar.fecharCon()

        End Try
    End Function


    Public Function insertConferenciaUtilizador(utilizador, senha, nivel, licenca)
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "INSERT INTO TDU_ConferenciaUtilizador ( CDU_utilizador , CDU_senha , CDU_nivel ,CDU_conferenciaLicencaId ) " &
                    "VALUES ('" & utilizador & "',  '" & Encrypt(senha) & "', '" & nivel & "','" & licenca & "')"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[insertConferenciaUtilizador] Erro " + ex.Message(), "Atenção - Perigo", MessageBoxButtons.OK)
            SQLTerramar.fecharCon()

        End Try
    End Function

    Public Function removeConferenciaUtilizador(utilizador)
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "remove from TDU_ConferenciaUtilizador where CDU_id = " & utilizador & "')"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())

            SQLTerramar.fecharCon()

        End Try
    End Function


    Public Function setSenhaUtilizador(utilizador As String, nova_senha As String) As Boolean

        Dim rv As Boolean = False
        Try

            If (SQLTerramar.temConexao()) Then
                'sqlAberturaInsert = "INSERT INTO CDU_diarioCaixa, CDU_modoMovimento, CDU_valor VALUES '" + Me.txtCaixaNum.Text + "', '" + modoReceb + "', ' " + valor + "' "
                'sqlAberturaInsert = "INSERT INTO (CDU_id, CDU_diarioCaixa, CDU_modoMovimento, CDU_valor) VALUES ('" & Me.txtCaixaNum.Text & "', '" & Me.txtCaixaNum.Text & "', '" & modoReceb & "', '" & valor.ToString() & "')"
                Dim query As String = "update TDU_ConferenciaUtilizador set CDU_senha = '" + nova_senha + "' where CDU_utilizador = '" + utilizador + "'"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())
            SQLTerramar.fecharCon()
            rv = False
        End Try

        Return rv
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



    Public Function criarFicheiroLicenca(texto_str As String)

        System.IO.File.WriteAllText("jmrLicenca.lic", texto_str)
    End Function

    Public Function lerFicheiroLicenca(ficheiro As String) As String
        Dim licenca_encoded As String = System.IO.File.ReadAllText(ficheiro)
        Return licenca_encoded
    End Function



    ' 
    ' Argumento:
    '       * utilizador    - funcionario registrado 
    '       * senha         - senha do usuario  (ja encriptada )
    '
    Public Function logar(utilizador, senha) As Utilizador

        Dim utilizador_logado As New Utilizador

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" + utilizador + "' and CDU_senha ='" + senha + "'"

        Dim tabela As New DataTable
        Dim login As Boolean = False


        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            Dim nivel As String = tabela.Rows(0)("CDU_nivel")
            utilizador_logado.setId(tabela.Rows(0)("CDU_id"))
            utilizador_logado.setNome(tabela.Rows(0)("CDU_utilizador"))
            utilizador_logado.setNivel(nivel)
            utilizador_logado.setSenha(tabela.Rows(0)("CDU_senha"))
            utilizador_logado.setLogado(True)
        Else
            utilizador_logado.setLogado(False)
        End If

        Return utilizador_logado

    End Function


    Public Function removeLicencaUsuario(usuario, nivel)

        Dim rv As Boolean = False
        Try

            If (SQLTerramar.temConexao()) Then
                Dim query As String = "delete from TDU_ConferenciaUtilizador where CDU_utilizador = '" & usuario & "' and CDU_nivel = '" & nivel & "'"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())
            SQLTerramar.fecharCon()
            rv = False

        End Try

        Return rv
    End Function
    Public Function actualizarLicencaUsuario(usuario, nivel)

        Dim rv As Boolean = False
        Try

            If (SQLTerramar.temConexao()) Then
                Dim query As String = "update  TDU_ConferenciaUtilizador set  CDU_nivel = '" & nivel & "' where  CDU_utilizador = '" & usuario & "'"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("erro " + ex.Message())
            SQLTerramar.fecharCon()
            rv = False

        End Try

        Return rv
    End Function

    Public Function isUtilizadorLicenciado(utilizador As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" & utilizador & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False


        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            rv = True
        Else
            rv = False
        End If

        Return rv
    End Function


    Public Function removeLinhasCaixa(diarioCaixa As Integer)

        Dim rv As Boolean = False
        Try

            If (SQLTerramar.temConexao()) Then
                Dim query As String = "delete from TDU_ConferenciaCaixa where CDU_diarioCaixa = '" & diarioCaixa & "'"
                SQLTerramar.abrirCon()
                Dim cmd = New SqlCommand(query, SQLTerramar.conexao)

                cmd.ExecuteNonQuery()
                SQLTerramar.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("[removeLinhasCaixa] Erro: " + ex.Message())
            SQLTerramar.fecharCon()
            rv = False

        End Try

        Return rv
    End Function

    Public Function criarEscreverFicheiro(filename As String, texto_str As String)
        'If System.IO.Directory.Exists("config") Then
        '    System.IO.Directory.CreateDirectory("config")
        'End If
        System.IO.File.WriteAllText(filename, texto_str)
    End Function

    Public Function lerFicheiro(ficheiro As String) As String
        Dim licenca_encoded As String = System.IO.File.ReadAllText(ficheiro)
        Return licenca_encoded
    End Function

    Public Function existeFicheiro(path) As Boolean
        Return System.IO.File.Exists(path)
    End Function





    Public Function isLicencaExpirado(licenca As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & licenca & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False
        Dim hoje As Date = Date.Now()
        Dim licencaFim As New Date

        Dim diasRestantes As Integer = 0
        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            licencaFim = Date.Parse(tabela.Rows(0)("CDU_dataLicencaFim"))
            diasRestantes = DateDiff(DateInterval.Day, hoje, licencaFim)

            If (diasRestantes <= 0) Then
                rv = True
            Else
                rv = False
            End If
        Else
            rv = True
        End If
        Return rv
    End Function


    Public Function isLicencaDentroPrazo(licenca As String) As Boolean
        Dim licenca_decode As String
        Dim licencaDuracaoActivacao As Integer
        Dim licencaDiaGerado As Date
        Dim hoje As Date = Date.Now()
        Dim diasRestantes As Integer = 0
        Dim rv As Boolean
        Dim dataDuracao As Date
        licenca_decode = Me.Decrypt(licenca)
        If (licenca_decode.Length > 0) Then

            licencaDiaGerado = Date.Parse(licenca_decode.Split("_")(4))
            licencaDuracaoActivacao = CInt(licenca_decode.Split("_")(5))

            dataDuracao = Date.Now().AddDays(licencaDuracaoActivacao)

            diasRestantes = DateDiff(DateInterval.Day, hoje, dataDuracao)

            If diasRestantes >= 0 Then
                rv = True
            Else
                rv = False
            End If

        Else
            rv = False

        End If
        Return rv


    End Function





    Public Function buscarUtilizadorLicenca(utilizador) As String

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" & utilizador & "'"
        Dim tabela, tblSerie As New DataTable
        Dim rv As Boolean = False
        Dim idSerie As Guid
        Dim serie As String = ""

        Try

            tabela = SQLTerramar.buscarDado(query)
            If (tabela.Rows.Count <> 0) Then
                idSerie = tabela.Rows(0)("CDU_conferenciaLicencaId")

                tblSerie = SQLTerramar.buscarDado("select * from TDU_ConferenciaLicenca where CDU_id = '" & idSerie.ToString & "'")

                If (tblSerie.Rows.Count <> 0) Then
                    serie = tblSerie.Rows(0)("CDU_serie_licenca")
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("[BUSCA UTILIZADOR LICENA] Erro:/> " + ex.Message)
        End Try

        Return serie

    End Function




    Public Function LicencaDiasExpiracao(licenca As String) As Integer

        Dim query As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & licenca & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False
        Dim hoje As Date = Date.Now()
        Dim licencaFim As New Date

        Dim diasRestantes As Integer = 0
        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            licencaFim = Date.Parse(tabela.Rows(0)("CDU_dataLicencaFim"))
            diasRestantes = DateDiff(DateInterval.Day, hoje, licencaFim)


        Else
            diasRestantes = -1
        End If
        Return diasRestantes


    End Function

    Public Function LicencaDiasExpiracao_str(licenca As String) As String
        'Dim licenca_decode As String
        'Dim licencaDuracaoActivacao As Integer
        'Dim licencaDiaGerado As Date
        'Dim hoje As Date = Date.Now()



        'licenca_decode = Me.Decrypt(licenca)
        'If (licenca_decode.Length > 0) Then

        '    licencaDiaGerado = Date.Parse(licenca_decode.Split("_")(4))
        '    licencaDuracaoActivacao = CInt(licenca_decode.Split("_")(5))


        '    diasRestantes = DateDiff(DateInterval.Day, hoje, licencaDiaGerado)
        '    If (diasRestantes <= 0) Then
        '        msgLicencaExpiracao = "A licenca em uso Expirou. Entre em contacto com a JMR para emissão da nova licença"
        '    Else
        '        msgLicencaExpiracao = "A licenca em uso esta preste a terminar dentro de " + diasRestantes + " dias"


        '    End If
        'Else

        '    msgLicencaExpiracao = "A licenca em uso inválido"
        'End If




        Dim query As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & licenca & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False
        Dim hoje As Date = Date.Now()
        Dim licencaFim As New Date
        Dim msgLicencaExpiracao As String

        Dim diasRestantes As Integer = 0
        tabela = SQLTerramar.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            licencaFim = Date.Parse(tabela.Rows(0)("CDU_dataLicencaFim"))
            diasRestantes = DateDiff(DateInterval.Day, hoje, licencaFim)

            If (diasRestantes <= 0) Then
                msgLicencaExpiracao = "A licenca em uso Expirou. Entre em contacto com a JMR para emissão da nova licença"
            Else
                msgLicencaExpiracao = "A licenca em uso esta preste a terminar dentro de " + CInt(diasRestantes).ToString + " dias"


            End If
        Else
            msgLicencaExpiracao = "A licenca em uso não foi activado. Entre em contacto com a JMR Assessoria de Gestão"
        End If
        Return msgLicencaExpiracao
    End Function


    Public Function testeConexaoBd() As Boolean

        Dim query As String = "select * from TDU_ConferenciaUtilizador "
        Dim tabela, tblSerie As New DataTable
        Dim rv As Boolean = False
        Dim idSerie As Guid
        Dim serie As String = ""

        Try

            tabela = SQLTerramar.buscarDado(query)
            If (tabela.Rows.Count <> 0) Then
                rv = True
            End If
        Catch ex As Exception
            rv = False
        End Try

        Return rv

    End Function


    Public Function actualizarImagemUtilizador(usuario, pathImage)

        Dim rv As Boolean = False
        Try

            If (SQLPriEmpre.temConexao()) Then
                Dim query As String = "update  Utilizadores set  Fotografia = '" & pathImage & "' where  Codigo = '" & usuario & "'"
                SQLPriEmpre.abrirCon()
                Dim cmd = New SqlCommand(query, SQLPriEmpre.conexao)

                cmd.ExecuteNonQuery()
                SQLPriEmpre.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MessageBox.Show("[ACTUALIZAR IMAGEM UTILIZADOR] Ocorreu um erro enquanto guardava imagem: " + ex.Message, "Atenção", MessageBoxButtons.OK)
            SQLPriEmpre.fecharCon()
            rv = False

        End Try

        Return rv
    End Function


    Public Function buscarUtilizadorImagem(usuario) As String

        Dim query As String = "select Fotografia from Utilizadores where Codigo ='" + usuario + "'"
        Dim tabela As New DataTable
        Dim path As String = ""
        Try
            If (SQLPriEmpre.temConexao()) Then

                tabela = SQLPriEmpre.buscarDado(query)
                If (tabela.Rows.Count <> 0) Then
                    path = tabela.Rows(0)("Fotografia")
                End If
            End If
        Catch ex As Exception
            path = ""
            MessageBox.Show("[BUSCAR UTILIZADOR IMAGEM] Ocorreu um erro enquanto carregava imagem: " + ex.Message, "Atenção", MessageBoxButtons.OK)
        End Try

        Return path
    End Function
End Class
