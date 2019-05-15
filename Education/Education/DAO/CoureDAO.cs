using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
    public class CoureDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
            var list = db.Courses.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
            return list;
        }



        public Object GetCoursesById(int id)
        {
            var list = db.Courses.Where(x => x.ID == id).SingleOrDefault();
            return list;
        }

        public void Save(Course item)
        {
            try
            {
                var old = db.Courses.Where(x => x.ID == item.ID).FirstOrDefault();
                if (item.ID == 0)
                {
                    item.IsDelete = false;
                    db.Courses.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    if (old != null)
                    {
                        old.CreateTime = DateTime.Now;
                        old.Description = item.Description;
                        old.Name = item.Name;
                        old.Status = item.Status;
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
            var lst = db.Courses.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
            if (lst != null)
            {
                lst.IsDelete = true;
                db.SaveChanges();
            }
            return lst;
        }
    }
}