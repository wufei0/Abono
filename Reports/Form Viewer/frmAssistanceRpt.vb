''Imports CrystalDecisions.Shared
''Imports CrystalDecisions.CrystalReports.Engine
'Imports System.Data.Odbc
'Public Class frmAssistanceRpt

'    Private Sub frmAssistanceRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'        Dim SQLString As String = "SELECT ASSISTANCE.CLAIMANT_NAME, ASSISTANCE.APPROVED_BV, ASSISTANCE.RELEASED_BV, ASSISTANCE.AMOUNT, ASSISTANCE.CLAIMANT_ADDRESS, ASSISTANCE_TYPE.DESCRIPTION FROM   ASSISTANCE ASSISTANCE INNER JOIN ASSISTANCE_TYPE ASSISTANCE_TYPE ON ASSISTANCE.ASSISTANCE_TYPE_ID=ASSISTANCE_TYPE.ASSISTANCE_TYPE_ID ORDER BY ASSISTANCE_TYPE.DESCRIPTION"
'        '"SELECT * FROM  ASSISTANCE INNER JOIN ASSISTANCE_TYPE ON ASSISTANCE.ASSISTANCE_TYPE_ID=ASSISTANCE_TYPE.ASSISTANCE_TYPE_ID ORDER BY ASSISTANCE_TYPE.DESCRIPTION"




'        Dim FBCommand As New OdbcCommand
'        Dim FBAdapter As New OdbcDataAdapter
'        Dim dtTable As New DataTable

'        Try
'            Call FBirdConnectionOpen()
'            FBCommand.Connection = FBirdConnection
'            FBCommand.CommandText = SQLString

'            FBAdapter.SelectCommand = FBCommand
'            FBAdapter.Fill(dtTable)
'            Dim crystal As New Assistance

'            'crystal.Parameter_Financial_Year. = "2013"
'            crystal.SetDataSource(dtTable)
'            CrystalReportViewer1.ReportSource = crystal
'            CrystalReportViewer1.Refresh()

'            FBirdConnection.Close()

'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try


'        'Me.ReportViewer1.RefreshReport()
'        'CrystalReportViewer1.ReportSource = rptass
'    End Sub
'End Class