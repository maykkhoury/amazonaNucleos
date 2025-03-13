<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class updateForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(updateForm))
        Me.butBrowseUpdate = New System.Windows.Forms.Button()
        Me.fileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.prgUpdate = New System.Windows.Forms.ProgressBar()
        Me.lbRemains = New System.Windows.Forms.Label()
        Me.txtUpdatePath = New garageApp.MyTextBox()
        Me.lbFilePath = New garageApp.TranslatedLabel()
        Me.butUpdateApp = New garageApp.MyButton()
        Me.FBrowserGarage = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'butBrowseUpdate
        '
        Me.butBrowseUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butBrowseUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.butBrowseUpdate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBrowseUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butBrowseUpdate.Location = New System.Drawing.Point(682, 8)
        Me.butBrowseUpdate.Name = "butBrowseUpdate"
        Me.butBrowseUpdate.Size = New System.Drawing.Size(37, 26)
        Me.butBrowseUpdate.TabIndex = 91
        Me.butBrowseUpdate.Text = "--"
        Me.butBrowseUpdate.UseVisualStyleBackColor = False
        '
        'fileDialog
        '
        Me.fileDialog.FileName = "OpenFileDialog1"
        '
        'prgUpdate
        '
        Me.prgUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgUpdate.Location = New System.Drawing.Point(13, 110)
        Me.prgUpdate.Name = "prgUpdate"
        Me.prgUpdate.Size = New System.Drawing.Size(706, 23)
        Me.prgUpdate.TabIndex = 93
        '
        'lbRemains
        '
        Me.lbRemains.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbRemains.AutoSize = True
        Me.lbRemains.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRemains.Location = New System.Drawing.Point(12, 75)
        Me.lbRemains.Name = "lbRemains"
        Me.lbRemains.Size = New System.Drawing.Size(0, 20)
        Me.lbRemains.TabIndex = 94
        '
        'txtUpdatePath
        '
        Me.txtUpdatePath.Location = New System.Drawing.Point(101, 12)
        Me.txtUpdatePath.Name = "txtUpdatePath"
        Me.txtUpdatePath.ReadOnly = True
        Me.txtUpdatePath.Size = New System.Drawing.Size(549, 20)
        Me.txtUpdatePath.TabIndex = 92
        '
        'lbFilePath
        '
        Me.lbFilePath.AutoSize = True
        Me.lbFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFilePath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbFilePath.Location = New System.Drawing.Point(10, 13)
        Me.lbFilePath.Name = "lbFilePath"
        Me.lbFilePath.Size = New System.Drawing.Size(82, 15)
        Me.lbFilePath.TabIndex = 90
        Me.lbFilePath.Text = "Browse file:"
        '
        'butUpdateApp
        '
        Me.butUpdateApp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butUpdateApp.BackColor = System.Drawing.SystemColors.Control
        Me.butUpdateApp.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butUpdateApp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butUpdateApp.Location = New System.Drawing.Point(379, 38)
        Me.butUpdateApp.Name = "butUpdateApp"
        Me.butUpdateApp.Size = New System.Drawing.Size(271, 57)
        Me.butUpdateApp.TabIndex = 89
        Me.butUpdateApp.Text = "Update Application"
        Me.butUpdateApp.UseVisualStyleBackColor = False
        '
        'updateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 145)
        Me.Controls.Add(Me.lbRemains)
        Me.Controls.Add(Me.prgUpdate)
        Me.Controls.Add(Me.txtUpdatePath)
        Me.Controls.Add(Me.butBrowseUpdate)
        Me.Controls.Add(Me.lbFilePath)
        Me.Controls.Add(Me.butUpdateApp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "updateForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butBrowseUpdate As System.Windows.Forms.Button
    Friend WithEvents lbFilePath As garageApp.TranslatedLabel
    Friend WithEvents butUpdateApp As garageApp.MyButton
    Friend WithEvents txtUpdatePath As garageApp.MyTextBox
    Friend WithEvents fileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents prgUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents lbRemains As System.Windows.Forms.Label
    Friend WithEvents FBrowserGarage As System.Windows.Forms.FolderBrowserDialog
End Class
