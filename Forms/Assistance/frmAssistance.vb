Imports System.Data.Odbc
Imports System.IO
Public Class frmAssistance
    Private m_SortingColumn As ColumnHeader
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApproved.CheckedChanged
        If chkApproved.Checked = False Then
            dtApproved.Enabled = False
            chkReleased.Enabled = False
            dtReleased.Enabled = False
        Else
            dtApproved.Enabled = True
            chkReleased.Enabled = True
            'dtApproved.Enabled = True
        End If
    End Sub

    Private Sub chkReleased_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReleased.CheckedChanged
        If chkReleased.Checked = False Then
            dtReleased.Enabled = False
        Else
            dtReleased.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim gUIDcREATE As String = GuidGenerator("AST", Me.Name)
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdTransacation As OdbcTransaction
        Dim FbirdRecordset As OdbcDataReader
        Dim FS As FileStream
        Dim RawData() As Byte

        If txtRecepientName.Text = "" Or txtAmount.Text = "" Or IsNumeric(txtAmount.Text) = False Or cboAssistanceType.Text = "" Then
            Beep()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If DuplicateIdentifier("SELECT COUNT(CLAIMANT_NAME) FROM ASSISTANCE WHERE CLAIMANT_NAME LIKE '" & txtClaimantName.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry of Claimant. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then Exit Sub
        End If
        If DuplicateIdentifier("SELECT COUNT(RECEPIENT_NAME) FROM ASSISTANCE WHERE RECEPIENT_NAME LIKE '" & txtRecepientName.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry of Recepient. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then Exit Sub
        End If

        Try
            'Dim Abc As Integer = 0
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdTransacation = FBirdConnection.BeginTransaction
            FbirdCommand.Transaction = FbirdTransacation

            FBsql = "SELECT ASSISTANCE_TYPE_ID FROM ASSISTANCE_TYPE   WHERE DESCRIPTION = '" & cboAssistanceType.Text & "' ORDER BY DESCRIPTION"
            FbirdCommand.CommandText = FBsql
            lblAssistance_ID.Text = FbirdCommand.ExecuteScalar
            'FBsql = "SELECT ASSISTANCE_TYPE_ID FROM ASSISTANCE_TYPE   WHERE DESCRIPTION = '" & cboAssistanceType.Text & "' ORDER BY DESCRIPTION"
            'FbirdCommand.CommandText = FBsql
            'lblAssistance_ID.Text = FbirdCommand.ExecuteScalar
            'While FBRecordset.Read
            '    If FBRecordset!DESCRIPTION = cboAssistanceType.Text Then
            '        Exit While
            '    End If

            'End While


            If lblID.Text = "" Then



                If chkApproved.Checked = True Then
                    If chkReleased.Checked = True Then
                        FBsql = "INSERT INTO ASSISTANCE(ASSISTANCE_ID,ASSISTANCE_TYPE_ID,CLAIMANT_NAME,CLAIMANT_ADDRESS,"
                        FBsql = FBsql & " DATE_RECEIVED,APPROVED_BV,DATE_APPROVED,AMOUNT,REMARKS,SECURITY_USER,RELEASED_BV,DATE_RELEASED,RECEPIENT_NAME,RECEPIENT_ADDRESS)"
                        FBsql = FBsql & " VALUES ('" & gUIDcREATE & "','" & lblAssistance_ID.Text & "','" & txtClaimantName.Text.ToUpper & "','" & txtClaimantAddress.Text.ToUpper & "', "
                        FBsql = FBsql & "'" & dtReceived.Text & "',1,'" & dtApproved.Text & "'," & txtAmount.Text & ","
                        FBsql = FBsql & "'" & txtRemark.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "',1,'" & dtReleased.Text & "','" & txtRecepientName.Text.ToUpper & "', '" & txtRecepientAddress.Text.ToUpper & "')"
                    Else
                        FBsql = "INSERT INTO ASSISTANCE(ASSISTANCE_ID,ASSISTANCE_TYPE_ID,CLAIMANT_NAME,CLAIMANT_ADDRESS,"
                        FBsql = FBsql & " DATE_RECEIVED,APPROVED_BV,DATE_APPROVED,AMOUNT,REMARKS,SECURITY_USER,RECEPIENT_NAME,RECEPIENT_ADDRESS,RELEASED_BV)"
                        FBsql = FBsql & " VALUES ('" & gUIDcREATE & "','" & lblAssistance_ID.Text & "','" & txtClaimantName.Text.ToUpper & "', '" & txtClaimantAddress.Text.ToUpper & "', "
                        FBsql = FBsql & "'" & dtReceived.Text & "',1,'" & dtApproved.Text & "'," & txtAmount.Text & ","
                        FBsql = FBsql & "'" & txtRemark.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "','" & txtRecepientName.Text.ToUpper & "', '" & txtRecepientAddress.Text.ToUpper & "',0)"
                    End If
                Else
                    FBsql = "INSERT INTO ASSISTANCE(ASSISTANCE_ID,ASSISTANCE_TYPE_ID,CLAIMANT_NAME,CLAIMANT_ADDRESS,"
                    FBsql = FBsql & " DATE_RECEIVED,AMOUNT,REMARKS,SECURITY_USER,RELEASED_BV,RECEPIENT_NAME,RECEPIENT_ADDRESS,APPROVED_BV)"
                    FBsql = FBsql & " VALUES ('" & gUIDcREATE & "','" & lblAssistance_ID.Text & "','" & txtClaimantName.Text.ToUpper & "','" & txtClaimantAddress.Text.ToUpper & "', "
                    FBsql = FBsql & "'" & dtReceived.Text & "'," & txtAmount.Text & ","
                    FBsql = FBsql & "'" & txtRemark.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "',0,'" & txtRecepientName.Text.ToUpper & "', '" & txtRecepientAddress.Text.ToUpper & "', 0)"

                End If
                FbirdCommand.CommandText = FBsql
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
                    FbirdCommand.Parameters.AddWithValue("@ID", gUIDcREATE)
                    FbirdCommand.Parameters.AddWithValue("@ATTACHMENT_BIN", RawData)
                    FbirdCommand.Parameters.AddWithValue("@NOTE", lstAttachment.Items(CounterY).SubItems(3).Text)
                    FbirdCommand.Parameters.AddWithValue("@FILENAME", lstAttachment.Items(CounterY).SubItems(2).Text)
                    FbirdCommand.ExecuteNonQuery()
                Next
                ''end insert attachements



                lblID.Text = gUIDcREATE

                ''ELSE IF LBLID IS NOTHING
            Else
                ''START CHECK FOR STATUS
                If chkApproved.Checked = True Then
                    If chkReleased.Checked = True Then
                        FBsql = "UPDATE ASSISTANCE SET ASSISTANCE_TYPE_ID = '" & lblAssistance_ID.Text & "',CLAIMANT_NAME = '" & txtClaimantName.Text.ToUpper & "',CLAIMANT_ADDRESS = '" & txtClaimantAddress.Text.ToUpper & "',"
                        FBsql = FBsql & " DATE_RECEIVED = '" & dtReceived.Text & "',APPROVED_BV=1,"
                        FBsql = FBsql & " DATE_APPROVED = '" & dtApproved.Text & "',AMOUNT = " & txtAmount.Text & ",REMARKS = '" & txtRemark.Text.ToUpper & "',"
                        FBsql = FBsql & "SECURITY_USER = '" & MdiAbono.TSUserName.Text & "',RELEASED_BV = 1,DATE_RELEASED = '" & dtReleased.Text & "', RECEPIENT_NAME = '" & txtRecepientName.Text.ToUpper & "', RECEPIENT_ADDRESS = '" & txtRecepientAddress.Text.ToUpper & "' WHERE "
                        FBsql = FBsql & "ASSISTANCE_ID = '" & lblID.Text & "' "

                    Else
                        FBsql = "UPDATE ASSISTANCE SET ASSISTANCE_TYPE_ID = '" & lblAssistance_ID.Text & "',CLAIMANT_NAME = '" & txtClaimantName.Text.ToUpper & "',CLAIMANT_ADDRESS = '" & txtClaimantAddress.Text.ToUpper & "',"
                        FBsql = FBsql & " DATE_RECEIVED = '" & dtReceived.Text & "',APPROVED_BV=1,"
                        FBsql = FBsql & " DATE_APPROVED = '" & dtApproved.Text & "',AMOUNT = " & txtAmount.Text & ",REMARKS = '" & txtRemark.Text.ToUpper & "',"
                        FBsql = FBsql & "SECURITY_USER = '" & MdiAbono.TSUserName.Text & "',RELEASED_BV = 0,DATE_RELEASED = NULL, RECEPIENT_NAME = '" & txtRecepientName.Text.ToUpper & "', RECEPIENT_ADDRESS = '" & txtRecepientAddress.Text.ToUpper & "' WHERE "
                        FBsql = FBsql & "ASSISTANCE_ID = '" & lblID.Text & "' "

                    End If
                Else
                    FBsql = "UPDATE ASSISTANCE SET ASSISTANCE_TYPE_ID = '" & lblAssistance_ID.Text & "',CLAIMANT_NAME = '" & txtClaimantName.Text.ToUpper & "',CLAIMANT_ADDRESS = '" & txtClaimantAddress.Text.ToUpper & "',"
                    FBsql = FBsql & " DATE_RECEIVED = '" & dtReceived.Text & "',APPROVED_BV=0,"
                    FBsql = FBsql & " DATE_APPROVED = NULL ,AMOUNT = " & txtAmount.Text & ",REMARKS = '" & txtRemark.Text.ToUpper & "',"
                    FBsql = FBsql & "SECURITY_USER = '" & MdiAbono.TSUserName.Text & "',RELEASED_BV = 0,DATE_RELEASED = NULL, RECEPIENT_NAME = '" & txtRecepientName.Text.ToUpper & "', RECEPIENT_ADDRESS = '" & txtRecepientAddress.Text.ToUpper & "' WHERE "
                    FBsql = FBsql & "ASSISTANCE_ID = '" & lblID.Text & "' "

                End If
                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()
                ''END CHECK FOR STATUS

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
            MsgBox("Assistance saved successful", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
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

    Private Sub frmAssistance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FBirdRecordset As OdbcDataReader = Nothing
        Dim FBirdCommand As New OdbcCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            cboAssistanceType.Items.Clear()
            Call FBirdConnectionOpen()
            FBirdCommand.Connection = FBirdConnection
            FBirdCommand.CommandText = "SELECT * FROM ASSISTANCE_TYPE ORDER BY DESCRIPTION"
            FBirdRecordset = FBirdCommand.ExecuteReader
            While FBirdRecordset.Read
                cboAssistanceType.Items.Add(FBirdRecordset!DESCRIPTION.ToString)
            End While
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FBirdCommand.Dispose()
            Try

            Catch ex As Exception
                FBirdRecordset.Close()
            End Try

        End Try
        'cboAssistanceType.TabIndex = 0

        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM ASSISTANCE JOIN ASSISTANCE_TYPE ON ASSISTANCE.ASSISTANCE_TYPE_ID = ASSISTANCE_TYPE.ASSISTANCE_TYPE_ID ORDER BY CLAIMANT_NAME")

        Me.Cursor = Cursors.Default
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

                    FbirdCommand.Dispose()
                    Try
                        FbirdRecordset.Close()
                    Catch ex As Exception

                    End Try
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


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub lstAssistance_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstAssistance.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstAssistance.Columns(e.Column)
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
        lstAssistance.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstAssistance.Sort()
    End Sub

    Private Sub lstAssistance_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAssistance.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdRecordset As OdbcDataReader
        Me.Cursor = Cursors.WaitCursor
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM ASSISTANCE JOIN ASSISTANCE_TYPE ON ASSISTANCE.ASSISTANCE_TYPE_ID = ASSISTANCE_TYPE.ASSISTANCE_TYPE_ID WHERE ASSISTANCE_ID = '" & lstAssistance.SelectedItems(0).SubItems(0).Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdRecordset = FbirdCommand.ExecuteReader()
            FbirdRecordset.Read()

            lblID.Text = FbirdRecordset!ASSISTANCE_ID.ToString
            lblAssistance_ID.Text = FbirdRecordset!ASSISTANCE_TYPE_ID.ToString
            txtClaimantName.Text = FbirdRecordset!CLAIMANT_NAME.ToString
            txtClaimantAddress.Text = FbirdRecordset!CLAIMANT_ADDRESS.ToString
            txtRecepientName.Text = FbirdRecordset!RECEPIENT_NAME.ToString
            txtRecepientAddress.Text = FbirdRecordset!RECEPIENT_ADDRESS.ToString
            txtAmount.Text = FbirdRecordset!AMOUNT.ToString
            txtRemark.Text = FbirdRecordset!REMARKS.ToString
            chkReceived.Checked = True
            dtReceived.Value = FbirdRecordset!DATE_RECEIVED

            If FbirdRecordset!RELEASED_BV = 1 Then
                chkApproved.Checked = True
                chkReleased.Checked = True
                dtApproved.Value = FbirdRecordset!DATE_APPROVED
                dtReleased.Value = FbirdRecordset!DATE_RELEASED
                dtApproved.Enabled = True
                dtReleased.Enabled = True
            Else
                If FbirdRecordset!APPROVED_BV = 1 Then
                    chkApproved.Checked = True
                    dtApproved.Enabled = True
                Else
                    chkApproved.Checked = False
                    dtApproved.Enabled = False
                End If
                chkReleased.Checked = False
                dtReleased.Enabled = False
            End If


            ''START CHECK ASSISTANCE
            Dim intx As Integer = 0
            While cboAssistanceType.Items.Count <> intx
                If cboAssistanceType.Items(intx).ToString = FbirdRecordset!DESCRIPTION Then
                    cboAssistanceType.SelectedIndex = intx
                    Exit While
                End If
                intx = intx + 1
            End While
            ''END CHECK ASSISTANCE

            FbirdRecordset.Close()
            ''START ATTACHMENT EXTRACT
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
            ''END ATTACHMENT EXTRACT
            FbirdRecordset.Close()

            Call Proc_Button_Edit(Me.Name)
            Call Proc_Textbox_Edit(Me.Name)
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
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


    Private Sub lstAssistance_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAssistance.SelectedIndexChanged

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FBsql = "SELECT * FROM ASSISTANCE JOIN ASSISTANCE_TYPE ON ASSISTANCE.ASSISTANCE_TYPE_ID = ASSISTANCE_TYPE.ASSISTANCE_TYPE_ID WHERE CLAIMANT_NAME LIKE '%" & txtSearch.Text & "%' "
        FBsql = FBsql & " OR RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR ASSISTANCE_TYPE.DESCRIPTION LIKE '%" & txtSearch.Text & "%'  ORDER BY CLAIMANT_NAME ASC"
        Call Proc_listview_Refresh(Me.Name, FBsql)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub

        Dim FBIRDCommand As New OdbcCommand

        Try
            Call FBirdConnectionOpen()
            FBIRDCommand.Connection = FBirdConnection
            FBTransaction = FBirdConnection.BeginTransaction
            FBIRDCommand.Transaction = FBTransaction


            FBsql = "DELETE FROM ASSISTANCE WHERE ASSISTANCE_ID = '" & lblID.Text & "' "
            FBIRDCommand.CommandText = FBsql
            FBIRDCommand.ExecuteNonQuery()

            FBsql = "DELETE FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
            FBIRDCommand.CommandText = FBsql
            FBIRDCommand.ExecuteNonQuery()

            FBTransaction.Commit()
            MsgBox("Assistance deleted successful", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()

            Call Proc_Button_Delete(Me.Name)
            Call Proc_Textbox_Delete(Me.Name)
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM ASSISTANCE ORDER BY CLAIMANT_NAME")

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBIRDCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBTransaction.Rollback()
            FBirdConnection.Close()
        Finally
            FBIRDCommand.Dispose()
            lstAttachment.Items.Clear()
        End Try


    End Sub


    Private Sub btnClaimant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        With frmSearch
            .lstSearch.Columns.Clear()
            .lstSearch.Columns.Add("Claimant_ID", 0)
            .lstSearch.Columns.Add("Name", 140)
            .lstSearch.Columns.Add("Address", 190)
            .lstSearch.Columns.Add("Designation", 90)
            .lstSearch.Columns.Add("Contact No", 80)
            Proc_listview_Refresh("frmSearch_Recepient", "SELECT * FROM RECEPIENT ORDER BY RECEPIENT_NAME ASC")
            .frmSearch_Key = "ASSISTANCE_CLAIMANT"
            .ShowDialog()
        End With
    End Sub

    Private Sub grpStatus_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpStatus.Enter

    End Sub

    Private Sub lstAttachment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAttachment.SelectedIndexChanged

    End Sub

    Private Sub cboAssistanceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssistanceType.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            FBsql = "SELECT * FROM ASSISTANCE JOIN ASSISTANCE_TYPE ON ASSISTANCE.ASSISTANCE_TYPE_ID = ASSISTANCE_TYPE.ASSISTANCE_TYPE_ID WHERE CLAIMANT_NAME LIKE '%" & txtSearch.Text & "%' "
            FBsql = FBsql & " OR RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR ASSISTANCE_TYPE.DESCRIPTION LIKE '%" & txtSearch.Text & "%'  ORDER BY CLAIMANT_NAME ASC"
            Call Proc_listview_Refresh(Me.Name, FBsql)

        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class