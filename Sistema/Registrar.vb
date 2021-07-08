Imports System.Data.OleDb

Public Class Registrar
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'buscar foto
        OpenFileDialog1.Filter = "Imagenes (*.jpg)|*.jpg|Imagenes (*.png)|*.png"
        OpenFileDialog1.ShowDialog()
        TextBox9.Text = OpenFileDialog1.FileName()
        Try
            PictureBox1.Load(TextBox9.Text)

        Catch ex As Exception

        End Try

    End Sub

    Dim cadena As New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'boton Registrar
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("INSERT INTO [User] VALUES ('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox7.Text + "', '" + TextBox8.Text + "', '" + ComboBox1.SelectedItem.ToString() + "', '" + DateTimePicker1.Value.Date + "', '" + TextBox9.Text + "')", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            cadena.Close()
            MsgBox("Registro realizado con exito!")
        Catch ex As Exception
            cadena.Close()
            MsgBox("Error!" + vbCr + "Asegurece que los datos sean correctos!!")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim admin As New Admin
        admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()
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
        PictureBox1.Dispose()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            CheckBox2.Enabled = False
        ElseIf Not CheckBox1.Checked Then
            CheckBox2.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox1.Enabled = False
        ElseIf Not CheckBox2.Checked Then
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub Registrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class