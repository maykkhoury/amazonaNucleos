<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class carCodeLocator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(carCodeLocator))
        Me.cclTitle = New System.Windows.Forms.Label()
        Me.cclCancelBtn = New System.Windows.Forms.Button()
        Me.pctCodeLoc = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pctCarImg = New System.Windows.Forms.PictureBox()
        Me.cmbYearCL = New System.Windows.Forms.ComboBox()
        Me.cmbModelCL = New System.Windows.Forms.ComboBox()
        Me.cmbCarCL = New System.Windows.Forms.ComboBox()
        Me.lbYearCL = New garageApp.TranslatedLabel()
        Me.lbModelCL = New garageApp.TranslatedLabel()
        Me.lbCarCL = New garageApp.TranslatedLabel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.butSearchCl = New garageApp.MyButton()
        CType(Me.pctCodeLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.pctCarImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cclTitle
        '
        Me.cclTitle.AutoSize = True
        Me.cclTitle.Location = New System.Drawing.Point(17, 10)
        Me.cclTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.cclTitle.Name = "cclTitle"
        Me.cclTitle.Size = New System.Drawing.Size(48, 16)
        Me.cclTitle.TabIndex = 4
        Me.cclTitle.Text = "Label1"
        '
        'cclCancelBtn
        '
        Me.cclCancelBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cclCancelBtn.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cclCancelBtn.ForeColor = System.Drawing.Color.Red
        Me.cclCancelBtn.Location = New System.Drawing.Point(0, 587)
        Me.cclCancelBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.cclCancelBtn.Name = "cclCancelBtn"
        Me.cclCancelBtn.Size = New System.Drawing.Size(619, 48)
        Me.cclCancelBtn.TabIndex = 6
        Me.cclCancelBtn.Text = "Close"
        Me.cclCancelBtn.UseVisualStyleBackColor = True
        '
        'pctCodeLoc
        '
        Me.pctCodeLoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pctCodeLoc.Image = CType(resources.GetObject("pctCodeLoc.Image"), System.Drawing.Image)
        Me.pctCodeLoc.Location = New System.Drawing.Point(4, 2)
        Me.pctCodeLoc.Margin = New System.Windows.Forms.Padding(4)
        Me.pctCodeLoc.Name = "pctCodeLoc"
        Me.pctCodeLoc.Size = New System.Drawing.Size(609, 564)
        Me.pctCodeLoc.TabIndex = 0
        Me.pctCodeLoc.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pctCarImg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbYearCL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbModelCL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbCarCL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbYearCL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbModelCL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbCarCL)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1320, 692)
        Me.SplitContainer1.SplitterDistance = 694
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 7
        '
        'pctCarImg
        '
        Me.pctCarImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pctCarImg.Location = New System.Drawing.Point(16, 187)
        Me.pctCarImg.Margin = New System.Windows.Forms.Padding(4)
        Me.pctCarImg.Name = "pctCarImg"
        Me.pctCarImg.Size = New System.Drawing.Size(656, 493)
        Me.pctCarImg.TabIndex = 180
        Me.pctCarImg.TabStop = False
        '
        'cmbYearCL
        '
        Me.cmbYearCL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbYearCL.DropDownHeight = 400
        Me.cmbYearCL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYearCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYearCL.FormattingEnabled = True
        Me.cmbYearCL.IntegralHeight = False
        Me.cmbYearCL.Location = New System.Drawing.Point(124, 133)
        Me.cmbYearCL.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbYearCL.Name = "cmbYearCL"
        Me.cmbYearCL.Size = New System.Drawing.Size(549, 40)
        Me.cmbYearCL.TabIndex = 178
        '
        'cmbModelCL
        '
        Me.cmbModelCL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbModelCL.DropDownHeight = 400
        Me.cmbModelCL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModelCL.FormattingEnabled = True
        Me.cmbModelCL.IntegralHeight = False
        Me.cmbModelCL.Location = New System.Drawing.Point(124, 71)
        Me.cmbModelCL.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbModelCL.Name = "cmbModelCL"
        Me.cmbModelCL.Size = New System.Drawing.Size(549, 40)
        Me.cmbModelCL.TabIndex = 177
        '
        'cmbCarCL
        '
        Me.cmbCarCL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCarCL.DropDownHeight = 400
        Me.cmbCarCL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCarCL.FormattingEnabled = True
        Me.cmbCarCL.IntegralHeight = False
        Me.cmbCarCL.Location = New System.Drawing.Point(124, 10)
        Me.cmbCarCL.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbCarCL.Name = "cmbCarCL"
        Me.cmbCarCL.Size = New System.Drawing.Size(549, 40)
        Me.cmbCarCL.TabIndex = 176
        '
        'lbYearCL
        '
        Me.lbYearCL.AutoSize = True
        Me.lbYearCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbYearCL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbYearCL.Location = New System.Drawing.Point(19, 149)
        Me.lbYearCL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbYearCL.Name = "lbYearCL"
        Me.lbYearCL.Size = New System.Drawing.Size(53, 20)
        Me.lbYearCL.TabIndex = 175
        Me.lbYearCL.Text = "Year:"
        '
        'lbModelCL
        '
        Me.lbModelCL.AutoSize = True
        Me.lbModelCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbModelCL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbModelCL.Location = New System.Drawing.Point(19, 87)
        Me.lbModelCL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbModelCL.Name = "lbModelCL"
        Me.lbModelCL.Size = New System.Drawing.Size(65, 20)
        Me.lbModelCL.TabIndex = 174
        Me.lbModelCL.Text = "Model:"
        '
        'lbCarCL
        '
        Me.lbCarCL.AutoSize = True
        Me.lbCarCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCarCL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCarCL.Location = New System.Drawing.Point(19, 26)
        Me.lbCarCL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCarCL.Name = "lbCarCL"
        Me.lbCarCL.Size = New System.Drawing.Size(45, 20)
        Me.lbCarCL.TabIndex = 173
        Me.lbCarCL.Text = "Car:"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.butSearchCl)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.pctCodeLoc)
        Me.SplitContainer2.Panel2.Controls.Add(Me.cclCancelBtn)
        Me.SplitContainer2.Size = New System.Drawing.Size(619, 690)
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 7
        '
        'butSearchCl
        '
        Me.butSearchCl.AccessibleDescription = "555"
        Me.butSearchCl.BackColor = System.Drawing.SystemColors.Control
        Me.butSearchCl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butSearchCl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSearchCl.ForeColor = System.Drawing.Color.Green
        Me.butSearchCl.Location = New System.Drawing.Point(0, 0)
        Me.butSearchCl.Margin = New System.Windows.Forms.Padding(4)
        Me.butSearchCl.Name = "butSearchCl"
        Me.butSearchCl.Size = New System.Drawing.Size(619, 50)
        Me.butSearchCl.TabIndex = 179
        Me.butSearchCl.Text = "Search"
        Me.butSearchCl.UseVisualStyleBackColor = False
        '
        'carCodeLocator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1320, 692)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cclTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1335, 728)
        Me.Name = "carCodeLocator"
        Me.Text = "Color Code Locator"
        CType(Me.pctCodeLoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.pctCarImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cclTitle As System.Windows.Forms.Label
    Friend WithEvents cclCancelBtn As System.Windows.Forms.Button
    Friend WithEvents pctCodeLoc As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbYearCL As garageApp.TranslatedLabel
    Friend WithEvents lbModelCL As garageApp.TranslatedLabel
    Friend WithEvents lbCarCL As garageApp.TranslatedLabel
    Friend WithEvents cmbCarCL As System.Windows.Forms.ComboBox
    Friend WithEvents cmbModelCL As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYearCL As System.Windows.Forms.ComboBox
    Friend WithEvents butSearchCl As garageApp.MyButton
    Friend WithEvents pctCarImg As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer

End Class
