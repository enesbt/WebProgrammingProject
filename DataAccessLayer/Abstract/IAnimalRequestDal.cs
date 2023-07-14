using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IAnimalRequestDal:IGenericRepository<AnimalRequest>
	{

		List<AnimalRequest> ListJoinTable();
		List<AnimalRequest> ListById(Expression<Func<AnimalRequest, bool>> filter);
		AnimalRequest GetByIdWithAnimal(Expression<Func<AnimalRequest, bool>> filter);
	}
}
