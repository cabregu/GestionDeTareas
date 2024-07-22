<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarEliminarElemento
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
        TxtCodigo = New TextBox()
        CmbCliente = New ComboBox()
        CmbProyecto = New ComboBox()
        CmbTarea = New ComboBox()
        CmbPrioridad = New ComboBox()
        DtpFechaLimite = New DateTimePicker()
        TxtEstadoActual = New TextBox()
        LblEstado = New Label()
        LblUsuario = New Label()
        SuspendLayout()
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Location = New Point(273, 345)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(150, 40)
        BtnEliminar.TabIndex = 35
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnModifica
        ' 
        BtnModifica.Location = New Point(12, 345)
        BtnModifica.Name = "BtnModifica"
        BtnModifica.Size = New Size(150, 40)
        BtnModifica.TabIndex = 34
        BtnModifica.Text = "Modificar"
        BtnModifica.UseVisualStyleBackColor = True
        ' 
        ' CmbUsuario
        ' 
        CmbUsuario.FormattingEnabled = True
        CmbUsuario.Location = New Point(188, 193)
        CmbUsuario.Name = "CmbUsuario"
        CmbUsuario.Size = New Size(235, 23)
        CmbUsuario.TabIndex = 32
        ' 
        ' LblComentario
        ' 
        LblComentario.AutoSize = True
        LblComentario.Location = New Point(12, 220)
        LblComentario.Name = "LblComentario"
        LblComentario.Size = New Size(70, 15)
        LblComentario.TabIndex = 31
        LblComentario.Text = "Comentario"
        ' 
        ' TxtComentario
        ' 
        TxtComentario.Location = New Point(12, 238)
        TxtComentario.Multiline = True
        TxtComentario.Name = "TxtComentario"
        TxtComentario.Size = New Size(411, 89)
        TxtComentario.TabIndex = 30
        ' 
        ' LblTarea
        ' 
        LblTarea.AutoSize = True
        LblTarea.Location = New Point(188, 120)
        LblTarea.Name = "LblTarea"
        LblTarea.Size = New Size(34, 15)
        LblTarea.TabIndex = 29
        LblTarea.Text = "Tarea"
        ' 
        ' LblPrioridad
        ' 
        LblPrioridad.AutoSize = True
        LblPrioridad.Location = New Point(12, 120)
        LblPrioridad.Name = "LblPrioridad"
        LblPrioridad.Size = New Size(102, 15)
        LblPrioridad.TabIndex = 27
        LblPrioridad.Text = "Nivel De Prioridad"
        ' 
        ' LblProyecto
        ' 
        LblProyecto.AutoSize = True
        LblProyecto.Location = New Point(186, 69)
        LblProyecto.Name = "LblProyecto"
        LblProyecto.Size = New Size(54, 15)
        LblProyecto.TabIndex = 25
        LblProyecto.Text = "Proyecto"
        ' 
        ' LblFechaLimite
        ' 
        LblFechaLimite.AutoSize = True
        LblFechaLimite.Location = New Point(12, 69)
        LblFechaLimite.Name = "LblFechaLimite"
        LblFechaLimite.Size = New Size(74, 15)
        LblFechaLimite.TabIndex = 23
        LblFechaLimite.Text = "Fecha Limite"
        ' 
        ' LblCliente
        ' 
        LblCliente.AutoSize = True
        LblCliente.Location = New Point(186, 16)
        LblCliente.Name = "LblCliente"
        LblCliente.Size = New Size(44, 15)
        LblCliente.TabIndex = 21
        LblCliente.Text = "Cliente"
        ' 
        ' LblCodigo
        ' 
        LblCodigo.AutoSize = True
        LblCodigo.Location = New Point(12, 16)
        LblCodigo.Name = "LblCodigo"
        LblCodigo.Size = New Size(46, 15)
        LblCodigo.TabIndex = 19
        LblCodigo.Text = "Codigo"
        ' 
        ' TxtCodigo
        ' 
        TxtCodigo.Enabled = False
        TxtCodigo.Location = New Point(14, 34)
        TxtCodigo.Name = "TxtCodigo"
        TxtCodigo.Size = New Size(154, 23)
        TxtCodigo.TabIndex = 43
        ' 
        ' CmbCliente
        ' 
        CmbCliente.FormattingEnabled = True
        CmbCliente.Location = New Point(188, 34)
        CmbCliente.Name = "CmbCliente"
        CmbCliente.Size = New Size(235, 23)
        CmbCliente.TabIndex = 44
        ' 
        ' CmbProyecto
        ' 
        CmbProyecto.FormattingEnabled = True
        CmbProyecto.Location = New Point(188, 87)
        CmbProyecto.Name = "CmbProyecto"
        CmbProyecto.Size = New Size(235, 23)
        CmbProyecto.TabIndex = 45
        ' 
        ' CmbTarea
        ' 
        CmbTarea.FormattingEnabled = True
        CmbTarea.Location = New Point(188, 138)
        CmbTarea.Name = "CmbTarea"
        CmbTarea.Size = New Size(235, 23)
        CmbTarea.TabIndex = 46
        ' 
        ' CmbPrioridad
        ' 
        CmbPrioridad.FormattingEnabled = True
        CmbPrioridad.Location = New Point(14, 138)
        CmbPrioridad.Name = "CmbPrioridad"
        CmbPrioridad.Size = New Size(152, 23)
        CmbPrioridad.TabIndex = 47
        ' 
        ' DtpFechaLimite
        ' 
        DtpFechaLimite.Format = DateTimePickerFormat.Short
        DtpFechaLimite.Location = New Point(14, 87)
        DtpFechaLimite.Name = "DtpFechaLimite"
        DtpFechaLimite.Size = New Size(152, 23)
        DtpFechaLimite.TabIndex = 48
        ' 
        ' TxtEstadoActual
        ' 
        TxtEstadoActual.Location = New Point(14, 194)
        TxtEstadoActual.Name = "TxtEstadoActual"
        TxtEstadoActual.Size = New Size(154, 23)
        TxtEstadoActual.TabIndex = 49
        ' 
        ' LblEstado
        ' 
        LblEstado.AutoSize = True
        LblEstado.Location = New Point(17, 176)
        LblEstado.Name = "LblEstado"
        LblEstado.Size = New Size(42, 15)
        LblEstado.TabIndex = 50
        LblEstado.Text = "Estado"
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(189, 175)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(47, 15)
        LblUsuario.TabIndex = 51
        LblUsuario.Text = "Usuario"
        ' 
        ' FrmModificarEliminarElemento
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(432, 398)
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
        Name = "FrmModificarEliminarElemento"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmModificarEliminarElemento"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnModifica As Button
    Friend WithEvents LblAsignar As Label
    Friend WithEvents CmbUsuario As ComboBox
    Friend WithEvents LblComentario As Label
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents LblTarea As Label
    Friend WithEvents LblPrioridad As Label
    Friend WithEvents LblProyecto As Label
    Friend WithEvents LblFechaLimite As Label
    Friend WithEvents LblCliente As Label
    Friend WithEvents LblCodigo As Label
    Friend WithEvents CmbCodigo As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents TxtEstadoActual As TextBox
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents CmbCliente As ComboBox
    Friend WithEvents CmbProyecto As ComboBox
    Friend WithEvents CmbTarea As ComboBox
    Friend WithEvents CmbPrioridad As ComboBox
    Friend WithEvents DtpFechaLimite As DateTimePicker
    Friend WithEvents LblEstado As Label
    Friend WithEvents LblUsuario As Label
    Friend WithEvents TxtEstado As TextBox
End Class
