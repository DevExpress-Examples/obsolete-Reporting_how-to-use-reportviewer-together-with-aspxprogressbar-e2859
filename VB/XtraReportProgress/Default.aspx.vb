Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Namespace XtraReportProgress
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private progressReflector As DevExpress.XtraPrinting.ProgressReflector
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

			If Me.ReportViewer1 IsNot Nothing Then
				If Me.ReportViewer1.Loaded Then
					InitProgress()
				Else
					AddHandler ReportViewer1.Load, AddressOf ReportViewer1_Load
				End If
			End If
		End Sub

		Private Sub ReportViewer1_Load(ByVal sender As Object, ByVal e As EventArgs)
			InitProgress()
		End Sub

		Private Sub InitProgress()
			progressReflector = ReportViewer1.Report.PrintingSystem.ProgressReflector
			AddHandler progressReflector.PositionChanged, AddressOf ProgressReflector_PositionChanged
			ProgressUpdater.SetProgress(100, 0)
		End Sub

		Private Sub ProgressReflector_PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
			ProgressUpdater.SetProgress(progressReflector.Maximum, progressReflector.Position)
		End Sub

		Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
			Me.Panel1.Visible = True
		End Sub
	End Class
End Namespace
