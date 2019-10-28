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
    using DevExpress.XtraEditors;
    using US_Control;
    public partial class QUANTRI : XtraForm
    {
        public QUANTRI()
        {
            InitializeComponent();
        }

        private void addControlsPanel(Control control)
        {
            control.Dock = DockStyle.Fill;
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(control);
        }

        private void btnUnionist_Click(object sender, EventArgs e)
        {
            addControlsPanel(US_DOANVIEN.Instance);
        }

        private void btnCongress_Click(object sender, EventArgs e)
        {
            addControlsPanel(US_DAIHOI.Instance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fDIEMDANH_CAMERA.Instance.Show();
                fTHONGTIN.Instance.Show();
            }
            catch (Exception)
            {
            }

        }

        private void QUANTRI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
