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

    Private Sub DgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles DgvDatos.DoubleClick
        Dim N As String = DgvDatos.SelectedCells(0).RowIndex.ToString
        Dim STR As String = DgvDatos.Rows(N).Cells("Codigo").Value

        MsgBox(STR)

    End Sub


End Class