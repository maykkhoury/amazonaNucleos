Public Class FormulaColor
    Private id_formulaColorAtt As Integer

    Private id_formulaAtt As Integer

    Private id_colorAtt As Integer

    Private quantiteAtt As Double

    Private id_UnitAtt As Integer

    Private encryptedAtt As Boolean = False

    Property encrypted() As Boolean
        Get
            Return encryptedAtt
        End Get
        Set(ByVal Value As Boolean)
            encryptedAtt = Value
        End Set
    End Property

    Property id_formulaColor() As Integer
        Get
            Return id_formulaColorAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaColorAtt = Value
        End Set
    End Property


    Property id_formula() As Integer
        Get
            Return id_formulaAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaAtt = Value
        End Set
    End Property


    Property id_color() As Integer
        Get
            Return id_colorAtt
        End Get
        Set(ByVal Value As Integer)
            id_colorAtt = Value
        End Set
    End Property


    Property quantite() As Double
        Get
            Return quantiteAtt
        End Get
        Set(ByVal Value As Double)
            quantiteAtt = Value
        End Set
    End Property


    Property id_Unit() As Integer
        Get
            Return id_UnitAtt
        End Get
        Set(ByVal Value As Integer)
            id_UnitAtt = Value
        End Set
    End Property


End Class
