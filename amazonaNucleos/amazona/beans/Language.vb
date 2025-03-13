Public Class Language
    Private id_languageAtt As Integer

    Private code_languageAtt As String

    Private label_languageAtt As String

    Private isDefaultAtt As String

    Private dateTimeFormatAtt As String


    Property id_language() As Integer
        Get
            Return id_languageAtt
        End Get
        Set(ByVal Value As Integer)
            id_languageAtt = Value
        End Set
    End Property


    Property code_language() As String
        Get
            Return code_languageAtt
        End Get
        Set(ByVal Value As String)
            code_languageAtt = Value
        End Set
    End Property


    Property label_language() As String
        Get
            Return label_languageAtt
        End Get
        Set(ByVal Value As String)
            label_languageAtt = Value
        End Set
    End Property


    Property isDefault() As String
        Get
            Return isDefaultAtt
        End Get
        Set(ByVal Value As String)
            isDefaultAtt = Value
        End Set
    End Property


    Property dateTimeFormat() As String
        Get
            Return dateTimeFormatAtt
        End Get
        Set(ByVal Value As String)
            dateTimeFormatAtt = Value
        End Set
    End Property


End Class
