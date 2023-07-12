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
	public class AnimalHouseRepository:GenericRepository<AnimalHouse>,IAnimalHouseDal
	{
		private readonly ProjectDbContext _projectDbContext;

		public AnimalHouseRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
		{
			_projectDbContext = projectDbContext;	
		}

		public List<AnimalHouse> ListWithAnimal()
		{
			return _projectDbContext.AnimalHouses.Include(x => x.Animals).ToList();
		}
	}
}
