<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.lbKey =New garageApp.TranslatedLabel()
        Me.txtKey = New garageApp.MyTextBox()
        Me.butSubmit = New garageApp.MyButton()
        Me.butCancel = New garageApp.MyButton()
        Me.lbError =New garageApp.TranslatedLabel()
        Me.SuspendLayout()
        '
        'lbKey
        '
        Me.lbKey.AutoSize = True
        Me.lbKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbKey.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbKey.Location = New System.Drawing.Point(16, 11)
        Me.lbKey.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbKey.Name = "lbKey"
        Me.lbKey.Size = New System.Drawing.Size(136, 20)
        Me.lbKey.TabIndex = 171
        Me.lbKey.Text = "Enter your key:"
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(183, 10)
        Me.txtKey.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(395, 22)
        Me.txtKey.TabIndex = 172
        '
        'butSubmit
        '
        Me.butSubmit.AccessibleDescription = "555"
        Me.butSubmit.BackColor = System.Drawing.SystemColors.Control
        Me.butSubmit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSubmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butSubmit.Location = New System.Drawing.Point(303, 42)
        Me.butSubmit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butSubmit.Name = "butSubmit"
        Me.butSubmit.Size = New System.Drawing.Size(132, 33)
        Me.butSubmit.TabIndex = 173
        Me.butSubmit.Text = "Submit"
        Me.butSubmit.UseVisualStyleBackColor = False
        '
        'butCancel
        '
        Me.butCancel.AccessibleDescription = "555"
        Me.butCancel.BackColor = System.Drawing.SystemColors.Control
        Me.butCancel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butCancel.Location = New System.Drawing.Point(443, 42)
        Me.butCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(132, 33)
        Me.butCancel.TabIndex = 174
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = False
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbError.ForeColor = System.Drawing.Color.Red
        Me.lbError.Location = New System.Drawing.Point(16, 48)
        Me.lbError.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(97, 20)
        Me.lbError.TabIndex = 175
        Me.lbError.Text = "Wrong key"
        Me.lbError.Visible = False
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 86)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butSubmit)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.lbKey)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbKey As garageApp.TranslatedLabel
    Friend WithEvents txtKey  As garageApp.MyTextBox
    Friend WithEvents butSubmit As garageApp.MyButton
    Friend WithEvents butCancel As garageApp.MyButton
    Friend WithEvents lbError As garageApp.TranslatedLabel
End Class
