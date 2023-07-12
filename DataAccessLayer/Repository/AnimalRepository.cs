using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class AnimalRepository : GenericRepository<Animal>, IAnimalDal
	{
		public AnimalRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
		{
		}
	}
}
