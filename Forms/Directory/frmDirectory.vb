Imports System.Data.Odbc

Public Class frmDirectory
    Private m_SortingColumn As ColumnHeader
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmDirectory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM CONTACT_DIRECTORY ORDER BY CONTACT_PERSON")

    End Sub

    Private Sub lstDirectory_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstDirectory.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstDirectory.Columns(e.Column)
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
        lstDirectory.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstDirectory.Sort()
    End Sub

    Private Sub lstDirectory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDirectory.DoubleClick
        Dim fbirdcommand As New OdbcCommand
        Dim fbirdrecordset As OdbcDataReader

        Try
            Call FBirdConnectionOpen()
            fbirdcommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM CONTACT_DIRECTORY WHERE DIRECTORY_ID = '" & lstDirectory.SelectedItems(0).Text & "' "
            fbirdcommand.CommandText = FBsql
            fbirdrecordset = fbirdcommand.ExecuteReader
            fbirdrecordset.Read()
            lblID.Text = lstDirectory.SelectedItems(0).Text
            txtContact_Name.Text = fbirdrecordset!CONTACT_PERSON.ToString
            txtContact_No.Text = fbirdrecordset!CONTACT_NUMBER.ToString
            txtAddress.Text = fbirdrecordset!CONTACT_ADDRESS.ToString
            txtOrganization.Text = fbirdrecordset!CONTACT_ORGANIZATION.ToString
            txtTag.Text = fbirdrecordset!CONTACT_TAG.ToString

            Call Proc_Button_Edit(Me.Name)
            Call Proc_Textbox_Edit(Me.Name)
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & fbirdcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            fbirdcommand.Dispose()
            Try
                fbirdrecordset.Close()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM CONTACT_DIRECTORY WHERE CONTACT_PERSON LIKE '%" & txtSearch.Text & "%' OR CONTACT_ORGANIZATION LIKE '%" & txtSearch.Text & "%' OR CONTACT_ADDRESS LIKE '%" & txtSearch.Text & "%' OR CONTACT_ADDRESS LIKE '%" & txtSearch.Text & "%' OR CONTACT_TAG LIKE '%" & txtSearch.Text & "%' ORDER BY CONTACT_PERSON")
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM CONTACT_DIRECTORY WHERE CONTACT_PERSON LIKE '%" & txtSearch.Text & "%' OR CONTACT_ORGANIZATION LIKE '%" & txtSearch.Text & "%' OR CONTACT_ADDRESS LIKE '%" & txtSearch.Text & "%' OR CONTACT_ADDRESS LIKE '%" & txtSearch.Text & "%' OR CONTACT_TAG LIKE '%" & txtSearch.Text & "%' ORDER BY CONTACT_PERSON")
        End If
    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FbirdCommand As New OdbcCommand
        If txtContact_Name.Text = "" Or txtContact_No.Text = "" Then
            Beep()
            Exit Sub
        End If

        If DuplicateIdentifier("SELECT COUNT(CONTACT_PERSON) FROM CONTACT_DIRECTORY WHERE CONTACT_PERSON LIKE '" & txtContact_Name.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry of Contact Person. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then Exit Sub
        End If

        Dim gUIDcREATE As String = GuidGenerator("DTY", Me.Name)

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection

            If lblID.Text = "" Then
                FBsql = "INSERT INTO CONTACT_DIRECTORY(DIRECTORY_ID, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_ORGANIZATION, CONTACT_ADDRESS, CONTACT_TAG, SECURITY_USER)"
                FBsql = FBsql & "VALUES ('" & gUIDcREATE & "', '" & txtContact_Name.Text.ToUpper & "', '" & txtContact_No.Text & "', '" & txtOrganization.Text.ToUpper & "', '" & txtAddress.Text.ToUpper & "', '" & txtTag.Text.ToUpper & "', '" & MdiAbono.TSUserName.Text & "')"
                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()
                lblID.Text = gUIDcREATE
            Else
                FBsql = "UPDATE CONTACT_DIRECTORY SET CONTACT_PERSON = '" & txtContact_Name.Text.ToUpper & "', CONTACT_NUMBER = '" & txtContact_No.Text & "', CONTACT_ORGANIZATION = '" & txtOrganization.Text.ToUpper & "',"
                FBsql = FBsql & "CONTACT_ADDRESS = '" & txtAddress.Text.ToUpper & "', CONTACT_TAG = '" & txtTag.Text.ToUpper & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "' WHERE DIRECTORY_ID = '" & lblID.Text & "' "
                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()
            End If

            Call Proc_Textbox_Save(Me.Name)
            Call Proc_Button_Save(Me.Name)
            MsgBox("Contact saved successful", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally

            FbirdCommand.Dispose()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Confirm to delete.", vbOKCancel + vbInformation, My.Application.Info.Title.ToString) = vbCancel Then Exit Sub
        Dim FbirdCommand As New OdbcCommand

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "DELETE FROM CONTACT_DIRECTORY WHERE DIRECTORY_ID = '" & lblID.Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdCommand.ExecuteNonQuery()
            MsgBox("Contact deleted successful", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            Call Proc_Button_Delete(Me.Name)
            Call Proc_Textbox_Delete(Me.Name)
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM CONTACT_DIRECTORY ORDER BY CONTACT_PERSON")
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
        End Try

    End Sub

    Private Sub lstDirectory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDirectory.SelectedIndexChanged

    End Sub

    Private Sub btnSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM CONTACT_DIRECTORY WHERE CONTACT_PERSON LIKE '%" & txtSearch.Text & "%' OR CONTACT_ORGANIZATION LIKE '%" & txtSearch.Text & "%' OR CONTACT_ADDRESS LIKE '%" & txtSearch.Text & "%' OR CONTACT_ADDRESS LIKE '%" & txtSearch.Text & "%' OR CONTACT_TAG LIKE '%" & txtSearch.Text & "%' ORDER BY CONTACT_PERSON")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class