using System.ComponentModel.DataAnnotations.Schema;

namespace CreationdesModel.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Matricule { get; set; }

        public int NbrPortes { get; set; }
        public int NbrPlaces { get; set;}
        public string photo { get; set;}
        public Marque marque { get; set;}
        public int marqueId { get; set; }
        public string couleur { get; set; }
        [NotMapped]
        public float prixAssurance { get; set; }
        [NotMapped]
        public float prixLocation { get; set; }
        public List<Assurance> Assurances { get; set; }
        public List<Location> Locations { get; set; }
        public  float prixTTotal()
        {
            float prix = 0;
            foreach(Assurance assurance in Assurances)
            {
                prix =prix+ assurance.prix;
            }
            return prix;
        } 
    }
}
