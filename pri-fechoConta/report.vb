Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared



Public Class report
    Dim diario As Integer
    Dim conta As String
    Dim js As JmrJson = New JmrJson()
    Dim administracao As ConferenciaAdmin = New ConferenciaAdmin()

    Dim utilizador As String = js.getConexao().utilizador
    Dim senha As String = administracao.Decrypt(js.getConexao().senha)
    Dim servidor As String = js.getConexao().servidor
    Dim basedados As String = js.getConexao.basedados

    Public crConnectionInfo As New ConnectionInfo()

    Public cryRpt As New ReportDocument
    Dim path As Util = New Util()
    Public Reporte_origem As String

    'filtro dados
    Dim byConta As Boolean
    Dim byCaixa As Boolean
    Dim byData As Boolean
    Dim caixa As Integer
    Dim data_inicio As String
    Dim data_final As String

    Public Sub setCaixa(byCaixa As Boolean, caixa As String)
        Me.byCaixa = byCaixa
        Me.caixa = caixa
    End Sub

    Public Function getCaixa() As String
        Return Me.caixa
    End Function



    Public Sub setDiario(d As Integer)
        diario = d
    End Sub

    Public Function getDiario() As Integer
        Return diario
    End Function

    Public Sub setConta(c As String)
        conta = c
    End Sub

    Public Function getConta() As String
        Return conta
    End Function





    Private Sub report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim reportPath As String
        'If (Reporte_origem = "FECHO CAIXA") Then
        '    reportPath = path.dataPathReport + "\PRIFCJMR.rpt"
        'Else
        '    reportPath = path.dataPathReport + "\PRIFTJMR.rpt"
        'End If

        'Try

        '    If (System.IO.File.Exists(reportPath) = True) Then
        '    ' cryRpt.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReport1.rpt")
        '    cryRpt.Load(reportPath)
        '    cryRpt.SetDatabaseLogon(utilizador, senha, servidor, basedados)
        '    With crConnectionInfo
        '        .ServerName = servidor
        '        'If you are connecting to Oracle there is no DatabaseName. Use an empty string. 
        '        'For example, .DatabaseName = ""
        '        .DatabaseName = basedados
        '        .UserID = utilizador
        '        .Password = senha
        '    End With
        '    If (Reporte_origem = "FECHO CAIXA") Then
        '        cryRpt.SetParameterValue("Diario", getDiario())
        '        cryRpt.SetParameterValue("Conta", getConta())
        '    End If

        '    CrystalReportViewer1.ReportSource = cryRpt
        '        CrystalReportViewer1.Refresh()

        '    Else
        '        MessageBox.Show("Mapa de Reporter não encontrado", "Atenção", MessageBoxButtons.OK)
        '    Me.Close()
        'End If

        'Catch ex As Exception
        '    MessageBox.Show("Ocorreu um erro", "Atenção", MessageBoxButtons.OK)
        'End Try

    End Sub

    ' exportar report por pdf
    'Try
    'Dim CrExportOptions As ExportOptions
    'Dim CrDiskFileDestinationOptions As New _
    '        DiskFileDestinationOptions()
    'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
    '        cryRpt.Load(path.dataPathReport + "PRIFCJMR.rpt")
    '        cryRpt.SetDatabaseLogon(utilizador, senha, servidor, basedados)

    '        'cryRpt.SetParameterValue("Diario", getDiario())
    '        'cryRpt.SetParameterValue("Conta", getConta())
    '        cryRpt.SetDatabaseLogon(utilizador, senha, servidor, basedados)

    '        cryRpt.SetParameterValue("Diario", getDiario())
    '        cryRpt.SetParameterValue("Conta", getConta())
    '        CrystalReportViewer1.ReportSource = cryRpt

    '        CrDiskFileDestinationOptions.DiskFileName = path.dataPathReport & "/" & Date.Now() & ".pdf"

    '        CrExportOptions = cryRpt.ExportOptions
    '        With CrExportOptions
    '.ExportDestinationType = ExportDestinationType.DiskFile
    '.ExportFormatType = ExportFormatType.PortableDocFormat
    '.DestinationOptions = CrDiskFileDestinationOptions
    '.FormatOptions = CrFormatTypeOptions
    'End With
    '        cryRpt.Export()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

End Class