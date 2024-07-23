Public Class FrmCrearProyecto

    Public CadenaDeConexion As String = ""

    Private Sub FrmCrearProyecto_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub RbProyectoExistente_CheckedChanged(sender As Object, e As EventArgs) Handles RbProyectoExistente.CheckedChanged
        If RbProyectoExistente.Checked = True Then


        End If
    End Sub

    Private Sub RbNuevoProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles RbNuevoProyecto.CheckedChanged
        If RbNuevoProyecto.Checked = True Then

        End If
    End Sub
End Class