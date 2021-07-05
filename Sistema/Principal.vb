Public Class Principal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim login As New Login
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class