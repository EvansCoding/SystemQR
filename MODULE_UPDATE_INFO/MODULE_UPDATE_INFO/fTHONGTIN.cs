using DevExpress.XtraEditors;
using DTODLL;
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
    public partial class fTHONGTIN : XtraForm
    {
        public fTHONGTIN()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }
        private static fTHONGTIN instance;

        public delegate void resultHash(String value);

        private string resultHashing;

        public static fTHONGTIN Instance
        {
            get
            {
                if (instance == null) return instance = new fTHONGTIN();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private void SetValue(String value)
        {
            resultHashing = value;
        }

        List<string> ds = new List<string>();
        Queue<DOANVIEN> dvs = new Queue<DOANVIEN>();
        List<DOANVIEN> tam = new List<DOANVIEN>();
        static int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            fDIEMDANH_CAMERA.mothodHasing(SetValue);
            
            if(!ds.Contains(resultHashing) && resultHashing != null)
            {
                ds.Add(resultHashing);
                if (ds != null ) {
                   dvs.Enqueue(BUS.doanVienBUS.Instance.getByHASHDOANVIEN(ds[i++]));
                }
                resultHashing = null;
            }

            for (int j = tam.Count; j < 5; j++)
            {
                if (dvs.Count != 0)
                {
                    DOANVIEN dv = dvs.Dequeue();
                    tam.Add(dv);
                    showClient(dv);
                }
                else break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tam.Count != 0)
            {
                DOANVIEN dv = tam.First(); 
                showMain(dv);
                tam.Remove(dv);

                foreach (Control item in flpAllUser.Controls)
                {
                    flpAllUser.Controls.Remove(item);
                    item.Dispose();
                    break;
                }
            }
        }

        private void showMain(DOANVIEN dv)
        {
            ptbMain.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\" + dv.CMND + ".jpg"); 
        }

        public void showClient(DOANVIEN _clientName)
        {
            Color col = ColorTranslator.FromHtml("#179BD7");
            Label label = new Label()
            {
                ForeColor = col,
                Height = 20,
                Width = 100,
                Text = _clientName.HOLOT +" "+ _clientName.TEN,
                TextAlign = ContentAlignment.TopCenter,
                Left = 25,
                Margin = this.Margin
            };
            var margin = label.Margin;
            margin.Left = 25;
            label.Margin = margin;
            Button btn = new Button()
            {
                Width = 100,
                Height = 100,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = Image.FromFile(Application.StartupPath + "\\Images\\" + _clientName.CMND + ".jpg"),
            };

            btn.Margin = margin;
            FlowLayoutPanel flowLayout = new FlowLayoutPanel()
            {
                Height = 165,
                Width = 150,
            };
            flowLayout.Controls.Add(btn);
            flowLayout.Controls.Add(label);

            flpAllUser.BeginInvoke((Action)(() =>
            {
                flpAllUser.Controls.Add(flowLayout);
            }));
        }
    }
}
