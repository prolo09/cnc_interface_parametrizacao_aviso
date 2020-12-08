Module Manual
    ' Rotinas Modo Manual

    Class ManualRotinas
        Public Per As Double


        ' Exemplo de uma subrotina
        Public Sub Perimetro(ByVal raio As Double)
            ' Calculo do Perimetro
            Per = 2 * 3.14 * raio
        End Sub

        ' Exemplo de uma função
        Public Function PosicaoX(ByVal comp As Double) As Double
            PosicaoX = comp * 2
            MainForm.txt_ManPosX.Text = "555"
            Return PosicaoX
        End Function
    End Class

    ' *************************************************************************
    ' Declaração de Rotinas a ser utilizadas pelo programa principal: MainForm
    ' *************************************************************************
    Public Sub Manual_SetRefPoint()
        ' Definição do Ponto de Referência do Equipamento (POM)
        ' A Borges - 29 Nov 2020
        '
        MainForm.mach = GetObject(, "Mach4.Document")
        MainForm.scriptObject = MainForm.mach.GetScriptDispatch()

        MainForm.scriptObject.SetOEMDRO(800, 0)
        MainForm.scriptObject.SetOEMDRO(801, 0)
        MainForm.scriptObject.SetOEMDRO(802, 0)
        MainForm.scriptObject.SetOEMDRO(803, 0)
        MainForm.scriptObject.SetOEMDRO(804, 0)
        MainForm.scriptObject.SetOEMDRO(805, 0)

        MainForm.scriptObject.SetMachZero(0)
        MainForm.scriptObject.SetMachZero(1)
        MainForm.scriptObject.SetMachZero(2)
        MainForm.scriptObject.SetMachZero(3)
        MainForm.scriptObject.SetMachZero(4)
        MainForm.scriptObject.SetMachZero(5)
    End Sub

    Sub Main()


    End Sub

End Module
