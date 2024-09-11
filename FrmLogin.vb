Imports System.IO

Public Class FrmLogin


    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        ingresar
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
        Try
            Dim Cadena As String = Conexion.ObtenerBaseDeDatosDeAccess()

            Dim Cargo As String = Conexion.ValidarUsuario(TxtUsuario.Text, TxtContraseña.Text, Cadena)

            If Cargo <> "" Then
                FrmPpal.LblUsuario.Text = TxtUsuario.Text
                FrmPpal.LblCargo.Text = Cargo
                FrmPpal.Cadenadeconexion = Cadena
                FrmPpal.Show()
                Me.Hide()
            Else
                MsgBox("Verifique su usuario o contraseña")
            End If


        Catch ex As Exception

        End Try

    End Sub



    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frmContraseña As New FrmContraseña()
        If frmContraseña.ShowDialog() = DialogResult.OK Then
            FrmConfiguracion.Show()
        End If
    End Sub

End Class
