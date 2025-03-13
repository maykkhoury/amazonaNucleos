Imports garageApp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
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
        Me.grpSettings = New garageApp.MyGroupBox()
        Me.chkShowHues = New System.Windows.Forms.CheckBox()
        Me.lbCurrencyId = New System.Windows.Forms.Label()
        Me.lbUnitId = New System.Windows.Forms.Label()
        Me.lbCurrency = New garageApp.TranslatedLabel()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.lbUnit = New garageApp.TranslatedLabel()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.grpSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'butDone
        '
        Me.butDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butDone.Location = New System.Drawing.Point(378, 145)
        Me.butDone.Name = "butDone"
        Me.butDone.Size = New System.Drawing.Size(64, 23)
        Me.butDone.TabIndex = 4
        Me.butDone.Text = "Done"
        Me.butDone.UseVisualStyleBackColor = True
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.chkShowHues)
        Me.grpSettings.Controls.Add(Me.lbCurrencyId)
        Me.grpSettings.Controls.Add(Me.lbUnitId)
        Me.grpSettings.Controls.Add(Me.lbCurrency)
        Me.grpSettings.Controls.Add(Me.cmbCurrency)
        Me.grpSettings.Controls.Add(Me.lbUnit)
        Me.grpSettings.Controls.Add(Me.cmbUnit)
        Me.grpSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grpSettings.Location = New System.Drawing.Point(14, 21)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(428, 118)
        Me.grpSettings.TabIndex = 55
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Amazona Settings"
        '
        'chkShowHues
        '
        Me.chkShowHues.AutoSize = True
        Me.chkShowHues.Location = New System.Drawing.Point(99, 91)
        Me.chkShowHues.Name = "chkShowHues"
        Me.chkShowHues.Size = New System.Drawing.Size(157, 21)
        Me.chkShowHues.TabIndex = 56
        Me.chkShowHues.Text = "SHOW ALL HUES"
        Me.chkShowHues.UseVisualStyleBackColor = True
        '
        'lbCurrencyId
        '
        Me.lbCurrencyId.AutoSize = True
        Me.lbCurrencyId.Location = New System.Drawing.Point(6, 68)
        Me.lbCurrencyId.Name = "lbCurrencyId"
        Me.lbCurrencyId.Size = New System.Drawing.Size(23, 17)
        Me.lbCurrencyId.TabIndex = 153
        Me.lbCurrencyId.Text = "-1"
        Me.lbCurrencyId.Visible = False
        '
        'lbUnitId
        '
        Me.lbUnitId.AutoSize = True
        Me.lbUnitId.Location = New System.Drawing.Point(6, 40)
        Me.lbUnitId.Name = "lbUnitId"
        Me.lbUnitId.Size = New System.Drawing.Size(23, 17)
        Me.lbUnitId.TabIndex = 152
        Me.lbUnitId.Text = "-1"
        Me.lbUnitId.Visible = False
        '
        'lbCurrency
        '
        Me.lbCurrency.AutoSize = True
        Me.lbCurrency.Location = New System.Drawing.Point(27, 68)
        Me.lbCurrency.Name = "lbCurrency"
        Me.lbCurrency.Size = New System.Drawing.Size(78, 17)
        Me.lbCurrency.TabIndex = 3
        Me.lbCurrency.Text = "Currency:"
        '
        'cmbCurrency
        '
        Me.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(99, 64)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(306, 25)
        Me.cmbCurrency.TabIndex = 2
        '
        'lbUnit
        '
        Me.lbUnit.AutoSize = True
        Me.lbUnit.Location = New System.Drawing.Point(27, 41)
        Me.lbUnit.Name = "lbUnit"
        Me.lbUnit.Size = New System.Drawing.Size(42, 17)
        Me.lbUnit.TabIndex = 1
        Me.lbUnit.Text = "Unit:"
        '
        'cmbUnit
        '
        Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(99, 37)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(306, 25)
        Me.cmbUnit.TabIndex = 0
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(454, 178)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.butDone)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butDone As garageApp.MyButton
    Friend WithEvents grpSettings As garageApp.MyGroupBox
    Friend WithEvents lbCurrency As garageApp.TranslatedLabel
    Friend WithEvents cmbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents lbUnit As garageApp.TranslatedLabel
    Friend WithEvents cmbUnit As System.Windows.Forms.ComboBox
    Friend WithEvents lbCurrencyId As System.Windows.Forms.Label
    Friend WithEvents lbUnitId As System.Windows.Forms.Label
    Friend WithEvents chkShowHues As System.Windows.Forms.CheckBox
End Class
