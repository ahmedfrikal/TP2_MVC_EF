using System.ComponentModel.DataAnnotations.Schema;

namespace CreationdesModel.Models
{
    public class Assurance
    {
        public string Id { get; set; }
        public string agence { get; set; }
        public DateTime date_debut { get; set; }
        public DateTime date_fin { get; set; }
        public float prix { get; set; }
        public Voiture voiture { get; set; }
        public int voitureID { get; set;}
        [NotMapped]
        public  float prix_total;
    }
}
