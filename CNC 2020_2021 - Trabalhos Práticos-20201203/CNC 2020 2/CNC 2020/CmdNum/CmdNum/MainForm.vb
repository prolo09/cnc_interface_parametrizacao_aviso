Imports Mach4
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

        'ler ficheiros de parametros
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

    Private Sub inicializarParamFerramentas()
        ' ferramentas predefinidas
        GlobalVars.param_ferramentas.Add("1" + "_NOME", "Fresa")
        GlobalVars.param_ferramentas.Add("1" + "_POCKET", "1")
        GlobalVars.param_ferramentas.Add("1" + "_ALTURA", "15")
        GlobalVars.param_ferramentas.Add("1" + "_DIAMETRO", "15")
        GlobalVars.param_ferramentas.Add("1" + "_OBSERCACOES", "Fresa predefinida")
    End Sub

    Private Sub inicializarParamReferenciais()
        ' inicializar tabela de referenciais
        GlobalVars.param_referenciais.Add("G28" + "_X", "0")
        GlobalVars.param_referenciais.Add("G28" + "_Y", "0")
        GlobalVars.param_referenciais.Add("G28" + "_Z", "0")
        GlobalVars.param_referenciais.Add("G28" + "_A", "0")
        GlobalVars.param_referenciais.Add("G28" + "_B", "0")
        GlobalVars.param_referenciais.Add("G28" + "_C", "0")

        For i As Integer = 54 To 59
            GlobalVars.param_referenciais.Add("G" + CStr(i) + "_X", "")
            GlobalVars.param_referenciais.Add("G" + CStr(i) + "_Y", "")
            GlobalVars.param_referenciais.Add("G" + CStr(i) + "_Z", "")
            GlobalVars.param_referenciais.Add("G" + CStr(i) + "_A", "")
            GlobalVars.param_referenciais.Add("G" + CStr(i) + "_B", "")
            GlobalVars.param_referenciais.Add("G" + CStr(i) + "_C", "")
        Next

    End Sub

    Private Sub readParamFerramentas(path As String)
        'ler ficheiro de parametros de ferramentas

        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros ferramentas
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_ferramentas = jss.Deserialize(Of Dictionary(Of String, String))(json)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página da tabela de ferramentas são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página da tabela de ferramentas são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' display on GUI
        Dim i As Integer
        Dim j As Integer = 0
        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_ferramentas
            If j = 0 Then
                i = tabela_dtgrid_ferramentas.Rows.Add()
                tabela_dtgrid_ferramentas.Rows(i).Cells(j).Value = kvp.Key.Split("_")(0)
                j = j + 1
                tabela_dtgrid_ferramentas.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            Else
                tabela_dtgrid_ferramentas.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            End If

            If j = tabela_dtgrid_ferramentas.Columns.Count Then
                j = 0
            End If
        Next

    End Sub

    Private Sub readParamReferenciais(path As String)
        ' ler ficheiro de parametros de referenciais

        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros referenciais
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_referenciais = jss.Deserialize(Of Dictionary(Of String, String))(json)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página da tabela de referenciais são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página da tabela de referenciais são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' display on GUI
        Dim i As Integer
        Dim j As Integer = 0
        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_referenciais
            If j = 0 Then
                i = tabela_dtgrid_referenciais.Rows.Add()
                tabela_dtgrid_referenciais.Rows(i).Cells(j).Value = kvp.Key.Split("_")(0)
                j = j + 1
                tabela_dtgrid_referenciais.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            Else
                tabela_dtgrid_referenciais.Rows(i).Cells(j).Value = kvp.Value
                j = j + 1
            End If

            If j = tabela_dtgrid_referenciais.Columns.Count Then
                j = 0
            End If
        Next

    End Sub

    Private Sub tabelas_btn_guardar_ferramentas_Click(sender As Object, e As EventArgs) Handles tabelas_btn_guardar_ferramentas.Click
        ' ler tabela de propriedades de ferramentas e colocar num dicionario

        ' confirmar os dados numericos
        For i As Integer = 0 To tabela_dtgrid_ferramentas.Rows.Count - 2
            For j As Integer = 0 To tabela_dtgrid_ferramentas.Rows(i).Cells.Count - 2
                If Not IsNumeric(tabela_dtgrid_ferramentas.Rows(i).Cells(j).Value) And Not j = 1 Then
                    MessageBox.Show("Valor da coluna """ + tabela_dtgrid_ferramentas.Columns(j).Name + """ da ferramenta " + CStr(tabela_dtgrid_ferramentas.Rows(i).Cells(0).Value) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            If i = 0 Then
                GlobalVars.param_ferramentas.Clear()
            End If

            ' atualizar o dicionario
            Dim idTool As String = tabela_dtgrid_ferramentas.Rows(i).Cells(0).FormattedValue

            GlobalVars.param_ferramentas.Add(idTool + "_NOME", CStr(tabela_dtgrid_ferramentas.Rows(i).Cells(1).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_POCKET", CStr(tabela_dtgrid_ferramentas.Rows(i).Cells(2).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_ALTURA", CStr(tabela_dtgrid_ferramentas.Rows(i).Cells(3).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_DIAMETRO", CStr(tabela_dtgrid_ferramentas.Rows(i).Cells(4).FormattedValue))
            GlobalVars.param_ferramentas.Add(idTool + "_OBSERCACOES", CStr(tabela_dtgrid_ferramentas.Rows(i).Cells(5).FormattedValue))
        Next

        ' exportar dicionario
        writeDictionary(GlobalVars.param_ferramentas, GlobalVars.param_ferramentas_path)
        tabelas_btn_enviar_ferramentas.Enabled = True
    End Sub

    Private Sub tabelas_btn_guardar_referenciais_Click(sender As Object, e As EventArgs) Handles tabelas_btn_guardar_referenciais.Click
        ' ler tabela de referenciais e colocar num dicionario

        ' confirmar os dados numericos
        For i As Integer = 0 To tabela_dtgrid_referenciais.Rows.Count - 2
            For j As Integer = 1 To tabela_dtgrid_referenciais.Rows(i).Cells.Count - 2
                If Not IsNumeric(tabela_dtgrid_referenciais.Rows(i).Cells(j).Value) And Not tabela_dtgrid_referenciais.Rows(i).Cells(j).Value = "" Then
                    MessageBox.Show("Valor da coluna """ + tabela_dtgrid_referenciais.Columns(j).Name + """ da ferramenta " + CStr(tabela_dtgrid_referenciais.Rows(i).Cells(0).Value) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            If i = 0 Then
                GlobalVars.param_referenciais.Clear()
            End If

            ' atualizar o dicionario
            Dim ref_name As String = tabela_dtgrid_referenciais.Rows(i).Cells(0).FormattedValue

            GlobalVars.param_referenciais.Add(ref_name + "_X", CStr(tabela_dtgrid_referenciais.Rows(i).Cells(1).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_Y", CStr(tabela_dtgrid_referenciais.Rows(i).Cells(2).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_Z", CStr(tabela_dtgrid_referenciais.Rows(i).Cells(3).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_A", CStr(tabela_dtgrid_referenciais.Rows(i).Cells(4).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_B", CStr(tabela_dtgrid_referenciais.Rows(i).Cells(5).FormattedValue))
            GlobalVars.param_referenciais.Add(ref_name + "_C", CStr(tabela_dtgrid_referenciais.Rows(i).Cells(6).FormattedValue))
        Next

        ' exportar dicionario
        writeDictionary(GlobalVars.param_referenciais, GlobalVars.param_referenciais_path)
        tabelas_btn_enviar_referenciais.Enabled = True
    End Sub

    Private Sub tabelas_btn_enviar_ferramentas_Click(sender As Object, e As EventArgs) Handles tabelas_btn_enviar_ferramentas.Click
        ' enviar para Mach3 propriedades das ferramentas

        Dim ID_ferramenta As String
        Dim diametro As String
        Dim compensa_altura As String

        For Each kvp As KeyValuePair(Of String, String) In GlobalVars.param_ferramentas
            If kvp.Key.Split("_")(1) = "NOME" Then
                ID_ferramenta = kvp.Key.Split("_")(0)
                diametro = GlobalVars.param_ferramentas(ID_ferramenta & "_DIAMETRO")
                compensa_altura = GlobalVars.param_ferramentas(ID_ferramenta & "_ALTURA")

                scriptObject.SetToolParam(CInt(ID_ferramenta), 1, CDbl(diametro))
                scriptObject.SetToolParam(CInt(ID_ferramenta), 2, CDbl(compensa_altura))

            End If
        Next

    End Sub

    Private Sub tabelas_btn_enviar_referenciais_Click(sender As Object, e As EventArgs) Handles tabelas_btn_enviar_referenciais.Click
        ' enviar para o Mach3 referenciais

        'scriptObject.SetOEMDRO(184, 46)
        'scriptObject.SetOEMDRO(185, 46)
        'scriptObject.SetOEMDRO(186, 46)
        'scriptObject.SetOEMDRO(187, 46)
        'scriptObject.SetOEMDRO(188, 46)
        'scriptObject.SetOEMDRO(189, 46)

        'envia os valores dos eixos relativos ao G28'
        scriptObject.SetOEMDRO(190, GlobalVars.param_referenciais("G28_X"))
        scriptObject.SetOEMDRO(191, GlobalVars.param_referenciais("G28_Y"))
        scriptObject.SetOEMDRO(192, GlobalVars.param_referenciais("G28_Z"))
        scriptObject.SetOEMDRO(193, GlobalVars.param_referenciais("G28_A"))
        scriptObject.SetOEMDRO(194, GlobalVars.param_referenciais("G28_B"))
        scriptObject.SetOEMDRO(195, GlobalVars.param_referenciais("G28_C"))
    End Sub

    Private Sub tabela_dtgrid_referenciais_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabela_dtgrid_referenciais.CellContentClick
        tabelas_btn_enviar_referenciais.Enabled = False
    End Sub

    Private Sub tabela_dtgrid_ferramentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabela_dtgrid_ferramentas.CellContentClick
        tabelas_btn_enviar_ferramentas.Enabled = False
    End Sub

    ' *******************************************
    ' ROTINAS PARAMETROS

    Private Sub inicializarParamGerais()
        ' parametros gerais predefinidos

        GlobalVars.param_gerais.Add("COMUNICACAO_PROTOCOLO", "RS232")
        GlobalVars.param_gerais.Add("COMUNICACAO_BAUDRATE", "19200")
        GlobalVars.param_gerais.Add("COMUNICACAO_PORTA_COM", "COM3")
        GlobalVars.param_gerais.Add("COMUNICACAO_ENDERECO_IP", "192.168.1.1")
    End Sub
    Private Sub inicializarParamEixos()
        ' parametros dos eixos predefinidos

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
        GlobalVars.param_eixos.Add("X" + "_ENC_PITCH", "0,1")
        GlobalVars.param_eixos.Add("X" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("Y" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("Y" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("Y" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("Y" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Y" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Y" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("Y" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("Y" + "_ENC_PITCH", "0,1")
        GlobalVars.param_eixos.Add("Y" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("Z" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("Z" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("Z" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("Z" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Z" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("Z" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("Z" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("Z" + "_ENC_PITCH", "0,1")
        GlobalVars.param_eixos.Add("Z" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("A" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("A" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("A" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("A" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("A" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("A" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("A" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("A" + "_ENC_PITCH", "0,1")
        GlobalVars.param_eixos.Add("A" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("B" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("B" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("B" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("B" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("B" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("B" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("B" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("B" + "_ENC_PITCH", "0,1")
        GlobalVars.param_eixos.Add("B" + "_ENC_N_PULSE", "200")

        GlobalVars.param_eixos.Add("C" + "_PASSO", CStr(passo))
        GlobalVars.param_eixos.Add("C" + "_RPM_MAX", "200")
        GlobalVars.param_eixos.Add("C" + "_G00_FEED_MAX", CStr(maxrpm * passo))
        GlobalVars.param_eixos.Add("C" + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
        GlobalVars.param_eixos.Add("C" + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
        GlobalVars.param_eixos.Add("C" + "_LIM_INF", "0")
        GlobalVars.param_eixos.Add("C" + "_LIM_SUP", "1000")
        GlobalVars.param_eixos.Add("C" + "_ENC_PITCH", "0,1")
        GlobalVars.param_eixos.Add("C" + "_ENC_N_PULSE", "200")
    End Sub

    Private Sub readParamGerais(path As String)
        'ler ficheiro de parametros gerais

        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros gerais
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_gerais = jss.Deserialize(Of Dictionary(Of String, String))(json)
            ' display on GUI
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página de configurações gerais são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página de configurações gerais são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        param_cb_protocolo.Text = GlobalVars.param_gerais("COMUNICACAO_PROTOCOLO")
        param_cb_baudrate.Text = GlobalVars.param_gerais("COMUNICACAO_BAUDRATE")
        param_cb_portcom.Text = GlobalVars.param_gerais("COMUNICACAO_PORTA_COM")
        param_txt_end_ip.Text = GlobalVars.param_gerais("COMUNICACAO_ENDERECO_IP")
    End Sub

    Private Sub readParamEixos(path As String)
        ' ler ficheiro de parametros dos eixos

        Dim json As String
        Dim jss = New JavaScriptSerializer()
        'parametros eixos
        Try
            json = File.ReadAllText(path)
            GlobalVars.param_eixos = jss.Deserialize(Of Dictionary(Of String, String))(json)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("Ficheiro " + path + " não existe." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página de configuração dos eixos são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex2 As System.ArgumentException
            MessageBox.Show("Ficheiro " + path + " contém erros de formatação." + vbNewLine + "Verifique a formatação do ficheiro e reinicie o programa." + vbNewLine + "Os valores apresentados na página de configuração dos eixos são os valores predefinidos.", "Erro na leitura de ficheiro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex3 As System.Collections.Generic.KeyNotFoundException
            MessageBox.Show("Ficheiro " + path + " não contém todos os parametros necessários." + vbNewLine + "Faça a parametrização da máquina antes de prosseguir." + vbNewLine + "Os valores apresentados na página de configuração dos eixos são os valores predefinidos.", "Configurações não encontradas",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    i = param_dtgrid_eixos.Rows.Add()
                    param_dtgrid_eixos.Rows(i).Cells(j).Value = kvp.Key.Split("_")(0)
                    j = j + 1
                    param_dtgrid_eixos.Rows(i).Cells(j).Value = kvp.Value
                    j = j + 1
                Else
                    param_dtgrid_eixos.Rows(i).Cells(j).Value = kvp.Value
                    j = j + 1
                End If

                If j = param_dtgrid_eixos.Columns.Count Then
                    j = 0
                End If
            End If

        Next
    End Sub


    Private Sub param_btn_guardar_gerais_Click(sender As Object, e As EventArgs) Handles param_btn_guardar_gerais.Click
        ' guardar ficheiro de parametros gerais

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
        For i As Integer = 0 To param_dtgrid_eixos.Rows.Count - 1
            For j As Integer = 1 To param_dtgrid_eixos.Rows(i).Cells.Count - 1
                If Not IsNumeric(param_dtgrid_eixos.Rows(i).Cells(j).Value) And Not param_dtgrid_eixos.Rows(i).Cells(j).Value = "" Then
                    MessageBox.Show("Valor da coluna """ + param_dtgrid_eixos.Columns(j).Name + """ da ferramenta " + CStr(param_dtgrid_eixos.Rows(i).Cells(0).Value) + " deve ser um número.", "Parametros não guardados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            If i = 0 Then
                GlobalVars.param_eixos.Clear()
            End If

            ' atualizar o dicionario
            Dim passo As Decimal = CDec(param_dtgrid_eixos.Rows(i).Cells(2).FormattedValue)
            Dim maxrpm As Decimal = CDec(param_dtgrid_eixos.Rows(i).Cells(3).FormattedValue)

            Dim axis_name As String = param_dtgrid_eixos.Rows(i).Cells(0).FormattedValue

            GlobalVars.param_eixos.Add(axis_name + "_PASSO", CStr(param_dtgrid_eixos.Rows(i).Cells(1).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_RPM_MAX", CStr(param_dtgrid_eixos.Rows(i).Cells(2).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_G00_FEED_MAX", CStr(passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_G01_FEED_MAX", CStr(0.6 * passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_JOG_FEED_MAX", CStr(0.2 * passo * maxrpm))
            GlobalVars.param_eixos.Add(axis_name + "_LIM_INF", CStr(param_dtgrid_eixos.Rows(i).Cells(3).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_LIM_SUP", CStr(param_dtgrid_eixos.Rows(i).Cells(4).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_ENC_PITCH", CStr(param_dtgrid_eixos.Rows(i).Cells(5).FormattedValue))
            GlobalVars.param_eixos.Add(axis_name + "_ENC_N_PULSE", CStr(param_dtgrid_eixos.Rows(i).Cells(6).FormattedValue))

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
        param_btn_eixos_enviar.Enabled = True

    End Sub

    Private Sub btn_envio_parametros_geral_Click(sender As Object, e As EventArgs)
        'enviar os valores dos parametros gerais para o mach 3'
    End Sub

    Private Sub param_btn_eixos_enviar_Click(sender As Object, e As EventArgs) Handles param_btn_eixos_enviar.Click
        'enviar os valores dos parametros Eixos para o mach 3'

        'define as unidades em mm '
        scriptObject.SetParam("Units", 0)

        'retira o valor de do nomero de eixos '

        Dim numero_eixos As String
        numero_eixos = GlobalVars.param_eixos("N_EIXOS").Substring(0, 1)

        'envia valores relativos a Eixos X'
        scriptObject.SetParam("StepsPerAxisX", CDbl(GlobalVars.param_eixos("X_PASSO")))
        scriptObject.SetParam("VelocitiesX", CDbl(GlobalVars.param_eixos("X_G01_FEED_MAX")))
        'valores de limite minimo e maximo'
        scriptObject.SetOEMDRO(156, GlobalVars.param_eixos("X_LIM_INF"))
        scriptObject.SetOEMDRO(150, GlobalVars.param_eixos("X_LIM_SUP"))

        'envia valores relativos a Eixos Y'
        scriptObject.SetParam("StepsPerAxisY", CDbl(GlobalVars.param_eixos("Y_PASSO")))
        scriptObject.SetParam("VelocitiesY", CDbl(GlobalVars.param_eixos("Y_G01_FEED_MAX")))
        'valores de limite minimo e maximo'
        scriptObject.SetOEMDRO(157, GlobalVars.param_eixos("Y_LIM_INF"))
        scriptObject.SetOEMDRO(151, GlobalVars.param_eixos("Y_LIM_SUP"))

        If numero_eixos = 3 Or numero_eixos = 4 Or numero_eixos = 5 Or numero_eixos = 6 Then
            'envia valores relativos a Eixos Z'
            scriptObject.SetParam("StepsPerAxisZ", CDbl(GlobalVars.param_eixos("Z_PASSO")))
            scriptObject.SetParam("VelocitiesZ", CDbl(GlobalVars.param_eixos("Z_G01_FEED_MAX")))
            'valores de limite minimo e maximo'
            scriptObject.SetOEMDRO(158, GlobalVars.param_eixos("Z_LIM_INF"))
            scriptObject.SetOEMDRO(152, GlobalVars.param_eixos("Z_LIM_SUP"))
        End If

        If numero_eixos = 4 Or numero_eixos = 5 Or numero_eixos = 6 Then
            'envia valores relativos a Eixos A'
            scriptObject.SetParam("StepsPerAxisA", CDbl(GlobalVars.param_eixos("A_PASSO")))
            scriptObject.SetParam("VelocitiesA", CDbl(GlobalVars.param_eixos("A_G01_FEED_MAX")))
            'valores de limite minimo e maximo'
            scriptObject.SetOEMDRO(159, GlobalVars.param_eixos("A_LIM_INF"))
            scriptObject.SetOEMDRO(153, GlobalVars.param_eixos("A_LIM_SUP"))
        End If

        If numero_eixos = 5 Or numero_eixos = 6 Then
            'envia valores relativos a Eixos B'
            scriptObject.SetParam("StepsPerAxisB", CDbl(GlobalVars.param_eixos("B_PASSO")))
            scriptObject.SetParam("VelocitiesB", CDbl(GlobalVars.param_eixos("B_G01_FEED_MAX")))
            'valores de limite minimo e maximo'
            scriptObject.SetOEMDRO(160, GlobalVars.param_eixos("B_LIM_INF"))
            scriptObject.SetOEMDRO(154, GlobalVars.param_eixos("B_LIM_SUP"))
        End If

        If numero_eixos = 6 Then
            'envia valores relativos a Eixos C'
            scriptObject.SetParam("StepsPerAxisC", CDbl(GlobalVars.param_eixos("C_PASSO")))
            scriptObject.SetParam("VelocitiesC", CDbl(GlobalVars.param_eixos("C_G01_FEED_MAX")))
            'valores de limite minimo e maximo'
            scriptObject.SetOEMDRO(161, GlobalVars.param_eixos("C_LIM_INF"))
            scriptObject.SetOEMDRO(155, GlobalVars.param_eixos("C_LIM_SUP"))
        End If
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
        param_btn_eixos_enviar.Enabled = False
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
        param_btn_eixos_enviar.Enabled = False
    End Sub

    Private Sub param_tabela_eixos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles param_dtgrid_eixos.CellContentClick
        param_btn_eixos_enviar.Enabled = False
    End Sub

    Private Sub param_txt_spindle_maxrpm_TextChanged(sender As Object, e As EventArgs) Handles param_txt_spindle_maxrpm.TextChanged
        param_btn_eixos_enviar.Enabled = False
    End Sub

    Private Sub param_cbox_n_eixos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles param_cbox_n_eixos.SelectedIndexChanged
        param_btn_eixos_enviar.Enabled = False
    End Sub

    Private Sub param_txt_laser_power_TextChanged(sender As Object, e As EventArgs) Handles param_txt_laser_power.TextChanged
        param_btn_eixos_enviar.Enabled = False
    End Sub

    ' *******************************************
    Private Sub writeDictionary(dictionary As Dictionary(Of String, String), path As String)
        ' recebe um dicionario e diretorio e escreve o dicionario nesse diretorio em formato JSON

        Dim s As String = "{"
        Dim i As Integer = 1
        Dim prefix As String = ""
        For Each kvp As KeyValuePair(Of String, String) In dictionary

            If Not kvp.Key.Split("_")(0) = prefix Then
                s = s + vbNewLine
            End If

            s = s + vbNewLine + """" + kvp.Key + """" + ": " + """" + kvp.Value + """"

            If i < dictionary.Count Then
                s = s + ","
            End If

            prefix = kvp.Key.Split("_")(0)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
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

End Class