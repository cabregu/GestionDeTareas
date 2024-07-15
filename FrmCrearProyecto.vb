Public Class FrmCrearProyecto
    Private Sub FrmCrearProyecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmCrearProyecto_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub
End Class