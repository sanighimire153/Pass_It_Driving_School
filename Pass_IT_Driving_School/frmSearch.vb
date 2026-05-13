
Public Class frmSearch

    ' =====================================================
    ' GLOBAL VARIABLES
    ' =====================================================
    Private DataGridView1 As New DataGridView
    Private searchData As New List(Of String())

    Private menuWidth As Integer = 220

    ' =====================================================
    ' FORM LOAD
    ' =====================================================
    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' =====================================================
        ' FORM SETTINGS
        ' =====================================================
        Me.Text = "Search"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9)

        ' =====================================================
        ' SAMPLE DATA
        ' =====================================================
        searchData.Add(New String() {"1001", "John Smith", "Student"})
        searchData.Add(New String() {"1002", "Sarah Johnson", "Instructor"})
        searchData.Add(New String() {"1003", "Michael Brown", "Student"})
        searchData.Add(New String() {"1004", "Emma Wilson", "Lesson"})
        searchData.Add(New String() {"1005", "David Miller", "Booking"})
        searchData.Add(New String() {"1006", "Sophia Taylor", "Instructor"})
        searchData.Add(New String() {"1007", "Daniel Anderson", "Student"})
        searchData.Add(New String() {"1008", "Olivia Thomas", "Lesson"})

        ' =====================================================
        ' SIDE MENU
        ' =====================================================

        Dim sideMenu As New Panel
        sideMenu.Width = menuWidth
        sideMenu.Dock = DockStyle.Left
        sideMenu.BackColor = Color.FromArgb(30, 30, 30)
        Me.Controls.Add(sideMenu)

        ' =====================================================
        ' MENU TITLE
        ' =====================================================

        Dim lblTitle As New Label
        lblTitle.Text = "Driving School"
        lblTitle.ForeColor = Color.White
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 25)
        sideMenu.Controls.Add(lblTitle)

        ' =====================================================
        ' MENU BUTTON FACTORY
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

                AddHandler btn.MouseEnter,
                    Sub()
                        btn.BackColor = Color.FromArgb(0, 120, 215)
                    End Sub

                AddHandler btn.MouseLeave,
                    Sub()
                        btn.BackColor = Color.FromArgb(45, 45, 45)
                    End Sub

                Return btn

            End Function

        ' =====================================================
        ' MENU BUTTONS (FIXED + WORKING)
        ' =====================================================

        Dim btnDashboard = CreateMenuButton("Dashboard", 90)
        Dim btnStudents = CreateMenuButton("Students", 145)
        Dim btnInstructors = CreateMenuButton("Instructors", 200)
        Dim btnLessons = CreateMenuButton("Lessons", 255)
        Dim btnBooking = CreateMenuButton("Booking", 310)
        Dim btnSearch = CreateMenuButton("Search", 365)
        Dim btnReports = CreateMenuButton("Reports", 420)

        sideMenu.Controls.Add(btnDashboard)
        sideMenu.Controls.Add(btnStudents)
        sideMenu.Controls.Add(btnInstructors)
        sideMenu.Controls.Add(btnLessons)
        sideMenu.Controls.Add(btnBooking)
        sideMenu.Controls.Add(btnSearch)
        sideMenu.Controls.Add(btnReports)

        ' =====================================================
        ' MENU EVENTS (FIXED)
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

        AddHandler btnSearch.Click,
            Sub()
                MessageBox.Show("You are already on Search page.")
            End Sub

        AddHandler btnReports.Click,
            Sub()
                Dim f As New frmReports
                f.Show()
                Me.Hide()
            End Sub



        ' =====================================================
        ' SEARCH BOX
        ' =====================================================
        TextBox1.Location = New Point(menuWidth + 30, 80)
        TextBox1.Size = New Size(350, 35)
        TextBox1.Font = New Font("Segoe UI", 11)

        ' =====================================================
        ' COMBOBOX
        ' =====================================================
        ComboBox1.Location = New Point(menuWidth + 400, 80)
        ComboBox1.Size = New Size(180, 35)
        ComboBox1.Font = New Font("Segoe UI", 10)

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Student")
        ComboBox1.Items.Add("Instructor")
        ComboBox1.Items.Add("Lesson")
        ComboBox1.Items.Add("Booking")

        ComboBox1.SelectedIndex = 0

        ' =====================================================
        ' SEARCH BUTTON
        ' =====================================================
        Button1.Text = "SEARCH"
        Button1.Location = New Point(menuWidth + 600, 75)
        Button1.Size = New Size(170, 45)

        Button1.BackColor = Color.FromArgb(0, 120, 215)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Button1.Cursor = Cursors.Hand

        ' =====================================================
        ' DATAGRIDVIEW (FIXED)
        ' =====================================================
        DataGridView1.Location = New Point(menuWidth + 30, 150)

        DataGridView1.Size =
            New Size(Me.ClientSize.Width - menuWidth - 60,
                     Me.ClientSize.Height - 220)

        DataGridView1.Anchor =
            AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.RowTemplate.Height = 40

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToResizeRows = False

        DataGridView1.ReadOnly = True
        DataGridView1.MultiSelect = False

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        DataGridView1.RowHeadersVisible = False

        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black

        DataGridView1.EnableHeadersVisualStyles = False

        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(0, 120, 215)

        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.Font =
            New Font("Segoe UI", 10, FontStyle.Bold)

        DataGridView1.ColumnHeadersHeight = 40

        DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView1.GridColor = Color.LightGray

        ' =====================================================
        ' COLUMNS
        ' =====================================================
        DataGridView1.Columns.Clear()

        DataGridView1.Columns.Add("ID", "ID")
        DataGridView1.Columns.Add("Name", "Name")
        DataGridView1.Columns.Add("Category", "Category")

        ' =====================================================
        ' ADD GRID
        ' =====================================================
        Me.Controls.Add(DataGridView1)

        ' =====================================================
        ' LOAD DATA
        ' =====================================================
        LoadData(searchData)

    End Sub

    ' =====================================================
    ' LOAD DATA
    ' =====================================================
    Private Sub LoadData(data As List(Of String()))

        DataGridView1.Rows.Clear()

        For Each item In data
            DataGridView1.Rows.Add(item(0), item(1), item(2))
        Next

    End Sub

    ' =====================================================
    ' SEARCH
    ' =====================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim keyword As String = TextBox1.Text.Trim().ToLower()
        Dim category As String = ComboBox1.Text

        Dim results As New List(Of String())

        For Each item In searchData

            Dim id As String = item(0).ToLower()
            Dim name As String = item(1).ToLower()
            Dim type As String = item(2)

            Dim matchKeyword As Boolean =
                id.Contains(keyword) OrElse name.Contains(keyword)

            Dim matchCategory As Boolean =
                category = "All" OrElse type = category

            If matchKeyword AndAlso matchCategory Then
                results.Add(item)
            End If

        Next

        LoadData(results)

        If results.Count = 0 Then
            MessageBox.Show("No matching records found.",
                            "Search",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If

    End Sub

End Class