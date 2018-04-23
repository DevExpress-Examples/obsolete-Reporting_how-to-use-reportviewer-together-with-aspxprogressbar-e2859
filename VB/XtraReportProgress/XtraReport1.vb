Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace XtraReportProgress
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Class DataItem
			Private _id As Integer
			Private _value As Integer

			Public Property ID() As Integer
				Get
					Return _id
				End Get
				Set(ByVal value As Integer)
					_id = value
				End Set
			End Property
			Public Property Value() As Integer
				Get
					Return _value
				End Get
				Set(ByVal value As Integer)
					_value = value
				End Set
			End Property
		End Class

		Public Sub New()
			InitializeComponent()
			DataSource = GetUnboundList()
			CreateDataBindings()
		End Sub
		Private Function GetUnboundList() As ArrayList
			Dim dataList As New ArrayList()
			Dim random As New Random()
			For i As Integer = 0 To 9999
				Dim item As New DataItem()
				item.ID = i + 1
				item.Value = random.Next()
				dataList.Add(item)
			Next i
			Return dataList
		End Function
		Private Sub CreateDataBindings()
			xrLabel1.DataBindings.Add("Text", DataSource, "ID")
			xrLabel2.DataBindings.Add("Text", DataSource, "Value")
		End Sub
	End Class
End Namespace
