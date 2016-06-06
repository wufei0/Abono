Imports System.Data.Odbc
Imports System.IO
Public Class frmRequest_Equipment

    Private m_SortingColumn As ColumnHeader

    Private Sub frmRequest_Equipment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Me.MdiParent = MdiAbono
        'MsgBox(Me.BackColor.ToString)
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT_REQUEST JOIN MUNICIPALITY ON EQUIPMENT_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON EQUIPMENT_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID")
        'radRecepient.Checked = True
        Me.Width = 821

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim gUIDcREATE As String = GuidGenerator("ERQ", Me.Name)
        Dim delivery_date As String = Nothing
        Dim requested_quantity As Integer = Nothing
        Dim delivered_quantity As Integer = Nothing
        Dim FS As FileStream
        Dim RawData() As Byte
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdRecordset As OdbcDataReader
        Dim FbirdTransaction As OdbcTransaction

        If lblRecepient_id.Text = Nothing Then
            Beep()
            Exit Sub
        End If
        If lbladdress_ID.Text = Nothing Then
            Beep()
            Exit Sub
        End If
        If lstEquipment_Input.Items.Count = 0 Then
            Beep()
            Exit Sub
        End If

        If DuplicateIdentifier("SELECT COUNT(RECEPIENT_ID) FROM EQUIPMENT_REQUEST WHERE RECEPIENT_ID = '" & lblRecepient_id.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry of Recepient. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Using FbirdCommand

            Try
                Call FBirdConnectionOpen()
                FbirdCommand.Connection = FBirdConnection
                FbirdTransaction = FBirdConnection.BeginTransaction
                FbirdCommand.Transaction = FbirdTransaction

                If lblID.Text = Nothing Then

                    lblID.Text = gUIDcREATE
                    Dim Approved_Bv As Integer
                    Dim Approved_data As Date

                    If chkApproved.Checked = True Then
                        Approved_Bv = 1
                        Approved_data = dtApproved.Value
                    ElseIf chkApproved.Checked = False Then
                        Approved_Bv = 0
                        Approved_data = Nothing
                    End If

                    ''start insert attachements
                    For CounterY = 0 To lstAttachment.Items.Count - 1
                        FS = New FileStream(lstAttachment.Items(CounterY).SubItems(1).Text, FileMode.Open, FileAccess.Read)
                        RawData = New Byte(FS.Length) {}
                        FS.Read(RawData, 0, FS.Length)
                        FS.Close()
                        FbirdCommand.Parameters.Clear()
                        'FbirdCommand.CommandText = "UPDATE ATTACHMENT("
                        FbirdCommand.CommandText = "INSERT INTO ATTACHMENT(ATTACHMENT_ID,ID,ATTACHMENT_BIN,NOTE,FILENAME) VALUES (?,?,?,?,?)"

                        FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(CounterY).Text)
                        FbirdCommand.Parameters.AddWithValue("@ID", lblID.Text)
                        FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_BIN", RawData)
                        FbirdCommand.Parameters.AddWithValue("@NOTE", lstAttachment.Items(CounterY).SubItems(3).Text)
                        FbirdCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(CounterY).SubItems(2).Text)
                        FbirdCommand.ExecuteNonQuery()
                    Next
                    ''end insert attachements

                    FBsql = "INSERT INTO EQUIPMENT_REQUEST(EQUIPMENT_REQUEST_ID,RECEPIENT_ID,DATE_RECEIVED,APPROVED_BV,APPROVED_DATE,NOTE,SECURITY_USER,MUNICIPALITY_ID) VALUES (?,?,?,?,?,?,?,?)"
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.Parameters.Clear()
                    FbirdCommand.Parameters.AddWithValue("EQUIPMENT_REQUEST_ID", lblID.Text)
                    FbirdCommand.Parameters.AddWithValue("RECEPIENT_ID", lblRecepient_id.Text)
                    FbirdCommand.Parameters.AddWithValue("DATE_RECEIVED", dtReceived.Value)
                    FbirdCommand.Parameters.AddWithValue("APPROVED_BV", Approved_Bv)
                    FbirdCommand.Parameters.AddWithValue("APPROVED_DATE", Approved_data)
                    FbirdCommand.Parameters.AddWithValue("NOTE", txtNote.Text)
                    FbirdCommand.Parameters.AddWithValue("SECURITY_USER", MdiAbono.TSUserName.Text)
                    FbirdCommand.Parameters.AddWithValue("MUNICIPALITY_ID", lbladdress_ID.Text)
                    FbirdCommand.ExecuteNonQuery()
                    For CountX = 0 To lstEquipment_Input.Items.Count - 1

                        Dim equipment_request_id, equipment_id, note As String


                        equipment_request_id = lblID.Text
                        equipment_id = lstEquipment_Input.Items(CountX).SubItems(0).Text
                        note = lstEquipment_Input.Items(CountX).SubItems(5).Text
                        requested_quantity = lstEquipment_Input.Items(CountX).SubItems(2).Text
                        If lstEquipment_Input.Items(CountX).SubItems(3).Text = "" Then
                            delivered_quantity = 0
                        Else

                            delivered_quantity = lstEquipment_Input.Items(CountX).SubItems(3).Text
                        End If

                        'If lstEquipment_Input.Items(CountX).SubItems(4).Text = "" Then
                        '    delivery_date = Nothing
                        'Else
                        delivery_date = lstEquipment_Input.Items(CountX).SubItems(4).Text
                        'End If


                        'FbirdCommand.Parameters.AddWithValue("REQUESTED_QUANTITY", requested_quantity)
                        If lstEquipment_Input.Items(CountX).SubItems(4).Text = "" Then
                            FBsql = "INSERT INTO CONT_EQUIPMENT_REQUEST(EQUIPMENT_REQUEST_ID,EQUIPMENT_ID,REQUESTED_QUANTITY,DELIVERED_QUANTITY,NOTE,RECEPIENT_NAME,RECEPIENT_DESIGNATION)"
                            FBsql = FBsql + "VALUES ('" & equipment_request_id & "','" & equipment_id & "'," & requested_quantity & " ," & delivered_quantity & ",'" & note & "','" & lstEquipment_Input.Items(CountX).SubItems(6).Text & "','" & lstEquipment_Input.Items(CountX).SubItems(7).Text & "')"
                        Else

                            FBsql = "INSERT INTO CONT_EQUIPMENT_REQUEST(EQUIPMENT_REQUEST_ID,EQUIPMENT_ID,REQUESTED_QUANTITY,DELIVERED_QUANTITY,NOTE,DELIVERY_DATE,RECEPIENT_NAME,RECEPIENT_DESIGNATION)"
                            FBsql = FBsql + "VALUES ('" & equipment_request_id & "','" & equipment_id & "'," & requested_quantity & " ," & delivered_quantity & ",'" & note & "','" & delivery_date & "','" & lstEquipment_Input.Items(CountX).SubItems(6).Text & "','" & lstEquipment_Input.Items(CountX).SubItems(7).Text & "')"
                        End If
                        FbirdCommand.CommandText = FBsql


                        FbirdCommand.ExecuteNonQuery()
                    Next




                ElseIf lblID.Text <> Nothing Then
                    If chkApproved.Checked = True Then
                        'delivery_date = dtReceived.Text
                        ''SQL FOR EQUIPMENT REQUEST
                        FBsql = "UPDATE EQUIPMENT_REQUEST"
                        FBsql = FBsql & " SET RECEPIENT_ID = '" & lblRecepient_id.Text & "',DATE_RECEIVED= '" & dtReceived.Text & "',APPROVED_BV=1,APPROVED_DATE='" & dtApproved.Text & "' "
                        FBsql = FBsql & ",NOTE= '" & txtNote.Text & "', MUNICIPALITY_ID = '" & lbladdress_ID.Text & "' , SECURITY_USER='" & MdiAbono.TSUserName.Text & "' WHERE EQUIPMENT_REQUEST_ID LIKE '" & lblID.Text & "' "
                    Else
                        FBsql = "UPDATE EQUIPMENT_REQUEST"
                        FBsql = FBsql & " SET RECEPIENT_ID = '" & lblRecepient_id.Text & "',DATE_RECEIVED= '" & dtReceived.Text & "',APPROVED_BV=0,APPROVED_DATE=NULL "
                        FBsql = FBsql & ",NOTE= '" & txtNote.Text & "', MUNICIPALITY_ID = '" & lbladdress_ID.Text & "' , SECURITY_USER='" & MdiAbono.TSUserName.Text & "' WHERE EQUIPMENT_REQUEST_ID LIKE '" & lblID.Text & "' "
                    End If
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()
                    'DELETE CONTENTS OF CONT_EQUIPMENT_REQUEST BEFORE RE-INSERTING/UPDATING OF 
                    'NEW EQUIPMENT REQUEST
                    FBsql = "DELETE FROM CONT_EQUIPMENT_REQUEST WHERE EQUIPMENT_REQUEST_ID = '" & lblID.Text & "' "
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()

                    'RE INSERT OF EQUIPMENTS ON CONT_EQUIPMENT_REQUEST
                    For CountX = 0 To lstEquipment_Input.Items.Count - 1

                        Dim equipment_request_id, equipment_id, note As String


                        equipment_request_id = lblID.Text
                        equipment_id = lstEquipment_Input.Items(CountX).SubItems(0).Text
                        note = lstEquipment_Input.Items(CountX).SubItems(5).Text
                        requested_quantity = lstEquipment_Input.Items(CountX).SubItems(2).Text
                        If lstEquipment_Input.Items(CountX).SubItems(3).Text = "" Then
                            delivered_quantity = 0
                        Else

                            delivered_quantity = lstEquipment_Input.Items(CountX).SubItems(3).Text
                        End If

                        delivery_date = lstEquipment_Input.Items(CountX).SubItems(4).Text

                        If lstEquipment_Input.Items(CountX).SubItems(4).Text = "" Then
                            FBsql = "INSERT INTO CONT_EQUIPMENT_REQUEST(EQUIPMENT_REQUEST_ID,EQUIPMENT_ID,REQUESTED_QUANTITY,DELIVERED_QUANTITY,NOTE,RECEPIENT_NAME, SECURITY_USER,RECEPIENT_DESIGNATION)"
                            FBsql = FBsql + "VALUES ('" & equipment_request_id & "','" & equipment_id & "'," & requested_quantity & " ," & delivered_quantity & ",'" & note & "','" & lstEquipment_Input.Items(CountX).SubItems(6).Text & "', '" & MdiAbono.TSUserName.Text & "','" & lstEquipment_Input.Items(CountX).SubItems(7).Text & "')"
                        Else

                            FBsql = "INSERT INTO CONT_EQUIPMENT_REQUEST(EQUIPMENT_REQUEST_ID,EQUIPMENT_ID,REQUESTED_QUANTITY,DELIVERED_QUANTITY,NOTE,DELIVERY_DATE,RECEPIENT_NAME, SECURITY_USER,RECEPIENT_DESIGNATION)"
                            FBsql = FBsql + "VALUES ('" & equipment_request_id & "','" & equipment_id & "'," & requested_quantity & " ," & delivered_quantity & ",'" & note & "','" & delivery_date & "','" & lstEquipment_Input.Items(CountX).SubItems(6).Text & "', '" & MdiAbono.TSUserName.Text & "','" & lstEquipment_Input.Items(CountX).SubItems(7).Text & "')"
                        End If
                        FbirdCommand.CommandText = FBsql
                        FbirdCommand.ExecuteNonQuery()
                    Next

                    ''START DELETE CONTENTS OF TEMP DIRECTORY
                    'Call Delete_Temp(My.Application.Info.DirectoryPath & "\TEMP\EQUIPMENT\")
                    ''END DELETE CONTENTS OF TEMP DIRECTORY

                    ''start delete OF PDF NOT IN LISTVIEW  before insert
                    FBsql = "SELECT ATTACHMENT_ID FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
                    FbirdCommand.CommandText = FBsql
                    FbirdRecordset = FbirdCommand.ExecuteReader
                    Dim Attachment_id_checker As Boolean
                    Dim Attachment_id_array(50) As String
                    Dim CounterG As Integer = 0
                    While FbirdRecordset.Read
                        Attachment_id_checker = False
                        For countL = 0 To lstAttachment.Items.Count - 1
                            If FbirdRecordset!ATTACHMENT_ID = lstAttachment.Items(countL).Text Then
                                Attachment_id_checker = True
                            End If

                        Next


                        If Attachment_id_checker = False Then
                            Attachment_id_array(CounterG) = FbirdRecordset!ATTACHMENT_ID.ToString

                            CounterG = CounterG + 1
                        End If
                    End While
                    FbirdRecordset.Close()

                    For Each value In Attachment_id_array
                        FBsql = "DELETE FROM ATTACHMENT WHERE ATTACHMENT_ID = '" & value & "' "
                        FbirdCommand.CommandText = FBsql
                        FbirdCommand.ExecuteNonQuery()
                    Next


                    ''end delete OF PDF NOT IN LISTVIEW  before insert


                    For CountZ = 0 To lstAttachment.Items.Count - 1
                        If lstAttachment.Items(CountZ).SubItems(1).Text = "" Then
                            'FBsql = "SELECT ATTACHMENT_BIN FROM ATTACHMENT WHERE ATTACHMENT_ID = '" & lstAttachment.Items(CountZ).Text & "' "
                            'FbirdCommand.CommandText = FBsql
                            'FbirdRecordset = FbirdCommand.ExecuteReader
                            'FbirdRecordset.Read()
                            ''Attach_temp_loc = Attach_temp_loc & FbirdRecordset!ATTACHMENT_ID.ToString & "a.pdf"
                            'Attach_temp_loc = Attach_temp_loc & CountZ & ".pdf"
                            'ReDim b(FbirdRecordset.GetBytes(PICTURECOL, 0, Nothing, 0, Integer.MaxValue) - 1)
                            'FbirdRecordset.GetBytes(PICTURECOL, 0, b, 0, b.Length)
                            'FS = New FileStream(Attach_temp_loc, FileMode.Create, FileAccess.Write)
                            'FS.Write(b, 0, b.Length)
                            'FS.Close()

                            'FbirdRecordset.Close()
                            'lstAttachment.Items(CountZ).SubItems(1).Text = Attach_temp_loc

                            'FS = New FileStream(lstAttachment.Items(CountZ).SubItems(1).Text, FileMode.Open, FileAccess.Read)
                            'RawData = New Byte(FS.Length) {}
                            'FS.Read(RawData, 0, FS.Length)
                            'FS.Close()

                            'FbirdCommand.CommandText = "UPDATE ATTACHMENT("
                            'FbirdCommand.CommandText = "INSERT INTO ATTACHMENT(ATTACHMENT_ID,ID,ATTACHMENT_BIN,NOTE,FILENAME) VALUES (?,?,?,?,?)"
                            'FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(CountZ).Text)
                            'FbirdCommand.Parameters.AddWithValue("@ID", lblID.Text)
                            'FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_BIN", RawData)
                            'FbirdCommand.Parameters.AddWithValue("@NOTE", lstAttachment.Items(CountZ).SubItems(3).Text)
                            'FbirdCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(CountZ).SubItems(2).Text)
                            'FbirdCommand.ExecuteNonQuery()

                        Else

                            FS = New FileStream(lstAttachment.Items(CountZ).SubItems(1).Text, FileMode.Open, FileAccess.Read)
                            RawData = New Byte(FS.Length) {}
                            FS.Read(RawData, 0, FS.Length)
                            FS.Close()
                            FbirdCommand.Parameters.Clear()
                            'FbirdCommand.CommandText = "UPDATE ATTACHMENT("
                            FbirdCommand.CommandText = "INSERT INTO ATTACHMENT(ATTACHMENT_ID,ID,ATTACHMENT_BIN,NOTE,FILENAME) VALUES (?,?,?,?,?)"
                            FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(CountZ).Text)
                            FbirdCommand.Parameters.AddWithValue("@ID", lblID.Text)
                            FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_BIN", RawData)
                            FbirdCommand.Parameters.AddWithValue("@NOTE", lstAttachment.Items(CountZ).SubItems(3).Text)
                            FbirdCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(CountZ).SubItems(2).Text)
                            FbirdCommand.ExecuteNonQuery()


                        End If




                    Next

                    ''END DOWNLOAD ATTACHMENTS BEFORE DELETE









                    'FBsql = "DELETE FROM CONT_EQUIPMENT_REQUEST WHERE EQUIPMENT_REQUEST_ID = '" & lblID.Text & "'"
                End If

                FbirdTransaction.Commit()
                FBirdConnection.Close()
                MsgBox("Request saved successful", vbInformation, My.Application.Info.Title.ToString)
                Call Proc_Button_Save(Me.Name)
                Call Proc_Textbox_Save(Me.Name)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FbirdTransaction.Rollback()
                FBirdConnection.Close()

            Finally
                FbirdCommand.Dispose()
            End Try
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
        lstAttachment.Items.Clear()
    End Sub

    Private Sub btnEquipment_Input_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipment_Input.Click
        Proc_listview_Refresh(frmRequest_Equipment_Input.Name, "SELECT * FROM EQUIPMENT")
        frmRequest_Equipment_Input.GroupBox1.Enabled = True
        frmRequest_Equipment_Input.txtRequest_Delivered.Enabled = False
        frmRequest_Equipment_Input.txtNote.Enabled = False
        frmRequest_Equipment_Input.btnAdd.Text = "Add"
        frmRequest_Equipment_Input.Enabled = True
        frmRequest_Equipment_Input.dtDate.Enabled = False
        Proc_Textbox_New(frmRequest_Equipment_Input.Name)

        frmRequest_Equipment_Input.ShowDialog()
    End Sub

    Private Sub btnEquipment_Input_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipment_Input_Delete.Click
        On Error Resume Next

        lstEquipment_Input.SelectedItems(0).Remove()
    End Sub

    Private Sub btnRecepient_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecepient_Search.Click
        With frmSearch
            .lstSearch.Columns.Clear()
            .lstSearch.Columns.Add("RECEPIENT_ID", 0)
            .lstSearch.Columns.Add("Name", 140)
            .lstSearch.Columns.Add("Address", 190)
            .lstSearch.Columns.Add("Designation", 90)
            .lstSearch.Columns.Add("Contact No", 80)
            Proc_listview_Refresh("frmSearch_Recepient", "SELECT * FROM RECEPIENT ORDER BY RECEPIENT_NAME ASC")
            .frmSearch_Key = "RECEPIENT"
            .ShowDialog()
        End With

        'frmSearch.ShowDialog()
    End Sub

    Private Sub btnAddress_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddress_Search.Click
        With frmSearch
            .lstSearch.Columns.Clear()
            .lstSearch.Columns.Add("MUNICIPALITY_ID", 0)
            .lstSearch.Columns.Add("Barangay", 140)
            .lstSearch.Columns.Add("Municipality", 190)
            .lstSearch.Columns.Add("Province", 90)
            .lstSearch.Columns.Add("Organization", 150)
            Proc_listview_Refresh("frmSearch_Address", "SELECT * FROM MUNICIPALITY ORDER BY BARANGAY ASC")
            .frmSearch_Key = "MUNICIPALITY"
            .ShowDialog()
        End With
    End Sub


    Private Sub chkApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApproved.CheckedChanged
        If chkApproved.Checked = False Then
            dtApproved.Enabled = False
        ElseIf chkApproved.Checked = True Then
            dtApproved.Enabled = True

        End If
    End Sub

    Private Sub lstEquipment_Input_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstEquipment_Input.DoubleClick, lstEquipment_Input.DoubleClick
        'On Error Resume Next
        With frmRequest_Equipment_Input
            .txtNote.Enabled = True
            .txtRequest_Delivered.Enabled = True
            .GroupBox1.Enabled = False
            .btnAdd.Enabled = True
            .dtDate.Enabled = True
            .txtRequest_Quantity.Enabled = False
            .txtName.Enabled = True
            .txtDesignation.Enabled = True

            .lblEquipment_ID.Text = lstEquipment_Input.SelectedItems(0).SubItems(0).Text
            .txtEquipment_Name.Text = lstEquipment_Input.SelectedItems(0).SubItems(1).Text
            '.txtEquipment_Description.Text = lstEquipment_Input.SelectedItems(0).SubItems(2).Text
            .txtRequest_Quantity.Text = lstEquipment_Input.SelectedItems(0).SubItems(2).Text
            .txtRequest_Delivered.Text = lstEquipment_Input.SelectedItems(0).SubItems(3).Text
            .dtDate.Text = lstEquipment_Input.SelectedItems(0).SubItems(4).Text
            .txtNote.Text = lstEquipment_Input.SelectedItems(0).SubItems(5).Text
            .txtName.Text = lstEquipment_Input.SelectedItems(0).SubItems(6).Text
            .txtDesignation.Text = lstEquipment_Input.SelectedItems(0).SubItems(7).Text
            'Using FBcommand
            '    Try
            '        FBcommand.Connection = FBirdConnection
            '        FBcommand.CommandText = "SELECT * FROM CONT_EQUIPMENT_REQUEST JOIN EQUIPMENT ON CONT_EQUIPMENT_REQUEST.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE EQUIPMENT_REQUEST_ID LIKE '" & lblID.Text & "' "

            '        If FBRecordset.IsClosed = False Then FBRecordset.Close()
            '        FBRecordset = FBcommand.ExecuteReader
            '        FBRecordset.Read()
            '        .txtEquipment_Name.Text = FBRecordset!EQUIPMENT_NAME.ToString
            '        .txtEquipment_Description.Text = FBRecordset!EQUIPMENT_DESCRIPTION.ToString
            '        .txtRequest_Quantity.Text = FBRecordset!REQUEST_QUANTITY.ToString
            '        .txtRequest_Delivered.Text = FBRecordset!REQUEST_DELIVERED.ToString
            '        .dtDate.Value = FBRecordset!DELIVERY_DATE
            '        .txtName.Text = FBRecordset!RECEPIENT_NAME.ToString


            '    Catch ex As Exception
            '        MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            '        FBRecordset.Close()
            '    End Try
            'End Using





            '.txtDesignation.Text = lstEquipment_Input.SelectedItems(0).SubItems(7).Text
            '.txtDesignation.Text = lstEquipment_Input.SelectedItems(0).SubItems(7).Text
            'MsgBox(lstEquipment_Input.Columns.Count)
            .btnAdd.Text = "Update"
            .ShowDialog()

        End With
    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FBsql = "SELECT distinct  EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID,BARANGAY,MUNICIPALITY,RECEPIENT.RECEPIENT_NAME,EQUIPMENT_REQUEST.DATE_RECEIVED,EQUIPMENT_REQUEST.SECURITY_USER, EQUIPMENT_REQUEST.approved_bv FROM EQUIPMENT_REQUEST JOIN MUNICIPALITY ON EQUIPMENT_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON EQUIPMENT_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID"
        FBsql = FBsql & " JOIN CONT_EQUIPMENT_REQUEST ON EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID = CONT_EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID JOIN EQUIPMENT ON CONT_EQUIPMENT_REQUEST.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID"
        FBsql = FBsql & " WHERE RECEPIENT.RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION like  '%" & txtSearch.Text & "%' OR EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' "

        'If radRecepient.Checked = True Then
        Call Proc_listview_Refresh(Me.Name, FBsql)
        'ElseIf radEquipment.Checked = True Then
        'Call Proc_listview_Refresh(Me.Name, "SELECT DISTINCT EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID, MUNICIPALITY.MUNICIPALITY, RECEPIENT.RECEPIENT_NAME, EQUIPMENT_REQUEST.DATE_RECEIVED FROM EQUIPMENT_REQUEST JOIN MUNICIPALITY ON EQUIPMENT_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON EQUIPMENT_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID  JOIN   CONT_EQUIPMENT_REQUEST ON EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID = CONT_EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID JOIN EQUIPMENT ON CONT_EQUIPMENT_REQUEST.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID  WHERE EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' ")

        'End If


    End Sub

    Private Sub lstEquipment_request_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstEquipment_request.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstEquipment_request.Columns(e.Column)
        ' Figure out the new sorting order.  
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.  
            sort_order = SortOrder.Ascending
        Else ' See if this is the same column.  
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.  
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.  
                sort_order = SortOrder.Ascending
            End If
            ' Remove the old sort indicator.  
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If
        ' Display the new sort order.  
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If
        ' Create a comparer.  
        lstEquipment_request.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstEquipment_request.Sort()
    End Sub

    Private Sub lstEquipment_request_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstEquipment_request.Disposed

    End Sub

    Private Sub lstEquipment_request_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstEquipment_request.DoubleClick
        Dim FBDataReader As OdbcDataReader
        Me.Cursor = Cursors.WaitCursor
        Using FBcommand
            Try
                Call FBirdConnectionOpen()
                'If FBRecordset.IsClosed = False Then FBRecordset.Close()
                FBcommand.Connection = FBirdConnection
                FBsql = "SELECT * FROM EQUIPMENT_REQUEST WHERE EQUIPMENT_REQUEST_ID LIKE '" & lstEquipment_request.SelectedItems(0).Text & "'"
                FBcommand.CommandText = FBsql
                FBDataReader = FBcommand.ExecuteReader
                FBDataReader.Read()

                lblID.Text = FBDataReader!EQUIPMENT_REQUEST_ID.ToString
                lbladdress_ID.Text = FBDataReader!MUNICIPALITY_ID.ToString
                lblRecepient_id.Text = FBDataReader!RECEPIENT_ID.ToString
                txtNote.Text = FBDataReader!NOTE.ToString
                dtReceived.Value = FBDataReader!DATE_RECEIVED

                If FBDataReader!APPROVED_BV = 1 Then
                    chkApproved.Checked = True
                    dtApproved.Enabled = True
                    dtApproved.Value = FBDataReader!APPROVED_DATE
                Else
                    chkApproved.Checked = False
                    dtApproved.Enabled = False
                End If

                FBirdConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            Finally
                FBcommand.Dispose()
                If FBDataReader.IsClosed = False Then FBDataReader.Close()
            End Try

        End Using

        Using FBcommand
            Try
                'If FBRecordset.IsClosed = False Then FBRecordset.Close()
                Call FBirdConnectionOpen()
                FBcommand.Connection = FBirdConnection
                FBsql = "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY_ID = '" & lbladdress_ID.Text & "' "
                FBcommand.CommandText = FBsql
                'FBRecordset.Close()
                'FBcommand.Dispose()
                'FBcommand = New Odbc.OdbcCommand

                FBDataReader = FBcommand.ExecuteReader
                FBDataReader.Read()
                txtAddress.Text = FBDataReader!BARANGAY.ToString & ", " & FBDataReader!MUNICIPALITY.ToString & ", " & FBDataReader!PROVINCE.ToString
                txtOrganization.Text = FBDataReader!organization.ToString

                FBirdConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                'FBRecordset.Close()
                FBirdConnection.Close()
            Finally
                If FBDataReader.IsClosed = False Then FBDataReader.Close()
            End Try
        End Using

        Using FBcommand
            Try
                'If FBRecordset.IsClosed = False Then FBRecordset.Close()
                Call FBirdConnectionOpen()
                FBcommand.Connection = FBirdConnection
                FBsql = "SELECT * FROM RECEPIENT WHERE RECEPIENT_ID = '" & lblRecepient_id.Text & "' "
                FBcommand.CommandText = FBsql
                'FBRecordset.Close()
                FBDataReader = FBcommand.ExecuteReader
                FBDataReader.Read()
                txtRecepient_name.Text = FBDataReader!RECEPIENT_NAME.ToString
                txtRecepient_Address.Text = FBDataReader!RECEPIENT_ADDRESS.ToString
                txtRecepient_contactno.Text = FBDataReader!RECEPIENT_CONTACTNO.ToString
                txtRecepient_Designation.Text = FBDataReader!RECEPIENT_DESIGNATION.ToString

                FBirdConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                'FBRecordset.Close()
                FBirdConnection.Close()
            Finally
                If FBDataReader.IsClosed = False Then FBDataReader.Close()
            End Try
        End Using

        Using FBcommand
            Try
                Call FBirdConnectionOpen()
                FBcommand.Connection = FBirdConnection
                FBsql = "SELECT CONT_EQUIPMENT_REQUEST.EQUIPMENT_ID,EQUIPMENT_NAME,REQUESTED_QUANTITY, DELIVERED_QUANTITY,DELIVERY_DATE,NOTE,RECEPIENT_NAME,RECEPIENT_DESIGNATION  FROM CONT_EQUIPMENT_REQUEST JOIN EQUIPMENT ON CONT_EQUIPMENT_REQUEST.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID WHERE EQUIPMENT_REQUEST_ID = '" & lblID.Text & "' "
                FBcommand.CommandText = FBsql
                'FBRecordset.Close()
                FBDataReader = FBcommand.ExecuteReader
                Dim LV As ListViewItem
                lstEquipment_Input.Items.Clear()
                While FBDataReader.Read()
                    LV = New ListViewItem(FBDataReader!EQUIPMENT_ID.ToString)
                    LV.SubItems.Add(FBDataReader!EQUIPMENT_NAME.ToString)
                    LV.SubItems.Add(FBDataReader!REQUESTED_QUANTITY.ToString)
                    LV.SubItems.Add(FBDataReader!DELIVERED_QUANTITY.ToString)
                    If IsDate(FBDataReader!DELIVERY_DATE) = True Then
                        LV.SubItems.Add(FBDataReader!DELIVERY_DATE)
                    Else
                        LV.SubItems.Add("")
                    End If

                    LV.SubItems.Add(FBDataReader!NOTE.ToString)
                    LV.SubItems.Add(FBDataReader!RECEPIENT_NAME.ToString)
                    LV.SubItems.Add(FBDataReader!RECEPIENT_DESIGNATION.ToString)
                    lstEquipment_Input.Items.Add(LV)

                End While

                FBirdConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                'FBRecordset.Close()
                FBirdConnection.Close()
            Finally
                If FBDataReader.IsClosed = False Then FBDataReader.Close()

            End Try
        End Using

        Using FBcommand
            Try
                Call FBirdConnectionOpen()
                FBcommand.Connection = FBirdConnection
                FBsql = "SELECT * FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
                FBcommand.CommandText = FBsql
                'FBRecordset.Close()
                FBDataReader = FBcommand.ExecuteReader
                Dim LV As ListViewItem
                lstAttachment.Items.Clear()
                While FBDataReader.Read()
                    LV = New ListViewItem(FBDataReader!ATTACHMENT_ID.ToString)
                    LV.SubItems.Add("")
                    LV.SubItems.Add(FBDataReader!FILENAME.ToString)
                    LV.SubItems.Add(FBDataReader!NOTE.ToString)
                    LV.SubItems.Add(FBDataReader!TRANSDATE.ToString)
                    lstAttachment.Items.Add(LV)

                End While
                FBirdConnection.Close()

            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            Finally
                If FBDataReader.IsClosed = False Then FBDataReader.Close()
            End Try
        End Using

        Call Proc_Textbox_Edit(Me.Name)
        Call Proc_Button_Edit(Me.Name)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lstEquipment_request_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEquipment_request.SelectedIndexChanged

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim fBIRD As New OdbcCommand


        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbOK Then

            Me.Cursor = Cursors.WaitCursor
            Try
                Call FBirdConnectionOpen()
                fBIRD.Connection = FBirdConnection
                FBTransaction = FBirdConnection.BeginTransaction
                fBIRD.Transaction = FBTransaction

                'If FBRecordset.IsClosed = False Then FBRecordset.Close()
                FBsql = "DELETE FROM CONT_EQUIPMENT_REQUEST WHERE EQUIPMENT_REQUEST_ID = '" & lblID.Text & "' "
                fBIRD.CommandText = FBsql
                fBIRD.ExecuteNonQuery()

                FBsql = "DELETE FROM EQUIPMENT_REQUEST WHERE EQUIPMENT_REQUEST_ID = '" & lblID.Text & "' "
                fBIRD.CommandText = FBsql
                fBIRD.ExecuteNonQuery()

                FBsql = "DELETE FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
                fBIRD.CommandText = FBsql
                fBIRD.ExecuteNonQuery()



                FBTransaction.Commit()

                Call Proc_Textbox_Delete(Me.Name)
                Call Proc_Button_Delete(Me.Name)
                FBirdConnection.Close()
                Call Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT_REQUEST JOIN MUNICIPALITY ON EQUIPMENT_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON EQUIPMENT_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID")
                MsgBox("Request deleted successful", vbInformation, My.Application.Info.Title.ToString)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & fBIRD.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBTransaction.Rollback()
                FBirdConnection.Close()
            Finally
                fBIRD.Dispose()
                lstAttachment.Items.Clear()
            End Try



        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment.Click
        If Me.Width = 821 Then
            Me.Width = 1086
            btnNew.Left = btnNew.Left + 265
            btnSave.Left = btnSave.Left + 265
            btnDelete.Left = btnDelete.Left + 265
            btnClose.Left = btnClose.Left + 265

        Else
            Me.Width = 821
            btnNew.Left = btnNew.Left - 265
            btnSave.Left = btnSave.Left - 265
            btnDelete.Left = btnDelete.Left - 265
            btnClose.Left = btnClose.Left - 265
        End If

    End Sub




    Private Sub btnAttachment_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment_add.Click
        frmScanDialog.FormSource = Me.Name
        frmScanDialog.ShowDialog()

    End Sub


    Private Sub btnAttachment_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment_remove.Click
        On Error Resume Next

        lstAttachment.SelectedItems(0).Remove()
    End Sub

    Private Sub lstAttachment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAttachment.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        frmPDFviewer.Show()

        Dim FbirdCommand As New OdbcCommand
        Dim FbirdRecordset As OdbcDataReader
        Dim picturecol As Integer

        With frmPDFviewer
            If .pdfReader.src <> Nothing Then
                .pdfReader.src = Nothing
            End If
            ''START DELETE CONTENTS OF TEMP DIRECTORY
            Call Delete_Temp(My.Application.Info.DirectoryPath & "\TEMP\viewer.pdf")
            ''END DELETE CONTENTS OF TEMP DIRECTORY

            If lstAttachment.SelectedItems(0).SubItems(1).Text = "" Then
                Try
                    Call FBirdConnectionOpen()
                    FbirdCommand.Connection = FBirdConnection
                    FbirdCommand.CommandText = "SELECT ATTACHMENT_BIN FROM ATTACHMENT WHERE ATTACHMENT_ID = '" & lstAttachment.SelectedItems(0).Text & "' "
                    FbirdRecordset = FbirdCommand.ExecuteReader

                    FbirdRecordset.Read()

                    Dim b(FbirdRecordset.GetBytes(picturecol, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                    Dim fs As New FileStream(My.Application.Info.DirectoryPath & "\TEMP\viewer.pdf", FileMode.Create, FileAccess.Write)
                    FbirdRecordset.GetBytes(picturecol, 0, b, 0, b.Length)
                    fs.Write(b, 0, b.Length)
                    fs.Close()
                    .pdfReader.src = My.Application.Info.DirectoryPath & "\TEMP\viewer.pdf"
                    FBirdConnection.Close()
                Catch ex As Exception
                    MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                    FBirdConnection.Close()
                Finally
                    If FbirdRecordset.IsClosed = False Then FbirdRecordset.Close()
                    FbirdCommand.Dispose()
                End Try


            Else

                .pdfReader.src = lstAttachment.SelectedItems(0).SubItems(1).Text

            End If


            'If lstAttachment.SelectedItems(0).SubItems(1).Text = "" Then

            'End If
            .pdfReader.ShowPropertyPages()
            .pdfReader.setShowScrollbars(True)
            .pdfReader.setShowToolbar(True)
        End With
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then

            FBsql = "SELECT distinct  EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID,BARANGAY,MUNICIPALITY,RECEPIENT.RECEPIENT_NAME,EQUIPMENT_REQUEST.DATE_RECEIVED,EQUIPMENT_REQUEST.SECURITY_USER, EQUIPMENT_REQUEST.approved_bv FROM EQUIPMENT_REQUEST JOIN MUNICIPALITY ON EQUIPMENT_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON EQUIPMENT_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID"
            FBsql = FBsql & " JOIN CONT_EQUIPMENT_REQUEST ON EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID = CONT_EQUIPMENT_REQUEST.EQUIPMENT_REQUEST_ID JOIN EQUIPMENT ON CONT_EQUIPMENT_REQUEST.EQUIPMENT_ID = EQUIPMENT.EQUIPMENT_ID"
            FBsql = FBsql & " WHERE RECEPIENT.RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION like  '%" & txtSearch.Text & "%' OR EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' "
            'If radRecepient.Checked = True Then
            Call Proc_listview_Refresh(Me.Name, FBsql)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub lstAttachment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAttachment.SelectedIndexChanged

    End Sub
End Class