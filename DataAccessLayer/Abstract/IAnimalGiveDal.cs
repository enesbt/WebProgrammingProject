using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IAnimalGiveDal:IGenericRepository<AnimalGive>
	{
		List<AnimalGive> ListJoinTable();

        List<AnimalGive> ListById(Expression<Func<AnimalGive, bool>> filter);

        AnimalGive GetByIdWithAnimal(Expression<Func<AnimalGive, bool>> filter);
    }
}
 