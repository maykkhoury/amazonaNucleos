Public Class Transaction
    Private id_transactionAtt As Integer

    Private transactionDateAtt As Date

    Private discountAtt As Double

    Private amountAtt As Double

    Private id_currenyAtt As Integer

    Private client_nameAtt As String

    Property client_name() As String
        Get
            Return client_nameAtt
        End Get
        Set(ByVal Value As String)
            client_nameAtt = Value
        End Set
    End Property


    Property id_transaction() As Integer
        Get
            Return id_transactionAtt
        End Get
        Set(ByVal Value As Integer)
            id_transactionAtt = Value
        End Set
    End Property


    Property transactionDate() As Date
        Get
            Return transactionDateAtt
        End Get
        Set(ByVal Value As Date)
            transactionDateAtt = Value
        End Set
    End Property


    Property discount() As Double
        Get
            Return discountAtt
        End Get
        Set(ByVal Value As Double)
            discountAtt = Value
        End Set
    End Property


    Property amount() As Double
        Get
            Return amountAtt
        End Get
        Set(ByVal Value As Double)
            amountAtt = Value
        End Set
    End Property


    Property id_curreny() As Integer
        Get
            Return id_currenyAtt
        End Get
        Set(ByVal Value As Integer)
            id_currenyAtt = Value
        End Set
    End Property


End Class
