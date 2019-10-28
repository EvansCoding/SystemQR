using System;
using System.Collections.Generic;
using System.Linq;

namespace DTODLL
{
    public class doanVienDAO
    {
        private static doanVienDAO instance;

        public static doanVienDAO Instance
        {
            get
            {
                if (instance == null) return instance = new doanVienDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool addInfo(DOANVIEN doanVien)
        {
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    db.DOANVIENs.InsertOnSubmit(doanVien);
                    db.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message.ToString());
                return false;
            }
            return true;
        }

        public List<DOANVIEN> displayInfo(string name = null)
        {
            List<DOANVIEN> dv = new List<DOANVIEN>();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    if(name == null)
                        dv = db.DOANVIENs.Select(p => p).ToList();
                    else dv = db.DOANVIENs.Where(c=> c.TEN.Contains(name)).Select(p => p).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return dv;
        }

        public DOANVIEN getByDOANVIEN(string cmnd)
        {
            DOANVIEN dv = null;
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.CMND == cmnd).Select(c => c).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public Guid checkExistedDOANVIEN(string cmnd)
        {
            Guid dv ;
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.CMND == cmnd).Select(c => c.MASODV).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return dv = new Guid("856ba4ba-fa2a-4d20-a0db-4bfa83a178e2");
        }

        public DOANVIEN getByGUIDDOANVIEN(Guid id)
        {
            DOANVIEN dv = new DOANVIEN();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.MASODV == id).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public DOANVIEN getByHASHDOANVIEN(string hasing)
        {
            DOANVIEN dv = new DOANVIEN();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.HASHING == hasing).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public bool updateInfoDOANVIEN(DOANVIEN dv)
        {
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    DOANVIEN data = db.DOANVIENs.Single(p => p.MASODV == dv.MASODV);
                    if(data != null)
                    {
                        data.CMND = dv.CMND;
                        data.HOLOT = dv.HOLOT;
                        data.TEN = dv.TEN;
                        data.NAM = dv.NAM;
                        data.NGUYENQUAN = dv.NGUYENQUAN;
                        data.DANTOC = dv.DANTOC;
                        data.TONGIAO = dv.TONGIAO;
                        data.CMNV = dv.CMNV;
                        data.LLCT = dv.LLCT;
                        data.NGAYVAODOAN = dv.NGAYVAODOAN;
                        data.NGAYVAODANG = dv.NGAYVAODANG;
                        data.NGAYCAPNHAT = dv.NGAYCAPNHAT;
                        data.GHICHU = dv.GHICHU;
                        data.HASHING = dv.HASHING;
                       
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

        public bool deleteInfoDOANVIEN(DOANVIEN dv)
        {
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    DOANVIEN data = db.DOANVIENs.FirstOrDefault(p => p.MASODV == dv.MASODV);
                    db.DOANVIENs.DeleteOnSubmit(data);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public DOANVIEN getByHASHING(string hashing)
        {
            DOANVIEN dv = new DOANVIEN();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.HASHING == hashing).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }


        public List<DOANVIEN> test()
        {
            List<DOANVIEN>  dv = new List<DOANVIEN>();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DOANVIENs.Select(c => c).ToList();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
