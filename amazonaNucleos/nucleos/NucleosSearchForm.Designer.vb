<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NucleosSearchForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NucleosSearchForm))
        Me.butGetJobs = New System.Windows.Forms.Button()
        Me.lstbJobs = New System.Windows.Forms.ListBox()
        Me.lbJobs = New System.Windows.Forms.Label()
        Me.lbChosenJob = New System.Windows.Forms.Label()
        Me.txtChosenJob = New System.Windows.Forms.TextBox()
        Me.lstvSearchResult = New System.Windows.Forms.ListView()
        Me.sampleId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sampleName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.merit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.autoCorrectedScore = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.effect = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.coarseness = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tricoat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.color = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.butSearch = New System.Windows.Forms.Button()
        Me.butSetLab = New System.Windows.Forms.Button()
        Me.jobRGB1 = New System.Windows.Forms.Label()
        Me.jobRGB2 = New System.Windows.Forms.Label()
        Me.jobRGB4 = New System.Windows.Forms.Label()
        Me.jobRGB3 = New System.Windows.Forms.Label()
        Me.jobRGB6 = New System.Windows.Forms.Label()
        Me.jobRGB5 = New System.Windows.Forms.Label()
        Me.lbCoat = New System.Windows.Forms.Label()
        Me.cmbCoats = New System.Windows.Forms.ComboBox()
        Me.tbControl = New System.Windows.Forms.TabControl()
        Me.tbSearchResult = New System.Windows.Forms.TabPage()
        Me.pbLoading = New System.Windows.Forms.PictureBox()
        Me.prgSearch = New System.Windows.Forms.ProgressBar()
        Me.butListCorrection = New System.Windows.Forms.Button()
        Me.tbDetails = New System.Windows.Forms.TabPage()
        Me.lbCorrectedScoreValue = New System.Windows.Forms.Label()
        Me.lbCorrectedScore = New System.Windows.Forms.Label()
        Me.lbOriginalScoreValue = New System.Windows.Forms.Label()
        Me.lbOriginalScore = New System.Windows.Forms.Label()
        Me.pnCorrectedWhite6 = New System.Windows.Forms.Panel()
        Me.pnCorrectedBlack6 = New System.Windows.Forms.Panel()
        Me.pnCorrectedWhite5 = New System.Windows.Forms.Panel()
        Me.pnCorrectedBlack3 = New System.Windows.Forms.Panel()
        Me.pnCorrectedWhite4 = New System.Windows.Forms.Panel()
        Me.pnCorrectedBlack5 = New System.Windows.Forms.Panel()
        Me.pnCorrectedBlack2 = New System.Windows.Forms.Panel()
        Me.btnOriginal = New System.Windows.Forms.Button()
        Me.lbTrial = New System.Windows.Forms.Label()
        Me.pnCorrectedBlack4 = New System.Windows.Forms.Panel()
        Me.pnTrial6 = New System.Windows.Forms.Panel()
        Me.pnTrial4 = New System.Windows.Forms.Panel()
        Me.pnTrial5 = New System.Windows.Forms.Panel()
        Me.pnTrial1 = New System.Windows.Forms.Panel()
        Me.pnCorrectedWhite3 = New System.Windows.Forms.Panel()
        Me.pnTrial3 = New System.Windows.Forms.Panel()
        Me.pnTrial2 = New System.Windows.Forms.Panel()
        Me.pnCorrectedWhite2 = New System.Windows.Forms.Panel()
        Me.pnTarget6 = New System.Windows.Forms.Panel()
        Me.pnTarget3 = New System.Windows.Forms.Panel()
        Me.pnTarget5 = New System.Windows.Forms.Panel()
        Me.pnTarget4 = New System.Windows.Forms.Panel()
        Me.pnTarget2 = New System.Windows.Forms.Panel()
        Me.lbBlackBg = New System.Windows.Forms.Label()
        Me.pnCorrectedBlack1 = New System.Windows.Forms.Panel()
        Me.lbWhiteBg = New System.Windows.Forms.Label()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lbTarget = New System.Windows.Forms.Label()
        Me.pnTarget1 = New System.Windows.Forms.Panel()
        Me.grpIngredients = New System.Windows.Forms.GroupBox()
        Me.pnlResult = New System.Windows.Forms.Panel()
        Me.butCoat2 = New System.Windows.Forms.Button()
        Me.butCoat1 = New System.Windows.Forms.Button()
        Me.lbAccumulation = New System.Windows.Forms.Label()
        Me.lbG = New System.Windows.Forms.Label()
        Me.txtCanSize = New System.Windows.Forms.TextBox()
        Me.lbCanSize = New System.Windows.Forms.Label()
        Me.lbCorrection = New System.Windows.Forms.Label()
        Me.lbQuantity = New System.Windows.Forms.Label()
        Me.lbColor = New System.Windows.Forms.Label()
        Me.btnCorrection = New System.Windows.Forms.Button()
        Me.pnCorrectedWhite1 = New System.Windows.Forms.Panel()
        Me.lbSampleId = New System.Windows.Forms.Label()
        Me.tbMeasuring = New System.Windows.Forms.TabPage()
        Me.lbSampleIdM = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBackFromM = New System.Windows.Forms.Button()
        Me.btnRemeasure = New System.Windows.Forms.Button()
        Me.lbMScoreValue = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlResultM = New System.Windows.Forms.Panel()
        Me.butCoat2m = New System.Windows.Forms.Button()
        Me.lbAccumulationM = New System.Windows.Forms.Label()
        Me.lbGM = New System.Windows.Forms.Label()
        Me.butCoat1m = New System.Windows.Forms.Button()
        Me.txtCanSizeM = New System.Windows.Forms.TextBox()
        Me.lbCanSizeM = New System.Windows.Forms.Label()
        Me.lbCorrectionM = New System.Windows.Forms.Label()
        Me.lbQuantityM = New System.Windows.Forms.Label()
        Me.lbcolorM = New System.Windows.Forms.Label()
        Me.cmbEffectType = New System.Windows.Forms.ComboBox()
        Me.lbEffectType = New System.Windows.Forms.Label()
        Me.butNucleosSettings = New System.Windows.Forms.Button()
        Me.pictGaragePic = New System.Windows.Forms.PictureBox()
        Me.butDeleteHistoryJob = New System.Windows.Forms.Button()
        Me.chkOldJobs = New System.Windows.Forms.CheckBox()
        Me.tbControl.SuspendLayout()
        Me.tbSearchResult.SuspendLayout()
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDetails.SuspendLayout()
        Me.grpIngredients.SuspendLayout()
        Me.pnlResult.SuspendLayout()
        Me.tbMeasuring.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlResultM.SuspendLayout()
        CType(Me.pictGaragePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butGetJobs
        '
        Me.butGetJobs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butGetJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butGetJobs.Location = New System.Drawing.Point(16, 831)
        Me.butGetJobs.Margin = New System.Windows.Forms.Padding(4)
        Me.butGetJobs.Name = "butGetJobs"
        Me.butGetJobs.Size = New System.Drawing.Size(368, 71)
        Me.butGetJobs.TabIndex = 0
        Me.butGetJobs.Text = "Get jobs"
        Me.butGetJobs.UseVisualStyleBackColor = True
        '
        'lstbJobs
        '
        Me.lstbJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstbJobs.FormattingEnabled = True
        Me.lstbJobs.ItemHeight = 29
        Me.lstbJobs.Location = New System.Drawing.Point(16, 347)
        Me.lstbJobs.Margin = New System.Windows.Forms.Padding(4)
        Me.lstbJobs.Name = "lstbJobs"
        Me.lstbJobs.Size = New System.Drawing.Size(368, 468)
        Me.lstbJobs.TabIndex = 2
        '
        'lbJobs
        '
        Me.lbJobs.AutoSize = True
        Me.lbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbJobs.Location = New System.Drawing.Point(13, 309)
        Me.lbJobs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbJobs.Name = "lbJobs"
        Me.lbJobs.Size = New System.Drawing.Size(123, 29)
        Me.lbJobs.TabIndex = 3
        Me.lbJobs.Text = "Jobs list:"
        '
        'lbChosenJob
        '
        Me.lbChosenJob.AutoSize = True
        Me.lbChosenJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbChosenJob.Location = New System.Drawing.Point(391, 11)
        Me.lbChosenJob.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbChosenJob.Name = "lbChosenJob"
        Me.lbChosenJob.Size = New System.Drawing.Size(159, 29)
        Me.lbChosenJob.TabIndex = 4
        Me.lbChosenJob.Text = "Chosen job:"
        '
        'txtChosenJob
        '
        Me.txtChosenJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChosenJob.Location = New System.Drawing.Point(593, 7)
        Me.txtChosenJob.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChosenJob.Name = "txtChosenJob"
        Me.txtChosenJob.ReadOnly = True
        Me.txtChosenJob.Size = New System.Drawing.Size(168, 32)
        Me.txtChosenJob.TabIndex = 5
        '
        'lstvSearchResult
        '
        Me.lstvSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstvSearchResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.sampleId, Me.sampleName, Me.merit, Me.autoCorrectedScore, Me.effect, Me.coarseness, Me.tricoat, Me.color})
        Me.lstvSearchResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvSearchResult.FullRowSelect = True
        Me.lstvSearchResult.GridLines = True
        Me.lstvSearchResult.HideSelection = False
        Me.lstvSearchResult.HoverSelection = True
        Me.lstvSearchResult.Location = New System.Drawing.Point(4, 4)
        Me.lstvSearchResult.Margin = New System.Windows.Forms.Padding(4)
        Me.lstvSearchResult.Name = "lstvSearchResult"
        Me.lstvSearchResult.Size = New System.Drawing.Size(1139, 691)
        Me.lstvSearchResult.TabIndex = 8
        Me.lstvSearchResult.UseCompatibleStateImageBehavior = False
        Me.lstvSearchResult.View = System.Windows.Forms.View.Details
        '
        'sampleId
        '
        Me.sampleId.Text = "Sample Id"
        Me.sampleId.Width = 0
        '
        'sampleName
        '
        Me.sampleName.Text = "Sample Name"
        Me.sampleName.Width = 350
        '
        'merit
        '
        Me.merit.Text = "Score"
        Me.merit.Width = 120
        '
        'autoCorrectedScore
        '
        Me.autoCorrectedScore.Text = "Auto Corrected Score"
        Me.autoCorrectedScore.Width = 250
        '
        'effect
        '
        Me.effect.Text = "Effect"
        Me.effect.Width = 100
        '
        'coarseness
        '
        Me.coarseness.Text = "Coarseness"
        Me.coarseness.Width = 120
        '
        'tricoat
        '
        Me.tricoat.Text = "Tricoat"
        Me.tricoat.Width = 75
        '
        'color
        '
        Me.color.Text = "Color"
        Me.color.Width = 300
        '
        'butSearch
        '
        Me.butSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSearch.Location = New System.Drawing.Point(9, 716)
        Me.butSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(325, 71)
        Me.butSearch.TabIndex = 9
        Me.butSearch.Text = "Search"
        Me.butSearch.UseVisualStyleBackColor = True
        '
        'butSetLab
        '
        Me.butSetLab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSetLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSetLab.Location = New System.Drawing.Point(937, 753)
        Me.butSetLab.Margin = New System.Windows.Forms.Padding(4)
        Me.butSetLab.Name = "butSetLab"
        Me.butSetLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butSetLab.Size = New System.Drawing.Size(205, 34)
        Me.butSetLab.TabIndex = 10
        Me.butSetLab.Text = "Set Lab Values with spectral type"
        Me.butSetLab.UseVisualStyleBackColor = True
        Me.butSetLab.Visible = False
        '
        'jobRGB1
        '
        Me.jobRGB1.AutoSize = True
        Me.jobRGB1.BackColor = System.Drawing.Color.Transparent
        Me.jobRGB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobRGB1.Location = New System.Drawing.Point(770, 11)
        Me.jobRGB1.Name = "jobRGB1"
        Me.jobRGB1.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB1.TabIndex = 11
        Me.jobRGB1.Text = " "
        '
        'jobRGB2
        '
        Me.jobRGB2.AutoSize = True
        Me.jobRGB2.BackColor = System.Drawing.Color.Transparent
        Me.jobRGB2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobRGB2.Location = New System.Drawing.Point(796, 11)
        Me.jobRGB2.Name = "jobRGB2"
        Me.jobRGB2.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB2.TabIndex = 12
        Me.jobRGB2.Text = " "
        '
        'jobRGB4
        '
        Me.jobRGB4.AutoSize = True
        Me.jobRGB4.BackColor = System.Drawing.Color.Transparent
        Me.jobRGB4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobRGB4.Location = New System.Drawing.Point(848, 11)
        Me.jobRGB4.Name = "jobRGB4"
        Me.jobRGB4.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB4.TabIndex = 14
        Me.jobRGB4.Text = " "
        '
        'jobRGB3
        '
        Me.jobRGB3.AutoSize = True
        Me.jobRGB3.BackColor = System.Drawing.Color.Transparent
        Me.jobRGB3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobRGB3.Location = New System.Drawing.Point(822, 11)
        Me.jobRGB3.Name = "jobRGB3"
        Me.jobRGB3.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB3.TabIndex = 13
        Me.jobRGB3.Text = " "
        '
        'jobRGB6
        '
        Me.jobRGB6.AutoSize = True
        Me.jobRGB6.BackColor = System.Drawing.Color.Transparent
        Me.jobRGB6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobRGB6.Location = New System.Drawing.Point(900, 11)
        Me.jobRGB6.Name = "jobRGB6"
        Me.jobRGB6.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB6.TabIndex = 16
        Me.jobRGB6.Text = " "
        '
        'jobRGB5
        '
        Me.jobRGB5.AutoSize = True
        Me.jobRGB5.BackColor = System.Drawing.Color.Transparent
        Me.jobRGB5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobRGB5.Location = New System.Drawing.Point(874, 11)
        Me.jobRGB5.Name = "jobRGB5"
        Me.jobRGB5.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB5.TabIndex = 15
        Me.jobRGB5.Text = " "
        '
        'lbCoat
        '
        Me.lbCoat.AutoSize = True
        Me.lbCoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCoat.Location = New System.Drawing.Point(13, 260)
        Me.lbCoat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCoat.Name = "lbCoat"
        Me.lbCoat.Size = New System.Drawing.Size(78, 29)
        Me.lbCoat.TabIndex = 17
        Me.lbCoat.Text = "Coat:"
        '
        'cmbCoats
        '
        Me.cmbCoats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoats.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCoats.FormattingEnabled = True
        Me.cmbCoats.Items.AddRange(New Object() {"LS", "BC"})
        Me.cmbCoats.Location = New System.Drawing.Point(99, 258)
        Me.cmbCoats.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCoats.Name = "cmbCoats"
        Me.cmbCoats.Size = New System.Drawing.Size(243, 34)
        Me.cmbCoats.TabIndex = 18
        '
        'tbControl
        '
        Me.tbControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbControl.Controls.Add(Me.tbSearchResult)
        Me.tbControl.Controls.Add(Me.tbDetails)
        Me.tbControl.Controls.Add(Me.tbMeasuring)
        Me.tbControl.Location = New System.Drawing.Point(396, 89)
        Me.tbControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(1157, 823)
        Me.tbControl.TabIndex = 19
        '
        'tbSearchResult
        '
        Me.tbSearchResult.Controls.Add(Me.pbLoading)
        Me.tbSearchResult.Controls.Add(Me.prgSearch)
        Me.tbSearchResult.Controls.Add(Me.butListCorrection)
        Me.tbSearchResult.Controls.Add(Me.lstvSearchResult)
        Me.tbSearchResult.Controls.Add(Me.butSetLab)
        Me.tbSearchResult.Controls.Add(Me.butSearch)
        Me.tbSearchResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchResult.Location = New System.Drawing.Point(4, 25)
        Me.tbSearchResult.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbSearchResult.Name = "tbSearchResult"
        Me.tbSearchResult.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbSearchResult.Size = New System.Drawing.Size(1149, 794)
        Me.tbSearchResult.TabIndex = 0
        Me.tbSearchResult.Text = "Search Result"
        Me.tbSearchResult.UseVisualStyleBackColor = True
        '
        'pbLoading
        '
        Me.pbLoading.Image = CType(resources.GetObject("pbLoading.Image"), System.Drawing.Image)
        Me.pbLoading.Location = New System.Drawing.Point(479, 34)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(140, 28)
        Me.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLoading.TabIndex = 25
        Me.pbLoading.TabStop = False
        Me.pbLoading.Visible = False
        '
        'prgSearch
        '
        Me.prgSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgSearch.Location = New System.Drawing.Point(9, 700)
        Me.prgSearch.Name = "prgSearch"
        Me.prgSearch.Size = New System.Drawing.Size(1133, 10)
        Me.prgSearch.Step = 1
        Me.prgSearch.TabIndex = 22
        '
        'butListCorrection
        '
        Me.butListCorrection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butListCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butListCorrection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butListCorrection.Location = New System.Drawing.Point(731, 758)
        Me.butListCorrection.Margin = New System.Windows.Forms.Padding(4)
        Me.butListCorrection.Name = "butListCorrection"
        Me.butListCorrection.Size = New System.Drawing.Size(190, 30)
        Me.butListCorrection.TabIndex = 21
        Me.butListCorrection.Text = "↑ Correct && Sort ↑"
        Me.butListCorrection.UseVisualStyleBackColor = True
        Me.butListCorrection.Visible = False
        '
        'tbDetails
        '
        Me.tbDetails.Controls.Add(Me.lbCorrectedScoreValue)
        Me.tbDetails.Controls.Add(Me.lbCorrectedScore)
        Me.tbDetails.Controls.Add(Me.lbOriginalScoreValue)
        Me.tbDetails.Controls.Add(Me.lbOriginalScore)
        Me.tbDetails.Controls.Add(Me.pnCorrectedWhite6)
        Me.tbDetails.Controls.Add(Me.pnCorrectedBlack6)
        Me.tbDetails.Controls.Add(Me.pnCorrectedWhite5)
        Me.tbDetails.Controls.Add(Me.pnCorrectedBlack3)
        Me.tbDetails.Controls.Add(Me.pnCorrectedWhite4)
        Me.tbDetails.Controls.Add(Me.pnCorrectedBlack5)
        Me.tbDetails.Controls.Add(Me.pnCorrectedBlack2)
        Me.tbDetails.Controls.Add(Me.btnOriginal)
        Me.tbDetails.Controls.Add(Me.lbTrial)
        Me.tbDetails.Controls.Add(Me.pnCorrectedBlack4)
        Me.tbDetails.Controls.Add(Me.pnTrial6)
        Me.tbDetails.Controls.Add(Me.pnTrial4)
        Me.tbDetails.Controls.Add(Me.pnTrial5)
        Me.tbDetails.Controls.Add(Me.pnTrial1)
        Me.tbDetails.Controls.Add(Me.pnCorrectedWhite3)
        Me.tbDetails.Controls.Add(Me.pnTrial3)
        Me.tbDetails.Controls.Add(Me.pnTrial2)
        Me.tbDetails.Controls.Add(Me.pnCorrectedWhite2)
        Me.tbDetails.Controls.Add(Me.pnTarget6)
        Me.tbDetails.Controls.Add(Me.pnTarget3)
        Me.tbDetails.Controls.Add(Me.pnTarget5)
        Me.tbDetails.Controls.Add(Me.pnTarget4)
        Me.tbDetails.Controls.Add(Me.pnTarget2)
        Me.tbDetails.Controls.Add(Me.lbBlackBg)
        Me.tbDetails.Controls.Add(Me.pnCorrectedBlack1)
        Me.tbDetails.Controls.Add(Me.lbWhiteBg)
        Me.tbDetails.Controls.Add(Me.btnMeasure)
        Me.tbDetails.Controls.Add(Me.btnBack)
        Me.tbDetails.Controls.Add(Me.lbTarget)
        Me.tbDetails.Controls.Add(Me.pnTarget1)
        Me.tbDetails.Controls.Add(Me.grpIngredients)
        Me.tbDetails.Controls.Add(Me.btnCorrection)
        Me.tbDetails.Controls.Add(Me.pnCorrectedWhite1)
        Me.tbDetails.Controls.Add(Me.lbSampleId)
        Me.tbDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDetails.Location = New System.Drawing.Point(4, 25)
        Me.tbDetails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbDetails.Name = "tbDetails"
        Me.tbDetails.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbDetails.Size = New System.Drawing.Size(1149, 794)
        Me.tbDetails.TabIndex = 1
        Me.tbDetails.Text = "Details"
        Me.tbDetails.UseVisualStyleBackColor = True
        '
        'lbCorrectedScoreValue
        '
        Me.lbCorrectedScoreValue.AutoSize = True
        Me.lbCorrectedScoreValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrectedScoreValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCorrectedScoreValue.Location = New System.Drawing.Point(584, 17)
        Me.lbCorrectedScoreValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCorrectedScoreValue.Name = "lbCorrectedScoreValue"
        Me.lbCorrectedScoreValue.Size = New System.Drawing.Size(28, 29)
        Me.lbCorrectedScoreValue.TabIndex = 33
        Me.lbCorrectedScoreValue.Text = "0"
        '
        'lbCorrectedScore
        '
        Me.lbCorrectedScore.AutoSize = True
        Me.lbCorrectedScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrectedScore.Location = New System.Drawing.Point(373, 17)
        Me.lbCorrectedScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCorrectedScore.Name = "lbCorrectedScore"
        Me.lbCorrectedScore.Size = New System.Drawing.Size(203, 29)
        Me.lbCorrectedScore.TabIndex = 32
        Me.lbCorrectedScore.Text = "Corrected Score:"
        '
        'lbOriginalScoreValue
        '
        Me.lbOriginalScoreValue.AutoSize = True
        Me.lbOriginalScoreValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOriginalScoreValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbOriginalScoreValue.Location = New System.Drawing.Point(584, 17)
        Me.lbOriginalScoreValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbOriginalScoreValue.Name = "lbOriginalScoreValue"
        Me.lbOriginalScoreValue.Size = New System.Drawing.Size(28, 29)
        Me.lbOriginalScoreValue.TabIndex = 31
        Me.lbOriginalScoreValue.Text = "0"
        '
        'lbOriginalScore
        '
        Me.lbOriginalScore.AutoSize = True
        Me.lbOriginalScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOriginalScore.Location = New System.Drawing.Point(396, 17)
        Me.lbOriginalScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbOriginalScore.Name = "lbOriginalScore"
        Me.lbOriginalScore.Size = New System.Drawing.Size(180, 29)
        Me.lbOriginalScore.TabIndex = 30
        Me.lbOriginalScore.Text = "Original Score:"
        '
        'pnCorrectedWhite6
        '
        Me.pnCorrectedWhite6.Location = New System.Drawing.Point(164, 613)
        Me.pnCorrectedWhite6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedWhite6.Name = "pnCorrectedWhite6"
        Me.pnCorrectedWhite6.Size = New System.Drawing.Size(51, 32)
        Me.pnCorrectedWhite6.TabIndex = 20
        Me.pnCorrectedWhite6.Visible = False
        '
        'pnCorrectedBlack6
        '
        Me.pnCorrectedBlack6.Location = New System.Drawing.Point(221, 610)
        Me.pnCorrectedBlack6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedBlack6.Name = "pnCorrectedBlack6"
        Me.pnCorrectedBlack6.Size = New System.Drawing.Size(51, 34)
        Me.pnCorrectedBlack6.TabIndex = 20
        Me.pnCorrectedBlack6.Visible = False
        '
        'pnCorrectedWhite5
        '
        Me.pnCorrectedWhite5.Location = New System.Drawing.Point(164, 576)
        Me.pnCorrectedWhite5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedWhite5.Name = "pnCorrectedWhite5"
        Me.pnCorrectedWhite5.Size = New System.Drawing.Size(51, 32)
        Me.pnCorrectedWhite5.TabIndex = 21
        Me.pnCorrectedWhite5.Visible = False
        '
        'pnCorrectedBlack3
        '
        Me.pnCorrectedBlack3.Location = New System.Drawing.Point(221, 500)
        Me.pnCorrectedBlack3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedBlack3.Name = "pnCorrectedBlack3"
        Me.pnCorrectedBlack3.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedBlack3.TabIndex = 19
        Me.pnCorrectedBlack3.Visible = False
        '
        'pnCorrectedWhite4
        '
        Me.pnCorrectedWhite4.Location = New System.Drawing.Point(164, 538)
        Me.pnCorrectedWhite4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedWhite4.Name = "pnCorrectedWhite4"
        Me.pnCorrectedWhite4.Size = New System.Drawing.Size(51, 32)
        Me.pnCorrectedWhite4.TabIndex = 22
        Me.pnCorrectedWhite4.Visible = False
        '
        'pnCorrectedBlack5
        '
        Me.pnCorrectedBlack5.Location = New System.Drawing.Point(221, 574)
        Me.pnCorrectedBlack5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedBlack5.Name = "pnCorrectedBlack5"
        Me.pnCorrectedBlack5.Size = New System.Drawing.Size(51, 34)
        Me.pnCorrectedBlack5.TabIndex = 21
        Me.pnCorrectedBlack5.Visible = False
        '
        'pnCorrectedBlack2
        '
        Me.pnCorrectedBlack2.Location = New System.Drawing.Point(221, 462)
        Me.pnCorrectedBlack2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedBlack2.Name = "pnCorrectedBlack2"
        Me.pnCorrectedBlack2.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedBlack2.TabIndex = 19
        Me.pnCorrectedBlack2.Visible = False
        '
        'btnOriginal
        '
        Me.btnOriginal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOriginal.Location = New System.Drawing.Point(939, 7)
        Me.btnOriginal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New System.Drawing.Size(197, 76)
        Me.btnOriginal.TabIndex = 22
        Me.btnOriginal.Text = "Original Sample"
        Me.btnOriginal.UseVisualStyleBackColor = True
        '
        'lbTrial
        '
        Me.lbTrial.AutoSize = True
        Me.lbTrial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTrial.Location = New System.Drawing.Point(252, 64)
        Me.lbTrial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTrial.Name = "lbTrial"
        Me.lbTrial.Size = New System.Drawing.Size(47, 20)
        Me.lbTrial.TabIndex = 20
        Me.lbTrial.Text = "Trial"
        '
        'pnCorrectedBlack4
        '
        Me.pnCorrectedBlack4.Location = New System.Drawing.Point(221, 539)
        Me.pnCorrectedBlack4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedBlack4.Name = "pnCorrectedBlack4"
        Me.pnCorrectedBlack4.Size = New System.Drawing.Size(51, 31)
        Me.pnCorrectedBlack4.TabIndex = 22
        Me.pnCorrectedBlack4.Visible = False
        '
        'pnTrial6
        '
        Me.pnTrial6.Location = New System.Drawing.Point(221, 334)
        Me.pnTrial6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTrial6.Name = "pnTrial6"
        Me.pnTrial6.Size = New System.Drawing.Size(140, 42)
        Me.pnTrial6.TabIndex = 21
        '
        'pnTrial4
        '
        Me.pnTrial4.Location = New System.Drawing.Point(221, 239)
        Me.pnTrial4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTrial4.Name = "pnTrial4"
        Me.pnTrial4.Size = New System.Drawing.Size(140, 42)
        Me.pnTrial4.TabIndex = 19
        '
        'pnTrial5
        '
        Me.pnTrial5.Location = New System.Drawing.Point(221, 287)
        Me.pnTrial5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTrial5.Name = "pnTrial5"
        Me.pnTrial5.Size = New System.Drawing.Size(140, 41)
        Me.pnTrial5.TabIndex = 20
        '
        'pnTrial1
        '
        Me.pnTrial1.Location = New System.Drawing.Point(221, 100)
        Me.pnTrial1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTrial1.Name = "pnTrial1"
        Me.pnTrial1.Size = New System.Drawing.Size(140, 39)
        Me.pnTrial1.TabIndex = 17
        '
        'pnCorrectedWhite3
        '
        Me.pnCorrectedWhite3.Location = New System.Drawing.Point(164, 500)
        Me.pnCorrectedWhite3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedWhite3.Name = "pnCorrectedWhite3"
        Me.pnCorrectedWhite3.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedWhite3.TabIndex = 19
        Me.pnCorrectedWhite3.Visible = False
        '
        'pnTrial3
        '
        Me.pnTrial3.Location = New System.Drawing.Point(221, 194)
        Me.pnTrial3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTrial3.Name = "pnTrial3"
        Me.pnTrial3.Size = New System.Drawing.Size(140, 37)
        Me.pnTrial3.TabIndex = 18
        '
        'pnTrial2
        '
        Me.pnTrial2.Location = New System.Drawing.Point(221, 146)
        Me.pnTrial2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTrial2.Name = "pnTrial2"
        Me.pnTrial2.Size = New System.Drawing.Size(140, 39)
        Me.pnTrial2.TabIndex = 18
        '
        'pnCorrectedWhite2
        '
        Me.pnCorrectedWhite2.Location = New System.Drawing.Point(164, 462)
        Me.pnCorrectedWhite2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedWhite2.Name = "pnCorrectedWhite2"
        Me.pnCorrectedWhite2.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedWhite2.TabIndex = 19
        Me.pnCorrectedWhite2.Visible = False
        '
        'pnTarget6
        '
        Me.pnTarget6.Location = New System.Drawing.Point(81, 334)
        Me.pnTarget6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTarget6.Name = "pnTarget6"
        Me.pnTarget6.Size = New System.Drawing.Size(133, 42)
        Me.pnTarget6.TabIndex = 28
        '
        'pnTarget3
        '
        Me.pnTarget3.Location = New System.Drawing.Point(81, 192)
        Me.pnTarget3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTarget3.Name = "pnTarget3"
        Me.pnTarget3.Size = New System.Drawing.Size(133, 39)
        Me.pnTarget3.TabIndex = 25
        '
        'pnTarget5
        '
        Me.pnTarget5.Location = New System.Drawing.Point(81, 286)
        Me.pnTarget5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTarget5.Name = "pnTarget5"
        Me.pnTarget5.Size = New System.Drawing.Size(133, 42)
        Me.pnTarget5.TabIndex = 27
        '
        'pnTarget4
        '
        Me.pnTarget4.Location = New System.Drawing.Point(81, 238)
        Me.pnTarget4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTarget4.Name = "pnTarget4"
        Me.pnTarget4.Size = New System.Drawing.Size(133, 42)
        Me.pnTarget4.TabIndex = 26
        '
        'pnTarget2
        '
        Me.pnTarget2.Location = New System.Drawing.Point(81, 146)
        Me.pnTarget2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTarget2.Name = "pnTarget2"
        Me.pnTarget2.Size = New System.Drawing.Size(133, 39)
        Me.pnTarget2.TabIndex = 25
        '
        'lbBlackBg
        '
        Me.lbBlackBg.AutoSize = True
        Me.lbBlackBg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBlackBg.Location = New System.Drawing.Point(241, 390)
        Me.lbBlackBg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbBlackBg.Name = "lbBlackBg"
        Me.lbBlackBg.Size = New System.Drawing.Size(178, 20)
        Me.lbBlackBg.TabIndex = 29
        Me.lbBlackBg.Text = "Corrected Black BG"
        Me.lbBlackBg.Visible = False
        '
        'pnCorrectedBlack1
        '
        Me.pnCorrectedBlack1.Location = New System.Drawing.Point(221, 422)
        Me.pnCorrectedBlack1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedBlack1.Name = "pnCorrectedBlack1"
        Me.pnCorrectedBlack1.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedBlack1.TabIndex = 19
        Me.pnCorrectedBlack1.Visible = False
        '
        'lbWhiteBg
        '
        Me.lbWhiteBg.AutoSize = True
        Me.lbWhiteBg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbWhiteBg.Location = New System.Drawing.Point(13, 390)
        Me.lbWhiteBg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbWhiteBg.Name = "lbWhiteBg"
        Me.lbWhiteBg.Size = New System.Drawing.Size(179, 20)
        Me.lbWhiteBg.TabIndex = 28
        Me.lbWhiteBg.Text = "Corrected White BG"
        Me.lbWhiteBg.Visible = False
        '
        'btnMeasure
        '
        Me.btnMeasure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeasure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMeasure.Location = New System.Drawing.Point(19, 673)
        Me.btnMeasure.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(401, 54)
        Me.btnMeasure.TabIndex = 27
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(19, 738)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(401, 48)
        Me.btnBack.TabIndex = 26
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lbTarget
        '
        Me.lbTarget.AutoSize = True
        Me.lbTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTarget.Location = New System.Drawing.Point(115, 64)
        Me.lbTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTarget.Name = "lbTarget"
        Me.lbTarget.Size = New System.Drawing.Size(63, 20)
        Me.lbTarget.TabIndex = 25
        Me.lbTarget.Text = "Target"
        '
        'pnTarget1
        '
        Me.pnTarget1.Location = New System.Drawing.Point(81, 100)
        Me.pnTarget1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTarget1.Name = "pnTarget1"
        Me.pnTarget1.Size = New System.Drawing.Size(133, 39)
        Me.pnTarget1.TabIndex = 24
        '
        'grpIngredients
        '
        Me.grpIngredients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpIngredients.Controls.Add(Me.pnlResult)
        Me.grpIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpIngredients.Location = New System.Drawing.Point(461, 90)
        Me.grpIngredients.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpIngredients.Name = "grpIngredients"
        Me.grpIngredients.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpIngredients.Size = New System.Drawing.Size(680, 697)
        Me.grpIngredients.TabIndex = 23
        Me.grpIngredients.TabStop = False
        '
        'pnlResult
        '
        Me.pnlResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlResult.Controls.Add(Me.butCoat2)
        Me.pnlResult.Controls.Add(Me.butCoat1)
        Me.pnlResult.Controls.Add(Me.lbAccumulation)
        Me.pnlResult.Controls.Add(Me.lbG)
        Me.pnlResult.Controls.Add(Me.txtCanSize)
        Me.pnlResult.Controls.Add(Me.lbCanSize)
        Me.pnlResult.Controls.Add(Me.lbCorrection)
        Me.pnlResult.Controls.Add(Me.lbQuantity)
        Me.pnlResult.Controls.Add(Me.lbColor)
        Me.pnlResult.Location = New System.Drawing.Point(5, 21)
        Me.pnlResult.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlResult.Name = "pnlResult"
        Me.pnlResult.Size = New System.Drawing.Size(668, 671)
        Me.pnlResult.TabIndex = 0
        '
        'butCoat2
        '
        Me.butCoat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butCoat2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCoat2.Location = New System.Drawing.Point(197, 62)
        Me.butCoat2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butCoat2.Name = "butCoat2"
        Me.butCoat2.Size = New System.Drawing.Size(184, 57)
        Me.butCoat2.TabIndex = 34
        Me.butCoat2.Text = "Second Coat"
        Me.butCoat2.UseVisualStyleBackColor = True
        '
        'butCoat1
        '
        Me.butCoat1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butCoat1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCoat1.Location = New System.Drawing.Point(21, 62)
        Me.butCoat1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butCoat1.Name = "butCoat1"
        Me.butCoat1.Size = New System.Drawing.Size(157, 59)
        Me.butCoat1.TabIndex = 33
        Me.butCoat1.Text = "First Coat"
        Me.butCoat1.UseVisualStyleBackColor = True
        '
        'lbAccumulation
        '
        Me.lbAccumulation.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbAccumulation.AutoSize = True
        Me.lbAccumulation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAccumulation.Location = New System.Drawing.Point(317, 144)
        Me.lbAccumulation.Name = "lbAccumulation"
        Me.lbAccumulation.Size = New System.Drawing.Size(142, 25)
        Me.lbAccumulation.TabIndex = 32
        Me.lbAccumulation.Text = "Accumulation"
        '
        'lbG
        '
        Me.lbG.AutoSize = True
        Me.lbG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbG.Location = New System.Drawing.Point(220, 21)
        Me.lbG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbG.Name = "lbG"
        Me.lbG.Size = New System.Drawing.Size(19, 20)
        Me.lbG.TabIndex = 31
        Me.lbG.Text = "g"
        '
        'txtCanSize
        '
        Me.txtCanSize.BackColor = System.Drawing.Color.White
        Me.txtCanSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanSize.Location = New System.Drawing.Point(141, 11)
        Me.txtCanSize.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCanSize.Name = "txtCanSize"
        Me.txtCanSize.Size = New System.Drawing.Size(69, 32)
        Me.txtCanSize.TabIndex = 21
        '
        'lbCanSize
        '
        Me.lbCanSize.AutoSize = True
        Me.lbCanSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCanSize.Location = New System.Drawing.Point(19, 18)
        Me.lbCanSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCanSize.Name = "lbCanSize"
        Me.lbCanSize.Size = New System.Drawing.Size(91, 20)
        Me.lbCanSize.TabIndex = 30
        Me.lbCanSize.Text = "Can Size:"
        '
        'lbCorrection
        '
        Me.lbCorrection.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbCorrection.AutoSize = True
        Me.lbCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrection.Location = New System.Drawing.Point(509, 146)
        Me.lbCorrection.Name = "lbCorrection"
        Me.lbCorrection.Size = New System.Drawing.Size(112, 25)
        Me.lbCorrection.TabIndex = 2
        Me.lbCorrection.Text = "Correction"
        Me.lbCorrection.Visible = False
        '
        'lbQuantity
        '
        Me.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbQuantity.AutoSize = True
        Me.lbQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQuantity.Location = New System.Drawing.Point(172, 144)
        Me.lbQuantity.Name = "lbQuantity"
        Me.lbQuantity.Size = New System.Drawing.Size(93, 25)
        Me.lbQuantity.TabIndex = 1
        Me.lbQuantity.Text = "Quantity"
        '
        'lbColor
        '
        Me.lbColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbColor.AutoSize = True
        Me.lbColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbColor.Location = New System.Drawing.Point(33, 144)
        Me.lbColor.Name = "lbColor"
        Me.lbColor.Size = New System.Drawing.Size(64, 25)
        Me.lbColor.TabIndex = 0
        Me.lbColor.Text = "Color"
        '
        'btnCorrection
        '
        Me.btnCorrection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCorrection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorrection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCorrection.Location = New System.Drawing.Point(729, 7)
        Me.btnCorrection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCorrection.Name = "btnCorrection"
        Me.btnCorrection.Size = New System.Drawing.Size(188, 76)
        Me.btnCorrection.TabIndex = 21
        Me.btnCorrection.Text = "Auto Correction"
        Me.btnCorrection.UseVisualStyleBackColor = True
        '
        'pnCorrectedWhite1
        '
        Me.pnCorrectedWhite1.Location = New System.Drawing.Point(164, 422)
        Me.pnCorrectedWhite1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnCorrectedWhite1.Name = "pnCorrectedWhite1"
        Me.pnCorrectedWhite1.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedWhite1.TabIndex = 18
        Me.pnCorrectedWhite1.Visible = False
        '
        'lbSampleId
        '
        Me.lbSampleId.AutoSize = True
        Me.lbSampleId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSampleId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbSampleId.Location = New System.Drawing.Point(14, 17)
        Me.lbSampleId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSampleId.Name = "lbSampleId"
        Me.lbSampleId.Size = New System.Drawing.Size(120, 25)
        Me.lbSampleId.TabIndex = 16
        Me.lbSampleId.Text = "lbSampleId"
        '
        'tbMeasuring
        '
        Me.tbMeasuring.Controls.Add(Me.lbSampleIdM)
        Me.tbMeasuring.Controls.Add(Me.Label2)
        Me.tbMeasuring.Controls.Add(Me.btnBackFromM)
        Me.tbMeasuring.Controls.Add(Me.btnRemeasure)
        Me.tbMeasuring.Controls.Add(Me.lbMScoreValue)
        Me.tbMeasuring.Controls.Add(Me.Label3)
        Me.tbMeasuring.Controls.Add(Me.GroupBox1)
        Me.tbMeasuring.Location = New System.Drawing.Point(4, 25)
        Me.tbMeasuring.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbMeasuring.Name = "tbMeasuring"
        Me.tbMeasuring.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbMeasuring.Size = New System.Drawing.Size(1149, 794)
        Me.tbMeasuring.TabIndex = 2
        Me.tbMeasuring.Text = "Measurement"
        Me.tbMeasuring.UseVisualStyleBackColor = True
        '
        'lbSampleIdM
        '
        Me.lbSampleIdM.AutoSize = True
        Me.lbSampleIdM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSampleIdM.Location = New System.Drawing.Point(180, 11)
        Me.lbSampleIdM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSampleIdM.Name = "lbSampleIdM"
        Me.lbSampleIdM.Size = New System.Drawing.Size(172, 29)
        Me.lbSampleIdM.TabIndex = 42
        Me.lbSampleIdM.Text = "lbSampleIdM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 29)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Sample ID:"
        '
        'btnBackFromM
        '
        Me.btnBackFromM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBackFromM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackFromM.Location = New System.Drawing.Point(935, 7)
        Me.btnBackFromM.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBackFromM.Name = "btnBackFromM"
        Me.btnBackFromM.Size = New System.Drawing.Size(196, 82)
        Me.btnBackFromM.TabIndex = 40
        Me.btnBackFromM.Text = "Back"
        Me.btnBackFromM.UseVisualStyleBackColor = True
        '
        'btnRemeasure
        '
        Me.btnRemeasure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemeasure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnRemeasure.Location = New System.Drawing.Point(700, 6)
        Me.btnRemeasure.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemeasure.Name = "btnRemeasure"
        Me.btnRemeasure.Size = New System.Drawing.Size(215, 84)
        Me.btnRemeasure.TabIndex = 39
        Me.btnRemeasure.Text = "Re-measure"
        Me.btnRemeasure.UseVisualStyleBackColor = True
        '
        'lbMScoreValue
        '
        Me.lbMScoreValue.AutoSize = True
        Me.lbMScoreValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMScoreValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbMScoreValue.Location = New System.Drawing.Point(308, 57)
        Me.lbMScoreValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbMScoreValue.Name = "lbMScoreValue"
        Me.lbMScoreValue.Size = New System.Drawing.Size(28, 29)
        Me.lbMScoreValue.TabIndex = 38
        Me.lbMScoreValue.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 57)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(211, 29)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Measuring Score:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pnlResultM)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(61, 89)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1027, 725)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'pnlResultM
        '
        Me.pnlResultM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlResultM.Controls.Add(Me.butCoat2m)
        Me.pnlResultM.Controls.Add(Me.lbAccumulationM)
        Me.pnlResultM.Controls.Add(Me.lbGM)
        Me.pnlResultM.Controls.Add(Me.butCoat1m)
        Me.pnlResultM.Controls.Add(Me.txtCanSizeM)
        Me.pnlResultM.Controls.Add(Me.lbCanSizeM)
        Me.pnlResultM.Controls.Add(Me.lbCorrectionM)
        Me.pnlResultM.Controls.Add(Me.lbQuantityM)
        Me.pnlResultM.Controls.Add(Me.lbcolorM)
        Me.pnlResultM.Location = New System.Drawing.Point(5, 21)
        Me.pnlResultM.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlResultM.Name = "pnlResultM"
        Me.pnlResultM.Size = New System.Drawing.Size(1015, 677)
        Me.pnlResultM.TabIndex = 0
        '
        'butCoat2m
        '
        Me.butCoat2m.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butCoat2m.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCoat2m.Location = New System.Drawing.Point(197, 62)
        Me.butCoat2m.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butCoat2m.Name = "butCoat2m"
        Me.butCoat2m.Size = New System.Drawing.Size(187, 58)
        Me.butCoat2m.TabIndex = 36
        Me.butCoat2m.Text = "Second Coat"
        Me.butCoat2m.UseVisualStyleBackColor = True
        '
        'lbAccumulationM
        '
        Me.lbAccumulationM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbAccumulationM.AutoSize = True
        Me.lbAccumulationM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAccumulationM.Location = New System.Drawing.Point(515, 128)
        Me.lbAccumulationM.Name = "lbAccumulationM"
        Me.lbAccumulationM.Size = New System.Drawing.Size(179, 29)
        Me.lbAccumulationM.TabIndex = 32
        Me.lbAccumulationM.Text = "Accumulation"
        '
        'lbGM
        '
        Me.lbGM.AutoSize = True
        Me.lbGM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGM.Location = New System.Drawing.Point(215, 18)
        Me.lbGM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbGM.Name = "lbGM"
        Me.lbGM.Size = New System.Drawing.Size(19, 20)
        Me.lbGM.TabIndex = 31
        Me.lbGM.Text = "g"
        '
        'butCoat1m
        '
        Me.butCoat1m.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butCoat1m.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCoat1m.Location = New System.Drawing.Point(21, 62)
        Me.butCoat1m.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butCoat1m.Name = "butCoat1m"
        Me.butCoat1m.Size = New System.Drawing.Size(157, 58)
        Me.butCoat1m.TabIndex = 35
        Me.butCoat1m.Text = "First Coat"
        Me.butCoat1m.UseVisualStyleBackColor = True
        '
        'txtCanSizeM
        '
        Me.txtCanSizeM.BackColor = System.Drawing.Color.White
        Me.txtCanSizeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanSizeM.Location = New System.Drawing.Point(136, 9)
        Me.txtCanSizeM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCanSizeM.Name = "txtCanSizeM"
        Me.txtCanSizeM.Size = New System.Drawing.Size(69, 32)
        Me.txtCanSizeM.TabIndex = 21
        '
        'lbCanSizeM
        '
        Me.lbCanSizeM.AutoSize = True
        Me.lbCanSizeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCanSizeM.Location = New System.Drawing.Point(19, 18)
        Me.lbCanSizeM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCanSizeM.Name = "lbCanSizeM"
        Me.lbCanSizeM.Size = New System.Drawing.Size(91, 20)
        Me.lbCanSizeM.TabIndex = 30
        Me.lbCanSizeM.Text = "Can Size:"
        '
        'lbCorrectionM
        '
        Me.lbCorrectionM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbCorrectionM.AutoSize = True
        Me.lbCorrectionM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrectionM.Location = New System.Drawing.Point(779, 129)
        Me.lbCorrectionM.Name = "lbCorrectionM"
        Me.lbCorrectionM.Size = New System.Drawing.Size(139, 29)
        Me.lbCorrectionM.TabIndex = 2
        Me.lbCorrectionM.Text = "Correction"
        Me.lbCorrectionM.Visible = False
        '
        'lbQuantityM
        '
        Me.lbQuantityM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbQuantityM.AutoSize = True
        Me.lbQuantityM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQuantityM.Location = New System.Drawing.Point(331, 128)
        Me.lbQuantityM.Name = "lbQuantityM"
        Me.lbQuantityM.Size = New System.Drawing.Size(115, 29)
        Me.lbQuantityM.TabIndex = 1
        Me.lbQuantityM.Text = "Quantity"
        '
        'lbcolorM
        '
        Me.lbcolorM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbcolorM.AutoSize = True
        Me.lbcolorM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcolorM.Location = New System.Drawing.Point(130, 129)
        Me.lbcolorM.Name = "lbcolorM"
        Me.lbcolorM.Size = New System.Drawing.Size(78, 29)
        Me.lbcolorM.TabIndex = 0
        Me.lbcolorM.Text = "Color"
        '
        'cmbEffectType
        '
        Me.cmbEffectType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEffectType.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEffectType.FormattingEnabled = True
        Me.cmbEffectType.Items.AddRange(New Object() {"Effect", "Solid"})
        Me.cmbEffectType.Location = New System.Drawing.Point(1306, 13)
        Me.cmbEffectType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEffectType.Name = "cmbEffectType"
        Me.cmbEffectType.Size = New System.Drawing.Size(243, 34)
        Me.cmbEffectType.TabIndex = 22
        '
        'lbEffectType
        '
        Me.lbEffectType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbEffectType.AutoSize = True
        Me.lbEffectType.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEffectType.Location = New System.Drawing.Point(1126, 17)
        Me.lbEffectType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbEffectType.Name = "lbEffectType"
        Me.lbEffectType.Size = New System.Drawing.Size(152, 29)
        Me.lbEffectType.TabIndex = 21
        Me.lbEffectType.Text = "Effect type:"
        '
        'butNucleosSettings
        '
        Me.butNucleosSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butNucleosSettings.BackgroundImage = Global.garageApp.My.Resources.Resources.settings_3110__2_
        Me.butNucleosSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butNucleosSettings.FlatAppearance.BorderSize = 0
        Me.butNucleosSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butNucleosSettings.Location = New System.Drawing.Point(1524, 89)
        Me.butNucleosSettings.Name = "butNucleosSettings"
        Me.butNucleosSettings.Size = New System.Drawing.Size(25, 20)
        Me.butNucleosSettings.TabIndex = 23
        Me.butNucleosSettings.UseVisualStyleBackColor = True
        '
        'pictGaragePic
        '
        Me.pictGaragePic.Location = New System.Drawing.Point(12, 11)
        Me.pictGaragePic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pictGaragePic.Name = "pictGaragePic"
        Me.pictGaragePic.Size = New System.Drawing.Size(372, 225)
        Me.pictGaragePic.TabIndex = 20
        Me.pictGaragePic.TabStop = False
        '
        'butDeleteHistoryJob
        '
        Me.butDeleteHistoryJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butDeleteHistoryJob.ForeColor = System.Drawing.Color.Red
        Me.butDeleteHistoryJob.Location = New System.Drawing.Point(159, 307)
        Me.butDeleteHistoryJob.Margin = New System.Windows.Forms.Padding(4)
        Me.butDeleteHistoryJob.Name = "butDeleteHistoryJob"
        Me.butDeleteHistoryJob.Size = New System.Drawing.Size(92, 36)
        Me.butDeleteHistoryJob.TabIndex = 22
        Me.butDeleteHistoryJob.Text = "Delete"
        Me.butDeleteHistoryJob.UseVisualStyleBackColor = True
        Me.butDeleteHistoryJob.Visible = False
        '
        'chkOldJobs
        '
        Me.chkOldJobs.AutoSize = True
        Me.chkOldJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOldJobs.Location = New System.Drawing.Point(258, 319)
        Me.chkOldJobs.Name = "chkOldJobs"
        Me.chkOldJobs.Size = New System.Drawing.Size(126, 20)
        Me.chkOldJobs.TabIndex = 24
        Me.chkOldJobs.Text = "Show old jobs"
        Me.chkOldJobs.UseVisualStyleBackColor = True
        '
        'NucleosSearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1572, 923)
        Me.Controls.Add(Me.butDeleteHistoryJob)
        Me.Controls.Add(Me.chkOldJobs)
        Me.Controls.Add(Me.butNucleosSettings)
        Me.Controls.Add(Me.cmbEffectType)
        Me.Controls.Add(Me.lbEffectType)
        Me.Controls.Add(Me.pictGaragePic)
        Me.Controls.Add(Me.tbControl)
        Me.Controls.Add(Me.cmbCoats)
        Me.Controls.Add(Me.lbCoat)
        Me.Controls.Add(Me.jobRGB6)
        Me.Controls.Add(Me.jobRGB5)
        Me.Controls.Add(Me.jobRGB4)
        Me.Controls.Add(Me.jobRGB3)
        Me.Controls.Add(Me.jobRGB2)
        Me.Controls.Add(Me.jobRGB1)
        Me.Controls.Add(Me.txtChosenJob)
        Me.Controls.Add(Me.lbChosenJob)
        Me.Controls.Add(Me.lbJobs)
        Me.Controls.Add(Me.lstbJobs)
        Me.Controls.Add(Me.butGetJobs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NucleosSearchForm"
        Me.Text = "NucleosSearchForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tbControl.ResumeLayout(False)
        Me.tbSearchResult.ResumeLayout(False)
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDetails.ResumeLayout(False)
        Me.tbDetails.PerformLayout()
        Me.grpIngredients.ResumeLayout(False)
        Me.pnlResult.ResumeLayout(False)
        Me.pnlResult.PerformLayout()
        Me.tbMeasuring.ResumeLayout(False)
        Me.tbMeasuring.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlResultM.ResumeLayout(False)
        Me.pnlResultM.PerformLayout()
        CType(Me.pictGaragePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butGetJobs As System.Windows.Forms.Button
    Friend WithEvents lstbJobs As System.Windows.Forms.ListBox
    Friend WithEvents lbJobs As System.Windows.Forms.Label
    Friend WithEvents lbChosenJob As System.Windows.Forms.Label
    Friend WithEvents txtChosenJob As System.Windows.Forms.TextBox
    Friend WithEvents lstvSearchResult As System.Windows.Forms.ListView
    Friend WithEvents butSearch As System.Windows.Forms.Button
    Friend WithEvents butSetLab As Button
    Friend WithEvents jobRGB1 As Label
    Friend WithEvents sampleId As ColumnHeader
    Friend WithEvents sampleName As ColumnHeader
    Friend WithEvents merit As ColumnHeader
    Friend WithEvents color As ColumnHeader
    Friend WithEvents jobRGB2 As Label
    Friend WithEvents jobRGB4 As Label
    Friend WithEvents jobRGB3 As Label
    Friend WithEvents jobRGB6 As Label
    Friend WithEvents jobRGB5 As Label
    Friend WithEvents lbCoat As Label
    Friend WithEvents cmbCoats As ComboBox
    Friend WithEvents tbControl As TabControl
    Friend WithEvents tbSearchResult As TabPage
    Friend WithEvents tbDetails As TabPage
    Friend WithEvents lbTrial As Label
    Friend WithEvents pnTrial1 As Panel
    Friend WithEvents pnCorrectedWhite1 As Panel
    Friend WithEvents lbSampleId As Label
    Friend WithEvents btnOriginal As Button
    Friend WithEvents btnCorrection As Button
    Friend WithEvents lbTarget As Label
    Friend WithEvents pnTarget1 As Panel
    Friend WithEvents grpIngredients As GroupBox
    Friend WithEvents pnlResult As Panel
    Friend WithEvents lbCorrection As Label
    Friend WithEvents lbQuantity As Label
    Friend WithEvents lbColor As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnMeasure As Button
    Friend WithEvents pictGaragePic As PictureBox
    Friend WithEvents effect As ColumnHeader
    Friend WithEvents autoCorrectedScore As ColumnHeader
    Friend WithEvents lbWhiteBg As Label
    Friend WithEvents lbBlackBg As Label
    Friend WithEvents pnCorrectedBlack1 As Panel
    Friend WithEvents pnTrial6 As Panel
    Friend WithEvents pnTrial3 As Panel
    Friend WithEvents pnTrial5 As Panel
    Friend WithEvents pnTrial2 As Panel
    Friend WithEvents pnTrial4 As Panel
    Friend WithEvents pnTarget6 As Panel
    Friend WithEvents pnTarget3 As Panel
    Friend WithEvents pnTarget5 As Panel
    Friend WithEvents pnTarget4 As Panel
    Friend WithEvents pnTarget2 As Panel
    Friend WithEvents pnCorrectedWhite3 As Panel
    Friend WithEvents pnCorrectedWhite2 As Panel
    Friend WithEvents pnCorrectedBlack2 As Panel
    Friend WithEvents pnCorrectedWhite6 As Panel
    Friend WithEvents pnCorrectedBlack6 As Panel
    Friend WithEvents pnCorrectedWhite5 As Panel
    Friend WithEvents pnCorrectedBlack3 As Panel
    Friend WithEvents pnCorrectedWhite4 As Panel
    Friend WithEvents pnCorrectedBlack5 As Panel
    Friend WithEvents pnCorrectedBlack4 As Panel
    Friend WithEvents coarseness As ColumnHeader
    Friend WithEvents lbG As Label
    Friend WithEvents txtCanSize As TextBox
    Friend WithEvents lbCanSize As Label
    Friend WithEvents lbAccumulation As Label
    Friend WithEvents lbOriginalScoreValue As Label
    Friend WithEvents lbOriginalScore As Label
    Friend WithEvents tbMeasuring As TabPage
    Friend WithEvents btnRemeasure As Button
    Friend WithEvents lbMScoreValue As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnlResultM As Panel
    Friend WithEvents lbAccumulationM As Label
    Friend WithEvents lbGM As Label
    Friend WithEvents txtCanSizeM As TextBox
    Friend WithEvents lbCanSizeM As Label
    Friend WithEvents lbCorrectionM As Label
    Friend WithEvents lbQuantityM As Label
    Friend WithEvents lbcolorM As Label
    Friend WithEvents btnBackFromM As Button
    Friend WithEvents lbSampleIdM As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents butCoat2 As Button
    Friend WithEvents butCoat1 As Button
    Friend WithEvents tricoat As ColumnHeader
    Friend WithEvents butCoat2m As Button
    Friend WithEvents butCoat1m As Button
    Friend WithEvents butListCorrection As Button
    Friend WithEvents cmbEffectType As ComboBox
    Friend WithEvents lbEffectType As Label
    Friend WithEvents butNucleosSettings As Button
    Friend WithEvents lbCorrectedScoreValue As Label
    Friend WithEvents lbCorrectedScore As Label
    Friend WithEvents chkOldJobs As CheckBox
    Friend WithEvents butDeleteHistoryJob As Button
    Friend WithEvents prgSearch As ProgressBar
    Friend WithEvents pbLoading As PictureBox
End Class
