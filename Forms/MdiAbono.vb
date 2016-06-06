Imports System.Windows.Forms
Imports FirebirdSql.Data.FirebirdClient
'Imports FirebirdSql.Data.Services
Imports System.Data.Odbc
Imports Microsoft.VisualBasic.DateAndTime



Public Class MdiAbono
    Private m_SortingColumn As ColumnHeader
    'Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click
    '    '' Create a new instance of the child form.
    '    'Dim ChildForm As New System.Windows.Forms.Form
    '    '' Make it a child of this MDI form before showing it.
    '    'ChildForm.MdiParent = Me

    '    'm_ChildFormNumber += 1
    '    'ChildForm.Text = "Window " & m_ChildFormNumber

    '    'ChildForm.Show()
    'End Sub

    'Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim OpenFileDialog As New OpenFileDialog
    '    OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
    '    If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = OpenFileDialog.FileName
    '        ' TODO: Add code here to open the file.
    '    End If
    'End Sub

    'Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim SaveFileDialog As New SaveFileDialog
    '    SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

    '    If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = SaveFileDialog.FileName
    '        ' TODO: Add code here to save the current contents of the form to a file.
    '    End If
    'End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        FBcommand.Dispose()
        FBirdConnection.Close()
        End
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        'Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub EquipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipmentToolStripMenuItem.Click
        frmEquipment.Show()
    End Sub

    Private Sub ReceipientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceipientToolStripMenuItem.Click
        frmRecepient.Show()
    End Sub

    Private Sub EquipmentRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipmentRequestToolStripMenuItem.Click
        frmRequest_Equipment.Show()
    End Sub

    Private Sub AddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressToolStripMenuItem.Click
        frmAddress.Show()
    End Sub

    Private Sub InfrastructureRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfrastructureRequestToolStripMenuItem.Click
        frmInfrastructure.Show()
    End Sub

    Private Sub AssistanceRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssistanceRequestToolStripMenuItem.Click
        frmAssistance.Show()
    End Sub

    Private Sub DocumentManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentManagerToolStripMenuItem.Click
        frmDocumentManager.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmDocumentType.Show()
    End Sub

    Private Sub AssistanceTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssistanceTypeToolStripMenuItem.Click
        frmAssistanceType.Show()
    End Sub

    Private Sub ContToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContToolStripMenuItem.Click
        frmDirectory.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BackupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem1.Click
        Call BackupDB()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmAssistance.Show()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.Click
        frmDirectory.Show()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        frmRequest_Equipment.Show()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        frmInfrastructure.Show()
    End Sub

    ' BACKUP DATABSE
    Private Sub BackupDB()
        Dim SFDDBBackup As New SaveFileDialog
        SFDDBBackup.Filter = "Firebird Database (*.fbk)|*.fbk"
        SFDDBBackup.FilterIndex = 1
        SFDDBBackup.RestoreDirectory = True
        'SFDDBBackup.ShowDialog()
        Try


            'If SFDDBBackup.ShowDialog() = DialogResult.OK Then
            '    'MsgBox(SFDDBBackup.FileName.ToString)
            '    Dim n As FirebirdSql.Data.Services.FbBackup = New FirebirdSql.Data.Services.FbBackup()
            '    Dim fl As FirebirdSql.Data.Services.FbBackupFile = New FirebirdSql.Data.Services.FbBackupFile(SFDDBBackup.FileName, 2048)

            '    n.BackupFiles.Add(fl)
            '    n.ConnectionString = "servertype=0;username=sysdba;password=masterkey;database=" & FirebirdDbase
            '    n.Execute()
            'End If

            'MsgBox(GetOSArchitecture)
            Dim BackupProcess As New ProcessStartInfo

            If SFDDBBackup.ShowDialog = DialogResult.OK Then
                If GetOSArchitecture() = "32-bit" Then
                    BackupProcess.FileName = My.Application.Info.DirectoryPath & "\temp\gbak\x32\gbak.exe"
                    BackupProcess.Arguments = "-b " & FirebirdIP & ":" & FirebirdDbase & " " & SFDDBBackup.FileName.ToString & " -user sysdba -pas masterkey -v"
                    'Process.Start(My.Application.Info.DirectoryPath & "\temp\gbak\x32\gbak.exe -b abono-info:abono abono.fbk -user sysdba -pas masterkey -v")

                Else
                    BackupProcess.FileName = My.Application.Info.DirectoryPath & "\temp\gbak\x64\gbak.exe"
                    BackupProcess.Arguments = "-b " & FirebirdIP & ":" & FirebirdDbase & " " & SFDDBBackup.FileName.ToString & " -user sysdba -pass masterkey -v"
                    'Process.Start(My.Application.Info.DirectoryPath & "\temp\gbak\x64\gbak.exe" & " -b abono-info:abono abono.fbk -user sysdba -pas masterkey -v")

                End If

                Process.Start(BackupProcess)
                MsgBox("Backup Process Initiated. Do not close the command application", MsgBoxStyle.OkOnly + vbInformation, My.Application.Info.Title.ToString)
            End If




        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click

        Call BackupDB()


    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        frmDocumentManager.Show()
    End Sub


    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Try
            FBcommand.Dispose()
            FBirdConnection.Close()
            End
        Catch

        Finally

        End Try

    End Sub

    Private Sub SchedulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchedulerToolStripMenuItem.Click
        frmSchedule.Show()
    End Sub


    Private Sub lstSched_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSched.ColumnClick
        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstSched.Columns(e.Column)
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
        lstSched.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstSched.Sort()
    End Sub

    Private Sub lstSched_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSched.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Dim LV As ListViewItem
        Me.Cursor = Cursors.WaitCursor
        With frmSchedule
            .lstAttachment.Items.Clear()
            frmSchedule.Show()
            Try
                Call FBirdConnectionOpen()
                FbirdCommand.Connection = FBirdConnection
                FBsql = "SELECT COUNT(SCHEDULE_ID) FROM SCHEDULER JOIN DOCUMENT ON SCHEDULER.SCHEDULER_DOCUMENT_ID = DOCUMENT.DOCUMENT_ID JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE SCHEDULE_ID =  '" & lstSched.SelectedItems(0).Text & "'"
                FbirdCommand.CommandText = FBsql
                If FbirdCommand.ExecuteScalar = 0 Then
                    FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_ID =  '" & lstSched.SelectedItems(0).Text & "' "
                    FbirdCommand.CommandText = FBsql
                    FbirdReader = FbirdCommand.ExecuteReader
                    FbirdReader.Read()
                Else
                    FBsql = "SELECT distinct * FROM SCHEDULER JOIN DOCUMENT ON SCHEDULER.SCHEDULER_DOCUMENT_ID = DOCUMENT.DOCUMENT_ID JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE SCHEDULE_ID =  '" & lstSched.SelectedItems(0).Text & "' "
                    FbirdCommand.CommandText = FBsql
                    FbirdReader = FbirdCommand.ExecuteReader
                    FbirdReader.Read()
                    LV = New ListViewItem(FbirdReader!DOCUMENT_ID.ToString)
                    LV.SubItems.Add(FbirdReader!RECEPIENT.ToString)
                    LV.SubItems.Add(FbirdReader!AGENCY.ToString)
                    LV.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                    .lstAttachment.Items.Add(LV)
                End If



                'FbirdReader.Read()
                .ID.Text = lstSched.SelectedItems(0).Text
                .txtAddress.Text = FbirdReader!SCHEDULE_ADDRESS.ToString
                .txtNote.Text = FbirdReader!NOTE.ToString
                .txtOrganization.Text = FbirdReader!ORGANIZATION.ToString
                .txtProgram.Text = FbirdReader!SCHEDULE_ACTIVITY.ToString
                .dtDate.Value = FbirdReader!SCHEDULE_DATE



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
            Call Proc_Button_Edit(frmSchedule.Name)
            Call Proc_Textbox_Edit(frmSchedule.Name)

            Me.Cursor = Cursors.Default
        End With
    End Sub

    Private Sub lstSched_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSched.SelectedIndexChanged

    End Sub

    'Private Sub mCalendar_MonthChanged(ByVal sender As System.Object, ByVal e As Pabo.Calendar.MonthChangedEventArgs) Handles mCalendar.MonthChanged
    '    'FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & Me.mCalendar.ActiveMonth.Month & "/" & 1 & "/" & Me.mCalendar.ActiveMonth.Year & "' AND '" & DateSerial(Me.mCalendar.ActiveMonth.Year, Me.mCalendar.ActiveMonth.Month + 1, 0) & "' ORDER BY SCHEDULE_DATE"
    '    'Call LoadDate(FBsql)
    'End Sub

    Private Sub ToolStripButton7_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.ButtonClick
        frmSchedule.Show()
    End Sub

    Private Sub ShiwToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShiwToolStripMenuItem.Click
        If pbSchedule.Visible = True Then
            ShiwToolStripMenuItem.Checked = False
            pbSchedule.Visible = False
            mCalendar.Visible = False
            lstSched.Visible = False
            lblSched.Visible = False
        Else
            ShiwToolStripMenuItem.Checked = True
            pbSchedule.Visible = True
            mCalendar.Visible = True
            lstSched.Visible = True
            lblSched.Visible = True
        End If
    End Sub

    Private Sub lblSched_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSched.DoubleClick

    End Sub

    Private Sub FinancialAssistanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmAssistanceRpt.Show()
    End Sub

    Private Sub MdiAbono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim oForm As MdiAbono
        'oForm = New MdiAbono

        'START SET SCHEDULE PANE LOCATION
        Me.pbSchedule.Height = Me.Height - 113
        ''pbSchedule.Location.X) = Me.Width
        Me.pbSchedule.Left = Me.Right - Me.pbSchedule.Width
        Me.mCalendar.Left = Me.pbSchedule.Left + 16
        ''Me.lstSched.Location = Me.mCalendar.Location
        Me.lstSched.Location = New Point(Me.mCalendar.Location.X - 10, Me.mCalendar.Location.Y + 240)
        Me.lstSched.Height = Me.pbSchedule.Height - mCalendar.Height - 120
        Me.lblSched.Left = Me.pbSchedule.Left + 7

        'END SET SCHEDULE PANE LOCATION


        Me.Text = My.Application.Info.Title.ToString & " v" & My.Application.Info.Version.ToString
        Call FirebirdConnect()
        Me.Show()


        frmLogin.ShowDialog()




    End Sub

    'Shared Function mcSchedule() As Object
    '    Throw New NotImplementedException
    'End Function


    Private Sub mCalendar_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mCalendar.DateChanged
        'FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & Me.mCalendar.Month & "/" & 1 & "/" & Me.mCalendar.ActiveMonth.Year & "' AND '" & DateSerial(Me.mCalendar.ActiveMonth.Year, Me.mCalendar.ActiveMonth.Month + 1, 0) & "' ORDER BY SCHEDULE_DATE"
        'Call LoadDate(FBsql)

        FBsql = "SELECT * FROM SCHEDULER WHERE SCHEDULE_DATE BETWEEN '" & Me.mCalendar.SelectionStart.ToString("MM") & "/1/" & Me.mCalendar.SelectionStart.ToString("yyyy") & "'  AND '" & DateSerial(mCalendar.SelectionEnd.Date.ToString("yyyy"), mCalendar.SelectionStart.ToString("MM") + 1, 0) & "' ORDER BY SCHEDULE_DATE"
        Call LoadDate(FBsql)
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Constring As String
        'Constring = "User ID=sysdba;Password=masterkey;" +
        '       "Database=google:abono; " +
        '       "DataSource=localhost;Charset=NONE;"
        ''FBirdConnectionOpen(adddetailsconenction = New FBirdConnection(Constring))
        'Dim Fbcon As FbConnection
        'Fbcon = New FbConnection(Constring)
        'Fbcon.Open()
        'Dim fback As new f



    End Sub

    Private Sub AssistanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssistanceToolStripMenuItem.Click
        'frmAssistanceRpt.Show()
    End Sub
End Class
