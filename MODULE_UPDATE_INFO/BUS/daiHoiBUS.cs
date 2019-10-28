using DevExpress.XtraGrid;
using DTODLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class daiHoiBUS
    {
        private static daiHoiBUS instance;

        public static daiHoiBUS Instance
        {
            get
            {
                if (instance == null) return instance = new daiHoiBUS();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public void displayInfo(GridControl gridControl, string name = null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("colSTT", Type.GetType("System.String"));
            dt.Columns.Add("colCHUDE", Type.GetType("System.String"));
            dt.Columns.Add("colNHIEMKY", Type.GetType("System.String"));
            dt.Columns.Add("colNGAY", Type.GetType("System.String"));
            dt.Columns.Add("colTRANGTHAI", Type.GetType("System.String"));
            dt.Columns.Add("colTHONGKE", Type.GetType("System.String"));
            dt.Columns.Add("colMADH", Type.GetType("System.String"));
            
            int i = 1;
            foreach (var item in daiHoiDAO.Instance.danhSachDaiHoi(name))
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = i.ToString();
                dataRow[1] = item.CHUDE;
                dataRow[2] = item.NHIEMKY;

                string date;
                if (item.NGAY == null)
                    date = "";
                else date = item.NGAY.Value.ToString("dd/M/yyyy");
                dataRow[3] = date;

                dataRow[4] = item.TRANGTHAI;
                dataRow[5] = "";
                dataRow[6] = item.MASODH.ToString();
                dt.Rows.Add(dataRow);
                i++;
            }
            gridControl.DataSource = dt;
        }

        public List<DAIHOI> getDsDH()
        {
            return daiHoiDAO.Instance.danhSachDaiHoi();
        }

        public DAIHOI getDAIHOI(Guid id)
        {
            DAIHOI dh = daiHoiDAO.Instance.getByDAIHOI(id);
            if (dh != null)
                return dh;
            return null;
        }
        public Guid checkExistInfo(Guid id)
        {
            Guid guid = daiHoiDAO.Instance.getByIDDAIHOI(id);
            return guid;
        }

        public bool insertDAIHOI(DAIHOI dh)
        {
            if (daiHoiDAO.Instance.addDaiHoi(dh))
            {
                return true;
            }
            return false;
        }


    }
}
