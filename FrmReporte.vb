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

    End Sub

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Return DtUsuHoras

    End Function





End Class