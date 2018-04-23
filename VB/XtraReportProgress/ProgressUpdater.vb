Imports Microsoft.VisualBasic
Imports System
Namespace XtraReportProgress
	Public Class ProgressUpdater
		Public Shared MaxValue As Integer
		Public Shared ProgressValue As Integer

		Public Shared Sub SetProgress(ByVal maxValue As Integer, ByVal progressValue As Integer)
			ProgressUpdater.MaxValue = maxValue
			ProgressUpdater.ProgressValue = progressValue
		End Sub
	End Class
End Namespace