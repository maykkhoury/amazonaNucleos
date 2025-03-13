Public Class Garage
    Private id_garageAtt As Integer

    Private id_languageAtt As Integer

    Private name_responsibleAtt As String

    Private garage_nameAtt As String
    Private locationAtt As String
    Private logoAtt As String
    Private keyAtt As String
    Private key1Att As String

    Private chosenAtt As Boolean
    Private apply_equationAtt As Boolean

    Private versionAtt As String
    Private coatAtt As String
    Private showAllAtt As String = False
    Private showAlternativeNameAtt As Boolean
    Private showAlternativeName2Att As Boolean


    Property key() As String
        Get
            Return keyAtt
        End Get
        Set(ByVal Value As String)
            keyAtt = Value
        End Set
    End Property
    Property key1() As String
        Get
            Return key1Att
        End Get
        Set(ByVal Value As String)
            key1Att = Value
        End Set
    End Property


    Property showAlternativeName() As Boolean
        Get
            Return showAlternativeNameAtt
        End Get
        Set(ByVal Value As Boolean)
            showAlternativeNameAtt = Value
        End Set
    End Property

    Property showAlternativeName2() As Boolean
        Get
            Return showAlternativeName2Att
        End Get
        Set(ByVal Value As Boolean)
            showAlternativeName2Att = Value
        End Set
    End Property
    Property showAll() As Boolean
        Get
            Return showAllAtt
        End Get
        Set(ByVal Value As Boolean)
            showAllAtt = Value
        End Set
    End Property

    Property coat() As String
        Get
            Return coatAtt
        End Get
        Set(ByVal Value As String)
            coatAtt = Value
        End Set
    End Property
    Property version() As String
        Get
            Return versionAtt
        End Get
        Set(ByVal Value As String)
            versionAtt = Value
        End Set
    End Property
   
    Property apply_equation() As Boolean
        Get
            Return apply_equationAtt
        End Get
        Set(ByVal Value As Boolean)
            apply_equationAtt = Value
        End Set
    End Property

  

    Property garage_name() As String
        Get
            Return garage_nameAtt
        End Get
        Set(ByVal Value As String)
            garage_nameAtt = Value
        End Set
    End Property
    Property location() As String
        Get
            Return locationAtt
        End Get
        Set(ByVal Value As String)
            locationAtt = Value
        End Set
    End Property
    Property logo() As String
        Get
            Return logoAtt
        End Get
        Set(ByVal Value As String)
            logoAtt = Value
        End Set
    End Property
    Property chosen() As Boolean
        Get
            Return chosenAtt
        End Get
        Set(ByVal Value As Boolean)
            chosenAtt = Value
        End Set
    End Property


    Property id_garage() As Integer
        Get
            Return id_garageAtt
        End Get
        Set(ByVal Value As Integer)
            id_garageAtt = Value
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


    Property name_responsible() As String
        Get
            Return name_responsibleAtt
        End Get
        Set(ByVal Value As String)
            name_responsibleAtt = Value
        End Set
    End Property


End Class
