<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class colorPrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(colorPrice))
        Me.grpBColors = New System.Windows.Forms.GroupBox()
        Me.butClearUpdate = New System.Windows.Forms.Button()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.lbUnit = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pctBColorImg = New System.Windows.Forms.PictureBox()
        Me.butEditBColorForm = New garageApp.MyButton()
        Me.lbNewPrice =New garageApp.TranslatedLabel()
        Me.txtPriceBcolorForm = New garageApp.MyTextBox()
        Me.lbIdBColorForm = New System.Windows.Forms.Label()
        Me.lsvBColors = New garageApp.MyListView()
        Me.cidBColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ccolorName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cgprice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cdprice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cunit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpBColors.SuspendLayout()
        CType(Me.pctBColorImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBColors
        '
        Me.grpBColors.BackColor = System.Drawing.Color.Transparent
        Me.grpBColors.Controls.Add(Me.butClearUpdate)
        Me.grpBColors.Controls.Add(Me.cmbCurrency)
        Me.grpBColors.Controls.Add(Me.lbUnit)
        Me.grpBColors.Controls.Add(Me.Label1)
        Me.grpBColors.Controls.Add(Me.Label16)
        Me.grpBColors.Controls.Add(Me.pctBColorImg)
        Me.grpBColors.Controls.Add(Me.butEditBColorForm)
        Me.grpBColors.Controls.Add(Me.lbNewPrice)
        Me.grpBColors.Controls.Add(Me.txtPriceBcolorForm)
        Me.grpBColors.Controls.Add(Me.lbIdBColorForm)
        Me.grpBColors.Controls.Add(Me.lsvBColors)
        Me.grpBColors.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBColors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpBColors.Location = New System.Drawing.Point(-33, -89)
        Me.grpBColors.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpBColors.Name = "grpBColors"
        Me.grpBColors.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpBColors.Size = New System.Drawing.Size(1545, 854)
        Me.grpBColors.TabIndex = 68
        Me.grpBColors.TabStop = False
        Me.grpBColors.Text = "BColors"
        '
        'butClearUpdate
        '
        Me.butClearUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.butClearUpdate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butClearUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butClearUpdate.Location = New System.Drawing.Point(648, 146)
        Me.butClearUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butClearUpdate.Name = "butClearUpdate"
        Me.butClearUpdate.Size = New System.Drawing.Size(168, 47)
        Me.butClearUpdate.TabIndex = 167
        Me.butClearUpdate.Text = "Clear"
        Me.butClearUpdate.UseVisualStyleBackColor = False
        '
        'cmbCurrency
        '
        Me.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(208, 146)
        Me.cmbCurrency.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(133, 28)
        Me.cmbCurrency.TabIndex = 130
        Me.cmbCurrency.Visible = False
        '
        'lbUnit
        '
        Me.lbUnit.AutoSize = True
        Me.lbUnit.Location = New System.Drawing.Point(489, 113)
        Me.lbUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbUnit.Name = "lbUnit"
        Me.lbUnit.Size = New System.Drawing.Size(0, 20)
        Me.lbUnit.TabIndex = 129
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(464, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 20)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "/"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(61, 208)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 18)
        Me.Label16.TabIndex = 127
        Me.Label16.Text = "Thumbnail:"
        '
        'pctBColorImg
        '
        Me.pctBColorImg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pctBColorImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pctBColorImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctBColorImg.Location = New System.Drawing.Point(208, 194)
        Me.pctBColorImg.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pctBColorImg.Name = "pctBColorImg"
        Me.pctBColorImg.Size = New System.Drawing.Size(133, 98)
        Me.pctBColorImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBColorImg.TabIndex = 126
        Me.pctBColorImg.TabStop = False
        '
        'butEditBColorForm
        '
        Me.butEditBColorForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butEditBColorForm.Location = New System.Drawing.Point(648, 110)
        Me.butEditBColorForm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butEditBColorForm.Name = "butEditBColorForm"
        Me.butEditBColorForm.Size = New System.Drawing.Size(168, 28)
        Me.butEditBColorForm.TabIndex = 125
        Me.butEditBColorForm.Text = "Edit"
        Me.butEditBColorForm.UseVisualStyleBackColor = True
        '
        'lbNewPrice
        '
        Me.lbNewPrice.AutoSize = True
        Me.lbNewPrice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbNewPrice.Location = New System.Drawing.Point(51, 113)
        Me.lbNewPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNewPrice.Name = "lbNewPrice"
        Me.lbNewPrice.Size = New System.Drawing.Size(101, 20)
        Me.lbNewPrice.TabIndex = 123
        Me.lbNewPrice.Text = "New Price:"
        '
        'txtPriceBcolorForm
        '
        Me.txtPriceBcolorForm.Location = New System.Drawing.Point(208, 110)
        Me.txtPriceBcolorForm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPriceBcolorForm.Name = "txtPriceBcolorForm"
        Me.txtPriceBcolorForm.Size = New System.Drawing.Size(247, 26)
        Me.txtPriceBcolorForm.TabIndex = 119
        '
        'lbIdBColorForm
        '
        Me.lbIdBColorForm.AutoSize = True
        Me.lbIdBColorForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIdBColorForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbIdBColorForm.Location = New System.Drawing.Point(49, 186)
        Me.lbIdBColorForm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbIdBColorForm.Name = "lbIdBColorForm"
        Me.lbIdBColorForm.Size = New System.Drawing.Size(23, 18)
        Me.lbIdBColorForm.TabIndex = 76
        Me.lbIdBColorForm.Text = "-1"
        Me.lbIdBColorForm.Visible = False
        '
        'lsvBColors
        '
        Me.lsvBColors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvBColors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cidBColor, Me.ccolorName, Me.cgprice, Me.cdprice, Me.cunit})
        Me.lsvBColors.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvBColors.FullRowSelect = True
        Me.lsvBColors.GridLines = True
        Me.lsvBColors.HideSelection = False
        Me.lsvBColors.Location = New System.Drawing.Point(53, 300)
        Me.lsvBColors.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lsvBColors.MultiSelect = False
        Me.lsvBColors.Name = "lsvBColors"
        Me.lsvBColors.Size = New System.Drawing.Size(1084, 451)
        Me.lsvBColors.TabIndex = 55
        Me.lsvBColors.UseCompatibleStateImageBehavior = False
        Me.lsvBColors.View = System.Windows.Forms.View.Details
        '
        'cidBColor
        '
        Me.cidBColor.Tag = "cidBColor"
        Me.cidBColor.Width = 0
        '
        'ccolorName
        '
        Me.ccolorName.Text = "Name"
        Me.ccolorName.Width = 262
        '
        'cgprice
        '
        Me.cgprice.Text = "Garage Price"
        Me.cgprice.Width = 194
        '
        'cdprice
        '
        Me.cdprice.Text = "Default Price"
        Me.cdprice.Width = 179
        '
        'cunit
        '
        Me.cunit.Text = "Unit"
        Me.cunit.Width = 153
        '
        'colorPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 678)
        Me.Controls.Add(Me.grpBColors)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "colorPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "colorPrice"
        Me.grpBColors.ResumeLayout(False)
        Me.grpBColors.PerformLayout()
        CType(Me.pctBColorImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBColors As System.Windows.Forms.GroupBox
    Friend WithEvents lbIdBColorForm As System.Windows.Forms.Label
    Friend WithEvents lsvBColors As garageApp.MyListView
    Friend WithEvents cidBColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents ccolorName As System.Windows.Forms.ColumnHeader
    Friend WithEvents cgprice As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPriceBcolorForm As garageApp.MyTextBox
    Friend WithEvents butEditBColorForm As garageApp.MyButton
    Friend WithEvents lbNewPrice As garageApp.TranslatedLabel
    Friend WithEvents cdprice As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pctBColorImg As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbUnit As System.Windows.Forms.Label
    Friend WithEvents cunit As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents butClearUpdate As System.Windows.Forms.Button
End Class
