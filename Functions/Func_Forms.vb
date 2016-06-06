Imports System.Data.Odbc
Imports System.IO

Module Func_Forms

    'AUTO GENERATES GUID FOR PRIMARY KEYS
    Function GuidGenerator(ByVal GuidPrefix As String, ByVal FormName As String) As String     'CREATES GUID FOR PRIMARY KEYS
        GuidGenerator = ""
        'Dim FirebirdRec As OdbcDataReader
        Dim FirebirdCom As New OdbcCommand

        Using FirebirdCom
            Try
                Call FBirdConnectionOpen()
                FirebirdCom.Connection = FBirdConnection
                'If FBRecordset.IsClosed = False Then FBRecordset.Close()
                Select Case FormName
                    Case "frmRecepient"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_RECEPIENT_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar


                    Case "frmEquipment"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_EQUIPMENT_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar


                    Case "frmRequest_Equipment"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_EQUIPMENT_REQUEST_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmAddress"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_ADDRESS_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmInfrastructure"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_INFRA_REQUEST_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmScanDialog"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_ATTACHMENT_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmAssistance"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_ASSISTANCE_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmDocumentManager"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_DOCUMENT_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmDocumentType"
                        With frmDocumentType
                            GuidGenerator = GuidPrefix
                            FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_DOCUMENT_TYPE_ID FROM RDB$DATABASE"
                            GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar
                        End With

                    Case "frmAssistanceType"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_ASSISTANCE_TYPE_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar


                    Case "frmDirectory"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_CONTACT_DIRECTORY_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar

                    Case "frmSchedule"
                        GuidGenerator = GuidPrefix
                        FirebirdCom.CommandText = "SELECT NEXT VALUE FOR GEN_SCHEDULER_ID FROM RDB$DATABASE"
                        GuidGenerator = GuidGenerator & ":" & FirebirdCom.ExecuteScalar
                End Select



                FBirdConnection.Close()
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & vbNewLine & FirebirdCom.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
                FBirdConnection.Close()
            Finally
                FirebirdCom.Dispose()
            End Try

        End Using

        'Dim xGUID As String = System.Guid.NewGuid.ToString()

        'GuidGenerator = GuidPrefix & ":" & xGUID

        Return GuidGenerator

    End Function

    Function DuplicateChecker(ByVal ListViewControl_Destination As ListView, ByVal SelectedItem As String) As Boolean 'CHECKS DUPLICATE ITEMS ON LISTVIEW

        For Each lstitem_lstPrevTD As ListViewItem In ListViewControl_Destination.Items
            If SelectedItem = lstitem_lstPrevTD.Text Then
                'MsgBox("Tax Declaration already exist on the list.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                DuplicateChecker = True
                Exit Function
            End If
        Next
        DuplicateChecker = False
    End Function

    Public Sub Delete_Temp(ByVal Filepath As String)
        'For countX = 0 To 100
        '    directory = directory & countX & ".pdf"

        If System.IO.File.Exists(Filepath) = True Then
            System.IO.File.Delete(Filepath)
        End If

        'Next
    End Sub

    Public Function DuplicateIdentifier(ByVal SQLQuery As String) As Boolean
        Dim FbirdCommand As New OdbcCommand
        'Dim FbirdReader As OdbcDataReader
        Dim RowCount As Integer
        'Dim SQLQuery As String


        Try
            Call FBirdConnectionOpen()
            FbirdCommand.Connection = FBirdConnection
            FbirdCommand.CommandText = SQLQuery
            RowCount = FbirdCommand.ExecuteNonQuery

            FBirdConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & FbirdCommand.CommandText, MsgBoxStyle.Critical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
        Finally
            FbirdCommand.Dispose()

        End Try

        If RowCount > 0 Then
            DuplicateIdentifier = True
        Else
            DuplicateIdentifier = False
        End If

        Return DuplicateIdentifier
    End Function

    '' <summary>
    ''' Returns a string describing whether the OS is 32-bit or 64-bit.
    ''' </summary>
    ''' <returns>A String value (e.g. "32-bit").</returns>
    ''' <remarks>If an error occurs, the result will be an empty string.
    ''' <para>Requires a reference to System.Management.</para></remarks>
    Public Function GetOSArchitecture() As String

        ' More Info on WMI available here:
        '
        ' http://msdn.microsoft.com/En-US/library/aa394239.aspx

        Dim osClass As System.Management.ManagementClass = Nothing
        Dim result As String = "32-bit" ' Default to 32-bit for OSes which don't support the OSArchitecture property of the Win32_OperatingSystem WMI class.

        Try

            ' Get the singleton Win32_OperatingSystem WMI class so we can access properties about the OS.
            osClass = New System.Management.ManagementClass("Win32_OperatingSystem")

            ' Loop thru all properties of the single instance of the Win32_OperatingSystem class and look for the property which will tell us if
            ' the OS is 32-bit or 64-bit.  If the property is not found, the OS is assumed to be 32-bit.
            ' NOTE: I'm not 100% sure if this detects 64-bit versions of XP.  See above MSDN link for more information.
            For Each mgo As System.Management.ManagementObject In osClass.GetInstances
                For Each prop As System.Management.PropertyData In mgo.Properties
                    If prop.Name = "OSArchitecture" Then
                        result = prop.Value.ToString
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception

            result = String.Empty

        Finally

            ' Clean up
            If osClass IsNot Nothing Then osClass.Dispose()

        End Try

        Return result

    End Function
End Module
