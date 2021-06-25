Public Class Registrar
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.Filter = "Imagenes (*.jpg)|*.jpg|Imagenes (*.png)|*.png"
        OpenFileDialog1.ShowDialog()
        TextBox9.Text = OpenFileDialog1.FileName()

        PictureBox1.Load(TextBox9.Text)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim admin As New Admin
        admin.Show()
        Me.Hide()
    End Sub
End Class