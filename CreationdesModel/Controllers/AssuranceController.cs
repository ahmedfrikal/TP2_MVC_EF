using CreationdesModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace CreationdesModel.Controllers
{
    public class AssuranceController : Controller
    {
        private readonly Mycontext _context;
        
        public AssuranceController(Mycontext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View(_context.assurances.Include(a=>a.voiture).ToList());
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Assurance assurance)
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
