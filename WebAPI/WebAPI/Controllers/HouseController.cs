using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private static List<House> _houses = new List<House>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_houses);
        }

        [HttpPost]
        public IActionResult Post([FromForm] AddHouseDTO house)
        {
            return Ok(house);
        }
    }
}
