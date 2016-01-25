Imports System.Data.SqlClient

Public Class Form1
    Dim consulta As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" Then
            LEER()
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Visible = True
        End If
    End Sub

    Sub LEER()
        consulta = "SELECT * FROM " & ComboBox1.Text

        Try
            Dim cnn As New SqlConnection(connexion)
            Dim da As New SqlDataAdapter(consulta, cnn)
            Dim ds As New DataSet

            da.Fill(ds, ComboBox1.Text)
            DataGridView1.DataSource = ds.Tables(ComboBox1.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox1
            .Items.Add("Gastos")
            .Items.Add("Alumno")
            .Items.Add("Personal")
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedIndex = 0 Then
            Form2.Show()
            Form2.Width = 514
            Form2.Label1.Text = "Codigo"
            Form2.Label2.Text = "Tipo Gasto"
            Form2.Label3.Text = "Precio"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Form2.Show()
            Form2.Width = 514
            Form2.Label1.Text = "Codigo"
            Form2.Label2.Text = "Seccion"
            Form2.Label3.Text = "Edad"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Form2.Show()
            Form2.Width = 958
            Form2.Label1.Text = "ID"
            Form2.Label2.Text = "Nombre"
            Form2.Label3.Text = "Apellido"
            Form2.Label4.Text = "Direccion"
            Form2.Label5.Text = "Telefono"
            Form2.Label7.Text = "Email"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Form5.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form6.Show()
    End Sub
End Class
