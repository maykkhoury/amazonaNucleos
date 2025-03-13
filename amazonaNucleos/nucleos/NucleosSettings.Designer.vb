Imports garageApp.garageApp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NucleosSettings
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
        Me.butDone = New garageApp.MyButton()
        Me.MyGroupBox1 = New garageApp.MyGroupBox()
        Me.TranslatedLabel2 = New garageApp.TranslatedLabel()
        Me.cmbDeltaBC = New System.Windows.Forms.ComboBox()
        Me.TranslatedLabel1 = New garageApp.TranslatedLabel()
        Me.cmbDeltaLs = New System.Windows.Forms.ComboBox()
        Me.lbMaxResult = New garageApp.TranslatedLabel()
        Me.cmbMaxResult = New System.Windows.Forms.ComboBox()
        Me.MyGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butDone
        '
        Me.butDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butDone.Location = New System.Drawing.Point(376, 164)
        Me.butDone.Name = "butDone"
        Me.butDone.Size = New System.Drawing.Size(64, 23)
        Me.butDone.TabIndex = 4
        Me.butDone.Text = "Done"
        Me.butDone.UseVisualStyleBackColor = True
        '
        'MyGroupBox1
        '
        Me.MyGroupBox1.Controls.Add(Me.TranslatedLabel2)
        Me.MyGroupBox1.Controls.Add(Me.cmbDeltaBC)
        Me.MyGroupBox1.Controls.Add(Me.TranslatedLabel1)
        Me.MyGroupBox1.Controls.Add(Me.cmbDeltaLs)
        Me.MyGroupBox1.Controls.Add(Me.lbMaxResult)
        Me.MyGroupBox1.Controls.Add(Me.cmbMaxResult)
        Me.MyGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.MyGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.MyGroupBox1.Name = "MyGroupBox1"
        Me.MyGroupBox1.Size = New System.Drawing.Size(428, 146)
        Me.MyGroupBox1.TabIndex = 154
        Me.MyGroupBox1.TabStop = False
        Me.MyGroupBox1.Text = "Nucleos Settings"
        '
        'TranslatedLabel2
        '
        Me.TranslatedLabel2.AutoSize = True
        Me.TranslatedLabel2.Location = New System.Drawing.Point(27, 103)
        Me.TranslatedLabel2.Name = "TranslatedLabel2"
        Me.TranslatedLabel2.Size = New System.Drawing.Size(76, 17)
        Me.TranslatedLabel2.TabIndex = 5
        Me.TranslatedLabel2.Text = "Delta BC:"
        '
        'cmbDeltaBC
        '
        Me.cmbDeltaBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeltaBC.FormattingEnabled = True
        Me.cmbDeltaBC.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cmbDeltaBC.Location = New System.Drawing.Point(184, 100)
        Me.cmbDeltaBC.Name = "cmbDeltaBC"
        Me.cmbDeltaBC.Size = New System.Drawing.Size(221, 25)
        Me.cmbDeltaBC.TabIndex = 4
        '
        'TranslatedLabel1
        '
        Me.TranslatedLabel1.AutoSize = True
        Me.TranslatedLabel1.Location = New System.Drawing.Point(27, 72)
        Me.TranslatedLabel1.Name = "TranslatedLabel1"
        Me.TranslatedLabel1.Size = New System.Drawing.Size(75, 17)
        Me.TranslatedLabel1.TabIndex = 3
        Me.TranslatedLabel1.Text = "Delta LS:"
        '
        'cmbDeltaLs
        '
        Me.cmbDeltaLs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeltaLs.FormattingEnabled = True
        Me.cmbDeltaLs.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cmbDeltaLs.Location = New System.Drawing.Point(184, 69)
        Me.cmbDeltaLs.Name = "cmbDeltaLs"
        Me.cmbDeltaLs.Size = New System.Drawing.Size(221, 25)
        Me.cmbDeltaLs.TabIndex = 2
        '
        'lbMaxResult
        '
        Me.lbMaxResult.AutoSize = True
        Me.lbMaxResult.Location = New System.Drawing.Point(27, 41)
        Me.lbMaxResult.Name = "lbMaxResult"
        Me.lbMaxResult.Size = New System.Drawing.Size(156, 17)
        Me.lbMaxResult.TabIndex = 1
        Me.lbMaxResult.Text = "Max Search Results:"
        '
        'cmbMaxResult
        '
        Me.cmbMaxResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaxResult.FormattingEnabled = True
        Me.cmbMaxResult.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30", "35", "40"})
        Me.cmbMaxResult.Location = New System.Drawing.Point(184, 38)
        Me.cmbMaxResult.Name = "cmbMaxResult"
        Me.cmbMaxResult.Size = New System.Drawing.Size(221, 25)
        Me.cmbMaxResult.TabIndex = 0
        '
        'NucleosSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(461, 206)
        Me.Controls.Add(Me.MyGroupBox1)
        Me.Controls.Add(Me.butDone)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NucleosSettings"
        Me.Text = "Settings"
        Me.MyGroupBox1.ResumeLayout(False)
        Me.MyGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butDone As MyButton
    Friend WithEvents MyGroupBox1 As garageApp.MyGroupBox
    Friend WithEvents lbMaxResult As garageApp.TranslatedLabel
    Friend WithEvents cmbMaxResult As ComboBox
    Friend WithEvents TranslatedLabel2 As garageApp.TranslatedLabel
    Friend WithEvents cmbDeltaBC As ComboBox
    Friend WithEvents TranslatedLabel1 As garageApp.TranslatedLabel
    Friend WithEvents cmbDeltaLs As ComboBox
End Class
