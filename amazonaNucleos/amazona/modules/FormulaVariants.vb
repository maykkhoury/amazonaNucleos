Public Class FormulaVariants
    Private variantNameAtt As String
    Private variantColorAtt As System.Drawing.Color
    Private variantDescriptionAtt As String
    Private variantImageAtt As Image

    Property variantImage() As Image
        Get
            Return variantImageAtt
        End Get
        Set(ByVal Value As Image)
            variantImageAtt = Value
        End Set
    End Property
    Property variantDescription() As String
        Get
            Return variantDescriptionAtt
        End Get
        Set(ByVal Value As String)
            variantDescriptionAtt = Value
        End Set
    End Property

    Property variantName() As String
        Get
            Return variantNameAtt
        End Get
        Set(ByVal Value As String)
            variantNameAtt = Value
        End Set
    End Property
    Property variantColor() As System.Drawing.Color
        Get
            Return variantColorAtt
        End Get
        Set(ByVal Value As System.Drawing.Color)
            variantColorAtt = Value
        End Set
    End Property

End Class
