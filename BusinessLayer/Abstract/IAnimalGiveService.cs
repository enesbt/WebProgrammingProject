using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAnimalGiveService:IGenericService<AnimalGive>
	{

        List<AnimalGive> GetAnimalGiveById(string id);
        AnimalGive GetByIdWithAnimal(int id);
    }
}
