using CreationdesModel.Models;
using CreationdesModel.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreationdesModel.Controllers
{
    public class ClientController : Controller
    {
        private readonly Mycontext _context;
        public ClientController(Mycontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            
            List<ClientAssuranceModelView> clients = _context.clients.Include(m => m.Locations).Select(c=>new ClientAssuranceModelView(c)).ToList();
            /*foreach(Client client in clients)
            {
               foreach(Location location in client.Locations)
                {
                 int nbrAssurance = (location.date_fin - location.date_debut).Days;
                 float prix=location.prix_jour*nbrAssurance;
                 client.prixTotal =client.prixTotal + prix;
                }
            }*/

            return View(clients);
        }

    }
}
