Imports System.IO
Imports ClosedXML.Excel

Public Class FrmReporte
    Dim Dt As New DataTable

    Public CadenaDeConexion As String = ""
    Private Sub FrmReporte_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        Dt = Conexion.ObtenerDatosReporte1(CadenaDeConexion, DtpFechaInicial.Value, DtpFechaFinal.Value)
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt

        ChkClienteshoras.Enabled = True
        ChkClientesProyectos.Enabled = True
        ChkClientesUsuarios.Enabled = True
        ChkCuadroNinja.Enabled = True
        CHKEstatusdetareas.Enabled = True
        ChkTareashoras.Enabled = True
        ChkUsuariosClientes.Enabled = True
        ChkUsuarioshoras.Enabled = True
        ChkUsuariosTareas.Enabled = True
        CHKEstatusdetareas.CheckState = CheckState.Checked


    End Sub

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub


    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click

        Dim dataTables As New Dictionary(Of String, DataTable)

        If CHKEstatusdetareas.Checked = True Then
            dataTables.Add("Estatus de tareas", Dt)
        End If

        If ChkUsuarioshoras.Checked = True Then
            Dim DtUsuH As New DataTable
            DtUsuH = UsuariosHoras(Dt)

            dataTables.Add("Usuario horas", DtUsuH)
        End If

        If ChkClienteshoras.Checked = True Then
            Dim DtCliH As New DataTable
            DtCliH = ClientesHoras(Dt)
            dataTables.Add("Clientes horas", DtCliH)

        End If

        If ChkTareashoras.Checked = True Then
            Dim DtTareaH As New DataTable
            DtTareaH = TareasHoras(Dt)
            dataTables.Add("Tareas horas", DtTareaH)
        End If

        If ChkUsuariosClientes.Checked = True Then
            Dim DtUsuCliH As New DataTable
            DtUsuCliH = UsuarioClienteHoras(Dt)
            dataTables.Add("Usuarios-Clientes", DtUsuCliH)
        End If

        If ChkUsuariosTareas.Checked = True Then
            Dim DtUsuTareasHora As New DataTable
            DtUsuTareasHora = UsuarioTareaHoras(Dt)
            dataTables.Add("Usuarios-Tareas", DtUsuTareasHora)
        End If

        If ChkClientesProyectos.Checked = True Then
            Dim DtCliPro As New DataTable
            DtCliPro = ClienteProyectoHoras(Dt)
            dataTables.Add("Clientes-Proyectos", DtCliPro)
        End If

        If ChkClientesUsuarios.Checked = True Then
            Dim DtCliUsuH As New DataTable
            DtCliUsuH = ClienteUsuarioHoras(Dt)
            dataTables.Add("Clientes-Usuarios", DtCliUsuH)

        End If


        If ChkCuadroNinja.Checked = True Then

            Dim DtCuenta As New DataTable
            DtCuenta = ContarEstados(Dt)

            dataTables.Add("Cuadro Ninja", DtCuenta)

        End If

        CrearReporte(dataTables)


    End Sub

    Private Sub CrearReporte(ByVal dataTables As Dictionary(Of String, DataTable))
        If dataTables IsNot Nothing AndAlso dataTables.Count > 0 Then
            Using workbook As New XLWorkbook()

                For Each kvp As KeyValuePair(Of String, DataTable) In dataTables
                    Dim sheetName As String = kvp.Key
                    Dim dt As DataTable = kvp.Value

                    Dim worksheet = workbook.Worksheets.Add(sheetName)

                    ' Agregar encabezados
                    For i As Integer = 1 To dt.Columns.Count
                        Dim cell = worksheet.Cell(1, i)
                        cell.Value = dt.Columns(i - 1).ColumnName
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center ' Justificar encabezados
                    Next

                    ' Agregar filas
                    For i As Integer = 0 To dt.Rows.Count - 1
                        For j As Integer = 0 To dt.Columns.Count - 1
                            Dim cellValue As Object = dt.Rows(i)(j)
                            Dim cell = worksheet.Cell(i + 2, j + 1)
                            cell.Value = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left ' Justificar texto
                        Next
                    Next

                    ' Ajustar tamaño de las columnas automáticamente
                    worksheet.Columns().AdjustToContents()

                    ' Verificar si la hoja es "Estatus de tareas" y aplicar formato
                    If sheetName = "Estatus de tareas" Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Dim statusValue As String = If(dt.Rows(i)("Status") IsNot DBNull.Value, dt.Rows(i)("Status").ToString(), String.Empty)
                            If statusValue = "CON RETRASO" Then
                                Dim row = worksheet.Row(i + 2)
                                row.Style.Font.FontColor = XLColor.Red
                                row.Style.Font.Bold = True
                            Else
                                Dim row = worksheet.Row(i + 2)
                                row.Style.Font.FontColor = XLColor.Green
                                row.Style.Font.Bold = True


                            End If
                        Next
                    End If

                Next

                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "Excel Files|*.xlsx"
                saveFileDialog.Title = "Guardar Reporte en Excel"
                saveFileDialog.FileName = "Reporte_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    workbook.SaveAs(saveFileDialog.FileName)
                    MessageBox.Show("Reporte guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Else
            MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    'Private Shared Function UsuariosHoras(ByVal DTable As DataTable) As DataTable
    '    Dim DtUsuHoras As New DataTable()
    '    DtUsuHoras.Columns.Add("USUARIOS", GetType(String))
    '    DtUsuHoras.Columns.Add("HORAS", GetType(String))

    '    Dim userTimeTotals As New Dictionary(Of String, TimeSpan)()

    '    For Each row As DataRow In DTable.Rows
    '        Dim user As String = row("usuario").ToString()
    '        Dim timeStr As String = row("tiempo").ToString()

    '        Dim timeSpent As TimeSpan
    '        If TimeSpan.TryParse(timeStr, timeSpent) Then
    '            If userTimeTotals.ContainsKey(user) Then
    '                userTimeTotals(user) = userTimeTotals(user).Add(timeSpent)
    '            Else
    '                userTimeTotals(user) = timeSpent
    '            End If
    '        End If
    '    Next

    '    Dim totalGlobal As New TimeSpan()
    '    For Each kvp In userTimeTotals
    '        DtUsuHoras.Rows.Add(kvp.Key, kvp.Value.ToString())
    '        totalGlobal = totalGlobal.Add(kvp.Value)
    '    Next

    '    ' Fila en blanco
    '    DtUsuHoras.Rows.Add()

    '    DtUsuHoras.Rows.Add("TOTAL", totalGlobal.ToString())
    '    Return DtUsuHoras
    'End Function

    'Private Shared Function ClientesHoras(ByVal DTable As DataTable) As DataTable
    '    Dim DtCliHoras As New DataTable()
    '    DtCliHoras.Columns.Add("CLIENTE", GetType(String))
    '    DtCliHoras.Columns.Add("HORAS", GetType(String))

    '    Dim clientTimeTotals As New Dictionary(Of String, TimeSpan)()

    '    For Each row As DataRow In DTable.Rows
    '        Dim client As String = row("cliente").ToString()
    '        Dim timeStr As String = row("tiempo").ToString()

    '        Dim timeSpent As TimeSpan
    '        If TimeSpan.TryParse(timeStr, timeSpent) Then
    '            If clientTimeTotals.ContainsKey(client) Then
    '                clientTimeTotals(client) = clientTimeTotals(client).Add(timeSpent)
    '            Else
    '                clientTimeTotals(client) = timeSpent
    '            End If
    '        End If
    '    Next

    '    Dim totalGlobal As New TimeSpan()
    '    For Each kvp In clientTimeTotals
    '        DtCliHoras.Rows.Add(kvp.Key, kvp.Value.ToString())
    '        totalGlobal = totalGlobal.Add(kvp.Value)
    '    Next

    '    ' Fila en blanco
    '    DtCliHoras.Rows.Add()

    '    DtCliHoras.Rows.Add("TOTAL", totalGlobal.ToString())
    '    Return DtCliHoras
    'End Function

    'Private Shared Function TareasHoras(ByVal DTable As DataTable) As DataTable
    '    Dim DtTareasHoras As New DataTable()
    '    DtTareasHoras.Columns.Add("TAREA", GetType(String))
    '    DtTareasHoras.Columns.Add("HORAS", GetType(String))

    '    Dim taskTimeTotals As New Dictionary(Of String, TimeSpan)()

    '    For Each row As DataRow In DTable.Rows
    '        Dim task As String = row("tarea").ToString()
    '        Dim timeStr As String = row("tiempo").ToString()

    '        Dim timeSpent As TimeSpan
    '        If TimeSpan.TryParse(timeStr, timeSpent) Then
    '            If taskTimeTotals.ContainsKey(task) Then
    '                taskTimeTotals(task) = taskTimeTotals(task).Add(timeSpent)
    '            Else
    '                taskTimeTotals(task) = timeSpent
    '            End If
    '        End If
    '    Next

    '    Dim totalGlobal As New TimeSpan()
    '    For Each kvp In taskTimeTotals
    '        DtTareasHoras.Rows.Add(kvp.Key, kvp.Value.ToString())
    '        totalGlobal = totalGlobal.Add(kvp.Value)
    '    Next

    '    ' Fila en blanco
    '    DtTareasHoras.Rows.Add()

    '    DtTareasHoras.Rows.Add("TOTAL", totalGlobal.ToString())
    '    Return DtTareasHoras
    'End Function

    'Private Shared Function UsuarioClienteHoras(ByVal DTable As DataTable) As DataTable
    '    Dim DtUsuCliHoras As New DataTable()
    '    DtUsuCliHoras.Columns.Add("USUARIO", GetType(String))
    '    DtUsuCliHoras.Columns.Add("CLIENTE", GetType(String))
    '    DtUsuCliHoras.Columns.Add("HORAS", GetType(String))

    '    Dim userClientTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

    '    For Each row As DataRow In DTable.Rows
    '        Dim user As String = row("usuario").ToString()
    '        Dim client As String = row("cliente").ToString()
    '        Dim timeStr As String = row("tiempo").ToString()

    '        Dim timeSpent As TimeSpan
    '        If TimeSpan.TryParse(timeStr, timeSpent) Then
    '            If Not userClientTimeTotals.ContainsKey(user) Then
    '                userClientTimeTotals(user) = New Dictionary(Of String, TimeSpan)()
    '            End If

    '            If userClientTimeTotals(user).ContainsKey(client) Then
    '                userClientTimeTotals(user)(client) = userClientTimeTotals(user)(client).Add(timeSpent)
    '            Else
    '                userClientTimeTotals(user)(client) = timeSpent
    '            End If
    '        End If
    '    Next

    '    For Each userKvp In userClientTimeTotals
    '        Dim totalUser As New TimeSpan()
    '        For Each clientKvp In userKvp.Value
    '            DtUsuCliHoras.Rows.Add(userKvp.Key, clientKvp.Key, clientKvp.Value.ToString())
    '            totalUser = totalUser.Add(clientKvp.Value)
    '        Next
    '        ' Fila en blanco
    '        DtUsuCliHoras.Rows.Add()
    '        DtUsuCliHoras.Rows.Add(userKvp.Key, "TOTAL", totalUser.ToString())
    '    Next

    '    Return DtUsuCliHoras
    'End Function

    'Private Shared Function UsuarioTareaHoras(ByVal DTable As DataTable) As DataTable
    '    Dim DtUsuTareaHoras As New DataTable()
    '    DtUsuTareaHoras.Columns.Add("USUARIO", GetType(String))
    '    DtUsuTareaHoras.Columns.Add("TAREA", GetType(String))
    '    DtUsuTareaHoras.Columns.Add("HORAS", GetType(String))

    '    Dim userTaskTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

    '    For Each row As DataRow In DTable.Rows
    '        Dim user As String = row("usuario").ToString()
    '        Dim task As String = row("tarea").ToString()
    '        Dim timeStr As String = row("tiempo").ToString()

    '        Dim timeSpent As TimeSpan
    '        If TimeSpan.TryParse(timeStr, timeSpent) Then
    '            If Not userTaskTimeTotals.ContainsKey(user) Then
    '                userTaskTimeTotals(user) = New Dictionary(Of String, TimeSpan)()
    '            End If

    '            If userTaskTimeTotals(user).ContainsKey(task) Then
    '                userTaskTimeTotals(user)(task) = userTaskTimeTotals(user)(task).Add(timeSpent)
    '            Else
    '                userTaskTimeTotals(user)(task) = timeSpent
    '            End If
    '        End If
    '    Next

    '    For Each userKvp In userTaskTimeTotals
    '        Dim totalUser As New TimeSpan()
    '        For Each taskKvp In userKvp.Value
    '            DtUsuTareaHoras.Rows.Add(userKvp.Key, taskKvp.Key, taskKvp.Value.ToString())
    '            totalUser = totalUser.Add(taskKvp.Value)
    '        Next
    '        ' Fila en blanco
    '        DtUsuTareaHoras.Rows.Add()
    '        DtUsuTareaHoras.Rows.Add(userKvp.Key, "TOTAL", totalUser.ToString())
    '    Next

    '    Return DtUsuTareaHoras
    'End Function

    'Private Shared Function ClienteProyectoHoras(ByVal DTable As DataTable) As DataTable
    '    Dim DtCliProyHoras As New DataTable()
    '    DtCliProyHoras.Columns.Add("CLIENTE", GetType(String))
    '    DtCliProyHoras.Columns.Add("PROYECTO", GetType(String))
    '    DtCliProyHoras.Columns.Add("HORAS", GetType(String))

    '    Dim clientProjectTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

    '    For Each row As DataRow In DTable.Rows
    '        Dim client As String = row("cliente").ToString()
    '        Dim project As String = row("proyecto").ToString()
    '        Dim timeStr As String = row("tiempo").ToString()

    '        Dim timeSpent As TimeSpan
    '        If TimeSpan.TryParse(timeStr, timeSpent) Then
    '            If Not clientProjectTimeTotals.ContainsKey(client) Then
    '                clientProjectTimeTotals(client) = New Dictionary(Of String, TimeSpan)()
    '            End If

    '            If clientProjectTimeTotals(client).ContainsKey(project) Then
    '                clientProjectTimeTotals(client)(project) = clientProjectTimeTotals(client)(project).Add(timeSpent)
    '            Else
    '                clientProjectTimeTotals(client)(project) = timeSpent
    '            End If
    '        End If
    '    Next

    '    For Each clientKvp In clientProjectTimeTotals
    '        Dim totalClient As New TimeSpan()
    '        For Each projectKvp In clientKvp.Value
    '            DtCliProyHoras.Rows.Add(clientKvp.Key, projectKvp.Key, projectKvp.Value.ToString())
    '            totalClient = totalClient.Add(projectKvp.Value)
    '        Next
    '        ' Fila en blanco
    '        DtCliProyHoras.Rows.Add()
    '        DtCliProyHoras.Rows.Add(clientKvp.Key, "TOTAL", totalClient.ToString())
    '    Next

    '    Return DtCliProyHoras
    'End Function



    Private Shared Function UsuariosHoras(ByVal DTable As DataTable) As DataTable
        Dim DtUsuHoras As New DataTable()
        DtUsuHoras.Columns.Add("USUARIOS", GetType(String))
        DtUsuHoras.Columns.Add("HORAS", GetType(String))

        Dim userTimeTotals As New Dictionary(Of String, TimeSpan)()

        For Each row As DataRow In DTable.Rows
            Dim user As String = row("usuario").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If userTimeTotals.ContainsKey(user) Then
                    userTimeTotals(user) = userTimeTotals(user).Add(timeSpent)
                Else
                    userTimeTotals(user) = timeSpent
                End If
            End If
        Next

        Dim totalGlobal As New TimeSpan()
        For Each kvp In userTimeTotals
            DtUsuHoras.Rows.Add(kvp.Key, kvp.Value.ToString())
            totalGlobal = totalGlobal.Add(kvp.Value)
        Next

        DtUsuHoras.Rows.Add("TOTAL", totalGlobal.ToString())
        DtUsuHoras.Rows.Add() ' Fila en blanco
        Return DtUsuHoras
    End Function

    Private Shared Function ClientesHoras(ByVal DTable As DataTable) As DataTable
        Dim DtCliHoras As New DataTable()
        DtCliHoras.Columns.Add("CLIENTE", GetType(String))
        DtCliHoras.Columns.Add("HORAS", GetType(String))

        Dim clientTimeTotals As New Dictionary(Of String, TimeSpan)()

        For Each row As DataRow In DTable.Rows
            Dim client As String = row("cliente").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If clientTimeTotals.ContainsKey(client) Then
                    clientTimeTotals(client) = clientTimeTotals(client).Add(timeSpent)
                Else
                    clientTimeTotals(client) = timeSpent
                End If
            End If
        Next

        Dim totalGlobal As New TimeSpan()
        For Each kvp In clientTimeTotals
            DtCliHoras.Rows.Add(kvp.Key, kvp.Value.ToString())
            totalGlobal = totalGlobal.Add(kvp.Value)
        Next

        DtCliHoras.Rows.Add("TOTAL", totalGlobal.ToString())
        DtCliHoras.Rows.Add() ' Fila en blanco
        Return DtCliHoras
    End Function

    Private Shared Function UsuarioClienteHoras(ByVal DTable As DataTable) As DataTable
        Dim DtUsuCliHoras As New DataTable()
        DtUsuCliHoras.Columns.Add("USUARIO", GetType(String))
        DtUsuCliHoras.Columns.Add("CLIENTE", GetType(String))
        DtUsuCliHoras.Columns.Add("HORAS", GetType(String))

        Dim userClientTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

        For Each row As DataRow In DTable.Rows
            Dim user As String = row("usuario").ToString()
            Dim client As String = row("cliente").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If Not userClientTimeTotals.ContainsKey(user) Then
                    userClientTimeTotals(user) = New Dictionary(Of String, TimeSpan)()
                End If

                If userClientTimeTotals(user).ContainsKey(client) Then
                    userClientTimeTotals(user)(client) = userClientTimeTotals(user)(client).Add(timeSpent)
                Else
                    userClientTimeTotals(user)(client) = timeSpent
                End If
            End If
        Next

        For Each userKvp In userClientTimeTotals
            Dim totalUser As New TimeSpan()
            For Each clientKvp In userKvp.Value
                DtUsuCliHoras.Rows.Add(userKvp.Key, clientKvp.Key, clientKvp.Value.ToString())
                totalUser = totalUser.Add(clientKvp.Value)
            Next
            DtUsuCliHoras.Rows.Add(userKvp.Key, "TOTAL", totalUser.ToString())
            DtUsuCliHoras.Rows.Add() ' Fila en blanco
        Next

        Return DtUsuCliHoras
    End Function

    Private Shared Function UsuarioTareaHoras(ByVal DTable As DataTable) As DataTable
        Dim DtUsuTareaHoras As New DataTable()
        DtUsuTareaHoras.Columns.Add("USUARIO", GetType(String))
        DtUsuTareaHoras.Columns.Add("TAREA", GetType(String))
        DtUsuTareaHoras.Columns.Add("HORAS", GetType(String))

        Dim userTaskTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

        For Each row As DataRow In DTable.Rows
            Dim user As String = row("usuario").ToString()
            Dim task As String = row("tarea").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If Not userTaskTimeTotals.ContainsKey(user) Then
                    userTaskTimeTotals(user) = New Dictionary(Of String, TimeSpan)()
                End If

                If userTaskTimeTotals(user).ContainsKey(task) Then
                    userTaskTimeTotals(user)(task) = userTaskTimeTotals(user)(task).Add(timeSpent)
                Else
                    userTaskTimeTotals(user)(task) = timeSpent
                End If
            End If
        Next

        For Each userKvp In userTaskTimeTotals
            Dim totalUser As New TimeSpan()
            For Each taskKvp In userKvp.Value
                DtUsuTareaHoras.Rows.Add(userKvp.Key, taskKvp.Key, taskKvp.Value.ToString())
                totalUser = totalUser.Add(taskKvp.Value)
            Next
            DtUsuTareaHoras.Rows.Add(userKvp.Key, "TOTAL", totalUser.ToString())
            DtUsuTareaHoras.Rows.Add() ' Fila en blanco
        Next

        Return DtUsuTareaHoras
    End Function

    Private Shared Function ClienteProyectoHoras(ByVal DTable As DataTable) As DataTable
        Dim DtCliProyHoras As New DataTable()
        DtCliProyHoras.Columns.Add("CLIENTE", GetType(String))
        DtCliProyHoras.Columns.Add("PROYECTO", GetType(String))
        DtCliProyHoras.Columns.Add("HORAS", GetType(String))

        Dim clientProjectTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

        For Each row As DataRow In DTable.Rows
            Dim client As String = row("cliente").ToString()
            Dim project As String = row("proyecto").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If Not clientProjectTimeTotals.ContainsKey(client) Then
                    clientProjectTimeTotals(client) = New Dictionary(Of String, TimeSpan)()
                End If

                If clientProjectTimeTotals(client).ContainsKey(project) Then
                    clientProjectTimeTotals(client)(project) = clientProjectTimeTotals(client)(project).Add(timeSpent)
                Else
                    clientProjectTimeTotals(client)(project) = timeSpent
                End If
            End If
        Next

        For Each clientKvp In clientProjectTimeTotals
            Dim totalClient As New TimeSpan()
            For Each projectKvp In clientKvp.Value
                DtCliProyHoras.Rows.Add(clientKvp.Key, projectKvp.Key, projectKvp.Value.ToString())
                totalClient = totalClient.Add(projectKvp.Value)
            Next
            DtCliProyHoras.Rows.Add(clientKvp.Key, "TOTAL", totalClient.ToString())
            DtCliProyHoras.Rows.Add() ' Fila en blanco
        Next

        Return DtCliProyHoras
    End Function

    Private Shared Function TareasHoras(ByVal DTable As DataTable) As DataTable
        Dim DtTareasHoras As New DataTable()
        DtTareasHoras.Columns.Add("TAREA", GetType(String))
        DtTareasHoras.Columns.Add("HORAS", GetType(String))

        Dim taskTimeTotals As New Dictionary(Of String, TimeSpan)()

        For Each row As DataRow In DTable.Rows
            Dim task As String = row("tarea").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If taskTimeTotals.ContainsKey(task) Then
                    taskTimeTotals(task) = taskTimeTotals(task).Add(timeSpent)
                Else
                    taskTimeTotals(task) = timeSpent
                End If
            End If
        Next

        Dim totalGlobal As New TimeSpan()
        For Each kvp In taskTimeTotals
            DtTareasHoras.Rows.Add(kvp.Key, kvp.Value.ToString())
            totalGlobal = totalGlobal.Add(kvp.Value)
        Next

        DtTareasHoras.Rows.Add("TOTAL", totalGlobal.ToString())
        DtTareasHoras.Rows.Add() ' Fila en blanco
        Return DtTareasHoras
    End Function

    Private Shared Function ClienteUsuarioHoras(ByVal DTable As DataTable) As DataTable
        Dim DtCliUsuHoras As New DataTable()
        DtCliUsuHoras.Columns.Add("CLIENTE", GetType(String))
        DtCliUsuHoras.Columns.Add("USUARIO", GetType(String))
        DtCliUsuHoras.Columns.Add("HORAS", GetType(String))

        Dim clientUserTimeTotals As New Dictionary(Of String, Dictionary(Of String, TimeSpan))()

        For Each row As DataRow In DTable.Rows
            Dim client As String = row("cliente").ToString()
            Dim user As String = row("usuario").ToString()
            Dim timeStr As String = row("tiempo").ToString()

            Dim timeSpent As TimeSpan
            If TimeSpan.TryParse(timeStr, timeSpent) Then
                If Not clientUserTimeTotals.ContainsKey(client) Then
                    clientUserTimeTotals(client) = New Dictionary(Of String, TimeSpan)()
                End If

                If clientUserTimeTotals(client).ContainsKey(user) Then
                    clientUserTimeTotals(client)(user) = clientUserTimeTotals(client)(user).Add(timeSpent)
                Else
                    clientUserTimeTotals(client)(user) = timeSpent
                End If
            End If
        Next

        For Each clientKvp In clientUserTimeTotals
            Dim totalClient As New TimeSpan()
            For Each userKvp In clientKvp.Value
                DtCliUsuHoras.Rows.Add(clientKvp.Key, userKvp.Key, userKvp.Value.ToString())
                totalClient = totalClient.Add(userKvp.Value)
            Next
            DtCliUsuHoras.Rows.Add(clientKvp.Key, "TOTAL", totalClient.ToString())
            DtCliUsuHoras.Rows.Add() ' Fila en blanco
        Next

        Return DtCliUsuHoras
    End Function

    Private Sub ExportDataGridViewToExcel(ByVal dgv As DataGridView, ByVal sheetName As String)
        If dgv IsNot Nothing AndAlso dgv.Rows.Count > 0 Then
            Using workbook As New XLWorkbook()
                ' Crear una hoja con el nombre especificado
                Dim worksheet = workbook.Worksheets.Add(sheetName)

                ' Agregar encabezados
                For i As Integer = 0 To dgv.Columns.Count - 1
                    Dim cell = worksheet.Cell(1, i + 1)
                    cell.Value = dgv.Columns(i).HeaderText
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center ' Justificar encabezados
                Next

                ' Agregar filas
                For i As Integer = 0 To dgv.Rows.Count - 1
                    For j As Integer = 0 To dgv.Columns.Count - 1
                        Dim cellValue As Object = dgv.Rows(i).Cells(j).Value
                        Dim cell = worksheet.Cell(i + 2, j + 1)
                        cell.Value = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left ' Justificar texto
                    Next
                Next

                ' Ajustar tamaño de las columnas automáticamente
                worksheet.Columns().AdjustToContents()

                ' Aplicar formato especial si el campo "Status" está presente
                If dgv.Columns.Cast(Of DataGridViewColumn)().Any(Function(c) c.HeaderText = "Status") Then
                    For i As Integer = 0 To dgv.Rows.Count - 1
                        Dim statusValue As String = If(dgv.Rows(i).Cells("Status").Value IsNot Nothing, dgv.Rows(i).Cells("Status").Value.ToString(), String.Empty)
                        If statusValue = "CON RETRASO" Then
                            Dim row = worksheet.Row(i + 2)
                            row.Style.Font.FontColor = XLColor.Red
                            row.Style.Font.Bold = True
                        Else
                            Dim row = worksheet.Row(i + 2)
                            row.Style.Font.FontColor = XLColor.Green
                            row.Style.Font.Bold = True
                        End If
                    Next
                End If

                ' Mostrar el cuadro de diálogo para guardar el archivo
                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "Excel Files|*.xlsx"
                saveFileDialog.Title = "Guardar Reporte en Excel"
                saveFileDialog.FileName = "Reporte_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    workbook.SaveAs(saveFileDialog.FileName)
                    MessageBox.Show("Reporte guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Else
            MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Shared Function ContarEstados(ByVal DTable As DataTable) As DataTable
        Dim DtEstados As New DataTable()
        DtEstados.Columns.Add("Estado", GetType(String))
        DtEstados.Columns.Add("Cantidad", GetType(Integer))

        Dim estadoContador As New Dictionary(Of String, Integer) From {
        {"Finalizada", 0},
        {"Asignada", 0},
        {"Pausada", 0},
        {"Ejecutando", 0}
    }

        For Each row As DataRow In DTable.Rows
            Dim estado As String = row("estado").ToString()

            If estadoContador.ContainsKey(estado) Then
                estadoContador(estado) += 1
            End If
        Next

        For Each kvp In estadoContador
            DtEstados.Rows.Add(kvp.Key, kvp.Value)
        Next

        Return DtEstados
    End Function






    Private Sub CHKEstatusdetareas_CheckedChanged(sender As Object, e As EventArgs) Handles CHKEstatusdetareas.CheckedChanged
        If CHKEstatusdetareas.Checked Then
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = Dt
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkUsuarioshoras_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUsuarioshoras.CheckedChanged
        If ChkUsuarioshoras.Checked Then
            Dim DtUsuH As DataTable = UsuariosHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtUsuH
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkClienteshoras_CheckedChanged(sender As Object, e As EventArgs) Handles ChkClienteshoras.CheckedChanged
        If ChkClienteshoras.Checked Then
            Dim DtCliH As DataTable = ClientesHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtCliH
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkTareashoras_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTareashoras.CheckedChanged
        If ChkTareashoras.Checked Then
            Dim DtTareaH As DataTable = TareasHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtTareaH
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkUsuariosClientes_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUsuariosClientes.CheckedChanged
        If ChkUsuariosClientes.Checked Then
            Dim DtUsuCliH As DataTable = UsuarioClienteHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtUsuCliH
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkUsuariosTareas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUsuariosTareas.CheckedChanged
        If ChkUsuariosTareas.Checked Then
            Dim DtUsuTareasHora As DataTable = UsuarioTareaHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtUsuTareasHora
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkClientesProyectos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkClientesProyectos.CheckedChanged
        If ChkClientesProyectos.Checked Then
            Dim DtCliPro As DataTable = ClienteProyectoHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtCliPro
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkClientesUsuarios_CheckedChanged(sender As Object, e As EventArgs) Handles ChkClientesUsuarios.CheckedChanged
        If ChkClientesUsuarios.Checked Then
            Dim DtCliUsuH As DataTable = ClienteUsuarioHoras(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtCliUsuH
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
        End If
    End Sub

    Private Sub ChkCuadroNinja_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCuadroNinja.CheckedChanged

        If ChkCuadroNinja.Checked Then
            Dim DtCuenta As DataTable = ContarEstados(Dt)
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = DtCuenta
            ' Deshabilitar la edición del DataGridView
            DgvDatos.ReadOnly = True
        ElseIf Not AnyOtherCheckboxChecked() Then
            DgvDatos.DataSource = Nothing
            ' Hacer que el DataGridView sea editable de nuevo si no hay otros CheckBox seleccionados
            DgvDatos.ReadOnly = False
        End If

    End Sub


    Private Function AnyOtherCheckboxChecked() As Boolean
        ' Verifica si algún otro CheckBox está marcado
        Return CHKEstatusdetareas.Checked OrElse
               ChkUsuarioshoras.Checked OrElse
               ChkClienteshoras.Checked OrElse
               ChkTareashoras.Checked OrElse
               ChkUsuariosClientes.Checked OrElse
               ChkUsuariosTareas.Checked OrElse
               ChkClientesProyectos.Checked OrElse
               ChkClientesUsuarios.Checked OrElse
               ChkCuadroNinja.Checked
    End Function

    Private Sub DgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles DgvDatos.DoubleClick
        If ChkCuadroNinja.Checked Then
            If DgvDatos.CurrentCell IsNot Nothing Then
                Dim rowIndex As Integer = DgvDatos.CurrentCell.RowIndex
                Dim estadoValue As String = DgvDatos.Rows(rowIndex).Cells("Estado").Value.ToString()

                Dim filteredDt As DataTable = FilterDataTableByEstado(Dt, estadoValue)
                DgvDatos.DataSource = Nothing
                DgvDatos.DataSource = filteredDt


                CHKEstatusdetareas.Checked = False
            End If
        End If
    End Sub

    Private Function FilterDataTableByEstado(originalDt As DataTable, estado As String) As DataTable
        Dim filteredDt As DataTable = originalDt.Clone()
        Dim rows As DataRow() = originalDt.Select("Estado = '" & estado.Replace("'", "''") & "'")
        For Each row As DataRow In rows
            filteredDt.ImportRow(row)
        Next

        Return filteredDt
    End Function

    Private Sub BtnXlssoloEstosDatos_Click(sender As Object, e As EventArgs) Handles BtnXlssoloEstosDatos.Click
        ExportDataGridViewToExcel(DgvDatos, "Por Estado")
    End Sub
End Class
