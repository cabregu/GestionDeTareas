Public Class FrmReporte
    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmReporte_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub
End Class