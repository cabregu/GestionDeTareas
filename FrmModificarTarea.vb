Public Class FrmModificarTarea
    Public CadenaDeConexion As String = ""


    Private Sub FrmModificarTarea_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub FrmModificarTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerLasTareasModificables()
    End Sub

    Private Sub ObtenerLasTareasModificables()
        DgvDatos.DataSource = Nothing
        Dim Dt As New DataTable
        Dt = Conexion.ObtenerTareasNoFinalizadas(CadenaDeConexion)
        DgvDatos.DataSource = Dt

    End Sub



End Class