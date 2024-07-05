<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrearCliente
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
        TxtNombreCliente = New TextBox()
        BtnNombre = New Label()
        BtnCancelar = New Button()
        BtnCrear = New Button()
        SuspendLayout()
        ' 
        ' TxtNombreCliente
        ' 
        TxtNombreCliente.Location = New Point(62, 62)
        TxtNombreCliente.Name = "TxtNombreCliente"
        TxtNombreCliente.Size = New Size(304, 23)
        TxtNombreCliente.TabIndex = 0
        ' 
        ' BtnNombre
        ' 
        BtnNombre.AutoSize = True
        BtnNombre.Location = New Point(179, 44)
        BtnNombre.Name = "BtnNombre"
        BtnNombre.Size = New Size(51, 15)
        BtnNombre.TabIndex = 1
        BtnNombre.Text = "Nombre"
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(234, 111)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(106, 39)
        BtnCancelar.TabIndex = 9
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' BtnCrear
        ' 
        BtnCrear.Location = New Point(95, 111)
        BtnCrear.Name = "BtnCrear"
        BtnCrear.Size = New Size(108, 39)
        BtnCrear.TabIndex = 8
        BtnCrear.Text = "Crear"
        BtnCrear.UseVisualStyleBackColor = True
        ' 
        ' FrmCrearCliente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(427, 213)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnCrear)
        Controls.Add(BtnNombre)
        Controls.Add(TxtNombreCliente)
        Name = "FrmCrearCliente"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Crear Cliente"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtNombreCliente As TextBox
    Friend WithEvents BtnNombre As Label
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnCrear As Button
End Class
