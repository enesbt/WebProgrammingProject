using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ProjectDbContext _projectDbContext;

		public GenericRepository(ProjectDbContext projectDbContext)
		{
			_projectDbContext = projectDbContext;
		}

		public void Add(T entity)
		{
			_projectDbContext.Set<T>().Add(entity);
			_projectDbContext.SaveChanges();
		}

		public void Delete(T entity)
		{
			_projectDbContext.Set<T>().Remove(entity);
			_projectDbContext.SaveChanges();
		}

		public T Get(Expression<Func<T, bool>> expression)
		{
			return _projectDbContext.Set<T>().FirstOrDefault(expression);
		}

		public List<T> GetAll()
		{
			return _projectDbContext.Set<T>().ToList();
		}

		public List<T> GetAll(Expression<Func<T, bool>> expression)
		{
			return _projectDbContext.Set<T>().Where(expression).ToList();
		}

		public void Update(T entity)
		{
			_projectDbContext.Set<T>().Update(entity);
			_projectDbContext.SaveChanges();
		}
	}
}
