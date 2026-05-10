Public Class frmcreate

    Private Sub frmcreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ===== FULL NAME =====
        TextBox1.Text = "Enter Full Name"
        TextBox1.ForeColor = Color.Gray

        ' ===== USERNAME =====
        TextBox2.Text = "Enter Username"
        TextBox2.ForeColor = Color.Gray

        ' ===== ADDRESS =====
        TextBox3.Text = "Enter Address"
        TextBox3.ForeColor = Color.Gray

        ' ===== PHONE =====
        TextBox4.Text = "Enter Phone Number"
        TextBox4.ForeColor = Color.Gray

        ' ===== EMAIL =====
        TextBox5.Text = "Enter Email"
        TextBox5.ForeColor = Color.Gray

        ' ===== PASSWORD =====
        TextBox6.Text = "Enter Password"
        TextBox6.ForeColor = Color.Gray
        TextBox6.UseSystemPasswordChar = False

        ' ===== CONFIRM PASSWORD =====
        TextBox7.Text = "Confirm Password"
        TextBox7.ForeColor = Color.Gray
        TextBox7.UseSystemPasswordChar = False

    End Sub

    ' ================= FULL NAME =================
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Enter Full Name" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter Full Name"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= USERNAME (UPPERCASE) =================
    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        If TextBox2.Text = "Enter Username" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text <> "" And TextBox2.Text <> "Enter Username" Then
            TextBox2.Text = TextBox2.Text.ToUpper()
        End If

        If TextBox2.Text = "" Then
            TextBox2.Text = "Enter Username"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= ADDRESS =================
    Private Sub TextBox3_Enter(sender As Object, e As EventArgs) Handles TextBox3.Enter
        If TextBox3.Text = "Enter Address" Then
            TextBox3.Text = ""
            TextBox3.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text = "" Then
            TextBox3.Text = "Enter Address"
            TextBox3.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= PHONE =================
    Private Sub TextBox4_Enter(sender As Object, e As EventArgs) Handles TextBox4.Enter
        If TextBox4.Text = "Enter Phone Number" Then
            TextBox4.Text = ""
            TextBox4.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        If TextBox4.Text = "" Then
            TextBox4.Text = "Enter Phone Number"
            TextBox4.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= EMAIL =================
    Private Sub TextBox5_Enter(sender As Object, e As EventArgs) Handles TextBox5.Enter
        If TextBox5.Text = "Enter Email" Then
            TextBox5.Text = ""
            TextBox5.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If TextBox5.Text = "" Then
            TextBox5.Text = "Enter Email"
            TextBox5.ForeColor = Color.Gray
        End If
    End Sub

    ' ================= PASSWORD =================
    Private Sub TextBox6_Enter(sender As Object, e As EventArgs) Handles TextBox6.Enter
        If TextBox6.Text = "Enter Password" Then
            TextBox6.Text = ""
            TextBox6.ForeColor = Color.Black
            TextBox6.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        If TextBox6.Text = "" Then
            TextBox6.Text = "Enter Password"
            TextBox6.ForeColor = Color.Gray
            TextBox6.UseSystemPasswordChar = False
        End If
    End Sub

    ' ================= CONFIRM PASSWORD =================
    Private Sub TextBox7_Enter(sender As Object, e As EventArgs) Handles TextBox7.Enter
        If TextBox7.Text = "Confirm Password" Then
            TextBox7.Text = ""
            TextBox7.ForeColor = Color.Black
            TextBox7.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TextBox7_Leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
        If TextBox7.Text = "" Then
            TextBox7.Text = "Confirm Password"
            TextBox7.ForeColor = Color.Gray
            TextBox7.UseSystemPasswordChar = False
        End If
    End Sub

    ' ================= CREATE BUTTON =================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "Enter Full Name" Or
           TextBox2.Text = "Enter Username" Or
           TextBox3.Text = "Enter Address" Or
           TextBox4.Text = "Enter Phone Number" Or
           TextBox5.Text = "Enter Email" Or
           TextBox6.Text = "Enter Password" Or
           TextBox7.Text = "Confirm Password" Then

            MessageBox.Show("Please fill all fields!", "Error")
            Exit Sub
        End If

        If TextBox6.Text <> TextBox7.Text Then
            MessageBox.Show("Passwords do not match!", "Error")
            Exit Sub
        End If

        MessageBox.Show("Account Created Successfully!", "Success")

        Dim login As New frmLogin
        login.Show()
        Me.Hide()

    End Sub

    ' ================= CANCEL BUTTON =================
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim result = MessageBox.Show("Cancel registration?", "Confirm", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Dim login As New frmLogin
            login.Show()
            Me.Hide()
        End If

    End Sub

End Class