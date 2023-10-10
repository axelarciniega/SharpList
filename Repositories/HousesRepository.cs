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

        internal House CreateHouse(House houseData)
        {
            string sql = @"
            INSERT INTO houses
            (sqft, bedrooms, bathrooms, imgUrl, description, price)
            VALUES
            (@sqft, @bedrooms, @bathrooms, @imgUrl, @description, @price);
            SELECT * FROM houses WHERE id = LAST_INSERT_ID();
            ";
            House house = _db.Query<House>(sql, houseData).FirstOrDefault();
            return house;
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