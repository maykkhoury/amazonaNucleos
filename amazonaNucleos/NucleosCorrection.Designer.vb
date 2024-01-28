<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NucleosCorrection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpIngredients = New System.Windows.Forms.GroupBox()
        Me.pnlResult = New System.Windows.Forms.Panel()
        Me.lbCorrection = New System.Windows.Forms.Label()
        Me.lbQuantity = New System.Windows.Forms.Label()
        Me.lbColor = New System.Windows.Forms.Label()
        Me.btnCorrection = New System.Windows.Forms.Button()
        Me.btnOriginal = New System.Windows.Forms.Button()
        Me.lbJobLabel = New System.Windows.Forms.Label()
        Me.lbSampleIdLabel = New System.Windows.Forms.Label()
        Me.lbJobName = New System.Windows.Forms.Label()
        Me.lbSampleId = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnOriginal = New System.Windows.Forms.Panel()
        Me.pnCorrected = New System.Windows.Forms.Panel()
        Me.lbCorrected = New System.Windows.Forms.Label()
        Me.lbOriginal = New System.Windows.Forms.Label()
        Me.grpIngredients.SuspendLayout()
        Me.pnlResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpIngredients
        '
        Me.grpIngredients.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpIngredients.Controls.Add(Me.pnlResult)
        Me.grpIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpIngredients.Location = New System.Drawing.Point(533, 131)
        Me.grpIngredients.Name = "grpIngredients"
        Me.grpIngredients.Size = New System.Drawing.Size(680, 401)
        Me.grpIngredients.TabIndex = 0
        Me.grpIngredients.TabStop = False
        '
        'pnlResult
        '
        Me.pnlResult.Controls.Add(Me.lbCorrection)
        Me.pnlResult.Controls.Add(Me.lbQuantity)
        Me.pnlResult.Controls.Add(Me.lbColor)
        Me.pnlResult.Location = New System.Drawing.Point(6, 21)
        Me.pnlResult.Name = "pnlResult"
        Me.pnlResult.Size = New System.Drawing.Size(668, 646)
        Me.pnlResult.TabIndex = 0
        '
        'lbCorrection
        '
        Me.lbCorrection.AutoSize = True
        Me.lbCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrection.Location = New System.Drawing.Point(536, 16)
        Me.lbCorrection.Name = "lbCorrection"
        Me.lbCorrection.Size = New System.Drawing.Size(139, 29)
        Me.lbCorrection.TabIndex = 2
        Me.lbCorrection.Text = "Correction"
        Me.lbCorrection.Visible = False
        '
        'lbQuantity
        '
        Me.lbQuantity.AutoSize = True
        Me.lbQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQuantity.Location = New System.Drawing.Point(350, 16)
        Me.lbQuantity.Name = "lbQuantity"
        Me.lbQuantity.Size = New System.Drawing.Size(115, 29)
        Me.lbQuantity.TabIndex = 1
        Me.lbQuantity.Text = "Quantity"
        '
        'lbColor
        '
        Me.lbColor.AutoSize = True
        Me.lbColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbColor.Location = New System.Drawing.Point(17, 16)
        Me.lbColor.Name = "lbColor"
        Me.lbColor.Size = New System.Drawing.Size(145, 29)
        Me.lbColor.TabIndex = 0
        Me.lbColor.Text = "Color code"
        '
        'btnCorrection
        '
        Me.btnCorrection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCorrection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCorrection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorrection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCorrection.Location = New System.Drawing.Point(548, 12)
        Me.btnCorrection.Name = "btnCorrection"
        Me.btnCorrection.Size = New System.Drawing.Size(334, 76)
        Me.btnCorrection.TabIndex = 1
        Me.btnCorrection.Text = "Execute Correction"
        Me.btnCorrection.UseVisualStyleBackColor = True
        '
        'btnOriginal
        '
        Me.btnOriginal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOriginal.Location = New System.Drawing.Point(903, 12)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New System.Drawing.Size(319, 76)
        Me.btnOriginal.TabIndex = 2
        Me.btnOriginal.Text = "Original Sample"
        Me.btnOriginal.UseVisualStyleBackColor = True
        '
        'lbJobLabel
        '
        Me.lbJobLabel.AutoSize = True
        Me.lbJobLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbJobLabel.Location = New System.Drawing.Point(13, 12)
        Me.lbJobLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbJobLabel.Name = "lbJobLabel"
        Me.lbJobLabel.Size = New System.Drawing.Size(65, 29)
        Me.lbJobLabel.TabIndex = 4
        Me.lbJobLabel.Text = "Job:"
        '
        'lbSampleIdLabel
        '
        Me.lbSampleIdLabel.AutoSize = True
        Me.lbSampleIdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSampleIdLabel.Location = New System.Drawing.Point(13, 59)
        Me.lbSampleIdLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSampleIdLabel.Name = "lbSampleIdLabel"
        Me.lbSampleIdLabel.Size = New System.Drawing.Size(148, 29)
        Me.lbSampleIdLabel.TabIndex = 5
        Me.lbSampleIdLabel.Text = "Sample ID:"
        '
        'lbJobName
        '
        Me.lbJobName.AutoSize = True
        Me.lbJobName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbJobName.Location = New System.Drawing.Point(175, 12)
        Me.lbJobName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbJobName.Name = "lbJobName"
        Me.lbJobName.Size = New System.Drawing.Size(142, 29)
        Me.lbJobName.TabIndex = 6
        Me.lbJobName.Text = "lbJobName"
        '
        'lbSampleId
        '
        Me.lbSampleId.AutoSize = True
        Me.lbSampleId.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSampleId.Location = New System.Drawing.Point(175, 59)
        Me.lbSampleId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSampleId.Name = "lbSampleId"
        Me.lbSampleId.Size = New System.Drawing.Size(140, 29)
        Me.lbSampleId.TabIndex = 7
        Me.lbSampleId.Text = "lbSampleId"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(12, 685)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(357, 76)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pnOriginal
        '
        Me.pnOriginal.Location = New System.Drawing.Point(18, 163)
        Me.pnOriginal.Name = "pnOriginal"
        Me.pnOriginal.Size = New System.Drawing.Size(357, 58)
        Me.pnOriginal.TabIndex = 11
        '
        'pnCorrected
        '
        Me.pnCorrected.Location = New System.Drawing.Point(16, 287)
        Me.pnCorrected.Name = "pnCorrected"
        Me.pnCorrected.Size = New System.Drawing.Size(359, 58)
        Me.pnCorrected.TabIndex = 12
        '
        'lbCorrected
        '
        Me.lbCorrected.AutoSize = True
        Me.lbCorrected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrected.Location = New System.Drawing.Point(20, 255)
        Me.lbCorrected.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCorrected.Name = "lbCorrected"
        Me.lbCorrected.Size = New System.Drawing.Size(92, 20)
        Me.lbCorrected.TabIndex = 13
        Me.lbCorrected.Text = "Corrected"
        '
        'lbOriginal
        '
        Me.lbOriginal.AutoSize = True
        Me.lbOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOriginal.Location = New System.Drawing.Point(20, 131)
        Me.lbOriginal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbOriginal.Name = "lbOriginal"
        Me.lbOriginal.Size = New System.Drawing.Size(75, 20)
        Me.lbOriginal.TabIndex = 14
        Me.lbOriginal.Text = "Original"
        '
        'NucleosCorrection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1236, 779)
        Me.Controls.Add(Me.lbOriginal)
        Me.Controls.Add(Me.pnOriginal)
        Me.Controls.Add(Me.lbCorrected)
        Me.Controls.Add(Me.pnCorrected)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lbSampleId)
        Me.Controls.Add(Me.lbJobName)
        Me.Controls.Add(Me.lbSampleIdLabel)
        Me.Controls.Add(Me.lbJobLabel)
        Me.Controls.Add(Me.btnOriginal)
        Me.Controls.Add(Me.btnCorrection)
        Me.Controls.Add(Me.grpIngredients)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NucleosCorrection"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recipe"
        Me.grpIngredients.ResumeLayout(False)
        Me.pnlResult.ResumeLayout(False)
        Me.pnlResult.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpIngredients As GroupBox
    Friend WithEvents lbQuantity As Label
    Friend WithEvents lbColor As Label
    Friend WithEvents pnlResult As Panel
    Friend WithEvents btnCorrection As Button
    Friend WithEvents btnOriginal As Button
    Friend WithEvents lbJobLabel As Label
    Friend WithEvents lbSampleIdLabel As Label
    Friend WithEvents lbJobName As Label
    Friend WithEvents lbSampleId As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnCorrected As Panel
    Friend WithEvents pnOriginal As Panel
    Friend WithEvents lbCorrected As Label
    Friend WithEvents lbOriginal As Label
    Friend WithEvents lbCorrection As Label
End Class
