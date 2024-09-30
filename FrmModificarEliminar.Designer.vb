<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarEliminar
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
        BtnClientes = New Button()
        BtnUsuarios = New Button()
        BtnModificar = New Button()
        BtnEliminar = New Button()
        BtnTareas = New Button()
        BtnCancelar = New Button()
        LblSeleccioneUnaOpcion = New Label()
        DgvDatos = New DataGridView()
        LblTabla = New Label()
        LblIden = New Label()
        TxtValorAModificar = New TextBox()
        LblCampo = New Label()
        TxtValorNuevo = New TextBox()
        LblModificar = New Label()
        Label2 = New Label()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnClientes
        ' 
        BtnClientes.Location = New Point(327, 56)
        BtnClientes.Name = "BtnClientes"
        BtnClientes.Size = New Size(100, 30)
        BtnClientes.TabIndex = 0
        BtnClientes.Text = "Clientes"
        BtnClientes.UseVisualStyleBackColor = True
        ' 
        ' BtnUsuarios
        ' 
        BtnUsuarios.Location = New Point(448, 56)
        BtnUsuarios.Name = "BtnUsuarios"
        BtnUsuarios.Size = New Size(100, 30)
        BtnUsuarios.TabIndex = 1
        BtnUsuarios.Text = "Usuarios"
        BtnUsuarios.UseVisualStyleBackColor = True
        ' 
        ' BtnModificar
        ' 
        BtnModificar.Enabled = False
        BtnModificar.Location = New Point(327, 452)
        BtnModificar.Name = "BtnModificar"
        BtnModificar.Size = New Size(100, 30)
        BtnModificar.TabIndex = 2
        BtnModificar.Text = "Modificar"
        BtnModificar.UseVisualStyleBackColor = True
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Enabled = False
        BtnEliminar.Location = New Point(564, 370)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(100, 30)
        BtnEliminar.TabIndex = 3
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnTareas
        ' 
        BtnTareas.Location = New Point(565, 56)
        BtnTareas.Name = "BtnTareas"
        BtnTareas.Size = New Size(100, 30)
        BtnTareas.TabIndex = 4
        BtnTareas.Text = "Tareas"
        BtnTareas.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(565, 497)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(100, 30)
        BtnCancelar.TabIndex = 5
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' LblSeleccioneUnaOpcion
        ' 
        LblSeleccioneUnaOpcion.AutoSize = True
        LblSeleccioneUnaOpcion.Location = New Point(12, 56)
        LblSeleccioneUnaOpcion.Name = "LblSeleccioneUnaOpcion"
        LblSeleccioneUnaOpcion.Size = New Size(129, 15)
        LblSeleccioneUnaOpcion.TabIndex = 6
        LblSeleccioneUnaOpcion.Text = "Seleccione Una Opcion"
        ' 
        ' DgvDatos
        ' 
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(12, 92)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(653, 272)
        DgvDatos.TabIndex = 7
        ' 
        ' LblTabla
        ' 
        LblTabla.AutoSize = True
        LblTabla.Location = New Point(12, 9)
        LblTabla.Name = "LblTabla"
        LblTabla.Size = New Size(13, 15)
        LblTabla.TabIndex = 8
        LblTabla.Text = "0"
        LblTabla.Visible = False
        ' 
        ' LblIden
        ' 
        LblIden.AutoSize = True
        LblIden.Location = New Point(141, 9)
        LblIden.Name = "LblIden"
        LblIden.Size = New Size(13, 15)
        LblIden.TabIndex = 9
        LblIden.Text = "0"
        LblIden.Visible = False
        ' 
        ' TxtValorAModificar
        ' 
        TxtValorAModificar.Enabled = False
        TxtValorAModificar.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        TxtValorAModificar.Location = New Point(5, 402)
        TxtValorAModificar.Name = "TxtValorAModificar"
        TxtValorAModificar.Size = New Size(304, 27)
        TxtValorAModificar.TabIndex = 10
        ' 
        ' LblCampo
        ' 
        LblCampo.AutoSize = True
        LblCampo.Location = New Point(327, 9)
        LblCampo.Name = "LblCampo"
        LblCampo.Size = New Size(13, 15)
        LblCampo.TabIndex = 11
        LblCampo.Text = "0"
        LblCampo.Visible = False
        ' 
        ' TxtValorNuevo
        ' 
        TxtValorNuevo.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        TxtValorNuevo.Location = New Point(5, 455)
        TxtValorNuevo.Name = "TxtValorNuevo"
        TxtValorNuevo.Size = New Size(304, 27)
        TxtValorNuevo.TabIndex = 12
        ' 
        ' LblModificar
        ' 
        LblModificar.AutoSize = True
        LblModificar.Location = New Point(5, 385)
        LblModificar.Name = "LblModificar"
        LblModificar.Size = New Size(83, 15)
        LblModificar.TabIndex = 13
        LblModificar.Text = "Modificar esto"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(5, 437)
        Label2.Name = "Label2"
        Label2.Size = New Size(50, 15)
        Label2.TabIndex = 14
        Label2.Text = "Por esto"
        ' 
        ' FrmModificarEliminar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(674, 540)
        Controls.Add(Label2)
        Controls.Add(LblModificar)
        Controls.Add(TxtValorNuevo)
        Controls.Add(LblCampo)
        Controls.Add(TxtValorAModificar)
        Controls.Add(LblIden)
        Controls.Add(LblTabla)
        Controls.Add(DgvDatos)
        Controls.Add(LblSeleccioneUnaOpcion)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnTareas)
        Controls.Add(BtnEliminar)
        Controls.Add(BtnModificar)
        Controls.Add(BtnUsuarios)
        Controls.Add(BtnClientes)
        Name = "FrmModificarEliminar"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmModificarEliminar"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnClientes As Button
    Friend WithEvents BtnUsuarios As Button
    Friend WithEvents BtnModificar As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnTareas As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents LblSeleccioneUnaOpcion As Label
    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents LblTabla As Label
    Friend WithEvents LblIden As Label
    Friend WithEvents TxtValorAModificar As TextBox
    Friend WithEvents LblCampo As Label
    Friend WithEvents TxtValorNuevo As TextBox
    Friend WithEvents LblModificar As Label
    Friend WithEvents Label2 As Label
End Class
