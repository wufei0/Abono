<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssistance
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
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecordFound = New System.Windows.Forms.Label()
        Me.lstAssistance = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.GrpAssistance = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnAttachment_remove = New System.Windows.Forms.Button()
        Me.btnAttachment_add = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtReceived = New System.Windows.Forms.DateTimePicker()
        Me.dtApproved = New System.Windows.Forms.DateTimePicker()
        Me.dtReleased = New System.Windows.Forms.DateTimePicker()
        Me.chkApproved = New System.Windows.Forms.CheckBox()
        Me.chkReceived = New System.Windows.Forms.CheckBox()
        Me.chkReleased = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtRecepientName = New System.Windows.Forms.TextBox()
        Me.txtRecepientAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtClaimantName = New System.Windows.Forms.TextBox()
        Me.txtClaimantAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboAssistanceType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAssistance_ID = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GrpAssistance.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(539, 531)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 29)
        Me.btnNew.TabIndex = 15
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(630, 531)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 29)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(836, 531)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 29)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(721, 531)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 29)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRecordFound)
        Me.GroupBox1.Controls.Add(Me.lstAssistance)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 500)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'lblRecordFound
        '
        Me.lblRecordFound.AutoSize = True
        Me.lblRecordFound.Location = New System.Drawing.Point(6, 482)
        Me.lblRecordFound.Name = "lblRecordFound"
        Me.lblRecordFound.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordFound.TabIndex = 21
        '
        'lstAssistance
        '
        Me.lstAssistance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader6, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lstAssistance.FullRowSelect = True
        Me.lstAssistance.GridLines = True
        Me.lstAssistance.Location = New System.Drawing.Point(6, 47)
        Me.lstAssistance.MultiSelect = False
        Me.lstAssistance.Name = "lstAssistance"
        Me.lstAssistance.Size = New System.Drawing.Size(275, 432)
        Me.lstAssistance.TabIndex = 13
        Me.lstAssistance.UseCompatibleStateImageBehavior = False
        Me.lstAssistance.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Claimant Name"
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Recepient Name"
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Assistance"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Amount"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Approved Status"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "User"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(247, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(34, 21)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.Location = New System.Drawing.Point(6, 20)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(235, 21)
        Me.txtSearch.TabIndex = 1
        '
        'GrpAssistance
        '
        Me.GrpAssistance.Controls.Add(Me.GroupBox6)
        Me.GrpAssistance.Controls.Add(Me.txtAmount)
        Me.GrpAssistance.Controls.Add(Me.txtRemark)
        Me.GrpAssistance.Controls.Add(Me.grpStatus)
        Me.GrpAssistance.Controls.Add(Me.Label11)
        Me.GrpAssistance.Controls.Add(Me.Label8)
        Me.GrpAssistance.Controls.Add(Me.GroupBox5)
        Me.GrpAssistance.Controls.Add(Me.GroupBox4)
        Me.GrpAssistance.Controls.Add(Me.GroupBox3)
        Me.GrpAssistance.Location = New System.Drawing.Point(311, 12)
        Me.GrpAssistance.Name = "GrpAssistance"
        Me.GrpAssistance.Size = New System.Drawing.Size(610, 500)
        Me.GrpAssistance.TabIndex = 20
        Me.GrpAssistance.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnAttachment_remove)
        Me.GroupBox6.Controls.Add(Me.btnAttachment_add)
        Me.GroupBox6.Controls.Add(Me.lstAttachment)
        Me.GroupBox6.Location = New System.Drawing.Point(357, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(253, 469)
        Me.GroupBox6.TabIndex = 50
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Attachments"
        '
        'btnAttachment_remove
        '
        Me.btnAttachment_remove.Location = New System.Drawing.Point(223, 440)
        Me.btnAttachment_remove.Name = "btnAttachment_remove"
        Me.btnAttachment_remove.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_remove.TabIndex = 10
        Me.btnAttachment_remove.Text = "-"
        Me.btnAttachment_remove.UseVisualStyleBackColor = True
        '
        'btnAttachment_add
        '
        Me.btnAttachment_add.Location = New System.Drawing.Point(191, 440)
        Me.btnAttachment_add.Name = "btnAttachment_add"
        Me.btnAttachment_add.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_add.TabIndex = 9
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
        Me.lstAttachment.Size = New System.Drawing.Size(241, 414)
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
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(61, 427)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(283, 21)
        Me.txtAmount.TabIndex = 49
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(61, 454)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(283, 31)
        Me.txtRemark.TabIndex = 48
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.Label9)
        Me.grpStatus.Controls.Add(Me.Label12)
        Me.grpStatus.Controls.Add(Me.Label10)
        Me.grpStatus.Controls.Add(Me.dtReceived)
        Me.grpStatus.Controls.Add(Me.dtApproved)
        Me.grpStatus.Controls.Add(Me.dtReleased)
        Me.grpStatus.Controls.Add(Me.chkApproved)
        Me.grpStatus.Controls.Add(Me.chkReceived)
        Me.grpStatus.Controls.Add(Me.chkReleased)
        Me.grpStatus.Location = New System.Drawing.Point(6, 273)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(343, 148)
        Me.grpStatus.TabIndex = 47
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Date Received"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(184, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Date Approved"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Date Released"
        '
        'dtReceived
        '
        Me.dtReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceived.Location = New System.Drawing.Point(17, 49)
        Me.dtReceived.Name = "dtReceived"
        Me.dtReceived.Size = New System.Drawing.Size(146, 21)
        Me.dtReceived.TabIndex = 3
        '
        'dtApproved
        '
        Me.dtApproved.Enabled = False
        Me.dtApproved.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtApproved.Location = New System.Drawing.Point(187, 49)
        Me.dtApproved.Name = "dtApproved"
        Me.dtApproved.Size = New System.Drawing.Size(147, 21)
        Me.dtApproved.TabIndex = 5
        '
        'dtReleased
        '
        Me.dtReleased.Enabled = False
        Me.dtReleased.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReleased.Location = New System.Drawing.Point(17, 118)
        Me.dtReleased.Name = "dtReleased"
        Me.dtReleased.Size = New System.Drawing.Size(147, 21)
        Me.dtReleased.TabIndex = 5
        '
        'chkApproved
        '
        Me.chkApproved.AutoSize = True
        Me.chkApproved.Location = New System.Drawing.Point(187, 13)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.Size = New System.Drawing.Size(71, 17)
        Me.chkApproved.TabIndex = 4
        Me.chkApproved.Text = "Approved"
        Me.chkApproved.UseVisualStyleBackColor = True
        '
        'chkReceived
        '
        Me.chkReceived.AutoSize = True
        Me.chkReceived.Checked = True
        Me.chkReceived.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReceived.Enabled = False
        Me.chkReceived.Location = New System.Drawing.Point(17, 14)
        Me.chkReceived.Name = "chkReceived"
        Me.chkReceived.Size = New System.Drawing.Size(69, 17)
        Me.chkReceived.TabIndex = 1
        Me.chkReceived.Text = "Received"
        Me.chkReceived.UseVisualStyleBackColor = True
        '
        'chkReleased
        '
        Me.chkReleased.AutoSize = True
        Me.chkReleased.Location = New System.Drawing.Point(17, 82)
        Me.chkReleased.Name = "chkReleased"
        Me.chkReleased.Size = New System.Drawing.Size(70, 17)
        Me.chkReleased.TabIndex = 4
        Me.chkReleased.Text = "Released"
        Me.chkReleased.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 472)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Remarks"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 435)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Amount"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtRecepientName)
        Me.GroupBox5.Controls.Add(Me.txtRecepientAddress)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 187)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(343, 83)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Recepient"
        '
        'txtRecepientName
        '
        Me.txtRecepientName.Location = New System.Drawing.Point(74, 18)
        Me.txtRecepientName.Name = "txtRecepientName"
        Me.txtRecepientName.Size = New System.Drawing.Size(264, 21)
        Me.txtRecepientName.TabIndex = 6
        '
        'txtRecepientAddress
        '
        Me.txtRecepientAddress.Location = New System.Drawing.Point(73, 46)
        Me.txtRecepientAddress.Multiline = True
        Me.txtRecepientAddress.Name = "txtRecepientAddress"
        Me.txtRecepientAddress.Size = New System.Drawing.Size(264, 31)
        Me.txtRecepientAddress.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Address"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Name"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtClaimantName)
        Me.GroupBox4.Controls.Add(Me.txtClaimantAddress)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 99)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(343, 82)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Claimant"
        '
        'txtClaimantName
        '
        Me.txtClaimantName.Location = New System.Drawing.Point(74, 18)
        Me.txtClaimantName.Name = "txtClaimantName"
        Me.txtClaimantName.Size = New System.Drawing.Size(263, 21)
        Me.txtClaimantName.TabIndex = 6
        '
        'txtClaimantAddress
        '
        Me.txtClaimantAddress.Location = New System.Drawing.Point(73, 46)
        Me.txtClaimantAddress.Multiline = True
        Me.txtClaimantAddress.Name = "txtClaimantAddress"
        Me.txtClaimantAddress.Size = New System.Drawing.Size(264, 31)
        Me.txtClaimantAddress.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Name"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboAssistanceType)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.lblAssistance_ID)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(340, 82)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Assistance"
        '
        'cboAssistanceType
        '
        Me.cboAssistanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssistanceType.FormattingEnabled = True
        Me.cboAssistanceType.Location = New System.Drawing.Point(72, 20)
        Me.cboAssistanceType.Name = "cboAssistanceType"
        Me.cboAssistanceType.Size = New System.Drawing.Size(263, 21)
        Me.cboAssistanceType.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Description"
        '
        'lblAssistance_ID
        '
        Me.lblAssistance_ID.AutoSize = True
        Me.lblAssistance_ID.Location = New System.Drawing.Point(69, 0)
        Me.lblAssistance_ID.Name = "lblAssistance_ID"
        Me.lblAssistance_ID.Size = New System.Drawing.Size(94, 13)
        Me.lblAssistance_ID.TabIndex = 0
        Me.lblAssistance_ID.Text = "Assistancetype_ID"
        Me.lblAssistance_ID.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(256, 2)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(17, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'frmAssistance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 572)
        Me.Controls.Add(Me.GrpAssistance)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblID)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "frmAssistance"
        Me.Text = "Assistance"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpAssistance.ResumeLayout(False)
        Me.GrpAssistance.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstAssistance As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents GrpAssistance As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRecepientName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtClaimantName As System.Windows.Forms.TextBox
    Friend WithEvents txtClaimantAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAssistanceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtReleased As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkReceived As System.Windows.Forms.CheckBox
    Friend WithEvents chkReleased As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAssistance_ID As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAttachment_remove As System.Windows.Forms.Button
    Friend WithEvents btnAttachment_add As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtApproved As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkApproved As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRecepientAddress As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblRecordFound As System.Windows.Forms.Label
End Class
