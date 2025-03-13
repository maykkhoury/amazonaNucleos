Public Class AmazonaColor
    Private id_colorAtt As Integer

    Private colorImgPathAtt As String

    Private defaultPriceAtt As Double

    Private id_defaultCurrenyAtt As Integer

    Private id_defaultUnitAtt As Integer

    Private name_colorAtt As String
    Private colorCodeAtt As String
    Private masse_volumiqueAtt As String

    Private id_unit_on_entryAtt As Integer
    Private masse_volumique_extAtt As String

    Property masse_volumique_ext() As String
        Get
            Return masse_volumique_extAtt
        End Get
        Set(ByVal Value As String)
            masse_volumique_extAtt = Value.Trim
        End Set
    End Property
    Property id_unit_on_entry() As Integer
        Get
            Return id_unit_on_entryAtt
        End Get
        Set(ByVal Value As Integer)
            id_unit_on_entryAtt = Value
        End Set
    End Property
    Property masse_volumique() As String
        Get
            Return masse_volumiqueAtt
        End Get
        Set(ByVal Value As String)
            masse_volumiqueAtt = Value.Trim
        End Set
    End Property

    Property colorCode() As String
        Get
            Return colorCodeAtt
        End Get
        Set(ByVal Value As String)
            colorCodeAtt = Value.Trim
        End Set
    End Property

    Property name_color() As String
        Get
            Return name_colorAtt
        End Get
        Set(ByVal Value As String)
            name_colorAtt = Value
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



    Property colorImgPath() As String
        Get
            Return colorImgPathAtt
        End Get
        Set(ByVal Value As String)
            colorImgPathAtt = Value
        End Set
    End Property


    Property defaultPrice() As Double
        Get
            Return defaultPriceAtt
        End Get
        Set(ByVal Value As Double)
            defaultPriceAtt = Value
        End Set
    End Property


    Property id_defaultCurreny() As Integer
        Get
            Return id_defaultCurrenyAtt
        End Get
        Set(ByVal Value As Integer)
            id_defaultCurrenyAtt = Value
        End Set
    End Property


    Property id_defaultUnit() As Integer
        Get
            Return id_defaultUnitAtt
        End Get
        Set(ByVal Value As Integer)
            id_defaultUnitAtt = Value
        End Set
    End Property


End Class
