using CreationdesModel.Models;
using CreationdesModel.ModelView;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
            var document = new iTextSharp.text.Document();
            // Create a new MemoryStream object to write the PDF bytes to
            var stream = new MemoryStream();
            // Create a new PdfWriter object, passing in the MemoryStream
            var writer = PdfWriter.GetInstance(document, stream);
            // Open the document
            document.Open();
            // Ajouter un tableau pour le panier
            PdfPTable table = new PdfPTable(6);
            PdfPCell cell = new PdfPCell(new Phrase("Votre Facture de location "));
            cell.Colspan = 6;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            table.AddCell("Date debut ");
            table.AddCell("Date Fin");
            table.AddCell("Prix de jour ");
            table.AddCell("Prix total");
            table.AddCell("client");
            table.AddCell("voiture");
            cell = new PdfPCell(new Phrase(locationAdd.datedebut.ToString()));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(locationAdd.datefin.ToString()));
            table.AddCell(cell);
           

            cell = new PdfPCell(new Phrase(location.prix_jour.ToString()));
            table.AddCell(cell);

            TimeSpan diff = (location.date_fin - location.date_debut);
            cell = new PdfPCell(new Phrase((diff * location.prix_jour).ToString()));
            table.AddCell(cell);
            
            string clientNom=context.clients.Find(locationAdd.clientId).prenom;
            cell = new PdfPCell(new Phrase(clientNom));
            table.AddCell(cell);

            string voiture = context.Voitures.Find(voitureId).Matricule;
            cell = new PdfPCell(new Phrase(voiture));
            table.AddCell(cell);


            document.Add(table);
            //Commande
            // Ajouter le panier au document
            document.Close();
            // Return the PDF as a file download
            return File(stream.ToArray(), "application/pdf", "MyPDF.pdf");
            //return RedirectToAction("Index", "Voiture");
        }

    }
}
