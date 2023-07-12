using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AddServices
{
	public static class AddServices
	{
		public static void AddBlServices(this IServiceCollection services)
		{
			services.AddScoped<IAnimalGiveService,AnimalGiveManager>();
			services.AddScoped<IAnimalHouseService,AnimalHouseManager>();
			services.AddScoped<IAnimalRequestService,AnimalRequestManager>();
			services.AddScoped<IAnimalService,AnimalManager>();
			services.AddScoped<IAnimalTypeService,AnimalTypeManager>();
		}
	}
}
