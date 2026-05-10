Public Class frmDashboard

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ===== FORM SETTINGS =====
        Me.Text = "Dashboard"
        Me.BackColor = Color.White
        Me.WindowState = FormWindowState.Maximized

        ' ===== MAIN CONTAINER =====
        Dim mainPanel As New Panel
        mainPanel.Dock = DockStyle.Fill
        mainPanel.Padding = New Padding(20)
        Me.Controls.Add(mainPanel)

        ' ===== LEFT PANEL (CARDS) =====
        Dim leftPanel As New FlowLayoutPanel
        leftPanel.Width = 700
        leftPanel.Dock = DockStyle.Left
        leftPanel.FlowDirection = FlowDirection.LeftToRight
        leftPanel.WrapContents = True
        leftPanel.AutoScroll = True
        leftPanel.Padding = New Padding(10)
        mainPanel.Controls.Add(leftPanel)

        ' ===== RIGHT PANEL (ACTIONS) =====
        Dim rightPanel As New Panel
        rightPanel.Width = 300
        rightPanel.Dock = DockStyle.Right
        rightPanel.BackColor = Color.WhiteSmoke
        rightPanel.Padding = New Padding(20)
        mainPanel.Controls.Add(rightPanel)

        ' ===== FUNCTION TO CREATE CARDS =====
        Dim CreateCard = Function(title As String, value As String, color As Color) As GroupBox
                             Dim g As New GroupBox
                             g.Text = title
                             g.Size = New Size(200, 130)
                             g.Font = New Font("Segoe UI", 10, FontStyle.Bold)

                             Dim lblValue As New Label
                             lblValue.Text = value
                             lblValue.Font = New Font("Segoe UI", 22, FontStyle.Bold)
                             lblValue.ForeColor = color
                             lblValue.Location = New Point(20, 30)
                             lblValue.AutoSize = True

                             Dim lblText As New Label
                             lblText.Text = title
                             lblText.Location = New Point(20, 80)
                             lblText.AutoSize = True

                             g.Controls.Add(lblValue)
                             g.Controls.Add(lblText)

                             Return g
                         End Function

        ' ===== ADD CARDS =====
        Dim card1 = CreateCard("Students", "45", Color.RoyalBlue)
        Dim card2 = CreateCard("Instructors", "12", Color.Green)
        Dim card3 = CreateCard("Lessons Today", "6", Color.DarkOrange)

        leftPanel.Controls.Add(card1)
        leftPanel.Controls.Add(card2)
        leftPanel.Controls.Add(card3)

        AddHandler card1.Click, AddressOf OpenStudents
        AddHandler card2.Click, AddressOf OpenInstructors
        AddHandler card3.Click, AddressOf OpenLessons

        ' ===== ACTION BUTTON FUNCTION =====
        Dim CreateButton = Function(text As String, color As Color, top As Integer) As Button
                               Dim btn As New Button
                               btn.Text = text
                               btn.Size = New Size(220, 45)
                               btn.Location = New Point(20, top)
                               btn.BackColor = color
                               btn.ForeColor = Color.White
                               btn.FlatStyle = FlatStyle.Flat
                               Return btn
                           End Function

        ' ===== ADD BUTTONS =====
        Dim btnBook = CreateButton("Course Lesson", Color.RoyalBlue, 20)
        Dim btnStudent = CreateButton("Add Student", Color.SeaGreen, 80)
        Dim btnInstructor = CreateButton("Add Instructor", Color.DarkOrange, 140)

        rightPanel.Controls.Add(btnBook)
        rightPanel.Controls.Add(btnStudent)
        rightPanel.Controls.Add(btnInstructor)

        AddHandler btnBook.Click, AddressOf OpenLessons
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

End Class