Imports System.IO

Public Class FrmLogin


    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        ingresar()
    End Sub


    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtContraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ingresar()
            e.Handled = True
        End If

    End Sub

    Private Sub ingresar()
        Dim Cadena As String = Conexion.ObtenerBaseDeDatosDeAccess()

        Dim Cargo As String = Conexion.ValidarUsuario(TxtUsuario.Text, TxtContraseña.Text, Cadena)

        If Cargo <> "" Then
            FrmPpal.LblUsuario.Text = TxtUsuario.Text
            FrmPpal.LblCargo.Text = Cargo
            FrmPpal.Cadenadeconexion = Cadena

            If Cargo = "Creador de Contenido" Then
                FrmPpal.Size = New Size(735, 268)
                FrmPpal.BtnModificarTarea.Visible = False
                FrmPpal.BtnConfiguracion.Visible = False
            End If

            FrmPpal.Show()
            Me.Hide()
        Else
            MsgBox("Verifique su usuario o contraseña")
        End If
    End Sub

    Private Sub TxtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsuario.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.D Then
            AbrirCarpeta()
        End If
    End Sub

    Private Sub LblContraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles LblContraseña.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.D Then
            AbrirCarpeta()

        End If
    End Sub


    Private Sub AbrirCarpeta()
        Dim carpeta As String = "Externos"
        Dim nombreBaseDatos As String = "Conexion.accdb"
        Dim rutaBaseDatos As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, nombreBaseDatos)
        Dim rutaCarpeta As String = Path.GetDirectoryName(rutaBaseDatos)

        If Directory.Exists(rutaCarpeta) Then
            Dim resultado As DialogResult = MessageBox.Show("¿Desea abrir la carpeta que contiene el archivo de configuración?", "Confirmar apertura", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resultado = DialogResult.Yes Then
                Try
                    Process.Start("explorer.exe", rutaCarpeta)
                Catch ex As Exception
                    MsgBox($"Error al intentar abrir la carpeta: {ex.Message}")
                End Try
            Else
                MsgBox("Apertura de la carpeta cancelada.")
            End If
        Else
            MsgBox("La carpeta no se encontró en la ruta especificada.")
        End If
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub
End Class
