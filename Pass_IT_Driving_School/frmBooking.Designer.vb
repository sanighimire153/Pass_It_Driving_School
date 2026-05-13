<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBooking
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        ComboBox3 = New ComboBox()
        DateTimePicker1 = New DateTimePicker()
        TableLayoutPanel1 = New TableLayoutPanel()
        Button2 = New Button()
        Button3 = New Button()
        Button1 = New Button()
        Label1 = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(224, 69)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(200, 28)
        ComboBox1.TabIndex = 17
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(466, 69)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(242, 28)
        ComboBox2.TabIndex = 18
        ' 
        ' ComboBox3
        ' 
        ComboBox3.FormattingEnabled = True
        ComboBox3.Location = New Point(224, 137)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(200, 28)
        ComboBox3.TabIndex = 19
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(466, 135)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(250, 27)
        DateTimePicker1.TabIndex = 20
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 126F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 160F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 139F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 8F))
        TableLayoutPanel1.Location = New Point(238, 324)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(509, 125)
        TableLayoutPanel1.TabIndex = 21
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(420, 213)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 23
        Button2.Text = "Edit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.IndianRed
        Button3.Location = New Point(559, 213)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 29)
        Button3.TabIndex = 24
        Button3.Text = "Delete"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DeepSkyBlue
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.ForeColor = SystemColors.ButtonFace
        Button1.Location = New Point(276, 213)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 25
        Button1.Text = "Create"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Location = New Point(238, 301)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 20)
        Label1.TabIndex = 26
        Label1.Text = "Booking List"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' frmBooking
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Untitled_design
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(DateTimePicker1)
        Controls.Add(ComboBox3)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Name = "frmBooking"
        Text = "frmBooking"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
