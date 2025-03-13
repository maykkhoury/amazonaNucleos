<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class garageHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(garageHome))
        Me.openfile = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menFile = New garageApp.MyMenuStrip()
        Me.NucleosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetLatestDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorLocatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportPricesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menUpdate = New garageApp.MyMenuStrip()
        Me.BackupCustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menEditColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.menExit = New garageApp.MyMenuStrip()
        Me.menSettings = New garageApp.MyMenuStrip()
        Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpFormulas = New garageApp.MyGroupBox()
        Me.lbAllCarsMode = New garageApp.TranslatedLabel()
        Me.chkAllCars = New garageApp.MyCheckBox()
        Me.lbDownloading = New System.Windows.Forms.Label()
        Me.prgUpdate = New System.Windows.Forms.ProgressBar()
        Me.cmbCarNameSearch = New System.Windows.Forms.ComboBox()
        Me.txtColorCode = New garageApp.MyTextBox()
        Me.chkColorCode = New garageApp.MyCheckBox()
        Me.lbColorCode = New garageApp.TranslatedLabel()
        Me.lbCarIdSearch = New System.Windows.Forms.Label()
        Me.lbCarSearch = New garageApp.TranslatedLabel()
        Me.butClearUpdate = New System.Windows.Forms.Button()
        Me.chkCardNumber = New garageApp.MyCheckBox()
        Me.txtCardNumber = New garageApp.MyTextBox()
        Me.lbCardNumber = New garageApp.TranslatedLabel()
        Me.txtYearSpec = New garageApp.MyTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbClientName = New System.Windows.Forms.ComboBox()
        Me.chkUseOldDb = New garageApp.MyCheckBox()
        Me.butExit = New garageApp.MyButton()
        Me.lbClient = New garageApp.TranslatedLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbCurrencyDetailsValue = New System.Windows.Forms.Label()
        Me.lbCurrencyDetails = New System.Windows.Forms.Label()
        Me.lbUnitMesureValue = New System.Windows.Forms.Label()
        Me.lbUnitMesure = New System.Windows.Forms.Label()
        Me.txtYearMax = New garageApp.MyTextBox()
        Me.txtYearMin = New garageApp.MyTextBox()
        Me.lbYear = New garageApp.TranslatedLabel()
        Me.lsvFamily = New garageApp.MyListView()
        Me.cformulaId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.db = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cctype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ccode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ccname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cyear = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cversion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ccardNbr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ccarid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ccarname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cclient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cvariant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New garageApp.MyGroupBox()
        Me.rdAny = New garageApp.MyRadioButton()
        Me.rdBC = New garageApp.MyRadioButton()
        Me.rd2k_LS = New garageApp.MyRadioButton()
        Me.chkFormulaName = New garageApp.MyCheckBox()
        Me.txtFormulaName = New garageApp.MyTextBox()
        Me.lbFormulaName = New garageApp.TranslatedLabel()
        Me.butGo = New garageApp.MyButton()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.FBrowserGarage = New System.Windows.Forms.FolderBrowserDialog()
        Me.fileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpFormulas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'openfile
        '
        Me.openfile.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menFile, Me.menSettings})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1051, 26)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menFile
        '
        Me.menFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NucleosToolStripMenuItem, Me.GetLatestDataToolStripMenuItem, Me.ColorLocatorToolStripMenuItem, Me.ImportPricesToolStripMenuItem, Me.menUpdate, Me.BackupCustomersToolStripMenuItem, Me.RestoreBackupToolStripMenuItem, Me.menEditColor, Me.menExit})
        Me.menFile.Name = "menFile"
        Me.menFile.Size = New System.Drawing.Size(50, 22)
        Me.menFile.Text = "&File"
        '
        'NucleosToolStripMenuItem
        '
        Me.NucleosToolStripMenuItem.Name = "NucleosToolStripMenuItem"
        Me.NucleosToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.NucleosToolStripMenuItem.Text = "&Nucleos"
        '
        'GetLatestDataToolStripMenuItem
        '
        Me.GetLatestDataToolStripMenuItem.Name = "GetLatestDataToolStripMenuItem"
        Me.GetLatestDataToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.GetLatestDataToolStripMenuItem.Text = "Get &Latest Data"
        '
        'ColorLocatorToolStripMenuItem
        '
        Me.ColorLocatorToolStripMenuItem.Name = "ColorLocatorToolStripMenuItem"
        Me.ColorLocatorToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.ColorLocatorToolStripMenuItem.Text = "&Color locator"
        '
        'ImportPricesToolStripMenuItem
        '
        Me.ImportPricesToolStripMenuItem.Name = "ImportPricesToolStripMenuItem"
        Me.ImportPricesToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.ImportPricesToolStripMenuItem.Text = "&Import prices"
        '
        'menUpdate
        '
        Me.menUpdate.Name = "menUpdate"
        Me.menUpdate.Size = New System.Drawing.Size(225, 26)
        Me.menUpdate.Text = "&Update"
        '
        'BackupCustomersToolStripMenuItem
        '
        Me.BackupCustomersToolStripMenuItem.Name = "BackupCustomersToolStripMenuItem"
        Me.BackupCustomersToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.BackupCustomersToolStripMenuItem.Text = "&Backup customers"
        '
        'RestoreBackupToolStripMenuItem
        '
        Me.RestoreBackupToolStripMenuItem.Name = "RestoreBackupToolStripMenuItem"
        Me.RestoreBackupToolStripMenuItem.Size = New System.Drawing.Size(225, 26)
        Me.RestoreBackupToolStripMenuItem.Text = "&Restore backup"
        '
        'menEditColor
        '
        Me.menEditColor.Name = "menEditColor"
        Me.menEditColor.Size = New System.Drawing.Size(225, 26)
        Me.menEditColor.Text = "E&dit Price"
        '
        'menExit
        '
        Me.menExit.Name = "menExit"
        Me.menExit.Size = New System.Drawing.Size(225, 26)
        Me.menExit.Text = "&Exit"
        '
        'menSettings
        '
        Me.menSettings.Name = "menSettings"
        Me.menSettings.Size = New System.Drawing.Size(84, 22)
        Me.menSettings.Text = "&Settings"
        '
        'dlgPrintPreview
        '
        Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview.Enabled = True
        Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview.Name = "dlgPrintPreview"
        Me.dlgPrintPreview.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grpFormulas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1051, 666)
        Me.Panel1.TabIndex = 63
        '
        'grpFormulas
        '
        Me.grpFormulas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFormulas.BackColor = System.Drawing.Color.Transparent
        Me.grpFormulas.Controls.Add(Me.lbAllCarsMode)
        Me.grpFormulas.Controls.Add(Me.chkAllCars)
        Me.grpFormulas.Controls.Add(Me.lbDownloading)
        Me.grpFormulas.Controls.Add(Me.prgUpdate)
        Me.grpFormulas.Controls.Add(Me.cmbCarNameSearch)
        Me.grpFormulas.Controls.Add(Me.txtColorCode)
        Me.grpFormulas.Controls.Add(Me.chkColorCode)
        Me.grpFormulas.Controls.Add(Me.lbColorCode)
        Me.grpFormulas.Controls.Add(Me.lbCarIdSearch)
        Me.grpFormulas.Controls.Add(Me.lbCarSearch)
        Me.grpFormulas.Controls.Add(Me.butClearUpdate)
        Me.grpFormulas.Controls.Add(Me.chkCardNumber)
        Me.grpFormulas.Controls.Add(Me.txtCardNumber)
        Me.grpFormulas.Controls.Add(Me.lbCardNumber)
        Me.grpFormulas.Controls.Add(Me.txtYearSpec)
        Me.grpFormulas.Controls.Add(Me.Label15)
        Me.grpFormulas.Controls.Add(Me.cmbClientName)
        Me.grpFormulas.Controls.Add(Me.chkUseOldDb)
        Me.grpFormulas.Controls.Add(Me.butExit)
        Me.grpFormulas.Controls.Add(Me.lbClient)
        Me.grpFormulas.Controls.Add(Me.Label1)
        Me.grpFormulas.Controls.Add(Me.lbCurrencyDetailsValue)
        Me.grpFormulas.Controls.Add(Me.lbCurrencyDetails)
        Me.grpFormulas.Controls.Add(Me.lbUnitMesureValue)
        Me.grpFormulas.Controls.Add(Me.lbUnitMesure)
        Me.grpFormulas.Controls.Add(Me.txtYearMax)
        Me.grpFormulas.Controls.Add(Me.txtYearMin)
        Me.grpFormulas.Controls.Add(Me.lbYear)
        Me.grpFormulas.Controls.Add(Me.lsvFamily)
        Me.grpFormulas.Controls.Add(Me.GroupBox1)
        Me.grpFormulas.Controls.Add(Me.chkFormulaName)
        Me.grpFormulas.Controls.Add(Me.txtFormulaName)
        Me.grpFormulas.Controls.Add(Me.lbFormulaName)
        Me.grpFormulas.Controls.Add(Me.butGo)
        Me.grpFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFormulas.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpFormulas.Location = New System.Drawing.Point(0, 0)
        Me.grpFormulas.Margin = New System.Windows.Forms.Padding(4)
        Me.grpFormulas.Name = "grpFormulas"
        Me.grpFormulas.Padding = New System.Windows.Forms.Padding(4)
        Me.grpFormulas.Size = New System.Drawing.Size(1051, 666)
        Me.grpFormulas.TabIndex = 54
        Me.grpFormulas.TabStop = False
        Me.grpFormulas.Text = "Formulas"
        '
        'lbAllCarsMode
        '
        Me.lbAllCarsMode.AutoSize = True
        Me.lbAllCarsMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAllCarsMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbAllCarsMode.Location = New System.Drawing.Point(164, 27)
        Me.lbAllCarsMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbAllCarsMode.Name = "lbAllCarsMode"
        Me.lbAllCarsMode.Size = New System.Drawing.Size(244, 39)
        Me.lbAllCarsMode.TabIndex = 176
        Me.lbAllCarsMode.Text = "All Cars Mode"
        Me.lbAllCarsMode.Visible = False
        '
        'chkAllCars
        '
        Me.chkAllCars.AutoSize = True
        Me.chkAllCars.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllCars.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAllCars.Location = New System.Drawing.Point(168, 87)
        Me.chkAllCars.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAllCars.Name = "chkAllCars"
        Me.chkAllCars.Size = New System.Drawing.Size(160, 21)
        Me.chkAllCars.TabIndex = 175
        Me.chkAllCars.Tag = ""
        Me.chkAllCars.Text = "Search In All Cars"
        Me.chkAllCars.UseVisualStyleBackColor = True
        '
        'lbDownloading
        '
        Me.lbDownloading.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDownloading.AutoSize = True
        Me.lbDownloading.Location = New System.Drawing.Point(611, 293)
        Me.lbDownloading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDownloading.Name = "lbDownloading"
        Me.lbDownloading.Size = New System.Drawing.Size(324, 20)
        Me.lbDownloading.TabIndex = 174
        Me.lbDownloading.Text = "Downloading new data, please wait ..."
        Me.lbDownloading.Visible = False
        '
        'prgUpdate
        '
        Me.prgUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgUpdate.Location = New System.Drawing.Point(16, 632)
        Me.prgUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.prgUpdate.Name = "prgUpdate"
        Me.prgUpdate.Size = New System.Drawing.Size(872, 28)
        Me.prgUpdate.TabIndex = 173
        '
        'cmbCarNameSearch
        '
        Me.cmbCarNameSearch.DropDownHeight = 400
        Me.cmbCarNameSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarNameSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCarNameSearch.FormattingEnabled = True
        Me.cmbCarNameSearch.IntegralHeight = False
        Me.cmbCarNameSearch.Location = New System.Drawing.Point(168, 30)
        Me.cmbCarNameSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbCarNameSearch.Name = "cmbCarNameSearch"
        Me.cmbCarNameSearch.Size = New System.Drawing.Size(349, 40)
        Me.cmbCarNameSearch.TabIndex = 168
        '
        'txtColorCode
        '
        Me.txtColorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColorCode.Location = New System.Drawing.Point(168, 133)
        Me.txtColorCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtColorCode.Name = "txtColorCode"
        Me.txtColorCode.Size = New System.Drawing.Size(195, 40)
        Me.txtColorCode.TabIndex = 167
        '
        'chkColorCode
        '
        Me.chkColorCode.AutoSize = True
        Me.chkColorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColorCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkColorCode.Location = New System.Drawing.Point(372, 138)
        Me.chkColorCode.Margin = New System.Windows.Forms.Padding(4)
        Me.chkColorCode.Name = "chkColorCode"
        Me.chkColorCode.Size = New System.Drawing.Size(93, 21)
        Me.chkColorCode.TabIndex = 169
        Me.chkColorCode.Tag = ""
        Me.chkColorCode.Text = "Contains"
        Me.chkColorCode.UseVisualStyleBackColor = True
        '
        'lbColorCode
        '
        Me.lbColorCode.AutoSize = True
        Me.lbColorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbColorCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbColorCode.Location = New System.Drawing.Point(25, 151)
        Me.lbColorCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbColorCode.Name = "lbColorCode"
        Me.lbColorCode.Size = New System.Drawing.Size(109, 20)
        Me.lbColorCode.TabIndex = 170
        Me.lbColorCode.Text = "Color Code:"
        '
        'lbCarIdSearch
        '
        Me.lbCarIdSearch.AutoSize = True
        Me.lbCarIdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCarIdSearch.Location = New System.Drawing.Point(120, 37)
        Me.lbCarIdSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCarIdSearch.Name = "lbCarIdSearch"
        Me.lbCarIdSearch.Size = New System.Drawing.Size(26, 20)
        Me.lbCarIdSearch.TabIndex = 171
        Me.lbCarIdSearch.Text = "-1"
        Me.lbCarIdSearch.Visible = False
        '
        'lbCarSearch
        '
        Me.lbCarSearch.AutoSize = True
        Me.lbCarSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCarSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCarSearch.Location = New System.Drawing.Point(25, 33)
        Me.lbCarSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCarSearch.Name = "lbCarSearch"
        Me.lbCarSearch.Size = New System.Drawing.Size(45, 20)
        Me.lbCarSearch.TabIndex = 172
        Me.lbCarSearch.Text = "Car:"
        '
        'butClearUpdate
        '
        Me.butClearUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.butClearUpdate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butClearUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butClearUpdate.Location = New System.Drawing.Point(528, 135)
        Me.butClearUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.butClearUpdate.Name = "butClearUpdate"
        Me.butClearUpdate.Size = New System.Drawing.Size(132, 47)
        Me.butClearUpdate.TabIndex = 166
        Me.butClearUpdate.Text = "Clear"
        Me.butClearUpdate.UseVisualStyleBackColor = False
        '
        'chkCardNumber
        '
        Me.chkCardNumber.AutoSize = True
        Me.chkCardNumber.Checked = True
        Me.chkCardNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCardNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCardNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCardNumber.Location = New System.Drawing.Point(372, 220)
        Me.chkCardNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCardNumber.Name = "chkCardNumber"
        Me.chkCardNumber.Size = New System.Drawing.Size(93, 21)
        Me.chkCardNumber.TabIndex = 165
        Me.chkCardNumber.Text = "Contains"
        Me.chkCardNumber.UseVisualStyleBackColor = True
        '
        'txtCardNumber
        '
        Me.txtCardNumber.Location = New System.Drawing.Point(168, 217)
        Me.txtCardNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.Size = New System.Drawing.Size(195, 26)
        Me.txtCardNumber.TabIndex = 163
        '
        'lbCardNumber
        '
        Me.lbCardNumber.AutoSize = True
        Me.lbCardNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCardNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCardNumber.Location = New System.Drawing.Point(21, 217)
        Me.lbCardNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCardNumber.Name = "lbCardNumber"
        Me.lbCardNumber.Size = New System.Drawing.Size(110, 18)
        Me.lbCardNumber.TabIndex = 164
        Me.lbCardNumber.Text = "Card number:"
        '
        'txtYearSpec
        '
        Me.txtYearSpec.Location = New System.Drawing.Point(168, 250)
        Me.txtYearSpec.Margin = New System.Windows.Forms.Padding(4)
        Me.txtYearSpec.Name = "txtYearSpec"
        Me.txtYearSpec.Size = New System.Drawing.Size(195, 26)
        Me.txtYearSpec.TabIndex = 160
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(643, 231)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 20)
        Me.Label15.TabIndex = 159
        Me.Label15.Text = "Specific:"
        Me.Label15.Visible = False
        '
        'cmbClientName
        '
        Me.cmbClientName.FormattingEnabled = True
        Me.cmbClientName.Location = New System.Drawing.Point(168, 283)
        Me.cmbClientName.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbClientName.Name = "cmbClientName"
        Me.cmbClientName.Size = New System.Drawing.Size(195, 28)
        Me.cmbClientName.TabIndex = 158
        '
        'chkUseOldDb
        '
        Me.chkUseOldDb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkUseOldDb.AutoSize = True
        Me.chkUseOldDb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseOldDb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkUseOldDb.Location = New System.Drawing.Point(863, 111)
        Me.chkUseOldDb.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUseOldDb.Name = "chkUseOldDb"
        Me.chkUseOldDb.Size = New System.Drawing.Size(173, 21)
        Me.chkUseOldDb.TabIndex = 157
        Me.chkUseOldDb.Tag = ""
        Me.chkUseOldDb.Text = "Use Original DB123"
        Me.chkUseOldDb.UseVisualStyleBackColor = True
        Me.chkUseOldDb.Visible = False
        '
        'butExit
        '
        Me.butExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butExit.BackColor = System.Drawing.SystemColors.Control
        Me.butExit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butExit.Location = New System.Drawing.Point(903, 632)
        Me.butExit.Margin = New System.Windows.Forms.Padding(4)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(132, 28)
        Me.butExit.TabIndex = 156
        Me.butExit.Text = "Exit"
        Me.butExit.UseVisualStyleBackColor = False
        '
        'lbClient
        '
        Me.lbClient.AutoSize = True
        Me.lbClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbClient.Location = New System.Drawing.Point(21, 286)
        Me.lbClient.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(102, 18)
        Me.lbClient.TabIndex = 153
        Me.lbClient.Text = "Client name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(543, 235)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 20)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "-"
        Me.Label1.Visible = False
        '
        'lbCurrencyDetailsValue
        '
        Me.lbCurrencyDetailsValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCurrencyDetailsValue.AutoSize = True
        Me.lbCurrencyDetailsValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCurrencyDetailsValue.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbCurrencyDetailsValue.Location = New System.Drawing.Point(912, 59)
        Me.lbCurrencyDetailsValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCurrencyDetailsValue.Name = "lbCurrencyDetailsValue"
        Me.lbCurrencyDetailsValue.Size = New System.Drawing.Size(25, 18)
        Me.lbCurrencyDetailsValue.TabIndex = 151
        Me.lbCurrencyDetailsValue.Text = "- -"
        '
        'lbCurrencyDetails
        '
        Me.lbCurrencyDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCurrencyDetails.AutoSize = True
        Me.lbCurrencyDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCurrencyDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCurrencyDetails.Location = New System.Drawing.Point(815, 59)
        Me.lbCurrencyDetails.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCurrencyDetails.Name = "lbCurrencyDetails"
        Me.lbCurrencyDetails.Size = New System.Drawing.Size(81, 18)
        Me.lbCurrencyDetails.TabIndex = 150
        Me.lbCurrencyDetails.Text = "Currency:"
        '
        'lbUnitMesureValue
        '
        Me.lbUnitMesureValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbUnitMesureValue.AutoSize = True
        Me.lbUnitMesureValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnitMesureValue.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbUnitMesureValue.Location = New System.Drawing.Point(912, 23)
        Me.lbUnitMesureValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbUnitMesureValue.Name = "lbUnitMesureValue"
        Me.lbUnitMesureValue.Size = New System.Drawing.Size(25, 18)
        Me.lbUnitMesureValue.TabIndex = 149
        Me.lbUnitMesureValue.Text = "- -"
        '
        'lbUnitMesure
        '
        Me.lbUnitMesure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbUnitMesure.AutoSize = True
        Me.lbUnitMesure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnitMesure.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbUnitMesure.Location = New System.Drawing.Point(815, 23)
        Me.lbUnitMesure.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbUnitMesure.Name = "lbUnitMesure"
        Me.lbUnitMesure.Size = New System.Drawing.Size(43, 18)
        Me.lbUnitMesure.TabIndex = 148
        Me.lbUnitMesure.Text = "Unit:"
        '
        'txtYearMax
        '
        Me.txtYearMax.Location = New System.Drawing.Point(569, 228)
        Me.txtYearMax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtYearMax.Name = "txtYearMax"
        Me.txtYearMax.Size = New System.Drawing.Size(64, 26)
        Me.txtYearMax.TabIndex = 4
        Me.txtYearMax.Visible = False
        '
        'txtYearMin
        '
        Me.txtYearMin.Location = New System.Drawing.Point(471, 228)
        Me.txtYearMin.Margin = New System.Windows.Forms.Padding(4)
        Me.txtYearMin.Name = "txtYearMin"
        Me.txtYearMin.Size = New System.Drawing.Size(63, 26)
        Me.txtYearMin.TabIndex = 3
        Me.txtYearMin.Visible = False
        '
        'lbYear
        '
        Me.lbYear.AutoSize = True
        Me.lbYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbYear.Location = New System.Drawing.Point(21, 249)
        Me.lbYear.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbYear.Name = "lbYear"
        Me.lbYear.Size = New System.Drawing.Size(47, 18)
        Me.lbYear.TabIndex = 144
        Me.lbYear.Text = "Year:"
        '
        'lsvFamily
        '
        Me.lsvFamily.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvFamily.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cformulaId, Me.db, Me.cctype, Me.ccode, Me.ccname, Me.cyear, Me.cversion, Me.ccardNbr, Me.ccarid, Me.ccarname, Me.cclient, Me.cvariant})
        Me.lsvFamily.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvFamily.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lsvFamily.FullRowSelect = True
        Me.lsvFamily.GridLines = True
        Me.lsvFamily.HideSelection = False
        Me.lsvFamily.Location = New System.Drawing.Point(16, 321)
        Me.lsvFamily.Margin = New System.Windows.Forms.Padding(4)
        Me.lsvFamily.Name = "lsvFamily"
        Me.lsvFamily.Size = New System.Drawing.Size(1017, 304)
        Me.lsvFamily.TabIndex = 143
        Me.lsvFamily.UseCompatibleStateImageBehavior = False
        Me.lsvFamily.View = System.Windows.Forms.View.Details
        '
        'cformulaId
        '
        Me.cformulaId.Tag = "cformulaId"
        Me.cformulaId.Text = "id"
        Me.cformulaId.Width = 0
        '
        'db
        '
        Me.db.Tag = "db"
        Me.db.Width = 0
        '
        'cctype
        '
        Me.cctype.Tag = "cctype"
        Me.cctype.Text = "Type"
        Me.cctype.Width = 69
        '
        'ccode
        '
        Me.ccode.Tag = "ccode"
        Me.ccode.Text = "Code"
        Me.ccode.Width = 86
        '
        'ccname
        '
        Me.ccname.Tag = "ccname"
        Me.ccname.Text = "Name"
        Me.ccname.Width = 79
        '
        'cyear
        '
        Me.cyear.Tag = "cyear"
        Me.cyear.Text = "Year"
        Me.cyear.Width = 74
        '
        'cversion
        '
        Me.cversion.Tag = "cversion"
        Me.cversion.Text = "Hue"
        Me.cversion.Width = 69
        '
        'ccardNbr
        '
        Me.ccardNbr.Tag = "ccardNbr"
        Me.ccardNbr.Text = "Card Number"
        Me.ccardNbr.Width = 107
        '
        'ccarid
        '
        Me.ccarid.Tag = "ccarid"
        Me.ccarid.Text = "carid"
        Me.ccarid.Width = 0
        '
        'ccarname
        '
        Me.ccarname.Text = "Car"
        Me.ccarname.Width = 80
        '
        'cclient
        '
        Me.cclient.Tag = "cclient"
        Me.cclient.Text = "Client"
        '
        'cvariant
        '
        Me.cvariant.Tag = "cvariant"
        Me.cvariant.Text = "Variant"
        Me.cvariant.Width = 78
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdAny)
        Me.GroupBox1.Controls.Add(Me.rdBC)
        Me.GroupBox1.Controls.Add(Me.rd2k_LS)
        Me.GroupBox1.Location = New System.Drawing.Point(823, 132)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(212, 43)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        '
        'rdAny
        '
        Me.rdAny.AutoSize = True
        Me.rdAny.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdAny.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdAny.Location = New System.Drawing.Point(136, 15)
        Me.rdAny.Margin = New System.Windows.Forms.Padding(4)
        Me.rdAny.Name = "rdAny"
        Me.rdAny.Size = New System.Drawing.Size(56, 21)
        Me.rdAny.TabIndex = 80
        Me.rdAny.Text = "Any"
        Me.rdAny.UseVisualStyleBackColor = True
        '
        'rdBC
        '
        Me.rdBC.AutoSize = True
        Me.rdBC.Checked = True
        Me.rdBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdBC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdBC.Location = New System.Drawing.Point(73, 15)
        Me.rdBC.Margin = New System.Windows.Forms.Padding(4)
        Me.rdBC.Name = "rdBC"
        Me.rdBC.Size = New System.Drawing.Size(49, 21)
        Me.rdBC.TabIndex = 79
        Me.rdBC.TabStop = True
        Me.rdBC.Text = "BC"
        Me.rdBC.UseVisualStyleBackColor = True
        '
        'rd2k_LS
        '
        Me.rd2k_LS.AutoSize = True
        Me.rd2k_LS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd2k_LS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rd2k_LS.Location = New System.Drawing.Point(12, 15)
        Me.rd2k_LS.Margin = New System.Windows.Forms.Padding(4)
        Me.rd2k_LS.Name = "rd2k_LS"
        Me.rd2k_LS.Size = New System.Drawing.Size(48, 21)
        Me.rd2k_LS.TabIndex = 78
        Me.rd2k_LS.Text = "2K"
        Me.rd2k_LS.UseVisualStyleBackColor = True
        '
        'chkFormulaName
        '
        Me.chkFormulaName.AutoSize = True
        Me.chkFormulaName.Checked = True
        Me.chkFormulaName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFormulaName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFormulaName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFormulaName.Location = New System.Drawing.Point(372, 186)
        Me.chkFormulaName.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFormulaName.Name = "chkFormulaName"
        Me.chkFormulaName.Size = New System.Drawing.Size(93, 21)
        Me.chkFormulaName.TabIndex = 70
        Me.chkFormulaName.Text = "Contains"
        Me.chkFormulaName.UseVisualStyleBackColor = True
        '
        'txtFormulaName
        '
        Me.txtFormulaName.Location = New System.Drawing.Point(168, 185)
        Me.txtFormulaName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFormulaName.Name = "txtFormulaName"
        Me.txtFormulaName.Size = New System.Drawing.Size(195, 26)
        Me.txtFormulaName.TabIndex = 2
        '
        'lbFormulaName
        '
        Me.lbFormulaName.AutoSize = True
        Me.lbFormulaName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFormulaName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbFormulaName.Location = New System.Drawing.Point(21, 185)
        Me.lbFormulaName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbFormulaName.Name = "lbFormulaName"
        Me.lbFormulaName.Size = New System.Drawing.Size(121, 18)
        Me.lbFormulaName.TabIndex = 68
        Me.lbFormulaName.Text = "Formula name:"
        '
        'butGo
        '
        Me.butGo.AccessibleDescription = "555"
        Me.butGo.BackColor = System.Drawing.SystemColors.Control
        Me.butGo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butGo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butGo.Location = New System.Drawing.Point(528, 30)
        Me.butGo.Margin = New System.Windows.Forms.Padding(4)
        Me.butGo.Name = "butGo"
        Me.butGo.Size = New System.Drawing.Size(132, 96)
        Me.butGo.TabIndex = 7
        Me.butGo.Text = "Go"
        Me.butGo.UseVisualStyleBackColor = False
        '
        'fileDialog
        '
        Me.fileDialog.FileName = "OpenFileDialog1"
        '
        'garageHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1051, 692)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1058, 676)
        Me.Name = "garageHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PaintShop (Garage)"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpFormulas.ResumeLayout(False)
        Me.grpFormulas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents ToolStripMenuItem1  As garageApp.MyMenuStrip
    'Friend WithEvents FileToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents ChangeToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents LogOutToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents ExitToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents DataEntryToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents ClientToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents AddUserToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents AmpereToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents TransactionsToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents CostToolStripMenuItem  As garageApp.MyMenuStrip
    Friend WithEvents openfile As System.Windows.Forms.OpenFileDialog
    'Friend WithEvents EnterMonthlyCostsToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents ClientStatusToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents ViewBalanceToolStripMenuItem  As garageApp.MyMenuStrip
    'Friend WithEvents BillsToolStripMenuItem  As garageApp.MyMenuStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents menFile As garageApp.MyMenuStrip
    Friend WithEvents menExit As garageApp.MyMenuStrip
    Friend WithEvents menSettings As garageApp.MyMenuStrip
    Friend WithEvents grpFormulas As garageApp.MyGroupBox
    Friend WithEvents butGo As garageApp.MyButton
    Friend WithEvents chkFormulaName As garageApp.MyCheckBox
    Friend WithEvents txtFormulaName As garageApp.MyTextBox
    Friend WithEvents lbFormulaName As garageApp.TranslatedLabel
    Friend WithEvents GroupBox1 As garageApp.MyGroupBox
    Friend WithEvents rdAny As garageApp.MyRadioButton
    Friend WithEvents rdBC As garageApp.MyRadioButton
    Friend WithEvents rd2k_LS As garageApp.MyRadioButton
    Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents menUpdate As garageApp.MyMenuStrip
    Friend WithEvents menEditColor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lsvFamily As garageApp.MyListView
    Friend WithEvents cformulaId As System.Windows.Forms.ColumnHeader
    Friend WithEvents ccode As System.Windows.Forms.ColumnHeader
    Friend WithEvents ccname As System.Windows.Forms.ColumnHeader
    Friend WithEvents cyear As System.Windows.Forms.ColumnHeader
    Friend WithEvents cctype As System.Windows.Forms.ColumnHeader
    Friend WithEvents cversion As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtYearMax As garageApp.MyTextBox
    Friend WithEvents txtYearMin As garageApp.MyTextBox
    Friend WithEvents lbYear As garageApp.TranslatedLabel
    Friend WithEvents lbCurrencyDetailsValue As System.Windows.Forms.Label
    Friend WithEvents lbCurrencyDetails As System.Windows.Forms.Label
    Friend WithEvents lbUnitMesureValue As System.Windows.Forms.Label
    Friend WithEvents lbUnitMesure As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbClient As garageApp.TranslatedLabel
    Friend WithEvents butExit As garageApp.MyButton
    Friend WithEvents chkUseOldDb As garageApp.MyCheckBox
    Friend WithEvents db As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbClientName As System.Windows.Forms.ComboBox
    Friend WithEvents txtYearSpec As garageApp.MyTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkCardNumber As garageApp.MyCheckBox
    Friend WithEvents txtCardNumber As garageApp.MyTextBox
    Friend WithEvents lbCardNumber As garageApp.TranslatedLabel
    Friend WithEvents ccardNbr As System.Windows.Forms.ColumnHeader
    Friend WithEvents butClearUpdate As System.Windows.Forms.Button
    Friend WithEvents cmbCarNameSearch As System.Windows.Forms.ComboBox
    Friend WithEvents txtColorCode As garageApp.MyTextBox
    Friend WithEvents chkColorCode As garageApp.MyCheckBox
    Friend WithEvents lbColorCode As garageApp.TranslatedLabel
    Friend WithEvents lbCarIdSearch As System.Windows.Forms.Label
    Friend WithEvents lbCarSearch As garageApp.TranslatedLabel
    Friend WithEvents BackupCustomersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreBackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FBrowserGarage As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents prgUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents cvariant As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColorLocatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportPricesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GetLatestDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbDownloading As System.Windows.Forms.Label
    Friend WithEvents chkAllCars As garageApp.MyCheckBox
    Friend WithEvents ccarname As ColumnHeader
    Friend WithEvents ccarid As ColumnHeader
    Friend WithEvents cclient As ColumnHeader
    Friend WithEvents lbAllCarsMode As garageApp.TranslatedLabel
    Friend WithEvents NucleosToolStripMenuItem As ToolStripMenuItem
End Class
