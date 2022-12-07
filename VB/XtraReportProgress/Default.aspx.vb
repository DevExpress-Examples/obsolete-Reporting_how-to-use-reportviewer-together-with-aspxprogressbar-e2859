Imports Microsoft.VisualBasic
Imports System
' ...

Namespace XtraReportProgress
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private progressReflector As DevExpress.XtraPrinting.ProgressReflector
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If Me.ReportViewer1 IsNot Nothing Then
				ReportViewer1.Report = New XtraReport1()
				InitProgress()
			End If
		End Sub

		Private Sub InitProgress()
			progressReflector = ReportViewer1.Report.PrintingSystem.ProgressReflector
			AddHandler progressReflector.PositionChanged, AddressOf ProgressReflector_PositionChanged
			ProgressUpdater.SetProgress(100, 0)
		End Sub

		Private Sub ProgressReflector_PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
			ProgressUpdater.SetProgress(progressReflector.Maximum, progressReflector.Position)
		End Sub

		Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
			Me.Panel1.Visible = True
		End Sub
	End Class
End Namespace
