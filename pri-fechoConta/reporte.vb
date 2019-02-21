Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class reporte
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

        Dim crpt As New ReportDocument()
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables


        With crConnectionInfo
            .ServerName = "LAPTOP-PI4UTIJ2\PRIMAVERA"
            .DatabaseName = "PRITERRAMARBG"
            .UserID = "sa"
            .Password = "jmr2013!"
        End With
        crpt.Load("C:\Primavera\SG900\Mapas\LP\NOVOS\pri-fechoConta.rpt")

        CrTables = crpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'CrystalReportViewer1.Refresh()

        CrystalReportViewer1.ReportSource = crpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class