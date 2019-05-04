using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.DAO
{
	public class PermisionDetailDAO
	{
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public Object GetById(int id)
		{
			var list = db.Permision_Detail.Where(x => x.ID == id).SingleOrDefault();
			return list;
		}

		public void Save(Permision_Detail item)
		{
			try
			{
				var old = db.Permision_Detail.Where(x => x.ID == item.ID).FirstOrDefault();
				if (old != null)
				{
					old.Add = item.Add;
					old.Delete = item.Delete;
					old.Edit = item.Edit;
					db.SaveChanges();
				}

			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}