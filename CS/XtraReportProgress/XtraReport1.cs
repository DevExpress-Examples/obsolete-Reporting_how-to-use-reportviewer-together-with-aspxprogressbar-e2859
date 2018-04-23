using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace XtraReportProgress {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public class DataItem {
            int _id;
            int _value;

            public int ID { get { return _id; } set { _id = value; } }
            public int Value { get { return _value; } set { _value = value; } }
        }
        
        public XtraReport1() {
            InitializeComponent();
            DataSource = GetUnboundList();
            CreateDataBindings();
        }
        ArrayList GetUnboundList() {
            ArrayList dataList = new ArrayList();
            Random random = new Random();
            for(int i = 0; i < 10000; i++) {
                DataItem item = new DataItem();
                item.ID = i + 1;
                item.Value = random.Next();
                dataList.Add(item);
            }
            return dataList;
        }
        void CreateDataBindings() {
            xrLabel1.DataBindings.Add("Text", DataSource, "ID");
            xrLabel2.DataBindings.Add("Text", DataSource, "Value");
        }
    }
}
