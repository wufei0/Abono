Imports System.Data.Odbc
Imports System.IO
Public Class frmInfrastructure
    Private m_SortingColumn As ColumnHeader
    Private Sub frmInfrastructure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM INFRA_REQUEST JOIN MUNICIPALITY ON INFRA_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON INFRA_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID")
        Me.Width = 803

        dtApproved.Format = DateTimePickerFormat.Custom
        dtApproved.CustomFormat = "MM/dd/yyyy"
        dtReceived.Format = DateTimePickerFormat.Custom
        dtReceived.CustomFormat = "MM/dd/yyyy"

        Me.Cursor = Cursors.Default
    End Sub

    

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim gUIDcREATE As String = GuidGenerator("IRQ", Me.Name)
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdTransacation As OdbcTransaction
        Dim FbirdRecordset As OdbcDataReader
        Dim FS As FileStream
        Dim RawData() As Byte
        Me.Cursor = Cursors.WaitCursor
        'Dim DATE_RECEIVED, DATE_APPROVED As Date
        If lblRecepient_id.Text = Nothing Then
            Beep()
            Exit Sub
        End If
        If lbladdress_id.Text = Nothing Then
            Beep()
            Exit Sub
        End If
        If IsNumeric(txtamount.Text) = False Then
            Beep()
            Exit Sub
        End If

        If DuplicateIdentifier("SELECT COUNT(RECEPIENT_ID) FROM INFRA_REQUEST WHERE RECEPIENT_ID = '" & lblRecepient_id.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry of recepient. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If
 


        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdTransacation = FBirdConnection.BeginTransaction
            FbirdCommand.Transaction = FbirdTransacation



            If lblID.Text = Nothing Then
                lblID.Text = gUIDcREATE

                If chkApproved.Checked = True Then
                    'DATE_APPROVED = dtApproved.Text
                    'DATE_RECEIVED = dtReceived.Text
                    FBsql = "INSERT INTO INFRA_REQUEST(INFRA_REQUEST_ID, RECEPIENT_ID, DATE_RECEIVED, PROPOSAL, APPROVED_BV, APPROVED_DATE, NOTE, SECURITY_USER, MUNICIPALITY_ID,AMOUNT) "
                    FBsql = FBsql & "VALUES ('" & lblID.Text & "','" & lblRecepient_id.Text & "','" & dtReceived.Text & "','" & txtProposal.Text.ToUpper & "',1,'" & dtApproved.Text & "','" & txtNote.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "','" & lbladdress_id.Text & "'," & txtamount.Text & ")"
                    FbirdCommand.CommandText = FBsql
                    'FbirdCommand.Parameters.AddWithValue("APPROVED_BV", 1)
                    'FbirdCommand.Parameters.AddWithValue("APPROVED_DATE", dtApproved.Value)
                Else
                    'DATE_RECEIVED = dtReceived.Text
                    FBsql = "INSERT INTO INFRA_REQUEST(INFRA_REQUEST_ID, RECEPIENT_ID,  PROPOSAL, APPROVED_BV, APPROVED_DATE, NOTE, SECURITY_USER, MUNICIPALITY_ID,DATE_RECEIVED,AMOUNT) "
                    FBsql = FBsql & "VALUES ('" & lblID.Text & "','" & lblRecepient_id.Text & "','" & txtProposal.Text.ToUpper & "',0,null,'" & txtNote.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "','" & lbladdress_id.Text & "','" & dtReceived.Text & "'," & txtamount.Text & ")"
                    FbirdCommand.CommandText = FBsql
                    'FbirdCommand.Parameters.AddWithValue("APPROVED_BV", 0)

                End If

                FbirdCommand.ExecuteNonQuery()


                ''start insert attachements
                For CounterY = 0 To lstAttachment.Items.Count - 1
                    FS = New FileStream(lstAttachment.Items(CounterY).SubItems(1).Text, FileMode.Open, FileAccess.Read)
                    RawData = New Byte(FS.Length) {}
                    FS.Read(RawData, 0, FS.Length)
                    FS.Close()
                    FbirdCommand.Parameters.Clear()
                    FbirdCommand.CommandText = "INSERT INTO ATTACHMENT(ATTACHMENT_ID,ID,ATTACHMENT_BIN,NOTE,FILENAME) VALUES (?,?,?,?,?)"
                    FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(CounterY).Text)
                    FbirdCommand.Parameters.AddWithValue("@ID", lblID.Text)
                    FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_BIN", RawData)
                    FbirdCommand.Parameters.AddWithValue("@NOTE", lstAttachment.Items(CounterY).SubItems(3).Text)
                    FbirdCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(CounterY).SubItems(2).Text)
                    FbirdCommand.ExecuteNonQuery()
                Next
                ''end insert attachements

            Else

                If chkApproved.Checked = True Then
                    FBsql = "UPDATE INFRA_REQUEST SET RECEPIENT_ID = '" & lblRecepient_id.Text & "', DATE_RECEIVED = '" & dtReceived.Text & "', "
                    FBsql = FBsql & " PROPOSAL = '" & txtProposal.Text.ToUpper & "', NOTE = '" & txtNote.Text.ToUpper & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "', "
                    FBsql = FBsql & " APPROVED_BV = 1, APPROVED_DATE = '" & dtApproved.Text & "', MUNICIPALITY_ID = '" & lbladdress_id.Text & "',AMOUNT = " & txtamount.Text & " WHERE INFRA_REQUEST_ID = '" & lblID.Text & "' "
                Else
                    FBsql = "UPDATE INFRA_REQUEST SET RECEPIENT_ID = '" & lblRecepient_id.Text & "', DATE_RECEIVED = '" & dtReceived.Text & "', "
                    FBsql = FBsql & " PROPOSAL = '" & txtProposal.Text.ToUpper & "', NOTE = '" & txtNote.Text.ToUpper & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "', "
                    FBsql = FBsql & " APPROVED_BV = 0, APPROVED_DATE = NULL , MUNICIPALITY_ID = '" & lbladdress_id.Text & "',AMOUNT = " & txtamount.Text & " WHERE INFRA_REQUEST_ID = '" & lblID.Text & "' "

                End If

                'FbirdCommand.Connection = FBirdConnection
                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()

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

                ''START INSERT OF ATTACHMENT
                For CountZ = 0 To lstAttachment.Items.Count - 1
                    If lstAttachment.Items(CountZ).SubItems(1).Text = "" Then

                    Else

                        FS = New FileStream(lstAttachment.Items(CountZ).SubItems(1).Text, FileMode.Open, FileAccess.Read)
                        RawData = New Byte(FS.Length) {}
                        FS.Read(RawData, 0, FS.Length)
                        FS.Close()
                        FbirdCommand.Parameters.Clear()
                        FbirdCommand.CommandText = "INSERT INTO ATTACHMENT(ATTACHMENT_ID,ID,ATTACHMENT_BIN,NOTE,FILENAME) VALUES (?,?,?,?,?)"
                        FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_ID", lstAttachment.Items(CountZ).Text)
                        FbirdCommand.Parameters.AddWithValue("@ID", lblID.Text)
                        FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_BIN", RawData)
                        FbirdCommand.Parameters.AddWithValue("@NOTE", lstAttachment.Items(CountZ).SubItems(3).Text)
                        FbirdCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(CountZ).SubItems(2).Text)
                        FbirdCommand.ExecuteNonQuery()


                    End If


                Next
                ''END INSERT OF ATTACHMENT



            End If

            Call Proc_Textbox_Save(Me.Name)
            Call Proc_Button_Save(Me.Name)
            FbirdTransacation.Commit()
            FBirdConnection.Close()
            MsgBox("Request saved successful", vbInformation, My.Application.Info.Title.ToString)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FbirdTransacation.Rollback()
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
            Try
                FbirdRecordset.Close()
            Catch ex As Exception

            End Try
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApproved.CheckedChanged

        If chkApproved.Checked = True Then
            dtApproved.Enabled = True
        Else
            dtApproved.Enabled = False
        End If

    End Sub

    Private Sub btnAddress_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddress_Search.Click
        With frmSearch
            .lstSearch.Columns.Clear()
            .lstSearch.Columns.Add("MUNICIPALITY_ID", 0)
            .lstSearch.Columns.Add("Barangay", 140)
            .lstSearch.Columns.Add("Municipality", 190)
            .lstSearch.Columns.Add("Province", 90)
            .lstSearch.Columns.Add("Organization", 140)
            Proc_listview_Refresh("frmSearch_Address", "SELECT * FROM MUNICIPALITY ORDER BY BARANGAY ASC")
            .frmSearch_Key = "MUNICIPALITY_INFRA"
            .ShowDialog()
        End With
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
            .frmSearch_Key = "RECEPIENT_INFRA"
            .ShowDialog()
        End With
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim FBIRDCommand As New OdbcCommand

        Try
            Call FBirdConnectionOpen()
            FBIRDCommand.Connection = FBirdConnection
            FBTransaction = FBirdConnection.BeginTransaction
            FBIRDCommand.Transaction = FBTransaction


            FBsql = "DELETE FROM INFRA_REQUEST WHERE INFRA_REQUEST_ID = '" & lblID.Text & "' "
            FBIRDCommand.CommandText = FBsql
            FBIRDCommand.ExecuteNonQuery()

            FBsql = "DELETE FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
            FBIRDCommand.CommandText = FBsql
            FBIRDCommand.ExecuteNonQuery()

            FBTransaction.Commit()
            MsgBox("Request deleted successful", vbInformation, My.Application.Info.Title.ToString)

            FBirdConnection.Close()
            Call Proc_Button_Delete(Me.Name)
            Call Proc_Textbox_Delete(Me.Name)
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM INFRA_REQUEST JOIN MUNICIPALITY ON INFRA_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON INFRA_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID")
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBIRDCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBTransaction.Rollback()
            FBirdConnection.Close()
        Finally
            FBIRDCommand.Dispose()
            lstAttachment.Items.Clear()
        End Try


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM INFRA_REQUEST JOIN MUNICIPALITY ON INFRA_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON INFRA_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID WHERE BARANGAY LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR  NOTE LIKE '%" & txtSearch.Text & "%'  OR ORGANIZATION LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT_NAME ASC")


    End Sub

    Private Sub lstInfrastructure_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstInfrastructure.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstInfrastructure.Columns(e.Column)
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
        lstInfrastructure.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstInfrastructure.Sort()
    End Sub

    Private Sub lstInfrastructure_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInfrastructure.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdRecordset As OdbcDataReader
        Me.Cursor = Cursors.WaitCursor

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM INFRA_REQUEST WHERE INFRA_REQUEST_ID = '" & lstInfrastructure.SelectedItems(0).SubItems(0).Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdRecordset = FbirdCommand.ExecuteReader
            FbirdRecordset.Read()

            txtProposal.Text = FbirdRecordset!PROPOSAL.ToString
            txtNote.Text = FbirdRecordset!NOTE.ToString
            lblID.Text = FbirdRecordset!INFRA_REQUEST_ID.ToString
            lbladdress_id.Text = FbirdRecordset!MUNICIPALITY_ID.ToString
            lblRecepient_id.Text = FbirdRecordset!RECEPIENT_ID.ToString
            txtamount.Text = FbirdRecordset!AMOUNT.ToString
            chkReceived.Checked = True
            dtReceived.Value = FbirdRecordset!DATE_RECEIVED

            If FbirdRecordset!APPROVED_BV = 1 Then
                chkApproved.Checked = True
                dtApproved.Value = FbirdRecordset!APPROVED_DATE
            Else
                chkApproved.Checked = False
                dtApproved.Enabled = False
            End If
            FbirdRecordset.Close()

            FBsql = "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY_ID = '" & lbladdress_id.Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdRecordset = FbirdCommand.ExecuteReader
            FbirdRecordset.Read()
            txtAddress.Text = FbirdRecordset!BARANGAY.ToString & ", " & FbirdRecordset!MUNICIPALITY.ToString & ", " & FbirdRecordset!PROVINCE.ToString
            txtOrganization.Text = FbirdRecordset!ORGANIZATION
            FbirdRecordset.Close()

            FBsql = "SELECT * FROM RECEPIENT WHERE RECEPIENT_ID = '" & lblRecepient_id.Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdRecordset = FbirdCommand.ExecuteReader
            FbirdRecordset.Read()
            txtRecepient_name.Text = FbirdRecordset!RECEPIENT_NAME.ToString
            txtRecepient_Address.Text = FbirdRecordset!RECEPIENT_ADDRESS.ToString
            txtRecepient_contactno.Text = FbirdRecordset!RECEPIENT_CONTACTNO.ToString
            txtRecepient_Designation.Text = FbirdRecordset!RECEPIENT_DESIGNATION.ToString
            FbirdRecordset.Close()

            FBsql = "SELECT * FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
            FbirdCommand.CommandText = FBsql
            'FBRecordset.Close()
            FbirdRecordset = FbirdCommand.ExecuteReader
            Dim LV As ListViewItem
            lstAttachment.Items.Clear()
            While FbirdRecordset.Read()
                LV = New ListViewItem(FbirdRecordset!ATTACHMENT_ID.ToString)
                LV.SubItems.Add("")
                LV.SubItems.Add(FbirdRecordset!FILENAME.ToString)
                LV.SubItems.Add(FbirdRecordset!NOTE.ToString)
                LV.SubItems.Add(FbirdRecordset!TRANSDATE.ToString)
                lstAttachment.Items.Add(LV)

            End While

            FbirdRecordset.Close()
            FBirdConnection.Close()


            Call Proc_Button_Edit(Me.Name)
            Call Proc_Textbox_Edit(Me.Name)



        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            Try
                FbirdRecordset.Close()
            Catch ex As Exception

            End Try

            FbirdCommand.Dispose()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstInfrastructure_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInfrastructure.SelectedIndexChanged

    End Sub

    Private Sub frmInfrastructure_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub

    Private Sub btnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment.Click
        If Me.Width = 803 Then
            Me.Width = 1060
            btnNew.Left = btnNew.Left + 257
            btnSave.Left = btnSave.Left + 257
            btnDelete.Left = btnDelete.Left + 257
            btnClose.Left = btnClose.Left + 257
        Else
            Me.Width = 803
            btnNew.Left = btnNew.Left - 257
            btnSave.Left = btnSave.Left - 257
            btnDelete.Left = btnDelete.Left - 257
            btnClose.Left = btnClose.Left - 257
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
                    FbirdRecordset.Close()
                    FbirdCommand.Dispose()
                End Try


            Else

                .pdfReader.src = lstAttachment.SelectedItems(0).SubItems(1).Text

            End If
            .pdfReader.ShowPropertyPages()
            .pdfReader.setShowScrollbars(True)
            .pdfReader.setShowToolbar(True)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstAttachment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAttachment.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM INFRA_REQUEST JOIN MUNICIPALITY ON INFRA_REQUEST.MUNICIPALITY_ID = MUNICIPALITY.MUNICIPALITY_ID JOIN RECEPIENT ON INFRA_REQUEST.RECEPIENT_ID = RECEPIENT.RECEPIENT_ID WHERE BARANGAY LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR  NOTE LIKE '%" & txtSearch.Text & "%'  OR ORGANIZATION LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT_NAME ASC")
        End If
    End Sub





    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class