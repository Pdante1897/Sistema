﻿Imports System.Data.OleDb

Public Class Iusi
    Private Sub Pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Load(My.Computer.FileSystem.CurrentDirectory + "\tarjeta.png")
        Label4.Text = "3000"
        Label8.Text = CStr(DateTime.Today.Year)
    End Sub

    Dim cadena As New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Error! Revisar datos.")
            Return
        End If
        Timer1.Start()
        Try
            cadena.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("INSERT INTO [IUSI] VALUES ('" + Principal.Cui + "', '" + CStr(DateTime.Today.Year) + "', '" + DateTime.Today + "', " + Label4.Text + ")", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            cadena.Close()
        Catch ex As Exception
            cadena.Close()
            MsgBox("Error! Revisar datos.")
        End Try



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(2)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            MsgBox("Pago realizado con exito!")
            Me.Hide()
        End If
    End Sub
End Class