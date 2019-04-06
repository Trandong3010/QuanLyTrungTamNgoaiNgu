using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
    public class ShiftDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
            var list = db.Shifts.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
            return list;
        }

        public Object GetShiftById(int id)
        {
            var list = db.Shifts.Where(x => x.ID == id).SingleOrDefault();
            return list;
        }
        public void Save(Shift item)
        {
            try
            {
                var old = db.Shifts.Where(x => x.ID == item.ID).FirstOrDefault();
                if (item.ID == 0)
                {
                    item.IsDelete = false;
                    db.Shifts.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    if (old != null)
                    {
                        old.Name = item.Name;
                        old.Description = item.Description;
                        old.Status = item.Status;
                        old.IDRoom = item.IDRoom;
                        old.TimeBegin = item.TimeBegin;
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Object Delete(int id)
        {
            var lst = db.Shifts.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
            if (lst != null)
            {
                lst.IsDelete = true;
                db.SaveChanges();
            }
            return lst;
        }

    }

}