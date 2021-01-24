Module GlobalVars

    ' *******************************************
    ' MainForm
    ' *******************************************

    Public PaginaSelecionada As String = "0"  ' Pagina modo funcionamento



    ' *******************************************
    ' MANUAL
    ' *******************************************



    ' *******************************************
    ' MODO AUTOMÁTICO
    ' *******************************************



    ' *******************************************
    ' PROGRAMA
    ' *******************************************


    ' *******************************************
    ' TABELAS
    ' *******************************************
    Public tabela_ferramentas As New Dictionary(Of String, String)
    Public tabela_ferramentas_path As String = "Config\Parametros_Ferramentas.json"
    Public tabela_referenciais As New Dictionary(Of String, String)
    Public tabela_referenciais_path As String = "Config\Parametros_Referenciais.json"


    ' *******************************************
    ' PARAMETROS
    ' *******************************************
    Public param_eixos As New Dictionary(Of String, String)
    Public param_gerais As New Dictionary(Of String, String)


    Public param_eixos_path As String = "Config\Parametros_Eixos.json"
    Public param_gerais_path As String = "Config\Parametros_Gerais.json"


    Public PosAtualEixoX As Double           ' Posição Atual Eixo X
    Public PosAtualEixoY As Double           ' Posição Atual Eixo Y
    Public PosAtualEixoZ As Double           ' Posição Atual Eixo Z
    Public PosAtualEixoSpindle As Double     ' Posição Atual Spindle

    Public EixoX_LimitePos As Double        ' Posição Limite Positivo Eixo X
    Public EixoY_LimitePos As Double        ' Posição Limite Positivo Eixo Y
    Public EixoZ_LimitePos As Double        ' Posição Limite Positivo Eixo Z

    Public EixoX_LimiteNeg As Double        ' Posição Limite Negativo Eixo X
    Public EixoY_LimiteNeg As Double        ' Posição Limite Negativo Eixo Y
    Public EixoZ_LimiteNeg As Double        ' Posição Limite Negativo Eixo Z


    ' *******************************************
    ' AVISOS
    ' *******************************************

End Module
