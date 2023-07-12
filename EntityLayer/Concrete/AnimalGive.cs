using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class AnimalGive
	{
		[Key]
		public int AnimalGiveId { get; set; }

		public bool Status { get; set; }
		public DateTime time { get; set; }
		[ForeignKey("AppUser")]
		public string Id { get; set; }
		public virtual AppUser AppUser { get; set; }
		public int AnimalId { get; set; }
		public Animal Animal { get; set; }	
	}
}
