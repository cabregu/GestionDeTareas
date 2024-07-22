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


End Class