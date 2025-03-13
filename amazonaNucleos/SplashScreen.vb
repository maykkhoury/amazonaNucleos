Imports System.Text
Imports System.IO
Public Class SplashScreen
    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  
        Control.CheckForIllegalCrossThreadCalls = False

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        ' Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Dim versiontxt As String = ""
        Dim applicationLabeltxt As String = ""
        Try
            Dim fileContents() As String = File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory() & "//vers.txt", Encoding.UTF8)
            If fileContents.Length > 1 Then
                applicationLabeltxt = fileContents(0)
                versiontxt = fileContents(1)
            Else
                versiontxt = fileContents(0)
            End If

        Catch ex As Exception

        End Try

        Version.Text = "Version:" & versiontxt
        ApplicationTitle.Text = applicationLabeltxt
        'Copyright info
        Copyright.Text = My.Application.Info.Copyright

        Dim imgPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "//logo.jpg"
        Try

            MainLayoutPanel.BackgroundImage = Image.FromFile(imgPath)
            MainLayoutPanel.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception

        End Try
    End Sub
End Class