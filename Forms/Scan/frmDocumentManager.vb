Imports System.Data.Odbc
Imports System.IO

Public Class frmDocumentManager
    Private m_SortingColumn As ColumnHeader
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim gUIDcREATE As String = GuidGenerator("DOM", Me.Name)
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdTransacation As OdbcTransaction
        Dim FbirdRecordset As OdbcDataReader
        Dim FS As FileStream
        Dim RawData() As Byte

        If lstAttachment.Items.Count = 0 Then
            Beep()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdTransacation = FBirdConnection.BeginTransaction
            FbirdCommand.Transaction = FbirdTransacation

            FBsql = "SELECT DOCUMENT_TYPE_ID FROM DOCUMENT_TYPE   WHERE DESCRIPTION = '" & cboDocumentType.Text & "' ORDER BY DESCRIPTION"
            FbirdCommand.CommandText = FBsql
            lblDocumentTYPEID.Text = FbirdCommand.ExecuteScalar

            'START IF DOCUMENT_ID IS NULL/NEW
            If lblID.Text = "" Then
                FBsql = "INSERT INTO DOCUMENT(DOCUMENT_ID,DOCUMENT_TYPE_ID,NOTE,MUNICIPALITY,RECEPIENT,AGENCY,DOCUMENT_DATE,SECURITY_USER) VALUES "
                FBsql = FBsql & "('" & gUIDcREATE & "','" & lblDocumentTYPEID.Text & "','" & txtNote.Text.ToUpper & "','" & txtMunicipality.Text.ToUpper & "','" & txtRecepient.Text.ToUpper & "','" & txtAgency.Text.ToUpper & "','" & dtDate.Text & "','" & MdiAbono.TSUserName.Text & "')"
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
                'END IF DOCUMENT_ID IS NULL/NEW

                'START IF DOCUMENT_ID IS NOT NULL/NEW
            Else
                FBsql = "UPDATE DOCUMENT SET DOCUMENT_TYPE_ID = '" & lblDocumentTYPEID.Text & "', NOTE = '" & txtNote.Text.ToUpper & "', MUNICIPALITY = '" & txtMunicipality.Text.ToUpper & "', RECEPIENT = '" & txtRecepient.Text.ToUpper & "', AGENCY = '" & txtAgency.Text.ToUpper & "', DOCUMENT_DATE = '" & dtDate.Text & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "' WHERE DOCUMENT_ID = '" & lblID.Text & "' "
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
            'END IF DOCUMENT_ID IS NOT NULL/NEW

            Call Proc_Textbox_Save(Me.Name)
            Call Proc_Button_Save(Me.Name)
            FbirdTransacation.Commit()
            MsgBox("Document saved successful", vbInformation, My.Application.Info.Title.ToString)
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

    Private Sub frmDocumentManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FBirdRecordset As OdbcDataReader = Nothing
        Dim FBirdCommand As New OdbcCommand
        Me.Cursor = Cursors.WaitCursor
        Try

            cboDocumentType.Items.Clear()
            Call FBirdConnectionOpen()
            FBirdCommand.Connection = FBirdConnection
            FBirdCommand.CommandText = "SELECT * FROM DOCUMENT_TYPE ORDER BY DESCRIPTION"
            FBirdRecordset = FBirdCommand.ExecuteReader

            While FBirdRecordset.Read
                cboDocumentType.Items.Add(FBirdRecordset!DESCRIPTION.ToString)
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

        dtDate.Format = DateTimePickerFormat.Custom
        dtDate.CustomFormat = "MM/dd/yyyy"




        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM DOCUMENT join DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID ORDER BY RECEPIENT")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub

        Dim FBIRDCommand As New OdbcCommand

        Try
            Call FBirdConnectionOpen()
            FBIRDCommand.Connection = FBirdConnection
            FBTransaction = FBirdConnection.BeginTransaction
            FBIRDCommand.Transaction = FBTransaction


            FBsql = "DELETE FROM DOCUMENT WHERE DOCUMENT_ID = '" & lblID.Text & "' "
            FBIRDCommand.CommandText = FBsql
            FBIRDCommand.ExecuteNonQuery()

            FBsql = "DELETE FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
            FBIRDCommand.CommandText = FBsql
            FBIRDCommand.ExecuteNonQuery()

            FBTransaction.Commit()
            MsgBox("Document deleted successful", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()

            Call Proc_Button_Delete(Me.Name)
            Call Proc_Textbox_Delete(Me.Name)
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM DOCUMENT join DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID ORDER BY RECEPIENT")
            'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM DOCUMENT ORDER BY CLAIMANT_NAME")
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBIRDCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBTransaction.Rollback()
            FBirdConnection.Close()
        Finally
            FBIRDCommand.Dispose()
            lstAttachment.Items.Clear()
        End Try
    End Sub

    Private Sub lstDocument_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstDocument.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstDocument.Columns(e.Column)
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
        lstDocument.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstDocument.Sort()
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

    Private Sub lstAttachment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAttachment.SelectedIndexChanged

    End Sub

    Private Sub cboDocumentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumentType.SelectedIndexChanged
        Dim FbirdCommand As New OdbcCommand

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT DOCUMENT_TYPE_ID FROM DOCUMENT_TYPE   WHERE DESCRIPTION = '" & cboDocumentType.Text & "' ORDER BY DESCRIPTION"
            FbirdCommand.CommandText = FBsql
            lblDocumentTYPEID.Text = FbirdCommand.ExecuteScalar
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FBsql = "SELECT * FROM DOCUMENT JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE DOCUMENT_TYPE.DESCRIPTION "
        FBsql = FBsql & " = '%" & txtSearch.Text & "%' OR  RECEPIENT LIKE '%" & txtSearch.Text & "%' OR NOTE LIKE '%" & txtSearch.Text & "%' OR MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR DESCRIPTION LIKE '%" & txtSearch.Text & "%'  OR AGENCY LIKE '%" & txtSearch.Text & "%'"
        Call Proc_listview_Refresh(Me.Name, FBsql)

    End Sub

    Private Sub lstDocument_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDocument.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Me.Cursor = Cursors.WaitCursor
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM DOCUMENT JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID "
            FBsql = FBsql & " WHERE DOCUMENT_ID = '" & lstDocument.SelectedItems(0).SubItems(0).Text & "'"
            FbirdCommand.CommandText = FBsql
            FbirdReader = FbirdCommand.ExecuteReader
            FbirdReader.Read()
            lblID.Text = lstDocument.SelectedItems(0).SubItems(0).Text
            txtRecepient.Text = FbirdReader!RECEPIENT.ToString
            txtAgency.Text = FbirdReader!AGENCY.ToString
            dtDate.Value = FbirdReader!DOCUMENT_DATE.ToString
            txtMunicipality.Text = FbirdReader!MUNICIPALITY.ToString
            txtNote.Text = FbirdReader!NOTE.ToString


            ''START CHECK ASSISTANCE
            Dim intx As Integer = 0
            While cboDocumentType.Items.Count <> intx
                If cboDocumentType.Items(intx).ToString = FbirdReader!DESCRIPTION Then
                    cboDocumentType.SelectedIndex = intx
                    Exit While
                End If
                intx = intx + 1
            End While
            ''END CHECK ASSISTANCE
            FbirdReader.Close()
            ''START ATTACHMENT EXTRACT
            FBsql = "SELECT * FROM ATTACHMENT WHERE ID = '" & lblID.Text & "' "
            FbirdCommand.CommandText = FBsql
            'FBRecordset.Close()
            FbirdReader = FbirdCommand.ExecuteReader
            Dim LV As ListViewItem
            lstAttachment.Items.Clear()
            While FbirdReader.Read()
                LV = New ListViewItem(FbirdReader!ATTACHMENT_ID.ToString)
                LV.SubItems.Add("")
                LV.SubItems.Add(FbirdReader!FILENAME.ToString)
                LV.SubItems.Add(FbirdReader!NOTE.ToString)
                LV.SubItems.Add(FbirdReader!TRANSDATE.ToString)
                lstAttachment.Items.Add(LV)

            End While
            ''END ATTACHMENT EXTRACT
            FbirdReader.Close()
            FBirdConnection.Close()
            Call Proc_Button_Edit(Me.Name)
            Call Proc_Textbox_Edit(Me.Name)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
            Try
                FbirdReader.Close()
            Catch ex As Exception

            End Try
        End Try


        Me.Cursor = Cursors.Default


    End Sub


    Private Sub lstDocument_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDocument.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            FBsql = "SELECT * FROM DOCUMENT JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE DOCUMENT_TYPE.DESCRIPTION "
            FBsql = FBsql & " = '%" & txtSearch.Text & "%' OR  RECEPIENT LIKE '%" & txtSearch.Text & "%' OR NOTE LIKE '%" & txtSearch.Text & "%' OR MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR DESCRIPTION LIKE '%" & txtSearch.Text & "%'  OR AGENCY LIKE '%" & txtSearch.Text & "%'"
            Call Proc_listview_Refresh(Me.Name, FBsql)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub grpDocManager_Enter(sender As System.Object, e As System.EventArgs) Handles grpDocManager.Enter

    End Sub
End Class