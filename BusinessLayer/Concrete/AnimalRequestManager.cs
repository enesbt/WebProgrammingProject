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
	public class AnimalRequestManager : IAnimalRequestService
	{
		private readonly IAnimalRequestDal _animalRequestDal;

		public AnimalRequestManager(IAnimalRequestDal animalRequestDal)
		{
			_animalRequestDal = animalRequestDal;
		}

        public List<AnimalRequest> GetAnimalRequestById(string id)
        {
			return _animalRequestDal.ListById(x=>x.Id==id);
        }

        public AnimalRequest GetAnimalRequestById(int id)
        {
			return _animalRequestDal.GetByIdWithAnimal(x => x.AnimalRequestId == id);
        }

        public AnimalRequest GetById(int id)
		{
			return _animalRequestDal.Get(x=>x.AnimalRequestId.Equals(id));
		}

		public AnimalRequest GetById(string id)
		{
			return _animalRequestDal.Get(x => x.AnimalRequestId.Equals(id));
		}

		public List<AnimalRequest> GetList()
		{
			return _animalRequestDal.GetAll();
		}

		public List<AnimalRequest> GetListActiveValues()
		{
			return _animalRequestDal.GetAll(x => x.Status == true);
		}

		public List<AnimalRequest> GetListJoinTable()
		{
			return _animalRequestDal.ListJoinTable();
		}

		public void TAdd(AnimalRequest model)
		{
			_animalRequestDal.Add(model);
		}

		public void TRemove(AnimalRequest model)
		{
			_animalRequestDal.Delete(model);
		}

		public void TUpdate(AnimalRequest model)
		{
			_animalRequestDal.Update(model);	
		}
	}
}
