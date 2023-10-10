using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using SharpList.Services;

namespace SharpList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _housesService;

        public HousesController(HousesService housesService)
        {
            _housesService = housesService;
        }


        [HttpGet]
        public ActionResult<List<House>> GetAllHouses()
        {
            try
            {
                List<House> houses = _housesService.GetAllHouses();
                return Ok(houses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{houseId}")]
        public ActionResult<House> GetHouseById(int houseId)
        {
            try
            {
                House house = _housesService.GetHouseById(houseId);
                return Ok(house);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public ActionResult<House> CreateHouse([FromBody] House houseData)
        {
            try
            {
                House house = _housesService.CreateHouse(houseData);
                return Ok(house);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{houseId}")]
        public ActionResult<string> RemoveHouse(int houseId)
        {
            try
            {
                string message = _housesService.RemoveHouse(houseId);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}