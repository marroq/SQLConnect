Imports System.Data.SqlClient

Public Class Form5
    Dim consulta As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MODIFICAR()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    Sub MODIFICAR()
        consulta = String.Format("UPDATE {0} SET {1} = '{2}' WHERE {3} = '{4}'", Form1.ComboBox1.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)

        Try
            Dim cnn As New SqlConnection(connexion)
            Dim da As New SqlDataAdapter(consulta, cnn)
            Dim ds As New DataSet

            da.Fill(ds, Form1.ComboBox1.Text)

            MsgBox("REGISTRO MODIFICADO EXITOSAMENTE", MsgBoxStyle.Information, "AVISO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub
End Class
