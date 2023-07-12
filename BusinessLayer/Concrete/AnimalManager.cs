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
	public class AnimalManager : IAnimalService
	{
		private readonly IAnimalDal _animalDal;

		public AnimalManager(IAnimalDal animalDal
			)
		{
			_animalDal = animalDal;
		}

		public Animal GetById(int id)
		{
			return _animalDal.Get(x=>x.AnimalId.Equals(id));
		}

		public Animal GetById(string id)
		{
			return _animalDal.Get(x => x.AnimalId.Equals(id));

		}

		public List<Animal> GetList()
		{
			return _animalDal.GetAll();
		}

		public List<Animal> GetListActiveValues()
		{
			return _animalDal.GetAll(x => x.Status == true);
		}

		public List<Animal> GetListJoinTable()
		{
			return _animalDal.GetAll();
		}

		public void TAdd(Animal model)
		{
			_animalDal.Add(model);	
		}

		public void TRemove(Animal model)
		{
			_animalDal.Delete(model);	
		}

		public void TUpdate(Animal model)
		{
			_animalDal.Update(model);
		}
	}
}
