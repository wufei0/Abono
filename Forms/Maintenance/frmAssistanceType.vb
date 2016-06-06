Imports System.Data.Odbc

Public Class frmAssistanceType

    Private Sub frmAssistanceType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiAbono
        Call Proc_Button_Delete(Me.Name)
        Call Proc_Textbox_Delete(Me.Name)
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM ASSISTANCE_TYPE ORDER BY DESCRIPTION")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call Proc_listview_Refresh(Me.Name, "SELECT * FROM ASSISTANCE_TYPE WHERE DESCRIPTION LIKE '%" & txtSearch.Text & "%' ORDER BY DESCRIPTION")
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM ASSISTANCE_TYPE WHERE DESCRIPTION LIKE '%" & txtSearch.Text & "%' ORDER BY DESCRIPTION")
        End If
    End Sub



    Private Sub lstAssistance_type_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAssistance_type.DoubleClick
        Dim FbirdCommand As New OdbcCommand
        Dim FbirdReader As OdbcDataReader
        Try
            Call FBirdConnectionOpen()
            lblID.Text = lstAssistance_type.SelectedItems(0).SubItems(0).Text
            FbirdCommand.Connection = FBirdConnection
            FBsql = "SELECT * FROM ASSISTANCE_TYPE WHERE ASSISTANCE_TYPE_ID = '" & lstAssistance_type.SelectedItems(0).SubItems(0).Text & "' "
            FbirdCommand.CommandText = FBsql
            FbirdReader = FbirdCommand.ExecuteReader
            FbirdReader.Read()
            lblID.Text = lstAssistance_type.SelectedItems(0).SubItems(0).Text
            txtAssistanceType.Text = FbirdReader!DESCRIPTION.ToString
            FBirdConnection.Close()
        Catch ex As Exception
            FBirdConnection.Close()
        Finally
            Try
                FbirdReader.Close()
            Catch ex1 As Exception

            End Try
        End Try

        'lblID.Text = lstDocument_type.SelectedItems(0).SubItems(0).Text
        'txtDocumentType.Text = lstDocument_type.SelectedItems(0).SubItems(1).Text
        Proc_Button_Edit(Me.Name)
        Proc_Textbox_Edit(Me.Name)
    End Sub

    Private Sub lstAssistance_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAssistance_type.SelectedIndexChanged

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Proc_Button_New(Me.Name)
        Call Proc_Textbox_New(Me.Name)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FbirdCommand As New OdbcCommand
        Dim GuidText As String

        If txtAssistanceType.Text = Nothing Then
            Beep()
            Exit Sub
        End If

        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection

            If lblID.Text = "" Then
                GuidText = GuidGenerator("ATP", Me.Name)
                FBsql = "INSERT INTO ASSISTANCE_TYPE(ASSISTANCE_TYPE_ID, DESCRIPTION,SECURITY_USER) VALUES ('" & GuidText & "','" & txtAssistanceType.Text.ToUpper & "','" & MdiAbono.TSUserName.Text & "') "
                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()
                lblID.Text = GuidText
            Else
                FBsql = "UPDATE ASSISTANCE_TYPE SET DESCRIPTION = '" & txtAssistanceType.Text.ToUpper & "', SECURITY_USER = '" & MdiAbono.TSUserName.Text & "' WHERE ASSISTANCE_TYPE_ID = '" & lblID.Text & "' "
                FbirdCommand.CommandText = FBsql
                FbirdCommand.ExecuteNonQuery()

            End If

            MsgBox("Assistance Type successfuly saved", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            Proc_Button_Save(Me.Name)
            Proc_Textbox_Save(Me.Name)

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim FbirdCommand As New OdbcCommand
        If MsgBox("Confirm to Delete '" & txtAssistanceType.Text.ToUpper & "'.", vbOKCancel + vbQuestion, My.Application.Info.Title.ToString) = vbCancel Then
            Exit Sub

        End If

        Try
            Call FBirdConnectionOpen()
            FBsql = "DELETE FROM ASSISTANCE_TYPE WHERE ASSISTANCE_TYPE_ID = '" & lblID.Text & "'"
            FbirdCommand.Connection = FBirdConnection
            FbirdCommand.CommandText = FBsql
            FbirdCommand.ExecuteNonQuery()
            MsgBox(txtAssistanceType.Text.ToUpper & " deleted.", vbInformation, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            Proc_Button_Delete(Me.Name)
            Proc_Textbox_Delete(Me.Name)
            Call Proc_listview_Refresh(Me.Name, "SELECT * FROM ASSISTANCE_TYPE ORDER BY DESCRIPTION ASC")
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

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class