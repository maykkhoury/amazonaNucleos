Public Class assignColorByCode

    Private Sub txtQuantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.GotFocus, txtColorCode.GotFocus
        sender.selectAll()
    End Sub

    Private Sub txtColorCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColorCode.KeyPress, txtQuantity.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            assign()
        End If
    End Sub

    Private Sub txtColorsCode_keyStroke(ByVal sender As System.Object, ByVal e As KeyEventArgs) ' Handles txtColorCode.KeyUp, txtQuantity.KeyUp

    End Sub


    Private Sub assign()
        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("The quantity must be a numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim chosencolor As AmazonaColor = getColorByCode(txtColorCode.Text)
        If chosencolor Is Nothing Then
            MessageBox.Show("Color code does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim id_color As Integer = chosencolor.id_color

        Dim id_unit As Integer = 2 'Kilo
        Dim quantite As Double = CType(txtQuantity.Text, Double)

        Dim id_formula As Integer = details.lbFormulaId.Text
        Dim alreadyexist = False
        Dim formulaColor As New FormulaColor
        formulaColor.id_color = id_color
        formulaColor.id_Unit = id_unit
        formulaColor.quantite = quantite


        If fromAddFormula Then


        Else 'from HeadQhome
            formulaColor.id_formula = id_formula
            If selectedFormulaColors Is Nothing Then
                Dim MyArray As New ArrayList
                MyArray.Add(formulaColor)

                selectedFormulaColors = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
            Else

                Dim MyArray As New ArrayList
                Dim i As Integer

                For i = 0 To selectedFormulaColors.Length - 1
                    MyArray.Add(selectedFormulaColors(i))
                    If selectedFormulaColors(i).id_color = id_color Then
                        alreadyexist = True
                    End If
                Next
                If alreadyexist Then
                    MsgBox("Color already exist for this formula", MessageBoxIcon.Information)
                    Exit Sub
                Else
                    MyArray.Add(formulaColor)


                End If

                selectedFormulaColors = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
                If Not details.quantitiesWithAllDecimals Is Nothing Then
                    InitQuantitiesWithAllDecimals()
                End If
                If Not details.quantitiesWithAllDecimalsCum Is Nothing Then
                    InitQuantitiesWithAllDecimalsCum()
                End If
            End If

            details.generatesDetail()
            details.rdNormal.Select()
            details.doRdNormalCheckChange()
            Me.Close()
        End If
    End Sub
    Private Sub InitQuantitiesWithAllDecimals()
        ReDim Preserve details.quantitiesWithAllDecimals(selectedFormulaColors.Length - 1)
        details.quantitiesWithAllDecimals(selectedFormulaColors.Length - 1) = selectedFormulaColors(selectedFormulaColors.Length - 1).quantite
        If IsNumeric(details.txtTotalQty.Text) Then
            details.quantitiesWithAllDecimals(selectedFormulaColors.Length - 1) = details.quantitiesWithAllDecimals(selectedFormulaColors.Length - 1) * details.txtTotalQty.Text
        End If

    End Sub

    Private Sub InitQuantitiesWithAllDecimalsCum()
        ReDim Preserve details.quantitiesWithAllDecimalsCum(selectedFormulaColors.Length)
        details.quantitiesWithAllDecimalsCum(selectedFormulaColors.Length - 1) = selectedFormulaColors(selectedFormulaColors.Length - 1).quantite
        If IsNumeric(details.txtTotalQty.Text) Then
            details.quantitiesWithAllDecimalsCum(selectedFormulaColors.Length - 1) = details.quantitiesWithAllDecimalsCum(selectedFormulaColors.Length - 1) * details.txtTotalQty.Text
        End If
    End Sub
    Private Sub assignColorByCode_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub assignColorByCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fromAddFormula Then

        Else
            'Dim butAddColor As Button = details.spltColorDetail.Panel1.Controls.Find("butAddColor", True)(0)

            Dim x As Integer = details.butEdit.Location.X - Me.Width
            Dim y As Integer = details.butEdit.Location.Y + details.butEdit.Height + 2

            Dim left As Integer = details.Location.X + 50 'details.spltColorDetail.Location.X
            Dim top As Integer = details.Location.Y + 225 'details.spltColorDetail.Location.Y
            Dim newPoint As New Point(left, top)
            Me.Location = newPoint

            'Me.Width = details.spltColorDetail.Size.Width

            'Dim xQuantity As Integer = details.grpDetail.Location.X + details.panColors.Location.X + details.butdetails.Location.X + details.butdetails.Size.Width + details.txtQuantityDetailHidden.Location.X
            'Dim yQuantity As Integer = txtQuantity.Location.Y

            'Dim newPointQuantity As New Point(xQuantity, yQuantity)
            'txtQuantity.Location = newPointQuantity

        End If

        txtColorCode.Focus()
        txtColorCode.SelectAll()
    End Sub

    Private Sub butBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBack.Click
        Me.Close()
    End Sub
End Class