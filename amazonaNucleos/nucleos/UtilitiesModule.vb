Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Core.Common.EntitySql
Imports System.Diagnostics.Tracing
Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports garageApp.XRite
Imports EngineSDKCS
Imports System.Linq.Expressions

Module UtilitiesModule
    Public DeltaSolid As Integer = 5
    Public DeltaEffect As Integer = 10
    Public ResultLimit As Integer = 20
    Public m_colorants As New List(Of ColorantCS)
    Public m_substrates As New List(Of SubstrateCS)
    Public selectedLegacyMode As String = "MA9x"
    Public selectedMeasurementTrigger As String = "Online"
    Public AveragingMode As String = "NONE"
    Public logFilePath As String

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
            ''recipe.CorrectedDifferenceValue = recipe.Quantity - originalRecipe.Quantity

            result.Add(recipe)
        Next
        Return result

    End Function

    Public Function getRecipeDifferences(correctedRecipeList As List(Of RecipeDB), originalRecipeList As List(Of RecipeDB)) As List(Of RecipeDB)


        Dim result As New List(Of RecipeDB)
        For Each recipe As RecipeDB In correctedRecipeList

            Dim originalRecipe As RecipeDB = retrieveColorantFromRecipe(originalRecipeList, recipe.Component)
            recipe.CorrectedDifferenceValue = recipe.Quantity - originalRecipe.Quantity

            result.Add(recipe)
        Next
        Return result

    End Function


    Public Function retrieveBaseCoatRecipeFromCorrection(correctionResults As List(Of MatchResultCS), originalRecipeList As List(Of RecipeDB)) As List(Of RecipeDB)
        Dim tricoatSample As TricoatSampleCS = correctionResults(0).Sample

        Dim components As List(Of FormulaComponentCS) = tricoatSample.FormulaBaseCoat.Components
        Dim result As New List(Of RecipeDB)
        For Each component As FormulaComponentCS In components
            Dim recipe As New RecipeDB()
            recipe.Component = component.Colorant.Name
            recipe.Quantity = component.Amount * 100

            Dim originalRecipe As RecipeDB = retrieveColorantFromRecipe(originalRecipeList, recipe.Component)
            recipe.rowId = originalRecipe.rowId
            recipe.SampleID = originalRecipe.SampleID
            recipe.Layer = 1
            recipe.CorrectedDifferenceValue = recipe.Quantity - originalRecipe.Quantity

            result.Add(recipe)
        Next
        Return result

    End Function
    Public Function retrieveMidCoatRecipeFromCorrection(correctionResults As List(Of MatchResultCS), originalRecipeList As List(Of RecipeDB)) As List(Of RecipeDB)
        Dim tricoatSample As TricoatSampleCS = correctionResults(0).Sample

        Dim components As List(Of FormulaComponentCS) = tricoatSample.FormulaMidCoat.Components
        Dim result As New List(Of RecipeDB)
        For Each component As FormulaComponentCS In components
            Dim recipe As New RecipeDB()
            recipe.Component = component.Colorant.Name
            recipe.Quantity = component.Amount * 100

            Dim originalRecipe As RecipeDB = retrieveColorantFromRecipe(originalRecipeList, recipe.Component)
            recipe.rowId = originalRecipe.rowId
            recipe.SampleID = originalRecipe.SampleID
            recipe.Layer = 2
            recipe.CorrectedDifferenceValue = recipe.Quantity - originalRecipe.Quantity

            result.Add(recipe)
        Next
        Return result

    End Function
    Public Function GetSingleSpectrum(waveValuesList As List(Of Double), spectralSetName As String) As ColorSpectrumCS
        Dim colorSpectrum As ColorSpectrumCS = Nothing
        Select Case spectralSetName
            Case "r45as-15"
                colorSpectrum = New ColorSpectrumCS(GeometryCS.Geometry45asMinus15, New SpectralRangeCS(400, 700, 10), waveValuesList)

            Case "r45as15"
                colorSpectrum = New ColorSpectrumCS(GeometryCS.Geometry45as15, New SpectralRangeCS(400, 700, 10), waveValuesList)

            Case "r45as25"
                colorSpectrum = New ColorSpectrumCS(GeometryCS.Geometry45as25, New SpectralRangeCS(400, 700, 10), waveValuesList)

            Case "r45as45"
                colorSpectrum = New ColorSpectrumCS(GeometryCS.Geometry45as45, New SpectralRangeCS(400, 700, 10), waveValuesList)

            Case "r45as75"
                colorSpectrum = New ColorSpectrumCS(GeometryCS.Geometry45as75, New SpectralRangeCS(400, 700, 10), waveValuesList)

            Case "r45as110"
                colorSpectrum = New ColorSpectrumCS(GeometryCS.Geometry45as110, New SpectralRangeCS(400, 700, 10), waveValuesList)
            Case Else
                MsgBox("Unknown Spectral Set: " & spectralSetName)
        End Select

        Return colorSpectrum
    End Function

    Public Sub setColorToTransparent(formElements As List(Of Control))
        For i = 0 To formElements.Count - 1
            formElements.Item(i).BackColor = Color.Transparent
        Next
    End Sub

    Public Sub SetLookupTablePath()
        Try
            'Dim path As String = "C:/Users/maykk/Documents/FormulationSDKs/FormulationSDK\LUT"
            Dim path As String = Directory.GetCurrentDirectory() & "\LUT"
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
        Dim i As Integer = 0
        File.AppendAllText(logFilePath, "substrate name retrieving is " & name & Environment.NewLine)
        For Each substrate As SubstrateCS In substrates
            ' Append text to the file
            If substrate Is Nothing Then
                File.AppendAllText(logFilePath, "substrate of " & i & " is null" & Environment.NewLine)
            Else
                File.AppendAllText(logFilePath, "substrate of " & i & " is " & substrate.Name & Environment.NewLine)
            End If

            If substrate.Name = name Then
                File.AppendAllText(logFilePath, "substrate " & substrate.Name & " is found " & Environment.NewLine)
                Return substrate
            End If
            i = i + 1
        Next
        File.AppendAllText(logFilePath, "throwing exception on " & name & Environment.NewLine)
        Throw New Exception(String.Format("Substrate ""{0}"" not found", name))
    End Function

    Public Function GetColorant(ByVal colorants As List(Of ColorantCS), ByVal name As String) As ColorantCS
        For Each colorant As ColorantCS In colorants

            If colorant.Name = name Then
                Return colorant
            End If
        Next

        Return Nothing
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

            'if at least one base color is not solid and not LS so it is effect formula
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
        Dim newBoldFont As Font = New Font(lstvItem.SubItems(3).Font.FontFamily, lstvItem.SubItems(3).Font.Size, FontStyle.Bold)
        lstvItem.SubItems(3).Font = newBoldFont
        lstvItem.SubItems(3).Text = newScore
        If newScore < 2 Then
            lstvItem.SubItems(3).ForeColor = System.Drawing.Color.Green
        ElseIf newScore < 5 Then
            lstvItem.SubItems(3).ForeColor = System.Drawing.Color.Orange
        Else
            lstvItem.SubItems(3).ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Public Sub colorSearchListViewItem(lstvItem As ListViewItem, color As System.Drawing.Color)
        For i = 0 To lstvItem.SubItems.Count - 2 'do not backcolor the last column which is the color
            Dim subItm As ListViewItem.ListViewSubItem = lstvItem.SubItems(i)
            If subItm IsNot Nothing And subItm.BackColor <> System.Drawing.Color.Gray Then
                subItm.BackColor = color
                subItm.ForeColor = Color.White
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

    Private Function IsKohinoorSelected() As Boolean
        'Dim type As Type = _spectro.[GetType]()
        'Return GetType(MAT5).IsAssignableFrom(type) OrElse GetType(MAT6).IsAssignableFrom(type) OrElse GetType(MAT12).IsAssignableFrom(type)
        Return False
    End Function
    Private Function IsTopazSelected() As Boolean
        'Dim type As Type = _spectro.[GetType]()
        'Return GetType(MA3).IsAssignableFrom(type) OrElse GetType(MA5).IsAssignableFrom(type)
        Return True
    End Function

    Private Function IsTopazQCSelected() As Boolean
        'Dim type As Type = _spectro.[GetType]()
        'Return GetType(MA5QC).IsAssignableFrom(type)
        Return False
    End Function
    Enum KohinoorLegacyCorrectionType
        [Default] = 0
        NoCorrection = 1
        Ma98 = 2
        V1 = 3
        V2 = 4
        V3 = 5
        V4 = 6
        V5 = 7
        V6 = 8
        V7 = 9
    End Enum

    Enum TopazLegacyCorrectionType
        NoLegacyCT = 0
        MAxxCT = 1
        Reserved1CT = 2
        Reserved2NoCT = 3
        Reserved3NoCT = 4
        MA9x = 5
        BYK = 7
        NoLegacyNoCT = 9
        Difference = 10
    End Enum

    Public Sub SetLegacyMode(_spectro As MA3)
        If IsKohinoorSelected() OrElse IsTopazSelected() OrElse IsTopazQCSelected() Then
            Dim value As Integer = 0
            ' Dim selectedLegacyMode As String = _view.MainMenuAccordion.ConfigurationPanel.LegacyMode

            If IsKohinoorSelected() Or IsTopazQCSelected() Then
                Dim enumValue = [Enum].Parse(GetType(KohinoorLegacyCorrectionType), selectedLegacyMode)
                value = CInt(enumValue)
            End If

            If IsTopazSelected() Then
                Dim enumValue = [Enum].Parse(GetType(TopazLegacyCorrectionType), selectedLegacyMode)
                value = CInt(enumValue)
            End If

            Dim cmd = "SetLegacyMode|" & value.ToString()
            Dim rtn = _spectro.Execute(cmd)

            If Not rtn.StartsWith("<00>") Then
                Console.WriteLine(cmd & " -> FAILED!")
            Else
                Console.WriteLine(cmd & " -> SUCCESS!")
            End If
        End If
    End Sub

    Public Sub SetMeasurementTrigger(_spectro As MA3)
        Dim selected As String = selectedMeasurementTrigger
        Dim cmd = "SetOption|Reading_Mode|" & selected

        If Not _spectro.SetOption("Reading_Mode", selected) Then
            Console.WriteLine(cmd & " -> FAILED!")
        Else
            Console.WriteLine(cmd & " -> SUCCESS!")
        End If
    End Sub

    Public Sub SetAveragingOptions(_spectro As MA3)
        If IsKohinoorSelected() OrElse IsTopazSelected() OrElse IsTopazQCSelected() Then
            'Dim mode As String = _view.MainMenuAccordion.ConfigurationPanel.AveragingMode
            Dim mode As String = AveragingMode
            Dim cmd = "SetMeasurementConditionValue|AveragingMode|" & mode
            Dim rtn = _spectro.Execute(cmd)

            If Not rtn.StartsWith("<00>") Then
                Console.WriteLine(cmd & " -> FAILED!")
            Else
                Console.WriteLine(cmd & " -> SUCCESS!")
            End If

            If mode = "AVERAGE" Then
                'Dim numSamples = _view.MainMenuAccordion.ConfigurationPanel.AveragingNumberOfMeasurements
                'cmd = "SetMeasurementConditionValue|AverageNumberOfSamples|" & numSamples
                ' rtn = _spectro.Execute(cmd)

                ''If Not rtn.StartsWith("<00>") Then
                Console.WriteLine(cmd & " -> FAILED!")
                'Else
                'rint(cmd & " -> SUCCESS!")
                'End If
            ElseIf mode = "SMC" Then
                'Dim minSMC = _view.MainMenuAccordion.ConfigurationPanel.MinSMC
                'cmd = "SetMeasurementConditionValue|SmcMinNumberOfSamples|" & minSMC
                'rtn = _spectro.Execute(cmd)

                'If Not rtn.StartsWith("<00>") Then
                'Print(cmd & " -> FAILED!")
                'Else
                'Print(cmd & " -> SUCCESS!")
                'End If

                'Dim maxSMC = _view.MainMenuAccordion.ConfigurationPanel.MaxSMC
                ' cmd = "SetMeasurementConditionValue|SmcMaxNumberOfSamples|" & maxSMC
                'rtn = _spectro.Execute(cmd)

                'If Not rtn.StartsWith("<00>") Then
                'Print(cmd & " -> FAILED!")
                'Else
                'Print(cmd & " -> SUCCESS!")
                'End If
            End If
        End If
    End Sub
    Public Sub SetColorDataOption()
        If IsKohinoorSelected() Then
            Dim colorData = "OFF"
            ' If _view.MainMenuAccordion.ConfigurationPanel.IsLabChDataChecked() Then
            'colorData = "ON"
            'End If
            Dim cmd = "SetMeasurementConditionValue|ColorData|" & colorData
            Dim rtn = _spectro.Execute(cmd)

            If Not rtn.StartsWith("<00>") Then
                Console.WriteLine(cmd & " -> FAILED!")
            Else
                Console.WriteLine(cmd & " -> SUCCESS!")
            End If
        End If
    End Sub
    Public Sub SetImageDataOption()
        If IsKohinoorSelected() Then
            Dim textureImages = "OFF"
            'If _view.MainMenuAccordion.ConfigurationPanel.ImageDataEnabled Then textureImages = "ON"
            Dim cmd = "SetMeasurementConditionValue|TextureImages|" & textureImages
            Dim rtn = _spectro.Execute(cmd)

            If Not rtn.StartsWith("<00>") Then
                Console.WriteLine(cmd & " -> FAILED!")
            Else
                Console.WriteLine(cmd & " -> SUCCESS!")
            End If
        End If
    End Sub

    Public Function isSelectedCoat(ByVal butCoat As Button) As Boolean
        Return butCoat.BackColor = System.Drawing.Color.Green
    End Function
    Public Sub selectCoatButton(ByVal butCoat As Button)
        butCoat.BackColor = System.Drawing.Color.Green
    End Sub
    Public Sub setAsChosenCoatButton(ByVal butCoatSelect As Button, ByVal butCoatUnselect As Button)
        butCoatSelect.BackColor = System.Drawing.Color.Green
        butCoatUnselect.BackColor = System.Drawing.Color.Gray
    End Sub
    Public Sub setAsChosenCoatButtonM(ByVal butCoatSelect As Button, ByVal butCoatUnselect As Button)
        butCoatSelect.BackColor = System.Drawing.Color.Green
        butCoatUnselect.BackColor = System.Drawing.Color.Gray
    End Sub
    Public Function retrieveCoatRecipe(ByVal recipeList As List(Of RecipeDB), ByVal layer As Integer) As List(Of RecipeDB)

        Dim coatRecipeList As New List(Of RecipeDB)
        For i = 0 To recipeList.Count - 1
            If recipeList(i).Layer = layer Then
                coatRecipeList.Add(recipeList(i))
            End If
        Next
        Return coatRecipeList
    End Function

End Module
