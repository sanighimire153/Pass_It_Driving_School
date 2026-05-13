Imports System.Drawing
Imports System.Windows.Forms

Public Class frmStudents

    Private studentTable As New List(Of String())
    Private scrollOffset As Integer = 0
    Private rowHeight As Integer = 35

    ' =====================================================
    ' FORM LOAD
    ' =====================================================
    Private Sub frmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Students"
        Me.BackColor = Color.White
        Me.WindowState = FormWindowState.Maximized
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
        ' MENU EVENTS (FIXED)
        ' =====================================================

        AddHandler btnDashboard.Click, Sub()
                                           SwitchForm(New frmDashboard)
                                       End Sub

        AddHandler btnStudents.Click, Sub()
                                          MessageBox.Show("You are already on Students page.")
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
        ' PLACEHOLDERS
        ' =====================================================
        SetPlaceholder(TextBox1, "Student Number")
        SetPlaceholder(TextBox2, "First Name")
        SetPlaceholder(TextBox3, "Last Name")
        SetPlaceholder(TextBox5, "Phone Number")
        SetPlaceholder(TextBox6, "Email Address")

        RichTextBox1.Text = "Address"

        ' =====================================================
        ' INSTRUCTOR DROPDOWN
        ' =====================================================
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Mark Wilson")
        ComboBox1.Items.Add("David Brown")
        ComboBox1.Items.Add("Lisa Taylor")
        ComboBox1.Text = "Select Instructor"

        ' =====================================================
        ' TABLE SCROLL
        ' =====================================================
        TableLayoutPanel1.AutoScroll = True
        AddHandler TableLayoutPanel1.MouseWheel, AddressOf Table_MouseWheel

    End Sub

    ' =====================================================
    ' SWITCH FORM (FIXED)
    ' =====================================================
    Private Sub SwitchForm(frm As Form)
        frm.Show()
        Me.Hide()
    End Sub

    ' =====================================================
    ' PLACEHOLDER SYSTEM
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
    ' SAVE
    ' =====================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim fullName As String = TextBox2.Text & " " & TextBox3.Text

        studentTable.Add(New String() {
            TextBox1.Text,
            fullName,
            TextBox5.Text
        })

        TableLayoutPanel1.Refresh()
        ClearFields()

        MessageBox.Show("Student Saved Successfully")

    End Sub

    ' =====================================================
    ' CLEAR
    ' =====================================================
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearFields()
    End Sub

    ' =====================================================
    ' DELETE
    ' =====================================================
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If studentTable.Count > 0 Then
            studentTable.RemoveAt(studentTable.Count - 1)
            TableLayoutPanel1.Refresh()
        End If

    End Sub

    ' =====================================================
    ' CLEAR FIELDS
    ' =====================================================
    Private Sub ClearFields()

        SetPlaceholder(TextBox1, "Student Number")
        SetPlaceholder(TextBox2, "First Name")
        SetPlaceholder(TextBox3, "Last Name")
        SetPlaceholder(TextBox5, "Phone Number")
        SetPlaceholder(TextBox6, "Email Address")

        RichTextBox1.Text = "Address"
        ComboBox1.Text = "Select Instructor"

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

        Dim headers() As String = {"Student ID", "Full Name", "Phone"}
        Dim colWidth As Integer = TableLayoutPanel1.Width \ 3

        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim rowFont As New Font("Segoe UI", 9)

        Dim headerBrush As New SolidBrush(Color.FromArgb(0, 120, 215))
        Dim headerTextBrush As New SolidBrush(Color.White)

        Dim rowBrush1 As New SolidBrush(Color.White)
        Dim rowBrush2 As New SolidBrush(Color.FromArgb(240, 240, 240))

        Dim textBrush As New SolidBrush(Color.Black)
        Dim borderPen As New Pen(Color.LightGray)

        For col As Integer = 0 To 2
            Dim rect As New Rectangle(col * colWidth, 0, colWidth, rowHeight)
            g.FillRectangle(headerBrush, rect)
            g.DrawRectangle(borderPen, rect)
            g.DrawString(headers(col), headerFont, headerTextBrush, rect.X + 5, rect.Y + 10)
        Next

        Dim visibleRows As Integer = (TableLayoutPanel1.Height \ rowHeight) - 1
        Dim startRow As Integer = scrollOffset
        Dim endRow As Integer = Math.Min(studentTable.Count - 1, startRow + visibleRows)

        Dim displayRow As Integer = 0

        For row As Integer = startRow To endRow

            If studentTable(row) IsNot Nothing AndAlso studentTable(row).Length >= 3 Then

                Dim bg As SolidBrush = If(row Mod 2 = 0, rowBrush1, rowBrush2)

                For col As Integer = 0 To 2

                    Dim rect As New Rectangle(col * colWidth,
                                               (displayRow + 1) * rowHeight,
                                               colWidth, rowHeight)

                    g.FillRectangle(bg, rect)
                    g.DrawRectangle(borderPen, rect)

                    g.DrawString(studentTable(row)(col),
                                 rowFont, textBrush,
                                 rect.X + 5, rect.Y + 10)

                Next

                displayRow += 1

            End If

        Next

    End Sub

End Class