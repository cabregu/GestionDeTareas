Public Class FrmModificarTarea
    Public CadenaDeConexion As String = ""


    Private Sub FrmModificarTarea_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub FrmModificarTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerLasTareasModificables(CadenaDeConexion)
    End Sub

    Public Sub ObtenerLasTareasModificables(ByVal CadenaDeConexionActual As String)
        DgvDatos.DataSource = Nothing
        Dim Dt As New DataTable
        Dt = Conexion.ObtenerTareasNoFinalizadas(CadenaDeConexionActual)
        DgvDatos.DataSource = Dt

    End Sub

    Private Sub DgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles DgvDatos.DoubleClick
        If DgvDatos.RowCount > 0 Then
            Dim N As String = DgvDatos.SelectedCells(0).RowIndex.ToString
            Dim STR As String = DgvDatos.Rows(N).Cells("Codigo").Value
            Dim formulario As New FrmUndatoModificarEliminar
            formulario.CadenaDeConexion = CadenaDeConexion
            formulario.codigo = STR
            formulario.Show()

        End If

    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()

    End Sub


End Class