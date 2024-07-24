Public Class FrmCrearCliente

    Public CadenaDeConexion As String = ""

    Private Sub FrmCrearCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmCrearCliente_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub


    Private Sub BtnCrear_Click(sender As Object, e As EventArgs) Handles BtnCrear.Click
        If String.IsNullOrWhiteSpace(TxtNombreCliente.Text) Then
            MessageBox.Show("Por favor, ingrese un nombre de cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cliente As String = TxtNombreCliente.Text
        Dim result As DialogResult = MessageBox.Show($"¿Está seguro de que desea crear el cliente '{cliente}'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim exito As Boolean = Conexion.InsertarClienteNuevo(CadenaDeConexion, cliente)
            If exito Then
                MessageBox.Show($"El cliente '{cliente}' se creó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNombreCliente.Text = String.Empty
            Else
                MessageBox.Show($"El cliente '{cliente}' ya existe. Por favor, elija otro nombre de cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub
End Class