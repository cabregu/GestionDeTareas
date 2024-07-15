Public Class FrmAsignarTareas


    Public CadenaDeConexion As String = ""
    Private Sub FrmAsignarTareas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
    End Sub

    Private Sub FrmAsignarTareas_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub CmbCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCodigo.SelectedValueChanged
        CargarTareasPorCodigo()
    End Sub

    Private Sub CargarTareasPorCodigo()

        Dim codigoSeleccionado As String = CmbCodigo.Text


        If Not String.IsNullOrEmpty(codigoSeleccionado) Then

            Dim tareas As List(Of Tarea) = Conexion.ObtenertareasPendientes(CadenaDeConexion, codigoSeleccionado)


            If tareas.Count > 0 Then
                Dim tarea As Tarea = tareas(0)
                TxtCliente.Text = tarea.cliente
                TxtProyecto.Text = tarea.proyecto
                TxtTarea.Text = tarea.tarea
                TxtNivelPrioridad.Text = tarea.niveldeprioridad
                TxtFechaLimite.Text = tarea.fechalimite
                TxtComentario.Text = tarea.comentario
            End If
        Else

        End If
    End Sub
    Private Sub CargarUsuarios()
        Dim usuarios As String() = Conexion.ObtenerUsuarios(CadenaDeConexion)
        CmbAsignar.Items.Clear()
        For Each usuario As String In usuarios
            CmbAsignar.Items.Add(usuario)
        Next
    End Sub

    Private Sub BtnAsignar_Click(sender As Object, e As EventArgs) Handles BtnAsignar.Click

    End Sub

    Private Sub BtnAsignarycerrar_Click(sender As Object, e As EventArgs) Handles BtnAsignarycerrar.Click

    End Sub
End Class