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
        BtnCerrar = New Button()
        LblComentario = New Label()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDatos
        ' 
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.AllowUserToDeleteRows = False
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(21, 41)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.ReadOnly = True
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(1158, 404)
        DgvDatos.TabIndex = 0
        ' 
        ' BtnCerrar
        ' 
        BtnCerrar.Location = New Point(1104, 451)
        BtnCerrar.Name = "BtnCerrar"
        BtnCerrar.Size = New Size(75, 23)
        BtnCerrar.TabIndex = 4
        BtnCerrar.Text = "Cerrar"
        BtnCerrar.UseVisualStyleBackColor = True
        ' 
        ' LblComentario
        ' 
        LblComentario.AutoSize = True
        LblComentario.Location = New Point(21, 23)
        LblComentario.Name = "LblComentario"
        LblComentario.Size = New Size(260, 15)
        LblComentario.TabIndex = 5
        LblComentario.Text = "Doble clic para modificar o eliminar el elemento"
        ' 
        ' FrmModificarTarea
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1191, 495)
        Controls.Add(LblComentario)
        Controls.Add(BtnCerrar)
        Controls.Add(DgvDatos)
        Name = "FrmModificarTarea"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmModificarTarea"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents LblSeleccionarUnaOpcion As Label
    Friend WithEvents BtnModificar As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents LblComentario As Label
End Class
