Imports System.IO

Public Class Login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim registrar As New Registrar
        registrar.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "123" Then
            Dim admin As New Admin
            admin.Show()
            Me.Hide()
        Else
            MessageBox.Show("Credenciales incorrectras")
            TextBox1.Text = My.Computer.FileSystem.CurrentDirectory
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class
