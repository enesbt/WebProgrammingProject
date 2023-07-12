using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.AddServices
{
	public static class AddServices
	{
		public static void AddDalServices(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<ProjectDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Psql")));
			services.AddScoped<IAnimalDal,AnimalRepository>();
			services.AddScoped<IAnimalGiveDal,AnimalGiveRepository>();
			services.AddScoped<IAnimalHouseDal,AnimalHouseRepository>();
			services.AddScoped<IAnimalRequestDal,AnimalRequestRepository>();
			services.AddScoped<IAnimalTypeDal,AnimalTypeRepository>();
			
		}
	}
}
