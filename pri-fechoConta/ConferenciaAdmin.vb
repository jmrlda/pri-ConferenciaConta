Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Script.Serialization

' Class ConferenciaAdmin 
' PROPOSITO : Controlar o acesso ao sistema de actua como intermediario na troca de dados entre base de dados  demais componentes do sistema
'
'
Public Class ConferenciaAdmin

    Dim SQLPriEmpre As New sqlControloPriEmpre
    Dim SQL As New sqlControlo

    Dim tblPrimEmpre, tblTerramar As New DataTable
    Dim sqlResult As New SqlDataAdapter

    Public super As String = "Super administrador"
    Public administrador As String = "Administrador"
    Public tesoureiro As String = "Tesoureiro"

    Public modulo As String = "priConferenciaConta"
    Public versao As String = "1.0.2"




    Public Function criarTblConferenciaUtilizador() As Boolean

        Dim query As String = "create table  dbo.TDU_ConferenciaUtilizador (CDU_id uniqueIdentifier default (newId()) primary key, CDU_utilizador varchar(50), CDU_senha varchar(200), CDU_nivel varchar(50), CDU_logado bit default 0, CDU_host varchar(64) null  ,CDU_conferenciaLicencaId uniqueidentifier null foreign key references dbo.TDU_ConferenciaLicenca(CDU_id))"

        Return SQL.criarTabela(query)
    End Function


    Public Function apagarTblConferenciaUtilizador() As Boolean
        Dim query As String = "drop table  dbo.TDU_ConferenciaUtilizador"

        Return SQL.criarTabela(query)

    End Function
    Public Function criarTblLicenca() As Boolean

        Dim query As String = "create table  dbo.TDU_ConferenciaLicenca(CDU_id uniqueIdentifier default (newId()) primary key, CDU_serie_licenca varchar(2018), CDU_numero_utilizador int ,CDU_dataLicenca varchar(30), CDU_dataLicencaFim varchar(30))"

        Return SQL.criarTabela(query)
    End Function


    Public Function apagarTblLicenca() As Boolean
        Dim query As String = "drop table  dbo.TDU_ConferenciaLicenca"

        Return SQL.criarTabela(query)

    End Function


    Public Function criarTblConferenciaCaixa() As Boolean

        Dim query As String = "create table TDU_ConferenciaCaixa (CDU_id uniqueIdentifier default (newId()) primary key, CDU_diarioCaixa  integer not null, CDU_modoMovimento nvarchar(50) not null, CDU_cartaoTipo nvarchar(50),CDU_TransacaoNumero  nvarchar(50), CDU_quantidade integer, CDU_valor varchar(64) not null, CDU_chequeNumero nvarchar(50), CDU_chequeDescricao nvarchar(50), CDU_dataConferencia varchar(50), CDU_utilizadorTesoureiro nvarchar(50), CDU_saidaDescricao nvarchar(50), CDU_referencia nvarchar(50),  CDU_IdCabecTesouraria uniqueidentifier not null, CDU_conta nvarchar(32) not null, CDU_data_fecho varchar(255), CDU_data_transacao varchar(32) null, CDU_rec_num_inicial integer default(0), CDU_rec_num_final integer default(0), CDU_rec_serie nvarchar(32))"

        Return SQL.criarTabela(query)
    End Function


    Public Function apagarTblConferenciaCaixa() As Boolean
        Dim query As String = "drop table  dbo.TDU_ConferenciaCaixa"

        Return SQL.criarTabela(query)

    End Function



    Public Sub insertLicenca(serie As String, numeroUtilizador As Integer, dataInicio As String, dataFim As String)
        Try


            If (SQL.temConexao()) Then
                Dim query As String = "INSERT INTO TDU_ConferenciaLicenca (CDU_serie_licenca , CDU_numero_utilizador, CDU_dataLicenca , CDU_dataLicencaFim ) VALUES ('" & serie & "',  '" & numeroUtilizador & "', '" & dataInicio & "', '" & dataFim & "')"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)
                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("[INSERT LICENCA] erro " + ex.Message())
            SQL.fecharCon()

        End Try
    End Sub

    Public Sub removeLicenca(codigo As String)
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "delete from TDU_ConferenciaLicenca where CDU_id = '" & codigo & "'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[REMOVE LICENCA] Erro " + ex.Message(), "Atenção", MessageBoxButtons.OK)
            SQL.fecharCon()

        End Try
    End Sub

    Public Sub removeLicencaBySerie(licenca)
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "delete from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & licenca & "'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[REMOVE LICENCA By SERIE] Erro " + ex.Message(), "Atenção", MessageBoxButtons.OK)
            SQL.fecharCon()

        End Try
    End Sub

    Public Function buscarLicencas() As List(Of String)

        Dim query As String = "select * from TDU_ConferenciaLicenca"

        Dim tabela As New DataTable
        Dim listaSerie As New List(Of String)
        listaSerie.Insert(0, "Selecionar")

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaSerie.Add(tabela.Rows(i)("CDU_serie_licenca"))
            Next
        End If

        Return listaSerie
    End Function
    Public Function buscarDataFechoDiario(diario As String) As String

        Dim query As String = "select DataFecho from diariocaixa where Diario= '" & diario & "'"

        Dim tabela As New DataTable
        Dim data As String = ""

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                data = tabela.Rows(i)("DataFecho")
            Next
        End If

        Return data
    End Function

    Public Function existeLicencasBySerie(serie As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & serie & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False

        tabela = SQL.buscarDado(query)
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

        tabela = SQL.buscarDado(query)


        Return tabela.Rows(0)("CDU_id").ToString()
    End Function


    Public Function insertConferenciaCaixa(caixa As Integer, movimento As String, cartaoTipo As String, transacaoNumero As String, quantidade As Integer, valor As Double, chequeNumero As String, chequeDescricao As String, dataConferencia As String, tesoureiro As String, saidaDescricao As String, referencia As String, idCabecTesourario As String, contaPos As String, data_fecho As String, data_transacao As String, rec_inicial As Integer, rec_final As Integer, rec_serie As String)

        Try

            If (SQL.temConexao()) Then
                Dim query As String = "INSERT INTO TDU_ConferenciaCaixa ( CDU_diarioCaixa , CDU_modoMovimento , CDU_cartaoTipo , CDU_TransacaoNumero, CDU_quantidade , CDU_valor , CDU_chequeNumero , CDU_chequeDescricao , CDU_dataConferencia , CDU_utilizadorTesoureiro , CDU_saidaDescricao , CDU_referencia, CDU_IdCabecTesouraria, CDU_conta, CDU_data_fecho, CDU_data_transacao, CDU_rec_num_inicial, CDU_rec_num_final, CDU_rec_serie) " &
                    "VALUES ('" & caixa & "',  '" & movimento & "', '" & cartaoTipo & "','" & transacaoNumero & "', '" & quantidade & "',  '" & valor & "',  '" & chequeNumero & "',  '" & chequeDescricao & "',  '" & dataConferencia & "',  '" & tesoureiro & "',  '" & saidaDescricao & "',  '" & referencia & "', '" & idCabecTesourario & "', '" & contaPos & "', '" & data_fecho & "' ,'" & data_transacao & "', '" & rec_inicial & "', '" & rec_final & "', '" & rec_serie & "' )"
                SQL.abrirCon()

                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[INSERT CONFERENCIA CAIXA]: Ocorreu um erro  /> " + ex.Message(), "Atenção - Perigo", MessageBoxButtons.OK)
            SQL.fecharCon()

            Return False
        End Try

        Return True
    End Function

    Public Sub removeConferenciaCaixa(caixa)
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "remove from TDU_ConferenciaCaixa where CDU_id = " & caixa & "')"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("[REMOVE CONFERENCIA CAIXA] erro " + ex.Message())
            SQL.fecharCon()

        End Try
    End Sub


    Public Sub insertConferenciaUtilizador(utilizador, senha, nivel, licenca)
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "INSERT INTO TDU_ConferenciaUtilizador ( CDU_utilizador , CDU_senha , CDU_nivel ,CDU_conferenciaLicencaId ) " &
                    "VALUES ('" & utilizador & "',  '" & Encrypt(senha) & "', '" & nivel & "','" & licenca & "')"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MessageBox.Show("[INSERT CONFERENCIA UTILIZADOR] Erro " + ex.Message(), "Atenção - Perigo", MessageBoxButtons.OK)
            SQL.fecharCon()

        End Try
    End Sub

    Public Sub removeConferenciaUtilizador(utilizador)
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "remove from TDU_ConferenciaUtilizador where CDU_id = " & utilizador & "')"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
            End If
        Catch ex As Exception
            MsgBox("[REMOVE CONFERENCIA UTILIZADOR] erro " + ex.Message())

            SQL.fecharCon()

        End Try
    End Sub


    Public Function setSenhaUtilizador(utilizador As String, nova_senha As String) As Boolean

        Dim rv As Boolean = False
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "update TDU_ConferenciaUtilizador set CDU_senha = '" + nova_senha + "' where CDU_utilizador = '" + utilizador + "'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("[SET SENHA UTILIZADOR] erro " + ex.Message())
            SQL.fecharCon()
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



    Public Sub criarFicheiroLicenca(texto_str As String)

        System.IO.File.WriteAllText("jmrLicenca.lic", texto_str)
    End Sub

    Public Function lerFicheiroLicenca(ficheiro As String) As String
        Dim licenca_encoded As String = System.IO.File.ReadAllText(ficheiro)
        Return licenca_encoded
    End Function



    ' inicio logar
    ' PROPOSITO :   entrar no sistema para iniciar as actividades
    ' Argumento:
    '   * utilizador    - funcionario registrado 
    '   * senha         - senha do usuario  (ja encriptada )
    ' RETORNO :  Objecto Utilizador com dados do usuario logado
    '
    Public Function logar(utilizador, senha) As Utilizador

        Dim utilizador_logado As New Utilizador

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" + utilizador + "' and CDU_senha ='" + senha + "'"
        Dim estado As Boolean = False
        Dim tabela As New DataTable
        Dim login As Boolean = False

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then

            Dim nivel As String = tabela.Rows(0)("CDU_nivel")
            utilizador_logado.setNome(tabela.Rows(0)("CDU_utilizador"))


            utilizador_logado.setId(tabela.Rows(0)("CDU_id"))
            utilizador_logado.setNivel(nivel)
            utilizador_logado.setSenha(tabela.Rows(0)("CDU_senha"))
            utilizador_logado.setLogado(True)


        Else
            utilizador_logado.setLogado(False)
        End If

        Return utilizador_logado

    End Function



    ' Definir presenca do utilizador 
    Public Function setUtilizadorLogado(usuario, host, logado)

        Dim rv As Boolean = False
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "update  TDU_ConferenciaUtilizador set  CDU_host = '" & host & "',  CDU_logado = '" & logado & "' where  CDU_utilizador = '" & usuario & "'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MessageBox.Show("[SET UTILIZADOR LOGs] Ocorreu um erro enquanto actualizava estado de presença " + ex.Message, "Atenção", MessageBoxButtons.OK)
            SQL.fecharCon()
            rv = False

        End Try

        Return rv
    End Function


    Public Function isUtilizadorLogado(utilizador As String, host As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" & utilizador & "' and CDU_logado = 1 and CDU_host = '" & host & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False


        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            rv = True
        Else
            rv = False
        End If

        Return rv
    End Function


    Public Function isUtilizadorLogadoNoutroComputador(utilizador As String, host As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" & utilizador & "' and CDU_logado = 1"
        Dim tabela As New DataTable
        Dim rv As Boolean = False
        Dim _host As String = ""

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            _host = tabela.Rows(0)("CDU_host")
            If _host.Length > 1 And _host <> host Then
                rv = True
            Else
                rv = False
            End If

        Else
            rv = False
        End If

        Return rv
    End Function



    Public Function removeLicencaUsuario(usuario, nivel)

        Dim rv As Boolean = False
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "delete from TDU_ConferenciaUtilizador where CDU_utilizador = '" & usuario & "' and CDU_nivel = '" & nivel & "'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("[REMOVE LICENCA USUARIO] erro " + ex.Message())
            SQL.fecharCon()
            rv = False

        End Try

        Return rv
    End Function
    Public Function removeUsuarioByLicenca(licenca As String)

        Dim rv As Boolean = False
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "delete from TDU_ConferenciaUtilizador where CDU_conferenciaLicencaId = '" & Me.buscarIdLicencasBySerie(licenca) & "' and CDU_nivel not like  'Super administrador'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("[REMOVE USUARIO BY LICENCA] erro " + ex.Message())
            SQL.fecharCon()
            rv = False

        End Try

        Return rv
    End Function
    Public Function actualizarLicencaUsuario(usuario, nivel)

        Dim rv As Boolean = False
        Try

            If (SQL.temConexao()) Then
                Dim query As String = "update  TDU_ConferenciaUtilizador set  CDU_nivel = '" & nivel & "' where  CDU_utilizador = '" & usuario & "'"
                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("[ACTUALIZAR LICENCA USUARIO] erro " + ex.Message())
            SQL.fecharCon()
            rv = False

        End Try

        Return rv
    End Function

    Public Function isUtilizadorLicenciado(utilizador As String) As Boolean

        Dim query As String = "select * from TDU_ConferenciaUtilizador where CDU_utilizador = '" & utilizador & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False


        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            rv = True
        Else
            rv = False
        End If

        Return rv
    End Function


    Public Function removeLinhasCaixa(diarioCaixa As Integer, conta As String, data As String, rec_inicial As Integer, rec_final As Integer, rec_serie As String)
        Dim query As String
        Dim rv As Boolean = False
        Try

            If (SQL.temConexao()) Then

                If (conta = "CXMT") Then
                    query = "delete from TDU_ConferenciaCaixa where CDU_conta = '" & conta & "' and CDU_data_fecho = '" & data & "'  and CDU_rec_num_inicial = '" & rec_inicial & "' and CDU_rec_num_final = '" & rec_final & "'   and CDU_rec_serie = '" & rec_serie & "'"
                Else
                    query = "delete from TDU_ConferenciaCaixa where CDU_diarioCaixa = '" & diarioCaixa & "'"

                End If

                SQL.abrirCon()
                Dim cmd = New SqlCommand(query, SQL.conexao)

                cmd.ExecuteNonQuery()
                SQL.fecharCon()
                rv = True
            End If
        Catch ex As Exception
            MsgBox("[REMOVE LINHA CAIXA] Erro: " + ex.Message())
            SQL.fecharCon()
            rv = False

        End Try

        Return rv
    End Function

    Public Sub criarEscreverFicheiro(filename As String, texto_str As String)
        'If System.IO.Directory.Exists("config") Then
        '    System.IO.Directory.CreateDirectory("config")
        'End If
        System.IO.File.WriteAllText(filename, texto_str)
    End Sub

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
        tabela = SQL.buscarDado(query)
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

            Dim data = licenca_decode.Split("_")(4)
            data = data.Split(" ")(0)
            licencaDiaGerado = Date.Parse(data)
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

            tabela = SQL.buscarDado(query)
            If (tabela.Rows.Count <> 0) Then
                idSerie = tabela.Rows(0)("CDU_conferenciaLicencaId")

                tblSerie = SQL.buscarDado("select * from TDU_ConferenciaLicenca where CDU_id = '" & idSerie.ToString & "'")

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
        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            licencaFim = Date.Parse(tabela.Rows(0)("CDU_dataLicencaFim"))
            diasRestantes = DateDiff(DateInterval.Day, hoje, licencaFim)


        Else
            diasRestantes = -1
        End If
        Return diasRestantes


    End Function

    Public Function LicencaDiasExpiracao_str(licenca As String) As String

        Dim query As String = "select * from TDU_ConferenciaLicenca where CDU_serie_licenca = '" & licenca & "'"
        Dim tabela As New DataTable
        Dim rv As Boolean = False
        Dim hoje As Date = Date.Now()
        Dim licencaFim As New Date
        Dim msgLicencaExpiracao As String

        Dim diasRestantes As Integer = 0
        tabela = SQL.buscarDado(query)
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

        Dim query As String = "select * from Artigo "
        Dim tabela, tblSerie As New DataTable
        Dim rv As Boolean = False

        Dim serie As String = ""

        Try

            tabela = SQL.buscarDado(query)
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



    Public Function buscarDocumentoMovimentoCodigo() As List(Of String)

        Dim query As String = "select * from DocumentosBancos where MovUtilizadoEmPOS='true' or CDU_fac=1 "
        Dim query1 As String = "select * from DocumentosTesouraria where Documento in ('ABTCX', 'FCHCX', 'SAICX', 'ENTCX') "
        'Dim query1 As String = "select * from DocumentosTesouraria   "

        Dim tabela As New DataTable

        Dim listaCodigo As New List(Of String)


        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaCodigo.Add(tabela.Rows(i)("Movim"))

            Next
        End If
        tabela = SQL.buscarDado(query1)

        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                If listaCodigo.IndexOf(tabela.Rows(i)("Documento")) < 0 Then
                    listaCodigo.Add(tabela.Rows(i)("Documento"))
                End If

            Next
        End If

        Return listaCodigo
    End Function

    Public Function buscarDocumentoMovimentoDescricao() As List(Of String)

        Dim query As String = "select * from DocumentosBancos  where MovUtilizadoEmPOS='true' or  CDU_fac=1"
        Dim query1 As String = "select * from DocumentosTesouraria where Documento in ('ABTCX', 'FCHCX', 'SAICX', 'ENTCX') "

        Dim tabela As New DataTable

        Dim listaDescricao As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaDescricao.Add(tabela.Rows(i)("Descricao"))
            Next
        End If
        tabela = SQL.buscarDado(query1)

        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                If listaDescricao.IndexOf(tabela.Rows(i)("Descricao")) < 0 Then

                    listaDescricao.Add(tabela.Rows(i)("Descricao"))
                End If
            Next
        End If

        listaDescricao.Add("Venda")
        Return listaDescricao
    End Function



    ' Inicio Consultar
    ' PROPOSITO: Consulta generica a tabelas da  base de dados e retornar dados de uma coluna especifica
    ' ARGUMENTO: 
    '   * query  - consulta
    '   * coluna - coluna de onde quer-se extrair o valor
    ' RETORNO :
    '   * List(OF String) - Lista de String com valores da coluna indicada
    '
    Public Function consultaColuna(query As String, coluna As String) As List(Of String)
        Dim tabela As New DataTable

        Dim listaDescricao As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaDescricao.Add(tabela.Rows(i)(coluna))
            Next
        End If

        Return listaDescricao
    End Function
    ' Fim consultarColuna


    ' Inicio Consultar
    ' PROPOSITO: Consulta generica a tabelas da  base de dados
    ' ARGUMENTO: 
    '   * query - consulta
    ' RETORNO :
    '   * DataTable - Dados da tabela
    '
    Public Function consultar(query As String) As DataTable
        Dim tabela As New DataTable
        Dim listaDescricao As New List(Of String)

        tabela = SQL.buscarDado(query)
        Return tabela

    End Function

    ' Fim consultar



    Public Function buscarCaixaConferido() As List(Of String)

        'Dim query As String = "SELECT distinct CDU_diarioCaixa  FROM TDU_ConferenciaCaixa "
        Dim query As String = "select distinct ct.numDoc as numDoc, tc.CDU_diarioCaixa as diarioCaixa from CabecTesouraria as ct, TDU_ConferenciaCaixa as tc, DiarioCaixa as dc where ct.TipoDoc = 'FCHCX' and  ct.IDDiarioCaixa = dc.Id and dc.Diario = tc.CDU_diarioCaixa"
        Dim tabela As New DataTable

        Dim listaCaixa As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaCaixa.Add((tabela.Rows(i)("numDoc") & " / " & tabela.Rows(i)("diarioCaixa")))
            Next
        End If


        Return listaCaixa
    End Function

    Public Function buscarContaConferido() As List(Of String)

        Dim query As String = "SELECT distinct CDU_conta  FROM TDU_ConferenciaCaixa"
        Dim tabela As New DataTable

        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("CDU_conta"))
            Next
        End If

        Return listaConta
    End Function

    Public Function buscarContaConferidoByDiario(diario As String) As List(Of String)

        Dim query As String = "SELECT distinct CDU_conta  FROM TDU_ConferenciaCaixa where CDU_diarioCaixa in (" + diario + ")"
        Dim tabela As New DataTable

        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("CDU_conta"))
            Next
        End If


        Return listaConta
    End Function


    Public Function buscarCaixaConferidoByConta(conta As String) As List(Of String)

        Dim query As String = "SELECT distinct CDU_diarioCaixa  FROM TDU_ConferenciaCaixa where CDU_conta in (" + conta + ")"
        Dim tabela As New DataTable

        Dim listaCaixa As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaCaixa.Add(tabela.Rows(i)("CDU_diarioCaixa"))
            Next
        End If


        Return listaCaixa
    End Function


    Public Function buscarDataByDiario(diario As String) As List(Of String)

        Dim query As String = "SELECT  distinct CDU_dataConferencia  FROM TDU_ConferenciaCaixa where CDU_diarioCaixa = '" + diario + "'"
        Dim tabela As New DataTable

        Dim listaCaixa As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaCaixa.Add(tabela.Rows(i)("CDU_dataConferencia"))
            Next
        End If


        Return listaCaixa
    End Function

    Public Function buscarDataByConta(conta As String) As List(Of String)

        Dim query As String = "SELECT distinct CDU_dataConferencia  FROM TDU_ConferenciaCaixa where CDU_conta in (" + conta + ")"
        Dim tabela As New DataTable

        Dim listaCaixa As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaCaixa.Add(tabela.Rows(i)("CDU_dataConferencia"))
            Next
        End If


        Return listaCaixa
    End Function



    Public Function buscarContaConferidoByData(data1 As String, data2 As String) As List(Of String)

        Dim query As String = "select distinct CDU_conta  from TDU_ConferenciaCaixa where CDU_data_fecho between '" + data1 + "' and '" + data2 + "'"
        Dim tabela As New DataTable
        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("CDU_conta"))


            Next
        End If


        Return listaConta
    End Function


    Public Function buscarCaixaByData(data1 As String, data2 As String) As List(Of String)
        Dim query As String = "select distinct CDU_diarioCaixa from TDU_ConferenciaCaixa where  CDU_dataConferencia between '" + data1 + "' and '" + data2 + "'"
        Dim tabela As New DataTable
        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("CDU_diarioCaixa"))


            Next
        End If

        Return listaConta
    End Function


    Public Function buscarMaxData() As List(Of String)
        Dim query As String = "select MAX(CDU_dataConferencia) as maxData from TDU_ConferenciaCaixa group by CDU_conta"
        Dim tabela As New DataTable
        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("maxData"))
            Next
        End If

        Return listaConta
    End Function

    Public Function buscarMinData() As List(Of String)
        Dim query As String = "select MIN(CDU_dataConferencia) as maxData from TDU_ConferenciaCaixa group by CDU_conta"
        Dim tabela As New DataTable
        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("maxData"))
            Next
        End If

        Return listaConta
    End Function


    Public Function countMaxUtilizadorBySerie(serie As String) As Integer
        Dim query As String = "SELECT CDU_numero_utilizador total_utilizador  FROM TDU_ConferenciaLicenca where CDU_serie_licenca = '" + serie + "'"
        Dim tabela As New DataTable
        Dim total_utilizador As Integer

        Try

            tabela = SQL.buscarDado(query)
            If (tabela.Rows.Count <> 0) Then
                For i As Integer = 0 To tabela.Rows.Count - 1
                    total_utilizador = tabela.Rows(i)("total_utilizador")
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("[countMaxUtilizadorBySerie] " + ex.Message())
            total_utilizador = -1
        End Try

        Return total_utilizador
    End Function

    '
    ' Buscar todos bancos em utilizacao no primavera
    Public Function buscarBancos() As List(Of String)
        Dim tabela As New DataTable

        Dim listaDescricao As New List(Of String)
        listaDescricao.Add("Selecionar")
        Try

            tabela = SQL.buscarDado("select Descricao from Bancos")
            If (tabela.Rows.Count <> 0) Then
                For i As Integer = 0 To tabela.Rows.Count - 1
                    listaDescricao.Add(tabela.Rows(i)("Descricao"))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("[buscarBancos] Ocorreu um erro enquanto buscava bancos " + ex.Message, "Atenção", MessageBoxButtons.OK)
            SQL.fecharCon()

        End Try

        Return listaDescricao
    End Function

    '
    ' Buscar nome da maquina do ultimo utilizador logado
    Public Function buscarMaquinaRemoto(usuario) As String
        Dim tabela As New DataTable

        Dim listaDescricao As New List(Of String)
        Dim maquina As String = ""
        Try


            tabela = SQL.buscarDado("select CDU_host from TDU_ConferenciaUtilizador where cdu_utilizador = '" & usuario & "' ")
            If (tabela.Rows.Count <> 0) Then
                maquina = tabela.Rows(0)("CDU_host")
            End If
        Catch ex As Exception
            MessageBox.Show("[buscarMaquinaRemoto] Ocorreu um erro enquanto buscava maquina remoto " + ex.Message, "Atenção", MessageBoxButtons.OK)
            SQL.fecharCon()
            maquina = ""

        End Try
        Return maquina
    End Function


    Public Function buscarSerie() As List(Of String)
        Dim query As String = "select Serie from SeriesCCT where tipodoc='RE'"
        Dim tabela As New DataTable
        Dim listaConta As New List(Of String)

        tabela = SQL.buscarDado(query)
        If (tabela.Rows.Count <> 0) Then
            For i As Integer = 0 To tabela.Rows.Count - 1
                listaConta.Add(tabela.Rows(i)("Serie"))
            Next
        End If

        Return listaConta
    End Function

End Class
