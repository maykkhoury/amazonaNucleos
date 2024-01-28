Imports System.Reflection
Imports amazonaNucleos.XRite

Module NucleosLogic
    Private _spectro As MA3 = New MA3()
    Public Sub printJobs(lstbJobs As ListBox)
        _spectro.Connect()
        Dim cmd = "GetJobList|"
        Dim rtn = _spectro.Execute(cmd)

        Dim jobs As String() = rtn.Split("|"c)
        lstbJobs.Items.Clear()
        For Each job In jobs
            Dim jobIdentifiers As String() = job.Split(";"c)

            If jobIdentifiers.Length > 0 Then
                Dim jobId As String = jobIdentifiers(0)
                Dim jobDisplayName As String = jobIdentifiers(0)
                If jobIdentifiers.Length > 1 Then
                    jobDisplayName = jobIdentifiers(1)
                End If
                lstbJobs.Items.Add(jobDisplayName)
            End If
        Next
    End Sub

    Public Sub setSpectralDataAndSetGeometriesUsed(jobName As String)
        Dim cmd = "SetCurrentJob|" & jobName

        Dim rtn = _spectro.Execute(cmd)
        If Not rtn.StartsWith("<00>") Then
            Return
        End If

        cmd = "GetCurrentJobSampleCount"
        rtn = _spectro.Execute(cmd)
        Dim sampleCountForJob As Integer = Integer.Parse(rtn)

        Dim waveSpectralValuesMapAllGeo As New Dictionary(Of String, Dictionary(Of Integer, List(Of Double)))
        Dim waveSpectralAverageValuesMapAllGeo As New Dictionary(Of String, Dictionary(Of Integer, Double))

        For index = 1 To sampleCountForJob
            If Not _spectro.SetCurrentSample(index) Then
                MsgBox("error set current sample " & index, MsgBoxStyle.Critical)
                Return
            End If
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
                            value = _spectro.GetSampleData(dataSet, wl) / 100
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
                Dim colorSpectrum As ColorSpectrumCS = GetSingleSpectrum(waveSpectralAverageValuesMapAllGeo(spectralSetName).Values.ToList)
                If NucleosSearchForm.machineSpectrumsPerGeometry.ContainsKey(spectralSetName) Then
                    NucleosSearchForm.machineSpectrumsPerGeometry.Remove(spectralSetName)
                End If

                NucleosSearchForm.machineSpectrumsPerGeometry.Add(spectralSetName, colorSpectrum)

            Next

        Next



    End Sub

    Public Function getLabValuesFromSpectrum(solidcolorSpectrum As ColorSpectrumCS) As LabValueCS

        Dim solidLabValue As LabValueCS = ColorimetryCS.ToLab(solidcolorSpectrum, ColorimetrySDKCS.IlluminantCS.D65, ColorimetrySDKCS.ObserverCS.Observer10Degrees)
        Console.WriteLine(solidLabValue.L & " " & solidLabValue.a & " " & solidLabValue.b)
        Return solidLabValue
    End Function

    Public Function filterByDelta(allColorsTarget As List(Of SpectralDB), deviceLabValue As LabValueCS) As List(Of SpectralDB)
        Dim filteredBySolidDeltaList As New List(Of SpectralDB)
        For i As Integer = 0 To allColorsTarget.Count - 1

            'if solid ou effet(recherche dans la recette pour trouver au moin un pigment qui n'est pas solid alors c'est une recette effets)
            Dim spectralDB As SpectralDB = allColorsTarget.Item(i)
            Dim currentLabValue As LabValueCS = spectralDB.labValue
            Dim dE2000 As Double = ColorimetryCS.DeltaE2000(currentLabValue, deviceLabValue)
            spectralDB.DeltaE2000 = dE2000

            If dE2000 <= DeltaSolid Then
                filteredBySolidDeltaList.Add(spectralDB)
            End If

        Next
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

    Public Function sortByMerit(filteredByDeltaList As List(Of SpectralDB), colorSpectrumCSDevice As List(Of ColorSpectrumCS), coat As String) As List(Of SpectralDB)
        Dim filteredByDeltaListWithMeritFilled As New List(Of SpectralDB)

        For i As Integer = 0 To filteredByDeltaList.Count - 1
            Dim spectralDB As SpectralDB = filteredByDeltaList.Item(i)

            'if the user is forcing the solid of this job because he is sure it's solid, or if not then check the actuel type of this recipe in the db based on its basic colors
            If NucleosSearchForm.solidJob Or Not IsEffectRecipe(spectralDB) Then
                Dim trialColorSpectrum As ColorSpectrumCS = filteredByDeltaList.Item(i).colorSpectrumCS
                Dim merit As Double = calculateMerit(
                    New List(Of ColorSpectrumCS) From {colorSpectrumCSDevice.Item(0)}, 'just one when solid
                    New List(Of ColorSpectrumCS) From {divideSpectrum(trialColorSpectrum)})

                spectralDB.tempMeritForSort = merit

            Else
                'pour les effets

                Dim trialColorSpectralDBList As List(Of SpectralDB) = retrieveAllGeometrySpectralBySampleId(filteredByDeltaList.Item(i).SampleId, NucleosSearchForm.geometriesInMachine, coat)
                Dim trialColorSpectrumList As New List(Of ColorSpectrumCS)
                For j = 0 To trialColorSpectralDBList.Count - 1
                    trialColorSpectrumList.Add(trialColorSpectralDBList.Item(j).colorSpectrumCS)
                Next


                Dim merit As Double = calculateMerit(
                    colorSpectrumCSDevice, 'just one when solid
                    trialColorSpectrumList)

                spectralDB.tempMeritForSort = merit

            End If
            filteredByDeltaListWithMeritFilled.Add(spectralDB)


        Next
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
            Console.WriteLine("Shape: {0:0.0000}", merit)
            Console.WriteLine("----------------")
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
End Module
