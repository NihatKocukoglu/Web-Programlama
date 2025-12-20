using Microsoft.AspNetCore.Mvc;
using FCenter.Data;
using FCenter.Models;
using System.Linq;

namespace FCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: Salon Listesi (Anasayfa)
        public IActionResult Index()
        {
            var gyms = _context.Gyms.ToList();
            return View(gyms);
        }

        // CREATE: Formu Göster
        public IActionResult Create() => View();

        // CREATE: Kaydet
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

        // UPDATE: Düzenleme Formu
        public IActionResult Edit(int id)
        {
            var gym = _context.Gyms.Find(id);
            if (gym == null) return NotFound();
            return View(gym);
        }

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

        // DELETE: Silme
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