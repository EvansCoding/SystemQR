using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTODLL
{
    public class chiTietDaiHoiDAO
    {
        private static chiTietDaiHoiDAO instance;

        public static chiTietDaiHoiDAO Instance
        {
            get
            {
                if (instance == null) return instance = new chiTietDaiHoiDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool insertChiTiet(THAMDUDAIHOI data)
        {
            try
            {
                using(QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    db.THAMDUDAIHOIs.InsertOnSubmit(data);
                    db.SubmitChanges();
                    return true;
                }
            }
           catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return false;
        }
        public bool setStatus(Guid idDV, Guid idDH)
        {
            THAMDUDAIHOI data = new THAMDUDAIHOI();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    data = db.THAMDUDAIHOIs.Where(p => p.MASODH == idDH && p.MASODV == idDV).SingleOrDefault();
                    if(data != null)
                    {
                        data.TRANGTHAI = true;
                        db.SubmitChanges();
                        return true;
                    }

                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool getStatus(Guid idDV, Guid idDH)
        {
            bool check = false;
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    check = db.THAMDUDAIHOIs.Where(p => p.MASODH == idDH && p.MASODV == idDV).Select(c => c.TRANGTHAI).SingleOrDefault();
                    return check;
                }
            }
            catch (Exception)
            {
            }
            return check;
        }

        public List<Guid> danhDachThamDu(Guid id)
        {
            List<Guid> data = new List<Guid>();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    data = db.THAMDUDAIHOIs.Where(p => p.MASODH == id).Select(c => c.DOANVIEN.MASODV).ToList();
                    return data;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }


    }
}
