﻿Imports Mach4
Imports System.IO
Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Web.Script.Serialization


Public Class MainForm

    ' Comando Numérico de Máquinas Ferramentas
    ' 10 Nov 2020
    ' ***********************************************
    ' Comentários para organizar correctamente o programa
    ' os nomes dos obejctos devem ter a estrutura:
    '       - tipo objecto + Funçao do Objecto + Opção
    '       - Exemplo:  txt_PosEixoX_Man        
    '                   txt - Text Box
    '                   PosEixoX - Posição eixo X
    '                   Man - Opção modo Manual

    ' DECLARAçÂO DE VARIÁVEIS GLOBAIS
    ' As variáveis Globais são declaradas no módulo: GlobalVars

    ' O CODIGO ASSOCIADO A CADA GRUPO DEVE SER COLOCADO NOS MÓDULOS RESPECTIVOS

    ' QUANDO NECESSÁRIO COLOCAR O CÓDIGO NO MAIN FORM NA ZONA INDICADA.
    ' ver comentários no programa;

    'Private Mach4.IMach4 _Mach = null;
    ' Private Mach4.IMyScriptObject Script = null;

    Public mach As Mach4.IMach4
    Public scriptObject As Mach4.IMyScriptObject

    ' Variável de demonstração do ficheiro de configuração
    Public Manual_ManualFeedRate As Integer

    'variaveis parametros
    'portCom
    Dim myPort As Array
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data





    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' LEITURA FICHEIRO DE CONFIGURACOES PARAMETROS-----------------------------------

        'parametros portcom
        myPort = IO.Ports.SerialPort.GetPortNames()
        param_cb_portcom.Items.AddRange(myPort)

        'parametros default
        inicializarParamEixos()
        inicializarParamFerramentas()
        inicializarParamGerais()
        inicializarParamReferenciais()

        'ficheiros de parametros
        readParamGerais(GlobalVars.param_gerais_path)
        readParamEixos(GlobalVars.param_eixos_path)
        readParamFerramentas(GlobalVars.param_ferramentas_path)
        readParamReferenciais(GlobalVars.param_referenciais_path)

        '--------------------------------------------------------------------------------

        ' Propriedades Iniciais
        ' Modo Manual
        StatusStripLbl_Modo.Text = "Modo Manual"

        ' Abertura das comunicações com o Match3
        mach = GetObject(, "Mach4.Document")
        scriptObject = mach.GetScriptDispatch()

        ' Necessário confirmar se o Match3 está OK

        ' Definições do temporizador para leitura de posição dos eixos (Match3)
        tmr_match3.Interval = 250
        tmr_match3.Enabled = True


    End Sub

    Private Sub TabCtrl_Option_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabCtrl_Option.Selecting
        ' Selecao de uma determinada página
        PaginaSelecionada = TabCtrl_Option.SelectedIndex.ToString

        Select Case (PaginaSelecionada)
            Case "0"
                ' Modo Manual
                StatusStripLbl_Modo.Text = "Modo Manual"

                Dim pp As ManualRotinas = New ManualRotinas

                pp.Perimetro(5)
                txt_AutFeedRate.Text = pp.Per
               ' txt_ManPosX.Text = PosX.PosEixoX.ToString

            Case "1"
                ' Modo Automático
                StatusStripLbl_Modo.Text = "Modo Automático"
            Case "2"
                ' Programas
                StatusStripLbl_Modo.Text = "Programas G Code"
            Case "3"
                ' Tabelas
                StatusStripLbl_Modo.Text = "Tabelas"
            Case "4"
                ' Parametros
                StatusStripLbl_Modo.Text = "Parametros"
            Case "5"
                ' Avisos / Help
                StatusStripLbl_Modo.Text = "Avisos"
            Case Else
                ' Outros....
                StatusStripLbl_Modo.Text = "Outros... Erro..."

        End Select


    End Sub

    '*******************************************************************
    '*******************************************************************


    ' *******************************************
    ' ROTINAS MODO MANUAL
    ' *******************************************

    Private Sub btn_ManSet_Click(sender As Object, e As EventArgs) Handles btn_ManSet.Click
        ' Zero Maquina
        ' A Borges - 28 Nov 2020
        Manual_SetRefPoint()
    End Sub

    Private Sub btn_ManXmenos_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManXmenos.MouseDown
        ' Deslocamento Eixo X-
        scriptObject.DoOEMButton(308)
    End Sub

    Private Sub btn_ManXmenos_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManXmenos.MouseUp
        ' Quando Liberta o X- Interrompe o movimento
        scriptObject.DoOEMButton(334)
    End Sub

    Private Sub btn_ManXmais_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManXmais.MouseUp
        ' Quando Liberta o X+ Interrompe o movimento
        scriptObject.DoOEMButton(334)
    End Sub

    Private Sub btn_ManXmais_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManXmais.MouseDown
        ' Movimento Manual X+
        scriptObject.DoOEMButton(307)
    End Sub

    Private Sub btn_ManMovToPos_Click(sender As Object, e As EventArgs) Handles btn_ManMovToPos.Click
        ' Modo Manual
        ' Move para o ponto definido...
        Dim auxMDI As String

        ' Abertura das comunicações com o Match3
        mach = GetObject(, "Mach4.Document")
        scriptObject = mach.GetScriptDispatch()

        auxMDI = "G90 G01 F" + Manual_ManualFeedRate.ToString + " X" + txt_PosManEixoX.Text

        scriptObject.Code(auxMDI.Trim())



    End Sub

    ' *******************************************
    ' ROTINAS MODO AUTOMÁTICO
    ' *******************************************



    ' *******************************************
    ' ROTINAS PROGRAMA
    ' *******************************************


    ' *******************************************
    ' ROTINAS TABELAS
    ' *******************************************


    Private Sub inicializarParamFerramentas()
        'GlobalVars.param_ferramentas.Add(idTool + "_NOME", CStr(param_dataGrid.Rows(i).Cells(1).FormattedValue))
        'GlobalVars.param_ferramentas.Add(idTool + "_POCKET", CStr(param_dataGrid.Rows(i).Cells(2).FormattedValue))
        'GlobalVars.param_ferramentas.Add(idTool + "_ALTURA", CStr(param_dataGrid.Rows(i).Cells(3).FormattedValue))
        'GlobalVars.param_ferramentas.Add(idTool + "_DIAMETRO", CStr(param_dataGrid.Rows(i).Cells(4).FormattedValue))
        'GlobalVars.param_ferramentas.Add(idTool + "_OBSERCACOES", CStr(param_dataGrid.Rows(i).Cells(5).FormattedValue))
    End Sub

    Private Sub inicializarParamReferenciais()
        'GlobalVars.param_referenciais.Add(ref_name + "_X", CStr(tab_referenciais.Rows(i).Cells(1).FormattedValue))
        'GlobalVars.param_referenciais.Add(ref_name + "_Y", CStr(tab_referenciais.Rows(i).Cells(2).FormattedValue))
        'GlobalVars.param_referenciais.Add(ref_name + "_Z", CStr(tab_referenciais.Rows(i).Cells(3).FormattedValue))
    End Sub

    Private Sub readParamFerramentas(path As String)
        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros ferramentas
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_ferramentas = jss.Deserialize(Of Dictionary(Of String, String))(json)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página da tabela de ferramentas são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página da tabela de ferramentas são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' display on GUI
        Dim i As Integer
        Dim j As Integer = 0
        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_ferramentas
            If j = 0 Then
                i = tab_ferramentas.Rows.Add()
                tab_ferramentas.Rows(i).Cells(j).Value = kvp.Key.Split("_")(0)
                j = j + 1
                tab_ferramentas.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            Else
                tab_ferramentas.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            End If

            If j = tab_ferramentas.Columns.Count Then
                j = 0
            End If
        Next

    End Sub

    Private Sub readParamReferenciais(path As String)
        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros ferramentas
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_referenciais = jss.Deserialize(Of Dictionary(Of String, String))(json)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página da tabela de referenciais são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página da tabela de referenciais são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' display on GUI
        Dim i As Integer
        Dim j As Integer = 0
        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_referenciais
            If j = 0 Then
                i = tab_referenciais.Rows.Add()
                tab_referenciais.Rows(i).Cells(j).Value = kvp.Key.Split("_")(0)
                j = j + 1
                tab_referenciais.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            Else
                tab_referenciais.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            End If

            If j = tab_referenciais.Columns.Count Then
                j = 0
            End If
        Next

    End Sub

    Private Sub btn_tabelas_ferramentas_Click(sender As Object, e As EventArgs) Handles btn_tabelas_ferramentas.Click
        ' ler tabela de propriedades de ferramentas e colocar num dicionario

        ' confirmar os dados numericos
        For i As Integer = 0 To tab_ferramentas.Rows.Count - 2
            For j As Integer = 2 To tab_ferramentas.Rows(i).Cells.Count - 2
                If Not IsNumeric(tab_ferramentas.Rows(i).Cells(j).Value) Then
                    MessageBox.Show("Valor da coluna """ + tab_ferramentas.Columns(j).Name + """ da ferramenta " + CStr(tab_ferramentas.Rows(i).Cells(0).Value) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            If i = 0 Then
                GlobalVars.param_ferramentas.Clear()
            End If

            ' atualizar o dicionario
            Dim idTool As String = tab_ferramentas.Rows(i).Cells(0).FormattedValue

            GlobalVars.param_ferramentas.Add(idTool + "_NOME", CStr(tab_ferramentas.Rows(i).Cells(1).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_POCKET", CStr(tab_ferramentas.Rows(i).Cells(2).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_ALTURA", CStr(tab_ferramentas.Rows(i).Cells(3).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_DIAMETRO", CStr(tab_ferramentas.Rows(i).Cells(4).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_OBSERCACOES", CStr(tab_ferramentas.Rows(i).Cells(5).FormattedValue))
        Next

        ' exportar dicionario
        writeDictionary(GlobalVars.param_ferramentas, GlobalVars.param_ferramentas_path)
        btn_enviar_talebas_ferramentas.Enabled = True
    End Sub

    Private Sub btn_tabelas_referenciais_Click(sender As Object, e As EventArgs) Handles btn_tabelas_referenciais.Click
        ' ler tabela de propriedades de ferramentas e colocar num dicionario

        ' confirmar os dados numericos
        For i As Integer = 0 To tab_referenciais.Rows.Count - 2
            For j As Integer = 2 To tab_referenciais.Rows(i).Cells.Count - 2
                If Not IsNumeric(tab_referenciais.Rows(i).Cells(j).Value) Then
                    MessageBox.Show("Valor da coluna """ + tab_referenciais.Columns(j).Name + """ da ferramenta " + CStr(tab_referenciais.Rows(i).Cells(0).Value) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            If i = 0 Then
                GlobalVars.param_referenciais.Clear()
            End If

            ' atualizar o dicionario
            Dim ref_name As String = tab_referenciais.Rows(i).Cells(0).FormattedValue

            GlobalVars.param_referenciais.Add(ref_name + "_X", CStr(tab_referenciais.Rows(i).Cells(1).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_Y", CStr(tab_referenciais.Rows(i).Cells(2).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_Z", CStr(tab_referenciais.Rows(i).Cells(3).FormattedValue))
        Next

        ' exportar dicionario
        writeDictionary(GlobalVars.param_referenciais, GlobalVars.param_referenciais_path)
        btn_envio_tabela_referenciais.Enabled = True
    End Sub

    ' *******************************************
    ' ROTINAS PARAMETROS

    'Formatar Index's da tabela com auto_incremento
    'Private Sub param_dataGrid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles param_dataGrid.CellFormatting
    '    param_dataGrid.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    'End Sub
    Private Sub inicializarParamGerais()
        'GlobalVars.param_gerais.Add("COMUNICACAO_PROTOCOLO", param_cb_protocolo.Text)
        'GlobalVars.param_gerais.Add("COMUNICACAO_BAUDRATE", param_cb_baudrate.Text)
        'GlobalVars.param_gerais.Add("COMUNICACAO_PORTA_COM", param_cb_portcom.Text)
        'GlobalVars.param_gerais.Add("COMUNICACAO_ENDERECO_IP", param_txt_end_ip.Text)
    End Sub
    Private Sub inicializarParamEixos()
        Dim maxrpm As Integer = 1000
        Dim passo As Integer = 1

        GlobalVars.param_eixos.Add("SPINDLE_RPM_MAX", "2000")
        GlobalVars.param_eixos.Add("N_EIXOS", "3 (X,Y,Z)")

        GlobalVars.param_eixos.Add("X" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("X" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("X" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("X" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("X" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("X" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("X" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("X" + "_ENC_PITCH", "0.1")
        GlobalVars.param_eixos.Add("X" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("Y" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("Y" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("Y" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("Y" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Y" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Y" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("Y" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("Y" + "_ENC_PITCH", "0.1")
        GlobalVars.param_eixos.Add("Y" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("Z" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("Z" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("Z" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("Z" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Z" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Z" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("Z" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("Z" + "_ENC_PITCH", "0.1")
        GlobalVars.param_eixos.Add("Z" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("A" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("A" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("A" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("A" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("A" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("A" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("A" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("A" + "_ENC_PITCH", "0.1")
        GlobalVars.param_eixos.Add("A" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("B" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("B" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("B" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("B" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("B" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("B" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("B" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("B" + "_ENC_PITCH", "0.1")
        GlobalVars.param_eixos.Add("B" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("C" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("C" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("C" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("C" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("C" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("C" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("C" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("C" + "_ENC_PITCH", "0.1")
        GlobalVars.param_eixos.Add("C" + "_ENC_N_PULSE", "200")
    End Sub

    Private Sub readParamGerais(path As String)
        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros gerais
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_gerais = jss.Deserialize(Of Dictionary(Of String, String))(json)
            ' display on GUI

            param_cb_protocolo.Text = GlobalVars.param_gerais("COMUNICACAO_PROTOCOLO")
            param_cb_baudrate.Text = GlobalVars.param_gerais("COMUNICACAO_BAUDRATE")
            param_cb_portcom.Text = GlobalVars.param_gerais("COMUNICACAO_PORTA_COM")
            param_txt_end_ip.Text = GlobalVars.param_gerais("COMUNICACAO_ENDERECO_IP")
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página de configurações gerais são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página de configurações gerais são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub readParamEixos(path As String)
        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros eixos
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_eixos = jss.Deserialize(Of Dictionary(Of String, String))(json)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página de configuração dos eixos são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página de configuração dos eixos são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex3 As System.Collections.Generic.KeyNotFoundException
            MessageBox.Show("Ficheiro " + path + " não contém todos os parametros necessários." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página de configuração dos eixos são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' display on GUI
        Dim i As Integer
        Dim j As Integer = 0
        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_eixos
            If kvp.Key = "SPINDLE_RPM_MAX" Or kvp.Key = "LASER_POTENCIA" Or kvp.Key = "N_EIXOS" Or kvp.Key.Split("_")(1) = "G00" Or kvp.Key.Split("_")(1) = "G01" Or kvp.Key.Split("_")(1) = "JOG" Then
                If kvp.Key = "SPINDLE_RPM_MAX" Then
                    param_radbtn_spindle.Checked = True
                    param_txt_spindle_maxrpm.Enabled = True
                    param_txt_laser_power.Enabled = False
                    param_radbtn_laser.Checked = False
                    param_txt_spindle_maxrpm.Text = kvp.Value
                ElseIf kvp.Key = "LASER_POTENCIA" Then
                    param_txt_spindle_maxrpm.Enabled = False
                    param_txt_laser_power.Enabled = True
                    param_radbtn_spindle.Checked = False
                    param_radbtn_laser.Checked = True
                    param_txt_laser_power.Text = kvp.Value
                ElseIf kvp.Key = "N_EIXOS" Then
                    param_cbox_n_eixos.Text = kvp.Value
                End If
            Else
                If j = 0 Then
                    i = param_tabela_eixos.Rows.Add()
                    param_tabela_eixos.Rows(i).Cells(j).Value = kvp.Key.Split("_")(0)
                    j = j + 1
                    param_tabela_eixos.Rows(i).Cells(j).Value = kvp.Value
                    j = j + 1
                Else
                    param_tabela_eixos.Rows(i).Cells(j).Value = kvp.Value
                    j = j + 1
                End If

                If j = param_tabela_eixos.Columns.Count Then
                    j = 0
                End If
            End If

        Next
    End Sub


    Private Sub btd_guardar_Click(sender As Object, e As EventArgs) Handles btd_guardar.Click
        ' adicionar parametros gerais

        'atualizar o dicionario
        GlobalVars.param_gerais.Clear() ' clear dictionary to fill with new info
        GlobalVars.param_gerais.Add("COMUNICACAO_PROTOCOLO", param_cb_protocolo.Text)
        GlobalVars.param_gerais.Add("COMUNICACAO_BAUDRATE", param_cb_baudrate.Text)
        GlobalVars.param_gerais.Add("COMUNICACAO_PORTA_COM", param_cb_portcom.Text)
        GlobalVars.param_gerais.Add("COMUNICACAO_ENDERECO_IP", param_txt_end_ip.Text)

        ' export dictionary to file
        writeDictionary(GlobalVars.param_gerais, GlobalVars.param_gerais_path)

    End Sub

    Private Sub param_btn_eixos_guardar_Click(sender As Object, e As EventArgs) Handles param_btn_eixos_guardar.Click
        ' ler tabela de propriedades de eixos e colocar num dicionario

        ' confirmar os dados numericos
        For i As Integer = 0 To param_tabela_eixos.Rows.Count - 2
            For j As Integer = 2 To param_tabela_eixos.Rows(i).Cells.Count - 1
                If Not IsNumeric(param_tabela_eixos.Rows(i).Cells(j).Value) Then
                    MessageBox.Show("Valor da coluna """ + param_tabela_eixos.Columns(j).Name + """ da ferramenta " + CStr(param_tabela_eixos.Rows(i).Cells(0).Value) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            If i = 0 Then
                GlobalVars.param_eixos.Clear()
            End If

            ' atualizar o dicionario
            Dim passo As Decimal = CDec(param_tabela_eixos.Rows(i).Cells(2).FormattedValue)
            Dim maxrpm As Decimal = CDec(param_tabela_eixos.Rows(i).Cells(3).FormattedValue)

            Dim axis_name As String = param_tabela_eixos.Rows(i).Cells(0).FormattedValue

            GlobalVars.param_eixos.Add(axis_name + "_PASSO", CStr(param_tabela_eixos.Rows(i).Cells(1).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_RPM_MAX", CStr(param_tabela_eixos.Rows(i).Cells(2).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_G00_FEED_MAX", CStr(passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_LIM_INF", CStr(param_tabela_eixos.Rows(i).Cells(3).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_LIM_SUP", CStr(param_tabela_eixos.Rows(i).Cells(4).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_ENC_PITCH", CStr(param_tabela_eixos.Rows(i).Cells(5).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_ENC_N_PULSE", CStr(param_tabela_eixos.Rows(i).Cells(6).FormattedValue))

        Next

        ' propriedades do spindle / laser
        Dim info_laser_spindle As String = "200"
        Dim laser_ou_spindle As String = "SPINDLE_RPM_MAX"
        Dim n_eixos As String = 3

        If Me.param_radbtn_spindle.Checked = True Then
            If Not IsNumeric(param_txt_spindle_maxrpm.Text) Then
                MessageBox.Show("Valor de RPM maximas deve ser um número.", "Parametros não guardados",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Me.param_txt_spindle_maxrpm.Enabled = True
            Me.param_txt_laser_power.Enabled = False
            Me.param_radbtn_laser.Checked = False
            info_laser_spindle = Me.param_txt_spindle_maxrpm.Text
            laser_ou_spindle = "SPINDLE_RPM_MAX"
            n_eixos = param_cbox_n_eixos.Text
        ElseIf Me.param_radbtn_laser.Checked = True Then
            If Not IsNumeric(param_txt_laser_power.Text) Then
                MessageBox.Show("Valor de Potência deve ser um número.", "Parametros não guardados",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Me.param_txt_spindle_maxrpm.Enabled = False
            Me.param_txt_laser_power.Enabled = True
            Me.param_radbtn_spindle.Checked = False
            info_laser_spindle = Me.param_txt_laser_power.Text
            laser_ou_spindle = "LASER_POTENCIA"
            n_eixos = "2 (X,V)"
        End If

        GlobalVars.param_eixos.Add(laser_ou_spindle, info_laser_spindle)
        GlobalVars.param_eixos.Add("N_EIXOS", n_eixos)

        ' export dictionary to file
        writeDictionary(GlobalVars.param_eixos, GlobalVars.param_eixos_path)
        btn_enviar_parametros_Eixos.Enabled = True

    End Sub

    Private Sub param_radbtn_spindle_CheckedChanged(sender As Object, e As EventArgs) Handles param_radbtn_spindle.CheckedChanged
        If Me.param_radbtn_spindle.Checked = True Then
            Me.param_txt_spindle_maxrpm.Enabled = True
            Me.param_txt_laser_power.Enabled = False
            Me.param_radbtn_laser.Checked = False
            Me.param_cbox_n_eixos.Enabled = True
        Else
            Me.param_txt_spindle_maxrpm.Enabled = False
            Me.param_txt_laser_power.Enabled = True
            Me.param_cbox_n_eixos.Enabled = False
            'Me.param_radbtn_spindle.Checked = False
        End If
        btn_enviar_parametros_Eixos.Enabled = False
    End Sub

    Private Sub param_radbtn_laser_CheckedChanged(sender As Object, e As EventArgs) Handles param_radbtn_laser.CheckedChanged
        If Me.param_radbtn_spindle.Checked = True Then
            Me.param_txt_spindle_maxrpm.Enabled = True
            Me.param_txt_laser_power.Enabled = False
            Me.param_radbtn_laser.Checked = False
            Me.param_cbox_n_eixos.Enabled = True
        ElseIf Me.param_radbtn_laser.Checked = True Then
            Me.param_txt_spindle_maxrpm.Enabled = False
            Me.param_txt_laser_power.Enabled = True
            Me.param_cbox_n_eixos.Enabled = False
            'Me.param_radbtn_spindle.Checked = False
        End If
        btn_enviar_parametros_Eixos.Enabled = False
    End Sub

    ' *******************************************
    Private Sub writeDictionary(dictionary As Dictionary(Of String, String), path As String)
        Dim s As String = "{"
        Dim i As Integer = 1
        For Each kvp As KeyValuePair(Of String, String) In dictionary
            s = s + vbNewLine + """" + kvp.Key + """" + ": " + """" + kvp.Value + """"
            If i < dictionary.Count Then
                s = s + ","
            End If
            i = i + 1

        Next
        s = s + vbNewLine + "}"

        ' write dictionary to file
        Dim param_txt_tabelaFerramentas As TextWriter = New StreamWriter(path)
        param_txt_tabelaFerramentas.WriteLine(s)
        param_txt_tabelaFerramentas.Close()

        MessageBox.Show("Ficheiro de parametros guardado com sucesso em " + path, "Guardado")
    End Sub

    ' *******************************************
    ' ROTINAS AVISOS
    ' *******************************************

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_teste.Click
        ' Teste ... Teste ... TESTE
        mach = GetObject(, "Mach3.Document")
        scriptObject = mach.GetScriptDispatch()

        scriptObject.LoadFile("11 CUX56.TXT")

        scriptObject.RunFile()

        While (scriptObject.IsMoving() <> 0)
            System.Threading.Thread.Sleep(1)
        End While
    End Sub

    Private Sub tmr_match3_Tick(sender As Object, e As EventArgs) Handles tmr_match3.Tick
        ' Leitura Posição Eixo X
        ''txt_ManPosX.Text = Format(scriptObject.GetABSPostion(0), "###,##0.#0")

    End Sub

    Private Sub btn_envio_parametros_geral_Click(sender As Object, e As EventArgs)
        'enviar os valores dos parametros gerais para o mach 3'



    End Sub

    Private Sub btn_enviar_parametros_Eixos_Click(sender As Object, e As EventArgs) Handles btn_enviar_parametros_Eixos.Click
        'enviar os valores dos parametros Eixos para o mach 3'

        Dim qual_eixo As String
        Dim stepX As Double
        qual_eixo = (GlobalVars.param_eixos("x_TIPO")).Substring(0, 1)

        MsgBox(qual_eixo)

        'define as unidades em mm '
        scriptObject.SetParam("Units", 0)


        'envia valores relativos a Eixos X'
        scriptObject.SetParam("StepsPerAxisX", CDbl(GlobalVars.param_eixos("x_PASSO")))
        'scriptObject.SetParam("FeedRate", GlobalVars.param_eixos("x_G01_FEED_MAX"))
        scriptObject.SetParam("VelocitiesX", CDbl(GlobalVars.param_eixos("x_G01_FEED_MAX")))

        'envia valores relativos a Eixos Y'
        scriptObject.SetParam("StepsPerAxisY", CDbl(GlobalVars.param_eixos("y_PASSO")))
        scriptObject.SetParam("VelocitiesY", CDbl(GlobalVars.param_eixos("y_G01_FEED_MAX")))

        'envia valores relativos a Eixos Z'
        scriptObject.SetParam("StepsPerAxisZ", CDbl(GlobalVars.param_eixos("z_PASSO")))
        scriptObject.SetParam("VelocitiesZ", CDbl(GlobalVars.param_eixos("z_G01_FEED_MAX")))

        'envia valores relativos a Eixos A'
        scriptObject.SetParam("StepsPerAxisA", CDbl(GlobalVars.param_eixos("a_PASSO")))
        scriptObject.SetParam("VelocitiesA", CDbl(GlobalVars.param_eixos("a_G01_FEED_MAX")))

        'envia valores relativos a Eixos B'
        scriptObject.SetParam("StepsPerAxisB", CDbl(GlobalVars.param_eixos("b_PASSO")))
        scriptObject.SetParam("VelocitiesB", CDbl(GlobalVars.param_eixos("b_G01_FEED_MAX")))

        'envia valores relativos a Eixos C'
        scriptObject.SetParam("StepsPerAxisC", CDbl(GlobalVars.param_eixos("c_PASSO")))
        scriptObject.SetParam("VelocitiesC", CDbl(GlobalVars.param_eixos("c_G01_FEED_MAX")))

    End Sub

    Private Sub param_tabela_eixos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles param_tabela_eixos.CellContentClick
        btn_enviar_parametros_Eixos.Enabled = False
    End Sub

    Private Sub param_txt_spindle_maxrpm_TextChanged(sender As Object, e As EventArgs) Handles param_txt_spindle_maxrpm.TextChanged
        btn_enviar_parametros_Eixos.Enabled = False
    End Sub

    Private Sub param_cbox_n_eixos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles param_cbox_n_eixos.SelectedIndexChanged
        btn_enviar_parametros_Eixos.Enabled = False
    End Sub

    Private Sub param_txt_laser_power_TextChanged(sender As Object, e As EventArgs) Handles param_txt_laser_power.TextChanged
        btn_enviar_parametros_Eixos.Enabled = False
    End Sub

    Private Sub tab_referenciais_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab_referenciais.CellContentClick
        btn_envio_tabela_referenciais.Enabled = False
    End Sub

    Private Sub tab_ferramentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab_ferramentas.CellContentClick
        btn_enviar_talebas_ferramentas.Enabled = False
    End Sub

    Private Sub btn_enviar_talebas_ferramentas_Click(sender As Object, e As EventArgs) Handles btn_enviar_talebas_ferramentas.Click
        Dim ID_ferramenta As String
        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_ferramentas
            If kvp.Key.Split("_")(1) = "NOME" Then
                ID_ferramenta = kvp.Key.Split("_")(0)


            End If
        Next
    End Sub
End Class