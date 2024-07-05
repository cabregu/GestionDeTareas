<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarTarea
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
        DgvDatos = New DataGridView()
        LblSeleccionarUnaOpcion = New Label()
        BtnModificar = New Button()
        BtnEliminar = New Button()
        BtnCancelar = New Button()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDatos
        ' 
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.AllowUserToDeleteRows = False
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(12, 79)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.ReadOnly = True
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(1158, 286)
        DgvDatos.TabIndex = 0
        ' 
        ' LblSeleccionarUnaOpcion
        ' 
        LblSeleccionarUnaOpcion.AutoSize = True
        LblSeleccionarUnaOpcion.Location = New Point(12, 61)
        LblSeleccionarUnaOpcion.Name = "LblSeleccionarUnaOpcion"
        LblSeleccionarUnaOpcion.Size = New Size(130, 15)
        LblSeleccionarUnaOpcion.TabIndex = 1
        LblSeleccionarUnaOpcion.Text = "Seleccionar una opcion"
        ' 
        ' BtnModificar
        ' 
        BtnModificar.Location = New Point(933, 50)
        BtnModificar.Name = "BtnModificar"
        BtnModificar.Size = New Size(75, 23)
        BtnModificar.TabIndex = 2
        BtnModificar.Text = "Modificar"
        BtnModificar.UseVisualStyleBackColor = True
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Location = New Point(1014, 50)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(75, 23)
        BtnEliminar.TabIndex = 3
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(1095, 50)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(75, 23)
        BtnCancelar.TabIndex = 4
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' FrmModificarTarea
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1185, 377)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnEliminar)
        Controls.Add(BtnModificar)
        Controls.Add(LblSeleccionarUnaOpcion)
        Controls.Add(DgvDatos)
        Name = "FrmModificarTarea"
        Text = "FrmModificarTarea"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents LblSeleccionarUnaOpcion As Label
    Friend WithEvents BtnModificar As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnCancelar As Button
End Class
