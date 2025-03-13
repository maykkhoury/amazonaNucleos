Imports System.ComponentModel

Namespace garageApp
    Public Class TranslatedLabel
        Inherits System.Windows.Forms.Label


        Overrides Property Text() As String
            Get
                Return MyBase.Text

            End Get
            Set(ByVal value As String)
                If testConnection() Then
                    MyBase.Text = getLabelDescription(MyBase.Name)
                    If MyBase.Text = "" Then
                        MyBase.Text = value
                    End If
                Else
                    MyBase.Text = value
                End If

                Me.Invalidate()
            End Set
        End Property

        Private Function testConnection() As Boolean
            Try
                If DB.State = ConnectionState.Closed Or DB.State = ConnectionState.Broken Then
                    DB.ConnectionString = conString
                    DB.Open()
                End If
                testConnection = True
            Catch ex As Exception
                testConnection = False
            End Try
        End Function
    End Class
End Namespace
