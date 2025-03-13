Public Class imagePreview

    Private Sub imagePreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = imageToPreview.Size
        Me.BackgroundImage = imageToPreview
    End Sub
End Class