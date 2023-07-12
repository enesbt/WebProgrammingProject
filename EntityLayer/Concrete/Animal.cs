using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Animal
	{
		[Key]
        public int AnimalId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public byte Age { get; set; }
        [MaxLength(200)]
        public string Image { get; set; }

        public bool Status { get; set; }
        public int AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }
        public int AnimalHouseId { get; set; }
        public virtual AnimalHouse AnimalHouse { get; set; }
        public AnimalRequest? AnimalRequest { get; set; }
        public AnimalGive? AnimalGive { get; set; }

	}
}
