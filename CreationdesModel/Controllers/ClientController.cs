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
            return View(clients);
        }
        public IActionResult clientLocationActive()
        {

            List<ClientAssuranceModelView> clients = _context.clients.Include(m => m.Locations).Select(c => new ClientAssuranceModelView(c)).ToList();
            
            return View(clients);
        }

    }
}
