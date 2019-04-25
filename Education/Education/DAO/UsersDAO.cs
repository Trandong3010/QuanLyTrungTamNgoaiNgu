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
			var list = db.Users.Where(x=>x.IsDelete == false).OrderBy(x => x.ID).ToList();
			return list;
		}
		/// <summary>
		/// Hàm lấy id vài trò truyền vô chi tiết vai trò để lấy mã của vai trò đó
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Object GetByIDRole(int id)
		{
			var lst = (from a in db.Role_Detail
					  where a.IDRole == id
					  select a.Name).FirstOrDefault<Object>();
			return lst;
		}

		/// <summary>
		/// Lấy id permision
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// 
		public Object GetByIDPermision(int id)
		{
			var lst = (from a in db.Permisions
					   where a.IDUser == id
					   select a.ID.ToString()).FirstOrDefault<Object>();
			return lst;
		}

		/// <summary>
		/// Phân quyền theo chức năng sử dụng join
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// 
		public Object GetPermision(int id)
		{
			var lst = (from a in db.Permision_Detail
					   where a.IDPermision == id
					   select a).FirstOrDefault<Object>();
			return lst;
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
					item.IsDelete = false;
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

		public Object Delete(int id)
		{
			var lst = db.Users.SingleOrDefault(x => x.IsDelete == false && x.ID == id);
			if(lst != null)
			{
				lst.IsDelete = true;
				db.SaveChanges();
			}
			return lst;
		}

		/// <summary>
		/// Hồ sơ cá nhân
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// 
		public Object Profile(int id)
		{
			var lst = db.Staffs.SingleOrDefault(x => x.IDUser == id);
			return lst;
		}

	}

}