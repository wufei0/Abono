<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentManager
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecordFound = New System.Windows.Forms.Label()
        Me.lstDocument = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.grpDocManager = New System.Windows.Forms.GroupBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAttachment_remove = New System.Windows.Forms.Button()
        Me.btnAttachment_add = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtAgency = New System.Windows.Forms.TextBox()
        Me.txtRecepient = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMunicipality = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboDocumentType = New System.Windows.Forms.ComboBox()
        Me.lblDocumentTYPEID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.grpDocManager.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRecordFound)
        Me.GroupBox1.Controls.Add(Me.lstDocument)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 434)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'lblRecordFound
        '
        Me.lblRecordFound.AutoSize = True
        Me.lblRecordFound.Location = New System.Drawing.Point(6, 418)
        Me.lblRecordFound.Name = "lblRecordFound"
        Me.lblRecordFound.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordFound.TabIndex = 27
        '
        'lstDocument
        '
        Me.lstDocument.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.lstDocument.FullRowSelect = True
        Me.lstDocument.GridLines = True
        Me.lstDocument.Location = New System.Drawing.Point(6, 48)
        Me.lstDocument.MultiSelect = False
        Me.lstDocument.Name = "lstDocument"
        Me.lstDocument.Size = New System.Drawing.Size(290, 364)
        Me.lstDocument.TabIndex = 13
        Me.lstDocument.UseCompatibleStateImageBehavior = False
        Me.lstDocument.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Recepient"
        Me.ColumnHeader5.Width = 110
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Document"
        Me.ColumnHeader6.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Municipality"
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "User"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(262, 20)
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
        Me.txtSearch.Location = New System.Drawing.Point(7, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(249, 21)
        Me.txtSearch.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(641, 457)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 29)
        Me.btnNew.TabIndex = 7
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(732, 457)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 29)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(938, 457)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 29)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(823, 457)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 29)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'grpDocManager
        '
        Me.grpDocManager.Controls.Add(Me.dtDate)
        Me.grpDocManager.Controls.Add(Me.GroupBox4)
        Me.grpDocManager.Controls.Add(Me.txtAgency)
        Me.grpDocManager.Controls.Add(Me.txtRecepient)
        Me.grpDocManager.Controls.Add(Me.Label7)
        Me.grpDocManager.Controls.Add(Me.Label6)
        Me.grpDocManager.Controls.Add(Me.Label5)
        Me.grpDocManager.Controls.Add(Me.txtMunicipality)
        Me.grpDocManager.Controls.Add(Me.Label4)
        Me.grpDocManager.Controls.Add(Me.txtNote)
        Me.grpDocManager.Controls.Add(Me.GroupBox3)
        Me.grpDocManager.Controls.Add(Me.Label1)
        Me.grpDocManager.Location = New System.Drawing.Point(332, 12)
        Me.grpDocManager.Name = "grpDocManager"
        Me.grpDocManager.Size = New System.Drawing.Size(698, 434)
        Me.grpDocManager.TabIndex = 26
        Me.grpDocManager.TabStop = False
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(87, 141)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(277, 21)
        Me.dtDate.TabIndex = 4
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnAttachment_remove)
        Me.GroupBox4.Controls.Add(Me.btnAttachment_add)
        Me.GroupBox4.Controls.Add(Me.lstAttachment)
        Me.GroupBox4.Location = New System.Drawing.Point(385, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(306, 398)
        Me.GroupBox4.TabIndex = 42
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Attachments"
        '
        'btnAttachment_remove
        '
        Me.btnAttachment_remove.Location = New System.Drawing.Point(267, 369)
        Me.btnAttachment_remove.Name = "btnAttachment_remove"
        Me.btnAttachment_remove.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_remove.TabIndex = 43
        Me.btnAttachment_remove.Text = "-"
        Me.btnAttachment_remove.UseVisualStyleBackColor = True
        '
        'btnAttachment_add
        '
        Me.btnAttachment_add.Location = New System.Drawing.Point(235, 369)
        Me.btnAttachment_add.Name = "btnAttachment_add"
        Me.btnAttachment_add.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_add.TabIndex = 42
        Me.btnAttachment_add.Text = "+"
        Me.btnAttachment_add.UseVisualStyleBackColor = True
        '
        'lstAttachment
        '
        Me.lstAttachment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16, Me.ColumnHeader19, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader20})
        Me.lstAttachment.FullRowSelect = True
        Me.lstAttachment.GridLines = True
        Me.lstAttachment.Location = New System.Drawing.Point(6, 18)
        Me.lstAttachment.MultiSelect = False
        Me.lstAttachment.Name = "lstAttachment"
        Me.lstAttachment.Size = New System.Drawing.Size(287, 345)
        Me.lstAttachment.TabIndex = 41
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
        Me.ColumnHeader19.Text = "path"
        Me.ColumnHeader19.Width = 1
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Filename"
        Me.ColumnHeader17.Width = 120
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Note"
        Me.ColumnHeader18.Width = 200
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Date"
        Me.ColumnHeader20.Width = 90
        '
        'txtAgency
        '
        Me.txtAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAgency.Location = New System.Drawing.Point(87, 114)
        Me.txtAgency.Name = "txtAgency"
        Me.txtAgency.Size = New System.Drawing.Size(277, 21)
        Me.txtAgency.TabIndex = 3
        '
        'txtRecepient
        '
        Me.txtRecepient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecepient.Location = New System.Drawing.Point(87, 87)
        Me.txtRecepient.Name = "txtRecepient"
        Me.txtRecepient.Size = New System.Drawing.Size(277, 21)
        Me.txtRecepient.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Agency"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Recepient"
        '
        'txtMunicipality
        '
        Me.txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMunicipality.Location = New System.Drawing.Point(87, 168)
        Me.txtMunicipality.Name = "txtMunicipality"
        Me.txtMunicipality.Size = New System.Drawing.Size(277, 21)
        Me.txtMunicipality.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Municipality"
        '
        'txtNote
        '
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNote.Location = New System.Drawing.Point(87, 195)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(277, 93)
        Me.txtNote.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboDocumentType)
        Me.GroupBox3.Controls.Add(Me.lblDocumentTYPEID)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(364, 57)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Document Type"
        '
        'cboDocumentType
        '
        Me.cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumentType.FormattingEnabled = True
        Me.cboDocumentType.Location = New System.Drawing.Point(72, 15)
        Me.cboDocumentType.Name = "cboDocumentType"
        Me.cboDocumentType.Size = New System.Drawing.Size(277, 21)
        Me.cboDocumentType.TabIndex = 5
        '
        'lblDocumentTYPEID
        '
        Me.lblDocumentTYPEID.AutoSize = True
        Me.lblDocumentTYPEID.Location = New System.Drawing.Point(100, -3)
        Me.lblDocumentTYPEID.Name = "lblDocumentTYPEID"
        Me.lblDocumentTYPEID.Size = New System.Drawing.Size(71, 13)
        Me.lblDocumentTYPEID.TabIndex = 0
        Me.lblDocumentTYPEID.Text = "Document_ID"
        Me.lblDocumentTYPEID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Note"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(354, 9)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(17, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'frmDocumentManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 498)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.grpDocManager)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDocumentManager"
        Me.Text = "Document Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpDocManager.ResumeLayout(False)
        Me.grpDocManager.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstDocument As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents grpDocManager As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtMunicipality As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAttachment_remove As System.Windows.Forms.Button
    Friend WithEvents btnAttachment_add As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtAgency As System.Windows.Forms.TextBox
    Friend WithEvents txtRecepient As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDocumentTYPEID As System.Windows.Forms.Label
    Friend WithEvents cboDocumentType As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblRecordFound As System.Windows.Forms.Label
End Class
