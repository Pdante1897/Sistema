Imports System.Data.OleDb
Imports System.IO

Public Class Login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim registrar As New Registrar
        'Registrar.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Consulta() Then
            Dim principal As New Principal
            principal.Show()
            Me.Hide()

        ElseIf TextBox1.Text = "admin" And TextBox2.Text = "123" Then
            Dim admin As New Admin
            admin.Show()
            Me.Hide()

        Else
            MessageBox.Show("Credenciales incorrectras")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub

    Dim cadena As New OleDbConnection

    Private Function Consulta()
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbCommand("SELECT Password FROM [User] WHERE Usuario= '" + TextBox1.Text + "'", cadena)
            Dim ds As OleDbDataReader
            cadena.Open()
            ds = comando.ExecuteReader()
            ds.Read()
            Dim pass As String
            pass = ds.GetString(0)
            If pass = TextBox2.Text Then
                cadena.Close()
                Return True
            Else
                cadena.Close()

                Return False
            End If
        Catch ex As Exception
            cadena.Close()
            Return False
        End Try






    End Function


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
