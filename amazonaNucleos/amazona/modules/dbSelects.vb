Imports System.Globalization

Module dbSelects
    Public password As String = "A!mA@HaP#pYZ$o"
    Public conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory() & "//dbPaintShop.mdb;Jet OLEDB:Database Password=" & password & ";"
    Public DB As New OleDb.OleDbConnection

#Region "optimization"
    Public Function getFormulaColorByIdFormulaOpt(ByVal formulaId As Integer) As FormulaColor()
        Dim allFormulaColorsClone As FormulaColor() = getFormulaColorsClone()
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulaColorsClone.Length - 1
            If allFormulaColorsClone(i).id_formula = formulaId Then
                MyArray.Add(allFormulaColorsClone(i))
            End If

        Next
        Dim formulaColorTab() As FormulaColor = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        Return formulaColorTab
    End Function

    Public Function getFormulaColorByIdFormulaClientOpt(ByVal formulaId As Integer) As FormulaColor()
        Dim allFormulaColorsClone As FormulaColor() = getFormulaColorsClientClone()
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulaColorsClone.Length - 1
            If allFormulaColorsClone(i).id_formula = formulaId Then
                MyArray.Add(allFormulaColorsClone(i))
            End If

        Next
        Dim formulaColorTab() As FormulaColor = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        Return formulaColorTab

    End Function

    Public Function getAllFormulas(ByVal oldDb As Boolean) As Formula()
        Dim MyArray As New ArrayList
        Dim conxOpen As Boolean = False

        conxOpen = openConnectionNewDb()

        If conxOpen Then
            Try

                Dim query As String = "Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,modified_once from ("
                query &= " Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,modified_once FROM [formula],[car] WHERE formula.id_car=car.id_car "
                query &= " UNION ALL Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,modified_once FROM [clientFormula],[car] WHERE clientFormula.id_car=car.id_car ORDER BY carName,colorCode,version"
                query &= ")"

                Dim startTime As DateTime
                Dim endTime As DateTime

                startTime = Now
                Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                endTime = Now
                Dim duration As TimeSpan = endTime - startTime
                myConsoleLog.WriteLine("select query took:" & duration.ToString)

                Dim i As Integer = 0

                startTime = Now
                While DR.Read
                    Dim type As String = ""
                    If Not DR.Item("type") Is DBNull.Value Then
                        type = DR.Item("type")
                    End If
                    If chosenGarage.coat.ToUpper = "LS" And type.ToUpper = "2K" Then
                        Continue While
                    ElseIf chosenGarage.coat.ToUpper = "2K" And type.ToUpper = "LS" Then
                        Continue While
                    End If
                    Dim newFormula As New Formula
                    newFormula.id_formula = DR.Item("id_formula")
                    If Not DR.Item("formulaImgPath") Is DBNull.Value Then
                        newFormula.formulaImgPath = DR.Item("formulaImgPath")
                    End If
                    If Not DR.Item("otherPrice") Is DBNull.Value Then
                        newFormula.otherPrice = DR.Item("otherPrice")
                    End If
                    If Not DR.Item("id_otherCurreny") Is DBNull.Value Then
                        newFormula.id_otherCurreny = DR.Item("id_otherCurreny")
                    End If
                    If Not DR.Item("id_otherUnit") Is DBNull.Value Then
                        newFormula.id_otherUnit = DR.Item("id_otherUnit")
                    End If
                    If Not DR.Item("type") Is DBNull.Value Then
                        newFormula.type = DR.Item("type")
                    End If
                    If Not DR.Item(0) Is DBNull.Value Then
                        newFormula.id_car = DR.Item(0)
                    End If
                    If Not DR.Item(1) Is DBNull.Value Then
                        newFormula.name_car = DR.Item(1)
                    End If
                    If Not DR.Item("name_formula") Is DBNull.Value Then
                        newFormula.name_formula = DR.Item("name_formula")
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        newFormula.version = DR.Item("version")
                    End If
                    If Not DR.Item("variant") Is DBNull.Value Then
                        newFormula.formulaVariant = DR.Item("variant")
                    End If
                    If Not DR.Item("duplicate") Is DBNull.Value Then
                        newFormula.duplicate = DR.Item("duplicate")
                    End If
                    If Not DR.Item("colorCode") Is DBNull.Value Then
                        newFormula.colorCode = DR.Item("colorCode")
                    End If
                    If Not DR.Item("colorRGB") Is DBNull.Value Then
                        newFormula.colorRGB = DR.Item("colorRGB")
                    End If
                    If Not DR.Item("c_year") Is DBNull.Value Then
                        newFormula.c_year = DR.Item("c_year")
                    End If
                    If Not DR.Item("clientName") Is DBNull.Value Then
                        newFormula.clientName = DR.Item("clientName")
                    End If

                    If Not DR.Item("id_formulaX") Is DBNull.Value Then
                        newFormula.id_formulaX = DR.Item("id_formulaX")
                    End If
                    If Not DR.Item("id_formulaXp") Is DBNull.Value Then
                        newFormula.id_formulaXp = DR.Item("id_formulaXp")
                    End If
                    If Not DR.Item("id_formulaX2p") Is DBNull.Value Then
                        newFormula.id_formulaX2p = DR.Item("id_formulaX2p")
                    End If

                    If Not DR.Item("id_formulaY") Is DBNull.Value Then
                        newFormula.id_formulaY = DR.Item("id_formulaY")
                    End If
                    If Not DR.Item("id_formulaYp") Is DBNull.Value Then
                        newFormula.id_formulaYp = DR.Item("id_formulaYp")
                    End If
                    If Not DR.Item("id_formulaY2p") Is DBNull.Value Then
                        newFormula.id_formulaY2p = DR.Item("id_formulaY2p")
                    End If

                    If Not DR.Item("id_formulaZ") Is DBNull.Value Then
                        newFormula.id_formulaZ = DR.Item("id_formulaZ")
                    End If
                    If Not DR.Item("id_formulaZp") Is DBNull.Value Then
                        newFormula.id_formulaZp = DR.Item("id_formulaZp")
                    End If
                    If Not DR.Item("id_formulaZ2p") Is DBNull.Value Then
                        newFormula.id_formulaZ2p = DR.Item("id_formulaZ2p")
                    End If

                    If Not DR.Item("cardNumber") Is DBNull.Value Then
                        newFormula.cardNumber = DR.Item("cardNumber")
                    End If

                    If Not DR.Item("modified_once") Is DBNull.Value Then
                        If DR.Item("modified_once") = 1 Then
                            newFormula.modified_once = True
                        Else
                            newFormula.modified_once = False
                        End If
                    Else
                        newFormula.modified_once = True 'we dont want to show an asteriks
                    End If

                    If Not DR.Item("date_cre_mod") Is DBNull.Value Then
                        Dim dateCreModStr As String = DR.Item("date_cre_mod")

                        Dim dateCreModStrTab() As String = dateCreModStr.Split(":")
                        Dim day As Integer = Integer.Parse(dateCreModStrTab(0))
                        Dim month As Integer = Integer.Parse(dateCreModStrTab(1))
                        Dim year As Integer = Integer.Parse(dateCreModStrTab(2))
                        Dim hour As Integer = Integer.Parse(dateCreModStrTab(3))
                        Dim minute As Integer = Integer.Parse(dateCreModStrTab(4))
                        Dim second As Integer = Integer.Parse(dateCreModStrTab(5))

                        'Dim dateCreMod As New DateTime(year, month, day, hour, minute, second)

                        Dim dayStr As String = day
                        If day < 10 Then
                            dayStr = "0" & day
                        End If

                        Dim monthStr As String = month
                        If month < 10 Then
                            monthStr = "0" & month
                        End If

                        Dim dateCreMod As New DateCreMod(year, monthStr, dayStr, hour, minute, second)

                        newFormula.dateCreMod = dateCreMod

                    End If
                    newFormula.oldDb = oldDb
                    MyArray.Add(newFormula)

                End While
                endTime = Now
                duration = endTime - startTime
                myConsoleLog.WriteLine("reading data took:" & duration.ToString)
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
    End Function

#End Region
#Region "Connection"


    Public Function openConnectionNewDb() As Boolean
        Try
            If DB.State = ConnectionState.Closed Or DB.State = ConnectionState.Broken Then
                DB.ConnectionString = conString
                DB.Open()
            End If
            openConnectionNewDb = True
        Catch ex As Exception
            openConnectionNewDb = False
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Function openConnectionSpecificDb(ByVal dbfileName As String) As Boolean
        Try
            Dim thisConString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbfileName & ";Jet OLEDB:Database Password=" & password & ";"
            If DB.State = ConnectionState.Closed Or DB.State = ConnectionState.Broken Then
                DB.ConnectionString = thisConString
                DB.Open()
            End If
            openConnectionSpecificDb = True
        Catch ex As Exception
            openConnectionSpecificDb = False
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function openConnection() As Boolean
        Try
            If DB.State = ConnectionState.Closed Or DB.State = ConnectionState.Broken Then
                DB.ConnectionString = conString
                DB.Open()
            End If
            openConnection = True
        Catch ex As Exception
            openConnection = False
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function closeConnection() As Boolean
        Try
            DB.Close()
            closeConnection = True
        Catch ex As Exception
            closeConnection = False
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Function selectQuery(ByVal query) As OleDb.OleDbDataReader
        Try
            Dim DR As OleDb.OleDbDataReader
            Dim DBC As New OleDb.OleDbCommand
            DBC.Connection = DB
            DBC.CommandText = query
            DR = DBC.ExecuteReader
            Return DR
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

#End Region

#Region "beansBinding"

    Public Function getLanguages() As Language()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [language]")
                Dim i As Integer = 0

                While DR.Read
                    Dim language As Language
                    language = New Language()

                    language.id_language = DR.Item("id_language")
                    If Not DR.Item("code_language") Is DBNull.Value Then
                        language.code_language = DR.Item("code_language")
                    End If
                    If Not DR.Item("dateTimeFormat") Is DBNull.Value Then
                        language.dateTimeFormat = DR.Item("dateTimeFormat")
                    End If
                    If Not DR.Item("isDefault") Is DBNull.Value Then
                        language.isDefault = DR.Item("isDefault")
                    End If
                    If Not DR.Item("label_language") Is DBNull.Value Then
                        language.label_language = DR.Item("label_language")
                    End If
                    MyArray.Add(language)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Language)), Language())
    End Function

    Public Function getUnits() As Unit()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [unit]")
                Dim i As Integer = 0

                While DR.Read
                    Dim newUnit As New Unit
                    newUnit.id_unit = DR.Item("id_unit")
                    If Not DR.Item("rateToLitre") Is DBNull.Value Then
                        newUnit.rateToLitre = DR.Item("rateToLitre")
                    End If
                    If Not DR.Item("code_unit") Is DBNull.Value Then
                        newUnit.code_unit = DR.Item("code_unit")
                    End If

                    Dim MyArray2 As New ArrayList
                    Dim unitLanguageTab() As UnitLanguage
                    Dim DR2 As OleDb.OleDbDataReader = selectQuery("Select * FROM unitLanguage where id_unit=" & DR.Item("id_unit"))
                    While DR2.Read
                        Dim unitLanguage As New UnitLanguage
                        unitLanguage.id_unitLanguage = DR2.Item("id_unitLanguage")
                        unitLanguage.id_unit = DR2.Item("id_unit")
                        unitLanguage.id_language = DR2.Item("id_language")
                        If Not DR2.Item("name_unit") Is DBNull.Value Then
                            unitLanguage.name_unit = DR2.Item("name_unit")
                        End If

                        MyArray2.Add(unitLanguage)
                    End While
                    DR2.Close()
                    unitLanguageTab = DirectCast(MyArray2.ToArray(GetType(UnitLanguage)), UnitLanguage())
                    newUnit.unitLanguage = unitLanguageTab
                    MyArray.Add(newUnit)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Unit)), Unit())
    End Function

    Public Function getColors() As AmazonaColor()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [color]")
                Dim i As Integer = 0

                While DR.Read
                    Dim newColor As New AmazonaColor
                    newColor.id_color = DR.Item("id_color")
                    If Not DR.Item("colorImgPath") Is DBNull.Value Then
                        newColor.colorImgPath = DR.Item("colorImgPath")
                    End If
                    If Not DR.Item("defaultPrice") Is DBNull.Value Then
                        newColor.defaultPrice = DR.Item("defaultPrice")
                    End If
                    If Not DR.Item("id_defaultCurreny") Is DBNull.Value Then
                        newColor.id_defaultCurreny = DR.Item("id_defaultCurreny")
                    End If
                    If Not DR.Item("id_defaultUnit") Is DBNull.Value Then
                        newColor.id_defaultUnit = DR.Item("id_defaultUnit")
                    End If
                    If Not DR.Item("name_color") Is DBNull.Value Then
                        newColor.name_color = DR.Item("name_color")
                    End If
                    If chosenGarage.showAlternativeName And Not DR.Item("name_color_alternative") Is DBNull.Value Then

                        If DR.Item("name_color_alternative").trim <> "" Then
                            Dim altColorName As String = decryptData(DR.Item("name_color_alternative"), password & chosenGarage.garage_name)
                            If altColorName <> "" Then
                                newColor.name_color = DR.Item("name_color_alternative")
                            End If

                        End If
                    End If

                    If chosenGarage.showAlternativeName2 And Not DR.Item("name_color_alternative2") Is DBNull.Value Then

                        If DR.Item("name_color_alternative2").trim <> "" Then
                            Dim altColorName As String = decryptData(DR.Item("name_color_alternative2"), password & chosenGarage.garage_name)
                            If altColorName <> "" Then
                                newColor.name_color = DR.Item("name_color_alternative2")
                            End If

                        End If
                    End If

                    If Not DR.Item("colorCode") Is DBNull.Value Then
                        newColor.colorCode = DR.Item("colorCode")
                    End If
                    If Not DR.Item("masse_volumique") Is DBNull.Value Then
                        newColor.masse_volumique = DR.Item("masse_volumique")
                    End If
                    If Not DR.Item("masse_volumique_ext") Is DBNull.Value Then
                        newColor.masse_volumique_ext = DR.Item("masse_volumique_ext")
                    End If
                    If Not DR.Item("id_unit_on_entry") Is DBNull.Value Then
                        newColor.id_unit_on_entry = DR.Item("id_unit_on_entry")
                    End If

                    'decryption
                    newColor.colorCode = decryptData(newColor.colorCode, password & chosenGarage.garage_name)
                    newColor.name_color = decryptData(newColor.name_color, password & chosenGarage.garage_name)


                    MyArray.Add(newColor)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(AmazonaColor)), AmazonaColor())
    End Function

    Public Function getCurrencies() As Currency()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [usercurrency]")
                Dim i As Integer = 0

                While DR.Read
                    Dim newCurrency As New Currency
                    newCurrency.id_currency = DR.Item("id_currency")
                    If Not DR.Item("code_currency") Is DBNull.Value Then
                        newCurrency.code_currency = DR.Item("code_currency")
                    End If
                    If Not DR.Item("symbol") Is DBNull.Value Then
                        newCurrency.symbol = DR.Item("symbol")
                    End If
                    If Not DR.Item("rateToDollar") Is DBNull.Value Then
                        newCurrency.rateToDollar = DR.Item("rateToDollar")
                    End If

                    Dim MyArray2 As New ArrayList
                    Dim currencyLanguageTab() As CurrencyLanguage
                    Dim DR2 As OleDb.OleDbDataReader = selectQuery("Select * FROM currencyLanguage where id_currency=" & DR.Item("id_currency"))
                    While DR2.Read
                        Dim currencyLanguage As New CurrencyLanguage
                        currencyLanguage.id_currencyLanguage = DR2.Item("id_currencyLanguage")
                        currencyLanguage.id_currency = DR2.Item("id_currency")
                        currencyLanguage.id_language = DR2.Item("id_language")
                        If Not DR2.Item("label") Is DBNull.Value Then
                            currencyLanguage.label = DR2.Item("label")
                        End If

                        MyArray2.Add(currencyLanguage)
                    End While
                    DR2.Close()
                    currencyLanguageTab = DirectCast(MyArray2.ToArray(GetType(CurrencyLanguage)), CurrencyLanguage())
                    newCurrency.currencyLanguage = currencyLanguageTab
                    MyArray.Add(newCurrency)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Currency)), Currency())
    End Function

    Public Function getLabels() As AmazonaLabel()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [label]")
                Dim i As Integer = 0

                While DR.Read
                    Dim newLabel As New AmazonaLabel
                    newLabel.id_label = DR.Item("id_label")
                    If Not DR.Item("name_label") Is DBNull.Value Then
                        newLabel.name_label = DR.Item("name_label")
                    End If
                    Dim MyArray2 As New ArrayList
                    Dim labelLanguageTab() As LabelLanguage
                    Dim DR2 As OleDb.OleDbDataReader = selectQuery("Select * FROM labelLanguage where id_label=" & DR.Item("id_label"))
                    While DR2.Read
                        Dim labelLanguage As New LabelLanguage
                        labelLanguage.id_labelLanguage = DR2.Item("id_labelLanguage")
                        labelLanguage.id_label = DR.Item("id_label")
                        labelLanguage.id_language = DR2.Item("id_language")
                        If Not DR2.Item("description") Is DBNull.Value Then
                            labelLanguage.description = DR2.Item("description")
                        End If

                        MyArray2.Add(labelLanguage)
                    End While
                    DR2.Close()
                    labelLanguageTab = DirectCast(MyArray2.ToArray(GetType(LabelLanguage)), LabelLanguage())
                    newLabel.labelLanguage = labelLanguageTab
                    MyArray.Add(newLabel)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(AmazonaLabel)), AmazonaLabel())
    End Function

    Public Function getFormulaColor(Optional isClientTable As Boolean = False) As FormulaColor()
        Dim tableName As String
        If isClientTable Then
            tableName = "clientFormulaColor"
        Else
            tableName = "formulaColor"
        End If
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [" & tableName & "]")
                Dim i As Integer = 0

                While DR.Read
                    Dim newFormulaColor As New FormulaColor
                    newFormulaColor.id_formulaColor = DR.Item("id_formulaColor")
                    newFormulaColor.id_color = DR.Item("id_color")
                    newFormulaColor.id_formula = DR.Item("id_formula")
                    If Not DR.Item("id_Unit") Is DBNull.Value Then
                        newFormulaColor.id_Unit = DR.Item("id_Unit")
                    End If
                    Dim dbQuantity As String = ""
                    If Not DR.Item("quantite") Is DBNull.Value Then
                        dbQuantity = DR.Item("quantite")
                    End If
                    If Not DR.Item("encrypted") Is DBNull.Value Then
                        If DR.Item("encrypted") = 1 Then
                            newFormulaColor.encrypted = True

                        End If
                    End If

                    If newFormulaColor.encrypted Then
                        'decrypt
                        newFormulaColor.quantite = decryptQuantity(dbQuantity, newFormulaColor.id_formulaColor)
                        '''''
                    Else
                        newFormulaColor.quantite = dbQuantity
                    End If

                    MyArray.Add(newFormulaColor)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
    End Function
#End Region

#Region "Formulas"
    Public Function getFormulaColorsByIdFormula(ByVal formulaId As Integer, ByVal typeFormula As String, ByVal carTableName As String, ByVal isCouche As Boolean, ByVal isApply4201_180Eq As Boolean) As FormulaColor()
        Dim formulaColorTab() As FormulaColor = Nothing
        If allFormulaColors Is Nothing Then
            Dim MyArray As New ArrayList
            If openConnection() Then
                Try
                    Dim query As String = "Select * FROM [" & carTableName & "_FormulaColor] WHERE id_formula =" & formulaId

                    Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                    Dim i As Integer = 0

                    While DR.Read
                        Dim newFormulaColor As New FormulaColor
                        newFormulaColor.id_formulaColor = DR.Item("id_formulaColor")
                        If Not DR.Item("id_color") Is DBNull.Value Then
                            newFormulaColor.id_color = DR.Item("id_color")
                        End If
                        newFormulaColor.id_formula = DR.Item("id_formula")
                        If Not DR.Item("id_Unit") Is DBNull.Value Then
                            newFormulaColor.id_Unit = DR.Item("id_Unit")
                        End If
                        Dim dbQuantity As String = ""
                        If Not DR.Item("quantite") Is DBNull.Value Then
                            dbQuantity = DR.Item("quantite")
                        End If
                        If Not DR.Item("encrypted") Is DBNull.Value Then
                            If DR.Item("encrypted") = 1 Then
                                newFormulaColor.encrypted = True

                            End If
                        End If

                        If newFormulaColor.encrypted Then
                            'decrypt

                            Dim decryptedQty As String = decryptQuantity(dbQuantity, newFormulaColor.id_formulaColor)
                            newFormulaColor.quantite = Double.Parse(decryptedQty, ciClone)

                            If newFormulaColor.quantite <= 0 Then
                                MsgBox("Please contact your administrator for the latest formula details", MsgBoxStyle.Information)
                                Exit Function
                            End If

                            printStringByLine(newFormulaColor.id_color & " - decryptedQty = " & decryptedQty)
                            printStringByLine(newFormulaColor.id_color & " - newFormulaColor.quantite = " & newFormulaColor.quantite)


                            '''''
                        Else
                            newFormulaColor.quantite = dbQuantity
                        End If

                        MyArray.Add(newFormulaColor)

                    End While
                    DR.Close()
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try
            End If
            closeConnection()

            formulaColorTab = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        Else
            formulaColorTab = getFormulaColorByIdFormulaOpt(formulaId)
        End If

        'test if all basic colors exist
        If testIfBColorsExist(formulaColorTab) = False Then
            MsgBox("This Formula is corrupted because a basic color in it is absent from the basic colors list", MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        ''''''''''''''''''''''''''''''''
        Dim qty4201 As Double = findQuantityOfColorInformula(formulaColorTab, "4201")

        printFormula(formulaColorTab, "before equations")

        If typeFormula = "LS" Then

            'sort descending
            formulaColorTab = sortDescending(formulaColorTab)
        Else
            If typeFormula = "BC" Then
                formulaColorTab = applyEquationBC(formulaColorTab, "4002", "4110")
                printFormula(formulaColorTab, "after applyEquationBC")
            End If

            If chosenGarage.apply_equation Then
                formulaColorTab = eqDiluted(formulaColorTab)
                printFormula(formulaColorTab, "after eqDoubleCBXB_50per4010")
            End If
        End If


        'reapply the sorting in case it was corrupted with the other eq
        If typeFormula = "BC" Then
            formulaColorTab = applyEquationBC(formulaColorTab, "4002", "4110")
            printFormula(formulaColorTab, "after applyEquationBC 2")
        End If


        printFormula(formulaColorTab, "end")
        Return formulaColorTab
    End Function

    Private Sub printFormula(ByVal formulaColorTab As FormulaColor(), ByVal title As String)

        printStringByLine("formulaColorTab - " & title)
        For i = 0 To formulaColorTab.Length - 1
            printStringByLine("formulaColorTab" & formulaColorTab(i).id_color & " : " & formulaColorTab(i).quantite)
        Next

    End Sub
    Public Function testIfBColorsExist(ByVal formulaColorTab As FormulaColor()) As Boolean
        Dim allColorsExist As Boolean = True
        For i = 0 To formulaColorTab.Length - 1
            If getColorById(formulaColorTab(i).id_color) Is Nothing Then
                allColorsExist = False
                Exit For
            End If
        Next
        Return allColorsExist

    End Function
    Public Function getFormulaColorsByIdFormulaClient(ByVal formulaId As Integer) As FormulaColor()
        Dim formulaColorTab() As FormulaColor = Nothing
        If allFormulaColorsClient Is Nothing Then
            Dim MyArray As New ArrayList
            If openConnection() Then
                Try
                    Dim query As String = "Select * FROM [clientFormulaColor] WHERE id_formula =" & formulaId

                    Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                    Dim i As Integer = 0

                    While DR.Read
                        Dim newFormulaColor As New FormulaColor
                        newFormulaColor.id_formulaColor = DR.Item("id_formulaColor")
                        If Not DR.Item("id_color") Is DBNull.Value Then
                            newFormulaColor.id_color = DR.Item("id_color")
                        End If
                        newFormulaColor.id_formula = DR.Item("id_formula")
                        If Not DR.Item("id_Unit") Is DBNull.Value Then
                            newFormulaColor.id_Unit = DR.Item("id_Unit")
                        End If
                        Dim dbQuantity As String = ""
                        If Not DR.Item("quantite") Is DBNull.Value Then
                            dbQuantity = DR.Item("quantite")
                        End If
                        If Not DR.Item("encrypted") Is DBNull.Value Then
                            If DR.Item("encrypted") = 1 Then
                                newFormulaColor.encrypted = True

                            End If
                        End If

                        If newFormulaColor.encrypted Then
                            'decrypt


                            Dim decryptedQty As String = decryptQuantity(dbQuantity, newFormulaColor.id_formulaColor)
                            newFormulaColor.quantite = Double.Parse(decryptedQty, ciClone)

                            '''''
                        Else
                            newFormulaColor.quantite = dbQuantity
                        End If
                        MyArray.Add(newFormulaColor)

                    End While
                    DR.Close()
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try
            End If
            closeConnection()
            formulaColorTab = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        Else
            formulaColorTab = getFormulaColorByIdFormulaClientOpt(formulaId)

        End If

        'test if all basic colors exist
        If testIfBColorsExist(formulaColorTab) = False Then
            MsgBox("This Formula is corrupted because a basic color in it is absent from the basic colors list", MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        ''''''''''''''''''''''''''''''''

        'Dim applyEquation As Boolean = chosenGarage.apply_equation
        'If applyEquation Then
        'formulaColorTab = garageEquation(formulaColorTab)
        'End If

        Return formulaColorTab
    End Function

    Public Function applyEquationLS_tmp(ByVal formulaColorTab As FormulaColor()) As FormulaColor()
        If formulaColorTab Is Nothing Then
            MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
            Return Nothing
            If formulaColorTab.Length = 0 Then
                MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        End If



        Dim indexOfLS01 As Integer = findIndexOfColorToUse(formulaColorTab, "LS 01")

        Dim MyArray2 As New ArrayList
        Dim MyArrayIdFormulas As New ArrayList

        If indexOfLS01 <> -1 Then
            MyArray2.Add(formulaColorTab(indexOfLS01))
        End If

        Dim lengthTarget As Integer = formulaColorTab.Length
        While MyArray2.Count < lengthTarget
            'find max
            Dim min As Decimal = 999999999999999999
            Dim indexMin As Integer = -1
            For i = 0 To formulaColorTab.Length - 1
                If formulaColorTab(i).quantite < min And Not MyArrayIdFormulas.Contains(formulaColorTab(i).id_formulaColor) And i <> indexOfLS01 Then
                    min = formulaColorTab(i).quantite
                    indexMin = i
                End If
            Next
            MyArray2.Add(formulaColorTab(indexMin))
            'formulaColorTab(indexMin).id_formula = -1
            MyArrayIdFormulas.Add(formulaColorTab(indexMin).id_formulaColor)
        End While

        formulaColorTab = DirectCast(MyArray2.ToArray(GetType(FormulaColor)), FormulaColor())
        ''''''''''''''''''''''''''''''

        Return formulaColorTab
    End Function


    Public Function applyEquationBC(ByVal formulaColorTab As FormulaColor(), ByVal colorCodeToFirst As String, ByVal colorCodeToLast As String) As FormulaColor()
        If formulaColorTab Is Nothing Then
            MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
            Return Nothing
            If formulaColorTab.Length = 0 Then
                MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        End If



        Dim indexOfBC_first As Integer = findIndexOfColorToUse(formulaColorTab, colorCodeToFirst)
        Dim indexOfBC_last As Integer = findIndexOfColorToUse(formulaColorTab, colorCodeToLast)

        Dim MyArray2 As New ArrayList
        Dim MyArrayIdFormulas As New ArrayList

        If indexOfBC_first <> -1 Then
            MyArray2.Add(formulaColorTab(indexOfBC_first))
        End If

        Dim lengthTarget As Integer = formulaColorTab.Length
        If indexOfBC_last <> -1 Then
            lengthTarget = lengthTarget - 1
        End If

        While MyArray2.Count < lengthTarget
            'find max
            Dim max As Decimal = 0
            Dim indexMax As Integer = -1
            For i = 0 To formulaColorTab.Length - 1
                If (formulaColorTab(i).quantite > max) And Not MyArrayIdFormulas.Contains(formulaColorTab(i).id_formulaColor) And i <> indexOfBC_first And i <> indexOfBC_last Then
                    max = formulaColorTab(i).quantite

                    indexMax = i
                End If
            Next
            If indexMax <> -1 Then
                MyArray2.Add(formulaColorTab(indexMax))
                'formulaColorTab(indexMin).id_formula = -1
                MyArrayIdFormulas.Add(formulaColorTab(indexMax).id_formulaColor)
            End If
        End While

        If indexOfBC_last <> -1 Then
            MyArray2.Add(formulaColorTab(indexOfBC_last))
        End If

        formulaColorTab = DirectCast(MyArray2.ToArray(GetType(FormulaColor)), FormulaColor())
        ''''''''''''''''''''''''''''''


        Return formulaColorTab
    End Function

    Public Function applyEquationLS(ByVal formulaColorTab As FormulaColor(), ByVal colorCodeToSpread As String) As FormulaColor()
        If formulaColorTab Is Nothing Then
            MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
            Return Nothing
            If formulaColorTab.Length = 0 Then
                MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        End If

        'Dim colorCodeToSpread As String = "01"
        'delete "LS01" from formula 
        Dim MyArray As New ArrayList
        Dim originalTotal As Decimal = 0
        Dim clrSpreadQty As Decimal = 0
        For i = 0 To formulaColorTab.Length - 1
            originalTotal = originalTotal + formulaColorTab(i).quantite
            Dim curColor As AmazonaColor = getColorById(formulaColorTab(i).id_color)
            If curColor.colorCode = colorCodeToSpread Then
                clrSpreadQty = clrSpreadQty + formulaColorTab(i).quantite
            Else
                MyArray.Add(formulaColorTab(i))
            End If
        Next

        'safer testings
        If MyArray Is Nothing Then
            MsgBox("Formula is empty without " & colorCodeToSpread & "!", MsgBoxStyle.Exclamation)
            Return Nothing
        Else
            If MyArray.Count = 0 Then
                MsgBox("Formula is empty without " & colorCodeToSpread & "!", MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        End If
        formulaColorTab = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())

        ''spread by % and find index of biggest qty
        Dim newTotal As Decimal = 0
        Dim biggestQty As Decimal = 0
        Dim indexBiggestQty = -1
        For i = 0 To formulaColorTab.Length - 1
            Dim qty As Decimal = formulaColorTab(i).quantite
            Dim newQty As Decimal
            newQty = qty + (qty * 100 / originalTotal) * clrSpreadQty / 100
            formulaColorTab(i).quantite = newQty
            newTotal = newTotal + formulaColorTab(i).quantite
            If newQty >= biggestQty Then
                biggestQty = newQty
                indexBiggestQty = i
            End If
        Next


        ''go back to original total
        For i = 0 To formulaColorTab.Length - 1
            Dim qty As Decimal = formulaColorTab(i).quantite
            Dim newQty As Decimal = originalTotal * qty / newTotal
            formulaColorTab(i).quantite = newQty
        Next

        '' make color with bigger qty first
        Dim biggestFormulaColor As FormulaColor = formulaColorTab(indexBiggestQty)
        Dim MyArray2 As New ArrayList
        MyArray2.Add(biggestFormulaColor)
        For i = 0 To formulaColorTab.Length - 1
            If i <> indexBiggestQty Then
                MyArray2.Add(formulaColorTab(i))
            End If
        Next
        formulaColorTab = DirectCast(MyArray2.ToArray(GetType(FormulaColor)), FormulaColor())
        ''''''''''''''''''''''''''''''

        Return formulaColorTab
    End Function
    Public Function sortDescending(ByVal formulaColorTab As FormulaColor()) As FormulaColor()
        If formulaColorTab Is Nothing Then
            MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
            Return Nothing
            If formulaColorTab.Length = 0 Then
                MsgBox("Formula is empty!", MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        End If


        Dim MyArray2 As New ArrayList
        Dim MyArrayIdFormulas As New ArrayList
        Dim lengthTarget As Integer = formulaColorTab.Length

        While MyArray2.Count < lengthTarget
            'find max
            Dim indexMax As Integer = -1
            Dim max As Decimal = 0
            For i = 0 To formulaColorTab.Length - 1
                If formulaColorTab(i).quantite >= max And Not MyArrayIdFormulas.Contains(formulaColorTab(i).id_formulaColor) Then
                    max = formulaColorTab(i).quantite
                    indexMax = i
                End If
            Next
            MyArray2.Add(formulaColorTab(indexMax))
            'formulaColorTab(indexMin).id_formula = -1
            MyArrayIdFormulas.Add(formulaColorTab(indexMax).id_formulaColor)
        End While




        formulaColorTab = DirectCast(MyArray2.ToArray(GetType(FormulaColor)), FormulaColor())
        ''''''''''''''''''''''''''''''

        Return formulaColorTab
    End Function


    Private Function eqDiluted(ByVal formulaColorTab As FormulaColor()) As FormulaColor()
        Dim initTotalQty As Double = 0
        Dim i As Integer
        For i = 0 To formulaColorTab.Length - 1
            initTotalQty += formulaColorTab(i).quantite
        Next



        'decrease 50% 4010
        Dim index4010 As Integer = findIndexOfColorToUse(formulaColorTab, "4010")
        If index4010 <> -1 Then
            formulaColorTab(index4010).quantite = formulaColorTab(index4010).quantite / 2
        End If
        ''''''''''''''''''''''''''''''''''''''''

        Dim MyArray As New ArrayList

        For i = 0 To formulaColorTab.Length - 1
            Dim curColor As AmazonaColor = getColorById(formulaColorTab(i).id_color)
            '' remove 4002
            If curColor.colorCode <> "4002" Then
                MyArray.Add(formulaColorTab(i))

            End If
        Next
        Dim resultformulaColorTab As FormulaColor()
        resultformulaColorTab = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim finalTotalQty As Double = 0
        For i = 0 To resultformulaColorTab.Length - 1
            finalTotalQty += resultformulaColorTab(i).quantite
        Next

        'regle de trois
        For i = 0 To resultformulaColorTab.Length - 1
            Dim curQty As Double = resultformulaColorTab(i).quantite
            resultformulaColorTab(i).quantite = curQty * initTotalQty / finalTotalQty
        Next

        Return resultformulaColorTab
    End Function

    Private Function findQuantityOfColorInformula(ByVal formulaColorTab As FormulaColor(), ByVal colorCode As String) As Double
        Dim indexColor As Integer = findIndexOfColorToUse(formulaColorTab, colorCode)
        If indexColor = -1 Then
            Return 0
        End If
        Dim qty As Double = formulaColorTab(indexColor).quantite

        Return qty
    End Function

    Private Function findIndexOfColorToUse(ByVal formulaColorTab As FormulaColor(), ByVal listOfColorCodeToUse As String) As Integer
        Dim index As Integer = -1
        Dim i As Integer
        For i = 0 To formulaColorTab.Length - 1
            Dim curColor As AmazonaColor = getColorById(formulaColorTab(i).id_color)
            If curColor.colorCode.Trim = listOfColorCodeToUse.Trim Then
                index = i
                Exit For
            End If
        Next
        Return index
    End Function

    Public Function getClientFormulasOnly(ByVal whereStr As String, ByVal oldDb As Boolean) As Formula()
        Dim MyArray As New ArrayList
        Dim conxOpen As Boolean = False

        conxOpen = openConnectionNewDb()

        If conxOpen Then
            Try
                'Dim query As String = "Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,colorRGB,c_year,clientName FROM [formula],[car] WHERE formula.id_car=car.id_car " & whereStr & " ORDER BY (Version) "
                'query &= (" UNION ALL Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,colorRGB,c_year,clientName FROM [clientFormula],[car] WHERE clientFormula.id_car=car.id_car " & whereStr & " ORDER BY (Version) ")

                Dim query As String = "Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,modified_once FROM [clientFormula],[car] WHERE clientFormula.id_car=car.id_car " & whereStr & " ORDER BY carName,colorCode,version"


                Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                Dim i As Integer = 0

                While DR.Read
                    Dim type As String = ""
                    If Not DR.Item("type") Is DBNull.Value Then
                        type = DR.Item("type")
                    End If
                    If chosenGarage.coat.ToUpper = "LS" And type.ToUpper = "2K" Then
                        Continue While
                    ElseIf chosenGarage.coat.ToUpper = "2K" And type.ToUpper = "LS" Then
                        Continue While
                    End If

                    Dim newFormula As New Formula
                    newFormula.id_formula = DR.Item("id_formula")
                    If Not DR.Item("formulaImgPath") Is DBNull.Value Then
                        newFormula.formulaImgPath = DR.Item("formulaImgPath")
                    End If
                    If Not DR.Item("otherPrice") Is DBNull.Value Then
                        newFormula.otherPrice = DR.Item("otherPrice")
                    End If
                    If Not DR.Item("id_otherCurreny") Is DBNull.Value Then
                        newFormula.id_otherCurreny = DR.Item("id_otherCurreny")
                    End If
                    If Not DR.Item("id_otherUnit") Is DBNull.Value Then
                        newFormula.id_otherUnit = DR.Item("id_otherUnit")
                    End If
                    If Not DR.Item("type") Is DBNull.Value Then
                        newFormula.type = DR.Item("type")
                    End If
                    If Not DR.Item(0) Is DBNull.Value Then
                        newFormula.id_car = DR.Item(0)
                    End If
                    If Not DR.Item(1) Is DBNull.Value Then
                        newFormula.name_car = DR.Item(1)
                    End If
                    If Not DR.Item("name_formula") Is DBNull.Value Then
                        newFormula.name_formula = DR.Item("name_formula")
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        newFormula.version = DR.Item("version")
                    End If
                    If Not DR.Item("variant") Is DBNull.Value Then
                        newFormula.formulaVariant = DR.Item("variant")
                    End If
                    If Not DR.Item("duplicate") Is DBNull.Value Then
                        newFormula.duplicate = DR.Item("duplicate")
                    End If
                    If Not DR.Item("colorCode") Is DBNull.Value Then
                        newFormula.colorCode = DR.Item("colorCode")
                    End If
                    If Not DR.Item("colorRGB") Is DBNull.Value Then
                        newFormula.colorRGB = DR.Item("colorRGB")
                    End If
                    If Not DR.Item("c_year") Is DBNull.Value Then
                        newFormula.c_year = DR.Item("c_year")
                    End If
                    If Not DR.Item("clientName") Is DBNull.Value Then
                        newFormula.clientName = DR.Item("clientName")
                    End If

                    If Not DR.Item("id_formulaX") Is DBNull.Value Then
                        newFormula.id_formulaX = DR.Item("id_formulaX")
                    End If
                    If Not DR.Item("id_formulaXp") Is DBNull.Value Then
                        newFormula.id_formulaXp = DR.Item("id_formulaXp")
                    End If
                    If Not DR.Item("id_formulaX2p") Is DBNull.Value Then
                        newFormula.id_formulaX2p = DR.Item("id_formulaX2p")
                    End If

                    If Not DR.Item("id_formulaY") Is DBNull.Value Then
                        newFormula.id_formulaY = DR.Item("id_formulaY")
                    End If
                    If Not DR.Item("id_formulaYp") Is DBNull.Value Then
                        newFormula.id_formulaYp = DR.Item("id_formulaYp")
                    End If
                    If Not DR.Item("id_formulaY2p") Is DBNull.Value Then
                        newFormula.id_formulaY2p = DR.Item("id_formulaY2p")
                    End If

                    If Not DR.Item("id_formulaZ") Is DBNull.Value Then
                        newFormula.id_formulaZ = DR.Item("id_formulaZ")
                    End If
                    If Not DR.Item("id_formulaZp") Is DBNull.Value Then
                        newFormula.id_formulaZp = DR.Item("id_formulaZp")
                    End If
                    If Not DR.Item("id_formulaZ2p") Is DBNull.Value Then
                        newFormula.id_formulaZ2p = DR.Item("id_formulaZ2p")
                    End If

                    If Not DR.Item("cardNumber") Is DBNull.Value Then
                        newFormula.cardNumber = DR.Item("cardNumber")
                    End If
                    If Not DR.Item("modified_once") Is DBNull.Value Then
                        If DR.Item("modified_once") = 1 Then
                            newFormula.modified_once = True
                        Else
                            newFormula.modified_once = False
                        End If
                    Else
                        newFormula.modified_once = True 'we dont want to show an asteriks
                    End If
                    If Not DR.Item("date_cre_mod") Is DBNull.Value Then
                        Dim dateCreModStr As String = DR.Item("date_cre_mod")

                        Dim dateCreModStrTab() As String = dateCreModStr.Split(":")
                        Dim day As Integer = Integer.Parse(dateCreModStrTab(0))
                        Dim month As Integer = Integer.Parse(dateCreModStrTab(1))
                        Dim year As Integer = Integer.Parse(dateCreModStrTab(2))
                        Dim hour As Integer = Integer.Parse(dateCreModStrTab(3))
                        Dim minute As Integer = Integer.Parse(dateCreModStrTab(4))
                        Dim second As Integer = Integer.Parse(dateCreModStrTab(5))

                        'Dim dateCreMod As New DateTime(year, month, day, hour, minute, second)

                        Dim dayStr As String = day
                        If day < 10 Then
                            dayStr = "0" & day
                        End If

                        Dim monthStr As String = month
                        If month < 10 Then
                            monthStr = "0" & month
                        End If

                        Dim dateCreMod As New DateCreMod(year, monthStr, dayStr, hour, minute, second)

                        newFormula.dateCreMod = dateCreMod

                    End If
                    newFormula.oldDb = oldDb
                    MyArray.Add(newFormula)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
    End Function
    Public Function getFormulas(ByVal whereStr As String, ByVal carTableName As String, ByVal carName As String, ByVal idCar As Long) As Formula()
        Dim MyArray As New ArrayList
        Dim conxOpen As Boolean = False

        conxOpen = openConnectionNewDb()

        If conxOpen Then
            Try
                'Dim query As String = "Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,colorRGB,c_year,clientName FROM [formula],[car] WHERE formula.id_car=car.id_car " & whereStr & " ORDER BY (Version) "
                'query &= (" UNION ALL Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,colorRGB,c_year,clientName FROM [clientFormula],[car] WHERE clientFormula.id_car=car.id_car " & whereStr & " ORDER BY (Version) ")

                Dim query As String = "Select id_car,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,noEquation4201_180,modified_once from ("
                query &= " Select id_car,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,noEquation4201_180,modified_once FROM [" & carTableName & "] WHERE " & carTableName & ".id_car=" & idCar & " " & whereStr
                query &= " UNION ALL Select id_car,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,noEquation4201_180,modified_once  FROM [clientFormula] WHERE clientFormula.id_car=" & idCar & " " & whereStr & " ORDER BY colorCode,version"
                query &= ")"


                ' Dim query As String = "Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod from ("
                ' query &= " Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod FROM [formula],[car] WHERE formula.id_car=car.id_car " & whereStr
                'query &= " UNION ALL Select car.id_car,car.carName,id_otherCurreny, version,name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod  FROM [clientFormula],[car] WHERE clientFormula.id_car=car.id_car " & whereStr & " ORDER BY carName,colorCode,version"
                'query &= ")"



                Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                Dim i As Integer = 0

                While DR.Read
                    Dim type As String = ""
                    If Not DR.Item("type") Is DBNull.Value Then
                        type = DR.Item("type")
                    End If
                    If chosenGarage.coat.ToUpper = "LS" And type.ToUpper = "2K" Then
                        Continue While
                    ElseIf chosenGarage.coat.ToUpper = "2K" And type.ToUpper = "LS" Then
                        Continue While
                    End If
                    Dim newFormula As New Formula
                    newFormula.id_formula = DR.Item("id_formula")
                    If Not DR.Item("formulaImgPath") Is DBNull.Value Then
                        newFormula.formulaImgPath = DR.Item("formulaImgPath")
                    End If
                    If Not DR.Item("otherPrice") Is DBNull.Value Then
                        newFormula.otherPrice = DR.Item("otherPrice")
                    End If
                    If Not DR.Item("id_otherCurreny") Is DBNull.Value Then
                        newFormula.id_otherCurreny = DR.Item("id_otherCurreny")
                    End If
                    If Not DR.Item("id_otherUnit") Is DBNull.Value Then
                        newFormula.id_otherUnit = DR.Item("id_otherUnit")
                    End If
                    If Not DR.Item("type") Is DBNull.Value Then
                        newFormula.type = DR.Item("type")
                    End If
                    If Not DR.Item("id_car") Is DBNull.Value Then
                        newFormula.id_car = DR.Item("id_car")
                    End If
                    newFormula.name_car = carName
                    If Not DR.Item("name_formula") Is DBNull.Value Then
                        newFormula.name_formula = DR.Item("name_formula")
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        newFormula.version = DR.Item("version")
                    End If
                    If Not DR.Item("variant") Is DBNull.Value Then
                        newFormula.formulaVariant = DR.Item("variant")
                    End If
                    If Not DR.Item("duplicate") Is DBNull.Value Then
                        newFormula.duplicate = DR.Item("duplicate")
                    End If
                    If Not DR.Item("colorCode") Is DBNull.Value Then
                        newFormula.colorCode = DR.Item("colorCode")
                    End If
                    If Not DR.Item("colorRGB") Is DBNull.Value Then
                        newFormula.colorRGB = DR.Item("colorRGB")
                    End If
                    If Not DR.Item("c_year") Is DBNull.Value Then
                        newFormula.c_year = DR.Item("c_year")
                    End If
                    If Not DR.Item("clientName") Is DBNull.Value Then
                        newFormula.clientName = DR.Item("clientName")
                    End If

                    If Not DR.Item("id_formulaX") Is DBNull.Value Then
                        newFormula.id_formulaX = DR.Item("id_formulaX")
                    End If
                    If Not DR.Item("id_formulaXp") Is DBNull.Value Then
                        newFormula.id_formulaXp = DR.Item("id_formulaXp")
                    End If
                    If Not DR.Item("id_formulaX2p") Is DBNull.Value Then
                        newFormula.id_formulaX2p = DR.Item("id_formulaX2p")
                    End If

                    If Not DR.Item("id_formulaY") Is DBNull.Value Then
                        newFormula.id_formulaY = DR.Item("id_formulaY")
                    End If
                    If Not DR.Item("id_formulaYp") Is DBNull.Value Then
                        newFormula.id_formulaYp = DR.Item("id_formulaYp")
                    End If
                    If Not DR.Item("id_formulaY2p") Is DBNull.Value Then
                        newFormula.id_formulaY2p = DR.Item("id_formulaY2p")
                    End If

                    If Not DR.Item("id_formulaZ") Is DBNull.Value Then
                        newFormula.id_formulaZ = DR.Item("id_formulaZ")
                    End If
                    If Not DR.Item("id_formulaZp") Is DBNull.Value Then
                        newFormula.id_formulaZp = DR.Item("id_formulaZp")
                    End If
                    If Not DR.Item("id_formulaZ2p") Is DBNull.Value Then
                        newFormula.id_formulaZ2p = DR.Item("id_formulaZ2p")
                    End If

                    If Not DR.Item("cardNumber") Is DBNull.Value Then
                        newFormula.cardNumber = DR.Item("cardNumber")
                    End If
                    If Not DR.Item("modified_once") Is DBNull.Value Then
                        If DR.Item("modified_once") = 1 Then
                            newFormula.modified_once = True
                        Else
                            newFormula.modified_once = False
                        End If
                    Else
                        newFormula.modified_once = True 'we dont want to show an asteriks
                    End If

                    If Not DR.Item("date_cre_mod") Is DBNull.Value Then
                        Dim dateCreModStr As String = DR.Item("date_cre_mod")

                        Dim dateCreModStrTab() As String = dateCreModStr.Split(":")
                        Dim day As Integer = Integer.Parse(dateCreModStrTab(0))
                        Dim month As Integer = Integer.Parse(dateCreModStrTab(1))
                        Dim year As Integer = Integer.Parse(dateCreModStrTab(2))
                        Dim hour As Integer = Integer.Parse(dateCreModStrTab(3))
                        Dim minute As Integer = Integer.Parse(dateCreModStrTab(4))
                        Dim second As Integer = Integer.Parse(dateCreModStrTab(5))

                        'Dim dateCreMod As New DateTime(year, month, day, hour, minute, second)

                        Dim dayStr As String = day
                        If day < 10 Then
                            dayStr = "0" & day
                        End If

                        Dim monthStr As String = month
                        If month < 10 Then
                            monthStr = "0" & month
                        End If

                        Dim dateCreMod As New DateCreMod(year, monthStr, dayStr, hour, minute, second)


                        newFormula.dateCreMod = dateCreMod

                    End If

                    If Not DR.Item("noEquation4201_180") Is DBNull.Value Then
                        If DR.Item("noEquation4201_180") = 1 Then
                            newFormula.isEquation4201_180 = False
                        Else
                            newFormula.isEquation4201_180 = True
                        End If
                    Else
                        newFormula.isEquation4201_180 = True
                    End If

                    newFormula.oldDb = False
                    MyArray.Add(newFormula)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
    End Function
    Private Function orredyExists(ByVal myArray As ArrayList, ByVal clientName As String) As Boolean
        If myArray.Count = 0 Then
            Return False
        End If
        Dim exist As Boolean = False
        Dim tmp() As String = DirectCast(myArray.ToArray(GetType(String)), String())
        Dim i As Integer
        For i = 0 To tmp.Length - 1
            If tmp(i).ToUpper = clientName.ToUpper Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function
    Public Function getClients(ByVal carTableName As String, ByVal carName As String, ByVal idCar As Long) As String()
        Dim myArray As New ArrayList
        Dim formulaTab() As Formula = getFormulas(" and clientName<>'' and clientName is not null ", carTableName, carName, idCar)
        Dim i As Integer
        If Not formulaTab Is Nothing Then
            For i = 0 To formulaTab.Length - 1
                If Not orredyExists(myArray, formulaTab(i).clientName) Then
                    myArray.Add(formulaTab(i).clientName)
                End If

            Next
        End If

        Return DirectCast(myArray.ToArray(GetType(String)), String())
    End Function


    Public Function getClientFormulaTable() As Formula()
        Dim MyArray As New ArrayList
        Dim conxOpen As Boolean = False
        conxOpen = openConnectionNewDb()
        If conxOpen Then
            Try
                Dim query As String = "Select id_car,id_otherCurreny, version, name_formula,type,id_otherUnit,id_formula,formulaImgPath,otherPrice,variant,duplicate,colorCode,cardNumber,colorRGB,c_year,clientName,id_formulaX,id_formulaY,id_formulaZ,id_formulaXp,id_formulaX2p,id_formulaYp,id_formulaY2p,id_formulaZp,id_formulaZ2p,date_cre_mod,noEquation4201_180,modified_once FROM [clientFormula]"


                Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                Dim i As Integer = 0

                While DR.Read
                    Dim type As String = ""
                    If Not DR.Item("type") Is DBNull.Value Then
                        type = DR.Item("type")
                    End If
                    If chosenGarage.coat.ToUpper = "LS" And type.ToUpper = "2K" Then
                        Continue While
                    ElseIf chosenGarage.coat.ToUpper = "2K" And type.ToUpper = "LS" Then
                        Continue While
                    End If
                    Dim newFormula As New Formula
                    newFormula.id_formula = DR.Item("id_formula")
                    If Not DR.Item("formulaImgPath") Is DBNull.Value Then
                        newFormula.formulaImgPath = DR.Item("formulaImgPath")
                    End If
                    If Not DR.Item("otherPrice") Is DBNull.Value Then
                        newFormula.otherPrice = DR.Item("otherPrice")
                    End If
                    If Not DR.Item("id_otherCurreny") Is DBNull.Value Then
                        newFormula.id_otherCurreny = DR.Item("id_otherCurreny")
                    End If
                    If Not DR.Item("id_otherUnit") Is DBNull.Value Then
                        newFormula.id_otherUnit = DR.Item("id_otherUnit")
                    End If
                    If Not DR.Item("type") Is DBNull.Value Then
                        newFormula.type = DR.Item("type")
                    End If
                    If Not DR.Item("id_car") Is DBNull.Value Then
                        newFormula.id_car = DR.Item(0)
                    End If
                    If Not DR.Item("name_formula") Is DBNull.Value Then
                        newFormula.name_formula = DR.Item("name_formula")
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        newFormula.version = DR.Item("version")
                    End If
                    If Not DR.Item("variant") Is DBNull.Value Then
                        newFormula.formulaVariant = DR.Item("variant")
                    End If
                    If Not DR.Item("duplicate") Is DBNull.Value Then
                        newFormula.duplicate = DR.Item("duplicate")
                    End If
                    If Not DR.Item("colorCode") Is DBNull.Value Then
                        newFormula.colorCode = DR.Item("colorCode")
                    End If
                    If Not DR.Item("colorRGB") Is DBNull.Value Then
                        newFormula.colorRGB = DR.Item("colorRGB")
                    End If
                    If Not DR.Item("c_year") Is DBNull.Value Then
                        newFormula.c_year = DR.Item("c_year")
                    End If
                    If Not DR.Item("clientName") Is DBNull.Value Then
                        newFormula.clientName = DR.Item("clientName")
                    End If

                    If Not DR.Item("id_formulaX") Is DBNull.Value Then
                        newFormula.id_formulaX = DR.Item("id_formulaX")
                    End If
                    If Not DR.Item("id_formulaXp") Is DBNull.Value Then
                        newFormula.id_formulaXp = DR.Item("id_formulaXp")
                    End If
                    If Not DR.Item("id_formulaX2p") Is DBNull.Value Then
                        newFormula.id_formulaX2p = DR.Item("id_formulaX2p")
                    End If

                    If Not DR.Item("id_formulaY") Is DBNull.Value Then
                        newFormula.id_formulaY = DR.Item("id_formulaY")
                    End If
                    If Not DR.Item("id_formulaYp") Is DBNull.Value Then
                        newFormula.id_formulaYp = DR.Item("id_formulaYp")
                    End If
                    If Not DR.Item("id_formulaY2p") Is DBNull.Value Then
                        newFormula.id_formulaY2p = DR.Item("id_formulaY2p")
                    End If

                    If Not DR.Item("id_formulaZ") Is DBNull.Value Then
                        newFormula.id_formulaZ = DR.Item("id_formulaZ")
                    End If
                    If Not DR.Item("id_formulaZp") Is DBNull.Value Then
                        newFormula.id_formulaZp = DR.Item("id_formulaZp")
                    End If
                    If Not DR.Item("id_formulaZ2p") Is DBNull.Value Then
                        newFormula.id_formulaZ2p = DR.Item("id_formulaZ2p")
                    End If

                    If Not DR.Item("cardNumber") Is DBNull.Value Then
                        newFormula.cardNumber = DR.Item("cardNumber")
                    End If
                    If Not DR.Item("modified_once") Is DBNull.Value Then
                        If DR.Item("modified_once") = 1 Then
                            newFormula.modified_once = True
                        Else
                            newFormula.modified_once = False
                        End If
                    Else
                        newFormula.modified_once = True 'we dont want to show an asteriks
                    End If
                    If Not DR.Item("date_cre_mod") Is DBNull.Value Then
                        Dim dateCreModStr As String = DR.Item("date_cre_mod")

                        Dim dateCreModStrTab() As String = dateCreModStr.Split(":")
                        Dim day As Integer = Integer.Parse(dateCreModStrTab(0))
                        Dim month As Integer = Integer.Parse(dateCreModStrTab(1))
                        Dim year As Integer = Integer.Parse(dateCreModStrTab(2))
                        Dim hour As Integer = Integer.Parse(dateCreModStrTab(3))
                        Dim minute As Integer = Integer.Parse(dateCreModStrTab(4))
                        Dim second As Integer = Integer.Parse(dateCreModStrTab(5))

                        'Dim dateCreMod As New DateTime(year, month, day, hour, minute, second)

                        Dim dayStr As String = day
                        If day < 10 Then
                            dayStr = "0" & day
                        End If

                        Dim monthStr As String = month
                        If month < 10 Then
                            monthStr = "0" & month
                        End If

                        Dim dateCreMod As New DateCreMod(year, monthStr, dayStr, hour, minute, second)

                        newFormula.dateCreMod = dateCreMod

                    End If
                    If Not DR.Item("noEquation4201_180") Is DBNull.Value Then
                        If DR.Item("noEquation4201_180") = 1 Then
                            newFormula.isEquation4201_180 = False
                        Else
                            newFormula.isEquation4201_180 = True
                        End If
                    Else
                        newFormula.isEquation4201_180 = True
                    End If
                    MyArray.Add(newFormula)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
    End Function


    Public Function getClientFormulaColorTable() As FormulaColor()

        Dim MyArray As New ArrayList

        If openConnectionNewDb() Then
            Try
                Dim query As String = "Select * FROM [clientFormulaColor]"

                Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                Dim i As Integer = 0

                While DR.Read
                    Dim newFormulaColor As New FormulaColor
                    newFormulaColor.id_formulaColor = DR.Item("id_formulaColor")
                    If Not DR.Item("id_color") Is DBNull.Value Then
                        newFormulaColor.id_color = DR.Item("id_color")
                    End If
                    newFormulaColor.id_formula = DR.Item("id_formula")
                    If Not DR.Item("id_Unit") Is DBNull.Value Then
                        newFormulaColor.id_Unit = DR.Item("id_Unit")
                    End If
                    Dim dbQuantity As String = ""
                    If Not DR.Item("quantite") Is DBNull.Value Then
                        dbQuantity = DR.Item("quantite")
                    End If
                    If Not DR.Item("encrypted") Is DBNull.Value Then
                        If DR.Item("encrypted") = 1 Then
                            newFormulaColor.encrypted = True

                        End If
                    End If

                    If newFormulaColor.encrypted Then
                        'decrypt

                        Dim decryptedQty As String = decryptQuantity(dbQuantity, newFormulaColor.id_formulaColor)
                        newFormulaColor.quantite = Double.Parse(decryptedQty, ciClone)

                        '''''
                    Else
                        newFormulaColor.quantite = dbQuantity
                    End If

                    MyArray.Add(newFormulaColor)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()

        Dim formulaColorTab() As FormulaColor = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        '''''''''''''''''''''''''''''
        Return formulaColorTab
    End Function

    Public Function getClientFormulaColorByIdFormula(ByVal idFormula As Integer) As FormulaColor()

        Dim MyArray As New ArrayList

        If openConnectionNewDb() Then
            Try
                Dim query As String = "Select * FROM [clientFormulaColor] where id_formula=" & idFormula

                Dim DR As OleDb.OleDbDataReader = selectQuery(query)
                Dim i As Integer = 0

                While DR.Read
                    Dim newFormulaColor As New FormulaColor
                    newFormulaColor.id_formulaColor = DR.Item("id_formulaColor")
                    If Not DR.Item("id_color") Is DBNull.Value Then
                        newFormulaColor.id_color = DR.Item("id_color")
                    End If
                    newFormulaColor.id_formula = DR.Item("id_formula")
                    If Not DR.Item("id_Unit") Is DBNull.Value Then
                        newFormulaColor.id_Unit = DR.Item("id_Unit")
                    End If
                    Dim dbQuantity As String = ""
                    If Not DR.Item("quantite") Is DBNull.Value Then
                        dbQuantity = DR.Item("quantite")
                    End If
                    If Not DR.Item("encrypted") Is DBNull.Value Then
                        If DR.Item("encrypted") = 1 Then
                            newFormulaColor.encrypted = True

                        End If
                    End If

                    If newFormulaColor.encrypted Then
                        'decrypt


                        Dim decryptedQty As String = decryptQuantity(dbQuantity, newFormulaColor.id_formulaColor)
                        newFormulaColor.quantite = Double.Parse(decryptedQty, ciClone)
                        '''''
                    Else
                        newFormulaColor.quantite = dbQuantity
                    End If

                    MyArray.Add(newFormulaColor)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()

        Dim formulaColorTab() As FormulaColor = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        '''''''''''''''''''''''''''''
        Return formulaColorTab
    End Function

#End Region

#Region "Cars"
    Public Function getCarByName(ByVal carname As String) As Car
        Dim car As Car
        car = New Car()
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [car] where lcase(carname) ='" & carname.ToLower & "'")
                Dim i As Integer = 0

                If DR.Read Then
                    car.id_car = DR.Item("id_car")
                    If Not DR.Item("model") Is DBNull.Value Then
                        car.model = DR.Item("model")
                    End If
                    If Not DR.Item("carImgPath") Is DBNull.Value Then
                        car.carImgPath = DR.Item("carImgPath")
                    End If
                    If Not DR.Item("carName") Is DBNull.Value Then
                        car.carName = DR.Item("carName")
                    End If
                    If Not DR.Item("colorCodeLocation") Is DBNull.Value Then
                        car.colorCodeLocation = DR.Item("colorCodeLocation")
                    End If
                    If Not DR.Item("tableName") Is DBNull.Value Then
                        car.tableName = DR.Item("tableName")
                    End If

                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return car
    End Function

    Public Function getCarById(ByVal id) As Car
        Dim car As Car
        car = New Car()
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [car] where id_car =" & id)
                Dim i As Integer = 0

                If DR.Read Then
                    car.id_car = DR.Item("id_car")
                    If Not DR.Item("model") Is DBNull.Value Then
                        car.model = DR.Item("model")
                    End If
                    If Not DR.Item("carImgPath") Is DBNull.Value Then
                        car.carImgPath = DR.Item("carImgPath")
                    End If
                    If Not DR.Item("carName") Is DBNull.Value Then
                        car.carName = DR.Item("carName")
                    End If
                    If Not DR.Item("colorCodeLocation") Is DBNull.Value Then
                        car.colorCodeLocation = DR.Item("colorCodeLocation")
                    End If
                    If Not DR.Item("tableName") Is DBNull.Value Then
                        car.tableName = DR.Item("tableName")
                    End If

                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return car
    End Function
    Public Function getLastChosenCar() As Car
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [globalVariables] WHERE variable_name='id_car'")
                Dim i As Integer = 0

                If DR.Read Then
                    If Not DR.Item("variable_value") Is DBNull.Value Then
                        getLastChosenCar = getCarById(DR.Item("variable_value"))
                    Else
                        getLastChosenCar = Nothing
                    End If

                Else
                    getLastChosenCar = Nothing
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function
    Public Function getCars(ByVal whereStr As String) As Car()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [car] " & whereStr & " Order by carName")
                Dim i As Integer = 0

                While DR.Read
                    Dim newcar As New Car

                    newcar.id_car = DR.Item("id_car")
                    If Not DR.Item("carName") Is DBNull.Value Then
                        newcar.carName = DR.Item("carName").trim
                    End If
                    If Not DR.Item("model") Is DBNull.Value Then
                        newcar.model = DR.Item("model").trim
                    End If
                    If Not DR.Item("carImgPath") Is DBNull.Value Then
                        newcar.carImgPath = DR.Item("carImgPath").trim
                    End If
                    If Not DR.Item("tableName") Is DBNull.Value Then
                        newcar.tableName = DR.Item("tableName")
                    End If

                    MyArray.Add(newcar)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Car)), Car())
    End Function


    Public Function getAllColorLocatorsByCar(ByVal carName As String) As String
        Dim locators As String = ""
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [colorLocator] where lcase(carname)='" & carName.ToLower & "'")
                Dim i As Integer = 0

                While DR.Read
                    locators = locators & ";" & DR.Item("locators")
                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return locators
    End Function
    Public Function getAllColorLocatorsByCarAndModel(ByVal carName As String, ByVal carModel As String) As String
        Dim locators As String = ""
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [colorLocator] where lcase(carname)='" & carName.ToLower & "' and lcase(carmodel)='" & carModel.ToLower & "'")
                Dim i As Integer = 0

                While DR.Read
                    locators = locators & ";" & DR.Item("locators")
                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return locators
    End Function

    Public Function getAllColorLocatorsByCarAndModelAndYear(ByVal carName As String, ByVal carmodel As String, ByVal caryear As String) As String
        Dim locators As String = ""
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [colorLocator] where lcase(carname)='" & carName.ToLower & "' and lcase(carmodel)='" & carmodel.ToLower & "' and lcase(caryear)='" & caryear.ToLower & "'")
                Dim i As Integer = 0

                While DR.Read
                    locators = locators & ";" & DR.Item("locators")
                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return locators
    End Function
    Public Function getCarModels(ByVal carName As String) As String()
        Dim MyArray As New ArrayList
        MyArray.Add("all")
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select distinct(carmodel) FROM [colorLocator] where lcase(carname)='" & carName.ToLower & "'")
                Dim i As Integer = 0

                While DR.Read
                    Dim model As String = DR.Item("carmodel")
                    If Not model.ToLower = "all" Then
                        MyArray.Add(model)
                    End If
                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(String)), String())
    End Function
    Public Function getCarModelYears(ByVal carName As String, ByVal carmodel As String) As String()
        Dim MyArray As New ArrayList
        MyArray.Add("all")
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select distinct(caryear) FROM [colorLocator] where lcase(carname)='" & carName.ToLower & "' and lcase(carmodel)='" & carmodel.ToLower & "'")
                Dim i As Integer = 0

                While DR.Read

                    Dim year As String = DR.Item("caryear")
                    If Not year.ToLower = "all" Then
                        MyArray.Add(year)
                    End If
                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(String)), String())
    End Function
    Public Function getCarNamesWithLocators() As String()
        Dim MyArray As New ArrayList

        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select distinct(carname) FROM [colorLocator]")
                Dim i As Integer = 0

                While DR.Read
                    Dim model As String = DR.Item("carname")
                    MyArray.Add(model)
                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(String)), String())
    End Function
#End Region

#Region "language"

    Public Function getLanguages(ByVal whereStr As String) As Language()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [language] " & whereStr)
                Dim i As Integer = 0

                While DR.Read
                    Dim newLang As New Language

                    newLang.id_language = DR.Item("id_language")
                    If Not DR.Item("code_language") Is DBNull.Value Then
                        newLang.code_language = DR.Item("code_language").trim
                    End If
                    If Not DR.Item("label_language") Is DBNull.Value Then
                        newLang.label_language = DR.Item("label_language").trim
                    End If

                    MyArray.Add(newLang)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Language)), Language())
    End Function

#End Region

#Region "garage"

    Public Function loginGarage(ByVal key As String) As Boolean
        Dim success As Boolean = False
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [garage] where [key]='" & key & "' and chosen='1'")
                Dim i As Integer = 0

                If DR.Read Then
                    success = True
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return success
    End Function

    Public Function getGarages(ByVal whereStr As String) As Garage()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [garage] " & whereStr)
                Dim i As Integer = 0

                While DR.Read
                    Dim newGarage As New Garage

                    newGarage.id_garage = DR.Item("id_garage")
                    If Not DR.Item("garage_name") Is DBNull.Value Then
                        newGarage.garage_name = DR.Item("garage_name").trim
                    End If
                    If Not DR.Item("name_responsible") Is DBNull.Value Then
                        newGarage.name_responsible = DR.Item("name_responsible").trim
                    End If
                    If Not DR.Item("location") Is DBNull.Value Then
                        newGarage.location = DR.Item("location").trim
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        newGarage.version = DR.Item("version").trim
                    End If
                    If Not DR.Item("id_language") Is DBNull.Value Then
                        newGarage.id_language = DR.Item("id_language")
                    End If
                    If Not DR.Item("logo") Is DBNull.Value Then
                        newGarage.logo = DR.Item("logo")
                    End If
                    If Not DR.Item("coat") Is DBNull.Value Then
                        newGarage.coat = DR.Item("coat")
                    End If
                    If Not DR.Item("key") Is DBNull.Value Then
                        newGarage.key = DR.Item("key")
                    End If
                    If Not DR.Item("key1") Is DBNull.Value Then
                        newGarage.key1 = DR.Item("key1")
                    End If
                    If Not DR.Item("chosen") Is DBNull.Value Then
                        If DR.Item("chosen") = "1" Then
                            newGarage.chosen = True
                        Else
                            newGarage.chosen = False
                        End If

                    End If

                    If Not DR.Item("showall") Is DBNull.Value Then
                        If DR.Item("showall") = "1" Then
                            newGarage.showAll = True
                        Else
                            newGarage.showAll = False
                        End If
                    Else
                        newGarage.showAll = False
                    End If

                    newGarage.showAlternativeName = False
                    newGarage.showAlternativeName2 = False

                    If Not DR.Item("showAlternativeName") Is DBNull.Value Then
                        If DR.Item("showAlternativeName") = "1" Then
                            newGarage.showAlternativeName = True
                        Else
                            If DR.Item("showAlternativeName") = "2" Then
                                newGarage.showAlternativeName2 = True
                            End If
                        End If

                    End If

                    newGarage.apply_equation = False

                    If Not DR.Item("apply_equation") Is DBNull.Value Then
                        Dim appEqDB As String = DR.Item("apply_equation")
                        Dim appEq As Integer = 0

                        If appEqDB.IndexOf("+") = -1 Then
                            appEq = Integer.Parse(appEqDB)
                        Else
                            Try
                                appEq = Integer.Parse(appEqDB.Substring(0, appEqDB.IndexOf("+")))

                            Catch ex As Exception
                                MsgBox("Verify garage data (Appy eq field)", MsgBoxStyle.Exclamation)
                                Throw ex
                            End Try
                        End If


                        If appEq = 1 Then
                            newGarage.apply_equation = True

                        End If
                    End If

                    MyArray.Add(newGarage)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Garage)), Garage())
    End Function

    Public Function getSelectedGarage(ByVal dbLocation As String) As Garage
        If openConnectionSpecificDb(dbLocation) Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [Garage] where chosen='1'")
                Dim i As Integer = 0

                If DR.Read Then
                    Dim garage As Garage
                    garage = New Garage()

                    garage.id_garage = DR.Item("id_garage")
                    If Not DR.Item("id_language") Is DBNull.Value Then
                        garage.id_language = DR.Item("id_language")
                    End If
                    If Not DR.Item("name_responsible") Is DBNull.Value Then
                        garage.name_responsible = DR.Item("name_responsible")
                    End If
                    If Not DR.Item("garage_name") Is DBNull.Value Then
                        garage.garage_name = DR.Item("garage_name")
                    End If
                    If Not DR.Item("location") Is DBNull.Value Then
                        garage.location = DR.Item("location")
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        garage.version = DR.Item("version").trim
                    End If
                    If Not DR.Item("logo") Is DBNull.Value Then
                        garage.logo = DR.Item("logo")
                    End If
                    If Not DR.Item("coat") Is DBNull.Value Then
                        garage.coat = DR.Item("coat")
                    End If
                    If Not DR.Item("key") Is DBNull.Value Then
                        garage.key = DR.Item("key")
                    End If
                    If Not DR.Item("key1") Is DBNull.Value Then
                        garage.key1 = DR.Item("key1")
                    End If
                    If Not DR.Item("showall") Is DBNull.Value Then
                        If DR.Item("showall") = "1" Then
                            garage.showAll = True
                        Else
                            garage.showAll = False
                        End If
                    Else
                        garage.showAll = False
                    End If

                    garage.showAlternativeName = False
                    garage.showAlternativeName2 = False

                    If Not DR.Item("showAlternativeName") Is DBNull.Value Then
                        If DR.Item("showAlternativeName") = "1" Then
                            garage.showAlternativeName = True
                        Else
                            If DR.Item("showAlternativeName") = "2" Then
                                garage.showAlternativeName2 = True
                            End If

                        End If
                    End If

                    garage.apply_equation = False
                    If Not DR.Item("apply_equation") Is DBNull.Value Then
                        Dim appEqDB As String = DR.Item("apply_equation")
                        Dim appEq As Integer = 0
                        If appEqDB.IndexOf("+") = -1 Then
                            appEq = Integer.Parse(appEqDB)
                        Else
                            Try
                                appEq = Integer.Parse(appEqDB.Substring(0, appEqDB.IndexOf("+")))

                            Catch ex As Exception
                                MsgBox("Verify garage data (Appy eq field)", MsgBoxStyle.Exclamation)
                                Throw ex
                            End Try
                        End If


                        If appEq = 1 Then
                            garage.apply_equation = True

                        End If
                    End If

                    garage.chosen = True
                    getSelectedGarage = garage

                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function
    Public Function getChosenGarage() As Garage
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [Garage] where chosen='1'")
                Dim i As Integer = 0

                If DR.Read Then
                    Dim garage As Garage
                    garage = New Garage()

                    garage.id_garage = DR.Item("id_garage")
                    If Not DR.Item("id_language") Is DBNull.Value Then
                        garage.id_language = DR.Item("id_language")
                    End If
                    If Not DR.Item("name_responsible") Is DBNull.Value Then
                        garage.name_responsible = DR.Item("name_responsible")
                    End If
                    If Not DR.Item("garage_name") Is DBNull.Value Then
                        garage.garage_name = DR.Item("garage_name")
                    End If
                    If Not DR.Item("location") Is DBNull.Value Then
                        garage.location = DR.Item("location")
                    End If
                    If Not DR.Item("version") Is DBNull.Value Then
                        garage.version = DR.Item("version").trim
                    End If
                    If Not DR.Item("logo") Is DBNull.Value Then
                        garage.logo = DR.Item("logo")
                    End If
                    If Not DR.Item("coat") Is DBNull.Value Then
                        garage.coat = DR.Item("coat")
                    End If
                    If Not DR.Item("key") Is DBNull.Value Then
                        garage.key = DR.Item("key")
                    End If
                    If Not DR.Item("key1") Is DBNull.Value Then
                        garage.key1 = DR.Item("key1")
                    End If
                    If Not DR.Item("showall") Is DBNull.Value Then
                        If DR.Item("showall") = "1" Then
                            garage.showAll = True
                        Else
                            garage.showAll = False
                        End If
                    Else
                        garage.showAll = False
                    End If

                    garage.showAlternativeName = False
                    garage.showAlternativeName2 = False

                    If Not DR.Item("showAlternativeName") Is DBNull.Value Then
                        If DR.Item("showAlternativeName") = "1" Then
                            garage.showAlternativeName = True
                        Else
                            If DR.Item("showAlternativeName") = "2" Then
                                garage.showAlternativeName2 = True
                            End If

                        End If
                    End If

                    garage.apply_equation = False

                    If Not DR.Item("apply_equation") Is DBNull.Value Then
                        Dim appEqDB As String = DR.Item("apply_equation")
                        Dim appEq As Integer = 0

                        If appEqDB.IndexOf("+") = -1 Then
                            appEq = Integer.Parse(appEqDB)
                        Else
                            Try
                                appEq = Integer.Parse(appEqDB.Substring(0, appEqDB.IndexOf("+")))

                            Catch ex As Exception
                                MsgBox("Verify garage data (Appy eq field)", MsgBoxStyle.Exclamation)
                                Throw ex
                            End Try
                        End If

                        If appEq = 1 Then
                            garage.apply_equation = True

                        End If
                    End If

                    garage.chosen = True
                    getChosenGarage = garage

                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function



#End Region

#Region "color"
    Public Function getColors(ByVal whereStr As String) As AmazonaColor()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [color] " & whereStr)
                Dim i As Integer = 0

                While DR.Read
                    Dim newcolor As New AmazonaColor

                    newcolor.id_color = DR.Item("id_color")
                    If Not DR.Item("name_color") Is DBNull.Value Then
                        newcolor.name_color = DR.Item("name_color").trim
                    End If
                    If chosenGarage.showAlternativeName And Not DR.Item("name_color_alternative") Is DBNull.Value Then
                        If DR.Item("name_color_alternative").trim <> "" Then
                            newcolor.name_color = DR.Item("name_color_alternative").trim
                        End If
                    End If
                    If chosenGarage.showAlternativeName2 And Not DR.Item("name_color_alternative2") Is DBNull.Value Then
                        If DR.Item("name_color_alternative2").trim <> "" Then
                            newcolor.name_color = DR.Item("name_color_alternative2").trim
                        End If
                    End If
                    If Not DR.Item("defaultPrice") Is DBNull.Value Then
                        newcolor.defaultPrice = DR.Item("defaultPrice")
                    End If
                    If Not DR.Item("id_defaultCurreny") Is DBNull.Value Then
                        newcolor.id_defaultCurreny = DR.Item("id_defaultCurreny")
                    End If
                    If Not DR.Item("id_defaultUnit") Is DBNull.Value Then
                        newcolor.id_defaultUnit = DR.Item("id_defaultUnit")
                    End If
                    If Not DR.Item("colorImgPath") Is DBNull.Value Then
                        newcolor.colorImgPath = DR.Item("colorImgPath")
                    End If
                    If Not DR.Item("colorCode") Is DBNull.Value Then
                        newcolor.colorCode = DR.Item("colorCode")
                    End If
                    If Not DR.Item("masse_volumique") Is DBNull.Value Then
                        newcolor.masse_volumique = DR.Item("masse_volumique")
                    End If
                    If Not DR.Item("masse_volumique_ext") Is DBNull.Value Then
                        newcolor.masse_volumique_ext = DR.Item("masse_volumique_ext")
                    End If
                    If Not DR.Item("id_unit_on_entry") Is DBNull.Value Then
                        newcolor.id_unit_on_entry = DR.Item("id_unit_on_entry")
                    End If

                    'decryption
                    newcolor.colorCode = decryptData(newcolor.colorCode, password & chosenGarage.garage_name)
                    newcolor.name_color = decryptData(newcolor.name_color, password & chosenGarage.garage_name)

                    MyArray.Add(newcolor)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(AmazonaColor)), AmazonaColor())
    End Function

    Public Function getColorById(ByVal id) As AmazonaColor
        If Not colors Is Nothing Then
            Dim i As Integer
            For i = 0 To colors.Length - 1
                If colors(i).id_color = id Then
                    Return colors(i)
                End If
            Next
        Else
            Dim whereStr As String = " WHERE id_color=" & id
            Dim colorTab() As AmazonaColor = getColors(whereStr)
            Dim color As AmazonaColor = Nothing
            If Not colorTab Is Nothing Then
                If colorTab.Length > 0 Then
                    color = colorTab(0)
                End If
            End If

            Return color
        End If

    End Function

    Public Function getColorByCode(ByVal colorCode As String) As AmazonaColor
        If Not colors Is Nothing Then
            Dim i As Integer
            For i = 0 To colors.Length - 1
                If colors(i).colorCode = colorCode Then
                    Return colors(i)
                End If
            Next
        End If
        Return Nothing

    End Function

#End Region

#Region "Labels"

    Public Function getLabelDescription(ByVal name_label As String) As String
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader
                DR = selectQuery(String.Format("SELECT description FROM [Label] lb,[labelLanguage] la WHERE lb.id_label=la.id_label AND la.id_language={0} AND name_label='{1}'", chosenLanguage.id_language, name_label))
                Dim i As Integer = 0

                If DR.Read Then
                    If Not DR.Item("description") Is DBNull.Value Then
                        getLabelDescription = DR.Item("description").trim
                    Else
                        getLabelDescription = ""
                    End If
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function
#End Region

#Region "font"
    Public Function getFontSize() As Integer()
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader
                DR = selectQuery(String.Format("SELECT * FROM [lastFont]"))
                Dim i As Integer = 0
                Dim pct_height As Integer
                Dim fontsize As Integer
                If DR.Read Then
                    If Not DR.Item("font_size") Is DBNull.Value Then
                        fontsize = DR.Item("font_size")
                    Else
                        fontsize = 9
                    End If
                    If Not DR.Item("pct_height") Is DBNull.Value Then
                        pct_height = DR.Item("pct_height")
                    Else
                        pct_height = 23
                    End If
                    Dim intArray(2) As Integer
                    intArray(0) = fontsize
                    intArray(1) = pct_height
                    getFontSize = intArray

                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function

#End Region

#Region "Transaction"
    Public Function getTransactionTab(ByVal formulaId, Optional ByVal transactionDate = Nothing) As Transaction()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim str As String = ""
                If Not transactionDate Is Nothing Then
                    Dim tDate As Date = transactionDate
                    Dim year As Long = tDate.Year
                    Dim month As Long = tDate.Month
                    Dim day As Long = tDate.Day

                    str = " AND transactionYear=" & year
                    str &= " AND transactionMonth=" & month
                    str &= " AND transactionDay=" & day
                End If
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select transactionTable.id_transaction,client_name,amount,id_curreny,discount,transactionYear,transactionMonth,transactionDay FROM [transactionTable],[transactionFormula] WHERE transactionTable.id_transaction=transactionFormula.id_transaction AND transactionFormula.id_formula=" & formulaId & str)
                Dim i As Integer = 0

                While DR.Read
                    Dim transaction As Transaction
                    transaction = New Transaction()

                    transaction.id_transaction = DR.Item(0)

                    Dim tDate As Date
                    Dim year As Long
                    Dim month As Long
                    Dim day As Long

                    If Not DR.Item("transactionYear") Is DBNull.Value Then
                        year = DR.Item("transactionYear")
                    End If
                    If Not DR.Item("transactionMonth") Is DBNull.Value Then
                        month = DR.Item("transactionMonth")
                    End If
                    If Not DR.Item("transactionDay") Is DBNull.Value Then
                        day = DR.Item("transactionDay")
                    End If
                    tDate = New Date(year, month, day)
                    transaction.transactionDate = tDate
                    If Not DR.Item("amount") Is DBNull.Value Then
                        transaction.amount = DR.Item("amount")
                    End If

                    If Not DR.Item("discount") Is DBNull.Value Then
                        transaction.discount = DR.Item("discount")
                    End If

                    If Not DR.Item("id_curreny") Is DBNull.Value Then
                        transaction.id_curreny = DR.Item("id_curreny")
                    End If

                    If Not DR.Item("client_name") Is DBNull.Value Then
                        transaction.client_name = DR.Item("client_name")
                    End If
                    MyArray.Add(transaction)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Transaction)), Transaction())
    End Function


    Public Function getTransactionTable() As Transaction()
        Dim MyArray As New ArrayList
        If openConnectionNewDb() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [transactionTable]")
                Dim i As Integer = 0

                While DR.Read
                    Dim transaction As Transaction
                    transaction = New Transaction()

                    transaction.id_transaction = DR.Item("id_transaction")

                    Dim tDate As Date
                    Dim year As Long
                    Dim month As Long
                    Dim day As Long

                    If Not DR.Item("transactionYear") Is DBNull.Value Then
                        year = DR.Item("transactionYear")
                    End If
                    If Not DR.Item("transactionMonth") Is DBNull.Value Then
                        month = DR.Item("transactionMonth")
                    End If
                    If Not DR.Item("transactionDay") Is DBNull.Value Then
                        day = DR.Item("transactionDay")
                    End If
                    tDate = New Date(year, month, day)
                    transaction.transactionDate = tDate
                    If Not DR.Item("amount") Is DBNull.Value Then
                        transaction.amount = DR.Item("amount")
                    End If

                    If Not DR.Item("discount") Is DBNull.Value Then
                        transaction.discount = DR.Item("discount")
                    End If

                    If Not DR.Item("id_curreny") Is DBNull.Value Then
                        transaction.id_curreny = DR.Item("id_curreny")
                    End If

                    If Not DR.Item("client_name") Is DBNull.Value Then
                        transaction.client_name = DR.Item("client_name")
                    End If
                    MyArray.Add(transaction)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(Transaction)), Transaction())
    End Function

    Public Function getTransactionFormulaTable() As TransactionFormula()
        Dim MyArray As New ArrayList
        If openConnectionNewDb() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [TransactionFormula]")
                Dim i As Integer = 0

                While DR.Read
                    Dim transactionFormula As TransactionFormula
                    transactionFormula = New TransactionFormula()

                    transactionFormula.id_transactionFormula = DR.Item("id_transactionFormula")

                    If Not DR.Item("id_formula") Is DBNull.Value Then
                        transactionFormula.id_formula = DR.Item("id_formula")
                    End If

                    If Not DR.Item("id_transaction") Is DBNull.Value Then
                        transactionFormula.id_transaction = DR.Item("id_transaction")

                    End If

                    MyArray.Add(transactionFormula)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(TransactionFormula)), TransactionFormula())
    End Function


#End Region

#Region "unit"
    Public Function getUnitLanguage(ByVal id_unit) As UnitLanguage()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [UnitLanguage] where id_unit=" & id_unit)
                Dim i As Integer = 0

                While DR.Read
                    Dim unitLanguage As UnitLanguage
                    unitLanguage = New UnitLanguage()

                    unitLanguage.id_unitLanguage = DR.Item("id_unitLanguage")
                    If Not DR.Item("id_unit") Is DBNull.Value Then
                        unitLanguage.id_unit = DR.Item("id_unit")
                    End If
                    If Not DR.Item("id_language") Is DBNull.Value Then
                        unitLanguage.id_language = DR.Item("id_language")
                    End If

                    If Not DR.Item("name_unit") Is DBNull.Value Then
                        unitLanguage.name_unit = DR.Item("name_unit")
                    End If

                    MyArray.Add(unitLanguage)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(UnitLanguage)), UnitLanguage())
    End Function


    Public Function getChosenUnit() As Unit
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [unit] where chosen='1'")
                Dim i As Integer = 0

                If DR.Read Then
                    Dim unit As Unit
                    unit = New Unit()

                    unit.id_unit = DR.Item("id_unit")
                    If Not DR.Item("code_unit") Is DBNull.Value Then
                        unit.code_unit = DR.Item("code_unit")
                    End If
                    If Not DR.Item("rateToLitre") Is DBNull.Value Then
                        unit.rateToLitre = DR.Item("rateToLitre")
                    End If
                    unit.unitLanguage = getUnitLanguage(unit.id_unit)
                    unit.chosen = True
                    getChosenUnit = unit
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function

    Public Function getUnitByCode(ByVal codeUnit As String) As Unit
        Dim unit As Unit = Nothing
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [unit] where lcase(code_unit)='" & codeUnit.ToLower & "'")
                Dim i As Integer = 0

                If DR.Read Then

                    unit = New Unit()

                    unit.id_unit = DR.Item("id_unit")
                    If Not DR.Item("code_unit") Is DBNull.Value Then
                        unit.code_unit = DR.Item("code_unit")
                    End If
                    If Not DR.Item("rateToLitre") Is DBNull.Value Then
                        unit.rateToLitre = DR.Item("rateToLitre")
                    End If
                    unit.unitLanguage = getUnitLanguage(unit.id_unit)
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Return unit
            End Try
        End If
        closeConnection()
        Return unit
    End Function
#End Region

#Region "currency"
    Public Function getCurrencyLanguage(ByVal id_unit) As CurrencyLanguage()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [currencyLanguage] where id_currency=" & id_unit)
                Dim i As Integer = 0

                While DR.Read
                    Dim currencyLanguage As CurrencyLanguage
                    currencyLanguage = New CurrencyLanguage()

                    currencyLanguage.id_currencyLanguage = DR.Item("id_currencyLanguage")
                    If Not DR.Item("id_currency") Is DBNull.Value Then
                        currencyLanguage.id_currency = DR.Item("id_currency")
                    End If
                    If Not DR.Item("id_language") Is DBNull.Value Then
                        currencyLanguage.id_language = DR.Item("id_language")
                    End If

                    If Not DR.Item("label") Is DBNull.Value Then
                        currencyLanguage.label = DR.Item("label")
                    End If

                    MyArray.Add(currencyLanguage)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(CurrencyLanguage)), CurrencyLanguage())
    End Function


    Public Function getChosenCurreny() As Currency
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [userCurrency] where chosen='1'")
                Dim i As Integer = 0

                If DR.Read Then
                    Dim currency As Currency
                    currency = New Currency()

                    currency.id_currency = DR.Item("id_currency")
                    If Not DR.Item("code_currency") Is DBNull.Value Then
                        currency.code_currency = DR.Item("code_currency")
                    End If
                    If Not DR.Item("rateToDollar") Is DBNull.Value Then
                        currency.rateToDollar = DR.Item("rateToDollar")
                    End If
                    currency.currencyLanguage = getCurrencyLanguage(currency.id_currency)
                    currency.chosen = True
                    getChosenCurreny = currency
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
    End Function

#End Region

#Region "Garage Price"
    Public Function getGaragePricesDB(ByVal whereStr As String) As GaragePrice()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [garagePrice] " & whereStr)
                Dim i As Integer = 0

                While DR.Read
                    Dim newGaragePrice As New GaragePrice

                    newGaragePrice.id_garagePrice = DR.Item("id_garagePrice")
                    If Not DR.Item("id_color") Is DBNull.Value Then
                        newGaragePrice.id_color = DR.Item("id_color")
                    End If
                    If Not DR.Item("garage_price") Is DBNull.Value Then
                        newGaragePrice.garage_price = DR.Item("garage_price")

                    End If
                    If Not DR.Item("id_currency") Is DBNull.Value Then
                        newGaragePrice.id_currency = DR.Item("id_currency")
                    End If
                    If Not DR.Item("id_unit") Is DBNull.Value Then
                        newGaragePrice.id_unit = DR.Item("id_unit")
                    End If
                    MyArray.Add(newGaragePrice)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(GaragePrice)), GaragePrice())
    End Function
#End Region


#Region "Cars and colorCode"
    Public Function findCarIdsByColorCode(ByVal colorCode As String, ByVal contains As Boolean) As List(Of Car)
        Dim cars As New List(Of Car)

        Dim allCars As Car() = getCars("")
        For Each car As Car In allCars
            Dim whereStr As String
            If contains Then
                whereStr = " AND LCASE(colorCode) like '%" & colorCode.ToLower & "%'"
            Else
                whereStr = " AND LCASE(colorCode) like '" & colorCode.ToLower & "%'"
            End If
            Dim formulas As Formula() = getFormulas(whereStr, car.tableName, car.carName, car.id_car)

            If Not formulas Is Nothing Then
                If formulas.Length > 0 Then
                    cars.Add(car)
                End If
            End If
        Next

        Return cars


    End Function
#End Region

End Module
