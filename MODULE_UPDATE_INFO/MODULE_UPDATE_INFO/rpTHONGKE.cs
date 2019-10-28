using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MODULE_UPDATE_INFO
{
    public partial class rpTHONGKE : DevExpress.XtraReports.UI.XtraReport
    {
        public rpTHONGKE()
        {
            InitializeComponent();
        }

        public void load(string tong, string coMat, string vangMat, string nam, string ptNam, string nu, string ptNu)
        {
            xrTong.Text = tong;
            xrCo.Text = coMat;
            xrVang.Text = vangMat;
            xrNam.Text = nam;
            xrNamPT.Text = ptNam;
            xrNu.Text = nu;
            xrNuPT.Text = ptNu;
        }
    }
}
