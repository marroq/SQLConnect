Imports System.Data.SqlClient

Public Class Form2
    Dim consulta As String
    Dim consulta2 As String
    Dim consulta3 As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text <> "") And (TextBox2.Text <> "") And (TextBox3.Text <> "") Then
            INGRESAR()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox1.Focus()
        Else
            MsgBox("CAMPOS VACIOS, LLENE TODOS LOS DATOS", MsgBoxStyle.Critical, "ERROR")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox1.Focus()
        End If
    End Sub

    Sub INGRESAR()
        consulta = String.Format("INSERT INTO {0} (Codigo, TipoGasto, Precio) VALUES ('{1}', '{2}', '{3}')", Form1.ComboBox1.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text)
        consulta2 = String.Format("INSERT INTO {0} (Codigo, Seccion, Edad) VALUES ('{1}', '{2}', '{3}')", Form1.ComboBox1.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text)
        consulta3 = String.Format("INSERT INTO {0} (Code, Nombre, Apellido, Direccion, Telefono, Email) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Form1.ComboBox1.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)

        Try
            Dim cnn As New SqlConnection(connexion)
            Dim da As SqlDataAdapter

            'ESCOGER QUE TIPO DE INSERT SE LE REALIZARA A LA BASE DE DATOS DEPENDIENDO DE LA TABLAS
            'QUE FUE SELECCIONADA EN LA VENTANA PRINCIPAL
            If Form1.ComboBox1.SelectedIndex = 0 Then
                da = New SqlDataAdapter(consulta, cnn)
            ElseIf Form1.ComboBox1.SelectedIndex = 1 Then
                da = New SqlDataAdapter(consulta2, cnn)
            ElseIf Form1.ComboBox1.SelectedIndex = 2 Then
                da = New SqlDataAdapter(consulta3, cnn)
            End If

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