<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLessons
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
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        ComboBox1 = New ComboBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(235, 59)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(168, 27)
        TextBox1.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(471, 59)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(172, 27)
        TextBox2.TabIndex = 1
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(235, 121)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(168, 27)
        TextBox3.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DeepSkyBlue
        Button1.ForeColor = SystemColors.ButtonFace
        Button1.Location = New Point(246, 186)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 3
        Button1.Text = "Create"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(380, 186)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 4
        Button2.Text = "Edit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.IndianRed
        Button3.ForeColor = SystemColors.ButtonFace
        Button3.Location = New Point(532, 186)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 29)
        Button3.TabIndex = 5
        Button3.Text = "Delete"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(475, 120)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(168, 28)
        ComboBox1.TabIndex = 17
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 5
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 106F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 121F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 97F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 123F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 8F))
        TableLayoutPanel1.Location = New Point(235, 279)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 5
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 27F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 8F))
        TableLayoutPanel1.Size = New Size(553, 165)
        TableLayoutPanel1.TabIndex = 18
        ' 
        ' frmLessons
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Untitled_design
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(ComboBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Name = "frmLessons"
        Text = "frmLessons"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
