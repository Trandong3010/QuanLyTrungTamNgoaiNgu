using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
    public class RoomDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
            var list = db.Rooms.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
            return list;
        }

        public Object GetRoomById(int id)
        {
            var list = db.Rooms.Where(x => x.ID == id).SingleOrDefault();
            return list;
        }
        public void Save(Room item)
        {
            try
            {
                var old = db.Rooms.Where(x => x.ID == item.ID).FirstOrDefault();
                if (item.ID == 0)
                {
                    item.IsDelete = false;
                    db.Rooms.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    if (old != null)
                    {
                        old.Name = item.Name;
                        old.Description = item.Description;
                        old.Status = item.Status;
                        old.CodeRoom = item.CodeRoom;
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
            var lst = db.Rooms.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
            if (lst != null)
            {
                lst.IsDelete = true;
                db.SaveChanges();
            }
            return lst;
        }
    }
}