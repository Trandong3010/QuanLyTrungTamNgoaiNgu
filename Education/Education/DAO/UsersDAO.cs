using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Education.DAO
{
	public class UsersDAO
	{
		QuanLyTrungTamEntities db = new QuanLyTrungTamEntities();
		public Object GetList()
		{
			var list = db.Users.OrderBy(x => x.ID).ToList();
			return list;
		}

		public Object GetUserById(int id)
		{
			var list = db.Users.Where(x => x.ID == id).SingleOrDefault();
			return list;
		}

		public void Save(User item)
		{
			try
			{
				var old = db.Users.Where(x => x.ID == item.ID).FirstOrDefault();
				if (item.ID == 0)
				{
					db.Users.Add(item);
					db.SaveChanges();
				}
				else
				{
					if (old != null)
					{
						old.Username = item.Username;
						old.Password = item.Password;
						old.Email = item.Email;
						db.SaveChanges();
					}
				}

			}
			catch (Exception)
			{

				throw;
			}
			
		}


	}

}