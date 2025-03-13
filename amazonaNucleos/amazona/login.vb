Public Class login

    Private Sub butSubmit_Click(sender As Object, e As EventArgs) Handles butSubmit.Click
        Dim key As String = txtKey.Text
        Dim salt As String = chosenGarage.garage_name & chosenGarage.id_garage
        Dim hashedKey As String = hashStringWithSalt(key, salt)
        If loginGarage(hashedKey) Then
            keepGarageLoggedIn(encryptData(key, password & chosenGarage.garage_name))
            goToHome()
        Else
            lbError.Show()

        End If


    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.Close()
    End Sub

    Private Sub txtKey_TextChanged(sender As Object, e As EventArgs) Handles txtKey.TextChanged
        lbError.Hide()
    End Sub

    Private Sub login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Hide()
        'check if logged in
        Dim garageHashedKey As String = chosenGarage.key
        Dim clearKey As String = decryptData(chosenGarage.key1, password & chosenGarage.garage_name)

        Dim salt As String = chosenGarage.garage_name & chosenGarage.id_garage

        Dim hashedClearKey As String = hashStringWithSalt(clearKey, salt)

        If garageHashedKey = hashedClearKey Then 'garage logged in already
            goToHome()
        Else
            Me.Show()
        End If
    End Sub

    Private Sub goToHome()
        garageHome.Show()
        Me.Hide()
    End Sub
End Class