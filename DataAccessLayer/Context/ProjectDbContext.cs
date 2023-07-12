using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class ProjectDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public ProjectDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Animal> Animals { get; set; }
		public DbSet<AnimalGive> AnimalGives { get; set; }
		public DbSet<AnimalHouse> AnimalHouses { get; set; }
		public DbSet<AnimalRequest>AnimalRequests { get; set; }
		public DbSet<AnimalType> AnimalTypes { get; set; }
	}
}
