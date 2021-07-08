Imports System.Data.OleDb

Public Class Admin
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'boton registrar
        Dim registrar As New Registrar
        registrar.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'boton eliminar
        Dim eliminar As New Eliminar
        eliminar.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click ' boton cerrar sesion
        Dim login As New Login
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'boton buscar
        Dim buscar As New Buscar
        buscar.Show()
        Me.Hide()
    End Sub

    Dim cadena As New OleDbConnection

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'carga de la ventana Admin
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT Cui, Nombres, Apellidos, Usuario, Sexo FROM [User]", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            DataGridView1.DataSource = ds.Tables(0)
            cadena.Close()
            MsgBox("Conexion realizada con exito!")
        Catch ex As Exception
            cadena.Close()
            MsgBox("Error!" + vbCr + "Asegurece que la base de datos exista!")
        End Try



    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class