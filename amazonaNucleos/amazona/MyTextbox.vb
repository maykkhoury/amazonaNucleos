Imports System.ComponentModel

Namespace garageApp
    Public Class MyTextBox
        Inherits TextBox


        Overrides Property Text() As String
            Get
                Dim str As String = SafeSqlLiteral(MyBase.Text)
                If str Is Nothing Then
                    Return ""
                Else
                    Return str
                End If

            End Get
            Set(ByVal value As String)
                MyBase.Text = value
                Me.Invalidate()
            End Set
        End Property

    End Class
End Namespace
