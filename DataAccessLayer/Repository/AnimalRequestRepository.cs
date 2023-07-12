﻿using DataAccessLayer.Abstract;
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
	public class AnimalRequestRepository:GenericRepository<AnimalRequest>,IAnimalRequestDal
	{
		private readonly ProjectDbContext _projectDbContext;

		public AnimalRequestRepository(ProjectDbContext projectDbContext) : base(projectDbContext)
		{
			_projectDbContext = projectDbContext;
		}

		public List<AnimalRequest> ListJoinTable()
		{
			return _projectDbContext.AnimalRequests.Include(x => x.Animal).Include(x => x.AppUser).ToList();
		}
	}
}
