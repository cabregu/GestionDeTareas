<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsignarTareas
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
        CmbCodigo = New ComboBox()
        LblCodigo = New Label()
        TxtCliente = New TextBox()
        LblCliente = New Label()
        LblFechaLimite = New Label()
        TxtFechaLimite = New TextBox()
        LblProyecto = New Label()
        TxtProyecto = New TextBox()
        LblTarea = New Label()
        TxtTarea = New TextBox()
        LblPrioridad = New Label()
        TxtNivelPrioridad = New TextBox()
        LblComentario = New Label()
        TxtComentario = New TextBox()
        LblAsignar = New Label()
        CmbAsignar = New ComboBox()
        BtnAsignar = New Button()
        BtnAsignarycerrar = New Button()
        SuspendLayout()
        ' 
        ' CmbCodigo
        ' 
        CmbCodigo.FormattingEnabled = True
        CmbCodigo.Location = New Point(12, 33)
        CmbCodigo.Name = "CmbCodigo"
        CmbCodigo.Size = New Size(121, 23)
        CmbCodigo.TabIndex = 0
        ' 
        ' LblCodigo
        ' 
        LblCodigo.AutoSize = True
        LblCodigo.Location = New Point(51, 15)
        LblCodigo.Name = "LblCodigo"
        LblCodigo.Size = New Size(46, 15)
        LblCodigo.TabIndex = 1
        LblCodigo.Text = "Codigo"
        ' 
        ' TxtCliente
        ' 
        TxtCliente.Location = New Point(158, 33)
        TxtCliente.Name = "TxtCliente"
        TxtCliente.Size = New Size(237, 23)
        TxtCliente.TabIndex = 2
        ' 
        ' LblCliente
        ' 
        LblCliente.AutoSize = True
        LblCliente.Location = New Point(253, 15)
        LblCliente.Name = "LblCliente"
        LblCliente.Size = New Size(44, 15)
        LblCliente.TabIndex = 3
        LblCliente.Text = "Cliente"
        ' 
        ' LblFechaLimite
        ' 
        LblFechaLimite.AutoSize = True
        LblFechaLimite.Location = New Point(34, 92)
        LblFechaLimite.Name = "LblFechaLimite"
        LblFechaLimite.Size = New Size(74, 15)
        LblFechaLimite.TabIndex = 5
        LblFechaLimite.Text = "Fecha Limite"
        ' 
        ' TxtFechaLimite
        ' 
        TxtFechaLimite.Location = New Point(12, 110)
        TxtFechaLimite.Name = "TxtFechaLimite"
        TxtFechaLimite.Size = New Size(121, 23)
        TxtFechaLimite.TabIndex = 4
        ' 
        ' LblProyecto
        ' 
        LblProyecto.AutoSize = True
        LblProyecto.Location = New Point(253, 92)
        LblProyecto.Name = "LblProyecto"
        LblProyecto.Size = New Size(54, 15)
        LblProyecto.TabIndex = 7
        LblProyecto.Text = "Proyecto"
        ' 
        ' TxtProyecto
        ' 
        TxtProyecto.Location = New Point(158, 110)
        TxtProyecto.Name = "TxtProyecto"
        TxtProyecto.Size = New Size(237, 23)
        TxtProyecto.TabIndex = 6
        ' 
        ' LblTarea
        ' 
        LblTarea.AutoSize = True
        LblTarea.Location = New Point(253, 168)
        LblTarea.Name = "LblTarea"
        LblTarea.Size = New Size(34, 15)
        LblTarea.TabIndex = 11
        LblTarea.Text = "Tarea"
        ' 
        ' TxtTarea
        ' 
        TxtTarea.Location = New Point(158, 186)
        TxtTarea.Name = "TxtTarea"
        TxtTarea.Size = New Size(237, 23)
        TxtTarea.TabIndex = 10
        ' 
        ' LblPrioridad
        ' 
        LblPrioridad.AutoSize = True
        LblPrioridad.Location = New Point(16, 168)
        LblPrioridad.Name = "LblPrioridad"
        LblPrioridad.Size = New Size(102, 15)
        LblPrioridad.TabIndex = 9
        LblPrioridad.Text = "Nivel De Prioridad"
        ' 
        ' TxtNivelPrioridad
        ' 
        TxtNivelPrioridad.Location = New Point(12, 186)
        TxtNivelPrioridad.Name = "TxtNivelPrioridad"
        TxtNivelPrioridad.Size = New Size(121, 23)
        TxtNivelPrioridad.TabIndex = 8
        ' 
        ' LblComentario
        ' 
        LblComentario.AutoSize = True
        LblComentario.Location = New Point(12, 241)
        LblComentario.Name = "LblComentario"
        LblComentario.Size = New Size(70, 15)
        LblComentario.TabIndex = 13
        LblComentario.Text = "Comentario"
        ' 
        ' TxtComentario
        ' 
        TxtComentario.Location = New Point(12, 259)
        TxtComentario.Multiline = True
        TxtComentario.Name = "TxtComentario"
        TxtComentario.Size = New Size(383, 89)
        TxtComentario.TabIndex = 12
        ' 
        ' LblAsignar
        ' 
        LblAsignar.AutoSize = True
        LblAsignar.Location = New Point(30, 378)
        LblAsignar.Name = "LblAsignar"
        LblAsignar.Size = New Size(61, 15)
        LblAsignar.TabIndex = 15
        LblAsignar.Text = "Asignar A:"
        ' 
        ' CmbAsignar
        ' 
        CmbAsignar.FormattingEnabled = True
        CmbAsignar.Location = New Point(100, 375)
        CmbAsignar.Name = "CmbAsignar"
        CmbAsignar.Size = New Size(215, 23)
        CmbAsignar.TabIndex = 14
        ' 
        ' BtnAsignar
        ' 
        BtnAsignar.Location = New Point(16, 415)
        BtnAsignar.Name = "BtnAsignar"
        BtnAsignar.Size = New Size(150, 40)
        BtnAsignar.TabIndex = 16
        BtnAsignar.Text = "Asignar"
        BtnAsignar.UseVisualStyleBackColor = True
        ' 
        ' BtnAsignarycerrar
        ' 
        BtnAsignarycerrar.Location = New Point(253, 415)
        BtnAsignarycerrar.Name = "BtnAsignarycerrar"
        BtnAsignarycerrar.Size = New Size(150, 40)
        BtnAsignarycerrar.TabIndex = 17
        BtnAsignarycerrar.Text = "Asignar y Cerrar"
        BtnAsignarycerrar.UseVisualStyleBackColor = True
        ' 
        ' FrmAsignarTareas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(421, 484)
        Controls.Add(BtnAsignarycerrar)
        Controls.Add(BtnAsignar)
        Controls.Add(LblAsignar)
        Controls.Add(CmbAsignar)
        Controls.Add(LblComentario)
        Controls.Add(TxtComentario)
        Controls.Add(LblTarea)
        Controls.Add(TxtTarea)
        Controls.Add(LblPrioridad)
        Controls.Add(TxtNivelPrioridad)
        Controls.Add(LblProyecto)
        Controls.Add(TxtProyecto)
        Controls.Add(LblFechaLimite)
        Controls.Add(TxtFechaLimite)
        Controls.Add(LblCliente)
        Controls.Add(TxtCliente)
        Controls.Add(LblCodigo)
        Controls.Add(CmbCodigo)
        Name = "FrmAsignarTareas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmAsignarTareas"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CmbCodigo As ComboBox
    Friend WithEvents LblCodigo As Label
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents LblFechaLimite As Label
    Friend WithEvents TxtFechaLimite As TextBox
    Friend WithEvents LblProyecto As Label
    Friend WithEvents TxtProyecto As TextBox
    Friend WithEvents LblTarea As Label
    Friend WithEvents TxtTarea As TextBox
    Friend WithEvents LblPrioridad As Label
    Friend WithEvents TxtNivelPrioridad As TextBox
    Friend WithEvents LblComentario As Label
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents LblAsignar As Label
    Friend WithEvents CmbAsignar As ComboBox
    Friend WithEvents BtnAsignar As Button
    Friend WithEvents BtnAsignarycerrar As Button
End Class
