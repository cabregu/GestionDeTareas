Public Class FrmRealizarTarea
    Public CadenaDeConexion As String = ""

    Private Sub FrmRealizarTarea_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub FrmRealizarTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarConCodigos(CadenaDeConexion, LblUsuario.Text)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        TxtCliente.Text = ""
        TxtProyecto.Text = ""
        TxtTarea.Text = ""
        TxtNiveldePrioridad.Text = ""
        TxtFechaLimite.Text = ""
        TxtComentario.Text = ""
        TxtEstado.Text = ""
        TxtFechaInicio.Text = ""



    End Sub

    Private Sub CmbCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCodigo.SelectedValueChanged
        If CmbCodigo.SelectedIndex <> -1 Then
            CargarTareasPorCodigo()
        End If

    End Sub




    Public Sub LlenarConCodigos(ByVal CadenaConexion As String, ByVal Usuario As String)
        Dim dt As New DataTable
        dt = Conexion.ObtenerCodigoClienteTareaPorUsuario(CadenaConexion, Usuario)
        CargarComboBox(CmbCodigo, dt)
    End Sub


    Public Sub CargarComboBox(ByVal comboBox As ComboBox, ByVal dt As DataTable)
        comboBox.DisplayMember = "DisplayText"
        comboBox.ValueMember = "codigo"

        Dim dtDisplay As New DataTable()
        dtDisplay.Columns.Add("codigo", GetType(String))
        dtDisplay.Columns.Add("DisplayText", GetType(String))

        For Each row As DataRow In dt.Rows
            ' Ajustar la cantidad de espacios entre los campos
            Dim displayText As String = $"{row("codigo")}  {row("cliente")}   {row("tarea")}"
            dtDisplay.Rows.Add(row("codigo"), displayText)
        Next

        comboBox.DataSource = dtDisplay

        ' Ajustar el ancho del ComboBox para que se ajuste al texto más largo
        AjustarAnchoComboBox(comboBox)

        comboBox.SelectedIndex = -1

    End Sub

    Private Sub AjustarAnchoComboBox(ByVal comboBox As ComboBox)
        ' Medir el texto más largo del ComboBox
        Dim maxWidth As Integer = 0

        For Each item As Object In comboBox.Items
            Dim text As String = DirectCast(DirectCast(item, DataRowView)("DisplayText"), String)
            Dim textSize As Size = TextRenderer.MeasureText(comboBox.CreateGraphics(), text, comboBox.Font)
            If textSize.Width > maxWidth Then
                maxWidth = textSize.Width
            End If
        Next

        comboBox.DropDownWidth = maxWidth + 20
    End Sub

    Private Sub CargarTareasPorCodigo()

        Dim codigoSeleccionado As String = CmbCodigo.Text
        If Not String.IsNullOrEmpty(codigoSeleccionado) Then

            Dim tareas As List(Of Tarea) = Conexion.ObtenertareasPendientesdeUsuario(CadenaDeConexion, codigoSeleccionado)


            If tareas.Count > 0 Then
                Dim tarea As Tarea = tareas(0)
                TxtCliente.Text = tarea.cliente
                TxtProyecto.Text = tarea.proyecto
                TxtTarea.Text = tarea.tarea
                TxtNiveldePrioridad.Text = tarea.niveldeprioridad
                TxtFechaLimite.Text = tarea.fechalimite
                TxtComentario.Text = tarea.comentario
                TxtEstado.Text = tarea.estado
                TxtFechaInicio.Text = tarea.fechadeinicio

            End If
        Else

        End If
    End Sub

    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles BtnIniciar.Click
        Dim FechaHoraServer As DateTime = Conexion.ObtenerFechaHoraServidor(CadenaDeConexion)
        If CmbCodigo.SelectedValue IsNot Nothing Then
            Dim codigoSeleccionado As String = CType(CmbCodigo.SelectedValue, String)
            If Conexion.ActualizarFechaInicioYCalcularPorCodigo(CadenaDeConexion, codigoSeleccionado, FechaHoraServer) = True Then
                CargarTareasPorCodigo()
            End If
        Else
            MessageBox.Show("Por favor, seleccione un código.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub BtnRetomar_Click(sender As Object, e As EventArgs) Handles BtnRetomar.Click
        Dim FechaHoraServer As DateTime = Conexion.ObtenerFechaHoraServidor(CadenaDeConexion)
        Dim codigoSeleccionado As String = CType(CmbCodigo.SelectedValue, String)
        Conexion.ActualizarFechaYEstado(CadenaDeConexion, codigoSeleccionado, FechaHoraServer, "Ejecutando")
        CargarTareasPorCodigo()

    End Sub

    Private Sub BtnPausar_Click(sender As Object, e As EventArgs) Handles BtnPausar.Click
        PausarTareas()
        CargarTareasPorCodigo()
    End Sub

    Private Sub FtnFinalizar_Click(sender As Object, e As EventArgs) Handles BtnFinalizar.Click
        FinalizarTarea()
    End Sub

    Private Sub TxtEstado_TextChanged(sender As Object, e As EventArgs) Handles TxtEstado.TextChanged

        If TxtEstado.Text = "Asignada" Then
            BtnIniciar.Enabled = True
        Else
            BtnIniciar.Enabled = False
        End If

        If TxtEstado.Text = "Pausada" Then
            BtnRetomar.Enabled = True
            BtnFinalizar.Enabled = False
            BtnPausar.Enabled = False
        End If

        If TxtEstado.Text = "Ejecutando" Then
            BtnPausar.Enabled = True
            BtnFinalizar.Enabled = True
            BtnRetomar.Enabled = False

        End If
        CargarTareasPorCodigo()
    End Sub



    Private Sub PausarTareas()

        Dim FechaHoraServer As DateTime = Conexion.ObtenerFechaHoraServidor(CadenaDeConexion)
        Dim codigoSeleccionado As String = CType(CmbCodigo.SelectedValue, String)
        'Tiempo que figura actualmente en tabla kanbas para sumarlo a lo que le pase mas adelante
        Dim TiempoObtenido As String = Conexion.ObtenerTiempo(CadenaDeConexion, codigoSeleccionado)

        'tiempo que paso en el server desde que obtube la fechaparacalcular de la tabla kanbas
        'y la fechayhora del servidor que estoy pasando por parametro ahora mismo
        Dim TiempoTranscurridoDesdeFechaParaCalcular As String = Conexion.ObtenerYCalcularTiempoTranscurrido(CadenaDeConexion, codigoSeleccionado, FechaHoraServer)

        'Sumar ambos tiempos para obtener el tiempo neto de trabajo
        'entre lo que ya esta en kanbas y lo que se sumo al momento de dar pausa
        Dim TiempoAcumulado As String = Conexion.SumarTiempos(TiempoObtenido, TiempoTranscurridoDesdeFechaParaCalcular)

        'convertirlo para pasarlo y podes actualizar el nuevo tiempo
        Dim NuevoTiempo As TimeSpan = TimeSpan.Parse(TiempoAcumulado)

        'actualizacion de fecha y estado no sirve la fecha pero es para no crear otra funcion ya que
        'al retomar la tarea vuelve a actulizar ese tiempo para que calcule desde que retome la tarea y no desde que coloque
        'la pausa lo que va controlar el doble clic es la anulacion de los botones segun su estado
        Conexion.ActualizarTiempo(CadenaDeConexion, codigoSeleccionado, NuevoTiempo)

        Conexion.ActualizarFechaYEstado(CadenaDeConexion, codigoSeleccionado, FechaHoraServer, "Pausada")

    End Sub

    Private Sub FinalizarTarea()

        If Len(TxtComentarioFinal.Text) < 1 Then

            MsgBox("Debe dejar un comentario final")

        Else


            Dim FechaHoraServer As DateTime = Conexion.ObtenerFechaHoraServidor(CadenaDeConexion)
            Dim codigoSeleccionado As String = CType(CmbCodigo.SelectedValue, String)
            'Tiempo que figura actualmente en tabla kanbas para sumarlo a lo que le pase mas adelante
            Dim TiempoObtenido As String = Conexion.ObtenerTiempo(CadenaDeConexion, codigoSeleccionado)

            'tiempo que paso en el server desde que obtube la fechaparacalcular de la tabla kanbas
            'y la fechayhora del servidor que estoy pasando por parametro ahora mismo
            Dim TiempoTranscurridoDesdeFechaParaCalcular As String = Conexion.ObtenerYCalcularTiempoTranscurrido(CadenaDeConexion, codigoSeleccionado, FechaHoraServer)

            'Sumar ambos tiempos para obtener el tiempo neto de trabajo
            'entre lo que ya esta en kanbas y lo que se sumo al momento de dar pausa
            Dim TiempoAcumulado As String = Conexion.SumarTiempos(TiempoObtenido, TiempoTranscurridoDesdeFechaParaCalcular)

            'convertirlo para pasarlo y podes actualizar el nuevo tiempo
            Dim NuevoTiempo As TimeSpan = TimeSpan.Parse(TiempoAcumulado)

            'actualizacion de fecha y estado no sirve la fecha pero es para no crear otra funcion ya que
            'al retomar la tarea vuelve a actulizar ese tiempo para que calcule desde que retome la tarea y no desde que coloque
            'la pausa lo que va controlar el doble clic es la anulacion de los botones segun su estado
            Conexion.ActualizarTiempo(CadenaDeConexion, codigoSeleccionado, NuevoTiempo)



            If Conexion.ActualizarEstadoKanbasFinalizada(CadenaDeConexion, codigoSeleccionado, "Finalizada", TxtComentarioFinal.Text, FechaHoraServer) = True Then

                CmbCodigo.Text = ""
                TxtCliente.Text = ""
                TxtProyecto.Text = ""
                TxtTarea.Text = ""
                TxtNiveldePrioridad.Text = ""
                TxtFechaLimite.Text = ""
                TxtComentario.Text = ""
                TxtEstado.Text = ""
                TxtFechaInicio.Text = ""
                TxtComentarioFinal.Text = ""
                LlenarConCodigos(CadenaDeConexion, LblUsuario.Text)

                BtnFinalizar.Enabled = False
                BtnPausar.Enabled = False

            End If

        End If


    End Sub

    Private Sub TmrChequear_Tick(sender As Object, e As EventArgs) Handles TmrChequear.Tick

    End Sub
End Class