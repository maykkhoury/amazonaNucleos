Public Class AmazonaLabel
    Private id_labelAtt As Integer

    Private name_labelAtt As String

    Private labelLanguageAtt() As LabelLanguage

    Property labelLanguage() As LabelLanguage()
        Get
            Return labelLanguageAtt
        End Get
        Set(ByVal Value As LabelLanguage())
            labelLanguageAtt = Value
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


    Property name_label() As String
        Get
            Return name_labelAtt
        End Get
        Set(ByVal Value As String)
            name_labelAtt = Value
        End Set
    End Property


End Class
