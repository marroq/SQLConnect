Imports System.Data.SqlClient

Public Class Form6
    Dim consulta As String

    Dim dt As DataTable
    Dim cn As New SqlConnection(connexion)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CONSULTAR()
        ComboBox2.Items.Clear()
        ComboBox1.Items.Clear()
    End Sub

    Sub CONSULTAR()
        If ComboBox2.Text = "" Then
            ComboBox2.Text = "*"
        End If

        consulta = String.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", ComboBox2.Text, Form1.ComboBox1.Text, ComboBox1.Text, ComboBox3.Text)

        Try
            Dim cnn As New SqlConnection(connexion)
            Dim da As New SqlDataAdapter(consulta, cnn)
            Dim ds As New DataSet

            da.Fill(ds, Form1.ComboBox1.Text)
            Form1.DataGridView1.DataSource = ds.Tables(Form1.ComboBox1.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form6_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        If Form1.ComboBox1.Text = "Gastos" Then
            ComboBox1.Items.Add("Codigo")
            ComboBox1.Items.Add("TipoGasto")
            ComboBox1.Items.Add("Precio")
        ElseIf Form1.ComboBox1.Text = "Alumno" Then
            ComboBox1.Items.Add("Codigo")
            ComboBox1.Items.Add("Seccion")
            ComboBox1.Items.Add("Edad")
        End If

        If Form1.ComboBox1.Text = "Gastos" Then
            ComboBox2.Items.Add("Codigo")
            ComboBox2.Items.Add("TipoGasto")
            ComboBox2.Items.Add("Precio")
        ElseIf Form1.ComboBox1.Text = "Alumno" Then
            ComboBox2.Items.Add("Codigo")
            ComboBox2.Items.Add("Seccion")
            ComboBox2.Items.Add("Edad")
        End If

        'CARGA DE DATOS EN COMBOBOX3
        If Form1.ComboBox1.Text = "Alumno" Then
            If ComboBox1.Text = "Codigo" Then
                CBCodigo()
            ElseIf ComboBox1.Text = "Seccion" Then
                CBSeccion()
            ElseIf ComboBox1.Text = "Edad" Then
                CBEdad()
            End If
        ElseIf Form1.ComboBox1.Text = "Gastos" Then
            If ComboBox1.Text = "Codigo" Then
                CBGCodigo()
            ElseIf ComboBox1.Text = "TipoGasto" Then
                CBGTipoGasto()
            ElseIf ComboBox1.Text = "Precio" Then
                CBGPrecio()
            End If
        End If
    End Sub

    Sub CBCodigo()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Alumno"
            .Connection = cn
        End With

        da.SelectCommand = cmd
        dt = New DataTable
        da.Fill(dt)

        With ComboBox3
            .DataSource = dt
            .DisplayMember = "Codigo"
            .ValueMember = "Codigo"
        End With
    End Sub

    Sub CBSeccion()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Alumno"
            .Connection = cn
        End With

        da.SelectCommand = cmd
        dt = New DataTable
        da.Fill(dt)

        With ComboBox3
            .DataSource = dt
            .DisplayMember = "Seccion"
            .ValueMember = "Codigo"
        End With
    End Sub

    Sub CBEdad()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Alumno"
            .Connection = cn
        End With

        da.SelectCommand = cmd
        dt = New DataTable
        da.Fill(dt)

        With ComboBox3
            .DataSource = dt
            .DisplayMember = "Edad"
            .ValueMember = "Codigo"
        End With
    End Sub

    Sub CBGCodigo()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Gastos"
            .Connection = cn
        End With

        da.SelectCommand = cmd
        dt = New DataTable
        da.Fill(dt)

        With ComboBox3
            .DataSource = dt
            .DisplayMember = "Codigo"
            .ValueMember = "Codigo"
        End With
    End Sub

    Sub CBGTipoGasto()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Gastos"
            .Connection = cn
        End With

        da.SelectCommand = cmd
        dt = New DataTable
        da.Fill(dt)

        With ComboBox3
            .DataSource = dt
            .DisplayMember = "TipoGasto"
            .ValueMember = "Codigo"
        End With
    End Sub

    Sub CBGPrecio()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Gastos"
            .Connection = cn
        End With

        da.SelectCommand = cmd
        dt = New DataTable
        da.Fill(dt)

        With ComboBox3
            .DataSource = dt
            .DisplayMember = "Precio"
            .ValueMember = "Codigo"
        End With
    End Sub
End Class