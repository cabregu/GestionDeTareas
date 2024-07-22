Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

Public Class Conexion

    'funciones de obtener
    Public Shared Function ObtenerBaseDeDatosDeAccess() As String
        Dim resultado As String = String.Empty
        Dim carpeta As String = "Externos"
        Dim nombreBaseDatos As String = "Conexion.accdb"
        Dim rutaBaseDatos As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, nombreBaseDatos)
        Dim cadenaConexion As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaBaseDatos};Jet OLEDB:Database Password=Gmt@2022;"

        Try
            Using conexion As New OleDbConnection(cadenaConexion)
                conexion.Open()
                Dim comando As New OleDbCommand("SELECT dato FROM datos WHERE tipo = 'Basededatos'", conexion)
                Dim lector As OleDbDataReader = comando.ExecuteReader()

                If lector.HasRows Then
                    While lector.Read()
                        resultado = lector("dato").ToString()
                    End While
                End If

                lector.Close()

                Return resultado

            End Using
        Catch ex As Exception
            MsgBox($"Error: {ex.Message}")
        End Try

        Return resultado
    End Function

    Public Shared Function ValidarUsuario(ByVal Usuario As String, ByVal Contraseña As String, ByVal Cadenaconexion As String) As String

        Dim Sql As String = "Select rango from usuarios Where nick='" & Usuario & "' and contraseña='" & Contraseña & "'"

        Dim cn As New MySqlConnection(Cadenaconexion)
        Dim cmconsult As New MySqlCommand(Sql, cn)
        cn.Open()
        Dim resultado As String = ""
        resultado = cmconsult.ExecuteScalar()
        cn.Close()

        If Len(resultado) > 0 Then
            Return resultado
        Else
            Return ""
        End If

    End Function

    Public Shared Function ObtenerClientes(ByVal CadenaConexion As String) As String()
        Dim clientes As New List(Of String)()

        Dim sql As String = "SELECT cliente FROM clientes"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()

                    clientes.Add(reader.GetString("cliente"))
                End While
            End Using
        End Using

        Return clientes.ToArray()
    End Function

    Public Shared Function ObtenerProyectos(ByVal CadenaConexion As String) As String()
        Dim proyecto As New List(Of String)()

        Dim sql As String = "SELECT DISTINCT proyecto FROM proyectotareas"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()

                    proyecto.Add(reader.GetString("proyecto"))
                End While
            End Using
        End Using

        Return proyecto.ToArray()
    End Function

    Public Shared Function ObtenertareasPorProyecto(ByVal Proyecto As String, ByVal CadenaConexion As String) As String()
        Dim tareas As New List(Of String)()
        Dim sql As String = "SELECT DISTINCT tareas FROM proyectotareas where proyecto='" & Proyecto & "'"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    tareas.Add(reader.GetString("tareas"))
                End While
            End Using
        End Using
        Return tareas.ToArray()
    End Function

    Public Shared Function ObtenerUsuarios(ByVal CadenaConexion As String) As String()
        Dim nick As New List(Of String)()

        Dim sql As String = "SELECT nick FROM usuarios"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    nick.Add(reader.GetString("nick"))
                End While
            End Using
        End Using

        Return nick.ToArray()
    End Function

    Public Shared Function ObtenertareasPendientes(ByVal CadenaConexion As String) As String()
        Dim tareas As New List(Of String)()
        Dim sql As String = "SELECT * FROM Kanbas WHERE Estado='Pendiente'"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ' Verificar el tipo de dato y convertir adecuadamente
                    If TypeOf reader("codigo") Is String Then
                        tareas.Add(reader.GetString("codigo"))
                    Else
                        tareas.Add(reader("codigo").ToString())
                    End If
                End While
            End Using
        End Using
        Return tareas.ToArray()
    End Function

    Public Shared Function ObtenerCodigo(ByVal CadenaConexion As String) As Integer
        Dim valor As Integer = 0

        Dim sql As String = "SELECT valor FROM configuracion WHERE descripcion = 'codigo'"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    valor = reader.GetInt32("valor")
                End If
            End Using
        End Using

        Return valor
    End Function

    Public Shared Function ObtenertareasPendientes(ByVal CadenaConexion As String, ByVal codigo As String) As List(Of Tarea)
        Dim tareas As New List(Of Tarea)()
        Dim sql As String = "SELECT * FROM Kanbas WHERE Estado='Pendiente' AND codigo = @codigo"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim tarea As New Tarea()
                    tarea.codigo = reader("codigo").ToString()
                    tarea.cliente = reader("cliente").ToString()
                    tarea.proyecto = reader("proyecto").ToString()
                    tarea.tarea = reader("tarea").ToString()
                    tarea.niveldeprioridad = reader("niveldeprioridad").ToString()
                    tarea.fechalimite = reader.GetDateTime("fechalimite")
                    tarea.comentario = reader("comentario").ToString()
                    tareas.Add(tarea)
                End While
            End Using
        End Using
        Return tareas
    End Function

    Public Shared Function ObtenertareasPendientesdeUsuario(ByVal CadenaConexion As String, ByVal codigo As String) As List(Of Tarea)
        Dim tareas As New List(Of Tarea)()
        Dim sql As String = "SELECT * FROM Kanbas WHERE codigo = @codigo"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim tarea As New Tarea()
                    tarea.codigo = reader("codigo").ToString()
                    tarea.cliente = reader("cliente").ToString()
                    tarea.proyecto = reader("proyecto").ToString()
                    tarea.tarea = reader("tarea").ToString()
                    tarea.niveldeprioridad = reader("niveldeprioridad").ToString()
                    tarea.fechalimite = reader.GetDateTime("fechalimite")
                    tarea.comentario = reader("comentario").ToString()
                    tarea.estado = reader("estado").ToString()

                    ' Verificar si fechadeinicio es DBNull o nulo
                    If Not reader.IsDBNull(reader.GetOrdinal("fechadeinicio")) Then
                        tarea.fechadeinicio = reader.GetDateTime("fechadeinicio")
                    Else
                        tarea.fechadeinicio = Nothing ' o cualquier valor por defecto que desees usar
                    End If

                    tareas.Add(tarea)
                End While
            End Using
        End Using
        Return tareas
    End Function

    Public Shared Function ObtenertareasEjecutandoPorUsuario(ByVal CadenaConexion As String, ByVal Usuario As String) As String()
        Dim tareas As New List(Of String)()
        Dim sql As String = "SELECT * FROM Kanbas WHERE Estado='Ejecutando' And Usuario = '" & Usuario & "'"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ' Verificar el tipo de dato y convertir adecuadamente
                    If TypeOf reader("codigo") Is String Then
                        tareas.Add(reader.GetString("codigo"))
                    Else
                        tareas.Add(reader("codigo").ToString())
                    End If
                End While
            End Using
        End Using
        Return tareas.ToArray()
    End Function

    Public Shared Function ObtenerCodigoPorUsuario(ByVal CadenaConexion As String, ByVal Usuario As String) As String()
        Dim codigousuario As New List(Of String)()

        Dim sql As String = "SELECT codigo FROM kanbas WHERE usuario=@usuario And estado <> 'Finalizada'"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@usuario", Usuario)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    codigousuario.Add(reader("codigo").ToString())
                End While
            End Using
        End Using

        Return codigousuario.ToArray()
    End Function

    Public Shared Function ObtenerFechaHoraServidor(ByVal CadenaConexion As String) As DateTime
        Dim sql As String = "SELECT NOW()"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                Try
                    cn.Open()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                        Return Convert.ToDateTime(resultado)
                    Else
                        Throw New Exception("No se pudo obtener la fecha y hora del servidor MySQL.")
                    End If
                Catch ex As Exception
                    Throw New Exception("Error al obtener la fecha y hora del servidor MySQL: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ObtenerYCalcularTiempoTranscurrido(ByVal CadenaConexion As String, ByVal codigo As String, ByVal fechaInicio As DateTime) As String
        Dim sql As String = "SELECT fechaparacalcular FROM kanbas WHERE codigo = @codigo"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                Try
                    cn.Open()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not DBNull.Value.Equals(resultado) Then
                        Dim fechaParaCalcular As DateTime = Convert.ToDateTime(resultado)
                        Dim tiempoTranscurrido As TimeSpan = fechaInicio - fechaParaCalcular
                        Dim tiempoFormateado As String = $"{tiempoTranscurrido.Hours:00}:{tiempoTranscurrido.Minutes:00}:{tiempoTranscurrido.Seconds:00}"
                        Return tiempoFormateado
                    Else
                        Return "No se encontró una fecha para calcular para el código proporcionado."
                    End If
                Catch ex As Exception
                    Return "Error al intentar obtener y calcular el tiempo transcurrido."
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ObtenerTiempo(ByVal CadenaConexion As String, ByVal codigo As String) As String
        Dim tiempo As String = "00:00:00"
        Dim sql As String = "SELECT Tiempo FROM Kanbas WHERE codigo = @codigo"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                Try
                    cn.Open()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not DBNull.Value.Equals(resultado) Then
                        tiempo = resultado.ToString()
                        If String.IsNullOrEmpty(tiempo) Then
                            tiempo = "00:00:00"
                        End If
                    End If
                Catch ex As Exception
                    ' Manejar el error según sea necesario
                    tiempo = "Error al obtener el tiempo."
                End Try
            End Using
        End Using

        Return tiempo
    End Function

    Public Shared Function ObtenerTareasNoFinalizadas(ByVal CadenaConexion As String) As DataTable
        Dim dtTareas As New DataTable()

        Dim sql As String = "SELECT * FROM Kanbas WHERE estado <> 'Finalizada'"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cn.Open()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dtTareas.Load(reader)
                End Using
            End Using
        End Using

        Return dtTareas
    End Function

    Public Shared Function ObtenertareasUnaTareaPorCodigo(ByVal CadenaConexion As String, ByVal codigo As String) As List(Of Tarea)
        Dim tareas As New List(Of Tarea)()
        Dim sql As String = "SELECT * FROM Kanbas WHERE codigo = @codigo"

        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                cn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim tarea As New Tarea()
                    tarea.codigo = reader("codigo").ToString()
                    tarea.cliente = reader("cliente").ToString()
                    tarea.proyecto = reader("proyecto").ToString()
                    tarea.tarea = reader("tarea").ToString()
                    tarea.niveldeprioridad = reader("niveldeprioridad").ToString()
                    tarea.fechalimite = reader.GetDateTime("fechalimite")
                    tarea.comentario = reader("comentario").ToString()
                    tarea.estado = reader("estado").ToString()
                    tarea.usuario = reader("usuario").ToString()
                    tareas.Add(tarea)
                End While
            End Using
        End Using
        Return tareas
    End Function


    'funciones de actualizar
    Public Shared Sub ActualizarCodigo(ByVal CadenaConexion As String, ByVal codigoactual As String)
        Dim valor As Integer = codigoactual + 1

        Dim sql As String = "UPDATE configuracion SET valor = @valor WHERE descripcion = 'codigo'"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@valor", valor)
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function ActualizarUsuarioPorCodigo(ByVal CadenaConexion As String, ByVal codigo As String, ByVal usuarioNuevo As String) As Boolean
        Dim sql As String = "UPDATE kanbas SET usuario = @usuarioNuevo, estado = 'Asignada' WHERE codigo = @codigo"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@usuarioNuevo", usuarioNuevo)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                Try
                    cn.Open()
                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ActualizarFechaInicioYCalcularPorCodigo(ByVal CadenaConexion As String, ByVal codigo As String, ByVal fechaDeInicio As DateTime) As Boolean
        Dim sql As String = "UPDATE kanbas SET fechadeinicio = @fechaDeInicio, fechaparacalcular = @fechaDeInicio, estado = 'Ejecutando' WHERE codigo = @codigo"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@fechaDeInicio", fechaDeInicio.ToString("yyyy-MM-dd HH:mm"))
                cmd.Parameters.AddWithValue("@codigo", codigo)
                Try
                    cn.Open()
                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Sub ActualizarTiempo(ByVal CadenaConexion As String, ByVal codigo As String, ByVal nuevoTiempo As TimeSpan)
        Dim tiempoFormateado As String = nuevoTiempo.ToString("hh\:mm\:ss") ' Formatear el TimeSpan a HH:mm:ss

        Dim sql As String = "UPDATE kanbas SET tiempo = @tiempo WHERE codigo = @codigo"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@tiempo", tiempoFormateado)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' Manejar el error según sea necesario
                End Try
            End Using
        End Using
    End Sub

    Public Shared Function ActualizarFechaYEstado(ByVal CadenaConexion As String, ByVal codigo As String, ByVal nuevaFechaParaCalcular As DateTime, ByVal nuevoEstado As String) As Boolean
        Dim sql As String = "UPDATE kanbas SET fechaparacalcular = @nuevaFecha, estado = @nuevoEstado WHERE codigo = @codigo"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@nuevaFecha", nuevaFechaParaCalcular)
                cmd.Parameters.AddWithValue("@nuevoEstado", nuevoEstado)
                cmd.Parameters.AddWithValue("@codigo", codigo)
                Try
                    cn.Open()
                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ActualizarEstadoKanbas(ByVal CadenaConexion As String, ByVal CodigoUsuario As String, ByVal NuevoEstado As String, ByVal Comentariofinal As String) As Boolean
        Dim sql As String = "UPDATE kanbas SET estado=@nuevoestado, comentariofinal =  @Comentariofinal WHERE codigo=@codigousuario"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@nuevoestado", NuevoEstado)
                cmd.Parameters.AddWithValue("@codigousuario", CodigoUsuario)
                cmd.Parameters.AddWithValue("@Comentariofinal", Comentariofinal)
                cn.Open()
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return filasAfectadas > 0
            End Using
        End Using
    End Function

    Public Shared Function ActualizarKanbasPorCodigo(ByVal CadenaConexion As String, ByVal CodigoUsuario As String, ByVal Cliente As String, ByVal Proyecto As String, ByVal Tarea As String, ByVal NivelDePrioridad As String, ByVal Usuario As String, ByVal FechaLimite As DateTime?, ByVal Comentario As String) As Boolean
        Dim sql As String = "UPDATE kanbas SET cliente=@cliente, proyecto=@proyecto, tarea=@tarea, niveldeprioridad=@niveldeprioridad, usuario=@usuario, fechalimite=@fechalimite, comentario=@comentario WHERE codigo=@codigousuario"
        Using cn As New MySqlConnection(CadenaConexion)
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@cliente", Cliente)
                cmd.Parameters.AddWithValue("@proyecto", Proyecto)
                cmd.Parameters.AddWithValue("@tarea", Tarea)
                cmd.Parameters.AddWithValue("@niveldeprioridad", NivelDePrioridad)
                cmd.Parameters.AddWithValue("@usuario", Usuario)
                cmd.Parameters.AddWithValue("@fechalimite", If(FechaLimite.HasValue, FechaLimite, DBNull.Value))
                cmd.Parameters.AddWithValue("@comentario", Comentario)
                cmd.Parameters.AddWithValue("@codigousuario", CodigoUsuario)
                cn.Open()
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return filasAfectadas > 0
            End Using
        End Using
    End Function


    'funcioneas de insertar
    Public Shared Function InsertarKanba(
    ByVal CadenaConexion As String,
    ByVal codigo As Integer,
    ByVal cliente As String,
    ByVal proyecto As String,
    ByVal tarea As String,
    ByVal niveldeprioridad As String,
    ByVal usuario As String,
    ByVal fechalimite As Date,
    ByVal estado As String,
    Optional ByVal fechadeinicio As DateTime? = Nothing,
    Optional ByVal tiempo As String = Nothing,
    Optional ByVal comentario As String = Nothing) As Boolean

        Dim sqlCheck As String = "SELECT COUNT(*) FROM kanbas WHERE codigo = @codigo"
        Dim sqlInsert As String = "INSERT INTO kanbas (codigo, cliente, proyecto, tarea, niveldeprioridad, usuario, fechalimite, estado, fechadeinicio, tiempo, comentario) VALUES (@codigo, @cliente, @proyecto, @tarea, @niveldeprioridad, @usuario, @fechalimite, @estado, @fechadeinicio, @tiempo, @comentario)"

        Using cn As New MySqlConnection(CadenaConexion)
            cn.Open()

            ' Verificar si el código ya existe
            Using cmdCheck As New MySqlCommand(sqlCheck, cn)
                cmdCheck.Parameters.AddWithValue("@codigo", codigo)
                Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

                If count > 0 Then
                    ' El código ya existe
                    Return False
                End If
            End Using

            ' Insertar el nuevo registro
            Using cmdInsert As New MySqlCommand(sqlInsert, cn)
                cmdInsert.Parameters.AddWithValue("@codigo", codigo)
                cmdInsert.Parameters.AddWithValue("@cliente", cliente)
                cmdInsert.Parameters.AddWithValue("@proyecto", proyecto)
                cmdInsert.Parameters.AddWithValue("@tarea", tarea)
                cmdInsert.Parameters.AddWithValue("@niveldeprioridad", niveldeprioridad)
                cmdInsert.Parameters.AddWithValue("@usuario", usuario)
                cmdInsert.Parameters.AddWithValue("@fechalimite", fechalimite)
                cmdInsert.Parameters.AddWithValue("@estado", estado)
                cmdInsert.Parameters.AddWithValue("@fechadeinicio", If(fechadeinicio.HasValue, fechadeinicio, DBNull.Value))
                cmdInsert.Parameters.AddWithValue("@tiempo", If(String.IsNullOrEmpty(tiempo), DBNull.Value, tiempo))
                cmdInsert.Parameters.AddWithValue("@comentario", If(String.IsNullOrEmpty(comentario), DBNull.Value, comentario))

                cmdInsert.ExecuteNonQuery()
            End Using
        End Using

        ' El registro se insertó correctamente
        Return True
    End Function


    'Tarea Sin conexion
    Public Shared Function SumarTiempos(ByVal ValorBaseDeDatos As String, ByVal ValorDesdeFechaParaCalcular As String) As String
        Try
            Dim ts1 As TimeSpan = TimeSpan.ParseExact(ValorBaseDeDatos, "hh\:mm\:ss", Nothing)
            Dim ts2 As TimeSpan = TimeSpan.ParseExact(ValorDesdeFechaParaCalcular, "hh\:mm\:ss", Nothing)

            Dim tiempoTotal As TimeSpan = ts1 + ts2

            Dim tiempoFormateado As String = $"{tiempoTotal.Hours:00}:{tiempoTotal.Minutes:00}:{tiempoTotal.Seconds:00}"
            Return tiempoFormateado
        Catch ex As Exception
            Return "Error al sumar los tiempos transcurridos."
        End Try
    End Function



End Class
