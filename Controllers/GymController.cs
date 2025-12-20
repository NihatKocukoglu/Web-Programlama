using Microsoft.AspNetCore.Mvc;
using FCenter.Data;
using FCenter.Models;
using System.Linq;

namespace GymManagement.Controllers
{
    public class GymController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GymController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: Tüm salonları listele
        public IActionResult Index()
        {
            // Veritabanındaki salonları listeye çevirip View'a gönderiyoruz
            var gyms = _context.Gyms.ToList();

            if (gyms == null)
            {
                gyms = new List<Gym>(); // Eğer null ise boş bir liste oluştur ki hata vermesin
            }

            return View(gyms);
        }

        // CREATE: Formu göster
        public IActionResult Create() => View();

        // CREATE: Veriyi kaydet
        [HttpPost]
        public IActionResult Create(Gym gym)
        {
            if (ModelState.IsValid)
            {
                _context.Gyms.Add(gym);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gym);
        }

        // UPDATE: Formu verilerle doldur
        public IActionResult Edit(int id)
        {
            var gym = _context.Gyms.Find(id);
            if (gym == null) return NotFound();
            return View(gym);
        }

        // UPDATE: Güncelleme işlemini yap
        [HttpPost]
        public IActionResult Edit(Gym gym)
        {
            if (ModelState.IsValid)
            {
                _context.Update(gym);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gym);
        }

        // DELETE: Silme işlemi
        public IActionResult Delete(int id)
        {
            var gym = _context.Gyms.Find(id);
            if (gym != null)
            {
                _context.Gyms.Remove(gym);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}