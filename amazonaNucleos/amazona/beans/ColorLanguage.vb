Public Class ColorLanguage
    Private id_colorLanguageAtt As Integer

    Private id_colorAtt As Integer

    Private id_languageAtt As Integer

    Private name_colorAtt As String


    Property id_colorLanguage() As Integer
        Get
            Return id_colorLanguageAtt
        End Get
        Set(ByVal Value As Integer)
            id_colorLanguageAtt = Value
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


    Property id_language() As Integer
        Get
            Return id_languageAtt
        End Get
        Set(ByVal Value As Integer)
            id_languageAtt = Value
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


End Class
