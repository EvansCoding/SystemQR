using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODULE_UPDATE_INFO
{
    public partial class fTHONGKE : XtraForm
    {
        public fTHONGKE()
        {
            InitializeComponent();
        }

        public void load(string tong, string coMat, string vangMat, string nam, string ptNam, string nu, string ptNu)
        {
            rpTHONGKE report = new rpTHONGKE();
            report.load(tong, coMat, vangMat, nam, ptNam, nu, ptNu);
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();

        }
    }
}
