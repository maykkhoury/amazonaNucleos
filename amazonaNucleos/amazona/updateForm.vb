Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Threading

Public Class updateForm
    Dim thread As System.Threading.Thread
    Dim thread2 As System.Threading.Thread
    Dim i As Integer
    Dim max As Integer
    ''update
    Private Sub countup()

        Do Until i = max
            'i = i + 1

            lbRemains.Text = i & "/" & max
            Me.Refresh()
        Loop


    End Sub
    Private Sub updateThread()
        Try
            Dim errors As String = ""
            Dim updateFilePath As String = txtUpdatePath.Text
            Dim objStreamReader As StreamReader
            'Pass the file path and the file name to the StreamWriter constructor.
            objStreamReader = New StreamReader(updateFilePath)
            prgUpdate.Maximum = max
            prgUpdate.Step = 1
            Do While objStreamReader.Peek() >= 0
                Dim query As String = objStreamReader.ReadLine()
                i += 1
                prgUpdate.PerformStep()
                errors &= performQuery(query)
            Loop

            Try
                prgUpdate.Value = 0
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If errors.Trim = "" Then
                MsgBox("Your application has been successfully update:" & vbNewLine & "Please restart your application", MsgBoxStyle.Information)
            Else
                writeLogfile(errors, updateFilePath & ".log")
                MsgBox("Your application has been successfully update, but some errors occured, please check the log file at (" & updateFilePath & ".log", MsgBoxStyle.Information)
            End If
            butBrowseUpdate.Enabled = True
            butUpdateApp.Enabled = True
            'butBackup.Enabled = True
            'butReintegrate.Enabled = True

            thread.Abort()
            thread2.Abort()
            Me.Close()
            'Close the file.
        Catch ex As IOException
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub butUpdateApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUpdateApp.Click

        If txtUpdatePath.Text = "" Then
            MsgBox("Please choose a directory first", MsgBoxStyle.Information)
            Exit Sub
        End If
        Try
            Dim updateFilePath As String = txtUpdatePath.Text
            Dim objStreamReader As StreamReader
            'Pass the file path and the file name to the StreamWriter constructor.
            objStreamReader = New StreamReader(updateFilePath)
            'Dim max As Integer = 0
            Do While objStreamReader.Peek() >= 0
                Dim query As String = objStreamReader.ReadLine()
                max += 1
                'performQuery(query)
            Loop
            'Close the file.
            objStreamReader.Close()
            lbRemains.Text = "0/" & max
            butBrowseUpdate.Enabled = False
            butUpdateApp.Enabled = False
            'butBackup.Enabled = False
            'butReintegrate.Enabled = False

            thread = New System.Threading.Thread(AddressOf countup)
            thread.Start()

            thread2 = New System.Threading.Thread(AddressOf updateThread)
            thread2.Start()

        Catch ex As IOException
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub writeLogfile(ByVal str As String, ByVal updateFilelog As String)
        Try
            Dim newF As FileStream = File.Create(updateFilelog, FileOptions.RandomAccess)
            newF.Close()
            'Pass the file path and the file name to the StreamWriter constructor.
            Dim objStreamWriter As New StreamWriter(updateFilelog)
            objStreamWriter.WriteLine(str)
            'Close the file.
            objStreamWriter.Close()
        Catch ex As IOException
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub butBrowseUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBrowseUpdate.Click
        If fileDialog.ShowDialog() = DialogResult.OK Then
            txtUpdatePath.Text = fileDialog.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub updateForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If thread Is Nothing Then
            Exit Sub
        End If
        If thread2 Is Nothing Then
            Exit Sub
        End If
        If thread.IsAlive Or thread2.IsAlive Then
            If MsgBox("Closing the form is noot recommended, Data may be corrupted! Close anyways?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                thread.Abort()
                thread2.Abort()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub updateForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbRemains.Text = ""
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub


End Class