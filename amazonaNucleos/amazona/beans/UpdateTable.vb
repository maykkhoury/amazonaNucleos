Public Class UpdateTable

    Private id_updateTableAtt As Integer

    Private actionTypeAtt As String

    Private id_actionAtt As Integer

    Private text_line As String

    Property text_lineType() As String
        Get
            Return text_line
        End Get
        Set(ByVal Value As String)
            text_line = Value
        End Set
    End Property

    Property actionType() As String
        Get
            Return actionTypeAtt
        End Get
        Set(ByVal Value As String)
            actionTypeAtt = Value
        End Set
    End Property


    Property id_action() As Integer
        Get
            Return id_actionAtt
        End Get
        Set(ByVal Value As Integer)
            id_actionAtt = Value
        End Set
    End Property

    Property id_updateTable() As Integer
        Get
            Return id_updateTableAtt
        End Get
        Set(ByVal Value As Integer)
            id_updateTableAtt = Value
        End Set
    End Property


End Class
