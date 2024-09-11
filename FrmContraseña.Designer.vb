<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContraseña
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        TxtPassword = New TextBox()
        btnAceptar = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 15)
        Label1.TabIndex = 0
        Label1.Text = "Password"
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(12, 31)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.PasswordChar = "*"c
        TxtPassword.Size = New Size(248, 23)
        TxtPassword.TabIndex = 1
        ' 
        ' btnAceptar
        ' 
        btnAceptar.Location = New Point(185, 60)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.Size = New Size(75, 23)
        btnAceptar.TabIndex = 2
        btnAceptar.Text = "Ingrear"
        btnAceptar.UseVisualStyleBackColor = True
        ' 
        ' FrmContraseña
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(272, 92)
        Controls.Add(btnAceptar)
        Controls.Add(TxtPassword)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmContraseña"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Contraseña"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents btnAceptar As Button
End Class
