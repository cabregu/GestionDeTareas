<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarEliminar
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
        BtnClientes = New Button()
        BtnUsuarios = New Button()
        BtnModificar = New Button()
        BtnEliminar = New Button()
        BtnTareas = New Button()
        BtnCancelar = New Button()
        LblSeleccioneUnaOpcion = New Label()
        DgvDatos = New DataGridView()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnClientes
        ' 
        BtnClientes.Location = New Point(218, 56)
        BtnClientes.Name = "BtnClientes"
        BtnClientes.Size = New Size(100, 30)
        BtnClientes.TabIndex = 0
        BtnClientes.Text = "Clientes"
        BtnClientes.UseVisualStyleBackColor = True
        ' 
        ' BtnUsuarios
        ' 
        BtnUsuarios.Location = New Point(339, 56)
        BtnUsuarios.Name = "BtnUsuarios"
        BtnUsuarios.Size = New Size(100, 30)
        BtnUsuarios.TabIndex = 1
        BtnUsuarios.Text = "Usuarios"
        BtnUsuarios.UseVisualStyleBackColor = True
        ' 
        ' BtnModificar
        ' 
        BtnModificar.Location = New Point(218, 92)
        BtnModificar.Name = "BtnModificar"
        BtnModificar.Size = New Size(100, 30)
        BtnModificar.TabIndex = 2
        BtnModificar.Text = "Modificar"
        BtnModificar.UseVisualStyleBackColor = True
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Location = New Point(339, 92)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(100, 30)
        BtnEliminar.TabIndex = 3
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnTareas
        ' 
        BtnTareas.Location = New Point(456, 56)
        BtnTareas.Name = "BtnTareas"
        BtnTareas.Size = New Size(100, 30)
        BtnTareas.TabIndex = 4
        BtnTareas.Text = "Tareas"
        BtnTareas.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(456, 92)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(100, 30)
        BtnCancelar.TabIndex = 5
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' LblSeleccioneUnaOpcion
        ' 
        LblSeleccioneUnaOpcion.AutoSize = True
        LblSeleccioneUnaOpcion.Location = New Point(12, 56)
        LblSeleccioneUnaOpcion.Name = "LblSeleccioneUnaOpcion"
        LblSeleccioneUnaOpcion.Size = New Size(129, 15)
        LblSeleccioneUnaOpcion.TabIndex = 6
        LblSeleccioneUnaOpcion.Text = "Seleccione Una Opcion"
        ' 
        ' DgvDatos
        ' 
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(12, 128)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(544, 272)
        DgvDatos.TabIndex = 7
        ' 
        ' FrmModificarEliminar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(577, 443)
        Controls.Add(DgvDatos)
        Controls.Add(LblSeleccioneUnaOpcion)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnTareas)
        Controls.Add(BtnEliminar)
        Controls.Add(BtnModificar)
        Controls.Add(BtnUsuarios)
        Controls.Add(BtnClientes)
        Name = "FrmModificarEliminar"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmModificarEliminar"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnClientes As Button
    Friend WithEvents BtnUsuarios As Button
    Friend WithEvents BtnModificar As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnTareas As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents LblSeleccioneUnaOpcion As Label
    Friend WithEvents DgvDatos As DataGridView
End Class
