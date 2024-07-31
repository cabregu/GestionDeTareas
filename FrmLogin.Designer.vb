<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        TxtUsuario = New TextBox()
        TxtContraseña = New TextBox()
        BtnIngresar = New Button()
        BtnSalir = New Button()
        LblUsuario = New Label()
        LblContraseña = New Label()
        SuspendLayout()
        ' 
        ' TxtUsuario
        ' 
        TxtUsuario.Location = New Point(46, 56)
        TxtUsuario.Name = "TxtUsuario"
        TxtUsuario.Size = New Size(192, 23)
        TxtUsuario.TabIndex = 0
        ' 
        ' TxtContraseña
        ' 
        TxtContraseña.Location = New Point(46, 128)
        TxtContraseña.Name = "TxtContraseña"
        TxtContraseña.PasswordChar = "*"c
        TxtContraseña.Size = New Size(192, 23)
        TxtContraseña.TabIndex = 1
        ' 
        ' BtnIngresar
        ' 
        BtnIngresar.Location = New Point(46, 192)
        BtnIngresar.Name = "BtnIngresar"
        BtnIngresar.Size = New Size(75, 23)
        BtnIngresar.TabIndex = 2
        BtnIngresar.Text = "Ingresar"
        BtnIngresar.UseVisualStyleBackColor = True
        ' 
        ' BtnSalir
        ' 
        BtnSalir.Location = New Point(163, 192)
        BtnSalir.Name = "BtnSalir"
        BtnSalir.Size = New Size(75, 23)
        BtnSalir.TabIndex = 3
        BtnSalir.Text = "Salir"
        BtnSalir.UseVisualStyleBackColor = True
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(46, 38)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(50, 15)
        LblUsuario.TabIndex = 4
        LblUsuario.Text = "Usuario:"
        ' 
        ' LblContraseña
        ' 
        LblContraseña.AutoSize = True
        LblContraseña.Location = New Point(46, 110)
        LblContraseña.Name = "LblContraseña"
        LblContraseña.Size = New Size(70, 15)
        LblContraseña.TabIndex = 5
        LblContraseña.Text = "Contraseña:"
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(304, 277)
        Controls.Add(LblContraseña)
        Controls.Add(LblUsuario)
        Controls.Add(BtnSalir)
        Controls.Add(BtnIngresar)
        Controls.Add(TxtContraseña)
        Controls.Add(TxtUsuario)
        Name = "FrmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents TxtContraseña As TextBox
    Friend WithEvents BtnIngresar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents LblUsuario As Label
    Friend WithEvents LblContraseña As Label
End Class
