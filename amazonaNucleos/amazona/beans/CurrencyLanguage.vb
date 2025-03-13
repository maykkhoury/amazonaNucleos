Public Class CurrencyLanguage
    Private id_currencyLanguageAtt As Integer

    Private id_currencyAtt As Integer

    Private id_languageAtt As Integer

    Private labelAtt As String


    Property id_currencyLanguage() As Integer
        Get
            Return id_currencyLanguageAtt
        End Get
        Set(ByVal Value As Integer)
            id_currencyLanguageAtt = Value
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


    Property id_language() As Integer
        Get
            Return id_languageAtt
        End Get
        Set(ByVal Value As Integer)
            id_languageAtt = Value
        End Set
    End Property


    Property label() As String
        Get
            Return labelAtt
        End Get
        Set(ByVal Value As String)
            labelAtt = Value
        End Set
    End Property


End Class
