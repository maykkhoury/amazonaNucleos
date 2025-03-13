Imports System.Reflection
Imports garageApp.XRite
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports JsonReaderSDKCS

Module NucleosLogic
    Public _spectro As MA3 = New MA3()
    Public jobDict As Dictionary(Of String, Job)

    Public Sub printJobs(lstbJobs As ListBox)
        jobDict = New Dictionary(Of String, Job)()
        lstbJobs.Items.Clear()
        If NucleosSearchForm.chkOldJobs.Checked Then
            Dim jobs As List(Of Job) = retrieveAllJobs()
            For Each job In jobs
                lstbJobs.Items.Add(job.jobName)
                jobDict(job.jobName) = job

            Next
        Else
            Try
                _spectro.Connect()
                Dim cmd = "GetJobList|"
                Dim rtn = _spectro.Execute(cmd)

                Dim jobs As String() = rtn.Split("|"c)


                For Each job In jobs
                    Dim jobIdentifiers As String() = job.Split(";"c)

                    If jobIdentifiers.Length > 0 Then

                        Dim jobName As String = jobIdentifiers(0)
                        Dim jobObj As New Job
                        jobObj.jobName = jobName
                        lstbJobs.Items.Add(jobName)
                        jobDict(jobName) = jobObj

                    End If
                Next
            Catch ex As System.AccessViolationException

                MsgBox("Make sure the device is plugged in the USB port", MsgBoxStyle.Exclamation)

            End Try
        End If

    End Sub

    Public Function setSpectralDataAndSetGeometriesUsed(job As Job) As Boolean

        Dim sampleCountForJob As Integer = -1
        If Not job.jobFromHistory Then
            SetLegacyMode(_spectro)

            Dim cmd = "SetCurrentJob|" & job.jobName

            Dim rtn = _spectro.Execute(cmd)
            If Not rtn.StartsWith("<00>") Then
                File.AppendAllText(logFilePath, "--SetCurrentJob: Not rtn.StartsWith("" < 0 > """ & Now & Environment.NewLine)
                Return False
            End If

            cmd = "RefreshStoredSamples"
            rtn = _spectro.Execute(cmd)
            If Not rtn.StartsWith("<00>") Then
                File.AppendAllText(logFilePath, "--RefreshStoredSamples: Not rtn.StartsWith("" < 0 > """ & Now & Environment.NewLine)
                Return False
            End If

            cmd = "GetCurrentJobSampleCount"
            rtn = _spectro.Execute(cmd)

            ''get from db sampleCountForJob

            sampleCountForJob = Integer.Parse(rtn)
            If sampleCountForJob = 0 Then
                MsgBox("This Job is corrupted")
                File.AppendAllText(logFilePath, "--GetCurrentJobSampleCount: sampleCountForJob = 0" & Now & Environment.NewLine)
                Return False
            End If
        End If

        Dim jobId As Integer = -1
        job.sampleCountForJob = sampleCountForJob
        Dim setJobToHistory As Boolean = False
        If Not job.jobFromHistory Then
            jobId = createJob(job)
            job.jobId = jobId
            setJobToHistory = True
        Else
            job = retrieveJobById(job.jobId)
            sampleCountForJob = job.sampleCountForJob
        End If

        Dim waveSpectralValuesMapAllGeo As New Dictionary(Of String, Dictionary(Of Integer, List(Of Double)))
        Dim waveSpectralAverageValuesMapAllGeo As New Dictionary(Of String, Dictionary(Of Integer, Double))

        Dim sampleList As New List(Of Sample)
        If job.jobFromHistory Then
            sampleList = retrieveSamplesByJobId(job.jobId)
        End If

        For index = 1 To sampleCountForJob
            Dim sample As New Sample
            Dim wlCount As Integer = -1
            Dim datSetCount As Integer = -1
            If job.jobFromHistory Then
                sample.sampleId = sampleList.Item(index - 1).sampleId
                wlCount = sampleList.Item(index - 1).wlCount
                datSetCount = sampleList.Item(index - 1).datSetCount
            Else
                If Not _spectro.SetCurrentSample(index) Then
                    MsgBox("error set current sample " & index, MsgBoxStyle.Critical)
                    Return False
                End If
                wlCount = _spectro.GetWavelengthCount()
                datSetCount = _spectro.GetSpectralSetCount()
            End If
            sample.wlCount = wlCount
            sample.datSetCount = datSetCount

            Dim waveValueMap As New Dictionary(Of Integer, Integer)

            ''get from db all wave length of currentSample of index
            Dim wlIndexes As New List(Of Integer)
            For wl = 0 To wlCount - 1
                Dim value As Integer = -1
                If job.jobFromHistory Then
                    value = sampleList.Item(index - 1).wlIndexes.Item(wl)
                Else
                    value = _spectro.GetWavelengthValue(wl) '/ 100
                End If
                waveValueMap.Add(wl, value)
                wlIndexes.Add(value)
            Next
            sample.wlIndexes = wlIndexes

            For i As Integer = 0 To waveValueMap.Count - 1
                Console.WriteLine("Wave index " & i & " is " & waveValueMap.Item(i))
            Next

            Dim sampleDataSets As New List(Of SampleDataSet)

            Dim sampleId As Integer = -1
            If Not job.jobFromHistory Then
                sample.jobId = jobId
                sampleId = createSample(sample)
            Else
                'get datasets
                sampleDataSets = retrieveSampleDataSetBySampleId(sample.sampleId)
            End If

            ''get from db all dataSet
            For dataSet = 0 To datSetCount - 1
                ''get from db GetSpectralSetName from dataSet
                Dim spectralSetName As String = Nothing
                If job.jobFromHistory Then
                    spectralSetName = sampleDataSets.Item(dataSet).spectralSetName
                Else
                    spectralSetName = _spectro.GetSpectralSetName(dataSet)
                End If

                Dim sampleDataSet As New SampleDataSet
                ''sampleDataSets.Add(sampleDataSet)
                If Not NucleosSearchForm.geometriesInMachine.Contains(spectralSetName) Then
                    NucleosSearchForm.geometriesInMachine.Add(spectralSetName)
                End If
                ' End If
            Next

            For j = 0 To NucleosSearchForm.geometriesInMachine.Count - 1

                Dim spectralSetName As String = NucleosSearchForm.geometriesInMachine.Item(j)


                For dataSet = 0 To datSetCount - 1
                    ''get from db GetSpectralSetName from dataSet
                    ''Dim spectralSetNameSpectro As String = _spectro.GetSpectralSetName(dataSet)
                    Dim spectralSetNameSpectro As String = Nothing
                    If job.jobFromHistory Then
                        spectralSetNameSpectro = sampleDataSets.Item(dataSet).spectralSetName
                    Else
                        spectralSetNameSpectro = _spectro.GetSpectralSetName(dataSet)
                    End If

                    If spectralSetNameSpectro = spectralSetName Then
                        Dim wlValues As New List(Of Double)
                        For wl = 0 To wlCount - 1
                            Dim value As Double
                            Dim valueRaw As Double = -1
                            If job.jobFromHistory Then
                                valueRaw = sampleDataSets.Item(dataSet).wlValues.Item(wl)
                            Else
                                valueRaw = _spectro.GetSampleData(dataSet, wl)
                            End If
                            wlValues.Add(valueRaw)
                            value = valueRaw / 100
                            Dim valuesList As List(Of Double)
                            Dim waveSpectralValuesMap As Dictionary(Of Integer, List(Of Double))
                            If waveSpectralValuesMapAllGeo.ContainsKey(spectralSetName) Then
                                waveSpectralValuesMap = waveSpectralValuesMapAllGeo(spectralSetName)
                            Else
                                waveSpectralValuesMap = New Dictionary(Of Integer, List(Of Double))
                            End If

                            Dim waveSpectralAverageValuesMap As Dictionary(Of Integer, Double)
                            If waveSpectralAverageValuesMapAllGeo.ContainsKey(spectralSetName) Then
                                waveSpectralAverageValuesMap = waveSpectralAverageValuesMapAllGeo(spectralSetName)
                            Else
                                waveSpectralAverageValuesMap = New Dictionary(Of Integer, Double)
                            End If


                            If waveSpectralValuesMap.ContainsKey(wl) Then
                                valuesList = waveSpectralValuesMap.Item(wl)
                                valuesList.Add(value)
                                waveSpectralValuesMap(wl) = valuesList
                            Else
                                valuesList = New List(Of Double) From {value}
                                waveSpectralValuesMap.Add(wl, valuesList)
                            End If
                            If waveSpectralValuesMapAllGeo.ContainsKey(spectralSetName) Then
                                waveSpectralValuesMapAllGeo(spectralSetName) = waveSpectralValuesMap
                            Else
                                waveSpectralValuesMapAllGeo.Add(spectralSetName, waveSpectralValuesMap)
                            End If
                            'caluclate the average for this wave
                            Dim total As Double = 0
                            For i As Integer = 0 To valuesList.Count - 1
                                total += valuesList.Item(i)
                            Next
                            Dim average As Double = total / valuesList.Count
                            If waveSpectralAverageValuesMap.ContainsKey(wl) Then
                                waveSpectralAverageValuesMap(wl) = average
                            Else
                                waveSpectralAverageValuesMap.Add(wl, average)
                            End If
                            If waveSpectralAverageValuesMapAllGeo.ContainsKey(spectralSetName) Then
                                waveSpectralAverageValuesMapAllGeo(spectralSetName) = waveSpectralAverageValuesMap
                            Else
                                waveSpectralAverageValuesMapAllGeo.Add(spectralSetName, waveSpectralAverageValuesMap)
                            End If
                            '--------------------------------------------'
                        Next
                        ''sampleDataSets.Item(dataSet).wlValues = wlValues

                        If Not job.jobFromHistory Then
                            Dim sampleDataSet As New SampleDataSet

                            sampleDataSet.sampleId = sampleId
                            sampleDataSet.wlValues = wlValues
                            sampleDataSet.spectralSetName = spectralSetNameSpectro
                            createSampleDataSet(sampleDataSet)
                        End If

                    End If
                Next


                For loopIndex As Integer = 0 To waveSpectralAverageValuesMapAllGeo(spectralSetName).Count - 1
                    Console.WriteLine(spectralSetName & ", average value at Wave index " & loopIndex & " is " & waveSpectralAverageValuesMapAllGeo(spectralSetName).Item(loopIndex))
                Next
                Dim colorSpectrum As ColorSpectrumCS = GetSingleSpectrum(waveSpectralAverageValuesMapAllGeo(spectralSetName).Values.ToList, spectralSetName)
                If NucleosSearchForm.machineSpectrumsPerGeometry.ContainsKey(spectralSetName) Then
                    NucleosSearchForm.machineSpectrumsPerGeometry.Remove(spectralSetName)
                End If

                NucleosSearchForm.machineSpectrumsPerGeometry.Add(spectralSetName, colorSpectrum)

            Next

        Next
        If setJobToHistory Then
            job.jobFromHistory = True
        End If
        Return True

    End Function
    Public Sub setSpectralDataAndSetGeometriesUsedAfterMeasurement()
        NucleosSearchForm.machineSpectrumsPerGeometryAfterMeasurement.Clear()

        Dim waveSpectralValuesMapAllGeo As New Dictionary(Of String, Dictionary(Of Integer, List(Of Double)))
        Dim waveSpectralAverageValuesMapAllGeo As New Dictionary(Of String, Dictionary(Of Integer, Double))

        Dim wlCount As Integer = _spectro.GetWavelengthCount()
        Dim datSetCount As Integer = _spectro.GetSpectralSetCount()
        Dim waveValueMap As New Dictionary(Of Integer, Integer)
        For wl = 0 To wlCount - 1
            Dim value As Integer = _spectro.GetWavelengthValue(wl) '/ 100
            waveValueMap.Add(wl, value)
        Next

        For i As Integer = 0 To waveValueMap.Count - 1
            Console.WriteLine("Wave index " & i & " is " & waveValueMap.Item(i))
        Next

        For dataSet = 0 To datSetCount - 1
            Dim spectralSetName As String = _spectro.GetSpectralSetName(dataSet)
            If Not NucleosSearchForm.geometriesInMachine.Contains(spectralSetName) Then
                NucleosSearchForm.geometriesInMachine.Add(spectralSetName)
            End If
            ' End If
        Next

        For j = 0 To NucleosSearchForm.geometriesInMachine.Count - 1

            Dim spectralSetName As String = NucleosSearchForm.geometriesInMachine.Item(j)


            For dataSet = 0 To datSetCount - 1
                Dim spectralSetNameSpectro As String = _spectro.GetSpectralSetName(dataSet)
                If spectralSetNameSpectro = spectralSetName Then
                    For wl = 0 To wlCount - 1
                        Dim value As Double
                        value = _spectro.GetSpectralData(dataSet, wl) / 100
                        Dim valuesList As List(Of Double)
                        Dim waveSpectralValuesMap As Dictionary(Of Integer, List(Of Double))
                        If waveSpectralValuesMapAllGeo.ContainsKey(spectralSetName) Then
                            waveSpectralValuesMap = waveSpectralValuesMapAllGeo(spectralSetName)
                        Else
                            waveSpectralValuesMap = New Dictionary(Of Integer, List(Of Double))
                        End If

                        Dim waveSpectralAverageValuesMap As Dictionary(Of Integer, Double)
                        If waveSpectralAverageValuesMapAllGeo.ContainsKey(spectralSetName) Then
                            waveSpectralAverageValuesMap = waveSpectralAverageValuesMapAllGeo(spectralSetName)
                        Else
                            waveSpectralAverageValuesMap = New Dictionary(Of Integer, Double)
                        End If


                        If waveSpectralValuesMap.ContainsKey(wl) Then
                            valuesList = waveSpectralValuesMap.Item(wl)
                            valuesList.Add(value)
                            waveSpectralValuesMap(wl) = valuesList
                        Else
                            valuesList = New List(Of Double) From {value}
                            waveSpectralValuesMap.Add(wl, valuesList)
                        End If
                        If waveSpectralValuesMapAllGeo.ContainsKey(spectralSetName) Then
                            waveSpectralValuesMapAllGeo(spectralSetName) = waveSpectralValuesMap
                        Else
                            waveSpectralValuesMapAllGeo.Add(spectralSetName, waveSpectralValuesMap)
                        End If
                        'caluclate the average for this wave
                        Dim total As Double = 0
                        For i As Integer = 0 To valuesList.Count - 1
                            total += valuesList.Item(i)
                        Next
                        Dim average As Double = total / valuesList.Count
                        If waveSpectralAverageValuesMap.ContainsKey(wl) Then
                            waveSpectralAverageValuesMap(wl) = average
                        Else
                            waveSpectralAverageValuesMap.Add(wl, average)
                        End If
                        If waveSpectralAverageValuesMapAllGeo.ContainsKey(spectralSetName) Then
                            waveSpectralAverageValuesMapAllGeo(spectralSetName) = waveSpectralAverageValuesMap
                        Else
                            waveSpectralAverageValuesMapAllGeo.Add(spectralSetName, waveSpectralAverageValuesMap)
                        End If
                        '--------------------------------------------'
                    Next
                End If
            Next
            For loopIndex As Integer = 0 To waveSpectralAverageValuesMapAllGeo(spectralSetName).Count - 1
                Console.WriteLine(spectralSetName & ", average value at Wave index " & loopIndex & " is " & waveSpectralAverageValuesMapAllGeo(spectralSetName).Item(loopIndex))
            Next
            Dim colorSpectrum As ColorSpectrumCS = GetSingleSpectrum(waveSpectralAverageValuesMapAllGeo(spectralSetName).Values.ToList, spectralSetName)
            NucleosSearchForm.machineSpectrumsPerGeometryAfterMeasurement.Add(spectralSetName, colorSpectrum)
        Next
    End Sub
    Public Function getLabValuesFromSpectrum(solidcolorSpectrum As ColorSpectrumCS) As LabValueCS

        Dim solidLabValue As LabValueCS = ColorimetryCS.ToLab(solidcolorSpectrum, ColorimetrySDKCS.IlluminantCS.D65, ColorimetrySDKCS.ObserverCS.Observer10Degrees)
        Console.WriteLine(solidLabValue.L & " " & solidLabValue.a & " " & solidLabValue.b)
        Return solidLabValue
    End Function

    Public Function filterByDelta(allColorsTarget As List(Of SpectralDB), deviceLabValue As LabValueCS, deltaCompare As Integer) As List(Of SpectralDB)

        ' Initialize Progress Bar
        NucleosSearchForm.prgSearch.Minimum = 0
        NucleosSearchForm.prgSearch.Maximum = allColorsTarget.Count
        NucleosSearchForm.prgSearch.Value = 0

        Dim filteredBySolidDeltaList As New List(Of SpectralDB)
        For i As Integer = 0 To allColorsTarget.Count - 1

            'if solid ou effet(recherche dans la recette pour trouver au moin un pigment qui n'est pas solid alors c'est une recette effets)
            Dim spectralDB As SpectralDB = allColorsTarget.Item(i)

            Dim currentLabValue As LabValueCS = spectralDB.labValue
            Dim dE2000 As Double = ColorimetryCS.DeltaE2000(currentLabValue, deviceLabValue)
            spectralDB.DeltaE2000 = dE2000

            If spectralDB.SampleName = "MERCEDES 297 (S1)" Then
                ''filteredBySolidDeltaList.Add(spectralDB)
                ''Exit For
            End If

            'TODO
            If dE2000 <= deltaCompare Then
                filteredBySolidDeltaList.Add(spectralDB)
            End If

            ' Update Progress Bar
            NucleosSearchForm.prgSearch.Value = i + 1
            Application.DoEvents()

        Next
        NucleosSearchForm.prgSearch.Value = 0
        Return filteredBySolidDeltaList
    End Function

    Public Function getLabValueByGeometry(labValueFromDeviceList As List(Of LabValueCS), geometriesInMachineForDb As List(Of String), geometry As String) As LabValueCS

        For i = 0 To geometriesInMachineForDb.Count - 1
            Dim g As String = geometriesInMachineForDb.Item(i)
            If geometry.ToLower.Contains(g) Then
                Return labValueFromDeviceList.Item(i)
            End If
        Next
    End Function
    Public Function calculateMerit(spectralDB As SpectralDB, colorSpectrumCSDevice As List(Of ColorSpectrumCS), coat As String) As Double
        Dim merit As Double
        'if the user is forcing the solid of this job because he is sure it's solid, or if not then check the actuel type of this recipe in the db based on its basic colors
        '' If NucleosSearchForm.solidJob Or Not IsEffectRecipe(spectralDB) Then
        If coat.ToLower = "ls" Then
            Dim trialColorSpectrum As ColorSpectrumCS = spectralDB.colorSpectrumCS
            merit = calculateMerit(
                    New List(Of ColorSpectrumCS) From {colorSpectrumCSDevice.Item(0)}, 'just one when solid
                    New List(Of ColorSpectrumCS) From {divideSpectrum(trialColorSpectrum)})
        Else
            'pour les effets
            ' Start timing

            Dim startTicks As Long = Environment.TickCount

            Console.WriteLine("BC: Elapsed Time retrieve geo start: " & DateTime.Now.ToString("HH:mm:ss.fff"))
            Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(spectralDB.SampleId, NucleosSearchForm.geometriesInMachine, coat)

            Dim elapsedMilliseconds As Long = Environment.TickCount - startTicks
            ' Display the result
            Console.WriteLine("BC: Elapsed Time retrieve geo: " & DateTime.Now.ToString("HH:mm:ss.fff"))


            Dim trialColorSpectrumList As New List(Of ColorSpectrumCS)
            For j = 0 To trialColorSpectralDBList.Count - 1
                trialColorSpectrumList.Add(trialColorSpectralDBList.Item(j).colorSpectrumCS)
            Next


            merit = calculateMerit(
                    colorSpectrumCSDevice, 'just one when solid
                    trialColorSpectrumList)

        End If

        Return merit
    End Function

    Public Function sortByMerit(filteredByDeltaList As List(Of SpectralDB), colorSpectrumCSDevice As List(Of ColorSpectrumCS), coat As String) As List(Of SpectralDB)
        Dim filteredByDeltaListWithMeritFilled As New List(Of SpectralDB)

        ' Initialize Progress Bar
        NucleosSearchForm.prgSearch.Minimum = 0
        NucleosSearchForm.prgSearch.Maximum = filteredByDeltaList.Count
        NucleosSearchForm.prgSearch.Value = 0

        For i As Integer = 0 To filteredByDeltaList.Count - 1
            Dim spectralDB As SpectralDB = filteredByDeltaList.Item(i)
            Dim merit As Double = calculateMerit(spectralDB, colorSpectrumCSDevice, coat)

            spectralDB.tempMeritForSort = merit
            filteredByDeltaListWithMeritFilled.Add(spectralDB)

            ' Update Progress Bar
            NucleosSearchForm.prgSearch.Value = i + 1
            Application.DoEvents()
        Next
        ' Initialize Progress Bar
        NucleosSearchForm.prgSearch.Value = 0



        Dim sortedByMerit As New List(Of SpectralDB)
        sortedByMerit = filteredByDeltaListWithMeritFilled.OrderBy(Function(x) x.tempMeritForSort).ToList()

        Return sortedByMerit

    End Function

    Public Function calculateMerit(targetColorSpectrumList As List(Of ColorSpectrumCS), trialColorSpectrumList As List(Of ColorSpectrumCS)) As Double
        Dim merit As Double = -1
        Try
            Dim targetMeasurement As MeasurementCS = GetMeasurement(targetColorSpectrumList)

            Dim trialMeasurement As MeasurementCS = GetMeasurement(trialColorSpectrumList)

            merit = ColorimetryCS.Merit(targetMeasurement, trialMeasurement)
            '' Console.WriteLine("Shape: {0:0.0000}", merit)
            ''Console.WriteLine("----------------")
        Catch exception As Exception
            Console.WriteLine("SDK error occurred: {0}", exception)
            Console.WriteLine("----------------")
        End Try
        Return merit
    End Function

    Public Function GetMeasurementForSolid(colorSpectrumCS As ColorSpectrumCS) As MeasurementCS
        Return New MeasurementCS(New List(Of ColorSpectrumCS) From {
            New ColorSpectrumCS(GeometryCS.Geometry45as45, New SpectralRangeCS(400, 700, 10), colorSpectrumCS.SpectralValues)
    })
    End Function
    Public Function GetMeasurement(colorSpectrumCSList As List(Of ColorSpectrumCS)) As MeasurementCS
        Return New MeasurementCS(colorSpectrumCSList)
    End Function

    Public Function GetJsonSubstrate(jsonFileContent As JsonFileContentCS) As SubstrateCS
        '----------------------------------------------------------
        '  Get substrate from JSON file
        '----------------------------------------------------------
        If jsonFileContent.Substrates.Count > 0 Then
            Return jsonFileContent.Substrates(0)
        End If

        Throw New JsonExceptionCS(JsonErrorCodeCS.UnknownError, "No substrate found in JSON file")
    End Function


    Public Function GetJsonFileContent(chosenCoat As String) As JsonFileContentCS
        Dim jsonFileName As String = ""
        If chosenCoat.ToLower = "ls" Then
            jsonFileName = Directory.GetCurrentDirectory() & "\2K LS_PM"
        Else
            jsonFileName = Directory.GetCurrentDirectory() & "\BASECOAT_PM"
        End If

        '----------------------------------------------------------
        '  Query JSON files
        '----------------------------------------------------------
        Dim jsonFiles As List(Of String) = JsonReaderCS.QueryJsonFiles(jsonFileName, Nothing)

        If jsonFiles.Count > 0 Then
            '----------------------------------------------------------
            '  Load first file
            '----------------------------------------------------------
            Return JsonReaderCS.LoadJsonFile(jsonFiles(0))
        End If

        Throw New JsonExceptionCS(JsonErrorCodeCS.JsonFileNotFound, "No JSON file found")
    End Function



End Module
