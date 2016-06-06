
Imports System.Data.Odbc
Imports Pabo.Calendar
Module Proc_ListView

    Public Sub Proc_listview_Refresh(ByVal Formname As String, ByVal SqlScript As String)
        Dim LVItem As ListViewItem
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader = Nothing


        MdiAbono.Cursor = Cursors.WaitCursor

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdCommand.CommandText = SqlScript
            'If FbirdReader.IsClosed = True Then FbirdReader.Close()
            FbirdReader = FbirdCommand.ExecuteReader

            Select Case Formname

                Case "frmEquipment"
                    With frmEquipment
                        .lstEquipment.Items.Clear()

                        While FbirdReader.Read
                            LVItem = .lstEquipment.Items.Add(FbirdReader!EQUIPMENT_ID)
                            LVItem.SubItems.Add(FbirdReader!EQUIPMENT_NAME.ToString)
                            'LVItem.SubItems.Add(FbirdReader!EQUIPMENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!EQUIPMENT_DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                        End While
                        .lblRecordFound.Text = .lstEquipment.Items.Count & " record/s found."

                    End With


                Case "frmRecepient"
                    With frmRecepient
                        .lstRecepient.Items.Clear()

                        While FbirdReader.Read
                            LVItem = .lstRecepient.Items.Add(FbirdReader!RECEPIENT_ID)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_DESIGNATION.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_ADDRESS.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                        End While
                        .lblRecordFound.Text = .lstRecepient.Items.Count & " record/s found."
                    End With

                Case "frmRequest_Equipment_Input"
                    With frmRequest_Equipment_Input
                        .lstEquipment.Items.Clear()

                        While FbirdReader.Read
                            LVItem = .lstEquipment.Items.Add(FbirdReader!EQUIPMENT_ID)
                            LVItem.SubItems.Add(FbirdReader!EQUIPMENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!EQUIPMENT_DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                        End While
                        .lblRecordFound.Text = .lstEquipment.Items.Count & " record/s found."
                    End With


                Case "frmSearch_Recepient"
                    With frmSearch
                        .lstSearch.Items.Clear()
                        While FbirdReader.Read
                            LVItem = .lstSearch.Items.Add(FbirdReader!RECEPIENT_ID)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_ADDRESS.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_DESIGNATION.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_CONTACTNO.ToString)
                        End While

                    End With

                Case "frmSearch_Address"
                    With frmSearch
                        .lstSearch.Items.Clear()
                        While FbirdReader.Read
                            LVItem = .lstSearch.Items.Add(FbirdReader!MUNICIPALITY_ID)
                            LVItem.SubItems.Add(FbirdReader!BARANGAY.ToString)
                            LVItem.SubItems.Add(FbirdReader!MUNICIPALITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!PROVINCE.ToString)
                            LVItem.SubItems.Add(FbirdReader!ORGANIZATION.ToString)

                        End While
                    End With
                Case "frmSearch_Schedule"
                    With frmSearch
                        .lstSearch.Items.Clear()
                        While FbirdReader.Read
                            LVItem = .lstSearch.Items.Add(FbirdReader!DOCUMENT_ID)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT.ToString)
                            LVItem.SubItems.Add(FbirdReader!AGENCY.ToString)
                            LVItem.SubItems.Add(FbirdReader!DOCUMENT_DATE)
                            LVItem.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!MUNICIPALITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!NOTE.ToString)

                        End While

                    End With

                Case "frmRequest_Equipment"
                    With frmRequest_Equipment
                        .lstEquipment_request.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!EQUIPMENT_REQUEST_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!BARANGAY.ToString & ", " & FbirdReader!MUNICIPALITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!DATE_RECEIVED)
                            LVItem.SubItems.Add(FbirdReader!approved_bv.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            'LVItem.SubItems.Add(FbirdReader!EQUIPMENT_REQUEST_ID.ToString)
                            .lstEquipment_request.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstEquipment_request.Items.Count & " record/s found."
                    End With

                Case "frmAddress"
                    With frmAddress
                        .lstAddress.Items.Clear()

                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!MUNICIPALITY_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!MUNICIPALITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!BARANGAY.ToString)
                            LVItem.SubItems.Add(FbirdReader!PROVINCE.ToString)
                            LVItem.SubItems.Add(FbirdReader!ORGANIZATION.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstAddress.Items.Add(LVItem)

                        End While
                        .lblRecordFound.Text = .lstAddress.Items.Count & " record/s found."
                    End With

                Case "frmRecepient"
                    With frmRecepient
                        .lstRecepient.Items.Clear()

                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!INFRA_REQUEST_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_DESIGNATION.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_ADDRESS.ToString)
                            .lstRecepient.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstRecepient.Items.Count & " record/s found."
                    End With

                Case "frmInfrastructure"
                    With frmInfrastructure
                        .lstInfrastructure.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!INFRA_REQUEST_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!BARANGAY.ToString & ", " & FbirdReader!MUNICIPALITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!DATE_RECEIVED)
                            LVItem.SubItems.Add(FbirdReader!AMOUNT.ToString)
                            LVItem.SubItems.Add(FbirdReader!APPROVED_BV.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstInfrastructure.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstInfrastructure.Items.Count & " record/s found."
                    End With

                Case "frmAssistance"
                    With frmAssistance
                        .lstAssistance.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!ASSISTANCE_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!CLAIMANT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                            LVItem.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!DATE_RECEIVED)
                            LVItem.SubItems.Add(FbirdReader!AMOUNT.ToString)
                            LVItem.SubItems.Add(FbirdReader!APPROVED_BV.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstAssistance.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstAssistance.Items.Count & " record/s found."
                    End With

                    'Case "frmSearch_Assistance"
                    '    With frmSearch
                    '        .lstSearch.Items.Clear()
                    '        While FbirdReader.Read
                    '            LVItem = New ListViewItem(FbirdReader!CLAIMANT_ID.ToString)
                    '            'LVItem.SubItems.Add(FbirdReader!BARANGAY.ToString & ", " & FbirdReader!MUNICIPALITY.ToString)
                    '            'LVItem.SubItems.Add(FbirdReader!RECEPIENT_NAME.ToString)
                    '            'LVItem.SubItems.Add(FbirdReader!DATE_RECEIVED.ToString)
                    '            .lstSearch.Items.Add(LVItem)
                    '        End While
                    '    End With


                Case "frmDocumentManager"
                    With frmDocumentManager
                        .lstDocument.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!DOCUMENT_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!RECEPIENT.ToString)
                            LVItem.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!MUNICIPALITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!DOCUMENT_DATE)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstDocument.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstDocument.Items.Count & " record/s found."
                    End With

                Case "frmDocumentType"
                    With frmDocumentType
                        .lstDocument_type.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!document_type_id.ToString)
                            LVItem.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstDocument_type.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstDocument_type.Items.Count & " record/s found."
                    End With

                Case "frmAssistanceType"
                    With frmAssistanceType
                        .lstAssistance_type.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!assistance_type_id.ToString)
                            LVItem.SubItems.Add(FbirdReader!DESCRIPTION.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstAssistance_type.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstAssistance_type.Items.Count & " record/s found."
                    End With

                Case "frmDirectory"
                    With frmDirectory
                        .lstDirectory.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!DIRECTORY_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!CONTACT_PERSON.ToString)
                            LVItem.SubItems.Add(FbirdReader!CONTACT_ORGANIZATION.ToString)
                            LVItem.SubItems.Add(FbirdReader!CONTACT_ADDRESS.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstDirectory.Items.Add(LVItem)
                        End While
                        .lblRecordFound.Text = .lstDirectory.Items.Count & " record/s found."
                    End With

                Case "frmSchedule"
                    With frmSchedule
                        .lstSchedule.Items.Clear()
                        While FbirdReader.Read
                            LVItem = New ListViewItem(FbirdReader!SCHEDULE_ID.ToString)
                            LVItem.SubItems.Add(FbirdReader!SCHEDULE_ACTIVITY.ToString)
                            LVItem.SubItems.Add(FbirdReader!SCHEDULE_DATE)
                            LVItem.SubItems.Add(FbirdReader!NOTE.ToString)
                            LVItem.SubItems.Add(FbirdReader!SECURITY_USER.ToString)
                            .lstSchedule.Items.Add(LVItem)

                        End While
                        .lblRecordFound.Text = .lstSchedule.Items.Count & " record/s found."
                    End With
            End Select


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

        MdiAbono.Cursor = Cursors.Default




    End Sub


    Public Sub LoadDate(ByVal SqlString As String)
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Dim lv As ListViewItem
        Dim BoldedDate As Date
        'Dim dateitem1 As DateItem
        MdiAbono.lstSched.Items.Clear()
        MdiAbono.lblSched.Text = "List of schedule/s for the month of " & MonthName(MdiAbono.mCalendar.TodayDate.Month) & "."
        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdCommand.CommandText = SqlString
            FbirdReader = FbirdCommand.ExecuteReader
            MdiAbono.mCalendar.BoldedDates = Nothing
            While FbirdReader.Read
                lv = New ListViewItem(FbirdReader!SCHEDULE_ID.ToString)
                lv.SubItems.Add(FbirdReader!SCHEDULE_DATE)
                lv.SubItems.Add(FbirdReader!SCHEDULE_ACTIVITY.ToString)
                lv.SubItems.Add(FbirdReader!SCHEDULE_ADDRESS.ToString)
                lv.SubItems.Add(FbirdReader!ORGANIZATION.ToString)
                lv.SubItems.Add(FbirdReader!NOTE.ToString)
                MdiAbono.lstSched.Items.Add(lv)
                BoldedDate = FbirdReader!SCHEDULE_DATE

                MdiAbono.mCalendar.AddBoldedDate(BoldedDate)
                MdiAbono.mCalendar.UpdateBoldedDates()
                'dateitem1 = New DateItem
                'dateitem1.Date = FbirdReader!SCHEDULE_DATE
                'dateitem1.BackColor1 = Color.Yellow
                'MdiAbono.mcSchedule.AddDateInfo(dateitem1)

            End While
            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally

            FbirdCommand.Dispose()

            Try
                FbirdReader.Close()
            Catch ex1 As Exception

            End Try
        End Try

    End Sub
End Module
