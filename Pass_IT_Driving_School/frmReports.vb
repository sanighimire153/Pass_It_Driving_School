Public Class frmReports

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ================= FORM SETTINGS =================
        Me.Text = "Reports"
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

        ' ================= MENU BUTTON FACTORY =================
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

    End Sub

End Class