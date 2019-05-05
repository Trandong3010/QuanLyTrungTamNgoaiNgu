using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Areas.Admin.Controllers
{
    public class StaffDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
           // var lst = db.Staffs.ToList();
            var lst = db.Staffs.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
            return lst;
        }
        public Object GetStaffById(int id)
        {
            var lst = db.Staffs.SingleOrDefault(x => x.ID == id);
            return lst;
        }
        public void Save(Staff item)
        {
            
            try
            {
                var old = db.Staffs.Where(x => x.ID == item.ID).FirstOrDefault();
                if (item.ID == 0)
                {
                    item.IsDelete = false;
                    item.CreateTime = DateTime.Now;
                    db.Staffs.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    if (old != null)
                    {
                       
                        old.CodeStaff = item.CodeStaff;
                        old.Name = item.Name;
                        old.Description = item.Description;
                        old.Address = item.Address;
                        old.BirthDay = item.BirthDay;
                        old.BirthPlace = item.BirthPlace;
                        old.Gender = item.Gender;
                        old.Position = item.Position;
                        old.Literacy = item.Literacy;
                        old.IDCard = item.IDCard;
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
            var lst = db.Staffs.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
            if (lst != null)
            {
                lst.IsDelete = true;
                db.SaveChanges();
            }
            return lst;
        }

    }
}