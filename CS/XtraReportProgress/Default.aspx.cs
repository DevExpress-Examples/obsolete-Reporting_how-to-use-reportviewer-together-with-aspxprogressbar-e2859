using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace XtraReportProgress {
    public partial class _Default : System.Web.UI.Page {
        DevExpress.XtraPrinting.ProgressReflector progressReflector; 
        protected void Page_Load(object sender, EventArgs e) {

            if(this.ReportViewer1 != null)  {
                if(this.ReportViewer1.Loaded) {
                    InitProgress();
                } else {
                    ReportViewer1.Load += new EventHandler(ReportViewer1_Load);
                }
            }
        }

        void ReportViewer1_Load(object sender, EventArgs e) {
            InitProgress();
        }

        void InitProgress() {
            progressReflector = ReportViewer1.Report.PrintingSystem.ProgressReflector;
            progressReflector.PositionChanged += new EventHandler(ProgressReflector_PositionChanged);
            ProgressUpdater.SetProgress(100, 0);
        }

        void ProgressReflector_PositionChanged(object sender, EventArgs e) {
            ProgressUpdater.SetProgress(progressReflector.Maximum, progressReflector.Position);
        }
        
        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e) {
            this.Panel1.Visible = true;
        }
    }
}
