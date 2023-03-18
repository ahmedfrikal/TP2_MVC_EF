using CreationdesModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Printing;

namespace CreationdesModel.Controllers
{
    public class AssuranceController : Controller
    {
        private readonly Mycontext _context;
        private static int voitureidmod;
        
        public AssuranceController(Mycontext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(_context.assurances.Include(a=>a.voiture).ToList());
        }
        public IActionResult Add(int id)
        {
            voitureidmod = id;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Assurance assurance)
        {
            assurance.Id = "3";
            assurance.voitureID=voitureidmod;
            _context.assurances.Add(assurance);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(string id)
        {
            Assurance assurance = _context.assurances.Find(id);
            return View(assurance);
        }
        [HttpPost]
        public IActionResult Edit(Assurance assurance)
        {
            Assurance assuranceNv = _context.assurances.Find(assurance.Id);
            assuranceNv.agence = assurance.agence;
            assuranceNv.date_debut = assurance.date_debut;
            assuranceNv.date_fin = assurance.date_fin;
            assuranceNv.prix = assurance.prix;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
            Assurance assuranceNv = _context.assurances.Find(id);
            _context.Remove(assuranceNv);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            }

        }
    }
}
