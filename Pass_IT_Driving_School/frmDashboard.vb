Public Class frmDashboard

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ===== FORM SETTINGS =====
        Me.Text = "Dashboard"
        Me.BackColor = Color.White
        Me.WindowState = FormWindowState.Maximized
        Me.Font = New Font("Segoe UI", 9)

        ' ===== MENU STRIP =====
        Dim menu As New MenuStrip
        menu.Dock = DockStyle.Top
        menu.BackColor = Color.WhiteSmoke
        menu.Font = New Font("Segoe UI", 10)

        ' ===== MENU ITEMS =====
        Dim mDashboard As New ToolStripMenuItem("Dashboard")
        Dim mStudents As New ToolStripMenuItem("Students")
        Dim mInstructors As New ToolStripMenuItem("Instructors")
        Dim mLessons As New ToolStripMenuItem("Lessons")
        Dim mExit As New ToolStripMenuItem("Exit")

        ' ===== ADD MENU ITEMS =====
        menu.Items.Add(mDashboard)
        menu.Items.Add(mStudents)
        menu.Items.Add(mInstructors)
        menu.Items.Add(mLessons)
        menu.Items.Add(mExit)

        ' ===== ADD MENU TO FORM =====
        Me.MainMenuStrip = menu
        Me.Controls.Add(menu)

        ' ===== MENU EVENTS =====
        AddHandler mStudents.Click, AddressOf OpenStudents
        AddHandler mInstructors.Click, AddressOf OpenInstructors
        AddHandler mLessons.Click, AddressOf OpenLessons

        AddHandler mExit.Click,
            Sub()
                Application.Exit()
            End Sub

        ' ===== MAIN CONTAINER =====
        Dim mainPanel As New Panel
        mainPanel.Dock = DockStyle.Fill
        mainPanel.Padding = New Padding(20)
        mainPanel.BackColor = Color.White
        Me.Controls.Add(mainPanel)

        ' ===== LEFT PANEL (CARDS) =====
        Dim leftPanel As New FlowLayoutPanel
        leftPanel.Width = 700
        leftPanel.Dock = DockStyle.Left
        leftPanel.FlowDirection = FlowDirection.LeftToRight
        leftPanel.WrapContents = True
        leftPanel.AutoScroll = True
        leftPanel.Padding = New Padding(10)
        leftPanel.BackColor = Color.White
        mainPanel.Controls.Add(leftPanel)

        ' ===== RIGHT PANEL =====
        Dim rightPanel As New Panel
        rightPanel.Width = 300
        rightPanel.Dock = DockStyle.Right
        rightPanel.BackColor = Color.WhiteSmoke
        rightPanel.Padding = New Padding(20)
        mainPanel.Controls.Add(rightPanel)

        ' ===== FUNCTION TO CREATE CARDS =====
        Dim CreateCard =
            Function(title As String, value As String, color As Color) As GroupBox

                Dim g As New GroupBox
                g.Text = title
                g.Size = New Size(220, 140)
                g.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                g.BackColor = Color.White

                Dim lblValue As New Label
                lblValue.Text = value
                lblValue.Font = New Font("Segoe UI", 24, FontStyle.Bold)
                lblValue.ForeColor = color
                lblValue.Location = New Point(20, 35)
                lblValue.AutoSize = True

                Dim lblText As New Label
                lblText.Text = title
                lblText.Font = New Font("Segoe UI", 10)
                lblText.Location = New Point(20, 90)
                lblText.AutoSize = True

                g.Controls.Add(lblValue)
                g.Controls.Add(lblText)

                Return g

            End Function

        ' ===== CREATE CARDS =====
        Dim card1 = CreateCard("Students", "45", Color.RoyalBlue)
        Dim card2 = CreateCard("Instructors", "12", Color.SeaGreen)
        Dim card3 = CreateCard("Lessons Today", "6", Color.DarkOrange)

        leftPanel.Controls.Add(card1)
        leftPanel.Controls.Add(card2)
        leftPanel.Controls.Add(card3)

        ' ===== CARD EVENTS =====
        AddHandler card1.Click, AddressOf OpenStudents
        AddHandler card2.Click, AddressOf OpenInstructors
        AddHandler card3.Click, AddressOf OpenLessons

        ' ===== FUNCTION TO CREATE BUTTONS =====
        Dim CreateButton =
            Function(text As String, color As Color, top As Integer) As Button

                Dim btn As New Button
                btn.Text = text
                btn.Size = New Size(220, 45)
                btn.Location = New Point(20, top)
                btn.BackColor = color
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                btn.Cursor = Cursors.Hand

                Return btn

            End Function

        ' ===== CREATE BUTTONS =====
        Dim btnLesson = CreateButton("Course Lesson", Color.RoyalBlue, 20)
        Dim btnStudent = CreateButton("Add Student", Color.SeaGreen, 80)
        Dim btnInstructor = CreateButton("Add Instructor", Color.DarkOrange, 140)

        rightPanel.Controls.Add(btnLesson)
        rightPanel.Controls.Add(btnStudent)
        rightPanel.Controls.Add(btnInstructor)

        ' ===== BUTTON EVENTS =====
        AddHandler btnLesson.Click, AddressOf OpenLessons
        AddHandler btnStudent.Click, AddressOf OpenStudents
        AddHandler btnInstructor.Click, AddressOf OpenInstructors

    End Sub

    ' ===== NAVIGATION =====

    Private Sub OpenStudents(sender As Object, e As EventArgs)

        Dim f As New frmStudents
        f.Show()
        Me.Hide()

    End Sub

    Private Sub OpenInstructors(sender As Object, e As EventArgs)

        Dim f As New frmInstructors
        f.Show()
        Me.Hide()

    End Sub

    Private Sub OpenLessons(sender As Object, e As EventArgs)

        Dim f As New frmLessons
        f.Show()
        Me.Hide()

    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening

    End Sub

End Class