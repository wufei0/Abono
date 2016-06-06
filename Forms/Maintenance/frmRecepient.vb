Imports System.Data.Odbc
Public Class frmRecepient
    Private m_SortingColumn As ColumnHeader
    Private Sub frmRecepient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM RECEPIENT ORDER BY RECEPIENT_NAME ASC")

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM RECEPIENT WHERE RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_ADDRESS  LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT_NAME ASC")
    End Sub

    Private Sub lstRecepient_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstRecepient.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstRecepient.Columns(e.Column)
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
        lstRecepient.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstRecepient.Sort()
    End Sub

    Private Sub lstRecepient_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstRecepient.DoubleClick
        lblID.Text = lstRecepient.SelectedItems(0).Text
        Using FBcommand
            Try
                Call FBirdConnectionOpen()
                FBcommand.Connection = FBirdConnection
                FBsql = "SELECT * FROM RECEPIENT WHERE RECEPIENT_ID LIKE '" & lstRecepient.SelectedItems(0).Text & "' "
                FBcommand.CommandText = FBsql
                FBRecordset = FBcommand.ExecuteReader
                FBRecordset.Read()

                txtName.Text = FBRecordset!RECEPIENT_NAME.ToString
                txtAddress.Text = FBRecordset!RECEPIENT_ADDRESS.ToString
                txtContact.Text = FBRecordset!RECEPIENT_CONTACTNO.ToString
                txtDesignation.Text = FBRecordset!RECEPIENT_DESIGNATION.ToString
                Call Proc_Button_Edit(Me.Name)
                Call Proc_Textbox_Edit(Me.Name)
                FBRecordset.Close()
                FBirdConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            End Try
        End Using
    End Sub

    Private Sub lstRecepient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRecepient.SelectedIndexChanged

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FbirdCommand As New odbcCommand
        If txtName.Text = Nothing Then
            Beep()
            Exit Sub
        End If
        If txtDesignation.Text = Nothing Then
            Beep()
            Exit Sub

        End If

        Dim gUIDcREATE As String = GuidGenerator("RPT", Me.Name)

        Using FbirdCommand
            Try
                Call FBirdConnectionOpen()
                If lblID.Text = Nothing Then

                    FbirdCommand.Connection = FBirdConnection
                    lblID.Text = gUIDcREATE
                    FBsql = "INSERT INTO RECEPIENT(RECEPIENT_ID,RECEPIENT_NAME,RECEPIENT_ADDRESS,RECEPIENT_DESIGNATION,RECEPIENT_CONTACTNO, SECURITY_USER) VALUES ('" & lblID.Text & "','" & txtName.Text.ToUpper & "', '" & txtAddress.Text.ToUpper & "','" & txtDesignation.Text.ToUpper & "', '" & txtContact.Text.ToString & "' ,'" & MdiAbono.TSUserName.Text & "') "
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()

                Else
                    FbirdCommand.Connection = FBirdConnection
                    FBsql = "UPDATE RECEPIENT SET RECEPIENT_NAME = '" & txtName.Text.ToUpper & "', RECEPIENT_ADDRESS = '" & txtAddress.Text.ToUpper & "', RECEPIENT_DESIGNATION = '" & txtDesignation.Text.ToUpper & "', RECEPIENT_CONTACTNO = '" & txtContact.Text & "', SECURITY_USER =  '" & MdiAbono.TSUserName.Text & "' WHERE RECEPIENT_ID LIKE '" & lblID.Text & "' "
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()
                End If

                MsgBox("Recepient saved successful", vbInformation, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
                Call Proc_Button_Save(Me.Name)
                Call Proc_Textbox_Save(Me.Name)
                Call Proc_listview_Refresh(Me.Name, "SELECT * FROM RECEPIENT ORDER BY RECEPIENT_NAME ASC")
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            Finally
                FbirdCommand.Dispose()
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub

        Using FBcommand
            Try
                Call FBirdConnectionOpen()
                'If FBRecordset.IsClosed = False Then FBRecordset.Close()
                FBsql = "DELETE FROM RECEPIENT WHERE RECEPIENT_ID = '" & lblID.Text & "' "
                FBcommand.Connection = FBirdConnection
                FBcommand.CommandText = FBsql
                FBcommand.ExecuteNonQuery()
                MsgBox("Recepient deleted successful", vbInformation, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
                Call Proc_Button_Delete(Me.Name)
                Call Proc_Textbox_Delete(Me.Name)
                Call Proc_listview_Refresh(Me.Name, "SELECT * FROM RECEPIENT ORDER BY RECEPIENT_NAME ASC")


            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            End Try
        End Using
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM RECEPIENT WHERE RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_ADDRESS  LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT_NAME ASC")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class