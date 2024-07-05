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
        CmbUsuario = New ComboBox()
        LblUsuario = New Label()
        BtnExcel = New Button()
        BtnConsultar = New Button()
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
        DgvDatos.Size = New Size(738, 295)
        DgvDatos.TabIndex = 4
        ' 
        ' CmbUsuario
        ' 
        CmbUsuario.FormattingEnabled = True
        CmbUsuario.Location = New Point(318, 56)
        CmbUsuario.Name = "CmbUsuario"
        CmbUsuario.Size = New Size(161, 23)
        CmbUsuario.TabIndex = 5
        ' 
        ' LblUsuario
        ' 
        LblUsuario.AutoSize = True
        LblUsuario.Location = New Point(318, 25)
        LblUsuario.Name = "LblUsuario"
        LblUsuario.Size = New Size(47, 15)
        LblUsuario.TabIndex = 6
        LblUsuario.Text = "Usuario"
        ' 
        ' BtnExcel
        ' 
        BtnExcel.Location = New Point(713, 396)
        BtnExcel.Name = "BtnExcel"
        BtnExcel.Size = New Size(75, 23)
        BtnExcel.TabIndex = 7
        BtnExcel.Text = "Xls"
        BtnExcel.UseVisualStyleBackColor = True
        ' 
        ' BtnConsultar
        ' 
        BtnConsultar.Location = New Point(501, 55)
        BtnConsultar.Name = "BtnConsultar"
        BtnConsultar.Size = New Size(75, 23)
        BtnConsultar.TabIndex = 8
        BtnConsultar.Text = "Consultar"
        BtnConsultar.UseVisualStyleBackColor = True
        ' 
        ' FrmReporte
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(812, 451)
        Controls.Add(BtnConsultar)
        Controls.Add(BtnExcel)
        Controls.Add(LblUsuario)
        Controls.Add(CmbUsuario)
        Controls.Add(DgvDatos)
        Controls.Add(LblFechaFinal)
        Controls.Add(LblFechaInicial)
        Controls.Add(DtpFechaFinal)
        Controls.Add(DtpFechaInicial)
        Name = "FrmReporte"
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
    Friend WithEvents CmbUsuario As ComboBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents BtnExcel As Button
    Friend WithEvents BtnConsultar As Button
End Class
