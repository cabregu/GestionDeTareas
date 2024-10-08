﻿Imports MySql.Data.MySqlClient
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


        Select Case LblCargo.Text
            Case "Administrador"

                formulario.CmbCrearComo.Items.Clear()
                formulario.CmbCrearComo.Items.Add("Administrador")
                formulario.CmbCrearComo.Items.Add("Creador de Contenido")
                formulario.CmbCrearComo.Items.Add("Usuario")

            Case "Creador de Contenido"

                formulario.CmbCrearComo.Items.Clear()
                formulario.CmbCrearComo.Items.Add("Creador de Contenido")
                formulario.CmbCrearComo.Items.Add("Usuario")

            Case "Usuario"

                formulario.CmbCrearComo.Items.Clear()

                formulario.CmbCrearComo.Enabled = False

                MessageBox.Show("No tienes permisos para crear usuarios.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Case Else

                formulario.CmbCrearComo.Items.Clear()
                formulario.CmbCrearComo.Enabled = False
        End Select

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
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        Dim formulario As New FrmReporte()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.Show()
        Me.Hide()
    End Sub

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs)

        Dim formulario As New FrmConfiguracion
        formulario.Show()
        Hide()
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
        Dim tareasPendientes As String() = Conexion.ObtenertareasEjecutandoPorUsuario(Cadenadeconexion, LblUsuario.Text)

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

    Private Sub FrmPpal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        TmrChekTareas.Start()


        If LblCargo.Text = "Creador de Contenido" Then
            BtnCrearProyecto.Enabled = False
            BtnCrearCliente.Enabled = False
            BtnModificarDatos.Enabled = False
            BtnModificarTarea.Enabled = False
            BtnCrearUsuario.Enabled = False
            BtnReporte.Enabled = False

        ElseIf LblCargo.Text = "Usuario" Then

            BtnCrearProyecto.Enabled = False
            BtnCrearCliente.Enabled = False
            BtnModificarDatos.Enabled = False
            BtnCrearTarea.Enabled = False
            BtnModificarDatos.Enabled = False
            BtnAsignarTarea.Enabled = False
            BtnModificarTarea.Enabled = False
            BtnCrearCliente.Enabled = False
            BtnCrearUsuario.Enabled = False
            BtnReporte.Enabled = False

        End If

    End Sub


    Private mensajeMostrado As Boolean = False

    Private Sub TmrChekTareas_Tick(sender As Object, e As EventArgs) Handles TmrChekTareas.Tick
        Try
            Dim mensajes As String = String.Empty

            Dim hayPausadas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Pausada")
            Dim hayAsignadas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Asignada")

            If hayPausadas Then
                mensajes &= "Tiene tareas Pausadas." & vbCrLf
            End If

            If hayAsignadas Then
                mensajes &= "Tiene tareas Asignadas." & vbCrLf
            End If

            If mensajes <> String.Empty AndAlso Not mensajeMostrado Then
                mensajeMostrado = True
                TmrChekTareas.Stop() ' Detiene el timer al mostrar el mensaje
                MessageBox.Show(mensajes.Trim(), "Aviso", MessageBoxButtons.OK)

                ' Reinicia el timer después de que el usuario presione Aceptar
                mensajeMostrado = False ' Reinicia la variable
                TmrChekTareas.Start() ' Reinicia el timer
            End If

        Catch ex As Exception
            ' Manejo de excepciones, puedes registrar el error si es necesario
        End Try
    End Sub



End Class




