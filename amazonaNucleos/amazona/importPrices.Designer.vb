<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class importPrices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(importPrices))
        Me.butBrowse = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtExcelFile = New garageApp.MyTextBox()
        Me.fileDialogPrices = New System.Windows.Forms.OpenFileDialog()
        Me.lbLoading = New System.Windows.Forms.Label()
        Me.prgBarImport = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'butBrowse
        '
        Me.butBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.butBrowse.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butBrowse.Location = New System.Drawing.Point(429, 18)
        Me.butBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.butBrowse.Name = "butBrowse"
        Me.butBrowse.Size = New System.Drawing.Size(49, 32)
        Me.butBrowse.TabIndex = 88
        Me.butBrowse.Text = "--"
        Me.butBrowse.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(17, 25)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 18)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "File Path:"
        '
        'butUpdate
        '
        Me.butUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.butUpdate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butUpdate.Location = New System.Drawing.Point(8, 65)
        Me.butUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(483, 70)
        Me.butUpdate.TabIndex = 85
        Me.butUpdate.Text = "Update Prices"
        Me.butUpdate.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtExcelFile)
        Me.GroupBox2.Controls.Add(Me.butBrowse)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.butUpdate)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(499, 144)
        Me.GroupBox2.TabIndex = 89
        Me.GroupBox2.TabStop = False
        '
        'txtExcelFile
        '
        Me.txtExcelFile.Location = New System.Drawing.Point(116, 22)
        Me.txtExcelFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.ReadOnly = True
        Me.txtExcelFile.Size = New System.Drawing.Size(304, 22)
        Me.txtExcelFile.TabIndex = 90
        '
        'fileDialogPrices
        '
        Me.fileDialogPrices.FileName = " "
        '
        'lbLoading
        '
        Me.lbLoading.AutoSize = True
        Me.lbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLoading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbLoading.Location = New System.Drawing.Point(0, 173)
        Me.lbLoading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbLoading.Name = "lbLoading"
        Me.lbLoading.Size = New System.Drawing.Size(255, 18)
        Me.lbLoading.TabIndex = 90
        Me.lbLoading.Text = "Import in progress, please wait..."
        Me.lbLoading.Visible = False
        '
        'prgBarImport
        '
        Me.prgBarImport.Location = New System.Drawing.Point(299, 158)
        Me.prgBarImport.Margin = New System.Windows.Forms.Padding(4)
        Me.prgBarImport.Name = "prgBarImport"
        Me.prgBarImport.Size = New System.Drawing.Size(208, 28)
        Me.prgBarImport.TabIndex = 91
        Me.prgBarImport.Visible = False
        '
        'importPrices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 191)
        Me.Controls.Add(Me.prgBarImport)
        Me.Controls.Add(Me.lbLoading)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "importPrices"
        Me.Text = "importPrices"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butBrowse As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents butUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents fileDialogPrices As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtExcelFile As garageApp.MyTextBox
    Friend WithEvents lbLoading As System.Windows.Forms.Label
    Friend WithEvents prgBarImport As System.Windows.Forms.ProgressBar
End Class
