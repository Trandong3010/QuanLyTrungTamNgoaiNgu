using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
    public class StudentDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
            var list = db.Students.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
            return list;
        }

        public Object GetStudentById(int id)
        {
            var list = db.Students.Where(x => x.ID == id).SingleOrDefault();
            return list;
        }

        public void Save(Student item)
        {
            try
            {
                var old = db.Students.Where(x => x.ID == item.ID).FirstOrDefault();
                if (item.ID == 0)
                {
                    item.IsDelete = false;
                    db.Students.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    if (old != null)
                    {
                        //old.Username = item.Username;
                        //old.Password = item.Password;
                        //old.Email = item.Email;
                        //db.SaveChanges();
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
            var lst = db.Students.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
            if (lst != null)
            {
                lst.IsDelete = true;
                db.SaveChanges();
            }
            return lst;
        }
    }
}