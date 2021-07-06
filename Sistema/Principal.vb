Imports System.Data.OleDb

Public Class Principal
    Public Shared Cui As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim login As New Login
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Dim cadena As New OleDbConnection
    Private Sub InicioCombo()
        Dim n As Integer
        For n = Year(Now) To 1900 Step -1

            ComboBox1.Items.Add(n)
        Next
    End Sub
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Bienvenido!")
        Dim foto As Control
        InicioCombo()
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT * FROM [User] WHERE Usuario= '" + Login.Sesion + "'", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            Label8.DataBindings.Add("Text", ds.Tables(0), "Cui")
            Cui = Label8.Text
            Label14.DataBindings.Add("Text", ds.Tables(0), "Nombres")
            Label13.DataBindings.Add("Text", ds.Tables(0), "Apellidos")
            Label12.DataBindings.Add("Text", ds.Tables(0), "Usuario")
            Label11.DataBindings.Add("Text", ds.Tables(0), "Direccion")
            Label10.DataBindings.Add("Text", ds.Tables(0), "Telefono")
            Label9.DataBindings.Add("Text", ds.Tables(0), "Celular")
            foto.DataBindings.Add("Text", ds.Tables(0), "Foto")
            cadena.Close()
        Catch ex As Exception
            cadena.Close()
        End Try
        Try
            PictureBox1.Load(foto.Text)
        Catch ex As Exception
            PictureBox1.Load(My.Computer.FileSystem.CurrentDirectory + "\incognito.png")

        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub
End Class