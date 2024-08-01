Public Class FrmConfiguracion
    Private Sub FrmConfiguracion_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
    End Sub
End Class