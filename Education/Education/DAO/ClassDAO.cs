using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
    public class ClassDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
            var list = db.Classes.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
            return list;
        }

        public Object GetClassById(int id)
        {
            var list = db.Classes.Where(x => x.ID == id).SingleOrDefault();
            return list;
        }
        public void Save(Class item)
        {
            try
            {
                var old = db.Classes.Where(x => x.ID == item.ID).FirstOrDefault();
                if (item.ID == 0)
                {
                    item.IsDelete = false;
                    db.Classes.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    if (old != null)
                    {
                        old.CodeClass = item.CodeClass;
                        old.Name = item.Name;
                        old.Description = item.Description;
                        old.Status = item.Status;
                        old.Level = item.Level;
                        old.QuantityOfStudents = item.QuantityOfStudents;
                        old.TotalLessons = item.TotalLessons;
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
            var lst = db.Classes.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
            if (lst != null)
            {
                lst.IsDelete = true;
                db.SaveChanges();
            }
            return lst;
        }
    }
}