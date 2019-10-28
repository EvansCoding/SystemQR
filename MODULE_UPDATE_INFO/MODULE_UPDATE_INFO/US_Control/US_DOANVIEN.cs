using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DTODLL;
using MODULE_UPDATE_INFO.Classes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using MODULE_UPDATE_INFO.Properties;

namespace MODULE_UPDATE_INFO.US_Control
{
    public partial class US_DOANVIEN : UserControl
    {
        private static DOANVIEN data;
        private static US_DOANVIEN instance;
        public static US_DOANVIEN Instance
        {
            get
            {
                if (instance == null) return instance = new US_DOANVIEN();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private US_DOANVIEN()
        {
            InitializeComponent();
        }

        #region METHODS
        private void disableInfo()
        {
            btnOpenImage.Enabled = false;
            tbCMND.Enabled = false;
            tbFirstName.Enabled = false;
            tbLastName.Enabled = false;
            cbIsMale.Enabled = false;
            cbbDomicile.Enabled = false;
            cbbNation.Enabled = false;
            cbbReligion.Enabled = false;
            tbSpecialize.Enabled = false;
            tbPolitic.Enabled = false;
            tbUnionistIn.Enabled = false;
            tbLeaguerIn.Enabled = false;
            dtpLeaguerIn.Enabled = false;
            dtpUnionistIn.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Hide();
        }

        private void enabledInfo()
        {
            btnOpenImage.Enabled = true;
            tbCMND.Enabled = true;
            tbFirstName.Enabled = true;
            tbLastName.Enabled = true;
            cbIsMale.Enabled = true;
            cbbDomicile.Enabled = true;
            cbbNation.Enabled = true;
            cbbReligion.Enabled = true;
            tbSpecialize.Enabled = true;
            tbPolitic.Enabled = true;
            tbUnionistIn.Enabled = true;
            tbLeaguerIn.Enabled = true;
            dtpLeaguerIn.Enabled = true;
            dtpUnionistIn.Enabled = true;


        }

        private void clearInfo()
        {
            btnOpenImage.Enabled = true;
            tbCMND.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            cbIsMale.Checked = false;
            cbbDomicile.Text = "";
            cbbNation.Text = "";
            cbbReligion.Text = "";
            tbSpecialize.Clear();
            tbPolitic.Clear();
            tbUnionistIn.Clear();
            tbLeaguerIn.Clear();
            ptbAvatar.BackgroundImage = Resources.imgQuestion;
        }


        private void openImage(PictureBox pictureBox)
        {
            
            OpenFileDialog f = new OpenFileDialog();
            
            f.Filter = "JPG(*.JPG)|*.jpg";
            if(f.ShowDialog() == DialogResult.OK)
            {
               Image File = Image.FromFile(f.FileName);
                pictureBox.BackgroundImage = File;
            }
        }
        
        private void saveImage(PictureBox pictureBox, string tbCMND)
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\Images\\" + tbCMND + ".jpg"))
                {
                    using (Image image = Image.FromFile(Application.StartupPath + "\\Images\\" + tbCMND + ".jpg"))
                    {
                        ptbAvatar.BackgroundImage.Dispose();
                        image.Dispose();
                        File.Delete(Application.StartupPath + "\\Images\\" + tbCMND + ".jpg");
                    }
                }
                pictureBox.BackgroundImage.Save(Application.StartupPath + "\\Images\\" + tbCMND + ".jpg");
            }
            catch (Exception)
            {
            }
            //!File.Exists(Application.StartupPath + "\\Images\\" + tbCMND + ".jpg")//!File.Exists(Application.StartupPath + "\\Images\\" + tbCMND + ".jpg")

        }

        private void displayImage(PictureBox pictureBox, string cmnd)
        {
            try
            {
                string f = Application.StartupPath + "\\" + "Images\\" + cmnd + ".jpg";
                Image File = Image.FromFile(f);
                pictureBox.BackgroundImage = File;
            }
            catch (Exception)
            {
            }

        }

        private bool deleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                XtraMessageBox.Show("File {0} không tồn tại!");
            }
            return false;
        }

        private void refesh()
        {
            BUS.doanVienBUS.Instance.displayInfo(gcInfo);

            clearInfo();
        }

        private void bindDingInfo(string cmnd)
        {
            try
            {
                var dv = BUS.doanVienBUS.Instance.getByDOANVIEN(cmnd);
                tbCMND.Text = dv.CMND;
                tbFirstName.Text = dv.HOLOT;
                tbLastName.Text = dv.TEN;
                cbIsMale.Checked = dv.NAM == false ? false : true;
                cbbDomicile.Text = dv.NGUYENQUAN;
                cbbNation.Text = dv.DANTOC;
                cbbReligion.Text = dv.TONGIAO;
                tbSpecialize.Text = dv.CMNV;
                tbPolitic.Text = dv.LLCT;
                DateTime dateDoan = dv.NGAYVAODOAN == null ? DateTime.Now : dv.NGAYVAODOAN.Value;
                tbUnionistIn.Text = dateDoan.ToString("dd/M/yyyy");
                DateTime dateDang = dv.NGAYVAODANG == null ? DateTime.Now : dv.NGAYVAODANG.Value;
                tbLeaguerIn.Text = dateDang.ToString("dd/M/yyyy");
                displayImage(ptbAvatar, dv.CMND);
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #region EVENTS
        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            openImage(ptbAvatar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn muốn lưu thông tin!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                if (BUS.doanVienBUS.Instance.checkExistedDOANVIEN(tbCMND.Text))
                {
                    DOANVIEN dv = new DOANVIEN();
                    dv.MASODV = GuidComb.GenerateComb();
                    dv.CMND = tbCMND.Text;
                    dv.HOLOT = tbFirstName.Text;
                    dv.TEN = tbLastName.Text;
                    dv.NAM = cbIsMale.Checked;
                    dv.NGUYENQUAN = cbbDomicile.Text;
                    dv.DANTOC = cbbNation.Text;
                    dv.TONGIAO = cbbReligion.Text;
                    dv.CMNV = tbSpecialize.Text;
                    dv.LLCT = tbLeaguerIn.Text;
                    if (String.Empty != tbUnionistIn.Text)
                        dv.NGAYVAODOAN = dtpUnionistIn.Value;
                    else
                        dv.NGAYVAODOAN = null;

                    if (String.Empty != tbLeaguerIn.Text)
                        dv.NGAYVAODANG = dtpLeaguerIn.Value;
                    else
                        dv.NGAYVAODANG = null;
                    dv.GHICHU = null;
                    dv.HASHING = Hash.ComputeSha256Hash(tbCMND.Text + tbFirstName.Text + tbLastName.Text + cbIsMale.Checked);
                    dv.NGAYTAO = DateTime.Now;
                    dv.NGAYCAPNHAT = DateTime.Now;
                    saveImage(ptbAvatar, tbCMND.Text);
                    QRGenerator.Instance.createQRCode(dv.HASHING);

                    BUS.doanVienBUS.Instance.addUser(dv);
                    refesh();
                    gcInfo.Enabled = true;
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Hide();
                }
                else
                {
                    XtraMessageBox.Show("Chứng Minh Nhân Dân Đã Tồn Tại");
                }
            }
            else
            {
                clearInfo();
                gcInfo.Enabled = true;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Hide();

            }
            
        }

        private void gcInfo_ControlAdded(object sender, ControlEventArgs e)
        {
            BUS.doanVienBUS.Instance.displayInfo(gcInfo);
            disableInfo();
            btnSave.Hide();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }


        private void dtpUnionistIn_ValueChanged(object sender, EventArgs e)
        {
            tbUnionistIn.Text = dtpUnionistIn.Value.Day + "/" + dtpUnionistIn.Value.Month + "/" + dtpUnionistIn.Value.Year;
        }


        private void dtpLeaguerIn_ValueChanged(object sender, EventArgs e)
        {
            tbLeaguerIn.Text = dtpLeaguerIn.Value.Day + "/" + dtpLeaguerIn.Value.Month + "/" + dtpLeaguerIn.Value.Year;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearInfo();

            enabledInfo();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            gcInfo.Enabled = false;
            btnSave.Show();
            btnSave.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (BUS.doanVienBUS.Instance.checkExistedDOANVIEN(tbCMND.Text))
            {
                DOANVIEN dv = new DOANVIEN();
                dv.MASODV = data.MASODV;
                dv.CMND = tbCMND.Text;
                dv.HOLOT = tbFirstName.Text;
                dv.TEN = tbLastName.Text;
                dv.NAM = cbIsMale.Checked;
                dv.NGUYENQUAN = cbbDomicile.Text;
                dv.DANTOC = cbbNation.Text;
                dv.TONGIAO = cbbReligion.Text;
                dv.CMNV = tbSpecialize.Text;
                dv.LLCT = tbPolitic.Text;
                if (String.Empty != tbUnionistIn.Text)
                    dv.NGAYVAODOAN = dtpUnionistIn.Value;
                else
                    dv.NGAYVAODOAN = null;

                if (String.Empty != tbLeaguerIn.Text)
                    dv.NGAYVAODANG = dtpLeaguerIn.Value;
                else
                    dv.NGAYVAODANG = null;

                dv.GHICHU = null;
                dv.HASHING = Hash.ComputeSha256Hash(tbCMND.Text + tbFirstName.Text + tbLastName.Text + cbIsMale.Checked);
                dv.NGAYCAPNHAT = DateTime.Now;
                saveImage(ptbAvatar, tbCMND.Text);
                QRGenerator.Instance.createQRCode(dv.HASHING);
                BUS.doanVienBUS.Instance.updateUser(dv);
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                refesh();
            }
            else
            {
                XtraMessageBox.Show("Chứng Minh Nhân Dân Đã Tồn Tại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BUS.doanVienBUS.Instance.deleteInfoDOANVIEN(data);
                ptbAvatar.BackgroundImage.Dispose();
                File.Delete(Application.StartupPath + "\\Images\\" + data.CMND + ".jpg");
                clearInfo();
                refesh();
                if (gcInfo.MainView.RowCount <= 0)
                {
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception)
            {
            }

        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            bindDingInfo(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString());
            data = BUS.doanVienBUS.Instance.getByDOANVIEN(tbCMND.Text);
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            enabledInfo();
        }

        private void tbSeach_TextChanged(object sender, EventArgs e)
        {
            BUS.doanVienBUS.Instance.displayInfo(gcInfo, tbSeach.Text);
        }
        #endregion

    }
}
