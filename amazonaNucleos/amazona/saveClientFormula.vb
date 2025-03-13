Public Class saveClientFormula

    Private Sub txtQuantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFName.GotFocus, txtColorCode.GotFocus
        sender.selectAll()
    End Sub

    Private Sub txtColorCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColorCode.KeyPress, txtFName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

        End If
    End Sub


    Private Sub assignColorByCode_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub butBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBack.Click
        Me.Close()
    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveNew.Click
        If txtColorCode.Text.Trim <> "" And txtFName.Text.Trim <> "" And txtYearMin.Text.Trim <> "" Then
            details.butSaveContinue()


        Else
            MsgBox("All values must be assigned.", MsgBoxStyle.Exclamation)
        End If


    End Sub
End Class