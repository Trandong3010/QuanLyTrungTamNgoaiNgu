using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
    public class TeacherDAO
    {
        QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
        public Object GetList()
        {
            var lst = db.Teachers.ToList();
            return lst;
        }

		public Object GetTeacherById(int id)
		{
			var list = db.Teachers.SingleOrDefault(x => x.ID == id);
			return list;
		}
	}
}