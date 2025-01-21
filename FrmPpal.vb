Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

Public Class FrmPpal

    Public Cadenadeconexion As String = ""
    Dim listaCodigos As New List(Of Integer)()


    Private Sub FrmPpal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        PausarTareas()
        MsgBox("Si hay tareas ejecutando seran pausadas")

        Application.Exit()

    End Sub

    Private Sub FrmPpal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        Me.MaximizeBox = False
        listaCodigos = Conexion.ObtenerCodigosTareasAsignadas(Cadenadeconexion, LblUsuario.Text)

        Dim NombreEmpresa As String = Conexion.ObtenerNombreEmpresa(Cadenadeconexion)

        Me.Text = Me.Text & " " & NombreEmpresa


        TmrAsignada.Start()
        TmrPausada.Start()
        TmrPendiente.Start()
        TmrChekTareas.Start()

        TmrColores.Start()




        VerificarTareasYNotificar("Asignada", LblAsignada, "Asignadas", TmrAsignada)


        VerificarTareasYNotificar("Pausada", LblPausada, "Pausadas", TmrPausada)

        VerificarTareasYNotificarPendiente("Pendiente", LblPendiente, "Pendientes", TmrPendiente)




        If LblCargo.Text = "Creador de Contenido" Then

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


    Private Sub VerificarNuevosCodigosTareas()
        Try

            Dim nuevosCodigos As List(Of Integer) = Conexion.ObtenerCodigosTareasAsignadas(Cadenadeconexion, LblUsuario.Text)


            For Each codigo As Integer In nuevosCodigos
                If Not listaCodigos.Contains(codigo) Then

                    listaCodigos.Add(codigo)


                    NtfIcon.BalloonTipTitle = "Nuevo Código de Tarea Asignada"
                    NtfIcon.BalloonTipText = $"Nuevo código de tarea asignada: {codigo}"
                    NtfIcon.BalloonTipIcon = ToolTipIcon.Info
                    NtfIcon.ShowBalloonTip(5000)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TmrChekTareas_Tick(sender As Object, e As EventArgs) Handles TmrChekTareas.Tick
        VerificarNuevosCodigosTareas()
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




    Private Sub NtfIcon_BalloonTipClicked(sender As Object, e As EventArgs) Handles NtfIcon.BalloonTipClicked

        Dim formulario As New FrmRealizarTarea()
        formulario.CadenaDeConexion = Cadenadeconexion
        formulario.LblUsuario.Text = LblUsuario.Text
        formulario.Show()
        Me.Hide()

    End Sub


    Private colores() As Color = {Color.Red, Color.Blue, Color.Green, Color.Magenta, Color.Orange, Color.Cyan}
    Private indiceColor As Integer = 0

    Private Sub TmrColores_Tick(sender As Object, e As EventArgs) Handles TmrColores.Tick

        LblAsignada.ForeColor = colores(indiceColor)
        LblPendiente.ForeColor = colores(indiceColor)
        LblPausada.ForeColor = colores(indiceColor)


        indiceColor += 1
        If indiceColor >= colores.Length Then
            indiceColor = 0
        End If
    End Sub


    Private Sub TmrAsignada_Tick(sender As Object, e As EventArgs) Handles TmrAsignada.Tick
        VerificarTareasYNotificar("Asignada", LblAsignada, "Asignadas", TmrAsignada)
    End Sub

    Private Sub TmrPendiente_Tick(sender As Object, e As EventArgs) Handles TmrPendiente.Tick
        VerificarTareasYNotificarPendiente("Pendiente", LblPendiente, "Pendientes", TmrPendiente)
    End Sub

    Private Sub TmrPausada_Tick(sender As Object, e As EventArgs) Handles TmrPausada.Tick
        VerificarTareasYNotificar("Pausada", LblPausada, "Pausadas", TmrPausada)
    End Sub



    Private mensajeMostrado As Boolean = False

    Private Sub VerificarTareasYNotificar(estado As String, lbl As Label, nombreTarea As String, timer As Timer)
        Try
            ' Consultar el estado de las tareas
            Dim hayTareas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, estado)

            If hayTareas Then
                lbl.Text = $"Tiene Tareas {nombreTarea}"

                If Not mensajeMostrado Then
                    mensajeMostrado = True
                    timer.Stop()

                    ' Mostrar notificación
                    NtfIcon.BalloonTipTitle = $"Notificación de Tareas {nombreTarea}"
                    NtfIcon.BalloonTipText = $"Tiene tareas {nombreTarea}."
                    NtfIcon.BalloonTipIcon = ToolTipIcon.Info
                    NtfIcon.ShowBalloonTip(5000)

                    mensajeMostrado = False
                    timer.Start()
                End If
            Else
                lbl.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub VerificarTareasYNotificarPendiente(estado As String, lbl As Label, nombreTarea As String, timer As Timer)
        Try
            ' Consultar el estado de las tareas
            Dim hayTareas As Boolean = Conexion.HayTareaPorEstadoSinUsuario(Cadenadeconexion, estado)

            If hayTareas Then
                lbl.Text = $"Tiene Tareas {nombreTarea}"

                If Not mensajeMostrado Then
                    mensajeMostrado = True
                    timer.Stop()

                    ' Mostrar notificación
                    NtfIcon.BalloonTipTitle = $"Notificación de Tareas {nombreTarea}"
                    NtfIcon.BalloonTipText = $"Tiene tareas {nombreTarea}."
                    NtfIcon.BalloonTipIcon = ToolTipIcon.Info
                    NtfIcon.ShowBalloonTip(5000)

                    mensajeMostrado = False
                    timer.Start()
                End If
            Else
                lbl.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Private mensajeMostrado As Boolean = False
    'Private Sub TmrAsignada_Tick(sender As Object, e As EventArgs) Handles TmrAsignada.Tick
    '    Try
    '        Dim hayAsignadas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Asignada")

    '        If hayAsignadas Then
    '            LblAsignada.Text = "Tiene Tareas Asignadas"

    '            If Not mensajeMostrado Then
    '                mensajeMostrado = True
    '                TmrAsignada.Stop()

    '                ' Mostrar notificación
    '                NtfIcon.BalloonTipTitle = "Notificación de Tareas Asignadas"
    '                NtfIcon.BalloonTipText = "Tiene tareas Asignadas."
    '                NtfIcon.BalloonTipIcon = ToolTipIcon.Info
    '                NtfIcon.ShowBalloonTip(5000)

    '                mensajeMostrado = False
    '                TmrAsignada.Start()
    '            End If
    '        Else
    '            LblAsignada.Text = ""
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    'Private Sub TmrPendiente_Tick(sender As Object, e As EventArgs) Handles TmrPendiente.Tick
    '    Try
    '        Dim hayPendientes As Boolean = Conexion.HayTareaPorEstadoSinUsuario(Cadenadeconexion, "Pendiente")

    '        If hayPendientes Then
    '            LblPendiente.Text = "Hay Tareas Pendientes"

    '            If Not mensajeMostrado Then
    '                mensajeMostrado = True
    '                TmrPendiente.Stop()

    '                ' Mostrar notificación
    '                NtfIcon.BalloonTipTitle = "Notificación de Tareas Pendientes"
    '                NtfIcon.BalloonTipText = "Hay Pendientes Sin Asignar"
    '                NtfIcon.BalloonTipIcon = ToolTipIcon.Info
    '                NtfIcon.ShowBalloonTip(5000)

    '                mensajeMostrado = False
    '                TmrPendiente.Start()
    '            End If
    '        Else
    '            LblPendiente.Text = ""
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub TmrPausada_Tick(sender As Object, e As EventArgs) Handles TmrPausada.Tick
    '    Try
    '        Dim hayPausadas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Pausada")

    '        If hayPausadas Then
    '            LblPausada.Text = "Tiene Tareas Pausadas"

    '            If Not mensajeMostrado Then
    '                mensajeMostrado = True
    '                TmrPausada.Stop()

    '                ' Mostrar notificación
    '                NtfIcon.BalloonTipTitle = "Notificación de Tareas Pausadas"
    '                NtfIcon.BalloonTipText = "Tiene tareas Pausadas."
    '                NtfIcon.BalloonTipIcon = ToolTipIcon.Info
    '                NtfIcon.ShowBalloonTip(5000)

    '                mensajeMostrado = False
    '                TmrPausada.Start()
    '            End If
    '        Else
    '            LblPausada.Text = ""
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub









    'Private mensajeMostrado As Boolean = False
    'Private Sub TmrChekTareas_Tick(sender As Object, e As EventArgs) Handles TmrChekTareas.Tick
    '    Try
    '        Dim mensajes As String = String.Empty

    '        ' Verifica las tareas pausadas, asignadas y pendientes
    '        Dim hayPausadas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Pausada")
    '        Dim hayAsignadas As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Asignada")
    '        Dim hayPendientes As Boolean = Conexion.HayTareaPorestado(Cadenadeconexion, LblUsuario.Text, "Pendiente")

    '        ' Actualizar etiquetas según el estado
    '        If hayPausadas Then
    '            LblPausada.Text = "Tiene Tareas Pausadas"
    '            mensajes &= "Tiene tareas Pausadas." & vbCrLf
    '        Else
    '            LblPausada.Text = ""
    '        End If

    '        If hayAsignadas Then
    '            LblAsignada.Text = "Tiene Tareas Asignadas"
    '            mensajes &= "Tiene tareas Asignadas." & vbCrLf
    '        Else
    '            LblAsignada.Text = ""
    '        End If

    '        If hayPendientes Then
    '            LblPendiente.Text = "Tiene Tareas Pendientes"
    '            mensajes &= "Tiene tareas Pendientes." & vbCrLf
    '        Else
    '            LblPendiente.Text = ""
    '        End If

    '        ' Mostrar notificación si hay tareas pendientes, pausadas o asignadas
    '        If mensajes <> String.Empty AndAlso Not mensajeMostrado Then
    '            mensajeMostrado = True
    '            TmrChekTareas.Stop()

    '            NtfIcon.BalloonTipTitle = "Notificación de Tareas"
    '            NtfIcon.BalloonTipText = mensajes.Trim()
    '            NtfIcon.BalloonTipIcon = ToolTipIcon.Info
    '            NtfIcon.ShowBalloonTip(5000)

    '            mensajeMostrado = False
    '            TmrChekTareas.Start()
    '            TmrColores.Start()
    '        End If

    '    Catch ex As Exception
    '        ' Manejo de excepciones
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


End Class




