Imports System.Data.Entity.Core.Common.EntitySql
Imports System.Reflection
Imports EngineSDKCS

Module UtilitiesModule
    Public DeltaSolid As Integer = 5
    Public DeltaEffect As Integer = 10
    Public ResultLimit As Integer = 10
    Public m_colorants As New List(Of ColorantCS)
    Public m_substrates As New List(Of SubstrateCS)

    Public Function retrieveColorantFromRecipe(RecipeList As List(Of RecipeDB), colorantName As String) As RecipeDB
        For Each recipe As RecipeDB In RecipeList
            If recipe.Component.ToLower = colorantName.ToLower Then
                Return recipe
            End If
        Next
        Return Nothing
    End Function
    Public Function retrieveRecipeFromCorrection(correctionResults As List(Of MatchResultCS), originalRecipeList As List(Of RecipeDB)) As List(Of RecipeDB)

        Dim components As List(Of FormulaComponentCS) = correctionResults(0).Sample.Formula.Components
        Dim result As New List(Of RecipeDB)
        For Each component As FormulaComponentCS In components
            Dim recipe As New RecipeDB()
            recipe.Component = component.Colorant.Name
            recipe.Quantity = component.Amount * 100

            Dim originalRecipe As RecipeDB = retrieveColorantFromRecipe(originalRecipeList, recipe.Component)
            recipe.rowId = originalRecipe.rowId
            recipe.SampleID = originalRecipe.SampleID
            recipe.Layer = originalRecipe.Layer
            recipe.colorImgPath = originalRecipe.colorImgPath
            recipe.CorrectedDifferenceValue = recipe.Quantity - originalRecipe.Quantity

            result.Add(recipe)
        Next
        Return result

    End Function
    Public Function GetSingleSpectrum(waveValuesList As List(Of Double)) As ColorSpectrumCS
        Return New ColorSpectrumCS(GeometryCS.Geometry45as45, New SpectralRangeCS(400, 700, 10), waveValuesList)
    End Function

    Public Sub setColorToTransparent(formElements As List(Of Control))
        For i = 0 To formElements.Count - 1
            formElements.Item(i).BackColor = Color.Transparent
        Next
    End Sub

    Public Sub SetLookupTablePath()
        Try
            Dim path As String = "C:/Users/maykk/Documents/FormulationSDKs/FormulationSDK\LUT"
            Console.WriteLine("--------------------------------------------------------------------------------")
            Console.WriteLine(" Set lookup table path                                                          ")
            Console.WriteLine("--------------------------------------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("Path:  {0}", path)
            Console.WriteLine()
            EngineCS.SetLookupTablePath(path)
        Catch exception As Exception
            'LogHelper.LogException(exception)
        End Try
    End Sub
    Public Sub ConfigureLicensing()
        Try
            Dim hostName As String = "localhost"
            Dim portNumber As Integer = 8091
            Console.WriteLine("--------------------------------------------------------------------------------")
            Console.WriteLine(" Set licensing service                                                          ")
            Console.WriteLine("--------------------------------------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("Service:  {0}", "Nucleos license server")
            Console.WriteLine("Host:     {0}", hostName)
            Console.WriteLine("Port:     {0}", portNumber)
            Console.WriteLine()
            EngineCS.SetLicensingService(LicensingServiceCS.NucleosLicenseServer, hostName, portNumber, licensingSettingsCS:=Nothing, clientIDCS:=Nothing)
        Catch exception As Exception
            'LogHelper.LogException(exception)
        End Try
    End Sub

    Public Function GetSubstrate(ByVal substrates As List(Of SubstrateCS), ByVal name As String) As SubstrateCS
        For Each substrate As SubstrateCS In substrates

            If substrate.Name = name Then
                Return substrate
            End If
        Next

        Throw New Exception(String.Format("Substrate ""{0}"" not found", name))
    End Function
    Public Function GetColorant(ByVal colorants As List(Of ColorantCS), ByVal name As String) As ColorantCS
        For Each colorant As ColorantCS In colorants

            If colorant.Name = name Then
                Return colorant
            End If
        Next

        Throw New Exception(String.Format("Colorant ""{0}"" not found", name))
    End Function
    Public Function IsEffectRecipe(spectralDb As SpectralDB) As Boolean

        Dim sampleId As String = spectralDb.SampleId
        Dim recipeList As List(Of RecipeDB) = retrieveRecipeBySampleId(sampleId)

        For i = 0 To recipeList.Count - 1
            Dim recipe As RecipeDB = recipeList.Item(i)

            'if at least one is LS so formula is LS so it's solid
            If recipe.Component.ToLower.Contains("ls") Then
                Return False
            End If

            'if at least one bas color is not solid and not LS so it is effect formula
            If Not retrieveComponentType(recipe.Component).ToLower.Trim = "solid" Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function multiplySpectrum(colorSpectrumCS As ColorSpectrumCS) As ColorSpectrumCS
        For i = 0 To colorSpectrumCS.SpectralValues.Count - 1
            colorSpectrumCS.SpectralValues.Item(i) = colorSpectrumCS.SpectralValues.Item(i) * 100

        Next
        Return colorSpectrumCS
    End Function
    Public Function divideSpectrum(colorSpectrumCS As ColorSpectrumCS) As ColorSpectrumCS
        For i = 0 To colorSpectrumCS.SpectralValues.Count - 1
            colorSpectrumCS.SpectralValues.Item(i) = colorSpectrumCS.SpectralValues.Item(i) * 100 / 10000

        Next
        Return colorSpectrumCS

    End Function


    Public Sub removeSpectralFromList(spectral As SpectralDB, autoCorrectionList As List(Of SpectralDB))
        autoCorrectionList.Where(Function(value) value.SampleId <> spectral.SampleId).ToList
    End Sub

    Public Sub addSpectralFromList(spectral As SpectralDB, autoCorrectionList As List(Of SpectralDB))
        autoCorrectionList.Add(spectral)
    End Sub

    Public Sub setAutCorrectedScoreSearchListViewItem(lstvItem As ListViewItem, newScore As Double)

        lstvItem.SubItems(3).Text = newScore
        If newScore < 2 Then
            lstvItem.SubItems(3).ForeColor = System.Drawing.Color.Green
        ElseIf newScore < 5 Then
            lstvItem.SubItems(3).ForeColor = System.Drawing.Color.Yellow
        Else
            lstvItem.SubItems(3).ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Public Sub colorSearchListViewItem(lstvItem As ListViewItem, color As System.Drawing.Color)
        For i = 0 To lstvItem.SubItems.Count - 2 'do not backcolor the last column which is the color
            Dim subItm As ListViewItem.ListViewSubItem = lstvItem.SubItems(i)
            If subItm IsNot Nothing And subItm.BackColor <> System.Drawing.Color.Gray Then
                subItm.BackColor = color
            End If
        Next
    End Sub
    Public Function findListViewItemBySampleId(lstvSearch As ListView, sampleId As String) As ListViewItem
        For Each item In lstvSearch.Items
            If item.SubItems(0).text = sampleId Then
                Return item
            End If
        Next
        Return Nothing
    End Function
End Module
