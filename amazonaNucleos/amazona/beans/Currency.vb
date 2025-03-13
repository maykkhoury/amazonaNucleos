Public Class Currency
    Private id_currencyAtt As Integer

    Private code_currencyAtt As String
    Private symbol_att As String
    Private rateToDollarAtt As Double
    Private chosenAtt As Boolean

    Property chosen() As Boolean
        Get
            Return chosenAtt
        End Get
        Set(ByVal Value As Boolean)
            chosenAtt = Value
        End Set
    End Property

    Property rateToDollar() As Double
        Get
            Return rateToDollarAtt
        End Get
        Set(ByVal Value As Double)
            rateToDollarAtt = Value
        End Set
    End Property



    Private currencyLanguageAtt() As CurrencyLanguage

    Property symbol() As String
        Get
            Return symbol_att
        End Get
        Set(ByVal Value As String)
            symbol_att = Value
        End Set
    End Property

    Property currencyLanguage() As CurrencyLanguage()
        Get
            Return currencyLanguageAtt
        End Get
        Set(ByVal Value As CurrencyLanguage())
            currencyLanguageAtt = Value
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


    Property code_currency() As String
        Get
            Return code_currencyAtt
        End Get
        Set(ByVal Value As String)
            code_currencyAtt = Value
        End Set
    End Property

End Class
