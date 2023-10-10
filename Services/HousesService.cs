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
    }
}