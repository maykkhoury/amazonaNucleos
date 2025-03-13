Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module Utility

    Private TripleDes As New TripleDESCryptoServiceProvider
    Public Function containsSpecialCharacters(ByVal value As String) As Boolean
        Dim regexItem As Regex = New Regex("^[a-zA-Z0-9 ]*$")
        Dim xval_regex As Boolean

        xval_regex = regexItem.IsMatch(value)

        If xval_regex = "False" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function StreamToByteArray(inputStream As Stream) As Byte()
        Dim bytes = New Byte(16383) {}
        Using memoryStream = New MemoryStream()
            Dim count As Integer
            While ((count = inputStream.Read(bytes, 0, bytes.Length)) > 0)
                memoryStream.Write(bytes, 0, count)
            End While
            Return memoryStream.ToArray()
        End Using
    End Function
    Public Function getVariant(ByVal variantName As String) As FormulaVariants
        Dim i As Integer
        Dim var As FormulaVariants = Nothing
        For i = 0 To variants.Length
            If variants(i).variantName = variantName Then
                var = variants(i)
                Exit For
            End If
        Next
        getVariant = var
    End Function

    Public Sub loopThroughProcess()
        For Each p As Process In Process.GetProcesses()
            Console.WriteLine(p.ProcessName & " - " & p.MainWindowTitle)
        Next
    End Sub
    Public Sub closeAllDbPaintshopOpened()
        For Each p As Process In Process.GetProcesses
            If p.MainWindowTitle.Contains("dbPaintShop") And p.ProcessName.ToUpper = "MSACCESS" Then
                'Ask nicely for the process to close.
                p.CloseMainWindow()

                'Wait up to 10 seconds for the process to close.
                p.WaitForExit(10000)

                If Not p.HasExited Then
                    'The process did not close itself so force it to close.
                    p.Kill()
                End If

                'Dispose the Process object, which is different to closing the running process.
                p.Close()
            End If
           
        Next
    End Sub

    ' Public Function convertToChosenUnit(ByVal value, ByVal rateToLitre) As Double
    'Dim valueInLitre As Double
    '     valueInLitre = value / rateToLitre

    ' Dim rateChosenUnitTolitre As Double = chosenUnit.rateToLitre

    ' Dim valueInChosenUnit As Double = valueInLitre * rateChosenUnitTolitre

    '    Return valueInChosenUnit

    ' End Function

    Public Function convertToChosenCurrency(ByVal value, ByVal rateToDollar) As Double
        Dim valueInDollar As Double
        valueInDollar = value / rateToDollar

        Dim rateChosenCurrToDol As Double = chosenCurrency.rateToDollar

        Dim valueInChosenCurrency As Double = valueInDollar * rateChosenCurrToDol

        Return valueInChosenCurrency

    End Function

    Function SafeSqlLiteral(ByVal strValue) As String
        Dim intLevel As Integer = 1
        '*** Written by user CWA, CoolWebAwards.com Forums. 2 February 2010
        '*** http://forum.coolwebawards.com/threads/11-Preventing-SQL-injection-attacks-using-VB-NET

        ' intLevel represent how thorough the value will be checked for dangerous code
        ' intLevel (1) - Do just the basic. This level will already counter most of the SQL injection attacks
        ' intLevel (2) - &nbsp; (non breaking space) will be added to most words used in SQL queries to prevent unauthorized access to the database. Safe to be printed back into HTML code. Don't use for usernames or passwords

        If Not IsDBNull(strValue) Then
            If intLevel > 0 Then
                strValue = Replace(strValue, "'", "''") ' Most important one! This line alone can prevent most injection attacks
                strValue = Replace(strValue, "--", "")
                strValue = Replace(strValue, "[", "[[]")
                strValue = Replace(strValue, "%", "[%]")
            End If

            If intLevel > 1 Then
                Dim myArray As Array
                myArray = Split("xp_ ;update ;insert ;select ;drop ;alter ;create ;rename ;delete ;replace ", ";")
                Dim i, i2, intLenghtLeft As Integer
                For i = LBound(myArray) To UBound(myArray)
                    Dim rx As New Regex(myArray(i), RegexOptions.Compiled Or RegexOptions.IgnoreCase)
                    Dim matches As MatchCollection = rx.Matches(strValue)
                    i2 = 0
                    For Each match As Match In matches
                        Dim groups As GroupCollection = match.Groups
                        intLenghtLeft = groups.Item(0).Index + Len(myArray(i)) + i2
                        strValue = Left(strValue, intLenghtLeft - 1) & "&nbsp;" & Right(strValue, Len(strValue) - intLenghtLeft)
                        i2 += 5
                    Next
                Next
            End If

            'strValue = replace(strValue, ";", ";&nbsp;")
            'strValue = replace(strValue, "_", "[_]")

            Return strValue
        Else
            Return strValue
        End If

    End Function

    Public Function swapColorsByName(ByVal formulaTab() As Formula, ByVal valDown As String, ByVal valUp As String)
        'fix sous-couche before couche
        Dim lastIndexSwaped As Integer = -2
        For i = 0 To formulaTab.Length - 1
            'swap sous-couche with couche
            If i < formulaTab.Length - 1 And i > lastIndexSwaped + 1 Then
                Dim nameFormula As String = formulaTab(i).name_formula
                If nameFormula.ToLower.Contains(valDown) And Not nameFormula.ToLower.Contains(valUp) Then
                    Dim nameFormulaPlus1 As String = formulaTab(i + 1).name_formula
                    If nameFormulaPlus1.ToLower.Contains(valUp) Then
                        nameFormula = nameFormula.ToLower
                        nameFormulaPlus1 = nameFormulaPlus1.ToLower

                        nameFormula = nameFormula.Substring(0, nameFormula.IndexOf(valDown))
                        nameFormulaPlus1 = nameFormulaPlus1.Substring(0, nameFormulaPlus1.IndexOf(valUp))
                        If nameFormula = nameFormulaPlus1 Then
                            'do the swap
                            Dim tempFormula As Formula = formulaTab(i)
                            formulaTab(i) = formulaTab(i + 1)
                            formulaTab(i + 1) = tempFormula
                            lastIndexSwaped = i
                        End If
                    End If
                End If

            End If
        Next
        Return formulaTab
    End Function


    Private Function getMinYearIndex(ByVal formulas As Formula()) As Integer
        Dim i As Integer
        Dim yearMin As Integer = -1
        Dim indexYearMin As Integer = 0
        For i = 0 To formulas.Length - 1
            Dim fnamecurrent As String = formulas(i).name_formula.ToLower
            Dim years As String = formulas(i).c_year
            If years Is Nothing Then
                Continue For
            End If
            If years.Trim = "" Then
                Continue For
            End If
            If years.IndexOf("-") < 0 Then
                Continue For
            End If
            If years.Trim = "-" Then
                Continue For
            End If
            Dim yearFirst As Integer = Integer.Parse(years.Substring(0, years.IndexOf("-") - 1).Trim)
            If i = 0 Then
                yearMin = yearFirst
                indexYearMin = i
            Else
                If yearFirst < yearMin Then
                    yearMin = yearFirst
                    indexYearMin = i
                End If
            End If
        Next
        Return indexYearMin
    End Function
    Public Function sortByYear(ByVal formulas As Formula()) As Formula()

        Dim targetCount As Integer = formulas.Length
        Dim yearMin As Integer = -1
        Dim MyArray As New ArrayList
        While MyArray.Count < targetCount
            Dim indexMin As Integer = getMinYearIndex(formulas)
            MyArray.Add(formulas(indexMin))
            'remove this element from the array
            Dim i As Integer
            Dim MyArrayTmp As New ArrayList
            For i = 0 To formulas.Length - 1
                If formulas(i).id_formula <> formulas(indexMin).id_formula Then
                    MyArrayTmp.Add(formulas(i))
                End If
            Next
            formulas = DirectCast(MyArrayTmp.ToArray(GetType(Formula)), Formula())
        End While

        Return DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
    End Function

    Public Function placeMetAndMat(ByVal formulas As Formula()) As Formula()
        Dim i As Integer
        Dim MyMetArray As New ArrayList
        Dim MyMatArray As New ArrayList
        Dim MyElseArray As New ArrayList
        Dim MyAllArray As New ArrayList

        For i = 0 To formulas.Length - 1
            Dim fname As String = formulas(i).name_formula
            fname = fname.ToLower.Replace("(couche)", "").Trim
            fname = fname.ToLower.Replace("(couche 1)", "").Trim
            fname = fname.ToLower.Replace("(couche 2)", "").Trim
            fname = fname.ToLower.Replace("(sous-couche)", "").Trim

            If fname.ToLower.EndsWith(" met") Then
                MyMetArray.Add(formulas(i))
            Else
                If fname.ToLower.EndsWith(" mat") Then
                    MyMetArray.Add(formulas(i))
                Else
                    MyElseArray.Add(formulas(i))
                End If
            End If
        Next

        MyAllArray.AddRange(MyMetArray)
        MyAllArray.AddRange(MyElseArray)
        MyAllArray.AddRange(MyMatArray)
        formulas = DirectCast(MyAllArray.ToArray(GetType(Formula)), Formula())

        Return formulas
    End Function


    Public Function placeMetAndMat_old(ByVal formulas As Formula()) As Formula()
        Dim i As Integer
        Dim indexOfMet As Integer = -1
        For i = 0 To formulas.Length - 1
            Dim fname As String = formulas(i).name_formula
            fname = fname.ToLower.Replace("(couche)", "").Trim
            fname = fname.ToLower.Replace("(couche 1)", "").Trim
            fname = fname.ToLower.Replace("(couche 2)", "").Trim
            fname = fname.ToLower.Replace("(sous-couche)", "").Trim

            If fname.ToLower.EndsWith(" met") Then
                indexOfMet = i
                Exit For
            End If
        Next

        If indexOfMet > -1 Then
            ' put met first
            Dim MyArray As New ArrayList
            MyArray.Add(formulas(indexOfMet))
            For i = 0 To formulas.Length - 1
                If i <> indexOfMet Then
                    MyArray.Add(formulas(i))
                End If
            Next
            formulas = DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
        End If

        Dim indexOfMat As Integer = -1
        For i = 0 To formulas.Length - 1
            Dim fname As String = formulas(i).name_formula
            fname = fname.ToLower.Replace("(couche)", "").Trim
            fname = fname.ToLower.Replace("(couche 1)", "").Trim
            fname = fname.ToLower.Replace("(couche 2)", "").Trim
            fname = fname.ToLower.Replace("(sous-couche)", "").Trim

            If fname.ToLower.EndsWith(" mat") Then
                indexOfMat = i
                Exit For
            End If
        Next
        If indexOfMat > -1 Then
            ' put mat last
            Dim MyArray As New ArrayList

            For i = 0 To formulas.Length - 1
                If i <> indexOfMat Then
                    MyArray.Add(formulas(i))
                End If
            Next
            MyArray.Add(formulas(indexOfMat))
            formulas = DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
        End If
        Return formulas
    End Function
    Public Function isCouche(ByVal fname As String) As Boolean
        isCouche = False
        If fname.ToLower.Contains("(couche)") Then
            isCouche = True
        End If
        If fname.ToLower.Contains("(couche 1)") Then
            isCouche = True
        End If
        If fname.ToLower.Contains("(couche 2)") Then
            isCouche = True
        End If
        If fname.ToLower.Contains("(sous-couche)") Then
            isCouche = True
        End If
    End Function

    Public Function getCoucheIndex(ByVal formulaTab() As Formula, ByVal fname As String, ByVal coucheSubstring As String) As Integer
        Dim lacquer As String = ""
        If fname.ToLower.EndsWith("(+ lacquer)") Then
            coucheSubstring = coucheSubstring & "(+ lacquer)"
        Else
            If fname.ToLower.EndsWith("(+lqr)") Then
                coucheSubstring = coucheSubstring & "(+lqr)"
            Else
                If fname.ToLower.EndsWith("(+lacquer)") Then
                    coucheSubstring = coucheSubstring & "(+lacquer)"
                Else
                    If fname.ToLower.EndsWith("(+ lqr)") Then
                        coucheSubstring = coucheSubstring & "(+ lqr)"
                    Else
                        If fname.ToLower.EndsWith("(+ laquer)") Then
                            coucheSubstring = coucheSubstring & "(+ laquer)"
                        Else
                            If fname.ToLower.EndsWith("(+laquer)") Then
                                coucheSubstring = coucheSubstring & "(+laquer)"
                            End If
                        End If
                    End If
                End If
            End If
        End If


        getCoucheIndex = -1
        fname = fname.ToLower
        If fname.Contains("(couche)") Then
            fname = fname.Substring(0, fname.IndexOf("(couche)"))
        End If
        If fname.Contains("(couche 1)") Then
            fname = fname.Substring(0, fname.IndexOf("(couche 1)"))
        End If
        If fname.Contains("(couche 2)") Then
            fname = fname.Substring(0, fname.IndexOf("(couche 2)"))
        End If
        If fname.Contains("(sous-couche)") Then
            fname = fname.Substring(0, fname.IndexOf("(sous-couche)"))
        End If
        For k = 0 To formulaTab.Length - 1
            If Not formulaTab(k).isMoved Then
                If formulaTab(k).name_formula.ToLower.Trim.StartsWith(fname & coucheSubstring) Then
                    getCoucheIndex = k
                    Exit For
                Else
                    If formulaTab(k).name_formula.ToLower.Trim.StartsWith(fname & " " & coucheSubstring) Then
                        getCoucheIndex = k
                        Exit For
                    End If
                End If
            End If
        Next
    End Function
    Public Function filterTabNameDistinct(ByVal formulaTab() As Formula) As Formula()
        If formulaTab Is Nothing Or formulaTab.Length = 0 Then
            Return formulaTab
        End If
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To formulaTab.Length - 1
            If MyArray.Count = 0 Then
                MyArray.Add(formulaTab(i))
            Else
                Dim formulaTempTab() As Formula
                formulaTempTab = DirectCast(MyArray.ToArray(GetType(Formula)), Formula())

                Dim j As Integer
                Dim orredyExists As Boolean = False
                For j = 0 To formulaTempTab.Length - 1
                    If formulaTempTab(j).colorCode = formulaTab(i).colorCode Then
                        orredyExists = True
                        Exit For
                    End If
                Next

                If orredyExists = False Then
                    MyArray.Add(formulaTab(i))
                End If

            End If
        Next
        Return DirectCast(MyArray.ToArray(GetType(Formula)), Formula())

    End Function

    Public Function IsNumeric(ByVal str As String)
        Return Microsoft.VisualBasic.IsNumeric(str)
        'Return New Regex("\b\d+(\.\d+)?\b").Match(str).Success
    End Function



    Public Function hashStringWithSalt(password As String, salt As String) As String
        Dim convertedToBytes As Byte() = Encoding.UTF8.GetBytes(password & salt)
        Dim hashType As HashAlgorithm = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(convertedToBytes)
        Dim hashedResult As String = Convert.ToBase64String(hashBytes)
        Return hashedResult
    End Function



    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function
    Public Function encryptData(ByVal plaintext As String, ByVal encryptionKey As String) As String
        Dim result As String = ""
        Try
            TripleDes.Key = TruncateHash(encryptionKey, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)


            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte =
                System.Text.Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the encoder to write to the stream.
            Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()

            ' Convert the encrypted stream to a printable string.
            result = Convert.ToBase64String(ms.ToArray)
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function decryptData(ByVal encryptedtext As String, ByVal encryptionKey As String) As String
       
        printStringByLine("encryptedtext=" & encryptedtext & " - encryptionKey=" & encryptionKey)

       

        Dim result As String = ""
        Try
            TripleDes.Key = TruncateHash(encryptionKey, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)

            Dim tripleKey As String = ""
            For i = 0 To TripleDes.Key.Length - 1
                tripleKey = tripleKey & TripleDes.Key(i) & ","
            Next
            Dim tripleIV As String = ""
            For i = 0 To TripleDes.IV.Length - 1
                tripleIV = tripleIV & TripleDes.IV(i) & ","
            Next


            printStringByLine("TripleDes.Key=" & tripleKey)
            printStringByLine("TripleDes.IV=" & tripleIV)


            ' Convert the encrypted text string to a byte array.
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

            Dim encryptedBytesStr As String = ""
            For i = 0 To encryptedBytes.Length - 1
                encryptedBytesStr = encryptedBytesStr & encryptedBytes(i) & ","
            Next


            printStringByLine("encryptedBytes=" & encryptedBytesStr)



            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream.
            Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()

            Dim msArraystr As String = ""
            For i = 0 To ms.ToArray.Length - 1
                msArraystr = msArraystr & ms.ToArray(i) & ","
            Next


            printStringByLine("msArraystr=" & msArraystr)


            ' Convert the plaintext stream to a string.
            result = System.Text.Encoding.Unicode.GetString(ms.ToArray)
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Function encryptFormulaColor(ByVal formulaColor As FormulaColor) As FormulaColor
        If encryptionActive = 0 Then
            Return formulaColor
        End If

        Dim clearQuantity As String = formulaColor.quantite
        Dim encQuantity As String = encryptData(clearQuantity, password & chosenGarage.garage_name)
        formulaColor.quantite = encQuantity
        Return formulaColor
    End Function

    Public Function decryptFormulaColor(ByVal formulaColor As FormulaColor) As FormulaColor
        If encryptionActive = 0 Then
            Return formulaColor
        End If

        Dim encQuantity As String = formulaColor.quantite
        Dim clearQuantity As String = decryptData(encQuantity, password & formulaColor.id_formulaColor)
        formulaColor.quantite = clearQuantity
        Return formulaColor
    End Function

    Public Function encryptQuantity(ByVal clearQuantity As String, ByVal idFormulaColor As Integer) As String
        If encryptionActive = 0 Then
            Return clearQuantity
        End If

        Dim encQuantity As String = encryptData(clearQuantity, password & idFormulaColor)
        Return encQuantity
    End Function
    Public Sub printStringsByLine(ByVal stringsTab As String())
        If enableLoging Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("logFile.txt", True)

            For i = 0 To stringsTab.Length - 1
                file.WriteLine(stringsTab(i))
            Next

            file.Close()
        End If
    End Sub
    Public Sub printStringByLine(ByVal stringsTab As String)
        If enableLoging Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("logFile.txt", True)
            file.WriteLine(stringsTab)
            file.Close()
        End If
    End Sub
    Public Function decryptQuantity(ByVal encQuantity As String, ByVal idFormulaColor As Integer) As String
        printStringByLine("encQuantity=" & encQuantity)
        If encryptionActive = 0 Then
            Return encQuantity
        End If

        Dim clearQuantity As String = decryptData(encQuantity, password & idFormulaColor)


        printStringByLine("clearQuantity=" & clearQuantity)
        printStringByLine("----------------------------------------------------------------")


        Return clearQuantity
    End Function

End Module
