Public Class frmBooking

    ' =====================================================
    ' DATA STORAGE
    ' =====================================================

    Private bookingTable As New List(Of String())

    Private scrollOffset As Integer = 0
    Private rowHeight As Integer = 35

    Private Sub frmBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load



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
                                           SwitchForm(New frmDashboard)
                                       End Sub

        AddHandler btnStudents.Click, Sub()
                                          SwitchForm(New frmStudents)
                                      End Sub

        AddHandler btnInstructors.Click, Sub()
                                             SwitchForm(New frmInstructors)
                                         End Sub

        AddHandler btnLessons.Click, Sub()
                                         SwitchForm(New frmLessons)
                                     End Sub

        AddHandler btnBooking.Click, Sub()
                                         SwitchForm(New frmBooking)
                                     End Sub

        AddHandler btnSearch.Click, Sub()
                                        SwitchForm(New frmSearch)
                                    End Sub

        AddHandler btnReports.Click, Sub()
                                         SwitchForm(New frmReports)
                                     End Sub



        ' =====================================================
        ' TABLE SCROLL
        ' =====================================================

        TableLayoutPanel1.AutoScroll = True
        AddHandler TableLayoutPanel1.MouseWheel, AddressOf Table_MouseWheel

        ' =====================================================
        ' COMBOBOX DATA
        ' =====================================================

        ComboBox1.Items.Add("John Smith")
        ComboBox1.Items.Add("David Brown")
        ComboBox1.Items.Add("Lisa Taylor")

        ComboBox2.Items.Add("Mr Wilson")
        ComboBox2.Items.Add("Mr David")
        ComboBox2.Items.Add("Mr Alex")

        ComboBox3.Items.Add("Driving")
        ComboBox3.Items.Add("Parking")
        ComboBox3.Items.Add("Theory")

    End Sub

    ' =====================================================
    ' NAVIGATION FUNCTION
    ' =====================================================

    Private Sub SwitchForm(f As Form)
        f.Show()
        Me.Hide()
    End Sub

    ' =====================================================
    ' SAVE BUTTON
    ' =====================================================

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text.Trim = "" Or
           ComboBox2.Text.Trim = "" Or
           ComboBox3.Text.Trim = "" Then

            MessageBox.Show("Please Fill Required Fields",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            Exit Sub

        End If

        bookingTable.Add(New String() {
            ComboBox1.Text,
            ComboBox2.Text,
            ComboBox3.Text,
            DateTimePicker1.Value.ToShortDateString()
        })

        TableLayoutPanel1.Refresh()

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

        DateTimePicker1.Value = DateTime.Now

        MessageBox.Show("Booking Saved Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

    End Sub

    ' =====================================================
    ' CLEAR BUTTON
    ' =====================================================

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

        DateTimePicker1.Value = DateTime.Now

    End Sub

    ' =====================================================
    ' DELETE BUTTON
    ' =====================================================

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If bookingTable.Count > 0 Then

            bookingTable.RemoveAt(bookingTable.Count - 1)

            TableLayoutPanel1.Refresh()

            MessageBox.Show("Last Booking Deleted",
                            "Delete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

        Else

            MessageBox.Show("No Data Found",
                            "Delete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

        End If

    End Sub

    ' =====================================================
    ' SCROLL
    ' =====================================================

    Private Sub Table_MouseWheel(sender As Object, e As MouseEventArgs)

        If e.Delta < 0 Then
            scrollOffset += 1
        ElseIf e.Delta > 0 And scrollOffset > 0 Then
            scrollOffset -= 1
        End If

        TableLayoutPanel1.Refresh()

    End Sub

    ' =====================================================
    ' TABLE DRAW
    ' =====================================================

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

        Dim g As Graphics = e.Graphics

        Dim headers() As String = {
            "Student",
            "Instructor",
            "Lesson",
            "Date"
        }

        Dim colWidth As Integer = TableLayoutPanel1.Width \ 4

        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim rowFont As New Font("Segoe UI", 9)

        Dim headerBrush As New SolidBrush(Color.FromArgb(0, 120, 215))
        Dim headerTextBrush As New SolidBrush(Color.White)

        Dim rowBrush1 As New SolidBrush(Color.White)
        Dim rowBrush2 As New SolidBrush(Color.FromArgb(240, 240, 240))

        Dim textBrush As New SolidBrush(Color.Black)
        Dim borderPen As New Pen(Color.LightGray)

        ' =====================================================
        ' HEADER
        ' =====================================================

        For col As Integer = 0 To 3

            Dim rect As New Rectangle(col * colWidth,
                                      0,
                                      colWidth,
                                      rowHeight)

            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(borderPen, rect)

            g.DrawString(headers(col),
                         headerFont,
                         headerTextBrush,
                         rect.X + 5,
                         rect.Y + 10)

        Next

        ' =====================================================
        ' ROWS
        ' =====================================================

        Dim visibleRows As Integer =
            (TableLayoutPanel1.Height \ rowHeight) - 1

        Dim startRow As Integer = scrollOffset

        Dim endRow As Integer =
            Math.Min(bookingTable.Count - 1,
                     startRow + visibleRows)

        Dim displayRow As Integer = 0

        For row As Integer = startRow To endRow

            Dim bg As SolidBrush =
                If(row Mod 2 = 0,
                   rowBrush1,
                   rowBrush2)

            For col As Integer = 0 To 3

                Dim rect As New Rectangle(
                    col * colWidth,
                    (displayRow + 1) * rowHeight,
                    colWidth,
                    rowHeight)

                g.FillRectangle(bg, rect)
                g.DrawRectangle(borderPen, rect)

                g.DrawString(
                    bookingTable(row)(col),
                    rowFont,
                    textBrush,
                    rect.X + 5,
                    rect.Y + 10)

            Next

            displayRow += 1

        Next

    End Sub

    ' =====================================================
    ' OTHER EVENTS
    ' =====================================================

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

End Class