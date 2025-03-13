
Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO

Module DatabaseOperations
    Dim SQLiteConn As SQLiteConnection
    Public connectionString As String = "Data Source=" & Directory.GetCurrentDirectory() & "\amazonaDB.db;"
    Private Sub openDbConnectionOld()
        SQLiteConn = New SQLiteConnection()

        SQLiteConn.ConnectionString = "Data Source=" & Directory.GetCurrentDirectory() & "\Amazona_2023v6.bcsqlite;"

        SQLiteConn.Open()
    End Sub
    Private Sub openDbConnection()
        SQLiteConn = New SQLiteConnection()

        SQLiteConn.ConnectionString = "Data Source=" & Directory.GetCurrentDirectory() & "\amazonaDB.db;"

        SQLiteConn.Open()
    End Sub
    Private Sub closeDbConnection()
        SQLiteConn.Close()
    End Sub

    Public Function setLABInDB() As List(Of SpectralDB)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        Dim tableName As String = "spectral_bc"
        If NucleosSearchForm.cmbCoats.Text.ToLower = "ls" Then
            tableName = "spectral_ls"
        End If

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT rowid,* from " & tableName ' & " where sampleID='AUDI LA3G (S1)-LS'"
        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim allColors As New List(Of SpectralDB)
        While SQLiteReader.Read()
            Dim spectral As New SpectralDB()
            spectral.rowId = SQLiteReader("rowID")
            spectral.SampleId = SQLiteReader("SampleId")
            spectral.Substrate = SQLiteReader("Substrate")
            spectral.SampleName = SQLiteReader("Sample name")
            spectral.DateTime = SQLiteReader("DateTime")
            spectral.Geometry = SQLiteReader("Geometry")
            spectral._400nm = SQLiteReader("400nm") / 100
            spectral._410nm = SQLiteReader("410nm") / 100
            spectral._420nm = SQLiteReader("420nm") / 100
            spectral._430nm = SQLiteReader("430nm") / 100
            spectral._440nm = SQLiteReader("440nm") / 100
            spectral._450nm = SQLiteReader("450nm") / 100
            spectral._460nm = SQLiteReader("460nm") / 100
            spectral._470nm = SQLiteReader("470nm") / 100
            spectral._480nm = SQLiteReader("480nm") / 100
            spectral._490nm = SQLiteReader("490nm") / 100
            spectral._500nm = SQLiteReader("500nm") / 100
            spectral._510nm = SQLiteReader("510nm") / 100
            spectral._520nm = SQLiteReader("520nm") / 100
            spectral._530nm = SQLiteReader("530nm") / 100
            spectral._540nm = SQLiteReader("540nm") / 100
            spectral._550nm = SQLiteReader("550nm") / 100
            spectral._560nm = SQLiteReader("560nm") / 100
            spectral._570nm = SQLiteReader("570nm") / 100
            spectral._580nm = SQLiteReader("580nm") / 100
            spectral._590nm = SQLiteReader("590nm") / 100
            spectral._600nm = SQLiteReader("600nm") / 100
            spectral._610nm = SQLiteReader("610nm") / 100
            spectral._620nm = SQLiteReader("620nm") / 100
            spectral._630nm = SQLiteReader("630nm") / 100
            spectral._640nm = SQLiteReader("640nm") / 100
            spectral._650nm = SQLiteReader("650nm") / 100
            spectral._660nm = SQLiteReader("660nm") / 100
            spectral._670nm = SQLiteReader("670nm") / 100
            spectral._680nm = SQLiteReader("680nm") / 100
            spectral._690nm = SQLiteReader("690nm") / 100
            spectral._700nm = SQLiteReader("700nm") / 100
            spectral.l = SQLiteReader("l").ToString()
            spectral.a = SQLiteReader("a").ToString()
            spectral.b = SQLiteReader("b").ToString()


            ' If spectral.l Is Nothing Or spectral.l = "" Then
            'calculate LAB
            Dim d As Double = CDbl(spectral._450nm)

            Dim waveSpectralAverageValuesMap As New Dictionary(Of Integer, Double)
            waveSpectralAverageValuesMap.Add(0, spectral._400nm)
            waveSpectralAverageValuesMap.Add(1, spectral._410nm)
            waveSpectralAverageValuesMap.Add(2, spectral._420nm)
            waveSpectralAverageValuesMap.Add(3, spectral._430nm)
            waveSpectralAverageValuesMap.Add(4, spectral._440nm)
            waveSpectralAverageValuesMap.Add(5, spectral._450nm)
            waveSpectralAverageValuesMap.Add(6, spectral._460nm)
            waveSpectralAverageValuesMap.Add(7, spectral._470nm)
            waveSpectralAverageValuesMap.Add(8, spectral._480nm)
            waveSpectralAverageValuesMap.Add(9, spectral._490nm)
            waveSpectralAverageValuesMap.Add(10, spectral._500nm)
            waveSpectralAverageValuesMap.Add(11, spectral._510nm)
            waveSpectralAverageValuesMap.Add(12, spectral._520nm)
            waveSpectralAverageValuesMap.Add(13, spectral._530nm)
            waveSpectralAverageValuesMap.Add(14, spectral._540nm)
            waveSpectralAverageValuesMap.Add(15, spectral._550nm)
            waveSpectralAverageValuesMap.Add(16, spectral._560nm)
            waveSpectralAverageValuesMap.Add(17, spectral._570nm)
            waveSpectralAverageValuesMap.Add(18, spectral._580nm)
            waveSpectralAverageValuesMap.Add(19, spectral._590nm)
            waveSpectralAverageValuesMap.Add(20, spectral._600nm)
            waveSpectralAverageValuesMap.Add(21, spectral._610nm)
            waveSpectralAverageValuesMap.Add(22, spectral._620nm)
            waveSpectralAverageValuesMap.Add(23, spectral._630nm)
            waveSpectralAverageValuesMap.Add(24, spectral._640nm)
            waveSpectralAverageValuesMap.Add(25, spectral._650nm)
            waveSpectralAverageValuesMap.Add(26, spectral._660nm)
            waveSpectralAverageValuesMap.Add(27, spectral._670nm)
            waveSpectralAverageValuesMap.Add(29, spectral._680nm)
            waveSpectralAverageValuesMap.Add(30, spectral._690nm)
            waveSpectralAverageValuesMap.Add(31, spectral._700nm)
            Dim colorSpectrumCS As ColorSpectrumCS = New ColorSpectrumCS(GeometryCS.Geometry45as45, New SpectralRangeCS(400, 700, 10), waveSpectralAverageValuesMap.Values.ToList)
            Dim solidLabValueFromDevice As LabValueCS = getLabValuesFromSpectrum(colorSpectrumCS)
            Dim l As String = solidLabValueFromDevice.L
            Dim a As String = solidLabValueFromDevice.a
            Dim b As String = solidLabValueFromDevice.b


            Dim SQLiteUpdatecmd As New SQLiteCommand
            SQLiteUpdatecmd.Connection = SQLiteConn
            SQLiteUpdatecmd.CommandText = "update " & tableName & " set l='" & l & "', a='" & a & "', b='" & b & "' where rowId=" & spectral.rowId
            SQLiteUpdatecmd.ExecuteNonQuery()
            SQLiteUpdatecmd.Dispose()
            'End If

            allColors.Add(spectral)
        End While

        SQLiteReader.Close()
        closeDbConnection()


        If tableName = "spectral_bc" Then 'retreive spectral effect type
            For Each spectral In allColors
                Dim effect As String = getFormulaEffect(spectral.SampleId)
                Dim tricoat As Boolean = isTricoat(spectral.SampleId)
                'Dim effect As String = "X"
                Using c As SQLiteConnection = New SQLiteConnection(connectionString)
                    c.Open()
                    Dim sql = "update spectral_bc set effect='" & effect & "', tricoat='" & tricoat & "' where sampleId='" & spectral.SampleId & "'"
                    Using cmd As SQLiteCommand = New SQLiteCommand(sql, c)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Next
        Else
            For Each spectral In allColors
                Dim tricoat As Boolean = isTricoat(spectral.SampleId)
                'Dim effect As String = "X"
                Using c As SQLiteConnection = New SQLiteConnection(connectionString)
                    c.Open()
                    Dim sql = "update spectral_ls set effect='2K', tricoat='" & tricoat & "' where sampleId='" & spectral.SampleId & "'"
                    Using cmd As SQLiteCommand = New SQLiteCommand(sql, c)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Next
        End If
        Return allColors
    End Function

    Public Function getAllColorsEffectTarget() As List(Of SpectralDB)
        Return getAllColorsByEffect(" effect!='S' ")
    End Function
    Public Function getAllColorsForSolidTarget() As List(Of SpectralDB)
        Return getAllColorsByEffect(" effect='S' ")
    End Function
    Public Function getAllColorsByEffect(queryCondition As String) As List(Of SpectralDB)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        Dim tableName As String = "spectral_bc"
        If NucleosSearchForm.cmbCoats.Text.ToLower = "ls" Then
            tableName = "spectral_ls"
        End If

        SQLitecmd.Connection = SQLiteConn
        If queryCondition Is Nothing Or queryCondition = "" Then
            SQLitecmd.CommandText = "SELECT rowID, * from " & tableName & " where geometry like '%45as45%'"
        Else
            SQLitecmd.CommandText = "SELECT rowID, * from " & tableName & " where " & queryCondition & " and geometry like '%45as45%'"
        End If

        If NucleosSearchForm.skipTriCoats Then
            SQLitecmd.CommandText &= " and tricoat='False'"
        End If
        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim allColorsForSolidTarget As New List(Of SpectralDB)
        While SQLiteReader.Read()
            Dim spectral As New SpectralDB()
            spectral.rowId = SQLiteReader("rowID")
            spectral.SampleId = SQLiteReader("SampleId")
            spectral.Substrate = SQLiteReader("Substrate")
            spectral.SampleName = SQLiteReader("Sample name")
            spectral.DateTime = SQLiteReader("DateTime")
            spectral.Geometry = SQLiteReader("Geometry")
            spectral._400nm = SQLiteReader("400nm")
            spectral._410nm = SQLiteReader("410nm")
            spectral._420nm = SQLiteReader("420nm")
            spectral._430nm = SQLiteReader("430nm")
            spectral._440nm = SQLiteReader("440nm")
            spectral._450nm = SQLiteReader("450nm")
            spectral._460nm = SQLiteReader("460nm")
            spectral._470nm = SQLiteReader("470nm")
            spectral._480nm = SQLiteReader("480nm")
            spectral._490nm = SQLiteReader("490nm")
            spectral._500nm = SQLiteReader("500nm")
            spectral._510nm = SQLiteReader("510nm")
            spectral._520nm = SQLiteReader("520nm")
            spectral._530nm = SQLiteReader("530nm")
            spectral._540nm = SQLiteReader("540nm")
            spectral._550nm = SQLiteReader("550nm")
            spectral._560nm = SQLiteReader("560nm")
            spectral._570nm = SQLiteReader("570nm")
            spectral._580nm = SQLiteReader("580nm")
            spectral._590nm = SQLiteReader("590nm")
            spectral._600nm = SQLiteReader("600nm")
            spectral._610nm = SQLiteReader("610nm")
            spectral._620nm = SQLiteReader("620nm")
            spectral._630nm = SQLiteReader("630nm")
            spectral._640nm = SQLiteReader("640nm")
            spectral._650nm = SQLiteReader("650nm")
            spectral._660nm = SQLiteReader("660nm")
            spectral._670nm = SQLiteReader("670nm")
            spectral._680nm = SQLiteReader("680nm")
            spectral._690nm = SQLiteReader("690nm")
            spectral._700nm = SQLiteReader("700nm")
            spectral.l = SQLiteReader("l").ToString()
            spectral.a = SQLiteReader("a").ToString()
            spectral.b = SQLiteReader("b").ToString()
            spectral.effect = SQLiteReader("effect")

            If Not SQLiteReader("Tricoat") Is Nothing Then
                spectral.tricoat = Boolean.Parse(SQLiteReader("Tricoat"))
            End If


            spectral.labValue = New LabValueCS(spectral.l, spectral.a, spectral.b)
            '' spectral.rgbValueCS = ColorimetryCS.ToRGB(spectral.labValue)

            Dim waveSpectralAverageValuesMap As New Dictionary(Of Integer, Double)
            waveSpectralAverageValuesMap.Add(0, spectral._400nm)
            waveSpectralAverageValuesMap.Add(1, spectral._410nm)
            waveSpectralAverageValuesMap.Add(2, spectral._420nm)
            waveSpectralAverageValuesMap.Add(3, spectral._430nm)
            waveSpectralAverageValuesMap.Add(4, spectral._440nm)
            waveSpectralAverageValuesMap.Add(5, spectral._450nm)
            waveSpectralAverageValuesMap.Add(6, spectral._460nm)
            waveSpectralAverageValuesMap.Add(7, spectral._470nm)
            waveSpectralAverageValuesMap.Add(8, spectral._480nm)
            waveSpectralAverageValuesMap.Add(9, spectral._490nm)
            waveSpectralAverageValuesMap.Add(10, spectral._500nm)
            waveSpectralAverageValuesMap.Add(11, spectral._510nm)
            waveSpectralAverageValuesMap.Add(12, spectral._520nm)
            waveSpectralAverageValuesMap.Add(13, spectral._530nm)
            waveSpectralAverageValuesMap.Add(14, spectral._540nm)
            waveSpectralAverageValuesMap.Add(15, spectral._550nm)
            waveSpectralAverageValuesMap.Add(16, spectral._560nm)
            waveSpectralAverageValuesMap.Add(17, spectral._570nm)
            waveSpectralAverageValuesMap.Add(18, spectral._580nm)
            waveSpectralAverageValuesMap.Add(19, spectral._590nm)
            waveSpectralAverageValuesMap.Add(20, spectral._600nm)
            waveSpectralAverageValuesMap.Add(21, spectral._610nm)
            waveSpectralAverageValuesMap.Add(22, spectral._620nm)
            waveSpectralAverageValuesMap.Add(23, spectral._630nm)
            waveSpectralAverageValuesMap.Add(24, spectral._640nm)
            waveSpectralAverageValuesMap.Add(25, spectral._650nm)
            waveSpectralAverageValuesMap.Add(26, spectral._660nm)
            waveSpectralAverageValuesMap.Add(27, spectral._670nm)
            waveSpectralAverageValuesMap.Add(29, spectral._680nm)
            waveSpectralAverageValuesMap.Add(30, spectral._690nm)
            waveSpectralAverageValuesMap.Add(31, spectral._700nm)
            Dim colorSpectrumCS As ColorSpectrumCS = New ColorSpectrumCS(GeometryCS.Geometry45as45, New SpectralRangeCS(400, 700, 10), waveSpectralAverageValuesMap.Values.ToList)
            spectral.colorSpectrumCS = colorSpectrumCS


            allColorsForSolidTarget.Add(spectral)
        End While

        SQLiteReader.Close()
        closeDbConnection()

        Return allColorsForSolidTarget
    End Function

    Public Function getAllColorsForEffectTarget(geometriesInMachineDb As List(Of String)) As List(Of SpectralDB)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        Dim tableName As String = "spectral_bc"
        If NucleosSearchForm.cmbCoats.Text.ToLower = "ls" Then
            tableName = "spectral_ls"
        End If


        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT rowID, * from " & tableName & " where "
        Dim i As Integer = 0
        For Each g In geometriesInMachineDb
            SQLitecmd.CommandText &= " geometry like '%" & g & "%' "
            If i < geometriesInMachineDb.Count - 1 Then
                SQLitecmd.CommandText &= " or "
            End If

            i += 1
        Next

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim allColorsForSolidTarget As New List(Of SpectralDB)
        While SQLiteReader.Read()
            Dim spectral As New SpectralDB()
            spectral.rowId = SQLiteReader("rowID")
            spectral.SampleId = SQLiteReader("SampleId")
            spectral.Substrate = SQLiteReader("Substrate")
            spectral.SampleName = SQLiteReader("Sample name")
            spectral.DateTime = SQLiteReader("DateTime")
            spectral.Geometry = SQLiteReader("Geometry")
            spectral._400nm = SQLiteReader("400nm")
            spectral._410nm = SQLiteReader("410nm")
            spectral._420nm = SQLiteReader("420nm")
            spectral._430nm = SQLiteReader("430nm")
            spectral._440nm = SQLiteReader("440nm")
            spectral._450nm = SQLiteReader("450nm")
            spectral._460nm = SQLiteReader("460nm")
            spectral._470nm = SQLiteReader("470nm")
            spectral._480nm = SQLiteReader("480nm")
            spectral._490nm = SQLiteReader("490nm")
            spectral._500nm = SQLiteReader("500nm")
            spectral._510nm = SQLiteReader("510nm")
            spectral._520nm = SQLiteReader("520nm")
            spectral._530nm = SQLiteReader("530nm")
            spectral._540nm = SQLiteReader("540nm")
            spectral._550nm = SQLiteReader("550nm")
            spectral._560nm = SQLiteReader("560nm")
            spectral._570nm = SQLiteReader("570nm")
            spectral._580nm = SQLiteReader("580nm")
            spectral._590nm = SQLiteReader("590nm")
            spectral._600nm = SQLiteReader("600nm")
            spectral._610nm = SQLiteReader("610nm")
            spectral._620nm = SQLiteReader("620nm")
            spectral._630nm = SQLiteReader("630nm")
            spectral._640nm = SQLiteReader("640nm")
            spectral._650nm = SQLiteReader("650nm")
            spectral._660nm = SQLiteReader("660nm")
            spectral._670nm = SQLiteReader("670nm")
            spectral._680nm = SQLiteReader("680nm")
            spectral._690nm = SQLiteReader("690nm")
            spectral._700nm = SQLiteReader("700nm")
            spectral.l = SQLiteReader("l").ToString()
            spectral.a = SQLiteReader("a").ToString()
            spectral.b = SQLiteReader("b").ToString()
            spectral.effect = SQLiteReader("effect")
            If Not SQLiteReader("Tricoat") Is Nothing Then
                spectral.tricoat = Boolean.Parse(SQLiteReader("Tricoat"))
            End If
            spectral.labValue = New LabValueCS(spectral.l, spectral.a, spectral.b)
            ''spectral.rgbValueCS = ColorimetryCS.ToRGB(spectral.labValue)

            Dim waveSpectralAverageValuesMap As New Dictionary(Of Integer, Double)
            waveSpectralAverageValuesMap.Add(0, spectral._400nm)
            waveSpectralAverageValuesMap.Add(1, spectral._410nm)
            waveSpectralAverageValuesMap.Add(2, spectral._420nm)
            waveSpectralAverageValuesMap.Add(3, spectral._430nm)
            waveSpectralAverageValuesMap.Add(4, spectral._440nm)
            waveSpectralAverageValuesMap.Add(5, spectral._450nm)
            waveSpectralAverageValuesMap.Add(6, spectral._460nm)
            waveSpectralAverageValuesMap.Add(7, spectral._470nm)
            waveSpectralAverageValuesMap.Add(8, spectral._480nm)
            waveSpectralAverageValuesMap.Add(9, spectral._490nm)
            waveSpectralAverageValuesMap.Add(10, spectral._500nm)
            waveSpectralAverageValuesMap.Add(11, spectral._510nm)
            waveSpectralAverageValuesMap.Add(12, spectral._520nm)
            waveSpectralAverageValuesMap.Add(13, spectral._530nm)
            waveSpectralAverageValuesMap.Add(14, spectral._540nm)
            waveSpectralAverageValuesMap.Add(15, spectral._550nm)
            waveSpectralAverageValuesMap.Add(16, spectral._560nm)
            waveSpectralAverageValuesMap.Add(17, spectral._570nm)
            waveSpectralAverageValuesMap.Add(18, spectral._580nm)
            waveSpectralAverageValuesMap.Add(19, spectral._590nm)
            waveSpectralAverageValuesMap.Add(20, spectral._600nm)
            waveSpectralAverageValuesMap.Add(21, spectral._610nm)
            waveSpectralAverageValuesMap.Add(22, spectral._620nm)
            waveSpectralAverageValuesMap.Add(23, spectral._630nm)
            waveSpectralAverageValuesMap.Add(24, spectral._640nm)
            waveSpectralAverageValuesMap.Add(25, spectral._650nm)
            waveSpectralAverageValuesMap.Add(26, spectral._660nm)
            waveSpectralAverageValuesMap.Add(27, spectral._670nm)
            waveSpectralAverageValuesMap.Add(29, spectral._680nm)
            waveSpectralAverageValuesMap.Add(30, spectral._690nm)
            waveSpectralAverageValuesMap.Add(31, spectral._700nm)
            Dim colorSpectrumCS As ColorSpectrumCS = New ColorSpectrumCS(GeometryCS.Geometry45as45, New SpectralRangeCS(400, 700, 10), waveSpectralAverageValuesMap.Values.ToList)
            spectral.colorSpectrumCS = colorSpectrumCS


            allColorsForSolidTarget.Add(spectral)
        End While

        SQLiteReader.Close()
        closeDbConnection()

        Return allColorsForSolidTarget
    End Function

    Public Function retrieveAllGeometrySpectralBySampleId(sampleId As String, geometryList As List(Of String), coat As String) As List(Of SpectralDB)



        Console.WriteLine("openDbConnection start " & DateTime.Now.ToString("HH:mm:ss.fff"))
        openDbConnection()


        Console.WriteLine("openDbConnection: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))


        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader


        SQLitecmd.Connection = SQLiteConn
        Dim tableName As String
        If coat.ToUpper = "LS" Then
            tableName = "spectral_ls"

        Else
            tableName = "spectral_bc"
        End If


        SQLitecmd.CommandText = "SELECT rowID, * from " & tableName & " where sampleId='" & sampleId & "' ORDER BY rowID"
        SQLiteReader = SQLitecmd.ExecuteReader()


        Console.WriteLine("ExecuteReader: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))


        '' GC.TryStartNoGCRegion(1000000) ' Prevents GC if possible

        ''Dim result As New List(Of SpectralDB)
        Dim result As New List(Of SpectralDB)(100)
        While SQLiteReader.Read()

            Console.WriteLine("read: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))
            Dim spectral As New SpectralDB()
            spectral.rowId = SQLiteReader("rowID")
            spectral.SampleId = SQLiteReader("SampleId")
            spectral.Substrate = SQLiteReader("Substrate")
            spectral.SampleName = SQLiteReader("Sample name")
            spectral.DateTime = SQLiteReader("DateTime")
            spectral.Geometry = SQLiteReader("Geometry").trim

            Console.WriteLine("first settings: Elapsed Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))

            If Not geometryList.Contains("r" & spectral.Geometry) Then
                Console.WriteLine("in Not geometryList: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))
                Continue While
            End If
            Console.WriteLine("out Not geometryList: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))

            spectral._400nm = SQLiteReader("400nm")
            spectral._410nm = SQLiteReader("410nm")
            spectral._420nm = SQLiteReader("420nm")
            spectral._430nm = SQLiteReader("430nm")
            spectral._440nm = SQLiteReader("440nm")
            spectral._450nm = SQLiteReader("450nm")
            spectral._460nm = SQLiteReader("460nm")
            spectral._470nm = SQLiteReader("470nm")
            spectral._480nm = SQLiteReader("480nm")
            spectral._490nm = SQLiteReader("490nm")
            spectral._500nm = SQLiteReader("500nm")
            spectral._510nm = SQLiteReader("510nm")
            spectral._520nm = SQLiteReader("520nm")
            spectral._530nm = SQLiteReader("530nm")
            spectral._540nm = SQLiteReader("540nm")
            spectral._550nm = SQLiteReader("550nm")
            spectral._560nm = SQLiteReader("560nm")
            spectral._570nm = SQLiteReader("570nm")
            spectral._580nm = SQLiteReader("580nm")
            spectral._590nm = SQLiteReader("590nm")
            spectral._600nm = SQLiteReader("600nm")
            spectral._610nm = SQLiteReader("610nm")
            spectral._620nm = SQLiteReader("620nm")
            spectral._630nm = SQLiteReader("630nm")
            spectral._640nm = SQLiteReader("640nm")
            spectral._650nm = SQLiteReader("650nm")
            spectral._660nm = SQLiteReader("660nm")
            spectral._670nm = SQLiteReader("670nm")
            spectral._680nm = SQLiteReader("680nm")
            spectral._690nm = SQLiteReader("690nm")
            spectral._700nm = SQLiteReader("700nm")
            spectral.l = SQLiteReader("l").ToString()
            spectral.a = SQLiteReader("a").ToString()
            spectral.b = SQLiteReader("b").ToString()
            spectral.effect = SQLiteReader("effect")
            spectral.tricoat = Boolean.Parse(SQLiteReader("Tricoat"))
            spectral.labValue = New LabValueCS(spectral.l, spectral.a, spectral.b)


            Console.WriteLine("second settings: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))


            Dim waveSpectralAverageValuesMap As New Dictionary(Of Integer, Double)
            waveSpectralAverageValuesMap.Add(0, spectral._400nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(1, spectral._410nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(2, spectral._420nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(3, spectral._430nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(4, spectral._440nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(5, spectral._450nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(6, spectral._460nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(7, spectral._470nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(8, spectral._480nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(9, spectral._490nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(10, spectral._500nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(11, spectral._510nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(12, spectral._520nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(13, spectral._530nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(14, spectral._540nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(15, spectral._550nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(16, spectral._560nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(17, spectral._570nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(18, spectral._580nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(19, spectral._590nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(20, spectral._600nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(21, spectral._610nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(22, spectral._620nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(23, spectral._630nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(24, spectral._640nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(25, spectral._650nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(26, spectral._660nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(27, spectral._670nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(29, spectral._680nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(30, spectral._690nm * 100 / 10000)
            waveSpectralAverageValuesMap.Add(31, spectral._700nm * 100 / 10000)


            Console.WriteLine("waveSpectralAverageValuesMap adds: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))



            Dim geometry As GeometryCS
            Select Case spectral.Geometry
                Case "45as-15"
                    geometry = GeometryCS.Geometry45asMinus15
                Case "45as15"
                    geometry = GeometryCS.Geometry45as15
                Case "45as25"
                    geometry = GeometryCS.Geometry45as25
                Case "45as45"
                    geometry = GeometryCS.Geometry45as45
                Case "45as75"
                    geometry = GeometryCS.Geometry45as75
                Case "45as110"
                    geometry = GeometryCS.Geometry45as110
            End Select

            Console.WriteLine("select adds: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))



            Dim colorSpectrumCS As ColorSpectrumCS = New ColorSpectrumCS(geometry, New SpectralRangeCS(400, 700, 10), waveSpectralAverageValuesMap.Values.ToList)

            Console.WriteLine("new ColorSpectrumCS: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))


            spectral.colorSpectrumCS = colorSpectrumCS


            result.Add(spectral)
            Console.WriteLine("result.add: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))

        End While

        Console.WriteLine("While total: Time: " & DateTime.Now.ToString("HH:mm:ss.fff"))
        '' GC.EndNoGCRegion()

        SQLiteReader.Close()
        closeDbConnection()

        Return result


    End Function

    Public Function retrieveRecipeBySampleId(sampleId As String, Optional coat As String = Nothing) As List(Of RecipeDB)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader
        Dim currentCoat As String = ""

        If coat Is Nothing Then
            currentCoat = NucleosSearchForm.cmbCoats.Text
        Else
            currentCoat = coat
        End If

        Dim tableName As String = "recipes_bc"
        If currentCoat.ToLower = "ls" Then
            tableName = "recipes_ls"
        End If

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT r.rowID, * from " & tableName & " r where SampleID='" & sampleId & "'"
        SQLiteReader = SQLitecmd.ExecuteReader()
        Dim result As New List(Of RecipeDB)

        While SQLiteReader.Read()
            Dim recipe As New RecipeDB()
            recipe.rowId = SQLiteReader("rowID")
            recipe.SampleID = SQLiteReader("SampleId")
            recipe.Layer = SQLiteReader("Layer")
            recipe.Component = SQLiteReader("Component")
            If recipe.Component IsNot Nothing Then
                recipe.Component = recipe.Component.Trim
            End If
            recipe.Quantity = SQLiteReader("Quantity")
            result.Add(recipe)
        End While
        SQLiteReader.Close()
        closeDbConnection()
        Return result
    End Function

    Public Function retrieveColorImgPath(color As String) As String
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader


        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT rowID, * from color where LOWER(name_color) like '%" & color & "%'"
        SQLiteReader = SQLitecmd.ExecuteReader()
        Dim result As String = ""

        If SQLiteReader.Read() Then
            result = SQLiteReader("colorImgPath")
        End If
        SQLiteReader.Close()
        closeDbConnection()
        Return result
    End Function

    Public Function retrieveComponentType(component As String) As String
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader


        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT rowID, * from baseCoats_type where Component like '" & component & "%'"
        SQLiteReader = SQLitecmd.ExecuteReader()
        Dim result As String = "solid"

        If SQLiteReader.Read() Then
            result = SQLiteReader("Type")
        End If
        SQLiteReader.Close()
        closeDbConnection()
        Return result
    End Function

    Public Function getFormulaEffect(sampleId As String) As String
        Dim tableName As String = "recipes_bc"
        If NucleosSearchForm.cmbCoats.Text.ToLower = "ls" Then
            tableName = "recipes_ls"
        End If

        Dim result As String = "S"
        Using c As SQLiteConnection = New SQLiteConnection(connectionString)
            c.Open()
            Dim sql = "SELECT rowID, * from " & tableName & " where SampleID='" & sampleId & "'"
            Using cmd As SQLiteCommand = New SQLiteCommand(sql, c)
                Using reader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim component As String = reader("Component")
                        If component IsNot Nothing Then
                            component = component.Trim
                        End If
                        If component.ToLower.Trim.StartsWith("ls") Then
                            Return "S"
                        End If

                        Dim componentType As String = getBaseCoatType(component)
                        If componentType = "X" Then
                            result = "X"
                            Exit While
                        End If
                        If componentType = "M" Then
                            If result = "P" Then
                                result = "MP"
                                Exit While
                            Else
                                result = "M"
                            End If
                        End If
                        If componentType = "P" Then
                            If result = "M" Then
                                result = "MP"
                                Exit While
                            Else
                                result = "P"
                            End If
                        End If
                    End While
                End Using
            End Using
        End Using



        Return result

    End Function
    Public Function isTricoat(sampleId As String) As Boolean
        Dim tableName As String = "recipes_bc"
        If NucleosSearchForm.cmbCoats.Text.ToLower = "ls" Then
            tableName = "recipes_ls"
        End If

        Dim result As Boolean = False
        Using c As SQLiteConnection = New SQLiteConnection(connectionString)
            c.Open()
            Dim sql = "SELECT rowID, * from " & tableName & " where SampleID='" & sampleId & "'"
            Using cmd As SQLiteCommand = New SQLiteCommand(sql, c)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim layer As Integer = reader("Layer")

                        If layer > 1 Then
                            result = True
                            Exit While
                        End If
                    End While
                End Using
            End Using
        End Using
        Return result

    End Function
    Public Function getBaseCoatType(component As String) As String


        Using c As SQLiteConnection = New SQLiteConnection(connectionString)
            c.Open()
            Dim sql = "SELECT * from baseCoats_type where component like '%" & component.ToUpper & "%'"
            Using cmd As SQLiteCommand = New SQLiteCommand(sql, c)
                Using reader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim type As String = reader("type")

                        If type.ToLower.Trim = "solid" Then
                            Return "S"
                        ElseIf type.ToLower.Trim = "metallic" Then
                            Return "M"
                        ElseIf type.ToLower.Trim = "pearl" Then
                            Return "P"
                        ElseIf type.ToLower.Trim = "xirallic" Then
                            Return "X"
                        End If
                    End While
                End Using
            End Using
        End Using
        Return "S"

    End Function

    Public Function retrieveTagFileBySampleId(sampleId As String) As TagFile
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        Dim tableName As String = "Tag_File_BC"
        If NucleosSearchForm.cmbCoats.Text.ToLower = "ls" Then
            tableName = "Tag_File_LS"
        End If

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT rowID, * from " & tableName & " where SampleID='" & sampleId & "'"
        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim tagFile As New TagFile()

        If SQLiteReader.Read() Then
            tagFile.sampleId = SQLiteReader("SampleID")
            tagFile.tagBrand = SQLiteReader("Tag_Brand")
            tagFile.tagColorCode = SQLiteReader("Tag_Color Code")
            tagFile.tagColor = SQLiteReader("Tag_Color")
            'tagFile.tagEdition = SQLiteReader("Tag_Edition")

            'If NucleosSearchForm.cmbCoats.Text.ToLower = "bc" Then
            ''tagFile.evaluation = SQLiteReader("Evaluation")
            ''tagFile.coat = "BC"
            ''Else
            ''  tagFile.coat = "LS"
            ''End If

            ''    tagFile.bucket = SQLiteReader("BUCKET")
            ''  tagFile.database = SQLiteReader("Database")
            tagFile.tagCoarseness = SQLiteReader("Tag_Coarseness")

        End If
        SQLiteReader.Close()
        closeDbConnection()
        Return tagFile
    End Function


    Public Function createJob(job As Job) As Long
        Try
            openDbConnection()
            Dim SQLitecmd As New SQLiteCommand
            SQLitecmd.Connection = SQLiteConn
            SQLitecmd.CommandText = "INSERT INTO Job (jobName, sampleCountForJob) VALUES (@jobName, @sampleCountForJob)"

            SQLitecmd.Parameters.AddWithValue("@jobName", job.jobName)
            SQLitecmd.Parameters.AddWithValue("@sampleCountForJob", job.sampleCountForJob)

            SQLitecmd.ExecuteNonQuery()

            ' Récupérer l'ID du job inséré
            SQLitecmd.CommandText = "SELECT last_insert_rowid()"
            Dim jobId As Long = CLng(SQLitecmd.ExecuteScalar())

            closeDbConnection()
            Return jobId
        Catch ex As Exception
            closeDbConnection()
            Return -1 ' Retourne -1 en cas d'erreur
        End Try
    End Function


    Public Function retrieveJobById(jobId As Long) As Job
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT * FROM Job WHERE jobId = @jobId"
        SQLitecmd.Parameters.AddWithValue("@jobId", jobId)

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim job As New Job()

        If SQLiteReader.Read() Then
            job.jobId = SQLiteReader("jobId")
            job.jobName = SQLiteReader("jobName")
            job.sampleCountForJob = SQLiteReader("sampleCountForJob")
            job.jobFromHistory = True
        End If

        SQLiteReader.Close()
        closeDbConnection()
        Return job
    End Function
    Public Function retrieveJobByName(jobName As Long) As Job
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT * FROM Job WHERE jobName = @jobName"
        SQLitecmd.Parameters.AddWithValue("@jobName", jobName)

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim job As New Job()

        If SQLiteReader.Read() Then
            job.jobId = SQLiteReader("jobId")
            job.jobName = SQLiteReader("jobName")
            job.sampleCountForJob = SQLiteReader("sampleCountForJob")
            job.jobFromHistory = True
        End If

        SQLiteReader.Close()
        closeDbConnection()
        Return job
    End Function
    Public Function retrieveAllJobs() As List(Of Job)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT * FROM Job"

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim jobList As New List(Of Job)()

        While SQLiteReader.Read()
            Dim job As New Job()
            job.jobId = SQLiteReader("jobId")
            job.jobName = SQLiteReader("jobName")
            job.sampleCountForJob = SQLiteReader("sampleCountForJob")
            job.jobFromHistory = True
            jobList.Add(job)
        End While

        SQLiteReader.Close()
        closeDbConnection()
        Return jobList
    End Function
    Public Sub deleteJobByName(jobName As String)
        Try
            openDbConnection()
            Dim SQLitecmd As New SQLiteCommand
            SQLitecmd.Connection = SQLiteConn
            SQLitecmd.CommandText = "DELETE FROM Job WHERE jobName = @jobName"
            SQLitecmd.Parameters.AddWithValue("@jobName", jobName)

            Dim rowsAffected As Integer = SQLitecmd.ExecuteNonQuery()
            closeDbConnection()

        Catch ex As Exception
            closeDbConnection()
            MessageBox.Show("Erreur deleting job : " & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function createSample(sample As Sample) As Long
        Try
            openDbConnection()
            Dim SQLitecmd As New SQLiteCommand
            SQLitecmd.Connection = SQLiteConn
            SQLitecmd.CommandText = "INSERT INTO Sample (wlCount, datSetCount, jobId, " &
            "wlIndex_1, wlIndex_2, wlIndex_3, wlIndex_4, wlIndex_5, wlIndex_6, wlIndex_7, wlIndex_8, wlIndex_9, wlIndex_10, " &
            "wlIndex_11, wlIndex_12, wlIndex_13, wlIndex_14, wlIndex_15, wlIndex_16, wlIndex_17, wlIndex_18, wlIndex_19, wlIndex_20, " &
            "wlIndex_21, wlIndex_22, wlIndex_23, wlIndex_24, wlIndex_25, wlIndex_26, wlIndex_27, wlIndex_28, wlIndex_29, wlIndex_30, wlIndex_31) " &
            "VALUES (@wlCount, @datSetCount, @jobId, " &
            "@wlIndex_1, @wlIndex_2, @wlIndex_3, @wlIndex_4, @wlIndex_5, @wlIndex_6, @wlIndex_7, @wlIndex_8, @wlIndex_9, @wlIndex_10, " &
            "@wlIndex_11, @wlIndex_12, @wlIndex_13, @wlIndex_14, @wlIndex_15, @wlIndex_16, @wlIndex_17, @wlIndex_18, @wlIndex_19, @wlIndex_20, " &
            "@wlIndex_21, @wlIndex_22, @wlIndex_23, @wlIndex_24, @wlIndex_25, @wlIndex_26, @wlIndex_27, @wlIndex_28, @wlIndex_29, @wlIndex_30, @wlIndex_31)"

            SQLitecmd.Parameters.AddWithValue("@wlCount", sample.wlCount)
            SQLitecmd.Parameters.AddWithValue("@datSetCount", sample.datSetCount)
            SQLitecmd.Parameters.AddWithValue("@jobId", sample.jobId)

            ' Ajouter les 31 valeurs des longueurs d'onde
            For i As Integer = 0 To 30
                Dim paramName As String = "@wlIndex_" & (i + 1).ToString()
                If i < sample.wlIndexes.Count Then
                    SQLitecmd.Parameters.AddWithValue(paramName, sample.wlIndexes(i))
                Else
                    SQLitecmd.Parameters.AddWithValue(paramName, DBNull.Value)
                End If
            Next

            SQLitecmd.ExecuteNonQuery()

            ' Récupérer l'ID généré
            SQLitecmd.CommandText = "SELECT last_insert_rowid()"
            Dim sampleId As Long = CLng(SQLitecmd.ExecuteScalar())

            closeDbConnection()
            Return sampleId
        Catch ex As Exception
            closeDbConnection()
            Return -1 ' Retourne -1 en cas d'erreur
        End Try
    End Function

    Public Function retrieveSamplesByJobId(jobId As Long) As List(Of Sample)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT * FROM Sample WHERE jobId = @jobId"
        SQLitecmd.Parameters.AddWithValue("@jobId", jobId)

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim sampleList As New List(Of Sample)()

        While SQLiteReader.Read()
            Dim sample As New Sample()
            sample.wlCount = SQLiteReader("wlCount")
            sample.datSetCount = SQLiteReader("datSetCount")
            sample.sampleId = SQLiteReader("sampleId")
            ' Récupérer les 31 indices de longueurs d'onde
            sample.wlIndexes = New List(Of Integer)()
            For i As Integer = 1 To 31
                Dim colName As String = "wlIndex_" & i.ToString()
                If Not SQLiteReader.IsDBNull(SQLiteReader.GetOrdinal(colName)) Then
                    sample.wlIndexes.Add(SQLiteReader(colName))
                Else
                    sample.wlIndexes.Add(0) ' Valeur par défaut si NULL
                End If
            Next

            sampleList.Add(sample)
        End While

        SQLiteReader.Close()
        closeDbConnection()
        Return sampleList
    End Function


    Public Function retrieveSampleById(sampleId As Long) As Sample
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT * FROM Sample WHERE sampleId = @sampleId"
        SQLitecmd.Parameters.AddWithValue("@sampleId", sampleId)

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim sample As New Sample()

        If SQLiteReader.Read() Then
            sample.wlCount = SQLiteReader("wlCount")
            sample.datSetCount = SQLiteReader("datSetCount")
            sample.sampleId = SQLiteReader("sampleId")
            ' Récupérer les 31 longueurs d'onde
            sample.wlIndexes = New List(Of Integer)()
            For i As Integer = 1 To 31
                Dim colName As String = "wlIndex_" & i.ToString()
                If Not SQLiteReader.IsDBNull(SQLiteReader.GetOrdinal(colName)) Then
                    sample.wlIndexes.Add(SQLiteReader(colName))
                End If
            Next
        End If

        SQLiteReader.Close()
        closeDbConnection()
        Return sample
    End Function


    Public Function createSampleDataSet(dataset As SampleDataSet) As Boolean
        Try
            openDbConnection()
            Dim SQLitecmd As New SQLiteCommand
            SQLitecmd.Connection = SQLiteConn
            SQLitecmd.CommandText = "INSERT INTO SampleDataSet (sampleId, spectralSetName, " &
                "wlValue_1, wlValue_2, wlValue_3, wlValue_4, wlValue_5, wlValue_6, wlValue_7, wlValue_8, wlValue_9, wlValue_10, " &
                "wlValue_11, wlValue_12, wlValue_13, wlValue_14, wlValue_15, wlValue_16, wlValue_17, wlValue_18, wlValue_19, wlValue_20, " &
                "wlValue_21, wlValue_22, wlValue_23, wlValue_24, wlValue_25, wlValue_26, wlValue_27, wlValue_28, wlValue_29, wlValue_30, wlValue_31) " &
                "VALUES (@sampleId, @spectralSetName, " &
                "@wlValue_1, @wlValue_2, @wlValue_3, @wlValue_4, @wlValue_5, @wlValue_6, @wlValue_7, @wlValue_8, @wlValue_9, @wlValue_10, " &
                "@wlValue_11, @wlValue_12, @wlValue_13, @wlValue_14, @wlValue_15, @wlValue_16, @wlValue_17, @wlValue_18, @wlValue_19, @wlValue_20, " &
                "@wlValue_21, @wlValue_22, @wlValue_23, @wlValue_24, @wlValue_25, @wlValue_26, @wlValue_27, @wlValue_28, @wlValue_29, @wlValue_30, @wlValue_31)"

            SQLitecmd.Parameters.AddWithValue("@sampleId", dataset.sampleId)
            SQLitecmd.Parameters.AddWithValue("@spectralSetName", dataset.spectralSetName)

            ' Ajouter les 31 valeurs spectrales
            For i As Integer = 0 To 30
                SQLitecmd.Parameters.AddWithValue("@wlValue_" & (i + 1), If(i < dataset.wlValues.Count, dataset.wlValues(i), DBNull.Value))
            Next

            SQLitecmd.ExecuteNonQuery()
            closeDbConnection()
            Return True
        Catch ex As Exception
            closeDbConnection()
            Return False
        End Try
    End Function

    Public Function retrieveSampleDataSetBySampleId(sampleId As Long) As List(Of SampleDataSet)
        openDbConnection()
        Dim SQLitecmd As New SQLiteCommand
        Dim SQLiteReader As SQLiteDataReader

        SQLitecmd.Connection = SQLiteConn
        SQLitecmd.CommandText = "SELECT * FROM SampleDataSet WHERE sampleId = @sampleId"
        SQLitecmd.Parameters.AddWithValue("@sampleId", sampleId)

        SQLiteReader = SQLitecmd.ExecuteReader()

        Dim dataSets As New List(Of SampleDataSet)()

        While SQLiteReader.Read()
            Dim dataset As New SampleDataSet()
            dataset.spectralSetName = SQLiteReader("spectralSetName")

            ' Récupérer les 31 valeurs spectrales
            dataset.wlValues = New List(Of Double)()
            For i As Integer = 1 To 31
                Dim colName As String = "wlValue_" & i.ToString()
                If Not SQLiteReader.IsDBNull(SQLiteReader.GetOrdinal(colName)) Then
                    dataset.wlValues.Add(SQLiteReader(colName))
                Else
                    dataset.wlValues.Add(0) ' Valeur par défaut si NULL
                End If
            Next

            dataSets.Add(dataset)
        End While

        SQLiteReader.Close()
        closeDbConnection()
        Return dataSets
    End Function

End Module


