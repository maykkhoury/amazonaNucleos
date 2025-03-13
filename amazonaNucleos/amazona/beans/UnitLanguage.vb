Public Class UnitLanguage
    Private id_unitLanguageAtt As Integer

    Private id_unitAtt As Integer

    Private id_languageAtt As Integer

    Private name_unitAtt As String


    Property id_unitLanguage() As Integer
        Get
            Return id_unitLanguageAtt
        End Get
        Set(ByVal Value As Integer)
            id_unitLanguageAtt = Value
        End Set
    End Property


    Property id_unit() As Integer
        Get
            Return id_unitAtt
        End Get
        Set(ByVal Value As Integer)
            id_unitAtt = Value
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


    Property name_unit() As String
        Get
            Return name_unitAtt
        End Get
        Set(ByVal Value As String)
            name_unitAtt = Value.Trim
        End Set
    End Property


End Class
