Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class frmDashboard

    Private graphPanel As Panel

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' =====================================================
        ' FORM SETTINGS
        ' =====================================================
        Me.Text = "Dashboard"
        Me.WindowState = FormWindowState.Maximized
        Me.Font = New Font("Segoe UI", 9)
        Me.BackColor = Color.FromArgb(245, 247, 250)

        ' =====================================================
        ' LEFT MENU
        ' =====================================================

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

        ' =====================================================
        ' MENU BUTTONS
        ' =====================================================

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

        ' =====================================================
        ' MENU EVENTS
        ' =====================================================

        AddHandler btnDashboard.Click, Sub()
                                           MessageBox.Show("You are already on Dashboard.")
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


        ' =====================================================
        ' GRAPH PANEL (GLASS STYLE LOOK)
        ' =====================================================
        graphPanel = New Panel
        graphPanel.Location = New Point(260, 50)
        graphPanel.Size = New Size(650, 340)

        ' fake transparency (clean modern card look)
        graphPanel.BackColor = Color.FromArgb(240, 255, 255, 255)
        graphPanel.BorderStyle = BorderStyle.None

        AddHandler graphPanel.Paint, AddressOf DrawGraphStatic
        Me.Controls.Add(graphPanel)

        ' =====================================================
        ' STATIC TABLES (NO DATA LOGIC CHANGES)
        ' =====================================================

        Dim dgvStudents As New DataGridView
        StyleGrid(dgvStudents)
        dgvStudents.Location = New Point(260, 420)
        dgvStudents.Size = New Size(650, 220)

        dgvStudents.ColumnCount = 5
        dgvStudents.Columns(0).Name = "First Name"
        dgvStudents.Columns(1).Name = "Last Name"
        dgvStudents.Columns(2).Name = "Address"
        dgvStudents.Columns(3).Name = "Email"
        dgvStudents.Columns(4).Name = "Phone"

        dgvStudents.Rows.Add("John", "Smith", "London", "john@email.com", "07123456789")
        dgvStudents.Rows.Add("Emma", "Brown", "Reading", "emma@email.com", "07234567890")

        Me.Controls.Add(dgvStudents)

        Dim dgvInstructors As New DataGridView
        StyleGrid(dgvInstructors)
        dgvInstructors.Location = New Point(940, 50)
        dgvInstructors.Size = New Size(450, 200)

        dgvInstructors.ColumnCount = 4
        dgvInstructors.Columns(0).Name = "First Name"
        dgvInstructors.Columns(1).Name = "Last Name"
        dgvInstructors.Columns(2).Name = "Address"
        dgvInstructors.Columns(3).Name = "Phone"

        dgvInstructors.Rows.Add("Mark", "Wilson", "London", "07000000001")
        dgvInstructors.Rows.Add("David", "Brown", "Oxford", "07000000002")

        Me.Controls.Add(dgvInstructors)

        Dim dgvCourses As New DataGridView
        StyleGrid(dgvCourses)
        dgvCourses.Location = New Point(940, 280)
        dgvCourses.Size = New Size(450, 200)

        dgvCourses.ColumnCount = 3
        dgvCourses.Columns(0).Name = "Course"
        dgvCourses.Columns(1).Name = "Cost"
        dgvCourses.Columns(2).Name = "Duration"

        dgvCourses.Rows.Add("Driving Basics", "£200", "4 Weeks")
        dgvCourses.Rows.Add("Advanced Driving", "£350", "6 Weeks")

        Me.Controls.Add(dgvCourses)

    End Sub

    ' =====================================================
    ' STATIC MODERN GRAPH (IMPROVED LOOK ONLY)
    ' =====================================================
    Private Sub DrawGraphStatic(sender As Object, e As PaintEventArgs)

        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim data() As Integer = {10, 15, 8, 20}
        Dim labels() As String = {"Jan", "Feb", "Mar", "Apr"}

        Dim maxVal As Integer = 25
        Dim baseY As Integer = graphPanel.Height - 60
        Dim chartTop As Integer = 40

        Dim barWidth As Integer = 90
        Dim spacing As Integer = 40
        Dim startX As Integer = 60

        ' GRID
        For i As Integer = 0 To 5
            Dim y As Integer = chartTop + (i * (baseY - chartTop) / 5)
            g.DrawLine(New Pen(Color.FromArgb(220, 220, 220)), 40, y, graphPanel.Width - 20, y)
        Next

        ' AXIS
        g.DrawLine(Pens.Gray, 40, chartTop, 40, baseY)
        g.DrawLine(Pens.Gray, 40, baseY, graphPanel.Width - 20, baseY)

        ' BARS
        For i As Integer = 0 To data.Length - 1

            Dim value As Integer = data(i)
            Dim height As Integer = CInt((value / maxVal) * (baseY - chartTop))

            Dim x As Integer = startX + (i * (barWidth + spacing))
            Dim y As Integer = baseY - height

            Dim rect As New Rectangle(x, y, barWidth, height)

            Using br As New LinearGradientBrush(
                rect,
                Color.FromArgb(80, 140, 255),
                Color.FromArgb(30, 80, 200),
                LinearGradientMode.Vertical)

                FillRounded(g, br, rect, 14)
            End Using

            g.DrawString(value.ToString(),
                         New Font("Segoe UI", 9, FontStyle.Bold),
                         Brushes.Black,
                         x + 30, y - 20)

            g.DrawString(labels(i),
                         New Font("Segoe UI", 9),
                         Brushes.DimGray,
                         x + 30, baseY + 10)

        Next

    End Sub

    ' =====================================================
    ' GRID STYLE (UNCHANGED CLEAN LOOK)
    ' =====================================================
    Private Sub StyleGrid(dgv As DataGridView)

        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.RowHeadersVisible = False
        dgv.BorderStyle = BorderStyle.None
        dgv.BackgroundColor = Color.White
        dgv.GridColor = Color.LightGray
        dgv.EnableHeadersVisualStyles = False

        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)

    End Sub

    ' =====================================================
    ' ROUNDED RECTANGLE
    ' =====================================================
    Private Sub FillRounded(g As Graphics, br As Brush, rect As Rectangle, radius As Integer)

        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2

        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()

        g.FillPath(br, path)

    End Sub

End Class