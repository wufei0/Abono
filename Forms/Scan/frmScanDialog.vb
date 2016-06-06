Public Class frmScanDialog
    Public FormSource As String
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim lviTEM As ListViewItem


        If txtPath.Text = "" Then
            Beep()
            Exit Sub
        End If
        Select Case FormSource

            Case "frmRequest_Equipment"
                With frmRequest_Equipment
                    lviTEM = New ListViewItem(lblID.Text)
                    lviTEM.SubItems.Add(txtPath.Text)
                    lviTEM.SubItems.Add(txtFilename.Text)
                    lviTEM.SubItems.Add(txtNote.Text.ToUpper)
                    .lstAttachment.Items.Add(lviTEM)
                End With

            Case "frmInfrastructure"
                With frmInfrastructure
                    lviTEM = New ListViewItem(lblID.Text)
                    lviTEM.SubItems.Add(txtPath.Text)
                    lviTEM.SubItems.Add(txtFilename.Text)
                    lviTEM.SubItems.Add(txtNote.Text.ToUpper)
                    .lstAttachment.Items.Add(lviTEM)
                End With

            Case "frmAssistance"
                With frmAssistance
                    lviTEM = New ListViewItem(lblID.Text)
                    lviTEM.SubItems.Add(txtPath.Text)
                    lviTEM.SubItems.Add(txtFilename.Text)
                    lviTEM.SubItems.Add(txtNote.Text.ToUpper)
                    .lstAttachment.Items.Add(lviTEM)
                End With

            Case "frmDocumentManager"
                With frmDocumentManager
                    lviTEM = New ListViewItem(lblID.Text)
                    lviTEM.SubItems.Add(txtPath.Text)
                    lviTEM.SubItems.Add(txtFilename.Text)
                    lviTEM.SubItems.Add(txtNote.Text.ToUpper)
                    .lstAttachment.Items.Add(lviTEM)
                End With

        End Select

        Me.Close()


    End Sub

    Private Sub frmScanDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPath.Text = ""
        txtNote.Text = ""
        lblID.Text = ""
        txtFilename.Text = ""
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        Dim ofdAttachment As New OpenFileDialog()
        ofdAttachment.InitialDirectory = "Desktop"
        ofdAttachment.Filter = "pdf file (*.pdf)|*.pdf"
        ofdAttachment.FilterIndex = 1
        ofdAttachment.RestoreDirectory = True
        ofdAttachment.ShowDialog()

        If ofdAttachment.FileName <> "" Then

            lblID.Text = GuidGenerator("ATH", Me.Name)
            txtPath.Text = ofdAttachment.FileName.ToString
            txtFilename.Text = ofdAttachment.SafeFileName.ToString

        End If

    End Sub
End Class