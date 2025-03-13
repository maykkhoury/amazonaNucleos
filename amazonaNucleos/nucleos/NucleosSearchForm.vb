Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.ListViewItem
Imports garageApp.XRite
Imports JsonReaderSDKCS

Public Class NucleosSearchForm

#Region "General"

    Private Shared _spectro As MA3 = New MA3()
    Public Shared colorSpectrumCSDevice As ColorSpectrumCS
    Public Shared colorSpectrumCSDeviceList As New List(Of ColorSpectrumCS)
    Private Shared solidLabValueFromDevice As LabValueCS
    Private Shared labValueFromDeviceList As New List(Of LabValueCS)
    Public Shared geometriesInMachine As New List(Of String)
    Public Shared geometriesInMachineForDb As New List(Of String)
    Public Shared machineSpectrumsPerGeometry As New Dictionary(Of String, ColorSpectrumCS)
    Public Shared machineSpectrumsPerGeometryAfterMeasurement As New Dictionary(Of String, ColorSpectrumCS)
    Public Shared solidJob As Boolean = False
    Public Shared effectJob As Boolean = False
    Public Shared sortedbyMeritSolid As List(Of SpectralDB)
    Public Shared selectedSpectralDB As SpectralDB
    Public Shared autoCorrectionList As List(Of SpectralDB)
    Public Shared skipTriCoats As Boolean = False 'temporary
    Public Shared enableAutomaticCorrection As Boolean = True 'temporary
    Public Shared dumpCorrection As Boolean = False

    Public Shared coat As String

    Private Sub NucleosSearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory

        ' File name to create
        Dim fileName As String = "logsNucleos.txt"

        ' Full path of the file
        logFilePath = Path.Combine(exeDirectory, fileName)


        ' Create and write to the file
        File.AppendAllText(logFilePath, "Nucleos debug " & Now & Environment.NewLine)

        ''''enable automatic correction
        ''' ' File name to create
        ''' 
         ' Create and write to the file
        File.AppendAllText(logFilePath, "--enableAutomaticCorrectionFilePath-" & Now & Environment.NewLine)
        Try
            Dim enableAutomaticCorrectionFilePath As String = Path.Combine(exeDirectory, "enableAutomaticCorrection.txt")
            If My.Computer.FileSystem.ReadAllText(enableAutomaticCorrectionFilePath) = "false" Then
                enableAutomaticCorrection = False
            End If
        Catch ex As Exception
            enableAutomaticCorrection = True
        End Try
        File.AppendAllText(logFilePath, "--enableAutomaticCorrectionFilePath=" & enableAutomaticCorrection & " - " & Now & Environment.NewLine)


        getSettingsFromFile()

        '''''
        '''
        cmbCoats.SelectedIndex = 0
        coat = cmbCoats.SelectedItem.ToString
        cmbEffectType.SelectedIndex = 0
        ''''
        'ciClone = CType(CultureInfo.InvariantCulture.Clone(), CultureInfo)
        'ciClone.NumberFormat.NumberDecimalSeparator = "."


        'set the garage pic
        Dim imgPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//logo.jpg"
        Try
            File.AppendAllText(logFilePath, "--try logo.jpg" & Now & Environment.NewLine)


            pictGaragePic.BackgroundImage = Image.FromFile(imgPath)
            pictGaragePic.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception
            File.AppendAllText(logFilePath, "exception" & Environment.NewLine & ex.Message & Environment.NewLine & Now & Environment.NewLine)
        End Try


        'threading
        File.AppendAllText(logFilePath, "--before CheckForIllegalCrossThreadCalls: " & Now & Environment.NewLine)
        Control.CheckForIllegalCrossThreadCalls = False

        File.AppendAllText(logFilePath, "--after CheckForIllegalCrossThreadCalls: " & Now & Environment.NewLine)
        ''''''
        '''
        File.AppendAllText(logFilePath, "--before ConfigureLicensing: " & Now & Environment.NewLine)
        ConfigureLicensing()
        File.AppendAllText(logFilePath, "--after ConfigureLicensing: " & Now & Environment.NewLine)
        SetLookupTablePath()
        File.AppendAllText(logFilePath, "--after SetLookupTablePath: " & Now & Environment.NewLine)
        ' setAssortmentsAndColorants()

        overrideSkin()
        File.AppendAllText(logFilePath, "--after overrideSkin: " & Now & Environment.NewLine)

    End Sub

    Private Sub getSettingsFromFile()
        Try
            ' File name to create
            Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            If File.Exists("settings-resultLimit.txt") Then
                Dim resultLimitFilePath As String = Path.Combine(exeDirectory, "settings-resultLimit.txt")
                ResultLimit = Integer.Parse(File.ReadAllText(resultLimitFilePath))
            End If


            If File.Exists("settings-deltals.txt") Then
                Dim deltalsFilePath As String = Path.Combine(exeDirectory, "settings-deltals.txt")
                DeltaSolid = Integer.Parse(File.ReadAllText(deltalsFilePath))
            End If

            If File.Exists("settings-deltabc.txt") Then
                Dim deltabcFilePath As String = Path.Combine(exeDirectory, "settings-deltabc.txt")
                DeltaEffect = Integer.Parse(File.ReadAllText(deltabcFilePath))
            End If

            If File.Exists("settings-dump-correction.txt") Then
                Dim dumpCorrectionFilePath As String = Path.Combine(exeDirectory, "settings-dump-correction.txt")
                dumpCorrection = Boolean.Parse(File.ReadAllText(dumpCorrectionFilePath))
            End If


            If File.Exists("skipTriCoats.txt") Then
                Dim skipTriCoatsFilePath As String = Path.Combine(exeDirectory, "skipTriCoats.txt")
                skipTriCoats = Boolean.Parse(File.ReadAllText(skipTriCoatsFilePath))
            End If



        Catch ex As Exception
            File.AppendAllText(logFilePath, "error retrieving settings" & vbNewLine & ex.Message & vbNewLine & Now & Environment.NewLine)
        End Try

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
        '''
        enableDisable(False)
        Application.DoEvents()


        coat = cmbCoats.SelectedItem.ToString
        '  MsgBox(solidLabValueFromDevice.L & " " & solidLabValueFromDevice.a & " " & solidLabValueFromDevice.b)

        If coat.ToLower = "ls" Then
            solidJob = True
            effectJob = False
        Else
            solidJob = False
            effectJob = True
        End If


        Dim allColors As List(Of SpectralDB)
        Dim filteredByDelta As List(Of SpectralDB)
        ''effect''
        If coat.ToLower <> "ls" Then
            If cmbEffectType.SelectedItem.ToString.ToLower = "effect" Then
                allColors = getAllColorsEffectTarget()
            ElseIf cmbEffectType.SelectedItem.ToString.ToLower = "solid" Then
                allColors = getAllColorsForSolidTarget()
            Else
                allColors = getAllColorsByEffect(Nothing)
            End If

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

            filteredByDelta = filterByDelta(allColors, labValueMedian, DeltaEffect)
        Else
            'solid'''''
            allColors = getAllColorsByEffect(Nothing)
            filteredByDelta = filterByDelta(allColors, solidLabValueFromDevice, DeltaSolid)
        End If

        sortedbyMeritSolid = sortByMerit(filteredByDelta, colorSpectrumCSDeviceList, coat)

        Dim listCount As Integer = 0
        If sortedbyMeritSolid.Count - 1 <= ResultLimit Then
            listCount = sortedbyMeritSolid.Count - 1
        Else
            listCount = ResultLimit - 1
        End If
        If listCount < 0 Then
            MsgBox("No Trial Colors Measurements Found")
        End If
        For i As Integer = 0 To listCount
            Dim sampleId As String = sortedbyMeritSolid.Item(i).SampleId
            Dim sampleName As String = sortedbyMeritSolid.Item(i).SampleName
            Dim merit As Double = sortedbyMeritSolid.Item(i).tempMeritForSort
            Dim rgbValueCS As RGBValueCS = ColorimetryCS.ToRGB(sortedbyMeritSolid.Item(i).labValue)
            Dim isTricoat As String = "No"
            If sortedbyMeritSolid.Item(i).tricoat Then
                isTricoat = "Yes"
            End If
            'Dim l As Double = Math.Round(sortedbyMeritSolid.Item(i).labValue.L, 2)
            'Dim a As Double = Math.Round(sortedbyMeritSolid.Item(i).labValue.a, 2)
            'Dim b As Double = Math.Round(sortedbyMeritSolid.Item(i).labValue.b, 2)
            'Dim de2000 As Double = sortedbyMeritSolid.Item(i).DeltaE2000
            Dim effect As String = sortedbyMeritSolid.Item(i).effect

            Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(rgbValueCS.R, rgbValueCS.G, rgbValueCS.B)

            Dim tagFile As TagFile = retrieveTagFileBySampleId(sampleId)
            Dim coarseness As String = tagFile.tagCoarseness
            Dim data() As String = {sampleId, sampleName, Math.Round(merit, 2), "", effect, coarseness, isTricoat, ""}

            Dim item = New ListViewItem(data)
            lstvSearchResult.Items.Add(item)
            lstvSearchResult.Items(i).UseItemStyleForSubItems = False
            lstvSearchResult.Items(i).SubItems(7).BackColor = color
            If merit < 2 Then
                lstvSearchResult.Items(i).SubItems(2).ForeColor = System.Drawing.Color.Green
            ElseIf merit < 5 Then
                lstvSearchResult.Items(i).SubItems(2).ForeColor = System.Drawing.Color.Orange
            Else
                lstvSearchResult.Items(i).SubItems(2).ForeColor = System.Drawing.Color.Red
            End If

        Next

        'pour les effets utiliser la meme filter by delta

        enableDisable(True)
        Application.DoEvents()
        initializeThreads()
    End Sub
    Private Sub butListCorrection_Click(sender As Object, e As EventArgs) Handles butListCorrection.Click
        subscribeSamplesForAutoCorrection()
        executeCorrectionsSub()

    End Sub


    Private Sub butSetLab_Click(sender As Object, e As EventArgs) Handles butSetLab.Click
        setLABInDB()
    End Sub

    Private Sub cmbEffectType_SelectedIndexChanged(sender As Object, e As EventArgs)
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
        ''If (selectedSpectralDB.autoCorrectedMerit And selectedSpectralDB.autoCorrectedMeritValue < 1.5) Or selectedSpectralDB.tempMeritForSort < 1.5 Then

        If selectedSpectralDB.tempMeritForSort < 1.5 Then
            btnCorrection.Enabled = False
            btnOriginal.Enabled = False
        Else
            btnCorrection.Enabled = True
            btnOriginal.Enabled = True
        End If
        lbMScoreValue.Text = "0"
        If selectedSpectralDB.autoCorrectedMerit Then
            ''lbOriginalScoreValue.Text = Math.Round(selectedSpectralDB.autoCorrectedMeritValue, 2)
            setScore(Math.Round(selectedSpectralDB.autoCorrectedMeritValue, 2), True)

        Else
            ''lbOriginalScoreValue.Text = Math.Round(selectedSpectralDB.tempMeritForSort, 2)
            setScore(Math.Round(selectedSpectralDB.tempMeritForSort, 2), False)
        End If
        'If Val(lbScoreValue.Text) < 1.5 Then
        'btnMeasure.Visible = False
        'Else
        'btnMeasure.Visible = True
        'End If
        If selectedSpectralDB.autoCorrectedMerit Then
            invokeCorrection()
        End If
    End Sub

    Public Sub setAssortmentsAndColorantsJson()

        Dim jsonFileContent As JsonFileContentCS = GetJsonFileContent(coat)

        m_colorants = jsonFileContent.Colorants
        m_substrates = New List(Of SubstrateCS)() From {
                GetJsonSubstrate(jsonFileContent)
            }


    End Sub

    'old way using bsqlite file'
    Public Sub setAssortmentsAndColorants()
        'If m_colorants Is Nothing Or m_substrates Is Nothing Or m_colorants.Count = 0 Or m_substrates.Count = 0 Then
        ''NucleosDatabaseCS.OpenDatabase("./Amazona_2023-assortments.bcsqlite")
        NucleosDatabaseCS.OpenDatabase("./Amazona_assortments.bcsqlite")

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
    Private correctedBaseCoatRecipe As List(Of RecipeDB)
    Private correctedMidCoatRecipe As List(Of RecipeDB)
    Private trialSampleId As String
    Private trialSpectralDb As SpectralDB
    Private trialEffect As String = "S"

    Private Sub emptyTargets()
        pnTarget1.BackColor = System.Drawing.Color.Transparent
        pnTarget2.BackColor = System.Drawing.Color.Transparent
        pnTarget3.BackColor = System.Drawing.Color.Transparent
        pnTarget4.BackColor = System.Drawing.Color.Transparent
        pnTarget5.BackColor = System.Drawing.Color.Transparent
        pnTarget6.BackColor = System.Drawing.Color.Transparent

    End Sub
    Private Sub emptyDetails()
        emptyDetailsM()

        lbSampleId.Text = ""
        lbOriginalScoreValue.Text = ""
        pnTrial1.BackColor = System.Drawing.Color.Transparent
        pnTrial2.BackColor = System.Drawing.Color.Transparent
        pnTrial3.BackColor = System.Drawing.Color.Transparent
        pnTrial4.BackColor = System.Drawing.Color.Transparent
        pnTrial5.BackColor = System.Drawing.Color.Transparent
        pnTrial6.BackColor = System.Drawing.Color.Transparent
        txtCanSize.Text = "100"
        lbWhiteBg.Visible = False
        lbBlackBg.Visible = False
        butCoat1.Visible = False
        butCoat2.Visible = False
        butCoat1m.Visible = False
        butCoat2m.Visible = False
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
        correctedBaseCoatRecipe = Nothing
        correctedMidCoatRecipe = Nothing

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
        initializeDetailsM()

        ''Me.Text = Me.Text & " (" & coat & ")"

        trialSampleId = lstvSearchResult.SelectedItems.Item(0).SubItems(0).Text
        trialEffect = lstvSearchResult.SelectedItems.Item(0).SubItems(4).Text
        lbSampleId.Text = trialSampleId

        Dim correctedScore As String = lstvSearchResult.SelectedItems.Item(0).SubItems(3).Text
        If correctedScore Is Nothing Or correctedScore = "" Then
            Dim originalScore As String = lstvSearchResult.SelectedItems.Item(0).SubItems(2).Text,
            setScore(originalScore, False)
        Else
            setScore(correctedScore, True)

        End If

        txtCanSize.Text = "100"
        lbWhiteBg.Visible = False
        lbBlackBg.Visible = False
        butCoat1.Visible = False
        butCoat2.Visible = False
        butCoat1m.Visible = False
        butCoat2m.Visible = False

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
        correctedBaseCoatRecipe = Nothing
        correctedMidCoatRecipe = Nothing

        recipeDBList = retrieveRecipeBySampleId(trialSampleId)
        cleanControls()



        Dim trialRGBValue As RGBValueCS = ColorimetryCS.ToRGB(selectedSpectralDB.labValue)
        If coat.ToUpper = "LS" Then 'Or cmbEffectType.Text.ToLower = "unspecified" Then
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
        If recipeList Is Nothing Then
            Exit Sub
        End If
        Dim isTricoat As Boolean = selectedSpectralDB.tricoat

        butCoat1.Visible = isTricoat
        butCoat2.Visible = isTricoat

        Dim recipeUsedList As New List(Of RecipeDB)
        If isTricoat Then
            If isSelectedCoat(butCoat1) Then
                recipeUsedList = retrieveCoatRecipe(recipeList, 1)
            Else
                If isSelectedCoat(butCoat2) Then
                    recipeUsedList = retrieveCoatRecipe(recipeList, 2)
                Else
                    'force select first coat
                    selectCoatButton(butCoat1)
                    recipeUsedList = retrieveCoatRecipe(recipeList, 1)
                End If

            End If
        Else
            recipeUsedList = recipeList
        End If


        showFormulaM(recipeUsedList, isTricoat)


        cleanControls()
        Dim currentTotal As Double = 0
        For i = 0 To recipeUsedList.Count - 1

            currentTotal += recipeUsedList.Item(i).Quantity

            Dim lbColorCodeTmp As New Label With {
                .Text = recipeUsedList.Item(i).Component
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
                .Text = Math.Round(recipeUsedList.Item(i).Quantity, 2)
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
            If Math.Round(recipeUsedList.Item(i).CorrectedDifferenceValue, 2) > 0 Then
                correctedValue = "+" & Math.Round(recipeUsedList.Item(i).CorrectedDifferenceValue, 2)
                lbCorrectionTmp.ForeColor = System.Drawing.Color.Green

            Else
                If recipeUsedList.Item(i).CorrectedDifferenceValue = 0 Then
                    correctedValue = "-"
                Else
                    correctedValue = Math.Round(recipeUsedList.Item(i).CorrectedDifferenceValue, 2)
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

            Dim colorImgPath = retrieveColorImgPath(recipeUsedList.Item(i).Component)
            pbxColorTmp.ImageLocation = System.AppDomain.CurrentDomain.BaseDirectory() & "//colors/" & colorImgPath
            pnlResult.Controls.Add(pbxColorTmp)

        Next
    End Sub
    Private Sub cleanControls()
        Dim controlToDispose As New List(Of Control)

        For i = 0 To pnlResult.Controls.Count - 1
            If pnlResult.Controls.Item(i).Name <> butCoat1.Name And pnlResult.Controls.Item(i).Name <> butCoat2.Name And pnlResult.Controls.Item(i).Name <> txtCanSize.Name And pnlResult.Controls.Item(i).Name <> lbG.Name And pnlResult.Controls.Item(i).Name <> lbCanSize.Name And pnlResult.Controls.Item(i).Name <> lbColor.Name And pnlResult.Controls.Item(i).Name <> lbQuantity.Name And pnlResult.Controls.Item(i).Name <> lbAccumulation.Name And pnlResult.Controls.Item(i).Name <> lbCorrection.Name Then
                controlToDispose.Add(pnlResult.Controls.Item(i))
            End If
        Next
        For i = 0 To controlToDispose.Count - 1
            controlToDispose.Item(i).Dispose()
        Next
    End Sub


    Private Function doAutoCorrectionGetNewScore(thisTrialSampleId As String, thisRecipeDBList As List(Of RecipeDB), ByRef correctedFormulas As FormulaCS, isTricoat As Boolean) As Double
        setAssortmentsAndColorants()

        '''
        'Setting the trial Sample
        Dim trialSample As New SampleCS()

        trialSample.Name = thisTrialSampleId
        trialSample.RelativeThickness = 1.0
        'trialSample.Substrate = GetSubstrate(m_substrates, "LENETA WHITE")

        ' Append text to the file
        File.AppendAllText(logFilePath, Now & ": " & thisTrialSampleId & Environment.NewLine)

        Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(thisTrialSampleId, geometriesInMachine, coat)
        Dim trialColorSpectrumList As New List(Of ColorSpectrumCS)

        For i = 0 To trialColorSpectralDBList.Count - 1
            ' Append text to the file
            File.AppendAllText(logFilePath, "trialColorSpectralDBList of " & i & ": " & trialColorSpectralDBList.Item(i).SampleId & " - " & trialColorSpectralDBList.Item(i).Substrate & Environment.NewLine)

            trialColorSpectrumList.Add(trialColorSpectralDBList.Item(i).colorSpectrumCS)
        Next


        If trialColorSpectralDBList.Count = 0 Then
            MsgBox("No Spectral for this trial: " & thisTrialSampleId)
            Exit Function
        End If
        Dim substrateStr As String = trialColorSpectralDBList.Item(0).Substrate

        ' Append text to the file
        File.AppendAllText(logFilePath, substrateStr & Environment.NewLine)



        Dim substrate As SubstrateCS = GetSubstrate(m_substrates, substrateStr)
        trialSample.Substrate = substrate


        Dim trialMeasurementCSList As New List(Of MeasurementCS)
        trialMeasurementCSList.Add(New MeasurementCS(trialColorSpectrumList))
        trialSample.Measurements = trialMeasurementCSList


        'colorant settings based on if tricoat
        Dim colorants As List(Of ColorantCS)
        ''tricoat checks
        If isTricoat Then
            ' Append text to the file
            File.AppendAllText(logFilePath, Now & ": isTricoat " & isTricoat & Environment.NewLine)

            colorants = m_colorants

            Dim recipeCoat1List As List(Of RecipeDB) = retrieveCoatRecipe(thisRecipeDBList, 1)
            Dim recipeCoat2List As List(Of RecipeDB) = retrieveCoatRecipe(thisRecipeDBList, 2)

            'basecoatFormula
            Dim basecoatFormulaComponents As New List(Of FormulaComponentCS)
            For i = 0 To recipeCoat1List.Count - 1

                Dim colorant As ColorantCS
                Try
                    colorant = GetColorant(m_colorants, recipeCoat1List.Item(i).Component)

                    If colorant IsNot Nothing Then
                        Dim formulaComponentCS As New FormulaComponentCS(colorant, recipeCoat1List.Item(i).Quantity)

                        ' Append text to the file
                        File.AppendAllText(logFilePath, Now & ": recipeCoat1List.Item(" & i & ").Component " & recipeCoat1List.Item(i).Component & Environment.NewLine)
                        File.AppendAllText(logFilePath, Now & ": recipeCoat1List.Item(" & i & ").Quantity " & recipeCoat1List.Item(i).Quantity & Environment.NewLine)


                        basecoatFormulaComponents.Add(formulaComponentCS)
                    End If

                Catch ex As Exception
                    MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                    Return -1
                End Try



            Next
            Dim tricoatFormulaBaseCoat As New FormulaCS(basecoatFormulaComponents)
            ''''''
            '''
            'midcoatFormula
            Dim midcoatFormulaComponents As New List(Of FormulaComponentCS)
            For i = 0 To recipeCoat2List.Count - 1
                Dim colorant As ColorantCS
                Try
                    colorant = GetColorant(m_colorants, recipeCoat2List.Item(i).Component)
                    If colorant IsNot Nothing Then
                        Dim formulaComponentCS As New FormulaComponentCS(colorant, recipeCoat2List.Item(i).Quantity)
                        File.AppendAllText(logFilePath, Now & ": recipeCoat2List.Item(" & i & ").Component " & recipeCoat2List.Item(i).Component & Environment.NewLine)
                        File.AppendAllText(logFilePath, Now & ": recipeCoat2List.Item(" & i & ").Component " & recipeCoat2List.Item(i).Component & Environment.NewLine)
                        midcoatFormulaComponents.Add(formulaComponentCS)

                    End If

                Catch ex As Exception
                    MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                    Return -1
                End Try

            Next
            Dim tricoatFormulaMidCoat As New FormulaCS(midcoatFormulaComponents)
            ''''''
            Dim tricoatName As String = trialSample.Name
            Dim tricoatMeasurements As List(Of MeasurementCS) = trialSample.Measurements
            Dim tricoatSubstrate As SubstrateCS = trialSample.Substrate

            trialSample = New TricoatSampleCS(tricoatName, tricoatMeasurements, tricoatSubstrate, tricoatFormulaBaseCoat, tricoatFormulaMidCoat, 1.0, 1.0)

        Else

            Dim trialFormulaComponentCSList As New List(Of FormulaComponentCS)
            For i = 0 To thisRecipeDBList.Count - 1
                Dim colorant As ColorantCS
                Try
                    colorant = GetColorant(m_colorants, thisRecipeDBList.Item(i).Component)
                    If colorant IsNot Nothing Then
                        Dim formulaComponentCS As New FormulaComponentCS(colorant, thisRecipeDBList.Item(i).Quantity)

                        File.AppendAllText(logFilePath, Now & ": thisRecipeDBList.Item(" & i & ").Component " & thisRecipeDBList.Item(i).Component & Environment.NewLine)
                        File.AppendAllText(logFilePath, Now & ": thisRecipeDBList.Item(" & i & ").Component " & thisRecipeDBList.Item(i).Component & Environment.NewLine)

                        trialFormulaComponentCSList.Add(formulaComponentCS)
                    End If

                Catch ex As Exception
                    MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                    Return Nothing
                End Try
            Next


            Dim trialFormulaCS As New FormulaCS(trialFormulaComponentCSList)

            trialSample.Formula = trialFormulaCS
            colorants = trialSample.Formula.GetColorants()
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------------


        ''''''setting the target Sample
        Dim targetSample As New SampleCS()
        targetSample.Name = txtChosenJob.Text
        '' Dim targetMeasurements As List(Of MeasurementCS)
        Dim targetColorSpectrumCSList As List(Of ColorSpectrumCS) = colorSpectrumCSDeviceList
        Dim targetMeasurementCSList As New List(Of MeasurementCS)
        targetMeasurementCSList.Add(New MeasurementCS(targetColorSpectrumCSList))
        targetSample.Measurements = targetMeasurementCSList
        targetSample.Substrate = substrate
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Correction start
        'setting the correction settings
        Dim correctionSettings As CorrectionSettingsCS = CorrectionSettingsCS.CreateNewSettings(ResinRestrictionTypeCS.None, ColorOnlyCorrectionModeCS.[On])


        Dim colorantConstraints As List(Of ColorantConstraintCS) = New List(Of ColorantConstraintCS)()


        'executing the correction
        Dim correctionResults As List(Of MatchResultCS) ' = EngineCS.CalculateCorrection(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, targetSample, trialSample.Formula.GetColorants(), trialSample, correctionSettings, colorantConstraints, modelSettingsCS:=Nothing, metricSettingsCS:=Nothing)
        Try
            If dumpCorrection Then
                EngineCS.EnableJsonDumps(AppDomain.CurrentDomain.BaseDirectory)
            End If

            correctionResults = EngineCS.CalculateCorrection(
                   IndustryTypeCS.Effects,
                   CalculationMethodCS.LookupTable,
                   UnitModeCS.Weight,
                   targetSample,
                   colorants,
                   trialSample,
                   correctionSettings,
                   colorantConstraints,
                   metricSettingsCS:=Nothing,
                   modelSettingsCS:=Nothing)
        Catch ex As Exception
            MsgBox("Problem correcting " & thisTrialSampleId, MsgBoxStyle.Exclamation)
            Return -1
        End Try
        File.AppendAllText(logFilePath, Now & ": correctionResults.Count" & correctionResults.Count & Environment.NewLine)

        Dim components As List(Of FormulaComponentCS) = correctionResults(0).Sample.Formula.Components
        correctedFormulas = New FormulaCS(components)

        File.AppendAllText(logFilePath, Now & ": correctionResults.Item(0).Score" & correctionResults.Item(0).Score & Environment.NewLine)
        Return Math.Round(correctionResults.Item(0).Score, 2)

    End Function

    Private Function doCorrection(thisTrialSampleId As String, thisRecipeDBList As List(Of RecipeDB)) As List(Of RecipeDB)
        setAssortmentsAndColorants()

        '''
        'Setting the trial Sample
        Dim trialSample As New SampleCS()

        trialSample.Name = thisTrialSampleId
        trialSample.RelativeThickness = 1.0
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


        Dim trialFormulaComponentCSListRemoved As New List(Of RecipeDB)
        Dim trialBaseCoatComponentCSListRemoved As New List(Of RecipeDB)
        Dim trialMidCoatComponentCSListRemoved As New List(Of RecipeDB)

        Dim recipeCoat1List As List(Of RecipeDB)
        Dim recipeCoat2List As List(Of RecipeDB)

        'colorant settings based on if tricoat
        Dim colorants As List(Of ColorantCS)
        ''tricoat checks
        Dim isTricoat As Boolean = selectedSpectralDB.tricoat
        If isTricoat Then
            colorants = m_colorants

            recipeCoat1List = retrieveCoatRecipe(thisRecipeDBList, 1)
            recipeCoat2List = retrieveCoatRecipe(thisRecipeDBList, 2)

            'basecoatFormula
            Dim basecoatFormulaComponents As New List(Of FormulaComponentCS)
            For i = 0 To recipeCoat1List.Count - 1
                Try
                    Dim colorant As ColorantCS = GetColorant(m_colorants, recipeCoat1List.Item(i).Component)
                    If colorant IsNot Nothing Then
                        Dim formulaComponentCS As New FormulaComponentCS(colorant, recipeCoat1List.Item(i).Quantity)
                        basecoatFormulaComponents.Add(formulaComponentCS)
                    Else
                        trialBaseCoatComponentCSListRemoved.Add(recipeCoat1List.Item(i))
                    End If
                Catch ex As Exception
                    MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                    Return Nothing
                End Try
            Next
            Dim tricoatFormulaBaseCoat As New FormulaCS(basecoatFormulaComponents)
            ''''''
            '''
            'midcoatFormula
            Dim midcoatFormulaComponents As New List(Of FormulaComponentCS)
            For i = 0 To recipeCoat2List.Count - 1
                Try
                    Dim colorant As ColorantCS = GetColorant(m_colorants, recipeCoat2List.Item(i).Component)
                    If colorant IsNot Nothing Then
                        Dim formulaComponentCS As New FormulaComponentCS(colorant, recipeCoat2List.Item(i).Quantity)
                        midcoatFormulaComponents.Add(formulaComponentCS)
                    Else
                        trialMidCoatComponentCSListRemoved.Add(recipeCoat2List.Item(i))
                    End If
                Catch ex As Exception
                    MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                    Return Nothing
                End Try
            Next
            Dim tricoatFormulaMidCoat As New FormulaCS(midcoatFormulaComponents)
            ''''''
            Dim tricoatName As String = trialSample.Name
            Dim tricoatMeasurements As List(Of MeasurementCS) = trialSample.Measurements
            Dim tricoatSubstrate As SubstrateCS = trialSample.Substrate

            trialSample = New TricoatSampleCS(tricoatName, tricoatMeasurements, tricoatSubstrate, tricoatFormulaBaseCoat, tricoatFormulaMidCoat, 1.0, 1.0)

        Else

            Dim trialFormulaComponentCSList As New List(Of FormulaComponentCS)


            For i = 0 To thisRecipeDBList.Count - 1
                Try
                    Dim colorant As ColorantCS = GetColorant(m_colorants, thisRecipeDBList.Item(i).Component)
                    If colorant IsNot Nothing Then
                        Dim formulaComponentCS As New FormulaComponentCS(colorant, thisRecipeDBList.Item(i).Quantity)
                        trialFormulaComponentCSList.Add(formulaComponentCS)
                    Else
                        trialFormulaComponentCSListRemoved.Add(thisRecipeDBList.Item(i))
                    End If

                Catch ex As Exception
                    MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                    Return Nothing
                End Try
            Next
            Dim trialFormulaCS As New FormulaCS(trialFormulaComponentCSList)

            trialSample.Formula = trialFormulaCS
            colorants = trialSample.Formula.GetColorants()

        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------------

        '''
        'Setting the target Sample
        Dim targetSample As New SampleCS()
        targetSample.Name = txtChosenJob.Text
        Dim targetColorSpectrumCSList As List(Of ColorSpectrumCS) = colorSpectrumCSDeviceList
        Dim targetMeasurementCSList As New List(Of MeasurementCS)
        targetMeasurementCSList.Add(New MeasurementCS(targetColorSpectrumCSList))
        targetSample.Measurements = targetMeasurementCSList
        targetSample.Substrate = substrate
        '------------------------------------------------------------------------------------------------------------------------------



        'Correction start
        'setting the correction settings
        Dim correctionSettings As CorrectionSettingsCS = CorrectionSettingsCS.CreateNewSettings(ResinRestrictionTypeCS.None, ColorOnlyCorrectionModeCS.[On])


        Dim recipeList As List(Of RecipeDB)
        Dim recipeMidCoatList As List(Of RecipeDB)

        Dim correctionResults As List(Of MatchResultCS)

        Dim colorantConstraints As List(Of ColorantConstraintCS) = New List(Of ColorantConstraintCS)()

        Try

            'print all colorants:
            For i = 0 To m_colorants.Count - 1
                Dim c As ColorantCS = m_colorants.Item(i)
                Console.WriteLine("m_colorants(" & i & ")=" & c.Name)
            Next


            'executing the correction
            For i = 0 To trialSample.Formula.Components.Count - 1
                Dim c As FormulaComponentCS = trialSample.Formula.Components.Item(i)
                Console.WriteLine("trialSample - component" & i & ", name=" & c.Colorant.Name & ", value=" & c.Amount)
            Next

            For i = 0 To targetSample.Measurements.Count - 1
                Dim m As MeasurementCS = targetSample.Measurements.Item(i)
                Dim colorSpectrumCSList As List(Of ColorSpectrumCS) = m.ColorSpectra
                For j = 0 To colorSpectrumCSList.Count - 1
                    Dim c As ColorSpectrumCS = colorSpectrumCSList.Item(j)
                    Console.WriteLine("targetSample - spectral " & j & ", geometry=" & c.Geometry)
                    For k = 0 To c.SpectralValues.Count - 1
                        Dim sv As Double = c.SpectralValues.Item(k)
                        Console.WriteLine("targetSample - spectralValue " & k & ", value=" & sv)

                    Next
                Next

            Next

            For i = 0 To trialSample.Measurements.Count - 1
                Dim m As MeasurementCS = trialSample.Measurements.Item(i)
                Dim colorSpectrumCSList As List(Of ColorSpectrumCS) = m.ColorSpectra
                For j = 0 To colorSpectrumCSList.Count - 1
                    Dim c As ColorSpectrumCS = colorSpectrumCSList.Item(j)
                    Console.WriteLine("trialSample - spectral " & j & ", geometry=" & c.Geometry)
                    For k = 0 To c.SpectralValues.Count - 1
                        Dim sv As Double = c.SpectralValues.Item(k)
                        Console.WriteLine("trialSample - spectralValue " & k & ", value=" & sv)

                    Next
                Next

            Next
            If dumpCorrection Then

                EngineCS.EnableJsonDumps(AppDomain.CurrentDomain.BaseDirectory)
            End If

            correctionResults = EngineCS.CalculateCorrection(
                   IndustryTypeCS.Effects,
                   CalculationMethodCS.LookupTable,
                   UnitModeCS.Weight,
                   targetSample,
                   colorants,
                   trialSample,
                   correctionSettings,
                   colorantConstraints,
                   metricSettingsCS:=Nothing,
                   modelSettingsCS:=Nothing)
            If isTricoat Then
                recipeList = retrieveBaseCoatRecipeFromCorrection(correctionResults, thisRecipeDBList)
                recipeMidCoatList = retrieveMidCoatRecipeFromCorrection(correctionResults, thisRecipeDBList)



                Dim baseCoatFormulaComponentCSList As List(Of FormulaComponentCS) = New List(Of FormulaComponentCS)
                For i = 0 To recipeList.Count - 1
                    Try
                        Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, recipeList.Item(i).Component), recipeList.Item(i).Quantity)
                        baseCoatFormulaComponentCSList.Add(formulaComponentCS)
                    Catch ex As Exception
                        MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                        Return Nothing
                    End Try
                Next
                Dim baseCoatformulaCS As FormulaCS = New FormulaCS(baseCoatFormulaComponentCSList)


                Dim midCoatFormulaComponentCSList As List(Of FormulaComponentCS) = New List(Of FormulaComponentCS)
                For i = 0 To recipeMidCoatList.Count - 1
                    Try
                        Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, recipeMidCoatList.Item(i).Component), recipeMidCoatList.Item(i).Quantity)
                        midCoatFormulaComponentCSList.Add(formulaComponentCS)
                    Catch ex As Exception
                        MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                        Return Nothing
                    End Try
                Next
                Dim midCoatformulaCS As FormulaCS = New FormulaCS(midCoatFormulaComponentCSList)


                trialSample = New TricoatSampleCS(trialSample.Name, trialSample.Measurements, trialSample.Substrate, baseCoatformulaCS, midCoatformulaCS, 1.0, 1.0)


            Else
                recipeList = retrieveRecipeFromCorrection(correctionResults, thisRecipeDBList)


                Dim formulaComponentCSList As List(Of FormulaComponentCS) = New List(Of FormulaComponentCS)
                For i = 0 To recipeList.Count - 1
                    Try
                        Dim formulaComponentCS As New FormulaComponentCS(GetColorant(m_colorants, recipeList.Item(i).Component), recipeList.Item(i).Quantity)
                        formulaComponentCSList.Add(formulaComponentCS)
                    Catch ex As Exception
                        MsgBox("Correction Stopped!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                        Return Nothing
                    End Try
                Next
                Dim formulaCS As FormulaCS = New FormulaCS(formulaComponentCSList)
                trialSample.Formula = formulaCS
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Function
        End Try


        'set the corrected score
        setScore(Math.Round(correctionResults.Item(0).Score, 2), True)
        ''lbOriginalScoreValue.Text = Math.Round(correctionResults.Item(0).Score, 2)
        ' lbScoreValue.Text = correctionResults.Item(0).Score

        Dim predictedMeasurements As List(Of MeasurementCS)
        Try
            'Anaylising correction results for measurements and get colors RGBs
            predictedMeasurements = EngineCS.PredictMeasurements(IndustryTypeCS.Effects, CalculationMethodCS.LookupTable, UnitModeCS.Weight, trialSample, modelSettingsCS:=Nothing, metricSettingsCS:=Nothing)
        Catch ex As Exception
            MsgBox("Error Predicting measurements" & vbNewLine & "Nucleos error msg: " & ex.Message, MsgBoxStyle.Exclamation)
            Exit Function
        End Try
        Dim colorSpectrum As ColorSpectrumCS
        If trialEffect.ToUpper = "2K" Then
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

        If isTricoat Then

            ''re add for basecoat

            ''get initial total after correction before re addding the missing colorants
            Dim originalTotal As Double = recipeList.Sum(Function(recipe) recipe.Quantity)

            For Each recipe As RecipeDB In trialBaseCoatComponentCSListRemoved
                If recipe.Component.EndsWith("4002") Then
                    recipeList = recipeList.Prepend(recipe).ToList()
                Else
                    recipeList.Add(recipe)
                End If

            Next

            recipeList = returnToOriginalTotal(recipeList, originalTotal)

            recipeList = getRecipeDifferences(recipeList, recipeCoat1List)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''re add for midcoat
            '''
            originalTotal = recipeMidCoatList.Sum(Function(recipe) recipe.Quantity)

            For Each recipe As RecipeDB In trialMidCoatComponentCSListRemoved
                If recipe.Component.EndsWith("4002") Then
                    recipeMidCoatList = recipeMidCoatList.Prepend(recipe).ToList()
                Else
                    recipeMidCoatList.Add(recipe)
                End If

            Next

            recipeMidCoatList = returnToOriginalTotal(recipeMidCoatList, originalTotal)

            recipeMidCoatList = getRecipeDifferences(recipeMidCoatList, recipeCoat2List)


            ''''''''''''''''
            '''mix both

            recipeList.AddRange(recipeMidCoatList)
        Else

            ''get initial total after correction before re addding the missing colorants
            Dim originalTotal As Double = recipeList.Sum(Function(recipe) recipe.Quantity)

            For Each recipe As RecipeDB In trialFormulaComponentCSListRemoved
                If recipe.Component.EndsWith("4002") Then
                    recipeList = recipeList.Prepend(recipe).ToList()
                Else
                    recipeList.Add(recipe)
                End If

            Next

            recipeList = returnToOriginalTotal(recipeList, originalTotal)

            recipeList = getRecipeDifferences(recipeList, thisRecipeDBList)


        End If


        Return recipeList

    End Function

    Private Function returnToOriginalTotal(recipeList As List(Of RecipeDB), originalTotal As Double) As List(Of RecipeDB)
        ' Calculer la somme actuelle des quantités
        Dim currentTotal As Double = recipeList.Sum(Function(recipe) recipe.Quantity)

        ' Éviter une division par zéro
        If currentTotal = 0 Then
            Throw New InvalidOperationException("La somme des quantités est égale à zéro, ajustement impossible.")
        End If

        ' Appliquer la règle de trois pour ajuster chaque quantité
        Dim adjustedList As New List(Of RecipeDB)

        For Each recipe As RecipeDB In recipeList
            Dim adjustedRecipe As New RecipeDB With {
            .rowId = recipe.rowId,
            .SampleID = recipe.SampleID,
            .Layer = recipe.Layer,
            .Component = recipe.Component,
            .Quantity = (recipe.Quantity / currentTotal) * originalTotal, ' Ajustement proportionnel
            .CorrectedDifferenceValue = recipe.CorrectedDifferenceValue
        }
            adjustedList.Add(adjustedRecipe)
        Next

        Return adjustedList
    End Function


    Private Sub setScore(ByVal score As Decimal, ByVal isAutocorrected As Boolean)
        If isAutocorrected Then
            lbCorrectedScore.Visible = True
            lbCorrectedScoreValue.Visible = True
            lbOriginalScore.Visible = False
            lbOriginalScoreValue.Visible = False
            lbCorrectedScoreValue.Text = score
        Else
            lbCorrectedScore.Visible = False
            lbCorrectedScoreValue.Visible = False
            lbOriginalScore.Visible = True
            lbOriginalScoreValue.Visible = True
            lbOriginalScoreValue.Text = score

        End If
    End Sub
    Private Sub invokeCorrection()
        Dim recipeList As List(Of RecipeDB) = doCorrection(trialSampleId, recipeDBList)
        correctedRecipe = recipeList
        correctedBaseCoatRecipe = Nothing
        correctedMidCoatRecipe = Nothing

        lbWhiteBg.Visible = True
        lbBlackBg.Visible = True
        ' If Val(lbScoreValue.Text) <1.5 Then
        ' btnMeasure.Visible = False
        ' Else
        ' btnMeasure.Visible = True
        ' End If
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
        ' btnMeasure.Visible = False
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

        'hide corrected score labels
        lbCorrectedScore.Visible = False
        lbCorrectedScoreValue.Visible = False

        'show original score labels
        lbOriginalScore.Visible = True
        lbOriginalScoreValue.Visible = True
        lbOriginalScoreValue.Text = lstvSearchResult.SelectedItems(0).SubItems(2).Text
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
            Dim recipeToUse As List(Of RecipeDB) = recipeDBList
            If Not correctedRecipe Is Nothing Then
                recipeToUse = correctedRecipe
            End If
            Dim accumulation As Double = 0
            For i = 0 To basicColorCount - 1

                Dim lbQuantityTmp As Label = pnlResult.Controls.Find(lbQuantity.Name & i, True)(0)
                Dim originalValue As Double = recipeToUse.Item(i).Quantity
                Dim newValue As Double = Math.Round(originalValue * fraction, 2)
                lbQuantityTmp.Text = newValue

                accumulation += newValue
                Dim lbAccumulationTmp As Label = pnlResult.Controls.Find(lbAccumulation.Name & i, True)(0)
                lbAccumulationTmp.Text = accumulation

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



    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        tbControl.SelectTab(0)
    End Sub
    Private Sub doMeasure()

        If Not _spectro.isConnected() Then
            _spectro.Connect()
        End If

        SetLegacyMode(_spectro)
        SetMeasurementTrigger(_spectro)
        If Not selectedMeasurementTrigger = "Software" Then
            SetAveragingOptions(_spectro)
        End If
        If Not _spectro.Measure() Then
            Console.WriteLine(_spectro.GetLastErrorString())
        ElseIf _spectro.IsDataReady Then
            setSpectralDataAndSetGeometriesUsedAfterMeasurement()
            Dim targetColorSpectrumList As New List(Of ColorSpectrumCS) 'new measurement
            Dim trialColorSpectrumList As New List(Of ColorSpectrumCS) 'initial job measurement

            For i = 0 To geometriesInMachine.Count - 1
                Dim geometry As String = geometriesInMachine.Item(i)
                Dim thisColorSpectrumCSDevice As ColorSpectrumCS = machineSpectrumsPerGeometryAfterMeasurement.Item(geometry)
                targetColorSpectrumList.Add(thisColorSpectrumCSDevice)
            Next


            For i = 0 To geometriesInMachine.Count - 1
                Dim geometry As String = geometriesInMachine.Item(i)
                Dim thisColorSpectrumCSDevice As ColorSpectrumCS = machineSpectrumsPerGeometry.Item(geometry)
                trialColorSpectrumList.Add(thisColorSpectrumCSDevice)
            Next

            'USe the initial device spectral
            Dim mertiAfterMeasure As Double = calculateMerit(targetColorSpectrumList, trialColorSpectrumList)
            lbMScoreValue.Text = Math.Round(mertiAfterMeasure, 2)

            tbControl.SelectTab(2)

            MsgBox("Measurement complete. Check the measurement score value.")
        End If

    End Sub
    Private Sub btnMeasure_Click(sender As Object, e As EventArgs) Handles btnMeasure.Click
        doMeasure()

    End Sub

    Private Sub btnRemeasure_Click(sender As Object, e As EventArgs) Handles btnRemeasure.Click
        doMeasure()

    End Sub

    Private Sub btnBackFromM_Click(sender As Object, e As EventArgs) Handles btnBackFromM.Click
        tbControl.SelectTab(1)
    End Sub

    Private Sub butCoat1_Click(sender As Object, e As EventArgs) Handles butCoat1.Click, butCoat1m.Click
        Dim alreadySelected As Boolean = isSelectedCoat(butCoat1)
        If Not alreadySelected Then
            setAsChosenCoatButton(butCoat1, butCoat2)
            setAsChosenCoatButton(butCoat1m, butCoat2m)
            If Not correctedRecipe Is Nothing Then
                showFormula(correctedRecipe)
            Else
                showFormula(recipeDBList)
            End If
        End If

    End Sub

    Private Sub butCoat2_Click(sender As Object, e As EventArgs) Handles butCoat2.Click, butCoat2m.Click
        Dim alreadySelected As Boolean = isSelectedCoat(butCoat2)
        If Not alreadySelected Then
            setAsChosenCoatButton(butCoat2, butCoat1)
            setAsChosenCoatButton(butCoat2m, butCoat1m)
            If Not correctedRecipe Is Nothing Then
                showFormula(correctedRecipe)
            Else
                showFormula(recipeDBList)
            End If
        End If
    End Sub


#End Region

#Region "Measurement"

    Private Sub emptyDetailsM()
        lbSampleIdM.Text = ""
        lbOriginalScoreValue.Text = ""


        correctedRecipe = Nothing

        cleanControlsM()
    End Sub
    Private Sub initializeDetailsM()

        trialSampleId = lstvSearchResult.SelectedItems.Item(0).SubItems(0).Text
        trialEffect = lstvSearchResult.SelectedItems.Item(0).SubItems(4).Text
        lbSampleIdM.Text = trialSampleId

        Dim correctedScore As String = lstvSearchResult.SelectedItems.Item(0).SubItems(3).Text
        If correctedScore Is Nothing Or correctedScore = "" Then
            Dim originalScore As String = lstvSearchResult.SelectedItems.Item(0).SubItems(2).Text,
            setScore(originalScore, False)
        Else
            setScore(correctedScore, True)

        End If

        '' lbOriginalScoreValue.Text = lstvSearchResult.SelectedItems.Item(0).SubItems(3).Text

        txtCanSizeM.Text = "100"


        correctedRecipe = Nothing
        recipeDBList = retrieveRecipeBySampleId(trialSampleId)
        cleanControlsM()


    End Sub

    Private Sub showFormulaM(recipeList As List(Of RecipeDB), isTricoat As Boolean)
        cleanControlsM()
        If recipeList Is Nothing Then
            Exit Sub
        End If
        butCoat1m.Visible = isTricoat
        butCoat2m.Visible = isTricoat
        Dim currentTotal As Double = 0
        For i = 0 To recipeList.Count - 1

            currentTotal += recipeList.Item(i).Quantity

            Dim lbColorCodeTmp As New Label With {
                .Text = recipeList.Item(i).Component
            }
            lbColorCodeTmp.Name = lbcolorM.Name & i
            lbColorCodeTmp.Anchor = lbcolorM.Anchor
            lbColorCodeTmp.Left = lbcolorM.Left
            lbColorCodeTmp.Top = lbcolorM.Top + (i * 30) + 50
            Dim lbColorFont As New Font(lbcolorM.Font, FontStyle.Regular)
            lbColorCodeTmp.Font = lbColorFont
            lbColorCodeTmp.BorderStyle = BorderStyle.FixedSingle
            lbColorCodeTmp.Width = 100

            ''lbColorCodeTmp.BackColor = System.Drawing.Color.Blue
            ''MsgBox(lbColorCodeTmp.Text)
            pnlResultM.Controls.Add(lbColorCodeTmp)


            Dim lbQuantityTmp As New Label With {
                .Text = Math.Round(recipeList.Item(i).Quantity, 2)
            }
            lbQuantityTmp.Name = lbQuantityM.Name & i
            lbQuantityTmp.Anchor = lbQuantityM.Anchor
            lbQuantityTmp.Left = lbQuantityM.Left
            lbQuantityTmp.Top = lbQuantityM.Top + (i * 30) + 50
            Dim lbQuantityFont As New Font(lbQuantityM.Font, FontStyle.Regular)
            lbQuantityTmp.Font = lbQuantityFont
            lbQuantityTmp.BorderStyle = BorderStyle.FixedSingle
            lbQuantityTmp.Width = 100
            pnlResultM.Controls.Add(lbQuantityTmp)

            Dim lbAccumulationTmp As New Label With {
                .Text = Math.Round(currentTotal, 2)
            }
            lbAccumulationTmp.Name = lbAccumulationM.Name & i
            lbAccumulationTmp.Anchor = lbAccumulationM.Anchor
            lbAccumulationTmp.Left = lbAccumulationM.Left
            lbAccumulationTmp.Top = lbAccumulationM.Top + (i * 30) + 50
            Dim lbAccumulationFont As New Font(lbAccumulationM.Font, FontStyle.Regular)
            lbAccumulationTmp.Font = lbAccumulationFont
            lbAccumulationTmp.BorderStyle = BorderStyle.FixedSingle
            lbAccumulationTmp.Width = 100
            pnlResultM.Controls.Add(lbAccumulationTmp)


            Dim lbCorrectionTmp As New Label

            Dim correctedValue As String
            If Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2) > 0 Then
                correctedValue = "+" & Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2)
                lbCorrectionTmp.ForeColor = System.Drawing.Color.Green

            Else
                If recipeList.Item(i).CorrectedDifferenceValue = 0 Then
                    correctedValue = "-"
                Else
                    correctedValue = Math.Round(recipeList.Item(i).CorrectedDifferenceValue, 2)
                    lbCorrectionTmp.ForeColor = System.Drawing.Color.DarkBlue
                End If
            End If


            lbCorrectionTmp.Text = correctedValue
            lbCorrectionTmp.Name = lbCorrectionM.Name & i
            lbCorrectionTmp.Anchor = lbCorrectionM.Anchor
            lbCorrectionTmp.Left = lbCorrectionM.Left
            lbCorrectionTmp.Top = lbCorrectionM.Top + (i * 30) + 50
            Dim lbCorrectionFont As New Font(lbCorrectionM.Font, FontStyle.Regular)
            lbCorrectionTmp.Font = lbCorrectionFont

            pnlResultM.Controls.Add(lbCorrectionTmp)



            Dim pbxColorTmp As New PictureBox
            pbxColorTmp.Name = "pbxColorTmpM" & i
            pbxColorTmp.Anchor = lbColorCodeTmp.Anchor
            pbxColorTmp.Left = lbColorCodeTmp.Left - 50
            pbxColorTmp.Top = lbColorCodeTmp.Top
            pbxColorTmp.Width = 45
            pbxColorTmp.Height = lbColorCodeTmp.Height

            Dim colorImgPath = retrieveColorImgPath(recipeList.Item(i).Component)
            pbxColorTmp.ImageLocation = System.AppDomain.CurrentDomain.BaseDirectory() & "//colors/" & colorImgPath
            pnlResultM.Controls.Add(pbxColorTmp)

        Next
    End Sub

    Private Sub cleanControlsM()
        Dim controlToDispose As New List(Of Control)

        For i = 0 To pnlResultM.Controls.Count - 1
            If pnlResultM.Controls.Item(i).Name <> butCoat1m.Name And pnlResultM.Controls.Item(i).Name <> butCoat2m.Name And pnlResultM.Controls.Item(i).Name <> txtCanSizeM.Name And pnlResultM.Controls.Item(i).Name <> lbGM.Name And pnlResultM.Controls.Item(i).Name <> lbCanSizeM.Name And pnlResultM.Controls.Item(i).Name <> lbcolorM.Name And pnlResultM.Controls.Item(i).Name <> lbQuantityM.Name And pnlResultM.Controls.Item(i).Name <> lbAccumulationM.Name And pnlResultM.Controls.Item(i).Name <> lbCorrectionM.Name Then
                controlToDispose.Add(pnlResultM.Controls.Item(i))
            End If
        Next
        For i = 0 To controlToDispose.Count - 1
            controlToDispose.Item(i).Dispose()
        Next
    End Sub

    Private Sub txtCanSizeM_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCanSizeM.KeyUp

        If e.KeyCode = Keys.Enter Then

            Dim canSizeText As String = txtCanSizeM.Text
            If Not Regex.IsMatch(canSizeText, "^[0-9 ]+$") Then
                MsgBox("Can size must contain a number", MsgBoxStyle.Exclamation)
                txtCanSizeM.Text = "100"
                Return
            End If
            Dim basicColorCount As Integer = recipeDBList.Count
            Dim fraction As Double = txtCanSizeM.Text / 100
            Dim recipeToUse As List(Of RecipeDB) = recipeDBList
            If Not correctedRecipe Is Nothing Then
                recipeToUse = correctedRecipe
            End If
            Dim accumulation As Double = 0
            For i = 0 To basicColorCount - 1

                Dim lbQuantityTmp As Label = pnlResultM.Controls.Find(lbQuantityM.Name & i, True)(0)
                Dim originalValue As Double = recipeToUse.Item(i).Quantity
                Dim newValue As Double = Math.Round(originalValue * fraction, 2)
                lbQuantityTmp.Text = newValue

                accumulation += newValue
                Dim lbAccumulationTmp As Label = pnlResult.Controls.Find(lbAccumulation.Name & i, True)(0)
                lbAccumulationTmp.Text = accumulation


                Dim lbCorrectionControls As Control() = pnlResultM.Controls.Find(lbCorrectionM.Name & i, True)
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
    Private Sub cmbCoats_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoats.SelectedIndexChanged
        If cmbCoats.SelectedItem.ToString.ToLower = "ls" Then
            lbEffectType.Visible = False
            cmbEffectType.Visible = False
        Else
            lbEffectType.Visible = True
            cmbEffectType.Visible = True
        End If
        selectJob()
    End Sub
    Private Sub butGetJobs_Click(sender As Object, e As EventArgs) Handles butGetJobs.Click
        StopThreads()
        printJobs(lstbJobs)
    End Sub
    Private Sub enableDisable(enableDisable As Boolean)
        cmbCoats.Enabled = enableDisable
        lstbJobs.Enabled = enableDisable
        butGetJobs.Enabled = enableDisable
        butSearch.Enabled = enableDisable
        If enableDisable Then
            AddHandler lstvSearchResult.MouseDoubleClick, AddressOf lstvSearchResult_MouseDoubleClick
        Else
            RemoveHandler lstvSearchResult.MouseDoubleClick, AddressOf lstvSearchResult_MouseDoubleClick
        End If
        butDeleteHistoryJob.Enabled = enableDisable
        chkOldJobs.Enabled = enableDisable
        cmbEffectType.Enabled = enableDisable
    End Sub
    Private Sub selectJob()
        File.AppendAllText(logFilePath, "--selectJob start: " & Now & Environment.NewLine)
        If lstbJobs.SelectedItem Is Nothing Then
            Return
        End If

        enableDisable(False)
        Application.DoEvents()


        emptyDetails()
        emptyTargets()

        'notes: recuperer les angles qui ont ete utilisé par la machine dans le but de les utiliser apres pour les effets
        'reinitialize the machine geometry of the job in use
        geometriesInMachine = New List(Of String)
        txtChosenJob.Text = lstbJobs.SelectedItem.ToString
        Dim jobObj As Job = jobDict(lstbJobs.SelectedItem.ToString)
        Dim jobAlreadyRetrievedFromHistory As Boolean = jobObj.jobFromHistory

        If Not setSpectralDataAndSetGeometriesUsed(jobObj) Then
            File.AppendAllText(logFilePath, "--Not setSpectralDataAndSetGeometriesUsed: " & Now & Environment.NewLine)
            enableDisable(True)
            Return
        End If
        File.AppendAllText(logFilePath, "--after setSpectralDataAndSetGeometriesUsed: " & Now & Environment.NewLine)

        Dim rgbValueCS As RGBValueCS
        Dim jobRGBs As New List(Of Control) From {jobRGB1, jobRGB2, jobRGB3, jobRGB4, jobRGB5, jobRGB6}
        File.AppendAllText(logFilePath, "--before setColorToTransparent: " & Now & Environment.NewLine)
        setColorToTransparent(jobRGBs)

        File.AppendAllText(logFilePath, "--after setColorToTransparent: " & Now & Environment.NewLine)

        'this is just to set the color based on the device spectral
        coat = cmbCoats.SelectedItem.ToString
        If coat.ToLower = "ls" Then
            solidJob = True
            effectJob = False
        Else
            solidJob = False
            effectJob = True
        End If
        File.AppendAllText(logFilePath, "--before conditions: " & Now & Environment.NewLine)
        If solidJob Then
            File.AppendAllText(logFilePath, "--before machineSpectrumsPerGeometry.Item: " & Now & Environment.NewLine)
            colorSpectrumCSDevice = machineSpectrumsPerGeometry.Item("r45as45")
            File.AppendAllText(logFilePath, "--after machineSpectrumsPerGeometry.Item: " & Now & Environment.NewLine)

            colorSpectrumCSDeviceList.Clear()
            colorSpectrumCSDeviceList.Add(colorSpectrumCSDevice)
            File.AppendAllText(logFilePath, "--before getLabValuesFromSpectrum.Item: " & Now & Environment.NewLine)
            solidLabValueFromDevice = getLabValuesFromSpectrum(colorSpectrumCSDevice)
            File.AppendAllText(logFilePath, "--after getLabValuesFromSpectrum.Item: " & Now & Environment.NewLine)
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
        File.AppendAllText(logFilePath, "--after conditions: " & Now & Environment.NewLine)

        lstvSearchResult.Items.Clear()

        If Not jobAlreadyRetrievedFromHistory Then
            If Not deleteJobFromMachine(jobObj) Then
                If Not deleteJobFromMachine(jobObj) Then
                    If Not deleteJobFromMachine(jobObj) Then

                    End If
                End If
            End If
        End If
        File.AppendAllText(logFilePath, "--end selectJob: " & Now & Environment.NewLine)
        enableDisable(True)
    End Sub
    Private Sub lstbJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbJobs.SelectedIndexChanged
        selectJob()
    End Sub

    Private Function deleteJobFromMachine(job As Job) As Boolean
        Dim cmd As String = "DeleteJob|" & job.jobName
        Dim rtn = _spectro.Execute(cmd)

        If Not rtn.StartsWith("<00>") Then
            File.AppendAllText(logFilePath, "--deleteJob " & job.jobName & ": Not rtn.StartsWith("" < 0 > """ & Now & Environment.NewLine)
            Return False
        End If
        Return True
    End Function

    Private Sub chkOldJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chkOldJobs.CheckedChanged
        If chkOldJobs.Checked Then
            butDeleteHistoryJob.Visible = True
        Else
            butDeleteHistoryJob.Visible = False
        End If
        StopThreads()
        printJobs(lstbJobs)
    End Sub

    Private Sub butDeleteHistoryJob_Click(sender As Object, e As EventArgs) Handles butDeleteHistoryJob.Click
        If lstbJobs.SelectedIndex = -1 Then
            MessageBox.Show("Select a job before", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete this job from the job history? [" & lstbJobs.SelectedItem.ToString & "]",
                                                        "Deletion",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Warning)

        ' Supprimer seulement si l'utilisateur clique sur OK
        If confirm = DialogResult.OK Then
            deleteJobByName(lstbJobs.SelectedItem.ToString)
            lstbJobs.Items.RemoveAt(lstbJobs.SelectedIndex)
            MessageBox.Show("Job successfully deleted from history.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
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

    Private Sub resetSorting()
        ' Remove sorting column reference
        m_SortingColumn = Nothing

        ' Remove sort indicators from all columns
        For Each col As ColumnHeader In lstvSearchResult.Columns
            col.Text = col.Text.Replace("↓ ", "").Replace("↑ ", "")
        Next

        ' Reset sorting
        lstvSearchResult.Sorting = SortOrder.None
        lstvSearchResult.ListViewItemSorter = Nothing
    End Sub

#End Region

#Region "multithreading"
    Private executeCorrections As Thread
    Private selectJobThread As Thread
    Private Shared isSelectingAJob As Boolean = False


    Private Sub initializeThreads()
        If Not enableAutomaticCorrection Then
            Return
        End If

        autoCorrectionList = New List(Of SpectralDB)
        subscribeSamplesForAutoCorrection()

        resetSorting()

        ''loading gif management workaround
        pbLoading.Visible = True
        If lstvSearchResult.Items.Count > 0 Then
            pbLoading.Location = getLoadingGifLocation(lstvSearchResult.Items(0).SubItems(3))
        End If

        Application.DoEvents()

        executeCorrections = New Thread(New ThreadStart(AddressOf executeCorrectionsSub))
        executeCorrections.Start()

    End Sub

    Private Function getLoadingGifLocation(subitemLocation As ListViewSubItem) As Point
        Dim location As Point = subitemLocation.Bounds.Location

        Dim subitemWidth As Integer = subitemLocation.Bounds.Size.Width
        location.X = location.X + 5 + subitemWidth / 2 - pbLoading.Width / 2
        location.Y = location.Y + 5
        Return location

    End Function
    Private Sub executeCorrectionsSub()
        cmbCoats.Enabled = False
        lstbJobs.Enabled = False
        butGetJobs.Enabled = False
        butSearch.Enabled = False
        'System.Threading.Thread.Sleep(1500)
        If sortedbyMeritSolid IsNot Nothing Then
            'loop on the first 3 only
            Dim correctedCount As Integer = 0
            Dim listCount As Integer = 0
            Console.WriteLine("---------------------sortedbyMeritSolid.Count=" & sortedbyMeritSolid.Count)
            Console.WriteLine("---------------------ResultLimit=" & ResultLimit)
            If sortedbyMeritSolid.Count - 1 <= ResultLimit Then
                listCount = sortedbyMeritSolid.Count - 1
            Else
                listCount = ResultLimit - 1
            End If
            Console.WriteLine("---------------------listCount=" & listCount)

            For colorCount = 0 To listCount
                Dim spectralDB As SpectralDB = sortedbyMeritSolid.Item(colorCount)
                Console.WriteLine("---------------------spectralDB=" & spectralDB.SampleId)
                ''For Each spectralDB In sortedbyMeritSolid
                If spectralDB.tempMeritForSort > 1.5 And Not spectralDB.autoCorrectedMerit Then
                    Console.WriteLine("---------------------spectralDB in process=" & spectralDB.SampleId)
                    Dim item As ListViewItem = findListViewItemBySampleId(lstvSearchResult, spectralDB.SampleId)
                    If item IsNot Nothing Then
                        Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(126, 192, 216)
                        colorSearchListViewItem(item, color)

                        ' Show loading GIF at a specific row
                        pbLoading.Visible = True
                        pbLoading.BackColor = color

                        pbLoading.Location = getLoadingGifLocation(item.SubItems(3))
                        Application.DoEvents()

                        Dim currentCoat As String = CStr(Invoke(New Func(Of String)(Function() Me.cmbCoats.Text)))
                        Dim recipeDBList As List(Of RecipeDB) = retrieveRecipeBySampleId(spectralDB.SampleId, currentCoat)
                        Dim correctedFormulas As FormulaCS = New FormulaCS()
                        Dim isTricoat As Boolean = spectralDB.tricoat
                        Dim newScore As Double = doAutoCorrectionGetNewScore(spectralDB.SampleId, recipeDBList, correctedFormulas, isTricoat)
                        setAutCorrectedScoreSearchListViewItem(item, newScore)
                        spectralDB.autoCorrectedMerit = True
                        spectralDB.autoCorrectedMeritValue = newScore
                        spectralDB.autoCorrectedFormula = correctedFormulas
                        correctedCount += 1
                        pbLoading.Visible = False
                        Application.DoEvents()
                    End If
                End If
                If correctedCount = listCount + 1 Then

                    Exit For
                End If
            Next
            doSortColumn(3)
        End If
        cmbCoats.Enabled = True
        lstbJobs.Enabled = True
        butGetJobs.Enabled = True
        butSearch.Enabled = True
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


    Private Sub StopThreads()

        If executeCorrections IsNot Nothing Then
            If executeCorrections.IsAlive Then
                executeCorrections.Abort()
            End If
        End If

    End Sub

    Private Sub butNucleosSettings_Click(sender As Object, e As EventArgs) Handles butNucleosSettings.Click
        NucleosSettings.ShowDialog()
    End Sub


#End Region
End Class
