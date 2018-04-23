using System;
using System.Collections.Generic;
using System.Web;

namespace XtraReportProgress {
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class ProgressHandler : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/xml";
            context.Response.CacheControl = "no-cache";
            context.Response.Write(
                string.Format("<status maxValue=\"{0}\" progressValue=\"{1}\"/>", 
                    ProgressUpdater.MaxValue.ToString(), 
                    ProgressUpdater.ProgressValue.ToString()
                )
            );
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
