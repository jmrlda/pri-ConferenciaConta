Imports CrystalDecisions.Shared

Public Class FiltroConferencia
    Dim js As JmrJson = New JmrJson()
    Dim SQL As New sqlControlo
    Dim utilitario As New Util
    Dim utilizador As String = js.getConexao().utilizador
    Dim senha As String = utilitario.Decrypt(js.getConexao().senha)
    Dim servidor As String = js.getConexao().servidor
    Dim basedados As String = js.getConexao.basedados
    Dim administracao As New ConferenciaAdmin()

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs)
        CaixaDiarioConferido.ShowDialog(Me)
    End Sub

    Private Sub FiltroConferencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstboxContaOrigem.DataSource = administracao.buscarContaConferido()
        lstboxDiariosConferidos.DataSource = administracao.buscarCaixaConferido()
    End Sub

    Private Sub cboContaOrigem_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub dtFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtFinal.ValueChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnContaCada_Click(sender As Object, e As EventArgs) Handles btnContaCada.Click
        Dim total As Integer = Me.lstboxContaOrigem.SelectedItems.Count()
        Dim i As Integer = 0
        Try
            'If Me.lstboxContaOrigemSelecionados.Items.IndexOf(Me.lstboxContaOrigem.SelectedItem) < 0 Then
            '    Me.lstboxContaOrigemSelecionados.Items.Add(Me.lstboxContaOrigem.SelectedItem)
            'End If
            For i = 0 To total
                If Me.lstboxContaOrigemSelecionados.Items.IndexOf(Me.lstboxContaOrigem.SelectedItems(i)) < 0 Then
                    Me.lstboxContaOrigemSelecionados.Items.Add(Me.lstboxContaOrigem.SelectedItems(i))
                End If
            Next i
        Catch ex As Exception
            Console.WriteLine("[btnContaCada] erro: " + ex.Message())
        End Try


    End Sub

    Private Sub btnContaTodas_Click(sender As Object, e As EventArgs) Handles btnContaTodas.Click

        Dim total As Integer = Me.lstboxContaOrigem.Items.Count()
        Dim i As Integer
        Try
            Me.lstboxContaOrigemSelecionados.Items.Clear()
            For i = 0 To total

                Me.lstboxContaOrigemSelecionados.Items.Add(Me.lstboxContaOrigem.Items(i))
            Next i

        Catch ex As Exception
            Console.WriteLine("[btnCaixaTodas] erro: " + ex.Message())
        End Try

    End Sub

    Private Sub btnContaRemover_Click(sender As Object, e As EventArgs) Handles btnContaRemover.Click
        Try
            Me.lstboxContaOrigemSelecionados.Items.RemoveAt(Me.lstboxContaOrigemSelecionados.SelectedIndex)
        Catch ex As Exception
            Console.WriteLine("[btnContaRemover] erro: " + ex.Message())
        End Try

    End Sub

    Private Sub btnContaRemoverTodas_Click(sender As Object, e As EventArgs) Handles btnContaRemoverTodas.Click
        Try
            Me.lstboxContaOrigemSelecionados.Items.Clear()
        Catch ex As Exception
            Me.lstboxContaOrigemSelecionados.DataSource = Nothing
        End Try


    End Sub

    Private Sub btnCaixaCada_Click(sender As Object, e As EventArgs) Handles btnCaixaCada.Click
        Dim total As Integer = Me.lstboxDiariosConferidos.SelectedItems.Count()
        Dim i As Integer = 0
        Try


            For i = 0 To total
                If Me.lstboxDiariosConferidoSelecionados.Items.IndexOf(Me.lstboxDiariosConferidos.SelectedItems(i).ToString().Split("/")(1).Trim()) < 0 Then
                    Me.lstboxDiariosConferidoSelecionados.Items.Add(Me.lstboxDiariosConferidos.SelectedItems(i).ToString().Split("/")(1).Trim())
                End If


            Next i
        Catch ex As Exception
            Console.WriteLine("[btnCaixaCada] erro: " + ex.Message())
        End Try

    End Sub

    Private Sub btnCaixaTodas_Click(sender As Object, e As EventArgs) Handles btnCaixaTodas.Click
        Dim total As Integer = Me.lstboxDiariosConferidos.Items.Count()
        Dim i As Integer = 0
        Try
            Me.lstboxDiariosConferidoSelecionados.Items.Clear()
            While i < total

                Me.lstboxDiariosConferidoSelecionados.Items.Add(Me.lstboxDiariosConferidos.Items(i).ToString().Split("/")(1).Trim())
                i += 1
            End While

        Catch ex As Exception
            Console.WriteLine("[btnCaixaTodas] erro: " + ex.Message())
        End Try
    End Sub

    Private Sub btnCaixaRemover_Click(sender As Object, e As EventArgs) Handles btnCaixaRemover.Click

        Try
            Me.lstboxDiariosConferidoSelecionados.Items.RemoveAt(Me.lstboxDiariosConferidoSelecionados.SelectedIndex)
        Catch ex As Exception
            Console.WriteLine("[btnContaRemover] erro: " + ex.Message())
        End Try

    End Sub

    Private Sub Button3btnCaixaRemoverTodas_Click(sender As Object, e As EventArgs) Handles btnCaixaRemoverTodas.Click
        Try
            Me.lstboxDiariosConferidoSelecionados.Items.Clear()

        Catch ex As Exception
            Me.lstboxDiariosConferidoSelecionados.DataSource = Nothing

        End Try

    End Sub

    Private Sub btnPrevisualizar_Click(sender As Object, e As EventArgs) Handles btnPrevisualizar.Click
        ' report.CrystalReportViewer5.ReportSource = New Object()

        report.Reporte_origem = "FECHO TOTAL"
        'report.cryRpt.ParameterFields.Clear()


        Dim reportPath As String
        Dim path As Util = New Util()
        Dim arrayVazio As String() = {""}
        reportPath = path.dataPathReport + "\PRIFTJMR.rpt"
        Dim msgParametroErro As String = ""
        Dim flagParametroErro As Boolean = False
        If (chkboxContaOrigem.Checked = False And chkboxDiarioCaixa.Checked = False And chkboxData.Checked = False) Then
            msgParametroErro = "Selecione um parametro"
            flagParametroErro = True

        ElseIf (chkboxContaOrigem.Checked = True And lstboxContaOrigemSelecionados.Items.Count <= 0) Or (chkboxDiarioCaixa.Checked = True And lstboxDiariosConferidoSelecionados.Items.Count <= 0) Then
            msgParametroErro = "Ao selecionar um parametro, escolha pelo menos um  filtro"
            flagParametroErro = True
        End If


        If (flagParametroErro = False) Then



            If (System.IO.File.Exists(reportPath) = True) Then
                ' cryRpt.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReport1.rpt")
                report.cryRpt.Load(reportPath)



                report.cryRpt.SetParameterValue("byConta", "False")
                report.cryRpt.SetParameterValue("byDiario", "False")
                report.cryRpt.SetParameterValue("byData", "False")
                report.cryRpt.SetParameterValue("byDataInicio", "False")
                report.cryRpt.SetParameterValue("byDataFim", "False")

                '
                ' Inicio Verificar se foi selecionado parametro CONTA
                '
                If chkboxContaOrigem.Checked = True Then
                    report.cryRpt.SetParameterValue("byConta", "True")
                    report.cryRpt.SetParameterValue("Conta", getArrayListbox(lstboxContaOrigemSelecionados).lista.Split(","))
                Else
                    report.cryRpt.SetParameterValue("byConta", "False")
                    Dim diarios As String
                    Dim lista As List(Of String)

                    If (chkboxDiarioCaixa.Checked = True And lstboxDiariosConferidoSelecionados.Items.Count > 0) Then
                        diarios = getArrayListbox(lstboxDiariosConferidoSelecionados).lista
                        lista = administracao.buscarContaConferidoByDiario(diarios)
                        report.cryRpt.SetParameterValue("Conta", getArrayListbox_(lista).lista.Split(","))
                    End If


                    If (chkboxDiarioCaixa.Checked = False And chkboxData.Checked = True) Then
                        Dim data1, data2 As String
                        data1 = utilitario.formatNum(dtInicial.Value.Day) & "-" & utilitario.formatNum(dtInicial.Value.Month) & "-" & dtInicial.Value.Year & ""
                        data2 = utilitario.formatNum(dtFinal.Value.Day) & "-" & utilitario.formatNum(dtFinal.Value.Month) & "-" & dtFinal.Value.Year & ""

                        lista = administracao.buscarContaConferidoByData(data1, data2)
                        report.cryRpt.SetParameterValue("Conta", getArrayListbox_(lista).lista.Split(","))
                    End If

                End If


                '
                ' Fim Verificar se foi selecionado parametro CONTA
                '

                '
                ' Inicio Verificar se foi selecionado parametro DIARIO CAIXA
                '

                If chkboxDiarioCaixa.Checked = True Then
                    report.cryRpt.SetParameterValue("byDiario", "True")
                    report.cryRpt.SetParameterValue("diario", getArrayListbox(lstboxDiariosConferidoSelecionados).lista.Split(","))

                Else
                    report.cryRpt.SetParameterValue("byDiario", "False")

                    Dim contas As String
                    Dim lista As List(Of String)
                    If (chkboxContaOrigem.Checked = True And lstboxContaOrigemSelecionados.Items.Count > 0) Then
                        contas = getArrayListbox_str(lstboxContaOrigemSelecionados).lista

                        lista = administracao.buscarCaixaConferidoByConta(contas)
                        If lista.Count() > 0 Then
                            report.cryRpt.SetParameterValue("diario", getArrayListbox_(lista).lista.Split(","))
                        Else
                            report.cryRpt.SetParameterValue("diario", "0")

                        End If
                    Else
                        report.cryRpt.SetParameterValue("diario", "0")
                    End If

                    If (chkboxContaOrigem.Checked = False And chkboxData.Checked = True) Then
                        Dim data1, data2 As String

                        data1 = utilitario.formatNum(dtInicial.Value.Day) & "-" & utilitario.formatNum(dtInicial.Value.Month) & "-" & dtInicial.Value.Year & ""

                        data2 = utilitario.formatNum(dtFinal.Value.Day) & "-" & utilitario.formatNum(dtFinal.Value.Month) & "-" & dtFinal.Value.Year & ""


                        lista = administracao.buscarCaixaByData(data1, data2)
                        If lista.Count() > 0 Then
                            report.cryRpt.SetParameterValue("diario", getArrayListbox_(lista).lista.Split(","))
                        Else
                            report.cryRpt.SetParameterValue("diario", 0)
                        End If
                    End If


                End If

                '
                ' Fim Verificar se foi selecionado parametro DIARIO CAIXA
                '

                '
                ' Inicio Verificar se foi selecionado parametro DATA
                '
                If chkboxData.Checked = True Then

                    report.cryRpt.SetParameterValue("byDataInicio", "True")
                    report.cryRpt.SetParameterValue("byDataFim", "True")

                    report.cryRpt.SetParameterValue("dataInicio", dtInicial.Value.ToShortDateString)
                    report.cryRpt.SetParameterValue("dataFim", dtFinal.Value.ToShortDateString)

                Else
                    Dim data As String
                    report.cryRpt.SetParameterValue("byDataInicio", "False")
                    report.cryRpt.SetParameterValue("byDataFim", "False")


                    ' Buscar data inicial e final dos caixas selecionados
                    If (chkboxDiarioCaixa.Checked = True And lstboxDiariosConferidoSelecionados.Items.Count > 0) Then
                        If (lstboxDiariosConferidoSelecionados.Items.Count = 1) Then
                            data = minData(administracao.buscarDataByDiario(lstboxDiariosConferidoSelecionados.Items(0)))
                            report.cryRpt.SetParameterValue("dataInicio", data)
                            report.cryRpt.SetParameterValue("dataFim", data)
                        ElseIf lstboxDiariosConferidoSelecionados.Items.Count > 1 Then
                            Dim min As Integer
                            Dim max As Integer


                            min = minimo(lstboxDiariosConferidoSelecionados)
                            max = maximo(lstboxDiariosConferidoSelecionados)
                            Dim data1 As String = minData(administracao.buscarDataByDiario(min))
                            Dim data2 As String = minData(administracao.buscarDataByDiario(max))

                            Dim diff As Integer = DateDiff(DateInterval.Day, CDate(data1), CDate(data2))
                            If (diff > 0) Then
                                report.cryRpt.SetParameterValue("dataInicio", data1)
                                report.cryRpt.SetParameterValue("dataFim", data2)
                            Else
                                report.cryRpt.SetParameterValue("dataInicio", data2)
                                report.cryRpt.SetParameterValue("dataFim", data1)
                            End If
                        Else

                            report.cryRpt.SetParameterValue("dataInicio", dtInicial.Value)
                            report.cryRpt.SetParameterValue("dataFim", dtFinal.Value)

                        End If


                    ElseIf (chkboxContaOrigem.Checked = True And lstboxContaOrigemSelecionados.Items.Count > 0) And (chkboxDiarioCaixa.Checked = False) Then ' Buscar data inicial e final das contas selecionados
                        Dim contas As String

                        If (lstboxContaOrigemSelecionados.Items.Count = 1) Then

                            contas = getArrayListbox_str(lstboxContaOrigemSelecionados).lista

                            data = minData(administracao.buscarDataByConta(contas))
                            report.cryRpt.SetParameterValue("dataInicio", data)
                            data = maxData(administracao.buscarDataByConta(contas))
                            report.cryRpt.SetParameterValue("dataFim", data)


                        ElseIf (lstboxContaOrigemSelecionados.Items.Count > 1) Then
                            Dim lista As List(Of String)
                            Dim data1 As String
                            Dim data2 As String

                            contas = getArrayListbox_str(lstboxContaOrigemSelecionados).lista
                            lista = administracao.buscarDataByConta(contas)
                            data1 = minData(lista)
                            data2 = maxData(lista)

                            Dim diff As Integer = DateDiff(DateInterval.Day, CDate(data1), CDate(data2))
                            If (diff > 0) Then
                                report.cryRpt.SetParameterValue("dataInicio", data1)
                                report.cryRpt.SetParameterValue("dataFim", data2)
                            Else

                                report.cryRpt.SetParameterValue("dataInicio", data2)
                                report.cryRpt.SetParameterValue("dataFim", data1)

                            End If




                        End If
                    End If
                End If

                If (chkboxContaOrigem.Checked = False And chkboxData.Checked = False And chkboxDiarioCaixa.Checked = False) Then


                    Try

                        Dim data1 As String = minData(administracao.buscarMinData())
                        Dim data2 As String = maxData(administracao.buscarMaxData())
                        Dim diff As Integer = DateDiff(DateInterval.Day, CDate(data1), CDate(data2))

                        report.cryRpt.SetParameterValue("diario", getArrayListbox(lstboxDiariosConferidos).lista.Split(","))
                        report.cryRpt.SetParameterValue("conta", getArrayListbox(lstboxContaOrigem).lista.Split(","))

                        If (diff > 0) Then
                            report.cryRpt.SetParameterValue("dataInicio", data1)
                            report.cryRpt.SetParameterValue("dataFim", data2)
                        Else

                            report.cryRpt.SetParameterValue("dataInicio", data2)
                            report.cryRpt.SetParameterValue("dataFim", data1)

                        End If

                    Catch ex As Exception
                        MessageBox.Show("Ocorreu um erro " & ex.Message, "Atenção", MessageBoxButtons.OK)
                    End Try


                End If
                '
                ' Fim Verificar se foi selecionado parametro DATA
                report.CrystalReportViewer5.ReportSource = Nothing
                report.CrystalReportViewer5.Refresh()
                report.CrystalReportViewer5.ReportSource = report.cryRpt

                'report.CrystalReportViewer5.Refresh()
                report.cryRpt.SetDatabaseLogon(utilizador, senha, servidor, basedados)
                With report.crConnectionInfo
                    .ServerName = servidor
                    'If you are connecting to Oracle there is no DatabaseName. Use an empty string. 
                    'For example, .DatabaseName = ""
                    .DatabaseName = basedados
                    .UserID = utilizador
                    .Password = senha
                End With

                'Dim pdfFilePath As String = System.IO.Path.Combine(Application.StartupPath, path.dataPathReport + "\" + "fechoTotal" + ".pdf")
                Try
                    report.ShowDialog()

                Catch ex As Exception
                    MessageBox.Show("Ocorreu um erro de formatação\n" + ex.Message, "Atenção")
                End Try
                'If System.IO.File.Exists(pdfFilePath) Then
                '    System.IO.File.Delete(pdfFilePath)
                'End If

                'report.cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFilePath)
                'pdfView pdf = New pdfView()


                'Me.OpenFileDialog1.FileName = String.Empty
                'Me.OpenFileDialog1.ShowDialog()
                'If System.IO.File.Exists(pdfFilePath) Then
                '    pdfView.AxAcroPDF1.src = pdfFilePath
                '    pdfView.AxAcroPDF1.Show()
                '    pdfView.AxAcroPDF1.Refresh()
                '    pdfView.Show()
                'End If
            End If

        Else
            'MessageBox.Show(msgParametroErro, "Atenção!", vbOK)
            MsgBox(msgParametroErro)
        End If

    End Sub

    Function getArrayListbox(lista As ListBox) As stringArray
        Dim total As Integer = lista.Items.Count
        Dim lista_str As New stringArray
        Dim i As Integer
        For i = 0 To total - 1

            lista_str.add(lista.Items(i))

        Next

        Return lista_str
    End Function

    Function getArrayListbox_(lista As List(Of String)) As stringArray
        Dim total As Integer = lista.Count
        Dim lista_str As New stringArray
        Dim i As Integer
        For i = 0 To total - 1

            lista_str.add(lista(i))



        Next

        Return lista_str
    End Function

    Function getArrayListbox_str(lista As ListBox) As stringArray
        Dim total As Integer = lista.Items.Count
        Dim lista_str As New stringArray
        Dim i As Integer
        For i = 0 To total - 1
            lista_str.add("'" + lista.Items(i) + "'")
        Next

        Return lista_str
    End Function

    Function minimo(lista As ListBox) As Integer
        Dim total As Integer = lista.Items.Count
        Dim min As Integer = 0
        Dim i As Integer
        Dim valor As Integer
        For i = 0 To total - 1
            valor = CInt(lista.Items(i))
            If i = 0 Then
                min = valor
            Else
                If min > valor Then
                    min = valor
                End If
            End If

        Next

        Return min
    End Function

    Function maximo(lista As ListBox) As Integer
        Dim total As Integer = lista.Items.Count
        Dim max As Integer = 0
        Dim i As Integer
        Dim valor As Integer
        For i = 0 To total - 1
            valor = CInt(lista.Items(i))
            If i = 0 Then
                max = valor
            Else
                If max < valor Then
                    max = valor
                End If
            End If

        Next

        Return max
    End Function


    Function maxData(lista As List(Of String)) As Date
        Dim total As Integer = lista.Count
        Dim data1 As String = ""
        Dim data2 As String = ""
        Dim i As Integer

        For i = 0 To total - 1
            If i = 0 Then
                data1 = lista(i)
            Else
                data2 = lista(i)
                Dim diff As Integer = DateDiff(DateInterval.Day, CDate(data1), CDate(data2))
                If (diff > 0) Then
                    data1 = data2
                End If
            End If
        Next

        Return data1
    End Function



    Function minData(lista As List(Of String)) As Date
        Dim total As Integer = lista.Count
        Dim data1 As String = ""
        Dim data2 As String = ""
        Dim i As Integer

        For i = 0 To total - 1
            If i = 0 Then
                data1 = lista(i)
            Else
                data2 = lista(i)
                Dim diff As Integer = DateDiff(DateInterval.Day, CDate(data1), CDate(data2))
                If (diff < 0) Then
                    data1 = data2
                End If
            End If
        Next

        Return data1
    End Function

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub
End Class