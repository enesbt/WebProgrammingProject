using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class AnimalTypeRepository:GenericRepository<AnimalType>,IAnimalTypeDal
	{
		private readonly ProjectDbContext _projectDbContext;

		public AnimalTypeRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
		{
			_projectDbContext = projectDbContext;
		}

		public List<AnimalType> ListWithAnimal()
		{
			return _projectDbContext.AnimalTypes.Include(x=>x.Animals).ToList();
		}
	}
}
