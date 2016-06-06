Imports System.Data.Odbc
Imports System.IO
Imports Microsoft.VisualBasic.Strings


Module modDeclarations

    Public FBirdConnection As OdbcConnection
    Public FBcommand As New OdbcCommand
    Public FBRecordset As OdbcDataReader
    Public FBTransaction As OdbcTransaction

    Public SysUserName As String
    Public SysPassword As String

    Public FBsql As String
    ''FOR DEVELOPENT
    Public FirebirdIP As String
    Public FirebirdDbase As String
    Public FirebirdDbasePassword As String

    ''FOR IMPLEMENTATION
    'Public FirebirdDbase As String = "ABONO-INFO:abono"

    'Dim DBConstring As String = "Driver=Firebird/InterBase(r) driver;Uid=sysdba; Pwd=masterkey; FirebirdDbase=" & FirebirdDbase & "; "
    Dim DBConstring As String

    Public Sub FirebirdConnect()
        Dim ConfCategory As String
        Try

            'VIEW CONFIG.INF TO VIEW DATABASE CONFIG
            Dim COnfReader As StreamReader = New StreamReader(My.Application.Info.DirectoryPath & " \config.inf")
            ConfCategory = COnfReader.ReadLine()
            Do

                If InStr(ConfCategory.ToUpper, "IP") Then    'SEARCH FOR IP KEYWORD
                    FirebirdIP = Microsoft.VisualBasic.Right(ConfCategory, Microsoft.VisualBasic.Len(ConfCategory) - InStr(ConfCategory, "'"))
                    FirebirdIP = Microsoft.VisualBasic.Left(FirebirdIP, Microsoft.VisualBasic.Len(FirebirdIP) - 1)
                    'txtIP.Text = FirebirdIP
                ElseIf InStr(ConfCategory.ToUpper, "DBNAME") Then   'SEARCH FOR FirebirdDbase KEYWORD
                    FirebirdDbase = Microsoft.VisualBasic.Right(ConfCategory, Microsoft.VisualBasic.Len(ConfCategory) - InStr(ConfCategory, "'"))
                    FirebirdDbase = Microsoft.VisualBasic.Left(FirebirdDbase, Microsoft.VisualBasic.Len(FirebirdDbase) - 1)
                    'txtFirebirdDbase.Text = FirebirdDbase

                    'ElseIf InStr(ConfCategory.ToUpper, "PASSWORD") Then   'SEARCH FOR PASSWORD KEYWORD
                    '    FirebirdDbasePassword = Microsoft.VisualBasic.Right(ConfCategory, Microsoft.VisualBasic.Len(ConfCategory) - InStr(ConfCategory, "'"))
                    '    FirebirdDbasePassword = Microsoft.VisualBasic.Left(FirebirdDbasePassword, Microsoft.VisualBasic.Len(FirebirdDbasePassword) - 1)
                    '    FirebirdDbasePassword = AES_Decrypt(FirebirdDbasePassword, "PaSSw0Rd")
                    '    'txtFirebirdDbasePasswordWORD.Text = AES_Decrypt(FirebirdDbasePassword, "PaSSw0Rd")
                End If
                ConfCategory = COnfReader.ReadLine()
            Loop Until ConfCategory Is Nothing
            COnfReader.Close()

            DBConstring = "Driver=Firebird/InterBase(r) driver;Uid=sysdba; Pwd=masterkey; Dbname=" & FirebirdIP & ":" & FirebirdDbase & "; "
            'DBConstring = "Driver=Firebird/InterBase(r) driver;Uid=sysdba; Pwd=masterkey; FirebirdDbase=" & FirebirdDbase & "; "
            FBirdConnection = New OdbcConnection(DBConstring)
            FBirdConnection.Open()

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & "Cannot Connect to Firebird Server. Consult your Database Admin.", vbCritical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            End

        End Try

        FBirdConnection.Close()
    End Sub

    Public Function FBUserConnect(ByVal UserName As String, ByVal Password As String) As Boolean

        Try
            DBConstring = "Driver=Firebird/InterBase(r) driver;Uid=" & UserName.ToUpper & "; Pwd=" & Password & "; Dbname=" & FirebirdIP & ":" & FirebirdDbase & "; "
            FBirdConnection = New OdbcConnection(DBConstring)
            FBirdConnection.Open()
        Catch ex As Exception

            FBirdConnection.Close()
            FBUserConnect = False
            Return FBUserConnect
        Finally
            FBirdConnection.Close()
        End Try


        FBUserConnect = True
    End Function

    Public Sub FBirdConnectionOpen()
        Try
            DBConstring = "Driver=Firebird/InterBase(r) driver;Uid=" & SysUserName.ToUpper & "; Pwd=" & SysPassword & "; Dbname=" & FirebirdIP & ":" & FirebirdDbase & "; "
            FBirdConnection = New OdbcConnection(DBConstring)
            FBirdConnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & vbNewLine & "Cannot Connect to Firebird Server. Consult your Database Admin.", vbCritical, My.Application.Info.Title.ToString)
            FBirdConnection.Close()
            'FBUserConnect = False
            'Return FBUserConnect()
        End Try
    End Sub

End Module
