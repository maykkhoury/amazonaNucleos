Imports System.IO

Public Class NucleosSettings

    Private Sub settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setCurrentValues()
    End Sub

    Private Sub setCurrentValues()
        cmbMaxResult.Text = ResultLimit
        cmbDeltaLs.Text = DeltaSolid
        cmbDeltaBC.Text = DeltaEffect
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDone.Click

        persistInFile()
        Me.Close()
    End Sub
    Private Sub persistInFile()
        ' File name to create
        Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory

        Dim resultLimitFilePath As String = Path.Combine(exeDirectory, "settings-resultLimit.txt")
        File.WriteAllText(resultLimitFilePath, ResultLimit)

        Dim deltalsFilePath As String = Path.Combine(exeDirectory, "settings-deltals.txt")
        File.WriteAllText(deltalsFilePath, DeltaSolid)

        Dim deltabcFilePath As String = Path.Combine(exeDirectory, "settings-deltabc.txt")
        File.WriteAllText(deltabcFilePath, DeltaEffect)

    End Sub
    Private Sub cmbMaxResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaxResult.SelectedIndexChanged
        ResultLimit = cmbMaxResult.SelectedItem.ToString
    End Sub

    Private Sub cmbDeltaLs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeltaLs.SelectedIndexChanged
        DeltaSolid = cmbDeltaLs.SelectedItem.ToString
    End Sub

    Private Sub cmbDeltaBC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeltaBC.SelectedIndexChanged
        DeltaEffect = cmbDeltaBC.SelectedItem.ToString
    End Sub
End Class