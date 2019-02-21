Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ConferenciaContaReporteView

    Dim diario As Integer


    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        Dim cr As New ReportDocument



        cr.Load("C:\Primavera\SG900\Mapas\LP\NOVOS\pri-fechoConta.rpt")
        ' cr.SetDatabaseLogon("sa", "jmr2013!", "LAPTOP-PI4UTIJ2\PRIMAVERA", "PRITERRAMARBG")
        'rd.SetDatabaseLogon(USER_ID, USER_PASSWORD, SERVER_NAME, DATABASE_NAME);

        'With crConnectionInfo
        '    .ServerName = "LAPTOP-PI4UTIJ2\PRIMAVERA"
        '    .DatabaseName = "PRITERRAMARBG"
        '    .UserID = "sa"
        '    .Password = "jmr2013!"
        'End With

        'CrTables = cr.Database.Tables
        'For Each CrTable In CrTables
        '    crtableLogoninfo = CrTable.LogOnInfo
        '    crtableLogoninfo.ConnectionInfo = crConnectionInfo
        '    CrTable.ApplyLogOnInfo(crtableLogoninfo)
        'Next

        cr.SetParameterValue("Diario", getDiario())
        CrystalReportViewer1.ReportSource = cr
    End Sub

    Public Sub setDiario(diario As Integer)
        Me.diario = diario
    End Sub

    Public Function getDiario() As Integer
        Return Me.diario
    End Function
End Class