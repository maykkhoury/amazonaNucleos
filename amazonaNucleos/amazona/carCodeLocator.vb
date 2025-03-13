Public Class carCodeLocator


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctCodeLoc.Click

    End Sub

    Private Sub colorCodeLocator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim carsTab() As String = getCarNamesWithLocators()
        cmbCarCL.Items.Add("")
        Dim i As Integer
        For i = 0 To carsTab.Length - 1
            cmbCarCL.Items.Add(carsTab(i))
        Next
        cmbCarCL.Text = ""
        cmbModelCL.Text = ""
        cmbYearCL.Text = ""

        cmbModelCL.Enabled = False
        cmbYearCL.Enabled = False
        butSearchCl.Enabled = False


    End Sub


    Private Sub cclCancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cclCancelBtn.Click
        Me.Close()
    End Sub


    Private Sub cmbCarCL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCarCL.SelectedIndexChanged
        cmbModelCL.Enabled = False
        cmbYearCL.Enabled = False
        butSearchCl.Enabled = False

        Dim selectedcar As String = cmbCarCL.Text
        If selectedcar = "" Then
            pctCarImg.BackgroundImage = Nothing
            Return
        End If
        Dim modelsTab As String() = getCarModels(selectedcar)

        If modelsTab.Length = 0 Then
            Return
        End If

        Dim i As Integer
        cmbModelCL.Items.Clear()
        If modelsTab.Length = 1 And modelsTab(0).ToLower = "all" Then 'only all
            'cmbModelCL.Items.Add("all")
            cmbModelCL.Text = "all"

            'also get years with all
            'If modelsTab.Length = 1 Then 'only all
            Dim yearsTab As String() = getCarModelYears(selectedcar, "all")
            cmbYearCL.Items.Clear()

            If yearsTab.Length = 1 And yearsTab(0).ToLower = "all" Then 'only all
                cmbYearCL.Enabled = False
            Else
                'cmbYearCL.Items.Add("all")
                For i = 0 To yearsTab.Length - 1
                    cmbYearCL.Items.Add(yearsTab(i))
                Next
                cmbYearCL.Text = "all"
                cmbYearCL.Enabled = True
            End If

            '''''
        Else
            'cmbModelCL.Items.Add("all")
            For i = 0 To modelsTab.Length - 1
                cmbModelCL.Items.Add(modelsTab(i))
            Next
            cmbModelCL.Text = "all"
        End If

        cmbModelCL.Enabled = True
        butSearchCl.Enabled = True

        Dim selectedCarObj As Car = getCarByName(selectedcar)
        If Not selectedCarObj Is Nothing Then
            Dim imgPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//images//" & selectedCarObj.carImgPath
            Try
                pctCarImg.BackgroundImage = Image.FromFile(imgPath)
                pctCarImg.BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
            End Try
        End If



    End Sub


    Private Sub cmbModelCL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModelCL.SelectedIndexChanged
        Dim selectedcar As String = cmbCarCL.Text
        Dim selectedmodel As String = cmbModelCL.Text
        Dim yearsTab As String() = getCarModelYears(selectedcar, selectedmodel)
        cmbYearCL.Items.Clear()
        If yearsTab Is Nothing Then
            cmbYearCL.Enabled = False
            Return
        End If
        If yearsTab.Length = 0 Then
            cmbYearCL.Enabled = False
            Return
        End If
        'If yearsTab.Length = 1 And yearsTab(0).ToLower = "all" Then 'only all
        'cmbYearCL.Enabled = False
        'cmbYearCL.Items.Add("all")
        'cmbYearCL.Text = "all"
        'Else
        'cmbYearCL.Items.Add("all")
        For i = 0 To yearsTab.Length - 1
            cmbYearCL.Items.Add(yearsTab(i))
        Next
        cmbYearCL.Text = "all"
        cmbYearCL.Enabled = True
        ' End If



    End Sub
    ' If selectedmodel.ToLower = "all" Then 'get all the locators for this car
    '        locatorsDBFormat = getAllColorLocatorsByCar(selectedcar)
    '    Else
    '        If selectedyear.ToLower = "all" Then 'model <> all and year=all=> get all locators for this car and model
    '           locatorsDBFormat = getAllColorLocatorsByCarAndModel(selectedcar, selectedmodel)
    '       Else 'get exactly the locators for this car this model this year
    '           locatorsDBFormat = getAllColorLocatorsByCarAndModelAndYear(selectedcar, selectedmodel, selectedyear)
    '     End If
    '   End If
    Private Sub butSearchCl_Click(sender As Object, e As EventArgs) Handles butSearchCl.Click
        Dim selectedcar As String = cmbCarCL.Text
        Dim selectedmodel As String = cmbModelCL.Text
        Dim selectedyear As String = cmbYearCL.Text
        Dim locatorsDBFormat As String = ""


        locatorsDBFormat = getAllColorLocatorsByCarAndModelAndYear(selectedcar, selectedmodel, selectedyear)

        locatorsDBFormat = locatorsDBFormat.Replace(";;", ";")
        Dim MyArray As New ArrayList
        Dim locatorsXY() As String = locatorsDBFormat.Split(";")
        For i = 0 To locatorsXY.Length - 1
            If Not locatorsXY(i).Contains(",") Then
                Continue For 'not a valid string
            End If
            Dim cssTop As String = locatorsXY(i).Split(",")(0).Replace("px", "")
            Dim cssLeft As String = locatorsXY(i).Split(",")(1).Replace("px", "")
            If cssTop.StartsWith("-") Or cssLeft.StartsWith("-") Then
                Continue For 'not a valid string, negative top or left
            End If
            Dim X As Integer = CType(cssLeft, Integer)
            Dim Y As Integer = CType(cssTop, Integer)
            Dim locPoint As New Point(X, Y)
            MyArray.Add(locPoint)

        Next
        Dim locPoints() As Point = DirectCast(MyArray.ToArray(GetType(Point)), Point())
        pctCodeLoc.Image = drawLocatorsImage(locPoints)

        'pctCodeLoc.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory()  & "//locatorsOutput.png")

    End Sub
    Private Function drawLocatorsImage(ByVal locPoints() As Point) As Image
        Dim greedDotImg As Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "//darkgreen-dot.png")

        'Create image object from existing image
        Dim carsImg As Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "//codelocator.gif")

        Dim img As Image = New Bitmap(454, 452)

        Dim g As Graphics = Graphics.FromImage(img)

        ' Place a.gif
        g.DrawImage(carsImg, New Point(0, 0))

        For i = 0 To locPoints.Length - 1
            g.DrawImage(greedDotImg, locPoints(i))
        Next

        ' img.Save(System.AppDomain.CurrentDomain.BaseDirectory()  & "//locatorsOutput.png", ImageFormat.Png)

        Return img
    End Function
End Class