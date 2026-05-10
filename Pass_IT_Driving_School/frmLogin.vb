Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Username placeholder
        TextBox1.Text = "Enter Username"
        TextBox1.ForeColor = Color.Gray

        ' Password placeholder
        TextBox2.Text = "Enter Password"
        TextBox2.ForeColor = Color.Gray
        TextBox2.UseSystemPasswordChar = False

    End Sub

    ' ================= USERNAME PLACEHOLDER =================

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Enter Username" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter Username"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= PASSWORD PLACEHOLDER =================

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        If TextBox2.Text = "Enter Password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text = "" Then
            TextBox2.UseSystemPasswordChar = False
            TextBox2.Text = "Enter Password"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= LOGIN BUTTON =================

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim username = TextBox1.Text
        Dim password = TextBox2.Text

        If username = "admin" And password = "1234" Then

            MessageBox.Show("Login Successful!", "Success")

            Dim dashboard As New frmDashboard
            dashboard.Show()
            Hide()

        ElseIf username = "student" And password = "5678" Then

            MessageBox.Show("Login Successful!", "Success")

            Dim dashboard As New frmDashboard
            dashboard.Show()
            Hide()

        Else

            MessageBox.Show("Invalid Username or Password", "Error")

        End If

    End Sub

    ' ================= CREATE BUTTON (Button2) =================

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' OPTION 1: Open Create Account Form
        Dim createForm As New frmCreate
        createForm.Show()

        ' OPTION 2 (if you DON'T have frmCreate yet)
        ' MessageBox.Show("Create account feature coming soon!", "Info")

        Me.Hide()

    End Sub

End Class