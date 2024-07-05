<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrearTareasPendientes
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
        CbmCliente = New ComboBox()
        LblCliente = New Label()
        LblProyecto = New Label()
        CmbProyecto = New ComboBox()
        LblTarea = New Label()
        CmbTarea = New ComboBox()
        LblNivleDePrioridad = New Label()
        CmbPrioridad = New ComboBox()
        DtpFechaLimite = New DateTimePicker()
        LblFechaLimite = New Label()
        TxtComentario = New TextBox()
        LblAsignar = New Label()
        CmbAsignar = New ComboBox()
        BtnCrearTarea = New Button()
        BtnCrearTareaysalir = New Button()
        LblUsuario = New Label()
        LblNombre = New Label()
        LblComenteario = New Label()
        SuspendLayout()
        ' 
        ' CbmCliente
        ' 
        CbmCliente.FormattingEnabled = True
        CbmCliente.Location = New Point(269, 32)
        CbmCliente.Name = "CbmCliente"
        CbmCliente.Size = New Size(185, 23)
        CbmCliente.TabIndex = 2
        ' 
        ' LblCliente
        ' 
        LblCliente.AutoSize = True
        LblCliente.Location = New Point(337, 14)
        LblCliente.Name = "LblCliente"
        LblCliente.Size = New Size(44, 15)
        LblCliente.TabIndex = 3
        LblCliente.Text = "Cliente"
        ' 
        ' LblProyecto
        ' 
        LblProyecto.AutoSize = True
        LblProyecto.Location = New Point(337, 78)
        LblProyecto.Name = "LblProyecto"
        LblProyecto.Size = New Size(54, 15)
        LblProyecto.TabIndex = 5
        LblProyecto.Text = "Proyecto"
        ' 
        ' CmbProyecto
        ' 
        CmbProyecto.FormattingEnabled = True
        CmbProyecto.Location = New Point(269, 96)
        CmbProyecto.Name = "CmbProyecto"
        CmbProyecto.Size = New Size(185, 23)
        CmbProyecto.TabIndex = 4
        ' 
        ' LblTarea
        ' 
        LblTarea.AutoSize = True
        LblTarea.Location = New Point(337, 139)
        LblTarea.Name = "LblTarea"
        LblTarea.Size = New Size(34, 15)
        LblTarea.TabIndex = 7
        LblTarea.Text = "Tarea"
        ' 
        ' CmbTarea
        ' 
        CmbTarea.FormattingEnabled = True
        CmbTarea.Location = New Point(269, 157)
        CmbTarea.Name = "CmbTarea"
        CmbTarea.Size = New Size(185, 23)
        CmbTarea.TabIndex = 6
        ' 
        ' LblNivleDePrioridad
        ' 
        LblNivleDePrioridad.AutoSize = True
        LblNivleDePrioridad.Location = New Point(58, 139)
        LblNivleDePrioridad.Name = "LblNivleDePrioridad"
        LblNivleDePrioridad.Size = New Size(105, 15)
        LblNivleDePrioridad.TabIndex = 9
        LblNivleDePrioridad.Text = "Nivel de Propridad"
        ' 
        ' CmbPrioridad
        ' 
        CmbPrioridad.FormattingEnabled = True
        CmbPrioridad.Location = New Point(23, 157)
        CmbPrioridad.Name = "CmbPrioridad"
        CmbPrioridad.Size = New Size(185, 23)
        CmbPrioridad.TabIndex = 8
        ' 
        ' DtpFechaLimite
        ' 
        DtpFechaLimite.Format = DateTimePickerFormat.Short
        DtpFechaLimite.Location = New Point(23, 96)
        DtpFechaLimite.Name = "DtpFechaLimite"
        DtpFechaLimite.Size = New Size(185, 23)
        DtpFechaLimite.TabIndex = 10
        ' 
        ' LblFechaLimite
        ' 
        LblFechaLimite.AutoSize = True
        LblFechaLimite.Location = New Point(69, 78)
        LblFechaLimite.Name = "LblFechaLimite"
        LblFechaLimite.Size = New Size(74, 15)
        LblFechaLimite.TabIndex = 11
        LblFechaLimite.Text = "Fecha Limite"
        ' 
        ' TxtComentario
        ' 
        TxtComentario.Location = New Point(23, 222)
        TxtComentario.Multiline = True
        TxtComentario.Name = "TxtComentario"
        TxtComentario.Size = New Size(431, 98)
        TxtComentario.TabIndex = 12
        ' 
        ' LblAsignar
        ' 
        LblAsignar.AutoSize = True
        LblAsignar.Location = New Point(89, 345)
        LblAsignar.Name = "LblAsignar"
        LblAsignar.Size = New Size(47, 15)
        LblAsignar.TabIndex = 14
        LblAsignar.Text = "Asignar"
        ' 
        ' CmbAsignar
        ' 
        CmbAsignar.FormattingEnabled = True
        CmbAsignar.Location = New Point(23, 363)
        CmbAsignar.Name = "CmbAsignar"
        CmbAsignar.Size = New Size(185, 23)
        CmbAsignar.TabIndex = 13
        ' 
        ' BtnCrearTarea
        ' 
        BtnCrearTarea.Location = New Point(23, 428)
        BtnCrearTarea.Name = "BtnCrearTarea"
        BtnCrearTarea.Size = New Size(150, 30)
        BtnCrearTarea.TabIndex = 15
        BtnCrearTarea.Text = "Crear Tarea"
        BtnCrearTarea.UseVisualStyleBackColor = True
        ' 
        ' BtnCrearTareaysalir
        ' 
        BtnCrearTareaysalir.Location = New Point(304, 428)
        BtnCrearTareaysalir.Name = "BtnCrearTareaysalir"
        BtnCrearTareaysalir.Size = New Size(150, 30)
        BtnCrearTareaysalir.TabIndex = 16
        BtnCrearTareaysalir.Text = "Crear y Cerrar"
        BtnCrearTareaysalir.UseVisualStyleBackColor = True
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(89, 32)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(14, 15)
        LblUsuario.TabIndex = 18
        LblUsuario.Text = "X"
        ' 
        ' LblNombre
        ' 
        LblNombre.AutoSize = True
        LblNombre.Location = New Point(23, 32)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New Size(50, 15)
        LblNombre.TabIndex = 17
        LblNombre.Text = "Usuario:"
        ' 
        ' LblComenteario
        ' 
        LblComenteario.AutoSize = True
        LblComenteario.Location = New Point(26, 201)
        LblComenteario.Name = "LblComenteario"
        LblComenteario.Size = New Size(70, 15)
        LblComenteario.TabIndex = 19
        LblComenteario.Text = "Comentario"
        ' 
        ' FrmCrearTareasPendientes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(466, 478)
        Controls.Add(LblComenteario)
        Controls.Add(LblUsuario)
        Controls.Add(LblNombre)
        Controls.Add(BtnCrearTareaysalir)
        Controls.Add(BtnCrearTarea)
        Controls.Add(LblAsignar)
        Controls.Add(CmbAsignar)
        Controls.Add(TxtComentario)
        Controls.Add(LblFechaLimite)
        Controls.Add(DtpFechaLimite)
        Controls.Add(LblNivleDePrioridad)
        Controls.Add(CmbPrioridad)
        Controls.Add(LblTarea)
        Controls.Add(CmbTarea)
        Controls.Add(LblProyecto)
        Controls.Add(CmbProyecto)
        Controls.Add(LblCliente)
        Controls.Add(CbmCliente)
        Name = "FrmCrearTareasPendientes"
        Text = "Crear Tareas Pendientes"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents CbmCliente As ComboBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents LblProyecto As Label
    Friend WithEvents CmbProyecto As ComboBox
    Friend WithEvents LblTarea As Label
    Friend WithEvents CmbTarea As ComboBox
    Friend WithEvents LblNivleDePrioridad As Label
    Friend WithEvents CmbPrioridad As ComboBox
    Friend WithEvents DtpFechaLimite As DateTimePicker
    Friend WithEvents LblFechaLimite As Label
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents LblAsignar As Label
    Friend WithEvents CmbAsignar As ComboBox
    Friend WithEvents BtnCrearTarea As Button
    Friend WithEvents BtnCrearTareaysalir As Button
    Friend WithEvents LblUsuario As Label
    Friend WithEvents LblNombre As Label
    Friend WithEvents LblComenteario As Label
End Class
