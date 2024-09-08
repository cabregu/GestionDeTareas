Imports Mysqlx.XDevAPI

Public Class FrmModificarEliminar
    Public CadenaDeConexion = ""
    Dim Dt As New DataTable
    Private Sub FrmModificarEliminar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub


    Private Sub BtnClientes_Click(sender As Object, e As EventArgs) Handles BtnClientes.Click

        Dt = Conexion.ObtenerDatosDeTablaPorNombre(CadenaDeConexion, "clientes")
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt
        LblTabla.Text = "clientes"
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.ReadOnly = True

    End Sub

    Private Sub BtnUsuarios_Click(sender As Object, e As EventArgs) Handles BtnUsuarios.Click

        Dt = Conexion.ObtenerDatosDeTablaPorNombre(CadenaDeConexion & ";charset=utf8mb4;", "usuarios")
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt
        LblTabla.Text = "usuarios"
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.ReadOnly = True

    End Sub

    Private Sub BtnTareas_Click(sender As Object, e As EventArgs) Handles BtnTareas.Click

        Dt = Conexion.ObtenerDatosDeTablaPorNombre(CadenaDeConexion, "proyectotareas")
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt
        LblTabla.Text = "proyectotareas"
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.ReadOnly = True

    End Sub




    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        If LblIden.Text = "0" Then
            MessageBox.Show("Por favor, seleccione un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar el registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmResult = DialogResult.Yes Then
            Dim resultado As Boolean = False

            If LblTabla.Text = "proyectotareas" Then
                resultado = Conexion.EliminarRegistroPorID(CadenaDeConexion, "proyectotareas", "idproyectotareas", LblIden.Text)
            ElseIf LblTabla.Text = "usuarios" Then
                resultado = Conexion.EliminarRegistroPorID(CadenaDeConexion, "usuarios", "idusuarios", LblIden.Text)
            ElseIf LblTabla.Text = "clientes" Then
                resultado = Conexion.EliminarRegistroPorID(CadenaDeConexion, "clientes", "idclientes", LblIden.Text)
            End If

            If resultado Then
                MessageBox.Show("El registro se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DgvDatos.DataSource = Nothing
                LblIden.Text = "0"
                LblTabla.Text = "0"
                TxtValorAModificar.Text = ""
                TxtValorNuevo.Text = ""
            Else
                MessageBox.Show("Ocurrió un error al eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("La eliminación ha sido cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub DgvDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDatos.CellClick
        If DgvDatos.RowCount > 0 AndAlso e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Verificar si la columna seleccionada no es la primera columna
            If e.ColumnIndex > 0 Then
                Dim rowIndex As Integer = e.RowIndex
                Dim cellValue As String = DgvDatos.Rows(rowIndex).Cells(e.ColumnIndex).Value.ToString()
                Dim columnName As String = DgvDatos.Columns(e.ColumnIndex).Name
                Dim columnIndex As Integer = e.ColumnIndex

                ' Obtener el valor de la primera columna
                Dim firstColumnValue As String = DgvDatos.Rows(rowIndex).Cells(0).Value.ToString()

                ' Actualizar los controles con los valores obtenidos
                LblIden.Text = firstColumnValue
                LblCampo.Text = columnName
                TxtValorAModificar.Text = cellValue
                TxtValorNuevo.Text = cellValue
            Else
                MsgBox("No se puede seleccionar el Identificador")
            End If
        End If
    End Sub


    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub

    Private Sub LblIden_TextChanged(sender As Object, e As EventArgs) Handles LblIden.TextChanged
        If LblTabla.Text <> "0" Then
            BtnEliminar.Enabled = True
            BtnModificar.Enabled = True
        Else
            BtnEliminar.Enabled = False
            BtnModificar.Enabled = True
        End If
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        If TxtValorAModificar.Text <> TxtValorNuevo.Text Then
            Dim resultado As Boolean = False

            If LblTabla.Text = "proyectotareas" Then
                resultado = Conexion.ActualizarRegistroPorTablaYporID(CadenaDeConexion, LblTabla.Text, LblCampo.Text, TxtValorNuevo.Text, "idproyectotareas", LblIden.Text)
            ElseIf LblTabla.Text = "usuarios" Then
                resultado = Conexion.ActualizarRegistroPorTablaYporID(CadenaDeConexion, LblTabla.Text, LblCampo.Text, TxtValorNuevo.Text, "idusuarios", LblIden.Text)
            ElseIf LblTabla.Text = "clientes" Then
                resultado = Conexion.ActualizarRegistroPorTablaYporID(CadenaDeConexion, LblTabla.Text, LblCampo.Text, TxtValorNuevo.Text, "idclientes", LblIden.Text)
            End If

            If resultado Then
                MessageBox.Show("El registro se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                TxtValorAModificar.Text = ""
                TxtValorNuevo.Text = ""
                DgvDatos.DataSource = Nothing

            Else
                MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub FrmModificarEliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub
End Class