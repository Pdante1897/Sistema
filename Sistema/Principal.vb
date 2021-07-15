Imports System.Data.OleDb

Public Class Principal
    Public Shared Cui As String
    Public Shared monto As Double
    Public Shared servicio As String
    Public Shared mes As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cui = ""
        Login.Sesion = ""
        Dim loginV As New Login
        loginV.Show()
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Dim cadena As New OleDbConnection
    Private Sub InicioCombo() 'Agregar numeros a comboBox
        Dim n As Integer
        For n = Year(Now) To 1900 Step -1

            ComboBox1.Items.Add(n)
        Next
    End Sub
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'carga de la ventana principal
        MsgBox("Bienvenido!")
        Dim foto As New Control
        InicioCombo()

        Try
            cadena.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
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
            Label22.DataBindings.Add("Text", ds.Tables(0), "Foto")
            cadena.Close()
        Catch ex As Exception
            cadena.Close()
        End Try

        Try
            PictureBox1.Load(Label22.Text)
        Catch ex As Exception
            PictureBox1.Load(My.Computer.FileSystem.CurrentDirectory + "\incognito.png")

        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'boton registrar vehiculo
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Error! Revisar datos.")
            Return
        End If
        Try
            cadena.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("INSERT INTO [Vehiculos] VALUES ('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', " + ComboBox1.SelectedItem.ToString + ", '" + Cui + "')", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            cadena.Close()
            MsgBox("Registro realizado con exito!")
        Catch ex As NullReferenceException
            cadena.Close()
            MsgBox("Error! Revisar datos.")
        End Try

        clear()
        actualizar()


    End Sub
    Private Sub actualizar()
        Try
            cadena.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT Placa, Tipo, Marca, Color, Modelo FROM [Vehiculos] WHERE Cui= '" + Cui + "'", cadena)
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click 'boton refescar vehiculos
        actualizar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'limpiar

        clear()


    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = "Seleccionar"
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'eliminar vehiculos
        Try
            cadena.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("DELETE FROM [Vehiculos] WHERE Placa= '" + TextBox1.Text + "'", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            cadena.Close()
            MsgBox("Eliminado exitosamente")
        Catch ex As Exception
            MsgBox("Error! Verifique los datos ingresados")
            cadena.Close()

        End Try
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click 'boton pago iusi
        Dim iusi As New Iusi
        iusi.Show()
    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click ' boton Refrescar pagos
        Try
            cadena.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Database2.mdb"
            Dim comando As New OleDbDataAdapter("SELECT Servicio, Mes, Fecha, Monto FROM [Pagos] WHERE Cui= '" + Cui + "'", cadena)
            Dim ds As New DataSet
            comando.Fill(ds)
            cadena.Open()
            DataGridView2.DataSource = ds.Tables(0)
            cadena.Close()
        Catch ex As Exception
            cadena.Close()
            MsgBox("Error!" + vbCr + "Asegurece que la base de datos exista!")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click 'pago de servicios
        Try
            Select Case ComboBox2.SelectedItem.ToString()
                Case "Agua"
                    monto = 150
                Case "Luz"
                    monto = 250
                Case "Telefono"
                    monto = 150
                Case "Internet"
                    monto = 300
                Case "Cable"
                    monto = 200
                Case "Gas"
                    monto = 125
                Case "Limpieza"
                    monto = 100
                Case "Mantenimiento y Seguridad"
                    monto = 300
                Case Else
                    MsgBox("error")
                    Return
            End Select
            servicio = ComboBox2.SelectedItem.ToString()
            mes = ComboBox3.SelectedItem.ToString()
            Dim pago As New Pagos
            pago.Show()
        Catch ex As Exception
            MsgBox("Seleccione Mes y Servicio")
        End Try


    End Sub



    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click 'boton mensualidad
        Try
            mes = ComboBox4.SelectedItem.ToString()
            Dim cuota As New Cuotas
            cuota.Show()
        Catch ex As Exception
            MsgBox("Seleccione Mes")
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click 'boton para visualizar iusi
        Dim listaIusi As New ListaIUSI
        listaIusi.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click 'boton para visualizar mensualidad
        Dim listaCuot As New ListaCuotas
        listaCuot.Show()
    End Sub
End Class

