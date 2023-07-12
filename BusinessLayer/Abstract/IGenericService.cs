using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		List<T> GetList();
		List<T> GetListJoinTable();
		List<T> GetListActiveValues();
		T GetById(int id);
		T GetById(string id);
		void TAdd(T model);
		void TRemove(T model);
		void TUpdate(T model);
	}
}
