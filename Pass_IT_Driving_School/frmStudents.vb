Public Class frmStudents

    Private Sub frmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Placeholder Text
        TextBox1.Text = "Student Number"
        TextBox2.Text = "First Name"
        TextBox3.Text = "Last Name"
        TextBox5.Text = "Phone Number"
        TextBox6.Text = "Email Address"
        TextBox8.Text = "Status"
        RichTextBox1.Text = "Address"

        ' Instructor Dropdown
        ComboBox1.Items.Add("Mark Wilson")
        ComboBox1.Items.Add("David Brown")
        ComboBox1.Items.Add("Lisa Taylor")
        ComboBox1.Text = "Select Instructor"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Delete Clicked")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        RichTextBox1.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = "Select Instructor"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Student Saved Successfully")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
        Dim g As Graphics = e.Graphics
        Dim headers() As String = {"Student ID", "Full Name", "Phone", "Status"}
        Dim data(,) As String = {
            {"ST001", "John Smith", "07123456789", "Active"},
            {"ST002", "Sarah Johnson", "07987654321", "Active"},
            {"ST003", "Michael Lee", "07451239876", "Active"},
            {"ST004", "Emily Davis", "07894561234", "Active"},
            {"ST005", "James Wilson", "07112233445", "Inactive"}
        }

        Dim colWidth As Integer = TableLayoutPanel1.Width \ 4
        Dim rowHeight As Integer = 30
        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim rowFont As New Font("Segoe UI", 9)
        Dim headerBrush As New SolidBrush(Color.FromArgb(0, 120, 215))
        Dim headerTextBrush As New SolidBrush(Color.White)
        Dim rowBrush1 As New SolidBrush(Color.White)
        Dim rowBrush2 As New SolidBrush(Color.FromArgb(240, 240, 240))
        Dim textBrush As New SolidBrush(Color.Black)
        Dim borderPen As New Pen(Color.LightGray)

        For col As Integer = 0 To 3
            Dim rect As New Rectangle(col * colWidth, 0, colWidth, rowHeight)
            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(borderPen, rect)
            g.DrawString(headers(col), headerFont, headerTextBrush, rect.X + 5, rect.Y + 8)
        Next

        For row As Integer = 0 To 4
            Dim bg As SolidBrush = If(row Mod 2 = 0, rowBrush1, rowBrush2)
            For col As Integer = 0 To 3
                Dim rect As New Rectangle(col * colWidth, (row + 1) * rowHeight, colWidth, rowHeight)
                g.FillRectangle(bg, rect)
                g.DrawRectangle(borderPen, rect)
                g.DrawString(data(row, col), rowFont, textBrush, rect.X + 5, rect.Y + 8)
            Next
        Next

        headerFont.Dispose()
        rowFont.Dispose()
        headerBrush.Dispose()
        headerTextBrush.Dispose()
        rowBrush1.Dispose()
        rowBrush2.Dispose()
        textBrush.Dispose()
        borderPen.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dashboard As New frmDashboard()
        dashboard.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    End Sub

End Class