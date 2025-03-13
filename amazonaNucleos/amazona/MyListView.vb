Namespace garageApp
    Public Class MyListView
        Inherits ListView


        WriteOnly Property MyListView()

            Set(ByVal value)
                Me.DoubleBuffered = True
            End Set
        End Property

    End Class
End Namespace
