<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracion
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
        DataGridView1 = New DataGridView()
        BtnMostrarDatos = New Button()
        ComboBox1 = New ComboBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(11, 108)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(810, 476)
        DataGridView1.TabIndex = 0
        ' 
        ' BtnMostrarDatos
        ' 
        BtnMostrarDatos.Location = New Point(189, 78)
        BtnMostrarDatos.Name = "BtnMostrarDatos"
        BtnMostrarDatos.Size = New Size(75, 23)
        BtnMostrarDatos.TabIndex = 1
        BtnMostrarDatos.Text = "Mostrar"
        BtnMostrarDatos.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(12, 79)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(171, 23)
        ComboBox1.TabIndex = 2
        ' 
        ' FrmConfiguracion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(833, 629)
        Controls.Add(ComboBox1)
        Controls.Add(BtnMostrarDatos)
        Controls.Add(DataGridView1)
        Name = "FrmConfiguracion"
        Text = "FrmConfiguracion"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnMostrarDatos As Button
    Friend WithEvents ComboBox1 As ComboBox
End Class
