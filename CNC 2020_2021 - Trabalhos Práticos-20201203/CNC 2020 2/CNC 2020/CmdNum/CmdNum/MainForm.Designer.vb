<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TabCtrl_Option = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txt_ManFeedRate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_ManMovToPos = New System.Windows.Forms.Button()
        Me.btn_ManSet = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_PosManEixoX = New System.Windows.Forms.TextBox()
        Me.trackBar_ManFeedRate = New System.Windows.Forms.TrackBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_AutFeedRate = New System.Windows.Forms.TextBox()
        Me.btn_ManZMenos = New System.Windows.Forms.Button()
        Me.trackBar_AutFeed = New System.Windows.Forms.TrackBar()
        Me.btn_ManZMais = New System.Windows.Forms.Button()
        Me.label127 = New System.Windows.Forms.Label()
        Me.btn_ManYmenos = New System.Windows.Forms.Button()
        Me.btn_ManXmenos = New System.Windows.Forms.Button()
        Me.btn_ManYMais = New System.Windows.Forms.Button()
        Me.btn_ManXmais = New System.Windows.Forms.Button()
        Me.Panel_PosActual_Man = New System.Windows.Forms.Panel()
        Me.txt_ManPosY = New System.Windows.Forms.TextBox()
        Me.txt_ManPosZ = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label122 = New System.Windows.Forms.Label()
        Me.txt_ManPosX = New System.Windows.Forms.TextBox()
        Me.label131 = New System.Windows.Forms.Label()
        Me.label125 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.tabelas_btn_enviar_referenciais = New System.Windows.Forms.Button()
        Me.tabelas_btn_guardar_referenciais = New System.Windows.Forms.Button()
        Me.tabela_dtgrid_referenciais = New System.Windows.Forms.DataGridView()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.tabelas_btn_enviar_ferramentas = New System.Windows.Forms.Button()
        Me.tabelas_btn_guardar_ferramentas = New System.Windows.Forms.Button()
        Me.tabela_dtgrid_ferramentas = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.param_tab_control = New System.Windows.Forms.TabControl()
        Me.param_tab_geral = New System.Windows.Forms.TabPage()
        Me.param_txt_end_ip = New System.Windows.Forms.TextBox()
        Me.param_cb_protocolo = New System.Windows.Forms.ComboBox()
        Me.param_lbl_endereçoIP = New System.Windows.Forms.Label()
        Me.param_lbl_protocolo = New System.Windows.Forms.Label()
        Me.param_cb_baudrate = New System.Windows.Forms.ComboBox()
        Me.param_lbl_baudrate = New System.Windows.Forms.Label()
        Me.param_cb_portcom = New System.Windows.Forms.ComboBox()
        Me.param_lbl_portcom = New System.Windows.Forms.Label()
        Me.param_btn_guardar_gerais = New System.Windows.Forms.Button()
        Me.param_tab_eixos = New System.Windows.Forms.TabPage()
        Me.param_cbox_n_eixos = New System.Windows.Forms.ComboBox()
        Me.param_lbl_n_eixos = New System.Windows.Forms.Label()
        Me.param_btn_eixos_enviar = New System.Windows.Forms.Button()
        Me.param_btn_eixos_guardar = New System.Windows.Forms.Button()
        Me.param_txt_laser_power = New System.Windows.Forms.TextBox()
        Me.param_txt_spindle_maxrpm = New System.Windows.Forms.TextBox()
        Me.param_laser_power = New System.Windows.Forms.Label()
        Me.param_radbtn_laser = New System.Windows.Forms.RadioButton()
        Me.param_lbl_spindle_maxrpm = New System.Windows.Forms.Label()
        Me.param_radbtn_spindle = New System.Windows.Forms.RadioButton()
        Me.param_dtgrid_eixos = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.StatusStripLbl_Modo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabelasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParâmetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvisosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmr_match3 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.param_dataGrid_nomeFerramentas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pocket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Altura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.param_dataGrid_obsercacoes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Z = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.A = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.B = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eixo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.passo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.max_rpm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.limite_inferior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.limite_superior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.encoder_pitch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.encoder_n_pulsos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabCtrl_Option.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.trackBar_ManFeedRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.trackBar_AutFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_PosActual_Man.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        CType(Me.tabela_dtgrid_referenciais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        CType(Me.tabela_dtgrid_ferramentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.param_tab_control.SuspendLayout()
        Me.param_tab_geral.SuspendLayout()
        Me.param_tab_eixos.SuspendLayout()
        CType(Me.param_dtgrid_eixos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCtrl_Option
        '
        Me.TabCtrl_Option.Controls.Add(Me.TabPage1)
        Me.TabCtrl_Option.Controls.Add(Me.TabPage2)
        Me.TabCtrl_Option.Controls.Add(Me.TabPage3)
        Me.TabCtrl_Option.Controls.Add(Me.TabPage4)
        Me.TabCtrl_Option.Controls.Add(Me.TabPage5)
        Me.TabCtrl_Option.Controls.Add(Me.TabPage6)
        Me.TabCtrl_Option.ImageList = Me.ImageList1
        resources.ApplyResources(Me.TabCtrl_Option, "TabCtrl_Option")
        Me.TabCtrl_Option.Multiline = True
        Me.TabCtrl_Option.Name = "TabCtrl_Option"
        Me.TabCtrl_Option.SelectedIndex = 0
        Me.TabCtrl_Option.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LightGray
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel_PosActual_Man)
        Me.TabPage1.Controls.Add(Me.label125)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        '
        'Label12
        '
        Me.Label12.AllowDrop = True
        Me.Label12.BackColor = System.Drawing.Color.DarkGray
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txt_ManFeedRate)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.btn_ManMovToPos)
        Me.Panel3.Controls.Add(Me.btn_ManSet)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.txt_PosManEixoX)
        Me.Panel3.Controls.Add(Me.trackBar_ManFeedRate)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'txt_ManFeedRate
        '
        Me.txt_ManFeedRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt_ManFeedRate, "txt_ManFeedRate")
        Me.txt_ManFeedRate.Name = "txt_ManFeedRate"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'btn_ManMovToPos
        '
        resources.ApplyResources(Me.btn_ManMovToPos, "btn_ManMovToPos")
        Me.btn_ManMovToPos.Name = "btn_ManMovToPos"
        Me.btn_ManMovToPos.UseVisualStyleBackColor = True
        '
        'btn_ManSet
        '
        resources.ApplyResources(Me.btn_ManSet, "btn_ManSet")
        Me.btn_ManSet.Name = "btn_ManSet"
        Me.btn_ManSet.UseVisualStyleBackColor = True
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'txt_PosManEixoX
        '
        Me.txt_PosManEixoX.BackColor = System.Drawing.SystemColors.Info
        Me.txt_PosManEixoX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt_PosManEixoX, "txt_PosManEixoX")
        Me.txt_PosManEixoX.Name = "txt_PosManEixoX"
        '
        'trackBar_ManFeedRate
        '
        resources.ApplyResources(Me.trackBar_ManFeedRate, "trackBar_ManFeedRate")
        Me.trackBar_ManFeedRate.Maximum = 100
        Me.trackBar_ManFeedRate.Name = "trackBar_ManFeedRate"
        '
        'Label8
        '
        Me.Label8.AllowDrop = True
        Me.Label8.BackColor = System.Drawing.Color.DarkGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txt_AutFeedRate)
        Me.Panel2.Controls.Add(Me.btn_ManZMenos)
        Me.Panel2.Controls.Add(Me.trackBar_AutFeed)
        Me.Panel2.Controls.Add(Me.btn_ManZMais)
        Me.Panel2.Controls.Add(Me.label127)
        Me.Panel2.Controls.Add(Me.btn_ManYmenos)
        Me.Panel2.Controls.Add(Me.btn_ManXmenos)
        Me.Panel2.Controls.Add(Me.btn_ManYMais)
        Me.Panel2.Controls.Add(Me.btn_ManXmais)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'txt_AutFeedRate
        '
        Me.txt_AutFeedRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt_AutFeedRate, "txt_AutFeedRate")
        Me.txt_AutFeedRate.Name = "txt_AutFeedRate"
        '
        'btn_ManZMenos
        '
        resources.ApplyResources(Me.btn_ManZMenos, "btn_ManZMenos")
        Me.btn_ManZMenos.Name = "btn_ManZMenos"
        Me.btn_ManZMenos.UseVisualStyleBackColor = True
        '
        'trackBar_AutFeed
        '
        resources.ApplyResources(Me.trackBar_AutFeed, "trackBar_AutFeed")
        Me.trackBar_AutFeed.Maximum = 100
        Me.trackBar_AutFeed.Name = "trackBar_AutFeed"
        '
        'btn_ManZMais
        '
        resources.ApplyResources(Me.btn_ManZMais, "btn_ManZMais")
        Me.btn_ManZMais.Name = "btn_ManZMais"
        Me.btn_ManZMais.UseVisualStyleBackColor = True
        '
        'label127
        '
        resources.ApplyResources(Me.label127, "label127")
        Me.label127.Name = "label127"
        '
        'btn_ManYmenos
        '
        resources.ApplyResources(Me.btn_ManYmenos, "btn_ManYmenos")
        Me.btn_ManYmenos.Name = "btn_ManYmenos"
        '
        'btn_ManXmenos
        '
        resources.ApplyResources(Me.btn_ManXmenos, "btn_ManXmenos")
        Me.btn_ManXmenos.Name = "btn_ManXmenos"
        Me.btn_ManXmenos.UseVisualStyleBackColor = True
        '
        'btn_ManYMais
        '
        resources.ApplyResources(Me.btn_ManYMais, "btn_ManYMais")
        Me.btn_ManYMais.Name = "btn_ManYMais"
        Me.btn_ManYMais.UseVisualStyleBackColor = True
        '
        'btn_ManXmais
        '
        resources.ApplyResources(Me.btn_ManXmais, "btn_ManXmais")
        Me.btn_ManXmais.Name = "btn_ManXmais"
        Me.btn_ManXmais.UseVisualStyleBackColor = True
        '
        'Panel_PosActual_Man
        '
        Me.Panel_PosActual_Man.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_PosActual_Man.Controls.Add(Me.txt_ManPosY)
        Me.Panel_PosActual_Man.Controls.Add(Me.txt_ManPosZ)
        Me.Panel_PosActual_Man.Controls.Add(Me.Label2)
        Me.Panel_PosActual_Man.Controls.Add(Me.Label1)
        Me.Panel_PosActual_Man.Controls.Add(Me.label122)
        Me.Panel_PosActual_Man.Controls.Add(Me.txt_ManPosX)
        Me.Panel_PosActual_Man.Controls.Add(Me.label131)
        resources.ApplyResources(Me.Panel_PosActual_Man, "Panel_PosActual_Man")
        Me.Panel_PosActual_Man.Name = "Panel_PosActual_Man"
        '
        'txt_ManPosY
        '
        Me.txt_ManPosY.BackColor = System.Drawing.SystemColors.Info
        Me.txt_ManPosY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt_ManPosY, "txt_ManPosY")
        Me.txt_ManPosY.Name = "txt_ManPosY"
        '
        'txt_ManPosZ
        '
        Me.txt_ManPosZ.BackColor = System.Drawing.SystemColors.Info
        Me.txt_ManPosZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt_ManPosZ, "txt_ManPosZ")
        Me.txt_ManPosZ.Name = "txt_ManPosZ"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'label122
        '
        resources.ApplyResources(Me.label122, "label122")
        Me.label122.Name = "label122"
        '
        'txt_ManPosX
        '
        Me.txt_ManPosX.BackColor = System.Drawing.SystemColors.Info
        Me.txt_ManPosX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt_ManPosX, "txt_ManPosX")
        Me.txt_ManPosX.Name = "txt_ManPosX"
        '
        'label131
        '
        resources.ApplyResources(Me.label131, "label131")
        Me.label131.Name = "label131"
        '
        'label125
        '
        Me.label125.AllowDrop = True
        Me.label125.BackColor = System.Drawing.Color.DarkGray
        Me.label125.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.label125, "label125")
        Me.label125.Name = "label125"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Name = "TabPage2"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Label6)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.TextBox3, "TextBox3")
        Me.TextBox3.Name = "TextBox3"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        Me.Label7.AllowDrop = True
        Me.Label7.BackColor = System.Drawing.Color.DarkGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.LightGray
        Me.TabPage3.Controls.Add(Me.MaskedTextBox1)
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        '
        'MaskedTextBox1
        '
        resources.ApplyResources(Me.MaskedTextBox1, "MaskedTextBox1")
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.LightGray
        Me.TabPage4.Controls.Add(Me.TabControl1)
        resources.ApplyResources(Me.TabPage4, "TabPage4")
        Me.TabPage4.Name = "TabPage4"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.tabelas_btn_enviar_referenciais)
        Me.TabPage8.Controls.Add(Me.tabelas_btn_guardar_referenciais)
        Me.TabPage8.Controls.Add(Me.tabela_dtgrid_referenciais)
        resources.ApplyResources(Me.TabPage8, "TabPage8")
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'tabelas_btn_enviar_referenciais
        '
        resources.ApplyResources(Me.tabelas_btn_enviar_referenciais, "tabelas_btn_enviar_referenciais")
        Me.tabelas_btn_enviar_referenciais.Name = "tabelas_btn_enviar_referenciais"
        Me.tabelas_btn_enviar_referenciais.UseVisualStyleBackColor = True
        '
        'tabelas_btn_guardar_referenciais
        '
        resources.ApplyResources(Me.tabelas_btn_guardar_referenciais, "tabelas_btn_guardar_referenciais")
        Me.tabelas_btn_guardar_referenciais.Name = "tabelas_btn_guardar_referenciais"
        Me.tabelas_btn_guardar_referenciais.UseVisualStyleBackColor = True
        '
        'tabela_dtgrid_referenciais
        '
        Me.tabela_dtgrid_referenciais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tabela_dtgrid_referenciais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabela_dtgrid_referenciais.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Referencial, Me.X, Me.Y, Me.Z, Me.A, Me.B, Me.C})
        resources.ApplyResources(Me.tabela_dtgrid_referenciais, "tabela_dtgrid_referenciais")
        Me.tabela_dtgrid_referenciais.Name = "tabela_dtgrid_referenciais"
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.tabelas_btn_enviar_ferramentas)
        Me.TabPage9.Controls.Add(Me.tabelas_btn_guardar_ferramentas)
        Me.TabPage9.Controls.Add(Me.tabela_dtgrid_ferramentas)
        resources.ApplyResources(Me.TabPage9, "TabPage9")
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'tabelas_btn_enviar_ferramentas
        '
        resources.ApplyResources(Me.tabelas_btn_enviar_ferramentas, "tabelas_btn_enviar_ferramentas")
        Me.tabelas_btn_enviar_ferramentas.Name = "tabelas_btn_enviar_ferramentas"
        Me.tabelas_btn_enviar_ferramentas.UseVisualStyleBackColor = True
        '
        'tabelas_btn_guardar_ferramentas
        '
        resources.ApplyResources(Me.tabelas_btn_guardar_ferramentas, "tabelas_btn_guardar_ferramentas")
        Me.tabelas_btn_guardar_ferramentas.Name = "tabelas_btn_guardar_ferramentas"
        Me.tabelas_btn_guardar_ferramentas.UseVisualStyleBackColor = True
        '
        'tabela_dtgrid_ferramentas
        '
        Me.tabela_dtgrid_ferramentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabela_dtgrid_ferramentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.param_dataGrid_nomeFerramentas, Me.Pocket, Me.Altura, Me.Diametro, Me.param_dataGrid_obsercacoes})
        resources.ApplyResources(Me.tabela_dtgrid_ferramentas, "tabela_dtgrid_ferramentas")
        Me.tabela_dtgrid_ferramentas.Name = "tabela_dtgrid_ferramentas"
        Me.tabela_dtgrid_ferramentas.RowTemplate.Height = 24
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.LightGray
        Me.TabPage5.Controls.Add(Me.param_tab_control)
        resources.ApplyResources(Me.TabPage5, "TabPage5")
        Me.TabPage5.Name = "TabPage5"
        '
        'param_tab_control
        '
        resources.ApplyResources(Me.param_tab_control, "param_tab_control")
        Me.param_tab_control.Controls.Add(Me.param_tab_geral)
        Me.param_tab_control.Controls.Add(Me.param_tab_eixos)
        Me.param_tab_control.Name = "param_tab_control"
        Me.param_tab_control.SelectedIndex = 0
        Me.param_tab_control.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        '
        'param_tab_geral
        '
        Me.param_tab_geral.Controls.Add(Me.param_txt_end_ip)
        Me.param_tab_geral.Controls.Add(Me.param_cb_protocolo)
        Me.param_tab_geral.Controls.Add(Me.param_lbl_endereçoIP)
        Me.param_tab_geral.Controls.Add(Me.param_lbl_protocolo)
        Me.param_tab_geral.Controls.Add(Me.param_cb_baudrate)
        Me.param_tab_geral.Controls.Add(Me.param_lbl_baudrate)
        Me.param_tab_geral.Controls.Add(Me.param_cb_portcom)
        Me.param_tab_geral.Controls.Add(Me.param_lbl_portcom)
        Me.param_tab_geral.Controls.Add(Me.param_btn_guardar_gerais)
        resources.ApplyResources(Me.param_tab_geral, "param_tab_geral")
        Me.param_tab_geral.Name = "param_tab_geral"
        Me.param_tab_geral.UseVisualStyleBackColor = True
        '
        'param_txt_end_ip
        '
        resources.ApplyResources(Me.param_txt_end_ip, "param_txt_end_ip")
        Me.param_txt_end_ip.Name = "param_txt_end_ip"
        '
        'param_cb_protocolo
        '
        Me.param_cb_protocolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.param_cb_protocolo.FormattingEnabled = True
        Me.param_cb_protocolo.Items.AddRange(New Object() {resources.GetString("param_cb_protocolo.Items"), resources.GetString("param_cb_protocolo.Items1"), resources.GetString("param_cb_protocolo.Items2")})
        resources.ApplyResources(Me.param_cb_protocolo, "param_cb_protocolo")
        Me.param_cb_protocolo.Name = "param_cb_protocolo"
        '
        'param_lbl_endereçoIP
        '
        resources.ApplyResources(Me.param_lbl_endereçoIP, "param_lbl_endereçoIP")
        Me.param_lbl_endereçoIP.Name = "param_lbl_endereçoIP"
        '
        'param_lbl_protocolo
        '
        resources.ApplyResources(Me.param_lbl_protocolo, "param_lbl_protocolo")
        Me.param_lbl_protocolo.Name = "param_lbl_protocolo"
        '
        'param_cb_baudrate
        '
        Me.param_cb_baudrate.FormattingEnabled = True
        Me.param_cb_baudrate.Items.AddRange(New Object() {resources.GetString("param_cb_baudrate.Items"), resources.GetString("param_cb_baudrate.Items1"), resources.GetString("param_cb_baudrate.Items2"), resources.GetString("param_cb_baudrate.Items3"), resources.GetString("param_cb_baudrate.Items4"), resources.GetString("param_cb_baudrate.Items5"), resources.GetString("param_cb_baudrate.Items6")})
        resources.ApplyResources(Me.param_cb_baudrate, "param_cb_baudrate")
        Me.param_cb_baudrate.Name = "param_cb_baudrate"
        '
        'param_lbl_baudrate
        '
        resources.ApplyResources(Me.param_lbl_baudrate, "param_lbl_baudrate")
        Me.param_lbl_baudrate.Name = "param_lbl_baudrate"
        '
        'param_cb_portcom
        '
        Me.param_cb_portcom.FormattingEnabled = True
        resources.ApplyResources(Me.param_cb_portcom, "param_cb_portcom")
        Me.param_cb_portcom.Name = "param_cb_portcom"
        '
        'param_lbl_portcom
        '
        resources.ApplyResources(Me.param_lbl_portcom, "param_lbl_portcom")
        Me.param_lbl_portcom.Name = "param_lbl_portcom"
        '
        'param_btn_guardar_gerais
        '
        resources.ApplyResources(Me.param_btn_guardar_gerais, "param_btn_guardar_gerais")
        Me.param_btn_guardar_gerais.Name = "param_btn_guardar_gerais"
        Me.param_btn_guardar_gerais.UseVisualStyleBackColor = True
        '
        'param_tab_eixos
        '
        Me.param_tab_eixos.Controls.Add(Me.param_cbox_n_eixos)
        Me.param_tab_eixos.Controls.Add(Me.param_lbl_n_eixos)
        Me.param_tab_eixos.Controls.Add(Me.param_btn_eixos_enviar)
        Me.param_tab_eixos.Controls.Add(Me.param_btn_eixos_guardar)
        Me.param_tab_eixos.Controls.Add(Me.param_txt_laser_power)
        Me.param_tab_eixos.Controls.Add(Me.param_txt_spindle_maxrpm)
        Me.param_tab_eixos.Controls.Add(Me.param_laser_power)
        Me.param_tab_eixos.Controls.Add(Me.param_radbtn_laser)
        Me.param_tab_eixos.Controls.Add(Me.param_lbl_spindle_maxrpm)
        Me.param_tab_eixos.Controls.Add(Me.param_radbtn_spindle)
        Me.param_tab_eixos.Controls.Add(Me.param_dtgrid_eixos)
        resources.ApplyResources(Me.param_tab_eixos, "param_tab_eixos")
        Me.param_tab_eixos.Name = "param_tab_eixos"
        Me.param_tab_eixos.UseVisualStyleBackColor = True
        '
        'param_cbox_n_eixos
        '
        Me.param_cbox_n_eixos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.param_cbox_n_eixos.FormattingEnabled = True
        Me.param_cbox_n_eixos.Items.AddRange(New Object() {resources.GetString("param_cbox_n_eixos.Items"), resources.GetString("param_cbox_n_eixos.Items1"), resources.GetString("param_cbox_n_eixos.Items2"), resources.GetString("param_cbox_n_eixos.Items3"), resources.GetString("param_cbox_n_eixos.Items4")})
        resources.ApplyResources(Me.param_cbox_n_eixos, "param_cbox_n_eixos")
        Me.param_cbox_n_eixos.Name = "param_cbox_n_eixos"
        '
        'param_lbl_n_eixos
        '
        resources.ApplyResources(Me.param_lbl_n_eixos, "param_lbl_n_eixos")
        Me.param_lbl_n_eixos.Name = "param_lbl_n_eixos"
        Me.param_lbl_n_eixos.UseMnemonic = False
        '
        'param_btn_eixos_enviar
        '
        resources.ApplyResources(Me.param_btn_eixos_enviar, "param_btn_eixos_enviar")
        Me.param_btn_eixos_enviar.Name = "param_btn_eixos_enviar"
        Me.param_btn_eixos_enviar.UseVisualStyleBackColor = True
        '
        'param_btn_eixos_guardar
        '
        resources.ApplyResources(Me.param_btn_eixos_guardar, "param_btn_eixos_guardar")
        Me.param_btn_eixos_guardar.Name = "param_btn_eixos_guardar"
        Me.param_btn_eixos_guardar.UseVisualStyleBackColor = True
        '
        'param_txt_laser_power
        '
        resources.ApplyResources(Me.param_txt_laser_power, "param_txt_laser_power")
        Me.param_txt_laser_power.Name = "param_txt_laser_power"
        '
        'param_txt_spindle_maxrpm
        '
        resources.ApplyResources(Me.param_txt_spindle_maxrpm, "param_txt_spindle_maxrpm")
        Me.param_txt_spindle_maxrpm.Name = "param_txt_spindle_maxrpm"
        '
        'param_laser_power
        '
        resources.ApplyResources(Me.param_laser_power, "param_laser_power")
        Me.param_laser_power.Name = "param_laser_power"
        Me.param_laser_power.UseMnemonic = False
        '
        'param_radbtn_laser
        '
        resources.ApplyResources(Me.param_radbtn_laser, "param_radbtn_laser")
        Me.param_radbtn_laser.Name = "param_radbtn_laser"
        Me.param_radbtn_laser.TabStop = True
        Me.param_radbtn_laser.UseVisualStyleBackColor = True
        '
        'param_lbl_spindle_maxrpm
        '
        resources.ApplyResources(Me.param_lbl_spindle_maxrpm, "param_lbl_spindle_maxrpm")
        Me.param_lbl_spindle_maxrpm.Name = "param_lbl_spindle_maxrpm"
        Me.param_lbl_spindle_maxrpm.UseMnemonic = False
        '
        'param_radbtn_spindle
        '
        resources.ApplyResources(Me.param_radbtn_spindle, "param_radbtn_spindle")
        Me.param_radbtn_spindle.Name = "param_radbtn_spindle"
        Me.param_radbtn_spindle.TabStop = True
        Me.param_radbtn_spindle.UseVisualStyleBackColor = True
        '
        'param_dtgrid_eixos
        '
        Me.param_dtgrid_eixos.AllowUserToAddRows = False
        Me.param_dtgrid_eixos.AllowUserToDeleteRows = False
        Me.param_dtgrid_eixos.AllowUserToResizeRows = False
        Me.param_dtgrid_eixos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.param_dtgrid_eixos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.param_dtgrid_eixos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.eixo, Me.passo, Me.max_rpm, Me.limite_inferior, Me.limite_superior, Me.encoder_pitch, Me.encoder_n_pulsos})
        resources.ApplyResources(Me.param_dtgrid_eixos, "param_dtgrid_eixos")
        Me.param_dtgrid_eixos.Name = "param_dtgrid_eixos"
        Me.param_dtgrid_eixos.RowHeadersVisible = False
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.TabPage6, "TabPage6")
        Me.TabPage6.Name = "TabPage6"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Avisos2.png")
        Me.ImageList1.Images.SetKeyName(1, "man1.png")
        Me.ImageList1.Images.SetKeyName(2, "Programas.png")
        Me.ImageList1.Images.SetKeyName(3, "Opções.png")
        Me.ImageList1.Images.SetKeyName(4, "Aut.png")
        Me.ImageList1.Images.SetKeyName(5, "apresentacao.PNG")
        Me.ImageList1.Images.SetKeyName(6, "Parametros.png")
        Me.ImageList1.Images.SetKeyName(7, "Tabelas.png")
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripLbl_Modo})
        resources.ApplyResources(Me.StatusStrip, "StatusStrip")
        Me.StatusStrip.Name = "StatusStrip"
        '
        'StatusStripLbl_Modo
        '
        Me.StatusStripLbl_Modo.Name = "StatusStripLbl_Modo"
        resources.ApplyResources(Me.StatusStripLbl_Modo, "StatusStripLbl_Modo")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ManualToolStripMenuItem, Me.AutomToolStripMenuItem, Me.ProgramasToolStripMenuItem, Me.TabelasToolStripMenuItem, Me.ParâmetrosToolStripMenuItem, Me.AvisosToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        resources.ApplyResources(Me.SairToolStripMenuItem, "SairToolStripMenuItem")
        '
        'ManualToolStripMenuItem
        '
        Me.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem"
        resources.ApplyResources(Me.ManualToolStripMenuItem, "ManualToolStripMenuItem")
        '
        'AutomToolStripMenuItem
        '
        Me.AutomToolStripMenuItem.Name = "AutomToolStripMenuItem"
        resources.ApplyResources(Me.AutomToolStripMenuItem, "AutomToolStripMenuItem")
        '
        'ProgramasToolStripMenuItem
        '
        Me.ProgramasToolStripMenuItem.Name = "ProgramasToolStripMenuItem"
        resources.ApplyResources(Me.ProgramasToolStripMenuItem, "ProgramasToolStripMenuItem")
        '
        'TabelasToolStripMenuItem
        '
        Me.TabelasToolStripMenuItem.Name = "TabelasToolStripMenuItem"
        resources.ApplyResources(Me.TabelasToolStripMenuItem, "TabelasToolStripMenuItem")
        '
        'ParâmetrosToolStripMenuItem
        '
        Me.ParâmetrosToolStripMenuItem.Name = "ParâmetrosToolStripMenuItem"
        resources.ApplyResources(Me.ParâmetrosToolStripMenuItem, "ParâmetrosToolStripMenuItem")
        '
        'AvisosToolStripMenuItem
        '
        Me.AvisosToolStripMenuItem.Name = "AvisosToolStripMenuItem"
        resources.ApplyResources(Me.AvisosToolStripMenuItem, "AvisosToolStripMenuItem")
        '
        'tmr_match3
        '
        '
        'ID
        '
        Me.ID.FillWeight = 13.27713!
        resources.ApplyResources(Me.ID, "ID")
        Me.ID.Name = "ID"
        '
        'param_dataGrid_nomeFerramentas
        '
        Me.param_dataGrid_nomeFerramentas.FillWeight = 49.00303!
        resources.ApplyResources(Me.param_dataGrid_nomeFerramentas, "param_dataGrid_nomeFerramentas")
        Me.param_dataGrid_nomeFerramentas.Name = "param_dataGrid_nomeFerramentas"
        '
        'Pocket
        '
        Me.Pocket.FillWeight = 83.93834!
        resources.ApplyResources(Me.Pocket, "Pocket")
        Me.Pocket.Name = "Pocket"
        '
        'Altura
        '
        Me.Altura.FillWeight = 118.1006!
        resources.ApplyResources(Me.Altura, "Altura")
        Me.Altura.Name = "Altura"
        '
        'Diametro
        '
        Me.Diametro.FillWeight = 151.5069!
        resources.ApplyResources(Me.Diametro, "Diametro")
        Me.Diametro.Name = "Diametro"
        '
        'param_dataGrid_obsercacoes
        '
        Me.param_dataGrid_obsercacoes.FillWeight = 184.1739!
        resources.ApplyResources(Me.param_dataGrid_obsercacoes, "param_dataGrid_obsercacoes")
        Me.param_dataGrid_obsercacoes.Name = "param_dataGrid_obsercacoes"
        '
        'Referencial
        '
        resources.ApplyResources(Me.Referencial, "Referencial")
        Me.Referencial.Name = "Referencial"
        Me.Referencial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'X
        '
        resources.ApplyResources(Me.X, "X")
        Me.X.Name = "X"
        Me.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Y
        '
        resources.ApplyResources(Me.Y, "Y")
        Me.Y.Name = "Y"
        Me.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Z
        '
        resources.ApplyResources(Me.Z, "Z")
        Me.Z.Name = "Z"
        Me.Z.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'A
        '
        resources.ApplyResources(Me.A, "A")
        Me.A.Name = "A"
        Me.A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'B
        '
        resources.ApplyResources(Me.B, "B")
        Me.B.Name = "B"
        Me.B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'C
        '
        resources.ApplyResources(Me.C, "C")
        Me.C.Name = "C"
        Me.C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'eixo
        '
        resources.ApplyResources(Me.eixo, "eixo")
        Me.eixo.Name = "eixo"
        Me.eixo.ReadOnly = True
        Me.eixo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'passo
        '
        resources.ApplyResources(Me.passo, "passo")
        Me.passo.Name = "passo"
        Me.passo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.passo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'max_rpm
        '
        resources.ApplyResources(Me.max_rpm, "max_rpm")
        Me.max_rpm.Name = "max_rpm"
        Me.max_rpm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'limite_inferior
        '
        resources.ApplyResources(Me.limite_inferior, "limite_inferior")
        Me.limite_inferior.Name = "limite_inferior"
        Me.limite_inferior.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'limite_superior
        '
        resources.ApplyResources(Me.limite_superior, "limite_superior")
        Me.limite_superior.Name = "limite_superior"
        Me.limite_superior.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'encoder_pitch
        '
        resources.ApplyResources(Me.encoder_pitch, "encoder_pitch")
        Me.encoder_pitch.Name = "encoder_pitch"
        Me.encoder_pitch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'encoder_n_pulsos
        '
        resources.ApplyResources(Me.encoder_n_pulsos, "encoder_n_pulsos")
        Me.encoder_n_pulsos.Name = "encoder_n_pulsos"
        Me.encoder_n_pulsos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabCtrl_Option)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.TabCtrl_Option.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.trackBar_ManFeedRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.trackBar_AutFeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_PosActual_Man.ResumeLayout(False)
        Me.Panel_PosActual_Man.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        CType(Me.tabela_dtgrid_referenciais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        CType(Me.tabela_dtgrid_ferramentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.param_tab_control.ResumeLayout(False)
        Me.param_tab_geral.ResumeLayout(False)
        Me.param_tab_geral.PerformLayout()
        Me.param_tab_eixos.ResumeLayout(False)
        Me.param_tab_eixos.PerformLayout()
        CType(Me.param_dtgrid_eixos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ImageList1 As ImageList
    Private WithEvents TabCtrl_Option As TabControl
    Private WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents label125 As Label
    Friend WithEvents Panel_PosActual_Man As Panel
    Private WithEvents txt_ManPosY As TextBox
    Private WithEvents txt_ManPosZ As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents Label1 As Label
    Private WithEvents label122 As Label
    Private WithEvents label131 As Label
    Private WithEvents label127 As Label
    Public WithEvents txt_AutFeedRate As TextBox
    Private WithEvents trackBar_AutFeed As TrackBar
    Friend WithEvents Panel1 As Panel
    Private WithEvents TextBox1 As TextBox
    Private WithEvents TextBox2 As TextBox
    Private WithEvents Label3 As Label
    Private WithEvents Label4 As Label
    Private WithEvents Label5 As Label
    Private WithEvents TextBox3 As TextBox
    Private WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Private WithEvents btn_ManZMenos As Button
    Private WithEvents btn_ManZMais As Button
    Private WithEvents btn_ManYmenos As Button
    Private WithEvents btn_ManXmenos As Button
    Private WithEvents btn_ManYMais As Button
    Private WithEvents btn_ManXmais As Button
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents StatusStripLbl_Modo As ToolStripStatusLabel
    Private WithEvents btn_ManSet As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabelasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParâmetrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AvisosToolStripMenuItem As ToolStripMenuItem
    Public WithEvents txt_ManPosX As TextBox
    Friend WithEvents tmr_match3 As Timer
    Private WithEvents Label10 As Label
    Private WithEvents Label9 As Label
    Private WithEvents txt_PosManEixoX As TextBox
    Private WithEvents btn_ManMovToPos As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Public WithEvents txt_ManFeedRate As TextBox
    Private WithEvents Label11 As Label
    Private WithEvents trackBar_ManFeedRate As TrackBar
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents tabelas_btn_guardar_referenciais As Button
    Friend WithEvents tabela_dtgrid_referenciais As DataGridView
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents tabelas_btn_guardar_ferramentas As Button
    Friend WithEvents tabela_dtgrid_ferramentas As DataGridView
    Friend WithEvents param_btn_Guardar As Button
    Friend WithEvents param_tab_control As TabControl
    Friend WithEvents param_tab_geral As TabPage
    Friend WithEvents param_txt_end_ip As TextBox
    Friend WithEvents param_cb_protocolo As ComboBox
    Friend WithEvents param_lbl_endereçoIP As Label
    Friend WithEvents param_lbl_protocolo As Label
    Friend WithEvents param_cb_baudrate As ComboBox
    Friend WithEvents param_lbl_baudrate As Label
    Friend WithEvents param_cb_portcom As ComboBox
    Friend WithEvents param_lbl_portcom As Label
    Friend WithEvents param_btn_guardar_gerais As Button
    Friend WithEvents param_tab_eixos As TabPage
    Friend WithEvents param_btn_eixos_guardar As Button
    Friend WithEvents param_txt_laser_power As TextBox
    Friend WithEvents param_txt_spindle_maxrpm As TextBox
    Friend WithEvents param_laser_power As Label
    Friend WithEvents param_radbtn_laser As RadioButton
    Friend WithEvents param_lbl_spindle_maxrpm As Label
    Friend WithEvents param_radbtn_spindle As RadioButton
    Friend WithEvents param_dtgrid_eixos As DataGridView
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents param_btn_eixos_enviar As Button
    Friend WithEvents tabelas_btn_enviar_referenciais As Button
    Friend WithEvents tabelas_btn_enviar_ferramentas As Button
    Friend WithEvents param_lbl_n_eixos As Label
    Friend WithEvents param_cbox_n_eixos As ComboBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents param_dataGrid_nomeFerramentas As DataGridViewTextBoxColumn
    Friend WithEvents Pocket As DataGridViewTextBoxColumn
    Friend WithEvents Altura As DataGridViewTextBoxColumn
    Friend WithEvents Diametro As DataGridViewTextBoxColumn
    Friend WithEvents param_dataGrid_obsercacoes As DataGridViewTextBoxColumn
    Friend WithEvents Referencial As DataGridViewTextBoxColumn
    Friend WithEvents X As DataGridViewTextBoxColumn
    Friend WithEvents Y As DataGridViewTextBoxColumn
    Friend WithEvents Z As DataGridViewTextBoxColumn
    Friend WithEvents A As DataGridViewTextBoxColumn
    Friend WithEvents B As DataGridViewTextBoxColumn
    Friend WithEvents C As DataGridViewTextBoxColumn
    Friend WithEvents eixo As DataGridViewTextBoxColumn
    Friend WithEvents passo As DataGridViewTextBoxColumn
    Friend WithEvents max_rpm As DataGridViewTextBoxColumn
    Friend WithEvents limite_inferior As DataGridViewTextBoxColumn
    Friend WithEvents limite_superior As DataGridViewTextBoxColumn
    Friend WithEvents encoder_pitch As DataGridViewTextBoxColumn
    Friend WithEvents encoder_n_pulsos As DataGridViewTextBoxColumn
End Class
