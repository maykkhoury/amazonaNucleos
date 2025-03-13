Public Class HistoryUpdate

    Private id_HistoryUpdateAtt As Integer

    Private update_dateAtt As Date

    Private name_responsibleAtt As String

    Property update_date() As Date
        Get
            Return update_dateAtt
        End Get
        Set(ByVal Value As Date)
            update_dateAtt = Value
        End Set
    End Property

    Property id_HistoryUpdate() As Integer
        Get
            Return id_HistoryUpdateAtt
        End Get
        Set(ByVal Value As Integer)
            id_HistoryUpdateAtt = Value
        End Set
    End Property


    Property name_responsible() As String
        Get
            Return name_responsibleAtt
        End Get
        Set(ByVal Value As String)
            name_responsibleAtt = Value.Trim
        End Set
    End Property
End Class
