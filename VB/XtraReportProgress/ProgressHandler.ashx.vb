Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web

Namespace XtraReportProgress
	''' <summary>
	''' Summary description for $codebehindclassname$
	''' </summary>
	Public Class ProgressHandler
		Implements IHttpHandler

		Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
			context.Response.ContentType = "text/xml"
			context.Response.CacheControl = "no-cache"
			context.Response.Write(String.Format("<status maxValue=""{0}"" progressValue=""{1}""/>", ProgressUpdater.MaxValue.ToString(), ProgressUpdater.ProgressValue.ToString()))
		End Sub

		Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
			Get
				Return False
			End Get
		End Property
	End Class
End Namespace
