Imports System.Data.SqlClient

Public Class Form4
    Dim consulta As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ELIMINAR()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
    End Sub

    Sub ELIMINAR()
        consulta = String.Format("DELETE FROM {0} WHERE {1} = '{2}'", Form1.ComboBox1.Text, TextBox1.Text, TextBox2.Text)

        Try
            Dim cnn As New SqlConnection(connexion)
            Dim da As New SqlDataAdapter(consulta, cnn)
            Dim ds As New DataSet

            da.Fill(ds, Form1.ComboBox1.Text)

            MsgBox("REGISTRO ELIMINADO EXITOSAMENTE", MsgBoxStyle.Information, "AVISO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class