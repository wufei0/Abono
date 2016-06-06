Imports System.Data.Odbc
Public Class frmSearch
    Private m_SortingColumn As ColumnHeader
    Public frmSearch_Key As String
    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
     
          

            Select Case frmSearch_Key
            Case "RECEPIENT"
                Proc_listview_Refresh("frmSearch_Recepient", "SELECT * FROM RECEPIENT WHERE RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_ADDRESS LIKE '%" & txtSearch.Text & "%'  ORDER BY RECEPIENT_NAME ASC")

            Case "MUNICIPALITY"
                Proc_listview_Refresh("frmSearch_Address", "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR PROVINCE LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE  '%" & txtSearch.Text & "%' ORDER BY BARANGAY ASC")

            Case "RECEPIENT_INFRA"
                Proc_listview_Refresh("frmSearch_Recepient", "SELECT * FROM RECEPIENT WHERE RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_ADDRESS LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT_NAME ASC")
            Case "MUNICIPALITY_INFRA"
                Proc_listview_Refresh("frmSearch_Address", "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR PROVINCE LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE  '%" & txtSearch.Text & "%'  ORDER BY BARANGAY ASC")

            Case "ASSISTANCE_CLAIMANT"
            Case "SCHEDULE"
                Proc_listview_Refresh("frmSearch_Schedule", "SELECT DISTINCT * FROM DOCUMENT JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE DOCUMENT_TYPE.DESCRIPTION  = '%" & txtSearch.Text & "%' OR  RECEPIENT LIKE '%" & txtSearch.Text & "%' OR NOTE LIKE '%" & txtSearch.Text & "%' OR MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR DESCRIPTION LIKE '%" & txtSearch.Text & "%'  OR AGENCY LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT ASC")

                'Proc_listview_Refresh("frmSearch_Assistance"
        End Select

   
    End Sub

    Private Sub lstSearch_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSearch.ColumnClick
        ' Get the new sorting column.  

        Dim new_sorting_column As ColumnHeader = lstSearch.Columns(e.Column)
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
        lstSearch.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.  
        lstSearch.Sort()
    End Sub



    Private Sub lstSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection

            Select Case frmSearch_Key
                Case "RECEPIENT"
                    FBsql = "SELECT * FROM RECEPIENT WHERE RECEPIENT_ID = '" & lstSearch.SelectedItems(0).SubItems(0).Text & "'"
                    FbirdCommand.CommandText = FBsql
                    FbirdReader = FbirdCommand.ExecuteReader()
                    FbirdReader.Read()
                    With frmRequest_Equipment
                        .txtRecepient_name.Text = FbirdReader!RECEPIENT_NAME
                        .txtRecepient_Address.Text = FbirdReader!RECEPIENT_ADDRESS
                        .txtRecepient_Designation.Text = FbirdReader!RECEPIENT_DESIGNATION
                        .txtRecepient_contactno.Text = FbirdReader!RECEPIENT_CONTACTNO
                        .lblRecepient_id.Text = FbirdReader!RECEPIENT_ID
                    End With

                Case "MUNICIPALITY"
                    With frmRequest_Equipment
                        .txtAddress.Text = lstSearch.SelectedItems(0).SubItems(1).Text & ", " & lstSearch.SelectedItems(0).SubItems(2).Text & " ," & lstSearch.SelectedItems(0).SubItems(3).Text
                        .lbladdress_ID.Text = lstSearch.SelectedItems(0).SubItems(0).Text
                        .txtOrganization.Text = lstSearch.SelectedItems(0).SubItems(4).Text
                    End With

                Case "RECEPIENT_INFRA"
                    FBsql = "SELECT * FROM RECEPIENT WHERE RECEPIENT_ID = '" & lstSearch.SelectedItems(0).SubItems(0).Text & "'"
                    FbirdCommand.CommandText = FBsql
                    FbirdReader = FbirdCommand.ExecuteReader()
                    FbirdReader.Read()

                    With frmInfrastructure
                        .txtRecepient_name.Text = FbirdReader!RECEPIENT_NAME
                        .txtRecepient_Address.Text = FbirdReader!RECEPIENT_ADDRESS
                        .txtRecepient_Designation.Text = FbirdReader!RECEPIENT_DESIGNATION
                        .txtRecepient_contactno.Text = FbirdReader!RECEPIENT_CONTACTNO
                        .lblRecepient_id.Text = FbirdReader!RECEPIENT_ID
                    End With

                Case "MUNICIPALITY_INFRA"
                    With frmInfrastructure
                        .txtAddress.Text = lstSearch.SelectedItems(0).SubItems(1).Text & ", " & lstSearch.SelectedItems(0).SubItems(2).Text & " ," & lstSearch.SelectedItems(0).SubItems(3).Text
                        .lbladdress_id.Text = lstSearch.SelectedItems(0).SubItems(0).Text
                        .txtOrganization.Text = lstSearch.SelectedItems(0).SubItems(4).Text
                    End With

                Case "SCHEDULE"
                    Dim LV As ListViewItem
                    With frmSchedule
                        .lstAttachment.Items.Clear()
                        LV = New ListViewItem(lstSearch.SelectedItems(0).Text)
                        LV.SubItems.Add(lstSearch.SelectedItems(0).SubItems(1).Text)
                        LV.SubItems.Add(lstSearch.SelectedItems(0).SubItems(2).Text)
                        LV.SubItems.Add(lstSearch.SelectedItems(0).SubItems(4).Text)
                        .lstAttachment.Items.Add(LV)

                        '.txtAddress.Text = lstSearch.SelectedItems(0).SubItems(1).Text & ", " & lstSearch.SelectedItems(0).SubItems(2).Text & " ," & lstSearch.SelectedItems(0).SubItems(3).Text
                        '.lbladdress_id.Text = lstSearch.SelectedItems(0).SubItems(0).Text
                        '.txtOrganization.Text = lstSearch.SelectedItems(0).SubItems(4).Text
                    End With


            End Select
            FBirdConnection.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FBcommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
            Try
                FbirdReader.Close()
            Catch ex As Exception

            End Try



        End Try

    End Sub

    Private Sub lstSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSearch.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then




            Select Case frmSearch_Key
                Case "RECEPIENT"
                    Proc_listview_Refresh("frmSearch_Recepient", "SELECT * FROM RECEPIENT WHERE RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_ADDRESS LIKE '%" & txtSearch.Text & "%'  ORDER BY RECEPIENT_NAME ASC")

                Case "MUNICIPALITY"
                    Proc_listview_Refresh("frmSearch_Address", "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR PROVINCE LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE  '%" & txtSearch.Text & "%' ORDER BY BARANGAY ASC")

                Case "RECEPIENT_INFRA"
                    Proc_listview_Refresh("frmSearch_Recepient", "SELECT * FROM RECEPIENT WHERE RECEPIENT_NAME LIKE '%" & txtSearch.Text & "%' OR RECEPIENT_ADDRESS LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT_NAME ASC")
                Case "MUNICIPALITY_INFRA"
                    Proc_listview_Refresh("frmSearch_Address", "SELECT * FROM MUNICIPALITY WHERE MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR PROVINCE LIKE '%" & txtSearch.Text & "%' OR BARANGAY LIKE '%" & txtSearch.Text & "%' OR ORGANIZATION LIKE  '%" & txtSearch.Text & "%'  ORDER BY BARANGAY ASC")

                Case "ASSISTANCE_CLAIMANT"
                    'Proc_listview_Refresh("frmSearch_Assistance"
                Case "SCHEDULE"
                    Proc_listview_Refresh("frmSearch_Schedule", "SELECT DISTINCT * FROM DOCUMENT JOIN DOCUMENT_TYPE ON DOCUMENT.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID WHERE DOCUMENT_TYPE.DESCRIPTION  = '%" & txtSearch.Text & "%' OR  RECEPIENT LIKE '%" & txtSearch.Text & "%' OR NOTE LIKE '%" & txtSearch.Text & "%' OR MUNICIPALITY LIKE '%" & txtSearch.Text & "%' OR DESCRIPTION LIKE '%" & txtSearch.Text & "%'  OR AGENCY LIKE '%" & txtSearch.Text & "%' ORDER BY RECEPIENT ASC")
            End Select
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class