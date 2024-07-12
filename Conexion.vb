Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

Public Class Conexion
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

    Public Shared Sub ActualizarCodigo(ByVal CadenaConexion As String, ByVal codigoactual As Integer)
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



End Class
