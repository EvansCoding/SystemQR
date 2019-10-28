using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace MODULE_UPDATE_INFO
{
    public partial class reportItem : DevExpress.XtraReports.UI.XtraReport
    {
        public reportItem()
        {
            InitializeComponent();
        }

        public void BindList()
        {
            xrLabel1.DataBindings.Add("Text", DataSource, "colTEN");
            xrPictureBox2.DataBindings.Add("Image", DataSource, "colPIC");
            xrPictureBox3.DataBindings.Add("Image", DataSource, "colQR");
        }
    }
}
