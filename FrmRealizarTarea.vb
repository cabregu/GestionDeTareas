Public Class FrmRealizarTarea
    Public CadenaDeConexion As String = ""

    Private Sub FrmRealizarTarea_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub FrmRealizarTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarConCodigos(CadenaDeConexion, LblUsuario.Text)
    End Sub

    Private Sub CmbCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCodigo.SelectedValueChanged
        CargarTareasPorCodigo()
    End Sub




    Public Sub LlenarConCodigos(ByVal CadenaConexion As String, ByVal Usuario As String)
        Dim codigos() As String = Conexion.ObtenerCodigoPorUsuario(CadenaConexion, Usuario)
        CmbCodigo.Items.Clear()
        For Each codigo As String In codigos
            CmbCodigo.Items.Add(codigo)
        Next
    End Sub
    Private Sub CargarTareasPorCodigo()

        Dim codigoSeleccionado As String = CmbCodigo.Text
        If Not String.IsNullOrEmpty(codigoSeleccionado) Then

            Dim tareas As List(Of Tarea) = Conexion.ObtenertareasPendientesdeUsuario(CadenaDeConexion, codigoSeleccionado)


            If tareas.Count > 0 Then
                Dim tarea As Tarea = tareas(0)
                TxtCliente.Text = tarea.cliente
                TxtProyecto.Text = tarea.proyecto
                TxtTarea.Text = tarea.tarea
                TxtNiveldePrioridad.Text = tarea.niveldeprioridad
                TxtFechaLimite.Text = tarea.fechalimite
                TxtComentario.Text = tarea.comentario
                TxtEstado.Text = tarea.estado
                TxtFechaInicio.Text = tarea.fechadeinicio

            End If
        Else

        End If
    End Sub

    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles BtnIniciar.Click

        Dim FechaHoraServer As DateTime = Conexion.ObtenerFechaHoraServidor(CadenaDeConexion)
        If Conexion.ActualizarFechaInicioPorCodigo(CadenaDeConexion, CmbCodigo.Text, FechaHoraServer) = True Then
            MsgBox("Tarea iniciada")

        End If

    End Sub


End Class