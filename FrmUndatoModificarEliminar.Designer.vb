<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUndatoModificarEliminar
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
        LblUsuario = New Label()
        LblEstado = New Label()
        TxtEstadoActual = New TextBox()
        DtpFechaLimite = New DateTimePicker()
        CmbPrioridad = New ComboBox()
        CmbTarea = New ComboBox()
        CmbProyecto = New ComboBox()
        CmbCliente = New ComboBox()
        TxtCodigo = New TextBox()
        BtnEliminar = New Button()
        BtnModifica = New Button()
        CmbUsuario = New ComboBox()
        LblComentario = New Label()
        TxtComentario = New TextBox()
        LblTarea = New Label()
        LblPrioridad = New Label()
        LblProyecto = New Label()
        LblFechaLimite = New Label()
        LblCliente = New Label()
        LblCodigo = New Label()
        SuspendLayout()
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(187, 168)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(47, 15)
        LblUsuario.TabIndex = 71
        LblUsuario.Text = "Usuario"
        ' 
        ' LblEstado
        ' 
        LblEstado.AutoSize = True
        LblEstado.Location = New Point(15, 169)
        LblEstado.Name = "LblEstado"
        LblEstado.Size = New Size(42, 15)
        LblEstado.TabIndex = 70
        LblEstado.Text = "Estado"
        ' 
        ' TxtEstadoActual
        ' 
        TxtEstadoActual.Enabled = False
        TxtEstadoActual.Location = New Point(12, 187)
        TxtEstadoActual.Name = "TxtEstadoActual"
        TxtEstadoActual.Size = New Size(154, 23)
        TxtEstadoActual.TabIndex = 69
        ' 
        ' DtpFechaLimite
        ' 
        DtpFechaLimite.Format = DateTimePickerFormat.Short
        DtpFechaLimite.Location = New Point(12, 80)
        DtpFechaLimite.Name = "DtpFechaLimite"
        DtpFechaLimite.Size = New Size(152, 23)
        DtpFechaLimite.TabIndex = 68
        ' 
        ' CmbPrioridad
        ' 
        CmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList
        CmbPrioridad.FormattingEnabled = True
        CmbPrioridad.Items.AddRange(New Object() {"Bajo", "Medio", "Alto", "Inmediato"})
        CmbPrioridad.Location = New Point(12, 131)
        CmbPrioridad.Name = "CmbPrioridad"
        CmbPrioridad.Size = New Size(152, 23)
        CmbPrioridad.TabIndex = 67
        ' 
        ' CmbTarea
        ' 
        CmbTarea.DropDownStyle = ComboBoxStyle.DropDownList
        CmbTarea.FormattingEnabled = True
        CmbTarea.Location = New Point(186, 131)
        CmbTarea.Name = "CmbTarea"
        CmbTarea.Size = New Size(235, 23)
        CmbTarea.TabIndex = 66
        ' 
        ' CmbProyecto
        ' 
        CmbProyecto.DropDownStyle = ComboBoxStyle.DropDownList
        CmbProyecto.FormattingEnabled = True
        CmbProyecto.Location = New Point(186, 80)
        CmbProyecto.Name = "CmbProyecto"
        CmbProyecto.Size = New Size(235, 23)
        CmbProyecto.TabIndex = 65
        ' 
        ' CmbCliente
        ' 
        CmbCliente.DropDownStyle = ComboBoxStyle.DropDownList
        CmbCliente.FormattingEnabled = True
        CmbCliente.Location = New Point(186, 27)
        CmbCliente.Name = "CmbCliente"
        CmbCliente.Size = New Size(235, 23)
        CmbCliente.TabIndex = 64
        ' 
        ' TxtCodigo
        ' 
        TxtCodigo.Enabled = False
        TxtCodigo.Location = New Point(12, 27)
        TxtCodigo.Name = "TxtCodigo"
        TxtCodigo.Size = New Size(154, 23)
        TxtCodigo.TabIndex = 63
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Location = New Point(271, 353)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(150, 40)
        BtnEliminar.TabIndex = 62
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnModifica
        ' 
        BtnModifica.Location = New Point(10, 353)
        BtnModifica.Name = "BtnModifica"
        BtnModifica.Size = New Size(150, 40)
        BtnModifica.TabIndex = 61
        BtnModifica.Text = "Modificar"
        BtnModifica.UseVisualStyleBackColor = True
        ' 
        ' CmbUsuario
        ' 
        CmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList
        CmbUsuario.FormattingEnabled = True
        CmbUsuario.Location = New Point(186, 186)
        CmbUsuario.Name = "CmbUsuario"
        CmbUsuario.Size = New Size(235, 23)
        CmbUsuario.TabIndex = 60
        ' 
        ' LblComentario
        ' 
        LblComentario.AutoSize = True
        LblComentario.Location = New Point(10, 213)
        LblComentario.Name = "LblComentario"
        LblComentario.Size = New Size(70, 15)
        LblComentario.TabIndex = 59
        LblComentario.Text = "Comentario"
        ' 
        ' TxtComentario
        ' 
        TxtComentario.Location = New Point(10, 231)
        TxtComentario.Multiline = True
        TxtComentario.Name = "TxtComentario"
        TxtComentario.Size = New Size(411, 89)
        TxtComentario.TabIndex = 58
        ' 
        ' LblTarea
        ' 
        LblTarea.AutoSize = True
        LblTarea.Location = New Point(186, 113)
        LblTarea.Name = "LblTarea"
        LblTarea.Size = New Size(34, 15)
        LblTarea.TabIndex = 57
        LblTarea.Text = "Tarea"
        ' 
        ' LblPrioridad
        ' 
        LblPrioridad.AutoSize = True
        LblPrioridad.Location = New Point(10, 113)
        LblPrioridad.Name = "LblPrioridad"
        LblPrioridad.Size = New Size(102, 15)
        LblPrioridad.TabIndex = 56
        LblPrioridad.Text = "Nivel De Prioridad"
        ' 
        ' LblProyecto
        ' 
        LblProyecto.AutoSize = True
        LblProyecto.Location = New Point(184, 62)
        LblProyecto.Name = "LblProyecto"
        LblProyecto.Size = New Size(54, 15)
        LblProyecto.TabIndex = 55
        LblProyecto.Text = "Proyecto"
        ' 
        ' LblFechaLimite
        ' 
        LblFechaLimite.AutoSize = True
        LblFechaLimite.Location = New Point(10, 62)
        LblFechaLimite.Name = "LblFechaLimite"
        LblFechaLimite.Size = New Size(74, 15)
        LblFechaLimite.TabIndex = 54
        LblFechaLimite.Text = "Fecha Limite"
        ' 
        ' LblCliente
        ' 
        LblCliente.AutoSize = True
        LblCliente.Location = New Point(184, 9)
        LblCliente.Name = "LblCliente"
        LblCliente.Size = New Size(44, 15)
        LblCliente.TabIndex = 53
        LblCliente.Text = "Cliente"
        ' 
        ' LblCodigo
        ' 
        LblCodigo.AutoSize = True
        LblCodigo.Location = New Point(10, 9)
        LblCodigo.Name = "LblCodigo"
        LblCodigo.Size = New Size(46, 15)
        LblCodigo.TabIndex = 52
        LblCodigo.Text = "Codigo"
        ' 
        ' FrmUndatoModificarEliminar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(440, 414)
        Controls.Add(LblUsuario)
        Controls.Add(LblEstado)
        Controls.Add(TxtEstadoActual)
        Controls.Add(DtpFechaLimite)
        Controls.Add(CmbPrioridad)
        Controls.Add(CmbTarea)
        Controls.Add(CmbProyecto)
        Controls.Add(CmbCliente)
        Controls.Add(TxtCodigo)
        Controls.Add(BtnEliminar)
        Controls.Add(BtnModifica)
        Controls.Add(CmbUsuario)
        Controls.Add(LblComentario)
        Controls.Add(TxtComentario)
        Controls.Add(LblTarea)
        Controls.Add(LblPrioridad)
        Controls.Add(LblProyecto)
        Controls.Add(LblFechaLimite)
        Controls.Add(LblCliente)
        Controls.Add(LblCodigo)
        Name = "FrmUndatoModificarEliminar"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Modificar o Eliminar"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblUsuario As Label
    Friend WithEvents LblEstado As Label
    Friend WithEvents TxtEstadoActual As TextBox
    Friend WithEvents DtpFechaLimite As DateTimePicker
    Friend WithEvents CmbPrioridad As ComboBox
    Friend WithEvents CmbTarea As ComboBox
    Friend WithEvents CmbProyecto As ComboBox
    Friend WithEvents CmbCliente As ComboBox
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnModifica As Button
    Friend WithEvents CmbUsuario As ComboBox
    Friend WithEvents LblComentario As Label
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents LblTarea As Label
    Friend WithEvents LblPrioridad As Label
    Friend WithEvents LblProyecto As Label
    Friend WithEvents LblFechaLimite As Label
    Friend WithEvents LblCliente As Label
    Friend WithEvents LblCodigo As Label
End Class
