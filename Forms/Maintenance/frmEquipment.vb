Imports System.Data.Odbc

Public Class frmEquipment

    Private m_SortingColumn As ColumnHeader

    Private Sub frmEquipment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiAbono
        Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT")
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)

    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FbirdCommand As New OdbcCommand
        Dim gUIDcREATE As String = GuidGenerator("EQP", Me.Name)
        If txtEquipment.Text = Nothing Then
            Beep()
            Exit Sub
        End If

        Using FbirdCommand
            Try

                Call FBirdConnectionOpen()
                If lblID.Text = Nothing Then

                    FbirdCommand.Connection = FBirdConnection
                    FBsql = "INSERT INTO EQUIPMENT(EQUIPMENT_ID,EQUIPMENT_NAME,EQUIPMENT_DESCRIPTION,"
                    FBsql = FBsql + "SECURITY_USER) VALUES ('" & gUIDcREATE & "' , '" & txtEquipment.Text.ToUpper & "'"
                    FBsql = FBsql + ", '" & txtEquipment_desciption.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "')"


                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()

                    MsgBox("Equipment insert successful", vbInformation, My.Application.Info.Title.ToString)
                    lblID.Text = gUIDcREATE



                ElseIf lblID.Text <> "" Then
                    FBsql = "UPDATE EQUIPMENT SET EQUIPMENT_NAME = '" & txtEquipment.Text.ToUpper & "',"
                    FBsql = FBsql + "EQUIPMENT_DESCRIPTION = '" & txtEquipment_desciption.Text.ToUpper & "' WHERE "
                    FBsql = FBsql + "EQUIPMENT_ID = '" & lblID.Text & "'"
                    FbirdCommand.Connection = FBirdConnection
                    FbirdCommand.CommandText = FBsql
                    FbirdCommand.ExecuteNonQuery()
                    MsgBox("Equipment update successful", vbInformation, My.Application.Info.Title.ToString)
                End If
                FBirdConnection.Close()
                Proc_Button_Save(Me.Name)
                Proc_Textbox_Save(Me.Name)
                Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT ORDER BY EQUIPMENT_NAME ASC")


            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            Finally
                FbirdCommand.Dispose()
            End Try





        End Using


    End Sub

    Private Sub lstEquipment_ColumnClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstEquipment.ColumnClick


        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstEquipment.Columns(e.Column)
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
        lstEquipment.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstEquipment.Sort()
    End Sub



    Private Sub lstEquipment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstEquipment.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader

        Try
            Call FBirdConnectionOpen()
            lblID.Text = lstEquipment.SelectedItems(0).SubItems(0).Text
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM EQUIPMENT WHERE EQUIPMENT_ID = '" & lstEquipment.SelectedItems(0).SubItems(0).Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdReader = FbirdCommand.ExecuteReader
            FbirdReader.Read()

            txtEquipment.Text = FbirdReader!EQUIPMENT_NAME.ToString
            txtEquipment_desciption.Text = FbirdReader!EQUIPMENT_DESCRIPTION.ToString
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            Try
                FbirdReader.Close()
            Catch ex As Exception

            End Try

        End Try

        'txtEquipment.Text = lstEquipment.SelectedItems(0).SubItems(1).Text
        'txtEquipment_desciption.Text = lstEquipment.SelectedItems(0).SubItems(2).Text

        Proc_Button_Edit(Me.Name)
        Proc_Textbox_Edit(Me.Name)

    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim FbirdCommand As New OdbcCommand




        If MsgBox("Confirm to Delete '" & txtEquipment.Text.ToUpper & "'.", vbOKCancel + vbQuestion, My.Application.Info.Title.ToString) = vbCancel Then
            Exit Sub

        End If


        Try
            Call FBirdConnectionOpen()
            FBsql = "DELETE FROM EQUIPMENT WHERE EQUIPMENT_ID = '" & lblID.Text & "'"
            FbirdCommand.Connection = FBirdConnection
            FbirdCommand.CommandText = FBsql
            FbirdCommand.ExecuteNonQuery()


            MsgBox(txtEquipment.Text.ToUpper & " deleted.", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            Proc_Button_Delete(Me.Name)
            Proc_Textbox_Delete(Me.Name)
            Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT ORDER BY EQUIPMENT_NAME ASC")




        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
        End Try




    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

   
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT WHERE EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' OR EQUIPMENT_DESCRIPTION LIKE '%" & txtSearch.Text & "%' ORDER BY EQUIPMENT_NAME ASC")
    End Sub

    Private Sub lstEquipment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEquipment.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT WHERE EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' OR EQUIPMENT_DESCRIPTION LIKE '%" & txtSearch.Text & "%' ORDER BY EQUIPMENT_NAME ASC")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class