<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfrastructure
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
        Me.lstInfrastructure = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.grpInfra = New System.Windows.Forms.GroupBox()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAttachment_remove = New System.Windows.Forms.Button()
        Me.btnAttachment_add = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtProposal = New System.Windows.Forms.TextBox()
        Me.grpRecepint = New System.Windows.Forms.GroupBox()
        Me.lblRecepient_id = New System.Windows.Forms.Label()
        Me.txtRecepient_contactno = New System.Windows.Forms.TextBox()
        Me.txtRecepient_Designation = New System.Windows.Forms.TextBox()
        Me.btnRecepient_Search = New System.Windows.Forms.Button()
        Me.txtRecepient_Address = New System.Windows.Forms.TextBox()
        Me.txtRecepient_name = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtReceived = New System.Windows.Forms.DateTimePicker()
        Me.dtApproved = New System.Windows.Forms.DateTimePicker()
        Me.chkReceived = New System.Windows.Forms.CheckBox()
        Me.chkApproved = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOrganization = New System.Windows.Forms.TextBox()
        Me.btnAddress_Search = New System.Windows.Forms.Button()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbladdress_id = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btnAttachment = New System.Windows.Forms.Button()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.grpInfra.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpRecepint.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRecordFound)
        Me.GroupBox1.Controls.Add(Me.lstInfrastructure)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 444)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'lblRecordFound
        '
        Me.lblRecordFound.AutoSize = True
        Me.lblRecordFound.Location = New System.Drawing.Point(6, 423)
        Me.lblRecordFound.Name = "lblRecordFound"
        Me.lblRecordFound.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordFound.TabIndex = 44
        '
        'lstInfrastructure
        '
        Me.lstInfrastructure.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader6})
        Me.lstInfrastructure.FullRowSelect = True
        Me.lstInfrastructure.GridLines = True
        Me.lstInfrastructure.Location = New System.Drawing.Point(6, 47)
        Me.lstInfrastructure.MultiSelect = False
        Me.lstInfrastructure.Name = "lstInfrastructure"
        Me.lstInfrastructure.Size = New System.Drawing.Size(275, 373)
        Me.lstInfrastructure.TabIndex = 13
        Me.lstInfrastructure.UseCompatibleStateImageBehavior = False
        Me.lstInfrastructure.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Address"
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Name"
        Me.ColumnHeader3.Width = 120
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
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "User"
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
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.Location = New System.Drawing.Point(6, 20)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(235, 21)
        Me.txtSearch.TabIndex = 1
        '
        'grpInfra
        '
        Me.grpInfra.Controls.Add(Me.txtamount)
        Me.grpInfra.Controls.Add(Me.GroupBox3)
        Me.grpInfra.Controls.Add(Me.txtNote)
        Me.grpInfra.Controls.Add(Me.txtProposal)
        Me.grpInfra.Controls.Add(Me.grpRecepint)
        Me.grpInfra.Controls.Add(Me.grpStatus)
        Me.grpInfra.Controls.Add(Me.GroupBox2)
        Me.grpInfra.Controls.Add(Me.Label2)
        Me.grpInfra.Controls.Add(Me.Label1)
        Me.grpInfra.Controls.Add(Me.Label3)
        Me.grpInfra.Location = New System.Drawing.Point(311, 12)
        Me.grpInfra.Name = "grpInfra"
        Me.grpInfra.Size = New System.Drawing.Size(752, 444)
        Me.grpInfra.TabIndex = 40
        Me.grpInfra.TabStop = False
        '
        'txtamount
        '
        Me.txtamount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtamount.Location = New System.Drawing.Point(64, 297)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(395, 21)
        Me.txtamount.TabIndex = 6
        Me.txtamount.Text = "0.00"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnAttachment_remove)
        Me.GroupBox3.Controls.Add(Me.btnAttachment_add)
        Me.GroupBox3.Controls.Add(Me.lstAttachment)
        Me.GroupBox3.Location = New System.Drawing.Point(486, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(253, 430)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Attachments"
        '
        'btnAttachment_remove
        '
        Me.btnAttachment_remove.Location = New System.Drawing.Point(221, 401)
        Me.btnAttachment_remove.Name = "btnAttachment_remove"
        Me.btnAttachment_remove.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_remove.TabIndex = 10
        Me.btnAttachment_remove.Text = "-"
        Me.btnAttachment_remove.UseVisualStyleBackColor = True
        '
        'btnAttachment_add
        '
        Me.btnAttachment_add.Location = New System.Drawing.Point(189, 401)
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
        Me.lstAttachment.Size = New System.Drawing.Size(241, 377)
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
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(64, 388)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(396, 48)
        Me.txtNote.TabIndex = 8
        '
        'txtProposal
        '
        Me.txtProposal.Location = New System.Drawing.Point(64, 324)
        Me.txtProposal.Multiline = True
        Me.txtProposal.Name = "txtProposal"
        Me.txtProposal.Size = New System.Drawing.Size(396, 58)
        Me.txtProposal.TabIndex = 7
        '
        'grpRecepint
        '
        Me.grpRecepint.Controls.Add(Me.lblRecepient_id)
        Me.grpRecepint.Controls.Add(Me.txtRecepient_contactno)
        Me.grpRecepint.Controls.Add(Me.txtRecepient_Designation)
        Me.grpRecepint.Controls.Add(Me.btnRecepient_Search)
        Me.grpRecepint.Controls.Add(Me.txtRecepient_Address)
        Me.grpRecepint.Controls.Add(Me.txtRecepient_name)
        Me.grpRecepint.Controls.Add(Me.Label7)
        Me.grpRecepint.Controls.Add(Me.Label6)
        Me.grpRecepint.Controls.Add(Me.Label8)
        Me.grpRecepint.Controls.Add(Me.Label9)
        Me.grpRecepint.Location = New System.Drawing.Point(6, 86)
        Me.grpRecepint.Name = "grpRecepint"
        Me.grpRecepint.Size = New System.Drawing.Size(464, 100)
        Me.grpRecepint.TabIndex = 45
        Me.grpRecepint.TabStop = False
        Me.grpRecepint.Text = "Recepient"
        '
        'lblRecepient_id
        '
        Me.lblRecepient_id.AutoSize = True
        Me.lblRecepient_id.Location = New System.Drawing.Point(303, 6)
        Me.lblRecepient_id.Name = "lblRecepient_id"
        Me.lblRecepient_id.Size = New System.Drawing.Size(81, 13)
        Me.lblRecepient_id.TabIndex = 28
        Me.lblRecepient_id.Text = "lblRecepient_id"
        Me.lblRecepient_id.Visible = False
        '
        'txtRecepient_contactno
        '
        Me.txtRecepient_contactno.Enabled = False
        Me.txtRecepient_contactno.Location = New System.Drawing.Point(59, 68)
        Me.txtRecepient_contactno.Name = "txtRecepient_contactno"
        Me.txtRecepient_contactno.Size = New System.Drawing.Size(141, 21)
        Me.txtRecepient_contactno.TabIndex = 27
        '
        'txtRecepient_Designation
        '
        Me.txtRecepient_Designation.Enabled = False
        Me.txtRecepient_Designation.Location = New System.Drawing.Point(266, 68)
        Me.txtRecepient_Designation.Name = "txtRecepient_Designation"
        Me.txtRecepient_Designation.Size = New System.Drawing.Size(191, 21)
        Me.txtRecepient_Designation.TabIndex = 27
        '
        'btnRecepient_Search
        '
        Me.btnRecepient_Search.Location = New System.Drawing.Point(390, 18)
        Me.btnRecepient_Search.Name = "btnRecepient_Search"
        Me.btnRecepient_Search.Size = New System.Drawing.Size(67, 23)
        Me.btnRecepient_Search.TabIndex = 2
        Me.btnRecepient_Search.Text = "Search"
        Me.btnRecepient_Search.UseVisualStyleBackColor = True
        '
        'txtRecepient_Address
        '
        Me.txtRecepient_Address.Enabled = False
        Me.txtRecepient_Address.Location = New System.Drawing.Point(59, 44)
        Me.txtRecepient_Address.Name = "txtRecepient_Address"
        Me.txtRecepient_Address.Size = New System.Drawing.Size(398, 21)
        Me.txtRecepient_Address.TabIndex = 27
        '
        'txtRecepient_name
        '
        Me.txtRecepient_name.Enabled = False
        Me.txtRecepient_name.Location = New System.Drawing.Point(59, 20)
        Me.txtRecepient_name.Name = "txtRecepient_name"
        Me.txtRecepient_name.Size = New System.Drawing.Size(325, 21)
        Me.txtRecepient_name.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 27)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Contact No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(200, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Designation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Address"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Name"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.Label4)
        Me.grpStatus.Controls.Add(Me.Label5)
        Me.grpStatus.Controls.Add(Me.dtReceived)
        Me.grpStatus.Controls.Add(Me.dtApproved)
        Me.grpStatus.Controls.Add(Me.chkReceived)
        Me.grpStatus.Controls.Add(Me.chkApproved)
        Me.grpStatus.Location = New System.Drawing.Point(6, 192)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(464, 95)
        Me.grpStatus.TabIndex = 44
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Date Received"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(285, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Date Approved"
        '
        'dtReceived
        '
        Me.dtReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceived.Location = New System.Drawing.Point(17, 56)
        Me.dtReceived.Name = "dtReceived"
        Me.dtReceived.Size = New System.Drawing.Size(166, 21)
        Me.dtReceived.TabIndex = 3
        '
        'dtApproved
        '
        Me.dtApproved.Enabled = False
        Me.dtApproved.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtApproved.Location = New System.Drawing.Point(288, 56)
        Me.dtApproved.Name = "dtApproved"
        Me.dtApproved.Size = New System.Drawing.Size(167, 21)
        Me.dtApproved.TabIndex = 5
        '
        'chkReceived
        '
        Me.chkReceived.AutoSize = True
        Me.chkReceived.Checked = True
        Me.chkReceived.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReceived.Enabled = False
        Me.chkReceived.Location = New System.Drawing.Point(17, 21)
        Me.chkReceived.Name = "chkReceived"
        Me.chkReceived.Size = New System.Drawing.Size(69, 17)
        Me.chkReceived.TabIndex = 1
        Me.chkReceived.Text = "Received"
        Me.chkReceived.UseVisualStyleBackColor = True
        '
        'chkApproved
        '
        Me.chkApproved.AutoSize = True
        Me.chkApproved.Location = New System.Drawing.Point(288, 20)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.Size = New System.Drawing.Size(71, 17)
        Me.chkApproved.TabIndex = 4
        Me.chkApproved.Text = "Approved"
        Me.chkApproved.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtOrganization)
        Me.GroupBox2.Controls.Add(Me.btnAddress_Search)
        Me.GroupBox2.Controls.Add(Me.txtAddress)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lbladdress_id)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(464, 74)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recepient Address"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Org"
        '
        'txtOrganization
        '
        Me.txtOrganization.Enabled = False
        Me.txtOrganization.Location = New System.Drawing.Point(56, 42)
        Me.txtOrganization.Name = "txtOrganization"
        Me.txtOrganization.Size = New System.Drawing.Size(398, 21)
        Me.txtOrganization.TabIndex = 45
        '
        'btnAddress_Search
        '
        Me.btnAddress_Search.Location = New System.Drawing.Point(387, 18)
        Me.btnAddress_Search.Name = "btnAddress_Search"
        Me.btnAddress_Search.Size = New System.Drawing.Size(67, 23)
        Me.btnAddress_Search.TabIndex = 1
        Me.btnAddress_Search.Text = "Search"
        Me.btnAddress_Search.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(56, 18)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(325, 21)
        Me.txtAddress.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Address"
        '
        'lbladdress_id
        '
        Me.lbladdress_id.AutoSize = True
        Me.lbladdress_id.Location = New System.Drawing.Point(6, 31)
        Me.lbladdress_id.Name = "lbladdress_id"
        Me.lbladdress_id.Size = New System.Drawing.Size(39, 13)
        Me.lbladdress_id.TabIndex = 42
        Me.lbladdress_id.Text = "Label1"
        Me.lbladdress_id.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 376)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Note"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Proposal"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(415, 462)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 29)
        Me.btnNew.TabIndex = 11
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(506, 462)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 29)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(712, 462)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 29)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(597, 462)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 29)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(244, 9)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(28, 13)
        Me.lblID.TabIndex = 42
        Me.lblID.Text = "lblid"
        Me.lblID.Visible = False
        '
        'btnAttachment
        '
        Me.btnAttachment.Location = New System.Drawing.Point(12, 462)
        Me.btnAttachment.Name = "btnAttachment"
        Me.btnAttachment.Size = New System.Drawing.Size(85, 29)
        Me.btnAttachment.TabIndex = 43
        Me.btnAttachment.Text = "Attachment"
        Me.btnAttachment.UseVisualStyleBackColor = True
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Approved Status"
        '
        'frmInfrastructure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 520)
        Me.Controls.Add(Me.btnAttachment)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.grpInfra)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmInfrastructure"
        Me.Text = "Infrastructure Request"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpInfra.ResumeLayout(False)
        Me.grpInfra.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.grpRecepint.ResumeLayout(False)
        Me.grpRecepint.PerformLayout()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstInfrastructure As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents grpInfra As System.Windows.Forms.GroupBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtProposal As System.Windows.Forms.TextBox
    Friend WithEvents grpRecepint As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecepient_id As System.Windows.Forms.Label
    Friend WithEvents txtRecepient_contactno As System.Windows.Forms.TextBox
    Friend WithEvents txtRecepient_Designation As System.Windows.Forms.TextBox
    Friend WithEvents btnRecepient_Search As System.Windows.Forms.Button
    Friend WithEvents txtRecepient_Address As System.Windows.Forms.TextBox
    Friend WithEvents txtRecepient_name As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtApproved As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkReceived As System.Windows.Forms.CheckBox
    Friend WithEvents chkApproved As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbladdress_id As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAddress_Search As System.Windows.Forms.Button
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents btnAttachment As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAttachment_remove As System.Windows.Forms.Button
    Friend WithEvents btnAttachment_add As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOrganization As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblRecordFound As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
End Class
