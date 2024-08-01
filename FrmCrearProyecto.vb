Public Class FrmCrearProyecto

    Public CadenaDeConexion As String = ""

    Private Sub FrmCrearProyecto_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub RbProyectoExistente_CheckedChanged(sender As Object, e As EventArgs) Handles RbProyectoExistente.CheckedChanged
        If RbProyectoExistente.Checked = True Then
            CmbProyectoExistente.Enabled = True
            CargarProyecto()
            TxtNuevoProyecto.Enabled = False
            TxtNuevoProyecto.Text = ""

        End If
    End Sub

    Private Sub RbNuevoProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles RbNuevoProyecto.CheckedChanged
        If RbNuevoProyecto.Checked = True Then
            CmbProyectoExistente.Items.Clear()
            DgvTareas.Rows.Clear()
            CmbProyectoExistente.Text = ""
            CmbProyectoExistente.Enabled = False
            TxtNuevoProyecto.Enabled = True




        End If
    End Sub


    Private Sub CargarProyecto()
        Dim proyectos As String() = Conexion.ObtenerProyectos(CadenaDeConexion)
        CmbProyectoExistente.Items.Clear()
        For Each proyecto As String In proyectos
            CmbProyectoExistente.Items.Add(proyecto)
        Next
    End Sub
    Private Sub CargarTareas(ByVal Proyecto As String)

        Dim tareas As String() = Conexion.ObtenertareasPorProyecto(Proyecto, CadenaDeConexion)
        DgvTareas.Rows.Clear()

        For Each tarea As String In tareas
            DgvTareas.Rows.Add(tarea)
        Next
    End Sub

    Private Sub CmbProyectoExistente_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbProyectoExistente.SelectedValueChanged
        CargarTareas(CmbProyectoExistente.Text)
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        If Len(CmbProyectoExistente.Text) > 0 Then

            If Len(TxtNuevaTarea.Text) > 0 Then

                DgvTareas.Rows.Add(TxtNuevaTarea.Text)
                TxtNuevaTarea.Text = ""

            End If

        Else

            If Len(TxtNuevaTarea.Text) > 0 Then

                DgvTareas.Rows.Add(TxtNuevaTarea.Text)
                TxtNuevaTarea.Text = ""

            End If


        End If



    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        If DgvTareas.RowCount > 0 Then
            InsertarProyecto()
        Else
            MsgBox("No agrego tareas aun")
        End If


    End Sub


    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub

    Private Sub InsertarProyecto()
        If RbProyectoExistente.Checked = True Then

            If Len(CmbProyectoExistente.Text) > 0 Then
                For Each drw As DataGridViewRow In DgvTareas.Rows
                    Conexion.InsertarProyectoYTarea(CadenaDeConexion, CmbProyectoExistente.Text, drw.Cells("Tareas").Value)
                Next
            Else
                MsgBox("Seleccione un proyecto")
            End If

        Else
            'Si el otro RB esta seleccionado
            If Len(TxtNuevoProyecto.Text) > 0 Then

                For Each drw As DataGridViewRow In DgvTareas.Rows
                    Conexion.InsertarProyectoYTarea(CadenaDeConexion, TxtNuevoProyecto.Text, drw.Cells("Tareas").Value)
                Next
            Else
                MsgBox("Cree el Proyecto")

            End If

        End If

        DgvTareas.Rows.Clear()


        TxtNuevoProyecto.Text = ""

        RbNuevoProyecto.Enabled = True
        RbProyectoExistente.Enabled = True


    End Sub

    Private Sub FrmCrearProyecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub
End Class