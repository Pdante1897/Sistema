Imports System.Data.OleDb

Public Class Admin
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim registrar As New Registrar
        registrar.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim eliminar As New Eliminar
        eliminar.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim login As New Login
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim buscar As New Buscar
        buscar.Show()
        Me.Hide()
    End Sub

    Dim cadena As New OleDbConnection

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT Cui, Nombres, Apellidos, Usuario, Sexo, Renta, Mensualidad FROM [User]", cadena)
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

    Private Sub actualizar()
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT Placa, Tipo, Marca, Color, Modelo FROM [Vehiculos]", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            DataGridView1.DataSource = ds.Tables(0)
            cadena.Close()
        Catch ex As Exception
            cadena.Close()
            MsgBox("Error!" + vbCr + "Asegurece que la base de datos exista!")
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class