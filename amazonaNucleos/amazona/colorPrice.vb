Imports System.IO

Public Class colorPrice

    Private Sub setListViewLabel()
        'ccolorcode.Text = getLabelDescription("ccolorcode")
        ccolorName.Text = getLabelDescription("ccolorName")
        cgprice.Text = getLabelDescription("cgprice")
        cdprice.Text = getLabelDescription("cdprice")
        'cquantity.Text = getLabelDescription("cquantity")

    End Sub
    Private Sub setCurrenciesCombo()
        cmbCurrency.Items.Clear()

        Dim i As Integer
        For i = 0 To currencies.Length - 1

            cmbCurrency.Items.Add(currencies(i).code_currency.Trim)

            If Not chosenCurrency Is Nothing Then
                If currencies(i).id_currency = chosenCurrency.id_currency Then
                    cmbCurrency.SelectedIndex = i
                End If
            End If
        Next i
    End Sub

    Public Sub addResultsToListviewBColors(ByVal BColorFiltered() As AmazonaColor)
        Try


            Dim garagePriceDetailTab() As GaragePrice
            ReDim garagePriceDetailTab(BColorFiltered.Length - 1)

            For i = 0 To BColorFiltered.Length - 1
                garagePriceDetailTab(i) = getGaragePriceDetail(BColorFiltered(i).id_color)

            Next

            Dim lsvString As String()()
            ReDim lsvString(BColorFiltered.Length - 1)

            For i = 0 To BColorFiltered.Length - 1
                ReDim Preserve lsvString(i)(4)

                lsvString(i)(0) = BColorFiltered(i).id_color
                'lsvString(i)(1) = BColorFiltered(i).colorCode
                lsvString(i)(1) = BColorFiltered(i).name_color

                Dim garagePriceDetail As GaragePrice = garagePriceDetailTab(i)
                If Not garagePriceDetail Is Nothing Then

                    Dim gPrice As Double = garagePriceDetail.garage_price
                    If gPrice <> Nothing Then

                        Dim gunit As Unit = getUnit(BColorFiltered(i).id_unit_on_entry)
                        Dim gunitStr As String = gunit.code_unit.Trim
                        Dim gcurrency As String = getCurrency(garagePriceDetail.id_currency).code_currency.Trim

                        Dim gRateToLitre As Double = gunit.rateToLitre
                        gPrice = gPrice * gRateToLitre * 1000

                        lsvString(i)(2) = (Math.Round(gPrice, 4)) '& " " & gcurrency) ' & " Per " & gunit)
                    Else
                        lsvString(i)(2) = ("")
                    End If
                Else
                    lsvString(i)(2) = ("")
                End If

                Dim price As Double = BColorFiltered(i).defaultPrice
                Dim unit As Unit = getUnit(BColorFiltered(i).id_unit_on_entry)
                Dim unitStr As String = unit.code_unit.Trim
                'Dim currency As String = getCurrency(BColorFiltered(i).id_defaultCurreny).code_currency.Trim
                'price = convertToChosenCurrency(price, getCurrency(BColorFiltered(i).id_defaultCurreny).rateToDollar)
                'price = convertToChosenUnit(price, getUnit(BColorFiltered(i).id_defaultUnit).rateToLitre)

                Dim rateToLitre As Double = unit.rateToLitre
                price = price * rateToLitre * 1000

                lsvString(i)(3) = (Math.Round(price, 4)) ' & " " & currency) '& " Per " & unitStr)
                lsvString(i)(4) = (unitStr)
            Next


            lsvBColors.Items.Clear()

            lsvBColors.BeginUpdate()
            lsvBColors.Sorting = SortOrder.None
            lsvBColors.ListViewItemSorter = Nothing
            setListViewLabel()
            For i = 0 To BColorFiltered.Length - 1
                lsvBColors.Items.Add(lsvString(i)(0))
                lsvBColors.Items(i).SubItems.Add(lsvString(i)(1))
                lsvBColors.Items(i).SubItems.Add(lsvString(i)(2))
                lsvBColors.Items(i).SubItems.Add(lsvString(i)(3))
                lsvBColors.Items(i).SubItems.Add(lsvString(i)(4))
                'lsvBColors.Items(i).SubItems.Add(lsvString(i)(5))
            Next
            lsvBColors.EndUpdate()

            'autoresize listview
            For Each column As ColumnHeader In lsvBColors.Columns
                If column.Tag <> "cidBColor" Then
                    column.Width = -2
                End If

            Next
            '------------------------

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtPriceBcolorForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPriceBcolorForm.KeyDown
        If e.KeyCode = Keys.Enter Then
            saveColor()
        End If
    End Sub

    Private Sub saveColor()
        Dim price As String = txtPriceBcolorForm.Text

        If txtPriceBcolorForm.Text.Trim = "" Then
            price = 0
        End If

        If Not IsNumeric(price) Then
            MsgBox("price must be numeric", MsgBoxStyle.Information)
            Exit Sub
        End If

        If lbIdBColorForm.Text < 0 Then
            MsgBox("A BColor must be selected first", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim unitsTab() As Unit = getUnits()
        Dim rateToLitre As Double = 1
        Dim id_unitLitre As Integer
        For i = 0 To unitsTab.Length - 1
            If unitsTab(i).code_unit.Trim = lbUnit.Text.Trim Then
                rateToLitre = unitsTab(i).rateToLitre

            End If

            If unitsTab(i).code_unit.Trim = "L" Then
                id_unitLitre = unitsTab(i).id_unit
            End If
        Next
        Dim currentCurrency_id As Integer = currencies(cmbCurrency.SelectedIndex).id_currency

        If lsvBColors.SelectedItems.Count = 0 Then
            MsgBox("A BColor must be selected first", MsgBoxStyle.Information)
            Exit Sub
        End If

        If orredyExists(lbIdBColorForm.Text.Trim) Then
            If updateGarageColor(lbIdBColorForm.Text.Trim, price / (rateToLitre * 1000), currentCurrency_id, id_unitLitre) Then
                MsgBox("Succes", MsgBoxStyle.Information, "Information")
                lsvBColors.SelectedItems(0).SubItems(2).Text = price '& " " & currencies(cmbCurrency.SelectedIndex).code_currency.Trim
            End If
        Else
            If insertIntoGaragePrice(lbIdBColorForm.Text.Trim, price / (rateToLitre * 1000), currentCurrency_id, id_unitLitre) Then
                MsgBox("Succes", MsgBoxStyle.Information, "Information")
                lsvBColors.SelectedItems(0).SubItems(2).Text = price '& " " & currencies(cmbCurrency.SelectedIndex).code_currency.Trim
            End If
        End If

        'addResultsToListviewBColors(getColors())
    End Sub
    Private Sub butEditBColorForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEditBColorForm.Click

        saveColor()


    End Sub
    Private Function orredyExists(ByVal id) As Boolean
        Dim whereStr As String = " WHERE id_color=" & id
        Dim tab = getGaragePricesDB(whereStr)
        If tab Is Nothing Then
            Return False
        End If
        If tab.Length = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub lsvBColors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvBColors.MouseClick, lsvBColors.KeyDown, lsvBColors.KeyUp
        lbIdBColorForm.Text = lsvBColors.SelectedItems(0).SubItems(0).Text
        Dim temp As String = lsvBColors.SelectedItems(0).SubItems(2).Text
        'Dim priceStr As String = ""
        'Dim currencyStr As String = ""

        ' If temp.Trim.IndexOf(" ") > 0 Then
        'priceStr = temp.Substring(0, temp.Trim.IndexOf(" ")).Trim
        'currencyStr = temp.Substring(temp.Trim.IndexOf(" ") + 1).Trim
        'Dim currenciesTab() As Currency = getCurrencies()
        'Dim i As Integer
        'For i = 0 To currenciesTab.Length - 1
        'If currenciesTab(i).code_currency.Trim.ToLower = currencyStr.ToLower Then
        'cmbCurrency.SelectedIndex = i

        'Exit For
        'End If
        'Next

        ' End If
        txtPriceBcolorForm.Text = temp
        lbUnit.Text = lsvBColors.SelectedItems(0).SubItems(4).Text
        Dim imgPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//images//" & getColorById(lbIdBColorForm.Text).colorImgPath
        Try
            imageToPreview = Image.FromFile(imgPath)
            'pctCarImg.Image = imageToPreview
            pctBColorImg.ImageLocation = imgPath
        Catch ex As IOException
            'MsgBox("Image not found:" & ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub colorPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        addResultsToListviewBColors(getColors())
        'lbUnitMesureValue.Text = chosenUnit.code_unit
        lbUnit.Text = ""
        txtPriceBcolorForm.Text = ""
        'lbCurrencyDetailsValue.Text = chosenCurrency.code_currency

        setCurrenciesCombo()
    End Sub


#Region "listViewSorting"
    ' The column currently used for sorting.
    Private m_SortingColumn As ColumnHeader

    ' Sort using the clicked column.
    Private Sub lvwBooks_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvBColors.ColumnClick
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = lsvBColors.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lsvBColors.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        lsvBColors.Sort()
    End Sub

#End Region




    Private Sub butClearUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClearUpdate.Click
        txtPriceBcolorForm.Text = ""
        lbUnit.Text = ""
        cmbCurrency.SelectedIndex = 0
        lbIdBColorForm.Text = "-1"
        pctBColorImg.Image = Nothing

    End Sub
End Class