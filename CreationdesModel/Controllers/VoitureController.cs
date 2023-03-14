using CreationdesModel.Models;
using CreationdesModel.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CreationdesModel.Controllers
{
    public class VoitureController : Controller
    {
        private readonly Mycontext db;
        public VoitureController(Mycontext db) 
        { 
            this.db = db; 
        }
        public IActionResult Index()
        {
            List<Voiture> voitures = db.Voitures.Include(m => m.marque).Include(m => m.Assurances).Include(m => m.Locations).ToList();
           foreach(Voiture v in voitures)
            {
                float PrixAssurance = 0;
                foreach (Assurance a in v.Assurances)
                {
                    PrixAssurance = PrixAssurance + a.prix;
                }
                v.prixAssurance = PrixAssurance;
                float PrixLocation = 0;
                foreach(Location l in v.Locations)
                {
                    PrixLocation=PrixLocation+l.prix_jour;
                }
                v.prixLocation = PrixLocation;
            }              
            return View(voitures);
        }
        public IActionResult Add()
        {
            ViewBag.citie = db.marques.Select(m => new SelectListItem
            {
                Text = m.Libelle,
                Value = m.Id.ToString(),
            });
          
            return View();
        }
        [HttpPost]
       
        public IActionResult Add(Voiture voiture,IFormFile image)
        {
            string[] extentionImage = new string[] { ".jpeg", ".png", ".jpg" };
            foreach (string item in extentionImage)
            {
                if (image.FileName.EndsWith(item))
                {
                    string fileName = image.FileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    var stream = new FileStream(uploadFilePath, FileMode.Create);
                    image.CopyToAsync(stream);
                    voiture.photo=fileName;
                   
                    db.Voitures.Add(voiture);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public IActionResult update(int id)
        {
            
            Voiture voiture = db.Voitures.Find(id);
            ViewBag.citie = db.marques.Select(m => new SelectListItem
            {
                Text = m.Libelle,
                Value = m.Id.ToString(),
            });

            return View(voiture);
        }
        [HttpPost]

        public IActionResult update(Voiture voiture, IFormFile image)
        {
            Voiture  voitureModif = db.Voitures.Find(voiture.Id);
            voitureModif.Matricule = voiture.Matricule;
            voitureModif.NbrPortes = voiture.NbrPortes;
            voitureModif.NbrPlaces = voiture.NbrPlaces;
            voitureModif.couleur = voiture.couleur;
            voitureModif.marque = voiture.marque;
            if (image == null)
            {
                voitureModif.photo = voiture.photo;
                db.SaveChanges();
            }
            else
            {
                string[] extentionImage = new string[] { ".jpeg", ".png", ".jpg" };
                foreach (string item in extentionImage)
                {
                    if (image.FileName.EndsWith(item))
                    {
                        string fileName = image.FileName;
                        fileName = Path.GetFileName(fileName);
                        string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                        var stream = new FileStream(uploadFilePath, FileMode.Create);
                        image.CopyToAsync(stream);
                        voitureModif.photo = fileName;
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            int voitureAssuranceNombre = db.locations.Where(l => l.Retour == false && l.voitureId==id).Count();
             
            if (voitureAssuranceNombre ==0)
            {
               List<Assurance> assurance = db.assurances.Where(e => e.voitureID.Equals(id)).ToList();
                if (assurance.Count != 0)
                {
                    foreach(Assurance a in assurance)
                    {
                        db.assurances.Remove(a);
                    }
                }
                Voiture voiture = db.Voitures.Find(id);
                db.Voitures.Remove(voiture);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
      
        }
    }
}
