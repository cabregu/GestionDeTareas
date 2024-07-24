Imports System.IO
Imports ClosedXML.Excel

Public Class FrmReporte

    Public CadenaDeConexion As String = ""
    Private Sub FrmReporte_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmPpal.Visible = True
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click

        Dim Dt As New DataTable
        Dt = Conexion.ObtenerTareasPorFecha(CadenaDeConexion, DtpFechaInicial.Value, DtpFechaFinal.Value)
        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = Dt

    End Sub

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        If DgvDatos.DataSource IsNot Nothing Then
            Using workbook As New XLWorkbook()
                Dim worksheet = workbook.Worksheets.Add("Reporte")

                ' Agregar encabezados
                For i As Integer = 1 To DgvDatos.Columns.Count
                    worksheet.Cell(1, i).Value = DgvDatos.Columns(i - 1).HeaderText
                Next

                ' Agregar filas
                For i As Integer = 0 To DgvDatos.Rows.Count - 1
                    For j As Integer = 0 To DgvDatos.Columns.Count - 1
                        Dim cellValue As Object = DgvDatos.Rows(i).Cells(j).Value
                        worksheet.Cell(i + 2, j + 1).Value = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                    Next
                Next

                ' Guardar el archivo
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








End Class