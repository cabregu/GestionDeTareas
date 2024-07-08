Public Class FrmCrearTareasPendientes

    Public CadenaDeConexion As String = ""

    Private Sub FrmCrearTareasPendientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmPpal.Visible = True

    End Sub

    Private Sub FrmCrearTareasPendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
        CargarProyecto()
        CargarUsuarios()
    End Sub

    Private Sub CmbProyecto_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbProyecto.SelectedValueChanged
        CmbTareas.Text = ""
        CargarTareas(CmbProyecto.Text)
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        CmbAsignar.Text = ""
    End Sub

    Private Sub BtnCrearTareaysalir_Click(sender As Object, e As EventArgs) Handles BtnCrearTareaysalir.Click
        Me.Close()

    End Sub
    Private Sub BtnCrearTarea_Click(sender As Object, e As EventArgs) Handles BtnCrearTarea.Click

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

End Class