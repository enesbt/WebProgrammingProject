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
	public class AnimalGiveManager:IAnimalGiveService
	{
		private readonly IAnimalGiveDal _animalGiveDal;

		public AnimalGiveManager(IAnimalGiveDal animalGiveDal)
		{
			_animalGiveDal = animalGiveDal;
		}

		public AnimalGive GetById(int id)
		{
			return _animalGiveDal.Get(x=>x.AnimalGiveId.Equals(id));
		}

		public AnimalGive GetById(string id)
		{
			return _animalGiveDal.Get(x => x.AnimalGiveId.Equals(id));
		}

		public List<AnimalGive> GetList()
		{
			return _animalGiveDal.GetAll(); 
		}

		public List<AnimalGive> GetListActiveValues()
		{
			return _animalGiveDal.GetAll(x => x.Status == true);
		}


		public List<AnimalGive> GetListJoinTable()
		{
			return _animalGiveDal.ListJoinTable();
		}

		public void TAdd(AnimalGive model)
		{
			_animalGiveDal.Add(model);
		}

		public void TRemove(AnimalGive model)
		{
			_animalGiveDal.Delete(model);
		}

		public void TUpdate(AnimalGive model)
		{
			_animalGiveDal.Update(model);	
		}
	}
}
