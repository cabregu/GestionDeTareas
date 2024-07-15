Public Class FrmCrearCliente
    Private Sub FrmCrearCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmCrearCliente_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub
End Class