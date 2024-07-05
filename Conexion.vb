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



End Class
