Imports Mysqlx.XDevAPI

Public Class FrmModificarEliminar
    Public CadenaDeConexion = ""

    Private Sub FrmModificarEliminar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub FrmModificarEliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnClientes_Click(sender As Object, e As EventArgs) Handles BtnClientes.Click
        Dim Dt As New DataTable
        Dt = Conexion.ObtenerDatosDeTablaPorNombre(CadenaDeConexion, "clientes")
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt
        LblTipoSeleccion.Text = "clientes"
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DgvDatos.AllowUserToAddRows = False
    End Sub

    Private Sub BtnUsuarios_Click(sender As Object, e As EventArgs) Handles BtnUsuarios.Click
        Dim Dt As New DataTable
        Dt = Conexion.ObtenerDatosDeTablaPorNombre(CadenaDeConexion & ";charset=utf8mb4;", "usuarios")
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt
        LblTipoSeleccion.Text = "usuarios"
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DgvDatos.AllowUserToAddRows = False
    End Sub

    Private Sub BtnTareas_Click(sender As Object, e As EventArgs) Handles BtnTareas.Click
        Dim Dt As New DataTable
        Dt = Conexion.ObtenerDatosDeTablaPorNombre(CadenaDeConexion, "proyectotareas")
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt
        LblTipoSeleccion.Text = "proyectotareas"
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DgvDatos.AllowUserToAddRows = False
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        If LblIden.Text = "0" Then
            MessageBox.Show("Por favor, seleccione un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim resultado As Boolean = False

        If LblTipoSeleccion.Text = "proyectotareas" Then
            resultado = Conexion.EliminarRegistroPorID(CadenaDeConexion, "proyectotareas", "idproyectotareas", LblIden.Text)

        ElseIf LblTipoSeleccion.Text = "usuarios" Then
            resultado = Conexion.EliminarRegistroPorID(CadenaDeConexion, "usuarios", "idusuarios", LblIden.Text)

        ElseIf LblTipoSeleccion.Text = "clientes" Then
            resultado = Conexion.EliminarRegistroPorID(CadenaDeConexion, "clientes", "idclientes", LblIden.Text)
        End If

        If resultado Then
            MessageBox.Show("El registro se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DgvDatos.DataSource = Nothing
            LblIden.Text = "0"
            LblTipoSeleccion.Text = "0"

        Else
            MessageBox.Show("Ocurrió un error al eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub DgvDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDatos.CellClick
        If DgvDatos.RowCount > 0 Then
            ' Obtener el índice de la fila seleccionada
            Dim rowIndex As Integer = DgvDatos.SelectedCells(0).RowIndex
            ' Obtener el valor de la primera celda de la fila seleccionada
            Dim cellValue As String = DgvDatos.Rows(rowIndex).Cells(0).Value.ToString()

            LblIden.Text = cellValue


        End If
    End Sub


    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub

    Private Sub LblIden_TextChanged(sender As Object, e As EventArgs) Handles LblIden.TextChanged
        If LblTipoSeleccion.Text <> "0" Then
            BtnEliminar.Enabled = True
            BtnModificar.Enabled = True
        Else
            BtnEliminar.Enabled = False
            BtnModificar.Enabled = True
        End If
    End Sub
End Class