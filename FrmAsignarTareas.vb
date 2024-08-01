Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FrmAsignarTareas


    Public CadenaDeConexion As String = ""
    Private Sub FrmAsignarTareas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        Me.MaximizeBox = False

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
        Actualizartarea()
    End Sub

    Private Sub BtnAsignarycerrar_Click(sender As Object, e As EventArgs) Handles BtnAsignarycerrar.Click
        Actualizartarea()
        Me.Close()
    End Sub


    Private Sub Actualizartarea()

        If CmbAsignar.SelectedItem IsNot Nothing Then
            Dim selectedValue As String = CmbAsignar.SelectedItem.ToString()

            For Each item As String In CmbAsignar.Items
                If item = selectedValue Then

                    If Conexion.ActualizarUsuarioPorCodigo(CadenaDeConexion, CmbCodigo.Text, CmbAsignar.Text) = True Then

                        TxtCliente.Text = ""
                        TxtProyecto.Text = ""
                        TxtTarea.Text = ""
                        TxtNivelPrioridad.Text = ""
                        TxtFechaLimite.Text = ""
                        TxtComentario.Text = ""
                        CmbCodigo.Text = ""
                        CmbAsignar.Text = ""

                        CargarTareas()

                    End If

                    Exit For
                End If
            Next
        Else
            MessageBox.Show("No selecciono el Usuario")
        End If

    End Sub
    Private Sub CargarTareas()
        Dim tareasPendientes As String() = Conexion.ObtenertareasPendientes(CadenaDeConexion)

        If tareasPendientes.Length = 0 Then
            MessageBox.Show("No hay tareas pendientes.")
            CmbCodigo.Items.Clear()
        Else
            CmbCodigo.Items.Clear()

            For Each codigo As String In tareasPendientes
                CmbCodigo.Items.Add(codigo)
            Next

        End If
    End Sub


End Class