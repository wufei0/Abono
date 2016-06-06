Public Class frmPDFviewer

    Private Sub frmPDFviewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiAbono
        'pdfReader.ShowPropertyPages()
        'pdfReader.setShowScrollbars(True)
        'pdfReader.setShowToolbar(True)
        'pdfReader.Show()


    End Sub

    Private Sub frmPDFviewer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize


        pdfReader.Height = Me.Height - 85
        btnClose.Left = Me.Width - 110
        btnClose.Top = Me.Height - 70

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

  
End Class