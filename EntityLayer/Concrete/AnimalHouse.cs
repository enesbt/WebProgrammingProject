using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class AnimalHouse
	{
		[Key]
        public int AnimalHouseId { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(200)]
		public string Adress { get; set; }
        public bool Status { get; set; }
		public ICollection<Animal> Animals { get; set; }
		
	}
}
