Imports System.Drawing.Printing

Public Class Form1

    ' Declare the PrintDocument with WithEvents so PrintPage fires
    Private WithEvents PD As New PrintDocument

    ' Button click event to start printing
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        ' Show the print dialog so you can select a printer
        Dim dlg As New PrintDialog
        dlg.Document = PD

        ' Optional: set your thermal printer here
        ' Replace "YOUR_PRINTER_NAME" with the exact name from Devices and Printers
        'PD.PrinterSettings.PrinterName = "POS58 Printer"

        If dlg.ShowDialog() = DialogResult.OK Then
            PD.Print()
        End If
    End Sub

    ' What gets printed — the receipt layout
    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim font As New Font("Courier New", 9) ' Monospaced for thermal printers
        Dim y As Integer = 10 ' Starting Y position

        ' Receipt content
        e.Graphics.DrawString("DENTAL CLINIC", font, Brushes.Black, 10, y)
        y += 15

        e.Graphics.DrawString("----------------------------", font, Brushes.Black, 10, y)
        y += 15

        e.Graphics.DrawString("Patient: Juan Dela Cruz", font, Brushes.Black, 10, y)
        y += 15

        e.Graphics.DrawString("Service: Cleaning", font, Brushes.Black, 10, y)
        y += 15

        e.Graphics.DrawString("Total: P500", font, Brushes.Black, 10, y)
        y += 15

        e.Graphics.DrawString("----------------------------", font, Brushes.Black, 10, y)
        y += 15

        e.Graphics.DrawString("Thank you!", font, Brushes.Black, 10, y)
    End Sub

End Class
