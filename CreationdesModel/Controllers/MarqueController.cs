using CreationdesModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreationdesModel.Controllers
{
    public class MarqueController : Controller
    {
        private readonly Mycontext _context;
        public MarqueController(Mycontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            List<Marque> marques = _context.marques.Include(m => m.Voitures).ToList();
            return View(marques);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Marque m)
        {
            if (ModelState.IsValid)
            {
                _context.marques.Add(m);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult edit(int id)
        {
            Marque marquEdit = _context.marques.Find(id);
            if (marquEdit == null)
            {
                return NotFound();
            }
            return View(marquEdit);
        }
        [HttpPost]
        public IActionResult edit(Marque m)
        {
            
            if (ModelState.IsValid)
            {
                Marque marque = _context.marques.Find(m.Id);
                marque.Libelle = m.Libelle;
                _context.marques.Update(marque);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult delete(int id)
        {
            int nbrMarqueVoitires = _context.Voitures.Where(m => m.marque.Id == id).Count();
            if (nbrMarqueVoitires==0)
            {
            Marque marque = _context.marques.Find(id);
            _context.marques.Remove(marque);
            _context.SaveChangesAsync();
            
            }
            else
            {
                ViewData["error"] = "la mmarque existe";
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite.");
                
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
