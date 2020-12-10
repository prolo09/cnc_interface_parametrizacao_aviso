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

        'parametros portcom
        myPort = IO.Ports.SerialPort.GetPortNames()
        param_cb_portcom.Items.AddRange(myPort)

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

    'Guardar informação da tabela na var writer.
    Private Sub param_btn_Guardar_Click(sender As Object, e As EventArgs) Handles param_btn_Guardar.Click

        Dim param_txt_tabelaFerramentas As TextWriter = New StreamWriter("E:\Text.txt")

        param_txt_tabelaFerramentas.Write("Nome Ferramenta" & vbTab & "|" & "Pocket")
        param_txt_tabelaFerramentas.WriteLine("")


        For i As Integer = 0 To param_dataGrid.Rows.Count - 2 Step +1

            For j As Integer = 0 To param_dataGrid.Columns.Count - 1 Step +1

                param_txt_tabelaFerramentas.Write(vbTab & param_dataGrid.Rows(i).Cells(j).Value.ToString() & vbTab & "|")

            Next

            param_txt_tabelaFerramentas.WriteLine("")

        Next
        param_txt_tabelaFerramentas.Close()
        MessageBox.Show("Tabela Guardada")

    End Sub

    Private Sub retriveParameters()

        'Dim parametros As New Dictionary(Of String, String)

        ' adicionar parametros gerais

        GlobalVars.parametros.Add("Comunicacao_Protocolo", param_cb_protocolo.Text)
        GlobalVars.parametros.Add("Comunicacao_Baudrate", param_cb_baudrate.Text)
        GlobalVars.parametros.Add("Comunicacao_Porta_COM", param_cb_portcom.Text)
        GlobalVars.parametros.Add("Comunicacao_Endereco_IP", param_txt_end_ip.Text)

        ' ler tabela de propriedades de ferramentas e colocar num dicionario
        For Each r As DataGridViewRow In Me.param_dataGrid.Rows
            Dim idTool As String = r.Cells(0).FormattedValue
            GlobalVars.parametros.Add(idTool + "_Nome", CStr(r.Cells(1).FormattedValue))
            GlobalVars.parametros.Add(idTool + "_Pocket", CStr(r.Cells(2).FormattedValue))
            GlobalVars.parametros.Add(idTool + "_Altura", CStr(r.Cells(3).FormattedValue))
            GlobalVars.parametros.Add(idTool + "_Diametro", CStr(r.Cells(4).FormattedValue))
            GlobalVars.parametros.Add(idTool + "_Observacoes", CStr(r.Cells(5).FormattedValue))

        Next

        ' ler tabela de propriedades de eixos e colocar num dicionario
        For Each r As DataGridViewRow In Me.param_tabela_eixos.Rows
            Dim axis_name As String = r.Cells(0).FormattedValue
            GlobalVars.parametros.Add(axis_name + "_tipo", CStr(r.Cells(1).FormattedValue))
            GlobalVars.parametros.Add(axis_name + "_passo", CStr(r.Cells(2).FormattedValue))
            GlobalVars.parametros.Add(axis_name + "_maxrpm", CStr(r.Cells(3).FormattedValue))
            GlobalVars.parametros.Add(axis_name + "_lim_inf", CStr(r.Cells(4).FormattedValue))
            GlobalVars.parametros.Add(axis_name + "_lim_sup", CStr(r.Cells(5).FormattedValue))
            GlobalVars.parametros.Add(axis_name + "_enc_pitch", CStr(r.Cells(6).FormattedValue))
            GlobalVars.parametros.Add(axis_name + "_enc_n_pulse", CStr(r.Cells(7).FormattedValue))

        Next

        ' propriedades do spindle / laser

        Dim info_laser_spindle As String

        If Me.param_radbtn_spindle.Checked = True Then
            Me.param_txt_spindle_maxrpm.Enabled = True
            Me.param_txt_laser_power.Enabled = False
            Me.param_radbtn_laser.Checked = False
            info_laser_spindle = Me.param_txt_spindle_maxrpm.Text

        ElseIf Me.param_radbtn_laser.Checked = True Then
            Me.param_txt_spindle_maxrpm.Enabled = False
            Me.param_txt_laser_power.Enabled = True
            Me.param_radbtn_spindle.Checked = False
            info_laser_spindle = Me.param_txt_laser_power.Text

        End If

        GlobalVars.parametros.Add("info_laser_spindle", info_laser_spindle)

        ' criar string tipo json

        Dim s As String = "{"
        For Each kvp As KeyValuePair(Of String, String) In parametros
            s = s + vbNewLine + kvp.Key + ":" + kvp.Value + ","
        Next
        s = s + vbNewLine + "}"
        TextBox1.Text = s

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