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
	public class AnimalGiveRepository:GenericRepository<AnimalGive>,IAnimalGiveDal
	{
		private readonly ProjectDbContext _projectDbContext;

		public AnimalGiveRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
		{
			_projectDbContext = projectDbContext;
		}

		public List<AnimalGive> ListJoinTable()
		{
			return _projectDbContext.AnimalGives.Include(x => x.Animal).Include(x => x.AppUser).ToList();
		}
	}
}
