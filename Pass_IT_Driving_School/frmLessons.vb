Public Class frmLessons

    Private Sub frmLessons_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' =====================================================
        ' FORM SETTINGS
        ' =====================================================

        Me.Text = "Lessons"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9)

        ' =====================================================
        ' LEFT SIDE MENU
        ' =====================================================

        Dim sideMenu As New Panel
        sideMenu.Width = 220
        sideMenu.Dock = DockStyle.Left
        sideMenu.BackColor = Color.FromArgb(30, 30, 30)
        Me.Controls.Add(sideMenu)

        ' =====================================================
        ' MENU TITLE
        ' =====================================================

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

        AddHandler btnStudents.Click,
            Sub()
                Dim f As New frmStudents
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
                MessageBox.Show("You are already in Lessons Form")
            End Sub

        AddHandler btnExit.Click,
            Sub()
                Application.Exit()
            End Sub

        ' =====================================================
        ' PAGE TITLE
        ' =====================================================

        Dim lblTitle As New Label
        lblTitle.Text = "LESSONS MANAGEMENT"
        lblTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(260, 30)
        lblTitle.AutoSize = True
        Me.Controls.Add(lblTitle)

    End Sub

End Class