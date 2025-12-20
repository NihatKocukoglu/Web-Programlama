using Microsoft.AspNetCore.Mvc;
using FCenter.Data;
using FCenter.Models;
using System.Linq;

namespace FCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GymApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GymApi
        // LINQ kullanarak tüm salonları isme göre sıralı getirir
        [HttpGet]
        public IActionResult GetGyms()
        {
            var gyms = _context.Gyms
                               .OrderBy(g => g.Name)
                               .ToList();
            return Ok(gyms);
        }

        // GET: api/GymApi/search?city=İstanbul
        // LINQ kullanarak adreste şehre göre filtreleme yapar
        [HttpGet("search")]
        public IActionResult SearchGyms(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("Lütfen bir şehir adı giriniz.");
            }

            // LINQ Query: Şehir adını içeren ve isme göre sıralanmış veriler
            var result = _context.Gyms
                                 .Where(g => g.Address.Contains(city))
                                 .OrderBy(g => g.Name)
                                 .ToList();

            return Ok(result);
        }
    }
}