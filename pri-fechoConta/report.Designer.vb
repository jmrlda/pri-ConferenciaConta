<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class report
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CrystalReportViewer5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CrystalReportViewer5
        '
        Me.CrystalReportViewer5.ActiveViewIndex = -1
        Me.CrystalReportViewer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer5.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer5.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer5.Name = "CrystalReportViewer5"
        Me.CrystalReportViewer5.Size = New System.Drawing.Size(700, 495)
        Me.CrystalReportViewer5.TabIndex = 0
        '
        'report
        '
        Me.ClientSize = New System.Drawing.Size(700, 495)
        Me.Controls.Add(Me.CrystalReportViewer5)
        Me.Name = "report"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalReportViewer5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReportViewer3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReportViewer4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
