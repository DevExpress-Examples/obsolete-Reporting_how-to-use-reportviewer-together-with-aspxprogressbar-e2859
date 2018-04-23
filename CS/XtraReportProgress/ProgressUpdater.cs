namespace XtraReportProgress {
    public class ProgressUpdater { 
        public static int MaxValue;
        public static int ProgressValue;

        public static void SetProgress(int maxValue, int progressValue) {
            MaxValue = maxValue;
            ProgressValue = progressValue;
        }
    }
}