<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPpal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        LblNombre = New Label()
        LblUsuario = New Label()
        LblTipoCargo = New Label()
        LblCargo = New Label()
        GpbTareas = New GroupBox()
        BtnModificarTarea = New Button()
        BtnAsignarTarea = New Button()
        BtnRealizarTarea = New Button()
        BtnCrearTarea = New Button()
        GpbDatos = New GroupBox()
        BtnModificarDatos = New Button()
        BtnCrearCliente = New Button()
        BtnCrearProyecto = New Button()
        BtnCrearUsuario = New Button()
        GpbReportes = New GroupBox()
        BtnReporte = New Button()
        BtnSalir = New Button()
        GpbTareas.SuspendLayout()
        GpbDatos.SuspendLayout()
        GpbReportes.SuspendLayout()
        SuspendLayout()
        ' 
        ' LblNombre
        ' 
        LblNombre.AutoSize = True
        LblNombre.Location = New Point(12, 9)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New Size(50, 15)
        LblNombre.TabIndex = 0
        LblNombre.Text = "Usuario:"
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(59, 9)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(14, 15)
        LblUsuario.TabIndex = 1
        LblUsuario.Text = "X"
        ' 
        ' LblTipoCargo
        ' 
        LblTipoCargo.AutoSize = True
        LblTipoCargo.Location = New Point(255, 9)
        LblTipoCargo.Name = "LblTipoCargo"
        LblTipoCargo.Size = New Size(42, 15)
        LblTipoCargo.TabIndex = 2
        LblTipoCargo.Text = "Cargo:"
        ' 
        ' LblCargo
        ' 
        LblCargo.AutoSize = True
        LblCargo.Location = New Point(317, 9)
        LblCargo.Name = "LblCargo"
        LblCargo.Size = New Size(30, 15)
        LblCargo.TabIndex = 3
        LblCargo.Text = "Tipo"
        ' 
        ' GpbTareas
        ' 
        GpbTareas.BackColor = SystemColors.ControlLight
        GpbTareas.Controls.Add(BtnModificarTarea)
        GpbTareas.Controls.Add(BtnAsignarTarea)
        GpbTareas.Controls.Add(BtnRealizarTarea)
        GpbTareas.Controls.Add(BtnCrearTarea)
        GpbTareas.Location = New Point(7, 62)
        GpbTareas.Name = "GpbTareas"
        GpbTareas.Size = New Size(438, 119)
        GpbTareas.TabIndex = 4
        GpbTareas.TabStop = False
        GpbTareas.Text = "Tareas Activas"
        ' 
        ' BtnModificarTarea
        ' 
        BtnModificarTarea.Location = New Point(280, 71)
        BtnModificarTarea.Name = "BtnModificarTarea"
        BtnModificarTarea.Size = New Size(150, 30)
        BtnModificarTarea.TabIndex = 3
        BtnModificarTarea.Text = "Modificar Tarea"
        BtnModificarTarea.UseVisualStyleBackColor = True
        ' 
        ' BtnAsignarTarea
        ' 
        BtnAsignarTarea.Location = New Point(280, 33)
        BtnAsignarTarea.Name = "BtnAsignarTarea"
        BtnAsignarTarea.Size = New Size(150, 30)
        BtnAsignarTarea.TabIndex = 2
        BtnAsignarTarea.Text = "Asignar Tarea"
        BtnAsignarTarea.UseVisualStyleBackColor = True
        ' 
        ' BtnRealizarTarea
        ' 
        BtnRealizarTarea.Location = New Point(40, 71)
        BtnRealizarTarea.Name = "BtnRealizarTarea"
        BtnRealizarTarea.Size = New Size(150, 30)
        BtnRealizarTarea.TabIndex = 1
        BtnRealizarTarea.Text = "Realizar Tarea"
        BtnRealizarTarea.UseVisualStyleBackColor = True
        ' 
        ' BtnCrearTarea
        ' 
        BtnCrearTarea.Location = New Point(40, 33)
        BtnCrearTarea.Name = "BtnCrearTarea"
        BtnCrearTarea.Size = New Size(150, 30)
        BtnCrearTarea.TabIndex = 0
        BtnCrearTarea.Text = "Crear Tarea"
        BtnCrearTarea.UseVisualStyleBackColor = True
        ' 
        ' GpbDatos
        ' 
        GpbDatos.BackColor = SystemColors.ControlLight
        GpbDatos.Controls.Add(BtnModificarDatos)
        GpbDatos.Controls.Add(BtnCrearCliente)
        GpbDatos.Controls.Add(BtnCrearProyecto)
        GpbDatos.Controls.Add(BtnCrearUsuario)
        GpbDatos.Location = New Point(7, 223)
        GpbDatos.Name = "GpbDatos"
        GpbDatos.Size = New Size(438, 119)
        GpbDatos.TabIndex = 5
        GpbDatos.TabStop = False
        GpbDatos.Text = "Datos"
        ' 
        ' BtnModificarDatos
        ' 
        BtnModificarDatos.Location = New Point(280, 70)
        BtnModificarDatos.Name = "BtnModificarDatos"
        BtnModificarDatos.Size = New Size(150, 30)
        BtnModificarDatos.TabIndex = 3
        BtnModificarDatos.Text = "Modificar Datos"
        BtnModificarDatos.UseVisualStyleBackColor = True
        ' 
        ' BtnCrearCliente
        ' 
        BtnCrearCliente.Location = New Point(280, 32)
        BtnCrearCliente.Name = "BtnCrearCliente"
        BtnCrearCliente.Size = New Size(150, 30)
        BtnCrearCliente.TabIndex = 2
        BtnCrearCliente.Text = "Crear Cliente"
        BtnCrearCliente.UseVisualStyleBackColor = True
        ' 
        ' BtnCrearProyecto
        ' 
        BtnCrearProyecto.Location = New Point(40, 70)
        BtnCrearProyecto.Name = "BtnCrearProyecto"
        BtnCrearProyecto.Size = New Size(150, 30)
        BtnCrearProyecto.TabIndex = 1
        BtnCrearProyecto.Text = "Crear Proyecto"
        BtnCrearProyecto.UseVisualStyleBackColor = True
        ' 
        ' BtnCrearUsuario
        ' 
        BtnCrearUsuario.Location = New Point(40, 32)
        BtnCrearUsuario.Name = "BtnCrearUsuario"
        BtnCrearUsuario.Size = New Size(150, 30)
        BtnCrearUsuario.TabIndex = 0
        BtnCrearUsuario.Text = "Crear Usuario"
        BtnCrearUsuario.UseVisualStyleBackColor = True
        ' 
        ' GpbReportes
        ' 
        GpbReportes.BackColor = SystemColors.ControlLight
        GpbReportes.Controls.Add(BtnReporte)
        GpbReportes.Location = New Point(7, 361)
        GpbReportes.Name = "GpbReportes"
        GpbReportes.Size = New Size(430, 119)
        GpbReportes.TabIndex = 6
        GpbReportes.TabStop = False
        GpbReportes.Text = "Reportes"
        ' 
        ' BtnReporte
        ' 
        BtnReporte.Location = New Point(40, 56)
        BtnReporte.Name = "BtnReporte"
        BtnReporte.Size = New Size(150, 30)
        BtnReporte.TabIndex = 2
        BtnReporte.Text = "Crear Reporte"
        BtnReporte.UseVisualStyleBackColor = True
        ' 
        ' BtnSalir
        ' 
        BtnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        BtnSalir.Location = New Point(287, 493)
        BtnSalir.Name = "BtnSalir"
        BtnSalir.Size = New Size(150, 30)
        BtnSalir.TabIndex = 0
        BtnSalir.Text = "Salir"
        BtnSalir.UseVisualStyleBackColor = True
        ' 
        ' FrmPpal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(457, 535)
        Controls.Add(GpbReportes)
        Controls.Add(GpbDatos)
        Controls.Add(BtnSalir)
        Controls.Add(GpbTareas)
        Controls.Add(LblCargo)
        Controls.Add(LblTipoCargo)
        Controls.Add(LblUsuario)
        Controls.Add(LblNombre)
        Name = "FrmPpal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Gestion de tareas"
        GpbTareas.ResumeLayout(False)
        GpbDatos.ResumeLayout(False)
        GpbReportes.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblNombre As Label
    Friend WithEvents LblUsuario As Label
    Friend WithEvents LblTipoCargo As Label
    Friend WithEvents LblCargo As Label
    Friend WithEvents GpbTareas As GroupBox
    Friend WithEvents BtnModificarTarea As Button
    Friend WithEvents BtnAsignarTarea As Button
    Friend WithEvents BtnRealizarTarea As Button
    Friend WithEvents BtnCrearTarea As Button
    Friend WithEvents GpbDatos As GroupBox
    Friend WithEvents BtnModificarDatos As Button
    Friend WithEvents BtnCrearCliente As Button
    Friend WithEvents BtnCrearProyecto As Button
    Friend WithEvents BtnCrearUsuario As Button
    Friend WithEvents GpbReportes As GroupBox
    Friend WithEvents BtnReporte As Button
    Friend WithEvents BtnSalir As Button

End Class
