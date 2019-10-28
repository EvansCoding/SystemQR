
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DTODLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODULE_UPDATE_INFO
{
    public partial class ftest : XtraForm
    {
        public ftest(Guid ID)
        {
            InitializeComponent();
            id = ID;
        }
        Guid id;
        reportItem reportItem;
        private void ftest_Load(object sender, EventArgs e)
        {
            reportItem = new reportItem();
            reportItem.DataSource = doanVienBUS.Instance.testList(id);
            reportItem.BindList();
            documentViewer1.PrintingSystem = reportItem.PrintingSystem;
            reportItem.CreateDocument();
            exportPDF();

        }

        private void exportPDF(string ID = null)
        {
            reportItem.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportItem.Margins.Bottom = 0;
            reportItem.PrintingSystem.ShowPrintStatusDialog = false;
            reportItem.PrintingSystem.ShowMarginsWarning = false;
            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(reportItem))
            {
                printTool.Report.CreateDocument(false); // <- ADD THIS LINE  
                printTool.PrintingSystem.ExportToPdf(Application.StartupPath + "\\Report\\" + id.ToString() + "_Export.pdf");
            }
        }

    }
}
