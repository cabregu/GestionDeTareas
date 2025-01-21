Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FrmConfiguracion

    ' Declarar las variables
    Dim server As String = ""
    Dim userId As String = ""
    Dim password As String = ""
    Dim database As String = ""
    Dim port As String = ""
    Dim persistSecurityInfo As String = ""

    Dim nuevaCadenaConexion As String = ""

    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexionCadena As String = Conexion.ObtenerBaseDeDatosDeAccess()
        ExtraerDatosConexion(conexionCadena, server, userId, password, database, port, persistSecurityInfo)

        TxtServer.Text = server
        TxtUser.Text = userId
        TxtPass.Text = password
        TxtDatabase.Text = database
        TxtPort.Text = port
        TxtSecurityInfo.Text = persistSecurityInfo

        Try
            Dim NombreEmpresa As String = Conexion.ObtenerNombreEmpresa(conexionCadena)
            TxtEmpresa.Text = NombreEmpresa

        Catch ex As Exception

        End Try


    End Sub

    Sub ExtraerDatosConexion(cadenaConexion As String, ByRef server As String, ByRef userId As String, ByRef password As String, ByRef database As String, ByRef port As String, ByRef persistSecurityInfo As String)
        ' Función para obtener el valor de un parámetro específico
        Dim funcionObtenerValor As Func(Of String, String, String) = Function(cadena As String, parametro As String) As String
                                                                         Dim patron As String = parametro & "="
                                                                         Dim inicio As Integer = cadena.IndexOf(patron) + patron.Length
                                                                         Dim fin As Integer = cadena.IndexOf(";", inicio)
                                                                         If fin = -1 Then fin = cadena.Length
                                                                         Return cadena.Substring(inicio, fin - inicio).Trim()
                                                                     End Function

        ' Extraer los valores y asignar a las variables correspondientes
        server = funcionObtenerValor(cadenaConexion, "server")
        userId = funcionObtenerValor(cadenaConexion, "User Id")
        password = funcionObtenerValor(cadenaConexion, "password")
        database = funcionObtenerValor(cadenaConexion, "database")
        port = funcionObtenerValor(cadenaConexion, "port")
        persistSecurityInfo = funcionObtenerValor(cadenaConexion, "Persist Security Info")
    End Sub


    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click

        If String.IsNullOrWhiteSpace(TxtEmpresa.Text) Then
            MsgBox("El campo 'Empresa' no puede estar vacío.", MsgBoxStyle.Exclamation, "Advertencia")
            TxtEmpresa.Focus()
            Exit Sub
        End If


        nuevaCadenaConexion = $"server={TxtServer.Text};User Id={TxtUser.Text};password={TxtPass.Text};database={TxtDatabase.Text};port={TxtPort.Text};Persist Security Info={TxtSecurityInfo.Text};"


        If Conexion.ActualizarDatoBaseDeDatosDeAccess(nuevaCadenaConexion) = True Then
            MsgBox("Cadena Actualizada Correctamente", MsgBoxStyle.Information, "Éxito")

            Dim nombreEmpresa As String = TxtEmpresa.Text

            If Conexion.GuardarNombreEmpresa(nuevaCadenaConexion, nombreEmpresa) Then
                MsgBox("El nombre de la empresa se guardó correctamente.", MsgBoxStyle.Information, "Éxito")
            Else
                MsgBox("No se pudo guardar el nombre de la empresa.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error al actualizar la cadena de conexión.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub



    Private Sub BtnProbarConexion_Click(sender As Object, e As EventArgs) Handles BtnProbarConexion.Click
        Dim cadenaConexion As String = $"server={TxtServer.Text};user id={TxtUser.Text};password={TxtPass.Text};database={TxtDatabase.Text};port={TxtPort.Text};"

        Try
            Using cn As New MySqlConnection(cadenaConexion)
                cn.Open()
                MessageBox.Show("Conexión exitosa a la base de datos MySQL.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                BtnActualizar.Enabled = True
                BtnProbarConexion.Enabled = False

                Dim nombreEmpresa As String = Conexion.ObtenerNombreEmpresa(cadenaConexion)

                If Not String.IsNullOrEmpty(nombreEmpresa) Then
                    TxtEmpresa.Text = nombreEmpresa
                Else
                    MessageBox.Show("No se encontró un valor para 'NombreEmpresa' en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"Error al intentar conectar a la base de datos MySQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error al intentar conectar a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class
