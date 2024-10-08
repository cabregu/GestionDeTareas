﻿Public Class FrmCrearTareasPendientes

    Public CadenaDeConexion As String = ""

    Private Sub FrmCrearTareasPendientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmPpal.Visible = True

    End Sub

    Private Sub FrmCrearTareasPendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        CargarClientes()
        CargarProyecto()
        CargarUsuarios()

        Dim Codigo As Integer = Conexion.ObtenerCodigo(CadenaDeConexion)
        LblCodigo.Text = Codigo


        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False


    End Sub

    Private Sub CmbProyecto_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbProyecto.SelectedValueChanged
        CmbTareas.Text = ""
        CargarTareas(CmbProyecto.Text)
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        CmbAsignar.Text = ""
    End Sub

    Private Sub BtnCrearTareaysalir_Click(sender As Object, e As EventArgs) Handles BtnCrearTareaysalir.Click

        If CmbAsignar.Text = "" Then
            Creartarea()
            Me.Close()
        Else
            Creartarea("Asignada")
            Me.Close()
        End If



    End Sub


    Private Sub BtnCrearTarea_Click(sender As Object, e As EventArgs) Handles BtnCrearTarea.Click

        If CmbAsignar.Text = "" Then
            Creartarea()
        Else
            Creartarea("Asignada")
        End If

    End Sub


    Private Sub Creartarea(Optional ByVal Estado As String = "Pendiente")

        ' Validar los campos obligatorios
        If String.IsNullOrEmpty(LblCodigo.Text) OrElse
       String.IsNullOrEmpty(CmbCliente.Text) OrElse
       String.IsNullOrEmpty(CmbProyecto.Text) OrElse
       String.IsNullOrEmpty(CmbTareas.Text) OrElse
       String.IsNullOrEmpty(CmbPrioridad.Text) OrElse
       String.IsNullOrEmpty(TxtComentario.Text) Then

            MsgBox("Todos los campos obligatorios deben ser completados.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim codigo As Integer = Integer.Parse(LblCodigo.Text)
        Dim cliente As String = CmbCliente.Text
        Dim proyecto As String = CmbProyecto.Text
        Dim tarea As String = CmbTareas.Text
        Dim nivelDePrioridad As String = CmbPrioridad.Text
        Dim fechaLimite As Date = DtpFechaLimite.Value
        Dim comentario As String = TxtComentario.Text
        Dim usuario As String = CmbAsignar.Text
        Dim fechaDeInicio As DateTime? = Nothing
        Dim tiempo As String = Nothing
        Dim FechaCreacion As DateTime = Conexion.ObtenerFechaHoraServidor(CadenaDeConexion)



        ' Intentar insertar el registro
        Dim resultado As Boolean = Conexion.InsertarKanba(CadenaDeConexion, codigo, cliente, proyecto, tarea, nivelDePrioridad, usuario, fechaLimite, Estado, fechaDeInicio, tiempo, comentario, FechaCreacion)

        ' Mostrar resultado
        If resultado Then
            MsgBox("El registro se insertó correctamente.")

            ' Limpiar los campos del formulario
            CmbCliente.Text = ""
            CmbProyecto.Text = ""
            CmbTareas.Text = ""
            CmbPrioridad.Text = ""
            TxtComentario.Text = ""
            CmbAsignar.Text = ""

            ' Actualizar el código
            Conexion.ActualizarCodigo(CadenaDeConexion, LblCodigo.Text)

            ' Obtener el nuevo código desde la base de datos
            Dim Codigonuevo As Integer = Conexion.ObtenerCodigo(CadenaDeConexion)
            LblCodigo.Text = Codigonuevo

        Else
            MsgBox("El código ya existe en la tabla se actualizo el nuevo codigo.")
            LblCodigo.Text = Conexion.ObtenerCodigo(CadenaDeConexion)
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
        CmbTareas.Items.Clear()
        For Each tarea As String In tareas
            CmbTareas.Items.Add(tarea)
        Next
    End Sub
    Private Sub CargarUsuarios()
        Dim usuarios As String() = Conexion.ObtenerUsuarios(CadenaDeConexion)
        CmbAsignar.Items.Clear()
        For Each usuario As String In usuarios
            CmbAsignar.Items.Add(usuario)
        Next
    End Sub

    Private Sub CmbTareas_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTareas.SelectedValueChanged
        If CmbTareas.Text <> "" Then
            BtnCrearTarea.Enabled = True
            BtnCrearTareaysalir.Enabled = True
        End If
    End Sub


End Class