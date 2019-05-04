using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
	public class PermisionDAO
	{
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public Object GetList()
		{
			var list = db.Permisions.Where(x => x.IsDelete == false).OrderBy(x => x.ID).ToList();
			return list;
		}

		public Object GetById(int id)
		{
			var list = db.Permisions.Where(x => x.ID == id).SingleOrDefault();
			return list;
		}

		public void Save(Permision item)
		{
			try
			{
				var old = db.Permisions.Where(x => x.ID == item.ID).FirstOrDefault();
				if (item.ID == 0)
				{
					item.IsDelete = false;
					db.Permisions.Add(item);
					db.SaveChanges();
				}
				else
				{
					if (old != null)
					{
						old.Name = item.Name;
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
			var lst = db.Permisions.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
			if (lst != null)
			{
				lst.IsDelete = true;
				db.SaveChanges();
			}
			return lst;
		}
	}
}