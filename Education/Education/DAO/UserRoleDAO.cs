using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
	public class UserRoleDAO
	{
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public Object GetList()
		{
			var list = db.UserRoles.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
			return list;
		}

		public Object GetById(int id)
		{
			var list = db.UserRoles.Where(x => x.ID == id).SingleOrDefault();
			return list;
		}

		public void Save(UserRole item)
		{
			try
			{
				var old = db.UserRoles.Where(x => x.ID == item.ID).FirstOrDefault();
				if (item.ID == 0)
				{
					item.IsDelete = false;
					db.UserRoles.Add(item);
					db.SaveChanges();
				}
				else
				{
					if (old != null)
					{
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
			var lst = db.UserRoles.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
			if (lst != null)
			{
				lst.IsDelete = true;
				db.SaveChanges();
			}
			return lst;
		}
	}
}