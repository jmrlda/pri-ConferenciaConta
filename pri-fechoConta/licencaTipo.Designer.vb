<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicencaTipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicencaTipo))
        Me.txtLicencaCodigo = New System.Windows.Forms.RichTextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ofdFicheiro = New System.Windows.Forms.OpenFileDialog()
        Me.btnAbrirFicheiro = New System.Windows.Forms.Button()
        Me.rdLicencaFicheiro = New System.Windows.Forms.RadioButton()
        Me.rdLicencaCodigo = New System.Windows.Forms.RadioButton()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtLicencaCodigo
        '
        Me.txtLicencaCodigo.Location = New System.Drawing.Point(25, 86)
        Me.txtLicencaCodigo.Name = "txtLicencaCodigo"
        Me.txtLicencaCodigo.Size = New System.Drawing.Size(391, 48)
        Me.txtLicencaCodigo.TabIndex = 2
        Me.txtLicencaCodigo.Text = ""
        '
        'btnSalvar
        '
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalvar.Location = New System.Drawing.Point(232, 155)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btnSalvar.TabIndex = 3
        Me.btnSalvar.Text = "Activar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Location = New System.Drawing.Point(341, 155)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Fechar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ofdFicheiro
        '
        Me.ofdFicheiro.FileName = "OpenFileDialog1"
        '
        'btnAbrirFicheiro
        '
        Me.btnAbrirFicheiro.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbrirFicheiro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAbrirFicheiro.Location = New System.Drawing.Point(25, 25)
        Me.btnAbrirFicheiro.Name = "btnAbrirFicheiro"
        Me.btnAbrirFicheiro.Size = New System.Drawing.Size(145, 23)
        Me.btnAbrirFicheiro.TabIndex = 5
        Me.btnAbrirFicheiro.Text = "Abrir Ficheiro"
        Me.btnAbrirFicheiro.UseVisualStyleBackColor = False
        '
        'rdLicencaFicheiro
        '
        Me.rdLicencaFicheiro.AutoSize = True
        Me.rdLicencaFicheiro.BackColor = System.Drawing.Color.Transparent
        Me.rdLicencaFicheiro.Location = New System.Drawing.Point(25, 2)
        Me.rdLicencaFicheiro.Name = "rdLicencaFicheiro"
        Me.rdLicencaFicheiro.Size = New System.Drawing.Size(131, 17)
        Me.rdLicencaFicheiro.TabIndex = 6
        Me.rdLicencaFicheiro.TabStop = True
        Me.rdLicencaFicheiro.Text = "Licenciar com Ficheiro"
        Me.rdLicencaFicheiro.UseVisualStyleBackColor = False
        '
        'rdLicencaCodigo
        '
        Me.rdLicencaCodigo.AutoSize = True
        Me.rdLicencaCodigo.BackColor = System.Drawing.Color.Transparent
        Me.rdLicencaCodigo.Location = New System.Drawing.Point(25, 61)
        Me.rdLicencaCodigo.Name = "rdLicencaCodigo"
        Me.rdLicencaCodigo.Size = New System.Drawing.Size(121, 17)
        Me.rdLicencaCodigo.TabIndex = 7
        Me.rdLicencaCodigo.TabStop = True
        Me.rdLicencaCodigo.Text = "Licenciar por codigo"
        Me.rdLicencaCodigo.UseVisualStyleBackColor = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Location = New System.Drawing.Point(22, 160)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(10, 13)
        Me.lblEstado.TabIndex = 8
        Me.lblEstado.Text = " "
        '
        'LicencaTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(451, 190)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.rdLicencaCodigo)
        Me.Controls.Add(Me.rdLicencaFicheiro)
        Me.Controls.Add(Me.btnAbrirFicheiro)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.txtLicencaCodigo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LicencaTipo"
        Me.Text = "PRI-Conferência de Caixa - Licenciar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLicencaCodigo As RichTextBox
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents ofdFicheiro As OpenFileDialog
    Friend WithEvents btnAbrirFicheiro As Button
    Friend WithEvents rdLicencaFicheiro As RadioButton
    Friend WithEvents rdLicencaCodigo As RadioButton
    Friend WithEvents lblEstado As Label
End Class
