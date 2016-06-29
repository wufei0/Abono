Public Class frmRequest_Equipment_Input
    Private m_SortingColumn As ColumnHeader
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT WHERE EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' OR EQUIPMENT_DESCRIPTION LIKE '%" & txtSearch.Text & "%' ORDER BY EQUIPMENT_NAME ASC")
    End Sub

    Private Sub frmRequest_Equipment_Input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = MdiAbono
        '

        dtDate.Format = DateTimePickerFormat.Custom
        dtDate.CustomFormat = "MM/dd/yyyy"
   


    End Sub



    Private Sub lstEquipment_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstEquipment.ColumnClick


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
        lblEquipment_ID.Text = lstEquipment.SelectedItems(0).SubItems(0).Text
        txtEquipment_Name.Text = lstEquipment.SelectedItems(0).SubItems(1).Text
        txtEquipment_Description.Text = lstEquipment.SelectedItems(0).SubItems(2).Text
        txtRequest_Quantity.Text = Nothing
        Proc_Button_Edit(Me.Name)
        Proc_Textbox_Edit(Me.Name)
        txtRequest_Delivered.Enabled = False
        txtNote.Enabled = False
        'lblID.Text = GuidGenerator("REI")
    End Sub


    Private Sub lstEquipment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEquipment.SelectedIndexChanged

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim LVItem As ListViewItem





        With frmRequest_Equipment

            Select Case btnAdd.Text


                Case "Add"
                    If DuplicateChecker(.lstEquipment_Input, lblEquipment_ID.Text) = True Then
                        'MsgBox("Equipment already added.", vbInformation + vbOKOnly, My.Application.Info.Title.ToString)
                        Beep()
                        Exit Sub
                    End If
                    If txtRequest_Quantity.Text = Nothing Then
                        Beep()
                        Exit Sub
                    End If
                    If IsNumeric(txtRequest_Quantity.Text) = False Then
                        Beep()
                        Exit Sub
                    End If
                    LVItem = .lstEquipment_Input.Items.Add(lblEquipment_ID.Text)
                    LVItem.SubItems.Add(txtEquipment_Name.Text.ToUpper)
                    'LVItem.SubItems.Add(txtEquipment_Description.Text)
                    LVItem.SubItems.Add(txtRequest_Quantity.Text)
                    LVItem.SubItems.Add("")
                    LVItem.SubItems.Add("")
                    LVItem.SubItems.Add("")
                    LVItem.SubItems.Add("")
                    LVItem.SubItems.Add("")
                Case "Update"

                    If txtRequest_Delivered.Text = Nothing Then
                        Beep()
                        Exit Sub
                    End If
                    If IsNumeric(txtRequest_Delivered.Text) = False Then
                        Beep()
                        Exit Sub
                    End If

                    Dim CountX As Integer = 0
                    For Each ListViewDest As ListViewItem In .lstEquipment_Input.Items
                        If lblEquipment_ID.Text = ListViewDest.Text Then
                            .lstEquipment_Input.Items(CountX).SubItems(0).Text = ListViewDest.Text
                            .lstEquipment_Input.Items(CountX).SubItems(1).Text = txtEquipment_Name.Text.ToUpper
                            '.lstEquipment_Input.Items(CountX).SubItems(2).Text = txtEquipment_Description.Text
                            .lstEquipment_Input.Items(CountX).SubItems(2).Text = txtRequest_Quantity.Text
                            .lstEquipment_Input.Items(CountX).SubItems(3).Text = txtRequest_Delivered.Text
                            .lstEquipment_Input.Items(CountX).SubItems(4).Text = dtDate.Text
                            .lstEquipment_Input.Items(CountX).SubItems(5).Text = txtNote.Text.ToUpper
                            .lstEquipment_Input.Items(CountX).SubItems(6).Text = txtName.Text.ToUpper
                            .lstEquipment_Input.Items(CountX).SubItems(7).Text = txtDesignation.Text.ToUpper
                            '.delivery_date = dtDate.Value
                            '.requested_quantity = txtRequest_Quantity.Text
                            '.delivered_quantity = txtRequest_Delivered.Text
                        End If
                        CountX = CountX + 1
                    Next

            End Select
        End With
        Me.Close()
    End Sub

    Private Sub txtRequest_Quantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequest_Quantity.LostFocus
        'If IsNumeric(txtRequest_Quantity.Text) = False Then
        '    Beep()
        '    txtRequest_Quantity.Focus()
        'End If
    End Sub

    Private Sub txtRequest_Quantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequest_Quantity.TextChanged
      
        'If txtRequest_Quantity.Text = Nothing Then
        '    Beep()
        '    txtRequest_Quantity.Focus()
        'End If


    End Sub

    Private Sub txtRequest_Delivered_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequest_Delivered.LostFocus
        'If IsNumeric(txtRequest_Quantity.Text) = False Then
        '    Beep()
        '    txtRequest_Delivered.Focus()
        'End If
    End Sub

    Private Sub txtRequest_Delivered_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequest_Delivered.TextChanged
       
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM EQUIPMENT WHERE EQUIPMENT_NAME LIKE '%" & txtSearch.Text & "%' OR EQUIPMENT_DESCRIPTION LIKE '%" & txtSearch.Text & "%' ORDER BY EQUIPMENT_NAME ASC")
        End If
    End Sub

   
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class