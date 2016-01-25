Imports System.Data.SqlClient

'DISPONIBLE PARA USO Y MODIFICACION
Public Class Form3
    Dim consulta As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        INGRESAR()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox1.Focus()
    End Sub

    Sub INGRESAR()
        consulta = String.Format("INSERT INTO {0} (Codigo, Seccion, Edad) VALUES ('{1}', '{2}', '{3}')", Form1.ComboBox1.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text)

        Try
            Dim cnn As New SqlConnection(connexion)
            Dim da As New SqlDataAdapter(consulta, cnn)
            Dim ds As New DataSet

            da.Fill(ds, Form1.ComboBox1.Text)

            MsgBox("REGISTRO ALMACENADO EXITOSAMENTE", MsgBoxStyle.Information, "AVISO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox1.Focus()
    End Sub
End Class
