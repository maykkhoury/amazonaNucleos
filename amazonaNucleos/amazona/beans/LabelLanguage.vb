Public Class LabelLanguage
    Private id_labelLanguageAtt As Integer

    Private id_labelAtt As Integer

    Private id_languageAtt As Integer

    Private descriptionAtt As String


    Property id_labelLanguage() As Integer
        Get
            Return id_labelLanguageAtt
        End Get
        Set(ByVal Value As Integer)
            id_labelLanguageAtt = Value
        End Set
    End Property


    Property id_label() As Integer
        Get
            Return id_labelAtt
        End Get
        Set(ByVal Value As Integer)
            id_labelAtt = Value
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


    Property description() As String
        Get
            Return descriptionAtt
        End Get
        Set(ByVal Value As String)
            descriptionAtt = Value
        End Set
    End Property


End Class
