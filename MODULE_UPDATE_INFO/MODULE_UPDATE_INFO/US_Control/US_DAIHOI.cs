using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DTODLL;
using MODULE_UPDATE_INFO.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MODULE_UPDATE_INFO.US_Control
{
    public partial class US_DAIHOI : UserControl
    {
        private static List<DOANVIEN> data = new List<DOANVIEN>();

        private static Guid id;

        private static US_DAIHOI instance;

        public static US_DAIHOI Instance
        {
            get
            {
                if (instance == null) return instance = new US_DAIHOI();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private US_DAIHOI()
        {
            InitializeComponent();
        }

        private DataTable openFileExcel()
        {
            OpenFileDialog f = new OpenFileDialog();
            string pathExcel = "";
            pathExcel = f.ShowDialog() == DialogResult.OK ? f.FileName : "";
            tbPathFolderExcel.Text = pathExcel;
            return Classes.ExcelDataBaseHelper.OpenFile(pathExcel);
        }

        private void btnOpenFileExcel_Click(object sender, EventArgs e)
        {
            dataTable = openFileExcel();
        }

        private void refesh()
        {
            BUS.daiHoiBUS.Instance.displayInfo(gridControl1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn muốn lưu thông tin!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DAIHOI dh = new DAIHOI();
                dh.MASODH = GuidComb.GenerateComb();
                id = dh.MASODH;
                dh.CHUDE = tbChuDe.Text;
                dh.NHIEMKY = tbNhiemKy.Text;
                dh.NGAY = dtpNgayDaiHoi.Value;
                dh.TRANGTHAI = cbTrangThai.Checked;
                dh.NGAYTAO = DateTime.Now;
                dh.NGAYCAPNHAT = DateTime.Now;
                BUS.daiHoiBUS.Instance.insertDAIHOI(dh);
                refesh();
                insertUSERtoEXCEL(dh.MASODH);
                saveImage();
                clear();
            }
        }

        private void clear()
        {
            tbChuDe.Clear();
            tbNhiemKy.Clear();
            tbPathFolderExcel.Clear();
            tbPathFolderImages.Clear();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            id = new Guid(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString());
            BUS.chiTietDaiHoiBUS.Instance.displayAllInfo(gridControl2, id, gridView2, repositoryItemPictureEdit1);
        }
        DataTable dataTable = new DataTable(); // openFileExcel();
        private bool insertUSERtoEXCEL(Guid id)
        {

            foreach (DataRow item in dataTable.Rows)
            {
                DOANVIEN dv = new DOANVIEN();
                if (BUS.doanVienBUS.Instance.getByDOANVIEN(item[0].ToString()) == null)
                {
                    dv.MASODV = GuidComb.GenerateComb();
                    dv.CMND = item[0].ToString();
                    dv.HOLOT = item[1].ToString();
                    dv.TEN = item[2].ToString();
                    dv.NAM = item[3].ToString() == "1" ? true : false;
                    dv.NGUYENQUAN = item[4].ToString();
                    dv.DANTOC = item[5].ToString();
                    dv.TONGIAO = item[6].ToString();
                    dv.CMNV = item[7].ToString();
                    dv.LLCT = item[8].ToString();

                    if (String.Empty == item[9].ToString())
                    {
                        dv.NGAYVAODOAN = null;
                    }
                    else
                    {
                        DateTime temp = (DateTime)item[9];
                        dv.NGAYVAODOAN = new DateTime(temp.Year, temp.Month, temp.Day);
                    }
                    if (String.Empty == item[10].ToString())
                    {
                        dv.NGAYVAODANG = null;
                    }
                    else
                    {
                        DateTime temp = (DateTime)item[10];
                        dv.NGAYVAODANG = new DateTime(temp.Year, temp.Month, temp.Day);
                    }

                    dv.GHICHU = null;
                    dv.HASHING = Hash.ComputeSha256Hash(dv.CMND + dv.HOLOT + dv.TEN + dv.NAM);
                    dv.NGAYTAO = DateTime.Now;
                    dv.NGAYCAPNHAT = DateTime.Now;

                    //saveImage(ptbAvatar, tbCMND.Text);
                    QRGenerator.Instance.createQRCode(dv.HASHING);

                    BUS.doanVienBUS.Instance.addUser(dv);

                    refesh();
                    dv = doanVienDAO.Instance.getByDOANVIEN(item[0].ToString());
                    data.Add(dv);
                }
                else
                {
                    dv = doanVienDAO.Instance.getByDOANVIEN(item[0].ToString());
                    data.Add(dv);
                }
            }

            BUS.chiTietDaiHoiBUS.Instance.dsThamDu(id, data);
            data.Clear();
            return true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            refesh();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show("dasfasdf");

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void btnThongKe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show("dasfasdf");
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            float  ptNam,  ptNu;
            int coMat = 0, vangMat = 0, tong , nam = 0, nu = 0;
            fTHONGKE tk = new fTHONGKE();
            List<Guid> guids = chiTietDaiHoiDAO.Instance.danhDachThamDu(id);
            tong = guids.Count;
            foreach (var item in guids)
            {
                bool check = chiTietDaiHoiDAO.Instance.getStatus(item,id);
                if (check) coMat++;
                else vangMat++;

                DOANVIEN dv = doanVienDAO.Instance.getByGUIDDOANVIEN(item);
                if (dv != null)
                    if ((bool)dv.NAM) nam++;
                    else nu++;
            }
            ptNam = ((float)nam / tong) * 100;
            ptNu = ((float)nu / tong) * 100;
            tk.load(tong.ToString(), coMat.ToString(), vangMat.ToString(), nam.ToString(), ptNam.ToString("N2"), nu.ToString(), ptNu.ToString("N2"));
            tk.ShowDialog();

        }

        string[] files;

        private void btnOpenImages_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath);
                    tbPathFolderImages.Text = fbd.SelectedPath;
                }
            }
        }

        private void saveImage()
        {
            try
            {
                foreach (var item in files)
                {
                    string[] name = item.Split('\\');
                    Image image = Image.FromFile(item);
                    image.Save(Application.StartupPath + "\\Images\\" + name[name.Length - 1]);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
            ftest test = new ftest(id);
            test.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void US_DAIHOI_Load(object sender, EventArgs e)
        {
            refesh();
        }
    }
}
