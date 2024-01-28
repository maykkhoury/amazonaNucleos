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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NucleosSearchForm))
        Me.butGetJobs = New System.Windows.Forms.Button()
        Me.lstbJobs = New System.Windows.Forms.ListBox()
        Me.lbJobs = New System.Windows.Forms.Label()
        Me.lbChosenJob = New System.Windows.Forms.Label()
        Me.txtChosenJob = New System.Windows.Forms.TextBox()
        Me.lbEffectType = New System.Windows.Forms.Label()
        Me.cmbEffectType = New System.Windows.Forms.ComboBox()
        Me.lstvSearchResult = New System.Windows.Forms.ListView()
        Me.sampleId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sampleName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.merit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.autoCorrectedScore = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.effect = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.coarseness = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.tbDetails = New System.Windows.Forms.TabPage()
        Me.lbScoreValue = New System.Windows.Forms.Label()
        Me.lbScoreLabel = New System.Windows.Forms.Label()
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
        Me.lbSampleIdLabel = New System.Windows.Forms.Label()
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.pictGaragePic = New System.Windows.Forms.PictureBox()
        Me.tbControl.SuspendLayout()
        Me.tbSearchResult.SuspendLayout()
        Me.tbDetails.SuspendLayout()
        Me.grpIngredients.SuspendLayout()
        Me.pnlResult.SuspendLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictGaragePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butGetJobs
        '
        Me.butGetJobs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butGetJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butGetJobs.Location = New System.Drawing.Point(16, 839)
        Me.butGetJobs.Margin = New System.Windows.Forms.Padding(4)
        Me.butGetJobs.Name = "butGetJobs"
        Me.butGetJobs.Size = New System.Drawing.Size(325, 71)
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
        Me.lstbJobs.Location = New System.Drawing.Point(16, 355)
        Me.lstbJobs.Margin = New System.Windows.Forms.Padding(4)
        Me.lstbJobs.Name = "lstbJobs"
        Me.lstbJobs.Size = New System.Drawing.Size(325, 439)
        Me.lstbJobs.TabIndex = 2
        '
        'lbJobs
        '
        Me.lbJobs.AutoSize = True
        Me.lbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbJobs.Location = New System.Drawing.Point(14, 309)
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
        Me.txtChosenJob.Location = New System.Drawing.Point(571, 7)
        Me.txtChosenJob.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChosenJob.Name = "txtChosenJob"
        Me.txtChosenJob.ReadOnly = True
        Me.txtChosenJob.Size = New System.Drawing.Size(168, 32)
        Me.txtChosenJob.TabIndex = 5
        '
        'lbEffectType
        '
        Me.lbEffectType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbEffectType.AutoSize = True
        Me.lbEffectType.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEffectType.Location = New System.Drawing.Point(1124, 11)
        Me.lbEffectType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbEffectType.Name = "lbEffectType"
        Me.lbEffectType.Size = New System.Drawing.Size(152, 29)
        Me.lbEffectType.TabIndex = 6
        Me.lbEffectType.Text = "Effect type:"
        '
        'cmbEffectType
        '
        Me.cmbEffectType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEffectType.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEffectType.FormattingEnabled = True
        Me.cmbEffectType.Items.AddRange(New Object() {"Unspecified", "Solid", "Effect"})
        Me.cmbEffectType.Location = New System.Drawing.Point(1304, 7)
        Me.cmbEffectType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEffectType.Name = "cmbEffectType"
        Me.cmbEffectType.Size = New System.Drawing.Size(243, 34)
        Me.cmbEffectType.TabIndex = 7
        '
        'lstvSearchResult
        '
        Me.lstvSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstvSearchResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.sampleId, Me.sampleName, Me.merit, Me.autoCorrectedScore, Me.effect, Me.coarseness, Me.color})
        Me.lstvSearchResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvSearchResult.FullRowSelect = True
        Me.lstvSearchResult.GridLines = True
        Me.lstvSearchResult.HideSelection = False
        Me.lstvSearchResult.HoverSelection = True
        Me.lstvSearchResult.Location = New System.Drawing.Point(4, 4)
        Me.lstvSearchResult.Margin = New System.Windows.Forms.Padding(4)
        Me.lstvSearchResult.Name = "lstvSearchResult"
        Me.lstvSearchResult.Size = New System.Drawing.Size(1139, 718)
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
        'color
        '
        Me.color.Text = "Color"
        Me.color.Width = 400
        '
        'butSearch
        '
        Me.butSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSearch.Location = New System.Drawing.Point(9, 743)
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
        Me.butSetLab.Location = New System.Drawing.Point(364, 743)
        Me.butSetLab.Margin = New System.Windows.Forms.Padding(4)
        Me.butSetLab.Name = "butSetLab"
        Me.butSetLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butSetLab.Size = New System.Drawing.Size(325, 71)
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
        Me.jobRGB1.Location = New System.Drawing.Point(747, 11)
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
        Me.jobRGB2.Location = New System.Drawing.Point(773, 11)
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
        Me.jobRGB4.Location = New System.Drawing.Point(825, 11)
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
        Me.jobRGB3.Location = New System.Drawing.Point(799, 11)
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
        Me.jobRGB6.Location = New System.Drawing.Point(877, 11)
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
        Me.jobRGB5.Location = New System.Drawing.Point(851, 11)
        Me.jobRGB5.Name = "jobRGB5"
        Me.jobRGB5.Size = New System.Drawing.Size(20, 29)
        Me.jobRGB5.TabIndex = 15
        Me.jobRGB5.Text = " "
        '
        'lbCoat
        '
        Me.lbCoat.AutoSize = True
        Me.lbCoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCoat.Location = New System.Drawing.Point(14, 260)
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
        Me.cmbCoats.Items.AddRange(New Object() {"LS", "BC/2K"})
        Me.cmbCoats.Location = New System.Drawing.Point(98, 259)
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
        Me.tbControl.Location = New System.Drawing.Point(396, 61)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(1158, 850)
        Me.tbControl.TabIndex = 19
        '
        'tbSearchResult
        '
        Me.tbSearchResult.Controls.Add(Me.lstvSearchResult)
        Me.tbSearchResult.Controls.Add(Me.butSetLab)
        Me.tbSearchResult.Controls.Add(Me.butSearch)
        Me.tbSearchResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchResult.Location = New System.Drawing.Point(4, 25)
        Me.tbSearchResult.Name = "tbSearchResult"
        Me.tbSearchResult.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSearchResult.Size = New System.Drawing.Size(1150, 821)
        Me.tbSearchResult.TabIndex = 0
        Me.tbSearchResult.Text = "Search Result"
        Me.tbSearchResult.UseVisualStyleBackColor = True
        '
        'tbDetails
        '
        Me.tbDetails.Controls.Add(Me.lbScoreValue)
        Me.tbDetails.Controls.Add(Me.lbScoreLabel)
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
        Me.tbDetails.Controls.Add(Me.lbSampleIdLabel)
        Me.tbDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDetails.Location = New System.Drawing.Point(4, 25)
        Me.tbDetails.Name = "tbDetails"
        Me.tbDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDetails.Size = New System.Drawing.Size(1150, 821)
        Me.tbDetails.TabIndex = 1
        Me.tbDetails.Text = "Details"
        Me.tbDetails.UseVisualStyleBackColor = True
        '
        'lbScoreValue
        '
        Me.lbScoreValue.AutoSize = True
        Me.lbScoreValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbScoreValue.ForeColor = System.Drawing.Color.Cyan
        Me.lbScoreValue.Location = New System.Drawing.Point(549, 42)
        Me.lbScoreValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbScoreValue.Name = "lbScoreValue"
        Me.lbScoreValue.Size = New System.Drawing.Size(28, 29)
        Me.lbScoreValue.TabIndex = 31
        Me.lbScoreValue.Text = "0"
        '
        'lbScoreLabel
        '
        Me.lbScoreLabel.AutoSize = True
        Me.lbScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbScoreLabel.Location = New System.Drawing.Point(463, 42)
        Me.lbScoreLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbScoreLabel.Name = "lbScoreLabel"
        Me.lbScoreLabel.Size = New System.Drawing.Size(86, 29)
        Me.lbScoreLabel.TabIndex = 30
        Me.lbScoreLabel.Text = "Score:"
        '
        'pnCorrectedWhite6
        '
        Me.pnCorrectedWhite6.Location = New System.Drawing.Point(164, 613)
        Me.pnCorrectedWhite6.Name = "pnCorrectedWhite6"
        Me.pnCorrectedWhite6.Size = New System.Drawing.Size(51, 32)
        Me.pnCorrectedWhite6.TabIndex = 20
        Me.pnCorrectedWhite6.Visible = False
        '
        'pnCorrectedBlack6
        '
        Me.pnCorrectedBlack6.Location = New System.Drawing.Point(221, 611)
        Me.pnCorrectedBlack6.Name = "pnCorrectedBlack6"
        Me.pnCorrectedBlack6.Size = New System.Drawing.Size(51, 34)
        Me.pnCorrectedBlack6.TabIndex = 20
        Me.pnCorrectedBlack6.Visible = False
        '
        'pnCorrectedWhite5
        '
        Me.pnCorrectedWhite5.Location = New System.Drawing.Point(164, 576)
        Me.pnCorrectedWhite5.Name = "pnCorrectedWhite5"
        Me.pnCorrectedWhite5.Size = New System.Drawing.Size(51, 32)
        Me.pnCorrectedWhite5.TabIndex = 21
        Me.pnCorrectedWhite5.Visible = False
        '
        'pnCorrectedBlack3
        '
        Me.pnCorrectedBlack3.Location = New System.Drawing.Point(221, 500)
        Me.pnCorrectedBlack3.Name = "pnCorrectedBlack3"
        Me.pnCorrectedBlack3.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedBlack3.TabIndex = 19
        Me.pnCorrectedBlack3.Visible = False
        '
        'pnCorrectedWhite4
        '
        Me.pnCorrectedWhite4.Location = New System.Drawing.Point(164, 538)
        Me.pnCorrectedWhite4.Name = "pnCorrectedWhite4"
        Me.pnCorrectedWhite4.Size = New System.Drawing.Size(51, 32)
        Me.pnCorrectedWhite4.TabIndex = 22
        Me.pnCorrectedWhite4.Visible = False
        '
        'pnCorrectedBlack5
        '
        Me.pnCorrectedBlack5.Location = New System.Drawing.Point(221, 574)
        Me.pnCorrectedBlack5.Name = "pnCorrectedBlack5"
        Me.pnCorrectedBlack5.Size = New System.Drawing.Size(51, 34)
        Me.pnCorrectedBlack5.TabIndex = 21
        Me.pnCorrectedBlack5.Visible = False
        '
        'pnCorrectedBlack2
        '
        Me.pnCorrectedBlack2.Location = New System.Drawing.Point(221, 461)
        Me.pnCorrectedBlack2.Name = "pnCorrectedBlack2"
        Me.pnCorrectedBlack2.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedBlack2.TabIndex = 19
        Me.pnCorrectedBlack2.Visible = False
        '
        'btnOriginal
        '
        Me.btnOriginal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOriginal.Location = New System.Drawing.Point(896, 8)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New System.Drawing.Size(240, 76)
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
        Me.pnCorrectedBlack4.Name = "pnCorrectedBlack4"
        Me.pnCorrectedBlack4.Size = New System.Drawing.Size(51, 31)
        Me.pnCorrectedBlack4.TabIndex = 22
        Me.pnCorrectedBlack4.Visible = False
        '
        'pnTrial6
        '
        Me.pnTrial6.Location = New System.Drawing.Point(221, 334)
        Me.pnTrial6.Name = "pnTrial6"
        Me.pnTrial6.Size = New System.Drawing.Size(140, 42)
        Me.pnTrial6.TabIndex = 21
        '
        'pnTrial4
        '
        Me.pnTrial4.Location = New System.Drawing.Point(221, 239)
        Me.pnTrial4.Name = "pnTrial4"
        Me.pnTrial4.Size = New System.Drawing.Size(140, 42)
        Me.pnTrial4.TabIndex = 19
        '
        'pnTrial5
        '
        Me.pnTrial5.Location = New System.Drawing.Point(221, 287)
        Me.pnTrial5.Name = "pnTrial5"
        Me.pnTrial5.Size = New System.Drawing.Size(140, 41)
        Me.pnTrial5.TabIndex = 20
        '
        'pnTrial1
        '
        Me.pnTrial1.Location = New System.Drawing.Point(221, 100)
        Me.pnTrial1.Name = "pnTrial1"
        Me.pnTrial1.Size = New System.Drawing.Size(140, 40)
        Me.pnTrial1.TabIndex = 17
        '
        'pnCorrectedWhite3
        '
        Me.pnCorrectedWhite3.Location = New System.Drawing.Point(164, 500)
        Me.pnCorrectedWhite3.Name = "pnCorrectedWhite3"
        Me.pnCorrectedWhite3.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedWhite3.TabIndex = 19
        Me.pnCorrectedWhite3.Visible = False
        '
        'pnTrial3
        '
        Me.pnTrial3.Location = New System.Drawing.Point(221, 195)
        Me.pnTrial3.Name = "pnTrial3"
        Me.pnTrial3.Size = New System.Drawing.Size(140, 37)
        Me.pnTrial3.TabIndex = 18
        '
        'pnTrial2
        '
        Me.pnTrial2.Location = New System.Drawing.Point(221, 146)
        Me.pnTrial2.Name = "pnTrial2"
        Me.pnTrial2.Size = New System.Drawing.Size(140, 40)
        Me.pnTrial2.TabIndex = 18
        '
        'pnCorrectedWhite2
        '
        Me.pnCorrectedWhite2.Location = New System.Drawing.Point(164, 461)
        Me.pnCorrectedWhite2.Name = "pnCorrectedWhite2"
        Me.pnCorrectedWhite2.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedWhite2.TabIndex = 19
        Me.pnCorrectedWhite2.Visible = False
        '
        'pnTarget6
        '
        Me.pnTarget6.Location = New System.Drawing.Point(81, 334)
        Me.pnTarget6.Name = "pnTarget6"
        Me.pnTarget6.Size = New System.Drawing.Size(134, 42)
        Me.pnTarget6.TabIndex = 28
        '
        'pnTarget3
        '
        Me.pnTarget3.Location = New System.Drawing.Point(81, 192)
        Me.pnTarget3.Name = "pnTarget3"
        Me.pnTarget3.Size = New System.Drawing.Size(134, 40)
        Me.pnTarget3.TabIndex = 25
        '
        'pnTarget5
        '
        Me.pnTarget5.Location = New System.Drawing.Point(81, 286)
        Me.pnTarget5.Name = "pnTarget5"
        Me.pnTarget5.Size = New System.Drawing.Size(134, 42)
        Me.pnTarget5.TabIndex = 27
        '
        'pnTarget4
        '
        Me.pnTarget4.Location = New System.Drawing.Point(81, 238)
        Me.pnTarget4.Name = "pnTarget4"
        Me.pnTarget4.Size = New System.Drawing.Size(134, 42)
        Me.pnTarget4.TabIndex = 26
        '
        'pnTarget2
        '
        Me.pnTarget2.Location = New System.Drawing.Point(81, 146)
        Me.pnTarget2.Name = "pnTarget2"
        Me.pnTarget2.Size = New System.Drawing.Size(134, 40)
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
        Me.pnCorrectedBlack1.Name = "pnCorrectedBlack1"
        Me.pnCorrectedBlack1.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedBlack1.TabIndex = 19
        Me.pnCorrectedBlack1.Visible = False
        '
        'lbWhiteBg
        '
        Me.lbWhiteBg.AutoSize = True
        Me.lbWhiteBg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbWhiteBg.Location = New System.Drawing.Point(14, 390)
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
        Me.btnMeasure.Location = New System.Drawing.Point(18, 651)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(401, 76)
        Me.btnMeasure.TabIndex = 27
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        Me.btnMeasure.Visible = False
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(18, 739)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(401, 76)
        Me.btnBack.TabIndex = 26
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lbTarget
        '
        Me.lbTarget.AutoSize = True
        Me.lbTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTarget.Location = New System.Drawing.Point(114, 64)
        Me.lbTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTarget.Name = "lbTarget"
        Me.lbTarget.Size = New System.Drawing.Size(63, 20)
        Me.lbTarget.TabIndex = 25
        Me.lbTarget.Text = "Target"
        '
        'pnTarget1
        '
        Me.pnTarget1.Location = New System.Drawing.Point(81, 100)
        Me.pnTarget1.Name = "pnTarget1"
        Me.pnTarget1.Size = New System.Drawing.Size(134, 40)
        Me.pnTarget1.TabIndex = 24
        '
        'grpIngredients
        '
        Me.grpIngredients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpIngredients.Controls.Add(Me.pnlResult)
        Me.grpIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpIngredients.Location = New System.Drawing.Point(462, 90)
        Me.grpIngredients.Name = "grpIngredients"
        Me.grpIngredients.Size = New System.Drawing.Size(680, 725)
        Me.grpIngredients.TabIndex = 23
        Me.grpIngredients.TabStop = False
        '
        'pnlResult
        '
        Me.pnlResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlResult.Controls.Add(Me.lbAccumulation)
        Me.pnlResult.Controls.Add(Me.lbG)
        Me.pnlResult.Controls.Add(Me.txtCanSize)
        Me.pnlResult.Controls.Add(Me.lbCanSize)
        Me.pnlResult.Controls.Add(Me.lbCorrection)
        Me.pnlResult.Controls.Add(Me.lbQuantity)
        Me.pnlResult.Controls.Add(Me.lbColor)
        Me.pnlResult.Location = New System.Drawing.Point(6, 21)
        Me.pnlResult.Name = "pnlResult"
        Me.pnlResult.Size = New System.Drawing.Size(668, 598)
        Me.pnlResult.TabIndex = 0
        '
        'lbAccumulation
        '
        Me.lbAccumulation.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbAccumulation.AutoSize = True
        Me.lbAccumulation.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAccumulation.Location = New System.Drawing.Point(325, 110)
        Me.lbAccumulation.Name = "lbAccumulation"
        Me.lbAccumulation.Size = New System.Drawing.Size(179, 29)
        Me.lbAccumulation.TabIndex = 32
        Me.lbAccumulation.Text = "Accumulation"
        '
        'lbG
        '
        Me.lbG.AutoSize = True
        Me.lbG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbG.Location = New System.Drawing.Point(194, 19)
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
        Me.txtCanSize.Location = New System.Drawing.Point(117, 11)
        Me.txtCanSize.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCanSize.Name = "txtCanSize"
        Me.txtCanSize.Size = New System.Drawing.Size(69, 32)
        Me.txtCanSize.TabIndex = 21
        '
        'lbCanSize
        '
        Me.lbCanSize.AutoSize = True
        Me.lbCanSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCanSize.Location = New System.Drawing.Point(18, 19)
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
        Me.lbCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrection.Location = New System.Drawing.Point(518, 112)
        Me.lbCorrection.Name = "lbCorrection"
        Me.lbCorrection.Size = New System.Drawing.Size(139, 29)
        Me.lbCorrection.TabIndex = 2
        Me.lbCorrection.Text = "Correction"
        Me.lbCorrection.Visible = False
        '
        'lbQuantity
        '
        Me.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbQuantity.AutoSize = True
        Me.lbQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQuantity.Location = New System.Drawing.Point(193, 110)
        Me.lbQuantity.Name = "lbQuantity"
        Me.lbQuantity.Size = New System.Drawing.Size(115, 29)
        Me.lbQuantity.TabIndex = 1
        Me.lbQuantity.Text = "Quantity"
        '
        'lbColor
        '
        Me.lbColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbColor.AutoSize = True
        Me.lbColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbColor.Location = New System.Drawing.Point(41, 110)
        Me.lbColor.Name = "lbColor"
        Me.lbColor.Size = New System.Drawing.Size(78, 29)
        Me.lbColor.TabIndex = 0
        Me.lbColor.Text = "Color"
        '
        'btnCorrection
        '
        Me.btnCorrection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCorrection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorrection.ForeColor = System.Drawing.Color.Cyan
        Me.btnCorrection.Location = New System.Drawing.Point(653, 8)
        Me.btnCorrection.Name = "btnCorrection"
        Me.btnCorrection.Size = New System.Drawing.Size(240, 76)
        Me.btnCorrection.TabIndex = 21
        Me.btnCorrection.Text = "Auto Correction"
        Me.btnCorrection.UseVisualStyleBackColor = True
        '
        'pnCorrectedWhite1
        '
        Me.pnCorrectedWhite1.Location = New System.Drawing.Point(164, 422)
        Me.pnCorrectedWhite1.Name = "pnCorrectedWhite1"
        Me.pnCorrectedWhite1.Size = New System.Drawing.Size(51, 33)
        Me.pnCorrectedWhite1.TabIndex = 18
        Me.pnCorrectedWhite1.Visible = False
        '
        'lbSampleId
        '
        Me.lbSampleId.AutoSize = True
        Me.lbSampleId.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSampleId.Location = New System.Drawing.Point(169, 8)
        Me.lbSampleId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSampleId.Name = "lbSampleId"
        Me.lbSampleId.Size = New System.Drawing.Size(150, 29)
        Me.lbSampleId.TabIndex = 16
        Me.lbSampleId.Text = "lbSampleId"
        '
        'lbSampleIdLabel
        '
        Me.lbSampleIdLabel.AutoSize = True
        Me.lbSampleIdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSampleIdLabel.Location = New System.Drawing.Point(7, 8)
        Me.lbSampleIdLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSampleIdLabel.Name = "lbSampleIdLabel"
        Me.lbSampleIdLabel.Size = New System.Drawing.Size(138, 29)
        Me.lbSampleIdLabel.TabIndex = 15
        Me.lbSampleIdLabel.Text = "Sample ID:"
        '
        'VisualStyler1
        '
        Me.VisualStyler1.HostForm = Me
        Me.VisualStyler1.License = CType(resources.GetObject("VisualStyler1.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler1.LoadVisualStyle(Nothing, "CORE (BLACK).vssf")
        '
        'pictGaragePic
        '
        Me.pictGaragePic.Location = New System.Drawing.Point(12, 11)
        Me.pictGaragePic.Name = "pictGaragePic"
        Me.pictGaragePic.Size = New System.Drawing.Size(372, 225)
        Me.pictGaragePic.TabIndex = 20
        Me.pictGaragePic.TabStop = False
        '
        'NucleosSearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1572, 923)
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
        Me.Controls.Add(Me.cmbEffectType)
        Me.Controls.Add(Me.lbEffectType)
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
        Me.tbDetails.ResumeLayout(False)
        Me.tbDetails.PerformLayout()
        Me.grpIngredients.ResumeLayout(False)
        Me.pnlResult.ResumeLayout(False)
        Me.pnlResult.PerformLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictGaragePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butGetJobs As System.Windows.Forms.Button
    Friend WithEvents lstbJobs As System.Windows.Forms.ListBox
    Friend WithEvents lbJobs As System.Windows.Forms.Label
    Friend WithEvents lbChosenJob As System.Windows.Forms.Label
    Friend WithEvents txtChosenJob As System.Windows.Forms.TextBox
    Friend WithEvents lbEffectType As System.Windows.Forms.Label
    Friend WithEvents cmbEffectType As System.Windows.Forms.ComboBox
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
    Friend WithEvents lbSampleIdLabel As Label
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
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
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
    Friend WithEvents lbScoreValue As Label
    Friend WithEvents lbScoreLabel As Label
End Class
