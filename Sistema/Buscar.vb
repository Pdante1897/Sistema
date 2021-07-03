Imports System.Data.OleDb

Public Class Buscar
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim admin As New Admin
        admin.Show()
        Me.Hide()
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Dim cadena As New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT * FROM [User] WHERE Cui= '" + TextBox1.Text + "'", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            TextBox2.DataBindings.Add("Text", ds.Tables(0), "Nombres")
            TextBox3.DataBindings.Add("Text", ds.Tables(0), "Apellidos")
            TextBox4.DataBindings.Add("Text", ds.Tables(0), "Usuario")
            TextBox5.DataBindings.Add("Text", ds.Tables(0), "Password")
            TextBox6.DataBindings.Add("Text", ds.Tables(0), "Direccion")
            TextBox7.DataBindings.Add("Text", ds.Tables(0), "Telefono")
            TextBox8.DataBindings.Add("Text", ds.Tables(0), "Celular")
            TextBox9.DataBindings.Add("Text", ds.Tables(0), "Sexo")
            TextBox10.DataBindings.Add("Text", ds.Tables(0), "Fecha")
            TextBox11.DataBindings.Add("Text", ds.Tables(0), "Foto")
            cadena.Close()
        Catch ex As Exception
            cadena.Close()
            MsgBox("Error!" + vbCr + "Asegurece que los datos sean correctos!!")
        End Try
        Try
            PictureBox1.Load(TextBox11.Text)
        Catch ex As Exception
            PictureBox1.Load(My.Computer.FileSystem.CurrentDirectory + "\incognito.png")

        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()

    End Sub
End Class