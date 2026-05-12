Public Class frmInstructors

    ' =====================================================
    ' DATA STORAGE (5 COLUMNS)
    ' Name | Email | Phone | Course | Cost
    ' =====================================================
    Private instructorTable As New List(Of String())

    ' =====================================================
    ' FORM LOAD
    ' =====================================================
    Private Sub frmInstructors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ================= FORM SETTINGS =================
        Me.Text = "Instructors"
        Me.BackColor = Color.White
        Me.WindowState = FormWindowState.Maximized
        Me.Font = New Font("Segoe UI", 9)

        ' ================= LEFT MENU =================
        Dim sideMenu As New Panel
        sideMenu.Width = 220
        sideMenu.Dock = DockStyle.Left
        sideMenu.BackColor = Color.FromArgb(30, 30, 30)
        Me.Controls.Add(sideMenu)

        Dim lblMenu As New Label
        lblMenu.Text = ""
        lblMenu.ForeColor = Color.White
        lblMenu.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblMenu.Location = New Point(20, 20)
        lblMenu.AutoSize = True
        sideMenu.Controls.Add(lblMenu)

        ' ================= MENU BUTTON =================
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

        ' ================= MENU BUTTONS =================
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

        ' ================= MENU EVENTS =================
        AddHandler btnDashboard.Click, Sub()
                                           Dim f As New frmDashboard
                                           f.Show()
                                           Me.Hide()
                                       End Sub

        AddHandler btnInstructors.Click, Sub()
                                             Dim f As New frmInstructors
                                             f.Show()
                                             Me.Hide()
                                         End Sub

        AddHandler btnLessons.Click, Sub()
                                         Dim f As New frmLessons
                                         f.Show()
                                         Me.Hide()
                                     End Sub

        AddHandler btnExit.Click, Sub()
                                      Application.Exit()
                                  End Sub

        ' ================= PLACEHOLDERS =================
        TextBox1.Text = "Instructor ID"
        TextBox2.Text = " Last Name"
        TextBox3.Text = "Email"
        TextBox5.Text = "Phone"
        TextBox6.Text = "Address"
        TextBox7.Text = "First Name"
        TextBox8.Text = "Qualification"
        TextBox9.Text = "Cost"

        ' ================= COURSE LIST =================
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Software Engineering")
        ComboBox1.Items.Add("Networking")
        ComboBox1.Items.Add("Database")
        ComboBox1.Items.Add("Cyber Security")
        ComboBox1.Items.Add("AI & ML")
        ComboBox1.Text = "Select Course"

        ' ================= SAMPLE DATA =================
        instructorTable.Add(New String() {"John Smith", "john@gmail.com", "07123456789", "Networking", "1000"})
        instructorTable.Add(New String() {"Sarah Johnson", "sarah@gmail.com", "07987654321", "Database", "1200"})
        instructorTable.Add(New String() {"David Brown", "david@gmail.com", "07451239876", "AI & ML", "1500"})

    End Sub

    ' =====================================================
    ' SAVE
    ' =====================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        instructorTable.Add(New String() {
            TextBox2.Text,
            TextBox5.Text,
            TextBox3.Text,
            ComboBox1.Text,
            TextBox9.Text
        })

        TableLayoutPanel1.Invalidate()

        MessageBox.Show("Instructor Saved Successfully")
    End Sub

    ' =====================================================
    ' CLEAR
    ' =====================================================
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox9.Clear()
        ComboBox1.SelectedIndex = -1

    End Sub

    ' =====================================================
    ' DELETE LAST
    ' =====================================================
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If instructorTable.Count > 0 Then
            instructorTable.RemoveAt(instructorTable.Count - 1)
            TableLayoutPanel1.Invalidate()
        Else
            MessageBox.Show("No Data to Delete")
        End If

    End Sub

    ' =====================================================
    ' TABLE DRAW (5 COLUMNS)
    ' =====================================================
    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

        Dim g As Graphics = e.Graphics

        Dim headers() As String = {"Name", "Email", "Phone", "Course", "Cost"}

        Dim colWidth As Integer = TableLayoutPanel1.Width \ 5
        Dim rowHeight As Integer = 35

        Dim headerBrush As New SolidBrush(Color.DarkBlue)
        Dim headerText As New SolidBrush(Color.White)
        Dim rowBrush1 As New SolidBrush(Color.White)
        Dim rowBrush2 As New SolidBrush(Color.FromArgb(240, 240, 240))
        Dim textBrush As New SolidBrush(Color.Black)
        Dim pen As New Pen(Color.LightGray)

        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim rowFont As New Font("Segoe UI", 9)

        ' ================= HEADERS =================
        For i As Integer = 0 To 4
            Dim rect As New Rectangle(i * colWidth, 0, colWidth, rowHeight)
            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(pen, rect)
            g.DrawString(headers(i), headerFont, headerText, rect.X + 5, rect.Y + 10)
        Next

        ' ================= ROWS =================
        For r As Integer = 0 To instructorTable.Count - 1

            Dim bg As Brush = If(r Mod 2 = 0, rowBrush1, rowBrush2)

            For c As Integer = 0 To 4

                Dim rect As New Rectangle(c * colWidth, (r + 1) * rowHeight, colWidth, rowHeight)

                g.FillRectangle(bg, rect)
                g.DrawRectangle(pen, rect)

                g.DrawString(instructorTable(r)(c),
                             rowFont,
                             textBrush,
                             rect.X + 5,
                             rect.Y + 10)

            Next

        Next

    End Sub


End Class