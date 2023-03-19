using CreationdesModel.Models;
using CreationdesModel.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CreationdesModel.Controllers
{
    public class locationController : Controller
    {
        public readonly Mycontext context;
        private static int voitureId;
        public locationController(Mycontext context)
        {
            this.context = context;
        }
        public IActionResult updateRetour(int id)
        {
            bool retourVoiture = context.locations.Where(e => e.voitureId == id).Select(l => l.Retour).FirstOrDefault();
            if (retourVoiture == false)
            {
                retourVoiture = true;
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Voiture");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            ViewBag.clients = context.clients.Select(m => new SelectListItem
            {
                Text = m.Nom+" "+m.prenom,
                Value = m.Id.ToString(),
            });
            voitureId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Add(LocationAddModelview locationAdd)
        {
            Location location = new Location(locationAdd);
            location.voitureId = voitureId;
            context.locations.Add(location);
            context.SaveChanges();
            return RedirectToAction("Index", "Voiture");
        }

    }
}
