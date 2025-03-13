Imports System.Drawing.Printing
Imports System.Globalization

Public Class details

    Private cont As Boolean = False, start As Long, pgnum As Long = 1
    Private qtyWidth As Integer = -1, clrWidth As Integer = -1
    Private kiloLitreRate As Double = Nothing
    Public formulaDup As Formula = Nothing
    Public fromMinimize As Boolean = False
    Public prevQty As Double = 1
    Public id_formulaComposedGlobal As Integer = -1, oldDbComposedGlobal As String = ""
    Public formulaCorrupted As Boolean = False
    Private isBumperEdit As Boolean = False
    Public selectNormal As Boolean = False
    Public quantitiesWithAllDecimals As Double()
    Public quantitiesWithAllDecimalsCum As Double()

    Public Sub loadClients()
        ' Dim idCar As Long = garageHome.lbCarIdSearch.Text
        Dim clientsTab() As String = getClients("clientFormula", chosenCar.carName, chosenCar.id_car)
        Dim i As Integer
        cmbClientName.Items.Clear()
        cmbClientName.Items.Add("")
        If Not clientsTab Is Nothing Then
            For i = 0 To clientsTab.Length - 1
                cmbClientName.Items.Add(clientsTab(i))
            Next
        End If
        'test if it's a client formula
        cmbClientName.Text = ""
        If Not garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text Is Nothing Then
            If garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text <> "" Then
                cmbClientName.Text = garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text
            End If
        End If
        '


    End Sub
    Public Sub loadEdit()
        Dim newFontColors As Font = New Font(txtColorsDetailHidden.Font.FontFamily, getFontSize(0))
        txtQuantityDetailHidden.Font = newFontColors
        txtColorsDetailHidden.Font = newFontColors
        pctColorDetailHidden.Size = New Size(pctColorDetailHidden.Width, getFontSize(1))

        'setFormLabels()
        lbUnitMesureValue.Text = chosenUnit.getUnitName(chosenLanguage.id_language)
        lbCurrencyDetailsValue.Text = chosenCurrency.code_currency

        If chosenUnit.id_unit = 2 Then
            enableKilo()
        Else
            enableLitre()
        End If

    End Sub

    Private Sub edit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not fromMinimize Then
            fromMinimize = False
            ' Me.Dispose()
            Me.disposeHiddenTextBoxes()

            garageHome.Visible = True
            garageHome.Show()
            If Not isBumperEdit And id_formulaComposedGlobal <> -1 Then 'coming from formulaComposed form
                formComposed.Visible = True
                formComposed.Show()
            End If

        End If

    End Sub

    Private Sub edit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If (e.KeyCode = Keys.Add Or e.KeyCode = 187) And e.Control = True Then
            addColorToFormula()
        End If
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = garageHome.Icon

        If selectNormal Then
            rdNormal.Select()
        End If
        loadEdit()
        loadClients()
        setChkBackColor()
        setVariantsMouseHover()

        Dim clientName As String = garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text
        If clientName = Nothing Then
            clientName = ""
        End If
        If clientName = "" Then
            butDeleteClientFormula.Visible = False
        Else
            butDeleteClientFormula.Visible = True
        End If
    End Sub
    Private Sub setVariantsMouseHover()
        chkVariantB.AccessibleDescription = chkVariantB.Text
        chkVariantL.AccessibleDescription = chkVariantL.Text
        chkVariantCO.AccessibleDescription = chkVariantCO.Text
        chkVariantD.AccessibleDescription = chkVariantD.Text
        chkVariantDRT.AccessibleDescription = chkVariantDRT.Text
        chkVariantF.AccessibleDescription = chkVariantF.Text
        chkVariantG.AccessibleDescription = chkVariantG.Text
        chkVariantL.AccessibleDescription = chkVariantL.Text
        chkVariantR.AccessibleDescription = chkVariantR.Text
        chkVariantY.AccessibleDescription = chkVariantY.Text

        Me.ToolTipVariant.SetToolTip(chkVariantB, "Blue")
        Me.ToolTipVariant.SetToolTip(chkVariantL, "Cleaner")
        Me.ToolTipVariant.SetToolTip(chkVariantCO, "Coarser")
        Me.ToolTipVariant.SetToolTip(chkVariantD, "Darker")
        Me.ToolTipVariant.SetToolTip(chkVariantDRT, "Dirtier")
        Me.ToolTipVariant.SetToolTip(chkVariantF, "Finer")
        Me.ToolTipVariant.SetToolTip(chkVariantG, "Green")
        Me.ToolTipVariant.SetToolTip(chkVariantL, "Lighter")
        Me.ToolTipVariant.SetToolTip(chkVariantR, "Red")
        Me.ToolTipVariant.SetToolTip(chkVariantY, "Yellow")

        ' AddHandler chkVariantB.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantB.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantL.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantL.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantCO.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantCO.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantD.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantD.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantDRT.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantDRT.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantF.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantF.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantG.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantG.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantL.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantL.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantR.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantR.MouseLeave, AddressOf chkVariant_MouseLeave

        'AddHandler chkVariantY.MouseHover, AddressOf chkVariant_MouseHover
        'AddHandler chkVariantY.MouseLeave, AddressOf chkVariant_MouseLeave

    End Sub


    Private Sub setChkBackColor()
        chkVariantD.BackgroundImage = variants(0).variantImage
        chkVariantF.BackgroundImage = variants(1).variantImage
        chkVariantDRT.BackgroundImage = variants(2).variantImage
        chkVariantL.BackgroundImage = variants(3).variantImage
        chkVariantR.BackgroundImage = variants(4).variantImage
        chkVariantY.BackgroundImage = variants(5).variantImage
        chkVariantB.BackgroundImage = variants(6).variantImage
        chkVariantCO.BackgroundImage = variants(7).variantImage
        chkVariantG.BackgroundImage = variants(8).variantImage
        chkVariantCL.BackgroundImage = variants(9).variantImage
    End Sub


    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub hideRadioVariants()

        chkVariantD.Visible = False

        chkVariantF.Visible = False

        chkVariantDRT.Visible = False

        chkVariantL.Visible = False

        chkVariantR.Visible = False

        chkVariantY.Visible = False

        chkVariantB.Visible = False

        chkVariantCO.Visible = False

        chkVariantG.Visible = False

        chkVariantL.Visible = False

    End Sub
    Public Sub disposeHiddenTextBoxes()

        Try
            txtTotalPrice.Text = ""
            txtTotalQty.Text = ""
            txtCarDetails.Text = ""
            lbFormulaId.Text = "-1"
            txtYear.Text = ""
            txtFormulaCode.Text = ""
            txtCardNumber.Text = ""
            txtFname.Text = ""
            txtHue.Text = ""
            pctCarImg.ImageLocation = Nothing

            'lbDuplicateName.Text = ""
            Dim controls As GroupBox.ControlCollection = grpDetail.Controls

            Dim j As Integer

            For j = 0 To controls.Count - 1
                If (controls(j).Name.IndexOf("pctColorDetail") <> -1 And controls(j).Name.IndexOf("hidden") = -1) Or ((controls(j).Name.IndexOf("txt") <> -1 And controls(j).Name.IndexOf("hidden") = -1 And controls(j).Name <> txtTotalPrice.Name And controls(j).Name <> txtTotalQty.Name) Or controls(j).Name = "butValidate" Or (controls(j).Name.IndexOf("butDeleteColor") <> -1 Or controls(j).Name.IndexOf("butAddColor") <> -1)) Then
                    controls(j).Dispose()
                    j = 0
                End If

            Next

        Catch ex As Exception
        End Try

        Try
            Dim controls2 As SplitContainer.ControlCollection = scrollPanel1.Controls
            For j = 0 To controls2.Count - 1
                If (controls2(j).Name.IndexOf("pctColorDetail") <> -1 And controls2(j).Name.IndexOf("hidden") = -1) Or ((controls2(j).Name.IndexOf("txt") <> -1 And controls2(j).Name.IndexOf("hidden") = -1 And controls2(j).Name <> txtTotalPrice.Name And controls2(j).Name <> txtTotalQty.Name) Or controls2(j).Name = "butValidate" Or (controls2(j).Name.IndexOf("butDeleteColor") <> -1 Or controls2(j).Name.IndexOf("butAddColor") <> -1)) Then
                    controls2(j).Dispose()
                    j = 0
                End If

            Next
        Catch ex As Exception
        End Try

        Try
            Dim controls3 As SplitContainer.ControlCollection = scrollPanel2.Controls

            For j = 0 To controls3.Count - 1
                If (controls3(j).Name.IndexOf("pctColorDetail") <> -1 And controls3(j).Name.IndexOf("hidden") = -1) Or ((controls3(j).Name.IndexOf("txt") <> -1 And controls3(j).Name.IndexOf("hidden") = -1 And controls3(j).Name <> txtTotalPrice.Name And controls3(j).Name <> txtTotalQty.Name) Or controls3(j).Name = "butValidate" Or (controls3(j).Name.IndexOf("butDeleteColor") <> -1 Or controls3(j).Name.IndexOf("butAddColor") <> -1)) Then
                    controls3(j).Dispose()
                    j = 0
                End If

            Next
        Catch ex As Exception
        End Try

        Try
            Dim controls3 As SplitContainer.ControlCollection = scrollPanel2.Controls

            For j = 0 To controls3.Count - 1
                If (controls3(j).Name.IndexOf("lbPlus") <> -1 And controls3(j).Name.IndexOf("hidden") = -1) Then
                    controls3(j).Dispose()
                    j = 0
                End If

            Next
        Catch ex As Exception
        End Try


        Try
            Dim controls4 As GroupBox.ControlCollection = panColors.Controls

            Dim j As Integer

            For j = 0 To controls4.Count - 1
                If (controls4(j).Name.IndexOf("pctColorDetail") <> -1 And controls4(j).Name.IndexOf("hidden") = -1) Or ((controls4(j).Name.IndexOf("txt") <> -1 And controls4(j).Name.IndexOf("hidden") = -1 And controls4(j).Name <> txtTotalPrice.Name And controls4(j).Name <> txtTotalQty.Name) Or controls4(j).Name = "butValidate") Then
                    controls4(j).Dispose()
                    j = 0
                End If

            Next

        Catch ex As Exception
        End Try


    End Sub

    Private Sub txtColorsQuantity_OnFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim index As Integer = textBox.AccessibleDescription


        'Dim colorCode As String = textBox.Text
        ' Dim bColorTab() As AmazonaColor = getColors(" WHERE UCase(colorCode)='" + SafeSqlLiteral(colorCode).ToUpper + "' ")
        'If Not bColorTab Is Nothing Then
        'If bColorTab.Length > 0 Then
        'lbColorNameDetail.Text = bColorTab(0).name_color
        'End If
        'End If


        Dim userControls As SplitContainer.ControlCollection
        userControls = scrollPanel1.Controls
        Dim j As Integer

        For j = 0 To userControls.Count - 1
            If userControls(j).Name = ("txtColorsDetail" & index) Or userControls(j).Name = ("txtQuantityDetail" & index) Then
                userControls(j).BackColor = Drawing.Color.Turquoise
            Else
                If userControls(j).Name.IndexOf("txtColorsDetail") > -1 Or userControls(j).Name.IndexOf("txtQuantityDetail") > -1 Then
                    userControls(j).BackColor = Drawing.Color.White
                End If
            End If

        Next

        userControls = scrollPanel2.Controls
        For j = 0 To userControls.Count - 1
            If userControls(j).Name = ("txtColorsDetail" & index) Or userControls(j).Name = ("txtQuantityDetail" & index) Then
                userControls(j).BackColor = Drawing.Color.Turquoise
            Else
                If userControls(j).Name.IndexOf("txtColorsDetail") > -1 Or userControls(j).Name.IndexOf("txtQuantityDetail") > -1 Then
                    userControls(j).BackColor = Drawing.Color.White
                End If
            End If

        Next

        If textBox.Name.IndexOf("txtColorsDetail") <> -1 Then
            scrollPanel2.VerticalScroll.Value = scrollPanel1.VerticalScroll.Value
        Else
            scrollPanel1.VerticalScroll.Value = scrollPanel2.VerticalScroll.Value
        End If


    End Sub

    Private Sub butDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim but As Button = CType(sender, Button)
        Dim id_formulaColor As Integer = but.AccessibleDescription
        deleteColorToFormula(id_formulaColor)
    End Sub


    Private Sub deleteColorToFormula(ByVal id_formulaColor As Integer)
        If MsgBox("Are you sure of this action", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim MyArray As New ArrayList
            Dim i As Integer
            For i = 0 To selectedFormulaColors.Length - 1
                If (selectedFormulaColors(i).id_formulaColor <> id_formulaColor) Then
                    MyArray.Add(selectedFormulaColors(i))

                End If
            Next

            selectedFormulaColors = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
            setTextBoxWidth()
            fromDelete = True
            generatesDetail()
            rdNormal.Select()
            doRdNormalCheckChange()

        End If
    End Sub
    Public fromDelete As Boolean = False
    Private Sub addColorToFormula()
        Dim id_formula As Long
        id_formula = lbFormulaId.Text

        If Not selectedFormulaColors Is Nothing Then
            fromAddFormula = False
            setTextBoxWidth()
            assignColorByCode.ShowDialog()
        End If
    End Sub
    Private Sub addColorToFormula_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        addColorToFormula()
    End Sub


    Private Sub txtColorsQuantity_keyStroke(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        'keypress on delete
        Dim deleteAction As Boolean = False
        If rdCorrection.Checked Then
            If (e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.Delete) And e.Control = True Then
                deleteAction = True
            End If
        Else
            If e.KeyCode = 46 Then
                deleteAction = True
            End If
        End If
        If deleteAction Then
            Dim txt As TextBox = CType(sender, TextBox)
            'txt.Text = "00000000"
            Dim id_formulaColor As Integer = selectedFormulaColors(txt.AccessibleDescription).id_formulaColor
            deleteColorToFormula(id_formulaColor)
            Exit Sub
        End If


        'keypress on + or =
        If e.KeyCode = 187 Or e.KeyCode = 107 Then
            addColorToFormula()

            Exit Sub
        End If

        Dim textBox As TextBox = CType(sender, TextBox)
        Dim index As Integer = textBox.AccessibleDescription

        Dim action As String = ""

        'generate the correction values
        If rdCorrection.Checked And e.KeyCode = Keys.Enter Then
            Try
                Dim txtChanged As TextBox = CType(Controls.Find("txtQuantityDetail" & (index), True)(0), TextBox)
                Dim newVal As Double = txtChanged.Text
                Dim oldVal As Double = selectedFormulaColors(index).quantite * ratio
                Dim diffVal As Double = newVal - oldVal
                Dim percentage = (diffVal / oldVal) * 100
                'txtTotalQty.Text = Math.Round(txtTotalQty.Text + (txtTotalQty.Text * percentage / 100), 1)

                Dim i As Integer
                For i = 0 To selectedFormulaColors.Length - 1
                    Dim lbPlus As Windows.Forms.Label = CType(Controls.Find("lbPlus" & (i), True)(0), Windows.Forms.Label)
                    Dim txtQty As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)

                    If i <> index Then
                        Dim oldVali As Double = txtQty.Text
                        Dim newVali As Double = oldVali + (oldVali * percentage / 100)
                        txtQty.Text = Math.Round(newVali, 1).ToString.Replace(",", ".")
                        Dim diff As Double = newVali - oldVali
                        Dim plus As String = "+"
                        If diff < 0 Then
                            plus = "-"
                            lbPlus.Text = plus & (-1) * Math.Round(diff, 1).ToString.Replace(",", ".")
                        Else
                            lbPlus.Text = plus & Math.Round(diff, 1).ToString.Replace(",", ".")
                        End If

                        If i > index Then
                            lbPlus.Visible = False
                        Else
                            lbPlus.Visible = True
                            If txtQty.Width > lbPlus.Width Then
                                txtQty.Width = txtQty.Width - 50
                                lbPlus.Left = lbPlus.Left - 50
                            End If

                        End If
                    Else
                        lbPlus.Text = ""
                    End If
                    'selectedFormulaColors(i).quantite = txtQty.Text

                Next
                'ratio = ratio + percentage / 100

                Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If


        If e.KeyCode = 40 Then
            action = "down"
        Else
            If e.KeyCode = 38 Then
                action = "up"
            End If
        End If
        If action = "up" Then
            Try
                Dim textBoxNext As TextBox
                If textBox.Name.IndexOf("txtColorsDetail") <> -1 Then
                    textBoxNext = CType(Controls.Find("txtColorsDetail" & (index - 1), True)(0), TextBox)
                Else
                    textBoxNext = CType(Controls.Find("txtQuantityDetail" & (index - 1), True)(0), TextBox)
                End If
                textBoxNext.Focus()
                textBoxNext.SelectAll()
            Catch ex As Exception

            End Try
        End If
        If action = "down" Then
            Try
                Dim textBoxNext As TextBox
                If textBox.Name.IndexOf("txtColorsDetail") <> -1 Then
                    textBoxNext = CType(Controls.Find("txtColorsDetail" & (index + 1), True)(0), TextBox)
                Else
                    textBoxNext = CType(Controls.Find("txtQuantityDetail" & (index + 1), True)(0), TextBox)
                End If
                textBoxNext.Focus()
                textBoxNext.SelectAll()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub generatesDetail(Optional ByVal startWithLitre As Boolean = False, Optional ByVal id_formulaComposed As Integer = -1, Optional ByVal oldDbComposed As String = Nothing, Optional ByVal isBumper As Boolean = False)
        Dim fromDeleteLocal As Boolean = fromDelete
        fromDelete = False
        myConsoleLog.WriteLine("start=" & Now.TimeOfDay.ToString)
        isBumperEdit = isBumper
        disposeHiddenTextBoxes()
        Dim newFontColors As Font = New Font(txtColorsDetailHidden.Font.FontFamily, getFontSize(0))
        txtQuantityDetailHidden.Font = newFontColors
        txtColorsDetailHidden.Font = newFontColors
        pctColorDetailHidden.Size = New Size(pctColorDetailHidden.Width, getFontSize(1))

        'test if it's a client formula
        Dim clientTable As Boolean = False


        If Not garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text Is Nothing Then
            If garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text <> "" Then
                clientTable = True
            End If
        End If
        '

        Dim cumulative As Boolean = False
        Dim correction As Boolean = False
        If rdCumulative.Checked And Not selectNormal Then
            cumulative = True
        End If
        If rdCorrection.Checked And Not selectNormal Then
            correction = True
        End If
        ' Dim indexSelected = garageHome.lsvFamily.SelectedItems(0).Index

        If garageHome.lsvFamily.SelectedItems.Count = 0 Then
            Exit Sub
        End If


        Dim idFormula As Integer
        If id_formulaComposed = -1 And id_formulaComposedGlobal = -1 Then
            idFormula = garageHome.lsvFamily.SelectedItems(0).SubItems(0).Text
        Else
            If id_formulaComposed <> -1 Then
                idFormula = id_formulaComposed
                id_formulaComposedGlobal = id_formulaComposed
            Else
                idFormula = id_formulaComposedGlobal
            End If
        End If



        Dim oldDb As Boolean
        If oldDbComposed = "" And oldDbComposedGlobal = "" Then
            oldDb = garageHome.lsvFamily.SelectedItems(0).SubItems(1).Text
        Else
            If oldDbComposed <> "" Then
                oldDb = oldDbComposed
                oldDbComposedGlobal = oldDbComposed
            Else
                oldDb = oldDbComposedGlobal
            End If

        End If


        Me.AccessibleDescription = oldDb
        Dim selectedFormula As Formula
        selectedFormula = getFormulaById(idFormula, oldDb, clientTable, chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
        myConsoleLog.WriteLine("after get formula:" & Now.TimeOfDay.ToString)
        If Not formulaDup Is Nothing Then
            idFormula = formulaDup.id_formula
            selectedFormula = formulaDup
        End If
        lbAsteriks.Visible = Not selectedFormula.modified_once
        If selectedFormulaColors Is Nothing Then
            Dim couche As Boolean = isCouche(selectedFormula.name_formula)

            If selectedFormula.clientName Is Nothing Then
                selectedFormulaColors = getFormulaColorsByIdFormula(idFormula, selectedFormula.type, chosenCar.tableName, couche, selectedFormula.isEquation4201_180)
            Else
                If selectedFormula.clientName.Trim = "" Then
                    selectedFormulaColors = getFormulaColorsByIdFormula(idFormula, selectedFormula.type, chosenCar.tableName, couche, selectedFormula.isEquation4201_180)
                Else
                    selectedFormulaColors = getFormulaColorsByIdFormulaClient(idFormula)
                End If
            End If
        End If
        If selectedFormulaColors Is Nothing Then
            formulaCorrupted = True
            Exit Sub
        End If
        myConsoleLog.WriteLine("after get colors:" & Now.TimeOfDay.ToString)
        Dim totalPrice As Double = 0
        Dim totalQty As Double = 0
        panColors.AutoScroll = False
        scrollPanel2.AutoScroll = False
        Dim i As Integer


        For i = 0 To selectedFormulaColors.Length - 1
            Dim color As AmazonaColor = getColorById(selectedFormulaColors(i).id_color)

            Dim dbQuantity As Double = selectedFormulaColors(i).quantite
            'convert to kilo
            Dim quantity As Double = 0

            'If getUnit(selectedFormulaColors(i).id_Unit).code_unit.Trim.ToUpper = "L" Then
            'convert to kilo
            'quantity = dbQuantity * color.masse_volumique
            'Else
            quantity = dbQuantity
            'End If
            printStringByLine("dbQuantity of " & color.id_color & " : " & dbQuantity)

            Dim unitUsed As Integer
            Dim currencyUsed As Integer
            Dim priceUsed As Double
            ' Dim id_unit_onEntry As Integer
            Dim detColor As GaragePrice = getGaragePriceDetail(color.id_color)
            If detColor Is Nothing Then
                unitUsed = color.id_defaultUnit
                currencyUsed = color.id_defaultCurreny
                priceUsed = color.defaultPrice
            Else
                unitUsed = detColor.id_unit
                currencyUsed = detColor.id_currency
                priceUsed = detColor.garage_price
            End If

            Dim curColorPrice As Double
            If chosenGarage.apply_equation Then
                If color.masse_volumique_ext > 0 Then
                    curColorPrice = (quantity * priceUsed) / (color.masse_volumique_ext)
                Else
                    curColorPrice = 0
                End If

            Else
                If color.masse_volumique > 0 Then
                    curColorPrice = (quantity * priceUsed) / (color.masse_volumique)
                Else
                    curColorPrice = 0
                End If

            End If


            curColorPrice = convertToChosenCurrency(curColorPrice, getCurrency(currencyUsed).rateToDollar)

            totalPrice = totalPrice + curColorPrice
            totalQty = totalQty + quantity

            'color name 
            Dim txtColorsDetail As New TextBox

            txtColorsDetail.Name = "txtColorsDetail" & i
            txtColorsDetail.AccessibleDescription = i
            txtColorsDetail.ReadOnly = True
            txtColorsDetail.Visible = True
            txtColorsDetail.Top = txtColorsDetailHidden.Top + i * txtColorsDetailHidden.Height
            txtColorsDetail.Left = txtColorsDetailHidden.Left
            If clrWidth = -1 Then
                txtColorsDetail.Width = txtColorsDetailHidden.Width
            Else
                txtColorsDetail.Width = clrWidth
            End If
            txtColorsDetail.Height = txtColorsDetailHidden.Height
            txtColorsDetail.Text = color.name_color
            txtColorsDetail.Anchor = txtColorsDetailHidden.Anchor
            txtColorsDetail.Font = txtColorsDetailHidden.Font
            txtColorsDetail.BackColor = Drawing.Color.White
            AddHandler txtColorsDetail.GotFocus, AddressOf txtColorsQuantity_OnFocus
            AddHandler txtColorsDetail.KeyUp, AddressOf txtColorsQuantity_keyStroke
            scrollPanel1.Controls.Add(txtColorsDetail)

            'quantity 
            If fromDeleteLocal Then
                Try
                    For Each ctrl As Control In Me.Controls.Find("txtQuantityDetail" & i, True)
                        ctrl.Dispose()
                    Next
                Catch ex As Exception

                End Try

            End If
            Dim txtQuantityDetail As New TextBox
            txtQuantityDetail.Name = "txtQuantityDetail" & i
            txtQuantityDetail.AccessibleDescription = i
            If correction = False Then
                txtQuantityDetail.ReadOnly = True
            Else
                txtQuantityDetail.ReadOnly = False
            End If
            txtQuantityDetail.Visible = True
            txtQuantityDetail.Top = txtQuantityDetailHidden.Top + i * txtQuantityDetailHidden.Height
            txtQuantityDetail.Left = txtQuantityDetailHidden.Left
            If qtyWidth = -1 Then
                txtQuantityDetail.Width = txtQuantityDetailHidden.Width
            Else
                txtQuantityDetail.Width = qtyWidth
            End If
            txtQuantityDetail.Height = txtQuantityDetailHidden.Height
            If cumulative Then
                printStringByLine("cumulative of " & color.id_color & " : " & Math.Round(totalQty, 1))
                txtQuantityDetail.Text = Math.Round(totalQty, 1).ToString.Replace(",", ".")
            Else
                printStringByLine("not cumulative of " & color.id_color & " : " & Math.Round(quantity, 1))
                txtQuantityDetail.Text = Math.Round(quantity, 1).ToString.Replace(",", ".")
            End If
            If fromDeleteLocal Then
                txtQuantityDetail.Text = txtQuantityDetail.Text & "delete"
            End If
            txtQuantityDetail.BackColor = Drawing.Color.White
            txtQuantityDetail.Anchor = txtQuantityDetailHidden.Anchor
            txtQuantityDetail.Font = txtQuantityDetailHidden.Font
            AddHandler txtQuantityDetail.KeyUp, AddressOf txtColorsQuantity_keyStroke
            AddHandler txtQuantityDetail.GotFocus, AddressOf txtColorsQuantity_OnFocus
            'AddHandler txtQuantityDetail.KeyUp, AddressOf txtColorsQuantity_KeyUp
            scrollPanel2.Controls.Add(txtQuantityDetail)

            Dim txtQuantityDetaili3 As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
            Dim qty As String = (txtQuantityDetaili3.Text)

            Dim butDeleteColor As New System.Windows.Forms.Button()
            butDeleteColor.AccessibleDescription = selectedFormulaColors(i).id_formulaColor
            butDeleteColor.Name = "butDeleteColor" & i
            butDeleteColor.Visible = False
            butDeleteColor.Enabled = True
            butDeleteColor.Top = txtQuantityDetail.Top
            butDeleteColor.Left = txtQuantityDetail.Left + txtQuantityDetail.Width + 10
            butDeleteColor.Text = "-"
            butDeleteColor.Width = butDeleteHidden.Width
            butDeleteColor.Height = butDeleteHidden.Height
            butDeleteColor.Anchor = butDeleteHidden.Anchor
            butDeleteColor.BringToFront()
            AddHandler butDeleteColor.Click, AddressOf butDelete_Click
            scrollPanel2.Controls.Add(butDeleteColor)



            If correction Then
                Dim lbplus As New Windows.Forms.Label
                lbplus.Name = "lbPlus" & i
                lbplus.Visible = True
                lbplus.Top = lbplushidden.Top + i * txtQuantityDetailHidden.Height
                lbplus.Left = txtQuantityDetailHidden.Left + txtQuantityDetailHidden.Width
                lbplus.Text = ""
                lbplus.Anchor = lbplushidden.Anchor
                scrollPanel2.Controls.Add(lbplus)

            End If
            '
            Dim pctColorDetail As New PictureBox
            pctColorDetail.Name = "pctColorDetail" & i
            pctColorDetail.AccessibleDescription = i
            pctColorDetail.Visible = True
            pctColorDetail.Top = pctColorDetailHidden.Top + i * pctColorDetailHidden.Height
            pctColorDetail.Left = pctColorDetailHidden.Left
            pctColorDetail.Width = pctColorDetailHidden.Width
            pctColorDetail.Height = pctColorDetailHidden.Height

            Dim imgPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//images//" & color.colorImgPath
            Try

                pctColorDetail.BackgroundImage = Image.FromFile(imgPath)
                pctColorDetail.BackgroundImageLayout = pctColorDetailHidden.BackgroundImageLayout
            Catch ex As Exception

            End Try

            pctColorDetail.Anchor = pctColorDetailHidden.Anchor

            scrollPanel1.Controls.Add(pctColorDetail)
            txtColorsDetail.BringToFront()


            'id
            Dim lbIdFormulaColor As New Windows.Forms.Label
            lbIdFormulaColor.Name = "lbIdFormulaColor" & i
            lbIdFormulaColor.Visible = False
            lbIdFormulaColor.Top = txtQuantityDetail.Top
            lbIdFormulaColor.Left = txtQuantityDetail.Left + 100
            lbIdFormulaColor.Text = selectedFormulaColors(i).id_formulaColor
            lbIdFormulaColor.Anchor = txtQuantityDetail.Anchor
            scrollPanel1.Controls.Add(lbIdFormulaColor)

        Next

        myConsoleLog.WriteLine("after boucle:" & Now.TimeOfDay.ToString)
        Dim butAddColor As New System.Windows.Forms.Button()
        butAddColor.Name = "butAddColor"
        butAddColor.Visible = False
        butAddColor.Enabled = True

        butAddColor.Top = butAddHidden.Top
        butAddColor.Left = butAddHidden.Left


        butAddColor.Text = "+"
        butAddColor.Width = butAddHidden.Width
        butAddColor.Height = butAddHidden.Height
        butAddColor.Anchor = butAddHidden.Anchor
        butAddColor.BringToFront()
        AddHandler butAddColor.Click, AddressOf addColorToFormula

        spltColorDetail.Panel1.Controls.Add(butAddColor)


        panColors.AutoScroll = True
        scrollPanel2.AutoScroll = True
        lbFormulaId.Text = selectedFormula.id_formula

        pctFormulaColor.BackColor = System.Drawing.Color.FromArgb(selectedFormula.colorRGB)

        If Not selectedFormula.dateCreMod Is Nothing Then
            'txtModDate.Text = selectedFormula.dateCreMod.ToShortDateString ' & " " & selectedFormula.dateCreMod.ToShortTimeString
            ' Dim dayStr As String = ""
            ' If selectedFormula.dateCreMod.day < 10 Then
            'dayStr = "0" & selectedFormula.dateCreMod.day
            'Else
            '   dayStr = selectedFormula.dateCreMod.day
            'End If

            'Dim monthStr As String = ""
            'If selectedFormula.dateCreMod.month < 10 Then
            'monthStr = "0" & selectedFormula.dateCreMod.month
            ' Else
            '   monthStr = selectedFormula.dateCreMod.month
            'End If
            'txtModDate.Text = dayStr & "/" & monthStr & "/" & selectedFormula.dateCreMod.year

            txtModDate.Text = selectedFormula.dateCreMod.day & "/" & selectedFormula.dateCreMod.month & "/" & selectedFormula.dateCreMod.year
        Else

            txtModDate.Text = ""
        End If

        txtYear.Text = selectedFormula.c_year
        txtFormulaCode.Text = selectedFormula.colorCode
        txtCardNumber.Text = selectedFormula.cardNumber
        txtFname.Text = selectedFormula.name_formula
        txtHue.Text = selectedFormula.version

        ' If selectedFormulaColors.Length > 0 Then
        'Dim idCar As Long = garageHome.lbCarIdSearch.Text
        Dim formulaVariant As String = getFormulaById(lbFormulaId.Text, oldDb, clientTable, chosenCar.tableName, chosenCar.carName, chosenCar.id_car).formulaVariant
        'chkVariantD.Checked = False
        'chkVariantF.Checked = False
        'chkVariantDRT.Checked = False
        'chkVariantL.Checked = False
        'chkVariantR.Checked = False
        'chkVariantY.Checked = False
        'chkVariantB.Checked = False
        'chkVariantCO.Checked = False
        'chkVariantG.Checked = False
        'chkVariantCL.Checked = False
        'RemoveHandler chkVariantCO.Paint, AddressOf drawRectangle


        If Not formulaVariant Is Nothing Then
            If formulaVariant.Trim <> "" Then
                setChkBackColor()
                setVariantsMouseHover()
                Dim formulaVariants() As String = formulaVariant.Split("+")
                Dim j As Integer
                Dim founds(formulaVariants.Length) As String
                For j = 0 To formulaVariants.Length - 1
                    If formulaVariants(j) = "D" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantD.Width = chkVariantD.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantD2"
                            .BackgroundImage = chkVariantD.BackgroundImage
                            .BackgroundImageLayout = chkVariantD.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantD.Location.X + chkVariantD.Width + 1, chkVariantD.Location.Y)
                            .Size = chkVariantD.Size
                            .SizeMode = chkVariantD.SizeMode
                            .BorderStyle = chkVariantD.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)

                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantD))
                    Else
                        If formulaVariants(j) = "D" Then
                            chkVariantD.Visible = True
                        End If
                    End If


                    If formulaVariants(j) = "F" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantF.Width = chkVariantF.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantF2"
                            .BackgroundImage = chkVariantF.BackgroundImage
                            .BackgroundImageLayout = chkVariantF.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantF.Location.X + chkVariantF.Width + 1, chkVariantF.Location.Y)
                            .Size = chkVariantF.Size
                            .SizeMode = chkVariantF.SizeMode
                            .BorderStyle = chkVariantF.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantF))
                    Else
                        If formulaVariants(j) = "F" Then
                            chkVariantF.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "DRT" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantDRT.Width = chkVariantDRT.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantDRT2"
                            .BackgroundImage = chkVariantDRT.BackgroundImage
                            .BackgroundImageLayout = chkVariantDRT.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantDRT.Location.X + chkVariantDRT.Width + 1, chkVariantDRT.Location.Y)
                            .Size = chkVariantDRT.Size
                            .SizeMode = chkVariantDRT.SizeMode
                            .BorderStyle = chkVariantDRT.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantDRT))
                    Else
                        If formulaVariants(j) = "DRT" Then
                            chkVariantDRT.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "L" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantL.Width = chkVariantL.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantL2"
                            .BackgroundImage = chkVariantL.BackgroundImage
                            .BackgroundImageLayout = chkVariantL.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantL.Location.X + chkVariantL.Width + 1, chkVariantL.Location.Y)
                            .Size = chkVariantL.Size
                            .SizeMode = chkVariantL.SizeMode
                            .BorderStyle = chkVariantL.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantL))
                    Else
                        If formulaVariants(j) = "L" Then
                            chkVariantL.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "R" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantR.Width = chkVariantR.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantR2"
                            .BackgroundImage = chkVariantR.BackgroundImage
                            .BackgroundImageLayout = chkVariantR.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantR.Location.X + chkVariantR.Width + 1, chkVariantR.Location.Y)
                            .Size = chkVariantR.Size
                            .SizeMode = chkVariantR.SizeMode
                            .BorderStyle = chkVariantR.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantR))

                    Else
                        If formulaVariants(j) = "R" Then
                            chkVariantR.Visible = True
                        End If
                    End If


                    If formulaVariants(j) = "Y" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantY.Width = chkVariantY.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantY2"
                            .BackgroundImage = chkVariantY.BackgroundImage
                            .BackgroundImageLayout = chkVariantY.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantY.Location.X + chkVariantY.Width + 1, chkVariantY.Location.Y)
                            .Size = chkVariantY.Size
                            .SizeMode = chkVariantY.SizeMode
                            .BorderStyle = chkVariantY.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantY))
                    Else
                        If formulaVariants(j) = "Y" Then
                            chkVariantY.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "B" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantB.Width = chkVariantB.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantB2"
                            .BackgroundImage = chkVariantB.BackgroundImage
                            .BackgroundImageLayout = chkVariantB.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantB.Location.X + chkVariantB.Width + 1, chkVariantB.Location.Y)
                            .Size = chkVariantB.Size
                            .SizeMode = chkVariantB.SizeMode
                            .BorderStyle = chkVariantB.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantB))
                    Else
                        If formulaVariants(j) = "B" Then
                            chkVariantB.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "CO" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantCO.Width = chkVariantCO.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantCO2"
                            .BackgroundImage = chkVariantCO.BackgroundImage
                            .BackgroundImageLayout = chkVariantCO.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantCO.Location.X + chkVariantCO.Width + 1, chkVariantCO.Location.Y)
                            .Size = chkVariantCO.Size
                            .SizeMode = chkVariantCO.SizeMode
                            .BorderStyle = chkVariantCO.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantCO))

                    Else
                        If formulaVariants(j) = "CO" Then
                            chkVariantCO.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "G" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantG.Width = chkVariantG.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantG2"
                            .BackgroundImage = chkVariantG.BackgroundImage
                            .BackgroundImageLayout = chkVariantG.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantG.Location.X + chkVariantG.Width + 1, chkVariantG.Location.Y)
                            .Size = chkVariantG.Size
                            .SizeMode = chkVariantG.SizeMode
                            .BorderStyle = chkVariantG.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantG))
                    Else
                        If formulaVariants(j) = "G" Then
                            chkVariantG.Visible = True
                        End If
                    End If

                    If formulaVariants(j) = "CL" And existInFounds(formulaVariants(j), founds) Then
                        chkVariantCL.Width = chkVariantCL.Width / 2 - 1
                        Dim PB As New PictureBox
                        With PB
                            .Name = "chkVariantCL2"
                            .BackgroundImage = chkVariantCL.BackgroundImage
                            .BackgroundImageLayout = chkVariantCL.BackgroundImageLayout
                            .Location = New System.Drawing.Point(chkVariantCL.Location.X + chkVariantCL.Width + 1, chkVariantCL.Location.Y)
                            .Size = chkVariantCL.Size
                            .SizeMode = chkVariantCL.SizeMode
                            .BorderStyle = chkVariantCL.BorderStyle
                            '  Note you can set more of the PicBox's Properties here
                        End With
                        MyGroupBox1.Controls.Add(PB)
                        Me.ToolTipVariant.SetToolTip(PB, Me.ToolTipVariant.GetToolTip(chkVariantCL))
                    Else
                        If formulaVariants(j) = "CL" Then
                            chkVariantCL.Visible = True
                        End If
                    End If

                    founds(j) = formulaVariants(j)
                Next
            End If
        End If

        Dim butValidate As New System.Windows.Forms.Button()

        butValidate.Name = "butValidate"
        butValidate.Visible = True
        butValidate.Enabled = True
        butValidate.Top = butValidateHidden.Top
        butValidate.Left = butValidateHidden.Left
        butValidate.Text = butValidateHidden.Text
        butValidate.Font = butValidateHidden.Font
        butValidate.Width = butValidateHidden.Width
        butValidate.Height = butValidateHidden.Height
        butValidate.Anchor = butValidateHidden.Anchor
        butValidate.BringToFront()



        AddHandler butValidate.Click, AddressOf saveTransaction
        panButtons.Controls.Add(butValidate)
        'totalPrice = totalPrice / 1000
        txtTotalPrice.Text = Math.Round(totalPrice, 1).ToString.Replace(",", ".")

        txtTotalQty.Text = 1 'Math.Round(totalQty, 1)


        'Dim idCar As Long = garageHome.lbCarIdSearch.Text
        Dim car As Car = chosenCar



        txtCarDetails.Text = car.carName
        Dim imgPath2 As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//images//" & car.carImgPath
        Try
            imageToPreview = Image.FromFile(imgPath2)
            pctCarImg.ImageLocation = imgPath2

        Catch ex As Exception

        End Try
        Me.Text = selectedFormula.name_formula

        If startWithLitre Then
            convertToLitre()
        End If

        myConsoleLog.WriteLine("generate details end=" & Now.TimeOfDay.ToString)

    End Sub

    Private Function existInFounds(ByVal formulaVariant As String, ByVal founds() As String) As Boolean
        Dim y As Integer
        For y = 0 To founds.Length - 1
            If founds(y) = formulaVariant Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub pctCarImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctCarImg.Click
        If Not imageToPreview Is Nothing And Not pctCarImg.ImageLocation Is Nothing Then
            imagePreview.ShowDialog()
        End If
    End Sub
    Private Sub pctCarImg_mouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctCarImg.MouseHover
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub
    Private Sub pctCarImg_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctCarImg.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub butFontAug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFontAug.Click, butFontDim.Click

        Dim controlsTab() As SplitContainer.ControlCollection
        ReDim controlsTab(1)
        controlsTab(0) = scrollPanel1.Controls
        controlsTab(1) = scrollPanel2.Controls

        Dim exist As Boolean = False
        Dim k As Integer
        For k = 0 To controlsTab.Length - 1
            Dim spltControls As SplitContainer.ControlCollection = controlsTab(k)

            Dim j As Integer

            For j = 0 To spltControls.Count - 1
                If spltControls(j).Name.IndexOf("txtColorsDetail0") <> -1 Then
                    exist = True
                    Exit For
                End If

            Next
        Next

        If exist Then
            Dim val As Integer
            Dim button As Button = CType(sender, Button)
            If button.Name = "butFontAug" Then
                val = 3
            Else
                val = -3
            End If
            Dim newFontSize As Integer
            Dim newPctHeight As Integer
            If txtColorsDetailHidden.Font.Size + val > 0 Then
                Dim newFontColors As Font = New Font(txtColorsDetailHidden.Font.FontFamily, txtColorsDetailHidden.Font.Size + val)
                txtColorsDetailHidden.Font = newFontColors
                newFontSize = newFontColors.Size
            End If

            If txtQuantityDetailHidden.Font.Size + val > 0 Then
                Dim newFontQty As Font = New Font(txtQuantityDetailHidden.Font.FontFamily, txtQuantityDetailHidden.Font.Size + val)
                txtQuantityDetailHidden.Font = newFontQty
                newFontSize = newFontQty.Size
            End If

            If lbplushidden.Font.Size + val > 0 Then
                Dim newFontCorr As Font = New Font(lbplushidden.Font.FontFamily, lbplushidden.Font.Size + val)
                lbplushidden.Font = newFontCorr
                'newFontSize = newFontCorr.Size
            End If

            If pctColorDetailHidden.Size.Height + val > 0 Then
                newPctHeight = txtQuantityDetailHidden.Size.Height
                Dim newSize As New Size(pctColorDetailHidden.Width, newPctHeight)
                pctColorDetailHidden.Size = newSize
            End If


            insertNewFontSize(newFontSize, newPctHeight)


            Dim i As Integer
            For i = 0 To selectedFormulaColors.Length - 1
                Dim pctColorDetail As PictureBox = CType(Controls.Find("pctColorDetail" & (i), True)(0), PictureBox)
                Dim newSize As New Size(pctColorDetailHidden.Width, newPctHeight)
                pctColorDetail.Size = newSize
                pctColorDetail.Top = pctColorDetailHidden.Top + i * pctColorDetailHidden.Height
                pctColorDetail.Left = pctColorDetailHidden.Left

                Dim txtColorsDetail As TextBox = CType(Controls.Find("txtColorsDetail" & (i), True)(0), TextBox)
                Dim newFontColors As Font = New Font(txtColorsDetailHidden.Font.FontFamily, newFontSize)
                txtColorsDetail.Font = newFontColors
                txtColorsDetail.Top = txtColorsDetailHidden.Top + i * txtColorsDetailHidden.Height
                txtColorsDetail.Left = txtColorsDetailHidden.Left

                Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
                txtQuantityDetail.Font = newFontColors
                txtQuantityDetail.Top = txtQuantityDetailHidden.Top + i * txtQuantityDetailHidden.Height
                txtQuantityDetail.Left = txtQuantityDetailHidden.Left

                Dim butDeleteColor As Button = CType(Controls.Find("butDeleteColor" & (i), True)(0), Button)
                butDeleteColor.Top = txtQuantityDetail.Top

                If rdCorrection.Checked Then
                    Dim lbplus As Windows.Forms.Label = CType(Controls.Find("lbplus" & (i), True)(0), Windows.Forms.Label)
                    lbplus.Top = txtQuantityDetail.Top
                    lbplus.Left = txtQuantityDetail.Left + txtQuantityDetail.Width
                End If

            Next

        End If

    End Sub

    Private Sub saveTransaction(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not selectedFormulaColors Is Nothing Then

            Dim clientName As String = ""
            clientName = InputBox("Please enter the client name", "Transaction", "")
            If clientName Is Nothing Then
                Exit Sub
            End If
            If clientName = "" Then
                Exit Sub
            End If

            Dim originalformulaPrice As Double = Double.Parse(txtTotalPrice.Text.Replace(",", "."), ciClone)
            'Dim diff As Double = originalformulaPrice - formulaPrice
            'Dim discount As Double = (diff * 100) / originalformulaPrice

            Dim formulaId As Integer = lbFormulaId.Text

            If addTransaction(formulaId, Now.Date, 0, originalformulaPrice, chosenCurrency.id_currency, clientName) Then
                MsgBox("Your Transaction has been saved", MsgBoxStyle.Information, "Information")
                disposeHiddenTextBoxes()
                'curFamily = Nothing
                'curSubFamily = Nothing
                'Dim formulaNameChosen As String = lsvFormula.SelectedItems(0).SubItems(0).Text

                'garageHome.lbSelectedFormulavalue.Text = ""
                'garageHome.lsvFamily.Items.Clear()
                'garageHome.loadGarageHome()
                Me.Close()
            Else
                MsgBox("Error transaction not saved", MsgBoxStyle.Information, "Information")
            End If

        End If
    End Sub

    Public Sub InitQuantitiesWithAllDecimals()
        ReDim quantitiesWithAllDecimals(selectedFormulaColors.Length)
        For i = 0 To selectedFormulaColors.Length - 1
            Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
            quantitiesWithAllDecimals(i) = Double.Parse(txtQuantityDetail.Text.Replace(",", "."), ciClone)
        Next

    End Sub

    Public Sub InitQuantitiesWithAllDecimalsCum()
        ReDim quantitiesWithAllDecimalsCum(selectedFormulaColors.Length)
        For i = 0 To selectedFormulaColors.Length - 1
            Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
            quantitiesWithAllDecimalsCum(i) = Double.Parse(txtQuantityDetail.Text.Replace(",", "."), ciClone)
        Next

    End Sub

    Private Sub setValueByQuantityChosen()
        If selectNormal Then
            rdNormal.Select()
        End If

        Dim chosenQty As Double = txtTotalQty.Text
        Dim totalPrice As Double = 0
        Dim totalQty As Double = 0
        Dim i As Integer
        If rdCumulative.Checked Then
            If quantitiesWithAllDecimalsCum Is Nothing Then
                InitQuantitiesWithAllDecimalsCum()
            End If
        Else
            If quantitiesWithAllDecimals Is Nothing Then
                InitQuantitiesWithAllDecimals()
            End If
        End If



        Dim defaultTotal As Double = 0
        For i = 0 To selectedFormulaColors.Length - 1
            Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
            txtQuantityDetail.BackColor = Drawing.Color.White
            Dim lbplus As Windows.Forms.Label
            If Controls.Find("lbPlus" & (i), True).Length > 0 Then
                lbplus = CType(Controls.Find("lbPlus" & (i), True)(0), Windows.Forms.Label)
                lbplus.Text = ""
            End If

            Dim quantity As Double

            If Not rdCumulative.Checked Then
                quantity = quantitiesWithAllDecimals(i)
                defaultTotal = defaultTotal + quantity
                totalQty = totalQty + (quantity * chosenQty / prevQty)
            Else
                quantity = quantitiesWithAllDecimalsCum(i)
                If i = selectedFormulaColors.Length - 1 Then
                    defaultTotal = defaultTotal + quantity
                    totalQty = totalQty + (quantity * chosenQty / prevQty)
                End If
            End If

            If i = selectedFormulaColors.Length - 1 And butLitre.Enabled Then
                If Not rdCumulative.Checked Then
                    quantitiesWithAllDecimals(i) = quantity * chosenQty / prevQty
                Else
                    quantitiesWithAllDecimalsCum(i) = quantity * chosenQty / prevQty
                End If

                Dim initNbr As Double = Math.Round(quantity * chosenQty / prevQty, 1)
                txtQuantityDetail.Text = initNbr.ToString.Replace(",", ".")
                'Dim testNbr As Double = Math.Ceiling(initNbr)
                'Dim testStr As String = testNbr
                'If testStr.Substring(testStr.Length - 1) = "1" Then
                'testNbr = Math.Floor(initNbr)
                'End If

                'txtQuantityDetail.Text = testNbr
            Else
                If Not rdCumulative.Checked Then
                    quantitiesWithAllDecimals(i) = quantity * chosenQty / prevQty
                Else
                    quantitiesWithAllDecimalsCum(i) = quantity * chosenQty / prevQty
                End If

                txtQuantityDetail.Text = Math.Round(quantity * chosenQty / prevQty, 1).ToString.Replace(",", ".")
            End If




        Next

        Dim totalPriceDouble As Double = Double.Parse(txtTotalPrice.Text.Replace(",", "."), ciClone)
        Dim totalQtyDouble As Double = Double.Parse(txtTotalQty.Text.Replace(",", "."), ciClone)

        txtTotalPrice.Text = Math.Round(totalPriceDouble * totalQtyDouble / prevQty, 1).ToString.Replace(",", ".")
        prevQty = txtTotalQty.Text
        'rdNormal.Checked = True
        If defaultTotal <> 0 Then

            ratio = ratio * (totalQty / defaultTotal)

        End If
    End Sub

    Private Sub paintRed()

        For i = 0 To selectedFormulaColors.Length - 1
            Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
            txtQuantityDetail.BackColor = Drawing.Color.Red

        Next

    End Sub
    Private Sub txtTotalQty_KeyUp(sender As Object, e As KeyEventArgs) ' Handles txtTotalQty.KeyUp
        If e.KeyCode <> Keys.Enter And e.KeyCode <> Keys.Left And e.KeyCode <> Keys.Right And Not selectedFormulaColors Is Nothing Then
            spltColorDetail.Visible = True

            'control numeric
            If Not IsNumeric(txtTotalQty.Text) Then
                'MessageBox.Show("The quantity must be a numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paintRed()
                Exit Sub
            End If
            If txtTotalQty.Text = 0 Then
                'MsgBox("Quantity cannot be zero", MsgBoxStyle.Exclamation)
                paintRed()
                Exit Sub
            End If


            setValueByQuantityChosen()


            'generatesDetail(formulaDup)
        End If
    End Sub
    Private Function isNumericKeyUp(ByVal e As KeyEventArgs) As Boolean
        isNumericKeyUp = False

        If Char.IsNumber(Convert.ToChar(e.KeyCode)) Then 'for the keys situated under the Function (F1,F2,F3... keys
            isNumericKeyUp = True
        End If

        'for the numpad Keys
        If e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.NumPad4 Then
            isNumericKeyUp = True
        End If
        If e.KeyCode = Keys.NumPad5 Or e.KeyCode = Keys.NumPad6 Or e.KeyCode = Keys.NumPad7 Or e.KeyCode = Keys.NumPad8 Then
            isNumericKeyUp = True
        End If
        If e.KeyCode = Keys.NumPad9 Or e.KeyCode = Keys.NumPad0 Then
            isNumericKeyUp = True
        End If
    End Function

    Private Sub txtTotalQty_keyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles txtTotalQty.KeyPress
        If (Asc(e.KeyChar) = Keys.Enter) And Not selectedFormulaColors Is Nothing Then
            spltColorDetail.Visible = True

            'control numeric
            If Not IsNumeric(txtTotalQty.Text) Then
                'MessageBox.Show("The quantity must be a numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paintRed()
                Exit Sub
            End If
            If txtTotalQty.Text = 0 Then
                'MsgBox("Quantity cannot be zero", MsgBoxStyle.Exclamation)
                paintRed()
                Exit Sub
            End If
            setValueByQuantityChosen()


            'generatesDetail(formulaDup)
        End If
    End Sub

    Private Sub txtTotalQty_TextChanged(sender As Object, e As EventArgs) Handles txtTotalQty.TextChanged
        If Not selectedFormulaColors Is Nothing Then
            spltColorDetail.Visible = True

            'control numeric
            If Not IsNumeric(txtTotalQty.Text) Then
                'MessageBox.Show("The quantity must be a numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paintRed()
                Exit Sub
            End If
            If txtTotalQty.Text = 0 Then
                'MsgBox("Quantity cannot be zero", MsgBoxStyle.Exclamation)
                paintRed()
                Exit Sub
            End If
            setValueByQuantityChosen()


            'generatesDetail(formulaDup)
        End If
        txtTotalQty.Focus()
    End Sub

    Public Sub doRdNormalCheckChange()
        For i = 0 To selectedFormulaColors.Length - 1

            Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
            txtQuantityDetail.ReadOnly = True
            If Controls.Find("lbPlus" & (i), True).Length > 0 Then
                Dim lbplus As Windows.Forms.Label = CType(Controls.Find("lbPlus" & (i), True)(0), Windows.Forms.Label)
                If lbplus.Text <> "" And lbplus.Visible Then
                    txtQuantityDetail.Width = txtQuantityDetail.Width + 50
                    lbplus.Left = lbplus.Left + 50

                End If
            End If


            ' Dim quantity As Double = selectedFormulaColors(i).quantite
            Dim quantity As Double = selectedFormulaColors(i).quantite * txtTotalQty.Text
            'quantity = convertToChosenUnit(quantity, getUnit(selectedFormulaColors(i).id_Unit).rateToLitre)
            'quantity = quantity * txtTotalQty.Text
            If butLitre.Enabled = True Then 'kilo is chosen
                Dim total As Double = 0
                Dim k As Integer
                For k = 0 To selectedFormulaColors.Length - 1
                    total = total + selectedFormulaColors(k).quantite
                Next
                If total > 0 Then
                    kiloLitreRate = 1000 / total
                    quantity = Math.Round(quantity * kiloLitreRate, 1) '* txtTotalQty.Text / prevQty
                Else
                End If
            End If



            txtQuantityDetail.Text = Math.Round(quantity, 1).ToString.Replace(",", ".")


            If Controls.Find("lbPlus" & (i), True).Length > 0 Then
                Dim lbplus As Windows.Forms.Label = Controls.Find("lbPlus" & (i), True)(0)
                lbplus.Text = ""
            End If

        Next
    End Sub

    Private Sub rd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCumulative.CheckedChanged, rdCorrection.CheckedChanged
        Dim rdEvent As RadioButton = CType(sender, RadioButton)

        If rdCorrection.Checked Then
            selectNormal = False
            'normalize first
            For i = 0 To selectedFormulaColors.Length - 1

                Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
                txtQuantityDetail.ReadOnly = True
                Dim quantity As Double = selectedFormulaColors(i).quantite
                'quantity = convertToChosenUnit(quantity, getUnit(selectedFormulaColors(i).id_Unit).rateToLitre)
                quantity = quantity * ratio
                txtQuantityDetail.Text = Math.Round(quantity, 1).ToString.Replace(",", ".")
            Next
            If butKilo.Enabled = False Then
                convertToKilo()
            End If
            For i = 0 To selectedFormulaColors.Length - 1

                Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
                txtQuantityDetail.ReadOnly = False

                If Controls.Find("lbPlus" & (i), True).Length = 0 Then
                    Dim lbplus As New Windows.Forms.Label
                    lbplus.Name = "lbPlus" & i
                    lbplus.Visible = True
                    lbplus.Top = txtQuantityDetail.Top
                    lbplus.Left = txtQuantityDetail.Left + txtQuantityDetail.Width
                    lbplus.Anchor = lbplushidden.Anchor
                    'lbplus.BackColor = Drawing.Color.Beige
                    scrollPanel2.Controls.Add(lbplus)
                End If

            Next
        End If

        If rdNormal.Checked Then
            doRdNormalCheckChange()

        End If

        If rdCumulative.Checked And rdEvent.Name = "rdCumulative" Then
            selectNormal = False
            Dim totalQty As Double = 0
            For i = 0 To selectedFormulaColors.Length - 1

                Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
                txtQuantityDetail.ReadOnly = True
                If Controls.Find("lbPlus" & (i), True).Length > 0 Then
                    Dim lbplus As Windows.Forms.Label = CType(Controls.Find("lbPlus" & (i), True)(0), Windows.Forms.Label)
                    If lbplus.Text <> "" And lbplus.Visible Then
                        txtQuantityDetail.Width = txtQuantityDetail.Width + 50
                        lbplus.Left = lbplus.Left + 50
                    End If
                End If
                ' Dim quantity As Double = selectedFormulaColors(i).quantite
                Dim quantity As Double = Double.Parse(txtQuantityDetail.Text, ciClone)
                'quantity = convertToChosenUnit(quantity, getUnit(selectedFormulaColors(i).id_Unit).rateToLitre)
                'quantity = quantity * txtTotalQty.Text
                totalQty = totalQty + quantity
                If i = selectedFormulaColors.Length - 1 And butLitre.Enabled Then

                    Dim initNbr As Double = Math.Round(totalQty, 1)

                    Dim testNbr As Double = Math.Ceiling(initNbr)
                    Dim testStr As String = testNbr
                    If testStr.Substring(testStr.Length - 1) = "1" Then
                        testNbr = Math.Floor(initNbr)
                    End If

                    txtQuantityDetail.Text = testNbr.ToString.Replace(",", ".")
                Else
                    txtQuantityDetail.Text = Math.Round(totalQty, 1).ToString.Replace(",", ".")
                End If


                If Controls.Find("lbPlus" & (i), True).Length > 0 Then
                    Dim lbplus As Windows.Forms.Label = Controls.Find("lbPlus" & (i), True)(0)
                    lbplus.Text = ""
                End If
            Next
        End If

        'generatesDetail(formulaDup)
    End Sub

    Private Sub butTransactionHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butTransactionHistory.Click
        If lbFormulaId.Text <> "-1" Then
            'test if it's a client formula
            Dim clientTable As Boolean = False
            If Not garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text Is Nothing Then
                If garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text <> "" Then
                    clientTable = True
                End If
            End If
            '
            Dim idCar As Long = garageHome.lbCarIdSearch.Text

            chosenFormula = getFormulaById(lbFormulaId.Text, Me.AccessibleDescription, clientTable, chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
            If Not chosenFormula Is Nothing Then
                Dim transationTab() As Transaction = getTransactionTab(chosenFormula.id_formula)
                TransactionForm.addResultsToListviewTransaction(transationTab)
                TransactionForm.ShowDialog()
            End If
        End If
    End Sub


#Region "print"

    Private Sub butPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click, butPrintDialog.Click
        If lbFormulaId.Text <> "-1" Then
            'test if it's a client formula
            Dim clientTable As Boolean = False
            If Not garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text Is Nothing Then
                If garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text <> "" Then
                    clientTable = True
                End If
            End If
            '
            Dim idCar As Long = garageHome.lbCarIdSearch.Text
            chosenPrintFormula = getFormulaById(lbFormulaId.Text, Me.AccessibleDescription, clientTable, chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
            If Not chosenPrintFormula Is Nothing And Not selectedFormulaColors Is Nothing Then
                Dim clientName As String = ""

                clientName = InputBox("Please enter the client name", "Transaction", "")
                'If clientName Is Nothing Then
                'Exit Sub
                'End If
                'If clientName = "" Then
                'Exit Sub
                'End If
                Dim originalformulaPrice As Double = txtTotalPrice.Text
                'Dim diff As Double = originalformulaPrice - formulaPrice
                'Dim discount As Double = (diff * 100) / originalformulaPrice
                chosenPrintTransaction = New Transaction
                chosenPrintTransaction.discount = 0
                chosenPrintTransaction.amount = originalformulaPrice
                chosenPrintTransaction.transactionDate = Today
                chosenPrintTransaction.id_curreny = chosenCurrency.id_currency
                chosenPrintTransaction.client_name = clientName
                'fmenue = False
                Dim printDoc As PrintDocument
                printDoc = PreparePrintDocument()
                Dim dlgPrintPreview As New CoolPrintPreviewDialog()
                dlgPrintPreview.WindowState = FormWindowState.Maximized
                dlgPrintPreview.Document = printDoc
                dlgPrintDialog.Document = printDoc

                ' Preview.
                'dlgPrintPreview.WindowState = FormWindowState.Maximized
                dlgPrintPreview.ShowDialog()








                '' Make a PrintDocument object.
                'Dim print_document As PrintDocument = PreparePrintDocument()

                '' Print immediately.
                'print_document.Print()

                ' If sender.name = "butPrint" Then
                'dlgPrintPreview.ShowDialog()
                ' Else
                ' dlgPrintDialog.ShowDialog()
                ' End If


            End If
        End If
    End Sub

    Private Function PreparePrintDocument() As PrintDocument
        ' Make the PrintDocument object.
        Dim print_document As New PrintDocument

        ' Install the PrintPage event handler.
        AddHandler print_document.PrintPage, AddressOf Print_PrintPage

        ' Return the object.
        Return print_document
    End Function

    Private Function PreparePrintDocument26072013() As PrintDocument
        ' Make the PrintDocument object.
        Dim print_document As New PrintDocument
        print_document.DefaultPageSettings.Landscape = False
        print_document.DefaultPageSettings.Margins.Left = 0
        print_document.DefaultPageSettings.Margins.Top = 0
        ' print_document.DefaultPageSettings.PaperSize =


        Dim psize As New Printing.PaperSize("sizeA6", 420, 298)
        print_document.DefaultPageSettings.PaperSize = psize

        If Not 1 = 1 Then
            ' The parameter of Item method is any kind of paper size avaliable on the printer
            Dim i As Integer

            'find if A6 exists

            For i = 0 To print_document.PrinterSettings.PaperSizes.Count - 1

                If print_document.PrinterSettings.PaperSizes.Item(i).Kind = PaperKind.A6 Then
                    psize = print_document.PrinterSettings.PaperSizes.Item(i)
                    Exit For
                End If
            Next

            'find if A5 exists
            If psize Is Nothing Then
                For i = 0 To print_document.PrinterSettings.PaperSizes.Count - 1
                    If print_document.PrinterSettings.PaperSizes.Item(i).Kind = PaperKind.A5 Then
                        psize = print_document.PrinterSettings.PaperSizes.Item(i)
                        Exit For
                    End If
                Next
            End If
            'find if A4 exists
            If psize Is Nothing Then
                For i = 0 To print_document.PrinterSettings.PaperSizes.Count - 1
                    If print_document.PrinterSettings.PaperSizes.Item(i).Kind = PaperKind.A4 Then
                        psize = print_document.PrinterSettings.PaperSizes.Item(i)
                        Exit For
                    End If
                Next
            End If
        End If



        ' Install the PrintPage event handler.
        AddHandler print_document.PrintPage, AddressOf Print_PrintPage

        ' Return the object.
        Return print_document
    End Function

    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fnt As New Font("Arial", 10)
        Dim fntBold As New Font("Arial", 10, FontStyle.Bold)
        Dim fntBoldBig As New Font("Arial", 12, FontStyle.Bold)
        Dim fntItalic As New Font("Arial", 10, FontStyle.Italic)
        Dim x As Integer = 0

        Dim y As Integer = -5

        Dim correctionY As Integer = 20 + 35
        y = y + correctionY

        Dim td As Date = Now
        'MsgBox(td)

        Dim std As String = "", z As String = ""
        If Val(td.Month) < 10 Then
            z = "0"
        Else
            z = ""
        End If
        'std = td.Day & "/" & z & td.Month & "/" & td.Year & " - " & TimeString
        'std = td.DayOfWeek & ", " & " - " & TimeString
        std = td.ToString("dddd, MMMM dd, yyyy, HH:mm:ss.ff", CultureInfo.CreateSpecificCulture("en-US"))

        e.Graphics.DrawString(chosenGarage.garage_name, fntBold, Brushes.Black, 50, y + 20)
        If chosenPrintTransaction.client_name.Trim <> "" Then
            e.Graphics.DrawString("Name: " & chosenPrintTransaction.client_name.Trim, fntBold, Brushes.Black, 50, y + 35)
        End If

        e.Graphics.DrawString(std, fntBold, Brushes.Black, 50, y + 50)
        e.Graphics.DrawString(chosenPrintFormula.name_car, fnt, Brushes.Black, 50, y + 70)
        e.Graphics.DrawString(chosenPrintFormula.colorCode, fnt, Brushes.Black, 50, y + 85)
        e.Graphics.DrawString(chosenPrintFormula.version, fnt, Brushes.Black, 50, y + 100)
        Dim mode As String = "Litres"
        If butLitre.Enabled Then
            mode = "Kilos"
        End If
        e.Graphics.DrawString("MODE = " + mode, fnt, Brushes.Black, 250, y + 70)
        e.Graphics.DrawString(chosenPrintFormula.name_formula, fnt, Brushes.Black, 250, y + 85)

        y = y + 10

        e.Graphics.DrawString("WEIGHT = " & txtTotalQty.Text, fntBold, Brushes.Black, 50, y + 125)

        y = y + 10
        Try

            For i = 0 To selectedFormulaColors.Length - 1

                'Dim colorName As String = getColorById(selectedFormulaColors(i).id_color).name_color
                'Dim quantity As String = Math.Round(selectedFormulaColors(i).quantite, 1) ' & " " & getUnit(selectedFormulaColors(i).id_Unit).code_unit

                Dim txtQty As TextBox = CType(Controls.Find("txtQuantityDetail" & i, True)(0), TextBox)
                Dim txtClr As TextBox = CType(Controls.Find("txtColorsDetail" & i, True)(0), TextBox)
                e.Graphics.DrawString(txtClr.Text, fnt, Brushes.Black, 50, y + 140 + i * 22)
                e.Graphics.DrawString(txtQty.Text, fnt, Brushes.Black, 290, y + 140 + i * 22)
            Next
        Catch ex As Exception

        End Try
        'If i > 12 Then
        cont = False
        'End If
        If cont = True Then
            pgnum += 1
            'cont = False
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            start = 0
            pgnum = 1
        End If
    End Sub
    Private Sub Print_PrintPageOrininal(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fnt As New Font("Arial", 10)
        Dim fntBold As New Font("Arial", 10, FontStyle.Bold)
        Dim fntItalic As New Font("Arial", 10, FontStyle.Italic)

        Dim td As Date = Today.ToShortDateString
        'MsgBox(td)

        Dim std As String = "", z As String = ""
        If Val(td.Month) < 10 Then
            z = "0"
        Else
            z = ""
        End If
        'std = td.Day & "/" & z & td.Month & "/" & td.Year & " - " & TimeString
        std = td & " - " & TimeString
        e.Graphics.DrawString(chosenGarage.garage_name & " (" & std & ")", fntBold, Brushes.Black, 110, 20)
        e.Graphics.DrawString("By '" & chosenGarage.name_responsible & "'", fntItalic, Brushes.Black, 110, 40)
        Dim str As String
        str = chosenPrintFormula.name_formula
        str &= " - " & chosenPrintFormula.type
        str &= " - " & chosenPrintFormula.version
        str &= " - " & chosenPrintFormula.duplicate
        str &= " - " & chosenPrintFormula.formulaVariant

        e.Graphics.DrawString("AmazonaColor:", fntBold, Brushes.Black, 10, 80)
        e.Graphics.DrawString(str, fnt, Brushes.Black, 55, 80)


        e.Graphics.DrawString("Client:", fntBold, Brushes.Black, 10, 100)
        e.Graphics.DrawString(chosenPrintTransaction.client_name, fnt, Brushes.Black, 55, 100)


        For i = 0 To selectedFormulaColors.Length - 1
            Dim colorName As String = getColorById(selectedFormulaColors(i).id_color).name_color
            Dim quantity As String = Math.Round(selectedFormulaColors(i).quantite, 1).ToString.Replace(",", ".") ' & " " & getUnit(selectedFormulaColors(i).id_Unit).code_unit

            e.Graphics.DrawString(colorName, fnt, Brushes.Black, 50, 130 + i * 20)
            e.Graphics.DrawString(quantity, fnt, Brushes.Black, 220, 130 + i * 20)
        Next

        'If i > 12 Then
        cont = False
        'End If
        If cont = True Then
            pgnum += 1
            'cont = False
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            start = 0
            pgnum = 1
        End If
    End Sub
    Public Sub alignright(ByVal stri, ByVal a, ByVal j, ByVal e, ByVal fnt1)
        Dim g As Integer, s As String = "", d As Integer
        Dim afpt As String = ""
        afpt = Mid(stri, InStr(stri, ".") + 1)
        If Len(afpt) < 2 Then
            stri = stri & "0"
        End If
        For g = 0 To Len(stri) - 1
            If Not IsNumeric(Mid(stri, Len(stri) - g, 1)) Then
                d = 5
                a = a + d
            End If
            e.Graphics.DrawString(Mid(stri, Len(stri) - g, 1), fnt1, Brushes.Black, a - g * 9.5, j)
        Next
    End Sub

#End Region
    Private Sub spltColorDetailPanel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrollPanel1.Scroll
        'If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
        'scrollPanel2.AutoScroll = False
        scrollPanel2.VerticalScroll.Value = scrollPanel1.VerticalScroll.Value
        'End If
        'scrollPanel2.AutoScroll = True
    End Sub
    Private Sub spltColorDetailPanel1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles scrollPanel1.MouseWheel
        'If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
        'scrollPanel2.AutoScroll = False
        scrollPanel2.VerticalScroll.Value = scrollPanel1.VerticalScroll.Value
        'End If
        'scrollPanel2.AutoScroll = True
    End Sub

    Private Sub spltColorDetailPanel2_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrollPanel2.Scroll

        'If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
        'scrollPanel1.AutoScroll = False
        scrollPanel1.VerticalScroll.Value = scrollPanel2.VerticalScroll.Value
        'End If
        ' scrollPanel1.AutoScroll = True

    End Sub

    Private Sub spltColorDetailPanel2_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles scrollPanel2.MouseWheel
        'If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
        'scrollPanel1.AutoScroll = False
        scrollPanel1.VerticalScroll.Value = scrollPanel2.VerticalScroll.Value
        'End If
        ' scrollPanel1.AutoScroll = True
    End Sub

    Private Sub butSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveNew.Click
        'test if it's a client formula
        Dim clientTable As Boolean = False
        If Not garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text Is Nothing Then
            If garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text <> "" Then
                clientTable = True
            End If
        End If
        '
        ' Dim idCar As Long = garageHome.lbCarIdSearch.Text
        Dim formula As Formula = getFormulaById(lbFormulaId.Text, Me.AccessibleDescription, clientTable, chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
        'Dim clientName As String = InputBox("Please enter the client name")
        Dim clientName As String = cmbClientName.Text

        If clientName Is Nothing Then
            MsgBox("You must choose a client or enter a new client", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            If clientName.Trim = "" Then
                MsgBox("You must choose a client or enter a new client", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        If clientName.Trim = "" Then
            MsgBox("You must choose a client or enter a new client", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        saveClientFormula.txtColorCode.Text = formula.colorCode
        saveClientFormula.txtFName.Text = formula.name_formula
        If formula.c_year.IndexOf(" -") > 0 Then
            saveClientFormula.txtYearMin.Text = formula.c_year.Substring(0, formula.c_year.IndexOf(" -"))
            If formula.c_year.Length >= formula.c_year.IndexOf("- ") + 2 Then
                saveClientFormula.txtYearMax.Text = formula.c_year.Substring(formula.c_year.IndexOf("- ") + 2)
            End If
        Else
            saveClientFormula.txtYearMin.Text = formula.c_year
        End If




        saveClientFormula.ShowDialog()


    End Sub
    Public Sub butSaveContinue()
        'save to chosen DB
        'test if it's a client formula
        Dim clientTable As Boolean = False
        If Not garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text Is Nothing Then
            If garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text <> "" Then
                clientTable = True
            End If
        End If
        '
        ' Dim idCar As Long = garageHome.lbCarIdSearch.Text
        Dim formula As Formula = getFormulaById(lbFormulaId.Text, Me.AccessibleDescription, clientTable, chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
        'Dim clientName As String = InputBox("Please enter the client name")
        Dim clientName As String = cmbClientName.Text

        If insertIntoFormulaClient(saveClientFormula.txtFName.Text, formula.id_car, formula.name_car, formula.type, formula.version, formula.formulaVariant, saveClientFormula.txtColorCode.Text, clientName.ToUpper, pctFormulaColor.BackColor.ToArgb, saveClientFormula.txtYearMin.Text & " - " & saveClientFormula.txtYearMax.Text, formula.cardNumber) Then
            Dim i As Integer
            For i = 0 To selectedFormulaColors.Length - 1
                insertIntoFormulaColorClient(getLastInsertedFormulaIdClient, selectedFormulaColors(i).id_color, selectedFormulaColors(i).quantite, selectedFormulaColors(i).id_Unit)
            Next

            MsgBox("Your formula has been saved", MsgBoxStyle.Information, "Information")
            garageHome.loadClients(chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
            Me.loadClients()
            disposeHiddenTextBoxes()
            'curFamily = Nothing
            'curSubFamily = Nothing
            'Dim formulaNameChosen As String = lsvFormula.SelectedItems(0).SubItems(0).Text

            'lbSelectedFormulavalue.Text = ""
            'HeadQHome.lsvFamily.Items.Clear()
            'HeadQHome.loadGarageHome()
            saveClientFormula.Close()
            Me.Close()
        Else
            MsgBox("Your formula not updated", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub butExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBack.Click
        Me.Close()

    End Sub


    Private Sub setTextBoxWidth()
        Dim t As TextBox

        If Controls.Find("txtQuantityDetail0", True).Length > 0 Then
            t = CType(Controls.Find("txtQuantityDetail0", True)(0), TextBox)
            If Not t Is Nothing Then
                qtyWidth = t.Width
            End If
        End If

        If Controls.Find("txtQuantityDetail0", True).Length > 0 Then
            t = CType(Controls.Find("txtColorsDetail0", True)(0), TextBox)
            If Not t Is Nothing Then
                clrWidth = t.Width
            End If
        End If

    End Sub

    Private Sub edit_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            fromMinimize = True
        Else
            fromMinimize = False
        End If
    End Sub

    Private Sub edit_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        setTextBoxWidth()

    End Sub

    Private Sub edit_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        setTextBoxWidth()
    End Sub

#Region "litreKilo"

    Private Sub enableLitre()
        butLitre.Enabled = False
        butLitre.BackColor = Drawing.Color.Red

        butKilo.Enabled = True
        butKilo.BackColor = Drawing.Color.Transparent
    End Sub

    Private Sub enableKilo()
        butLitre.Enabled = True
        butLitre.BackColor = Drawing.Color.Transparent
        butKilo.Enabled = False
        butKilo.BackColor = Drawing.Color.Red
    End Sub
    Private Sub butLitreKilo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLitre.Click, butKilo.Click
        Dim but As Button = CType(sender, Button)

        If but.Name = "butKilo" Then
            enableKilo()
        Else
            enableLitre()
        End If

        Dim i As Integer
        If but.Name = "butKilo" Then
            convertToKilo()
        Else
            convertToLitre()
        End If


    End Sub
    Private Sub convertToLitre()


        If kiloLitreRate <> Nothing Then
            If kiloLitreRate > 0 Then
                For i = 0 To selectedFormulaColors.Length - 1
                    Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
                    'selectedFormulaColors(i).quantite = selectedFormulaColors(i).quantite / kiloLitreRate '* txtTotalQty.Text / prevQty

                    Dim totalQty As Double = Double.Parse(txtQuantityDetail.Text.Replace(",", "."), ciClone)
                    txtQuantityDetail.Text = Math.Round(totalQty / kiloLitreRate, 1).ToString.Replace(",", ".")
                Next
                Dim totalPrice As Double = Double.Parse(txtTotalPrice.Text.Replace(",", "."), ciClone)
                txtTotalPrice.Text = Math.Round(totalPrice / kiloLitreRate, 1).ToString.Replace(",", ".")
            End If
        End If

        Dim str As String = txtTotalQty.Text
        setTextBoxWidth()
        'generatesDetail()
        txtTotalQty.Text = str.ToString.Replace(",", ".")

    End Sub
    Private Sub convertToKilo()
        Dim total As Double = 0
        For i = 0 To selectedFormulaColors.Length - 1
            total = total + selectedFormulaColors(i).quantite
        Next
        If total > 0 Then

            kiloLitreRate = 1000 / total

            Dim totalPrice As Double = Double.Parse(txtTotalPrice.Text, ciClone)
            txtTotalPrice.Text = Math.Round(totalPrice * kiloLitreRate, 1).ToString.Replace(",", ".")
            For i = 0 To selectedFormulaColors.Length - 1
                Dim txtQuantityDetail As TextBox = CType(Controls.Find("txtQuantityDetail" & (i), True)(0), TextBox)
                Dim totalQty As Double = Double.Parse(txtQuantityDetail.Text.Replace(",", "."), ciClone)
                txtQuantityDetail.Text = Math.Round(totalQty * kiloLitreRate, 1).ToString.Replace(",", ".")

            Next
        Else
        End If

        Dim str As String = txtTotalQty.Text
        setTextBoxWidth()
        'generatesDetail()
        txtTotalQty.Text = str.ToString.Replace(",", ".")

    End Sub

#End Region



    Private Sub butEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        Try

            Dim i As Integer
            For i = 0 To selectedFormulaColors.Length - 1
                Dim butDeleteTab As Button = CType(Me.Controls.Find("butDeleteColor" & i, True)(0), Button)
                If Not butDeleteTab Is Nothing Then
                    butDeleteTab.Visible = Not butDeleteTab.Visible
                End If

            Next
            Dim butAddTab As Button = CType(Me.Controls.Find("butAddColor", True)(0), Button)
            If Not butAddTab Is Nothing Then
                butAddTab.Visible = Not butAddTab.Visible

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub butDeleteClientFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDeleteClientFormula.Click

        Dim clientName As String = garageHome.lsvFamily.SelectedItems(0).SubItems(garageHome.clientNameColumnIndex - 1).Text
        If clientName = Nothing Then
            clientName = ""
        End If
        Dim idCar As Long = garageHome.lbCarIdSearch.Text
        If MsgBox("Are you sure you want to delete this color?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If deleteFormula(garageHome.lsvFamily.SelectedItems(0).SubItems(0).Text, garageHome.lsvFamily.SelectedItems(0).SubItems(1).Text) Then
                'MsgBox("The client formula has been deleted", MsgBoxStyle.Information)
                loadClients()
                garageHome.loadClients(chosenCar.tableName, chosenCar.carName, chosenCar.id_car)
                garageHome.lsvFamily.SelectedItems(0).Remove()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub butClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClear.Click
        cmbClientName.SelectedIndex = 0
        txtTotalQty.Text = ""
    End Sub


End Class