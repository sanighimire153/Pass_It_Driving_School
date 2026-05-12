Public Class frmStudents

    Private Sub frmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' =====================================================
        ' FORM SETTINGS
        ' =====================================================

        Me.Text = "Students"
        Me.BackColor = Color.White
        Me.WindowState = FormWindowState.Maximized
        Me.Font = New Font("Segoe UI", 9)

        ' =====================================================
        ' LEFT SIDE MENU
        ' =====================================================

        Dim sideMenu As New Panel
        sideMenu.Width = 220
        sideMenu.Dock = DockStyle.Left
        sideMenu.BackColor = Color.FromArgb(30, 30, 30)
        Me.Controls.Add(sideMenu)

        ' ===== MENU TITLE =====
        Dim lblMenu As New Label
        lblMenu.Text = "STUDENT SYSTEM"
        lblMenu.ForeColor = Color.White
        lblMenu.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblMenu.Location = New Point(20, 20)
        lblMenu.AutoSize = True
        sideMenu.Controls.Add(lblMenu)

        ' =====================================================
        ' MENU BUTTON FUNCTION
        ' =====================================================

        Dim CreateMenuButton =
            Function(text As String, top As Integer) As Button

                Dim btn As New Button

                btn.Text = text
                btn.Size = New Size(180, 45)
                btn.Location = New Point(20, top)

                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0

                btn.BackColor = Color.FromArgb(45, 45, 45)
                btn.ForeColor = Color.White

                btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                btn.Cursor = Cursors.Hand

                Return btn

            End Function

        ' =====================================================
        ' MENU BUTTONS
        ' =====================================================

        Dim btnDashboard = CreateMenuButton("Dashboard", 80)
        Dim btnStudents = CreateMenuButton("Students", 140)
        Dim btnInstructors = CreateMenuButton("Instructors", 200)
        Dim btnLessons = CreateMenuButton("Lessons", 260)
        Dim btnExit = CreateMenuButton("Exit", 320)

        sideMenu.Controls.Add(btnDashboard)
        sideMenu.Controls.Add(btnStudents)
        sideMenu.Controls.Add(btnInstructors)
        sideMenu.Controls.Add(btnLessons)
        sideMenu.Controls.Add(btnExit)

        ' =====================================================
        ' MENU EVENTS
        ' =====================================================

        AddHandler btnDashboard.Click,
            Sub()
                Dim f As New frmDashboard
                f.Show()
                Me.Hide()
            End Sub

        AddHandler btnInstructors.Click,
            Sub()
                Dim f As New frmInstructors
                f.Show()
                Me.Hide()
            End Sub

        AddHandler btnLessons.Click,
            Sub()
                Dim f As New frmLessons
                f.Show()
                Me.Hide()
            End Sub

        AddHandler btnExit.Click,
            Sub()
                Application.Exit()
            End Sub

        ' =====================================================
        ' PLACEHOLDER TEXT
        ' =====================================================

        TextBox1.Text = "Student Number"
        TextBox2.Text = "First Name"
        TextBox3.Text = "Last Name"
        TextBox5.Text = "Phone Number"
        TextBox6.Text = "Email Address"
        TextBox8.Text = "Status"

        RichTextBox1.Text = "Address"

        ' =====================================================
        ' INSTRUCTOR DROPDOWN
        ' =====================================================

        ComboBox1.Items.Add("Mark Wilson")
        ComboBox1.Items.Add("David Brown")
        ComboBox1.Items.Add("Lisa Taylor")

        ComboBox1.Text = "Select Instructor"

    End Sub

    ' =====================================================
    ' SAVE BUTTON
    ' =====================================================

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MessageBox.Show(
            "Student Saved Successfully",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub

    ' =====================================================
    ' CLEAR BUTTON
    ' =====================================================

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()

        RichTextBox1.Clear()

        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = "Select Instructor"

    End Sub

    ' =====================================================
    ' DELETE BUTTON
    ' =====================================================

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        MessageBox.Show(
            "Delete Clicked",
            "Delete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )

    End Sub

    ' =====================================================
    ' TABLE DESIGN
    ' =====================================================

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

        Dim g As Graphics = e.Graphics

        Dim headers() As String =
            {"Student ID", "Full Name", "Phone", "Status"}

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

        ' ===== HEADERS =====
        For col As Integer = 0 To 3

            Dim rect As New Rectangle(
                col * colWidth,
                0,
                colWidth,
                rowHeight
            )

            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(borderPen, rect)

            g.DrawString(
                headers(col),
                headerFont,
                headerTextBrush,
                rect.X + 5,
                rect.Y + 8
            )

        Next

        ' ===== ROWS =====
        For row As Integer = 0 To 4

            Dim bg As SolidBrush =
                If(row Mod 2 = 0, rowBrush1, rowBrush2)

            For col As Integer = 0 To 3

                Dim rect As New Rectangle(
                    col * colWidth,
                    (row + 1) * rowHeight,
                    colWidth,
                    rowHeight
                )

                g.FillRectangle(bg, rect)
                g.DrawRectangle(borderPen, rect)

                g.DrawString(
                    data(row, col),
                    rowFont,
                    textBrush,
                    rect.X + 5,
                    rect.Y + 8
                )

            Next

        Next

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class