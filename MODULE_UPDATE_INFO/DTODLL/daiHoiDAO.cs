using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTODLL
{
    public class daiHoiDAO
    {
        private static daiHoiDAO instance;

        public static daiHoiDAO Instance
        {
            get
            {
                if (instance == null) return instance = new daiHoiDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool addDaiHoi(DAIHOI dh)
        {
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    db.DAIHOIs.InsertOnSubmit(dh);
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

        public Guid getByIDDAIHOI(Guid id)
        {
            DAIHOI dv = new DAIHOI();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DAIHOIs.Where(p => p.MASODH == id).Select(c => c).SingleOrDefault();
                    return dv.MASODH;
                }
            }
            catch (Exception)
            {
            }
            return new Guid("856ba4ba-fa2a-4d20-a0db-4bfa83a178e2");
        }

        public DAIHOI getByDAIHOI(Guid id)
        {
            DAIHOI dv = new DAIHOI();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    dv = db.DAIHOIs.Where(p => p.MASODH == id).Select(c => c).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
        public List<DAIHOI> danhSachDaiHoi(string name = null)
        {
            List<DAIHOI> dh = new List<DAIHOI>();
            try
            {
                using (QLHTDOANVIENDataContext db = new QLHTDOANVIENDataContext())
                {
                    if (name == null) dh = db.DAIHOIs.Select(p => p).ToList();
                    else dh = db.DAIHOIs.Where(c => c.CHUDE.Contains(name)).Select(p => p).ToList();
                    return dh;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
