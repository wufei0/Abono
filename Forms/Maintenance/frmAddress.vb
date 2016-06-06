Imports System.Data.Odbc
Public Class frmAddress
    Private m_SortingColumn As ColumnHeader
    Private Sub frmAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        'Call Proc_listview_Refresh(Me.Name, "SELECT * FROM MUNICIPALITY ORDER BY MUNICIPALITY ASC")

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FbirdCommand As New OdbcCommand

        Dim gUIDcREATE As String = GuidGenerator("ADR", Me.Name)



        If DuplicateIdentifier("SELECT COUNT(BARANGAY) FROM MUNICIPALITY WHERE BARANGAY = '" & txtBarangay.Text & "' ") = True Then
            Beep()
            If MsgBox("Possible duplicate entry of Barangay. Continue?.", MsgBoxStyle.YesNo, My.Application.Info.Title.ToString) = MsgBoxResult.No Then Exit Sub
        End If


        Using FbirdCommand
            Try

                Call FBirdConnectionOpen()
                If lblID.Text = Nothing Then

                    FbirdCommand.Connection = FBirdConnection
                    lblID.Text = gUIDcREATE
                    FBsql = "INSERT INTO MUNICIPALITY(MUNICIPALITY_ID,PROVINCE,MUNICIPALITY,BARANGAY,ORGANIZATION) VALUES ('" & lblID.Text & "','" & txtProvince.Text.ToUpper & "', '" & txtMunicipality.Text.ToUpper & "','" & txtBarangay.Text.ToUpper & "', '" & txtOrganization.Text.ToUpper & "') "
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()

                Else
                    FbirdCommand.Connection = FBirdConnection
                    FBsql = "UPDATE MUNICIPALITY SET PROVINCE = '" & txtProvince.Text.ToUpper & "', MUNICIPALITY = '" & txtMunicipality.Text.ToUpper & "', BARANGAY = '" & txtBarangay.Text.ToUpper & "', ORGANIZATION = '" & txtOrganization.Text.ToUpper & "' WHERE MUNICIPALITY_ID LIKE '" & lblID.Text & "' "
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()
                End If

                MsgBox("Municipality saved successful", vbInformation, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
                Call Proc_Button_Save(Me.Name)
                Call Proc_Textbox_Save(Me.Name)
                Call Proc_listview_Refresh(Me.Name, "SELECT * FROM MUNICIPALITY ORDER BY MUNICIPALITY ASC")
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
                FBsql = "DELETE FROM MUNICIPALITY WHERE MUNICIPALITY_ID = '" & lblID.Text & "' "
                FBcommand.Connection = FBirdConnection
                FBcommand.CommandText = FBsql
                FBcommand.ExecuteNonQuery()
                FBirdConnection.Close()

                Call Proc_Button_Delete(Me.Name)
                Call Proc_Textbox_Delete(Me.Name)
                Call Proc_listview_Refresh(Me.Name, "SELECT * FROM MUNICIPALITY ORDER BY MUNICIPALITY ASC")
                MsgBox("Municipality deleted successful", vbInformation, My.Application.Info.Title.ToString)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            End Try
        End Using
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE '%" & txtSearch.Text & "%' ORDER BY MUNICIPALITY ASC")
    End Sub

    Private Sub lstAddress_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstAddress.ColumnClick

        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstAddress.Columns(e.Column)
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
        lstAddress.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstAddress.Sort()
    End Sub

    Private Sub lstAddress_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAddress.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Me.Cursor = Cursors.WaitCursor
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY_ID = '" & lstAddress.SelectedItems(0).Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdReader = FbirdCommand.ExecuteReader

            FbirdReader.Read()
            lblID.Text = lstAddress.SelectedItems(0).Text
            txtMunicipality.Text = FbirdReader!MUNICIPALITY.ToString
            txtProvince.Text = FbirdReader!PROVINCE.ToString
            txtBarangay.Text = FbirdReader!BARANGAY.ToString
            txtOrganization.Text = FbirdReader!ORGANIZATION.ToString
            FbirdReader.Close()
            FbirdCommand.Dispose()
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        End Try



        'txtBarangay.Text = lstAddress.SelectedItems(0).SubItems(2).Text
        'txtMunicipality.Text = lstAddress.SelectedItems(0).SubItems(1).Text
        'txtProvince.Text = lstAddress.SelectedItems(0).SubItems(3).Text
        Call Proc_Button_Edit(Me.Name)
        Call Proc_Textbox_Edit(Me.Name)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAddress.SelectedIndexChanged

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE '%" & txtSearch.Text & "%' ORDER BY MUNICIPALITY ASC")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class