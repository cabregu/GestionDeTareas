<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracion
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
        BtnCrearUsuario = New Button()
        SuspendLayout()
        ' 
        ' BtnCrearUsuario
        ' 
        BtnCrearUsuario.Location = New Point(62, 61)
        BtnCrearUsuario.Name = "BtnCrearUsuario"
        BtnCrearUsuario.Size = New Size(75, 23)
        BtnCrearUsuario.TabIndex = 1
        BtnCrearUsuario.Text = "Crear "
        BtnCrearUsuario.UseVisualStyleBackColor = True
        ' 
        ' FrmConfiguracion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(447, 368)
        Controls.Add(BtnCrearUsuario)
        Name = "FrmConfiguracion"
        Text = "FrmConfiguracion"
        ResumeLayout(False)
    End Sub
    Friend WithEvents BtnCrearUsuario As Button
End Class
