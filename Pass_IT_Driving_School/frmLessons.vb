Imports System.Drawing
Imports System.Windows.Forms

Public Class frmLessons

    ' =====================================================
    ' DATA STORAGE
    ' =====================================================
    Private lessonTable As New List(Of String())
    Private scrollOffset As Integer = 0
    Private rowHeight As Integer = 35

    ' =====================================================
    ' FORM LOAD
    ' =====================================================
    Private Sub frmLessons_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Lessons"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9)

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
        ' NAVIGATION
        ' =====================================================
        AddHandler btnDashboard.Click, Sub() SwitchForm(New frmDashboard)
        AddHandler btnStudents.Click, Sub() SwitchForm(New frmStudents)
        AddHandler btnInstructors.Click, Sub() SwitchForm(New frmInstructors)
        AddHandler btnLessons.Click, Sub() MessageBox.Show("You are already on Lessons page.")
        AddHandler btnBooking.Click, Sub() SwitchForm(New frmBooking)
        AddHandler btnSearch.Click, Sub() SwitchForm(New frmSearch)
        AddHandler btnReports.Click, Sub() SwitchForm(New frmReports)

        ' =====================================================
        ' PLACEHOLDERS
        ' =====================================================
        SetPlaceholder(TextBox1, "Lesson Name")
        SetPlaceholder(TextBox2, "Duration (e.g. 2 hours)")
        SetPlaceholder(TextBox3, "Cost (£)")

        ' =====================================================
        ' COURSE LEVEL DROPDOWN
        ' =====================================================
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Beginner")
        ComboBox1.Items.Add("Intermediate")
        ComboBox1.Items.Add("Advanced")
        SetComboPlaceholder(ComboBox1, "Select Course Level")

        ' =====================================================
        ' TABLE SCROLL
        ' =====================================================
        TableLayoutPanel1.AutoScroll = True
        AddHandler TableLayoutPanel1.MouseWheel, AddressOf Table_MouseWheel

    End Sub

    ' =====================================================
    ' SWITCH FORM
    ' =====================================================
    Private Sub SwitchForm(frm As Form)
        frm.Show()
        Me.Hide()
    End Sub

    ' =====================================================
    ' SAVE
    ' =====================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        lessonTable.Add(New String() {
            TextBox1.Text,
            TextBox2.Text,
            TextBox3.Text,
            ComboBox1.Text
        })

        TableLayoutPanel1.Refresh()
        ClearFields()

        MessageBox.Show("Lesson Saved Successfully")

    End Sub

    ' =====================================================
    ' CLEAR
    ' =====================================================
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearFields()
    End Sub

    ' =====================================================
    ' DELETE (last record like your Students form)
    ' =====================================================
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If lessonTable.Count > 0 Then
            lessonTable.RemoveAt(lessonTable.Count - 1)
            TableLayoutPanel1.Refresh()
        End If

    End Sub

    ' =====================================================
    ' CLEAR FIELDS
    ' =====================================================
    Private Sub ClearFields()

        SetPlaceholder(TextBox1, "Lesson Name")
        SetPlaceholder(TextBox2, "Duration (e.g. 2 hours)")
        SetPlaceholder(TextBox3, "Cost (£)")
        SetComboPlaceholder(ComboBox1, "Select Course Level")

    End Sub

    ' =====================================================
    ' PLACEHOLDER (TEXTBOX)
    ' =====================================================
    Private Sub SetPlaceholder(txt As TextBox, placeholder As String)

        txt.Tag = placeholder

        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = placeholder
            txt.ForeColor = Color.Gray
        End If

        RemoveHandler txt.GotFocus, AddressOf RemovePlaceholder
        RemoveHandler txt.LostFocus, AddressOf ApplyPlaceholder

        AddHandler txt.GotFocus, AddressOf RemovePlaceholder
        AddHandler txt.LostFocus, AddressOf ApplyPlaceholder

    End Sub

    Private Sub RemovePlaceholder(sender As Object, e As EventArgs)

        Dim txt As TextBox = CType(sender, TextBox)

        If txt.ForeColor = Color.Gray Then
            txt.Text = ""
            txt.ForeColor = Color.Black
        End If

    End Sub

    Private Sub ApplyPlaceholder(sender As Object, e As EventArgs)

        Dim txt As TextBox = CType(sender, TextBox)

        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = txt.Tag.ToString()
            txt.ForeColor = Color.Gray
        End If

    End Sub

    ' =====================================================
    ' PLACEHOLDER (COMBOBOX)
    ' =====================================================
    Private Sub SetComboPlaceholder(cmb As ComboBox, placeholder As String)

        cmb.Tag = placeholder
        cmb.Text = placeholder
        cmb.ForeColor = Color.Gray

        RemoveHandler cmb.Enter, AddressOf ComboEnter
        RemoveHandler cmb.Leave, AddressOf ComboLeave

        AddHandler cmb.Enter, AddressOf ComboEnter
        AddHandler cmb.Leave, AddressOf ComboLeave

    End Sub

    Private Sub ComboEnter(sender As Object, e As EventArgs)

        Dim cmb As ComboBox = CType(sender, ComboBox)

        If cmb.ForeColor = Color.Gray Then
            cmb.Text = ""
            cmb.ForeColor = Color.Black
        End If

    End Sub

    Private Sub ComboLeave(sender As Object, e As EventArgs)

        Dim cmb As ComboBox = CType(sender, ComboBox)

        If String.IsNullOrWhiteSpace(cmb.Text) Then
            cmb.Text = cmb.Tag.ToString()
            cmb.ForeColor = Color.Gray
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

        Dim headers() As String = {"Lesson Name", "Duration", "Cost", "Level"}
        Dim colWidth As Integer = TableLayoutPanel1.Width \ 4

        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim rowFont As New Font("Segoe UI", 9)

        Dim headerBrush As New SolidBrush(Color.FromArgb(0, 120, 215))
        Dim headerTextBrush As New SolidBrush(Color.White)

        Dim rowBrush1 As New SolidBrush(Color.White)
        Dim rowBrush2 As New SolidBrush(Color.FromArgb(240, 240, 240))

        Dim textBrush As New SolidBrush(Color.Black)
        Dim borderPen As New Pen(Color.LightGray)

        ' headers
        For col As Integer = 0 To 3
            Dim rect As New Rectangle(col * colWidth, 0, colWidth, rowHeight)
            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(borderPen, rect)
            g.DrawString(headers(col), headerFont, headerTextBrush, rect.X + 5, rect.Y + 10)
        Next

        Dim visibleRows As Integer = (TableLayoutPanel1.Height \ rowHeight) - 1
        Dim startRow As Integer = scrollOffset
        Dim endRow As Integer = Math.Min(lessonTable.Count - 1, startRow + visibleRows)

        Dim displayRow As Integer = 0

        For row As Integer = startRow To endRow

            If lessonTable(row) IsNot Nothing AndAlso lessonTable(row).Length >= 4 Then

                Dim bg As SolidBrush = If(row Mod 2 = 0, rowBrush1, rowBrush2)

                For col As Integer = 0 To 3

                    Dim rect As New Rectangle(col * colWidth,
                                               (displayRow + 1) * rowHeight,
                                               colWidth,
                                               rowHeight)

                    g.FillRectangle(bg, rect)
                    g.DrawRectangle(borderPen, rect)

                    g.DrawString(lessonTable(row)(col),
                                 rowFont,
                                 textBrush,
                                 rect.X + 5,
                                 rect.Y + 10)

                Next

                displayRow += 1

            End If

        Next

    End Sub

End Class