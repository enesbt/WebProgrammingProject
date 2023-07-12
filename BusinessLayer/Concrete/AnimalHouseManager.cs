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
	public class AnimalHouseManager : IAnimalHouseService
	{
		private readonly IAnimalHouseDal _animalHouseDal;

		public AnimalHouseManager(IAnimalHouseDal animalHouseDal)
		{
			_animalHouseDal = animalHouseDal;
		}

		public AnimalHouse GetById(int id)
		{
			return _animalHouseDal.Get(x => x.AnimalHouseId.Equals(id));
		}

		public AnimalHouse GetById(string id)
		{
			return _animalHouseDal.Get(x => x.AnimalHouseId.Equals(id));
		}

		public List<AnimalHouse> GetList()
		{
			return _animalHouseDal.GetAll();
		}

		public List<AnimalHouse> GetListActiveValues()
		{
			return _animalHouseDal.GetAll(x => x.Status == true);
		}

		public List<AnimalHouse> GetListJoinTable()
		{
			return _animalHouseDal.ListWithAnimal();
		}

		public void TAdd(AnimalHouse model)
		{
			_animalHouseDal.Add(model);
		}

		public void TRemove(AnimalHouse model)
		{
			_animalHouseDal.Delete(model);
		}

		public void TUpdate(AnimalHouse model)
		{
			_animalHouseDal.Update(model);
		}
	}
}
