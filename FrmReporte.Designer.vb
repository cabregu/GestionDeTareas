<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte
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
        DtpFechaInicial = New DateTimePicker()
        DtpFechaFinal = New DateTimePicker()
        LblFechaInicial = New Label()
        LblFechaFinal = New Label()
        DgvDatos = New DataGridView()
        BtnExcel = New Button()
        BtnConsultar = New Button()
        CHKEstatusdetareas = New CheckBox()
        ChkUsuarioshoras = New CheckBox()
        ChkClienteshoras = New CheckBox()
        ChkTareashoras = New CheckBox()
        ChkUsuariosClientes = New CheckBox()
        ChkUsuariosTareas = New CheckBox()
        ChkClientesUsuarios = New CheckBox()
        ChkClientesProyectos = New CheckBox()
        ChkCuadroNinja = New CheckBox()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DtpFechaInicial
        ' 
        DtpFechaInicial.Format = DateTimePickerFormat.Short
        DtpFechaInicial.Location = New Point(50, 56)
        DtpFechaInicial.Name = "DtpFechaInicial"
        DtpFechaInicial.Size = New Size(90, 23)
        DtpFechaInicial.TabIndex = 0
        ' 
        ' DtpFechaFinal
        ' 
        DtpFechaFinal.Format = DateTimePickerFormat.Short
        DtpFechaFinal.Location = New Point(198, 56)
        DtpFechaFinal.Name = "DtpFechaFinal"
        DtpFechaFinal.Size = New Size(90, 23)
        DtpFechaFinal.TabIndex = 1
        ' 
        ' LblFechaInicial
        ' 
        LblFechaInicial.AutoSize = True
        LblFechaInicial.Location = New Point(50, 25)
        LblFechaInicial.Name = "LblFechaInicial"
        LblFechaInicial.Size = New Size(72, 15)
        LblFechaInicial.TabIndex = 2
        LblFechaInicial.Text = "Fecha Inicial"
        ' 
        ' LblFechaFinal
        ' 
        LblFechaFinal.AutoSize = True
        LblFechaFinal.Location = New Point(198, 25)
        LblFechaFinal.Name = "LblFechaFinal"
        LblFechaFinal.Size = New Size(66, 15)
        LblFechaFinal.TabIndex = 3
        LblFechaFinal.Text = "Fecha Final"
        ' 
        ' DgvDatos
        ' 
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(50, 95)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(967, 414)
        DgvDatos.TabIndex = 4
        ' 
        ' BtnExcel
        ' 
        BtnExcel.Location = New Point(940, 586)
        BtnExcel.Name = "BtnExcel"
        BtnExcel.Size = New Size(75, 23)
        BtnExcel.TabIndex = 7
        BtnExcel.Text = "Xls"
        BtnExcel.UseVisualStyleBackColor = True
        ' 
        ' BtnConsultar
        ' 
        BtnConsultar.Location = New Point(940, 58)
        BtnConsultar.Name = "BtnConsultar"
        BtnConsultar.Size = New Size(75, 23)
        BtnConsultar.TabIndex = 8
        BtnConsultar.Text = "Consultar"
        BtnConsultar.UseVisualStyleBackColor = True
        ' 
        ' CHKEstatusdetareas
        ' 
        CHKEstatusdetareas.AutoSize = True
        CHKEstatusdetareas.Enabled = False
        CHKEstatusdetareas.Location = New Point(50, 559)
        CHKEstatusdetareas.Name = "CHKEstatusdetareas"
        CHKEstatusdetareas.Size = New Size(113, 19)
        CHKEstatusdetareas.TabIndex = 9
        CHKEstatusdetareas.Text = "Estatus de tareas"
        CHKEstatusdetareas.UseVisualStyleBackColor = True
        ' 
        ' ChkUsuarioshoras
        ' 
        ChkUsuarioshoras.AutoSize = True
        ChkUsuarioshoras.Enabled = False
        ChkUsuarioshoras.Location = New Point(50, 603)
        ChkUsuarioshoras.Name = "ChkUsuarioshoras"
        ChkUsuarioshoras.Size = New Size(103, 19)
        ChkUsuarioshoras.TabIndex = 10
        ChkUsuarioshoras.Text = "Usuarios horas"
        ChkUsuarioshoras.UseVisualStyleBackColor = True
        ' 
        ' ChkClienteshoras
        ' 
        ChkClienteshoras.AutoSize = True
        ChkClienteshoras.Enabled = False
        ChkClienteshoras.Location = New Point(169, 559)
        ChkClienteshoras.Name = "ChkClienteshoras"
        ChkClienteshoras.Size = New Size(100, 19)
        ChkClienteshoras.TabIndex = 11
        ChkClienteshoras.Text = "Clientes horas"
        ChkClienteshoras.UseVisualStyleBackColor = True
        ' 
        ' ChkTareashoras
        ' 
        ChkTareashoras.AutoSize = True
        ChkTareashoras.Enabled = False
        ChkTareashoras.Location = New Point(169, 603)
        ChkTareashoras.Name = "ChkTareashoras"
        ChkTareashoras.Size = New Size(90, 19)
        ChkTareashoras.TabIndex = 12
        ChkTareashoras.Text = "Tareas horas"
        ChkTareashoras.UseVisualStyleBackColor = True
        ' 
        ' ChkUsuariosClientes
        ' 
        ChkUsuariosClientes.AutoSize = True
        ChkUsuariosClientes.Enabled = False
        ChkUsuariosClientes.Location = New Point(278, 559)
        ChkUsuariosClientes.Name = "ChkUsuariosClientes"
        ChkUsuariosClientes.Size = New Size(118, 19)
        ChkUsuariosClientes.TabIndex = 13
        ChkUsuariosClientes.Text = "Usuarios-Clientes"
        ChkUsuariosClientes.UseVisualStyleBackColor = True
        ' 
        ' ChkUsuariosTareas
        ' 
        ChkUsuariosTareas.AutoSize = True
        ChkUsuariosTareas.Enabled = False
        ChkUsuariosTareas.Location = New Point(278, 606)
        ChkUsuariosTareas.Name = "ChkUsuariosTareas"
        ChkUsuariosTareas.Size = New Size(108, 19)
        ChkUsuariosTareas.TabIndex = 14
        ChkUsuariosTareas.Text = "Usuarios-Tareas"
        ChkUsuariosTareas.UseVisualStyleBackColor = True
        ' 
        ' ChkClientesUsuarios
        ' 
        ChkClientesUsuarios.AutoSize = True
        ChkClientesUsuarios.Enabled = False
        ChkClientesUsuarios.Location = New Point(402, 606)
        ChkClientesUsuarios.Name = "ChkClientesUsuarios"
        ChkClientesUsuarios.Size = New Size(118, 19)
        ChkClientesUsuarios.TabIndex = 15
        ChkClientesUsuarios.Text = "Clientes-Usuarios"
        ChkClientesUsuarios.UseVisualStyleBackColor = True
        ' 
        ' ChkClientesProyectos
        ' 
        ChkClientesProyectos.AutoSize = True
        ChkClientesProyectos.Enabled = False
        ChkClientesProyectos.Location = New Point(402, 559)
        ChkClientesProyectos.Name = "ChkClientesProyectos"
        ChkClientesProyectos.Size = New Size(125, 19)
        ChkClientesProyectos.TabIndex = 16
        ChkClientesProyectos.Text = "Clientes-Proyectos"
        ChkClientesProyectos.UseVisualStyleBackColor = True
        ' 
        ' ChkCuadroNinja
        ' 
        ChkCuadroNinja.AutoSize = True
        ChkCuadroNinja.Enabled = False
        ChkCuadroNinja.Location = New Point(533, 606)
        ChkCuadroNinja.Name = "ChkCuadroNinja"
        ChkCuadroNinja.Size = New Size(96, 19)
        ChkCuadroNinja.TabIndex = 18
        ChkCuadroNinja.Text = "Cuadro Ninja"
        ChkCuadroNinja.UseVisualStyleBackColor = True
        ' 
        ' FrmReporte
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1027, 646)
        Controls.Add(ChkCuadroNinja)
        Controls.Add(ChkClientesProyectos)
        Controls.Add(ChkClientesUsuarios)
        Controls.Add(ChkUsuariosTareas)
        Controls.Add(ChkUsuariosClientes)
        Controls.Add(ChkTareashoras)
        Controls.Add(ChkClienteshoras)
        Controls.Add(ChkUsuarioshoras)
        Controls.Add(CHKEstatusdetareas)
        Controls.Add(BtnConsultar)
        Controls.Add(BtnExcel)
        Controls.Add(DgvDatos)
        Controls.Add(LblFechaFinal)
        Controls.Add(LblFechaInicial)
        Controls.Add(DtpFechaFinal)
        Controls.Add(DtpFechaInicial)
        Name = "FrmReporte"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmReporte"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DtpFechaInicial As DateTimePicker
    Friend WithEvents DtpFechaFinal As DateTimePicker
    Friend WithEvents LblFechaInicial As Label
    Friend WithEvents LblFechaFinal As Label
    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents BtnExcel As Button
    Friend WithEvents BtnConsultar As Button
    Friend WithEvents CHKEstatusdetareas As CheckBox
    Friend WithEvents ChkUsuarioshoras As CheckBox
    Friend WithEvents ChkClienteshoras As CheckBox
    Friend WithEvents ChkTareashoras As CheckBox
    Friend WithEvents ChkUsuariosClientes As CheckBox
    Friend WithEvents ChkUsuariosTareas As CheckBox
    Friend WithEvents ChkClientesUsuarios As CheckBox
    Friend WithEvents ChkClientesProyectos As CheckBox
    Friend WithEvents ChkCuadroNinja As CheckBox
End Class
