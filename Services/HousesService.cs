using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using SharpList.Repositories;

namespace SharpList.Services
{
    public class HousesService
    {

        private readonly HousesRepository _repo;

        public HousesService(HousesRepository repo)
        {
            _repo = repo;
        }

        internal House CreateHouse(House houseData)
        {
            House house = _repo.CreateHouse(houseData);
            return house;
        }

        internal List<House> GetAllHouses()
        {
            List<House> houses = _repo.GetAllHouses();
            return houses;
        }

        internal House GetHouseById(int houseId)
        {
            House house = _repo.GetHouseById(houseId);
            if (house == null) throw new Exception($"no car with id:{houseId}");
            return house;
        }

        internal string RemoveHouse(int houseId)
        {
            House house = this.GetHouseById(houseId);

            _repo.RemoveHouse(houseId);
            return $"{houseId} was removed";
        }

        internal House UpdateHouse(House updateData)
        {
            House original = this.GetHouseById(updateData.Id);
            original.Sqft = updateData.Sqft != null ? updateData.Sqft : original.Sqft;

            original.Bedrooms = updateData.Bedrooms != null ? updateData.Bedrooms : original.Bedrooms;

            original.Bathrooms = updateData.Bathrooms != null ? updateData.Bathrooms : original.Bathrooms;

            original.ImgUrl = updateData.ImgUrl != null ? updateData.ImgUrl : original.ImgUrl;

            original.Description = updateData.Description != null ? updateData.Description : original.Description;

            original.Price = updateData.Price != null ? updateData.Price : original.Price;

            House house = _repo.UpdateHouse(original);
            return house;
        }
    }
}