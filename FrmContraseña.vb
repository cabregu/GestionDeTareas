Public Class FrmContraseña
    Public ReadOnly Property ContraseñaCorrecta As Boolean
        Get
            Return TxtPassword.Text = "Gmt@2022"
        End Get
    End Property

    Private Sub FrmContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPassword.UseSystemPasswordChar = True
        TxtPassword.Focus() ' Coloca el foco en el campo de contraseña al cargar el formulario
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ContraseñaCorrecta Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Contraseña incorrecta. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtPassword.Clear()
            TxtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAceptar.PerformClick()
        End If
    End Sub
End Class
