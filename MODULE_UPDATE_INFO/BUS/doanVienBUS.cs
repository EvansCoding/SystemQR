using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DTODLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class doanVienBUS
    {
        private static doanVienBUS instance;

        public static doanVienBUS Instance
        {
            get
            {
                if (instance == null) return instance = new doanVienBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool addUser(DOANVIEN dv)
        {
            if (doanVienDAO.Instance.addInfo(dv))
                return true;
            return false;
        }

        public bool updateUser(DOANVIEN dv)
        {
            if (doanVienDAO.Instance.updateInfoDOANVIEN(dv))
                return true;
            return false;
        }
        
        public DOANVIEN getByDOANVIEN(string cmnd)
        {
            DOANVIEN dv = doanVienDAO.Instance.getByDOANVIEN(cmnd);
            if (dv != null)
                return dv;
            else return null;
        }

        public DOANVIEN getByHASHDOANVIEN(string hashing)
        {
            DOANVIEN dv = doanVienDAO.Instance.getByHASHING(hashing);
            if (dv != null)
                return dv;
            return null;
        }

        public bool checkExistedDOANVIEN(string cmnd)
        {
            if (doanVienDAO.Instance.checkExistedDOANVIEN(cmnd) == Constants.GuidNone) return false;
            return true;
        }

        public void displayInfo(GridControl gridControl, string name = null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("colSTT", Type.GetType("System.String"));
            dt.Columns.Add("colCMND", Type.GetType("System.String"));
            dt.Columns.Add("colHOLOT", Type.GetType("System.String"));
            dt.Columns.Add("colTEN", Type.GetType("System.String"));
            dt.Columns.Add("colPHAI", Type.GetType("System.String"));
            dt.Columns.Add("colNGUYENQUAN", Type.GetType("System.String"));
            dt.Columns.Add("colDANTOC", Type.GetType("System.String"));
            dt.Columns.Add("colTONGIAO", Type.GetType("System.String"));
            dt.Columns.Add("colCHUYENMON", Type.GetType("System.String"));
            dt.Columns.Add("colCHINHTRI", Type.GetType("System.String"));
            dt.Columns.Add("colNGAYVAODOAN", Type.GetType("System.String"));
            dt.Columns.Add("colNGAYVAODANG", Type.GetType("System.String"));
            int i = 1;
            foreach (var item in doanVienDAO.Instance.displayInfo(name))
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = i.ToString();
                dataRow[1] = item.CMND;
                dataRow[2] = item.HOLOT;
                dataRow[3] = item.TEN;
                dataRow[4] = item.NAM;
                dataRow[5] = item.NGUYENQUAN;
                dataRow[6] = item.DANTOC;
                dataRow[7] = item.TONGIAO;
                dataRow[8] = item.CMNV;
                dataRow[9] = item.LLCT;
                //   string dateDoan = (DateTime)item.NGAYVAODOAN == null ? "" : item.NGAYVAODOAN.Value.ToString("dd/M/yyyy");
                string dateDoan;
                if (item.NGAYVAODOAN == null)
                    dateDoan = "";
                else dateDoan = item.NGAYVAODOAN.Value.ToString("dd/M/yyyy");
                dataRow[10] = dateDoan;

                string dateDang;
                if (item.NGAYVAODANG == null) dateDang = "";
                else dateDang = item.NGAYVAODANG.Value.ToString("dd/M/yyyy");
                dataRow[11] = dateDang;

                dt.Rows.Add(dataRow);
                i++;
            }
            gridControl.DataSource = dt;
        }

        public bool deleteInfoDOANVIEN(DOANVIEN dv)
        {
            if (doanVienDAO.Instance.deleteInfoDOANVIEN(dv))
                return true;
            return false;
        }

        public DOANVIEN getByHashing(string hashing)
        {
            DOANVIEN dv = doanVienDAO.Instance.getByHASHING(hashing);
            if (dv != null)
                return dv;
            return null;
        }

        public DataTable testList(Guid ID)
        {
            List<DOANVIEN> tam = new List<DOANVIEN>();

            DataTable dt = new DataTable();
            dt.Columns.Add("colTEN", Type.GetType("System.String"));
            dt.Columns.Add("colPIC", typeof(Image));
            dt.Columns.Add("colQR", typeof(Image));

            foreach (var item in chiTietDaiHoiBUS.Instance.exListDOANtoPDF(ID))
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = item.HOLOT.ToUpper() + " " + item.TEN.ToUpper();
                Image image = Image.FromFile(Application.StartupPath + "\\" + "Images\\" + item.CMND + ".jpg");
                dataRow[1] = image;
                image = Image.FromFile(Application.StartupPath + "\\" + "QRCode\\" + item.HASHING + ".jpg");
                dataRow[2] = image;

                dt.Rows.Add(dataRow);
            }

            return dt;
        }
    }
}
