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
        LblServer = New Label()
        TxtServer = New TextBox()
        TxtUser = New TextBox()
        LblUser = New Label()
        TxtPass = New TextBox()
        LblPass = New Label()
        TxtDatabase = New TextBox()
        LblDatabase = New Label()
        TxtPort = New TextBox()
        LblPort = New Label()
        TxtSecurityInfo = New TextBox()
        LblPersisSecurityInfo = New Label()
        BtnActualizar = New Button()
        BtnProbarConexion = New Button()
        SuspendLayout()
        ' 
        ' LblServer
        ' 
        LblServer.AutoSize = True
        LblServer.Location = New Point(13, 44)
        LblServer.Name = "LblServer"
        LblServer.Size = New Size(39, 15)
        LblServer.TabIndex = 0
        LblServer.Text = "Server"
        ' 
        ' TxtServer
        ' 
        TxtServer.Location = New Point(125, 36)
        TxtServer.Name = "TxtServer"
        TxtServer.Size = New Size(214, 23)
        TxtServer.TabIndex = 1
        ' 
        ' TxtUser
        ' 
        TxtUser.Location = New Point(125, 70)
        TxtUser.Name = "TxtUser"
        TxtUser.Size = New Size(124, 23)
        TxtUser.TabIndex = 3
        ' 
        ' LblUser
        ' 
        LblUser.AutoSize = True
        LblUser.Location = New Point(13, 73)
        LblUser.Name = "LblUser"
        LblUser.Size = New Size(30, 15)
        LblUser.TabIndex = 2
        LblUser.Text = "User"
        ' 
        ' TxtPass
        ' 
        TxtPass.Location = New Point(125, 99)
        TxtPass.Name = "TxtPass"
        TxtPass.PasswordChar = "*"c
        TxtPass.Size = New Size(84, 23)
        TxtPass.TabIndex = 5
        ' 
        ' LblPass
        ' 
        LblPass.AutoSize = True
        LblPass.Location = New Point(13, 102)
        LblPass.Name = "LblPass"
        LblPass.Size = New Size(57, 15)
        LblPass.TabIndex = 4
        LblPass.Text = "Password"
        ' 
        ' TxtDatabase
        ' 
        TxtDatabase.Location = New Point(125, 128)
        TxtDatabase.Name = "TxtDatabase"
        TxtDatabase.Size = New Size(84, 23)
        TxtDatabase.TabIndex = 7
        ' 
        ' LblDatabase
        ' 
        LblDatabase.AutoSize = True
        LblDatabase.Location = New Point(12, 131)
        LblDatabase.Name = "LblDatabase"
        LblDatabase.Size = New Size(55, 15)
        LblDatabase.TabIndex = 6
        LblDatabase.Text = "Database"
        ' 
        ' TxtPort
        ' 
        TxtPort.Location = New Point(125, 157)
        TxtPort.Name = "TxtPort"
        TxtPort.Size = New Size(84, 23)
        TxtPort.TabIndex = 9
        ' 
        ' LblPort
        ' 
        LblPort.AutoSize = True
        LblPort.Location = New Point(14, 160)
        LblPort.Name = "LblPort"
        LblPort.Size = New Size(29, 15)
        LblPort.TabIndex = 8
        LblPort.Text = "Port"
        ' 
        ' TxtSecurityInfo
        ' 
        TxtSecurityInfo.Location = New Point(125, 186)
        TxtSecurityInfo.Name = "TxtSecurityInfo"
        TxtSecurityInfo.Size = New Size(84, 23)
        TxtSecurityInfo.TabIndex = 11
        ' 
        ' LblPersisSecurityInfo
        ' 
        LblPersisSecurityInfo.AutoSize = True
        LblPersisSecurityInfo.Location = New Point(13, 189)
        LblPersisSecurityInfo.Name = "LblPersisSecurityInfo"
        LblPersisSecurityInfo.Size = New Size(107, 15)
        LblPersisSecurityInfo.TabIndex = 10
        LblPersisSecurityInfo.Text = "persistSecurityInfo "
        ' 
        ' BtnActualizar
        ' 
        BtnActualizar.Location = New Point(14, 236)
        BtnActualizar.Name = "BtnActualizar"
        BtnActualizar.Size = New Size(92, 23)
        BtnActualizar.TabIndex = 12
        BtnActualizar.Text = "Actualizar"
        BtnActualizar.UseVisualStyleBackColor = True
        ' 
        ' BtnProbarConexion
        ' 
        BtnProbarConexion.Location = New Point(278, 236)
        BtnProbarConexion.Name = "BtnProbarConexion"
        BtnProbarConexion.Size = New Size(92, 23)
        BtnProbarConexion.TabIndex = 13
        BtnProbarConexion.Text = "Conexion"
        BtnProbarConexion.UseVisualStyleBackColor = True
        ' 
        ' FrmConfiguracion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(382, 271)
        Controls.Add(BtnProbarConexion)
        Controls.Add(BtnActualizar)
        Controls.Add(TxtSecurityInfo)
        Controls.Add(LblPersisSecurityInfo)
        Controls.Add(TxtPort)
        Controls.Add(LblPort)
        Controls.Add(TxtDatabase)
        Controls.Add(LblDatabase)
        Controls.Add(TxtPass)
        Controls.Add(LblPass)
        Controls.Add(TxtUser)
        Controls.Add(LblUser)
        Controls.Add(TxtServer)
        Controls.Add(LblServer)
        Name = "FrmConfiguracion"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Configuracion"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblServer As Label
    Friend WithEvents TxtServer As TextBox
    Friend WithEvents TxtUser As TextBox
    Friend WithEvents LblUser As Label
    Friend WithEvents TxtPass As TextBox
    Friend WithEvents LblPass As Label
    Friend WithEvents TxtDatabase As TextBox
    Friend WithEvents LblDatabase As Label
    Friend WithEvents TxtPort As TextBox
    Friend WithEvents LblPort As Label
    Friend WithEvents TxtSecurityInfo As TextBox
    Friend WithEvents LblPersisSecurityInfo As Label
    Friend WithEvents BtnActualizar As Button
    Friend WithEvents BtnProbarConexion As Button
End Class
