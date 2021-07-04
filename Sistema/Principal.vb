Public Class Principal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim login As New Login
        login.Show()
        Me.Hide()
    End Sub
End Class