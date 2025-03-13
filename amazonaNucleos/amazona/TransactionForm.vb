Public Class TransactionForm



    Private Sub butSearchCarForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearchTransaction.Click

        Dim tDate As Date = dpTransactionDate.Value
        Dim transactionFiltered() As Transaction = getTransactionTab(chosenFormula.id_formula, tDate)

        addResultsToListviewTransaction(transactionFiltered)
    End Sub

    Public Sub addResultsToListviewTransaction(ByVal transactionFiltered() As Transaction)
        Try
            lsvTransaction.Items.Clear()
            Dim i As Integer = 0
            For i = 0 To transactionFiltered.Length - 1
                lsvTransaction.Items.Add(transactionFiltered(i).id_transaction)
                lsvTransaction.Items(i).SubItems.Add(chosenFormula.name_formula)
                lsvTransaction.Items(i).SubItems.Add(transactionFiltered(i).transactionDate)
                lsvTransaction.Items(i).SubItems.Add(transactionFiltered(i).amount)
                lsvTransaction.Items(i).SubItems.Add(transactionFiltered(i).discount)
                lsvTransaction.Items(i).SubItems.Add(getCurrency(transactionFiltered(i).id_curreny).code_currency)
                lsvTransaction.Items(i).SubItems.Add(transactionFiltered(i).client_name)
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class