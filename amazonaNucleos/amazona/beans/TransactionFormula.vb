Public Class TransactionFormula
    Private id_transactionFormulaAtt As Integer

    Private id_formulaAtt As Integer

    Private id_transactionAtt As Integer


    Property id_transactionFormula() As Integer
        Get
            Return id_transactionFormulaAtt
        End Get
        Set(ByVal Value As Integer)
            id_transactionFormulaAtt = Value
        End Set
    End Property


    Property id_formula() As Integer
        Get
            Return id_formulaAtt
        End Get
        Set(ByVal Value As Integer)
            id_formulaAtt = Value
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


End Class
