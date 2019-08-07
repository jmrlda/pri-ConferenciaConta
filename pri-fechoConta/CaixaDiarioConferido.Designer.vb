<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaixaDiarioConferido
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
        Me.dgvCaixaDiariaConferido = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvCaixaDiariaConferido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCaixaDiariaConferido
        '
        Me.dgvCaixaDiariaConferido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCaixaDiariaConferido.Location = New System.Drawing.Point(0, 0)
        Me.dgvCaixaDiariaConferido.Name = "dgvCaixaDiariaConferido"
        Me.dgvCaixaDiariaConferido.Size = New System.Drawing.Size(363, 202)
        Me.dgvCaixaDiariaConferido.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(369, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 44)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Inserir Selecionados"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CaixaDiarioConferido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 208)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvCaixaDiariaConferido)
        Me.Name = "CaixaDiarioConferido"
        Me.Text = "CaixaDiarioConferido"
        CType(Me.dgvCaixaDiariaConferido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCaixaDiariaConferido As DataGridView
    Friend WithEvents Button1 As Button
End Class
