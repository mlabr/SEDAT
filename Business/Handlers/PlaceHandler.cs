using Business.BusinessObjects;
using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
	public class PlaceHandler
	{

        public PlaceHandler()
        {
            
        }

        public void InsertPlace(PlaceBo bo)
        {
			var repo = new PlaceRepository();

			var place = new Place();

            //mapping
            place.Name = bo.Name;
            place.Description = bo.Description;
            place.Note = bo.Note;
            place.IsUsed = true;

            repo.Insert(place);
		}

        public List<PlaceBo> GetAll()
        {
            //var repo = new PlaceRepository();
            var repo = new PlaceRepository();
            var placeList = repo.GetAllList();


            var placeBoList = new List<PlaceBo>();
            foreach (var item in placeList)
            { 
                var bo = new PlaceBo();
                bo.Name = item.Name;
                bo.DbId = item.PlaceId;
                bo.Description = item.Description;
                bo.Note = item.Note;
                bo.IsUsed = item.IsUsed;
				placeBoList.Add(bo);
			}

            return placeBoList;
        }

		public PlaceBo GetById(int id)
		{
			var repo = new PlaceRepository();
            var item = repo.Get(id);

			var bo = new PlaceBo();
			bo.Name = item.Name;
			bo.DbId = item.PlaceId;
			bo.Description = item.Description;
			bo.Note = item.Note;
			bo.IsUsed = item.IsUsed;

			return bo;
		}

		public void Delete(int id)
		{
			var repo = new PlaceRepository();
            repo.Delete(id);
		}

		public void Update(PlaceBo bo)
		{
			var repo = new PlaceRepository();

            var item = new Place();
            item.Name = bo.Name;
            item.PlaceId = bo.DbId;
            item.Description = bo.Description;
            item.Note = bo.Note;
            item.IsUsed = bo.IsUsed;
            repo.Update(item);
		}
	}
}
