<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrearProyecto
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
        RbProyectoExistente = New RadioButton()
        RbNuevoProyecto = New RadioButton()
        CmbProyectoExistente = New ComboBox()
        TxtNuevoProyecto = New TextBox()
        LblAgregarProyecto = New Label()
        DgvTareas = New DataGridView()
        Tareas = New DataGridViewTextBoxColumn()
        TxtNuevaTarea = New TextBox()
        BtnAgregar = New Button()
        BtnCancelar = New Button()
        BtnConfirmar = New Button()
        CType(DgvTareas, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RbProyectoExistente
        ' 
        RbProyectoExistente.AutoSize = True
        RbProyectoExistente.Location = New Point(34, 25)
        RbProyectoExistente.Name = "RbProyectoExistente"
        RbProyectoExistente.Size = New Size(122, 19)
        RbProyectoExistente.TabIndex = 0
        RbProyectoExistente.TabStop = True
        RbProyectoExistente.Text = "Proyecto Existente"
        RbProyectoExistente.UseVisualStyleBackColor = True
        ' 
        ' RbNuevoProyecto
        ' 
        RbNuevoProyecto.AutoSize = True
        RbNuevoProyecto.Location = New Point(267, 25)
        RbNuevoProyecto.Name = "RbNuevoProyecto"
        RbNuevoProyecto.Size = New Size(110, 19)
        RbNuevoProyecto.TabIndex = 1
        RbNuevoProyecto.TabStop = True
        RbNuevoProyecto.Text = "Nuevo Proyecto"
        RbNuevoProyecto.UseVisualStyleBackColor = True
        ' 
        ' CmbProyectoExistente
        ' 
        CmbProyectoExistente.FormattingEnabled = True
        CmbProyectoExistente.Location = New Point(34, 50)
        CmbProyectoExistente.Name = "CmbProyectoExistente"
        CmbProyectoExistente.Size = New Size(212, 23)
        CmbProyectoExistente.TabIndex = 2
        ' 
        ' TxtNuevoProyecto
        ' 
        TxtNuevoProyecto.Location = New Point(267, 50)
        TxtNuevoProyecto.Name = "TxtNuevoProyecto"
        TxtNuevoProyecto.Size = New Size(219, 23)
        TxtNuevoProyecto.TabIndex = 3
        ' 
        ' LblAgregarProyecto
        ' 
        LblAgregarProyecto.AutoSize = True
        LblAgregarProyecto.Location = New Point(67, 122)
        LblAgregarProyecto.Name = "LblAgregarProyecto"
        LblAgregarProyecto.Size = New Size(79, 15)
        LblAgregarProyecto.TabIndex = 4
        LblAgregarProyecto.Text = "Agregar Tarea"
        ' 
        ' DgvTareas
        ' 
        DgvTareas.AllowUserToAddRows = False
        DgvTareas.AllowUserToDeleteRows = False
        DgvTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvTareas.Columns.AddRange(New DataGridViewColumn() {Tareas})
        DgvTareas.Location = New Point(67, 149)
        DgvTareas.Name = "DgvTareas"
        DgvTareas.ReadOnly = True
        DgvTareas.RowTemplate.Height = 25
        DgvTareas.Size = New Size(372, 403)
        DgvTareas.TabIndex = 5
        ' 
        ' Tareas
        ' 
        Tareas.HeaderText = "Tareas"
        Tareas.Name = "Tareas"
        Tareas.ReadOnly = True
        Tareas.Width = 250
        ' 
        ' TxtNuevaTarea
        ' 
        TxtNuevaTarea.Location = New Point(152, 119)
        TxtNuevaTarea.Name = "TxtNuevaTarea"
        TxtNuevaTarea.Size = New Size(225, 23)
        TxtNuevaTarea.TabIndex = 6
        ' 
        ' BtnAgregar
        ' 
        BtnAgregar.Location = New Point(383, 118)
        BtnAgregar.Name = "BtnAgregar"
        BtnAgregar.Size = New Size(56, 23)
        BtnAgregar.TabIndex = 7
        BtnAgregar.Text = "Añadir"
        BtnAgregar.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(297, 591)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(142, 39)
        BtnCancelar.TabIndex = 9
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' BtnConfirmar
        ' 
        BtnConfirmar.Location = New Point(67, 591)
        BtnConfirmar.Name = "BtnConfirmar"
        BtnConfirmar.Size = New Size(164, 39)
        BtnConfirmar.TabIndex = 8
        BtnConfirmar.Text = "Confirmar Cambios"
        BtnConfirmar.UseVisualStyleBackColor = True
        ' 
        ' FrmCrearProyecto
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(530, 669)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnConfirmar)
        Controls.Add(BtnAgregar)
        Controls.Add(TxtNuevaTarea)
        Controls.Add(DgvTareas)
        Controls.Add(LblAgregarProyecto)
        Controls.Add(TxtNuevoProyecto)
        Controls.Add(CmbProyectoExistente)
        Controls.Add(RbNuevoProyecto)
        Controls.Add(RbProyectoExistente)
        Name = "FrmCrearProyecto"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmCrearProyecto"
        CType(DgvTareas, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RbProyectoExistente As RadioButton
    Friend WithEvents RbNuevoProyecto As RadioButton
    Friend WithEvents CmbProyectoExistente As ComboBox
    Friend WithEvents TxtNuevoProyecto As TextBox
    Friend WithEvents LblAgregarProyecto As Label
    Friend WithEvents DgvTareas As DataGridView
    Friend WithEvents Tareas As DataGridViewTextBoxColumn
    Friend WithEvents TxtNuevaTarea As TextBox
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnConfirmar As Button
End Class
