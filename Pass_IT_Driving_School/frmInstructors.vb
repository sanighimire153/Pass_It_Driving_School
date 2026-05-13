Public Class frmInstructors

    Private instructorTable As New List(Of String())

    ' =====================================================
    ' PLACEHOLDER FUNCTION
    ' =====================================================
    Private Sub SetPlaceholder(txt As TextBox, placeholder As String)

        txt.Tag = placeholder
        txt.Text = placeholder
        txt.ForeColor = Color.Gray

        AddHandler txt.Enter, Sub()
                                  If txt.Text = txt.Tag.ToString() Then
                                      txt.Text = ""
                                      txt.ForeColor = Color.Black
                                  End If
                              End Sub

        AddHandler txt.Leave, Sub()
                                  If txt.Text = "" Then
                                      txt.Text = txt.Tag.ToString()
                                      txt.ForeColor = Color.Gray
                                  End If
                              End Sub

    End Sub

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
        Dim btnBooking = CreateMenuButton("Booking", 320)
        Dim btnSearch = CreateMenuButton("Search", 380)
        Dim btnReports = CreateMenuButton("Reports", 440)

        sideMenu.Controls.Add(btnDashboard)
        sideMenu.Controls.Add(btnStudents)
        sideMenu.Controls.Add(btnInstructors)
        sideMenu.Controls.Add(btnLessons)
        sideMenu.Controls.Add(btnBooking)
        sideMenu.Controls.Add(btnSearch)
        sideMenu.Controls.Add(btnReports)

        ' ================= MENU EVENTS =================
        AddHandler btnDashboard.Click, Sub()
                                           Dim f As New frmDashboard
                                           f.Show()
                                           Me.Hide()
                                       End Sub

        AddHandler btnStudents.Click, Sub()
                                          Dim f As New frmStudents
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

        AddHandler btnBooking.Click, Sub()
                                         Dim f As New frmBooking
                                         f.Show()
                                         Me.Hide()
                                     End Sub

        AddHandler btnSearch.Click, Sub()
                                        Dim f As New frmSearch
                                        f.Show()
                                        Me.Hide()
                                    End Sub

        AddHandler btnReports.Click, Sub()
                                         Dim f As New frmReports
                                         f.Show()
                                         Me.Hide()
                                     End Sub

        ' ================= PLACEHOLDERS =================
        SetPlaceholder(TextBox1, "Instructor ID")
        SetPlaceholder(TextBox7, "First Name")
        SetPlaceholder(TextBox2, "Last Name")
        SetPlaceholder(TextBox3, "Email")
        SetPlaceholder(TextBox5, "Phone")
        SetPlaceholder(TextBox6, "Address")
        SetPlaceholder(TextBox8, "Qualification")
        SetPlaceholder(TextBox9, "Cost")

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
        instructorTable.Add(New String() {"David Brown", "07451239876", "AI & ML", "1500", ""})

    End Sub

    ' =====================================================
    ' SAVE
    ' =====================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox7.Text = TextBox7.Tag.ToString() OrElse
           TextBox3.Text = TextBox3.Tag.ToString() OrElse
           TextBox5.Text = TextBox5.Tag.ToString() OrElse
           TextBox9.Text = TextBox9.Tag.ToString() Then

            MessageBox.Show("Please fill all fields properly")
            Exit Sub

        End If

        instructorTable.Add(New String() {
            TextBox7.Text,
            TextBox3.Text,
            TextBox5.Text,
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

        SetPlaceholder(TextBox1, "Instructor ID")
        SetPlaceholder(TextBox7, "First Name")
        SetPlaceholder(TextBox2, "Last Name")
        SetPlaceholder(TextBox3, "Email")
        SetPlaceholder(TextBox5, "Phone")
        SetPlaceholder(TextBox6, "Address")
        SetPlaceholder(TextBox8, "Qualification")
        SetPlaceholder(TextBox9, "Cost")

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
    ' TABLE DRAW
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

        For i As Integer = 0 To 4
            Dim rect As New Rectangle(i * colWidth, 0, colWidth, rowHeight)
            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(pen, rect)
            g.DrawString(headers(i), headerFont, headerText, rect.X + 5, rect.Y + 10)
        Next

        For r As Integer = 0 To instructorTable.Count - 1

            Dim bg As Brush = If(r Mod 2 = 0, rowBrush1, rowBrush2)

            For c As Integer = 0 To 4

                Dim rect As New Rectangle(c * colWidth,
                                           (r + 1) * rowHeight,
                                           colWidth,
                                           rowHeight)

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