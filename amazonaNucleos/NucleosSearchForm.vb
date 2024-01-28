Imports System.Net.Sockets
Imports System.Runtime.ConstrainedExecution
Imports System.Security.AccessControl
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip
Imports amazonaNucleos.XRite
Imports NucleosDatabaseSDKCS

Public Class NucleosSearchForm

#Region "General"

    Private _spectro As MA3 = New MA3()
    Public colorSpectrumCSDevice As ColorSpectrumCS
    Public colorSpectrumCSDeviceList As New List(Of ColorSpectrumCS)
    Private solidLabValueFromDevice As LabValueCS
    Private labValueFromDeviceList As New List(Of LabValueCS)
    Public geometriesInMachine As New List(Of String)
    Public geometriesInMachineForDb As New List(Of String)
    Public machineSpectrumsPerGeometry As New Dictionary(Of String, ColorSpectrumCS)
    Public solidJob As Boolean = False
    Public effectJob As Boolean = False
    Public unspecifiedEffectJob As Boolean = False
    Public sortedbyMeritSolid As List(Of SpectralDB)
    Public selectedSpectralDB As SpectralDB
    Public autoCorrectionList As List(Of SpectralDB)


    Public coat As String


    Private Sub NucleosSearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEffectType.SelectedIndex = 0
        cmbCoats.SelectedIndex = 0
        coat = cmbCoats.SelectedItem.ToString

        'set the garage pic
        Dim imgPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//logo.jpg"
        Try

            pictGaragePic.BackgroundImage = Image.FromFile(imgPath)
            pictGaragePic.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception

        End Try


        'threading
        Control.CheckForIllegalCrossThreadCalls = False
        ''''''
        '''
        ConfigureLicensing()
        SetLookupTablePath()
        ' setAssortmentsAndColorants()

        overrideSkin()

    End Sub

    Private Sub overrideSkin()
        'Dim txtCanSizeColor As System.Drawing.Color = System.Drawing.Color.FromArgb(224, 224, 224)
        txtCanSize.BackColor = System.Drawing.Color.Gray
    End Sub


    Private Sub setListViewLabel()
        sampleId.Text = sampleId.Text.Replace("↑", "").Replace("↓", "")
        sampleName.Text = sampleName.Text.Replace("↑", "").Replace("↓", "")
        merit.Text = merit.Text.Replace("↑", "").Replace("↓", "")
        color.Text = color.Text.Replace("↑", "").Replace("↓", "")
        effect.Text = effect.Text.Replace("↑", "").Replace("↓", "")
    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click

        If lstbJobs.SelectedItems.Count = 0 Then
            MsgBox("Please select a job")
            Return
        End If

        'reset the sorting
        lstvSearchResult.Items.Clear()
        lstvSearchResult.Sorting = SortOrder.None
        lstvSearchResult.ListViewItemSorter = Nothing
        setListViewLabel()
        '''''''''''


        coat = cmbCoats.SelectedItem.ToString
        '  MsgBox(solidLabValueFromDevice.L & " " & solidLabValueFromDevice.a & " " & solidLabValueFromDevice.b)

        If cmbEffectType.SelectedItem.ToString = "Solid" Then
            solidJob = True
            effectJob = False
            unspecifiedEffectJob = False
        Else
            If cmbEffectType.SelectedItem.ToString = "Effect" Then
                solidJob = False
                effectJob = True
                unspecifiedEffectJob = False
            Else
                solidJob = False
                effectJob = False
                unspecifiedEffectJob = True
            End If
        End If


        Dim allColors As List(Of SpectralDB)
        Dim filteredByDelta As List(Of SpectralDB)
        ''effect''
        If cmbEffectType.Text.ToLower = "effect" Then
            allColors = getAllColorsEffectTarget()
            Dim l As Double = 0
            Dim a As Double = 0
            Dim b As Double = 0

            Dim countAngles As Integer = 0
            For Each labValue In labValueFromDeviceList
                countAngles += 1
                l += labValue.L
                a += labValue.a
                b += labValue.b
            Next
            l = l / countAngles
            a = a / countAngles
            b = b / countAngles
            Dim labValueMedian As New LabValueCS(l, a, b)

            filteredByDelta = filterByDelta(allColors, labValueMedian)
        Else
            'solid'''''
            allColors = getAllColorsForSolidTarget()
            filteredByDelta = filterByDelta(allColors, solidLabValueFromDevice)
        End If

        sortedbyMeritSolid = sortByMerit(filteredByDelta, colorSpectrumCSDeviceList, coat)

        Dim listCount As Integer = 0
        If sortedbyMeritSolid.Count - 1 <= ResultLimit Then
            listCount = sortedbyMeritSolid.Count - 1
        Else
            listCount = ResultLimit - 1
        End If

        For i As Integer = 0 To listCount
            Dim sampleId As String = sortedbyMeritSolid.Item(i).SampleId
            Dim sampleName As String = sortedbyMeritSolid.Item(i).SampleName
            Dim merit As Double = sortedbyMeritSolid.Item(i).tempMeritForSort
            Dim rgbValueCS As RGBValueCS = sortedbyMeritSolid.Item(i).rgbValueCS
            'Dim l As Double = Math.Round(sortedbyMeritSolid.Item(i).labValue.L, 2)
            'Dim a As Double = Math.Round(sortedbyMeritSolid.Item(i).labValue.a, 2)
            'Dim b As Double = Math.Round(sortedbyMeritSolid.Item(i).labValue.b, 2)
            'Dim de2000 As Double = sortedbyMeritSolid.Item(i).DeltaE2000
            Dim effect As String = sortedbyMeritSolid.Item(i).effect

            Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)

            Dim tagFile As TagFile = retrieveTagFileBySampleId(sampleId)
            Dim coarseness As String = tagFile.tagCoarseness
            Dim data() As String = {sampleId, sampleName, Math.Round(merit, 2), "", effect, coarseness, ""}

            Dim item = New ListViewItem(data)
            lstvSearchResult.Items.Add(item)
            lstvSearchResult.Items(i).UseItemStyleForSubItems = False
            lstvSearchResult.Items(i).SubItems(6).BackColor = color
            If merit < 2 Then
                lstvSearchResult.Items(i).SubItems(2).ForeColor = System.Drawing.Color.Green
            ElseIf merit < 5 Then
                lstvSearchResult.Items(i).SubItems(2).ForeColor = System.Drawing.Color.Yellow
            Else
                lstvSearchResult.Items(i).SubItems(2).ForeColor = System.Drawing.Color.Red
            End If

        Next

        'pour les effets utiliser la meme filter by delta


        initializeThreads()
    End Sub

    Private Sub butSetLab_Click(sender As Object, e As EventArgs) Handles butSetLab.Click
        setLABInDB()
    End Sub

    Private Sub cmbEffectType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEffectType.SelectedIndexChanged
        selectJob()
    End Sub


    Private Sub lstvSearchResult_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstvSearchResult.MouseDoubleClick
        Dim sampleId As String = lstvSearchResult.SelectedItems.Item(0).SubItems(0).Text

        For Each spectral In sortedbyMeritSolid
            If spectral.SampleId = sampleId Then
                selectedSpectralDB = spectral
                Exit For
            End If
        Next

        tbControl.SelectTab(1)
        initializeDetails()


        showFormula(recipeDBList)
        'NucleosCorrection.ShowDialog()

        'show/hide stuff based on score
        If (selectedSpectralDB.autoCorrectedMerit And selectedSpectralDB.autoCorrectedMeritValue < 1.5) Or selectedSpectralDB.tempMeritForSort < 1.5 Then
            btnCorrection.Enabled = False
            btnOriginal.Enabled = False
        Else
            btnCorrection.Enabled = True
            btnOriginal.Enabled = True
        End If
        If selectedSpectralDB.autoCorrectedMerit Then
            lbScoreValue.Text = Math.Round(selectedSpectralDB.autoCorrectedMeritValue, 2)
        Else
            lbScoreValue.Text = Math.Round(selectedSpectralDB.tempMeritForSort, 2)
        End If
        If Val(lbScoreValue.Text) < 1.5 Then
            btnMeasure.Visible = False
        Else
            btnMeasure.Visible = True
        End If
        If selectedSpectralDB.autoCorrectedMerit Then
            invokeCorrection()
        End If
    End Sub

    Public Sub setAssortmentsAndColorants()
        'If m_colorants Is Nothing Or m_substrates Is Nothing Or m_colorants.Count = 0 Or m_substrates.Count = 0 Then
        NucleosDatabaseCS.OpenDatabase("./Amazona_2023-assortments.bcsqlite")
        Dim assortments As List(Of NucleosAssortmentCS) = NucleosDatabaseCS.QueryAssortments()

        If assortments.Count > 0 Then
            Dim assortmentsIndex As Integer
            If coat = "LS" Then
                assortmentsIndex = 1
            Else
                assortmentsIndex = 0
            End If
            Dim assortment As NucleosAssortmentCS = NucleosDatabaseCS.LoadAssortmentByUUID(assortments(assortmentsIndex).UUID)
            m_colorants = assortment.Colorants

            If assortment.Substrate IsNot Nothing Then
                m_substrates = New List(Of SubstrateCS)() From {
                assortment.Substrate
            }
            End If
        End If
        'End If


    End Sub

#End Region

#Region "Details"
    Private recipeDBList As List(Of RecipeDB)
    Private correctedRecipe As List(Of RecipeDB)
    Private trialSampleId As String
    Private trialSpectralDb As SpectralDB
    Private trialEffect As String = "S"


    Private Sub emptyDetails()
        lbSampleId.Text = ""
        lbScoreValue.Text = ""
        pnTrial1.BackColor = System.Drawing.Color.Transparent
        pnTrial2.BackColor = System.Drawing.Color.Transparent
        pnTrial3.BackColor = System.Drawing.Color.Transparent
        pnTrial4.BackColor = System.Drawing.Color.Transparent
        pnTrial5.BackColor = System.Drawing.Color.Transparent
        pnTrial6.BackColor = System.Drawing.Color.Transparent
        txtCanSize.Text = "100"
        lbWhiteBg.Visible = False
        lbBlackBg.Visible = False
        'btnMeasure.Visible = False
        pnCorrectedWhite1.Visible = False
        pnCorrectedWhite2.Visible = False
        pnCorrectedWhite3.Visible = False
        pnCorrectedWhite4.Visible = False
        pnCorrectedWhite5.Visible = False
        pnCorrectedWhite6.Visible = False

        pnCorrectedBlack1.Visible = False
        pnCorrectedBlack2.Visible = False
        pnCorrectedBlack3.Visible = False
        pnCorrectedBlack4.Visible = False
        pnCorrectedBlack5.Visible = False
        pnCorrectedBlack6.Visible = False

        correctedRecipe = Nothing
        pnCorrectedWhite1.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite2.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite3.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite4.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite5.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite6.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack1.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack2.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack3.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack4.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack5.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack6.BackColor = System.Drawing.Color.Transparent

        cleanControls()
    End Sub
    Private Sub initializeDetails()
        Me.Text = Me.Text & " (" & coat & ")"

        trialSampleId = lstvSearchResult.SelectedItems.Item(0).SubItems(0).Text
        trialEffect = lstvSearchResult.SelectedItems.Item(0).SubItems(4).Text
        lbSampleId.Text = trialSampleId
        lbScoreValue.Text = lstvSearchResult.SelectedItems.Item(0).SubItems(3).Text

        txtCanSize.Text = "100"
        lbWhiteBg.Visible = False
        lbBlackBg.Visible = False

        pnCorrectedWhite1.Visible = False
        pnCorrectedWhite2.Visible = False
        pnCorrectedWhite3.Visible = False
        pnCorrectedWhite4.Visible = False
        pnCorrectedWhite5.Visible = False
        pnCorrectedWhite6.Visible = False

        pnCorrectedBlack1.Visible = False
        pnCorrectedBlack2.Visible = False
        pnCorrectedBlack3.Visible = False
        pnCorrectedBlack4.Visible = False
        pnCorrectedBlack5.Visible = False
        pnCorrectedBlack6.Visible = False


        correctedRecipe = Nothing
        recipeDBList = retrieveRecipeBySampleId(trialSampleId)
        cleanControls()



        Dim trialRGBValue As RGBValueCS = selectedSpectralDB.rgbValueCS
        If coat.ToUpper = "LS" Or cmbEffectType.Text.ToLower = "solid" Or cmbEffectType.Text.ToLower = "unspecified" Then
            Dim trialColor As System.Drawing.Color = System.Drawing.Color.FromArgb(trialRGBValue.R, trialRGBValue.G, trialRGBValue.B)
            pnTrial1.BackColor = trialColor
        Else
            Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(selectedSpectralDB.SampleId, geometriesInMachine, coat)
            For i = 0 To trialColorSpectralDBList.Count - 1
                Dim thisRgbValueCS As RGBValueCS = ColorimetryCS.ToRGB(trialColorSpectralDBList.Item(i).labValue)

                Dim colorPanel As Panel = Nothing
                If i = 0 Then
                    colorPanel = pnTrial1
                ElseIf i = 1 Then
                    colorPanel = pnTrial2
                ElseIf i = 2 Then
                    colorPanel = pnTrial3
                ElseIf i = 3 Then
                    colorPanel = pnTrial4
                ElseIf i = 4 Then
                    colorPanel = pnTrial5
                ElseIf i = 5 Then
                    colorPanel = pnTrial6
                End If
                colorPanel.BackColor = System.Drawing.Color.FromArgb(thisRgbValueCS.R, thisRgbValueCS.G, thisRgbValueCS.B)
            Next

        End If

        pnCorrectedWhite1.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite2.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite3.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite4.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite5.BackColor = System.Drawing.Color.Transparent
        pnCorrectedWhite6.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack1.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack2.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack3.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack4.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack5.BackColor = System.Drawing.Color.Transparent
        pnCorrectedBlack6.BackColor = System.Drawing.Color.Transparent

    End Sub

    Private Sub showFormula(recipeList As List(Of RecipeDB))
        cleanControls()
        Dim currentTotal As Double=0
        For i = 0 To recipeList.Count - 1

            currentTotal += recipeList.Item(i).Quantity

            Dim lbColorCodeTmp As New Label With {
                .Text = recipeList.Item(i).Component
            }
            lbColorCodeTmp.Name = lbColor.Name & i
            lbColorCodeTmp.Anchor = lbColor.Anchor
            lbColorCodeTmp.Left = lbColor.Left
            lbColorCodeTmp.Top = lbColor.Top + (i * 30) + 50
            Dim lbColorFont As New Font(lbColor.Font, FontStyle.Regular)
            lbColorCodeTmp.Font = lbColorFont
            lbColorCodeTmp.BorderStyle = BorderStyle.FixedSingle
            lbColorCodeTmp.Width = 85
            pnlResult.Controls.Add(lbColorCodeTmp)


            Dim lbQuantityTmp As New Label With {
                .Text = Math.Round(recipeList.Item(i).Quantity, 2)
            }
            lbQuantityTmp.Name = lbQuantity.Name & i
            lbQuantityTmp.Anchor = lbQuantity.Anchor
            lbQuantityTmp.Left = lbQuantity.Left
            lbQuantityTmp.Top = lbQuantity.Top + (i * 30) + 50
            Dim lbQuantityFont As New Font(lbQuantity.Font, FontStyle.Regular)
            lbQuantityTmp.Font = lbQuantityFont
            lbQuantityTmp.BorderStyle = BorderStyle.FixedSingle
            lbQuantityTmp.Width = 100
            pnlResult.Controls.Add(lbQuantityTmp)

            Dim lbAccumulationTmp As New Label With {
                .Text = Math.Round(currentTotal, 2)
            }
            lbAccumulationTmp.Name = lbAccumulation.Name & i
            lbAccumulationTmp.Anchor = lbAccumulation.Anchor
            lbAccumulationTmp.Left = lbAccumulation.Left
            lbAccumulationTmp.Top = lbAccumulation.Top + (i * 30) + 50
            Dim lbAccumulationFont As New Font(lbAccumulation.Font, FontStyle.Regular)
            lbAccumulationTmp.Font = lbAccumulationFont
            lbAccumulationTmp.BorderStyle = BorderStyle.FixedSingle
            lbAccumulationTmp.Width = 100
            pnlResult.Controls.Add(lbAccumulationTmp)


            Dim lbCorrectionTmp As New Label

            Dim correctedValue As String
            If Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2) > 0 Then
                correctedValue = "+" & Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2)
                lbCorrectionTmp.ForeColor = System.Drawing.Color.White

            Else
                If recipeList.Item(i).CorrectedDifferenceValue = 0 Then
                    correctedValue = "-"
                Else
                    correctedValue = Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2)
                    lbCorrectionTmp.ForeColor = System.Drawing.Color.DarkBlue
                End If
            End If
            lbCorrectionTmp.Text = correctedValue
            lbCorrectionTmp.Name = lbCorrection.Name & i
            lbCorrectionTmp.Anchor = lbCorrection.Anchor
            lbCorrectionTmp.Left = lbCorrection.Left
            lbCorrectionTmp.Top = lbCorrection.Top + (i * 30) + 50
            Dim lbCorrectionFont As New Font(lbCorrection.Font, FontStyle.Regular)
            lbCorrectionTmp.Font = lbCorrectionFont

            pnlResult.Controls.Add(lbCorrectionTmp)



            Dim pbxColorTmp As New PictureBox
            pbxColorTmp.Name = "pbxColorTmp" & i
            pbxColorTmp.Anchor = lbColorCodeTmp.Anchor
            pbxColorTmp.Left = lbColorCodeTmp.Left - 50
            pbxColorTmp.Top = lbColorCodeTmp.Top
            pbxColorTmp.Width = 45
            pbxColorTmp.Height = lbColorCodeTmp.Height
            pbxColorTmp.ImageLocation = System.AppDomain.CurrentDomain.BaseDirectory() & "//colors/" & recipeList.Item(i).colorImgPath
            pnlResult.Controls.Add(pbxColorTmp)

        Next
    End Sub
    Private Sub cleanControls()
        Dim controlToDispose As New List(Of Control)

        For i = 0 To pnlResult.Controls.Count - 1
            If pnlResult.Controls.Item(i).Name <> txtCanSize.Name And pnlResult.Controls.Item(i).Name <> lbG.Name And pnlResult.Controls.Item(i).Name <> lbCanSize.Name And pnlResult.Controls.Item(i).Name <> lbColor.Name And pnlResult.Controls.Item(i).Name <> lbQuantity.Name And pnlResult.Controls.Item(i).Name <> lbAccumulation.Name And pnlResult.Controls.Item(i).Name <> lbCorrection.Name Then
                controlToDispose.Add(pnlResult.Controls.Item(i))
            End If
        Next
        For i = 0 To controlToDispose.Count - 1
            controlToDispose.Item(i).Dispose()
        Next
    End Sub



    Private Function doAutoCorrectionGetNewScore(thisTrialSampleId As String, thisRecipeDBList As List(Of RecipeDB), ByRef correctedFormulas As FormulaCS) As Double
        setAssortmentsAndColorants()

        'setting the trial Sample
        Dim trialSample As New SampleCS()
        trialSample.Name = thisTrialSampleId
        'trialSample.Substrate = GetSubstrate(m_substrates, "LENETA WHITE")



        Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(thisTrialSampleId, geometriesInMachine, coat)
        Dim trialColorSpectrumList As New List(Of ColorSpectrumCS)
        For i = 0 To trialColorSpectralDBList.Count - 1
            trialColorSpectrumList.Add(trialColorSpectralDBList.Item(i).colorSpectrumCS)
        Next


        Dim substrateStr As String = trialColorSpectralDBList.Item(0).Substrate
        Dim substrate As SubstrateCS = GetSubstrate(m_substrates, substrateStr)
        trialSample.Substrate = substrate


        Dim trialMeasurementCSList As New List(Of MeasurementCS)
        trialMeasurementCSList.Add(New MeasurementCS(trialColorSpectrumList))
        trialSample.Measurements = trialMeasurementCSList



        'setting the target Sample
        Dim targetSample As New SampleCS()
        targetSample.Name = txtChosenJob.Text
        Dim targetMeasurements As List(Of MeasurementCS)
        Dim targetColorSpectrumCSList As List(Of ColorSpectrumCS) = colorSpectrumCSDeviceList
        Dim targetMeasurementCSList As New List(Of MeasurementCS)
        targetMeasurementCSList.Add(New MeasurementCS(targetColorSpectrumCSList))
        targetSample.Measurements = targetMeasurementCSList
        targetSample.Substrate = substrate



        Dim formulaComponentCSList As New List(Of FormulaComponentCS)
        For i = 0 To thisRecipeDBList.Count - 1
            Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, thisRecipeDBList.Item(i).Component), thisRecipeDBList.Item(i).Quantity)
            formulaComponentCSList.Add(formulaComponentCS)
        Next
        Dim formulaCS As New FormulaCS(formulaComponentCSList)
        trialSample.Formula = formulaCS
        trialSample.RelativeThickness = 1.0


        'setting the correction settings
        Dim correctionSettings As CorrectionSettingsCS = CorrectionSettingsCS.CreateNewSettings(ResinRestrictionTypeCS.None, ColorOnlyCorrectionModeCS.[On])
        Dim colorantConstraints As List(Of ColorantConstraintCS) = New List(Of ColorantConstraintCS)()

        'executing the correction
        Dim correctionResults As List(Of MatchResultCS) = EngineCS.CalculateCorrection(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, targetSample, trialSample.Formula.GetColorants(), trialSample, correctionSettings, colorantConstraints, modelSettingsCS:=Nothing, metricSettingsCS:=Nothing)

        Dim components As List(Of FormulaComponentCS) = correctionResults(0).Sample.Formula.Components
        correctedFormulas = New FormulaCS(components)



        Return Math.Round(correctionResults.Item(0).Score, 2)

    End Function


    Private Function doCorrection(thisTrialSampleId As String, thisRecipeDBList As List(Of RecipeDB)) As List(Of RecipeDB)
        setAssortmentsAndColorants()

        'setting the trial Sample
        Dim trialSample As New SampleCS()
        trialSample.Name = thisTrialSampleId
        'trialSample.Substrate = GetSubstrate(m_substrates, "LENETA WHITE")



        Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(thisTrialSampleId, geometriesInMachine, coat)
        Dim trialColorSpectrumList As New List(Of ColorSpectrumCS)
        For i = 0 To trialColorSpectralDBList.Count - 1
            trialColorSpectrumList.Add(trialColorSpectralDBList.Item(i).colorSpectrumCS)
        Next


        Dim substrateStr As String = trialColorSpectralDBList.Item(0).Substrate
        Dim substrate As SubstrateCS = GetSubstrate(m_substrates, substrateStr)
        trialSample.Substrate = substrate


        Dim trialMeasurementCSList As New List(Of MeasurementCS)
        trialMeasurementCSList.Add(New MeasurementCS(trialColorSpectrumList))
        trialSample.Measurements = trialMeasurementCSList



        'setting the target Sample
        Dim targetSample As New SampleCS()
        targetSample.Name = txtChosenJob.Text
        Dim targetMeasurements As List(Of MeasurementCS)
        Dim targetColorSpectrumCSList As List(Of ColorSpectrumCS) = colorSpectrumCSDeviceList
        Dim targetMeasurementCSList As New List(Of MeasurementCS)
        targetMeasurementCSList.Add(New MeasurementCS(targetColorSpectrumCSList))
        targetSample.Measurements = targetMeasurementCSList
        targetSample.Substrate = substrate



        Dim trialFormulaComponentCSList As New List(Of FormulaComponentCS)
        For i = 0 To thisRecipeDBList.Count - 1
            Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, thisRecipeDBList.Item(i).Component), thisRecipeDBList.Item(i).Quantity)
            trialFormulaComponentCSList.Add(formulaComponentCS)
        Next
        Dim trialFormulaCS As New FormulaCS(trialFormulaComponentCSList)
        trialSample.Formula = trialFormulaCS


        trialSample.RelativeThickness = 1.0


        'setting the correction settings
        Dim correctionSettings As CorrectionSettingsCS = CorrectionSettingsCS.CreateNewSettings(ResinRestrictionTypeCS.None, ColorOnlyCorrectionModeCS.[On])
        Dim colorantConstraints As List(Of ColorantConstraintCS) = New List(Of ColorantConstraintCS)()

        'executing the correction
        Dim correctionResults As List(Of MatchResultCS) = EngineCS.CalculateCorrection(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, targetSample, trialSample.Formula.GetColorants(), trialSample, correctionSettings, colorantConstraints, modelSettingsCS:=Nothing, metricSettingsCS:=Nothing)
        Dim recipeList As List(Of RecipeDB) = retrieveRecipeFromCorrection(correctionResults, thisRecipeDBList)


        'targetSample.Formula = formulaCS
        'put the new recipe in the trial to get the color

        Dim formulaComponentCSList As List(Of FormulaComponentCS) = New List(Of FormulaComponentCS)
        For i = 0 To recipeList.Count - 1
            Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, recipeList.Item(i).Component), recipeList.Item(i).Quantity)
            formulaComponentCSList.Add(formulaComponentCS)
        Next
        Dim formulaCS As FormulaCS = New FormulaCS(formulaComponentCSList)
        trialSample.Formula = formulaCS

        'set the corrected score
        lbScoreValue.Text = Math.Round(correctionResults.Item(0).Score, 2)

        Dim predictedMeasurements As List(Of MeasurementCS) = EngineCS.PredictMeasurements(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, trialSample, modelSettingsCS:=Nothing, metricSettingsCS:=Nothing)
        Dim colorSpectrum As ColorSpectrumCS
        If trialEffect = "S" Then
            'colorSpectrum = predictedMeasurements.Item(0).ColorSpectra.Item(2) 'for solid use 45as45
            'white BG
            For i = 0 To predictedMeasurements.Item(0).ColorSpectra.Count - 1
                Dim tmpColorSpectrum As ColorSpectrumCS = predictedMeasurements.Item(0).ColorSpectra.Item(i)
                If predictedMeasurements.Item(0).ColorSpectra.Item(i).Geometry.ToString = GeometryCS.Geometry45as45.ToString Then
                    colorSpectrum = tmpColorSpectrum
                    Dim labValueFromDevice As LabValueCS = getLabValuesFromSpectrum(colorSpectrum)
                    Dim rgbValueCS = ColorimetryCS.ToRGB(labValueFromDevice)
                    Dim correctedColor As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)
                    pnCorrectedWhite1.BackColor = correctedColor
                    Exit For
                End If
            Next

            'Black BG
            For i = 0 To predictedMeasurements.Item(1).ColorSpectra.Count - 1
                Dim tmpColorSpectrum As ColorSpectrumCS = predictedMeasurements.Item(1).ColorSpectra.Item(i)
                If predictedMeasurements.Item(1).ColorSpectra.Item(i).Geometry.ToString = GeometryCS.Geometry45as45.ToString Then
                    colorSpectrum = tmpColorSpectrum
                    Dim labValueFromDevice As LabValueCS = getLabValuesFromSpectrum(colorSpectrum)
                    Dim rgbValueCS = ColorimetryCS.ToRGB(labValueFromDevice)
                    Dim correctedColor As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)
                    pnCorrectedBlack1.BackColor = correctedColor
                    Exit For
                End If
            Next
        Else
            'effects
            For Each g In geometriesInMachineForDb
                'white BG effect
                Dim panelCount As Integer = 0
                For i = 0 To predictedMeasurements.Item(0).ColorSpectra.Count - 1
                    Dim tmpColorSpectrum As ColorSpectrumCS = predictedMeasurements.Item(0).ColorSpectra.Item(i)
                    If predictedMeasurements.Item(0).ColorSpectra.Item(i).Geometry.ToString.ToLower.Contains(g.ToLower) Then
                        panelCount += 1
                        colorSpectrum = tmpColorSpectrum
                        Dim labValueFromDevice As LabValueCS = getLabValuesFromSpectrum(colorSpectrum)
                        Dim rgbValueCS = ColorimetryCS.ToRGB(labValueFromDevice)
                        Dim correctedColor As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)

                        Dim colorPanel As Panel = Nothing
                        If panelCount = 1 Then
                            colorPanel = pnCorrectedWhite1
                        ElseIf panelCount = 2 Then
                            colorPanel = pnCorrectedWhite2
                        ElseIf panelCount = 3 Then
                            colorPanel = pnCorrectedWhite3
                        ElseIf panelCount = 4 Then
                            colorPanel = pnCorrectedWhite4
                        ElseIf panelCount = 5 Then
                            colorPanel = pnCorrectedWhite5
                        ElseIf panelCount = 6 Then
                            colorPanel = pnCorrectedWhite6
                        End If
                        If Not colorPanel Is Nothing Then
                            colorPanel.BackColor = correctedColor
                        End If

                    End If
                Next

                'black BG effect
                panelCount = 0
                For i = 0 To predictedMeasurements.Item(1).ColorSpectra.Count - 1
                    Dim tmpColorSpectrum As ColorSpectrumCS = predictedMeasurements.Item(0).ColorSpectra.Item(i)
                    If predictedMeasurements.Item(1).ColorSpectra.Item(i).Geometry.ToString.ToLower.Contains(g.ToLower) Then
                        panelCount += 1
                        colorSpectrum = tmpColorSpectrum
                        Dim labValueFromDevice As LabValueCS = getLabValuesFromSpectrum(colorSpectrum)
                        Dim rgbValueCS = ColorimetryCS.ToRGB(labValueFromDevice)
                        Dim correctedColor As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)

                        Dim colorPanel As Panel = Nothing
                        If panelCount = 1 Then
                            colorPanel = pnCorrectedBlack1
                        ElseIf panelCount = 2 Then
                            colorPanel = pnCorrectedBlack2
                        ElseIf panelCount = 3 Then
                            colorPanel = pnCorrectedBlack3
                        ElseIf panelCount = 4 Then
                            colorPanel = pnCorrectedBlack4
                        ElseIf panelCount = 5 Then
                            colorPanel = pnCorrectedBlack5
                        ElseIf panelCount = 6 Then
                            colorPanel = pnCorrectedBlack6
                        End If
                        If Not colorPanel Is Nothing Then
                            colorPanel.BackColor = correctedColor
                        End If

                    End If
                Next
            Next


        End If



        Return recipeList

    End Function
    Private Sub invokeCorrection()
        Dim recipeList As List(Of RecipeDB) = doCorrection(trialSampleId, recipeDBList)
        correctedRecipe = recipeList
        lbWhiteBg.Visible = True
        lbBlackBg.Visible = True
        btnMeasure.Visible = True
        pnCorrectedWhite1.Visible = True
        pnCorrectedWhite2.Visible = True
        pnCorrectedWhite3.Visible = True
        pnCorrectedWhite4.Visible = True
        pnCorrectedWhite5.Visible = True
        pnCorrectedWhite6.Visible = True

        pnCorrectedBlack1.Visible = True
        pnCorrectedBlack2.Visible = True
        pnCorrectedBlack3.Visible = True
        pnCorrectedBlack4.Visible = True
        pnCorrectedBlack5.Visible = True
        pnCorrectedBlack6.Visible = True

        showFormula(recipeList)
    End Sub
    Private Sub btnCorrection_Click(sender As Object, e As EventArgs) Handles btnCorrection.Click
        invokeCorrection()

    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        correctedRecipe = Nothing
        txtCanSize.Text = "100"
        lbWhiteBg.Visible = False
        lbBlackBg.Visible = False
        btnMeasure.Visible = False
        pnCorrectedWhite1.Visible = False
        pnCorrectedWhite2.Visible = False
        pnCorrectedWhite3.Visible = False
        pnCorrectedWhite4.Visible = False
        pnCorrectedWhite5.Visible = False
        pnCorrectedWhite6.Visible = False

        pnCorrectedBlack1.Visible = False
        pnCorrectedBlack2.Visible = False
        pnCorrectedBlack3.Visible = False
        pnCorrectedBlack4.Visible = False
        pnCorrectedBlack5.Visible = False
        pnCorrectedBlack6.Visible = False

        showFormula(recipeDBList)
    End Sub

    Private Sub txtCanSize_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCanSize.KeyUp

        If e.KeyCode = Keys.Enter Then

            Dim canSizeText As String = txtCanSize.Text
            If Not Regex.IsMatch(canSizeText, "^[0-9 ]+$") Then
                MsgBox("Can size must contain a number", MsgBoxStyle.Exclamation)
                txtCanSize.Text = "100"
                Return
            End If
            Dim basicColorCount As Integer = recipeDBList.Count
            Dim fraction As Double = txtCanSize.Text / 100
            Dim recipeToUse As List(Of RecipeDB) =recipeDBList
            If Not correctedRecipe Is Nothing Then
                recipeToUse = correctedRecipe
            End If
            For i = 0 To basicColorCount - 1

                Dim lbQuantityTmp As Label = pnlResult.Controls.Find(lbQuantity.Name & i, True)(0)
                Dim originalValue As Double = recipeToUse.Item(i).Quantity
                Dim newValue As Double = Math.Round(originalValue * fraction, 2)
                lbQuantityTmp.Text = newValue

                Dim lbCorrectionControls As Control() = pnlResult.Controls.Find(lbCorrection.Name & i, True)
                If lbCorrectionControls.Count > 0 Then
                    Dim lbCorrectionTmp As Label = lbCorrectionControls(0)

                    Dim newCorrectedValue As Double = recipeToUse.Item(i).CorrectedDifferenceValue * fraction

                    Dim newCorrectedValueStr As String
                    If newCorrectedValue > 0 Then
                        newCorrectedValueStr = "+" & Math.Round(newCorrectedValue, 2)
                    Else
                        If newCorrectedValue = 0 Then
                            newCorrectedValueStr = "-"
                        Else
                            newCorrectedValueStr = Math.Round(newCorrectedValue, 2)
                        End If
                    End If

                    lbCorrectionTmp.Text = newCorrectedValueStr
                End If

            Next

        End If
    End Sub




#End Region
#Region "Jobs listview"
    Private Sub butGetJobs_Click(sender As Object, e As EventArgs) Handles butGetJobs.Click
        StopThreadOnListView()
        printJobs(lstbJobs)
    End Sub

    Private Sub selectJob()
        If lstbJobs.SelectedItem Is Nothing Then
            Return
        End If
        emptyDetails()
        StopThreadOnListView()
        'notes: recuperer les angles qui ont ete utilisé par la machine dans le but de les utiliser apres pour les effets
        'reinitialize the machine geometry of the job in use
        geometriesInMachine = New List(Of String)
        txtChosenJob.Text = lstbJobs.SelectedItem.ToString
        setSpectralDataAndSetGeometriesUsed(txtChosenJob.Text)
        Dim rgbValueCS As RGBValueCS
        Dim jobRGBs As New List(Of Control) From {jobRGB1, jobRGB2, jobRGB3, jobRGB4, jobRGB5, jobRGB6}
        setColorToTransparent(jobRGBs)


        'this is just to set the color based on the device spectral
        If cmbEffectType.SelectedItem.ToString = "Solid" Then
            solidJob = True
            effectJob = False
            unspecifiedEffectJob = False
        Else
            If cmbEffectType.SelectedItem.ToString = "Effect" Then
                solidJob = False
                effectJob = True
                unspecifiedEffectJob = False
            Else
                solidJob = False
                effectJob = False
                unspecifiedEffectJob = True
            End If
        End If
        If solidJob Or unspecifiedEffectJob Then
            colorSpectrumCSDevice = machineSpectrumsPerGeometry.Item("r45as45")
            colorSpectrumCSDeviceList.Clear()
            colorSpectrumCSDeviceList.Add(colorSpectrumCSDevice)
            solidLabValueFromDevice = getLabValuesFromSpectrum(colorSpectrumCSDevice)
            rgbValueCS = ColorimetryCS.ToRGB(solidLabValueFromDevice)
            jobRGB1.BackColor = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)
            pnTarget1.BackColor = jobRGB1.BackColor
        Else
            If effectJob Then
                colorSpectrumCSDevice = Nothing
                solidLabValueFromDevice = Nothing
                labValueFromDeviceList = New List(Of LabValueCS)
                colorSpectrumCSDeviceList = New List(Of ColorSpectrumCS)
                For i = 0 To geometriesInMachine.Count - 1
                    Dim geometry As String = geometriesInMachine.Item(i)

                    'Dim thisColorSpectrumCSDevice As ColorSpectrumCS = multiplySpectrum(machineSpectrumsPerGeometry.Item(geometry))
                    Dim thisColorSpectrumCSDevice As ColorSpectrumCS = machineSpectrumsPerGeometry.Item(geometry)

                    If geometry.ToLower.Contains("45as-15") Or geometry.ToLower.Contains("45asminus15") Then
                        thisColorSpectrumCSDevice.Geometry = GeometryCS.Geometry45asMinus15
                    ElseIf geometry.ToLower.Contains("45as15") Then
                        thisColorSpectrumCSDevice.Geometry = GeometryCS.Geometry45as15
                    ElseIf geometry.ToLower.Contains("45as25") Then
                        thisColorSpectrumCSDevice.Geometry = GeometryCS.Geometry45as25
                    ElseIf geometry.ToLower.Contains("45as45") Then
                        thisColorSpectrumCSDevice.Geometry = GeometryCS.Geometry45as45
                    ElseIf geometry.ToLower.Contains("45as75") Then
                        thisColorSpectrumCSDevice.Geometry = GeometryCS.Geometry45as75
                    ElseIf geometry.ToLower.Contains("45as110") Then
                        thisColorSpectrumCSDevice.Geometry = GeometryCS.Geometry45as110
                    End If

                    colorSpectrumCSDeviceList.Add(thisColorSpectrumCSDevice)

                    Dim thisLabValueFromDevice As LabValueCS = getLabValuesFromSpectrum(thisColorSpectrumCSDevice)
                    labValueFromDeviceList.Add(thisLabValueFromDevice)

                    Dim thisRgbValueCS As RGBValueCS = ColorimetryCS.ToRGB(thisLabValueFromDevice)
                    jobRGBs.Item(i).BackColor = System.Drawing.Color.FromArgb(thisRgbValueCS.R, thisRgbValueCS.G, thisRgbValueCS.B)

                    Dim colorPanel As Panel = Nothing
                    If i = 0 Then
                        colorPanel = pnTarget1
                    ElseIf i = 1 Then
                        colorPanel = pnTarget2
                    ElseIf i = 2 Then
                        colorPanel = pnTarget3
                    ElseIf i = 3 Then
                        colorPanel = pnTarget4
                    ElseIf i = 4 Then
                        colorPanel = pnTarget5
                    ElseIf i = 5 Then
                        colorPanel = pnTarget6
                    End If
                    colorPanel.BackColor = System.Drawing.Color.FromArgb(thisRgbValueCS.R, thisRgbValueCS.G, thisRgbValueCS.B)

                Next
                geometriesInMachineForDb = New List(Of String)
                For Each g In geometriesInMachine
                    Dim gDb As String = g.ToLower.Replace("r45", "45")
                    geometriesInMachineForDb.Add(gDb)
                Next
            End If
        End If


        lstvSearchResult.Items.Clear()

    End Sub
    Private Sub lstbJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbJobs.SelectedIndexChanged
        selectJob()
    End Sub
#End Region

#Region "listViewSorting"
    ' The column currently used for sorting.
    Private m_SortingColumn As ColumnHeader

    Private Sub doSortColumn(column As Integer)
        Dim new_sorting_column As ColumnHeader = lstvSearchResult.Columns(column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("↑ ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Replace("↓ ", "")
            m_SortingColumn.Text = m_SortingColumn.Text.Replace("↑ ", "")
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "↑ " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "↓ " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lstvSearchResult.ListViewItemSorter = New ListViewComparer(column, sort_order)

        ' Sort.
        lstvSearchResult.Sort()
    End Sub


    ' Sort using the clicked column.
    Private Sub lvwBooks_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstvSearchResult.ColumnClick
        doSortColumn(e.Column)
    End Sub

#End Region

#Region "multithreading"
    Private executeCorrections As Thread

    Private executeCorrectionItem1Thread As Thread

    Private Sub initializeThreads()
        autoCorrectionList = New List(Of SpectralDB)
        subscribeSamplesForAutoCorrection()


        executeCorrections = New Thread(New ThreadStart(AddressOf executeCorrectionsSub))
        executeCorrections.Start()

    End Sub
    Private Sub executeCorrectionsSub()
        If sortedbyMeritSolid IsNot Nothing Then
            'loop on the first 3 only
            Dim correctedCount As Integer = 0
            For Each spectralDB In sortedbyMeritSolid
                If spectralDB.tempMeritForSort > 1.5 And Not spectralDB.autoCorrectedMerit Then
                    Dim item As ListViewItem = findListViewItemBySampleId(lstvSearchResult, spectralDB.SampleId)
                    If item IsNot Nothing Then
                        Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(50, 50, 50)
                        colorSearchListViewItem(item, color)


                        Dim currentCoat As String = CStr(Invoke(New Func(Of String)(Function() Me.cmbCoats.Text)))
                        Dim recipeDBList As List(Of RecipeDB) = retrieveRecipeBySampleId(spectralDB.SampleId, currentCoat)
                        Dim correctedFormulas As FormulaCS = New FormulaCS()
                        Dim newScore As Double = doAutoCorrectionGetNewScore(spectralDB.SampleId, recipeDBList, correctedFormulas)
                        setAutCorrectedScoreSearchListViewItem(item, newScore)
                        spectralDB.autoCorrectedMerit = True
                        spectralDB.autoCorrectedMeritValue = newScore
                        spectralDB.autoCorrectedFormula = correctedFormulas
                        correctedCount += 1
                    End If
                End If
                If correctedCount = 3 Then
                    doSortColumn(3)
                    Exit For
                End If
            Next
        End If

    End Sub
    Private Sub subscribeSamplesForAutoCorrection()
        If sortedbyMeritSolid IsNot Nothing Then
            'loop on the first 3 only
            For Each spectralDB In sortedbyMeritSolid
                If spectralDB.tempMeritForSort > 1.5 And Not spectralDB.autoCorrectedMerit Then
                    'subscribe for autocorrection
                    addSpectralFromList(spectralDB, autoCorrectionList)
                End If
            Next
        End If
    End Sub


    Private Sub StopThreadOnListView()

        If executeCorrectionItem1Thread IsNot Nothing Then
            If executeCorrectionItem1Thread.IsAlive Then
                executeCorrectionItem1Thread.Abort()
            End If
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        tbControl.SelectTab(0)
    End Sub

#End Region
End Class
