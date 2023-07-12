using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class AppUser: IdentityUser
	{
        public byte Age { get; set; }
		public string Adress { get; set; }
        public ICollection<AnimalRequest> AnimalRequests { get; set; }
		public ICollection<AnimalGive> AnimalGives { get; set; }
	}
}
