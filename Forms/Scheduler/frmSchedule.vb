Imports Pabo.Calendar
Imports System.Data.Odbc
Imports System.IO
Public Class frmSchedule
    Private m_SortingColumn As ColumnHeader
    Private Sub frmSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)

        dtDate.Format = DateTimePickerFormat.Custom
        dtDate.CustomFormat = "MM/dd/yyyy"
    

        'Dim todaydate As Date = "10 / 10 / 2013"
        'Dim dateitem1 As DateItem
        ''MonthCalendar2.AddBoldedDate(todaydate)
        ''MonthCalendar2.UpdateBoldedDates()

        ''MonthCalendar2.AddBoldedDate("10 / 11/ 2013")
        ''MonthCalendar2.UpdateBoldedDates()

        ''MonthCalendar1.AddDateInfo(Now)
        'MonthCalendar1.ResetDateInfo()
        'dateitem1 = New DateItem
        'dateitem1.Date = Now
        'dateitem1.BackColor1 = Color.Red

        'MonthCalendar1.AddDateInfo(dateitem1)

    End Sub

    'Private Sub MonthCalendar1_DayQueryInfo(ByVal sender As Object, ByVal e As Pabo.Calendar.DayQueryInfoEventArgs)
    '    If e.Date = "10/10/2013" Then
    '        e.Info.BackColor1 = Color.Yellow
    '        e.Info.BackColor2 = Color.GhostWhite
    '        e.Info.ImageListIndex = 3
    '        e.Info.GradientMode = mcGradientMode.Horizontal
    '        '// Set ownerdraw = true to add custom formatting
    '        e.OwnerDraw = True
    '    End If
    'End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM SCHEDULER WHERE SCHEDULE_ACTIVITY LIKE '%" & txtSearch.Text & "%' OR NOTE LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE '%" & txtSearch.Text & "%' OR SCHEDULE_ADDRESS LIKE '%" & txtSearch.Text & "%' ORDER BY SCHEDULE_ACTIVITY ASC")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub
        Dim FbirdCommand As New OdbcCommand

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "DELETE FROM SCHEDULER WHERE SCHEDULE_ID = '" & ID.Text & "'"
            FbirdCommand.CommandText = FBsql
            FbirdCommand.ExecuteNonQuery()
            FBirdConnection.Close()
            Call Proc_Button_Delete(Me.Name)
            Call Proc_Textbox_Delete(Me.Name)
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM SCHEDULER ORDER BY SCHEDULE_ACTIVITY ASC")
            MsgBox("Schedule deleted successful", vbInformation, My.Application.Info.Title.ToString)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
        End Try
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM SCHEDULER ORDER BY SCHEDULE_ACTIVITY ASC")
        FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & MdiAbono.mCalendar.TodayDate.Month & "/" & 1 & "/" & MdiAbono.mCalendar.TodayDate.Year & "' AND '" & DateSerial(MdiAbono.mCalendar.TodayDate.Year, MdiAbono.mCalendar.TodayDate.Month + 1, 0) & "' ORDER BY SCHEDULE_DATE"
        Call LoadDate(FBsql)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtProgram.Text = Nothing Or txtOrganization.Text = Nothing Then Exit Sub





        If DuplicateIdentifier("SELECT COUNT(SCHEDULE_DATE) FROM SCHEDULER WHERE SCHEDULE_DATE = '" & dtDate.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then Exit Sub
        End If

        Dim gUIDcREATE As String = GuidGenerator("SCL", Me.Name)
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdTransacation As OdbcTransaction
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdTransacation = FBirdConnection.BeginTransaction
            FbirdCommand.Transaction = FbirdTransacation

            If ID.Text = Nothing Then


                ID.Text = gUIDcREATE
                If lstAttachment.Items.Count > 0 Then
                    FBsql = "INSERT INTO SCHEDULER(SCHEDULE_ID,SCHEDULE_DATE,NOTE,ORGANIZATION,SCHEDULE_ADDRESS,SECURITY_USER,SCHEDULE_ACTIVITY,SCHEDULER_DOCUMENT_ID) VALUES ('" & ID.Text & "','" & dtDate.Text & "', '" & txtNote.Text.ToUpper & "', '" & txtOrganization.Text.ToUpper & "','" & txtAddress.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "','" & txtProgram.Text.ToUpper & "','" & lstAttachment.Items(0).Text & "')"

                Else
                    FBsql = "INSERT INTO SCHEDULER(SCHEDULE_ID,SCHEDULE_DATE,NOTE,ORGANIZATION,SCHEDULE_ADDRESS,SECURITY_USER,SCHEDULE_ACTIVITY) VALUES ('" & ID.Text & "','" & dtDate.Text & "', '" & txtNote.Text.ToUpper & "', '" & txtOrganization.Text.ToUpper & "','" & txtAddress.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "','" & txtProgram.Text.ToUpper & "')"
                End If

                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()


            Else
                If lstAttachment.Items.Count > 0 Then
                    FBsql = "UPDATE SCHEDULER SET SCHEDULE_DATE = '" & dtDate.Text & "',NOTE = '" & txtNote.Text.ToUpper & "', ORGANIZATION = '" & txtOrganization.Text.ToUpper & "', SCHEDULE_ADDRESS = '" & txtAddress.Text.ToUpper & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "', SCHEDULE_ACTIVITY = '" & txtProgram.Text.ToUpper & "',SCHEDULER_DOCUMENT_ID= '" & lstAttachment.Items(0).Text & "' WHERE SCHEDULE_ID = '" & ID.Text & "' "

                Else
                    FBsql = "UPDATE SCHEDULER SET SCHEDULE_DATE = '" & dtDate.Text & "',NOTE = '" & txtNote.Text.ToUpper & "', ORGANIZATION = '" & txtOrganization.Text.ToUpper & "', SCHEDULE_ADDRESS = '" & txtAddress.Text.ToUpper & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "', SCHEDULE_ACTIVITY = '" & txtProgram.Text.ToUpper & "',SCHEDULER_DOCUMENT_ID= NULL WHERE SCHEDULE_ID = '" & ID.Text & "' "
                End If

                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()
                'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM SCHEDULER ORDER BY SCHEDULE_ACTIVITY ASC")
            End If
            FbirdTransacation.Commit()
            MsgBox("Schedule saved successful", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            Call Proc_Button_Save(Me.Name)
            Call Proc_Textbox_Save(Me.Name)

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FbirdTransacation.Rollback()
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
        End Try
        FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & MdiAbono.mCalendar.TodayDate.Month & "/" & 1 & "/" & MdiAbono.mCalendar.TodayDate.Year & "' AND '" & DateSerial(MdiAbono.mCalendar.TodayDate.Year, MdiAbono.mCalendar.TodayDate.Month + 1, 0) & "' ORDER BY SCHEDULE_DATE"
        Call LoadDate(FBsql)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub lstSchedule_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSchedule.ColumnClick
        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstSchedule.Columns(e.Column)
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
        lstSchedule.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstSchedule.Sort()
    End Sub

    Private Sub lstSchedule_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSchedule.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Dim LV As ListViewItem
        Me.Cursor = Cursors.WaitCursor
        lstAttachment.Items.Clear()
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT COUNT(SCHEDULE_ID) FROM SCHEDULER JOIN DOCUMENT ON SCHEDULER.SCHEDULER_DOCUMENT_ID = DOCUMENT.DOCUMENT_ID JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE SCHEDULE_ID =  '" & lstSchedule.SelectedItems(0).Text & "'"
            FbirdCommand.CommandText = FBsql
            If FbirdCommand.ExecuteScalar = 0 Then
                FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_ID =  '" & lstSchedule.SelectedItems(0).Text & "' "
                FbirdCommand.CommandText = FBsql
                FbirdReader = FbirdCommand.ExecuteReader
                FbirdReader.Read()
            Else
                FBsql = "SELECT distinct * FROM SCHEDULER JOIN DOCUMENT ON SCHEDULER.SCHEDULER_DOCUMENT_ID = DOCUMENT.DOCUMENT_ID JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE SCHEDULE_ID =  '" & lstSchedule.SelectedItems(0).Text & "' "
                FbirdCommand.CommandText = FBsql
                FbirdReader = FbirdCommand.ExecuteReader
                FbirdReader.Read()
                LV = New ListViewItem(FbirdReader!DOCUMENT_ID.ToString)
                LV.SubItems.Add(FbirdReader!RECEPIENT.ToString)
                LV.SubItems.Add(FbirdReader!AGENCY.ToString)
                LV.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                lstAttachment.Items.Add(LV)
            End If



            'FbirdReader.Read()
            ID.Text = lstSchedule.SelectedItems(0).Text
            txtAddress.Text = FbirdReader!SCHEDULE_ADDRESS.ToString
            txtNote.Text = FbirdReader!NOTE.ToString
            txtOrganization.Text = FbirdReader!ORGANIZATION.ToString
            txtProgram.Text = FbirdReader!SCHEDULE_ACTIVITY.ToString
            dtDate.Value = FbirdReader!SCHEDULE_DATE



            FBirdConnection.Close()
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
        Call Proc_Button_Edit(Me.Name)
        Call Proc_Textbox_Edit(Me.Name)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstSchedule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSchedule.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM SCHEDULER WHERE SCHEDULE_ACTIVITY LIKE '%" & txtSearch.Text & "%' OR NOTE LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE '%" & txtSearch.Text & "%' OR SCHEDULE_ADDRESS LIKE '%" & txtSearch.Text & "%' ORDER BY SCHEDULE_ACTIVITY ASC")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub btnAttachment_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment_add.Click
        With frmSearch
            .lstSearch.Columns.Clear()
            .lstSearch.Columns.Add("ID", 0)
            .lstSearch.Columns.Add("RECEPIENT", 140)
            .lstSearch.Columns.Add("AGENCY", 190)
            .lstSearch.Columns.Add("DATE", 90)
            .lstSearch.Columns.Add("TYPE", 140)
            .lstSearch.Columns.Add("MUNICIPALITY", 90)
            .lstSearch.Columns.Add("NOTE", 140)
            Proc_listview_Refresh("frmSearch_Schedule", "SELECT DISTINCT * FROM DOCUMENT JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID ORDER BY RECEPIENT ASC")
            .frmSearch_Key = "SCHEDULE"
            .ShowDialog()
        End With
    End Sub

    Private Sub btnAttachment_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachment_remove.Click
        lstAttachment.Items.Clear()
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


            Try
                Call FBirdConnectionOpen()
                FbirdCommand.Connection = FBirdConnection
                FbirdCommand.CommandText = "SELECT ATTACHMENT_BIN FROM ATTACHMENT WHERE ID = '" & lstAttachment.SelectedItems(0).Text & "' "

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


            .pdfReader.ShowPropertyPages()
            .pdfReader.setShowScrollbars(True)
            .pdfReader.setShowToolbar(True)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstAttachment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAttachment.SelectedIndexChanged

    End Sub
End Class