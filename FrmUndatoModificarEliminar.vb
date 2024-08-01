Public Class FrmUndatoModificarEliminar
    Public CadenaDeConexion As String = ""
    Public codigo As String = ""
    Private Sub FrmUndatoModificarEliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtCodigo.Text = codigo
        CargarClientes()
        CargarProyecto()
        CargarUsuarios()
        CargarTareasPorCodigo()
        CargarTareas(CmbProyecto.Text)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
    End Sub



    Private Sub CargarTareasPorCodigo()

        Dim codigoSeleccionado As String = codigo


        If Not String.IsNullOrEmpty(codigoSeleccionado) Then

            Dim tareas As List(Of Tarea) = Conexion.ObtenertareasUnaTareaPorCodigo(CadenaDeConexion, codigoSeleccionado)


            If tareas.Count > 0 Then
                Dim tarea As Tarea = tareas(0)
                CmbCliente.Text = tarea.cliente
                CmbProyecto.Text = tarea.proyecto
                CmbTarea.Text = tarea.tarea
                CmbPrioridad.Text = tarea.niveldeprioridad
                DtpFechaLimite.Text = tarea.fechalimite
                TxtComentario.Text = tarea.comentario
                TxtEstadoActual.Text = tarea.estado
                CmbUsuario.Text = tarea.usuario
            End If
        Else

        End If
    End Sub
    Private Sub CargarProyecto()
        Dim proyectos As String() = Conexion.ObtenerProyectos(CadenaDeConexion)
        CmbProyecto.Items.Clear()
        For Each proyecto As String In proyectos
            CmbProyecto.Items.Add(proyecto)
        Next
    End Sub
    Private Sub CargarClientes()
        Dim clientes As String() = Conexion.ObtenerClientes(CadenaDeConexion)
        CmbCliente.Items.Clear()
        For Each cliente As String In clientes
            CmbCliente.Items.Add(cliente)
        Next
    End Sub
    Private Sub CargarTareas(ByVal Proyecto As String)
        Dim tareas As String() = Conexion.ObtenertareasPorProyecto(Proyecto, CadenaDeConexion)
        CmbTarea.Items.Clear()
        For Each tarea As String In tareas
            CmbTarea.Items.Add(tarea)
        Next
    End Sub
    Private Sub CargarUsuarios()
        Dim usuarios As String() = Conexion.ObtenerUsuarios(CadenaDeConexion)
        CmbUsuario.Items.Clear()
        For Each usuario As String In usuarios
            CmbUsuario.Items.Add(usuario)
        Next
    End Sub

    Private Sub CmbProyecto_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbProyecto.SelectedValueChanged
        CmbTarea.Text = ""
        CargarTareas(CmbProyecto.Text)
    End Sub

    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click
        If Conexion.ActualizarKanbasPorCodigo(CadenaDeConexion, codigo, CmbCliente.Text, CmbProyecto.Text, CmbTarea.Text, CmbPrioridad.Text, CmbUsuario.Text, DtpFechaLimite.Value, TxtComentario.Text) = True Then
            MsgBox("Se actualizo correctamente")
            Me.Close()
        End If
    End Sub

    Private Sub FrmUndatoModificarEliminar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmModificarTarea.ObtenerLasTareasModificables(CadenaDeConexion)
        FrmModificarTarea.Refresh()
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            If Conexion.EliminarKanbasPorCodigo(CadenaDeConexion, codigo) = True Then
                MsgBox("Se eliminó el registro correctamente")
                Me.Close()
            Else
                MsgBox("No se pudo eliminar el registro")
            End If
        End If
    End Sub


End Class