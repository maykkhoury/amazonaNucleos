Imports System.Xml
Imports System.IO
Imports System.Globalization
Imports System.Net

Module GlobalVariables
    Public languages() As Language
    Public units() As Unit
    Public colors() As AmazonaColor
    Public currencies() As Currency
    Public allFormulasNewDB() As Formula
    Public allFormulasOldDB() As Formula
    Public formulaColor() As FormulaColor
    Public curFormulas() As Formula
    Public curFamily() As Formula
    Public curSubFamily() As Formula
    Public labels() As AmazonaLabel
    Public chosenGarage As Garage
    Public chosenLanguage As Language
    Public chosenUnit As Unit
    Public chosenCurrency As Currency
    Public selectedFormulaColors() As FormulaColor
    Public ratio As Double
    Public idLangTranslate As Long
    Public imageToPreview As Image
    Public fromAddFormula As Boolean = False
    Public addDuplicate As Boolean = False
    Public variants(10) As FormulaVariants
    Public chosenFormula As Formula = Nothing
    Public chosenPrintTransaction As Transaction = Nothing
    Public chosenPrintFormula As Formula = Nothing
    Public chosenCar As Car = Nothing
    Public allFormulaColors() As FormulaColor
    Public allFormulaColorsClient() As FormulaColor
    Public myConsoleLog As StreamWriter
    Public encryptionActive As Integer = 1
    Public ciClone As CultureInfo
    Public enableLoging As Boolean = False
    Public ftp_garageupload_uri As String = "FTP://ftp.amazonapaints.com/"
    Public ftp_garageupload_username As String = "amazona002_mk@amazonapaints.com"
    Public ftp_garageupload_password As String = "k<Yd*C$.2"
#Region "Application start"

    Public Sub downloadFileFTP_mobile(ByVal filenameToDownload As String, ByVal downloadTargetFolder As String)
        downloadFileFTP(filenameToDownload, ftp_garageupload_uri, ftp_garageupload_username,
                                                 ftp_garageupload_password, downloadTargetFolder)
    End Sub

    Private Sub downloadFileFTP(ByVal filenameToDownload As String, ByVal ftpuri As String,
                             ByVal ftpusername As String, ByVal ftppassword As String, ByVal downloadTargetFolder As String)

        Try
            Dim sFtpFile As String = ftp_garageupload_uri & filenameToDownload

            Dim sTargetFileName = System.IO.Path.GetFileName(sFtpFile)
            sTargetFileName = sTargetFileName.Replace("/", "\")
            sTargetFileName = downloadTargetFolder & sTargetFileName

            My.Computer.Network.DownloadFile(sFtpFile, sTargetFileName, ftpusername, ftppassword)

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

    End Sub

    Public Function fileExists_desktop(ByVal filenameToDownload As String) As Boolean
        fileExists_desktop = fileExists(filenameToDownload, ftp_garageupload_uri, ftp_garageupload_username, ftp_garageupload_password)
    End Function

    Private Function fileExists(ByVal filenameToDownload As String, ByVal ftpuri As String,
                           ByVal ftpusername As String, ByVal ftppassword As String) As Boolean
        fileExists = True
        ' Create a web request that will be used to talk with the server and set the request method to upload a file by ftp.
        Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(ftpuri & filenameToDownload), FtpWebRequest)

        Try
            'ftpRequest.UsePassive = False
            ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize

            ' Confirm the Network credentials based on the user name and password passed in.
            ftpRequest.Credentials = New NetworkCredential(ftpusername, ftppassword)

            Dim response As FtpWebResponse = DirectCast(ftpRequest.GetResponse(), FtpWebResponse)
            Dim fileSize As Long = response.ContentLength
        Catch ex As Exception
            'ExceptionInfo = ex
            Dim webex As WebException = CType(ex, WebException)
            Dim ftpRes As FtpWebResponse = CType(webex.Response, FtpWebResponse)
            Dim status As String = ftpRes.StatusDescription
            'MsgBox("Please make sure you have an internet connection and that you have entered the correct code!", MsgBoxStyle.Exclamation)
            fileExists = Nothing
            Exit Function
        End Try
    End Function
    Public Function getFormulaColorsClone() As FormulaColor()
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulaColors.Length - 1
            Dim formulaColorIt = New FormulaColor
            formulaColorIt.id_color = allFormulaColors(i).id_color
            formulaColorIt.id_formula = allFormulaColors(i).id_formula
            formulaColorIt.id_formulaColor = allFormulaColors(i).id_formulaColor
            formulaColorIt.id_Unit = allFormulaColors(i).id_Unit
            formulaColorIt.quantite = allFormulaColors(i).quantite
            MyArray.Add(formulaColorIt)

        Next
        Dim formulaColorTab() As FormulaColor = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        Return formulaColorTab
    End Function
    Public Function getFormulaColorsClientClone() As FormulaColor()
        Dim MyArray As New ArrayList
        Dim i As Integer
        For i = 0 To allFormulaColorsClient.Length - 1
            Dim formulaColorIt = New FormulaColor
            formulaColorIt.id_color = allFormulaColorsClient(i).id_color
            formulaColorIt.id_formula = allFormulaColorsClient(i).id_formula
            formulaColorIt.id_formulaColor = allFormulaColorsClient(i).id_formulaColor
            formulaColorIt.id_Unit = allFormulaColorsClient(i).id_Unit
            formulaColorIt.quantite = allFormulaColorsClient(i).quantite
            MyArray.Add(formulaColorIt)

        Next
        Dim formulaColorTab() As FormulaColor = DirectCast(MyArray.ToArray(GetType(FormulaColor)), FormulaColor())
        Return formulaColorTab
    End Function

    Public Function getFormulasClone() As Formula()

        Dim MyArray As New ArrayList

        Dim c As Integer
        For c = 0 To allFormulasNewDB.Length - 1
            Dim formula As New Formula
            formula.id_formula = allFormulasNewDB(c).id_formula
            formula.formulaImgPath = allFormulasNewDB(c).formulaImgPath
            formula.otherPrice = allFormulasNewDB(c).otherPrice
            formula.id_otherCurreny = allFormulasNewDB(c).id_otherCurreny
            formula.id_otherUnit = allFormulasNewDB(c).id_otherUnit
            formula.id_car = allFormulasNewDB(c).id_car
            formula.name_car = allFormulasNewDB(c).name_car
            formula.type = allFormulasNewDB(c).type
            formula.version = allFormulasNewDB(c).version
            formula.name_formula = allFormulasNewDB(c).name_formula
            formula.formulaVariant = allFormulasNewDB(c).formulaVariant
            formula.duplicate = allFormulasNewDB(c).duplicate
            formula.colorRGB = allFormulasNewDB(c).colorRGB
            formula.c_year = allFormulasNewDB(c).c_year
            formula.colorCode = allFormulasNewDB(c).colorCode
            formula.clientName = allFormulasNewDB(c).clientName
            formula.oldDb = allFormulasNewDB(c).oldDb
            formula.id_formulaX = allFormulasNewDB(c).id_formulaX
            formula.id_formulaXp = allFormulasNewDB(c).id_formulaXp
            formula.id_formulaX2p = allFormulasNewDB(c).id_formulaX2p
            formula.id_formulaY = allFormulasNewDB(c).id_formulaY
            formula.id_formulaYp = allFormulasNewDB(c).id_formulaYp
            formula.id_formulaY2p = allFormulasNewDB(c).id_formulaY2p
            formula.id_formulaZ = allFormulasNewDB(c).id_formulaZ
            formula.id_formulaZp = allFormulasNewDB(c).id_formulaZp
            formula.id_formulaZ2p = allFormulasNewDB(c).id_formulaZ2p
            formula.cardNumber = allFormulasNewDB(c).cardNumber
            formula.isMoved = allFormulasNewDB(c).isMoved
            formula.dateCreMod = allFormulasNewDB(c).dateCreMod
            MyArray.Add(formula)

        Next
        Dim formulaTab() As Formula = DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
        Return formulaTab
    End Function


    Public Sub setVariables()
        ciClone = CType(CultureInfo.InvariantCulture.Clone(), CultureInfo)
        ciClone.NumberFormat.NumberDecimalSeparator = "."


        Dim logActive As String
        Try
            logActive = My.Computer.FileSystem.ReadAllText("logActive.txt", System.Text.Encoding.UTF8)
            If logActive = "true" Then
                enableLoging = True
            End If
        Catch ex As Exception
            enableLoging = False
        End Try


        SplashScreen.lbInfosLoading.Text = "Setting languages"
        languages = getLanguages()

        SplashScreen.lbInfosLoading.Text = "Setting units"
        units = getUnits()

        SplashScreen.lbInfosLoading.Text = "Setting currencies"
        currencies = getCurrencies()

        SplashScreen.lbInfosLoading.Text = "Setting labels"
        labels = getLabels()

        chosenGarage = getChosenGarage()

        SplashScreen.lbInfosLoading.Text = "Setting colors"
        colors = getColors() 'uses chosenGarage
        If Not chosenGarage Is Nothing Then
            chosenLanguage = getLanguage(chosenGarage.id_language)
        End If
        If Not units Is Nothing And chosenUnit Is Nothing Then
            chosenUnit = getChosenUnit()
        End If
        If Not currencies Is Nothing And chosenCurrency Is Nothing Then
            chosenCurrency = getChosenCurreny()
        End If

        SplashScreen.lbInfosLoading.Text = "Setting variants"
        setVariants()

        SplashScreen.lbInfosLoading.Text = "Load completed"
        myConsoleLog = New StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory() & "//consoleOut.log")

    End Sub

    Public Sub readXml()
        Dim oldDb As Boolean = False
        Dim startTime As DateTime
        Dim endTime As DateTime

        Dim formulacount As Integer = 0
        Dim settings As New XmlReaderSettings()
        settings.IgnoreComments = True
        Dim Countryfile As String = Path.Combine("D:\paintshop\PaintShopApplication(800-600) - optimization tests\PaintShopApplication\bin\Release", "formula.xml")
        startTime = Now
        Dim MyArray As New ArrayList
        Dim newFormula As Formula = Nothing
        Using reader As XmlReader = XmlReader.Create(Countryfile, settings)
            While (reader.Read())
                If (reader.NodeType = XmlNodeType.Element And "formula" = reader.LocalName) Then
                    'starting new formula so add the previous one and reinitialize
                    If Not newFormula Is Nothing Then 'first iteration
                        MyArray.Add(newFormula)
                        formulacount += 1
                    End If
                    newFormula = New Formula
                End If

                ' Dim reader As XmlReader = reader.ReadSubtree
                'While (reader.Read())
                If (reader.NodeType = XmlNodeType.Element And "type" = reader.LocalName) Then
                    newFormula.type = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formula" = reader.LocalName) Then
                    newFormula.id_formula = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "formulaImgPath" = reader.LocalName) Then
                    newFormula.formulaImgPath = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "otherPrice" = reader.LocalName) Then
                    newFormula.otherPrice = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_otherCurreny" = reader.LocalName) Then
                    newFormula.id_otherCurreny = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_otherUnit" = reader.LocalName) Then
                    newFormula.id_otherUnit = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_car" = reader.LocalName) Then
                    newFormula.id_car = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "name_car" = reader.LocalName) Then
                    newFormula.name_car = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "name_formula" = reader.LocalName) Then
                    newFormula.name_formula = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "version" = reader.LocalName) Then
                    newFormula.version = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "variant" = reader.LocalName) Then
                    newFormula.formulaVariant = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "duplicate" = reader.LocalName) Then
                    newFormula.duplicate = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "colorCode" = reader.LocalName) Then
                    newFormula.colorCode = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "colorRGB" = reader.LocalName) Then
                    newFormula.colorRGB = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "c_year" = reader.LocalName) Then
                    newFormula.c_year = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "clientName" = reader.LocalName) Then
                    newFormula.clientName = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaX" = reader.LocalName) Then
                    newFormula.id_formulaX = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaXp" = reader.LocalName) Then
                    newFormula.id_formulaXp = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaX2p" = reader.LocalName) Then
                    newFormula.id_formulaX2p = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaY" = reader.LocalName) Then
                    newFormula.id_formulaY = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaYp" = reader.LocalName) Then
                    newFormula.id_formulaYp = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaY2p" = reader.LocalName) Then
                    newFormula.id_formulaY2p = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaZ" = reader.LocalName) Then
                    newFormula.id_formulaZ = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaZp" = reader.LocalName) Then
                    newFormula.id_formulaZp = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "id_formulaZ2p" = reader.LocalName) Then
                    newFormula.id_formulaZ2p = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "cardNumber" = reader.LocalName) Then
                    newFormula.cardNumber = reader.ReadString
                End If
                If (reader.NodeType = XmlNodeType.Element And "date_cre_mod" = reader.LocalName) Then
                    Dim dateCreModStr As String = reader.ReadString
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
                'End While
                ' End If
            End While
            Dim formulaTab() As Formula = DirectCast(MyArray.ToArray(GetType(Formula)), Formula())
        End Using
        endTime = Now
        Dim duration As TimeSpan = endTime - startTime
        myConsoleLog.WriteLine("reading xml wihout filling beans:" & duration.ToString & " count=" & formulacount)
    End Sub
    Private Sub setVariants()

        variants(0) = New FormulaVariants
        variants(0).variantName = "D"
        variants(0).variantColor = Drawing.Color.Black
        variants(0).variantDescription = "Darker"

        Dim imageD As Image
        Dim imgPathD As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantD.jpg"
        imageD = Image.FromFile(imgPathD)
        variants(0).variantImage = imageD

        variants(1) = New FormulaVariants
        variants(1).variantName = "F"
        variants(1).variantColor = Drawing.Color.Fuchsia
        variants(1).variantDescription = "Finer"
        Dim imageF As Image
        Dim imgPathF As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantF.jpg"
        imageF = Image.FromFile(imgPathF)
        variants(1).variantImage = imageF

        variants(2) = New FormulaVariants
        variants(2).variantName = "DRT"
        variants(2).variantColor = Drawing.Color.DarkTurquoise
        variants(2).variantDescription = "Dirtier"
        Dim imageDRT As Image
        Dim imgPathDRT As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantDRT.jpg"
        imageDRT = Image.FromFile(imgPathDRT)
        variants(2).variantImage = imageDRT

        variants(3) = New FormulaVariants
        variants(3).variantName = "L"
        variants(3).variantColor = Drawing.Color.Lime
        variants(3).variantDescription = "Lighter"
        Dim imageL As Image
        Dim imgPathL As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantL.jpg"
        imageL = Image.FromFile(imgPathL)
        variants(3).variantImage = imageL

        variants(4) = New FormulaVariants
        variants(4).variantName = "R"
        variants(4).variantColor = Drawing.Color.Red
        variants(4).variantDescription = "Red"
        Dim imageR As Image
        Dim imgPathR As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantR.jpg"
        imageR = Image.FromFile(imgPathR)
        variants(4).variantImage = imageR

        variants(5) = New FormulaVariants
        variants(5).variantName = "Y"
        variants(5).variantColor = Drawing.Color.Yellow
        variants(5).variantDescription = "Yellow"
        Dim imageY As Image
        Dim imgPathY As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantY.jpg"
        imageY = Image.FromFile(imgPathY)
        variants(5).variantImage = imageY

        variants(6) = New FormulaVariants
        variants(6).variantName = "B"
        variants(6).variantColor = Drawing.Color.Blue
        variants(6).variantDescription = "Blue"
        Dim imageB As Image
        Dim imgPathB As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantB.jpg"
        imageB = Image.FromFile(imgPathB)
        variants(6).variantImage = imageB

        variants(7) = New FormulaVariants
        variants(7).variantName = "CO"
        variants(7).variantColor = Drawing.Color.Coral
        variants(7).variantDescription = "Coarser"
        Dim imageCO As Image
        Dim imgPathCO As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantCO.jpg"
        imageCO = Image.FromFile(imgPathCO)
        variants(7).variantImage = imageCO

        variants(8) = New FormulaVariants
        variants(8).variantName = "G"
        variants(8).variantColor = Drawing.Color.Green
        variants(8).variantDescription = "Green"
        Dim imageG As Image
        Dim imgPathG As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantG.jpg"
        imageG = Image.FromFile(imgPathG)
        variants(8).variantImage = imageG

        variants(9) = New FormulaVariants
        variants(9).variantName = "CL"
        variants(9).variantColor = Drawing.Color.Chocolate
        variants(9).variantDescription = "Cleaner"
        Dim imageCL As Image
        Dim imgPathCL As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//variants//variantCL.jpg"
        imageCL = Image.FromFile(imgPathCL)
        variants(9).variantImage = imageCL

    End Sub
#End Region

    Public Function getGaragePriceDetail(ByVal idColor) As GaragePrice
        Dim whereStr As String = " WHERE id_color=" & idColor
        Dim tab As GaragePrice() = getGaragePricesDB(whereStr)
        If tab Is Nothing Then
            Return Nothing
        End If
        If tab.Length = 0 Then
            Return Nothing
        End If

        Return tab(0)
    End Function
    Public Function getGaragePrices(ByVal id) As GaragePrice
        Dim whereStr As String = " WHERE id_color=" & id

        getGaragePrices = getGaragePricesDB(whereStr)(0)

    End Function

    Public Function getLanguage(ByVal id) As Language
        Dim whereStr As String = " WHERE id_language=" & id

        getLanguage = getLanguages(whereStr)(0)

    End Function

    Public Function getCurrency(ByVal id As Integer) As Currency
        Dim i As Integer
        For i = 0 To currencies.Length - 1
            If currencies(i).id_currency = id Then
                getCurrency = currencies(i)
                Exit For
            End If
        Next i
    End Function

    Public Function getUnit(ByVal id) As Unit
        Dim i As Integer
        For i = 0 To units.Length - 1
            If units(i).id_unit = id Then
                getUnit = units(i)
                Exit For
            End If
        Next i
    End Function


    Public Function getFormulaById(ByVal id, ByVal oldDb, ByVal clientTable, ByVal carTableName, ByVal carName, ByVal idCar) As Formula

        Dim whereStr As String = " AND id_formula=" & id


        Dim formulaTab() As Formula
        If clientTable Then
            formulaTab = getClientFormulasOnly(whereStr, oldDb)
        Else
            formulaTab = getFormulas(whereStr, carTableName, carName, idCar)
        End If
        Dim formula As Formula = Nothing

        If Not formulaTab Is Nothing Then
            If formulaTab.Length > 0 Then
                formula = formulaTab(0)
            End If
        End If

        Return formula



    End Function


    Public Function getLanguageById(ByVal id) As Language

        Dim whereStr As String = " WHERE id_language=" & id

        getLanguageById = getLanguages(whereStr)(0)

    End Function


    Public Function filterTabNameDistinct(ByVal formulaTab() As Formula) As Formula()
        If formulaTab Is Nothing Then
            Return formulaTab
        End If
        If formulaTab.Length = 0 Then
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

End Module
