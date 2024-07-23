Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

Public Class FrmPpal

    Public Cadenadeconexion As String = ""

    Private Sub FrmPpal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        PausarTareas()
        MsgBox("Si hay tareas ejecutando seran pausadas")

        Application.Exit()

    End Sub
    Private Sub BtnCrearTarea_Click(sender As Object, e As EventArgs) Handles BtnCrearTarea.Click
        Dim formulario As New FrmCrearTareasPendientes()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnAsignarTarea_Click(sender As Object, e As EventArgs) Handles BtnAsignarTarea.Click

        Dim tareasPendientes As String() = Conexion.ObtenertareasPendientes(Cadenadeconexion)

        If tareasPendientes.Length = 0 Then
            MessageBox.Show("No hay tareas pendientes.")
        Else
            Dim formulario As New FrmAsignarTareas()
            For Each codigo As String In tareasPendientes
                formulario.CmbCodigo.Items.Add(codigo)
                formulario.CadenaDeConexion = Cadenadeconexion

            Next
            formulario.Show()
            Me.Hide()
        End If



    End Sub

    Private Sub BtnRealizarTarea_Click(sender As Object, e As EventArgs) Handles BtnRealizarTarea.Click
        Dim formulario As New FrmRealizarTarea()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.LblUsuario.Text = LblUsuario.Text
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BrnModificarTarea_Click(sender As Object, e As EventArgs) Handles BtnModificarTarea.Click
        FrmModificarTarea.CadenaDeConexion = Cadenadeconexion
        FrmModificarTarea.Show()
        Me.Hide()
    End Sub

    Private Sub BtnCrearUsuario_Click(sender As Object, e As EventArgs) Handles BtnCrearUsuario.Click
        Dim formulario As New FrmUsuario()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnCrearCliente_Click(sender As Object, e As EventArgs) Handles BtnCrearCliente.Click
        Dim formulario As New FrmCrearCliente()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnCrearProyecto_Click(sender As Object, e As EventArgs) Handles BtnCrearProyecto.Click
        Dim formulario As New FrmCrearProyecto()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnModificarDatos_Click(sender As Object, e As EventArgs) Handles BtnModificarDatos.Click
        Dim formulario As New FrmModificarEliminar()
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        Dim formulario As New FrmReporte()
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles BtnConfiguracion.Click

        Dim formulario As New FrmConfiguracion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    'funcion para importar del access principal 
    Public Sub TransferirDatos(accessTableName As String, mysqlTableName As String, columnsToImport As String())
        ' Ruta y cadena de conexión a la base de datos Access
        Dim rutaBaseDatos As String = "C:\Users\Cristian\Desktop\hensel\appdegestion.accdb"
        Dim cadenaConexion As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaBaseDatos};Jet OLEDB:Database Password=Gmt@2022;"

        Using accessConnection As New OleDbConnection(cadenaConexion)
            accessConnection.Open()
            ' Construir la consulta SELECT en Access con las columnas especificadas
            Dim accessQuery As String = $"SELECT {String.Join(", ", columnsToImport)} FROM {accessTableName}"
            Dim accessCommand As New OleDbCommand(accessQuery, accessConnection)
            Dim reader As OleDbDataReader = accessCommand.ExecuteReader()

            ' Conexión a la base de datos MySQL
            Dim mysqlConnectionString As String = "server=localhost;User Id=root;password=123456;database=gestion;Persist Security Info=True;"
            Using mysqlConnection As New MySqlConnection(mysqlConnectionString)
                mysqlConnection.Open()

                ' Leer los datos desde Access y transferir a MySQL
                While reader.Read()
                    Dim insertQuery As String = "INSERT INTO " & mysqlTableName & " (" & String.Join(", ", columnsToImport) & ") VALUES (" & String.Join(", ", columnsToImport.Select(Function(c) "@" & c)) & ")"
                    Dim mysqlCommand As New MySqlCommand(insertQuery, mysqlConnection)

                    ' Añadir parámetros con valores
                    For Each columnName As String In columnsToImport
                        mysqlCommand.Parameters.AddWithValue("@" & columnName, reader(columnName))
                    Next

                    Try
                        mysqlCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        ' Manejar errores de inserción
                        MsgBox("Error al insertar datos: " & ex.Message)
                    End Try
                End While
            End Using
        End Using
        MsgBox("Transferencia de datos completada.")
    End Sub


    Private Sub PausarTareas()
        Dim FechaHoraServer As DateTime = Conexion.ObtenerFechaHoraServidor(Cadenadeconexion)
        Dim tareasPendientes As String() = Conexion.ObtenertareasejecutandoPorUsuario(Cadenadeconexion, LblUsuario.Text)

        If tareasPendientes.Length = 0 Then
            'MessageBox.Show("No hay tareas pendientes.")
        Else



            Dim formulario As New FrmAsignarTareas()
            For Each codigo As String In tareasPendientes

                Dim TiempoObtenido As String = Conexion.ObtenerTiempo(Cadenadeconexion, codigo)
                Dim TiempoTranscurridoDesdeFechaParaCalcular As String = Conexion.ObtenerYCalcularTiempoTranscurrido(Cadenadeconexion, codigo, FechaHoraServer)
                Dim TiempoAcumulado As String = Conexion.SumarTiempos(TiempoObtenido, TiempoTranscurridoDesdeFechaParaCalcular)
                Dim NuevoTiempo As TimeSpan = TimeSpan.Parse(TiempoAcumulado)
                Conexion.ActualizarTiempo(Cadenadeconexion, codigo, NuevoTiempo)
                Conexion.ActualizarFechaYEstado(Cadenadeconexion, codigo, FechaHoraServer, "Pausada")


            Next
        End If


    End Sub


End Class




