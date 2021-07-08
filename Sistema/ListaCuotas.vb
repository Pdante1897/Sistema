Imports System.Data.OleDb

Public Class ListaCuotas
    Dim cadena As New OleDbConnection

    Private Sub ListaCuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cadena.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT Mes, Fecha, Monto FROM [Mensualidad] WHERE Cui= '" + Principal.Cui + "'", cadena)
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
End Class