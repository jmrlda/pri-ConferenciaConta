<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class caixaDiaria
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(caixaDiaria))
        Me.dgvCaixaDiaria = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCaixaDiaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCaixaDiaria
        '
        Me.dgvCaixaDiaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCaixaDiaria.Location = New System.Drawing.Point(12, 1)
        Me.dgvCaixaDiaria.Name = "dgvCaixaDiaria"
        Me.dgvCaixaDiaria.ReadOnly = True
        Me.dgvCaixaDiaria.Size = New System.Drawing.Size(785, 213)
        Me.dgvCaixaDiaria.TabIndex = 0
        '
        'caixaDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 222)
        Me.Controls.Add(Me.dgvCaixaDiaria)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "caixaDiaria"
        Me.Text = "PRI-Conferencia de Caixa  -- Diarios"
        CType(Me.dgvCaixaDiaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCaixaDiaria As DataGridView
End Class
