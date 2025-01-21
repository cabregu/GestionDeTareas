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

        LblPorEsto1.Visible = False
        TxtValorNuevo.Visible = False
        LblPorEsto2.Visible = True
        CmbValorNuevo.Visible = True



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
            Dim columnName As String = DgvDatos.Columns(e.ColumnIndex).Name

            ' Si la columna es "rango", mostramos el ComboBox
            If columnName.Equals("rango", StringComparison.OrdinalIgnoreCase) Then
                Dim rowIndex As Integer = e.RowIndex
                Dim cellValue As String = DgvDatos.Rows(rowIndex).Cells(e.ColumnIndex).Value.ToString()
                Dim firstColumnValue As String = DgvDatos.Rows(rowIndex).Cells(0).Value.ToString()

                ' Llenar el ComboBox con las opciones
                CmbValorNuevo.Visible = True
                LblPorEsto1.Visible = False
                LblPorEsto2.Visible = True
                CmbValorNuevo.Items.Clear()
                CmbValorNuevo.Items.Add("Administrador")
                CmbValorNuevo.Items.Add("Creador de Contenido")
                CmbValorNuevo.Items.Add("Usuario")


                ' Seleccionar el valor actual en el ComboBox
                CmbValorNuevo.SelectedItem = cellValue

                ' Mostrar el ComboBox y ocultar el TextBox
                CmbValorNuevo.Visible = True
                TxtValorNuevo.Visible = False

                ' Actualizar etiquetas y controles
                LblIden.Text = firstColumnValue
                LblCampo.Text = columnName

            Else
                ' Si no es "rango", usar el TextBox
                Dim rowIndex As Integer = e.RowIndex
                Dim cellValue As String = DgvDatos.Rows(rowIndex).Cells(e.ColumnIndex).Value.ToString()
                Dim firstColumnValue As String = DgvDatos.Rows(rowIndex).Cells(0).Value.ToString()

                ' Mostrar el TextBox y ocultar el ComboBox
                CmbValorNuevo.Visible = False
                LblPorEsto2.Visible = False

                LblPorEsto1.Visible = True
                TxtValorNuevo.Visible = True

                ' Actualizar etiquetas y controles
                LblIden.Text = firstColumnValue
                LblCampo.Text = columnName
                TxtValorAModificar.Text = cellValue
                TxtValorNuevo.Text = cellValue
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
        ' Obtener el nuevo valor desde el control correspondiente
        Dim nuevoValor As String

        If LblCampo.Text.Equals("rango", StringComparison.OrdinalIgnoreCase) Then
            If CmbValorNuevo.SelectedItem Is Nothing Then
                MessageBox.Show("Seleccione un valor válido en el rango.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            nuevoValor = CmbValorNuevo.SelectedItem.ToString()
        Else
            If String.IsNullOrEmpty(TxtValorNuevo.Text) Then
                MessageBox.Show("El nuevo valor no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            nuevoValor = TxtValorNuevo.Text
        End If

        ' Verificar si el valor ha cambiado
        If TxtValorAModificar.Text <> nuevoValor Then
            Dim resultado As Boolean = False

            ' Actualizar según la tabla seleccionada
            If LblTabla.Text = "proyectotareas" Then
                resultado = Conexion.ActualizarRegistroPorTablaYporID(CadenaDeConexion, LblTabla.Text, LblCampo.Text, nuevoValor, "idproyectotareas", LblIden.Text)
            ElseIf LblTabla.Text = "usuarios" Then
                resultado = Conexion.ActualizarRegistroPorTablaYporID(CadenaDeConexion, LblTabla.Text, LblCampo.Text, nuevoValor, "idusuarios", LblIden.Text)
            ElseIf LblTabla.Text = "clientes" Then
                resultado = Conexion.ActualizarRegistroPorTablaYporID(CadenaDeConexion, LblTabla.Text, LblCampo.Text, nuevoValor, "idclientes", LblIden.Text)
            End If

            ' Mostrar mensaje según el resultado
            If resultado Then
                MessageBox.Show("El registro se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtValorAModificar.Text = ""
                TxtValorNuevo.Text = ""
                DgvDatos.DataSource = Nothing
            Else
                MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El valor no ha cambiado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub FrmModificarEliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub
End Class