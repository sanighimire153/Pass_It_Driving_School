'Public Class frmDashboard
'    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

'    End Sub

'    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

'    End Sub

'    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

'    End Sub

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

'    End Sub

'    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

'    End Sub
'End Class

Public Class frmLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        If username = "admin" And password = "1234" Then

            MessageBox.Show("Login Successful!", "Success")

            Dim studentForm As New frmStudents
            studentForm.Show()
            Me.Hide()

        ElseIf username = "student A" And password = "5678" Then

            MessageBox.Show("Login Successful!", "Success")

            Dim studentForm As New frmStudents
            studentForm.Show()
            Me.Hide()

        Else
            MessageBox.Show("Invalid Username or Password", "Error")

        End If

    End Sub

End Class