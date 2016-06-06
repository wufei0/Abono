Module Proc_Button

    Public Sub Proc_Button_New(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmRequest_Equipment_Input"
                With frmRequest_Equipment_Input
                    .btnAdd.Enabled = False
                End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True

                End With

            Case "frmAddress"
                With frmAddress
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True

                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmAssistance"
                With frmAssistance
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmDocumentType"
                With frmDocumentType
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmAssistanceType"
                With frmAssistanceType
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmDirectory"
                With frmDirectory
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmSchedule"
                With frmSchedule
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With
        End Select

    End Sub
    Public Sub Proc_Button_Save(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

                'Case "frmRequest_Equipment_Input"
                '    With frmRequest_Equipment_Input
                '        .btnAdd.Enabled = False
                '    End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False

                End With

            Case "frmAddress"
                With frmAddress
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False

                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmAssistance"
                With frmAssistance
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmDocumentType"
                With frmDocumentType
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmAssistanceType"
                With frmAssistanceType
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmDirectory"
                With frmDirectory
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmSchedule"
                With frmSchedule
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
        End Select
    End Sub
    Public Sub Proc_Button_Delete(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False

                End With

            Case "frmAddress"
                With frmAddress
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False

                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmAssistance"
                With frmAssistance
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmDocumentType"
                With frmDocumentType
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmAssistanceType"
                With frmAssistanceType
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmDirectory"
                With frmDirectory
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
            Case "frmSchedule"
                With frmSchedule
                    .btnDelete.Enabled = False
                    .btnNew.Enabled = True
                    .btnSave.Enabled = False
                End With
        End Select
    End Sub

    Public Sub Proc_Button_Edit(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With
            Case "frmRequest_Equipment_Input"
                With frmRequest_Equipment_Input
                    .btnAdd.Enabled = True
                End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True

                End With

            Case "frmAddress"
                With frmAddress
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmRecepient"
                With frmRecepient
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True

                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmAssistance"
                With frmAssistance
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With

            Case "frmDocumentType"
                With frmDocumentType
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With
            Case "frmAssistanceType"
                With frmAssistanceType
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With
            Case "frmDirectory"
                With frmDirectory
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With
            Case "frmSchedule"
                With frmSchedule
                    .btnDelete.Enabled = True
                    .btnNew.Enabled = True
                    .btnSave.Enabled = True
                End With
        End Select
    End Sub
End Module
