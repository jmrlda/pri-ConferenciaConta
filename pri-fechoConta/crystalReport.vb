
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared



Public Class crystalReport

    Dim cryRpt As New ReportDocument
    Dim reporte As New fechoContaReporte()

    Dim crpt As New ReportDocument()

    Public Sub abrirReporte()

        'Dim crtableLogoninfos As New TableLogOnInfos
        'Dim crtableLogoninfo As New TableLogOnInfo
        ''("C:\Users\jmr-guirruta\Documents\develop\projectos\primavera\pri-fechoConta\pri-fechoConta\crystalReport.vb")
        'Dim crConnectionInfo As New ConnectionInfo
        'Dim CrTables As Tables
        'Dim CrTable As Table

        'cryRpt.Load("C:\Primavera\SG900\Mapas\LP\NOVOS\pri-fechoConta.rpt")

        'With crConnectionInfo
        '    .ServerName = "LAPTOP-PI4UTIJ2\PRIMAVERA"
        '    .DatabaseName = "PRITERRAMARBG"
        '    .UserID = "sa"
        '    .Password = "jmr2013!"
        'End With

        'CrTables = cryRpt.Database.Tables
        'For Each CrTable In CrTables
        '    crtableLogoninfo = CrTable.LogOnInfo
        '    crtableLogoninfo.ConnectionInfo = crConnectionInfo
        '    CrTable.ApplyLogOnInfo(crtableLogoninfo)
        'Next

        'cryRpt.Refresh()

        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table


        cryRpt.Load("C:\Primavera\SG900\Mapas\LP\NOVOS\pri-fechoConta.rpt")

        With crConnectionInfo
                .ServerName = "LAPTOP-PI4UTIJ2\PRIMAVERA"
                .DatabaseName = "PRITERRAMARBG"
                .UserID = "sa"
                .Password = "jmr2013!"
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'crystalReport ReportSource = cryRpt _
        reporte.SetDataSource(cryRpt)
        ConferenciaContaReporteView.CrystalReportViewer1.ReportSource = reporte
        ConferenciaContaReporteView.CrystalReportViewer1.Refresh()
        ConferenciaContaReporteView.Show()

        'fechoContaReporte.ReportSource = reporte


        'fechoContaReporte.Refresh()

    End Sub


End Class
