﻿Imports Mach4
Imports System.IO
Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel


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

    ' Private Mach4.IMach4 _Mach = null;
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

        '--------------------------------------------------------------------------------

        Dim aux As String

        ' Propriedades Iniciais
        ' Modo Manual
        StatusStripLbl_Modo.Text = "Modo Manual"

        ' Abertura das comunicações com o Match3
        ''mach = GetObject(, "Mach4.Document")
        ''scriptObject = mach.GetScriptDispatch()

        ' Necessário confirmar se o Match3 está OK

        ' Definições do temporizador para leitura de posição dos eixos (Match3)
        tmr_match3.Interval = 250
        tmr_match3.Enabled = True

        ' Ficheiro de configurações - Modo Manual
        ''FileOpen(1, "Config\CmdNum_Manual.Ini", OpenMode.Input)

        ''For i = 1 To 8
        ''aux = LineInput(1)
        ''Next

        'para acresentar um modo de por comentario'

        ' Leitura da velocidade de deslocamento
        '' aux = LineInput(1)
        ''Dim words As String() = aux.Split(New Char() {" "c})



        ''Manual_ManualFeedRate = Integer.Parse(words(2))

        ' Visualizaçºao da Velocidade de Deslocamento
        ''txt_ManFeedRate.Text = Manual_ManualFeedRate.ToString


        ' PrintLine  para escerever em ficheiro...
        'PrintLine (1, "teste teste")

        ''FileClose(1)

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


    ' *******************************************
    ' ROTINAS PARAMETROS

    'Formatar Index's da tabela com auto_incremento
    'Private Sub param_dataGrid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles param_dataGrid.CellFormatting
    '    param_dataGrid.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    'End Sub

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


    Private Sub param_btn_Guardar_Click(sender As Object, e As EventArgs) Handles param_btn_Guardar.Click
        ' ler tabela de propriedades de ferramentas e colocar num dicionario

        ' confirmar os dados numericos
        For Each r As DataGridViewRow In Me.param_dataGrid.Rows
            For i = 2 To r.Cells.Count - 2
                If Not IsNumeric(r.Cells(i).FormattedValue) Then
                    MessageBox.Show("Valor da coluna " + CStr(i) + " da ferramenta " + CStr(r.Cells(0).FormattedValue) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            ' atualizar o dicionario
            Dim idTool As String = r.Cells(0).FormattedValue

            GlobalVars.param_ferramentas.Clear() ' clear dictionary to fill with new info
            GlobalVars.param_ferramentas.Add(idTool + "_NOME", CStr(r.Cells(1).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_POCKET", CStr(r.Cells(2).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_ALTURA", CStr(r.Cells(3).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_DIAMETRO", CStr(r.Cells(4).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_OBSERCACOES", CStr(r.Cells(5).FormattedValue))
        Next

        ' exportar dicionario
        writeDictionary(GlobalVars.param_ferramentas, "Config\Parametros_Ferramentas.json")

    End Sub

    Private Sub btd_guardar_Click(sender As Object, e As EventArgs) Handles btd_guardar.Click
        ' adicionar parametros gerais

        'atualizar o dicionario
        GlobalVars.param_ferramentas.Clear() ' clear dictionary to fill with new info
        GlobalVars.param_gerais.Add("COMUNICACAO_PROTOCOLO", param_cb_protocolo.Text)
        GlobalVars.param_gerais.Add("COMUNICACAO_BAUDRATE", param_cb_baudrate.Text)
        GlobalVars.param_gerais.Add("COMUNICACAO_PORTA_COM", param_cb_portcom.Text)
        GlobalVars.param_gerais.Add("COMUNICACAO_ENDERECO_IP", param_txt_end_ip.Text)

        ' export dictionary to file
        writeDictionary(GlobalVars.param_gerais, "Config\Parametros_Gerais.json")

    End Sub

    Private Sub param_btn_eixos_guardar_Click(sender As Object, e As EventArgs) Handles param_btn_eixos_guardar.Click
        ' ler tabela de propriedades de eixos e colocar num dicionario

        ' confirmar os dados numericos
        For Each r As DataGridViewRow In Me.param_tabela_eixos.Rows

            For i = 2 To r.Cells.Count - 1
                If Not IsNumeric(r.Cells(i).FormattedValue) Then
                    MessageBox.Show("Valor da coluna " + CStr(i) + " do eixo " + CStr(r.Cells(0).FormattedValue) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            ' atualizar o dicionario
            Dim passo As Decimal = CDec(r.Cells(2).FormattedValue)
            Dim maxrpm As Decimal = CDec(r.Cells(3).FormattedValue)

            Dim axis_name As String = r.Cells(0).FormattedValue

            GlobalVars.param_ferramentas.Clear() ' clear dictionary to fill with new info
            GlobalVars.param_eixos.Add(axis_name + "_TIPO", CStr(r.Cells(1).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_G00_FEED_MAX", CStr(passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_LIM_INF", CStr(r.Cells(4).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_LIM_SUP", CStr(r.Cells(5).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_ENC_PITCH", CStr(r.Cells(6).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_ENC_N_PULSE", CStr(r.Cells(7).FormattedValue))

        Next

        ' propriedades do spindle / laser
        Dim info_laser_spindle As String
        Dim laser_ou_spindle As String

        If Me.param_radbtn_spindle.Checked = True Then
            If Not IsNumeric(param_txt_laser_power.Text) Then
                MessageBox.Show("Valor de RPM maximas deve ser um número.", "Parametros não guardados",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Me.param_txt_spindle_maxrpm.Enabled = True
            Me.param_txt_laser_power.Enabled = False
            Me.param_radbtn_laser.Checked = False
            info_laser_spindle = Me.param_txt_spindle_maxrpm.Text
            laser_ou_spindle = "SPINDLE_RPM_MAX"
        Else
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
        End If

        GlobalVars.param_eixos.Add(laser_ou_spindle, info_laser_spindle)

        ' export dictionary to file
        writeDictionary(GlobalVars.param_eixos, "Config\Parametros_Eixos.json")

    End Sub

    ' *******************************************


    ' *******************************************
    ' ROTINAS AVISOS
    ' *******************************************

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_teste.Click
        ' Teste ... Teste ... TESTE
        mach = GetObject(, "Mach4.Document")
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


End Class