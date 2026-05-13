Imports System.Drawing
Imports System.Windows.Forms

Public Class frmReports

    ' =====================================================
    ' GLOBAL VARIABLES
    ' =====================================================

    Private dgvReports As New DataGridView
    Private reportData As New List(Of String())

    Private txtSearch As New TextBox
    Private cmbCategory As New ComboBox
    Private btnSearch As New Button

    Private menuWidth As Integer = 220

    ' =====================================================
    ' FORM LOAD
    ' =====================================================

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' =====================================================
        ' FORM SETTINGS
        ' =====================================================

        Me.Text = "Reports"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.WhiteSmoke
        Me.Font = New Font("Segoe UI", 9)

        ' =====================================================
        ' SAMPLE STATIC DATA
        ' =====================================================

        reportData.Add(New String() {"1001", "John Smith", "Student", "20", "18", "90%", "Passed"})
        reportData.Add(New String() {"1002", "Sarah Johnson", "Student", "15", "12", "80%", "Passed"})
        reportData.Add(New String() {"1003", "Michael Brown", "Student", "12", "6", "50%", "In Progress"})
        reportData.Add(New String() {"1004", "Emma Wilson", "Student", "25", "25", "100%", "Completed"})
        reportData.Add(New String() {"1005", "David Miller", "Student", "18", "10", "55%", "Needs Practice"})
        reportData.Add(New String() {"1006", "Sophia Taylor", "Student", "30", "28", "93%", "Excellent"})
        reportData.Add(New String() {"1007", "Daniel Anderson", "Student", "10", "4", "40%", "Weak"})
        reportData.Add(New String() {"1008", "Olivia Thomas", "Student", "22", "20", "91%", "Passed"})

        ' =====================================================
        ' SIDE MENU
        ' =====================================================

        Dim sideMenu As New Panel

        sideMenu.Width = menuWidth
        sideMenu.Dock = DockStyle.Left
        sideMenu.BackColor = Color.FromArgb(25, 25, 35)

        Me.Controls.Add(sideMenu)

        ' =====================================================
        ' MENU TITLE
        ' =====================================================

        Dim lblTitle As New Label

        lblTitle.Text = "Driving School"
        lblTitle.ForeColor = Color.White
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 30)

        sideMenu.Controls.Add(lblTitle)

        ' =====================================================
        ' MENU BUTTON FUNCTION
        ' =====================================================

        Dim CreateMenuButton =
            Function(text As String, top As Integer) As Button

                Dim btn As New Button

                btn.Text = text
                btn.Size = New Size(180, 48)
                btn.Location = New Point(20, top)

                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0

                btn.BackColor = Color.FromArgb(45, 45, 55)
                btn.ForeColor = Color.White

                btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)

                btn.Cursor = Cursors.Hand

                AddHandler btn.MouseEnter,
                    Sub()
                        btn.BackColor = Color.FromArgb(0, 120, 215)
                    End Sub

                AddHandler btn.MouseLeave,
                    Sub()
                        btn.BackColor = Color.FromArgb(45, 45, 55)
                    End Sub

                Return btn

            End Function

        ' =====================================================
        ' MENU BUTTONS
        ' =====================================================

        Dim btnDashboard = CreateMenuButton("Dashboard", 100)
        Dim btnStudents = CreateMenuButton("Students", 160)
        Dim btnInstructors = CreateMenuButton("Instructors", 220)
        Dim btnLessons = CreateMenuButton("Lessons", 280)
        Dim btnBooking = CreateMenuButton("Booking", 340)
        Dim btnSearchMenu = CreateMenuButton("Search", 400)
        Dim btnReports = CreateMenuButton("Reports", 460)

        sideMenu.Controls.Add(btnDashboard)
        sideMenu.Controls.Add(btnStudents)
        sideMenu.Controls.Add(btnInstructors)
        sideMenu.Controls.Add(btnLessons)
        sideMenu.Controls.Add(btnBooking)
        sideMenu.Controls.Add(btnSearchMenu)
        sideMenu.Controls.Add(btnReports)

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
                Dim f As New frmLessons
                f.Show()
                Me.Hide()
            End Sub

        AddHandler btnBooking.Click,
            Sub()
                Dim f As New frmBooking
                f.Show()
                Me.Hide()
            End Sub

        AddHandler btnSearchMenu.Click,
            Sub()
                Dim f As New frmSearch
                f.Show()
                Me.Hide()
            End Sub

        AddHandler btnReports.Click,
            Sub()
                MessageBox.Show("You are already on Reports page.")
            End Sub




        ' =====================================================
        ' SEARCH BOX
        ' =====================================================

        txtSearch.Location = New Point(menuWidth + 30, 90)
        txtSearch.Size = New Size(300, 35)

        txtSearch.Font = New Font("Segoe UI", 11)
        txtSearch.PlaceholderText = "Search by ID or Name"

        Me.Controls.Add(txtSearch)

        ' =====================================================
        ' CATEGORY COMBOBOX
        ' =====================================================

        cmbCategory.Location = New Point(menuWidth + 350, 90)
        cmbCategory.Size = New Size(180, 35)

        cmbCategory.Font = New Font("Segoe UI", 10)

        cmbCategory.Items.Add("All")
        cmbCategory.Items.Add("Passed")
        cmbCategory.Items.Add("In Progress")
        cmbCategory.Items.Add("Completed")
        cmbCategory.Items.Add("Needs Practice")
        cmbCategory.Items.Add("Excellent")
        cmbCategory.Items.Add("Weak")

        cmbCategory.SelectedIndex = 0

        Me.Controls.Add(cmbCategory)

        ' =====================================================
        ' SEARCH BUTTON
        ' =====================================================

        btnSearch.Text = "SEARCH"

        btnSearch.Location = New Point(menuWidth + 560, 85)
        btnSearch.Size = New Size(170, 45)

        btnSearch.BackColor = Color.FromArgb(0, 120, 215)
        btnSearch.ForeColor = Color.White

        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.FlatAppearance.BorderSize = 0

        btnSearch.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        btnSearch.Cursor = Cursors.Hand

        AddHandler btnSearch.MouseEnter,
            Sub()
                btnSearch.BackColor = Color.FromArgb(0, 90, 180)
            End Sub

        AddHandler btnSearch.MouseLeave,
            Sub()
                btnSearch.BackColor = Color.FromArgb(0, 120, 215)
            End Sub

        Me.Controls.Add(btnSearch)

        ' =====================================================
        ' DATAGRIDVIEW
        ' =====================================================

        dgvReports.Location = New Point(menuWidth + 30, 160)

        dgvReports.Size =
            New Size(Me.ClientSize.Width - menuWidth - 60,
                     Me.ClientSize.Height - 230)

        dgvReports.Anchor =
            AnchorStyles.Top Or AnchorStyles.Bottom Or
            AnchorStyles.Left Or AnchorStyles.Right

        dgvReports.BackgroundColor = Color.White
        dgvReports.BorderStyle = BorderStyle.None

        dgvReports.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvReports.RowTemplate.Height = 40

        dgvReports.AllowUserToAddRows = False
        dgvReports.AllowUserToResizeRows = False

        dgvReports.ReadOnly = True
        dgvReports.MultiSelect = False

        dgvReports.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvReports.RowHeadersVisible = False

        dgvReports.EnableHeadersVisualStyles = False

        dgvReports.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(0, 120, 215)

        dgvReports.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.White

        dgvReports.ColumnHeadersDefaultCellStyle.Font =
            New Font("Segoe UI", 10, FontStyle.Bold)

        dgvReports.ColumnHeadersHeight = 40

        dgvReports.DefaultCellStyle.Font =
            New Font("Segoe UI", 10)

        dgvReports.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter

        dgvReports.DefaultCellStyle.SelectionBackColor =
            Color.LightBlue

        dgvReports.DefaultCellStyle.SelectionForeColor =
            Color.Black

        dgvReports.GridColor = Color.LightGray

        ' =====================================================
        ' COLUMNS
        ' =====================================================

        dgvReports.Columns.Clear()

        dgvReports.Columns.Add("ID", "Student ID")
        dgvReports.Columns.Add("NAME", "Student Name")
        dgvReports.Columns.Add("TYPE", "Type")
        dgvReports.Columns.Add("TOTAL", "Total Lessons")
        dgvReports.Columns.Add("COMPLETED", "Completed")
        dgvReports.Columns.Add("PROGRESS", "Progress")
        dgvReports.Columns.Add("STATUS", "Status")

        Me.Controls.Add(dgvReports)

        ' =====================================================
        ' LOAD DATA
        ' =====================================================

        LoadData(reportData)

        ' =====================================================
        ' SEARCH EVENT
        ' =====================================================

        AddHandler btnSearch.Click, AddressOf SearchReports
        AddHandler txtSearch.TextChanged, AddressOf SearchReports

    End Sub

    ' =====================================================
    ' LOAD DATA
    ' =====================================================

    Private Sub LoadData(data As List(Of String()))

        dgvReports.Rows.Clear()

        For Each item In data

            dgvReports.Rows.Add(
                item(0),
                item(1),
                item(2),
                item(3),
                item(4),
                item(5),
                item(6)
            )

        Next

    End Sub

    ' =====================================================
    ' SEARCH FUNCTION
    ' =====================================================

    Private Sub SearchReports(sender As Object, e As EventArgs)

        Dim keyword As String =
            txtSearch.Text.Trim().ToLower()

        Dim category As String =
            cmbCategory.Text

        Dim results As New List(Of String())

        For Each item In reportData

            Dim id As String = item(0).ToLower()
            Dim name As String = item(1).ToLower()
            Dim status As String = item(6)

            Dim matchKeyword As Boolean =
                id.Contains(keyword) OrElse
                name.Contains(keyword)

            Dim matchCategory As Boolean =
                category = "All" OrElse
                status = category

            If matchKeyword AndAlso matchCategory Then
                results.Add(item)
            End If

        Next

        LoadData(results)

        If results.Count = 0 Then

            MessageBox.Show(
                "No matching reports found.",
                "Reports Search",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        End If

    End Sub

End Class