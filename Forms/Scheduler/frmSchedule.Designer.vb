<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchedule
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
        Me.DateItem1 = New Pabo.Calendar.DateItem()
        Me.ID = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecordFound = New System.Windows.Forms.Label()
        Me.lstSchedule = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.grpSchedule = New System.Windows.Forms.GroupBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtOrganization = New System.Windows.Forms.TextBox()
        Me.txtProgram = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAttachment_remove = New System.Windows.Forms.Button()
        Me.btnAttachment_add = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateItem1
        '
        Me.DateItem1.BackColor1 = System.Drawing.Color.Empty
        Me.DateItem1.BackColor2 = System.Drawing.Color.White
        Me.DateItem1.BackgroundImage = Nothing
        Me.DateItem1.BoldedDate = False
        Me.DateItem1.Date = New Date(2013, 10, 17, 0, 0, 0, 0)
        Me.DateItem1.DateColor = System.Drawing.Color.Empty
        Me.DateItem1.Enabled = True
        Me.DateItem1.GradientMode = Pabo.Calendar.mcGradientMode.None
        Me.DateItem1.Image = Nothing
        Me.DateItem1.ImageListIndex = -1
        Me.DateItem1.Pattern = Pabo.Calendar.mcDayInfoRecurrence.None
        Me.DateItem1.Range = New Date(2013, 10, 17, 0, 0, 0, 0)
        Me.DateItem1.Tag = Nothing
        Me.DateItem1.Text = ""
        Me.DateItem1.TextColor = System.Drawing.Color.Empty
        Me.DateItem1.Weekend = False
        '
        'ID
        '
        Me.ID.AutoSize = True
        Me.ID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ID.Location = New System.Drawing.Point(325, 9)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(17, 13)
        Me.ID.TabIndex = 5
        Me.ID.Text = "ID"
        Me.ID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRecordFound)
        Me.GroupBox1.Controls.Add(Me.lstSchedule)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 389)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'lblRecordFound
        '
        Me.lblRecordFound.AutoSize = True
        Me.lblRecordFound.Location = New System.Drawing.Point(4, 370)
        Me.lblRecordFound.Name = "lblRecordFound"
        Me.lblRecordFound.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordFound.TabIndex = 31
        '
        'lstSchedule
        '
        Me.lstSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lstSchedule.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.lstSchedule.FullRowSelect = True
        Me.lstSchedule.GridLines = True
        Me.lstSchedule.Location = New System.Drawing.Point(6, 48)
        Me.lstSchedule.MultiSelect = False
        Me.lstSchedule.Name = "lstSchedule"
        Me.lstSchedule.Size = New System.Drawing.Size(266, 318)
        Me.lstSchedule.TabIndex = 13
        Me.lstSchedule.UseCompatibleStateImageBehavior = False
        Me.lstSchedule.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Activity"
        Me.ColumnHeader7.Width = 90
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Date"
        Me.ColumnHeader8.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Note"
        Me.ColumnHeader10.Width = 120
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "User"
        Me.ColumnHeader11.Width = 100
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.btnSearch.Location = New System.Drawing.Point(238, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(34, 21)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.txtSearch.Location = New System.Drawing.Point(7, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(225, 21)
        Me.txtSearch.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(305, 420)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 29)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(396, 420)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 29)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(602, 420)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 29)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(487, 420)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 29)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.btnAttachment_remove)
        Me.grpSchedule.Controls.Add(Me.btnAttachment_add)
        Me.grpSchedule.Controls.Add(Me.lstAttachment)
        Me.grpSchedule.Controls.Add(Me.dtDate)
        Me.grpSchedule.Controls.Add(Me.txtNote)
        Me.grpSchedule.Controls.Add(Me.txtAddress)
        Me.grpSchedule.Controls.Add(Me.txtOrganization)
        Me.grpSchedule.Controls.Add(Me.txtProgram)
        Me.grpSchedule.Controls.Add(Me.Label4)
        Me.grpSchedule.Controls.Add(Me.Label3)
        Me.grpSchedule.Controls.Add(Me.Label5)
        Me.grpSchedule.Controls.Add(Me.Label2)
        Me.grpSchedule.Controls.Add(Me.Label1)
        Me.grpSchedule.Location = New System.Drawing.Point(305, 25)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(382, 389)
        Me.grpSchedule.TabIndex = 16
        Me.grpSchedule.TabStop = False
        '
        'dtDate
        '
        Me.dtDate.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(84, 136)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(288, 21)
        Me.dtDate.TabIndex = 13
        '
        'txtNote
        '
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNote.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(84, 220)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(288, 51)
        Me.txtNote.TabIndex = 15
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(84, 163)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(288, 51)
        Me.txtAddress.TabIndex = 14
        '
        'txtOrganization
        '
        Me.txtOrganization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrganization.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganization.Location = New System.Drawing.Point(84, 79)
        Me.txtOrganization.Multiline = True
        Me.txtOrganization.Name = "txtOrganization"
        Me.txtOrganization.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOrganization.Size = New System.Drawing.Size(288, 51)
        Me.txtOrganization.TabIndex = 12
        '
        'txtProgram
        '
        Me.txtProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProgram.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgram.Location = New System.Drawing.Point(84, 22)
        Me.txtProgram.Multiline = True
        Me.txtProgram.Name = "txtProgram"
        Me.txtProgram.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProgram.Size = New System.Drawing.Size(288, 51)
        Me.txtProgram.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Note"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Organization"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 51)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Program /  Activity"
        '
        'btnAttachment_remove
        '
        Me.btnAttachment_remove.Location = New System.Drawing.Point(346, 360)
        Me.btnAttachment_remove.Name = "btnAttachment_remove"
        Me.btnAttachment_remove.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_remove.TabIndex = 49
        Me.btnAttachment_remove.Text = "-"
        Me.btnAttachment_remove.UseVisualStyleBackColor = True
        '
        'btnAttachment_add
        '
        Me.btnAttachment_add.Location = New System.Drawing.Point(314, 360)
        Me.btnAttachment_add.Name = "btnAttachment_add"
        Me.btnAttachment_add.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_add.TabIndex = 48
        Me.btnAttachment_add.Text = "+"
        Me.btnAttachment_add.UseVisualStyleBackColor = True
        '
        'lstAttachment
        '
        Me.lstAttachment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16, Me.ColumnHeader19, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.lstAttachment.FullRowSelect = True
        Me.lstAttachment.GridLines = True
        Me.lstAttachment.Location = New System.Drawing.Point(85, 280)
        Me.lstAttachment.MultiSelect = False
        Me.lstAttachment.Name = "lstAttachment"
        Me.lstAttachment.Size = New System.Drawing.Size(287, 74)
        Me.lstAttachment.TabIndex = 47
        Me.lstAttachment.UseCompatibleStateImageBehavior = False
        Me.lstAttachment.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "ID"
        Me.ColumnHeader16.Width = 1
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Recepient"
        Me.ColumnHeader19.Width = 110
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Agency"
        Me.ColumnHeader17.Width = 90
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Type"
        Me.ColumnHeader18.Width = 200
        '
        'frmSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 465)
        Me.Controls.Add(Me.grpSchedule)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ID)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.MaximizeBox = False
        Me.Name = "frmSchedule"
        Me.Text = "Schedule"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateItem1 As Pabo.Calendar.DateItem
    Friend WithEvents ID As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecordFound As System.Windows.Forms.Label
    Friend WithEvents lstSchedule As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOrganization As System.Windows.Forms.TextBox
    Friend WithEvents txtProgram As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAttachment_remove As System.Windows.Forms.Button
    Friend WithEvents btnAttachment_add As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
End Class
