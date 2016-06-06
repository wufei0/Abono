Module Proc_TextBox

    Public Sub Proc_Textbox_New(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .txtEquipment.Enabled = True
                    .txtEquipment_desciption.Enabled = True

                    .txtEquipment.Text = Nothing
                    .txtEquipment_desciption.Text = Nothing
                    .lblID.Text = Nothing
                End With


            Case "frmRequest_Equipment_Input"
                With frmRequest_Equipment_Input
                    .txtNote.Enabled = False
                    .txtRequest_Delivered.Enabled = False
                    .txtRequest_Quantity.Enabled = False
                    .txtName.Enabled = False
                    .txtDesignation.Enabled = False

                    .txtName.Text = Nothing
                    .txtDesignation.Text = Nothing

                    .txtEquipment_Name.Text = Nothing
                    .txtEquipment_Description.Text = Nothing
                    .txtRequest_Delivered.Text = Nothing
                    .txtRequest_Quantity.Text = Nothing
                    .txtNote.Text = Nothing
                    .lblID.Text = Nothing
                End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    '.grpEquipment.BackColor = backcolor.KnownColor.Control
                    .grpEquipmentRequest.Enabled = True

                    .txtRecepient_name.Text = Nothing
                    .txtRecepient_Address.Text = Nothing
                    .txtRecepient_contactno.Text = Nothing
                    .txtRecepient_Designation.Text = Nothing
                    .txtNote.Text = Nothing
                    .txtAddress.Text = Nothing
                    .txtOrganization.Text = Nothing


                    .dtApproved.Enabled = False
                    .lbladdress_ID.Text = Nothing
                    .lblID.Text = Nothing
                    .lblRecepient_id.Text = Nothing

                    .lstEquipment_Input.Items.Clear()
                    .lstAttachment.Items.Clear()
                    .chkApproved.Checked = False
                End With

            Case "frmAddress"
                With frmAddress
                    .lblID.Text = Nothing
                    .txtProvince.Text = Nothing
                    .txtMunicipality.Text = Nothing
                    .txtBarangay.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .txtOrganization.Enabled = True
                    .txtMunicipality.Enabled = True
                    .txtProvince.Enabled = True
                    .txtBarangay.Enabled = True

                End With

            Case "frmRecepient"
                With frmRecepient
                    .txtName.Text = Nothing
                    .txtAddress.Text = Nothing
                    .txtDesignation.Text = Nothing
                    .txtContact.Text = Nothing
                    .lblID.Text = Nothing

                    .txtName.Enabled = True
                    .txtAddress.Enabled = True
                    .txtDesignation.Enabled = True
                    .txtContact.Enabled = True

                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    .grpInfra.Enabled = True

                    .txtAddress.Text = Nothing
                    .txtRecepient_name.Text = Nothing
                    .txtRecepient_Address.Text = Nothing
                    .txtRecepient_contactno.Text = Nothing
                    .txtRecepient_Designation.Text = Nothing
                    .txtOrganization.Text = Nothing

                    .chkApproved.Checked = False
                    .txtProposal.Text = Nothing
                    .txtNote.Text = Nothing

                    .lblID.Text = Nothing
                    .lblRecepient_id.Text = Nothing
                    .lbladdress_id.Text = Nothing
                    .txtamount.Text = 0.0
                    .lstAttachment.Items.Clear()
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    .grpDocManager.Enabled = True
                    .lblDocumentTYPEID.Text = Nothing
                    '.txtDocumentType.Text = Nothing
                    '.txtDescription.Text = Nothing
                    .txtRecepient.Text = Nothing
                    .txtAgency.Text = Nothing
                    .dtDate.Value = Now
                    .txtMunicipality.Text = Nothing
                    .txtNote.Text = Nothing
                    '.txtNote.Enabled = True
                    .lblID.Text = Nothing
                    .lstAttachment.Items.Clear()

                End With

            Case "frmAssistance"
                With frmAssistance
                    .GrpAssistance.Enabled = True

                    '.txtAssistance_description.Text = Nothing
                    .txtRecepientName.Text = Nothing
                    .txtRecepientAddress.Text = Nothing
                    .txtClaimantAddress.Text = Nothing
                    .txtClaimantName.Text = Nothing
                    .txtAmount.Text = 0
                    .txtRemark.Text = Nothing
                    .chkApproved.Checked = False
                    .chkReleased.Checked = False
                    .dtApproved.Enabled = False
                    .dtReleased.Enabled = False


                    .lblID.Text = Nothing
                    .lblAssistance_ID.Text = Nothing

                    .lstAttachment.Items.Clear()

                End With

            Case "frmDocumentType"
                With frmDocumentType
                    .txtDocumentType.Text = Nothing
                    .txtDocumentType.Enabled = True
                    .lblID.Text = Nothing
                End With

            Case "frmAssistanceType"
                With frmAssistanceType
                    .txtAssistanceType.Text = Nothing
                    .txtAssistanceType.Enabled = True
                    .lblID.Text = Nothing
                End With

            Case "frmDirectory"
                With frmDirectory
                    .grpDirectory.Enabled = True
                    .lblID.Text = Nothing
                    .txtContact_Name.Text = Nothing
                    .txtContact_No.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .txtTag.Text = Nothing
                    .txtAddress.Text = Nothing
                End With

            Case "frmSchedule"
                With frmSchedule
                    .lstAttachment.Items.Clear()
                    .grpSchedule.Enabled = True
                    .ID.Text = Nothing
                    .txtProgram.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .txtAddress.Text = Nothing
                    .txtNote.Text = Nothing

                End With
        End Select
    End Sub

    Public Sub Proc_Textbox_Save(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .txtEquipment.Enabled = False
                    .txtEquipment_desciption.Enabled = False

                End With

                'Case "frmRecepient"
                '    With frmRecepient
                '        .txtRecepient_name.Enabled = False
                '        .txtRecepient_designation.Enabled = False
                '        .txtrecepient_address.Enabled = False
                '        .txtrecepient_Contantno.Enabled = False

                '    End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .grpEquipmentRequest.Enabled = False

                    '.txtRecepient_name.Text = Nothing
                    '.txtRecepient_Address.Text = Nothing
                    '.txtRecepient_contactno.Text = Nothing
                    '.txtRecepient_Designation.Text = Nothing

                    '.dtApproved.Enabled = False
                    '.lbladdress_ID.Text = Nothing
                    '.lblID.Text = Nothing
                    '.lblRecepient_id.Text = Nothing
                End With

            Case "frmAddress"
                With frmAddress
                    '.lblID.Text = Nothing
                    '.txtProvince.Text = Nothing
                    '.txtMunicipality.Text = Nothing
                    '.txtxBarangay.Text = Nothing

                    .txtMunicipality.Enabled = False
                    .txtProvince.Enabled = False
                    .txtBarangay.Enabled = False
                    '.txtOrganization.Text = Nothing
                    .txtOrganization.Enabled = False
                End With

            Case "frmRecepient"
                With frmRecepient
                    '.txtName.Text = Nothing
                    '.txtAddress.Text = Nothing
                    '.txtDesignation.Text = Nothing
                    '.txtContact.Text = Nothing

                    .txtName.Enabled = False
                    .txtAddress.Enabled = False
                    .txtDesignation.Enabled = False
                    .txtContact.Enabled = False

                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    .grpInfra.Enabled = False

                    '.txtAddress.Text = Nothing
                    '.txtRecepient_name.Text = Nothing
                    '.txtRecepient_Address.Text = Nothing
                    '.txtRecepient_contactno.Text = Nothing
                    '.txtRecepient_Designation.Text = Nothing

                    '.chkApproved.Checked = False
                    '.txtProposal.Text = Nothing
                    '.txtNote.Text = Nothing

                    '.lblID.Text = Nothing
                    '.lblRecepient_id.Text = Nothing
                    '.lbladdress_id.Text = Nothing

                End With
            Case "frmDocumentManager"
                With frmDocumentManager
                    .grpDocManager.Enabled = False

                    '.txtDocumentType.Text = Nothing
                    '.txtDescription.Text = Nothing
                    '.txtRecepient.Text = Nothing
                    '.txtAgency.Text = Nothing
                    '.dtDate.Value = Now
                    '.txtMunicipality.Text = Nothing
                    '.txtNote.Text = Nothing

                    '.lblID.Text = Nothing
                    '.lstAttachment.Items.Clear()

                End With

            Case "frmAssistance"
                With frmAssistance
                    .GrpAssistance.Enabled = False

                End With

            Case "frmDocumentType"
                With frmDocumentType

                    .txtDocumentType.Enabled = False

                End With
            Case "frmAssistanceType"
                With frmAssistanceType

                    .txtAssistanceType.Enabled = False

                End With

            Case "frmDirectory"
                With frmDirectory
                    .grpDirectory.Enabled = False
  
                End With

            Case "frmSchedule"
                With frmSchedule
                    .grpSchedule.Enabled = False
       

                End With
        End Select
    End Sub
    Public Sub Proc_Textbox_Delete(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .txtEquipment.Enabled = False
                    .txtEquipment_desciption.Enabled = False

                    .txtEquipment.Text = Nothing
                    .txtEquipment_desciption.Text = Nothing
                    .lblID.Text = Nothing
                End With

                'Case "frmRecepient"
                '    With frmRecepient
                '        .txtRecepient_name.Enabled = False
                '        .txtRecepient_designation.Enabled = False
                '        .txtrecepient_address.Enabled = False
                '        .txtrecepient_Contantno.Enabled = False
                '        .txtRecepient_name.Text = Nothing
                '        .txtRecepient_designation.Text = Nothing
                '        .txtrecepient_address.Text = Nothing
                '        .txtrecepient_Contantno.Text = Nothing
                '        .lblID.Text = Nothing
                '    End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .grpEquipmentRequest.Enabled = False
                    .txtOrganization.Text = Nothing
                    .txtRecepient_name.Text = Nothing
                    .txtRecepient_Address.Text = Nothing
                    .txtRecepient_contactno.Text = Nothing
                    .txtRecepient_Designation.Text = Nothing
                    .txtNote.Text = Nothing
                    .txtAddress.Text = Nothing
                    .dtApproved.Enabled = False
                    .lbladdress_ID.Text = Nothing
                    .lblID.Text = Nothing
                    .lblRecepient_id.Text = Nothing
                    .lstEquipment_Input.Items.Clear()
                    .lstAttachment.Items.Clear()
                    .chkApproved.Checked = False
                End With

            Case "frmAddress"
                With frmAddress
                    .lblID.Text = Nothing
                    .txtProvince.Text = Nothing
                    .txtMunicipality.Text = Nothing
                    .txtBarangay.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .txtOrganization.Enabled = False
                    .txtMunicipality.Enabled = False
                    .txtProvince.Enabled = False
                    .txtBarangay.Enabled = False

                End With

            Case "frmRecepient"
                With frmRecepient
                    .txtName.Text = Nothing
                    .txtAddress.Text = Nothing
                    .txtDesignation.Text = Nothing
                    .txtContact.Text = Nothing
                    .lblID.Text = Nothing

                    .txtName.Enabled = False
                    .txtAddress.Enabled = False
                    .txtDesignation.Enabled = False
                    .txtContact.Enabled = False

                End With
            Case "frmInfrastructure"
                With frmInfrastructure
                    .grpInfra.Enabled = False

                    .txtAddress.Text = Nothing
                    .txtRecepient_name.Text = Nothing
                    .txtRecepient_Address.Text = Nothing
                    .txtRecepient_contactno.Text = Nothing
                    .txtRecepient_Designation.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .chkApproved.Checked = False
                    .txtProposal.Text = Nothing
                    .txtNote.Text = Nothing

                    .lblID.Text = Nothing
                    .lblRecepient_id.Text = Nothing
                    .lbladdress_id.Text = Nothing
                    .txtamount.Text = 0.0
                    .lstAttachment.Items.Clear()
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    .grpDocManager.Enabled = False
                    .lblDocumentTYPEID.Text = Nothing
                    '.txtDocumentType.Text = Nothing
                    '.txtDescription.Text = Nothing
                    .txtRecepient.Text = Nothing
                    .txtAgency.Text = Nothing
                    .dtDate.Value = Now
                    .txtMunicipality.Text = Nothing
                    .txtNote.Text = Nothing
                    '.txtNote.Enabled = False
                    .lblID.Text = Nothing
                    .lstAttachment.Items.Clear()

                End With

            Case "frmAssistance"
                With frmAssistance
                    .GrpAssistance.Enabled = False

                    '.txtAssistance_description.Text = Nothing
                    .txtRecepientName.Text = Nothing
                    .txtRecepientAddress.Text = Nothing
                    .txtClaimantAddress.Text = Nothing
                    .txtClaimantName.Text = Nothing
                    .txtAmount.Text = 0
                    .txtRemark.Text = Nothing
                    .chkApproved.Checked = False
                    .chkReleased.Checked = False
                    .dtApproved.Enabled = False
                    .dtReleased.Enabled = False

                    .lblID.Text = Nothing
                    .lblAssistance_ID.Text = Nothing
                    '.lblRecepient_ID.Text = Nothing
                    '.lblClaimant.Text = Nothing
                    .lstAttachment.Items.Clear()

                End With

            Case "frmDocumentType"
                With frmDocumentType
                    .txtDocumentType.Text = Nothing
                    .txtDocumentType.Enabled = False
                    .lblID.Text = Nothing
                End With
            Case "frmAssistanceType"
                With frmAssistanceType
                    .txtAssistanceType.Text = Nothing
                    .txtAssistanceType.Enabled = False
                    .lblID.Text = Nothing
                End With

            Case "frmDirectory"
                With frmDirectory
                    .grpDirectory.Enabled = False
                    .txtContact_Name.Text = Nothing
                    .txtContact_No.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .txtTag.Text = Nothing
                    .txtAddress.Text = Nothing
                    .lblID.Text = Nothing
                    .lstDirectory.Items.Clear()
                End With

            Case "frmSchedule"
                With frmSchedule
                    .lstAttachment.Items.Clear()
                    .grpSchedule.Enabled = False
                    .ID.Text = Nothing
                    .txtProgram.Text = Nothing
                    .txtOrganization.Text = Nothing
                    .txtAddress.Text = Nothing
                    .txtNote.Text = Nothing

                End With
        End Select
    End Sub
    Public Sub Proc_Textbox_Edit(ByVal Formname As String)

        Select Case Formname

            Case "frmEquipment"
                With frmEquipment
                    .txtEquipment.Enabled = True
                    .txtEquipment_desciption.Enabled = True

                End With

                'Case "frmRecepient"
                '    With frmRecepient
                '        .txtRecepient_name.Enabled = True
                '        .txtRecepient_designation.Enabled = True
                '        .txtrecepient_address.Enabled = True
                '        .txtrecepient_Contantno.Enabled = True

                '    End With
            Case "frmRequest_Equipment_Input"
                With frmRequest_Equipment_Input
                    .txtNote.Enabled = True
                    .txtRequest_Delivered.Enabled = True
                    .txtRequest_Quantity.Enabled = True
                    .txtName.Enabled = True
                    .txtDesignation.Enabled = True
                    .txtName.Enabled = False
                    .txtDesignation.Enabled = False
                    '.txtEquipment_Name.Text = Nothing
                    '.txtEquipment_Description.Text = Nothing
                    '.txtRequest_Delivered.Text = Nothing
                    '.txtRequest_Quantity.Text = Nothing
                    '.txtNote.Text = Nothing
                End With

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    .grpEquipmentRequest.Enabled = True

                    '.txtRecepient_name.Text = Nothing
                    '.txtRecepient_Address.Text = Nothing
                    '.txtRecepient_contactno.Text = Nothing
                    '.txtRecepient_Designation.Text = Nothing

                    '.dtApproved.Enabled = 
                    '.lbladdress_ID.Text = Nothing
                    '.lblID.Text = Nothing
                    '.lblRecepient_id.Text = Nothing
                End With

            Case "frmAddress"
                With frmAddress
                    '.lblID.Text = Nothing
                    '.txtProvince.Text = Nothing
                    '.txtMunicipality.Text = Nothing
                    '.txtxBarangay.Text = Nothing

                    .txtMunicipality.Enabled = True
                    .txtProvince.Enabled = True
                    .txtBarangay.Enabled = True
                    .txtOrganization.Enabled = True

                End With

            Case "frmRecepient"
                With frmRecepient
                    '.txtName.Text = Nothing
                    '.txtAddress.Text = Nothing
                    '.txtDesignation.Text = Nothing
                    '.txtContact.Text = Nothing

                    .txtName.Enabled = True
                    .txtAddress.Enabled = True
                    .txtDesignation.Enabled = True
                    .txtContact.Enabled = True

                End With
            Case "frmInfrastructure"
                With frmInfrastructure
                    .grpInfra.Enabled = True

                    '.txtAddress.Text = Nothing
                    '.txtRecepient_name.Text = Nothing
                    '.txtRecepient_Address.Text = Nothing
                    '.txtRecepient_contactno.Text = Nothing
                    '.txtRecepient_Designation.Text = Nothing

                    '.chkApproved.Checked = False
                    '.txtProposal.Text = Nothing
                    '.txtNote.Text = Nothing

                    '.lblID.Text = Nothing
                    '.lblRecepient_id.Text = Nothing
                    '.lbladdress_id.Text = Nothing

                End With
            Case "frmDocumentManager"
                With frmDocumentManager
                    .grpDocManager.Enabled = True

                    '.txtDocumentType.Text = Nothing
                    '.txtDescription.Text = Nothing
                    '.txtRecepient.Text = Nothing
                    '.txtAgency.Text = Nothing
                    '.dtDate.Value = Now
                    '.txtMunicipality.Text = Nothing
                    '.txtNote.Text = Nothing

                    '.lblID.Text = Nothing
                    '.lstAttachment.Items.Clear()

                End With

            Case "frmAssistance"
                With frmAssistance
                    .GrpAssistance.Enabled = True

                    '.txtAssistance_description.Text = Nothing
                    '.txtRecepientName.Text = Nothing
                    '.txtRecepientAddress.Text = Nothing
                    '.txtClaimantAddress.Text = Nothing
                    '.txtClaimantName.Text = Nothing
                    '.txtAmount.Text = 0
                    '.txtRemark.Text = Nothing

                    '.lblAssistance_ID.Text = Nothing
                    '.lblRecepient_ID.Text = Nothing
                    '.lblClaimant.Text = Nothing
                    '.lstAttachment.Items.Clear()


                End With
            Case "frmDocumentType"
                With frmDocumentType

                    .txtDocumentType.Enabled = True

                End With

            Case "frmAssistanceType"
                With frmAssistanceType

                    .txtAssistanceType.Enabled = True

                End With

            Case "frmDirectory"
                With frmDirectory
                    .grpDirectory.Enabled = True
                End With

            Case "frmSchedule"
                With frmSchedule
                    .grpSchedule.Enabled = True
    

                End With
        End Select
    End Sub
End Module
