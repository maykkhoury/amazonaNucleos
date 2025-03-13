Module dbNonQueries

#Region "UpdateFile"
    Public Sub insertIntoUpdateTable(ByVal str As String, ByVal actionType As String)
        Try

            Dim id_action As String = 0
            Try
                openConnection()
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select MAX(id_action)  FROM [UpdateTable]")
                If DR.Read Then
                    If Not DR.Item(0) Is DBNull.Value Then
                        id_action = DR.Item(0)
                    End If
                End If
                DR.Close()
                closeConnection()
            Catch ex As Exception
                closeConnection()
                MsgBox(ex.Message.ToString)
                Exit Sub
            End Try
            id_action += 1
            str = SafeSqlLiteral(str) & ";"
            'insert line by line (200 char per line)
           
            While str.Length > 0
                openConnection()
                Dim line As String = ""
                If str.Length > 200 Then
                    line = str.Substring(0, 200)
                    str = str.Substring(200)
                Else
                    line = str
                    str = ""
                End If

                Dim SQLstr As String = String.Format("INSERT INTO [updateTable] (id_action, text_line,actionType) VALUES({0},'{1}','{2}')", id_action, line, actionType)
                Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

                Dim icount As Integer = Command.ExecuteNonQuery()


                closeConnection()
            End While
            '--------------------------
        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Sub
    
    Public Sub restoreDatabase()
        Try
            'delete DeleteTable
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("DELETE FROM [UpdateTable]")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()

            closeConnection()

        Catch ex As Exception
            closeConnection()
            MessageBox.Show("could not DELETE record:" & ex.Message.ToString)
        End Try
    End Sub
    Public Function getUpdateTable() As UpdateTable()
        Dim MyArray As New ArrayList
        If openConnection() Then
            Try
                Dim DR As OleDb.OleDbDataReader = selectQuery("Select * FROM [UpdateTable] ORDER BY id_updateTable asc")
                Dim i As Integer = 0

                While DR.Read
                    Dim newRow As New UpdateTable

                    newRow.id_updateTable = DR.Item("id_updateTable")
                    If Not DR.Item("id_action") Is DBNull.Value Then
                        newRow.id_action = DR.Item("id_action")
                    End If
                    If Not DR.Item("actionType") Is DBNull.Value Then
                        newRow.actionType = DR.Item("actionType").trim
                    End If
                    If Not DR.Item("text_line") Is DBNull.Value Then
                        newRow.text_lineType = DR.Item("text_line").trim
                    End If
                    MyArray.Add(newRow)

                End While
                DR.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
        closeConnection()
        Return DirectCast(MyArray.ToArray(GetType(UpdateTable)), UpdateTable())
    End Function

    Public Function performQuery(ByVal query As String) As String
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format(query)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()
            Return ""
        Catch ex As Exception
            closeConnection()
            Return ("could not execute query:" & query & vbNewLine & ex.Message.ToString & vbNewLine & vbNewLine)
        End Try
    End Function
#End Region
#Region "Optimisation"
    Private Sub updateColorCodeByFormulaIdOpt(ByVal idFormula As Integer, ByVal colorCode As String)
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulasNewDB.Length - 1
            If allFormulasNewDB(i).id_formula = idFormula Then
                allFormulasNewDB(i).colorCode = colorCode
            End If

        Next
        
    End Sub

    Private Sub updateFormulaTableOpt(ByVal formula As Formula)
        Dim dayStr As String = Now.Day
        If Now.Day < 10 Then
            dayStr = "0" & Now.Day
        End If

        Dim monthStr As String = Now.Month
        If Now.Month < 10 Then
            monthStr = "0" & Now.Month
        End If

        formula.dateCreMod = New DateCreMod(Now.Year, monthStr, dayStr, Now.Hour, Now.Minute, Now.Second)
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulasNewDB.Length - 1
            If allFormulasNewDB(i).id_formula = formula.id_formula Then
                allFormulasNewDB(i) = formula
            End If

        Next
    End Sub
   
    Private Sub deleteFromFormulaColorByIdFormula(ByVal idFormula As Integer)
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulaColors.Length - 1
            If allFormulaColors(i).id_formula <> idFormula Then
                MyArray.Add(allFormulaColors(i))
            End If

        Next
        allFormulaColors = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())

    End Sub
    Private Sub deleteFromFormulaColorByIdFormulaColor(ByVal idFormulaColor As Integer)
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulaColors.Length - 1
            If allFormulaColors(i).id_formulaColor <> idFormulaColor Then
                MyArray.Add(allFormulaColors(i))
            End If

        Next
        allFormulaColors = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())

    End Sub

    Private Sub deleteFromFormulaByIdFormula(ByVal idFormula As Integer)
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulasNewDB.Length - 1
            If allFormulasNewDB(i).id_formula <> idFormula Then
                MyArray.Add(allFormulasNewDB(i))
            End If

        Next
        allFormulasNewDB = DirectCast(MyArray.ToArray(GetType(Formula)), Formula())

    End Sub

   
    
#End Region
#Region "Formulas"

    Public Function deleteClientIntoFormulaColor(ByVal idFormula, ByVal olddb) As Boolean
        Try
     
            openConnectionNewDb()
           
            Dim SQLstr As String
            SQLstr = String.Format("DELETE FROM [clientFormulaColor] WHERE id_formula={0}", idFormula)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                deleteClientIntoFormulaColor = True

            Else
                deleteClientIntoFormulaColor = False
            End If
            closeConnection()

        Catch ex As Exception
            closeConnection()
            deleteClientIntoFormulaColor = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Function deleteFormula(ByVal id_Formula, ByVal olddb) As Boolean
        If deleteClientIntoFormulaColor(id_Formula, olddb) Then
            Try

                openConnectionNewDb()

                Dim SQLstr As String
                SQLstr = String.Format("DELETE FROM [clientFormula] WHERE id_Formula={0}", id_Formula)
                Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

                Dim icount As Integer = Command.ExecuteNonQuery()
                If icount > 0 Then
                    deleteFormula = True
                    'deleteFromFormulaByIdFormula(id_Formula)
                Else
                    deleteFormula = False
                End If
                closeConnection()


            Catch ex As Exception
                closeConnection()
                deleteFormula = False
                MessageBox.Show("could not delete record:" & ex.Message.ToString)
            End Try
        End If
    End Function

    Public Function getCurrentDateDBString() As String
        Dim dateCreMod As Date = Now

        Dim day As Integer = dateCreMod.Day
        Dim month As Integer = dateCreMod.Month
        Dim year As Integer = dateCreMod.Year
        Dim hour As Integer = dateCreMod.Hour
        Dim minute As Integer = dateCreMod.Minute
        Dim second As Integer = dateCreMod.Second
        Dim dateCreModStr As String = day & ":" & month & ":" & year
        dateCreModStr = dateCreModStr & ":" & hour & ":" & minute & ":" & second

        Return dateCreModStr
    End Function

    Public Function getLastInsertedFormulaColorIdClient() As Integer
        Try
            openConnection()
            Dim DR As OleDb.OleDbDataReader = selectQuery("Select max(id_formulaColor) FROM [clientformulaColor]")
            If DR.Read Then
                If DR.Item(0) Is DBNull.Value Then
                    getLastInsertedFormulaColorIdClient = -1
                Else
                    getLastInsertedFormulaColorIdClient = DR.Item(0)
                End If
            End If
            DR.Close()
            closeConnection()
        Catch ex As Exception
            getLastInsertedFormulaColorIdClient = -1
            MessageBox.Show("could not select max :" & ex.Message.ToString & ": " & vbNewLine & ex.StackTrace)
        End Try
    End Function

    Public Function getLastInsertedFormulaIdClient() As Integer
        Try
            openConnection()
            Dim DR As OleDb.OleDbDataReader = selectQuery("Select max(id_formula) FROM [Clientformula]")
            If DR.Read Then
                If DR.Item(0) Is DBNull.Value Then
                    getLastInsertedFormulaIdClient = 0
                Else
                    getLastInsertedFormulaIdClient = DR.Item(0)
                End If
            End If
            DR.Close()
            closeConnection()
        Catch ex As Exception
            getLastInsertedFormulaIdClient = 0
            MessageBox.Show("could not select max :" & ex.Message.ToString)
        End Try
    End Function

    Public Function insertIntoFormulaClient(ByVal name_formula, ByVal id_car, ByVal nameCar, ByVal type, ByVal version, ByVal formulaVariant, ByVal colorCode, ByVal clientName, ByVal colorRGB, ByVal c_year, ByVal cardNumber) As Boolean
        Try
            Dim newId_formula As Integer = getLastInsertedFormulaIdClient() + 1
            Dim dateCreModStr As String = getCurrentDateDBString()
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [Clientformula] (id_formula,name_formula, id_car, type, version, variant,clientName,colorCode,colorRGB,c_year,cardNumber,date_cre_mod,state,seqnum) VALUES({0},'{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','I',0)", newId_formula, name_formula, id_car, type, version, formulaVariant, clientName, colorCode, colorRGB, c_year, cardNumber, dateCreModStr)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoFormulaClient = True
                
            Else
                insertIntoFormulaClient = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoFormulaClient = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Function

   
    Public Function insertIntoFormulaColorClient(ByVal id_formula, ByVal id_color, ByVal quantite, ByVal id_unit) As Boolean
        Try
            Dim newId_formulaColor As Integer = getLastInsertedFormulaColorIdClient() + 1
            Dim encQuantity As String = encryptQuantity(quantite, newId_formulaColor)

            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [ClientformulaColor]  (id_formulaColor,id_formula,id_color,quantite,id_unit,state, encrypted) VALUES({0},{1},'{2}','{3}',{4},'I',{5})", newId_formulaColor, id_formula, id_color, encQuantity, id_unit, encryptionActive)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)


            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoFormulaColorClient = True
            Else
                insertIntoFormulaColorClient = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoFormulaColorClient = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function


    Public Function deleteIntoFormulaColor(ByVal idFormulaColor) As Boolean
        Try
            'delete formulaColor
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("DELETE FROM [formulaColor] WHERE id_formulaColor={0}", idFormulaColor)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                deleteIntoFormulaColor = True
                deleteFromFormulaColorByIdFormulaColor(idFormulaColor)
            Else
                deleteIntoFormulaColor = False
            End If
            closeConnection()

        Catch ex As Exception
            closeConnection()
            deleteIntoFormulaColor = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function



    Public Sub setLastChosenBaseCoat(ByVal chosenBaseCoat As String)
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("delete from [GlobalVariables] where variable_name like '%chosenBaseCoat%'")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()

        Catch ex As Exception
            closeConnection()
            MessageBox.Show("could not delete record:" & ex.Message.ToString)
        End Try

        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [GlobalVariables] (variable_name,variable_value) VALUES('chosenBaseCoat','{0}')", chosenBaseCoat)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()

        Catch ex As Exception
            closeConnection()
            MessageBox.Show("could not INSERT record:" & ex.Message.ToString)
        End Try
    End Sub

#End Region

#Region "Cars"

  
    Public Sub setLastChosenCar(ByVal chosenCar As Car)
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("delete from [GlobalVariables] where variable_name like '%id_car%'")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()

        Catch ex As Exception
            closeConnection()
            MessageBox.Show("could not delete record:" & ex.Message.ToString)
        End Try

        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [GlobalVariables] (variable_name,variable_value) VALUES('id_car','{0}')", chosenCar.id_car)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()

        Catch ex As Exception
            closeConnection()
            MessageBox.Show("could not INSERT record:" & ex.Message.ToString)
        End Try
    End Sub


#End Region

#Region "language"

    Public Function insertIntoLanguages(ByVal code, ByVal label) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [language] (code_language,label_language,isDefault, state,seqnum) VALUES('{0}','{1}',0,'I',0)", code, label)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoLanguages = True
                insertIntoUpdateTable(SQLstr, "INSERT")
            Else
                insertIntoLanguages = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoLanguages = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Function updateLanguage(ByVal id_language, ByVal code_language, ByVal label_language) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [language] set isDefault='0',code_language = '{0}',label_language='{1}',state='U',seqnum=seqnum+1 WHERE id_language={2}", code_language, label_language, id_language)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                updateLanguage = True
                insertIntoUpdateTable(SQLstr, "UPDATE")
            Else
                updateLanguage = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            updateLanguage = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Function deleteLanguage(ByVal id_language) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("DELETE FROM [language]  WHERE id_language={0}", id_language)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                deleteLanguage = True
                insertIntoUpdateTable(SQLstr, "DELETE")
            Else
                deleteLanguage = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            deleteLanguage = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

#End Region

#Region "garage"
    Public Function insertIntoGarages(ByVal name, ByVal location, ByVal responsible, ByVal id_language, ByVal logo, ByVal apply_equation) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [garage] (garage_name,location,name_responsible,id_language,logo,apply_equation,state,seqnum) VALUES('{0}','{1}','{2}',{3},'{4}','{5}','I',0)", name, location, responsible, id_language, logo, apply_equation)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoGarages = True
                insertIntoUpdateTable(SQLstr, "INSERT")
            Else
                insertIntoGarages = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoGarages = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function


    Public Function keepGarageLoggedIn(ByVal key1 As String) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [GARAGE] set key1 = '{0}' where chosen='1'", key1)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                keepGarageLoggedIn = True
                insertIntoUpdateTable(SQLstr, "UPDATE")
            Else
                keepGarageLoggedIn = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            keepGarageLoggedIn = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Function updateGarage(ByVal id_garage, ByVal garage_name, ByVal name_responsible, ByVal location, ByVal id_language, ByVal logo, ByVal apply_equation) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [GARAGE] set garage_name = '{0}',name_responsible='{1}',location='{2}',id_language={3},logo='{4}',apply_equation='{5}',state='U',seqnum=seqnum+1 WHERE id_garage={6}", garage_name, name_responsible, location, id_language, logo, apply_equation, id_garage)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                updateGarage = True
                insertIntoUpdateTable(SQLstr, "UPDATE")
            Else
                updateGarage = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            updateGarage = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Function deleteGarage(ByVal id_garage) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("DELETE FROM [garage]  WHERE id_garage={0}", id_garage)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                deleteGarage = True
                insertIntoUpdateTable(SQLstr, "DELETE")
            Else
                deleteGarage = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            deleteGarage = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Sub setChosenGarage(ByVal id_garage)
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [garage] set chosen = '0' ")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()

            insertIntoUpdateTable(SQLstr, "UPDATE")

            openConnection()
            Dim SQLstr2 As String
            SQLstr2 = String.Format("UPDATE [garage] set chosen = '1' WHERE id_garage={0}", id_garage)
            Dim Command2 As New OleDb.OleDbCommand(SQLstr2, DB)
            Dim icount2 As Integer = Command2.ExecuteNonQuery()
            closeConnection()
            insertIntoUpdateTable(SQLstr2, "UPDATE")

        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Sub


#End Region

#Region "color"

#End Region

#Region "Labels"

    Public Sub deleteLabelLang(ByVal idLabel, ByVal idLanguage)
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("DELETE FROM [labelLanguage]  WHERE id_label={0} AND id_language={1}", idLabel, idLanguage)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoUpdateTable(SQLstr, "DELETE")
            End If
            closeConnection()
        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Sub

    Public Function addLabelLanguage(ByVal id_label As String, ByVal value As String, ByVal id_language As Integer) As Boolean
        Try

            openConnection()

            Dim SQLstr2 As String
            SQLstr2 = String.Format("INSERT INTO [LABELLANGUAGE] (id_label, id_language, description) VALUES({0},{1},'{2}')", id_label, id_language, value)

            Dim Command2 As New OleDb.OleDbCommand(SQLstr2, DB)
            Dim icount As Integer = Command2.ExecuteNonQuery
            If icount > 0 Then
                addLabelLanguage = True
                insertIntoUpdateTable(SQLstr2, "INSERT")
            Else
                addLabelLanguage = False
            End If

            closeConnection()
        Catch ex As Exception
            closeConnection()
            addLabelLanguage = False
            MessageBox.Show("could not insert record int table labelLanguage:" & ex.Message.ToString)
        End Try
    End Function

    Public Function addLabel(ByVal name_label As String, ByVal value As String, ByVal id_language As Integer) As Boolean
        Try

            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [LABEL] (name_label) VALUES('{0}')", name_label)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Try
                Command.ExecuteNonQuery()
                insertIntoUpdateTable(SQLstr, "INSERT")
            Catch ex As Exception
                closeConnection()
                addLabel = False
                Exit Function
            End Try



            openConnection()
            Dim id_label As Integer = 0
            Dim DR2 As OleDb.OleDbDataReader = selectQuery("Select max(id_label) FROM [label]")
            If DR2.Read Then
                id_label = DR2.Item(0)
            End If
            DR2.Close()
            closeConnection()

            openConnection()
            If id_label > 0 Then
                Dim SQLstr2 As String
                SQLstr2 = String.Format("INSERT INTO [LABELLANGUAGE] (id_label, id_language, description) VALUES({0},{1},'{2}')", id_label, id_language, value)

                Dim Command2 As New OleDb.OleDbCommand(SQLstr2, DB)
                Dim icount As Integer '= Command2.ExecuteNonQuery
                If icount > 0 Then
                    addLabel = True
                    insertIntoUpdateTable(SQLstr2, "INSERT")
                Else
                    addLabel = False
                End If
            Else
                addLabel = False
            End If
            closeConnection()
        Catch ex As Exception
            closeConnection()
            addLabel = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Function

#End Region

#Region "font"
    Public Sub insertNewFontSize(ByVal value As Integer, ByVal pct_height As Integer)
        Try

            openConnection()

            Dim SQLstr2 As String
            SQLstr2 = String.Format("UPDATE [LastFont] set font_size={0},pct_height={1}", value, pct_height)

            Dim Command2 As New OleDb.OleDbCommand(SQLstr2, DB)
            Dim icount As Integer = Command2.ExecuteNonQuery

            closeConnection()
        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record into font table:" & ex.Message.ToString)
        End Try
    End Sub

#End Region

#Region "transaction"
    Public Function getLastInsertedTransactionId() As Integer
        Try
            openConnection()
            Dim DR As OleDb.OleDbDataReader = selectQuery("Select max(id_transaction) FROM [transactionTable]")
            If DR.Read Then
                getLastInsertedTransactionId = DR.Item(0)
            End If
            DR.Close()
            closeConnection()
        Catch ex As Exception
            getLastInsertedTransactionId = -1
            MessageBox.Show("could not select max :" & ex.Message.ToString)
        End Try
    End Function
    Public Function addTransaction(ByVal id_formula, ByVal transactionDate, ByVal discount, ByVal amount, ByVal id_curreny, ByVal client_name) As Boolean
        addTransaction = False
        If insertIntoTransaction(transactionDate, discount, amount, id_curreny, client_name) Then
            If insertIntoTransactionFormula(id_formula, getLastInsertedTransactionId) Then
                addTransaction = True
            End If
        End If
    End Function
    Public Function insertIntoTransaction(ByVal transactionDate, ByVal discount, ByVal amount, ByVal id_curreny, ByVal client_name) As Boolean
        Try
            Dim tDate As Date = transactionDate
            Dim year As Long = tDate.Year
            Dim month As Long = tDate.Month
            Dim day As Long = tDate.Day
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [transactionTable] (transactionYear,transactionMonth,transactionDay, discount, amount, id_curreny,client_name) VALUES({0},{1},{2},'{3}','{4}',{5},'{6}')", year, month, day, discount, amount, id_curreny, client_name)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoTransaction = True

            Else
                insertIntoTransaction = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoTransaction = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Function

    Public Function insertIntoTransactionFormula(ByVal id_formula, ByVal id_transaction) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [TransactionFormula] (id_formula,id_transaction) VALUES({0},{1})", id_formula, id_transaction)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoTransactionFormula = True
            Else
                insertIntoTransactionFormula = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoTransactionFormula = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function
#End Region

#Region "Unit"
    Public Sub setChosenUnit(ByVal id_unit)
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [unit] set chosen = '0' ")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()
            openConnection()

            Dim SQLstr2 As String
            SQLstr2 = String.Format("UPDATE [unit] set chosen = '1' WHERE id_unit={0}", id_unit)
            Dim Command2 As New OleDb.OleDbCommand(SQLstr2, DB)

            Dim icount2 As Integer = Command2.ExecuteNonQuery()
            closeConnection()

        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region "currency"
    Public Sub setChosenCurrency(ByVal id_Currency)
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [userCurrency] set chosen = '0' ")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()
            openConnection()

            Dim SQLstr2 As String
            SQLstr2 = String.Format("UPDATE [userCurrency] set chosen = '1' WHERE id_currency={0}", id_Currency)
            Dim Command2 As New OleDb.OleDbCommand(SQLstr2, DB)

            Dim icount2 As Integer = Command2.ExecuteNonQuery()
            closeConnection()

        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region "garage Price"

    Public Function insertIntoGaragePrice(ByVal id_color, ByVal price, ByVal id_currency, ByVal id_unit) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("INSERT INTO [garagePrice] (id_color,garage_price,id_currency,id_unit) VALUES({0},'{1}',{2},{3})", id_color, price, id_currency, id_unit)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                insertIntoGaragePrice = True

            Else
                insertIntoGaragePrice = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            insertIntoGaragePrice = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

    Public Function updateGarageColor(ByVal id_color, ByVal price, ByVal id_currency, ByVal id_unit) As Boolean
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [garagePrice] set garage_price='{0}',id_currency={1},id_unit={2} WHERE id_color={3}", price, id_currency, id_unit, id_color)
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)

            Dim icount As Integer = Command.ExecuteNonQuery()
            If icount > 0 Then
                updateGarageColor = True

            Else
                updateGarageColor = False
            End If
            closeConnection()


        Catch ex As Exception
            closeConnection()
            updateGarageColor = False
            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try

    End Function

#End Region

#Region "SHOW ALL HUES"
    Public Sub setShowAllHuesCheck(ByVal showHues As Boolean)
        Dim yesNo As Integer = "0"
        If showHues Then
            yesNo = "1"
        End If
        Try
            openConnection()
            Dim SQLstr As String
            SQLstr = String.Format("UPDATE [garage] set showall='" & yesNo & "' where chosen = '1' ")
            Dim Command As New OleDb.OleDbCommand(SQLstr, DB)
            Dim icount As Integer = Command.ExecuteNonQuery()
            closeConnection()


        Catch ex As Exception
            closeConnection()

            MessageBox.Show("could not insert record:" & ex.Message.ToString)
        End Try
    End Sub
#End Region

End Module
