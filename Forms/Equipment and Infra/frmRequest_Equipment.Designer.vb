<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequest_Equipment
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
        Me.lstEquipment_request = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.grpEquipmentRequest = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOrganization = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAttachment_remove = New System.Windows.Forms.Button()
        Me.btnAttachment_add = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddress_Search = New System.Windows.Forms.Button()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.grpRecepint = New System.Windows.Forms.GroupBox()
        Me.lblRecepient_id = New System.Windows.Forms.Label()
        Me.txtRecepient_contactno = New System.Windows.Forms.TextBox()
        Me.txtRecepient_Designation = New System.Windows.Forms.TextBox()
        Me.btnRecepient_Search = New System.Windows.Forms.Button()
        Me.txtRecepient_Address = New System.Windows.Forms.TextBox()
        Me.txtRecepient_name = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.grpEquipment = New System.Windows.Forms.GroupBox()
        Me.btnEquipment_Input_Delete = New System.Windows.Forms.Button()
        Me.btnEquipment_Input = New System.Windows.Forms.Button()
        Me.lstEquipment_Input = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtReceived = New System.Windows.Forms.DateTimePicker()
        Me.dtApproved = New System.Windows.Forms.DateTimePicker()
        Me.chkReceived = New System.Windows.Forms.CheckBox()
        Me.chkApproved = New System.Windows.Forms.CheckBox()
        Me.lbladdress_ID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Note = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btnAttachment = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grpEquipmentRequest.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpRecepint.SuspendLayout()
        Me.grpEquipment.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRecordFound)
        Me.GroupBox1.Controls.Add(Me.lstEquipment_request)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 469)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'lblRecordFound
        '
        Me.lblRecordFound.AutoSize = True
        Me.lblRecordFound.Location = New System.Drawing.Point(6, 451)
        Me.lblRecordFound.Name = "lblRecordFound"
        Me.lblRecordFound.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordFound.TabIndex = 32
        '
        'lstEquipment_request
        '
        Me.lstEquipment_request.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader22, Me.ColumnHeader21})
        Me.lstEquipment_request.FullRowSelect = True
        Me.lstEquipment_request.GridLines = True
        Me.lstEquipment_request.Location = New System.Drawing.Point(6, 46)
        Me.lstEquipment_request.MultiSelect = False
        Me.lstEquipment_request.Name = "lstEquipment_request"
        Me.lstEquipment_request.Size = New System.Drawing.Size(290, 402)
        Me.lstEquipment_request.TabIndex = 13
        Me.lstEquipment_request.UseCompatibleStateImageBehavior = False
        Me.lstEquipment_request.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Municipality"
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
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Approve Status"
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "User"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(262, 19)
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
        Me.txtSearch.Size = New System.Drawing.Size(250, 21)
        Me.txtSearch.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(432, 491)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 29)
        Me.btnNew.TabIndex = 18
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(523, 491)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 29)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(729, 491)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 29)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(614, 491)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 29)
        Me.btnDelete.TabIndex = 20
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'grpEquipmentRequest
        '
        Me.grpEquipmentRequest.BackColor = System.Drawing.SystemColors.Control
        Me.grpEquipmentRequest.Controls.Add(Me.Label8)
        Me.grpEquipmentRequest.Controls.Add(Me.txtOrganization)
        Me.grpEquipmentRequest.Controls.Add(Me.GroupBox2)
        Me.grpEquipmentRequest.Controls.Add(Me.btnAddress_Search)
        Me.grpEquipmentRequest.Controls.Add(Me.txtAddress)
        Me.grpEquipmentRequest.Controls.Add(Me.grpRecepint)
        Me.grpEquipmentRequest.Controls.Add(Me.txtNote)
        Me.grpEquipmentRequest.Controls.Add(Me.grpEquipment)
        Me.grpEquipmentRequest.Controls.Add(Me.grpStatus)
        Me.grpEquipmentRequest.Controls.Add(Me.lbladdress_ID)
        Me.grpEquipmentRequest.Controls.Add(Me.Label3)
        Me.grpEquipmentRequest.Controls.Add(Me.Note)
        Me.grpEquipmentRequest.Controls.Add(Me.lblID)
        Me.grpEquipmentRequest.Location = New System.Drawing.Point(332, 5)
        Me.grpEquipmentRequest.Name = "grpEquipmentRequest"
        Me.grpEquipmentRequest.Size = New System.Drawing.Size(747, 476)
        Me.grpEquipmentRequest.TabIndex = 30
        Me.grpEquipmentRequest.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Org"
        '
        'txtOrganization
        '
        Me.txtOrganization.Enabled = False
        Me.txtOrganization.Location = New System.Drawing.Point(74, 147)
        Me.txtOrganization.Name = "txtOrganization"
        Me.txtOrganization.Size = New System.Drawing.Size(398, 21)
        Me.txtOrganization.TabIndex = 42
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAttachment_remove)
        Me.GroupBox2.Controls.Add(Me.btnAttachment_add)
        Me.GroupBox2.Controls.Add(Me.lstAttachment)
        Me.GroupBox2.Location = New System.Drawing.Point(488, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(253, 453)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Attachments"
        '
        'btnAttachment_remove
        '
        Me.btnAttachment_remove.Location = New System.Drawing.Point(221, 418)
        Me.btnAttachment_remove.Name = "btnAttachment_remove"
        Me.btnAttachment_remove.Size = New System.Drawing.Size(26, 23)
        Me.btnAttachment_remove.TabIndex = 43
        Me.btnAttachment_remove.Text = "-"
        Me.btnAttachment_remove.UseVisualStyleBackColor = True
        '
        'btnAttachment_add
        '
        Me.btnAttachment_add.Location = New System.Drawing.Point(189, 418)
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
        Me.lstAttachment.Size = New System.Drawing.Size(241, 397)
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
        'btnAddress_Search
        '
        Me.btnAddress_Search.Location = New System.Drawing.Point(405, 120)
        Me.btnAddress_Search.Name = "btnAddress_Search"
        Me.btnAddress_Search.Size = New System.Drawing.Size(67, 23)
        Me.btnAddress_Search.TabIndex = 39
        Me.btnAddress_Search.Text = "Search"
        Me.btnAddress_Search.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(74, 120)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(325, 21)
        Me.txtAddress.TabIndex = 38
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
        Me.grpRecepint.Controls.Add(Me.Label1)
        Me.grpRecepint.Controls.Add(Me.Label6)
        Me.grpRecepint.Controls.Add(Me.Label5)
        Me.grpRecepint.Location = New System.Drawing.Point(15, 14)
        Me.grpRecepint.Name = "grpRecepint"
        Me.grpRecepint.Size = New System.Drawing.Size(464, 100)
        Me.grpRecepint.TabIndex = 37
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
        Me.btnRecepient_Search.TabIndex = 25
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(200, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Designation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Name"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(74, 174)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(398, 29)
        Me.txtNote.TabIndex = 36
        '
        'grpEquipment
        '
        Me.grpEquipment.Controls.Add(Me.btnEquipment_Input_Delete)
        Me.grpEquipment.Controls.Add(Me.btnEquipment_Input)
        Me.grpEquipment.Controls.Add(Me.lstEquipment_Input)
        Me.grpEquipment.Location = New System.Drawing.Point(18, 297)
        Me.grpEquipment.Name = "grpEquipment"
        Me.grpEquipment.Size = New System.Drawing.Size(464, 170)
        Me.grpEquipment.TabIndex = 35
        Me.grpEquipment.TabStop = False
        Me.grpEquipment.Text = "Equipment/s"
        '
        'btnEquipment_Input_Delete
        '
        Me.btnEquipment_Input_Delete.Location = New System.Drawing.Point(432, 49)
        Me.btnEquipment_Input_Delete.Name = "btnEquipment_Input_Delete"
        Me.btnEquipment_Input_Delete.Size = New System.Drawing.Size(26, 23)
        Me.btnEquipment_Input_Delete.TabIndex = 25
        Me.btnEquipment_Input_Delete.Text = "-"
        Me.btnEquipment_Input_Delete.UseVisualStyleBackColor = True
        '
        'btnEquipment_Input
        '
        Me.btnEquipment_Input.Location = New System.Drawing.Point(432, 20)
        Me.btnEquipment_Input.Name = "btnEquipment_Input"
        Me.btnEquipment_Input.Size = New System.Drawing.Size(26, 23)
        Me.btnEquipment_Input.TabIndex = 25
        Me.btnEquipment_Input.Text = "+"
        Me.btnEquipment_Input.UseVisualStyleBackColor = True
        '
        'lstEquipment_Input
        '
        Me.lstEquipment_Input.AllowDrop = True
        Me.lstEquipment_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstEquipment_Input.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lstEquipment_Input.FullRowSelect = True
        Me.lstEquipment_Input.GridLines = True
        Me.lstEquipment_Input.Location = New System.Drawing.Point(17, 20)
        Me.lstEquipment_Input.MultiSelect = False
        Me.lstEquipment_Input.Name = "lstEquipment_Input"
        Me.lstEquipment_Input.Size = New System.Drawing.Size(409, 138)
        Me.lstEquipment_Input.TabIndex = 0
        Me.lstEquipment_Input.TabStop = False
        Me.lstEquipment_Input.UseCompatibleStateImageBehavior = False
        Me.lstEquipment_Input.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ID"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Equipment"
        Me.ColumnHeader6.Width = 140
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Req Quantity"
        Me.ColumnHeader7.Width = 50
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Del Quantity"
        Me.ColumnHeader8.Width = 50
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date Delivered"
        Me.ColumnHeader9.Width = 90
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Note"
        Me.ColumnHeader10.Width = 160
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Name"
        Me.ColumnHeader12.Width = 130
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Designation"
        Me.ColumnHeader13.Width = 100
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.Label4)
        Me.grpStatus.Controls.Add(Me.Label2)
        Me.grpStatus.Controls.Add(Me.dtReceived)
        Me.grpStatus.Controls.Add(Me.dtApproved)
        Me.grpStatus.Controls.Add(Me.chkReceived)
        Me.grpStatus.Controls.Add(Me.chkApproved)
        Me.grpStatus.Location = New System.Drawing.Point(18, 204)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(464, 87)
        Me.grpStatus.TabIndex = 34
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Date Received"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(285, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Date Approved"
        '
        'dtReceived
        '
        Me.dtReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceived.Location = New System.Drawing.Point(17, 55)
        Me.dtReceived.Name = "dtReceived"
        Me.dtReceived.Size = New System.Drawing.Size(166, 21)
        Me.dtReceived.TabIndex = 3
        '
        'dtApproved
        '
        Me.dtApproved.Enabled = False
        Me.dtApproved.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtApproved.Location = New System.Drawing.Point(288, 55)
        Me.dtApproved.Name = "dtApproved"
        Me.dtApproved.Size = New System.Drawing.Size(167, 21)
        Me.dtApproved.TabIndex = 3
        '
        'chkReceived
        '
        Me.chkReceived.AutoSize = True
        Me.chkReceived.Checked = True
        Me.chkReceived.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReceived.Enabled = False
        Me.chkReceived.Location = New System.Drawing.Point(17, 20)
        Me.chkReceived.Name = "chkReceived"
        Me.chkReceived.Size = New System.Drawing.Size(69, 17)
        Me.chkReceived.TabIndex = 1
        Me.chkReceived.Text = "Received"
        Me.chkReceived.UseVisualStyleBackColor = True
        '
        'chkApproved
        '
        Me.chkApproved.AutoSize = True
        Me.chkApproved.Location = New System.Drawing.Point(288, 19)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.Size = New System.Drawing.Size(71, 17)
        Me.chkApproved.TabIndex = 1
        Me.chkApproved.Text = "Approved"
        Me.chkApproved.UseVisualStyleBackColor = True
        '
        'lbladdress_ID
        '
        Me.lbladdress_ID.AutoSize = True
        Me.lbladdress_ID.Location = New System.Drawing.Point(71, 109)
        Me.lbladdress_ID.Name = "lbladdress_ID"
        Me.lbladdress_ID.Size = New System.Drawing.Size(72, 13)
        Me.lbladdress_ID.TabIndex = 31
        Me.lbladdress_ID.Text = "lblAddress_ID"
        Me.lbladdress_ID.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Address"
        '
        'Note
        '
        Me.Note.AutoSize = True
        Me.Note.Location = New System.Drawing.Point(33, 174)
        Me.Note.Name = "Note"
        Me.Note.Size = New System.Drawing.Size(30, 13)
        Me.Note.TabIndex = 33
        Me.Note.Text = "Note"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(33, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(115, 13)
        Me.lblID.TabIndex = 30
        Me.lblID.Text = "equipment_request_id"
        Me.lblID.Visible = False
        '
        'btnAttachment
        '
        Me.btnAttachment.Location = New System.Drawing.Point(12, 491)
        Me.btnAttachment.Name = "btnAttachment"
        Me.btnAttachment.Size = New System.Drawing.Size(85, 29)
        Me.btnAttachment.TabIndex = 31
        Me.btnAttachment.Text = "Attachment"
        Me.btnAttachment.UseVisualStyleBackColor = True
        '
        'frmRequest_Equipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 532)
        Me.Controls.Add(Me.btnAttachment)
        Me.Controls.Add(Me.grpEquipmentRequest)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRequest_Equipment"
        Me.Text = "Equipment Request"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpEquipmentRequest.ResumeLayout(False)
        Me.grpEquipmentRequest.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grpRecepint.ResumeLayout(False)
        Me.grpRecepint.PerformLayout()
        Me.grpEquipment.ResumeLayout(False)
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstEquipment_request As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents grpEquipmentRequest As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddress_Search As System.Windows.Forms.Button
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents grpRecepint As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecepient_id As System.Windows.Forms.Label
    Friend WithEvents txtRecepient_contactno As System.Windows.Forms.TextBox
    Friend WithEvents txtRecepient_Designation As System.Windows.Forms.TextBox
    Friend WithEvents btnRecepient_Search As System.Windows.Forms.Button
    Friend WithEvents txtRecepient_Address As System.Windows.Forms.TextBox
    Friend WithEvents txtRecepient_name As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents grpEquipment As System.Windows.Forms.GroupBox
    Friend WithEvents btnEquipment_Input_Delete As System.Windows.Forms.Button
    Friend WithEvents btnEquipment_Input As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtApproved As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkReceived As System.Windows.Forms.CheckBox
    Friend WithEvents chkApproved As System.Windows.Forms.CheckBox
    Friend WithEvents lbladdress_ID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Note As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstEquipment_Input As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAttachment As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAttachment_add As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAttachment_remove As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOrganization As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblRecordFound As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
End Class
