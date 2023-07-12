using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AnimalTypeManager : IAnimalTypeService
	{
		private readonly IAnimalTypeDal _animalTypeDal;

		public AnimalTypeManager(IAnimalTypeDal animalTypeDal)
		{
			_animalTypeDal = animalTypeDal;
		}

		public AnimalType GetById(int id)
		{
			return _animalTypeDal.Get(x=>x.AnimalTypeId.Equals(id));
		}

		public AnimalType GetById(string id)
		{
			return _animalTypeDal.Get(x => x.AnimalTypeId.Equals(id));

		}

		public List<AnimalType> GetList()
		{
			return _animalTypeDal.GetAll();
		}

		public List<AnimalType> GetListActiveValues()
		{
			return _animalTypeDal.GetAll(x => x.Status == true);
		}

		public List<AnimalType> GetListJoinTable()
		{
			return _animalTypeDal.ListWithAnimal();
		}


		public void TAdd(AnimalType model)
		{
			_animalTypeDal.Add(model);
		}

		public void TRemove(AnimalType model)
		{
			_animalTypeDal.Delete(model);
		}

		public void TUpdate(AnimalType model)
		{
			_animalTypeDal.Update(model);
		}
	}
}
