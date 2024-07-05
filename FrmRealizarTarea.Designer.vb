<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRealizarTarea
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
        TxtUsuario = New TextBox()
        LblUsuario = New Label()
        CmbCodigo = New ComboBox()
        LblCodigo = New Label()
        LblFechaLimite = New Label()
        TxtFechaLimite = New TextBox()
        LblCliente = New Label()
        TxtCliente = New TextBox()
        LblPrioridad = New Label()
        TxtPrioridad = New TextBox()
        LblProyecto = New Label()
        TxtProyecto = New TextBox()
        LblFechaInicio = New Label()
        TxtFechaInicio = New TextBox()
        LblTarea = New Label()
        TxtTarea = New TextBox()
        Lblcomentario = New Label()
        TxtComentario = New TextBox()
        LblComentarioFinal = New Label()
        TxtComentarioFinal = New TextBox()
        LblEstado = New Label()
        TxtEstado = New TextBox()
        BtnIniciar = New Button()
        BtnPausar = New Button()
        BtnRetomar = New Button()
        FtnFinalizar = New Button()
        SuspendLayout()
        ' 
        ' TxtUsuario
        ' 
        TxtUsuario.Location = New Point(20, 38)
        TxtUsuario.Name = "TxtUsuario"
        TxtUsuario.Size = New Size(180, 23)
        TxtUsuario.TabIndex = 0
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(79, 20)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(47, 15)
        LblUsuario.TabIndex = 1
        LblUsuario.Text = "Usuario"
        ' 
        ' CmbCodigo
        ' 
        CmbCodigo.FormattingEnabled = True
        CmbCodigo.Location = New Point(307, 38)
        CmbCodigo.Name = "CmbCodigo"
        CmbCodigo.Size = New Size(180, 23)
        CmbCodigo.TabIndex = 2
        ' 
        ' LblCodigo
        ' 
        LblCodigo.AutoSize = True
        LblCodigo.Location = New Point(366, 20)
        LblCodigo.Name = "LblCodigo"
        LblCodigo.Size = New Size(46, 15)
        LblCodigo.TabIndex = 3
        LblCodigo.Text = "Codigo"
        ' 
        ' LblFechaLimite
        ' 
        LblFechaLimite.AutoSize = True
        LblFechaLimite.Location = New Point(67, 83)
        LblFechaLimite.Name = "LblFechaLimite"
        LblFechaLimite.Size = New Size(74, 15)
        LblFechaLimite.TabIndex = 5
        LblFechaLimite.Text = "Fecha Limite"
        ' 
        ' TxtFechaLimite
        ' 
        TxtFechaLimite.Location = New Point(20, 101)
        TxtFechaLimite.Name = "TxtFechaLimite"
        TxtFechaLimite.Size = New Size(180, 23)
        TxtFechaLimite.TabIndex = 4
        ' 
        ' LblCliente
        ' 
        LblCliente.AutoSize = True
        LblCliente.Location = New Point(366, 83)
        LblCliente.Name = "LblCliente"
        LblCliente.Size = New Size(44, 15)
        LblCliente.TabIndex = 7
        LblCliente.Text = "Cliente"
        ' 
        ' TxtCliente
        ' 
        TxtCliente.Location = New Point(307, 101)
        TxtCliente.Name = "TxtCliente"
        TxtCliente.Size = New Size(180, 23)
        TxtCliente.TabIndex = 6
        ' 
        ' LblPrioridad
        ' 
        LblPrioridad.AutoSize = True
        LblPrioridad.Location = New Point(79, 156)
        LblPrioridad.Name = "LblPrioridad"
        LblPrioridad.Size = New Size(55, 15)
        LblPrioridad.TabIndex = 9
        LblPrioridad.Text = "Prioridad"
        ' 
        ' TxtPrioridad
        ' 
        TxtPrioridad.Location = New Point(20, 174)
        TxtPrioridad.Name = "TxtPrioridad"
        TxtPrioridad.Size = New Size(180, 23)
        TxtPrioridad.TabIndex = 8
        ' 
        ' LblProyecto
        ' 
        LblProyecto.AutoSize = True
        LblProyecto.Location = New Point(366, 156)
        LblProyecto.Name = "LblProyecto"
        LblProyecto.Size = New Size(54, 15)
        LblProyecto.TabIndex = 11
        LblProyecto.Text = "Proyecto"
        ' 
        ' TxtProyecto
        ' 
        TxtProyecto.Location = New Point(307, 174)
        TxtProyecto.Name = "TxtProyecto"
        TxtProyecto.Size = New Size(180, 23)
        TxtProyecto.TabIndex = 10
        ' 
        ' LblFechaInicio
        ' 
        LblFechaInicio.AutoSize = True
        LblFechaInicio.Location = New Point(67, 225)
        LblFechaInicio.Name = "LblFechaInicio"
        LblFechaInicio.Size = New Size(86, 15)
        LblFechaInicio.TabIndex = 13
        LblFechaInicio.Text = "Fecha de Inicio"
        ' 
        ' TxtFechaInicio
        ' 
        TxtFechaInicio.Location = New Point(20, 243)
        TxtFechaInicio.Name = "TxtFechaInicio"
        TxtFechaInicio.Size = New Size(180, 23)
        TxtFechaInicio.TabIndex = 12
        ' 
        ' LblTarea
        ' 
        LblTarea.AutoSize = True
        LblTarea.Location = New Point(376, 225)
        LblTarea.Name = "LblTarea"
        LblTarea.Size = New Size(34, 15)
        LblTarea.TabIndex = 15
        LblTarea.Text = "Tarea"
        ' 
        ' TxtTarea
        ' 
        TxtTarea.Location = New Point(307, 243)
        TxtTarea.Name = "TxtTarea"
        TxtTarea.Size = New Size(180, 23)
        TxtTarea.TabIndex = 14
        ' 
        ' Lblcomentario
        ' 
        Lblcomentario.AutoSize = True
        Lblcomentario.Location = New Point(20, 296)
        Lblcomentario.Name = "Lblcomentario"
        Lblcomentario.Size = New Size(70, 15)
        Lblcomentario.TabIndex = 17
        Lblcomentario.Text = "Comentario"
        ' 
        ' TxtComentario
        ' 
        TxtComentario.Location = New Point(20, 314)
        TxtComentario.Multiline = True
        TxtComentario.Name = "TxtComentario"
        TxtComentario.Size = New Size(467, 81)
        TxtComentario.TabIndex = 16
        ' 
        ' LblComentarioFinal
        ' 
        LblComentarioFinal.AutoSize = True
        LblComentarioFinal.Location = New Point(20, 402)
        LblComentarioFinal.Name = "LblComentarioFinal"
        LblComentarioFinal.Size = New Size(98, 15)
        LblComentarioFinal.TabIndex = 19
        LblComentarioFinal.Text = "Comentario Final"
        ' 
        ' TxtComentarioFinal
        ' 
        TxtComentarioFinal.Location = New Point(20, 420)
        TxtComentarioFinal.Multiline = True
        TxtComentarioFinal.Name = "TxtComentarioFinal"
        TxtComentarioFinal.Size = New Size(467, 81)
        TxtComentarioFinal.TabIndex = 18
        ' 
        ' LblEstado
        ' 
        LblEstado.AutoSize = True
        LblEstado.Location = New Point(120, 523)
        LblEstado.Name = "LblEstado"
        LblEstado.Size = New Size(42, 15)
        LblEstado.TabIndex = 21
        LblEstado.Text = "Estado"
        ' 
        ' TxtEstado
        ' 
        TxtEstado.Location = New Point(173, 520)
        TxtEstado.Name = "TxtEstado"
        TxtEstado.Size = New Size(180, 23)
        TxtEstado.TabIndex = 20
        ' 
        ' BtnIniciar
        ' 
        BtnIniciar.Location = New Point(53, 573)
        BtnIniciar.Name = "BtnIniciar"
        BtnIniciar.Size = New Size(172, 40)
        BtnIniciar.TabIndex = 22
        BtnIniciar.Text = "Iniciar"
        BtnIniciar.UseVisualStyleBackColor = True
        ' 
        ' BtnPausar
        ' 
        BtnPausar.Location = New Point(285, 573)
        BtnPausar.Name = "BtnPausar"
        BtnPausar.Size = New Size(172, 40)
        BtnPausar.TabIndex = 23
        BtnPausar.Text = "Pausar"
        BtnPausar.UseVisualStyleBackColor = True
        ' 
        ' BtnRetomar
        ' 
        BtnRetomar.Location = New Point(53, 619)
        BtnRetomar.Name = "BtnRetomar"
        BtnRetomar.Size = New Size(172, 40)
        BtnRetomar.TabIndex = 24
        BtnRetomar.Text = "Retomar"
        BtnRetomar.UseVisualStyleBackColor = True
        ' 
        ' FtnFinalizar
        ' 
        FtnFinalizar.Location = New Point(285, 619)
        FtnFinalizar.Name = "FtnFinalizar"
        FtnFinalizar.Size = New Size(172, 40)
        FtnFinalizar.TabIndex = 25
        FtnFinalizar.Text = "Finalizar"
        FtnFinalizar.UseVisualStyleBackColor = True
        ' 
        ' FrmRealizarTarea
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(506, 684)
        Controls.Add(FtnFinalizar)
        Controls.Add(BtnRetomar)
        Controls.Add(BtnPausar)
        Controls.Add(BtnIniciar)
        Controls.Add(LblEstado)
        Controls.Add(TxtEstado)
        Controls.Add(LblComentarioFinal)
        Controls.Add(TxtComentarioFinal)
        Controls.Add(Lblcomentario)
        Controls.Add(TxtComentario)
        Controls.Add(LblTarea)
        Controls.Add(TxtTarea)
        Controls.Add(LblFechaInicio)
        Controls.Add(TxtFechaInicio)
        Controls.Add(LblProyecto)
        Controls.Add(TxtProyecto)
        Controls.Add(LblPrioridad)
        Controls.Add(TxtPrioridad)
        Controls.Add(LblCliente)
        Controls.Add(TxtCliente)
        Controls.Add(LblFechaLimite)
        Controls.Add(TxtFechaLimite)
        Controls.Add(LblCodigo)
        Controls.Add(CmbCodigo)
        Controls.Add(LblUsuario)
        Controls.Add(TxtUsuario)
        Name = "FrmRealizarTarea"
        Text = "Realizar"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents CmbCodigo As ComboBox
    Friend WithEvents LblCodigo As Label
    Friend WithEvents LblFechaLimite As Label
    Friend WithEvents TxtFechaLimite As TextBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents LblPrioridad As Label
    Friend WithEvents TxtPrioridad As TextBox
    Friend WithEvents LblProyecto As Label
    Friend WithEvents TxtProyecto As TextBox
    Friend WithEvents LblFechaInicio As Label
    Friend WithEvents TxtFechaInicio As TextBox
    Friend WithEvents LblTarea As Label
    Friend WithEvents TxtTarea As TextBox
    Friend WithEvents Lblcomentario As Label
    Friend WithEvents TxtComentario As TextBox
    Friend WithEvents LblComentarioFinal As Label
    Friend WithEvents TxtComentarioFinal As TextBox
    Friend WithEvents LblEstado As Label
    Friend WithEvents TxtEstado As TextBox
    Friend WithEvents BtnIniciar As Button
    Friend WithEvents BtnPausar As Button
    Friend WithEvents BtnRetomar As Button
    Friend WithEvents FtnFinalizar As Button
End Class
