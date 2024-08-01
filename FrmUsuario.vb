Public Class FrmUsuario
    Public CadenaDeConexion As String = ""

    Private Sub FrmUsuario_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub BtnCrear_Click(sender As Object, e As EventArgs) Handles BtnCrear.Click
        If String.IsNullOrWhiteSpace(TxtUsuario.Text) OrElse
       String.IsNullOrWhiteSpace(TxtContraseña.Text) OrElse
       CmbCrearComo.SelectedIndex = -1 Then
            MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea crear este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim exito As Boolean = Conexion.InsertarUsuarioNuevo(CadenaDeConexion, TxtUsuario.Text, CmbCrearComo.Text, TxtContraseña.Text)
            If exito Then
                MessageBox.Show("El usuario se creó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtUsuario.Text = String.Empty
                TxtContraseña.Text = String.Empty
                CmbCrearComo.SelectedIndex = -1
            Else
                MessageBox.Show("El usuario ya existe. Por favor, elija otro nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
    End Sub
End Class