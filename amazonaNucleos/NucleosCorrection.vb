Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports NucleosDatabaseSDKCS

Public Class NucleosCorrection
    Private recipeDBList As List(Of RecipeDB)
    Private trialSampleId As String
    Private trialSpectralDb As SpectralDB
    Private coat As String

    Private Sub showFormula(recipeList As List(Of RecipeDB))
        cleanControls()

        For i = 0 To recipeList.Count - 1
            Dim lbColorCodeTmp As New Label With {
                .Text = recipeList.Item(i).Component
            }
            lbColorCodeTmp.Name = lbColor.Name & i
            lbColorCodeTmp.Anchor = lbColor.Anchor
            lbColorCodeTmp.Left = lbColor.Left
            lbColorCodeTmp.Top = lbColor.Top + (i * 30) + 50
            Dim lbColorFont As New Font(lbColor.Font, FontStyle.Regular)
            lbColorCodeTmp.Font = lbColorFont

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

            pnlResult.Controls.Add(lbQuantityTmp)

            Dim lbCorrectionTmp As New Label

            Dim correctedValue As String
            If Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2) > 0 Then
                correctedValue = "+" & Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2)
                lbCorrectionTmp.ForeColor = Color.Blue

            Else
                If recipeList.Item(i).CorrectedDifferenceValue = 0 Then
                    correctedValue = "-"
                Else
                    correctedValue = Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2)
                    lbCorrectionTmp.ForeColor = Color.DarkBlue
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

        Next
    End Sub

    Private Sub NucleosCorrection_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' MsgBox(NucleosSearchForm.lstvSearchResult.SelectedItems.Item(0).SubItems(0).Text)


        coat = NucleosSearchForm.coat
        Me.Text = Me.Text & " (" & coat & ")"
        trialSampleId = NucleosSearchForm.lstvSearchResult.SelectedItems.Item(0).SubItems(0).Text

        lbSampleId.Text = trialSampleId
        lbJobName.Text = NucleosSearchForm.txtChosenJob.Text



        recipeDBList = retrieveRecipeBySampleId(trialSampleId)
        showFormula(recipeDBList)

        Dim originalRGBValue As RGBValueCS = NucleosSearchForm.selectedSpectralDB.rgbValueCS
        Dim originalColor As System.Drawing.Color = System.Drawing.Color.FromArgb(originalRGBValue.R, originalRGBValue.G, originalRGBValue.B)
        pnOriginal.BackColor = originalColor

        pnCorrected.BackColor = Color.Transparent

    End Sub

    Private Sub cleanControls()
        Dim controlToDispose As New List(Of Control)

        For i = 0 To pnlResult.Controls.Count - 1
            If pnlResult.Controls.Item(i).Name <> lbColor.Name And pnlResult.Controls.Item(i).Name <> lbQuantity.Name And pnlResult.Controls.Item(i).Name <> lbCorrection.Name Then
                controlToDispose.Add(pnlResult.Controls.Item(i))
            End If
        Next
        For i = 0 To controlToDispose.Count - 1
            controlToDispose.Item(i).Dispose()
        Next
    End Sub

    Public Sub setAssortmentsAndColorants()
        If m_colorants Is Nothing Or m_substrates Is Nothing Or m_colorants.Count = 0 Or m_substrates.Count = 0 Then
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
        End If

    End Sub
    Private Sub btnCorrection_Click(sender As Object, e As EventArgs) Handles btnCorrection.Click
        ConfigureLicensing()
        SetLookupTablePath()
        setAssortmentsAndColorants()



        'setting the trial Sample
        Dim trialSample As New SampleCS()
        trialSample.Name = trialSampleId
        'trialSample.Substrate = GetSubstrate(m_substrates, "LENETA WHITE")



        Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(trialSampleId, NucleosSearchForm.geometriesInMachine, coat)
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
        targetSample.Name = NucleosSearchForm.txtChosenJob.Text
        Dim targetMeasurements As List(Of MeasurementCS)
        Dim targetColorSpectrumCSList As List(Of ColorSpectrumCS) = NucleosSearchForm.colorSpectrumCSDeviceList
        Dim targetMeasurementCSList As New List(Of MeasurementCS)
        targetMeasurementCSList.Add(New MeasurementCS(targetColorSpectrumCSList))
        targetSample.Measurements = targetMeasurementCSList
        targetSample.Substrate = substrate



        Dim formulaComponentCSList As New List(Of FormulaComponentCS)
        For i = 0 To recipeDBList.Count - 1
            Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, recipeDBList.Item(i).Component), recipeDBList.Item(i).Quantity)
            formulaComponentCSList.Add(formulaComponentCS)
        Next
        Dim formulaCS As New FormulaCS(formulaComponentCSList)
        trialSample.Formula = formulaCS
        trialSample.RelativeThickness = 1.0


        'setting the correction settings
        Dim correctionSettings As CorrectionSettingsCS = CorrectionSettingsCS.CreateNewSettings(ResinRestrictionTypeCS.None, ColorOnlyCorrectionModeCS.[On])
        Dim colorantConstraints As List(Of ColorantConstraintCS) = New List(Of ColorantConstraintCS)()

        'executing the correction
        ' Dim correctionResults As List(Of MatchResultCS) = EngineCS.CalculateCorrection(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, targetSample, trialSample.Formula.GetColorants(), trialSample, correctionSettings, colorantConstraints, , modelSettingsCS:=Nothing, metricSettingsCS:=Nothing)
        ' Dim recipeList As List(Of RecipeDB) = retrieveRecipeFromCorrection(correctionResults, recipeDBList)
        'targetSample.Formula = formulaCS

        'Dim predictedMeasurements As List(Of MeasurementCS) = EngineCS.PredictMeasurements(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, targetSample, trialSample, colorimetricSettingsCS:=Nothing)
        'Dim colorSpectrum As ColorSpectrumCS = predictedMeasurements.Item(0).ColorSpectra.Item(0)

        'Dim labValueFromDevice As LabValueCS = getLabValuesFromSpectrum(colorSpectrum)
        'Dim rgbValueCS = ColorimetryCS.ToRGB(labValueFromDevice)

        'Dim correctedColor As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)
        'pnCorrected.BackColor = correctedColor



        'showFormula(recipeList)

    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        showFormula(recipeDBList)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class