<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="XtraReportProgress._Default" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style type="text/css">
		#form1
		{
			height: 122px;
			width: 888px;
		}
	</style>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxProgressBar ID="ASPxProgressBar1" runat="server" Height="21px" Position="50"
			Width="200px"  ClientInstanceName="ASPxProgressBar1">
		</dx:ASPxProgressBar>
	</div>
	<dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Height="88px" Width="791px"
		ClientInstanceName="ASPxCallbackPanel1" OnCallback="ASPxCallbackPanel1_Callback">
		<PanelCollection>
			<dx:PanelContent runat="server">
				<asp:Panel ID="Panel1" runat="server" Visible="False">
					<dx:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%#ReportViewer1%>"
						ShowDefaultButtons="False">
						<Items>
							<dx:ReportToolbarButton ItemKind="Search" />
							<dx:ReportToolbarSeparator />
							<dx:ReportToolbarButton ItemKind="PrintReport" />
							<dx:ReportToolbarButton ItemKind="PrintPage" />
							<dx:ReportToolbarSeparator />
							<dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
							<dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
							<dx:ReportToolbarLabel ItemKind="PageLabel" />
							<dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
							</dx:ReportToolbarComboBox>
							<dx:ReportToolbarLabel ItemKind="OfLabel" />
							<dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
							<dx:ReportToolbarButton ItemKind="NextPage" />
							<dx:ReportToolbarButton ItemKind="LastPage" />
							<dx:ReportToolbarSeparator />
							<dx:ReportToolbarButton ItemKind="SaveToDisk" />
							<dx:ReportToolbarButton ItemKind="SaveToWindow" />
							<dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
								<Elements>
									<dx:ListElement Value="pdf" />
									<dx:ListElement Value="xls" />
									<dx:ListElement Value="xlsx" />
									<dx:ListElement Value="rtf" />
									<dx:ListElement Value="mht" />
									<dx:ListElement Value="html" />
									<dx:ListElement Value="txt" />
									<dx:ListElement Value="csv" />
									<dx:ListElement Value="png" />
								</Elements>
							</dx:ReportToolbarComboBox>
						</Items>
						<Styles>
							<LabelStyle>
								<Margins MarginLeft="3px" MarginRight="3px" />
							</LabelStyle>
						</Styles>
						<ClientSideEvents ItemClick="function(o, e) { StartProgress(); }"/>
					</dx:ReportToolbar>
					<dx:ReportViewer ID="ReportViewer1" runat="server" >
					</dx:ReportViewer>
				</asp:Panel>
			</dx:PanelContent>
		</PanelCollection>
	</dx:ASPxCallbackPanel>
	</form>

	<script type="text/javascript">
		function OnLoad() {
			ASPxCallbackPanel1.PerformCallback();
			StartProgress();
		}
		function StartProgress() {
			ASPxProgressBar1.SetPosition(0);
			new ProggressUpdater().Start(UpdateProgress);
		}
		function UpdateProgress(maximum, position) {
			ASPxProgressBar1.maximum = maximum;
			ASPxProgressBar1.SetPosition(position);
		} 
		_aspxAttachEventToElement(window, "load", OnLoad);

		function ProggressUpdater() {
			this.progressWaiting = false;
			this.timerId = null;
			this.isComplete = true;
			this.updateProgress = null;

			this.Start = function(updateProgressFunc) {
				window.ProggressUpdaterInstance = this;
				this.maximum = 100;
				this.position = 0;
				this.isComplete = false;
				this.timerId = window.setInterval("ContinueProgress()", 500);
				this.updateProgress = updateProgressFunc;
			};

			this.End = function() {
				if(this.timerId != null && this.timerId > -1)
					window.clearInterval(this.timerId);
			};

			this.ContinueProgress = function() {
				if (this.progressWaiting) {
					return;
				}
				this.progressWaiting = true;

				var xmlHttp = this.CreateXmlHttpRequestObject();
				if (xmlHttp == null) {
					this.isProgressWaiting = false;
					this.End();
					return;
				}

				if (!this.isComplete) {
					var url = window.location.protocol + "//" + window.location.host + "/" + "ProgressHandler.ashx";
					xmlHttp.open('GET', url, false);
					xmlHttp.send('');

					if (xmlHttp.status == 200) {
						this.UpdateInfo(xmlHttp.responseXML);
						if (this.updateProgress != null)
							this.updateProgress(this.maximum, this.position);
						if (this.isComplete)
							this.End();
					}
				}

				this.progressWaiting = false;
			};

			this.UpdateInfo = function(xml) {
				this.maximum = parseInt(xml.childNodes[0].attributes[0].value);
				this.position = parseInt(xml.childNodes[0].attributes[1].value);
				this.isComplete = (this.maximum <= this.position);
			};

			this.CreateXmlHttpRequestObject = function() {
				if (typeof (XMLHttpRequest) != 'undefined')
					return new XMLHttpRequest();
				else if (typeof (ActiveXObject) != 'undefined')
					return new ActiveXObject('Microsoft.XMLHTTP');
				return null;
			};
		}
		function ContinueProgress() {
			window.ProggressUpdaterInstance.ContinueProgress();
		}
	</script>

</body>
</html>