Imports Microsoft.Win32

Public Class config_acesso_remoto
    Dim administracao As ConferenciaAdmin = New ConferenciaAdmin()

    Private Sub config_acesso_remoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        Me.ofd.ValidateNames = False
        Me.ofd.CheckFileExists = False

        Me.ofd.CheckPathExists = True
        ofd.FileName = "folderselection"
        If Me.ofd.ShowDialog = DialogResult.OK Then

            txtPath.Text = System.IO.Path.GetFullPath(ofd.FileName)
            txtPath.Text = txtPath.Text.Replace("folderselection", "").Trim()

            'Dim fi As New FileInfo(Me.ofd.sel)

            'MsgBox(fi.Directory.ToString)
        End If
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click

        If Not System.IO.Directory.Exists(Me.txtPath.Text) Then
            MessageBox.Show("Caminho Selecionado não encontrado! Selecione novamente", "Atenção", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Caminho Selecionado  encontrado! ", "Atenção", MessageBoxButtons.OK)

        End If
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click





        Me.Close()
    End Sub
End Class