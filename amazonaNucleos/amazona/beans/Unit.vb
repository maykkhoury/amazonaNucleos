Public Class Unit
    Private id_unitAtt As Integer

    Private rateToLitreAtt As Double

    Private code_unitAtt As String

    Private unitLanguageAtt() As UnitLanguage

    Private chosenAtt As Boolean

    Property chosen() As Boolean
        Get
            Return chosenAtt
        End Get
        Set(ByVal Value As Boolean)
            chosenAtt = Value
        End Set
    End Property


    Public Function getUnitName(ByVal id_language) As String

        Dim i As Integer
        For i = 0 To unitLanguageAtt.Length
            If unitLanguageAtt(i).id_language = chosenLanguage.id_language Then
                Return unitLanguageAtt(i).name_unit
            End If
        Next
    End Function

    Property unitLanguage() As UnitLanguage()
        Get
            Return unitLanguageAtt
        End Get
        Set(ByVal Value As UnitLanguage())
            unitLanguageAtt = Value
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


    Property rateToLitre() As Double
        Get
            Return rateToLitreAtt
        End Get
        Set(ByVal Value As Double)
            rateToLitreAtt = Value
        End Set
    End Property


    Property code_unit() As String
        Get
            Return code_unitAtt
        End Get
        Set(ByVal Value As String)
            code_unitAtt = Value
        End Set
    End Property


End Class
