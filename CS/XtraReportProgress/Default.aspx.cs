using System;
// ...

namespace XtraReportProgress {
    public partial class _Default : System.Web.UI.Page {
        DevExpress.XtraPrinting.ProgressReflector progressReflector;
        protected void Page_Load(object sender, EventArgs e) {
            if (this.ReportViewer1 != null) {
                ReportViewer1.Report = new XtraReport1();
                InitProgress();
            }
        }

        void InitProgress() {
            progressReflector = ReportViewer1.Report.PrintingSystem.ProgressReflector;
            progressReflector.PositionChanged += new EventHandler(ProgressReflector_PositionChanged);
            ProgressUpdater.SetProgress(100, 0);
        }

        void ProgressReflector_PositionChanged(object sender, EventArgs e) {
            ProgressUpdater.SetProgress(progressReflector.Maximum, progressReflector.Position);
        }

        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e) {
            this.Panel1.Visible = true;
        }
    }
}
