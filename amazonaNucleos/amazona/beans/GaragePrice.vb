Public Class GaragePrice
    Private id_garagePriceAtt As Integer

    Private id_colorAtt As Integer
    Private id_currencyAtt As Integer
    Private id_unitAtt As Integer
    Private garage_priceAtt As Double
    Property id_unit() As Integer
        Get
            Return id_unitAtt
        End Get
        Set(ByVal Value As Integer)
            id_unitAtt = Value
        End Set
    End Property
    Property id_currency() As Integer
        Get
            Return id_currencyAtt
        End Get
        Set(ByVal Value As Integer)
            id_currencyAtt = Value
        End Set
    End Property
    Property id_garagePrice() As Integer
        Get
            Return id_garagePriceAtt
        End Get
        Set(ByVal Value As Integer)
            id_garagePriceAtt = Value
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


    Property garage_price() As Double
        Get
            Return garage_priceAtt
        End Get
        Set(ByVal Value As Double)
            garage_priceAtt = Value
        End Set
    End Property



End Class
