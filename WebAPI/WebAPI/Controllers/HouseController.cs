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
            var fileName = house.Image!.FileName;
            
            var uniqueFileName = Guid.NewGuid() + "_" + fileName;
            
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uniqueFileName);
            
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                house.Image.CopyTo(fileStream);
            }
            
            var imageUrl = $"https://localhost:7057/images/{uniqueFileName}";
            
            var newHouse = new House
            {
                Address = house.Address,
                Price = house.Price,
                Image = imageUrl
            };
            
            _houses.Add(newHouse);

            return Ok(newHouse);
        }
    }
}
