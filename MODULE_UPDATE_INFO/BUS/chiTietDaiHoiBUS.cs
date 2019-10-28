using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DTODLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class chiTietDaiHoiBUS
    {
        private static chiTietDaiHoiBUS instance;

        public  static chiTietDaiHoiBUS Instance
        {
            get
            {
                if (instance == null) return instance = new chiTietDaiHoiBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool dsThamDu(Guid maDH, List<DOANVIEN> dv)
        {
            try
            {
                foreach (DOANVIEN item in dv)
                {
                    THAMDUDAIHOI temp = new THAMDUDAIHOI();
                    temp.MASODH = maDH;
                    temp.MASODV = item.MASODV;
                    chiTietDaiHoiDAO.Instance.insertChiTiet(temp);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public List<DOANVIEN> doanVienThamDu(Guid id)
        {
            
            List<DOANVIEN> dsdv = new List<DOANVIEN>();
            foreach (var item in chiTietDaiHoiDAO.Instance.danhDachThamDu(id))
            {
                DOANVIEN dv = doanVienDAO.Instance.getByGUIDDOANVIEN(item);
                if(dv != null)
                {
                    dsdv.Add(dv);
                }
            }
            return dsdv;
        }

        public bool setStatus(Guid idDV, Guid idDH)
        {
            if (chiTietDaiHoiDAO.Instance.setStatus(idDV, idDH) == true)
                return true;
            return false;
        }
        public string getStatus(Guid idDV, Guid idDH)
        {
            if (chiTietDaiHoiDAO.Instance.getStatus(idDV, idDH) == true)
                return "Có";
            return "Vắng";
        }

        public void displayAllInfo(GridControl gridControl, Guid id, GridView gridView, RepositoryItemPictureEdit repositoryItemPictureEdit)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("colSTT1", Type.GetType("System.String"));
                dt.Columns.Add("colHOLOT1", Type.GetType("System.String"));
                dt.Columns.Add("colTEN", Type.GetType("System.String"));
                dt.Columns.Add("colCOMAT", Type.GetType("System.String"));
                dt.Columns.Add("colANH", typeof(Image));

                int i = 1;
                foreach (var item in doanVienThamDu(id))
                {
                    DataRow dataRow = dt.NewRow();
                    dataRow[0] = i.ToString();
                    dataRow[1] = item.HOLOT;
                    dataRow[2] = item.TEN;
                    dataRow[3] = getStatus(item.MASODV, id);
                    dataRow[4] = Image.FromFile(Application.StartupPath + "\\Images\\" + item.CMND + ".jpg");
                    dt.Rows.Add(dataRow);
                    i++;
                }

                gridControl.DataSource = dt;
                repositoryItemPictureEdit = new RepositoryItemPictureEdit();
                repositoryItemPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                repositoryItemPictureEdit.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
                gridControl.RepositoryItems.Add(repositoryItemPictureEdit);
                gridView.Columns["colANH"].ColumnEdit = repositoryItemPictureEdit;
            }
            catch (Exception)
            {
            }

        }

        public List<DOANVIEN> exListDOANtoPDF(Guid id)
        {
            return doanVienThamDu(id);
        }
    }
}
