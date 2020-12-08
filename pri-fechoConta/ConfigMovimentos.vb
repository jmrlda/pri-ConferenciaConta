Public Class ConfigMovimentos

    Public numerario_mov As New Movimento()
    Public pagamentoAutomatico_mov As New Movimento()
    Public cheque_mov As New Movimento()
    Public outros_mov As New Movimento()
    Public abertura_mov As New Movimento()
    Public fecho_mov As New Movimento()
    Public entrada_mov As New Movimento()
    Public saida_mov As New Movimento()

    Dim lista_movimentos As New Movimentos()
    Dim loading As Boolean = False
    Dim listaCodigo As List(Of String)
    Dim listaDescricao As List(Of String)

    Dim js As JmrJson = New JmrJson()

    Dim administracao As New ConferenciaAdmin()

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        carregarConfiguracao()

        Me.Close()
    End Sub



    Private Sub chkLstMovCodigo_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkLstMovCodigo.ItemCheck

        If Not loading Then
            'Dim i As Integer = Me.chkLstMovCodigo.SelectedIndex()
            Dim i As Integer = e.Index 'Me.chkLstMovDescricao.SelectedIndex()

            Dim codigo As String
            codigo = Me.chkLstMovCodigo.Items.Item(i).ToString




            If Not (Me.chkLstMovCodigo.GetItemChecked(i)) Then
                ' Adicionar codigo que representa cada movimento a uma lista 

                If rdBtnNumerario.Checked Then
                    If Not numerario_mov.codigo.Contains(codigo) Then

                        numerario_mov.codigo.Add(codigo)
                    End If
                    numerario_mov.tipoMovimento = "numerario"

                ElseIf rdBtnCheques.Checked Then
                    If Not cheque_mov.codigo.Contains(codigo) Then

                        cheque_mov.codigo.Add(codigo)
                    End If
                    cheque_mov.tipoMovimento = "cheque"


                ElseIf rdBtnPagAutomatico.Checked Then
                    If Not pagamentoAutomatico_mov.codigo.Contains(codigo) Then

                        pagamentoAutomatico_mov.codigo.Add(codigo)
                    End If
                    pagamentoAutomatico_mov.tipoMovimento = "pagamento automatico"

                ElseIf rdBtnOutros.Checked Then
                    If Not outros_mov.codigo.Contains(codigo) Then

                        outros_mov.codigo.Add(codigo)
                    End If
                    outros_mov.tipoMovimento = "outros"
                ElseIf rdBtnAbertura.Checked Then
                    If Not abertura_mov.codigo.Contains(codigo) Then

                        abertura_mov.codigo.Add(codigo)
                    End If
                    abertura_mov.tipoMovimento = "abertura caixa"
                ElseIf rdBtnFecho.Checked Then
                    If Not fecho_mov.codigo.Contains(codigo) Then

                        fecho_mov.codigo.Add(codigo)
                    End If
                    fecho_mov.tipoMovimento = "fecho caixa"
                ElseIf rdBtnEntrada.Checked Then
                    If Not entrada_mov.codigo.Contains(codigo) Then

                        entrada_mov.codigo.Add(codigo)
                    End If
                    entrada_mov.tipoMovimento = "entrada caixa"
                ElseIf rdBtnSaida.Checked Then
                    If Not saida_mov.codigo.Contains(codigo) Then
                        saida_mov.codigo.Add(codigo)
                    End If
                    saida_mov.tipoMovimento = "saida caixa"
                End If

            Else





                    'item_idx = numerario_mov.descricao.IndexOf(descricao)

                    'While item_idx >= 0
                    '    numerario_mov.descricao.RemoveAt(item_idx)
                    '    item_idx = numerario_mov.descricao.IndexOf(descricao)

                    'End While

                    ' Remover codigo da lista de  cada movimento 
                    Dim item_idx As Integer
                    If rdBtnNumerario.Checked Then
                        item_idx = numerario_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            numerario_mov.codigo.RemoveAt(item_idx)
                            item_idx = numerario_mov.codigo.IndexOf(codigo)

                        End While
                    ElseIf rdBtnCheques.Checked Then
                        item_idx = cheque_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            cheque_mov.codigo.RemoveAt(item_idx)
                            item_idx = cheque_mov.codigo.IndexOf(codigo)

                        End While
                    ElseIf rdBtnPagAutomatico.Checked Then
                        item_idx = pagamentoAutomatico_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            pagamentoAutomatico_mov.codigo.RemoveAt(item_idx)
                            item_idx = pagamentoAutomatico_mov.codigo.IndexOf(codigo)

                        End While
                    ElseIf rdBtnOutros.Checked Then
                        item_idx = outros_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            outros_mov.codigo.RemoveAt(item_idx)
                            item_idx = outros_mov.codigo.IndexOf(codigo)

                        End While
                    ElseIf rdBtnAbertura.Checked Then
                        item_idx = abertura_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            abertura_mov.codigo.RemoveAt(item_idx)
                            item_idx = abertura_mov.codigo.IndexOf(codigo)

                        End While
                    ElseIf rdBtnFecho.Checked Then
                        item_idx = fecho_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            fecho_mov.codigo.RemoveAt(item_idx)
                            item_idx = fecho_mov.codigo.IndexOf(codigo)

                        End While
                    ElseIf rdBtnEntrada.Checked Then
                        item_idx = entrada_mov.codigo.IndexOf(codigo)
                    While item_idx >= 0
                        entrada_mov.codigo.RemoveAt(item_idx)
                        item_idx = entrada_mov.codigo.IndexOf(codigo)

                    End While
                    ElseIf rdBtnSaida.Checked Then
                        item_idx = saida_mov.codigo.IndexOf(codigo)
                        While item_idx >= 0
                            saida_mov.codigo.RemoveAt(item_idx)
                            item_idx = saida_mov.codigo.IndexOf(codigo)

                        End While
                    End If


                End If
        End If
    End Sub

    Private Sub ConfigMovimentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not System.IO.File.Exists(js.MOVIMENTO_PATH) Then


            carregarMovimentoDocumento()
        Else
            carregarConfiguracao()

        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'administracao.criarEscreverFicheiro()

        lista_movimentos.lista.Clear()
        lista_movimentos.lista.Add(numerario_mov)
        lista_movimentos.lista.Add(pagamentoAutomatico_mov)
        lista_movimentos.lista.Add(cheque_mov)
        lista_movimentos.lista.Add(abertura_mov)
        lista_movimentos.lista.Add(fecho_mov)
        lista_movimentos.lista.Add(entrada_mov)
        lista_movimentos.lista.Add(saida_mov)
        lista_movimentos.lista.Add(outros_mov)

        If (rdiMovBancario.Checked = True) Then
            lista_movimentos.modoMovimento = "bancario"
        Else
            lista_movimentos.modoMovimento = "contabilistico"
        End If



        administracao.criarEscreverFicheiro(js.MOVIMENTO_PATH, js.js.Serialize(lista_movimentos))

            MsgBox("Configuração Gravada com Sucesso")
            ConferenciaCaixa.getDescricaoMovimento()

    End Sub


    Sub carregarConfiguracao()

        Dim lista_mov As Movimentos
        Dim geral As New Movimento()
        lista_mov = js.getListaMovimento()
        Dim max As Integer = lista_mov.lista.Count()
        Dim i As Integer
        For i = 0 To max - 1
            geral = lista_mov.lista(i)
            If (geral.tipoMovimento = "numerario") Then
                numerario_mov = geral
            ElseIf (geral.tipoMovimento = "pagamento automatico") Then
                pagamentoAutomatico_mov = geral
            ElseIf (geral.tipoMovimento = "cheque") Then
                cheque_mov = geral
            ElseIf (geral.tipoMovimento = "outros") Then
                outros_mov = geral
            ElseIf (geral.tipoMovimento = "abertua caixa") Then
                abertura_mov = geral
            ElseIf (geral.tipoMovimento = "fecho caixa") Then
                fecho_mov = geral
            ElseIf (geral.tipoMovimento = "entrada caixa") Then
                entrada_mov = geral
            ElseIf (geral.tipoMovimento = "saida caixa") Then
                saida_mov = geral

            End If

        Next


        Me.chkLstMovCodigo.DataSource = administracao.buscarDocumentoMovimentoCodigo()
        Me.chkLstMovDescricao.DataSource = administracao.buscarDocumentoMovimentoDescricao()

        If lista_mov.modoMovimento = "contabilistico" Then
            rdiMovContabilistico.Checked = True
        Else
            rdiMovBancario.Checked = True
        End If

        'getContaBancaria()




    End Sub

    Private Sub chkLstMovDescricao_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkLstMovDescricao.ItemCheck

        ''If Not loading Then
        '   Dim i As Integer = Me.chkLstMovDescricao.SelectedIndex()
        Dim i As Integer = e.Index
        Dim descricao As String
            descricao = Me.chkLstMovDescricao.Items.Item(i).ToString


            If Not (Me.chkLstMovDescricao.GetItemChecked(i)) Then
            ' Adicionar codigo que representa cada movimento a uma lista 

            If rdBtnNumerario.Checked Then
                If numerario_mov.descricao.IndexOf(descricao) < 0 Then
                    numerario_mov.descricao.Add(descricao)
                End If

            ElseIf rdBtnCheques.Checked Then
                If cheque_mov.descricao.IndexOf(descricao) < 0 Then

                    cheque_mov.descricao.Add(descricao)
                End If

            ElseIf rdBtnPagAutomatico.Checked Then
                If pagamentoAutomatico_mov.descricao.IndexOf(descricao) < 0 Then

                    pagamentoAutomatico_mov.descricao.Add(descricao)
                End If

            ElseIf rdBtnOutros.Checked Then
                If outros_mov.descricao.IndexOf(descricao) < 0 Then

                    outros_mov.descricao.Add(descricao)
                End If
            ElseIf rdBtnAbertura.Checked Then
                If abertura_mov.descricao.IndexOf(descricao) < 0 Then

                    abertura_mov.descricao.Add(descricao)
                End If
            ElseIf rdBtnFecho.Checked Then
                If fecho_mov.descricao.IndexOf(descricao) < 0 Then

                    fecho_mov.descricao.Add(descricao)
                End If
            ElseIf rdBtnEntrada.Checked Then
                If entrada_mov.descricao.IndexOf(descricao) < 0 Then

                    entrada_mov.descricao.Add(descricao)
                End If
            ElseIf rdBtnSaida.Checked Then
                If saida_mov.descricao.IndexOf(descricao) < 0 Then

                    saida_mov.descricao.Add(descricao)
                End If
            End If

            Else
            ' Remover codigo da lista de  cada movimento ,
            ' 30/10/20
            ' usar loop para verificar se item ainda existe na lista e remover
            Dim item_idx As Integer
            If rdBtnNumerario.Checked Then
                item_idx = numerario_mov.descricao.IndexOf(descricao)

                While item_idx >= 0
                    numerario_mov.descricao.RemoveAt(item_idx)
                    item_idx = numerario_mov.descricao.IndexOf(descricao)

                End While
            ElseIf rdBtnCheques.Checked Then
                item_idx = cheque_mov.descricao.IndexOf(descricao)
                While item_idx >= 0
                    cheque_mov.descricao.RemoveAt(item_idx)
                    item_idx = cheque_mov.descricao.IndexOf(descricao)
            End While
            ElseIf rdBtnPagAutomatico.Checked Then
            item_idx = pagamentoAutomatico_mov.descricao.IndexOf(descricao)
                While item_idx >= 0
                    pagamentoAutomatico_mov.descricao.RemoveAt(item_idx)
                    item_idx = pagamentoAutomatico_mov.descricao.IndexOf(descricao)

                End While
            ElseIf rdBtnOutros.Checked Then
                item_idx = outros_mov.descricao.IndexOf(descricao)
                While item_idx >= 0
                    outros_mov.descricao.RemoveAt(item_idx)
                    item_idx = outros_mov.descricao.IndexOf(descricao)

                End While
            ElseIf rdBtnAbertura.Checked Then
                item_idx = abertura_mov.descricao.IndexOf(descricao)
                While item_idx >= 0
                    abertura_mov.descricao.RemoveAt(item_idx)
                    item_idx = abertura_mov.descricao.IndexOf(descricao)

                End While
            ElseIf rdBtnFecho.Checked Then
                item_idx = fecho_mov.descricao.IndexOf(descricao)
                While item_idx >= 0
                    fecho_mov.descricao.RemoveAt(item_idx)
                    item_idx = fecho_mov.descricao.IndexOf(descricao)

                End While
            ElseIf rdBtnEntrada.Checked Then
                item_idx = entrada_mov.descricao.IndexOf(descricao)
                While item_idx >= 0
                    entrada_mov.descricao.RemoveAt(item_idx)
                    item_idx = entrada_mov.descricao.IndexOf(descricao)

                End While
            ElseIf rdBtnSaida.Checked Then
                item_idx = saida_mov.descricao.IndexOf(descricao)
                    While item_idx >= 0
                    saida_mov.descricao.RemoveAt(item_idx)
                    item_idx = saida_mov.descricao.IndexOf(descricao)

                End While



                    End If

            End If
    End Sub

    Private Sub rdBtnNumerario_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnNumerario.CheckedChanged
        If (Me.rdBtnNumerario.Checked) Then
            limpar()
            Dim max As Integer = numerario_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = numerario_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next


            max = numerario_mov.descricao.Count()

            For i = 0 To max - 1
                str = numerario_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False


    End Sub

    Private Sub rdBtnPagAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnPagAutomatico.CheckedChanged

        If (Me.rdBtnPagAutomatico.Checked) Then
            limpar()
            Dim max As Integer = pagamentoAutomatico_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = pagamentoAutomatico_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next

            max = pagamentoAutomatico_mov.descricao.Count()

            For i = 0 To max - 1
                str = pagamentoAutomatico_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False
    End Sub

    Private Sub rdBtnCheques_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnCheques.CheckedChanged


        If (Me.rdBtnCheques.Checked) Then
            limpar()
            Dim max As Integer = cheque_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = cheque_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next


            max = cheque_mov.descricao.Count()

            For i = 0 To max - 1
                str = cheque_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False
    End Sub

    Private Sub rdBtnOutros_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnOutros.CheckedChanged
        If (Me.rdBtnOutros.Checked) Then
            limpar()
            Dim max As Integer = outros_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = outros_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next

            max = outros_mov.descricao.Count()

            For i = 0 To max - 1
                str = outros_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next



        End If

        loading = False
    End Sub

    Sub limpar()
        loading = True
        For Each i As Integer In chkLstMovDescricao.CheckedIndices

            chkLstMovDescricao.SetItemCheckState(i, CheckState.Unchecked)

        Next


        For Each i As Integer In chkLstMovCodigo.CheckedIndices

            chkLstMovCodigo.SetItemCheckState(i, CheckState.Unchecked)

        Next
        loading = False
    End Sub

    Sub carregarMovimentoDocumento()
        'Dim tabela As New DataTable
        'tabela = administracao.buscarDocumentoMovimento()
        'If (tabela.Rows.Count <> 0) Then
        '    For i As Integer = 0 To tabela.Rows.Count - 1
        '        listaCodigo.Add(tabela.Rows(i)("Movim"))
        '        listaDescricao.Add(tabela.Rows(i)("Descricao"))
        '    Next
        'End If


        Me.chkLstMovCodigo.DataSource = administracao.buscarDocumentoMovimentoCodigo()
        Me.chkLstMovDescricao.DataSource = administracao.buscarDocumentoMovimentoDescricao()


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnAbertura.CheckedChanged

        If (Me.rdBtnAbertura.Checked) Then
            limpar()
            Dim max As Integer = abertura_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = abertura_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next

            max = abertura_mov.descricao.Count()

            For i = 0 To max - 1
                str = abertura_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False
    End Sub

    Private Sub rdBtnFecho_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnFecho.CheckedChanged

        If (Me.rdBtnFecho.Checked) Then
            limpar()
            Dim max As Integer = fecho_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = fecho_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next

            max = fecho_mov.descricao.Count()

            For i = 0 To max - 1
                str = fecho_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False
    End Sub

    Private Sub rdBtnEntrada_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnEntrada.CheckedChanged

        If (Me.rdBtnEntrada.Checked) Then
            limpar()
            Dim max As Integer = entrada_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = entrada_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next

            max = entrada_mov.descricao.Count()

            For i = 0 To max - 1
                str = entrada_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False
    End Sub

    Private Sub rdBtnSaida_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnSaida.CheckedChanged

        If (Me.rdBtnSaida.Checked) Then
            limpar()
            Dim max As Integer = saida_mov.codigo.Count()
            Dim i As Integer
            Dim idx As Integer
            Dim str As String
            loading = True

            For i = 0 To max - 1
                str = saida_mov.codigo(i).ToString()
                idx = chkLstMovCodigo.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovCodigo.SetItemChecked(idx, True)
                End If

            Next

            max = saida_mov.descricao.Count()

            For i = 0 To max - 1
                str = saida_mov.descricao(i).ToString()
                idx = chkLstMovDescricao.Items.IndexOf(str)
                If idx >= 0 Then
                    chkLstMovDescricao.SetItemChecked(idx, True)
                End If
            Next
        End If

        loading = False
    End Sub

    Private Sub ConfigMovimentos_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'carregarConfiguracao()

    End Sub


End Class
