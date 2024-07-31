<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsuario
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
        LblUsuario = New Label()
        LblContraseña = New Label()
        TxtContraseña = New TextBox()
        CmbCrearComo = New ComboBox()
        LblCrearComo = New Label()
        BtnCrear = New Button()
        BtnCancelar = New Button()
        SuspendLayout()
        ' 
        ' TxtUsuario
        ' 
        TxtUsuario.Location = New Point(41, 41)
        TxtUsuario.Name = "TxtUsuario"
        TxtUsuario.Size = New Size(245, 23)
        TxtUsuario.TabIndex = 0
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(41, 23)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(47, 15)
        LblUsuario.TabIndex = 1
        LblUsuario.Text = "Usuario"
        ' 
        ' LblContraseña
        ' 
        LblContraseña.AutoSize = True
        LblContraseña.Location = New Point(41, 72)
        LblContraseña.Name = "LblContraseña"
        LblContraseña.Size = New Size(67, 15)
        LblContraseña.TabIndex = 3
        LblContraseña.Text = "Contraseña"
        ' 
        ' TxtContraseña
        ' 
        TxtContraseña.Location = New Point(41, 90)
        TxtContraseña.Name = "TxtContraseña"
        TxtContraseña.Size = New Size(245, 23)
        TxtContraseña.TabIndex = 2
        ' 
        ' CmbCrearComo
        ' 
        CmbCrearComo.FormattingEnabled = True
        CmbCrearComo.Items.AddRange(New Object() {"Administrador", "Creador de Contenido", "Usuario"})
        CmbCrearComo.Location = New Point(41, 140)
        CmbCrearComo.Name = "CmbCrearComo"
        CmbCrearComo.Size = New Size(245, 23)
        CmbCrearComo.TabIndex = 4
        ' 
        ' LblCrearComo
        ' 
        LblCrearComo.AutoSize = True
        LblCrearComo.Location = New Point(41, 122)
        LblCrearComo.Name = "LblCrearComo"
        LblCrearComo.Size = New Size(69, 15)
        LblCrearComo.TabIndex = 5
        LblCrearComo.Text = "Crear como"
        ' 
        ' BtnCrear
        ' 
        BtnCrear.Location = New Point(41, 201)
        BtnCrear.Name = "BtnCrear"
        BtnCrear.Size = New Size(108, 39)
        BtnCrear.TabIndex = 6
        BtnCrear.Text = "Crear"
        BtnCrear.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(180, 201)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(106, 39)
        BtnCancelar.TabIndex = 7
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' FrmUsuario
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(371, 273)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnCrear)
        Controls.Add(LblCrearComo)
        Controls.Add(CmbCrearComo)
        Controls.Add(LblContraseña)
        Controls.Add(TxtContraseña)
        Controls.Add(LblUsuario)
        Controls.Add(TxtUsuario)
        Name = "FrmUsuario"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Crear Usuarios"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents LblContraseña As Label
    Friend WithEvents TxtContraseña As TextBox
    Friend WithEvents CmbCrearComo As ComboBox
    Friend WithEvents LblCrearComo As Label
    Friend WithEvents BtnCrear As Button
    Friend WithEvents BtnCancelar As Button
End Class
