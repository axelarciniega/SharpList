using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace SharpList.Repositories
{
    public class HousesRepository
    {
        private readonly IDbConnection _db;

        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }



        internal List<House> GetAllHouses()
        {
            string sql = "SELECT * FROM houses;";
            List<House> houses = _db.Query<House>(sql).ToList();
            return houses;
        }

        internal House GetHouseById(int houseId)
        {
            string sql = "SELECT * FROM houses WHERE id = @houseId;";
            House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
            return house;
        }
    }
}